
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.IO.Compression

Public Class Form1
    Private fso As Object
    Private FileSystemObject As Object
    Private ZipFile As Object
    Private ISOName As String
    Private Property file_ctr As Integer
    Public PerformStep


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the default directory of the folder browser to the current directory.     
        FolderBrowserDialogSource.SelectedPath = "C:\"
        FolderBrowserDialogDestination.SelectedPath = "C:\Users\"
    End Sub

    Private Sub sourceButton_Click(sender As Object, e As EventArgs) Handles sourceButton.Click
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

    Private Sub destinationButton_Click(sender As Object, e As EventArgs) Handles destinationButton.Click
        If FolderBrowserDialogDestination.ShowDialog() = DialogResult.OK Then

        End If
    End Sub
    Private Sub ListFiles(selectedPath As Object)
        'Throw New NotImplementedException()
    End Sub

    Private Sub copyButton_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Function vbAlignBottom() As Object
        Throw New NotImplementedException()
    End Function

    Public Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        ListBox1.HorizontalScrollbar = True

    End Sub

    Private Sub createButton_Click(sender As Object, e As EventArgs) Handles createButton.Click

        If My.Computer.FileSystem.CurrentDirectory.Count = 0 Then
            MsgBox("No files in List box")
        End If
        My.Computer.FileSystem.CurrentDirectory = FolderBrowserDialogDestination.SelectedPath
        Dim filename = ""
        Dim s2 As String = ".pak"
        Dim s3 As String = ".iso"
        Dim w As IO.StreamWriter
        Dim i As Integer
        w = New IO.StreamWriter("masterlist.txt", True)
        For i = 0 To ListBox1.Items.Count - 1
            filename = ListBox1.Items.Item(i)
            If filename.Contains(s2) Then
                w.WriteLine(ListBox1.Items.Item(i))
            End If
            If filename.Contains(s3) Then
                w.WriteLine(ListBox1.Items.Item(i))
            End If
        Next
        w.Close()

        If ListBox1.Items.Count = 0 Then
            MsgBox("No files in List box")

        End If

    End Sub

    Private Sub resetButton_Click(sender As Object, e As EventArgs) Handles resetButton.Click
        Controls.Clear()
        InitializeComponent()
    End Sub

    Private Sub sigButton_Click(sender As Object, e As EventArgs) Handles sigButton.Click
        Dim BannedFiles As String = "*.txt"
        Dim files() As System.IO.FileInfo
        Dim dirinfo As New System.IO.DirectoryInfo(FolderBrowserDialogDestination.SelectedPath)
        files = dirinfo.GetFiles("*.iso", IO.SearchOption.AllDirectories)
        'Dim BannedFiles = ("*.txt")
        If files.Count > 0 Then
            Process.Start("\\Cspdata1\gd\Internal QA Released Area\ZJer\MakeSigs\mksig.bat", FolderBrowserDialogDestination.SelectedPath)
        Else
            MsgBox("No files found in destination directory")
        End If
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
                ' Do Heavy Work
                DoHeavyWork()
                    BackgroundWorker1.ReportProgress(i)

    End If
        Next
    End Sub
    'Update ProgressBar Component 
    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        'PrecentLabel.Text = e.ProgressPercentage.ToString() + " %"
    End Sub
    'Called when work is complete
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs)
        If BackgroundWorker1.WorkerSupportsCancellation = True Then
            BackgroundWorker1.CancelAsync()
        End If
    End Sub


    Private Sub DoHeavyWork()
        System.Threading.Thread.Sleep(100)
    End Sub

    Private Sub symbolsCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles symbolsCheckBox.CheckedChanged

    End Sub



    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup
        Dim toolTip1 As New ToolTip()
        ' Set up the delays for the ToolTip.
        toolTip1.AutoPopDelay = 500
        toolTip1.InitialDelay = 500
        toolTip1.ReshowDelay = 500
        ' Set up the ToolTip text for the Button and Checkbox.

    End Sub




    Private Sub sigBox_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub ISOsigSortToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ISOsigSortToolStripMenuItem1.Click
        Form2.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub copyButton1_Click(sender As Object, e As EventArgs) Handles copyButton1.Click

        'If Not BackgroundWorker1.IsBusy = True Then
        'BackgroundWorker1.RunWorkerAsync()

        'Progress bar controls
        ProgressBar1.Visible = True

        Dim dirinfo As New System.IO.DirectoryInfo(FolderBrowserDialogSource.SelectedPath)
            Dim filesPak() As String = Directory.GetFiles(FolderBrowserDialogSource.SelectedPath, "*.pak")
            Dim filesDir() As String = Directory.GetFiles(FolderBrowserDialogSource.SelectedPath, "*.dir")
            Dim filesIso() As String = Directory.GetFiles(FolderBrowserDialogSource.SelectedPath, "*.iso")
            Dim filesDat() As String = Directory.GetFiles(FolderBrowserDialogSource.SelectedPath, "*.dat*")
            Dim filesZip() As String = Directory.GetFiles(FolderBrowserDialogSource.SelectedPath, "*.zip*")


            'Dim extractPath() As String = Directory.GetFiles(FolderBrowserDialogDestination.SelectedPath)
            Dim BannedFiles As String = "_Symbols"

            Dim clickedButton As Button = sender
            clickedButton.Text = "Processing..."
            clickedButton.Enabled = False

        If filesZip.Count > 0 Then
            'Logic for copying ISO, dat and paks
            For Each f In filesDat
                'Remove path from the file name.
                Dim fName As String = f.Substring(FolderBrowserDialogSource.SelectedPath.Length + 1)
                ' Use the Path.Combine method to safely append the file name to the path.
                ' Will overwrite if the destination file already exists.
                File.Copy(Path.Combine(FolderBrowserDialogSource.SelectedPath, fName), Path.Combine(FolderBrowserDialogDestination.SelectedPath, fName), True)
                ListBox1.Items.Add(fName)
            Next
            For Each f In filesPak
                'Remove path from the file name.
                Dim fName As String = f.Substring(FolderBrowserDialogSource.SelectedPath.Length + 1)
                ' Use the Path.Combine method to safely append the file name to the path.
                ' Will overwrite if the destination file already exists.
                File.Copy(Path.Combine(FolderBrowserDialogSource.SelectedPath, fName), Path.Combine(FolderBrowserDialogDestination.SelectedPath, fName), True)
                ListBox1.Items.Add(fName)
            Next
            For Each f In filesDir
                'Remove path from the file name.
                Dim fName As String = f.Substring(FolderBrowserDialogSource.SelectedPath.Length + 1)
                ' Use the Path.Combine method to safely append the file name to the path.
                ' Will overwrite if the destination file already exists.
                File.Copy(Path.Combine(FolderBrowserDialogSource.SelectedPath, fName), Path.Combine(FolderBrowserDialogDestination.SelectedPath, fName), True)
                ListBox1.Items.Add(fName)
            Next

            For Each f In filesIso
                'Remove path from the file name.
                Dim fName As String = f.Substring(FolderBrowserDialogSource.SelectedPath.Length + 1)

                ' Use the Path.Combine method to safely append the file name to the path.
                ' Will overwrite if the destination file already exists.
                If symbolsCheckBox.Checked = True Then
                    File.Copy(Path.Combine(FolderBrowserDialogSource.SelectedPath, fName), Path.Combine(FolderBrowserDialogDestination.SelectedPath, fName), True)
                    ListBox1.Items.Add(fName)
                ElseIf symbolsCheckBox.Checked = False Then
                    If Not fName.Contains(BannedFiles) Then
                        File.Copy(Path.Combine(FolderBrowserDialogSource.SelectedPath, fName), Path.Combine(FolderBrowserDialogDestination.SelectedPath, fName), True)
                        ListBox1.Items.Add(fName)
                    End If
                End If
            Next



            For Each f In filesZip


                'Declare the folder where the files will be extracted, creates it if not present
                Dim folderpath As String
                folderpath = FolderBrowserDialogSource.SelectedPath + "\temp"
                If Directory.Exists(folderpath) Then

                    'Remove path from the file name.
                    'Use the Path.Combine method to safely append the file name to the path.
                    Dim fName As String = f.Substring(FolderBrowserDialogSource.SelectedPath.Length + 1)


                    Dim sc As New Shell32.Shell()


                    folderpath = FolderBrowserDialogSource.SelectedPath + "\temp"
                    'Dim output As Shell32.Folder = sc.NameSpace("C:\Users\jorr\Desktop\zips\test\")
                    Dim output As Shell32.Folder = sc.NameSpace(folderpath)
                    'Declare your input zip file as folder
                    Dim input As Shell32.Folder = sc.NameSpace(Path.Combine(FolderBrowserDialogSource.SelectedPath, fName))
                    'Extract the files from the zip file using the CopyHere command
                    output.CopyHere(input.Items, 16)

                Else
                    folderpath = FolderBrowserDialogSource.SelectedPath + "\temp"
                    Directory.CreateDirectory(folderpath)

                    'Remove path from the file name.
                    'Use the Path.Combine method to safely append the file name to the path.
                    Dim fName As String = f.Substring(FolderBrowserDialogSource.SelectedPath.Length + 1)

                    Dim sc As New Shell32.Shell()


                    folderpath = FolderBrowserDialogSource.SelectedPath + "\temp"
                    'Dim output As Shell32.Folder = sc.NameSpace("C:\Users\jorr\Desktop\zips\test\")
                    Dim output As Shell32.Folder = sc.NameSpace(folderpath)
                    'Declare your input zip file as folder
                    Dim input As Shell32.Folder = sc.NameSpace(Path.Combine(FolderBrowserDialogSource.SelectedPath, fName))
                    'Extract the files from the zip file using the CopyHere command
                    output.CopyHere(input.Items, 16)

                End If
            Next
            Dim sourceDir As String
            sourceDir = FolderBrowserDialogSource.SelectedPath + "\temp"
            Dim filesIsoZip() As String = Directory.GetFiles(sourceDir, "*.iso")



            For Each ISO In filesIsoZip

                Dim folderpath1 As String = sourceDir
                Dim ISOName As String = ISO.Substring(folderpath1.Length + 1)

                File.Copy(Path.Combine(sourceDir, ISOName), Path.Combine(FolderBrowserDialogDestination.SelectedPath, ISOName), True)
                ProgressBar1.PerformStep()

                ListBox1.Items.Add(ISOName)

            Next

            copyButton1.Enabled = True
            clickedButton.Text = "UnZip"
            'End If
            finishedLabel.Text = "Done!"
            ProgressBar1.Value = 100

        Else
            MsgBox("No ZIP files found in Source directory")
        End If

    End Sub

    Private Function CopyFile(v As Char) As Boolean
        Throw New NotImplementedException()
    End Function

    Private Sub ISOUnZipToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ISOUnZipToolStripMenuItem.Click
        ISOUnzip.Show()
    End Sub
End Class