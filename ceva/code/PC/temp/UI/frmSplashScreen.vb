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
    Protected Friend WithEvents lblVersion As System.Windows.Forms.Label
    Protected Friend WithEvents picHeader As System.Windows.Forms.PictureBox
    Protected Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    Protected Friend WithEvents lblProductName As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSplashScreenBase__))
        Me.lblVersion = New System.Windows.Forms.Label
        Me.picHeader = New System.Windows.Forms.PictureBox
        Me.picLogo = New System.Windows.Forms.PictureBox
        Me.lblProductName = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblVersion
        '
        Me.lblVersion.BackColor = System.Drawing.Color.Black
        Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Location = New System.Drawing.Point(0, 206)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(398, 30)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Build 1.0.0.0"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picHeader
        '
        Me.picHeader.BackgroundImage = CType(resources.GetObject("picHeader.BackgroundImage"), System.Drawing.Image)
        Me.picHeader.Location = New System.Drawing.Point(-80, 0)
        Me.picHeader.Name = "picHeader"
        Me.picHeader.Size = New System.Drawing.Size(478, 64)
        Me.picHeader.TabIndex = 3
        Me.picHeader.TabStop = False
        '
        'picLogo
        '
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(24, 44)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(48, 48)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picLogo.TabIndex = 8
        Me.picLogo.TabStop = False
        '
        'lblProductName
        '
        Me.lblProductName.BackColor = System.Drawing.Color.Transparent
        Me.lblProductName.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductName.Location = New System.Drawing.Point(14, 104)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.Size = New System.Drawing.Size(360, 40)
        Me.lblProductName.TabIndex = 9
        Me.lblProductName.Text = "COM Express Generated"
        Me.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSplashScreenBase__
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(398, 236)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblProductName)
        Me.Controls.Add(Me.picLogo)
        Me.Controls.Add(Me.picHeader)
        Me.Controls.Add(Me.lblVersion)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmSplashScreenBase__"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSplashScreenBase___Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblVersion.Text = "Build #" & System.Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString
    End Sub

#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region

