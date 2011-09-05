<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frm_overView
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
        Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem
        Me.p1 = New System.Windows.Forms.Panel
        Me.tb_lot = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lv01 = New System.Windows.Forms.ListView
        Me.rowheader = New System.Windows.Forms.ColumnHeader
        Me.DN0 = New System.Windows.Forms.ColumnHeader
        Me.binid = New System.Windows.Forms.ColumnHeader
        Me.btn_pick = New System.Windows.Forms.Button
        Me.lblDoc = New System.Windows.Forms.Label
        Me.ll_cnt = New System.Windows.Forms.Label
        Me.ll_cnt2 = New System.Windows.Forms.Label
        Me.p1.SuspendLayout()
        Me.SuspendLayout()
        '
        'p1
        '
        Me.p1.Controls.Add(Me.ll_cnt2)
        Me.p1.Controls.Add(Me.ll_cnt)
        Me.p1.Controls.Add(Me.tb_lot)
        Me.p1.Controls.Add(Me.Label1)
        Me.p1.Controls.Add(Me.lv01)
        Me.p1.Controls.Add(Me.btn_pick)
        Me.p1.Controls.Add(Me.lblDoc)
        Me.p1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.p1.Location = New System.Drawing.Point(0, 0)
        Me.p1.Name = "p1"
        Me.p1.Size = New System.Drawing.Size(320, 240)
        '
        'tb_lot
        '
        Me.tb_lot.BackColor = System.Drawing.SystemColors.Info
        Me.tb_lot.Location = New System.Drawing.Point(121, 32)
        Me.tb_lot.Name = "tb_lot"
        Me.tb_lot.ReadOnly = True
        Me.tb_lot.Size = New System.Drawing.Size(176, 23)
        Me.tb_lot.TabIndex = 1
        Me.tb_lot.Tag = "0"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Info
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(320, 22)
        Me.Label1.Tag = "22904"
        Me.Label1.Text = "拣货任务-库位分配预览"
        '
        'lv01
        '
        Me.lv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lv01.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lv01.Columns.Add(Me.rowheader)
        Me.lv01.Columns.Add(Me.DN0)
        Me.lv01.Columns.Add(Me.binid)
        Me.lv01.Font = New System.Drawing.Font("Tahoma", 11.0!, System.Drawing.FontStyle.Regular)
        Me.lv01.FullRowSelect = True
        ListViewItem1.Text = "1"
        ListViewItem1.SubItems.Add("A")
        ListViewItem1.SubItems.Add("120")
        Me.lv01.Items.Add(ListViewItem1)
        Me.lv01.Location = New System.Drawing.Point(3, 61)
        Me.lv01.Name = "lv01"
        Me.lv01.Size = New System.Drawing.Size(313, 135)
        Me.lv01.TabIndex = 138
        Me.lv01.View = System.Windows.Forms.View.Details
        '
        'rowheader
        '
        Me.rowheader.Text = "No"
        Me.rowheader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.rowheader.Width = 39
        '
        'DN0
        '
        Me.DN0.Text = "库区"
        Me.DN0.Width = 119
        '
        'binid
        '
        Me.binid.Text = "库位数"
        Me.binid.Width = 107
        '
        'btn_pick
        '
        Me.btn_pick.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn_pick.BackColor = System.Drawing.Color.Silver
        Me.btn_pick.Location = New System.Drawing.Point(226, 199)
        Me.btn_pick.Name = "btn_pick"
        Me.btn_pick.Size = New System.Drawing.Size(89, 36)
        Me.btn_pick.TabIndex = 3
        Me.btn_pick.Tag = ""
        Me.btn_pick.Text = "确 定"
        '
        'lblDoc
        '
        Me.lblDoc.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDoc.Location = New System.Drawing.Point(15, 32)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(100, 19)
        Me.lblDoc.Tag = ""
        Me.lblDoc.Text = "CEVA批号 :"
        Me.lblDoc.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'll_cnt
        '
        Me.ll_cnt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ll_cnt.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ll_cnt.Location = New System.Drawing.Point(5, 197)
        Me.ll_cnt.Name = "ll_cnt"
        Me.ll_cnt.Size = New System.Drawing.Size(218, 21)
        Me.ll_cnt.Tag = ""
        Me.ll_cnt.Text = "合计:库位数=120"
        '
        'll_cnt2
        '
        Me.ll_cnt2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ll_cnt2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ll_cnt2.Location = New System.Drawing.Point(3, 217)
        Me.ll_cnt2.Name = "ll_cnt2"
        Me.ll_cnt2.Size = New System.Drawing.Size(218, 21)
        Me.ll_cnt2.Tag = ""
        Me.ll_cnt2.Text = "件数=200"
        '
        'frm_overView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(320, 240)
        Me.ControlBox = False
        Me.Controls.Add(Me.p1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frm_overView"
        Me.Text = "frm_overView"
        Me.p1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents p1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lv01 As System.Windows.Forms.ListView
    Public WithEvents rowheader As System.Windows.Forms.ColumnHeader
    Friend WithEvents DN0 As System.Windows.Forms.ColumnHeader
    Friend WithEvents binid As System.Windows.Forms.ColumnHeader
    Friend WithEvents btn_pick As System.Windows.Forms.Button
    Friend WithEvents tb_lot As System.Windows.Forms.TextBox
    Friend WithEvents lblDoc As System.Windows.Forms.Label
    Friend WithEvents ll_cnt As System.Windows.Forms.Label
    Friend WithEvents ll_cnt2 As System.Windows.Forms.Label
End Class
