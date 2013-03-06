'----------------------------------------------------------------------------------'
'----------------------------- gain file writer class -----------------------------'
'----------------------------------------------------------------------------------'
' this shiz writes us a gain file. it stores the data in an array and then writes 
' the actual file at the bitter end.
Imports System.IO
Public Class GainFileWriter
    Private lengths As Integer = 1000
    Private kp1Gains(lengths + 1) As Single
    Private kd1Gains(lengths + 1) As Single
    Private gain1Times(lengths + 1) As Single

    Private kp2Gains(lengths + 1) As Single
    Private kd2Gains(lengths + 1) As Single
    Private gain2Times(lengths + 1) As Single

    Private gain1Index As Integer = 0
    Private gain2Index As Integer = 0

    Private gainFile As StreamWriter

    '----------------------------------------------------------------------------------'
    '---------------------------- Oh NOOOOO It's a constructor ------------------------'
    '----------------------------------------------------------------------------------'
    Public Sub New(ByRef PathAndName As String)
        gainFile = New StreamWriter(PathAndName)
        gainFile.WriteLine("Kp1" & vbTab & "Kd1" & vbTab & "gain1Time" & vbTab & "Kp2" & vbTab & "Kd2" & vbTab & "gain2Time")
    End Sub

    '----------------------------------------------------------------------------------'
    '---------------------------- store data for finger 1 gains -----------------------'
    '----------------------------------------------------------------------------------'
    Public Sub storeGainsF1(ByVal Kp As Single, ByVal Kd As Single, ByVal time As Single)
        kp1Gains(gain1Index) = Kp
        kd1Gains(gain1Index) = Kd
        gain1Times(gain1Index) = time
        If (gain1Index + 1) < lengths Then gain1Index += 1
    End Sub

    '----------------------------------------------------------------------------------'
    '---------------------------- store data for finger 2 gains -----------------------'
    '----------------------------------------------------------------------------------'
    Public Sub storeGainsF2(ByVal Kp As Single, ByVal Kd As Single, ByVal time As Single)
        kp2Gains(gain2Index) = Kp
        kd2Gains(gain2Index) = Kd
        gain2Times(gain2Index) = time
        If (gain2Index + 1) < lengths Then gain2Index += 1
    End Sub

    '----------------------------------------------------------------------------------'
    '------------------------ write the crap out of the gain file ---------------------'
    '----------------------------------------------------------------------------------'
    Public Sub writeGainFile()
        Dim maxIndex As Integer
        Dim gainString As String
        If gain2Index >= gain1Index Then
            maxIndex = gain2Index
        Else
            maxIndex = gain1Index
        End If

        For i As Integer = 0 To (maxIndex - 1)
            gainString = ""
            If i < gain1Index Then
                gainString = CStr(kp1Gains(i)) & vbTab & CStr(kd1Gains(i)) & vbTab & CStr(gain1Times(i)) & vbTab
            Else
                gainString = "0" & vbTab & "0" & vbTab & "0" & vbTab
            End If

            If i < gain2Index Then
                gainString = gainString & CStr(kp2Gains(i)) & vbTab & CStr(kd2Gains(i)) & vbTab & CStr(gain2Times(i)) & vbTab
            Else
                gainString = gainString & "0" & vbTab & "0" & vbTab & "0" & vbTab
            End If

            gainFile.WriteLine(gainString)
        Next

        gainFile.Close()

    End Sub


End Class
