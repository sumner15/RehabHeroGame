Imports System.IO

'----------------------------------------------------------------------------------'
'------------------------ class containing game settings --------------------------'
'----------------------------------------------------------------------------------'
' This class will be used to record the settings that the user selects from the GUI.
' These settings will determine the performance of the game. For example the class
' specifies how early upcoming notes will be displayed to the user, how assistance
' should be applied, etc. 


Public Class GameSettings

    Private minMsecBetweenBursts As Single
    Private maxMsecBetweenBursts As Single
    Private maxNumberNotesPerBurst As Integer
    Private allowedReactionTime As Single 'how early the object appears in miliseconds
    Private assistanceMode As Integer
    Private Kp1Start As Single
    Private Kp2Start As Single

    Private settingsFileName As String = "default"

    Private gameSetDic As FileDict

    Public ID As String

    '----------------------------------------------------------------------------------'
    '------------------------------------ constructor ---------------------------------'
    '----------------------------------------------------------------------------------'
    Public Sub New()
        ID = currentSub.ID
    End Sub

    'Public Sub New()
    '    ID = currentSub.ID
    '    If My.Computer.FileSystem.FileExists(GAMEPATH & "gameSettings\" & ID & ".txt") Then
    '        readGameSetFile()
    '    Else
    '        minMsecBetweenBursts = 300
    '        maxMsecBetweenBursts = 1000
    '        maxNumberNotesPerBurst = 1
    '        allowedReactionTime = 51
    '        assistanceMode = 2
    '        Kp1Start = 2
    '        Kp2Start = 2
    '    End If
    'End Sub


    '--------------------------------------------------------------------------------'
    '--------------------------- write game settings file ---------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub writeGameSetFile()        
        Dim gameSetFile As StreamWriter = New StreamWriter(GAMEPATH & "gameSettings\" & settingsFileName & ".txt")
        gameSetFile.WriteLine("minMsecBetweenBursts: " & minMsecBetweenBursts)
        gameSetFile.WriteLine("maxMsecBetweenBursts: " & maxMsecBetweenBursts)
        gameSetFile.WriteLine("maxNumberNotesPerBurst: " & maxNumberNotesPerBurst)
        gameSetFile.WriteLine("allowedReactionTime: " & allowedReactionTime)
        gameSetFile.WriteLine("assistanceMode: " & assistanceMode)
        gameSetFile.WriteLine("Kp1Start: " & Kp1Start)
        gameSetFile.WriteLine("Kp2Start: " & Kp2Start)
        gameSetFile.Close()
    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------------------- read file -----------------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub readGameSetFile()
        Dim gameSetDic As FileDict = New FileDict(GAMEPATH & "gameSettings\" & settingsFileName & ".txt")
        minMsecBetweenBursts = gameSetDic.Lookup("minMsecBetweenBursts", "300")
        maxMsecBetweenBursts = gameSetDic.Lookup("maxMsecBetweenBursts", "1000")
        maxNumberNotesPerBurst = gameSetDic.Lookup("maxNumberNotesPerBurst", "1")
        allowedReactionTime = gameSetDic.Lookup("allowedReactionTime", "51")
        assistanceMode = gameSetDic.Lookup("assistanceMode", "2")
        Kp1Start = gameSetDic.Lookup("Kp1Start", "2")
        Kp2Start = gameSetDic.Lookup("Kp2Start", "2")

    End Sub

    '----------------------------------------------------------------------------------'
    '---------------------- functions to get private values ---------------------------'
    '----------------------------------------------------------------------------------'
#Region "getter functions"
    Public Function get_minMsecBetweenBursts() As Single
        Return minMsecBetweenBursts
    End Function

    Public Function get_maxMsecBetweenBursts() As Single
        Return maxMsecBetweenBursts
    End Function

    Public Function get_maxNumberNotesPerBurst() As Single
        Return maxNumberNotesPerBurst
    End Function

    Public Function get_allowedReactionTime() As Single
        Return allowedReactionTime
    End Function

    Public Function get_assistanceMode() As Single
        Return assistanceMode
    End Function

    Public Function get_Kp1Start() As Single
        Return Kp1Start
    End Function

    Public Function get_Kp2Start() As Single
        Return Kp2Start
    End Function
#End Region

    '----------------------------------------------------------------------------------'
    '---------------------- functions to set private values ---------------------------'
    '----------------------------------------------------------------------------------'
#Region "setter functions"
    Public Sub set_minMsecBetweenBursts(ByVal newVal As Single)
        minMsecBetweenBursts = newVal        
    End Sub

    Public Sub set_maxMsecBetweenBursts(ByVal newVal As Single)
        maxMsecBetweenBursts = newVal
    End Sub

    Public Sub set_maxNumberNotesPerBurst(ByVal newVal As Integer)
        maxNumberNotesPerBurst = newVal
    End Sub

    Public Sub set_allowedReactionTime(ByVal newVal As Single)
        allowedReactionTime = newVal
    End Sub

    Public Sub set_assistanceMode(ByVal newVal As Integer)
        assistanceMode = newVal
    End Sub

    Public Sub set_Kp1Start(ByVal newVal As Single)
        Kp1Start = newVal
    End Sub

    Public Sub set_Kp2Start(ByVal newVal As Single)
        Kp2Start = newVal        
    End Sub
#End Region

End Class

