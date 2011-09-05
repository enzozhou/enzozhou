<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_Alert2
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
    Private mainMenu1 As System.Windows.Forms.MainMenu

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.p1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.btn_rtn = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.ll_info = New System.Windows.Forms.Label
        Me.p1.SuspendLayout()
        Me.SuspendLayout()
        '
        'p1
        '
        Me.p1.BackColor = System.Drawing.Color.SeaShell
        Me.p1.Controls.Add(Me.ll_info)
        Me.p1.Controls.Add(Me.Label1)
        Me.p1.Controls.Add(Me.btn_rtn)
        Me.p1.Controls.Add(Me.Label2)
        Me.p1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.p1.Location = New System.Drawing.Point(0, 0)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(320, 300)
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SeaShell
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(3, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(314, 74)
        Me.Label1.Text = "电池剩余电量低于10%，请充电或者更换电池！"
        '
        'btn_rtn
        '
        Me.btn_rtn.BackColor = System.Drawing.Color.PeachPuff
        Me.btn_rtn.Location = New System.Drawing.Point(72, 225)
        Me.btn_rtn.Name = "btn_rtn"
        Me.btn_rtn.Size = New System.Drawing.Size(173, 43)
        Me.btn_rtn.TabIndex = 9
        Me.btn_rtn.Text = "确 定"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.MistyRose
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(320, 21)
        Me.Label2.Text = "系统提示"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'll_info
        '
        Me.ll_info.BackColor = System.Drawing.Color.SeaShell
        Me.ll_info.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.ll_info.ForeColor = System.Drawing.Color.Red
        Me.ll_info.Location = New System.Drawing.Point(3, 123)
        Me.ll_info.Name = "ll_info"
        Me.ll_info.Size = New System.Drawing.Size(314, 55)
        '
        'frm_Alert2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(320, 300)
        Me.ControlBox = False
        Me.Controls.Add(Me.p1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Menu = Me.mainMenu1
        Me.Name = "frm_Alert2"
        Me.Text = "frm_Alert2"
        Me.p1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents p1 As System.Windows.Forms.Panel
    Friend WithEvents btn_rtn As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ll_info As System.Windows.Forms.Label
End Class
