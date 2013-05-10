Imports System.IO

Public Class FileDict
    Private sourceFileName As String
    Private fileExists As Boolean
    Private content As Dictionary(Of String, String)

    '------------------------------------ constructor -------------------------------'
    Public Sub New(ByVal fileName As String)
        sourceFileName = fileName
        Read()
    End Sub

    Public Sub Read()
        If My.Computer.FileSystem.FileExists(sourceFileName) Then
            fileExists = True
            Dim file As StreamReader = New StreamReader(sourceFileName)
            Dim lines As String() = file.ReadToEnd().Split(vbNewLine)
            file.Close()
            content = New Dictionary(Of String, String)
            Dim parts As String()
            For Each line In lines
                parts = line.Split({":"c}, 2)
                If parts.Length = 2 Then content.Add(parts(0).Trim(), parts(1).Trim())
            Next
        Else
            fileExists = False
            MsgBox("the file " & sourceFileName & " does not exist")
        End If
        
    End Sub
    Public Function Lookup(ByVal key As String, ByVal defaultValue As String) As String
        If fileExists Then
            If content.ContainsKey(key) Then Return content(key) Else Return defaultValue
        Else
            Return defaultValue
        End If

    End Function
    Public Function AsText() As String
        Dim result As String = ""
        Dim list As New List(Of String)(content.Keys)
        list.Sort()
        For Each key In list
            result = result & key & ": " & content(key) & vbNewLine
        Next
        Return result
    End Function
    Public Sub Write()
        Dim file As StreamWriter = New StreamWriter(sourceFileName)
        file.Write(AsText())
        file.Close()
    End Sub
End Class