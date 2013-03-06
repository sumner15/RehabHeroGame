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
        Dim num As Integer           ' number corresponding to subejct

        If Not (subIdTb.Text = "") Then
            num = pop.popSize + 1
            subj = New Subject(num, subIdTb.Text)
            pop.addSubejct(subj)

            subjectList.DataSource = pop.subIds
            subjectList.Update()
        Else
            MsgBox("Enter the subject's information before trying to save the subejct.")
        End If
    End Sub

    '--------------------------------------------------------------------------------'
    '--------------------------- click subject list event ---------------------------'
    '--------------------------------------------------------------------------------'
    Private Sub subjectList_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles subjectList.SelectedValueChanged
        Dim selected As Integer
        selected = subjectList.SelectedIndex
        currentSub = pop.subjects(selected)
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
        Dim successRate As Single
        Dim perceivedSuccessRate As Single
        Dim difficulties() As Integer = {level.superEasy, level.easy, level.medium}
        If Not gameRunning Then
            successRate = successRateList.SelectedItem
            perceivedSuccessRate = perceivedSuccessLB.SelectedItem
            If successRate = 0 Then successRate = 0.75
            If perceivedSuccessRate = 0 Then perceivedSuccessRate = 0.75

            gameRunning = True
            trialStr = currentSong.name & "_" & CStr(CInt(perceivedSuccessRate * 100)) & "_"
            ourWindow = New SongGame(currentSong, successRate, perceivedSuccessRate, difficulties(difficultyList.SelectedIndex))
            ourWindow.Run(FPS)
            ourWindow.Dispose()
            gameRunning = False
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
End Class