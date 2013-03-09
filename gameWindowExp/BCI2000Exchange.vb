Imports BCI2000AutomationLib

Public Class BCI2000Exchange
    Public remote As BCI2000Remote
    Private modules(0 To 2) As String
    Private lastCall As Date
    Private lastSourceTime As Double
    Private Const stateScaling As Integer = 100000
    Private Const stateOffset As Integer = 0 'stateScaling
    Private samplesPerBlock As Double
    Private samplesPerSecond As Double

    Private Const timeRes As UInteger = 10 ' 10 msec is standard. This affects all processes on the OS
    Declare Function timeBeginPeriod Lib "winmm.dll" (uPeriod As UInteger) As Integer
    Declare Function timeEndPeriod Lib "winmm.dll" (uPeriod As UInteger) As Integer

    Private running As Boolean
    Private sourceTime As Double

    Private udpIncoming As Boolean = False
    Private udpOutgoing As Boolean = False

    '----------------------------------------------------------------------------------'
    '---------------------------- BCI2000 setup ---------------------------------------'
    '----------------------------------------------------------------------------------'
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
        timeBeginPeriod(timeRes)
        remote = New BCI2000Remote()
        remote.WindowVisible = 0
        If Not remote.Connect() Then Die()

        modules(0) = "gUSBampSource32Release --local"
        'modules(0) = "SignalGenerator --local" 'TODO: remove
        modules(0) = modules(0) & " --FileFormat=Null"  'TODO: remove

        modules(1) = "DummySignalProcessing --local" 'TODO: eventually, replace this with some real BCI signal processing (such as SpectralSignalProcessing) to do real BCI interaction
        modules(2) = "DummyApplication --local" ' this one can probably be left as is: the song game takes on the role of the application module
        If Not remote.StartupModules(modules) Then Die()

        remote.SubjectID = "JohnnyCash" ' TODO: unify this with the subject ID from the game interface; verify whether/how/when this is propagated forward to the SubjectName parameter
        'TODO: extract useful bits of session info from game and add this info as parameters here - like for example whether right- or left-handed, GameType, Song, GameMode, GameCodeVersion

        ExecuteScript("ADD STATE FingerBotPosF1      32 0")
        ExecuteScript("ADD STATE FingerBotVelF1      32 0")
        ExecuteScript("ADD STATE FingerBotPosF1Lie   32 0")
        ExecuteScript("ADD STATE FingerBotVelF1Lie   32 0")

        ExecuteScript("ADD STATE FingerBotPosF2      32 0")
        ExecuteScript("ADD STATE FingerBotVelF2      32 0")
        ExecuteScript("ADD STATE FingerBotPosF2Lie   32 0")
        ExecuteScript("ADD STATE FingerBotVelF2Lie   32 0")

        ExecuteScript("ADD STATE FingerBotTargetTime 32 0")

        ExecuteScript("SET PARAMETER SamplingRate   600")
        ExecuteScript("SET PARAMETER SampleBlockSize 30") ' defaults: 600Hz sample rate, 20Hz block rate (50ms blocks)
        ExecuteScript("SET PARAMETER VisualizeSource 1")
        ExecuteScript("SET PARAMETER VisualizeTiming 1")

        ExecuteScript("LOAD PARAMETERFILE ../parms/gUSBamp-Cap16.prm")

        'TODO: load any additional BCI2000 parameters (signal-processing?) Flag the parameter-set by encoding in session number? or subject name?

        'TODO: remove this bit, which lets you visualize the FingerBot states-----------------
        Dim expr As String
        expr = "SET PARAMETER Filtering matrix Expressions= { PosF1 VelF1 PosF1Lie VelF1Lie PosF2 VelF2 PosF2Lie VelF2Lie } 1 "  ' TODO: how to change the channel labels output by the ExpressionFilter? these matrix row labels don't work
        expr = expr & " 100*(FingerBotPosF1-" & stateOffset & ")/" & stateScaling
        expr = expr & " 100*(FingerBotVelF1-" & stateOffset & ")/" & stateScaling
        expr = expr & " 100*(FingerBotPosF1Lie-" & stateOffset & ")/" & stateScaling
        expr = expr & " 100*(FingerBotVelF1Lie-" & stateOffset & ")/" & stateScaling
        expr = expr & " 100*(FingerBotPosF2-" & stateOffset & ")/" & stateScaling
        expr = expr & " 100*(FingerBotVelF2-" & stateOffset & ")/" & stateScaling
        expr = expr & " 100*(FingerBotPosF2Lie-" & stateOffset & ")/" & stateScaling
        expr = expr & " 100*(FingerBotVelF2Lie-" & stateOffset & ")/" & stateScaling
        ExecuteScript(expr)
        ExecuteScript("SET PARAMETER VisualizeExpressionFilter 1")
        '----------------------------------------------------------------'

        If Not remote.SetConfig() Then Die()
        Dim tempStr As String = ""
        If Not remote.GetParameter("SamplingRate", tempStr) Then Die()
        samplesPerSecond = CDbl(tempStr)
        If Not remote.GetParameter("SampleBlockSize", tempStr) Then Die()
        samplesPerBlock = CDbl(tempStr)
        If Not remote.Start() Then Die()
        lastSourceTime = -1.23 ' a value that would never be returned by an actual call to remote.GetStateVariable("SourceTime")
        lastCall = Now()
    End Sub

    Private Sub Incoming()

        If udpIncoming Then
            ' TODO: obtain mutex lock, copy the latest line of WATCH output, which has been updated in a separate thread, then unlock the mutex; parse the line into Running and SourceTime (and control signal, if you want)
        Else
            CheckInit()
            Dim systemState As String = "Running"
            If Not remote.GetSystemState(systemState) Then Die()
            running = (systemState = "Running")
            sourceTime = 0
            If Not running Then Return
            If Not remote.GetStateVariable("SourceTime", sourceTime) Then Die()
            'TODO: this is where we would use remote.GetControlSignal(oneBasedChannelIndex, oneBasedElementIndex, byref val as double) to read back from BCI2000 if we were doing true BCI interaction and had a real signal-processing module in place
        End If

    End Sub

    Public Sub SetState(name As String, value As Double)

        If udpOutgoing Then
            'TODO: write to ConnectorInput (shouldn't need a separate thread)
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
        SetState("FingerBotPosF1Lie", secondHand.posF1Lie * stateScaling + stateOffset)
        SetState("FingerBotVelF1Lie", secondHand.velF1Lie * stateScaling + stateOffset)

        SetState("FingerBotPosF2", secondHand.posF2 * stateScaling + stateOffset)
        SetState("FingerBotVelF2", secondHand.velF2 * stateScaling + stateOffset)
        SetState("FingerBotPosF2Lie", secondHand.posF2Lie * stateScaling + stateOffset)
        SetState("FingerBotVelF2Lie", secondHand.velF2Lie * stateScaling + stateOffset)

        SetState("FingerBotTargetTime", secondHand.targetTime)

        'TODO: states that record how far away the three targets are and whether we've just had a miss or a hit
        'TODO: states that record how far away the three targets are and whether we've just had a miss or a hit

        tEnd = Now() : outgoingDuration = tEnd - tStart : tStart = tEnd

        Console.WriteLine("Source module is " & modules(0))
        Console.WriteLine("SamplingRate = " & samplesPerSecond & ";  SampleBlockSize = " & samplesPerBlock & ";   Block duration = " & GetBlockDurationMsec() & "msec")
        Console.Write("Previous event loop period was      ") : Console.WriteLine(updatePeriod)
        Console.Write("Performed incoming operations in    ") : Console.WriteLine(incomingDuration)
        Console.Write("Performed outgoing operations in    ") : Console.WriteLine(outgoingDuration)
        Console.Write("Console writes except for this one: ") : Console.WriteLine(Now() - tStart)

    End Sub
    Public Sub Close()
        If Not (remote Is Nothing) Then remote.Disconnect()
        remote = Nothing
        timeEndPeriod(timeRes)
    End Sub
End Class
