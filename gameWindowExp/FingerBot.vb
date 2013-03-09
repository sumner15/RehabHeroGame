'----------------------------------------------------------------------------------'
'---------------------------------- Robot class -----------------------------------'
'----------------------------------------------------------------------------------'
' this class deals with all communications between the tapperrobot and the VB game

Imports XPCAPICOMLib
Imports GUITAR2COMIFACELib

Imports System.Math
Imports OpenTK
Imports OpenTK.Platform
Imports OpenTK.Graphics.OpenGL
Imports OpenTK.Graphics
Imports System.IO
Public Class FingerBot
    Private protocol_obj As XPCAPICOMLib.xPCProtocol

    Private target_obj As XPCAPICOMLib.xPCTarget
    Private scope_obj As XPCAPICOMLib.xPCScopes
    Private parameters_obj As guitar2pt
    Private signals_obj As guitar2bio
    Private stat As Integer

    Private modelRunning As Boolean = True
    Private forceOn As Boolean = True

    Private Const scopeNum As Integer = 3
    Public rightHandMode As Boolean

    Public posF1 As Single = 0
    Public posF2 As Single = 0
    Public velF1 As Single = 0
    Public velF2 As Single = 0

    Public posF1Lie As Single = 0 'fake position determine by combining true pos and desired pos
    Public posF2Lie As Single = 0
    Public velF1Lie As Single = 0
    Public velF2Lie As Single = 0

    Private f1VisLieWeight() As Single = {0.1, 0.0}
    Private f2VisLieWeight() As Single = {0.1, 0.0}

    Public Kp1 As Single = 8
    Public Kp2 As Single = 8
    Public Kv1 As Single = 0.8
    Public Kv2 As Single = 0.8

    Private sigmaKp As Single = 0.625 '0.5
    Private sigmaKd As Single = 0.05
    Public alpha As Single = 4 '4
    Public visAlpha As Single = 3
    Public visSigma As Single = 0.07

    Private increaseStepKp As Single = alpha * sigmaKp
    Private decreaseStepKp As Single = sigmaKp
    Private increaseStepKd As Single = alpha * sigmaKd
    Private decreaseStepKd As Single = sigmaKd

    Private hitTimeFile As StreamWriter
    Private dataFile As StreamWriter
    Private dataFileOpen As Boolean = 0
    Private fileTimer As New Stopwatch

    Private zeroPos1 As Single = 0
    Private zeroPos2 As Single = 0

    Public targetTime As Single = 0

    '---------------------- graphics related objects --------------------------------
    Private finger1Ball As New FingerBall("ballg", {0.0, 0.0, 0.0}, {0.0, 0.0, 0.0}, 0.25)
    Private finger2Ball As New FingerBall("bally", {0.0, 0.0, 0.0}, {0.0, 0.0, 0.0}, 0.25)
    Private fingers1Ball As New FingerBall("ballb", {0.0, 0.0, 0.0}, {0.0, 0.0, 0.0}, 0.25)
    Private fingers2Ball As New FingerBall("ballb", {0.0, 0.0, 0.0}, {0.0, 0.0, 0.0}, 0.25)
    Private fingerScale As Single = 10

    Private backLine As New Model("cubegreen", {0.0, 0.25, 0.0}, {0.0, 0.0, 0.0}, {2.5, 0.01, 0.01})
    Private targFrontLine As New Model("cube", {0.0, 0.25, 0.0}, {0.0, 0.0, 0.0}, {2.5, 0.01, 0.01})
    Private targBackLine As New Model("cube", {0.0, 0.25, 0.0}, {0.0, 0.0, 0.0}, {2.5, 0.01, 0.01})

    '---------------------- parameters specific to guitar hero game -----------------'
    Private movementSet As Boolean = False
    Public destination As Single = 0.105 ' 0.175
    Private reachtime As Single = 0
    Public startTime As Double = 0

    Private posHitWindow As Single = 0.02
    Private velThreshold As Single = 0.0035

    Private FittsA As Double = 0.0125
    Private FittsB As Double = 0.22
    Private FittsW As Double = posHitWindow * 2
    Public fixedDur As Single = 0.5

    Private hitSet As Boolean = False
    Public hitChanged As Boolean = False
    Public hitString As Integer = 0
    Public hitTime As Single = 0
    Public hitPos As Single = 0

    Private hitSetVis As Boolean = False
    Public hitChangedVis As Boolean = False
    Public hitStringVis As Integer = 0
    Public hitTimeVis As Single = 0
    Public hitPosVis As Single = 0

    Public InPosWindow As Boolean = False
    Public InTimeWindow As Boolean = False

    Public InPosWindowVis As Boolean = False
    Public InTimeWindowVis As Boolean = False

    Private Kdcap() As Single = {0, 7}
    Private Kpcap() As Single = {0, 70}
    Private KpBlock As Single = 20
    Private KdBlock As Single = 0.5

    Public hitSetResetPos As Single = 0.045
    Private gainFileMaker As New GainFileWriter(GAMEPATH & "gainFiles\" & "gains_" & currentSub.ID & String.Format("{0:yyyyMMddhhmmss}", Now) & ".txt")

    Private Const FakeSuccessRate As Boolean = True

#Region "constructors"
    '--------------------------------------------------------------------------------'
    '------------------------------ default contructor ------------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub New()
        protocol_obj = New xPCProtocol
        target_obj = New xPCTarget
        scope_obj = New xPCScopes
        parameters_obj = New guitar2pt
        signals_obj = New guitar2bio

        stat = protocol_obj.Init
        If stat < 0 Then
            MsgBox("Could not load api") 'We can no longer continue.
            End
        End If
        stat = protocol_obj.TcpIpConnect("169.254.201.253", "22222") ' 129.101.53.73
        If (stat = 0) Then MsgBox("failed to connect to xpc target computer" & vbNewLine)
        stat = target_obj.Init(protocol_obj)
        stat = scope_obj.Init(protocol_obj)
        stat = parameters_obj.Init(protocol_obj.Ref)
        stat = signals_obj.Init(protocol_obj.Ref)

        ' now actually load the model to the xpc computer
        stat = target_obj.LoadApp(GAMEPATH, "guitar2")

        Dim setVal(0) As Double
        setVal(0) = -5
        stat = target_obj.SetParam(parameters_obj.learning_rate, setVal)
        setVal(0) = -1
        stat = target_obj.SetParam(parameters_obj.forgetting_rate, setVal)
        setVal(0) = 0.15
        stat = target_obj.SetParam(parameters_obj.gcRate, setVal)

        ' graphics setup
        backLine.useTransparency = True
        backLine.pos(2) = (hitSetResetPos - destination) * fingerScale
        targFrontLine.pos(2) = (-posHitWindow) * fingerScale
        targBackLine.pos(2) = (posHitWindow) * fingerScale

        ' make the duration of the blocked region a bit bigger
        setNoteBlockDur(0.06)

        initializeGains()
    End Sub
#End Region

#Region "settup and shutdown functions"

    '--------------------------------------------------------------------------------'
    '------------------------------- start the model --------------------------------'
    '--------------------------------------------------------------------------------'
    ' actually start the robot
    Public Sub startR()
        createDataFile()
        stat = target_obj.StartApp
        hitTimeFile = New StreamWriter(GAMEPATH & "hitTimeFiles\" & "hittimes_" & currentSub.ID & String.Format("{0:yyyyMMddhhmmss}", Now) & ".txt")
        hitTimeFile.WriteLine("desiredNote" & vbTab & "desiredTime" & vbTab & "actualNote" & vbTab & "actualTime")
        fileTimer.Start()
        checkGravityDir() ' used to determine whether the robot is configured for left hand mode or right hand mode

    End Sub

    '--------------------------------------------------------------------------------'
    '------------------------------- stop the robot ---------------------------------'
    '--------------------------------------------------------------------------------'
    ' actually start the robot
    Public Sub stopR()
        stat = target_obj.StopApp
    End Sub


    '--------------------------------------------------------------------------------'
    '--------------------------- close the communication ----------------------------'
    '--------------------------------------------------------------------------------'
    ' actually start the robot
    Public Sub close()
        gainFileMaker.writeGainFile()
        hitTimeFile.Close()
        closeDataFile()
        protocol_obj.Close()
    End Sub

#End Region

#Region "file writing functions"

    '--------------------------------------------------------------------------------'
    '------------------------------- create data file -------------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub createDataFile()
        dataFileOpen = 1
        'scope_obj.RemScope(scopeNum)
        'scope_obj.AddHostScope(scopeNum)
        'scope_obj.ScopeAddSignal(scopeNum, 37)
        'scope_obj.ScopeAddSignal(scopeNum, 38)
        'scope_obj.ScopeAddSignal(scopeNum, 46)
        'scope_obj.ScopeAddSignal(scopeNum, 49)
        'scope_obj.ScopeAddSignal(scopeNum, 6)
        'scope_obj.ScopeAddSignal(scopeNum, 7)
        'scope_obj.ScopeSetDecimation(scopeNum, 1)
        'Dim signals() As Int16 = scope_obj.ScopeGetSignals(scopeNum, 10)
        'Dim sigString As String = ""
        'For Each signal In signals
        'sigString = sigString & CStr(signal) & " "
        'Next
        
        scope_obj.ScopeSetNumSamples(scopeNum, 4.5 * 60 * 1000)
        scope_obj.ScopeSetDecimation(scopeNum, 1)
        'MsgBox("number of samples is " & CStr(scope_obj.ScopeGetNumSamples(scopeNum)))

        'scope_obj.ScopeSetNumSamples(scopeNum, CInt(5.5 * 60 * 1000)) ' set it up to record for 2.5 minutes without interuption
        dataFile = New System.IO.StreamWriter(GAMEPATH & "dataFiles\" & "positions" & "_" & currentSub.ID & trialStr & String.Format("{0:yyyyMMddhhmmss}", Now) & ".txt")
        dataFile.WriteLine("Pos1" & vbTab & "vel1" & vbTab & "Pos2" & vbTab & "vel2" & vbTab & "pos1d" & vbTab & "pos2d" & vbTab & "kp1" & vbTab & "kd1" & vbTab & "Kp2" & vbTab & "kd2" & vbTab & "time")
    End Sub

    '--------------------------------------------------------------------------------'
    '-------------------------------- close data file -------------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub closeDataFile()
        saveDataChunk()
        dataFileOpen = 0
        dataFile.Close()
    End Sub

    '--------------------------------------------------------------------------------'
    '-------------------------------- save Data chunk -------------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub saveDataChunk()
        If dataFileOpen Then
            Dim scopeState As String
            Dim numSamples As Integer
            Dim signals(12) As Int16
            Dim posGold() As Double
            Dim velGold() As Double
            Dim posBlue() As Double
            Dim velBlue() As Double
            Dim posGoldd() As Double
            Dim posBlued() As Double
            Dim kpGold() As Double
            Dim kvGold() As Double
            Dim kpBlue() As Double
            Dim kvBlue() As Double
            Dim time() As Double
            'Dim scopeNum As Integer = 3 ' I made this availabele to the whole class

            scopeState = scope_obj.ScopeGetState(scopeNum)
            If scopeState = "Acquiring" Then
                stat = scope_obj.ScopeStop(scopeNum)
            End If

            numSamples = scope_obj.ScopeGetNumSamples(scopeNum)
            signals = scope_obj.ScopeGetSignals(scopeNum, 11)

            'Console.Write("signals are ")
            'For Each signal In signals
            'Console.Write(CStr(signal) & vbTab)
            'Next

            posBlue = scope_obj.ScopeGetData(scopeNum, signals(0), 0, numSamples, 1)
            velBlue = scope_obj.ScopeGetData(scopeNum, signals(1), 0, numSamples, 1)
            posGold = scope_obj.ScopeGetData(scopeNum, signals(2), 0, numSamples, 1)
            velGold = scope_obj.ScopeGetData(scopeNum, signals(3), 0, numSamples, 1)
            posBlued = scope_obj.ScopeGetData(scopeNum, signals(4), 0, numSamples, 1)
            posGoldd = scope_obj.ScopeGetData(scopeNum, signals(5), 0, numSamples, 1)
            kpBlue = scope_obj.ScopeGetData(scopeNum, signals(6), 0, numSamples, 1)
            kvBlue = scope_obj.ScopeGetData(scopeNum, signals(7), 0, numSamples, 1)
            kpGold = scope_obj.ScopeGetData(scopeNum, signals(8), 0, numSamples, 1)
            kvGold = scope_obj.ScopeGetData(scopeNum, signals(9), 0, numSamples, 1)
            time = scope_obj.ScopeGetData(scopeNum, signals(10), 0, numSamples, 1)

            For i As Integer = 0 To (numSamples - 1) Step 1
                If rightHandMode Then
                    'dataFile.WriteLine(posGold(i) & vbTab & posBlue(i) & vbTab & posGoldd(i) & vbTab & posBlued(i) & vbTab & forceGold(i) & vbTab & forceBlue(i) & vbTab & time(i))
                    dataFile.WriteLine(posGold(i) & vbTab & velGold(i) & vbTab & posBlue(i) & vbTab & velBlue(i) & vbTab & _
                                       posGoldd(i) & vbTab & posBlued(i) & vbTab & kpGold(i) & vbTab & kvGold(i) & vbTab & kpBlue(i) & vbTab & kvBlue(i) & vbTab & time(i))
                Else
                    'dataFile.WriteLine(posBlue(i) & vbTab & posGold(i) & vbTab & posBlued(i) & vbTab & posGoldd(i) & vbTab & forceBlue(i) & vbTab & forceGold(i) & vbTab & time(i))
                    dataFile.WriteLine(posBlue(i) & vbTab & velBlue(i) & vbTab & posGold(i) & vbTab & velGold(i) & vbTab & _
                                       posBlued(i) & vbTab & posGoldd(i) & vbTab & kpBlue(i) & vbTab & kvBlue(i) & vbTab & kpGold(i) & vbTab & kvGold(i) & vbTab & time(i))
                End If

            Next

            stat = scope_obj.ScopeStart(scopeNum)

        End If
    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------- check if the scope is ready to reset --------------------'
    '--------------------------------------------------------------------------------'
    ' the xpc host scope will only collect data for a specified period of time before it resets. 
    ' I need to catch the scope just before it resets and write the data to a file.
    Public Sub checkScopeReset()
        'Dim scopeNum As Integer = 3   ' made this availabelt to the whole calss
        Dim numSamples As Single
        numSamples = scope_obj.ScopeGetNumSamples(scopeNum)

        If fileTimer.ElapsedMilliseconds > (numSamples - 20) Then
            saveDataChunk()
            fileTimer.Restart()
        End If

    End Sub
#End Region

#Region "functions to set finger movements"
    '--------------------------------------------------------------------------------'
    '-------------------------- set finger 1 movement -------------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub moveFinger1(ByVal targetHitTime As Single)

        Dim setVal(0) As Double
        startTime = targetHitTime
        setVal(0) = targetHitTime

        If rightHandMode Then
            stat = target_obj.SetParam(parameters_obj.hitTimeGold, setVal)
            setVal(0) = reachtime
            stat = target_obj.SetParam(parameters_obj.durationGold, setVal)
            setVal(0) = destination
            stat = target_obj.SetParam(parameters_obj.finalPosGold, setVal)
        Else
            stat = target_obj.SetParam(parameters_obj.hitTimeBlue, setVal)
            setVal(0) = reachtime
            stat = target_obj.SetParam(parameters_obj.durationBlue, setVal)
            setVal(0) = destination
            stat = target_obj.SetParam(parameters_obj.finalPosBlue, setVal)
        End If

    End Sub

    '--------------------------------------------------------------------------------'
    '-------------------------- set finger 2 movement -------------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub moveFinger2(ByVal targetHitTime As Single)

        Dim setVal(0) As Double
        startTime = targetHitTime
        setVal(0) = targetHitTime

        If rightHandMode Then
            stat = target_obj.SetParam(parameters_obj.hitTimeBlue, setVal)
            setVal(0) = reachtime
            stat = target_obj.SetParam(parameters_obj.durationBlue, setVal)
            setVal(0) = destination
            stat = target_obj.SetParam(parameters_obj.finalPosBlue, setVal)
        Else
            stat = target_obj.SetParam(parameters_obj.hitTimeGold, setVal)
            setVal(0) = reachtime
            stat = target_obj.SetParam(parameters_obj.durationGold, setVal)
            setVal(0) = destination
            stat = target_obj.SetParam(parameters_obj.finalPosGold, setVal)
        End If

    End Sub

    Public Sub moveFingersToCurrent(ByVal turnBlockOn As Boolean)

        Dim setVal(0) As Double
        If turnBlockOn Then
            setVal(0) = posF1
            stat = target_obj.SetParam(parameters_obj.blockoffset1, setVal)
            setVal(0) = posF2
            stat = target_obj.SetParam(parameters_obj.blockoffset2, setVal)
        Else
            setVal(0) = 0
            stat = target_obj.SetParam(parameters_obj.blockoffset1, setVal)
            setVal(0) = 0
            stat = target_obj.SetParam(parameters_obj.blockoffset2, setVal)
        End If

    End Sub

    '--------------------------------------------------------------------------------'
    '------------------------ set finger both fingers to move -----------------------'
    '--------------------------------------------------------------------------------'
    Public Sub moveFingers(ByVal targetHitTime As Single)
        Dim setVal(0) As Double
        startTime = targetHitTime
        setVal(0) = targetHitTime
        stat = target_obj.SetParam(parameters_obj.hitTimeBlue, setVal)
        stat = target_obj.SetParam(parameters_obj.hitTimeGold, setVal)
        setVal(0) = reachtime
        stat = target_obj.SetParam(parameters_obj.durationBlue, setVal)
        stat = target_obj.SetParam(parameters_obj.durationGold, setVal)
        setVal(0) = destination
        stat = target_obj.SetParam(parameters_obj.finalPosBlue, setVal)
        stat = target_obj.SetParam(parameters_obj.finalPosGold, setVal)
    End Sub
#End Region

#Region "functions to check for hits"

    ' here's the idea:
    ' if finger1 reaches 0 velocity, then check if the distance between finger 1 and finger 2 is small. If so, then it is a combohit.
    ' otherwise it is a figer 1 hit. Do the same thing with finger 2. if it reaches zero and is close to finer1, then it is a combo. otherwise it is a finger2 hit.
    ' for a finger1 hit, compare the hit position to the desired position and the hit time to the desired time. If the subject used the correct
    ' finger, and hit the note at the right time and at the right place, then the hit counts. otherwise, it's a miss.

    '--------------------------------------------------------------------------------'
    '-------------------------- check for a hit by finger 1 -------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub checkFingerHit(ByRef fretBoard As Fretboard)
        Dim comboHitThresh As Single = 0.04

        If (velF1 < velThreshold) And (posF1 > hitSetResetPos) And Not hitSet Then
            hitChanged = True
            hitSet = True
            hitPos = posF1
            hitTime = targetTime

            ' is it a combo hit?
            If Abs(posF1 - posF2) < comboHitThresh Then  ' combo hit condition
                hitString = 1
            Else
                hitString = 0
            End If

            InTimeWindow = fretBoard.checkHit(hitTime, hitString)

            hitTimeFile.WriteLine(fretBoard.nextNotePos & vbTab & fretBoard.nextNoteTime & vbTab & hitString & vbTab & hitTime)

            If Abs(hitPos - destination) < posHitWindow Then
                InPosWindow = True
            Else
                InPosWindow = False
            End If

            If (InTimeWindow And InPosWindow And Not FakeSuccessRate) Then : fretBoard.triggerFlame(hitString) : End If

            'Console.WriteLine("hit attempt on string " & hitString & " on time?" & " " & InTimeWindow & vbTab & "In target?" & " " & InPosWindow)

        ElseIf (velF2 < velThreshold) And (posF2 > hitSetResetPos) And Not hitSet Then
            hitChanged = True
            hitSet = True
            hitPos = posF2
            hitTime = targetTime

            ' is it a combo hit?
            If Abs(posF1 - posF2) < comboHitThresh Then  ' combo hit condition
                hitString = 1
            Else
                hitString = 2
            End If

            InTimeWindow = fretBoard.checkHit(hitTime, hitString)

            hitTimeFile.WriteLine(fretBoard.nextNotePos & vbTab & fretBoard.nextNoteTime & vbTab & hitString & vbTab & hitTime)

            If Abs(hitPos - destination) < posHitWindow Then
                InPosWindow = True
                'Console.WriteLine("hit attempt on string " & hitString & " in window")
            Else
                InPosWindow = False
                'Console.WriteLine("hit attempt on string " & hitString & " NOT in window")
            End If

            'Console.WriteLine("hit attempt on string " & hitString & " on time?" & " " & InTimeWindow & vbTab & "In target?" & " " & InPosWindow)

            If (InTimeWindow And InPosWindow And Not FakeSuccessRate) Then : fretBoard.triggerFlame(hitString) : End If

        Else
            hitChanged = False
        End If

        If (posF1 <= hitSetResetPos) And (posF2 <= hitSetResetPos) Then
            'If hitSet Then Console.WriteLine("hitSet flag reset")
            hitSet = False
            InPosWindow = False
            InTimeWindow = False

        End If

    End Sub


    '--------------------------------------------------------------------------------'
    '------------------- visual version of the check hit function -------------------'
    '--------------------------------------------------------------------------------'
    Public Sub checkFingerHitVis(ByRef fretBoard As Fretboard)
        Dim comboHitThresh As Single = 0.04

        ' check if the lie has stopped past the line for the first time
        If (velF1Lie < velThreshold) And (posF1Lie > hitSetResetPos) And Not hitSetVis Then
            ' if they have, check if they are in the correct position
            hitSetVis = True
            hitChangedVis = True
            hitSetVis = True
            hitPosVis = posF1Lie
            hitTimeVis = targetTime

            ' is it a combo hit?
            If Abs(posF1Lie - posF2Lie) < comboHitThresh Then  ' combo hit condition
                hitStringVis = 1
            Else
                hitStringVis = 0
            End If

            InTimeWindowVis = fretBoard.checkHit(hitTimeVis, hitStringVis)

            'hitTimeFile.WriteLine(fretBoard.nextNotePos & vbTab & fretBoard.nextNoteTime & vbTab & hitString & vbTab & hitTime)

            If Abs(hitPosVis - destination) < posHitWindow Then
                InPosWindowVis = True
            Else
                InPosWindowVis = False
            End If

            If (InTimeWindowVis And InPosWindowVis And FakeSuccessRate) Then : fretBoard.triggerFlame(hitStringVis) : End If

            'Console.WriteLine("hit attempt on string " & hitString & " on time?" & " " & InTimeWindow & vbTab & "In target?" & " " & InPosWindow)

        ElseIf (velF2Lie < velThreshold) And (posF2Lie > hitSetResetPos) And Not hitSetVis Then
            hitChangedVis = True
            hitSetVis = True
            hitPosVis = posF2Lie
            hitTimeVis = targetTime

            ' is it a combo hit?
            If Abs(posF1Lie - posF2Lie) < comboHitThresh Then  ' combo hit condition
                hitStringVis = 1
            Else
                hitStringVis = 2
            End If

            InTimeWindowVis = fretBoard.checkHit(hitTimeVis, hitStringVis)

            'hitTimeFile.WriteLine(fretBoard.nextNotePos & vbTab & fretBoard.nextNoteTime & vbTab & hitString & vbTab & hitTime)

            If Abs(hitPosVis - destination) < posHitWindow Then
                InPosWindowVis = True
                'Console.WriteLine("hit attempt on string " & hitString & " in window")
            Else
                InPosWindowVis = False
                'Console.WriteLine("hit attempt on string " & hitString & " NOT in window")
            End If

            'Console.WriteLine("hit attempt on string " & hitString & " on time?" & " " & InTimeWindow & vbTab & "In target?" & " " & InPosWindow)

            If (InTimeWindowVis And InPosWindowVis And FakeSuccessRate) Then : fretBoard.triggerFlame(hitStringVis) : End If

        Else
            hitChangedVis = False
        End If

        If (posF1Lie <= hitSetResetPos) And (posF2Lie <= hitSetResetPos) Then
            'If hitSetVis Then Console.WriteLine("hitSet flag reset")
            hitSetVis = False
            InPosWindowVis = False
            InTimeWindowVis = False
        End If

    End Sub


#End Region

#Region "update weights"
    '--------------------------------------------------------------------------------'
    '---------------------- changes the values for the weights ----------------------'
    '--------------------------------------------------------------------------------'
    Public Sub updateWeightsRationmetrically(ByVal blockedTrial As Boolean)
        Dim setVal(0) As Double
        If hitChangedVis And Not blockedTrial Then
            If hitStringVis = 0 Then
                If InPosWindowVis And InTimeWindowVis Then
                    If f1VisLieWeight(0) - visSigma >= 0 Then f1VisLieWeight(0) -= visSigma
                    f1VisLieWeight(1) += visSigma
                    'Console.WriteLine("weight updated to " & f1VisLieWeight(0))
                Else
                    If f1VisLieWeight(1) - visAlpha * visSigma >= 0 Then f1VisLieWeight(1) -= visAlpha * visSigma
                    f1VisLieWeight(0) += visAlpha * visSigma
                    'Console.WriteLine("weight updated to " & f1VisLieWeight(0))
                End If
            ElseIf hitString = 1 Then
                If InPosWindowVis And InTimeWindowVis Then
                    If f1VisLieWeight(0) - visSigma >= 0 Then f1VisLieWeight(0) -= visSigma
                    f1VisLieWeight(1) += visSigma
                    If f2VisLieWeight(0) - visSigma >= 0 Then f2VisLieWeight(0) -= visSigma
                    f2VisLieWeight(1) += visSigma
                    'Console.WriteLine("weight updated to " & f1VisLieWeight(0))
                Else
                    If f1VisLieWeight(1) - visAlpha * visSigma >= 0 Then f1VisLieWeight(1) -= visAlpha * visSigma
                    f1VisLieWeight(0) += visAlpha * visSigma
                    If f2VisLieWeight(1) - visAlpha * visSigma >= 0 Then f2VisLieWeight(1) -= visAlpha * visSigma
                    f2VisLieWeight(0) += visAlpha * visSigma
                    'Console.WriteLine("weight updated to " & f1VisLieWeight(0))
                End If

            ElseIf hitString = 2 Then
                If InPosWindowVis And InTimeWindowVis Then
                    If f2VisLieWeight(0) - visSigma >= 0 Then f2VisLieWeight(0) -= visSigma
                    f2VisLieWeight(1) += visSigma
                    'Console.WriteLine("weight updated to " & f1VisLieWeight(0))
                Else
                    If f2VisLieWeight(1) - visAlpha * visSigma >= 0 Then f2VisLieWeight(1) -= visAlpha * visSigma
                    f2VisLieWeight(0) += visAlpha * visSigma
                    'Console.WriteLine("weight updated to " & f1VisLieWeight(0))
                End If
            End If
            visSigma = 0.995 * visSigma
        End If
    End Sub
#End Region

#Region "update gains"

    '--------------------------------------------------------------------------------'
    '------------ change proportional and differential gains together ---------------'
    '--------------------------------------------------------------------------------'
    Public Sub updateGainsRatiometrically(ByVal blockedTrial As Boolean)
        Dim setVal(0) As Double

        If hitChanged And Not blockedTrial Then
            If hitString = 0 Then
                If InPosWindow And InTimeWindow Then
                    If (Kp1 - decreaseStepKp > Kpcap(0)) Then Kp1 -= decreaseStepKp
                    'Console.WriteLine("decreased gain to " & Kp1)
                Else
                    If (Kp1 + increaseStepKp < Kpcap(1)) Then
                        Kp1 += increaseStepKp
                    Else
                        Kp1 = Kpcap(1)
                    End If
                    'Console.WriteLine("increased gain to " & Kp1)
                End If
            ElseIf hitString = 1 Then
                If InPosWindow And InTimeWindow Then
                    If (Kp1 - decreaseStepKp > Kpcap(0)) Then Kp1 -= decreaseStepKp
                    If (Kp2 - decreaseStepKp > Kpcap(0)) Then Kp2 -= decreaseStepKp
                Else
                    If (Kp1 + increaseStepKp < Kpcap(1)) Then
                        Kp1 += increaseStepKp
                    Else
                        Kp1 = Kpcap(1)
                    End If
                    If (Kp2 + increaseStepKp < Kpcap(1)) Then
                        Kp2 += increaseStepKp
                    Else
                        Kp2 = Kpcap(1)
                    End If
                End If

            ElseIf hitString = 2 Then
                If InPosWindow And InTimeWindow Then
                    If (Kp2 - decreaseStepKp > Kpcap(0)) Then Kp2 -= decreaseStepKp
                Else
                    If (Kp2 + increaseStepKp < Kpcap(1)) Then
                        Kp2 += increaseStepKp
                    Else
                        Kp2 = Kpcap(1)
                    End If
                End If
                'reduce sigma
                sigmaKp = 0.9985 * sigmaKp '0.992
                increaseStepKp = alpha * sigmaKp
                decreaseStepKp = sigmaKp
            End If

            Kv1 = Kp1 / 10
            Kv2 = Kp2 / 10


            If (rightHandMode) Then
                setVal(0) = Kp1 ' this is the gain for the index finger
                stat = target_obj.SetParam(parameters_obj.Kp2, setVal) ' in right hand mode I assign that to kp2
                setVal(0) = Kp2 ' this si the gain for the middle finger
                stat = target_obj.SetParam(parameters_obj.Kp1, setVal)
                setVal(0) = Kv1 ' diff gain for index
                stat = target_obj.SetParam(parameters_obj.Kd2, setVal)
                setVal(0) = Kv2 ' diff gain for middel
                stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
            Else
                setVal(0) = Kp1
                stat = target_obj.SetParam(parameters_obj.Kp1, setVal)
                setVal(0) = Kp2
                stat = target_obj.SetParam(parameters_obj.Kp2, setVal)
                setVal(0) = Kv1
                stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
                setVal(0) = Kv2
                stat = target_obj.SetParam(parameters_obj.Kd2, setVal)
            End If


        ElseIf hitChanged And blockedTrial Then
            setVal(0) = Kp1
            stat = target_obj.SetParam(parameters_obj.Kp1, setVal)
            setVal(0) = Kp2
            stat = target_obj.SetParam(parameters_obj.Kp2, setVal)
            setVal(0) = Kv1
            stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
            setVal(0) = Kv2
            stat = target_obj.SetParam(parameters_obj.Kd2, setVal)


        End If
    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------- update the proportional gains ---------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub updatePGains(ByVal blockedTrial As Boolean)
        Dim setVal(0) As Double

        If hitChanged And Not blockedTrial Then
            If hitString = 0 Then
                If InPosWindow Then
                    If (Kp1 - decreaseStepKp > Kpcap(0)) Then Kp1 -= decreaseStepKp
                    'Console.WriteLine("decreased gain to " & Kp1)
                Else
                    If (Kp1 + increaseStepKp < Kpcap(1)) Then Kp1 += increaseStepKp
                    'Console.WriteLine("increased gain to " & Kp1)
                End If
                setVal(0) = Kp1
                stat = target_obj.SetParam(parameters_obj.Kp1, setVal)
            ElseIf hitString = 1 Then
                If InPosWindow Then
                    If (Kp1 - decreaseStepKp > Kpcap(0)) Then Kp1 -= decreaseStepKp
                    If (Kp2 - decreaseStepKp > Kpcap(0)) Then Kp2 -= decreaseStepKp
                Else
                    If (Kp1 + increaseStepKp < Kpcap(1)) Then Kp1 += increaseStepKp
                    If (Kp2 + increaseStepKp < Kpcap(1)) Then Kp2 += increaseStepKp
                End If
                setVal(0) = Kp1
                stat = target_obj.SetParam(parameters_obj.Kp1, setVal)
                setVal(0) = Kp2
                stat = target_obj.SetParam(parameters_obj.Kp2, setVal)
            ElseIf hitString = 2 Then
                If InPosWindow Then
                    If (Kp2 - decreaseStepKp > Kpcap(0)) Then Kp2 -= decreaseStepKp
                Else
                    If (Kp2 + increaseStepKp < Kpcap(1)) Then Kp2 += increaseStepKp
                End If
                setVal(0) = Kp2
                stat = target_obj.SetParam(parameters_obj.Kp2, setVal)
            End If
        ElseIf hitChanged And blockedTrial Then
            setVal(0) = Kp1
            stat = target_obj.SetParam(parameters_obj.Kp1, setVal)
            setVal(0) = Kp2
            stat = target_obj.SetParam(parameters_obj.Kp2, setVal)
        End If
    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------- update the differential gains ---------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub updateDGains(ByVal inTimeWindow As Boolean, ByVal blockedTrial As Boolean)
        Dim setVal(0) As Double
        If hitChanged And Not blockedTrial Then
            If hitString = 0 Then
                If inTimeWindow Then
                    If (Kv1 - decreaseStepKd > Kdcap(0)) Then Kv1 -= decreaseStepKd
                Else
                    If (Kv1 + increaseStepKd > Kdcap(0)) Then Kv1 += increaseStepKd
                End If
                setVal(0) = Kv1
                stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
            ElseIf hitString = 1 Then
                If inTimeWindow Then
                    If (Kv1 - decreaseStepKd > Kdcap(0)) Then Kv1 -= decreaseStepKd
                    If (Kv2 - decreaseStepKd > Kdcap(0)) Then Kv2 -= decreaseStepKd
                    setVal(0) = Kv1
                    stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
                    setVal(0) = Kv2
                    stat = target_obj.SetParam(parameters_obj.Kd2, setVal)
                Else
                    If (Kv1 + increaseStepKd < Kdcap(1)) Then Kv1 += increaseStepKd
                    If (Kv2 + increaseStepKd < Kdcap(1)) Then Kv2 += increaseStepKd
                    setVal(0) = Kv1
                    stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
                    setVal(0) = Kv2
                    stat = target_obj.SetParam(parameters_obj.Kd2, setVal)
                End If
            ElseIf hitString = 2 Then
                If inTimeWindow Then
                    If (Kv2 - decreaseStepKd > Kdcap(0)) Then Kv2 -= decreaseStepKd
                Else
                    If (Kv2 + increaseStepKd > Kdcap(0)) Then Kv2 += increaseStepKd
                End If
                setVal(0) = Kv2
                stat = target_obj.SetParam(parameters_obj.Kd2, setVal)
            End If
        ElseIf hitChanged And blockedTrial Then
            setVal(0) = Kv1
            stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
            setVal(0) = Kv2
            stat = target_obj.SetParam(parameters_obj.Kd2, setVal)
        End If
    End Sub

    '--------------------------------------------------------------------------------'
    '--------------------------- update the gain file -------------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub updateGainFile()
        If rightHandMode Then
            If hitChanged Then
                If hitString = 0 Then
                    gainFileMaker.storeGainsF1(Kp2, Kv2, targetTime)
                ElseIf hitString = 1 Then
                    gainFileMaker.storeGainsF1(Kp2, Kv2, targetTime)
                    gainFileMaker.storeGainsF2(Kp1, Kv1, targetTime)
                ElseIf hitString = 2 Then
                    gainFileMaker.storeGainsF2(Kp1, Kv1, targetTime)
                End If
            End If
        Else
            If hitChanged Then
                If hitString = 0 Then
                    gainFileMaker.storeGainsF1(Kp1, Kv1, targetTime)
                ElseIf hitString = 1 Then
                    gainFileMaker.storeGainsF1(Kp1, Kv1, targetTime)
                    gainFileMaker.storeGainsF2(Kp2, Kv2, targetTime)
                ElseIf hitString = 2 Then
                    gainFileMaker.storeGainsF2(Kp2, Kv2, targetTime)
                End If
            End If
        End If

    End Sub

    '--------------------------------------------------------------------------------'
    '------------------------------------- increase gains ---------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub increaseGains(ByRef stringNum As Integer)
        If stringNum = positions(0) Then
            incramentGainsF1()
        ElseIf stringNum = positions(1) Then
            incramentGainsF1()
            incramentGainsF2()
        ElseIf stringNum = positions(2) Then
            incramentGainsF2()
        End If
    End Sub

    '--------------------------------------------------------------------------------'
    '------------------------------------- decrease gains ---------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub decreaseGains(ByRef stringNum As Integer)
        If stringNum = positions(0) Then
            decramentGainsF1()
        ElseIf stringNum = positions(1) Then
            decramentGainsF1()
            decramentGainsF2()
        ElseIf stringNum = positions(2) Then
            decramentGainsF2()
        End If
    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------------- incrament gains finger 1 --------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub incramentGainsF1()
        Dim setVal(0) As Double
        If (Kp1 + increaseStepKp < Kpcap(1)) Then
            Kp1 += increaseStepKp
        Else
            Kp1 = Kpcap(1)
        End If
        Kv1 = Kp1 / 10

        setVal(0) = Kp1

        If rightHandMode Then
            stat = target_obj.SetParam(parameters_obj.Kp2, setVal) ' backwards in right hand mode (gold is Kp2 and Kd2)
            setVal(0) = Kv1
            stat = target_obj.SetParam(parameters_obj.Kd2, setVal)
            'Console.WriteLine("gain incramented to " & Kp1)
        Else
            stat = target_obj.SetParam(parameters_obj.Kp1, setVal)
            setVal(0) = Kv1
            stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
            'Console.WriteLine("gain incramented to " & Kp1)
        End If

    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------------- incrament gains finger 2 --------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub incramentGainsF2()
        Dim setVal(0) As Double
        If (Kp2 + increaseStepKp < Kpcap(1)) Then
            Kp2 += increaseStepKp
        Else
            Kp2 = Kpcap(1)
        End If
        Kv2 = Kp2 / 10

        If rightHandMode Then
            setVal(0) = Kp2
            stat = target_obj.SetParam(parameters_obj.Kp1, setVal) ' kp1 and kd1 corespond to the blue finger this is the bottom finger in righthand mode
            setVal(0) = Kv2
            stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
        Else
            setVal(0) = Kp2
            stat = target_obj.SetParam(parameters_obj.Kp2, setVal)
            setVal(0) = Kv2
            stat = target_obj.SetParam(parameters_obj.Kd2, setVal)
        End If

    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------------- decrament gains finger 1 --------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub decramentGainsF1()
        Dim setVal(0) As Double
        If (Kp1 - decreaseStepKp > Kpcap(0)) Then Kp1 -= decreaseStepKp
        Kv1 = Kp1 / 10
        setVal(0) = Kp1

        If rightHandMode Then
            stat = target_obj.SetParam(parameters_obj.Kp2, setVal) ' backwards in right hand mode (gold is Kp2 and Kd2)
            setVal(0) = Kv1
            stat = target_obj.SetParam(parameters_obj.Kd2, setVal)
            'Console.WriteLine("gain incramented to " & Kp1)
        Else
            stat = target_obj.SetParam(parameters_obj.Kp1, setVal)
            setVal(0) = Kv1
            stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
            'Console.WriteLine("gain incramented to " & Kp1)
        End If

    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------------- decrament gains finger 2 --------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub decramentGainsF2()
        Dim setVal(0) As Double
        If (Kp2 - decreaseStepKp > Kpcap(0)) Then Kp2 -= decreaseStepKp
        Kv2 = Kp2 / 10
        setVal(0) = Kp2

        If rightHandMode Then
            stat = target_obj.SetParam(parameters_obj.Kp1, setVal) ' backwards in right hand mode (gold is Kp2 and Kd2)
            setVal(0) = Kv2
            stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
            'Console.WriteLine("gain incramented to " & Kp2)
        Else
            stat = target_obj.SetParam(parameters_obj.Kp2, setVal)
            setVal(0) = Kv2
            stat = target_obj.SetParam(parameters_obj.Kd2, setVal)
            'Console.WriteLine("gain incramented to " & Kp2)
        End If

    End Sub

    '--------------------------------------------------------------------------------'
    '--------------------- set the special gains for blocking -----------------------'
    '--------------------------------------------------------------------------------'
    Public Sub setBlockingGains()
        Dim setVal(0) As Double
        setVal(0) = KpBlock
        stat = target_obj.SetParam(parameters_obj.Kp1, setVal)
        stat = target_obj.SetParam(parameters_obj.Kp2, setVal)

        setVal(0) = KdBlock
        stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
        stat = target_obj.SetParam(parameters_obj.Kd2, setVal)
        'Console.WriteLine("Kp1 set to blocking gain of " & KpBlock)
    End Sub

    '--------------------------------------------------------------------------------'
    '------------------ set superbig special gains for blocking ---------------------'
    '--------------------------------------------------------------------------------'
    Public Sub setBigBlockingGains()
        Dim setVal(0) As Double
        setVal(0) = 60
        stat = target_obj.SetParam(parameters_obj.Kp1, setVal)
        stat = target_obj.SetParam(parameters_obj.Kp2, setVal)

        setVal(0) = 6
        stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
        stat = target_obj.SetParam(parameters_obj.Kd2, setVal)
        'Console.WriteLine("Kp1 set to blocking gain of " & KpBlock)
    End Sub

    '--------------------------------------------------------------------------------'
    '------------------------------ turn on noteblock signal ------------------------'
    '--------------------------------------------------------------------------------'
    ' turn on the note blocker (put blocked region inside of a trajectory)
    Public Sub noteBlockerOn(ByVal fNum As Integer)
        Dim setVal() As Double = {1}
        If fNum = 1 And rightHandMode Then
            stat = target_obj.SetParam(parameters_obj.blockComGold, setVal)
        ElseIf fNum = 2 And rightHandMode Then
            stat = target_obj.SetParam(parameters_obj.blockComBlue, setVal)
        ElseIf fNum = 1 And Not rightHandMode Then
            stat = target_obj.SetParam(parameters_obj.blockComBlue, setVal)
        Else
            stat = target_obj.SetParam(parameters_obj.blockComGold, setVal)
        End If
    End Sub

    '--------------------------------------------------------------------------------'
    '--------------------------------- set noteblock amount -------------------------'
    '--------------------------------------------------------------------------------'
    ' this controls how long the blocked period is. smaller numbers mean a longer block ... sorry about that, that was kind of dumb
    Private Sub setNoteBlockDur(ByVal num As Double)
        Dim setVal(0) As Double
        setVal(0) = num
        stat = target_obj.SetParam(parameters_obj.blockThresh, setVal)
    End Sub

    '--------------------------------------------------------------------------------'
    '----------------------------- turn off noteblock signal ------------------------'
    '--------------------------------------------------------------------------------'
    ' turn on the note blocker (put blocked region inside of a trajectory)
    Public Sub noteBlockerOff()
        Dim setVal() As Double = {0}
        stat = target_obj.SetParam(parameters_obj.blockComBlue, setVal)
        stat = target_obj.SetParam(parameters_obj.blockComGold, setVal)
    End Sub

    '--------------------------------------------------------------------------------'
    '------------------- reset the gains to their previous values -------------------'
    '--------------------------------------------------------------------------------'
    Public Sub returnToCurrentGains()
        Dim setVal(0) As Double
        setVal(0) = Kp1
        stat = target_obj.SetParam(parameters_obj.Kp1, setVal)
        setVal(0) = Kp2
        stat = target_obj.SetParam(parameters_obj.Kp2, setVal)

        setVal(0) = Kv1
        stat = target_obj.SetParam(parameters_obj.Kd1, setVal)
        setVal(0) = Kv2
        stat = target_obj.SetParam(parameters_obj.Kd2, setVal)
        'Console.WriteLine("Kp1 setBack to " & Kp1)
    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------- attribute gains to curerent subject ---------------------'
    '--------------------------------------------------------------------------------'
    Public Sub attributeGainsToSubject()

        If rightHandMode Then
            currentSub.Kp1 = Kp2
            currentSub.Kp2 = Kp1
            currentSub.Kd1 = Kv2
            currentSub.Kd2 = Kv1
            currentSub.update()
        Else
            currentSub.Kp1 = Kp1
            currentSub.Kp2 = Kp2
            currentSub.Kd1 = Kv1
            currentSub.Kd2 = Kv2
            currentSub.update()
        End If


    End Sub

    '--------------------------------------------------------------------------------'
    '----------------------- initialize gains from subject file ---------------------'
    '--------------------------------------------------------------------------------'
    Public Sub initializeGains()
        Dim setVal(0) As Double
        'Kp1 = currentSub.Kp1
        'Kv1 = currentSub.Kd1
        'Kp2 = currentSub.Kp2
        'Kv2 = currentSub.Kd2
        setVal(0) = Kp1
        target_obj.SetParam(parameters_obj.Kp1, setVal)
        setVal(0) = Kp2
        target_obj.SetParam(parameters_obj.Kp2, setVal)
        setVal(0) = Kv1
        target_obj.SetParam(parameters_obj.Kd1, setVal)
        setVal(0) = Kv2
        target_obj.SetParam(parameters_obj.Kd2, setVal)
    End Sub

#End Region

#Region "gameflow related commands sadly not used"
    '--------------------------------------------------------------------------------'
    '------------------ check if the are past the hit line --------------------------'
    '--------------------------------------------------------------------------------'
    Public Function checkHitLine() As Boolean
        If posF1 < hitSetResetPos And posF2 < hitSetResetPos Then
            Return False
        Else
            Return True
        End If

    End Function

    '--------------------------------------------------------------------------------'
    '-------------------------- check if they have stopped --------------------------'
    '--------------------------------------------------------------------------------'
    ' return the finger whith which they have stopped. 0 is index, 1 is both, 2 is middle
    Public Function checkIfStopped() As Single

        If velF1 < velThreshold And posF1 > hitSetResetPos Then
            ' check for a combo hit
            If Abs(posF1 - posF2) < 0.04 Then
                'Console.WriteLine("combo")
                Return positions(1)
            Else
                'Console.WriteLine("index")
                Return positions(0)
            End If
        ElseIf velF2 < velThreshold And posF2 > hitSetResetPos Then
            If Abs(posF1 - posF2) < 0.04 Then
                'Console.WriteLine("combo")
                Return positions(1)
            Else
                'Console.WriteLine("middle")
                Return positions(2)
            End If
        Else
            Return -1
        End If

    End Function


    '--------------------------------------------------------------------------------'
    '---------------- check if they are in the pos and time windows -----------------'
    '--------------------------------------------------------------------------------'
    Function checkTimeAndPosWindows(ByRef fb As Fretboard) As Boolean
        Dim poscheck As Single = -1.0

        If fb.nextNotePos = positions(0) Then
            poscheck = posF1
        ElseIf fb.nextNotePos = positions(1) Then
            poscheck = (posF1 + posF2) / 2
        ElseIf fb.nextNotePos = positions(2) Then
            poscheck = posF2
        End If

        If (Abs(poscheck - destination) < posHitWindow) Then
            'Console.WriteLine("in pos window")
        End If

        If (fb.checkHit(targetTime)) Then
            'Console.WriteLine("in time window")
        End If

        If (Abs(poscheck - destination) < posHitWindow) And (fb.checkHit(targetTime)) Then
            Return True
        Else
            Return False
        End If

    End Function

    '--------------------------------------------------------------------------------'
    '------------------------------- set up next movement ---------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub prepMovement(ByRef fb As Fretboard, ByRef trueStartUpDelay As Single)
        Select Case (fb.nextNotePos)
            Case positions(0)
                moveFinger1((fb.nextNoteTime + trueStartUpDelay) / 1000)
                Exit Select
            Case positions(1)
                moveFingers((fb.nextNoteTime + trueStartUpDelay) / 1000)
                Exit Select
            Case positions(2)
                moveFinger2((fb.nextNoteTime + trueStartUpDelay) / 1000)
                Exit Select
        End Select
    End Sub

    Public Sub SetRedMode()
        finger1Ball.RedMode = False
        finger2Ball.RedMode = False
        fingers1Ball.RedMode = False
        fingers2Ball.RedMode = False

        If posF1 > hitSetResetPos Then
            finger1Ball.RedMode = True
            If (Abs(posF1 - posF2) < 0.04) Then
                fingers1Ball.RedMode = True
                fingers2Ball.RedMode = True
            End If
        End If

        If posF2 > hitSetResetPos Then
            finger2Ball.RedMode = True
            If (Abs(posF1 - posF2) < 0.04) Then
                fingers1Ball.RedMode = True
                fingers2Ball.RedMode = True
            End If
        End If


    End Sub


#End Region

#Region "drawing commands"
    Public Sub drawModels()
        finger1Ball.drawModel()
        finger2Ball.drawModel()

        fingers1Ball.drawModel()
        fingers2Ball.drawModel()

        backLine.drawModel()
        targFrontLine.drawModel()
        targBackLine.drawModel()
    End Sub

    Public Sub moveFingerBalls()
        ' move the fingerballs
        Dim pf1 As Single
        Dim pf2 As Single

        If FakeSuccessRate Then
            pf1 = posF1Lie
            pf2 = posF2Lie
        Else
            pf1 = posF1
            pf2 = posF2
        End If

        finger1Ball.pos(0) = positions(0)
        finger1Ball.pos(1) = 0.25
        finger1Ball.pos(2) = -(destination * fingerScale - pf1 * fingerScale)

        finger2Ball.pos(0) = positions(2)
        finger2Ball.pos(1) = 0.25
        finger2Ball.pos(2) = -(destination * fingerScale - pf2 * fingerScale)

        fingers1Ball.pos(0) = positions(1) + 0.1
        fingers1Ball.pos(1) = 0.25
        fingers1Ball.pos(2) = -(destination * fingerScale - pf1 * fingerScale)

        fingers2Ball.pos(0) = positions(1) - 0.1
        fingers2Ball.pos(1) = 0.25
        fingers2Ball.pos(2) = -(destination * fingerScale - pf2 * fingerScale)

        If hitSet Then
            finger1Ball.RedMode = True
            finger2Ball.RedMode = True
            fingers1Ball.RedMode = True
            fingers2Ball.RedMode = True
        Else
            finger1Ball.RedMode = False
            finger2Ball.RedMode = False
            fingers1Ball.RedMode = False
            fingers2Ball.RedMode = False
        End If

    End Sub

#End Region

    '--------------------------------------------------------------------------------'
    '---------------------------- flip the on/off switch ----------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub stopModel()
        Dim setVal(0) As Double

        If modelRunning Then
            modelRunning = Not modelRunning
            setVal(0) = 1
            stat = target_obj.SetParam(parameters_obj.onSwitch, setVal)
        Else
            modelRunning = Not modelRunning
            setVal(0) = 0
            stat = target_obj.SetParam(parameters_obj.onSwitch, setVal)
        End If

    End Sub

    '--------------------------------------------------------------------------------'
    '------------------------ get positions and velocities --------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub getPos()
        checkScopeReset()
        If rightHandMode Then
            posF2 = target_obj.GetSignal(signals_obj.posBlue) - zeroPos2
            velF2 = target_obj.GetSignal(signals_obj.velBlue)
            posF1 = target_obj.GetSignal(signals_obj.posGold) - zeroPos1
            velF1 = target_obj.GetSignal(signals_obj.velGold)

            posF1Lie = (posF1 + target_obj.GetSignal(signals_obj.posGoldDes) * f1VisLieWeight(0) + 0 * f1VisLieWeight(1)) / (1 + f1VisLieWeight(0) + f1VisLieWeight(1))
            'velF1Lie = (velF1 + target_obj.GetSignal(signals_obj.velGoldDes) * f1VisLieWeight(0) + 0 * f1VisLieWeight(1)) / (1 + f1VisLieWeight(0) + f1VisLieWeight(1))
            velF1Lie = target_obj.GetSignal(signals_obj.velGoldDes)

            posF2Lie = (posF2 + target_obj.GetSignal(signals_obj.posBlueDes) * f2VisLieWeight(0) + 0 * f2VisLieWeight(1)) / (1 + f2VisLieWeight(0) + f2VisLieWeight(1))
            'velF2Lie = (velF2 + target_obj.GetSignal(signals_obj.velBlueDes) * f2VisLieWeight(0) + 0 * f2VisLieWeight(1)) / (1 + f2VisLieWeight(0) + f2VisLieWeight(1))
            velF2Lie = target_obj.GetSignal(signals_obj.velBlueDes)
            'Console.WriteLine("true pos2 - " & CStr(posF2) & vbTab & "pos 2 lie - " & CStr(posF2Lie))
        Else
            posF1 = target_obj.GetSignal(signals_obj.posBlue) - zeroPos1
            velF1 = target_obj.GetSignal(signals_obj.velBlue)
            posF2 = target_obj.GetSignal(signals_obj.posGold) - zeroPos2
            velF2 = target_obj.GetSignal(signals_obj.velGold)

            posF1Lie = (posF1 + target_obj.GetSignal(signals_obj.posBlueDes) * f1VisLieWeight(0) + 0 * f1VisLieWeight(1)) / (1 + f1VisLieWeight(0) + f1VisLieWeight(1))
            'velF1Lie = (velF1 + target_obj.GetSignal(signals_obj.velBlueDes) * f1VisLieWeight(0) + 0 * f1VisLieWeight(1)) / (1 + f1VisLieWeight(0) + f1VisLieWeight(1))
            velF1Lie = target_obj.GetSignal(signals_obj.velBlueDes)

            posF2Lie = (posF2 + target_obj.GetSignal(signals_obj.posGoldDes) * f2VisLieWeight(0) + 0 * f2VisLieWeight(1)) / (1 + f2VisLieWeight(0) + f2VisLieWeight(1))
            'velF2Lie = (velF2 + target_obj.GetSignal(signals_obj.velGoldDes) * f2VisLieWeight(0) + 0 * f2VisLieWeight(1)) / (1 + f2VisLieWeight(0) + f2VisLieWeight(1))
            velF2Lie = target_obj.GetSignal(signals_obj.velGoldDes)
        End If

    End Sub

    '--------------------------------------------------------------------------------'
    '-------------------------- get frelling target time ----------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub getTargetTime()
        targetTime = (target_obj.GetSignal(signals_obj.targetTime) - 5) * 1000 ' subtract off the zeroing time and convert to miliseconds
    End Sub

    '--------------------------------------------------------------------------------'
    '------------------------------- set pos offset ---------------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub setPosOffset()
        Dim setVal(0) As Double
        setVal(0) = -0.06
        stat = target_obj.SetParam(parameters_obj.posoffset, setVal)
    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------------------- Tore the game -------------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub toreGame()
        getPos()
        zeroPos1 = posF1
        zeroPos2 = posF2
    End Sub


    '--------------------------------------------------------------------------------'
    '------------------------------ turn forces on/off ------------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub setForceOnOff()
        Dim setVal(0) As Double

        If forceOn Then
            forceOn = Not forceOn
            setVal(0) = 1
            stat = target_obj.SetParam(parameters_obj.stopForces, setVal)
        Else
            forceOn = Not forceOn
            setVal(0) = 0
            stat = target_obj.SetParam(parameters_obj.stopForces, setVal)
        End If

    End Sub

    '--------------------------------------------------------------------------------'
    '-------------------------- calculate reach time --------------------------------'
    '--------------------------------------------------------------------------------'
    ' calculates the expected reach time for an upcoming movement using Fitts law
    ' yeah, I don't use this ...
    Public Sub getMovementTimes()
        movementSet = False
        ' the system allways moves back to the zero position, so we don't need to calculate the movement time
        'reachtime = (FittsA + FittsB * Log((Abs(destination) / FittsW) + 1, 2)) * 1000
        reachtime = fixedDur
    End Sub

    '--------------------------------------------------------------------------------'
    '----------------------------- update gain steps --------------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub updateGainStep(ByVal successRate As Single)
        alpha = successRate / (1 - successRate)

        increaseStepKp = alpha * sigmaKp
        decreaseStepKp = sigmaKp
        increaseStepKd = alpha * sigmaKd
        decreaseStepKd = sigmaKd
        'MsgBox("increase step " & CStr(increaseStepKp))

    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------------- check gravity direction ---------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub checkGravityDir()
        Dim gDir As Single = target_obj.GetSignal(signals_obj.gDirection) '= -0.05 '
        'uncomment this line to see what the raw accelerometer values are in left and right hand modes.
        'Console.WriteLine("gravity direction value " & CStr(gDir))

        If gDir < 0.001 Then
            rightHandMode = True
        Else
            rightHandMode = False
        End If

        'Console.WriteLine("right hand mode is " & CStr(rightHandMode) & vbTab & CStr(gDir))

    End Sub

    Public Function usingFakeSucessRates() As Boolean
        Return FakeSuccessRate
    End Function

End Class
