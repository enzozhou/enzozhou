<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_Picklist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Picklist))
        Dim ListViewItem7 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem
        Dim ListViewItem8 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem
        Me.p0 = New System.Windows.Forms.Panel
        Me.pb_keyBoard = New System.Windows.Forms.PictureBox
        Me.lv_tasklist = New System.Windows.Forms.ListView
        Me.rowheader = New System.Windows.Forms.ColumnHeader
        Me.SKU0 = New System.Windows.Forms.ColumnHeader
        Me.binid0 = New System.Windows.Forms.ColumnHeader
        Me.qty0 = New System.Windows.Forms.ColumnHeader
        Me.rqty0 = New System.Windows.Forms.ColumnHeader
        Me.DN0 = New System.Windows.Forms.ColumnHeader
        Me.task_id = New System.Windows.Forms.ColumnHeader
        Me.bch_no = New System.Windows.Forms.ColumnHeader
        Me.tb_sku0 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.tb_binid0 = New System.Windows.Forms.TextBox
        Me.btn_pick = New System.Windows.Forms.Button
        Me.btn_refresh0 = New System.Windows.Forms.Button
        Me.tb_task_id = New System.Windows.Forms.TextBox
        Me.tb_dn0 = New System.Windows.Forms.TextBox
        Me.btn_rtn0 = New System.Windows.Forms.Button
        Me.tb_lot0 = New System.Windows.Forms.TextBox
        Me.lblDoc = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.p1 = New System.Windows.Forms.Panel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ll_qtySum = New System.Windows.Forms.Label
        Me.lv_scan = New System.Windows.Forms.ListView
        Me.no02 = New System.Windows.Forms.ColumnHeader
        Me.skuo2 = New System.Windows.Forms.ColumnHeader
        Me.sno02 = New System.Windows.Forms.ColumnHeader
        Me.rowid = New System.Windows.Forms.ColumnHeader
        Me.tb_binOK = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.tb_name2 = New System.Windows.Forms.TextBox
        Me.tb_sno = New System.Windows.Forms.TextBox
        Me.ll_title = New System.Windows.Forms.Label
        Me.btn_rtn = New System.Windows.Forms.Button
        Me.tb_sku2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.tb_binid2 = New System.Windows.Forms.TextBox
        Me.tb_sku3 = New System.Windows.Forms.TextBox
        Me.label14 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ll_info = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.p0.SuspendLayout()
        Me.p1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'p0
        '
        Me.p0.BackColor = System.Drawing.Color.SeaShell
        Me.p0.Controls.Add(Me.pb_keyBoard)
        Me.p0.Controls.Add(Me.lv_tasklist)
        Me.p0.Controls.Add(Me.tb_sku0)
        Me.p0.Controls.Add(Me.Label11)
        Me.p0.Controls.Add(Me.tb_binid0)
        Me.p0.Controls.Add(Me.btn_pick)
        Me.p0.Controls.Add(Me.btn_refresh0)
        Me.p0.Controls.Add(Me.tb_task_id)
        Me.p0.Controls.Add(Me.tb_dn0)
        Me.p0.Controls.Add(Me.btn_rtn0)
        Me.p0.Controls.Add(Me.tb_lot0)
        Me.p0.Controls.Add(Me.lblDoc)
        Me.p0.Controls.Add(Me.Label2)
        Me.p0.Location = New System.Drawing.Point(0, 0)
        Me.p0.Name = "p0"
        Me.p0.Size = New System.Drawing.Size(320, 300)
        '
        'pb_keyBoard
        '
        Me.pb_keyBoard.Image = CType(resources.GetObject("pb_keyBoard.Image"), System.Drawing.Image)
        Me.pb_keyBoard.Location = New System.Drawing.Point(182, 0)
        Me.pb_keyBoard.Name = "pb_keyBoard"
        Me.pb_keyBoard.Size = New System.Drawing.Size(37, 25)
        Me.pb_keyBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'lv_tasklist
        '
        Me.lv_tasklist.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lv_tasklist.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lv_tasklist.Columns.Add(Me.rowheader)
        Me.lv_tasklist.Columns.Add(Me.SKU0)
        Me.lv_tasklist.Columns.Add(Me.binid0)
        Me.lv_tasklist.Columns.Add(Me.qty0)
        Me.lv_tasklist.Columns.Add(Me.rqty0)
        Me.lv_tasklist.Columns.Add(Me.DN0)
        Me.lv_tasklist.Columns.Add(Me.task_id)
        Me.lv_tasklist.Columns.Add(Me.bch_no)
        Me.lv_tasklist.FullRowSelect = True
        ListViewItem7.Text = ""
        ListViewItem7.SubItems.Add("")
        ListViewItem7.SubItems.Add("")
        ListViewItem7.SubItems.Add("")
        ListViewItem7.SubItems.Add("")
        ListViewItem7.SubItems.Add("")
        Me.lv_tasklist.Items.Add(ListViewItem7)
        Me.lv_tasklist.Location = New System.Drawing.Point(3, 59)
        Me.lv_tasklist.Name = "lv_tasklist"
        Me.lv_tasklist.Size = New System.Drawing.Size(314, 169)
        Me.lv_tasklist.TabIndex = 147
        Me.lv_tasklist.View = System.Windows.Forms.View.Details
        '
        'rowheader
        '
        Me.rowheader.Text = "No"
        Me.rowheader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.rowheader.Width = 27
        '
        'SKU0
        '
        Me.SKU0.Text = "SKU"
        Me.SKU0.Width = 86
        '
        'binid0
        '
        Me.binid0.Text = "库位"
        Me.binid0.Width = 82
        '
        'qty0
        '
        Me.qty0.Text = "数量"
        Me.qty0.Width = 43
        '
        'rqty0
        '
        Me.rqty0.Text = "拣货数"
        Me.rqty0.Width = 57
        '
        'DN0
        '
        Me.DN0.Text = "DN单号"
        Me.DN0.Width = 64
        '
        'task_id
        '
        Me.task_id.Text = "任务单号"
        Me.task_id.Width = 0
        '
        'bch_no
        '
        Me.bch_no.Text = "批次号"
        Me.bch_no.Width = 60
        '
        'tb_sku0
        '
        Me.tb_sku0.Location = New System.Drawing.Point(80, 33)
        Me.tb_sku0.Name = "tb_sku0"
        Me.tb_sku0.Size = New System.Drawing.Size(139, 23)
        Me.tb_sku0.TabIndex = 1
        Me.tb_sku0.Tag = "0"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(12, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 20)
        Me.Label11.Tag = ""
        Me.Label11.Text = "SKU:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tb_binid0
        '
        Me.tb_binid0.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tb_binid0.BackColor = System.Drawing.SystemColors.Info
        Me.tb_binid0.Location = New System.Drawing.Point(80, 233)
        Me.tb_binid0.Name = "tb_binid0"
        Me.tb_binid0.ReadOnly = True
        Me.tb_binid0.Size = New System.Drawing.Size(139, 23)
        Me.tb_binid0.TabIndex = 151
        Me.tb_binid0.Tag = "0"
        '
        'btn_pick
        '
        Me.btn_pick.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_pick.BackColor = System.Drawing.Color.NavajoWhite
        Me.btn_pick.Location = New System.Drawing.Point(12, 260)
        Me.btn_pick.Name = "btn_pick"
        Me.btn_pick.Size = New System.Drawing.Size(87, 34)
        Me.btn_pick.TabIndex = 153
        Me.btn_pick.Tag = ""
        Me.btn_pick.Text = "拣货扫描"
        '
        'btn_refresh0
        '
        Me.btn_refresh0.BackColor = System.Drawing.Color.NavajoWhite
        Me.btn_refresh0.Location = New System.Drawing.Point(225, 22)
        Me.btn_refresh0.Name = "btn_refresh0"
        Me.btn_refresh0.Size = New System.Drawing.Size(86, 34)
        Me.btn_refresh0.TabIndex = 152
        Me.btn_refresh0.Tag = ""
        Me.btn_refresh0.Text = "刷 新"
        '
        'tb_task_id
        '
        Me.tb_task_id.Location = New System.Drawing.Point(12, 180)
        Me.tb_task_id.Name = "tb_task_id"
        Me.tb_task_id.ReadOnly = True
        Me.tb_task_id.Size = New System.Drawing.Size(139, 23)
        Me.tb_task_id.TabIndex = 149
        Me.tb_task_id.Tag = "0"
        Me.tb_task_id.Text = "tb_task_id"
        Me.tb_task_id.Visible = False
        '
        'tb_dn0
        '
        Me.tb_dn0.Location = New System.Drawing.Point(12, 126)
        Me.tb_dn0.Name = "tb_dn0"
        Me.tb_dn0.ReadOnly = True
        Me.tb_dn0.Size = New System.Drawing.Size(139, 23)
        Me.tb_dn0.TabIndex = 148
        Me.tb_dn0.Tag = "0"
        Me.tb_dn0.Text = "tb_dn0"
        Me.tb_dn0.Visible = False
        '
        'btn_rtn0
        '
        Me.btn_rtn0.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_rtn0.BackColor = System.Drawing.Color.NavajoWhite
        Me.btn_rtn0.Location = New System.Drawing.Point(225, 260)
        Me.btn_rtn0.Name = "btn_rtn0"
        Me.btn_rtn0.Size = New System.Drawing.Size(86, 34)
        Me.btn_rtn0.TabIndex = 155
        Me.btn_rtn0.Tag = ""
        Me.btn_rtn0.Text = "返回"
        '
        'tb_lot0
        '
        Me.tb_lot0.Location = New System.Drawing.Point(12, 153)
        Me.tb_lot0.Name = "tb_lot0"
        Me.tb_lot0.ReadOnly = True
        Me.tb_lot0.Size = New System.Drawing.Size(139, 23)
        Me.tb_lot0.TabIndex = 146
        Me.tb_lot0.Tag = "0"
        Me.tb_lot0.Text = "CEVA20110411123023"
        Me.tb_lot0.Visible = False
        '
        'lblDoc
        '
        Me.lblDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDoc.Location = New System.Drawing.Point(12, 236)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(64, 20)
        Me.lblDoc.Tag = ""
        Me.lblDoc.Text = "库位:"
        Me.lblDoc.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SeaShell
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(4, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 22)
        Me.Label2.Tag = "22904"
        Me.Label2.Text = "SKU列表:"
        '
        'p1
        '
        Me.p1.BackColor = System.Drawing.Color.SeaShell
        Me.p1.Controls.Add(Me.PictureBox1)
        Me.p1.Controls.Add(Me.Button2)
        Me.p1.Controls.Add(Me.Button1)
        Me.p1.Controls.Add(Me.Panel1)
        Me.p1.Controls.Add(Me.tb_binOK)
        Me.p1.Controls.Add(Me.Label15)
        Me.p1.Controls.Add(Me.tb_name2)
        Me.p1.Controls.Add(Me.tb_sno)
        Me.p1.Controls.Add(Me.ll_title)
        Me.p1.Controls.Add(Me.btn_rtn)
        Me.p1.Controls.Add(Me.tb_sku2)
        Me.p1.Controls.Add(Me.Label1)
        Me.p1.Controls.Add(Me.tb_binid2)
        Me.p1.Controls.Add(Me.tb_sku3)
        Me.p1.Controls.Add(Me.label14)
        Me.p1.Controls.Add(Me.Label3)
        Me.p1.Controls.Add(Me.ll_info)
        Me.p1.Location = New System.Drawing.Point(325, 0)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(320, 300)
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(188, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 25)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.NavajoWhite
        Me.Button2.Location = New System.Drawing.Point(231, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(86, 30)
        Me.Button2.TabIndex = 161
        Me.Button2.Tag = ""
        Me.Button2.Text = "刷 新"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.NavajoWhite
        Me.Button1.Location = New System.Drawing.Point(230, 83)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 32)
        Me.Button1.TabIndex = 153
        Me.Button1.Tag = ""
        Me.Button1.Text = "删 除"
        Me.Button1.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ll_qtySum)
        Me.Panel1.Controls.Add(Me.lv_scan)
        Me.Panel1.Location = New System.Drawing.Point(0, 116)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(319, 143)
        '
        'll_qtySum
        '
        Me.ll_qtySum.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.ll_qtySum.Location = New System.Drawing.Point(194, 117)
        Me.ll_qtySum.Name = "ll_qtySum"
        Me.ll_qtySum.Size = New System.Drawing.Size(78, 20)
        Me.ll_qtySum.Tag = ""
        Me.ll_qtySum.Text = "/"
        Me.ll_qtySum.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lv_scan
        '
        Me.lv_scan.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lv_scan.Columns.Add(Me.no02)
        Me.lv_scan.Columns.Add(Me.skuo2)
        Me.lv_scan.Columns.Add(Me.sno02)
        Me.lv_scan.Columns.Add(Me.rowid)
        Me.lv_scan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv_scan.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.lv_scan.FullRowSelect = True
        ListViewItem8.Text = "1"
        ListViewItem8.SubItems.Add("")
        ListViewItem8.SubItems.Add("")
        Me.lv_scan.Items.Add(ListViewItem8)
        Me.lv_scan.Location = New System.Drawing.Point(0, 0)
        Me.lv_scan.Name = "lv_scan"
        Me.lv_scan.Size = New System.Drawing.Size(319, 143)
        Me.lv_scan.TabIndex = 140
        Me.lv_scan.View = System.Windows.Forms.View.Details
        '
        'no02
        '
        Me.no02.Text = "No"
        Me.no02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.no02.Width = 37
        '
        'skuo2
        '
        Me.skuo2.Text = "SKU"
        Me.skuo2.Width = 120
        '
        'sno02
        '
        Me.sno02.Text = "数量"
        Me.sno02.Width = 130
        '
        'rowid
        '
        Me.rowid.Text = ""
        Me.rowid.Width = 0
        '
        'tb_binOK
        '
        Me.tb_binOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tb_binOK.BackColor = System.Drawing.SystemColors.HighlightText
        Me.tb_binOK.Location = New System.Drawing.Point(83, 271)
        Me.tb_binOK.Name = "tb_binOK"
        Me.tb_binOK.Size = New System.Drawing.Size(93, 23)
        Me.tb_binOK.TabIndex = 23
        Me.tb_binOK.Tag = "0"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.Location = New System.Drawing.Point(6, 273)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(73, 18)
        Me.Label15.Tag = ""
        Me.Label15.Text = "确认库位:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tb_name2
        '
        Me.tb_name2.BackColor = System.Drawing.SystemColors.Info
        Me.tb_name2.ForeColor = System.Drawing.Color.Red
        Me.tb_name2.Location = New System.Drawing.Point(178, 58)
        Me.tb_name2.Name = "tb_name2"
        Me.tb_name2.Size = New System.Drawing.Size(138, 23)
        Me.tb_name2.TabIndex = 0
        Me.tb_name2.Tag = "0"
        '
        'tb_sno
        '
        Me.tb_sno.Location = New System.Drawing.Point(70, 88)
        Me.tb_sno.Name = "tb_sno"
        Me.tb_sno.Size = New System.Drawing.Size(155, 23)
        Me.tb_sno.TabIndex = 21
        Me.tb_sno.Tag = "0"
        Me.tb_sno.Visible = False
        '
        'll_title
        '
        Me.ll_title.Location = New System.Drawing.Point(3, 90)
        Me.ll_title.Name = "ll_title"
        Me.ll_title.Size = New System.Drawing.Size(66, 18)
        Me.ll_title.Tag = ""
        Me.ll_title.Text = "机身号:"
        Me.ll_title.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.ll_title.Visible = False
        '
        'btn_rtn
        '
        Me.btn_rtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_rtn.BackColor = System.Drawing.Color.NavajoWhite
        Me.btn_rtn.Location = New System.Drawing.Point(231, 262)
        Me.btn_rtn.Name = "btn_rtn"
        Me.btn_rtn.Size = New System.Drawing.Size(86, 34)
        Me.btn_rtn.TabIndex = 26
        Me.btn_rtn.Tag = ""
        Me.btn_rtn.Text = "返 回"
        '
        'tb_sku2
        '
        Me.tb_sku2.Location = New System.Drawing.Point(70, 58)
        Me.tb_sku2.Name = "tb_sku2"
        Me.tb_sku2.Size = New System.Drawing.Size(106, 23)
        Me.tb_sku2.TabIndex = 20
        Me.tb_sku2.Tag = "0"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 18)
        Me.Label1.Tag = ""
        Me.Label1.Text = "SKU:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tb_binid2
        '
        Me.tb_binid2.BackColor = System.Drawing.SystemColors.Info
        Me.tb_binid2.ForeColor = System.Drawing.Color.Red
        Me.tb_binid2.Location = New System.Drawing.Point(70, 33)
        Me.tb_binid2.Name = "tb_binid2"
        Me.tb_binid2.Size = New System.Drawing.Size(106, 23)
        Me.tb_binid2.TabIndex = 0
        Me.tb_binid2.Tag = "0"
        '
        'tb_sku3
        '
        Me.tb_sku3.BackColor = System.Drawing.SystemColors.Info
        Me.tb_sku3.Enabled = False
        Me.tb_sku3.ForeColor = System.Drawing.Color.Red
        Me.tb_sku3.Location = New System.Drawing.Point(178, 33)
        Me.tb_sku3.Name = "tb_sku3"
        Me.tb_sku3.Size = New System.Drawing.Size(138, 23)
        Me.tb_sku3.TabIndex = 0
        Me.tb_sku3.Tag = ""
        '
        'label14
        '
        Me.label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.label14.Location = New System.Drawing.Point(3, 35)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(66, 18)
        Me.label14.Tag = ""
        Me.label14.Text = "库位/SKU:"
        Me.label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SeaShell
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(4, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(221, 25)
        Me.Label3.Tag = ""
        Me.Label3.Text = "货位物品扫描:"
        '
        'll_info
        '
        Me.ll_info.BackColor = System.Drawing.Color.SeaShell
        Me.ll_info.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ll_info.Location = New System.Drawing.Point(152, 4)
        Me.ll_info.Name = "ll_info"
        Me.ll_info.Size = New System.Drawing.Size(73, 20)
        Me.ll_info.Tag = ""
        Me.ll_info.Text = "15/2000"
        Me.ll_info.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.NavajoWhite
        Me.Button3.Location = New System.Drawing.Point(5, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(86, 34)
        Me.Button3.TabIndex = 27
        Me.Button3.Tag = ""
        Me.Button3.Text = "返 回"
        '
        'frm_Picklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(681, 316)
        Me.ControlBox = False
        Me.Controls.Add(Me.p1)
        Me.Controls.Add(Me.p0)
        Me.Controls.Add(Me.Button3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_Picklist"
        Me.Text = "frm_Picklist"
        Me.p0.ResumeLayout(False)
        Me.p1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents p0 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents p1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tb_binid2 As System.Windows.Forms.TextBox
    Friend WithEvents tb_sku3 As System.Windows.Forms.TextBox
    Friend WithEvents label14 As System.Windows.Forms.Label
    Friend WithEvents tb_sku2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btn_rtn As System.Windows.Forms.Button
    Friend WithEvents tb_sno As System.Windows.Forms.TextBox
    Friend WithEvents ll_title As System.Windows.Forms.Label
    Friend WithEvents tb_name2 As System.Windows.Forms.TextBox
    Friend WithEvents ll_info As System.Windows.Forms.Label
    Friend WithEvents tb_binid0 As System.Windows.Forms.TextBox
    Friend WithEvents btn_pick As System.Windows.Forms.Button
    Friend WithEvents btn_refresh0 As System.Windows.Forms.Button
    Friend WithEvents btn_rtn0 As System.Windows.Forms.Button
    Friend WithEvents lblDoc As System.Windows.Forms.Label
    Friend WithEvents lv_tasklist As System.Windows.Forms.ListView
    Public WithEvents rowheader As System.Windows.Forms.ColumnHeader
    Friend WithEvents SKU0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents binid0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents qty0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents rqty0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents DN0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents task_id As System.Windows.Forms.ColumnHeader
    Friend WithEvents tb_task_id As System.Windows.Forms.TextBox
    Friend WithEvents tb_lot0 As System.Windows.Forms.TextBox
    Friend WithEvents tb_dn0 As System.Windows.Forms.TextBox
    Friend WithEvents tb_sku0 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tb_binOK As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lv_scan As System.Windows.Forms.ListView
    Public WithEvents no02 As System.Windows.Forms.ColumnHeader
    Friend WithEvents skuo2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents sno02 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ll_qtySum As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents rowid As System.Windows.Forms.ColumnHeader
    Friend WithEvents bch_no As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents pb_keyBoard As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
