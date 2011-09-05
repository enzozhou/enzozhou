<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_SysSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SysSetting))
        Me.p1 = New System.Windows.Forms.Panel
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.btn_ok = New System.Windows.Forms.Button
        Me.btn_rtn = New System.Windows.Forms.Button
        Me.btn_test = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tb_ip = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.tb_port = New System.Windows.Forms.TextBox
        Me.p1.SuspendLayout()
        Me.SuspendLayout()
        '
        'p1
        '
        Me.p1.BackColor = System.Drawing.Color.SeaShell
        Me.p1.Controls.Add(Me.Label3)
        Me.p1.Controls.Add(Me.tb_port)
        Me.p1.Controls.Add(Me.PictureBox3)
        Me.p1.Controls.Add(Me.btn_ok)
        Me.p1.Controls.Add(Me.btn_rtn)
        Me.p1.Controls.Add(Me.btn_test)
        Me.p1.Controls.Add(Me.Label2)
        Me.p1.Controls.Add(Me.Label1)
        Me.p1.Controls.Add(Me.tb_ip)
        Me.p1.Location = New System.Drawing.Point(0, 0)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(320, 300)
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(275, 2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(30, 24)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'btn_ok
        '
        Me.btn_ok.BackColor = System.Drawing.Color.PeachPuff
        Me.btn_ok.Location = New System.Drawing.Point(11, 207)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(101, 43)
        Me.btn_ok.TabIndex = 10
        Me.btn_ok.Text = "确 定"
        '
        'btn_rtn
        '
        Me.btn_rtn.BackColor = System.Drawing.Color.PeachPuff
        Me.btn_rtn.Location = New System.Drawing.Point(204, 207)
        Me.btn_rtn.Name = "btn_rtn"
        Me.btn_rtn.Size = New System.Drawing.Size(101, 43)
        Me.btn_rtn.TabIndex = 9
        Me.btn_rtn.Text = "返 回"
        '
        'btn_test
        '
        Me.btn_test.BackColor = System.Drawing.Color.PeachPuff
        Me.btn_test.Location = New System.Drawing.Point(240, 45)
        Me.btn_test.Name = "btn_test"
        Me.btn_test.Size = New System.Drawing.Size(65, 52)
        Me.btn_test.TabIndex = 8
        Me.btn_test.Text = "测 试"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.MistyRose
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(3, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(314, 21)
        Me.Label2.Text = "服务器连接设置"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(5, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.Text = "服务器IP:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tb_ip
        '
        Me.tb_ip.Location = New System.Drawing.Point(96, 58)
        Me.tb_ip.Name = "tb_ip"
        Me.tb_ip.Size = New System.Drawing.Size(138, 23)
        Me.tb_ip.TabIndex = 0
        Me.tb_ip.Text = "192"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(5, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.Text = "服务器端口:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label3.Visible = False
        '
        'tb_port
        '
        Me.tb_port.Location = New System.Drawing.Point(96, 101)
        Me.tb_port.Name = "tb_port"
        Me.tb_port.Size = New System.Drawing.Size(33, 23)
        Me.tb_port.TabIndex = 14
        Me.tb_port.Text = "1433"
        Me.tb_port.Visible = False
        '
        'frm_SysSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(378, 314)
        Me.ControlBox = False
        Me.Controls.Add(Me.p1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_SysSetting"
        Me.Text = "frm_SysSetting"
        Me.p1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents p1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Friend WithEvents btn_rtn As System.Windows.Forms.Button
    Friend WithEvents btn_test As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_ip As System.Windows.Forms.TextBox
    Private WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_port As System.Windows.Forms.TextBox
End Class
