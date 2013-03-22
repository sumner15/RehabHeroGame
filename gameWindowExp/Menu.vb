'----------------------------------------------------------------------------------'
'-------------------------- the windows form menu codez ---------------------------'
'----------------------------------------------------------------------------------'
Public Class Menu
    Private pop As Population
    Private library As Library
    Private gameRunning As Boolean
    Public ourWindow As SongGame
    Public measurementGame As measureForce

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
            subj = New Subject(num, subIdTb.Text, subHandList.SelectedItem, 1)
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
        trialNumLbl.Text = currentSub.getTrial()
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

        currentSub.trial += 1
        currentSub.update()

        Dim successRate As Single
        Dim perceivedSuccessRate As Single
        Dim difficulties() As Integer = {level.superEasy, level.easy, level.medium}

        successRate = CSng(setSucRateHSB.Value) / 100.0
        perceivedSuccessRate = CSng(setFakeSucRateHSB.Value) / 100.0

        If successRate = 0 Then successRate = 0.75
        If perceivedSuccessRate = 0 Then perceivedSuccessRate = 0.75

        If Not gameRunning Then
            If useExplicitGainsBtn.Checked Then

                Dim propGains() As Single = {setGainsHSB.Value, setGainsHSB.Value}

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
    '-------------------------- update horizontal scroll bars -----------------------'
    '--------------------------------------------------------------------------------'
    Private Sub setSucRateHSB_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles setSucRateHSB.Scroll
        ' I want this slider to be discrete
        If setSucRateHSB.Value >= 80 Then
            setSucRateHSB.Value = 99
        ElseIf setSucRateHSB.Value < 80 And setSucRateHSB.Value > 60 Then
            setSucRateHSB.Value = 75
        ElseIf setSucRateHSB.Value <= 60 Then
            setSucRateHSB.Value = 50
        End If

        successRateLbl.Text = CStr(CSng(setSucRateHSB.Value) / 100)
    End Sub

    Private Sub setFakeSucRateHSB_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles setFakeSucRateHSB.Scroll
        If setFakeSucRateHSB.Value >= 80 Then
            setFakeSucRateHSB.Value = 99
        ElseIf setFakeSucRateHSB.Value < 80 And setFakeSucRateHSB.Value > 60 Then
            setFakeSucRateHSB.Value = 75
        ElseIf setFakeSucRateHSB.Value <= 60 Then
            setFakeSucRateHSB.Value = 50
        End If

        fakeSuccessRateLbl.Text = CStr(CSng(setFakeSucRateHSB.Value) / 100)
    End Sub

    Private Sub setGainsHSB_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles setGainsHSB.Scroll
        setGainsTb.Text = CStr(setGainsHSB.Value)
    End Sub

    '--------------------------------------------------------------------------------'
    '----------------- toggle explicit gains settings visibility --------------------'
    '--------------------------------------------------------------------------------'
    Private Sub useExplicitGainsBtn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles useExplicitGainsBtn.CheckedChanged
        setGainsHSB.Visible = useExplicitGainsBtn.Checked
        setGainsInstructions.Visible = useExplicitGainsBtn.Checked
        setGainsTb.Visible = useExplicitGainsBtn.Checked

        If useExplicitGainsBtn.Checked Then
            successRateLbl.Text = "not used"
        End If
    End Sub

   
    Private Sub setGainsTb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles setGainsTb.TextChanged
        If IsNumeric(setGainsTb.Text) Then
            Dim val = CInt(setGainsTb.Text)
            If val <= setGainsHSB.Maximum Then
                setGainsHSB.Value = CInt(setGainsTb.Text)
            End If
        Else
            If Not (setGainsTb.Text = "" Or setGainsTb.Text = " ") Then
                MsgBox("friend, you seem to be confused. You can only put number is this box.")
            End If
        End If

    End Sub
End Class