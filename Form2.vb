Imports System.IO
Imports Microsoft.VisualBasic

Public Class Form2

    Private Property file_ctr As Integer


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the default directory of the folder browser to the current directory.     
        FolderBrowserDialogSource.SelectedPath = "C:\"
        FolderBrowserDialogDestination.SelectedPath = "C:\"
    End Sub



    Private Sub resetButton_Click(sender As Object, e As EventArgs)
        Controls.Clear()
        InitializeComponent()
    End Sub


    Private Sub symbolsCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles symbolsCheckBox.CheckedChanged

    End Sub

    Private Sub sourceButton_Click(sender As Object, e As EventArgs)
        If FolderBrowserDialogSource.ShowDialog() = DialogResult.OK Then
            'list files in the folder.
            ListFiles(FolderBrowserDialogSource.SelectedPath)
        End If
        'if files equal 0
        file_ctr = 0
        ' Loop through each file in the directory
        For Each file As IO.FileInfo In New IO.DirectoryInfo(FolderBrowserDialogSource.SelectedPath).GetFiles
            file_ctr += 1
        Next
    End Sub

    Private Sub sourceLabel_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub ListFiles(selectedPath As Object)
        'Throw New NotImplementedException()
    End Sub
    Private Sub ISOsigSortToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Form1.Show()
    End Sub

    Private Sub destinationButton_Click(sender As Object, e As EventArgs) Handles destinationButton.Click
        If FolderBrowserDialogDestination.ShowDialog() = DialogResult.OK Then

        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub ToolStripProgressBar1_Click(sender As Object, e As EventArgs)

    End Sub

    'Do heavy work in background thread
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        For i = 0 To 100
            If BackgroundWorker1.CancellationPending = True Then
                e.Cancel = True
                Exit For
            Else
                'Do Heavy Work
                DoHeavyWork()
                BackgroundWorker1.ReportProgress(i)

            End If
        Next
    End Sub
    'Update ProgressBar Component 
    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        'precentLabel.Text = e.ProgressPercentage.ToString() + " %"
    End Sub
    'Called when work is complete
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs)
        If BackgroundWorker1.WorkerSupportsCancellation = True Then
            BackgroundWorker1.CancelAsync()
        End If
    End Sub

    Private Sub ProgressBar1_Click(sender As Object, e As EventArgs) Handles ProgressBar1.Click

    End Sub

    Private Sub copyButton1_Click(sender As Object, e As EventArgs)
        If Not BackgroundWorker1.IsBusy = True Then
            BackgroundWorker1.RunWorkerAsync()

            Dim clickedButton As Button = sender
            'Changes button to Processing and disables it
            clickedButton.Text = "Processing..."
            clickedButton.Enabled = False
            Dim sort_Name As String
            Dim files() As System.IO.FileInfo
            Dim dirinfo As New System.IO.DirectoryInfo(FolderBrowserDialogSource.SelectedPath)
            Dim BannedFiles As String = "_Symbols"
            files = dirinfo.GetFiles("*.iso", IO.SearchOption.AllDirectories)

            For Each file In files



                'Sorts isos and sigs and _symbols

                If symbolsCheckBox.Checked = True Then
                    If file.Name.EndsWith(".iso") Then
                        sort_Name = file.Name + ".sig"
                        My.Computer.FileSystem.CurrentDirectory = FolderBrowserDialogSource.SelectedPath
                        Dim newpath As String
                        newpath = IO.Path.Combine(FolderBrowserDialogDestination.SelectedPath, file.Name)
                        ' Overwrites iso to users local directory
                        If Not My.Computer.FileSystem.FileExists(sort_Name) Then

                            file.CopyTo(newpath, True)
                            'ListBox1.Items.Add(file)
                        End If
                    End If
                ElseIf symbolsCheckBox.Checked = False Then

                    If Not file.Name.Contains(BannedFiles) And file.Name.EndsWith(".iso") Then
                        sort_Name = file.Name + ".sig"
                        My.Computer.FileSystem.CurrentDirectory = FolderBrowserDialogSource.SelectedPath
                        Dim newpath As String
                        newpath = IO.Path.Combine(FolderBrowserDialogDestination.SelectedPath, file.Name)
                        'file.CopyTo(Path.Combine(FolderBrowserDialogSource.SelectedPath, sort_Name), Path.Combine(FolderBrowserDialogDestination.SelectedPath, sort_Name), True)
                        If Not My.Computer.FileSystem.FileExists(sort_Name) Then
                            file.CopyTo(newpath, True)
                            ListBox1.Items.Add(file)
                        End If

                    End If
                End If

                clickedButton.Text = "Copy"
                clickedButton.Enabled = True
            Next
        End If
        finishedLabel1.Text = "Done"


    End Sub
    Private Sub DoHeavyWork()
        System.Threading.Thread.Sleep(100)
    End Sub

    Private Sub symbolLabel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox1.HorizontalScrollbar = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim sort_Name As String
        Dim files() As System.IO.FileInfo
        Dim filexml() As System.IO.FileInfo
        Dim filebin() As System.IO.FileInfo
        Dim fileSource() As System.IO.FileInfo
        Dim dirinfo As New System.IO.DirectoryInfo(FolderBrowserDialogDestination.SelectedPath)
        Dim FileToDelete As String
        'Dim filexml As String
        files = dirinfo.GetFiles("*.iso", IO.SearchOption.AllDirectories)
        filexml = dirinfo.GetFiles("*.xml", IO.SearchOption.AllDirectories)
        filebin = dirinfo.GetFiles("*.bin", IO.SearchOption.AllDirectories)
        fileSource = dirinfo.GetFiles("*-Source.iso", IO.SearchOption.AllDirectories)

        For Each file In files
            If files.Count > 0 Then
                If file.Name.EndsWith(".iso") Then
                    FileToDelete = file.Name + ".sig"
                    My.Computer.FileSystem.CurrentDirectory = FolderBrowserDialogDestination.SelectedPath

                    If System.IO.File.Exists(FileToDelete) = True Then

                        System.IO.File.Delete(FileToDelete)
                        System.IO.File.Delete(file.Name)

                    End If
                End If
            Else
                MsgBox("No files found in destination directory")
            End If
        Next
        For Each file In filexml
            If filexml.Count > 0 Then
                If file.Name.EndsWith(".xml") Then
                    System.IO.File.Delete(file.Name)
                End If
            Else
                MsgBox("No files found in destination directory")
            End If

        Next
        For Each file In filebin
            If filebin.Count > 0 Then
                If file.Name.EndsWith(".bin") Then
                    System.IO.File.Delete(file.Name)
                End If
            Else
                MsgBox("No files found in destination directory")
            End If

        Next
        For Each file In fileSource
            If fileSource.Count > 0 Then
                If file.Name.EndsWith("-Source.iso") Then
                    System.IO.File.Delete(file.Name)
                End If
            Else
                MsgBox("No files found in destination directory")
            End If

        Next
        finishedLabel1.Text = "Cleared!"

    End Sub

    Private Sub FolderBrowserDialogSource_HelpRequest(sender As Object, e As EventArgs) Handles FolderBrowserDialogSource.HelpRequest

    End Sub

End Class
