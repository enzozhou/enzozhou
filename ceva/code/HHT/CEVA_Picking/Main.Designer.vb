<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.p0 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.StatusPanel = New System.Windows.Forms.Panel
        Me.ll_pcnt = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.tb_msg1 = New System.Windows.Forms.Label
        Me.timeStatus = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.pictureBox2 = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.PB_Exit = New System.Windows.Forms.PictureBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.PB_Inquire = New System.Windows.Forms.PictureBox
        Me.TopPanel = New System.Windows.Forms.Panel
        Me.ll_version = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.p1 = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.btn_ok = New System.Windows.Forms.Button
        Me.btn_rtn = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Timer2 = New System.Windows.Forms.Timer
        Me.p0.SuspendLayout()
        Me.StatusPanel.SuspendLayout()
        Me.TopPanel.SuspendLayout()
        Me.p1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'p0
        '
        Me.p0.BackColor = System.Drawing.Color.SeaShell
        Me.p0.Controls.Add(Me.Label3)
        Me.p0.Controls.Add(Me.PictureBox5)
        Me.p0.Controls.Add(Me.StatusPanel)
        Me.p0.Controls.Add(Me.Label4)
        Me.p0.Controls.Add(Me.pictureBox2)
        Me.p0.Controls.Add(Me.Label6)
        Me.p0.Controls.Add(Me.pictureBox1)
        Me.p0.Controls.Add(Me.Label7)
        Me.p0.Controls.Add(Me.PB_Exit)
        Me.p0.Controls.Add(Me.Label10)
        Me.p0.Controls.Add(Me.PB_Inquire)
        Me.p0.Location = New System.Drawing.Point(0, 0)
        Me.p0.Name = "p0"
        Me.p0.Size = New System.Drawing.Size(320, 300)
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(13, 253)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.Text = "挂起设备"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.SeaShell
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(13, 178)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(72, 72)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'StatusPanel
        '
        Me.StatusPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.StatusPanel.Controls.Add(Me.ll_pcnt)
        Me.StatusPanel.Controls.Add(Me.ProgressBar1)
        Me.StatusPanel.Controls.Add(Me.tb_msg1)
        Me.StatusPanel.Controls.Add(Me.timeStatus)
        Me.StatusPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusPanel.Location = New System.Drawing.Point(0, 275)
        Me.StatusPanel.Name = "StatusPanel"
        Me.StatusPanel.Size = New System.Drawing.Size(320, 25)
        '
        'll_pcnt
        '
        Me.ll_pcnt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.ll_pcnt.ForeColor = System.Drawing.Color.Black
        Me.ll_pcnt.Location = New System.Drawing.Point(278, 4)
        Me.ll_pcnt.Name = "ll_pcnt"
        Me.ll_pcnt.Size = New System.Drawing.Size(40, 18)
        Me.ll_pcnt.Text = "100%"
        Me.ll_pcnt.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(234, 2)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(44, 20)
        Me.ProgressBar1.Value = 20
        '
        'tb_msg1
        '
        Me.tb_msg1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.tb_msg1.Location = New System.Drawing.Point(131, 3)
        Me.tb_msg1.Name = "tb_msg1"
        Me.tb_msg1.Size = New System.Drawing.Size(103, 19)
        Me.tb_msg1.Text = "[admin]"
        Me.tb_msg1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'timeStatus
        '
        Me.timeStatus.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.timeStatus.Location = New System.Drawing.Point(4, 3)
        Me.timeStatus.Name = "timeStatus"
        Me.timeStatus.Size = New System.Drawing.Size(143, 19)
        Me.timeStatus.Text = "2011-10-23 12:30:21"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(123, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 15)
        Me.Label4.Text = "货位转移"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pictureBox2
        '
        Me.pictureBox2.BackColor = System.Drawing.Color.SeaShell
        Me.pictureBox2.Image = CType(resources.GetObject("pictureBox2.Image"), System.Drawing.Image)
        Me.pictureBox2.Location = New System.Drawing.Point(123, 42)
        Me.pictureBox2.Name = "pictureBox2"
        Me.pictureBox2.Size = New System.Drawing.Size(72, 72)
        Me.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(233, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 15)
        Me.Label6.Text = "查询"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.Color.SeaShell
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
        Me.pictureBox1.Location = New System.Drawing.Point(233, 42)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(72, 72)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(233, 253)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.Tag = "15008"
        Me.Label7.Text = "退 出"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PB_Exit
        '
        Me.PB_Exit.Image = CType(resources.GetObject("PB_Exit.Image"), System.Drawing.Image)
        Me.PB_Exit.Location = New System.Drawing.Point(233, 178)
        Me.PB_Exit.Name = "PB_Exit"
        Me.PB_Exit.Size = New System.Drawing.Size(72, 72)
        Me.PB_Exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(11, 117)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(76, 15)
        Me.Label10.Text = "拣 货"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PB_Inquire
        '
        Me.PB_Inquire.BackColor = System.Drawing.Color.SeaShell
        Me.PB_Inquire.Image = CType(resources.GetObject("PB_Inquire.Image"), System.Drawing.Image)
        Me.PB_Inquire.Location = New System.Drawing.Point(13, 42)
        Me.PB_Inquire.Name = "PB_Inquire"
        Me.PB_Inquire.Size = New System.Drawing.Size(72, 72)
        Me.PB_Inquire.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'TopPanel
        '
        Me.TopPanel.BackColor = System.Drawing.Color.Blue
        Me.TopPanel.Controls.Add(Me.ll_version)
        Me.TopPanel.Controls.Add(Me.lblTitle)
        Me.TopPanel.Location = New System.Drawing.Point(0, 0)
        Me.TopPanel.Name = "TopPanel"
        Me.TopPanel.Size = New System.Drawing.Size(320, 30)
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
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(4, 5)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(198, 21)
        Me.lblTitle.Text = "CEVA拣货系统"
        '
        'p1
        '
        Me.p1.BackColor = System.Drawing.Color.SeaShell
        Me.p1.Controls.Add(Me.Button2)
        Me.p1.Controls.Add(Me.Button1)
        Me.p1.Controls.Add(Me.btn_ok)
        Me.p1.Controls.Add(Me.btn_rtn)
        Me.p1.Controls.Add(Me.Label2)
        Me.p1.Location = New System.Drawing.Point(331, 0)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(316, 300)
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.PeachPuff
        Me.Button2.Location = New System.Drawing.Point(72, 47)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(173, 43)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "DN查询"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.PeachPuff
        Me.Button1.Location = New System.Drawing.Point(72, 145)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(173, 43)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "库位查询"
        '
        'btn_ok
        '
        Me.btn_ok.BackColor = System.Drawing.Color.PeachPuff
        Me.btn_ok.Location = New System.Drawing.Point(72, 96)
        Me.btn_ok.Name = "btn_ok"
        Me.btn_ok.Size = New System.Drawing.Size(173, 43)
        Me.btn_ok.TabIndex = 10
        Me.btn_ok.Text = "物料查询"
        '
        'btn_rtn
        '
        Me.btn_rtn.BackColor = System.Drawing.Color.PeachPuff
        Me.btn_rtn.Location = New System.Drawing.Point(72, 225)
        Me.btn_rtn.Name = "btn_rtn"
        Me.btn_rtn.Size = New System.Drawing.Size(173, 43)
        Me.btn_rtn.TabIndex = 9
        Me.btn_rtn.Text = "返 回"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SeaShell
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(316, 21)
        Me.Label2.Text = "系统查询"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Timer2
        '
        Me.Timer2.Interval = 3000
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(693, 316)
        Me.ControlBox = False
        Me.Controls.Add(Me.TopPanel)
        Me.Controls.Add(Me.p0)
        Me.Controls.Add(Me.p1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.Text = "CEVA_RTN"
        Me.p0.ResumeLayout(False)
        Me.StatusPanel.ResumeLayout(False)
        Me.TopPanel.ResumeLayout(False)
        Me.p1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents p0 As System.Windows.Forms.Panel
    Private WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pictureBox2 As System.Windows.Forms.PictureBox
    Private WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PB_Exit As System.Windows.Forms.PictureBox
    Private WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents PB_Inquire As System.Windows.Forms.PictureBox
    Private WithEvents StatusPanel As System.Windows.Forms.Panel
    Private WithEvents timeStatus As System.Windows.Forms.Label
    Private WithEvents TopPanel As System.Windows.Forms.Panel
    Public WithEvents lblTitle As System.Windows.Forms.Label
    Private WithEvents tb_msg1 As System.Windows.Forms.Label
    Public WithEvents ll_version As System.Windows.Forms.Label
    Public WithEvents p1 As System.Windows.Forms.Panel
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btn_rtn As System.Windows.Forms.Button
    Friend WithEvents btn_ok As System.Windows.Forms.Button
    Private WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ll_pcnt As System.Windows.Forms.Label
    Public WithEvents Timer2 As System.Windows.Forms.Timer

End Class
