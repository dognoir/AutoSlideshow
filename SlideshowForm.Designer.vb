<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SlideshowForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SlideshowForm))
        Me.HideMessageTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SlideshowTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MenuOptions = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SlideshowMenuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.FasterMenuOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.SlowerMenuOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.PauseMenuOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlayMenuOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreviousMenuOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.NextMenuOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartFullScreenOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitFullScreenOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseOption = New System.Windows.Forms.ToolStripMenuItem()
        Me.MessageTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MessageValue = New System.Windows.Forms.Label()
        Me.SlideshowPictureBox = New System.Windows.Forms.PictureBox()
        Me.GlobalEventProvider1 = New Gma.UserActivityMonitor.GlobalEventProvider()
        Me.MenuOptions.SuspendLayout()
        CType(Me.SlideshowPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HideMessageTimer
        '
        '
        'SlideshowTimer
        '
        Me.SlideshowTimer.Interval = 1000
        '
        'MenuOptions
        '
        Me.MenuOptions.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SlideshowMenuOptions, Me.StartFullScreenOption, Me.ExitFullScreenOption, Me.ToolStripSeparator1, Me.CloseOption})
        Me.MenuOptions.Name = "MenuOptions"
        Me.MenuOptions.Size = New System.Drawing.Size(188, 98)
        '
        'SlideshowMenuOptions
        '
        Me.SlideshowMenuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FasterMenuOption, Me.SlowerMenuOption, Me.PauseMenuOption, Me.PlayMenuOption, Me.PreviousMenuOption, Me.NextMenuOption})
        Me.SlideshowMenuOptions.Image = Global.Slideshow.My.Resources.Resources.media_play_green
        Me.SlideshowMenuOptions.Name = "SlideshowMenuOptions"
        Me.SlideshowMenuOptions.Size = New System.Drawing.Size(187, 22)
        Me.SlideshowMenuOptions.Text = "Slideshow Control"
        '
        'FasterMenuOption
        '
        Me.FasterMenuOption.Image = Global.Slideshow.My.Resources.Resources.media_fast_forward
        Me.FasterMenuOption.Name = "FasterMenuOption"
        Me.FasterMenuOption.Size = New System.Drawing.Size(195, 22)
        Me.FasterMenuOption.Text = "Faster   [Up-Arrow]"
        '
        'SlowerMenuOption
        '
        Me.SlowerMenuOption.Image = Global.Slideshow.My.Resources.Resources.media_rewind
        Me.SlowerMenuOption.Name = "SlowerMenuOption"
        Me.SlowerMenuOption.Size = New System.Drawing.Size(195, 22)
        Me.SlowerMenuOption.Text = "Slower  [Down-Arrow]"
        '
        'PauseMenuOption
        '
        Me.PauseMenuOption.Image = Global.Slideshow.My.Resources.Resources.media_pause
        Me.PauseMenuOption.Name = "PauseMenuOption"
        Me.PauseMenuOption.Size = New System.Drawing.Size(195, 22)
        Me.PauseMenuOption.Text = "Pause   [Spacebar]"
        '
        'PlayMenuOption
        '
        Me.PlayMenuOption.Image = Global.Slideshow.My.Resources.Resources.media_play
        Me.PlayMenuOption.Name = "PlayMenuOption"
        Me.PlayMenuOption.Size = New System.Drawing.Size(195, 22)
        Me.PlayMenuOption.Text = "Play      [Spacebar]"
        Me.PlayMenuOption.Visible = False
        '
        'PreviousMenuOption
        '
        Me.PreviousMenuOption.Image = Global.Slideshow.My.Resources.Resources.media_step_back
        Me.PreviousMenuOption.Name = "PreviousMenuOption"
        Me.PreviousMenuOption.Size = New System.Drawing.Size(195, 22)
        Me.PreviousMenuOption.Text = "Previous [Left-Arrow]"
        Me.PreviousMenuOption.Visible = False
        '
        'NextMenuOption
        '
        Me.NextMenuOption.Image = Global.Slideshow.My.Resources.Resources.media_step_forward
        Me.NextMenuOption.Name = "NextMenuOption"
        Me.NextMenuOption.Size = New System.Drawing.Size(195, 22)
        Me.NextMenuOption.Text = "Next        [Right-Arrow]"
        Me.NextMenuOption.Visible = False
        '
        'StartFullScreenOption
        '
        Me.StartFullScreenOption.Image = Global.Slideshow.My.Resources.Resources.breakpoint_selection
        Me.StartFullScreenOption.Name = "StartFullScreenOption"
        Me.StartFullScreenOption.Size = New System.Drawing.Size(187, 22)
        Me.StartFullScreenOption.Text = "Start Full Screen [F11]"
        Me.StartFullScreenOption.Visible = False
        '
        'ExitFullScreenOption
        '
        Me.ExitFullScreenOption.Image = Global.Slideshow.My.Resources.Resources.element_selection
        Me.ExitFullScreenOption.Name = "ExitFullScreenOption"
        Me.ExitFullScreenOption.Size = New System.Drawing.Size(187, 22)
        Me.ExitFullScreenOption.Text = "Exit Full Screen [F11]"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(184, 6)
        '
        'CloseOption
        '
        Me.CloseOption.Image = Global.Slideshow.My.Resources.Resources.exit_door
        Me.CloseOption.Name = "CloseOption"
        Me.CloseOption.Size = New System.Drawing.Size(187, 22)
        Me.CloseOption.Text = "Close [Esc-Key]"
        '
        'MessageTimer
        '
        Me.MessageTimer.Interval = 1000
        '
        'MessageValue
        '
        Me.MessageValue.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.MessageValue.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MessageValue.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MessageValue.ForeColor = System.Drawing.Color.White
        Me.MessageValue.Location = New System.Drawing.Point(0, 224)
        Me.MessageValue.Name = "MessageValue"
        Me.MessageValue.Size = New System.Drawing.Size(408, 30)
        Me.MessageValue.TabIndex = 2
        Me.MessageValue.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.MessageValue.Visible = False
        '
        'SlideshowPictureBox
        '
        Me.SlideshowPictureBox.ContextMenuStrip = Me.MenuOptions
        Me.SlideshowPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SlideshowPictureBox.InitialImage = Nothing
        Me.SlideshowPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.SlideshowPictureBox.Name = "SlideshowPictureBox"
        Me.SlideshowPictureBox.Size = New System.Drawing.Size(408, 254)
        Me.SlideshowPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.SlideshowPictureBox.TabIndex = 0
        Me.SlideshowPictureBox.TabStop = False
        '
        'GlobalEventProvider1
        '
        '
        'SlideshowForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(408, 254)
        Me.Controls.Add(Me.MessageValue)
        Me.Controls.Add(Me.SlideshowPictureBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SlideshowForm"
        Me.Text = "Slideshow"
        Me.TopMost = True
        Me.MenuOptions.ResumeLayout(False)
        CType(Me.SlideshowPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SlideshowPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents HideMessageTimer As System.Windows.Forms.Timer
    Private WithEvents SlideshowTimer As System.Windows.Forms.Timer
    Friend WithEvents MenuOptions As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents SlideshowMenuOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FasterMenuOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SlowerMenuOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PauseMenuOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlayMenuOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreviousMenuOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NextMenuOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartFullScreenOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitFullScreenOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CloseOption As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MessageTimer As System.Windows.Forms.Timer
    Friend WithEvents MessageValue As System.Windows.Forms.Label
    Friend WithEvents GlobalEventProvider1 As Gma.UserActivityMonitor.GlobalEventProvider

End Class
