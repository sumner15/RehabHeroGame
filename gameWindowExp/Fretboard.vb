'----------------------------------------------------------------------------------'
'-------------------------------- Fretboard class ---------------------------------'
'----------------------------------------------------------------------------------'
' the fretboard class mannages the stage, the five strings, and the five targets

Imports System.Math
Imports OpenTK
Imports OpenTK.Platform
Imports OpenTK.Graphics.OpenGL
Imports OpenTK.Graphics

Enum level As Integer
    superEasy = 1
    easy = 2
    medium = 3
    Amazing = 4
End Enum

Public Class Fretboard
    Public stage As MeshVbo
    Public strings(4) As GuitarString
    Public targets(4) As Target

    Public allNotes(,) As Double
    Public numNotes As Integer

    Private currentNote As Integer = 0
    Public nextNotePos As Single
    Public nextNoteTime As Double

    Public songOver As Boolean = False

    Private fretBoardZ As Single
    Private winSizeS As Double = 5000  ' how early notes appear in miliseconds
    Private winSizeU As Double = 18    ' how far away notes are when they appears

    Private timeSinceLastMove As New Stopwatch

    '----------------------------------------------------------------------------------'
    '----------------------------------- constructor ----------------------------------'
    '----------------------------------------------------------------------------------'
    ' the constructor requires that we pass in a song and a difficulty
    Public Sub New(ByRef mySong As Song, ByVal difficulty As Integer)
        Select Case difficulty
            Case level.superEasy
                allNotes = mySong.superEasyAll
                For i = 0 To 4 Step 1
                    strings(i) = New GuitarString(mySong.superEasy(i).onTimes, i)
                    targets(i) = New Target(i)
                Next
                Exit Select
            Case level.easy
                allNotes = mySong.easyAll
                For i = 0 To 4 Step 1
                    strings(i) = New GuitarString(mySong.easy(i).onTimes, i)
                    targets(i) = New Target(i)
                Next
                Exit Select
            Case level.medium
                allNotes = mySong.mediumAll
                For i = 0 To 4 Step 1
                    strings(i) = New GuitarString(mySong.medium(i).onTimes, i)
                    targets(i) = New Target(i)
                Next
                Exit Select
            Case level.Amazing
                allNotes = mySong.amazingAll
                For i = 0 To 4 Step 1
                    strings(i) = New GuitarString(mySong.amazing(i).onTimes, i)
                    targets(i) = New Target(i)
                Next
                Exit Select
        End Select

        stage = New MeshVbo(poly.QUADS)
        stage.readWavefront("fretBoard.obj")
        stage.useMaterial = False
        stage.loadVbo()
        stage.loadTexture("fretBoard3.bmp")
        fretBoardZ = -8

        numNotes = allNotes.GetLength(0)

        timeSinceLastMove.Start()
        'getNextNote()

    End Sub

    '----------------------------------------------------------------------------------'
    '-------------------------------- drawing function --------------------------------'
    '----------------------------------------------------------------------------------'
    ' draws the fretboard, the strings, and the targets
    Public Sub draw(ByRef targetTime As Single)
        'GL.Enable(EnableCap.Blend)
        GL.Enable(EnableCap.Texture2D)
        GL.PushMatrix()
        GL.Translate(0.0, 0.0, fretBoardZ)
        GL.BindTexture(TextureTarget.Texture2D, stage.textureID)
        stage.drawVbo()
        GL.PopMatrix()

        GL.PushMatrix()
        GL.Translate(0.0, 0.0, fretBoardZ - 18)
        GL.BindTexture(TextureTarget.Texture2D, stage.textureID)
        stage.drawVbo()
        GL.PopMatrix()
        'GL.Disable(EnableCap.Blend)

        If (fretBoardZ >= 10) Then
            fretBoardZ = -8
        Else
            fretBoardZ += winSizeU / winSizeS * timeSinceLastMove.ElapsedMilliseconds  ' clock.timeStep
            timeSinceLastMove.Restart()
        End If

        For i = 0 To 4 Step 1
            strings(i).drawNotes(targetTime)
            targets(i).drawTarget()
        Next
    End Sub

    '----------------------------------------------------------------------------------'
    '-------------------------------- check for a hit ---------------------------------'
    '----------------------------------------------------------------------------------'
    ' cheks if we have a hit. If we do, it draws flames and stuff
    Public Function checkHit(ByRef gameTime As Double, ByVal stringNum As Integer) As Boolean
        Dim hit As Boolean
        targets(stringNum).drawHit()

        hit = strings(stringNum).checkHit(gameTime)
        'If hit Then
        '    'Console.Write(vbTab & "hit")
        '    targets(stringNum).drawFlame()
        '    Console.WriteLine("draw flame if hit")
        'Else
        '    'Console.Write(vbTab & "miss")
        'End If
        Return hit
    End Function

    '----------------------------------------------------------------------------------'
    '-------------------------------- check for a hit overload ------------------------'
    '----------------------------------------------------------------------------------'
    ' cheks if we have a hit. If we do, it draws flames and stuff
    Public Function checkHit(ByRef gameTime As Double) As Boolean
        Dim hit As Boolean
        'targets(nextNotePos).drawHit()

        If nextNotePos = positions(0) Then
            hit = strings(0).checkHit(gameTime)
        ElseIf nextNotePos = positions(1) Then
            hit = strings(1).checkHit(gameTime)
        ElseIf nextNotePos = positions(2) Then
            hit = strings(2).checkHit(gameTime)
        End If


        'If hit Then
        '    'Console.Write(vbTab & "hit")
        '    targets(stringNum).drawFlame()
        '    Console.WriteLine("draw flame if hit")
        'Else
        '    'Console.Write(vbTab & "miss")
        'End If
        Return hit
    End Function

    '----------------------------------------------------------------------------------'
    '------------------------------ draw flame on command -----------------------------'
    '----------------------------------------------------------------------------------'
    Public Sub triggerFlame(ByVal stringNum As Integer)
        targets(stringNum).drawFlame()
    End Sub

    '----------------------------------------------------------------------------------'
    '------------------------------ draw flame on command -----------------------------'
    '----------------------------------------------------------------------------------'
    'overload that assumes we want to draw the flame on the fret of the current note
    Public Sub triggerFlame()
        If nextNotePos = positions(0) Then
            targets(0).drawFlame()
        ElseIf nextNotePos = positions(1) Then
            targets(1).drawFlame()
        ElseIf nextNotePos = positions(2) Then
            targets(2).drawFlame()
        End If


    End Sub



    '----------------------------------------------------------------------------------'
    '----------------------------------- free memory ----------------------------------'
    '----------------------------------------------------------------------------------'
    ' freesup the memory - cal only when you are done with it.
    Public Sub freeMemory()
        GL.DeleteTextures(TextureTarget.Texture2D, stage.textureID)
        stage.freeBuffers()

        For i = 0 To 4 Step 1
            strings(i).freeMemory()
            targets(i).freeMemory()
        Next
    End Sub

    '----------------------------------------------------------------------------------'
    '----------------------------------- get next note --------------------------------'
    '----------------------------------------------------------------------------------'
    ' looks at all of the strings and checks which one has the next note
    Public Sub getNextNote()
        nextNoteTime = allNotes(currentNote, 0)
        nextNotePos = positions(CInt(allNotes(currentNote, 2)))
        If (currentNote + 1) < allNotes.GetLength(0) Then
            currentNote += 1
        Else
            songOver = True
        End If
        'Console.Write("next note: " & nextNotePos & vbTab & "time: " & nextNoteTime & vbNewLine)
    End Sub

End Class
