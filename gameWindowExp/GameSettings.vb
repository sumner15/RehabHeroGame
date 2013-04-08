'----------------------------------------------------------------------------------'
'------------------------ class containing game settings --------------------------'
'----------------------------------------------------------------------------------'
' this class will be used to record the settings that the user selects from, the GUI
' these settings will dewtermine the performance of the game. For example the class
' specify how early upcoming notes will be displayed to the user, how assistance
' should be applied, etc. The class should also be serializable and retreivable


Public Class GameSettings


    Private minMsecBetweenBursts As Single
    Private maxMsecBetweenBursts As Single
    Private maxNumberOFNotesPerBurst As Single

    Private allowedReactionTime As Single 'how early the object appears in miliseconds
    Private assistanceMode As Integer

    Private Kp1Start As Single
    Private Kp2Start As Single

    '---------------------- functions to get private values ---------------------------'
    '------------------------------------ constructor ---------------------------------'
    Public Sub New()

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
#End Region

End Class

