Imports BCI2000AutomationLib

Public Class BCI2000Exchange

#Region "Members"
    Public remote As BCI2000Remote
    Private modules(0 To 2) As String
    Private lastCall As Date
    Private lastSourceTime As Double
    Private Const stateScaling As Integer = 100000
    Private Const stateOffset As Integer = 0 'stateScaling
    Private samplesPerBlock As Double
    Private samplesPerSecond As Double

    Private sampleBlockIndex As UInteger
    Private running As Boolean
    Private sourceTime As Double
    Private controlSignal As Double

    'Private Const timeRes As UInteger = 10 ' 10 msec is standard. This affects all processes on the OS
    'Declare Function timeBeginPeriod Lib "winmm.dll" (uPeriod As UInteger) As Integer
    'Declare Function timeEndPeriod Lib "winmm.dll" (uPeriod As UInteger) As Integer

    Private udpSender As System.Net.Sockets.UdpClient
    Private udpReceiver As System.Net.Sockets.UdpClient
    Private receiverThread As System.Threading.Thread
    Private remoteIPEndPoint As System.Net.IPEndPoint
    Private keepListening As Boolean
    Private watchMessage As String = ""

    Private verbose As Boolean = False
    Private visualize As Boolean = True
    Private udpIncomingPort As Integer = 4567 ' specify port number, or 0 to use BCI2000Automation calls for incoming info instead during the update loop
    Private udpOutgoingPort As Integer = 5678 ' specify port number, or 0 to use BCI2000Automation calls for outgoing info instead during the update loop
    ' TODO: ideally we would get rid of the udp communication and use BCI2000Automation COM calls exclusively, making for much simpler vb code in this file, but currently each interpreter command takes too long to return (Juergen will try to fix this)
#End Region

    Private Sub Die(msg As String)
        Throw New Exception(msg)
    End Sub

    Private Sub Die()
        Die(remote.Result)
    End Sub

    Private Sub CheckInit()
        If remote Is Nothing Then Die("BCI2000Exchange object not initialized")
    End Sub

    Public Sub ExecuteScript(cmd As String)
        CheckInit()
        If remote.Execute(cmd) <> 0 Then Die() ' Execute() returns zero on success, unlike other methods
    End Sub

    Public Function GetBlockDurationMsec()
        Return 1000.0 * samplesPerBlock / samplesPerSecond
    End Function

    Public Sub New(ByRef game As SongGame)
        'timeBeginPeriod(timeRes)
        remote = New BCI2000Remote()
        remote.WindowVisible = 0
        If Not remote.Connect() Then Die()

        modules(0) = "gUSBampSource32Release --local"
        'modules(0) = "SignalGenerator --local" 'TODO: remove
        modules(0) = modules(0) & " --FileFormat=Null"  'TODO: remove

        modules(1) = "DummySignalProcessing --local" 'TODO: eventually, replace this with some real BCI signal processing (such as SpectralSignalProcessing) to do real BCI interaction
        modules(2) = "DummyApplication --local" ' this one can probably be left as is: the song game takes on the role of the application module
        If Not remote.StartupModules(modules) Then Die()

        Console.WriteLine("Current subject is " & currentSub.ID)
        remote.SubjectID = currentSub.ID
        'TODO: extract useful bits of session info from game and add this info as parameters here - like for example whether right- or left-handed, GameType, Song, GameMode, GameCodeVersion

        ExecuteScript("ADD STATE FingerBotPosF1      32 0")
        ExecuteScript("ADD STATE FingerBotVelF1      32 0")
        ExecuteScript("ADD STATE FingerBotPosF2      32 0")
        ExecuteScript("ADD STATE FingerBotVelF2      32 0")

        ExecuteScript("ADD STATE FingerBotTargetTime 32 0")

        ExecuteScript("SET PARAMETER SamplingRate   600")
        ExecuteScript("SET PARAMETER SampleBlockSize 30") ' defaults: 600Hz sample rate, 20Hz block rate (50ms blocks) - but note that .prm file probably overrides these settings
        ExecuteScript("SET PARAMETER VisualizeSource  1")
        ExecuteScript("SET PARAMETER VisualizeTiming  0")

        If udpOutgoingPort Then
            ExecuteScript("SET PARAMETER Connector:Connector%20Input list   ConnectorInputFilter=  1 *")
            ExecuteScript("SET PARAMETER Connector:Connector%20Input string ConnectorInputAddress=   localhost:" & udpOutgoingPort)
        End If

        ExecuteScript("LOAD PARAMETERFILE ../parms/gUSBamp-Cap16.prm")
        'TODO: load any additional BCI2000 parameters (signal-processing?) Flag the parameter-set by encoding in session number? or subject name?

        If visualize Then
            Dim expr As String
            expr = "SET PARAMETER Filtering matrix Expressions= { PosF1 VelF1 PosF2 VelF2 } 1 "  ' TODO: how to change the channel labels output by the ExpressionFilter? these matrix row labels don't work
            expr = expr & " 100*(FingerBotPosF1-" & stateOffset & ")/" & stateScaling
            expr = expr & " 100*(FingerBotVelF1-" & stateOffset & ")/" & stateScaling
            expr = expr & " 100*(FingerBotPosF2-" & stateOffset & ")/" & stateScaling
            expr = expr & " 100*(FingerBotVelF2-" & stateOffset & ")/" & stateScaling
            ExecuteScript(expr)
            ExecuteScript("SET PARAMETER VisualizeExpressionFilter 1")
            ExecuteScript("SET PARAMETER VisualizeSource 1")
            ExecuteScript("SET PARAMETER VisualizeTiming 1")
        End If

        If Not remote.SetConfig() Then Die()

        Dim tempStr As String = ""
        If Not remote.GetParameter("SamplingRate", tempStr) Then Die()
        samplesPerSecond = CDbl(tempStr)
        If Not remote.GetParameter("SampleBlockSize", tempStr) Then Die()
        samplesPerBlock = CDbl(tempStr)
        If udpIncomingPort Then
            CheckInit() : remote.Execute("WATCH Running SourceTime Signal(1,1) AT localhost:" & udpIncomingPort) ' TODO: should be ExecuteScript() but remote.Execute() returns non-zero (indicating failure) and a message "127.0.0.1:4567" - a bug at juergen's end?
        End If

        If Not remote.Start() Then Die()

        If udpIncomingPort Then
            udpReceiver = New System.Net.Sockets.UdpClient(udpIncomingPort)
            remoteIPEndPoint = New System.Net.IPEndPoint(System.Net.IPAddress.Any, udpIncomingPort)
            receiverThread = New System.Threading.Thread(AddressOf ReceiveMessages)
            keepListening = True
            receiverThread.Start()
        End If
        If udpOutgoingPort Then
            udpSender = New System.Net.Sockets.UdpClient()
            udpSender.Connect("localhost", udpOutgoingPort)
        End If

        lastSourceTime = -1.23 ' a value that would never be returned by an actual call to remote.GetStateVariable("SourceTime")
        lastCall = Now()
    End Sub

    Private Sub ReceiveMessages()
        While keepListening
            Dim raw As Byte() = udpReceiver.Receive(remoteIPEndPoint)
            If raw.Length Then
                watchMessage = System.Text.Encoding.ASCII.GetString(raw)
            End If
            System.Threading.Thread.Yield()
        End While
    End Sub

    Private Sub Incoming()

        If udpIncomingPort Then
            Dim delims As Char() = {vbTab}
            Dim substrings As String() = watchMessage.Split(delims) 'TODO: need mutex or not?
            If substrings.Length = 3 Or substrings.Length = 4 Then
                sampleBlockIndex = CUInt(substrings(0))
                running = CBool(substrings(1))
                sourceTime = CDbl(substrings(2))
                If substrings.Length = 4 Then controlSignal = CDbl(substrings(3))
            End If
        Else
            CheckInit()
            Dim systemState As String = "Running"
            If Not remote.GetSystemState(systemState) Then Die()
            running = (systemState = "Running")
            sourceTime = 0
            If Not running Then Return
            If Not remote.GetStateVariable("SourceTime", sourceTime) Then Die()
            remote.GetControlSignal(1, 1, controlSignal) 'TODO: to do true BCI interaction, put a real signal-processing module in place instead of DummySignalProcessing
        End If

    End Sub

    Public Sub SetState(name As String, value As Double)

        If udpOutgoingPort Then
            Dim raw As Byte() = System.Text.Encoding.ASCII.GetBytes(name & " " & value & vbLf)
            udpSender.Send(raw, raw.Length)
        Else
            CheckInit()
            If Not remote.SetStateVariable(name, value) Then Die()
        End If

    End Sub

    Public Sub Update(ByRef secondHand As FingerBot)

        CheckInit()

        Dim tStart, tEnd As Date
        Dim updatePeriod, incomingDuration, outgoingDuration As TimeSpan

        tStart = Now() : updatePeriod = tStart - lastCall : lastCall = tStart

        Incoming()

        tEnd = Now() : incomingDuration = tEnd - tStart : tStart = tEnd

        If sourceTime = lastSourceTime Then Return
        lastSourceTime = sourceTime
        ' TODO: Ideally BCI2000's interpreter needs to be altered to have the capability to set multiple states while ensuring that all the changes happen in the same SampleBlock.
        '       As it is, the sourceTime logic above should approximate this, but only if BCI2000's SampleBlock duration is at least twice the period with which this Sub gets called in the game update loop

        SetState("FingerBotPosF1", secondHand.posF1 * stateScaling + stateOffset)
        SetState("FingerBotVelF1", secondHand.velF1 * stateScaling + stateOffset)
        SetState("FingerBotPosF2", secondHand.posF2 * stateScaling + stateOffset)
        SetState("FingerBotVelF2", secondHand.velF2 * stateScaling + stateOffset)

        SetState("FingerBotTargetTime", secondHand.targetTime)

        'TODO: states that record how far away the three targets are and whether we've just had a miss or a hit

        tEnd = Now() : outgoingDuration = tEnd - tStart : tStart = tEnd

        If verbose Then
            Console.WriteLine("Source module is " & modules(0))
            Console.WriteLine("SamplingRate = " & samplesPerSecond & ";  SampleBlockSize = " & samplesPerBlock & ";   Block duration = " & GetBlockDurationMsec() & "msec")
            Console.Write("Previous event loop period was      ") : Console.WriteLine(updatePeriod)
            Console.Write("Performed incoming operations in    ") : Console.WriteLine(incomingDuration)
            Console.Write("Performed outgoing operations in    ") : Console.WriteLine(outgoingDuration)
            Console.Write("Console writes except for this one: ") : Console.WriteLine(Now() - tStart)
        End If

    End Sub
    Public Sub Close()
        If udpIncomingPort Then
            keepListening = False
            Threading.Thread.Sleep(100)
            udpReceiver.Close()
        End If
        If udpOutgoingPort Then
            udpSender.Close()
        End If
        If Not (remote Is Nothing) Then remote.Disconnect()
        remote = Nothing
        'timeEndPeriod(timeRes)
    End Sub
End Class
