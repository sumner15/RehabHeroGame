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
    Private useExplicitGains As Boolean
    Private sucRate As Single
    Private fakeSucRate As Single
    Private gains As Single

    Public settingsFileName As String = "default"
    Public studyIds() As String

    Private gameSetDic As FileDict

    '----------------------------------------------------------------------------------'
    '------------------------------------ constructor ---------------------------------'
    '----------------------------------------------------------------------------------'
    Public Sub New(ByVal studyID As String)
        settingsFileName = studyID
        readGameSetFile()
    End Sub


    '--------------------------------------------------------------------------------'
    '--------------------------- write game settings file ---------------------------'
    '--------------------------------------------------------------------------------'
    Public Sub writeGameSetFile()
        Dim fullFileName As String = GAMEPATH & "gameSettings\" & settingsFileName & ".txt"
        Console.WriteLine(fullFileName)
        Dim gameSetFile As StreamWriter = New StreamWriter(fullFileName)
        gameSetFile.WriteLine("minMsecBetweenBursts: " & minMsecBetweenBursts)
        gameSetFile.WriteLine("maxMsecBetweenBursts: " & maxMsecBetweenBursts)
        gameSetFile.WriteLine("maxNumberNotesPerBurst: " & maxNumberNotesPerBurst)
        gameSetFile.WriteLine("allowedReactionTime: " & allowedReactionTime)
        gameSetFile.WriteLine("sucRate: " & sucRate)
        gameSetFile.WriteLine("fakeSucRate: " & fakeSucRate)
        gameSetFile.WriteLine("useExplicitGains: " & useExplicitGains)
        gameSetFile.WriteLine("gains: " & gains)
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
        allowedReactionTime = gameSetDic.Lookup("allowedReactionTime", "1000")
        useExplicitGains = gameSetDic.Lookup("useExplicitGains", "False")
        sucRate = gameSetDic.Lookup("sucRate", "0.5")
        fakeSucRate = gameSetDic.Lookup("fakeSucRate", "0.5")
        gains = gameSetDic.Lookup("gains", "0")

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

    Public Function get_maxNumberNotesPerBurst() As Integer
        Return maxNumberNotesPerBurst
    End Function

    Public Function get_allowedReactionTime() As Single
        Return allowedReactionTime
    End Function

    Public Function get_useExplicitGains() As Boolean
        Return useExplicitGains
    End Function

    Public Function get_sucRate() As Single
        Return sucRate
    End Function

    Public Function get_fakeSucRate() As Single
        Return fakeSucRate
    End Function

    Public Function get_gains() As Single
        Return gains
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

    Public Sub set_useExplicitGains(ByVal newval As Boolean)
        useExplicitGains = newval
    End Sub

    Public Sub set_sucRate(ByVal newVal As Single)
        sucRate = newVal
    End Sub

    Public Sub set_fakeSucRate(ByVal newVal As Single)
        fakeSucRate = newVal
    End Sub

    Public Sub set_gains(ByVal newVal As Single)
        gains = newVal
    End Sub
#End Region

End Class

