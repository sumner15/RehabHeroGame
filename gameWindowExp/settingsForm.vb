Public Class settingsForm

    Private gameSettings As GameSettings
    Public ID As String

    '--------------------------------------------------------------------------------'
    '---------------------- constructor for the settings screen ---------------------'
    '--------------------------------------------------------------------------------'
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        gameSettings = New GameSettings()
        gameSettings.readGameSetFile()
        ID = currentSub.ID

        ''first, check if there is an existing settings file. Otherwise, the default values will be set
        If My.Computer.FileSystem.FileExists(GAMEPATH & "gameSettings\" & ID & ".txt") Then
            minMsecBetweenBurstsHSB.Value = gameSettings.get_minMsecBetweenBursts
            maxMsecBetweenBurstsHSB.Value = gameSettings.get_maxMsecBetweenBursts         'Note: getter functions always returning '0', not defaults (fileDict)
            maxNotesPerRiffHSB.Value = gameSettings.get_maxNumberNotesPerBurst            'Note: when I try to set HSB.Value here, it crashes
            reactionTimeHSB.Value = gameSettings.get_allowedReactionTime
            assistanceModeHSB.Value = gameSettings.get_assistanceMode
            Kp1StartHSB.Value = gameSettings.get_Kp1Start
            Kp2StartHSB.Value = gameSettings.get_Kp2Start
        End If

        minBurstValLbl.Text = CStr(CSng(minMsecBetweenBurstsHSB.Value))
        maxBurstValLbl.Text = CStr(CSng(maxMsecBetweenBurstsHSB.Value))
        maxNotesValLbl.Text = CStr(CSng(maxNotesPerRiffHSB.Value))
        reactionTimeValLbl.Text = CStr(CSng(reactionTimeHSB.Value))
        assistanceModeValLbl.Text = CStr(CSng(assistanceModeHSB.Value))
        Kp1StartValLbl.Text = CStr(CSng(Kp1StartHSB.Value))
        Kp2StartValLbl.Text = CStr(CSng(Kp2StartHSB.Value))
    End Sub


#Region "HSB value labels"
    Private Sub minMsecBetweenBurstsHSB_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles minMsecBetweenBurstsHSB.Scroll
        minBurstValLbl.Text = CStr(CSng(minMsecBetweenBurstsHSB.Value))
    End Sub

    Private Sub maxMsecBetweenBurstsHSB_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles maxMsecBetweenBurstsHSB.Scroll
        maxBurstValLbl.Text = CStr(CSng(maxMsecBetweenBurstsHSB.Value))
    End Sub

    Private Sub maxNotesPerRiffHSB_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles maxNotesPerRiffHSB.Scroll
        maxNotesValLbl.Text = CStr(CSng(maxNotesPerRiffHSB.Value))
    End Sub

    Private Sub reactionTimeHSB_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles reactionTimeHSB.Scroll
        reactionTimeValLbl.Text = CStr(CSng(reactionTimeHSB.Value))
    End Sub

    Private Sub assistanceModeHSB_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles assistanceModeHSB.Scroll
        assistanceModeValLbl.Text = CStr(CSng(assistanceModeHSB.Value))
    End Sub

    Private Sub Kp1StartHSB_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Kp1StartHSB.Scroll
        Kp1StartValLbl.Text = CStr(CSng(Kp1StartHSB.Value))
    End Sub

    Private Sub Kp2StartHSB_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Kp2StartHSB.Scroll
        Kp2StartValLbl.Text = CStr(CSng(Kp2StartHSB.Value))
    End Sub
#End Region

    Private Sub saveSettingsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveSettingsBtn.Click
        'make sure we have set real-life-possible values before we set anything
        If CSng(maxMsecBetweenBurstsHSB.Value) > CSng(minMsecBetweenBurstsHSB.Value) Then
            '---set all the settings from the scrollbar---'

            gameSettings.set_minMsecBetweenBursts(CSng(minMsecBetweenBurstsHSB.Value))
            gameSettings.set_maxMsecBetweenBursts(CSng(maxMsecBetweenBurstsHSB.Value))
            gameSettings.set_maxNumberNotesPerBurst(CSng(maxNotesPerRiffHSB.Value))
            gameSettings.set_allowedReactionTime(CSng(reactionTimeHSB.Value))
            gameSettings.set_assistanceMode(CSng(assistanceModeHSB.Value))
            gameSettings.set_Kp1Start(CSng(Kp1StartHSB.Value))
            gameSettings.set_Kp2Start(CSng(Kp2StartHSB.Value))
            gameSettings.writeGameSetFile()

            '---------------------------------------------'
            Me.Close() 'close the setting window'
        Else
            MsgBox("please set the maximum time between bursts larger than the minimum time between bursts")
        End If

    End Sub
End Class

