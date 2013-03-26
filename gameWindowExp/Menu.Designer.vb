<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Me.subjectList = New System.Windows.Forms.ListBox()
        Me.titleRehabHeroLbl = New System.Windows.Forms.Label()
        Me.subjectPnl = New System.Windows.Forms.Panel()
        Me.updateLstBtn = New System.Windows.Forms.Button()
        Me.subIDLbl = New System.Windows.Forms.Label()
        Me.subIdTb = New System.Windows.Forms.TextBox()
        Me.songList = New System.Windows.Forms.ListBox()
        Me.songPnl = New System.Windows.Forms.Panel()
        Me.songNameLbl = New System.Windows.Forms.Label()
        Me.thumbnail = New System.Windows.Forms.PictureBox()
        Me.playSongBtn = New System.Windows.Forms.Button()
        Me.difficultyList = New System.Windows.Forms.ListBox()
        Me.isometricForcesBtn = New System.Windows.Forms.Button()
        Me.rangeOfMotionBtn = New System.Windows.Forms.Button()
        Me.gameSettingPnl = New System.Windows.Forms.Panel()
        Me.setGainsTb = New System.Windows.Forms.TextBox()
        Me.useExplicitGainsBtn = New System.Windows.Forms.CheckBox()
        Me.setGainsInstructions = New System.Windows.Forms.Label()
        Me.setGainsHSB = New System.Windows.Forms.HScrollBar()
        Me.fakeSuccessRateLbl = New System.Windows.Forms.Label()
        Me.setFakeSucRateHSB = New System.Windows.Forms.HScrollBar()
        Me.successRateLbl = New System.Windows.Forms.Label()
        Me.setSucRateHSB = New System.Windows.Forms.HScrollBar()
        Me.fakeSuccessRateTitle = New System.Windows.Forms.Label()
        Me.successRateTitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lastSessionLabel = New System.Windows.Forms.Label()
        Me.sessionNumberTB = New System.Windows.Forms.TextBox()
        Me.subjectPnl.SuspendLayout()
        Me.songPnl.SuspendLayout()
        CType(Me.thumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gameSettingPnl.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'subjectList
        '
        Me.subjectList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subjectList.FormattingEnabled = True
        Me.subjectList.ItemHeight = 18
        Me.subjectList.Location = New System.Drawing.Point(10, 61)
        Me.subjectList.Name = "subjectList"
        Me.subjectList.Size = New System.Drawing.Size(180, 364)
        Me.subjectList.TabIndex = 0
        '
        'titleRehabHeroLbl
        '
        Me.titleRehabHeroLbl.AutoSize = True
        Me.titleRehabHeroLbl.BackColor = System.Drawing.Color.Transparent
        Me.titleRehabHeroLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titleRehabHeroLbl.ForeColor = System.Drawing.Color.White
        Me.titleRehabHeroLbl.Location = New System.Drawing.Point(6, 23)
        Me.titleRehabHeroLbl.Name = "titleRehabHeroLbl"
        Me.titleRehabHeroLbl.Size = New System.Drawing.Size(181, 33)
        Me.titleRehabHeroLbl.TabIndex = 1
        Me.titleRehabHeroLbl.Text = "Rehab Hero"
        '
        'subjectPnl
        '
        Me.subjectPnl.Controls.Add(Me.updateLstBtn)
        Me.subjectPnl.Controls.Add(Me.subIDLbl)
        Me.subjectPnl.Controls.Add(Me.subIdTb)
        Me.subjectPnl.Location = New System.Drawing.Point(12, 505)
        Me.subjectPnl.Name = "subjectPnl"
        Me.subjectPnl.Size = New System.Drawing.Size(342, 66)
        Me.subjectPnl.TabIndex = 2
        '
        'updateLstBtn
        '
        Me.updateLstBtn.Location = New System.Drawing.Point(207, 23)
        Me.updateLstBtn.Name = "updateLstBtn"
        Me.updateLstBtn.Size = New System.Drawing.Size(121, 23)
        Me.updateLstBtn.TabIndex = 3
        Me.updateLstBtn.Text = "Update Subject List"
        Me.updateLstBtn.UseVisualStyleBackColor = True
        '
        'subIDLbl
        '
        Me.subIDLbl.AutoSize = True
        Me.subIDLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subIDLbl.Location = New System.Drawing.Point(3, 26)
        Me.subIDLbl.Name = "subIDLbl"
        Me.subIDLbl.Size = New System.Drawing.Size(100, 20)
        Me.subIDLbl.TabIndex = 1
        Me.subIDLbl.Text = "Add Subject:"
        '
        'subIdTb
        '
        Me.subIdTb.Location = New System.Drawing.Point(109, 25)
        Me.subIdTb.Name = "subIdTb"
        Me.subIdTb.Size = New System.Drawing.Size(92, 20)
        Me.subIdTb.TabIndex = 0
        '
        'songList
        '
        Me.songList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.songList.FormattingEnabled = True
        Me.songList.ItemHeight = 18
        Me.songList.Location = New System.Drawing.Point(193, 61)
        Me.songList.Name = "songList"
        Me.songList.Size = New System.Drawing.Size(161, 364)
        Me.songList.TabIndex = 3
        '
        'songPnl
        '
        Me.songPnl.Controls.Add(Me.songNameLbl)
        Me.songPnl.Controls.Add(Me.thumbnail)
        Me.songPnl.Location = New System.Drawing.Point(361, 61)
        Me.songPnl.Name = "songPnl"
        Me.songPnl.Size = New System.Drawing.Size(251, 281)
        Me.songPnl.TabIndex = 4
        '
        'songNameLbl
        '
        Me.songNameLbl.AutoSize = True
        Me.songNameLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.songNameLbl.Location = New System.Drawing.Point(-1, 251)
        Me.songNameLbl.Name = "songNameLbl"
        Me.songNameLbl.Size = New System.Drawing.Size(111, 24)
        Me.songNameLbl.TabIndex = 2
        Me.songNameLbl.Text = "Song Name"
        '
        'thumbnail
        '
        Me.thumbnail.Location = New System.Drawing.Point(3, 3)
        Me.thumbnail.Name = "thumbnail"
        Me.thumbnail.Size = New System.Drawing.Size(245, 245)
        Me.thumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.thumbnail.TabIndex = 0
        Me.thumbnail.TabStop = False
        '
        'playSongBtn
        '
        Me.playSongBtn.Location = New System.Drawing.Point(361, 348)
        Me.playSongBtn.Name = "playSongBtn"
        Me.playSongBtn.Size = New System.Drawing.Size(251, 44)
        Me.playSongBtn.TabIndex = 5
        Me.playSongBtn.Text = "Play Song"
        Me.playSongBtn.UseVisualStyleBackColor = True
        '
        'difficultyList
        '
        Me.difficultyList.FormattingEnabled = True
        Me.difficultyList.Items.AddRange(New Object() {"easy", "medium", "hard"})
        Me.difficultyList.Location = New System.Drawing.Point(187, 13)
        Me.difficultyList.Name = "difficultyList"
        Me.difficultyList.Size = New System.Drawing.Size(58, 56)
        Me.difficultyList.TabIndex = 9
        '
        'isometricForcesBtn
        '
        Me.isometricForcesBtn.Location = New System.Drawing.Point(361, 539)
        Me.isometricForcesBtn.Name = "isometricForcesBtn"
        Me.isometricForcesBtn.Size = New System.Drawing.Size(120, 32)
        Me.isometricForcesBtn.TabIndex = 10
        Me.isometricForcesBtn.Text = "isometric forces"
        Me.isometricForcesBtn.UseVisualStyleBackColor = True
        '
        'rangeOfMotionBtn
        '
        Me.rangeOfMotionBtn.Location = New System.Drawing.Point(487, 539)
        Me.rangeOfMotionBtn.Name = "rangeOfMotionBtn"
        Me.rangeOfMotionBtn.Size = New System.Drawing.Size(125, 32)
        Me.rangeOfMotionBtn.TabIndex = 11
        Me.rangeOfMotionBtn.Text = "range of motion"
        Me.rangeOfMotionBtn.UseVisualStyleBackColor = True
        '
        'gameSettingPnl
        '
        Me.gameSettingPnl.Controls.Add(Me.setGainsTb)
        Me.gameSettingPnl.Controls.Add(Me.useExplicitGainsBtn)
        Me.gameSettingPnl.Controls.Add(Me.setGainsInstructions)
        Me.gameSettingPnl.Controls.Add(Me.setGainsHSB)
        Me.gameSettingPnl.Controls.Add(Me.fakeSuccessRateLbl)
        Me.gameSettingPnl.Controls.Add(Me.setFakeSucRateHSB)
        Me.gameSettingPnl.Controls.Add(Me.successRateLbl)
        Me.gameSettingPnl.Controls.Add(Me.setSucRateHSB)
        Me.gameSettingPnl.Controls.Add(Me.fakeSuccessRateTitle)
        Me.gameSettingPnl.Controls.Add(Me.successRateTitle)
        Me.gameSettingPnl.Controls.Add(Me.difficultyList)
        Me.gameSettingPnl.Location = New System.Drawing.Point(364, 399)
        Me.gameSettingPnl.Name = "gameSettingPnl"
        Me.gameSettingPnl.Size = New System.Drawing.Size(248, 134)
        Me.gameSettingPnl.TabIndex = 13
        '
        'setGainsTb
        '
        Me.setGainsTb.AutoCompleteCustomSource.AddRange(New String() {"0"})
        Me.setGainsTb.Location = New System.Drawing.Point(141, 109)
        Me.setGainsTb.Name = "setGainsTb"
        Me.setGainsTb.Size = New System.Drawing.Size(17, 20)
        Me.setGainsTb.TabIndex = 24
        Me.setGainsTb.Text = "0"
        Me.setGainsTb.Visible = False
        '
        'useExplicitGainsBtn
        '
        Me.useExplicitGainsBtn.AutoSize = True
        Me.useExplicitGainsBtn.Checked = True
        Me.useExplicitGainsBtn.CheckState = System.Windows.Forms.CheckState.Checked
        Me.useExplicitGainsBtn.Location = New System.Drawing.Point(6, 75)
        Me.useExplicitGainsBtn.Name = "useExplicitGainsBtn"
        Me.useExplicitGainsBtn.Size = New System.Drawing.Size(111, 17)
        Me.useExplicitGainsBtn.TabIndex = 23
        Me.useExplicitGainsBtn.Text = "Use Explicit Gains"
        Me.useExplicitGainsBtn.UseVisualStyleBackColor = True
        '
        'setGainsInstructions
        '
        Me.setGainsInstructions.AutoSize = True
        Me.setGainsInstructions.Location = New System.Drawing.Point(4, 95)
        Me.setGainsInstructions.Name = "setGainsInstructions"
        Me.setGainsInstructions.Size = New System.Drawing.Size(96, 13)
        Me.setGainsInstructions.TabIndex = 20
        Me.setGainsInstructions.Text = "Set Gains Explicitly"
        '
        'setGainsHSB
        '
        Me.setGainsHSB.LargeChange = 15
        Me.setGainsHSB.Location = New System.Drawing.Point(6, 112)
        Me.setGainsHSB.Maximum = 45
        Me.setGainsHSB.Name = "setGainsHSB"
        Me.setGainsHSB.Size = New System.Drawing.Size(132, 13)
        Me.setGainsHSB.SmallChange = 5
        Me.setGainsHSB.TabIndex = 19
        '
        'fakeSuccessRateLbl
        '
        Me.fakeSuccessRateLbl.AutoSize = True
        Me.fakeSuccessRateLbl.Location = New System.Drawing.Point(142, 56)
        Me.fakeSuccessRateLbl.Name = "fakeSuccessRateLbl"
        Me.fakeSuccessRateLbl.Size = New System.Drawing.Size(16, 13)
        Me.fakeSuccessRateLbl.TabIndex = 18
        Me.fakeSuccessRateLbl.Text = ".5"
        '
        'setFakeSucRateHSB
        '
        Me.setFakeSucRateHSB.Location = New System.Drawing.Point(7, 57)
        Me.setFakeSucRateHSB.Maximum = 99
        Me.setFakeSucRateHSB.Minimum = 50
        Me.setFakeSucRateHSB.Name = "setFakeSucRateHSB"
        Me.setFakeSucRateHSB.Size = New System.Drawing.Size(132, 13)
        Me.setFakeSucRateHSB.SmallChange = 10
        Me.setFakeSucRateHSB.TabIndex = 17
        Me.setFakeSucRateHSB.Value = 50
        '
        'successRateLbl
        '
        Me.successRateLbl.AutoSize = True
        Me.successRateLbl.Location = New System.Drawing.Point(142, 19)
        Me.successRateLbl.Name = "successRateLbl"
        Me.successRateLbl.Size = New System.Drawing.Size(16, 13)
        Me.successRateLbl.TabIndex = 16
        Me.successRateLbl.Text = ".5"
        '
        'setSucRateHSB
        '
        Me.setSucRateHSB.Location = New System.Drawing.Point(7, 21)
        Me.setSucRateHSB.Maximum = 99
        Me.setSucRateHSB.Minimum = 50
        Me.setSucRateHSB.Name = "setSucRateHSB"
        Me.setSucRateHSB.Size = New System.Drawing.Size(132, 13)
        Me.setSucRateHSB.TabIndex = 1
        Me.setSucRateHSB.Value = 50
        '
        'fakeSuccessRateTitle
        '
        Me.fakeSuccessRateTitle.AutoSize = True
        Me.fakeSuccessRateTitle.Location = New System.Drawing.Point(3, 41)
        Me.fakeSuccessRateTitle.Name = "fakeSuccessRateTitle"
        Me.fakeSuccessRateTitle.Size = New System.Drawing.Size(120, 13)
        Me.fakeSuccessRateTitle.TabIndex = 14
        Me.fakeSuccessRateTitle.Text = "Set Fake Success Rate"
        '
        'successRateTitle
        '
        Me.successRateTitle.AutoSize = True
        Me.successRateTitle.Location = New System.Drawing.Point(4, 4)
        Me.successRateTitle.Name = "successRateTitle"
        Me.successRateTitle.Size = New System.Drawing.Size(93, 13)
        Me.successRateTitle.TabIndex = 13
        Me.successRateTitle.Text = "Set Success Rate"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.lastSessionLabel)
        Me.Panel1.Controls.Add(Me.sessionNumberTB)
        Me.Panel1.Location = New System.Drawing.Point(10, 431)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(344, 68)
        Me.Panel1.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(130, 20)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Session Number:"
        '
        'lastSessionLabel
        '
        Me.lastSessionLabel.AutoSize = True
        Me.lastSessionLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lastSessionLabel.Location = New System.Drawing.Point(4, 40)
        Me.lastSessionLabel.Name = "lastSessionLabel"
        Me.lastSessionLabel.Size = New System.Drawing.Size(81, 15)
        Me.lastSessionLabel.TabIndex = 1
        Me.lastSessionLabel.Text = "last session: -"
        '
        'sessionNumberTB
        '
        Me.sessionNumberTB.Location = New System.Drawing.Point(139, 7)
        Me.sessionNumberTB.Name = "sessionNumberTB"
        Me.sessionNumberTB.Size = New System.Drawing.Size(69, 20)
        Me.sessionNumberTB.TabIndex = 0
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(624, 583)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gameSettingPnl)
        Me.Controls.Add(Me.rangeOfMotionBtn)
        Me.Controls.Add(Me.isometricForcesBtn)
        Me.Controls.Add(Me.playSongBtn)
        Me.Controls.Add(Me.songPnl)
        Me.Controls.Add(Me.songList)
        Me.Controls.Add(Me.subjectPnl)
        Me.Controls.Add(Me.titleRehabHeroLbl)
        Me.Controls.Add(Me.subjectList)
        Me.Name = "Menu"
        Me.Text = "Menu"
        Me.subjectPnl.ResumeLayout(False)
        Me.subjectPnl.PerformLayout()
        Me.songPnl.ResumeLayout(False)
        Me.songPnl.PerformLayout()
        CType(Me.thumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gameSettingPnl.ResumeLayout(False)
        Me.gameSettingPnl.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents subjectList As System.Windows.Forms.ListBox
    Friend WithEvents titleRehabHeroLbl As System.Windows.Forms.Label
    Friend WithEvents subjectPnl As System.Windows.Forms.Panel
    Friend WithEvents updateLstBtn As System.Windows.Forms.Button
    Friend WithEvents subIDLbl As System.Windows.Forms.Label
    Friend WithEvents subIdTb As System.Windows.Forms.TextBox
    Friend WithEvents songList As System.Windows.Forms.ListBox
    Friend WithEvents songPnl As System.Windows.Forms.Panel
    Friend WithEvents songNameLbl As System.Windows.Forms.Label
    Friend WithEvents thumbnail As System.Windows.Forms.PictureBox
    Friend WithEvents playSongBtn As System.Windows.Forms.Button
    Friend WithEvents difficultyList As System.Windows.Forms.ListBox
    Friend WithEvents isometricForcesBtn As System.Windows.Forms.Button
    Friend WithEvents rangeOfMotionBtn As System.Windows.Forms.Button
    Friend WithEvents gameSettingPnl As System.Windows.Forms.Panel
    Friend WithEvents successRateTitle As System.Windows.Forms.Label
    Friend WithEvents setSucRateHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents fakeSuccessRateTitle As System.Windows.Forms.Label
    Friend WithEvents fakeSuccessRateLbl As System.Windows.Forms.Label
    Friend WithEvents setFakeSucRateHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents successRateLbl As System.Windows.Forms.Label
    Friend WithEvents setGainsInstructions As System.Windows.Forms.Label
    Friend WithEvents setGainsHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents useExplicitGainsBtn As System.Windows.Forms.CheckBox
    Friend WithEvents setGainsTb As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lastSessionLabel As System.Windows.Forms.Label
    Friend WithEvents sessionNumberTB As System.Windows.Forms.TextBox
End Class
