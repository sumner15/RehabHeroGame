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
        filterNotes()
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

    Private Sub filterNotes()
        ' manipulate notes in two places: allNotes( 0 to totalNumberOfNotes,  0 to 2 )
        '                                 strings( i ).noteTimes( 0 to numberOfNotesOnThisString )   for i = 0 to 2
        ' remove notes that violate the conditions set by minMsecBetweenBursts and maxNumberNotesPerBurst
        ' In Python this would be about ten lines.

        Dim minGap As Double = gameSets.get_minMsecBetweenBursts()
        Dim maxGap As Double = gameSets.get_maxMsecBetweenBursts()
        Dim maxRiffLength As Integer = gameSets.get_maxNumberNotesPerBurst()

        Dim lastNoteTime As Double = 0
        Dim riffLength As Integer = 0
        Dim index_all As Integer = 0
        Dim nLeft_all As Integer = 0

        Dim indices As Integer()
        ReDim indices(strings.Length - 1)
        Dim nLeft As Integer()
        ReDim nLeft(strings.Length - 1)
        Dim sel As Boolean()()
        ReDim sel(strings.Length - 1)
        ' initialize counters and arrays for the string-by-string search
        For iString As Integer = 0 To strings.Length - 1
            'Console.WriteLine("string {0} has {1} notes", iString, strings(iString).noteTimes.Length)
            ReDim sel(iString)(strings(iString).noteTimes.Length - 1)
            indices(iString) = 0
            nLeft(iString) = 0
        Next
        Dim sel_all As Boolean()
        ReDim sel_all(allNotes.GetLength(0) - 1)

        Dim maxString = 2 ' don't take into account notes on strings 3 and 4 (they should not be removed, and they are not included in allNotes anyway)

        While True
            Dim noteTime As Double = -1
            Dim noteString As Integer = -1
            ' Find the string and time of the next note
            For iString As Integer = 0 To maxString ' by iterating through the strings
                Dim index As Integer = indices(iString) ' looking at the next note on each string
                If index < strings(iString).noteTimes.Length Then  ' and seeing which string has a note soonest
                    If noteTime < 0 Or strings(iString).noteTimes(index) < noteTime Then
                        noteTime = strings(iString).noteTimes(index)
                        noteString = iString
                    End If
                End If
            Next
            If noteString = -1 Then Exit While ' must have exhausted all strings
            riffLength += 1
            If noteTime - lastNoteTime >= minGap Then riffLength = 1
            If noteTime - lastNoteTime >= maxGap Then Console.WriteLine("maxMsecBetweenBursts exceeded") ' can't actually prevent this
            Dim keep As Boolean = (riffLength <= maxRiffLength)
            sel(noteString)(indices(noteString)) = keep   ' selector arrays for each string
            sel_all(index_all) = keep  ' selector array for allNotes
            'If noteTime < 30000 Then Console.WriteLine("{0} {1}:  {2}", noteTime, noteString, keep)
            If keep Then
                lastNoteTime = noteTime
                nLeft(noteString) += 1
                nLeft_all += 1
            End If
            indices(noteString) += 1
            index_all += 1
        End While
        ' reconstruct the array of note times for each string, including only selected notes:
        For iString As Integer = 0 To maxString
            Dim newNoteTimes As Double()
            ReDim newNoteTimes(nLeft(iString) - 1) ' this array will replace the previous noteTimes member array of the GuitarString object
            Dim index As Integer = 0
            For iNote As Integer = 0 To strings(iString).noteTimes.Length - 1
                If sel(iString)(iNote) Then
                    newNoteTimes(index) = strings(iString).noteTimes(iNote)
                    index += 1
                End If
            Next
            strings(iString).noteTimes = newNoteTimes
            ReDim strings(iString).hitTimes(nLeft(iString) - 1, 1)
        Next
        ' reconstruct the table allNotes, including only selected notes:
        Dim newAllNotes As Double(,)
        ReDim newAllNotes(nLeft_all - 1, allNotes.GetLength(1) - 1)
        index_all = 0
        For iNote As Integer = 0 To allNotes.GetLength(0) - 1
            If sel_all(iNote) Then
                For iCol As Integer = 0 To allNotes.GetLength(1) - 1
                    newAllNotes(index_all, iCol) = allNotes(iNote, iCol)
                Next
                index_all += 1
            End If
        Next
        allNotes = newAllNotes

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
