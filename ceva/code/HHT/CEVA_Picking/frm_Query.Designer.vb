<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_Query
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Query))
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem
        Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem
        Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem
        Me.p1 = New System.Windows.Forms.Panel
        Me.pb_keyBoard = New System.Windows.Forms.PictureBox
        Me.tb_dn = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lv01 = New System.Windows.Forms.ListView
        Me.rowheader = New System.Windows.Forms.ColumnHeader
        Me.DN0 = New System.Windows.Forms.ColumnHeader
        Me.binid = New System.Windows.Forms.ColumnHeader
        Me.sku_no1 = New System.Windows.Forms.ColumnHeader
        Me.qty0 = New System.Windows.Forms.ColumnHeader
        Me.btn_pick = New System.Windows.Forms.Button
        Me.lblDoc = New System.Windows.Forms.Label
        Me.btn_rtn0 = New System.Windows.Forms.Button
        Me.p2 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lv02 = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.tb_sku = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.p3 = New System.Windows.Forms.Panel
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.lv03 = New System.Windows.Forms.ListView
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.tb_bin = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.p1.SuspendLayout()
        Me.p2.SuspendLayout()
        Me.p3.SuspendLayout()
        Me.SuspendLayout()
        '
        'p1
        '
        Me.p1.BackColor = System.Drawing.Color.SeaShell
        Me.p1.Controls.Add(Me.pb_keyBoard)
        Me.p1.Controls.Add(Me.tb_dn)
        Me.p1.Controls.Add(Me.Label1)
        Me.p1.Controls.Add(Me.lv01)
        Me.p1.Controls.Add(Me.btn_pick)
        Me.p1.Controls.Add(Me.lblDoc)
        Me.p1.Controls.Add(Me.btn_rtn0)
        Me.p1.Location = New System.Drawing.Point(0, 0)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(320, 300)
        '
        'pb_keyBoard
        '
        Me.pb_keyBoard.Image = CType(resources.GetObject("pb_keyBoard.Image"), System.Drawing.Image)
        Me.pb_keyBoard.Location = New System.Drawing.Point(263, 232)
        Me.pb_keyBoard.Name = "pb_keyBoard"
        Me.pb_keyBoard.Size = New System.Drawing.Size(37, 25)
        Me.pb_keyBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'tb_dn
        '
        Me.tb_dn.Location = New System.Drawing.Point(118, 233)
        Me.tb_dn.Name = "tb_dn"
        Me.tb_dn.Size = New System.Drawing.Size(139, 23)
        Me.tb_dn.TabIndex = 1
        Me.tb_dn.Tag = "0"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.MistyRose
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(4, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(221, 22)
        Me.Label1.Tag = "22904"
        Me.Label1.Text = "DN查询"
        '
        'lv01
        '
        Me.lv01.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lv01.Columns.Add(Me.rowheader)
        Me.lv01.Columns.Add(Me.DN0)
        Me.lv01.Columns.Add(Me.binid)
        Me.lv01.Columns.Add(Me.sku_no1)
        Me.lv01.Columns.Add(Me.qty0)
        Me.lv01.FullRowSelect = True
        ListViewItem1.Text = "1"
        ListViewItem1.SubItems.Add("9001")
        ListViewItem1.SubItems.Add("10A-01")
        ListViewItem1.SubItems.Add("200")
        ListViewItem1.SubItems.Add("20/120")
        Me.lv01.Items.Add(ListViewItem1)
        Me.lv01.Location = New System.Drawing.Point(3, 27)
        Me.lv01.Name = "lv01"
        Me.lv01.Size = New System.Drawing.Size(313, 202)
        Me.lv01.TabIndex = 138
        Me.lv01.View = System.Windows.Forms.View.Details
        '
        'rowheader
        '
        Me.rowheader.Text = "No"
        Me.rowheader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.rowheader.Width = 27
        '
        'DN0
        '
        Me.DN0.Text = "DN单号"
        Me.DN0.Width = 84
        '
        'binid
        '
        Me.binid.Text = "库位"
        Me.binid.Width = 68
        '
        'sku_no1
        '
        Me.sku_no1.Text = "SKU"
        Me.sku_no1.Width = 68
        '
        'qty0
        '
        Me.qty0.Text = "数量"
        Me.qty0.Width = 60
        '
        'btn_pick
        '
        Me.btn_pick.BackColor = System.Drawing.Color.NavajoWhite
        Me.btn_pick.Location = New System.Drawing.Point(3, 262)
        Me.btn_pick.Name = "btn_pick"
        Me.btn_pick.Size = New System.Drawing.Size(87, 34)
        Me.btn_pick.TabIndex = 3
        Me.btn_pick.Tag = ""
        Me.btn_pick.Text = "确 定"
        '
        'lblDoc
        '
        Me.lblDoc.Location = New System.Drawing.Point(12, 235)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(100, 19)
        Me.lblDoc.Tag = ""
        Me.lblDoc.Text = "DN单:"
        Me.lblDoc.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btn_rtn0
        '
        Me.btn_rtn0.BackColor = System.Drawing.Color.NavajoWhite
        Me.btn_rtn0.Location = New System.Drawing.Point(230, 262)
        Me.btn_rtn0.Name = "btn_rtn0"
        Me.btn_rtn0.Size = New System.Drawing.Size(86, 34)
        Me.btn_rtn0.TabIndex = 5
        Me.btn_rtn0.Tag = ""
        Me.btn_rtn0.Text = "返 回"
        '
        'p2
        '
        Me.p2.BackColor = System.Drawing.Color.SeaShell
        Me.p2.Controls.Add(Me.PictureBox1)
        Me.p2.Controls.Add(Me.lv02)
        Me.p2.Controls.Add(Me.tb_sku)
        Me.p2.Controls.Add(Me.Label2)
        Me.p2.Controls.Add(Me.Button1)
        Me.p2.Controls.Add(Me.Label3)
        Me.p2.Controls.Add(Me.Button2)
        Me.p2.Location = New System.Drawing.Point(329, 0)
        Me.p2.Name = "p2"
        Me.p2.Size = New System.Drawing.Size(320, 300)
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(263, 233)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 25)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'lv02
        '
        Me.lv02.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lv02.Columns.Add(Me.ColumnHeader1)
        Me.lv02.Columns.Add(Me.ColumnHeader2)
        Me.lv02.Columns.Add(Me.ColumnHeader3)
        Me.lv02.Columns.Add(Me.ColumnHeader4)
        Me.lv02.Columns.Add(Me.ColumnHeader9)
        Me.lv02.FullRowSelect = True
        ListViewItem2.Text = "1"
        ListViewItem2.SubItems.Add("9001")
        ListViewItem2.SubItems.Add("10A-01")
        ListViewItem2.SubItems.Add("200")
        ListViewItem2.SubItems.Add("120")
        Me.lv02.Items.Add(ListViewItem2)
        Me.lv02.Location = New System.Drawing.Point(4, 27)
        Me.lv02.Name = "lv02"
        Me.lv02.Size = New System.Drawing.Size(313, 202)
        Me.lv02.TabIndex = 140
        Me.lv02.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "No"
        Me.ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader1.Width = 27
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "DN单号"
        Me.ColumnHeader2.Width = 87
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "库位"
        Me.ColumnHeader3.Width = 63
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "SKU"
        Me.ColumnHeader4.Width = 81
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "数量"
        Me.ColumnHeader9.Width = 43
        '
        'tb_sku
        '
        Me.tb_sku.Location = New System.Drawing.Point(118, 233)
        Me.tb_sku.Name = "tb_sku"
        Me.tb_sku.Size = New System.Drawing.Size(139, 23)
        Me.tb_sku.TabIndex = 1
        Me.tb_sku.Tag = "0"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.MistyRose
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(4, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(221, 22)
        Me.Label2.Tag = "22904"
        Me.Label2.Text = "SKU查询"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.NavajoWhite
        Me.Button1.Location = New System.Drawing.Point(3, 262)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(87, 34)
        Me.Button1.TabIndex = 3
        Me.Button1.Tag = ""
        Me.Button1.Text = "确 定"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 235)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 19)
        Me.Label3.Tag = ""
        Me.Label3.Text = "Sku:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.NavajoWhite
        Me.Button2.Location = New System.Drawing.Point(230, 262)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 34)
        Me.Button2.TabIndex = 5
        Me.Button2.Tag = ""
        Me.Button2.Text = "返 回"
        '
        'p3
        '
        Me.p3.BackColor = System.Drawing.Color.SeaShell
        Me.p3.Controls.Add(Me.PictureBox2)
        Me.p3.Controls.Add(Me.lv03)
        Me.p3.Controls.Add(Me.tb_bin)
        Me.p3.Controls.Add(Me.Label4)
        Me.p3.Controls.Add(Me.Button3)
        Me.p3.Controls.Add(Me.Label5)
        Me.p3.Controls.Add(Me.Button4)
        Me.p3.Location = New System.Drawing.Point(658, 0)
        Me.p3.Name = "p3"
        Me.p3.Size = New System.Drawing.Size(320, 300)
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(263, 231)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(37, 25)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'lv03
        '
        Me.lv03.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lv03.Columns.Add(Me.ColumnHeader5)
        Me.lv03.Columns.Add(Me.ColumnHeader6)
        Me.lv03.Columns.Add(Me.ColumnHeader7)
        Me.lv03.Columns.Add(Me.ColumnHeader8)
        Me.lv03.Columns.Add(Me.ColumnHeader10)
        Me.lv03.FullRowSelect = True
        ListViewItem3.Text = "1"
        ListViewItem3.SubItems.Add("9001")
        ListViewItem3.SubItems.Add("10A-01")
        ListViewItem3.SubItems.Add("200")
        ListViewItem3.SubItems.Add("120")
        Me.lv03.Items.Add(ListViewItem3)
        Me.lv03.Location = New System.Drawing.Point(3, 27)
        Me.lv03.Name = "lv03"
        Me.lv03.Size = New System.Drawing.Size(313, 202)
        Me.lv03.TabIndex = 140
        Me.lv03.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "No"
        Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader5.Width = 27
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "DN单号"
        Me.ColumnHeader6.Width = 91
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "库位"
        Me.ColumnHeader7.Width = 68
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "SKU"
        Me.ColumnHeader8.Width = 74
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "数量"
        Me.ColumnHeader10.Width = 44
        '
        'tb_bin
        '
        Me.tb_bin.Location = New System.Drawing.Point(118, 233)
        Me.tb_bin.Name = "tb_bin"
        Me.tb_bin.Size = New System.Drawing.Size(139, 23)
        Me.tb_bin.TabIndex = 1
        Me.tb_bin.Tag = "0"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.MistyRose
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(4, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(221, 22)
        Me.Label4.Tag = "22904"
        Me.Label4.Text = "库位查询"
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.NavajoWhite
        Me.Button3.Location = New System.Drawing.Point(3, 262)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(87, 34)
        Me.Button3.TabIndex = 3
        Me.Button3.Tag = ""
        Me.Button3.Text = "确 定"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(12, 235)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 19)
        Me.Label5.Tag = ""
        Me.Label5.Text = "Bin:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.NavajoWhite
        Me.Button4.Location = New System.Drawing.Point(230, 262)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(86, 34)
        Me.Button4.TabIndex = 5
        Me.Button4.Tag = ""
        Me.Button4.Text = "返 回"
        '
        'frm_Query
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1036, 312)
        Me.ControlBox = False
        Me.Controls.Add(Me.p3)
        Me.Controls.Add(Me.p2)
        Me.Controls.Add(Me.p1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_Query"
        Me.Text = "frm_Query"
        Me.p1.ResumeLayout(False)
        Me.p2.ResumeLayout(False)
        Me.p3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents p1 As System.Windows.Forms.Panel
    Friend WithEvents tb_dn As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lv01 As System.Windows.Forms.ListView
    Public WithEvents rowheader As System.Windows.Forms.ColumnHeader
    Friend WithEvents binid As System.Windows.Forms.ColumnHeader
    Friend WithEvents sku_no1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents DN0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_pick As System.Windows.Forms.Button
    Friend WithEvents lblDoc As System.Windows.Forms.Label
    Friend WithEvents btn_rtn0 As System.Windows.Forms.Button
    Friend WithEvents p2 As System.Windows.Forms.Panel
    Friend WithEvents tb_sku As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents p3 As System.Windows.Forms.Panel
    Friend WithEvents tb_bin As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents lv02 As System.Windows.Forms.ListView
    Public WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lv03 As System.Windows.Forms.ListView
    Public WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents qty0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents pb_keyBoard As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
