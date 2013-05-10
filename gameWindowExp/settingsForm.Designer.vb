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
        Me.minMsecBetweenBurstsHSB = New System.Windows.Forms.HScrollBar()
        Me.maxMsecBetweenBurstsHSB = New System.Windows.Forms.HScrollBar()
        Me.maxNotesPerRiffHSB = New System.Windows.Forms.HScrollBar()
        Me.minBurstValLbl = New System.Windows.Forms.Label()
        Me.maxBurstValLbl = New System.Windows.Forms.Label()
        Me.maxNotesValLbl = New System.Windows.Forms.Label()
        Me.reactionTimeHSB = New System.Windows.Forms.HScrollBar()
        Me.reactionTimeValLbl = New System.Windows.Forms.Label()
        Me.saveSettingsBtn = New System.Windows.Forms.Button()
        Me.studyList = New System.Windows.Forms.ListBox()
        Me.StudySettingsLbl = New System.Windows.Forms.Label()
        Me.updateLstBtn = New System.Windows.Forms.Button()
        Me.addNewStudyLbl = New System.Windows.Forms.Label()
        Me.studyIDLbl = New System.Windows.Forms.Label()
        Me.studyIdTb = New System.Windows.Forms.TextBox()
        Me.useExplicitGainsBtn = New System.Windows.Forms.CheckBox()
        Me.GainsHSB = New System.Windows.Forms.HScrollBar()
        Me.fakeSuccessRateLbl = New System.Windows.Forms.Label()
        Me.FakeSucRateHSB = New System.Windows.Forms.HScrollBar()
        Me.successRateLbl = New System.Windows.Forms.Label()
        Me.SucRateHSB = New System.Windows.Forms.HScrollBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.explicitGainsLbl = New System.Windows.Forms.Label()
        Me.RiffTimingLbl = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.useBCICbox = New System.Windows.Forms.CheckBox()
        Me.hitWindowValLbl = New System.Windows.Forms.Label()
        Me.hitWindowSizeHSB = New System.Windows.Forms.HScrollBar()
        Me.hitWindowSizeLbl = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.takeNthNoteHSB = New System.Windows.Forms.HScrollBar()
        Me.takeNthNoteLbl = New System.Windows.Forms.Label()
        Me.takeNthNothHSB = New System.Windows.Forms.HScrollBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'minMsecBetweenBurstsLbl
        '
        Me.minMsecBetweenBurstsLbl.AutoSize = True
        Me.minMsecBetweenBurstsLbl.Location = New System.Drawing.Point(12, 43)
        Me.minMsecBetweenBurstsLbl.Name = "minMsecBetweenBurstsLbl"
        Me.minMsecBetweenBurstsLbl.Size = New System.Drawing.Size(149, 13)
        Me.minMsecBetweenBurstsLbl.TabIndex = 14
        Me.minMsecBetweenBurstsLbl.Text = "Minimum msec between ""riffs"""
        '
        'maxMsecBetweenBurstsLbl
        '
        Me.maxMsecBetweenBurstsLbl.AutoSize = True
        Me.maxMsecBetweenBurstsLbl.Location = New System.Drawing.Point(12, 69)
        Me.maxMsecBetweenBurstsLbl.Name = "maxMsecBetweenBurstsLbl"
        Me.maxMsecBetweenBurstsLbl.Size = New System.Drawing.Size(152, 13)
        Me.maxMsecBetweenBurstsLbl.TabIndex = 15
        Me.maxMsecBetweenBurstsLbl.Text = "Maximum msec between ""riffs"""
        '
        'maxNumberNotesPerBurstLbl
        '
        Me.maxNumberNotesPerBurstLbl.AutoSize = True
        Me.maxNumberNotesPerBurstLbl.Location = New System.Drawing.Point(12, 98)
        Me.maxNumberNotesPerBurstLbl.Name = "maxNumberNotesPerBurstLbl"
        Me.maxNumberNotesPerBurstLbl.Size = New System.Drawing.Size(132, 13)
        Me.maxNumberNotesPerBurstLbl.TabIndex = 16
        Me.maxNumberNotesPerBurstLbl.Text = "Maximum # notes per ""riff"""
        '
        'allowedReactionTimeLbl
        '
        Me.allowedReactionTimeLbl.AutoSize = True
        Me.allowedReactionTimeLbl.Location = New System.Drawing.Point(12, 178)
        Me.allowedReactionTimeLbl.Name = "allowedReactionTimeLbl"
        Me.allowedReactionTimeLbl.Size = New System.Drawing.Size(197, 13)
        Me.allowedReactionTimeLbl.TabIndex = 17
        Me.allowedReactionTimeLbl.Text = "Reaction time (time notes are on screen)"
        '
        'minMsecBetweenBurstsHSB
        '
        Me.minMsecBetweenBurstsHSB.Location = New System.Drawing.Point(15, 56)
        Me.minMsecBetweenBurstsHSB.Maximum = 999
        Me.minMsecBetweenBurstsHSB.Minimum = 1
        Me.minMsecBetweenBurstsHSB.Name = "minMsecBetweenBurstsHSB"
        Me.minMsecBetweenBurstsHSB.Size = New System.Drawing.Size(161, 13)
        Me.minMsecBetweenBurstsHSB.TabIndex = 21
        Me.minMsecBetweenBurstsHSB.Value = 300
        '
        'maxMsecBetweenBurstsHSB
        '
        Me.maxMsecBetweenBurstsHSB.Location = New System.Drawing.Point(15, 82)
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
        Me.maxNotesPerRiffHSB.Location = New System.Drawing.Point(15, 111)
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
        Me.minBurstValLbl.Location = New System.Drawing.Point(179, 56)
        Me.minBurstValLbl.Name = "minBurstValLbl"
        Me.minBurstValLbl.Size = New System.Drawing.Size(25, 13)
        Me.minBurstValLbl.TabIndex = 24
        Me.minBurstValLbl.Text = "300"
        '
        'maxBurstValLbl
        '
        Me.maxBurstValLbl.AutoSize = True
        Me.maxBurstValLbl.Location = New System.Drawing.Point(179, 82)
        Me.maxBurstValLbl.Name = "maxBurstValLbl"
        Me.maxBurstValLbl.Size = New System.Drawing.Size(31, 13)
        Me.maxBurstValLbl.TabIndex = 25
        Me.maxBurstValLbl.Text = "1000"
        '
        'maxNotesValLbl
        '
        Me.maxNotesValLbl.AutoSize = True
        Me.maxNotesValLbl.Location = New System.Drawing.Point(179, 111)
        Me.maxNotesValLbl.Name = "maxNotesValLbl"
        Me.maxNotesValLbl.Size = New System.Drawing.Size(13, 13)
        Me.maxNotesValLbl.TabIndex = 26
        Me.maxNotesValLbl.Text = "1"
        '
        'reactionTimeHSB
        '
        Me.reactionTimeHSB.Location = New System.Drawing.Point(15, 191)
        Me.reactionTimeHSB.Maximum = 5000
        Me.reactionTimeHSB.Minimum = 200
        Me.reactionTimeHSB.Name = "reactionTimeHSB"
        Me.reactionTimeHSB.Size = New System.Drawing.Size(161, 13)
        Me.reactionTimeHSB.TabIndex = 27
        Me.reactionTimeHSB.Value = 1000
        '
        'reactionTimeValLbl
        '
        Me.reactionTimeValLbl.AutoSize = True
        Me.reactionTimeValLbl.Location = New System.Drawing.Point(179, 191)
        Me.reactionTimeValLbl.Name = "reactionTimeValLbl"
        Me.reactionTimeValLbl.Size = New System.Drawing.Size(31, 13)
        Me.reactionTimeValLbl.TabIndex = 28
        Me.reactionTimeValLbl.Text = "1000"
        '
        'saveSettingsBtn
        '
        Me.saveSettingsBtn.Location = New System.Drawing.Point(21, 458)
        Me.saveSettingsBtn.Name = "saveSettingsBtn"
        Me.saveSettingsBtn.Size = New System.Drawing.Size(202, 60)
        Me.saveSettingsBtn.TabIndex = 35
        Me.saveSettingsBtn.Text = "Save Settings"
        Me.saveSettingsBtn.UseVisualStyleBackColor = True
        '
        'studyList
        '
        Me.studyList.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.studyList.FormattingEnabled = True
        Me.studyList.ItemHeight = 18
        Me.studyList.Location = New System.Drawing.Point(274, 43)
        Me.studyList.Name = "studyList"
        Me.studyList.Size = New System.Drawing.Size(178, 346)
        Me.studyList.TabIndex = 36
        '
        'StudySettingsLbl
        '
        Me.StudySettingsLbl.AutoSize = True
        Me.StudySettingsLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StudySettingsLbl.Location = New System.Drawing.Point(285, 5)
        Me.StudySettingsLbl.Name = "StudySettingsLbl"
        Me.StudySettingsLbl.Size = New System.Drawing.Size(142, 24)
        Me.StudySettingsLbl.TabIndex = 38
        Me.StudySettingsLbl.Text = "Study Settings"
        '
        'updateLstBtn
        '
        Me.updateLstBtn.Location = New System.Drawing.Point(265, 447)
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
        Me.addNewStudyLbl.Location = New System.Drawing.Point(285, 396)
        Me.addNewStudyLbl.Name = "addNewStudyLbl"
        Me.addNewStudyLbl.Size = New System.Drawing.Size(118, 20)
        Me.addNewStudyLbl.TabIndex = 41
        Me.addNewStudyLbl.Text = "Add New Study"
        '
        'studyIDLbl
        '
        Me.studyIDLbl.AutoSize = True
        Me.studyIDLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.studyIDLbl.Location = New System.Drawing.Point(270, 416)
        Me.studyIDLbl.Name = "studyIDLbl"
        Me.studyIDLbl.Size = New System.Drawing.Size(71, 20)
        Me.studyIDLbl.TabIndex = 40
        Me.studyIDLbl.Text = "Study ID"
        '
        'studyIdTb
        '
        Me.studyIdTb.Location = New System.Drawing.Point(360, 419)
        Me.studyIdTb.Name = "studyIdTb"
        Me.studyIdTb.Size = New System.Drawing.Size(69, 20)
        Me.studyIdTb.TabIndex = 39
        '
        'useExplicitGainsBtn
        '
        Me.useExplicitGainsBtn.AutoSize = True
        Me.useExplicitGainsBtn.Location = New System.Drawing.Point(15, 380)
        Me.useExplicitGainsBtn.Name = "useExplicitGainsBtn"
        Me.useExplicitGainsBtn.Size = New System.Drawing.Size(111, 17)
        Me.useExplicitGainsBtn.TabIndex = 52
        Me.useExplicitGainsBtn.Text = "Use Explicit Gains"
        Me.useExplicitGainsBtn.UseVisualStyleBackColor = True
        '
        'GainsHSB
        '
        Me.GainsHSB.LargeChange = 15
        Me.GainsHSB.Location = New System.Drawing.Point(16, 403)
        Me.GainsHSB.Maximum = 45
        Me.GainsHSB.Name = "GainsHSB"
        Me.GainsHSB.Size = New System.Drawing.Size(138, 10)
        Me.GainsHSB.SmallChange = 5
        Me.GainsHSB.TabIndex = 50
        Me.GainsHSB.Visible = False
        '
        'fakeSuccessRateLbl
        '
        Me.fakeSuccessRateLbl.AutoSize = True
        Me.fakeSuccessRateLbl.Location = New System.Drawing.Point(151, 361)
        Me.fakeSuccessRateLbl.Name = "fakeSuccessRateLbl"
        Me.fakeSuccessRateLbl.Size = New System.Drawing.Size(19, 13)
        Me.fakeSuccessRateLbl.TabIndex = 49
        Me.fakeSuccessRateLbl.Text = "50"
        '
        'FakeSucRateHSB
        '
        Me.FakeSucRateHSB.Location = New System.Drawing.Point(16, 364)
        Me.FakeSucRateHSB.Maximum = 99
        Me.FakeSucRateHSB.Minimum = 50
        Me.FakeSucRateHSB.Name = "FakeSucRateHSB"
        Me.FakeSucRateHSB.Size = New System.Drawing.Size(138, 10)
        Me.FakeSucRateHSB.SmallChange = 10
        Me.FakeSucRateHSB.TabIndex = 48
        Me.FakeSucRateHSB.Value = 50
        '
        'successRateLbl
        '
        Me.successRateLbl.AutoSize = True
        Me.successRateLbl.Location = New System.Drawing.Point(151, 324)
        Me.successRateLbl.Name = "successRateLbl"
        Me.successRateLbl.Size = New System.Drawing.Size(19, 13)
        Me.successRateLbl.TabIndex = 47
        Me.successRateLbl.Text = "50"
        '
        'SucRateHSB
        '
        Me.SucRateHSB.Location = New System.Drawing.Point(16, 327)
        Me.SucRateHSB.Maximum = 99
        Me.SucRateHSB.Minimum = 50
        Me.SucRateHSB.Name = "SucRateHSB"
        Me.SucRateHSB.Size = New System.Drawing.Size(138, 10)
        Me.SucRateHSB.TabIndex = 43
        Me.SucRateHSB.Value = 50
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 346)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Set Fake Success Rate"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 309)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Set Success Rate"
        '
        'explicitGainsLbl
        '
        Me.explicitGainsLbl.AutoSize = True
        Me.explicitGainsLbl.Location = New System.Drawing.Point(151, 400)
        Me.explicitGainsLbl.Name = "explicitGainsLbl"
        Me.explicitGainsLbl.Size = New System.Drawing.Size(13, 13)
        Me.explicitGainsLbl.TabIndex = 53
        Me.explicitGainsLbl.Text = "0"
        Me.explicitGainsLbl.Visible = False
        '
        'RiffTimingLbl
        '
        Me.RiffTimingLbl.AutoSize = True
        Me.RiffTimingLbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RiffTimingLbl.Location = New System.Drawing.Point(82, 13)
        Me.RiffTimingLbl.Name = "RiffTimingLbl"
        Me.RiffTimingLbl.Size = New System.Drawing.Size(82, 16)
        Me.RiffTimingLbl.TabIndex = 54
        Me.RiffTimingLbl.Text = "Riff Timing"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 284)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(187, 16)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Assistance Mode Settings"
        '
        'useBCICbox
        '
        Me.useBCICbox.AutoSize = True
        Me.useBCICbox.BackColor = System.Drawing.Color.Transparent
        Me.useBCICbox.Location = New System.Drawing.Point(81, 435)
        Me.useBCICbox.Name = "useBCICbox"
        Me.useBCICbox.Size = New System.Drawing.Size(63, 17)
        Me.useBCICbox.TabIndex = 56
        Me.useBCICbox.Text = "use BCI"
        Me.useBCICbox.UseVisualStyleBackColor = False
        '
        'hitWindowValLbl
        '
        Me.hitWindowValLbl.AutoSize = True
        Me.hitWindowValLbl.Location = New System.Drawing.Point(179, 227)
        Me.hitWindowValLbl.Name = "hitWindowValLbl"
        Me.hitWindowValLbl.Size = New System.Drawing.Size(25, 13)
        Me.hitWindowValLbl.TabIndex = 59
        Me.hitWindowValLbl.Text = "500"
        '
        'hitWindowSizeHSB
        '
        Me.hitWindowSizeHSB.Location = New System.Drawing.Point(15, 227)
        Me.hitWindowSizeHSB.Maximum = 1000
        Me.hitWindowSizeHSB.Minimum = 50
        Me.hitWindowSizeHSB.Name = "hitWindowSizeHSB"
        Me.hitWindowSizeHSB.Size = New System.Drawing.Size(161, 13)
        Me.hitWindowSizeHSB.TabIndex = 58
        Me.hitWindowSizeHSB.Value = 500
        '
        'hitWindowSizeLbl
        '
        Me.hitWindowSizeLbl.AutoSize = True
        Me.hitWindowSizeLbl.Location = New System.Drawing.Point(12, 214)
        Me.hitWindowSizeLbl.Name = "hitWindowSizeLbl"
        Me.hitWindowSizeLbl.Size = New System.Drawing.Size(150, 13)
        Me.hitWindowSizeLbl.TabIndex = 57
        Me.hitWindowSizeLbl.Text = "Hit Window Size (milliseconds)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(78, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 16)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Note Timing"
        '
        'takeNthNoteHSB
        '
        Me.takeNthNoteHSB.LargeChange = 1
        Me.takeNthNoteHSB.Location = New System.Drawing.Point(15, 262)
        Me.takeNthNoteHSB.Maximum = 5
        Me.takeNthNoteHSB.Minimum = 1
        Me.takeNthNoteHSB.Name = "takeNthNoteHSB"
        Me.takeNthNoteHSB.Size = New System.Drawing.Size(161, 13)
        Me.takeNthNoteHSB.TabIndex = 61
        Me.takeNthNoteHSB.Value = 5
        '
        'takeNthNoteLbl
        '
        Me.takeNthNoteLbl.AutoSize = True
        Me.takeNthNoteLbl.Location = New System.Drawing.Point(179, 262)
        Me.takeNthNoteLbl.Name = "takeNthNoteLbl"
        Me.takeNthNoteLbl.Size = New System.Drawing.Size(25, 13)
        Me.takeNthNoteLbl.TabIndex = 62
        Me.takeNthNoteLbl.Text = "500"
        '
        'takeNthNothHSB
        '
        Me.takeNthNothHSB.LargeChange = 1
        Me.takeNthNothHSB.Location = New System.Drawing.Point(15, 262)
        Me.takeNthNothHSB.Maximum = 5
        Me.takeNthNothHSB.Minimum = 1
        Me.takeNthNothHSB.Name = "takeNthNothHSB"
        Me.takeNthNothHSB.Size = New System.Drawing.Size(161, 13)
        Me.takeNthNothHSB.TabIndex = 61
        Me.takeNthNothHSB.Value = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 249)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(105, 13)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Take every Nth note"
        '
        'settingsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 567)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.takeNthNoteLbl)
        Me.Controls.Add(Me.takeNthNoteHSB)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.hitWindowValLbl)
        Me.Controls.Add(Me.hitWindowSizeHSB)
        Me.Controls.Add(Me.hitWindowSizeLbl)
        Me.Controls.Add(Me.useBCICbox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RiffTimingLbl)
        Me.Controls.Add(Me.explicitGainsLbl)
        Me.Controls.Add(Me.useExplicitGainsBtn)
        Me.Controls.Add(Me.GainsHSB)
        Me.Controls.Add(Me.fakeSuccessRateLbl)
        Me.Controls.Add(Me.FakeSucRateHSB)
        Me.Controls.Add(Me.successRateLbl)
        Me.Controls.Add(Me.SucRateHSB)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.updateLstBtn)
        Me.Controls.Add(Me.addNewStudyLbl)
        Me.Controls.Add(Me.studyIDLbl)
        Me.Controls.Add(Me.studyIdTb)
        Me.Controls.Add(Me.StudySettingsLbl)
        Me.Controls.Add(Me.studyList)
        Me.Controls.Add(Me.saveSettingsBtn)
        Me.Controls.Add(Me.reactionTimeValLbl)
        Me.Controls.Add(Me.reactionTimeHSB)
        Me.Controls.Add(Me.maxNotesValLbl)
        Me.Controls.Add(Me.maxBurstValLbl)
        Me.Controls.Add(Me.minBurstValLbl)
        Me.Controls.Add(Me.maxNotesPerRiffHSB)
        Me.Controls.Add(Me.maxMsecBetweenBurstsHSB)
        Me.Controls.Add(Me.minMsecBetweenBurstsHSB)
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
    Friend WithEvents minMsecBetweenBurstsHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents maxMsecBetweenBurstsHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents maxNotesPerRiffHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents minBurstValLbl As System.Windows.Forms.Label
    Friend WithEvents maxBurstValLbl As System.Windows.Forms.Label
    Friend WithEvents maxNotesValLbl As System.Windows.Forms.Label
    Friend WithEvents reactionTimeHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents reactionTimeValLbl As System.Windows.Forms.Label
    Friend WithEvents saveSettingsBtn As System.Windows.Forms.Button
    Friend WithEvents studyList As System.Windows.Forms.ListBox
    Friend WithEvents StudySettingsLbl As System.Windows.Forms.Label
    Friend WithEvents updateLstBtn As System.Windows.Forms.Button
    Friend WithEvents addNewStudyLbl As System.Windows.Forms.Label
    Friend WithEvents studyIDLbl As System.Windows.Forms.Label
    Friend WithEvents studyIdTb As System.Windows.Forms.TextBox
    Friend WithEvents useExplicitGainsBtn As System.Windows.Forms.CheckBox
    Friend WithEvents GainsHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents fakeSuccessRateLbl As System.Windows.Forms.Label
    Friend WithEvents FakeSucRateHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents successRateLbl As System.Windows.Forms.Label
    Friend WithEvents SucRateHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents explicitGainsLbl As System.Windows.Forms.Label
    Friend WithEvents RiffTimingLbl As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents useBCICbox As System.Windows.Forms.CheckBox
    Friend WithEvents hitWindowValLbl As System.Windows.Forms.Label
    Friend WithEvents hitWindowSizeHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents hitWindowSizeLbl As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents takeNthNoteHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents takeNthNoteLbl As System.Windows.Forms.Label
    Friend WithEvents takeNthNothHSB As System.Windows.Forms.HScrollBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
