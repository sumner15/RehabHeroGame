﻿'----------------------------------------------------------------------------------'
'-------------------------- the windows form menu codez ---------------------------'
'----------------------------------------------------------------------------------'
Public Class Menu
    Private pop As Population
    Private library As Library
    Private gameRunning As Boolean
    Public ourWindow As SongGame
    Public measurementGame As measureForce
    Public settingsMenu As settingsForm

    '--------------------------------------------------------------------------------'
    '------------------------- constructor for the menu screen ----------------------'
    '--------------------------------------------------------------------------------'
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        pop = New Population()
        library = New Library()
        subjectList.DataSource = pop.subIds
        songList.DataSource = library.songNames
        gameRunning = 0
        currentSub = pop.subjects(0)
        currentSong = library.songs(0)
    End Sub

    '--------------------------------------------------------------------------------'
    '--------------------------- add subject button event ---------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub updateLstBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles updateLstBtn.Click
        Dim subj As Subject
        Dim num As Integer           ' number corresponding to subject

        If Not (subIdTb.Text = "") Then
            num = pop.popSize + 1
            'subj = New Subject(num, subIdTb.Text, subHandList.SelectedItem, 1)
            subj = New Subject(num, subIdTb.Text, 1)
            pop.addSubject(subj)

            subjectList.DataSource = pop.subIds
            subjectList.Update()
        Else
            MsgBox("Enter the subject's information before trying to save the subject.")
        End If
    End Sub

    '--------------------------------------------------------------------------------'
    '--------------------------- click subject list event ---------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub subjectList_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles subjectList.SelectedValueChanged
        Dim selected As Integer
        selected = subjectList.SelectedIndex
        currentSub = pop.subjects(selected)
        updateSubjectInfoGUI()
    End Sub

    Private Sub updateSubjectInfoGUI()
        lastSessionLabel.Text = currentSub.getSessionString()
        sessionNumberTB.Text = currentSub.getExpectedSessionNumber()
    End Sub

    '--------------------------------------------------------------------------------'
    '------------------------------ click song list event ---------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub songList_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles songList.SelectedValueChanged
        Dim selected As Integer
        selected = songList.SelectedIndex
        currentSong = library.songs(selected)
        thumbnail.ImageLocation = currentSong.songPath & "thumbnail.jpg"
        songNameLbl.Text = currentSong.name
    End Sub

    '--------------------------------------------------------------------------------'
    '---------------------------------- play song button ----------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub playSongBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles playSongBtn.Click

        If currentSub.ID = "default" Then MsgBox("select a real subject name") : Return
        If difficultyList.SelectedIndex = -1 Then MsgBox("choose a difficulty level") : Return

        currentSub.trial += 1
        currentSub.lastSessionDate = Now()
        currentSub.lastSessionNumber = sessionNumberTB.Text
        currentSub.update()
        updateSubjectInfoGUI()

        Dim successRate As Single
        Dim perceivedSuccessRate As Single
        Dim difficulties() As Integer = {level.superEasy, level.easy, level.medium}
        If Not difficultyList.SelectedIndex >= 0 Then
            difficultyList.SelectedIndex = 0
        End If

        successRate = CSng(gameSets.get_sucRate) / 100.0
        perceivedSuccessRate = CSng(gameSets.get_fakeSucRate) / 100.0

        If successRate = 0 Then successRate = 0.75
        If perceivedSuccessRate = 0 Then perceivedSuccessRate = 0.75

        If Not gameRunning Then
            If useExplicitGains Then

                Dim propGains() As Single = {gameSets.get_gains, gameSets.get_gains}

                gameRunning = True
                trialStr = currentSong.name & "_" & CStr(CInt(perceivedSuccessRate * 100)) & "_"                
                ourWindow = New SongGame(currentSong, perceivedSuccessRate, propGains, difficulties(difficultyList.SelectedIndex))
                ourWindow.Run(FPS)
                ourWindow.Dispose()
                gameRunning = False
            Else
                gameRunning = True
                trialStr = currentSong.name & "_" & CStr(CInt(perceivedSuccessRate * 100)) & "_"
                ourWindow = New SongGame(currentSong, successRate, perceivedSuccessRate, difficulties(difficultyList.SelectedIndex))
                ourWindow.Run(FPS)
                ourWindow.Dispose()
                gameRunning = False
            End If

        End If
    End Sub

    '--------------------------------------------------------------------------------'
    '--------------------------- Range of Motion Btn press --------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub rangeOfMotionBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rangeOfMotionBtn.Click
        If Not gameRunning Then
            gameRunning = True
            trialStr = "rom"
            measurementGame = New measureForce(False, 0.12)
            measurementGame.Run(FPS)
            measurementGame.Dispose()
            gameRunning = False
        End If
    End Sub

    '--------------------------------------------------------------------------------'
    '--------------------------- isometric forces btn click -------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub isometricForcesBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles isometricForcesBtn.Click
        If Not gameRunning Then
            gameRunning = True
            trialStr = "isometric"
            measurementGame = New measureForce(True, 0.07)
            measurementGame.Run(FPS)
            measurementGame.Dispose()
            gameRunning = False
        End If
    End Sub

    '--------------------------------------------------------------------------------'
    '--------------------------- Game Settings Btn press ----------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub gameSettingsBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gameSettingsBtn.Click
        'opens a new settings form
        settingsMenu = New settingsForm
        settingsMenu.Show()
    End Sub

   
End Class