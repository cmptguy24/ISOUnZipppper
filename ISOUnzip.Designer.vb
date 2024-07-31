<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ISOUnzip
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
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.treecounter = New System.Windows.Forms.Label()
        Me.Tv_Explorer = New System.Windows.Forms.TreeView()
        Me.Pop_button = New System.Windows.Forms.Button()
        Me.TxtBx_Path = New System.Windows.Forms.TextBox()
        Me.Tv_ImgList = New System.Windows.Forms.ImageList(Me.components)
        Me.UnZipButton = New System.Windows.Forms.Button()
        Me.UpdateListBox = New System.Windows.Forms.ListBox()
        Me.ClearCheckBox = New System.Windows.Forms.CheckBox()
        Me.unZipISOWorker = New System.ComponentModel.BackgroundWorker()
        Me.link = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MD5SumWorker = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MakeSigToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout
        Me.GroupBox2.SuspendLayout
        Me.MenuStrip1.SuspendLayout
        Me.SuspendLayout
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.treecounter)
        Me.GroupBox1.Controls.Add(Me.Tv_Explorer)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 95)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(379, 404)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = false
        Me.GroupBox1.Text = "Copy/Paste path"
        '
        'treecounter
        '
        Me.treecounter.AutoSize = true
        Me.treecounter.Location = New System.Drawing.Point(6, -19)
        Me.treecounter.Name = "treecounter"
        Me.treecounter.Size = New System.Drawing.Size(0, 13)
        Me.treecounter.TabIndex = 3
        '
        'Tv_Explorer
        '
        Me.Tv_Explorer.Location = New System.Drawing.Point(6, 19)
        Me.Tv_Explorer.Name = "Tv_Explorer"
        Me.Tv_Explorer.Size = New System.Drawing.Size(343, 366)
        Me.Tv_Explorer.TabIndex = 2
        '
        'Pop_button
        '
        Me.Pop_button.BackColor = System.Drawing.Color.Honeydew
        Me.Pop_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Pop_button.Location = New System.Drawing.Point(585, 42)
        Me.Pop_button.Name = "Pop_button"
        Me.Pop_button.Size = New System.Drawing.Size(87, 23)
        Me.Pop_button.TabIndex = 1
        Me.Pop_button.Text = "Add"
        Me.Pop_button.UseVisualStyleBackColor = false
        '
        'TxtBx_Path
        '
        Me.TxtBx_Path.Location = New System.Drawing.Point(12, 42)
        Me.TxtBx_Path.Name = "TxtBx_Path"
        Me.TxtBx_Path.Size = New System.Drawing.Size(548, 20)
        Me.TxtBx_Path.TabIndex = 0
        '
        'Tv_ImgList
        '
        Me.Tv_ImgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.Tv_ImgList.ImageSize = New System.Drawing.Size(16, 16)
        Me.Tv_ImgList.TransparentColor = System.Drawing.Color.Transparent
        '
        'UnZipButton
        '
        Me.UnZipButton.BackColor = System.Drawing.Color.AliceBlue
        Me.UnZipButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.UnZipButton.Location = New System.Drawing.Point(59, 23)
        Me.UnZipButton.Name = "UnZipButton"
        Me.UnZipButton.Size = New System.Drawing.Size(133, 26)
        Me.UnZipButton.TabIndex = 1
        Me.UnZipButton.Text = "Zip?"
        Me.UnZipButton.UseVisualStyleBackColor = false
        '
        'UpdateListBox
        '
        Me.UpdateListBox.FormattingEnabled = true
        Me.UpdateListBox.Location = New System.Drawing.Point(397, 95)
        Me.UpdateListBox.Name = "UpdateListBox"
        Me.UpdateListBox.Size = New System.Drawing.Size(275, 251)
        Me.UpdateListBox.TabIndex = 2
        '
        'ClearCheckBox
        '
        Me.ClearCheckBox.AutoSize = true
        Me.ClearCheckBox.Location = New System.Drawing.Point(420, 382)
        Me.ClearCheckBox.Name = "ClearCheckBox"
        Me.ClearCheckBox.Size = New System.Drawing.Size(80, 17)
        Me.ClearCheckBox.TabIndex = 3
        Me.ClearCheckBox.Text = "Clear path?"
        Me.ClearCheckBox.UseVisualStyleBackColor = true
        '
        'unZipISOWorker
        '
        Me.unZipISOWorker.WorkerReportsProgress = true
        Me.unZipISOWorker.WorkerSupportsCancellation = true
        '
        'link
        '
        Me.link.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.link.Location = New System.Drawing.Point(59, 57)
        Me.link.Name = "link"
        Me.link.Size = New System.Drawing.Size(60, 26)
        Me.link.TabIndex = 4
        Me.link.Text = "//Link"
        Me.link.UseVisualStyleBackColor = true
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Honeydew
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Location = New System.Drawing.Point(523, 374)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 30)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "ISO Unzip"
        Me.Button1.UseVisualStyleBackColor = false
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.UnZipButton)
        Me.GroupBox2.Controls.Add(Me.link)
        Me.GroupBox2.Location = New System.Drawing.Point(397, 418)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(275, 89)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = false
        Me.GroupBox2.Text = "Additional Controls"
        '
        'Button2
        '
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Location = New System.Drawing.Point(132, 57)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(60, 26)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "MD5Sum"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'MD5SumWorker
        '
        Me.MD5SumWorker.WorkerReportsProgress = true
        Me.MD5SumWorker.WorkerSupportsCancellation = true
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MakeSigToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(684, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MakeSigToolStripMenuItem
        '
        Me.MakeSigToolStripMenuItem.Name = "MakeSigToolStripMenuItem"
        Me.MakeSigToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.MakeSigToolStripMenuItem.Text = "MakeSig"
        '
        'ISOUnzip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(684, 533)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ClearCheckBox)
        Me.Controls.Add(Me.UpdateListBox)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Pop_button)
        Me.Controls.Add(Me.TxtBx_Path)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ISOUnzip"
        Me.Text = "ISOUnzip"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.MenuStrip1.ResumeLayout(false)
        Me.MenuStrip1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Tv_Explorer As TreeView
    Friend WithEvents Pop_button As Button
    Friend WithEvents TxtBx_Path As TextBox
    Friend WithEvents treecounter As Label
    Friend WithEvents Tv_ImgList As ImageList
    Friend WithEvents UnZipButton As Button
    Friend WithEvents UpdateListBox As ListBox
    Friend WithEvents ClearCheckBox As CheckBox
    Friend WithEvents unZipISOWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents link As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Button2 As Button
    Friend WithEvents MD5SumWorker As System.ComponentModel.BackgroundWorker
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MakeSigToolStripMenuItem As ToolStripMenuItem
End Class
