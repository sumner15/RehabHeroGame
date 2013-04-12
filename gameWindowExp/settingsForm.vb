Public Class settingsForm

    Private studyPop As StudyPopulation

    '--------------------------------------------------------------------------------'
    '---------------------- constructor for the settings screen ---------------------'
    '--------------------------------------------------------------------------------'
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.          
        gameSets.readGameSetFile()
        studyPop = New StudyPopulation()
        studyList.DataSource = studyPop.studyIds

        'first, check if there is an existing settings file ("default")
        If My.Computer.FileSystem.FileExists(GAMEPATH & "gameSettings\" & gameSets.settingsFileName & ".txt") Then
            set_allSettings()
        End If
        'Set all of the labels to the HSB start values
        set_allLabels()
    End Sub


    '--------------------------------------------------------------------------------'
    '---------------------- reset the labels when a HSB is used ---------------------'
    '--------------------------------------------------------------------------------'
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

    '--------------------------------------------------------------------------------'
    '--------------------------- click save set list event --------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub saveSettingsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveSettingsBtn.Click
        'make sure we have set real-life-possible values before we set anything
        If CSng(maxMsecBetweenBurstsHSB.Value) > CSng(minMsecBetweenBurstsHSB.Value) Then
            '---set all the settings from the scrollbars---'
            set_allSettings()            
            Me.Close() 'close the setting window'
        Else
            MsgBox("please set the maximum time between bursts larger than the minimum time between bursts")
        End If

    End Sub


    '--------------------------------------------------------------------------------'
    '--------------------------- click study list event -----------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub studyList_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles studyList.SelectedValueChanged
        Dim selected As Integer
        selected = studyList.SelectedIndex        

        gameSets.settingsFileName = studyList.SelectedValue
        gameSets.readGameSetFile()

        'first, check if there is an existing settings file. Otherwise, the default values will be set
        If My.Computer.FileSystem.FileExists(GAMEPATH & "gameSettings\" & gameSets.settingsFileName & ".txt") Then
            get_allSettings()
        End If        
        set_allLabels()
    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------------- add study button event ----------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub updateLstBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateLstBtn.Click                
        If Not (studyIdTb.Text = "") Then
            gameSets.settingsFileName = studyIdTb.Text
            ' make sure we have set real-life-possible values before we set anything
            If CSng(maxMsecBetweenBurstsHSB.Value) > CSng(minMsecBetweenBurstsHSB.Value) Then
                '---set all the settings from the scrollbars---'
                set_allSettings()
            Else
                MsgBox("please set the maximum time between bursts larger than the minimum time between bursts")
            End If

            'update the studies list'
            studyPop.addStudy(studyIdTb.Text)
            studyList.DataSource = studyPop.studyIds
            studyList.Update()

            Me.Close() 'close the setting window'
        Else
            MsgBox("Enter the subject's information before trying to save the subject.")
        End If
    End Sub


    '--------------------------------------------------------------------------------'
    '-------------------- common use functions (get/set values) ---------------------'
    '--------------------------------------------------------------------------------'
#Region "get and set"
    Private Sub set_allSettings()
        'this function's purpose is to set all values from the scroll bars to the gameSets object
        gameSets.set_minMsecBetweenBursts(CSng(minMsecBetweenBurstsHSB.Value))
        gameSets.set_maxMsecBetweenBursts(CSng(maxMsecBetweenBurstsHSB.Value))
        gameSets.set_maxNumberNotesPerBurst(CSng(maxNotesPerRiffHSB.Value))
        gameSets.set_allowedReactionTime(CSng(reactionTimeHSB.Value))
        gameSets.set_assistanceMode(CSng(assistanceModeHSB.Value))
        gameSets.set_Kp1Start(CSng(Kp1StartHSB.Value))
        gameSets.set_Kp2Start(CSng(Kp2StartHSB.Value))
        gameSets.writeGameSetFile()
    End Sub

    Private Sub get_allSettings()
        'this function's purpose is to retrieve the settings from the gameSets object
        'in order to set those values on the scroll bars
        minMsecBetweenBurstsHSB.Value = gameSets.get_minMsecBetweenBursts
        maxMsecBetweenBurstsHSB.Value = gameSets.get_maxMsecBetweenBursts
        maxNotesPerRiffHSB.Value = gameSets.get_maxNumberNotesPerBurst
        reactionTimeHSB.Value = gameSets.get_allowedReactionTime
        assistanceModeHSB.Value = gameSets.get_assistanceMode
        Kp1StartHSB.Value = gameSets.get_Kp1Start
        Kp2StartHSB.Value = gameSets.get_Kp2Start
    End Sub

    Private Sub set_allLabels()
        'this function's purpose is to refresh the labels next to each scroll bar
        minBurstValLbl.Text = CStr(CSng(minMsecBetweenBurstsHSB.Value))
        maxBurstValLbl.Text = CStr(CSng(maxMsecBetweenBurstsHSB.Value))
        maxNotesValLbl.Text = CStr(CSng(maxNotesPerRiffHSB.Value))
        reactionTimeValLbl.Text = CStr(CSng(reactionTimeHSB.Value))
        assistanceModeValLbl.Text = CStr(CSng(assistanceModeHSB.Value))
        Kp1StartValLbl.Text = CStr(CSng(Kp1StartHSB.Value))
        Kp2StartValLbl.Text = CStr(CSng(Kp2StartHSB.Value))
    End Sub
#End Region

End Class

