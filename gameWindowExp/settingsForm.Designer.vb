<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class settingsForm
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
        Me.minMsecBetweenBurstsLbl = New System.Windows.Forms.Label()
        Me.maxMsecBetweenBurstsLbl = New System.Windows.Forms.Label()
        Me.maxNumberNotesPerBurstLbl = New System.Windows.Forms.Label()
        Me.allowedReactionTimeLbl = New System.Windows.Forms.Label()
        Me.assistanceModeLbl = New System.Windows.Forms.Label()
        Me.Kp1StartLbl = New System.Windows.Forms.Label()
        Me.Kp2StartLbl = New System.Windows.Forms.Label()
        Me.minMsecBetweenBurstsHSB = New System.Windows.Forms.HScrollBar()
        Me.maxMsecBetweenBurstsHSB = New System.Windows.Forms.HScrollBar()
        Me.maxNotesPerRiffHSB = New System.Windows.Forms.HScrollBar()
        Me.minBurstValLbl = New System.Windows.Forms.Label()
        Me.maxBurstValLbl = New System.Windows.Forms.Label()
        Me.maxNotesValLbl = New System.Windows.Forms.Label()
        Me.reactionTimeHSB = New System.Windows.Forms.HScrollBar()
        Me.reactionTimeValLbl = New System.Windows.Forms.Label()
        Me.assistanceModeHSB = New System.Windows.Forms.HScrollBar()
        Me.assistanceModeValLbl = New System.Windows.Forms.Label()
        Me.Kp1StartHSB = New System.Windows.Forms.HScrollBar()
        Me.Kp1StartValLbl = New System.Windows.Forms.Label()
        Me.Kp2StartHSB = New System.Windows.Forms.HScrollBar()
        Me.Kp2StartValLbl = New System.Windows.Forms.Label()
        Me.saveSettingsBtn = New System.Windows.Forms.Button()
        Me.studyList = New System.Windows.Forms.ListBox()
        Me.addNewSubLbl = New System.Windows.Forms.Label()
        Me.updateLstBtn = New System.Windows.Forms.Button()
        Me.addNewStudyLbl = New System.Windows.Forms.Label()
        Me.studyIDLbl = New System.Windows.Forms.Label()
        Me.studyIdTb = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'minMsecBetweenBurstsLbl
        '
        Me.minMsecBetweenBurstsLbl.AutoSize = True
        Me.minMsecBetweenBurstsLbl.Location = New System.Drawing.Point(35, 58)
        Me.minMsecBetweenBurstsLbl.Name = "minMsecBetweenBurstsLbl"
        Me.minMsecBetweenBurstsLbl.Size = New System.Drawing.Size(149, 13)
        Me.minMsecBetweenBurstsLbl.TabIndex = 14
        Me.minMsecBetweenBurstsLbl.Text = "Minimum msec between ""riffs"""
        '
        'maxMsecBetweenBurstsLbl
        '
        Me.maxMsecBetweenBurstsLbl.AutoSize = True
        Me.maxMsecBetweenBurstsLbl.Location = New System.Drawing.Point(35, 106)
        Me.maxMsecBetweenBurstsLbl.Name = "maxMsecBetweenBurstsLbl"
        Me.maxMsecBetweenBurstsLbl.Size = New System.Drawing.Size(152, 13)
        Me.maxMsecBetweenBurstsLbl.TabIndex = 15
        Me.maxMsecBetweenBurstsLbl.Text = "Maximum msec between ""riffs"""
        '
        'maxNumberNotesPerBurstLbl
        '
        Me.maxNumberNotesPerBurstLbl.AutoSize = True
        Me.maxNumberNotesPerBurstLbl.Location = New System.Drawing.Point(35, 152)
        Me.maxNumberNotesPerBurstLbl.Name = "maxNumberNotesPerBurstLbl"
        Me.maxNumberNotesPerBurstLbl.Size = New System.Drawing.Size(132, 13)
        Me.maxNumberNotesPerBurstLbl.TabIndex = 16
        Me.maxNumberNotesPerBurstLbl.Text = "Maximum # notes per ""riff"""
        '
        'allowedReactionTimeLbl
        '
        Me.allowedReactionTimeLbl.AutoSize = True
        Me.allowedReactionTimeLbl.Location = New System.Drawing.Point(35, 199)
        Me.allowedReactionTimeLbl.Name = "allowedReactionTimeLbl"
        Me.allowedReactionTimeLbl.Size = New System.Drawing.Size(227, 13)
        Me.allowedReactionTimeLbl.TabIndex = 17
        Me.allowedReactionTimeLbl.Text = "Allowed reaction time (time for notes to appear)"
        '
        'assistanceModeLbl
        '
        Me.assistanceModeLbl.AutoSize = True
        Me.assistanceModeLbl.Location = New System.Drawing.Point(35, 239)
        Me.assistanceModeLbl.Name = "assistanceModeLbl"
        Me.assistanceModeLbl.Size = New System.Drawing.Size(87, 13)
        Me.assistanceModeLbl.TabIndex = 18
        Me.assistanceModeLbl.Text = "Assistance mode"
        '
        'Kp1StartLbl
        '
        Me.Kp1StartLbl.AutoSize = True
        Me.Kp1StartLbl.Location = New System.Drawing.Point(35, 285)
        Me.Kp1StartLbl.Name = "Kp1StartLbl"
        Me.Kp1StartLbl.Size = New System.Drawing.Size(164, 13)
        Me.Kp1StartLbl.TabIndex = 19
        Me.Kp1StartLbl.Text = "Gain #1 initialization default (Kp1)"
        '
        'Kp2StartLbl
        '
        Me.Kp2StartLbl.AutoSize = True
        Me.Kp2StartLbl.Location = New System.Drawing.Point(35, 332)
        Me.Kp2StartLbl.Name = "Kp2StartLbl"
        Me.Kp2StartLbl.Size = New System.Drawing.Size(164, 13)
        Me.Kp2StartLbl.TabIndex = 20
        Me.Kp2StartLbl.Text = "Gain #2 initialization default (Kp2)"
        '
        'minMsecBetweenBurstsHSB
        '
        Me.minMsecBetweenBurstsHSB.Location = New System.Drawing.Point(38, 71)
        Me.minMsecBetweenBurstsHSB.Maximum = 999
        Me.minMsecBetweenBurstsHSB.Minimum = 1
        Me.minMsecBetweenBurstsHSB.Name = "minMsecBetweenBurstsHSB"
        Me.minMsecBetweenBurstsHSB.Size = New System.Drawing.Size(161, 13)
        Me.minMsecBetweenBurstsHSB.TabIndex = 21
        Me.minMsecBetweenBurstsHSB.Value = 300
        '
        'maxMsecBetweenBurstsHSB
        '
        Me.maxMsecBetweenBurstsHSB.Location = New System.Drawing.Point(38, 119)
        Me.maxMsecBetweenBurstsHSB.Maximum = 2000
        Me.maxMsecBetweenBurstsHSB.Minimum = 50
        Me.maxMsecBetweenBurstsHSB.Name = "maxMsecBetweenBurstsHSB"
        Me.maxMsecBetweenBurstsHSB.Size = New System.Drawing.Size(161, 13)
        Me.maxMsecBetweenBurstsHSB.TabIndex = 22
        Me.maxMsecBetweenBurstsHSB.Value = 1000
        '
        'maxNotesPerRiffHSB
        '
        Me.maxNotesPerRiffHSB.LargeChange = 1
        Me.maxNotesPerRiffHSB.Location = New System.Drawing.Point(38, 165)
        Me.maxNotesPerRiffHSB.Maximum = 5
        Me.maxNotesPerRiffHSB.Minimum = 1
        Me.maxNotesPerRiffHSB.Name = "maxNotesPerRiffHSB"
        Me.maxNotesPerRiffHSB.Size = New System.Drawing.Size(161, 13)
        Me.maxNotesPerRiffHSB.TabIndex = 23
        Me.maxNotesPerRiffHSB.Value = 1
        '
        'minBurstValLbl
        '
        Me.minBurstValLbl.AutoSize = True
        Me.minBurstValLbl.Location = New System.Drawing.Point(202, 71)
        Me.minBurstValLbl.Name = "minBurstValLbl"
        Me.minBurstValLbl.Size = New System.Drawing.Size(25, 13)
        Me.minBurstValLbl.TabIndex = 24
        Me.minBurstValLbl.Text = "300"
        '
        'maxBurstValLbl
        '
        Me.maxBurstValLbl.AutoSize = True
        Me.maxBurstValLbl.Location = New System.Drawing.Point(202, 119)
        Me.maxBurstValLbl.Name = "maxBurstValLbl"
        Me.maxBurstValLbl.Size = New System.Drawing.Size(31, 13)
        Me.maxBurstValLbl.TabIndex = 25
        Me.maxBurstValLbl.Text = "1000"
        '
        'maxNotesValLbl
        '
        Me.maxNotesValLbl.AutoSize = True
        Me.maxNotesValLbl.Location = New System.Drawing.Point(202, 165)
        Me.maxNotesValLbl.Name = "maxNotesValLbl"
        Me.maxNotesValLbl.Size = New System.Drawing.Size(13, 13)
        Me.maxNotesValLbl.TabIndex = 26
        Me.maxNotesValLbl.Text = "1"
        '
        'reactionTimeHSB
        '
        Me.reactionTimeHSB.Location = New System.Drawing.Point(38, 212)
        Me.reactionTimeHSB.Maximum = 1000
        Me.reactionTimeHSB.Minimum = 50
        Me.reactionTimeHSB.Name = "reactionTimeHSB"
        Me.reactionTimeHSB.Size = New System.Drawing.Size(161, 13)
        Me.reactionTimeHSB.TabIndex = 27
        Me.reactionTimeHSB.Value = 300
        '
        'reactionTimeValLbl
        '
        Me.reactionTimeValLbl.AutoSize = True
        Me.reactionTimeValLbl.Location = New System.Drawing.Point(202, 212)
        Me.reactionTimeValLbl.Name = "reactionTimeValLbl"
        Me.reactionTimeValLbl.Size = New System.Drawing.Size(19, 13)
        Me.reactionTimeValLbl.TabIndex = 28
        Me.reactionTimeValLbl.Text = "50"
        '
        'assistanceModeHSB
        '
        Me.assistanceModeHSB.LargeChange = 1
        Me.assistanceModeHSB.Location = New System.Drawing.Point(38, 252)
        Me.assistanceModeHSB.Maximum = 5
        Me.assistanceModeHSB.Minimum = 1
        Me.assistanceModeHSB.Name = "assistanceModeHSB"
        Me.assistanceModeHSB.Size = New System.Drawing.Size(161, 13)
        Me.assistanceModeHSB.TabIndex = 29
        Me.assistanceModeHSB.Value = 5
        '
        'assistanceModeValLbl
        '
        Me.assistanceModeValLbl.AutoSize = True
        Me.assistanceModeValLbl.Location = New System.Drawing.Point(202, 252)
        Me.assistanceModeValLbl.Name = "assistanceModeValLbl"
        Me.assistanceModeValLbl.Size = New System.Drawing.Size(13, 13)
        Me.assistanceModeValLbl.TabIndex = 30
        Me.assistanceModeValLbl.Text = "5"
        '
        'Kp1StartHSB
        '
        Me.Kp1StartHSB.LargeChange = 5
        Me.Kp1StartHSB.Location = New System.Drawing.Point(38, 298)
        Me.Kp1StartHSB.Maximum = 45
        Me.Kp1StartHSB.Name = "Kp1StartHSB"
        Me.Kp1StartHSB.Size = New System.Drawing.Size(161, 13)
        Me.Kp1StartHSB.TabIndex = 31
        Me.Kp1StartHSB.Value = 5
        '
        'Kp1StartValLbl
        '
        Me.Kp1StartValLbl.AutoSize = True
        Me.Kp1StartValLbl.Location = New System.Drawing.Point(202, 298)
        Me.Kp1StartValLbl.Name = "Kp1StartValLbl"
        Me.Kp1StartValLbl.Size = New System.Drawing.Size(13, 13)
        Me.Kp1StartValLbl.TabIndex = 32
        Me.Kp1StartValLbl.Text = "0"
        '
        'Kp2StartHSB
        '
        Me.Kp2StartHSB.LargeChange = 5
        Me.Kp2StartHSB.Location = New System.Drawing.Point(38, 345)
        Me.Kp2StartHSB.Maximum = 45
        Me.Kp2StartHSB.Name = "Kp2StartHSB"
        Me.Kp2StartHSB.Size = New System.Drawing.Size(161, 13)
        Me.Kp2StartHSB.TabIndex = 33
        Me.Kp2StartHSB.Value = 5
        '
        'Kp2StartValLbl
        '
        Me.Kp2StartValLbl.AutoSize = True
        Me.Kp2StartValLbl.Location = New System.Drawing.Point(202, 345)
        Me.Kp2StartValLbl.Name = "Kp2StartValLbl"
        Me.Kp2StartValLbl.Size = New System.Drawing.Size(13, 13)
        Me.Kp2StartValLbl.TabIndex = 34
        Me.Kp2StartValLbl.Text = "0"
        '
        'saveSettingsBtn
        '
        Me.saveSettingsBtn.Location = New System.Drawing.Point(38, 378)
        Me.saveSettingsBtn.Name = "saveSettingsBtn"
        Me.saveSettingsBtn.Size = New System.Drawing.Size(180, 32)
        Me.saveSettingsBtn.TabIndex = 35
        Me.saveSettingsBtn.Text = "Save Settings"
        Me.saveSettingsBtn.UseVisualStyleBackColor = True
        '
        'studyList
        '
        Me.studyList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.studyList.FormattingEnabled = True
        Me.studyList.ItemHeight = 18
        Me.studyList.Location = New System.Drawing.Point(283, 12)
        Me.studyList.Name = "studyList"
        Me.studyList.Size = New System.Drawing.Size(178, 310)
        Me.studyList.TabIndex = 36
        '
        'addNewSubLbl
        '
        Me.addNewSubLbl.AutoSize = True
        Me.addNewSubLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addNewSubLbl.Location = New System.Drawing.Point(34, 12)
        Me.addNewSubLbl.Name = "addNewSubLbl"
        Me.addNewSubLbl.Size = New System.Drawing.Size(124, 20)
        Me.addNewSubLbl.TabIndex = 38
        Me.addNewSubLbl.Text = "Current Subject:"
        '
        'updateLstBtn
        '
        Me.updateLstBtn.Location = New System.Drawing.Point(283, 378)
        Me.updateLstBtn.Name = "updateLstBtn"
        Me.updateLstBtn.Size = New System.Drawing.Size(178, 32)
        Me.updateLstBtn.TabIndex = 42
        Me.updateLstBtn.Text = "Add New Study"
        Me.updateLstBtn.UseVisualStyleBackColor = True
        '
        'addNewStudyLbl
        '
        Me.addNewStudyLbl.AutoSize = True
        Me.addNewStudyLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addNewStudyLbl.Location = New System.Drawing.Point(303, 327)
        Me.addNewStudyLbl.Name = "addNewStudyLbl"
        Me.addNewStudyLbl.Size = New System.Drawing.Size(118, 20)
        Me.addNewStudyLbl.TabIndex = 41
        Me.addNewStudyLbl.Text = "Add New Study"
        '
        'studyIDLbl
        '
        Me.studyIDLbl.AutoSize = True
        Me.studyIDLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.studyIDLbl.Location = New System.Drawing.Point(288, 347)
        Me.studyIDLbl.Name = "studyIDLbl"
        Me.studyIDLbl.Size = New System.Drawing.Size(71, 20)
        Me.studyIDLbl.TabIndex = 40
        Me.studyIDLbl.Text = "Study ID"
        '
        'studyIdTb
        '
        Me.studyIdTb.Location = New System.Drawing.Point(378, 350)
        Me.studyIdTb.Name = "studyIdTb"
        Me.studyIdTb.Size = New System.Drawing.Size(69, 20)
        Me.studyIdTb.TabIndex = 39
        '
        'settingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 422)
        Me.Controls.Add(Me.updateLstBtn)
        Me.Controls.Add(Me.addNewStudyLbl)
        Me.Controls.Add(Me.studyIDLbl)
        Me.Controls.Add(Me.studyIdTb)
        Me.Controls.Add(Me.addNewSubLbl)
        Me.Controls.Add(Me.studyList)
        Me.Controls.Add(Me.saveSettingsBtn)
        Me.Controls.Add(Me.Kp2StartValLbl)
        Me.Controls.Add(Me.Kp2StartHSB)
        Me.Controls.Add(Me.Kp1StartValLbl)
        Me.Controls.Add(Me.Kp1StartHSB)
        Me.Controls.Add(Me.assistanceModeValLbl)
        Me.Controls.Add(Me.assistanceModeHSB)
        Me.Controls.Add(Me.reactionTimeValLbl)
        Me.Controls.Add(Me.reactionTimeHSB)
        Me.Controls.Add(Me.maxNotesValLbl)
        Me.Controls.Add(Me.maxBurstValLbl)
        Me.Controls.Add(Me.minBurstValLbl)
        Me.Controls.Add(Me.maxNotesPerRiffHSB)
        Me.Controls.Add(Me.maxMsecBetweenBurstsHSB)
        Me.Controls.Add(Me.minMsecBetweenBurstsHSB)
        Me.Controls.Add(Me.Kp2StartLbl)
        Me.Controls.Add(Me.Kp1StartLbl)
        Me.Controls.Add(Me.assistanceModeLbl)
        Me.Controls.Add(Me.allowedReactionTimeLbl)
        Me.Controls.Add(Me.maxNumberNotesPerBurstLbl)
        Me.Controls.Add(Me.maxMsecBetweenBurstsLbl)
        Me.Controls.Add(Me.minMsecBetweenBurstsLbl)
        Me.Name = "settingsForm"
        Me.Text = "Game Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents minMsecBetweenBurstsLbl As System.Windows.Forms.Label
    Friend WithEvents maxMsecBetweenBurstsLbl As System.Windows.Forms.Label
    Friend WithEvents maxNumberNotesPerBurstLbl As System.Windows.Forms.Label
    Friend WithEvents allowedReactionTimeLbl As System.Windows.Forms.Label
    Friend WithEvents assistanceModeLbl As System.Windows.Forms.Label
    Friend WithEvents Kp1StartLbl As System.Windows.Forms.Label
    Friend WithEvents Kp2StartLbl As System.Windows.Forms.Label
    Friend WithEvents minMsecBetweenBurstsHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents maxMsecBetweenBurstsHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents maxNotesPerRiffHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents minBurstValLbl As System.Windows.Forms.Label
    Friend WithEvents maxBurstValLbl As System.Windows.Forms.Label
    Friend WithEvents maxNotesValLbl As System.Windows.Forms.Label
    Friend WithEvents reactionTimeHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents reactionTimeValLbl As System.Windows.Forms.Label
    Friend WithEvents assistanceModeHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents assistanceModeValLbl As System.Windows.Forms.Label
    Friend WithEvents Kp1StartHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents Kp1StartValLbl As System.Windows.Forms.Label
    Friend WithEvents Kp2StartHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents Kp2StartValLbl As System.Windows.Forms.Label
    Friend WithEvents saveSettingsBtn As System.Windows.Forms.Button
    Friend WithEvents studyList As System.Windows.Forms.ListBox
    Friend WithEvents addNewSubLbl As System.Windows.Forms.Label
    Friend WithEvents updateLstBtn As System.Windows.Forms.Button
    Friend WithEvents addNewStudyLbl As System.Windows.Forms.Label
    Friend WithEvents studyIDLbl As System.Windows.Forms.Label
    Friend WithEvents studyIdTb As System.Windows.Forms.TextBox
End Class
