<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_skuputaway
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_skuputaway))
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem
        Dim ListViewItem4 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.pb_keyBoard = New System.Windows.Forms.PictureBox
        Me.ll_mod = New System.Windows.Forms.Label
        Me.btn_module = New System.Windows.Forms.Button
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.no = New System.Windows.Forms.ColumnHeader
        Me.Sku = New System.Windows.Forms.ColumnHeader
        Me.qty = New System.Windows.Forms.ColumnHeader
        Me.Encode = New System.Windows.Forms.ColumnHeader
        Me.Label3 = New System.Windows.Forms.Label
        Me.tb_encode = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.btn_chgBinid = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.tb_binid = New System.Windows.Forms.TextBox
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.ll_sum = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pb_keyBoard)
        Me.Panel2.Controls.Add(Me.ll_mod)
        Me.Panel2.Controls.Add(Me.btn_module)
        Me.Panel2.Controls.Add(Me.ListView1)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.tb_encode)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.tb_binid)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.btn_chgBinid)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(326, 300)
        '
        'pb_keyBoard
        '
        Me.pb_keyBoard.Image = CType(resources.GetObject("pb_keyBoard.Image"), System.Drawing.Image)
        Me.pb_keyBoard.Location = New System.Drawing.Point(285, 35)
        Me.pb_keyBoard.Name = "pb_keyBoard"
        Me.pb_keyBoard.Size = New System.Drawing.Size(37, 25)
        Me.pb_keyBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'll_mod
        '
        Me.ll_mod.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.ll_mod.ForeColor = System.Drawing.Color.Black
        Me.ll_mod.Location = New System.Drawing.Point(127, 264)
        Me.ll_mod.Name = "ll_mod"
        Me.ll_mod.Size = New System.Drawing.Size(69, 25)
        Me.ll_mod.Text = "增加"
        Me.ll_mod.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btn_module
        '
        Me.btn_module.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.btn_module.Location = New System.Drawing.Point(5, 259)
        Me.btn_module.Name = "btn_module"
        Me.btn_module.Size = New System.Drawing.Size(97, 35)
        Me.btn_module.TabIndex = 162
        Me.btn_module.Text = "模 式"
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListView1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ListView1.Columns.Add(Me.no)
        Me.ListView1.Columns.Add(Me.Sku)
        Me.ListView1.Columns.Add(Me.qty)
        Me.ListView1.Columns.Add(Me.Encode)
        Me.ListView1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.ListView1.FullRowSelect = True
        ListViewItem3.Text = "1"
        ListViewItem3.SubItems.Add("DM1001,121")
        ListViewItem4.Text = "2"
        ListViewItem4.SubItems.Add("DM1003,001")
        Me.ListView1.Items.Add(ListViewItem3)
        Me.ListView1.Items.Add(ListViewItem4)
        Me.ListView1.Location = New System.Drawing.Point(3, 63)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(320, 161)
        Me.ListView1.TabIndex = 161
        Me.ListView1.TabStop = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'no
        '
        Me.no.Text = ""
        Me.no.Width = 26
        '
        'Sku
        '
        Me.Sku.Text = "SKU"
        Me.Sku.Width = 121
        '
        'qty
        '
        Me.qty.Text = "数量"
        Me.qty.Width = 62
        '
        'Encode
        '
        Me.Encode.Text = "Encode"
        Me.Encode.Width = 107
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(3, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 18)
        Me.Label3.Text = "Encode"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tb_encode
        '
        Me.tb_encode.Location = New System.Drawing.Point(100, 36)
        Me.tb_encode.MaxLength = 20
        Me.tb_encode.Name = "tb_encode"
        Me.tb_encode.Size = New System.Drawing.Size(156, 23)
        Me.tb_encode.TabIndex = 152
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.Button1.Location = New System.Drawing.Point(230, 259)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(92, 35)
        Me.Button1.TabIndex = 148
        Me.Button1.Text = "返 回"
        '
        'btn_chgBinid
        '
        Me.btn_chgBinid.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_chgBinid.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
        Me.btn_chgBinid.Location = New System.Drawing.Point(40, 160)
        Me.btn_chgBinid.Name = "btn_chgBinid"
        Me.btn_chgBinid.Size = New System.Drawing.Size(24, 35)
        Me.btn_chgBinid.TabIndex = 147
        Me.btn_chgBinid.Text = "上架完成"
        Me.btn_chgBinid.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(40, 233)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 18)
        Me.Label1.Text = "货位"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tb_binid
        '
        Me.tb_binid.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.tb_binid.Location = New System.Drawing.Point(100, 229)
        Me.tb_binid.MaxLength = 20
        Me.tb_binid.Name = "tb_binid"
        Me.tb_binid.Size = New System.Drawing.Size(135, 24)
        Me.tb_binid.TabIndex = 144
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel4.Controls.Add(Me.Button2)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.ll_sum)
        Me.Panel4.Location = New System.Drawing.Point(0, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(322, 32)
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.Button2.Location = New System.Drawing.Point(216, 1)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(104, 29)
        Me.Button2.TabIndex = 163
        Me.Button2.Text = "库位库存"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 14.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(5, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(133, 24)
        Me.Label5.Text = "SKU上架"
        '
        'll_sum
        '
        Me.ll_sum.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.ll_sum.Location = New System.Drawing.Point(144, 4)
        Me.ll_sum.Name = "ll_sum"
        Me.ll_sum.Size = New System.Drawing.Size(52, 21)
        Me.ll_sum.Text = "0"
        Me.ll_sum.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ll_sum.Visible = False
        '
        'frm_skuputaway
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(444, 309)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_skuputaway"
        Me.Text = "frm_skuPutaway"
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pb_keyBoard As System.Windows.Forms.PictureBox
    Friend WithEvents ll_mod As System.Windows.Forms.Label
    Friend WithEvents btn_module As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Public WithEvents no As System.Windows.Forms.ColumnHeader
    Friend WithEvents Sku As System.Windows.Forms.ColumnHeader
    Friend WithEvents ll_sum As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_encode As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btn_chgBinid As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tb_binid As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Encode As System.Windows.Forms.ColumnHeader
    Friend WithEvents qty As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
