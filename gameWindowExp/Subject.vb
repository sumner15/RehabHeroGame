Imports System.IO

'================================================================================'
'---------------------------------- Subject class -------------------------------'
'================================================================================'
Public Class Subject
    Public num As Integer           ' number corresponding to subject
    Public ID As String             ' the user's subject ID
    Public LoginDate As DateTime        ' date subject was created
    Public Kp1 As Single
    Public Kp2 As Single
    Public Kd1 As Single
    Public Kd2 As Single
    Public trial As Single
    Public lastSessionDate As DateTime
    Public lastSessionNumber As Integer

    Private epoch As DateTime = "1970-01-01 00:00:00"
    'Public dataFiles(10) As String  'array of file names for experimental dta files

    '--------------------------------------------------------------------------------'
    '------------------------- constructor for new subjects -------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub New(ByRef subNum As Integer, ByRef subID As String, ByRef subTrial As Single)
        num = subNum
        ID = subID
        LoginDate = Now
        Kp1 = 10
        Kp2 = 10
        Kd1 = 1
        Kd2 = 1
        trial = subTrial
        lastSessionDate = epoch
        lastSessionNumber = 0
        writeSubjectFile()
    End Sub

    Public Sub New(ByVal subID As String)
        readSubjectFile(subID)
    End Sub

    '--------------------------------------------------------------------------------'
    '----------------------------- write subject file -------------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub writeSubjectFile()
        Dim subjectFile As StreamWriter = New StreamWriter(GAMEPATH & "Subjects\" & ID & ".txt")
        subjectFile.WriteLine("num: " & num)
        subjectFile.WriteLine("ID: " & ID)
        subjectFile.WriteLine("LoginDate: " & LoginDate.ToString("s").Replace("T", " "))
        subjectFile.WriteLine("Kp1: " & Kp1)
        subjectFile.WriteLine("Kp2: " & Kp2)
        subjectFile.WriteLine("Kd1: " & Kd1)
        subjectFile.WriteLine("Kd2: " & Kd2)
        subjectFile.WriteLine("trial: " & trial)
        subjectFile.WriteLine("lastSessionDate: " & lastSessionDate.ToString("s").Replace("T", " "))
        subjectFile.WriteLine("lastSessionNumber: " & lastSessionNumber)
        subjectFile.Close()
    End Sub

    '--------------------------------------------------------------------------------'
    '------------------------------- write read file --------------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub readSubjectFile(ByVal subId As String)
        Dim fromFile As FileDict = New FileDict(GAMEPATH & "Subjects\" & subId & ".txt")
        num = fromFile.Lookup("num", "0")
        ID = fromFile.Lookup("ID", subId)
        LoginDate = fromFile.Lookup("LoginDate", Now.ToString("s").Replace("T", " "))
        Kp1 = fromFile.Lookup("Kp1", "10")
        Kp2 = fromFile.Lookup("Kp2", "10")
        Kd1 = fromFile.Lookup("Kd1", "1")
        Kd2 = fromFile.Lookup("Kd2", "1")
        trial = fromFile.Lookup("trial", "0")
        lastSessionDate = fromFile.Lookup("lastSessionDate", epoch)
        lastSessionNumber = fromFile.Lookup("lastSessionNumber", 0)
    End Sub
    '--------------------------------------------------------------------------------'
    '------------------------------- update subject file ----------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub update()
        writeSubjectFile()
    End Sub

    '--------------------------------------------------------------------------------'
    '------------------------------- make trial var public --------------------------'
    '--------------------------------------------------------------------------------'
    Public Function getSessionString() As String
        Dim today As Boolean = Math.Floor(lastSessionDate.Subtract(epoch).TotalDays) = Math.Floor(Now.Subtract(epoch).TotalDays)
        Dim never As Boolean = (lastSessionDate = epoch)
        If never Then Return "no previous session"
        Dim result As String = "Last measurement: session " & lastSessionNumber.ToString("000.##")
        result = result & If(today, " today", " on " & lastSessionDate.ToString("yyyy-MM-dd"))
        result = result & " at " & lastSessionDate.ToString("h:mm tt")
        Return result
    End Function
    Public Function getExpectedSessionNumber() As String
        Dim hrs As Double = Now.Subtract(lastSessionDate).TotalHours
        Dim number As Integer = If(hrs < 4, lastSessionNumber, lastSessionNumber + 1)
        Return number.ToString("000.##")
    End Function
End Class

Public Class FileDict
    Private sourceFileName As String
    Private content As Dictionary(Of String, String)

    Public Sub New(fileName As String)
        sourceFileName = fileName
        Read()
    End Sub
    Public Sub Read()
        Dim file As StreamReader = New StreamReader(sourceFileName)
        Dim lines As String() = file.ReadToEnd().Split(vbNewLine)
        file.Close()
        content = New Dictionary(Of String, String)
        Dim parts As String()
        For Each line In lines
            parts = line.Split({":"c}, 2)
            If parts.Length = 2 Then content.Add(parts(0).Trim(), parts(1).Trim())
        Next
    End Sub
    Public Function Lookup(key As String, defaultValue As String) As String
        If content.ContainsKey(key) Then Return content(key) Else Return defaultValue
    End Function
    Public Sub Write()
        Dim file As StreamWriter = New StreamWriter(sourceFileName)
        Dim list As New List(Of String)(content.Keys)
        For Each key In list
            file.WriteLine("{0}: {1}", key, content(key))
        Next
        file.Close()
    End Sub

End Class