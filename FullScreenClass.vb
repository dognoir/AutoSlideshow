
Public Class FullScreenClass
    Private winState As FormWindowState
    Private brdStyle As FormBorderStyle
    Private topMost As Boolean
    Private bounds As Rectangle

    Public Sub New()
        IsFullScreen = False
    End Sub

    Public IsFullScreen As Boolean

    ''' <summary>
    ''' Maximize the window to the full screen.
    ''' </summary>
    Public Sub EnterFullScreen(ByVal targetForm As Form)
        If Not IsFullScreen Then
            Save(targetForm) ' Save the original form state.

            targetForm.WindowState = FormWindowState.Maximized
            targetForm.FormBorderStyle = FormBorderStyle.None
            targetForm.TopMost = True
            targetForm.Bounds = Screen.GetBounds(targetForm)
            targetForm.Focus()
            IsFullScreen = True
        End If
    End Sub

    ''' <summary>
    ''' Save the current Window state.
    ''' </summary>
    Private Sub Save(ByVal targetForm As Form)
        winState = targetForm.WindowState
        brdStyle = targetForm.FormBorderStyle
        topMost = targetForm.TopMost
        bounds = targetForm.Bounds
    End Sub

    ''' <summary>
    ''' Leave the full screen mode and restore the original window state.
    ''' </summary>
    Public Sub LeaveFullScreen(ByVal targetForm As Form)
        If IsFullScreen Then
            ' Restore the original Window state.
            targetForm.WindowState = winState
            targetForm.FormBorderStyle = brdStyle
            targetForm.TopMost = topMost
            targetForm.Bounds = bounds

            IsFullScreen = False
        End If
    End Sub
End Class

