Imports System.IO
Imports System.Reflection
Imports System.Diagnostics


Public Class SlideshowForm

    'Private ImageFiles() As String = Nothing
    Private ImageFiles As ArrayList = Nothing
    Private ImageFolder As String = My.Application.Info.DirectoryPath
    Private ImageIndex As Integer = 0

    Const ONE_SECOND As Integer = 1000
    Private StartingInterval As Integer = 3 * ONE_SECOND
    Private IntervalStep As Integer = ONE_SECOND
    Private IntervalMin As Integer = ONE_SECOND
    Private IntervalMax As Integer = 10 * ONE_SECOND
    Private MessageShowCount As Integer = 3
    Private MessageSeenCount As Integer = 0
    Private MessageHideSpeed As Integer = 10
    Private MessageDisplayHeight As Integer = 30

    Private FullScreen As New FullScreenClass
    Public watchfolder As FileSystemWatcher

    Public Sub New()
        InitializeComponent()
    End Sub

#Region "Form Events"
    Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try

            ImageFiles = GetFiles(ImageFolder, "*.jpg;*.jpeg;*.png;*.bmp;*.tif;*.tiff;*.gif")

            watchfolder = New System.IO.FileSystemWatcher()
            watchfolder.IncludeSubdirectories = True
            watchfolder.Path = ImageFolder
            watchfolder.NotifyFilter = IO.NotifyFilters.FileName
            AddHandler watchfolder.Created, AddressOf LoadNewImage
            watchfolder.EnableRaisingEvents = True

            'Hide Message
            MessageValue.Height = 0

            'Load Image     
            ShowImage()

#If Not Debug Then
            'Set the image to full screen          
            FullScreen.EnterFullScreen(Me)
#End If

            'Start the slideshow 
            SlideshowTimer.Enabled = True
            SlideshowTimer.Interval = StartingInterval



        Catch ex As Exception
            MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        End Try
    End Sub
    Private Sub MainForm_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If SlideshowSplashScreen IsNot Nothing AndAlso SlideshowSplashScreen.Visible Then
            SlideshowSplashScreen.Close()
        End If
        watchfolder.EnableRaisingEvents = False
        SlideshowTimer.Enabled = False
        SlideshowTimer.Dispose()
        MessageTimer.Dispose()
    End Sub

    Private Sub GlobalEventProvider1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles GlobalEventProvider1.KeyDown
        e.Handled = True
        Select Case e.KeyData
            Case Keys.Escape
                Me.Close()
            Case Keys.Up
                GoFaster()
            Case Keys.Down
                GoSlower()
            Case Keys.Left
                ShowPrevImage()
            Case Keys.Right
                ShowNextImage()
            Case Keys.Space
                TogglePlay()
            Case Keys.F11
                ToggleFullScreen()
            Case Else
                e.Handled = False
        End Select
    End Sub


    Private Sub SlideShowPictureBox_DoubleClick(sender As System.Object, e As System.EventArgs) Handles SlideshowPictureBox.DoubleClick
        ToggleFullScreen()
    End Sub

    Private Sub Message_VisibleChanged(sender As System.Object, e As System.EventArgs) Handles MessageValue.VisibleChanged
        If MessageValue.Visible Then MessageValue.Height = MessageDisplayHeight

        MessageTimer.Enabled = MessageValue.Visible
    End Sub

    Private Sub SlideshowPictureBox_LoadCompleted(sender As System.Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles SlideshowPictureBox.LoadCompleted
        If e.Error IsNot Nothing Then
            'Unable to load image file, so remove from our list and load the next image
            ImageFiles.RemoveAt(ImageIndex)
            ShowImage()
        End If
    End Sub

#End Region


#Region "Timers"
    Private Sub SlideshowTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles SlideshowTimer.Tick
        ShowNextImage()
    End Sub
    Private Sub MessageTimer_Tick(sender As System.Object, e As System.EventArgs) Handles MessageTimer.Tick
        MessageSeenCount += 1
        If MessageSeenCount >= MessageShowCount Then
            MessageSeenCount = 0
            MessageTimer.Enabled = False
            HideMessageTimer.Interval = MessageHideSpeed
            HideMessageTimer.Enabled = True
        End If
    End Sub
    Private Sub HideMessageTimer_Tick(sender As System.Object, e As System.EventArgs) Handles HideMessageTimer.Tick
        If MessageValue.Height <= 0 Then
            MessageValue.Visible = False
            HideMessageTimer.Enabled = False
        Else
            MessageValue.Height -= 1
        End If
    End Sub
#End Region



#Region "Context Menu Options"
    Private Sub FasterMenuOption_Click(sender As System.Object, e As System.EventArgs) Handles FasterMenuOption.Click
        GoFaster()
    End Sub

    Private Sub SlowerMenuOption_Click(sender As System.Object, e As System.EventArgs) Handles SlowerMenuOption.Click
        GoSlower()
    End Sub

    Private Sub PauseMenuOption_Click(sender As System.Object, e As System.EventArgs) Handles PauseMenuOption.Click, PlayMenuOption.Click
        TogglePlay()
    End Sub

    Private Sub PreviousMenuOption_Click(sender As System.Object, e As System.EventArgs) Handles PreviousMenuOption.Click
        ShowPrevImage()
    End Sub
    Private Sub NextMenuOption_Click(sender As System.Object, e As System.EventArgs) Handles NextMenuOption.Click
        ShowNextImage()
    End Sub

    Private Sub FullScreenOption_Click(sender As System.Object, e As System.EventArgs) Handles ExitFullScreenOption.Click, StartFullScreenOption.Click
        ToggleFullScreen()
    End Sub

    Private Sub CloseOption_Click(sender As System.Object, e As System.EventArgs) Handles CloseOption.Click
        Me.Close()
    End Sub
#End Region

#Region "Methods"
    Public Shared Function GetFiles(ByVal path As String, ByVal searchPattern As String) As ArrayList 'String()
        Dim patterns() As String = searchPattern.Split(";"c)
        '   Dim files As New List(Of String)()
        Dim fileList As New ArrayList
        For Each filter As String In patterns
            ' Iterate through the directory tree and ignore the 
            ' DirectoryNotFoundException or UnauthorizedAccessException 
            ' exceptions. 
            ' http://msdn.microsoft.com/en-us/library/bb513869.aspx

            ' Data structure to hold names of subfolders to be
            ' examined for files.
            Dim dirs As New Stack(Of String)(20)

            If Not Directory.Exists(path) Then
                Throw New ArgumentException()
            End If
            dirs.Push(path)

            Do While dirs.Count > 0
                Dim currentDir As String = dirs.Pop()
                Dim subDirs() As String
                Try
                    subDirs = Directory.GetDirectories(currentDir)
                    ' An UnauthorizedAccessException exception will be thrown 
                    ' if we do not have discovery permission on a folder or 
                    ' file. It may or may not be acceptable to ignore the 
                    ' exception and continue enumerating the remaining files 
                    ' and folders. It is also possible (but unlikely) that a 
                    ' DirectoryNotFound exception will be raised. This will 
                    ' happen if currentDir has been deleted by another 
                    ' application or thread after our call to Directory.Exists. 
                    ' The choice of which exceptions to catch depends entirely 
                    ' on the specific task you are intending to perform and 
                    ' also on how much you know with certainty about the 
                    ' systems on which this code will run.
                Catch e1 As UnauthorizedAccessException
                    Continue Do
                Catch e2 As DirectoryNotFoundException
                    Continue Do
                End Try

                Try
                    fileList.AddRange(Directory.GetFiles(currentDir, filter))
                Catch e3 As UnauthorizedAccessException
                    Continue Do
                Catch e4 As DirectoryNotFoundException
                    Continue Do
                End Try

                ' Push the subdirectories onto the stack for traversal.
                ' This could also be done before handing the files.
                For Each str As String In subDirs
                    dirs.Push(str)
                Next str
            Loop
        Next filter

        'Return files.ToArray()
        Return fileList
    End Function

    Private Sub ShowImage(Optional ByVal jump As Integer = 0)
        Try
            ImageIndex += jump
            If ImageIndex < 0 Then
                'loop to last image
                ImageIndex = ImageFiles.Count - 1
            ElseIf ImageIndex >= ImageFiles.Count Then
                'loop to first image
                ImageIndex = 0
            End If
            If ImageFiles.Count > 0 AndAlso IO.File.Exists(ImageFiles(ImageIndex)) Then
                SlideshowPictureBox.ImageLocation = ImageFiles(ImageIndex)
            Else
                'image not found, remove from list
                If ImageFiles.Count > 0 Then ImageFiles.RemoveAt(ImageIndex)
                If ImageFiles.Count <= 0 Then
                    'no images left.

                    'stop slideshow                    
                    SlideshowTimer.Enabled = False

                    'show error message
                    MessageValue.Text = "Closing...no images found"
                    MessageValue.Visible = True                

                Me.Close()
                Else
                'show new image at old index               
                ShowImage()
            End If
            End If
        Catch ex As Exception
        Finally
            Me.BringToFront()
            Me.Focus()
        End Try

    End Sub

    Private Sub ShowPrevImage()
        ShowImage(-1)
    End Sub

    Private Sub ShowNextImage()
        ShowImage(1)
    End Sub

    Private Sub GoFaster()
        ShowTimerSpeed()
        If SlideshowTimer.Interval <= IntervalMin Then Exit Sub
        SlideshowTimer.Interval = SlideshowTimer.Interval - IntervalStep
    End Sub

    Private Sub GoSlower()
        ShowTimerSpeed()
        If SlideshowTimer.Interval >= IntervalMax Then Exit Sub
        SlideshowTimer.Interval = SlideshowTimer.Interval + IntervalStep
    End Sub

    Private Sub ShowTimerSpeed()
        MessageValue.Text = "Speed: " & SlideshowTimer.Interval / ONE_SECOND & " seconds"
        MessageValue.Visible = True
    End Sub

    Private Sub ToggleFullScreen()
        If FullScreen.IsFullScreen Then
            ExitFullScreenOption.Visible = False
            StartFullScreenOption.Visible = True
            'Set the image to full screen     
            FullScreen.LeaveFullScreen(Me)
        Else
            StartFullScreenOption.Visible = False
            ExitFullScreenOption.Visible = True
            FullScreen.EnterFullScreen(Me)
        End If
    End Sub

    Private Sub TogglePlay()
        SlideshowTimer.Enabled = Not SlideshowTimer.Enabled
        PauseMenuOption.Visible = SlideshowTimer.Enabled
        PlayMenuOption.Visible = Not SlideshowTimer.Enabled
        PreviousMenuOption.Visible = Not SlideshowTimer.Enabled
        NextMenuOption.Visible = Not SlideshowTimer.Enabled

        If SlideshowTimer.Enabled Then
            MessageValue.Text = "Slideshow started..."
        Else
            MessageValue.Text = "Slideshow paused"
        End If
        MessageValue.Visible = True
    End Sub

    Private Sub LoadNewImage(ByVal source As Object, ByVal e As System.IO.FileSystemEventArgs)
        'When a new file has been added to the folder, this method is called.

        'Test the file to make sure it's an image type from our list: "*.jpg;*.jpeg;*.png;*.bmp;*.tif;*.tiff;*.gif"
        Select Case e.FullPath.Substring(e.FullPath.LastIndexOf("."))
            Case ".jpg", ".jpeg", ".png", ".bmp", ".tif", ".tiff", ".gif"
                'We add the new file to the list of images, so it will part of the slideshow.
                ImageFiles.Add(e.FullPath)
        End Select
    End Sub

#End Region


 
End Class
