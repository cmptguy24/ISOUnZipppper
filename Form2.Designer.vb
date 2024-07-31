<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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
        Me.symbolsCheckBox = New System.Windows.Forms.CheckBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.destinationButton = New System.Windows.Forms.Button()
        Me.FolderBrowserDialogSource = New System.Windows.Forms.FolderBrowserDialog()
        Me.FolderBrowserDialogDestination = New System.Windows.Forms.FolderBrowserDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.finishedLabel1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolTip2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'symbolsCheckBox
        '
        Me.symbolsCheckBox.AutoSize = True
        Me.symbolsCheckBox.Location = New System.Drawing.Point(369, 197)
        Me.symbolsCheckBox.Name = "symbolsCheckBox"
        Me.symbolsCheckBox.Size = New System.Drawing.Size(15, 14)
        Me.symbolsCheckBox.TabIndex = 27
        Me.ToolTip1.SetToolTip(Me.symbolsCheckBox, "If checked adds Symbols files if available")
        Me.symbolsCheckBox.UseVisualStyleBackColor = True
        Me.symbolsCheckBox.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(225, 193)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(113, 10)
        Me.ProgressBar1.Step = 20
        Me.ProgressBar1.TabIndex = 14
        Me.ProgressBar1.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 27)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(207, 186)
        Me.ListBox1.TabIndex = 21
        '
        'destinationButton
        '
        Me.destinationButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.destinationButton.Location = New System.Drawing.Point(15, 46)
        Me.destinationButton.Name = "destinationButton"
        Me.destinationButton.Size = New System.Drawing.Size(112, 26)
        Me.destinationButton.TabIndex = 20
        Me.destinationButton.Text = "Destination"
        Me.destinationButton.UseVisualStyleBackColor = False
        '
        'FolderBrowserDialogSource
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(395, 24)
        Me.MenuStrip1.TabIndex = 29
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
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'finishedLabel1
        '
        Me.finishedLabel1.AutoSize = True
        Me.finishedLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.finishedLabel1.Location = New System.Drawing.Point(277, 197)
        Me.finishedLabel1.Name = "finishedLabel1"
        Me.finishedLabel1.Size = New System.Drawing.Size(0, 20)
        Me.finishedLabel1.TabIndex = 32
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Button1.Location = New System.Drawing.Point(29, 86)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 36)
        Me.Button1.TabIndex = 33
        Me.Button1.Text = "Clean up"
        Me.ToolTip2.SetToolTip(Me.Button1, "Cleans up ISO and sigs in Destination directory")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.destinationButton)
        Me.GroupBox1.Location = New System.Drawing.Point(235, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(149, 160)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Clears ISOs and SIGs"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(395, 228)
        Me.Controls.Add(Me.finishedLabel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.symbolsCheckBox)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Form2"
        Me.Text = "ISO Sort"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents symbolsCheckBox As CheckBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents destinationButton As Button
    Friend WithEvents FolderBrowserDialogSource As FolderBrowserDialog
    Friend WithEvents FolderBrowserDialogDestination As FolderBrowserDialog
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents finishedLabel1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolTip2 As ToolTip
    Friend WithEvents GroupBox1 As GroupBox
End Class
