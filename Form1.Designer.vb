<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.sourceButton = New System.Windows.Forms.Button()
        Me.destinationButton = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.sigButton = New System.Windows.Forms.Button()
        Me.createButton = New System.Windows.Forms.Button()
        Me.FolderBrowserDialogSource = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialogDestination = New System.Windows.Forms.FolderBrowserDialog()
        Me.resetButton = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.controlBox1 = New System.Windows.Forms.GroupBox()
        Me.symbolsCheckBox = New System.Windows.Forms.CheckBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ISOsigSortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ISOsigSortToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManifestFixerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManifestFixerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ISOUnZipToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.workingLabel = New System.Windows.Forms.Label()
        Me.copyButton1 = New System.Windows.Forms.Button()
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip3 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolTip4 = New System.Windows.Forms.ToolTip(Me.components)
        Me.finishedLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.controlBox1.SuspendLayout
        Me.MenuStrip1.SuspendLayout
        Me.SuspendLayout
        '
        'sourceButton
        '
        Me.sourceButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.sourceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.sourceButton.Location = New System.Drawing.Point(350, 35)
        Me.sourceButton.Name = "sourceButton"
        Me.sourceButton.Size = New System.Drawing.Size(139, 32)
        Me.sourceButton.TabIndex = 0
        Me.sourceButton.Text = "Source"
        Me.ToolTip2.SetToolTip(Me.sourceButton, "Choose your folder where the Zip files are located")
        Me.sourceButton.UseVisualStyleBackColor = false
        '
        'destinationButton
        '
        Me.destinationButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.destinationButton.Location = New System.Drawing.Point(350, 84)
        Me.destinationButton.Name = "destinationButton"
        Me.destinationButton.Size = New System.Drawing.Size(139, 32)
        Me.destinationButton.TabIndex = 1
        Me.destinationButton.Text = "Destination"
        Me.ToolTip3.SetToolTip(Me.destinationButton, "Choose the destination you want unzipped to")
        Me.destinationButton.UseVisualStyleBackColor = false
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = true
        Me.ListBox1.Location = New System.Drawing.Point(26, 35)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(280, 225)
        Me.ListBox1.TabIndex = 2
        '
        'sigButton
        '
        Me.sigButton.Location = New System.Drawing.Point(27, 52)
        Me.sigButton.Name = "sigButton"
        Me.sigButton.Size = New System.Drawing.Size(136, 27)
        Me.sigButton.TabIndex = 7
        Me.sigButton.Text = "Create Checkwin Sigs"
        Me.sigButton.UseVisualStyleBackColor = true
        '
        'createButton
        '
        Me.createButton.Location = New System.Drawing.Point(27, 19)
        Me.createButton.Name = "createButton"
        Me.createButton.Size = New System.Drawing.Size(136, 27)
        Me.createButton.TabIndex = 8
        Me.createButton.Text = "Create masterlist.txt"
        Me.ToolTip4.SetToolTip(Me.createButton, "Creates a masterlist.text at destination")
        Me.createButton.UseVisualStyleBackColor = true
        '
        'resetButton
        '
        Me.resetButton.Location = New System.Drawing.Point(26, 296)
        Me.resetButton.Name = "resetButton"
        Me.resetButton.Size = New System.Drawing.Size(75, 23)
        Me.resetButton.TabIndex = 13
        Me.resetButton.Text = "Reset"
        Me.resetButton.UseVisualStyleBackColor = true
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(26, 266)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(280, 22)
        Me.ProgressBar1.Step = 27
        Me.ProgressBar1.TabIndex = 14
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = true
        Me.BackgroundWorker1.WorkerSupportsCancellation = true
        '
        'controlBox1
        '
        Me.controlBox1.Controls.Add(Me.Label1)
        Me.controlBox1.Controls.Add(Me.createButton)
        Me.controlBox1.Controls.Add(Me.sigButton)
        Me.controlBox1.Location = New System.Drawing.Point(335, 189)
        Me.controlBox1.Name = "controlBox1"
        Me.controlBox1.Size = New System.Drawing.Size(181, 99)
        Me.controlBox1.TabIndex = 17
        Me.controlBox1.TabStop = false
        Me.controlBox1.Text = "Additional Controls"
        '
        'symbolsCheckBox
        '
        Me.symbolsCheckBox.AutoSize = true
        Me.symbolsCheckBox.Location = New System.Drawing.Point(5, 305)
        Me.symbolsCheckBox.Name = "symbolsCheckBox"
        Me.symbolsCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.symbolsCheckBox.TabIndex = 18
        Me.ToolTip1.SetToolTip(Me.symbolsCheckBox, "If checked adds Symbols files if available")
        Me.symbolsCheckBox.UseVisualStyleBackColor = true
        Me.symbolsCheckBox.Visible = false
        '
        'ToolTip1
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ISOsigSortToolStripMenuItem, Me.ManifestFixerToolStripMenuItem, Me.ISOUnZipToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(532, 24)
        Me.MenuStrip1.TabIndex = 22
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(93, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ISOsigSortToolStripMenuItem
        '
        Me.ISOsigSortToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ISOsigSortToolStripMenuItem1})
        Me.ISOsigSortToolStripMenuItem.Name = "ISOsigSortToolStripMenuItem"
        Me.ISOsigSortToolStripMenuItem.Size = New System.Drawing.Size(78, 20)
        Me.ISOsigSortToolStripMenuItem.Text = "ISO Sorting"
        '
        'ISOsigSortToolStripMenuItem1
        '
        Me.ISOsigSortToolStripMenuItem1.Name = "ISOsigSortToolStripMenuItem1"
        Me.ISOsigSortToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.ISOsigSortToolStripMenuItem1.Text = "ISO/sig sorting"
        '
        'ManifestFixerToolStripMenuItem
        '
        Me.ManifestFixerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManifestFixerToolStripMenuItem1})
        Me.ManifestFixerToolStripMenuItem.Name = "ManifestFixerToolStripMenuItem"
        Me.ManifestFixerToolStripMenuItem.Size = New System.Drawing.Size(12, 20)
        '
        'ManifestFixerToolStripMenuItem1
        '
        Me.ManifestFixerToolStripMenuItem1.Name = "ManifestFixerToolStripMenuItem1"
        Me.ManifestFixerToolStripMenuItem1.Size = New System.Drawing.Size(170, 22)
        Me.ManifestFixerToolStripMenuItem1.Text = "Manifest/SIG Fixer"
        '
        'ISOUnZipToolStripMenuItem
        '
        Me.ISOUnZipToolStripMenuItem.Name = "ISOUnZipToolStripMenuItem"
        Me.ISOUnZipToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.ISOUnZipToolStripMenuItem.Text = "ISO UnZip"
        '
        'workingLabel
        '
        Me.workingLabel.AutoSize = true
        Me.workingLabel.Location = New System.Drawing.Point(249, 367)
        Me.workingLabel.Name = "workingLabel"
        Me.workingLabel.Size = New System.Drawing.Size(0, 13)
        Me.workingLabel.TabIndex = 23
        '
        'copyButton1
        '
        Me.copyButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.copyButton1.Image = CType(resources.GetObject("copyButton1.Image"),System.Drawing.Image)
        Me.copyButton1.Location = New System.Drawing.Point(362, 132)
        Me.copyButton1.Name = "copyButton1"
        Me.copyButton1.Size = New System.Drawing.Size(114, 34)
        Me.copyButton1.TabIndex = 24
        Me.copyButton1.Text = "UnZip!"
        Me.ToolTip4.SetToolTip(Me.copyButton1, "And go...")
        Me.copyButton1.UseVisualStyleBackColor = true
        '
        'finishedLabel
        '
        Me.finishedLabel.AutoSize = true
        Me.finishedLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.finishedLabel.Location = New System.Drawing.Point(400, 291)
        Me.finishedLabel.Name = "finishedLabel"
        Me.finishedLabel.Size = New System.Drawing.Size(0, 20)
        Me.finishedLabel.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Location = New System.Drawing.Point(11, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 13)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Hint: Use \Temptransfers\Jeremy"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(532, 324)
        Me.Controls.Add(Me.finishedLabel)
        Me.Controls.Add(Me.copyButton1)
        Me.Controls.Add(Me.workingLabel)
        Me.Controls.Add(Me.symbolsCheckBox)
        Me.Controls.Add(Me.controlBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.resetButton)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.destinationButton)
        Me.Controls.Add(Me.sourceButton)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = false
        Me.Name = "Form1"
        Me.Text = "ISO UnZipppper"
        Me.controlBox1.ResumeLayout(false)
        Me.controlBox1.PerformLayout
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents sourceButton As Button
    Friend WithEvents destinationButton As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents sigButton As Button
    Friend WithEvents createButton As Button
    Friend WithEvents FolderBrowserDialogSource As FolderBrowserDialog
    Friend WithEvents FolderBrowserDialogDestination As FolderBrowserDialog
    Friend WithEvents resetButton As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents controlBox1 As GroupBox
    Friend WithEvents symbolsCheckBox As CheckBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ISOsigSortToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ISOsigSortToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents workingLabel As Label
    Friend WithEvents copyButton1 As Button
    Friend WithEvents ToolTip2 As ToolTip
    Friend WithEvents ToolTip3 As ToolTip
    Friend WithEvents ToolTip4 As ToolTip
    Friend WithEvents ManifestFixerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManifestFixerToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents finishedLabel As Label
    Friend WithEvents ISOUnZipToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
End Class
