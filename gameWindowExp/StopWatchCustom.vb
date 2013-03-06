Public Class StopWatchCustom
    Public startTime As Date
    Public currentTime As Date
    Public previousTime As Date
    Public gameTime As Double = 0
    Public timeStep As Double = 0
    Public frameCount As Double = 0
    Public timeRec() As Double

    Private Started As Boolean = False

    Public Sub New()
        startTime = New Date
        currentTime = New Date
        previousTime = New Date
        ReDim timeRec(200)
    End Sub

    Public Sub start()
        startTime = Now
        previousTime = Now
        Started = True
    End Sub

    Public Sub updateAll()
        If Started = True Then
            currentTime = Now
            gameTime = (currentTime - startTime).TotalMilliseconds
            timeStep = (currentTime - previousTime).TotalMilliseconds
            previousTime = Now
            If (frameCount < timeRec.Length) Then timeRec(frameCount) = gameTime
            frameCount = frameCount + 1

            If (diagnostic = True) Then Console.Write("FPS: " & CStr(timeStep) & vbNewLine)
        Else
            Console.Write("you need to start the timer ... goober" & vbNewLine)
        End If

    End Sub

    Public Sub updateGameTime()
        If Started = True Then
            currentTime = Now
            gameTime = (currentTime - startTime).TotalMilliseconds
        Else
            Console.Write("you need to start the timer ... goober" & vbNewLine)
        End If
    End Sub

    Public Sub writeRecord()
        Dim timeStr As String = "gameTime: " & vbNewLine

        For i = 0 To (timeRec.Length - 1) Step 1
            timeStr = timeStr & CStr(timeRec(i) & vbNewLine)
        Next i

        Console.Write(timeStr)
    End Sub


End Class
