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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.updateLstBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.subIDLbl = New System.Windows.Forms.Label()
        Me.subIdTb = New System.Windows.Forms.TextBox()
        Me.songList = New System.Windows.Forms.ListBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.songNameLbl = New System.Windows.Forms.Label()
        Me.thumbnail = New System.Windows.Forms.PictureBox()
        Me.playSongBtn = New System.Windows.Forms.Button()
        Me.successRateList = New System.Windows.Forms.ListBox()
        Me.difficultyList = New System.Windows.Forms.ListBox()
        Me.isometricForcesBtn = New System.Windows.Forms.Button()
        Me.rangeOfMotionBtn = New System.Windows.Forms.Button()
        Me.perceivedSuccessLB = New System.Windows.Forms.ListBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.thumbnail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'subjectList
        '
        Me.subjectList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subjectList.FormattingEnabled = True
        Me.subjectList.ItemHeight = 18
        Me.subjectList.Location = New System.Drawing.Point(12, 61)
        Me.subjectList.Name = "subjectList"
        Me.subjectList.Size = New System.Drawing.Size(178, 256)
        Me.subjectList.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(181, 33)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Rehab Hero"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.updateLstBtn)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.subIDLbl)
        Me.Panel1.Controls.Add(Me.subIdTb)
        Me.Panel1.Location = New System.Drawing.Point(14, 325)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(176, 100)
        Me.Panel1.TabIndex = 2
        '
        'updateLstBtn
        '
        Me.updateLstBtn.Location = New System.Drawing.Point(7, 58)
        Me.updateLstBtn.Name = "updateLstBtn"
        Me.updateLstBtn.Size = New System.Drawing.Size(153, 23)
        Me.updateLstBtn.TabIndex = 3
        Me.updateLstBtn.Text = "Update Subject List"
        Me.updateLstBtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Add New Subject"
        '
        'subIDLbl
        '
        Me.subIDLbl.AutoSize = True
        Me.subIDLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subIDLbl.Location = New System.Drawing.Point(3, 26)
        Me.subIDLbl.Name = "subIDLbl"
        Me.subIDLbl.Size = New System.Drawing.Size(84, 20)
        Me.subIDLbl.TabIndex = 1
        Me.subIDLbl.Text = "Subject ID"
        '
        'subIdTb
        '
        Me.subIdTb.Location = New System.Drawing.Point(91, 28)
        Me.subIdTb.Name = "subIdTb"
        Me.subIdTb.Size = New System.Drawing.Size(69, 20)
        Me.subIdTb.TabIndex = 0
        '
        'songList
        '
        Me.songList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.songList.FormattingEnabled = True
        Me.songList.ItemHeight = 18
        Me.songList.Location = New System.Drawing.Point(196, 61)
        Me.songList.Name = "songList"
        Me.songList.Size = New System.Drawing.Size(159, 364)
        Me.songList.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.songNameLbl)
        Me.Panel2.Controls.Add(Me.thumbnail)
        Me.Panel2.Location = New System.Drawing.Point(361, 61)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(251, 281)
        Me.Panel2.TabIndex = 4
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
        Me.playSongBtn.Size = New System.Drawing.Size(87, 44)
        Me.playSongBtn.TabIndex = 5
        Me.playSongBtn.Text = "Play Song"
        Me.playSongBtn.UseVisualStyleBackColor = True
        '
        'successRateList
        '
        Me.successRateList.FormattingEnabled = True
        Me.successRateList.Items.AddRange(New Object() {".5", ".75", ".99"})
        Me.successRateList.Location = New System.Drawing.Point(454, 348)
        Me.successRateList.Name = "successRateList"
        Me.successRateList.Size = New System.Drawing.Size(39, 43)
        Me.successRateList.TabIndex = 8
        '
        'difficultyList
        '
        Me.difficultyList.FormattingEnabled = True
        Me.difficultyList.Items.AddRange(New Object() {"easy", "medium", "hard"})
        Me.difficultyList.Location = New System.Drawing.Point(545, 348)
        Me.difficultyList.Name = "difficultyList"
        Me.difficultyList.Size = New System.Drawing.Size(67, 43)
        Me.difficultyList.TabIndex = 9
        '
        'isometricForcesBtn
        '
        Me.isometricForcesBtn.Location = New System.Drawing.Point(361, 398)
        Me.isometricForcesBtn.Name = "isometricForcesBtn"
        Me.isometricForcesBtn.Size = New System.Drawing.Size(120, 32)
        Me.isometricForcesBtn.TabIndex = 10
        Me.isometricForcesBtn.Text = "isometric forces"
        Me.isometricForcesBtn.UseVisualStyleBackColor = True
        '
        'rangeOfMotionBtn
        '
        Me.rangeOfMotionBtn.Location = New System.Drawing.Point(487, 398)
        Me.rangeOfMotionBtn.Name = "rangeOfMotionBtn"
        Me.rangeOfMotionBtn.Size = New System.Drawing.Size(125, 32)
        Me.rangeOfMotionBtn.TabIndex = 11
        Me.rangeOfMotionBtn.Text = "range of motion"
        Me.rangeOfMotionBtn.UseVisualStyleBackColor = True
        '
        'perceivedSuccessLB
        '
        Me.perceivedSuccessLB.FormattingEnabled = True
        Me.perceivedSuccessLB.Items.AddRange(New Object() {".5", ".75", ".99"})
        Me.perceivedSuccessLB.Location = New System.Drawing.Point(500, 348)
        Me.perceivedSuccessLB.Name = "perceivedSuccessLB"
        Me.perceivedSuccessLB.Size = New System.Drawing.Size(39, 43)
        Me.perceivedSuccessLB.TabIndex = 12
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(624, 442)
        Me.Controls.Add(Me.perceivedSuccessLB)
        Me.Controls.Add(Me.rangeOfMotionBtn)
        Me.Controls.Add(Me.isometricForcesBtn)
        Me.Controls.Add(Me.difficultyList)
        Me.Controls.Add(Me.successRateList)
        Me.Controls.Add(Me.playSongBtn)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.songList)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.subjectList)
        Me.Name = "Menu"
        Me.Text = "Menu"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.thumbnail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents subjectList As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents updateLstBtn As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents subIDLbl As System.Windows.Forms.Label
    Friend WithEvents subIdTb As System.Windows.Forms.TextBox
    Friend WithEvents songList As System.Windows.Forms.ListBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents songNameLbl As System.Windows.Forms.Label
    Friend WithEvents thumbnail As System.Windows.Forms.PictureBox
    Friend WithEvents playSongBtn As System.Windows.Forms.Button
    Friend WithEvents successRateList As System.Windows.Forms.ListBox
    Friend WithEvents difficultyList As System.Windows.Forms.ListBox
    Friend WithEvents isometricForcesBtn As System.Windows.Forms.Button
    Friend WithEvents rangeOfMotionBtn As System.Windows.Forms.Button
    Friend WithEvents perceivedSuccessLB As System.Windows.Forms.ListBox
End Class
