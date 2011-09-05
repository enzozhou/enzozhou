Public Class frmSplashScreenBase__
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected OverLoads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Protected Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents lblLicenseTo As System.Windows.Forms.Label
    Friend WithEvents lblWebSite As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblForRegion As System.Windows.Forms.Label
    Friend WithEvents lblAppTitle As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents lblLicenseText As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSplashScreenBase__))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblProductName = New System.Windows.Forms.Label
        Me.lblWarning = New System.Windows.Forms.Label
        Me.lblLicenseTo = New System.Windows.Forms.Label
        Me.lblLicenseText = New System.Windows.Forms.Label
        Me.lblWebSite = New System.Windows.Forms.Label
        Me.lblCopyright = New System.Windows.Forms.Label
        Me.lblForRegion = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.lblAppTitle = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.lblProductName)
        Me.GroupBox1.Controls.Add(Me.lblWarning)
        Me.GroupBox1.Controls.Add(Me.lblLicenseTo)
        Me.GroupBox1.Controls.Add(Me.lblLicenseText)
        Me.GroupBox1.Controls.Add(Me.lblWebSite)
        Me.GroupBox1.Controls.Add(Me.lblCopyright)
        Me.GroupBox1.Controls.Add(Me.lblForRegion)
        Me.GroupBox1.Controls.Add(Me.lblVersion)
        Me.GroupBox1.Controls.Add(Me.lblAppTitle)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(452, 326)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(166, 232)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 30
        Me.PictureBox1.TabStop = False
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.BackColor = System.Drawing.Color.Transparent
        Me.lblProductName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductName.ForeColor = System.Drawing.Color.Black
        Me.lblProductName.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.lblProductName.Location = New System.Drawing.Point(229, 56)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblProductName.Size = New System.Drawing.Size(85, 18)
        Me.lblProductName.TabIndex = 29
        Me.lblProductName.Text = "RF-Picking"
        Me.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblProductName.Visible = False
        '
        'lblWarning
        '
        Me.lblWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.Location = New System.Drawing.Point(8, 268)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(432, 48)
        Me.lblWarning.TabIndex = 28
        Me.lblWarning.Text = "Warning: This application software is protected by international copyright law. P" & _
            "lease do not distribute it illegally  in any form and media."
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLicenseTo
        '
        Me.lblLicenseTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLicenseTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicenseTo.Location = New System.Drawing.Point(188, 216)
        Me.lblLicenseTo.Name = "lblLicenseTo"
        Me.lblLicenseTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLicenseTo.Size = New System.Drawing.Size(248, 40)
        Me.lblLicenseTo.TabIndex = 27
        Me.lblLicenseTo.Text = "-"
        '
        'lblLicenseText
        '
        Me.lblLicenseText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicenseText.Location = New System.Drawing.Point(188, 192)
        Me.lblLicenseText.Name = "lblLicenseText"
        Me.lblLicenseText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLicenseText.Size = New System.Drawing.Size(72, 16)
        Me.lblLicenseText.TabIndex = 26
        Me.lblLicenseText.Text = "License to:"
        '
        'lblWebSite
        '
        Me.lblWebSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebSite.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblWebSite.Location = New System.Drawing.Point(188, 148)
        Me.lblWebSite.Name = "lblWebSite"
        Me.lblWebSite.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWebSite.Size = New System.Drawing.Size(256, 24)
        Me.lblWebSite.TabIndex = 25
        Me.lblWebSite.Text = "http://www.schmidtelectronics.com"
        '
        'lblCopyright
        '
        Me.lblCopyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.Location = New System.Drawing.Point(188, 124)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCopyright.Size = New System.Drawing.Size(256, 16)
        Me.lblCopyright.TabIndex = 24
        Me.lblCopyright.Text = "Copyright 2008 by Schmidt && Co., (H.K.) Ltd."
        '
        'lblForRegion
        '
        Me.lblForRegion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForRegion.Location = New System.Drawing.Point(252, 84)
        Me.lblForRegion.Name = "lblForRegion"
        Me.lblForRegion.Size = New System.Drawing.Size(180, 16)
        Me.lblForRegion.TabIndex = 23
        Me.lblForRegion.Text = "-"
        Me.lblForRegion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(320, 60)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblVersion.Size = New System.Drawing.Size(84, 16)
        Me.lblVersion.TabIndex = 22
        Me.lblVersion.Text = "Version 1.0.0"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAppTitle
        '
        Me.lblAppTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppTitle.Location = New System.Drawing.Point(188, 28)
        Me.lblAppTitle.Name = "lblAppTitle"
        Me.lblAppTitle.Size = New System.Drawing.Size(256, 24)
        Me.lblAppTitle.TabIndex = 21
        Me.lblAppTitle.Text = "CEVA RF-Picking System"
        '
        'frmSplashScreenBase__
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(468, 332)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSplashScreenBase__"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSplashScreenBase___Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadControlText()
        Me.lblVersion.Text = GetFieldCaption("ID_cap_frmAbout_lblVersion", True, "Version") & " " & GetCurrentVersion()
    End Sub

    Private Sub lblWebSite_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblWebSite.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lblWebSite_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblWebSite.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub LoadControlText()
        SetTextResource("ID_cap_frmAbout", Me.lblAppTitle)
        SetTextResource("ID_cap_frmAbout", Me.lblProductName)
        SetTextResource("ID_cap_frmAbout", Me.lblForRegion)
        SetTextResource("ID_cap_frmAbout", Me.lblCopyright)
        SetTextResource("ID_cap_frmAbout", Me.lblLicenseText)
        SetTextResource("ID_cap_frmAbout", Me.lblLicenseTo)
        SetTextResource("ID_cap_frmAbout", Me.lblWarning)
        Me.Text = ""      ' 2008-03-27, Simon, set caption to blank and not display title bar
        ' me.Text = GetFieldCaption("ID_cap_frmAbout_Title", True)
    End Sub

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region

    Private Sub frmSplashScreenBase___Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.lblVersion.Left = lblForRegion.Left + lblForRegion.Width - lblVersion.Width
        lblProductName.Left = Me.lblVersion.Left - 12 - lblProductName.Width
    End Sub


End Class

#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
'This section will not be overwritten during a round-trip code generation
#End Region

