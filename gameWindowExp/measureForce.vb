'----------------------------------------------------------------------------------'
'------------- a short game to measure their force prodution abilities -------------'
'----------------------------------------------------------------------------------'
Imports OpenTK
Imports OpenTK.Platform
Imports OpenTK.Graphics.OpenGL
Imports OpenTK.Input
Imports System.Runtime.InteropServices
Imports OpenTK.Graphics
Imports System.IO

Public Class measureForce
    Inherits OpenTK.GameWindow

    Private myLights As Lights
    Private myCamera As Camera
    'define and create your models here
    Private room As New Model("cloudSphere", "clouds2", {0, 0, 0}, {0, 0, 0}, 3) 'filename, texturename, position, orientation, scale'
    Private tube As New Model("tube", {0.0, 0.0, 0.0}, {0.0, 0.0, 0.0}, 1)
    Private cursor As New Model("gripper", {0.0, 0.0, 0.0}, {0.0, 0.0, 0.0}, 1)
    Private peakBall As New Model("ballb", {0.0, 0.0, 0.0}, {0.0, 0.0, 0.0}, 0.5)
    Private instructions As New TextSign("relax fingers")

    Private secondHand As FingerBot
    Private useForce As Boolean
    Private maxVal As Single = 0.14
    Private restPos1 As Single = 0
    Private restPos2 As Single = 0

    Private avePos1(50) As Single
    Private avePos2(50) As Single
    Private avePosCounter As Integer = 0

    Private state As Integer = 0
    Private delayMaker As Stopwatch = New Stopwatch

#Region "constructors"
    '----------------------------------------------------------------------------------'
    '------------------------------------- constructor --------------------------------'
    '----------------------------------------------------------------------------------'
    Public Sub New(ByVal forceOn As Boolean, ByVal max As Single)
        myLights = New Lights({0.0F, -1.0F, 1.0F}, {-2.0F, 0.0F, -2.0F}, {0.0F, 0.0F, 0.0F})
        myCamera = New Camera({0.0F, 0.0F, 15.0F}, {0.0F, 0.0F, 0.0F})

        myCamera.ViewPerspective(Width, Height)
        myCamera.setViewPoint()
        initializeGL()

        secondHand = New FingerBot()
        useForce = forceOn

        instructions.pos(0) -= 4
        instructions.scale = 2

        maxVal = max
        'drummer.setMovement(4)

    End Sub

#End Region

#Region "graphics functions"
    '----------------------------------------------------------------------------------'
    '------------------------------ Initializes open GL -------------------------------'
    '----------------------------------------------------------------------------------'
    Public Sub initializeGL()
        GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest)
        GL.ShadeModel(ShadingModel.Smooth)
        GL.Enable(EnableCap.DepthTest)
        GL.ClearDepth(1.0)
        GL.DepthFunc(DepthFunction.Lequal)
        GraphicsContext.CurrentContext.VSync = False ' if you don't set this to false then swapbuffers will wait for the monitor to refresh
    End Sub
#End Region

#Region "drawing events"

    '----------------------------------------------------------------------------------'
    '----------------------- drawing commands - render event --------------------------'
    '----------------------------------------------------------------------------------'
    ' put your drawing commands here
    Private Sub purdyWindow_RenderFrame(ByVal sender As Object, ByVal e As OpenTK.FrameEventArgs) Handles Me.RenderFrame

        myCamera.setViewPoint()
        GL.Clear(ClearBufferMask.ColorBufferBit Or ClearBufferMask.DepthBufferBit)

        ' put drawing commands here
        room.drawModel()
        tube.drawModel()
        cursor.drawModel()
        peakBall.drawModel()

        instructions.drawSign()

        Me.SwapBuffers()
    End Sub

#End Region

#Region "put state machine here"
    '----------------------------------------------------------------------------------'
    '------------------------------ update frame event --------------------------------'
    '----------------------------------------------------------------------------------'
    Private Sub purdyWindow_UpdateFrame(ByVal sender As Object, ByVal e As OpenTK.FrameEventArgs) Handles Me.UpdateFrame
        ' you can put your state code ( or anything else of a similar nature) here

        If Mouse.Item(0) = True Then
            myCamera.pitch = Mouse.X / 1.25
            myCamera.roll = Mouse.Y / 1.25
        ElseIf Mouse.Item(1) = True Then
            'ball.pos(0) = (Mouse.X - Width / 2) / 100
            'ball.pos(1) = -(Mouse.Y - Height / 2) / 100
        End If

        secondHand.getPos()

        ' if you have a state machine, put it here.
        gameStates()

    End Sub

    '----------------------------------------------------------------------------------'
    '----------------------------- Here's my state machine ----------------------------'
    '----------------------------------------------------------------------------------'
    Private Sub gameStates()
        Dim tubeSize As Single = 4
        Select Case state
            Case 0
                If delayMaker.ElapsedMilliseconds > 5000 Then
                    If Not useForce Then secondHand.setForceOnOff() : secondHand.setForceOnOff()
                    state = 1
                    secondHand.setPosOffset()
                    delayMaker.Restart()
                    fillAvePos(0, 0, True)
                End If
                Exit Select
            Case 1
                ' tell them to relax for a second
                If delayMaker.ElapsedMilliseconds > 2000 And delayMaker.ElapsedMilliseconds < 4000 Then
                    fillAvePos(secondHand.posF1, secondHand.posF2, False)
                    Console.WriteLine("attempted to fill arrayPos")
                ElseIf delayMaker.ElapsedMilliseconds > 5000 Then
                    restPos1 = avePos1.Average() 'secondHand.posF1
                    restPos2 = avePos2.Average() 'secondHand.posF2
                    Console.WriteLine(restPos1 & vbTab & restPos2)
                    peakBall.pos(1) = -tubeSize
                    delayMaker.Restart()
                    instructions = New TextSign("flex index finger") : instructions.pos(0) = -4 : instructions.scale = 2
                    state = 2
                End If
                Exit Select
            Case 2 ' flex finger 1
                cursor.pos(1) = (-restPos1 + secondHand.posF1) * tubeSize * 2 / (maxVal - restPos1) - tubeSize
                If cursor.pos(1) > peakBall.pos(1) Then peakBall.pos(1) = cursor.pos(1)
                If delayMaker.ElapsedMilliseconds > 10000 Then
                    'text - flex finger 1
                    instructions = New TextSign("flex middle finger") : instructions.pos(0) = -4 : instructions.scale = 2
                    peakBall.pos(1) = -tubeSize
                    state = 3
                    delayMaker.Restart()
                End If
                Exit Select
            Case 3 'flex finger 2
                cursor.pos(1) = (-restPos2 + secondHand.posF2) * tubeSize * 2 / (maxVal - restPos2) - tubeSize
                If cursor.pos(1) > peakBall.pos(1) Then peakBall.pos(1) = cursor.pos(1)
                If delayMaker.ElapsedMilliseconds > 10000 Then
                    'text - flex finger 2
                    peakBall.pos(1) = -tubeSize
                    state = 4
                    delayMaker.Restart()
                    instructions = New TextSign("flex both fingers") : instructions.pos(0) = -4 : instructions.scale = 2
                End If
                Exit Select
            Case 4 'flex both fingers
                cursor.pos(1) = (-(restPos2 + restPos1) / 2 + (secondHand.posF2 + secondHand.posF1) / 2) * tubeSize * 2 / (maxVal - (restPos2 + restPos1) / 2) - tubeSize
                If cursor.pos(1) > peakBall.pos(1) Then peakBall.pos(1) = cursor.pos(1)
                If delayMaker.ElapsedMilliseconds > 10000 Then
                    instructions = New TextSign("extend index finger") : instructions.pos(0) = -4 : instructions.scale = 2
                    state = 5
                    peakBall.pos(1) = -tubeSize
                    delayMaker.Restart()
                End If
                Exit Select
            Case 5 ' extend first finger
                cursor.pos(1) = (-secondHand.posF1 + restPos1) * tubeSize * 2 / (maxVal - restPos1) - tubeSize
                If cursor.pos(1) > peakBall.pos(1) Then peakBall.pos(1) = cursor.pos(1)
                If delayMaker.ElapsedMilliseconds > 10000 Then
                    instructions = New TextSign("extend middle finger") : instructions.pos(0) = -4 : instructions.scale = 2
                    peakBall.pos(1) = -tubeSize
                    state = 6
                    delayMaker.Restart()
                End If
                Exit Select
            Case 6 ' extend middle finger - lol
                cursor.pos(1) = (-secondHand.posF2 + restPos2) * tubeSize * 2 / (maxVal - restPos2) - tubeSize
                If cursor.pos(1) > peakBall.pos(1) Then peakBall.pos(1) = cursor.pos(1)
                If delayMaker.ElapsedMilliseconds > 10000 Then
                    instructions = New TextSign("extend both finger") : instructions.pos(0) = -4 : instructions.scale = 2
                    peakBall.pos(1) = -tubeSize
                    state = 7
                    delayMaker.Restart()
                End If
                Exit Select
            Case 7 ' extend both fingers
                cursor.pos(1) = (-(secondHand.posF2 + secondHand.posF1) / 2 + (restPos2 + restPos1) / 2) * tubeSize * 2 / (maxVal - (restPos2 + restPos1) / 2) - tubeSize
                If cursor.pos(1) > peakBall.pos(1) Then peakBall.pos(1) = cursor.pos(1)
                If delayMaker.ElapsedMilliseconds > 10000 Then
                    instructions = New TextSign("flex index finger") : instructions.pos(0) = -4 : instructions.scale = 2
                    state = 8
                    peakBall.pos(1) = -tubeSize
                    delayMaker.Restart()
                End If
                Exit Select
            Case 8
                Me.Exit()
                Exit Select
        End Select
    End Sub

    '----------------------------------------------------------------------------------'
    '-------------------------------- fill AveposCounter ------------------------------'
    '----------------------------------------------------------------------------------'
    Private Sub fillAvePos(ByVal pos1 As Single, ByVal pos2 As Single, ByVal reset As Boolean)
        If reset Then
            avePosCounter = 0
        Else
            If avePosCounter < (avePos1.Length - 1) Then
                avePos1(avePosCounter) = pos1
                avePos2(avePosCounter) = pos2
                avePosCounter += 1
                Console.WriteLine(avePosCounter)
            End If
        End If
    End Sub

#End Region

#Region "other events"
    '----------------------------------------------------------------------------------'
    '------------------------------ keyboard event handler ----------------------------'
    '----------------------------------------------------------------------------------'
    Private Sub purdyWindow_KeyPress(ByVal sender As Object, ByVal e As OpenTK.KeyPressEventArgs) Handles Me.KeyPress
        'Dim hit As Boolean
        '
        If (e.KeyChar = "i") Then
            MsgBox("Warning! Do not press i again. I'm serious!")
        ElseIf (e.KeyChar = "f") Then
            secondHand.setForceOnOff()
        ElseIf (AscW(e.KeyChar) = 27) Then
            Me.Exit()
        End If
    End Sub

    '----------------------------------------------------------------------------------'
    '---------------------------- instructions executed on load -----------------------'
    '----------------------------------------------------------------------------------'
    ' initialize your graphics objects here
    Private Sub purdyWindow_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        initializeGL()
        secondHand.startR()
        delayMaker.Start()

        If useForce Then
            secondHand.setBigBlockingGains()
            secondHand.moveFinger1(100000)
            secondHand.moveFinger2(100000)
        End If


    End Sub

    '----------------------------------------------------------------------------------'
    '------------------------------ resize window event -------------------------------'
    '----------------------------------------------------------------------------------'
    Private Sub purdyWindow_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        GL.Viewport(0, 0, Width, Height)
        myCamera.ViewPerspective(Width, Height)
    End Sub

    '----------------------------------------------------------------------------------'
    '------------------------- unloading game window event ----------------------------'
    '----------------------------------------------------------------------------------'
    ' do your cleanup here
    Private Sub purdyWindow_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload

        secondHand.stopR()
        secondHand.close() ' change  1 to trial type integer later 

    End Sub

#End Region
End Class
