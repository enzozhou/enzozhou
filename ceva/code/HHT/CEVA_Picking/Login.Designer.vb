<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Login
    Inherits System.Windows.Forms.Form

    '窗体重写释放，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox_uid = New System.Windows.Forms.TextBox
        Me.TextBox_pwd = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.TopPanel = New System.Windows.Forms.Panel
        Me.ll_version = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.tb_svrIP = New System.Windows.Forms.TextBox
        Me.btn_select = New System.Windows.Forms.Button
        Me.pb_keyBoard = New System.Windows.Forms.PictureBox
        Me.TopPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(40, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 19)
        Me.Label1.Text = "工号"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TextBox_uid
        '
        Me.TextBox_uid.Location = New System.Drawing.Point(120, 99)
        Me.TextBox_uid.MaxLength = 10
        Me.TextBox_uid.Name = "TextBox_uid"
        Me.TextBox_uid.Size = New System.Drawing.Size(153, 23)
        Me.TextBox_uid.TabIndex = 1
        '
        'TextBox_pwd
        '
        Me.TextBox_pwd.Location = New System.Drawing.Point(120, 126)
        Me.TextBox_pwd.MaxLength = 10
        Me.TextBox_pwd.Name = "TextBox_pwd"
        Me.TextBox_pwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox_pwd.Size = New System.Drawing.Size(153, 23)
        Me.TextBox_pwd.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(40, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 19)
        Me.Label3.Text = "密码"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(37, 208)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 47)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "确 定"
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.Location = New System.Drawing.Point(185, 208)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 47)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "取 消"
        '
        'TopPanel
        '
        Me.TopPanel.BackColor = System.Drawing.Color.Blue
        Me.TopPanel.Controls.Add(Me.ll_version)
        Me.TopPanel.Controls.Add(Me.Label6)
        Me.TopPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopPanel.Name = "TopPanel"
        Me.TopPanel.Size = New System.Drawing.Size(324, 30)
        '
        'll_version
        '
        Me.ll_version.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.ll_version.ForeColor = System.Drawing.Color.White
        Me.ll_version.Location = New System.Drawing.Point(222, 5)
        Me.ll_version.Name = "ll_version"
        Me.ll_version.Size = New System.Drawing.Size(95, 21)
        Me.ll_version.Text = "V1.0.1"
        Me.ll_version.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(5, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(198, 21)
        Me.Label6.Text = "CEVA拣货系统"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(40, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 19)
        Me.Label2.Text = "服务器"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tb_svrIP
        '
        Me.tb_svrIP.BackColor = System.Drawing.SystemColors.Info
        Me.tb_svrIP.Enabled = False
        Me.tb_svrIP.Location = New System.Drawing.Point(120, 157)
        Me.tb_svrIP.MaxLength = 10
        Me.tb_svrIP.Name = "tb_svrIP"
        Me.tb_svrIP.Size = New System.Drawing.Size(111, 23)
        Me.tb_svrIP.TabIndex = 0
        '
        'btn_select
        '
        Me.btn_select.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.btn_select.Location = New System.Drawing.Point(235, 155)
        Me.btn_select.Name = "btn_select"
        Me.btn_select.Size = New System.Drawing.Size(38, 27)
        Me.btn_select.TabIndex = 22
        Me.btn_select.Text = "..."
        '
        'pb_keyBoard
        '
        Me.pb_keyBoard.Image = CType(resources.GetObject("pb_keyBoard.Image"), System.Drawing.Image)
        Me.pb_keyBoard.Location = New System.Drawing.Point(280, 36)
        Me.pb_keyBoard.Name = "pb_keyBoard"
        Me.pb_keyBoard.Size = New System.Drawing.Size(37, 25)
        Me.pb_keyBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(324, 300)
        Me.ControlBox = False
        Me.Controls.Add(Me.pb_keyBoard)
        Me.Controls.Add(Me.btn_select)
        Me.Controls.Add(Me.tb_svrIP)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TopPanel)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox_pwd)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBox_uid)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login"
        Me.Text = "CEVA_RTN"
        Me.TopPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox_uid As System.Windows.Forms.TextBox
    Friend WithEvents TextBox_pwd As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Private WithEvents TopPanel As System.Windows.Forms.Panel
    Public WithEvents ll_version As System.Windows.Forms.Label
    Public WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tb_svrIP As System.Windows.Forms.TextBox
    Friend WithEvents btn_select As System.Windows.Forms.Button
    Friend WithEvents pb_keyBoard As System.Windows.Forms.PictureBox
End Class
