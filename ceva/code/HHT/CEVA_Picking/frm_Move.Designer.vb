<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_Move
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Move))
        Me.p0 = New System.Windows.Forms.Panel
        Me.pb_keyBoard = New System.Windows.Forms.PictureBox
        Me.btn_pick = New System.Windows.Forms.Button
        Me.btn_finish = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.tb_binid1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tb_binid = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.p0.SuspendLayout()
        Me.SuspendLayout()
        '
        'p0
        '
        Me.p0.BackColor = System.Drawing.Color.SeaShell
        Me.p0.Controls.Add(Me.pb_keyBoard)
        Me.p0.Controls.Add(Me.btn_pick)
        Me.p0.Controls.Add(Me.btn_finish)
        Me.p0.Controls.Add(Me.Label3)
        Me.p0.Controls.Add(Me.tb_binid1)
        Me.p0.Controls.Add(Me.Label1)
        Me.p0.Controls.Add(Me.tb_binid)
        Me.p0.Controls.Add(Me.Label2)
        Me.p0.Location = New System.Drawing.Point(0, 0)
        Me.p0.Name = "p0"
        Me.p0.Size = New System.Drawing.Size(320, 300)
        '
        'pb_keyBoard
        '
        Me.pb_keyBoard.Image = CType(resources.GetObject("pb_keyBoard.Image"), System.Drawing.Image)
        Me.pb_keyBoard.Location = New System.Drawing.Point(280, 0)
        Me.pb_keyBoard.Name = "pb_keyBoard"
        Me.pb_keyBoard.Size = New System.Drawing.Size(37, 25)
        Me.pb_keyBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'btn_pick
        '
        Me.btn_pick.BackColor = System.Drawing.Color.NavajoWhite
        Me.btn_pick.Location = New System.Drawing.Point(176, 183)
        Me.btn_pick.Name = "btn_pick"
        Me.btn_pick.Size = New System.Drawing.Size(98, 39)
        Me.btn_pick.TabIndex = 6
        Me.btn_pick.Tag = ""
        Me.btn_pick.Text = "返 回"
        '
        'btn_finish
        '
        Me.btn_finish.BackColor = System.Drawing.Color.NavajoWhite
        Me.btn_finish.Location = New System.Drawing.Point(35, 183)
        Me.btn_finish.Name = "btn_finish"
        Me.btn_finish.Size = New System.Drawing.Size(98, 39)
        Me.btn_finish.TabIndex = 5
        Me.btn_finish.Tag = ""
        Me.btn_finish.Text = "完 成"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(58, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 18)
        Me.Label3.Tag = ""
        Me.Label3.Text = "新货位:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tb_binid1
        '
        Me.tb_binid1.BackColor = System.Drawing.Color.White
        Me.tb_binid1.Location = New System.Drawing.Point(124, 106)
        Me.tb_binid1.Name = "tb_binid1"
        Me.tb_binid1.Size = New System.Drawing.Size(138, 23)
        Me.tb_binid1.TabIndex = 3
        Me.tb_binid1.Tag = "0"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(58, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 18)
        Me.Label1.Tag = ""
        Me.Label1.Text = "原货位:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tb_binid
        '
        Me.tb_binid.BackColor = System.Drawing.SystemColors.HighlightText
        Me.tb_binid.Location = New System.Drawing.Point(124, 77)
        Me.tb_binid.Name = "tb_binid"
        Me.tb_binid.Size = New System.Drawing.Size(138, 23)
        Me.tb_binid.TabIndex = 2
        Me.tb_binid.Tag = "0"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.MistyRose
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(4, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(270, 22)
        Me.Label2.Tag = "22904"
        Me.Label2.Text = "DN单-移货位"
        '
        'frm_Move
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(320, 300)
        Me.ControlBox = False
        Me.Controls.Add(Me.p0)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Move"
        Me.Text = "frm_Move"
        Me.p0.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents p0 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_binid1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_binid As System.Windows.Forms.TextBox
    Friend WithEvents btn_pick As System.Windows.Forms.Button
    Friend WithEvents btn_finish As System.Windows.Forms.Button
    Friend WithEvents pb_keyBoard As System.Windows.Forms.PictureBox
End Class
