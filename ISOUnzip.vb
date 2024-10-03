Imports System.IO
Imports Shell32
Imports System.Text
Imports System.Runtime.InteropServices
Imports System.Security.Cryptography

Public Class ISOUnzip
    Public Property addNodes As String
    Public filelist As String
    Private Parents As List(Of String)
    Private Children As List(Of String)
    Public Property Submitfullpathname As String
    Public Property file_exist As String

    Private Sub ISOUnzip_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Tv_ImgList.ImageSize = New Size(20, 20) 'we will set the size for the icon images to 20x20 just to make them easier to see clearly
        Tv_Explorer.ImageList = Tv_ImgList 'we need to set the ImageList property of the TreeView to our ImageList that will contain all the icon images.

        AddSpecialAndStandardFolderImages() 'now add the Special Folder and Standard folder icon images to the Image list before you add any root nodes.

        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
    End Sub

#Region "ICON info"

    Public Enum IconSizes As Integer
        Large32x32 = 0
        Small16x16 = 1
    End Enum

    Public Class Iconhelper

        Private Const SHGFI_ICON As Integer = &H100

        Private Const SHGFI_USEFILEATTRIBUTES As Integer = &H10



        <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
        Private Structure SHFILEINFOW
            Public hIcon As IntPtr
            Public iIcon As Integer
            Public dwAttributes As Integer
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)> Public szDisplayName As String
            <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)> Public szTypeName As String
        End Structure



        <DllImport("shell32.dll", EntryPoint:="SHGetFileInfoW")>
        Private Shared Function SHGetFileInfoW(<MarshalAs(UnmanagedType.LPTStr)> ByVal pszPath As String, ByVal dwFileAttributes As Integer, ByRef psfi As SHFILEINFOW, ByVal cbFileInfo As Integer, ByVal uFlags As Integer) As Integer
        End Function



        <DllImport("user32.dll", EntryPoint:="DestroyIcon")> Private Shared Function DestroyIcon(ByVal hIcon As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
        End Function



        ''' <summary>Gets a Bitmap image of the specified file or folder icon.</summary>
        ''' <param name="FileOrFolderPath">The full path to the folder or file to get the icon image from, or just a file extension (.ext) to get the registered icon image of the file type.</param>
        ''' <param name="IconSize">The size of the icon to retrieve.</param>
        Public Shared Function GetIconImage(ByVal FileOrFolderPath As String, ByVal IconSize As IconSizes) As Bitmap
            Dim bm As Bitmap = Nothing
            Dim fi As New SHFILEINFOW
            Dim flags As Integer = If(FileOrFolderPath.StartsWith("."), (IconSize Or SHGFI_USEFILEATTRIBUTES), IconSize)
            If SHGetFileInfoW(FileOrFolderPath, 0, fi, Marshal.SizeOf(fi), SHGFI_ICON Or flags) <> 0 Then
                bm = Icon.FromHandle(fi.hIcon).ToBitmap
            End If
            DestroyIcon(fi.hIcon).ToString()
            Return bm
        End Function
    End Class

#End Region

#Region "Add Image List"

    Private Function AddImageToImgList(FullPath As String, Optional SpecialImageKeyName As String = "") As String
        'If we specify a special ImageKey name when calling the sub, the ImgKey string is set to that name. Otherwise it is set to the full path.
        Dim ImgKey As String = If(SpecialImageKeyName = "", FullPath, SpecialImageKeyName)
        Dim LoadFromExt As Boolean = False

        'If a special ImageKey was not specified and the FullPath points to a File then we get the extension of the file and check
        'to see if it is not an exe, lnk, or url file type. If it is not, then we change the ImgKey to the extension of the file.
        If ImgKey = FullPath AndAlso File.Exists(FullPath) Then
            Dim ext As String = Path.GetExtension(FullPath).ToLower
            If ext <> ".iso" AndAlso ext <> ".zip" Then
                ImgKey = Path.GetExtension(FullPath).ToLower
                LoadFromExt = True
            End If
        End If

        'If the ImageList does not contain an image with this same ImageKey name, then we add the new image to the ImageList.
        If Not Tv_ImgList.Images.Keys.Contains(ImgKey) Then
            Tv_ImgList.Images.Add(ImgKey, Iconhelper.GetIconImage(If(LoadFromExt, ImgKey, FullPath), IconSizes.Large32x32))
        End If
        'we return the ImageKey name that was used to add this image to the ImageList. This will be used when a node for a file is added to the TreeView.

        Return ImgKey
    End Function

#End Region

#Region "Special and Standard Images"

    Private Sub AddSpecialAndStandardFolderImages()
        'Add one standard folder to the ImageList that will be used for all standard folders that are added to the ListView
        AddImageToImgList(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Folder")
        'Here we create a list of the Special Folders that have special icon images.
        Dim SpecialFolders As New List(Of Environment.SpecialFolder)
        With SpecialFolders

            .Add(Environment.SpecialFolder.Desktop)
            .Add(Environment.SpecialFolder.MyDocuments)
            .Add(Environment.SpecialFolder.Favorites)
            .Add(Environment.SpecialFolder.Recent)
            .Add(Environment.SpecialFolder.MyMusic)
            .Add(Environment.SpecialFolder.MyVideos)
            .Add(Environment.SpecialFolder.Fonts)
            .Add(Environment.SpecialFolder.History)
            .Add(Environment.SpecialFolder.MyPictures)
            .Add(Environment.SpecialFolder.UserProfile)

        End With
        'Now we iterate through the list of special folders and add these icon images to the ImageList
        For Each sf As Environment.SpecialFolder In SpecialFolders
            AddImageToImgList(Environment.GetFolderPath(sf))

        Next

    End Sub

#End Region


    Private Enum SpecialNodeFolders As Integer
        Desktop = Environment.SpecialFolder.Desktop
        Favorites = Environment.SpecialFolder.Favorites
        History = Environment.SpecialFolder.History
        MyDocuments = Environment.SpecialFolder.MyDocuments
        MyMusic = Environment.SpecialFolder.MyMusic
        MyPictures = Environment.SpecialFolder.MyPictures
        MyVideos = Environment.SpecialFolder.MyVideos
        Recent = Environment.SpecialFolder.Recent
        UserProfile = Environment.SpecialFolder.UserProfile
    End Enum

    Private Sub AddSpecialFolderRootNode(SpecialFolder As SpecialNodeFolders)
        'get the actual folder path for this Special Folder
        Dim SpecialFolderPath As String = Environment.GetFolderPath(CType(SpecialFolder, Environment.SpecialFolder))

        'Get just the name of the folder such as (Desktop, Documents, Pictures... you get the point)

        Dim SpecialFolderName As String = Path.GetFileName(SpecialFolderPath)
        'Add the image of the special folder. It is only added if the ImageList does not already contain this image.

        AddImageToImgList(SpecialFolderPath, SpecialFolderName)

        Dim DesktopNode As New TreeNode(SpecialFolderName) 'Create the new TreeNode for this folder.
        With DesktopNode
            .Tag = SpecialFolderPath 'set the Tag to the full path to this folder.
            .ImageKey = SpecialFolderName 'set the ImageKey to the ImageKey that was used when the image was added to the ImageList
            .SelectedImageKey = SpecialFolderName
            .Nodes.Add("Empty") 'add an empty child node so that this node shows the box for expanding the node
        End With
        Tv_Explorer.Nodes.Add(DesktopNode) 'add the folder node to the TreeView

    End Sub

    Private Sub AddCustomFolderRootNode(folderpath As String)
        If Directory.Exists(folderpath) Then 'check to make sure the folder exists before adding a node for it
            Dim FolderName As String = New DirectoryInfo(folderpath).Name 'get just the folder's name from the specified folder path.
            AddImageToImgList(folderpath) 'add the folder's icon to the ImageList.
            filelist = folderpath
            Dim rootNode As New TreeNode(FolderName) 'create a new TreeNode using the folder's name for the node's Text property.
            With rootNode
                .Tag = folderpath 'set the root node's Tag property to the folder's full path. This is used to get the full path of the folder that this node represents.
                .ImageKey = folderpath 'set the root node's ImageKey property to the folder's full path. Used to identify the icon for this node in the ImageList
                .SelectedImageKey = folderpath 'set the root node's SelectedImageKey property to the folder's full path

                'if the specified folder contains any sub files/folders, then we need to add an empty child node to this root node. This will add the [+] sign on the root node which will allow it to be expanded.
                If Directory.GetDirectories(folderpath).Count > 0 OrElse Directory.GetFiles(folderpath).Count > 0 Then
                    .Nodes.Add("Empty")
                End If
            End With
            Tv_Explorer.Nodes.Add(rootNode) 'add this root node to the treeview


        Else
            MsgBox("Folder does not exist! Check your path and try again")

        End If


    End Sub

    Private Sub JersCustomFolderRootNodeRefesh(folderpath As String)
        If Directory.Exists(folderpath) Then 'check to make sure the folder exists before adding a node for it
            Dim FolderName As String = New DirectoryInfo(folderpath).Name 'get just the folder's name from the specified folder path.
            AddImageToImgList(folderpath) 'add the folder's icon to the ImageList.

            Dim rootNode As New TreeNode(FolderName) 'create a new TreeNode using the folder's name for the node's Text property.

            With rootNode
                .Tag = folderpath 'set the root node's Tag property to the folder's full path. This is used to get the full path of the folder that this node represents.
                .ImageKey = folderpath 'set the root node's ImageKey property to the folder's full path. Used to identify the icon for this node in the ImageList
                .SelectedImageKey = folderpath 'set the root node's SelectedImageKey property to the folder's full path

                Try
                    'if the specified folder contains any sub files/folders, then we need to add an empty child node to this root node. This will add the [+] sign on the root node which will allow it to be expanded.
                    If Directory.GetDirectories(folderpath).Count > 0 OrElse Directory.GetFiles(folderpath).Count > 0 Then
                        .Nodes.Add("Empty")
                    End If
                Catch ex As Exception
                    'MessageBox.Show("Caller does not have the required permission")
                End Try
            End With
            Tv_Explorer.Nodes.Add(rootNode) 'add this root node to the treeview
            Tv_Explorer.SelectedNode = rootNode
            Tv_Explorer.SelectedNode.Expand()

        Else
            MsgBox("Folder does not exist! Check your path and try again")

        End If


    End Sub


    Private Sub AddChildNodes(tn As TreeNode, DirPath As String)
        Dim DirInfo As New DirectoryInfo(DirPath) 'Create a new DirectoryInfo class for the directory
        'We will place the code that iterates through the sub directories and files in a Try Catch because we might run into a folder or file
        'that we do not have the proper permissions to access. This will stop the code from throwing an exception and crashing our application.
        'We will use the Catch to handle any exceptions and let the user know what happened. Then the program can continue.

        Try

            For Each di As DirectoryInfo In DirInfo.GetDirectories 'iterate through sub folders of this directory or drive
                If Not (di.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then 'Make sure it is not a hidden folder, we don`t want them
                    Dim FolderNode As New TreeNode(di.Name) 'ceate a new TreeNode for the folder
                    With FolderNode
                        .Tag = di.FullName 'add the full folder path to the Tag property
                        '.Tag = TxtBx_Path

                        'If the ImageList contains an ImageKey for this folder path, we want to use the full path for the ImageKey of this node
                        If Tv_ImgList.Images.Keys.Contains(di.FullName) Then
                            .ImageKey = di.FullName
                            .SelectedImageKey = di.FullName
                        Else 'if the ImageList does not contain this folder path it would mean it is not a Special Folder, so we want to use the standard Folder image
                            .ImageKey = "Folder"
                            .SelectedImageKey = "Folder"
                        End If
                        .Nodes.Add("*Empty*") 'add an empty node to this child node so it can be expanded in the TreeView
                    End With
                    tn.Nodes.Add(FolderNode) 'add this folder node to the node that was expanded, the one passed to this sub
                    Submitfullpathname = di.FullName

                End If
            Next

            For Each fi As FileInfo In DirInfo.GetFiles 'iterate through the files in this directory or drive
                If Not (fi.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then 'Make sure it is not a hidden file, we don`t want them
                    'here is where we need to use the returned ImageKey that was used in the AddImageToImgList function to add the image to the ImageList.
                    'If you remember, if it is a registered file other than an exe, lnk, or url file type, the ImageKey name will be the extension of the file.
                    'Otherwise, it will be the full path to the file that is used to add the image to the ImageList.
                    Dim ImgKey As String = AddImageToImgList(fi.FullName)
                    Dim FileNode As New TreeNode(fi.Name) ' create a new TreeNode for this file
                    With FileNode
                        .Tag = fi.FullName 'add the full path to the file to the Tag property
                        .ImageKey = ImgKey 'we need to use the same ImageKey name that was used to add the image to the ImageList
                        .SelectedImageKey = ImgKey
                    End With


                    tn.Nodes.Add(FileNode) 'add this file node to the node that was expanded, the one passed to this sub

                End If
            Next

        Catch ex As Exception 'if an exception was thrown trying to access a folder or file, let the user know what exception was thrown
            MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub Tv_Explorer_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles Tv_Explorer.BeforeExpand


        'making use of LINQ we can get a boolean value of True/False that we can use to determine if the node is a drive and is ready to be accessed.
        'CD and DVD-ROMs will throw an exception if you try accessing anything other than their name if there is not a disc in the drive.
        Dim DrvIsReady As Boolean = (From d As DriveInfo In DriveInfo.GetDrives Where d.Name = e.Node.ImageKey Select d.IsReady).FirstOrDefault
        'if the node is not the Desktop node and does not contain a full folder path, or if it is a drive that is ready, or if the directory path
        'exists, we can add the child nodes to it from a single path that it`s Tag property has been set to.

        If (e.Node.ImageKey <> "Desktop" AndAlso Not e.Node.ImageKey.Contains(":\")) OrElse DrvIsReady OrElse Directory.Exists(e.Node.ImageKey) Then
            e.Node.Nodes.Clear() 'clear the "Empty" child node from this node
            AddChildNodes(e.Node, e.Node.Tag.ToString) 'call our sub to add the child nodes to this node
            Submitfullpathname = e.Node.Tag.ToString
        ElseIf e.Node.ImageKey = "Desktop" Then 'if the node is the Desktop node, we need to add the child nodes from two different folders.
            e.Node.Nodes.Clear() 'clear the "Empty" child node from this node

            'If a program was installed on the computer for all useres, the desktop shortcut will be placed in the CommonDesktopFolder. If a program was
            'installed for the current user only, then the desktop shortcut would be placed in the Desktop folder. So, we need to add the child nodes to
            'this node from two different folders in order to make sure we get all the shortcuts that the user sees on their desktop.
            Dim PublicDesktopFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)
            Dim CurrentUserDesktopFolder As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            AddChildNodes(e.Node, CurrentUserDesktopFolder)
            AddChildNodes(e.Node, PublicDesktopFolder)

        Else 'if it makes it to the Else part, it indicates that it must be a flash drive that is empty.
            e.Cancel = True 'cancel the node from expanding and then let the user know why
            MessageBox.Show("The Flash or Network Path is empty.", "Drive Info...", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Tv_Explorer_AfterCollapse(sender As Object, e As TreeViewEventArgs) Handles Tv_Explorer.AfterCollapse
        e.Node.Nodes.Clear()
        e.Node.Nodes.Add("Empty")
    End Sub


    Private Sub Tv_Explorer_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Tv_Explorer.NodeMouseDoubleClick
        'Make sure it is the left mouse button that was double clicked and that the node is a File node.
        If e.Button = MouseButtons.Left AndAlso File.Exists(e.Node.Tag.ToString) Then

            'we will use a Try Catch here just in case we run into a problem such as there not being a program registered on the system to
            'open the file type that we double click. Files like a (.dll) are not meant to be opened or ran and would give you this messege.
            Try
                Process.Start(e.Node.Tag.ToString) 'start the program exe or the default program for the double clicked file type
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

#Region "If checked in checkbox area"

    Private Sub Tv_Explorer_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles Tv_Explorer.AfterCheck
        Try
            Dim A As Boolean = e.Node.Checked
            If e.Action = TreeViewAction.ByMouse Or e.Action = TreeViewAction.ByKeyboard Then
                CUchkall(e.Node, A) 'updated 07/03/20 jbo
            End If
            'UnCheckParentNodes(e.Node)
            Call CuChild(e.Node)
        Catch
        End Try
    End Sub

    Private Sub CuChild(ByVal iNode As TreeNode)

        Try
            Dim E As Boolean = True
            If iNode.Parent IsNot Nothing Then
                For Each M As TreeNode In iNode.Parent.Nodes
                    If M.Checked = False Then E = False 'Jer modified
                    'If M.Checked = False Then E = True 'updated 07/03/20 jbo
                Next
                iNode.Parent.Checked = E

            End If
        Catch
        End Try
    End Sub

    Private Sub CUchkall(ByVal iNode As TreeNode, COU As Boolean)
        Try
            If iNode.Nodes IsNot Nothing Then
                For Each N As TreeNode In iNode.Nodes
                    N.Checked = COU
                    Call CUchkall(N, COU)
                Next
            End If
        Catch
        End Try
    End Sub

    Private Sub UnCheckParentNodes(ByVal iNode As TreeNode)
        Try
            If iNode.Checked = False AndAlso iNode.Parent IsNot Nothing Then
                iNode.Parent.Checked = False
                UnCheckParentNodes(iNode.Parent)
            End If
        Catch
        End Try
    End Sub
#End Region


    Private Sub setLabelTxt(ByVal text As String, ByVal lbl As Label)
        If lbl.InvokeRequired Then
            lbl.Invoke(New setLabelTxtInvoker(AddressOf setLabelTxt), text, lbl)
        Else
            lbl.Text = text
        End If
    End Sub
    Private Delegate Sub setLabelTxtInvoker(ByVal text As String, ByVal lbl As Label)

    Private Sub Pop_button_Click(sender As Object, e As EventArgs) Handles Pop_button.Click
        Tv_Explorer.Nodes.Clear()
        addNodes = TxtBx_Path.Text 'Sets path containing files
        If String.IsNullOrEmpty(addNodes) Then 'Checks for empty values in path
            MsgBox("Please enter a path!")
        ElseIf addNodes IsNot Nothing Then

            JersCustomFolderRootNodeRefesh(addNodes)

            Try
#Region "Sets label for file type extensions"
                Dim counter As Integer = IO.Directory.GetFiles(addNodes, "*.*", IO.SearchOption.TopDirectoryOnly).Length 'counts the number of files
                setLabelTxt("Found: " + counter.ToString, treecounter) 'displays the amount of files
            Catch ex As Exception
                setLabelTxt("Opps! You don't have permission to this folder!", treecounter)
            End Try
#End Region
        End If
    End Sub

    Private Sub UnZipButton_Click(sender As Object, e As EventArgs) Handles UnZipButton.Click
        UpdateListBox.Items.Clear()
        UpdateListBox.Items.Add("Initializing UnZip...")
        Pop_button.Enabled = False
        Button1.Enabled = False
        UnZipButton.Enabled = False
        Button2.Enabled = False
        addNodes = Submitfullpathname


        Dim result As New List(Of TreeNode)
        'Get the root nodes
        Dim nodes As New Stack(Of TreeNode)
        For Each tn As TreeNode In Tv_Explorer.Nodes
            nodes.Push(tn)

        Next
        'Check each node and it's children
        While nodes.Count > 0
            Dim popNode As TreeNode = nodes.Pop
            If popNode.Checked Then
                result.Add(popNode)
            End If
            For Each tn As TreeNode In popNode.Nodes
                nodes.Push(tn)

                If tn.Checked Then

                    Dim isoname, isolink As String
                    isoname = tn.Text
                    isolink = tn.Tag

                    My.Computer.FileSystem.CurrentDirectory = addNodes
                    Dim destinationdirectory As String = ("\\C:\Source\") 'Place your Source folder here
                    If System.IO.File.Exists(isoname) Then
                        If isoname.EndsWith(".zip") Then
                            Dim filesZip() As String = Directory.GetFiles(addNodes, "*.zip*")
                            Dim folderpath As String


                            'For Each f In filesZip
                            'Declare the folder where the files will be extracted, creates it if not present
                            folderpath = System.IO.Path.GetTempPath + "zips"
                                'Checks to see if Temp/Zip folder exsists and creates it if not
                                If Not Directory.Exists(folderpath) Then
                                    Directory.CreateDirectory(folderpath)
                                End If
                            'Sets the file name
                            'Dim fName As String = Path.GetFileName(f)
                            Dim fName As String = Path.GetFileName(isolink)
                            Dim sc As New Shell32.Shell()
                                Dim output As Shell32.Folder = sc.NameSpace(folderpath)
                                Dim input As Shell32.Folder = sc.NameSpace(Path.Combine(addNodes, fName))
                                UpdateListBox.Items.Add("ZIP file found! ... extracting")
                                'Extract the files from the zip file using the CopyHere command
                                output.CopyHere(input.Items, 20) 'Unzip parameters updated from 16 - jbo 09/24/2020

                                UpdateListBox.TopIndex = UpdateListBox.Items.Count - 1 'updates list to scroll to bottom
                            'Next
                        End If
                    End If
                End If
            Next
        End While
        UpdateListBox.Items.Add("Extracted!")


    End Sub

    Private Sub unZipISOWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles unZipISOWorker.DoWork
        Dim OrigPath = TxtBx_Path.Text 'sets path to copy content
        Dim ZipPath = ("C:\Users\jorr\AppData\Local\Temp\zips")
        Dim destName As String = ("C:\Source\") 'Place your Source folder here
        If OrigPath Is Nothing Then
            MsgBox("Please Choose a destination")
        ElseIf OrigPath Is "" Then
            MsgBox("Please Choose a destination")
        Else
            If ClearCheckBox.Checked = True Then
                UpdateListBox.Items.Add("Is checked. Cleaning Files In Path ...")
                UpdateListBox.TopIndex = UpdateListBox.Items.Count - 1 'updates list to scroll to bottom
                Dim files() As System.IO.FileInfo
                Dim dirinfo As New System.IO.DirectoryInfo(destName)

                files = dirinfo.GetFiles("*.*", IO.SearchOption.TopDirectoryOnly) 'set working directory


                For Each file In files
                    If files.Count > 0 Then
                        My.Computer.FileSystem.CurrentDirectory = destName
                        If file.Name.EndsWith(".iso") Then
                            System.IO.File.Delete(file.Name) 'Cleans iso file in temp/sig folder
                            UpdateListBox.Items.Add(file.Name & " ... Cleared ")
                            UpdateListBox.TopIndex = UpdateListBox.Items.Count - 1 'updates list to scroll to bottom
                        Else
                        End If
                        If file.Name.EndsWith(".txt") Then
                            System.IO.File.Delete(file.Name) 'Cleans iso file in temp/sig folder
                            UpdateListBox.Items.Add(file.Name & " ... Cleared ")
                            UpdateListBox.TopIndex = UpdateListBox.Items.Count - 1 'updates list to scroll to bottom
                        Else
                        End If
                    End If
                Next
            End If


            Dim filesIso() As String = Directory.GetFiles(OrigPath, "*.iso*")

            For Each f In filesIso
                'If tn.Checked Then
                'Sets the file name
                Dim fName As String = Path.GetFileName(f)
                Dim dirName As String = Path.GetFileNameWithoutExtension(f)
                Dim full As String = Path.GetFullPath(f)
                My.Computer.FileSystem.CurrentDirectory = destName
                If Not Directory.Exists(dirName) Then
                    Directory.CreateDirectory(dirName)
                End If
                Dim copydest As String = destName + dirName
                Dim exePath As String = "C:\Program Files\7-Zip\7z.exe"
                Dim args As String = "x " + full + " -o""C:\Source\*" 'Place your Source folder here
                System.Diagnostics.Process.Start(exePath, args)

                UpdateListBox.Items.Add("Found " & fName)
                UpdateListBox.Items.Add("Extracting contents .. ")
                'Extract the files from the ISO file using the CopyHere command
                UpdateListBox.TopIndex = UpdateListBox.Items.Count - 1 'updates list to scroll to bottom
                'End If
            Next
        End If




    End Sub

    Private Sub unZipISOWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles unZipISOWorker.RunWorkerCompleted

        UpdateListBox.Items.Add("Finished!")
        'UpdateListBox.DrawMode = DrawMode.OwnerDrawFixed
        UpdateListBox.TopIndex = UpdateListBox.Items.Count - 1 'updates list to scroll to bottom
        Pop_button.Enabled = True
        Button1.Enabled = True
        UnZipButton.Enabled = True
        Button2.Enabled = True
    End Sub



    Private Sub link_Click(sender As Object, e As EventArgs) Handles link.Click
        Dim tempfolder As String
        tempfolder = System.IO.Path.GetTempPath + "zips"
        If Directory.Exists(tempfolder) Then
            Process.Start(tempfolder)
        Else
            MsgBox("Temp folder seems to be missing")
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Pop_button.Enabled = False
        Button1.Enabled = False
        UnZipButton.Enabled = False
        Button2.Enabled = False
        Dim destDir = "W:\Jeremy\ItalySource\"
        ' Loop over the subdirectories and remove them with their contents
        For Each d In Directory.GetDirectories(destDir, "*.*", SearchOption.AllDirectories)
            Try
                Directory.Delete(d, True)
            Catch ex As Exception
                'MsgBox("Error")
            End Try
        Next



        unZipISOWorker.RunWorkerAsync()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Pop_button.Enabled = False
        Button1.Enabled = False
        UnZipButton.Enabled = False
        Button2.Enabled = False




        MD5SumWorker.RunWorkerAsync()
    End Sub

    Private Shared Function CreateMD5StringFromFile(ByVal Filename As String) As String

        Dim MD5 = System.Security.Cryptography.MD5.Create
        Dim Hash As Byte()
        Dim sb As New System.Text.StringBuilder

        Using st As New IO.FileStream(Filename, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
            Hash = MD5.ComputeHash(st)
        End Using

        For Each b In Hash
            sb.Append(b.ToString("x2"))
        Next

        Return sb.ToString
    End Function

    Private Sub MD5SumWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles MD5SumWorker.DoWork
        For Each Dir As String In Directory.GetDirectories("W:\Jeremy\ItalySource")
            Dim dirInfo As New System.IO.DirectoryInfo(Dir)
            UpdateListBox.Items.Add("Working on " & dirInfo.Name & ".txt")
            UpdateListBox.TopIndex = UpdateListBox.Items.Count - 1 'updates list to scroll to bottom
            My.Computer.FileSystem.CurrentDirectory = "W:\Jeremy\ItalySource"
            If Not System.IO.File.Exists(dirInfo.Name) Then
                System.IO.File.Create(dirInfo.Name + ".txt").Dispose()
            End If
            'Dim files As var = Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories).OrderByp.ToList()
            Dim MD5file = dirInfo.Name + ".txt"

            For Each f As String In My.Computer.FileSystem.GetFiles(dirInfo.Name, FileIO.SearchOption.SearchAllSubDirectories, "*.*")
                Dim md5String = CreateMD5StringFromFile(f)

                Dim trimChars As Char() = {"W"c, ":"c, "\"c, "J"c, "e"c, "r"c, "e"c, "m"c, "y"c, "I"c, "t"c, "a"c, "l"c, "y"c, "S"c, "o"c, "u"c, "r"c, "c"c, "e"c}
                Dim str4 As String = f
                Dim result As String = str4.TrimStart(trimChars)
                'Dim folderPath As String = f.TrimStart
                Using writer As New StreamWriter(MD5file, True)
                    writer.WriteLine(".\" & result & ";" & md5String)
                End Using
            Next
        Next
    End Sub

    Private Sub MD5SumWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles MD5SumWorker.RunWorkerCompleted

        UpdateListBox.Items.Add("MD5 results finished!")
        UpdateListBox.TopIndex = UpdateListBox.Items.Count - 1 'updates list to scroll to bottom
        Pop_button.Enabled = True
        Button1.Enabled = True
        UnZipButton.Enabled = True
        Button2.Enabled = True
    End Sub

   

    Private Sub MakeSigToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MakeSigToolStripMenuItem.Click
        Form1.show
    End Sub
End Class
