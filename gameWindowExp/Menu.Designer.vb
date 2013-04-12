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
        Me.trialNumLbl = New System.Windows.Forms.Label()
        Me.subHandList = New System.Windows.Forms.ListBox()
        Me.trialNumTextLbl = New System.Windows.Forms.Label()
        Me.handLbl = New System.Windows.Forms.Label()
        Me.updateLstBtn = New System.Windows.Forms.Button()
        Me.addNewSubLbl = New System.Windows.Forms.Label()
        Me.subIDLbl = New System.Windows.Forms.Label()
        Me.subIdTb = New System.Windows.Forms.TextBox()
        Me.songList = New System.Windows.Forms.ListBox()
        Me.songPnl = New System.Windows.Forms.Panel()
        Me.songNameLbl = New System.Windows.Forms.Label()
        Me.thumbnail = New System.Windows.Forms.PictureBox()
        Me.playSongBtn = New System.Windows.Forms.Button()
        Me.isometricForcesBtn = New System.Windows.Forms.Button()
        Me.rangeOfMotionBtn = New System.Windows.Forms.Button()
        Me.gameSettingPnl = New System.Windows.Forms.Panel()
        Me.gameSettingsBtn = New System.Windows.Forms.Button()
        Me.difficultyList = New System.Windows.Forms.ListBox()
        Me.subjectPnl.SuspendLayout()
        Me.songPnl.SuspendLayout()
        CType(Me.thumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gameSettingPnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'subjectList
        '
        Me.subjectList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subjectList.FormattingEnabled = True
        Me.subjectList.ItemHeight = 18
        Me.subjectList.Location = New System.Drawing.Point(12, 61)
        Me.subjectList.Name = "subjectList"
        Me.subjectList.Size = New System.Drawing.Size(178, 382)
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
        Me.subjectPnl.Controls.Add(Me.trialNumLbl)
        Me.subjectPnl.Controls.Add(Me.subHandList)
        Me.subjectPnl.Controls.Add(Me.trialNumTextLbl)
        Me.subjectPnl.Controls.Add(Me.handLbl)
        Me.subjectPnl.Controls.Add(Me.updateLstBtn)
        Me.subjectPnl.Controls.Add(Me.addNewSubLbl)
        Me.subjectPnl.Controls.Add(Me.subIDLbl)
        Me.subjectPnl.Controls.Add(Me.subIdTb)
        Me.subjectPnl.Location = New System.Drawing.Point(15, 449)
        Me.subjectPnl.Name = "subjectPnl"
        Me.subjectPnl.Size = New System.Drawing.Size(340, 84)
        Me.subjectPnl.TabIndex = 2
        '
        'trialNumLbl
        '
        Me.trialNumLbl.AutoSize = True
        Me.trialNumLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trialNumLbl.Location = New System.Drawing.Point(280, 52)
        Me.trialNumLbl.Name = "trialNumLbl"
        Me.trialNumLbl.Size = New System.Drawing.Size(18, 20)
        Me.trialNumLbl.TabIndex = 14
        Me.trialNumLbl.Text = "0"
        '
        'subHandList
        '
        Me.subHandList.FormattingEnabled = True
        Me.subHandList.Items.AddRange(New Object() {"R", "L"})
        Me.subHandList.Location = New System.Drawing.Point(255, 13)
        Me.subHandList.Name = "subHandList"
        Me.subHandList.Size = New System.Drawing.Size(17, 30)
        Me.subHandList.TabIndex = 13
        '
        'trialNumTextLbl
        '
        Me.trialNumTextLbl.AutoSize = True
        Me.trialNumTextLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trialNumTextLbl.Location = New System.Drawing.Point(176, 52)
        Me.trialNumTextLbl.Name = "trialNumTextLbl"
        Me.trialNumTextLbl.Size = New System.Drawing.Size(98, 20)
        Me.trialNumTextLbl.TabIndex = 6
        Me.trialNumTextLbl.Text = "Trial Number"
        '
        'handLbl
        '
        Me.handLbl.AutoSize = True
        Me.handLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.handLbl.Location = New System.Drawing.Point(201, 20)
        Me.handLbl.Name = "handLbl"
        Me.handLbl.Size = New System.Drawing.Size(48, 20)
        Me.handLbl.TabIndex = 4
        Me.handLbl.Text = "Hand"
        '
        'updateLstBtn
        '
        Me.updateLstBtn.Location = New System.Drawing.Point(7, 49)
        Me.updateLstBtn.Name = "updateLstBtn"
        Me.updateLstBtn.Size = New System.Drawing.Size(153, 23)
        Me.updateLstBtn.TabIndex = 3
        Me.updateLstBtn.Text = "Update Subject List"
        Me.updateLstBtn.UseVisualStyleBackColor = True
        '
        'addNewSubLbl
        '
        Me.addNewSubLbl.AutoSize = True
        Me.addNewSubLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addNewSubLbl.Location = New System.Drawing.Point(18, 0)
        Me.addNewSubLbl.Name = "addNewSubLbl"
        Me.addNewSubLbl.Size = New System.Drawing.Size(131, 20)
        Me.addNewSubLbl.TabIndex = 2
        Me.addNewSubLbl.Text = "Add New Subject"
        '
        'subIDLbl
        '
        Me.subIDLbl.AutoSize = True
        Me.subIDLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subIDLbl.Location = New System.Drawing.Point(3, 20)
        Me.subIDLbl.Name = "subIDLbl"
        Me.subIDLbl.Size = New System.Drawing.Size(84, 20)
        Me.subIDLbl.TabIndex = 1
        Me.subIDLbl.Text = "Subject ID"
        '
        'subIdTb
        '
        Me.subIdTb.Location = New System.Drawing.Point(93, 23)
        Me.subIdTb.Name = "subIdTb"
        Me.subIdTb.Size = New System.Drawing.Size(69, 20)
        Me.subIdTb.TabIndex = 0
        '
        'songList
        '
        Me.songList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.songList.FormattingEnabled = True
        Me.songList.ItemHeight = 18
        Me.songList.Location = New System.Drawing.Point(195, 61)
        Me.songList.Name = "songList"
        Me.songList.Size = New System.Drawing.Size(159, 382)
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
        'isometricForcesBtn
        '
        Me.isometricForcesBtn.Location = New System.Drawing.Point(3, 73)
        Me.isometricForcesBtn.Name = "isometricForcesBtn"
        Me.isometricForcesBtn.Size = New System.Drawing.Size(123, 52)
        Me.isometricForcesBtn.TabIndex = 10
        Me.isometricForcesBtn.Text = "isometric forces"
        Me.isometricForcesBtn.UseVisualStyleBackColor = True
        '
        'rangeOfMotionBtn
        '
        Me.rangeOfMotionBtn.Location = New System.Drawing.Point(132, 73)
        Me.rangeOfMotionBtn.Name = "rangeOfMotionBtn"
        Me.rangeOfMotionBtn.Size = New System.Drawing.Size(113, 52)
        Me.rangeOfMotionBtn.TabIndex = 11
        Me.rangeOfMotionBtn.Text = "range of motion"
        Me.rangeOfMotionBtn.UseVisualStyleBackColor = True
        '
        'gameSettingPnl
        '
        Me.gameSettingPnl.Controls.Add(Me.gameSettingsBtn)
        Me.gameSettingPnl.Controls.Add(Me.rangeOfMotionBtn)
        Me.gameSettingPnl.Controls.Add(Me.difficultyList)
        Me.gameSettingPnl.Controls.Add(Me.isometricForcesBtn)
        Me.gameSettingPnl.Location = New System.Drawing.Point(364, 399)
        Me.gameSettingPnl.Name = "gameSettingPnl"
        Me.gameSettingPnl.Size = New System.Drawing.Size(248, 134)
        Me.gameSettingPnl.TabIndex = 13
        '
        'gameSettingsBtn
        '
        Me.gameSettingsBtn.Location = New System.Drawing.Point(3, 11)
        Me.gameSettingsBtn.Name = "gameSettingsBtn"
        Me.gameSettingsBtn.Size = New System.Drawing.Size(178, 56)
        Me.gameSettingsBtn.TabIndex = 14
        Me.gameSettingsBtn.Text = "game settings"
        Me.gameSettingsBtn.UseVisualStyleBackColor = True
        '
        'difficultyList
        '
        Me.difficultyList.FormattingEnabled = True
        Me.difficultyList.Items.AddRange(New Object() {"easy", "medium", "hard"})
        Me.difficultyList.Location = New System.Drawing.Point(187, 11)
        Me.difficultyList.Name = "difficultyList"
        Me.difficultyList.Size = New System.Drawing.Size(58, 56)
        Me.difficultyList.TabIndex = 45
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(624, 541)
        Me.Controls.Add(Me.gameSettingPnl)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents subjectList As System.Windows.Forms.ListBox
    Friend WithEvents titleRehabHeroLbl As System.Windows.Forms.Label
    Friend WithEvents subjectPnl As System.Windows.Forms.Panel
    Friend WithEvents updateLstBtn As System.Windows.Forms.Button
    Friend WithEvents addNewSubLbl As System.Windows.Forms.Label
    Friend WithEvents subIDLbl As System.Windows.Forms.Label
    Friend WithEvents subIdTb As System.Windows.Forms.TextBox
    Friend WithEvents songList As System.Windows.Forms.ListBox
    Friend WithEvents songPnl As System.Windows.Forms.Panel
    Friend WithEvents songNameLbl As System.Windows.Forms.Label
    Friend WithEvents thumbnail As System.Windows.Forms.PictureBox
    Friend WithEvents playSongBtn As System.Windows.Forms.Button
    Friend WithEvents isometricForcesBtn As System.Windows.Forms.Button
    Friend WithEvents rangeOfMotionBtn As System.Windows.Forms.Button
    Friend WithEvents handLbl As System.Windows.Forms.Label
    Friend WithEvents trialNumTextLbl As System.Windows.Forms.Label
    Friend WithEvents subHandList As System.Windows.Forms.ListBox
    Friend WithEvents trialNumLbl As System.Windows.Forms.Label
    Friend WithEvents gameSettingPnl As System.Windows.Forms.Panel
    Friend WithEvents gameSettingsBtn As System.Windows.Forms.Button
    Friend WithEvents difficultyList As System.Windows.Forms.ListBox
End Class
