Imports System.IO
'================================================================================'
'-------------------------------- Population class ------------------------------'
'================================================================================'
' organizer for studies
Public Class StudyPopulation    
    Private studyList As String = "allStudies.txt"
    Public studySize As Integer
    Public studyIds() As String

    '--------------------------------------------------------------------------------'
    '------------------------- constructor for population ---------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub New()
        Dim fileReader As StreamReader
        Dim idstring As String
        'need to find out how many studies we have
        fileReader = My.Computer.FileSystem.OpenTextFileReader(GAMEPATH & "gameSettings\" & studyList)
        studySize = 0
        While (Not fileReader.EndOfStream)
            idstring = fileReader.ReadLine()
            If (Not (idstring = "") And Not (idstring = " ")) Then studySize += 1
        End While

        'now we can actually read in the subject's data        
        ReDim studyIds(studySize - 1)
        If studySize > 0 Then
            fileReader.Close()
            fileReader = My.Computer.FileSystem.OpenTextFileReader(GAMEPATH & "gameSettings\" & studyList)

            For i As Integer = 0 To (studySize - 1) Step 1
                studyIds(i) = ""
                While studyIds(i) = "" Or studyIds(i) = " "
                    studyIds(i) = fileReader.ReadLine()
                End While
            Next i

            fileReader.Close()
        End If

    End Sub

    '--------------------------------------------------------------------------------'
    '--------------------------- add study to the population ------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub addStudy(ByRef studyID As String)
        Dim idLine = vbNewLine & studyID        
        Dim oldStudyIds() As String
        My.Computer.FileSystem.WriteAllText(GAMEPATH & "gameSettings\" & studyList, idLine, True)

        oldStudyIds = studyIds        
        ReDim studyIds(studySize)

        For i = 0 To (studySize - 1) Step 1            
            studyIds(i) = oldStudyIds(i)
        Next i

        studySize += 1

        studyIds(studySize - 1) = studyID        
    End Sub

End Class
