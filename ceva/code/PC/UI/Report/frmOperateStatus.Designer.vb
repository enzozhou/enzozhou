<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOperateStatus
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnExport = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSonyBCH = New System.Windows.Forms.TextBox
        Me.txtCEVABCH = New System.Windows.Forms.TextBox
        Me.btn_search = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCityTo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbStatus = New System.Windows.Forms.ComboBox
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.opt_dtime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dn_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sony_bch_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bch_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.city_to = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bin_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.status_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtBin = New System.Windows.Forms.TextBox
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(695, 34)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 25)
        Me.btnExport.TabIndex = 13
        Me.btnExport.Text = "导出"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Sony批次号"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "CEVA批次号"
        '
        'txtSonyBCH
        '
        Me.txtSonyBCH.Location = New System.Drawing.Point(83, 38)
        Me.txtSonyBCH.MaxLength = 20
        Me.txtSonyBCH.Name = "txtSonyBCH"
        Me.txtSonyBCH.Size = New System.Drawing.Size(152, 21)
        Me.txtSonyBCH.TabIndex = 10
        '
        'txtCEVABCH
        '
        Me.txtCEVABCH.Location = New System.Drawing.Point(83, 4)
        Me.txtCEVABCH.MaxLength = 20
        Me.txtCEVABCH.Name = "txtCEVABCH"
        Me.txtCEVABCH.Size = New System.Drawing.Size(152, 21)
        Me.txtCEVABCH.TabIndex = 9
        '
        'btn_search
        '
        Me.btn_search.Location = New System.Drawing.Point(606, 34)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 25)
        Me.btn_search.TabIndex = 8
        Me.btn_search.Text = "搜索"
        Me.btn_search.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(252, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "送达城市"
        '
        'txtCityTo
        '
        Me.txtCityTo.Location = New System.Drawing.Point(311, 5)
        Me.txtCityTo.MaxLength = 20
        Me.txtCityTo.Name = "txtCityTo"
        Me.txtCityTo.Size = New System.Drawing.Size(152, 21)
        Me.txtCityTo.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(252, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "完成状态"
        '
        'cmbStatus
        '
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"选择操作", "初始状态", "处理中", "已完成"})
        Me.cmbStatus.Location = New System.Drawing.Point(311, 42)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(152, 20)
        Me.cmbStatus.TabIndex = 17
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.opt_dtime, Me.dn_no, Me.sony_bch_no, Me.bch_no, Me.city_to, Me.bin_code, Me.status_code})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.Location = New System.Drawing.Point(5, 70)
        Me.dgv.Name = "dgv"
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.Size = New System.Drawing.Size(765, 356)
        Me.dgv.TabIndex = 18
        '
        'opt_dtime
        '
        Me.opt_dtime.DataPropertyName = "opt_dtime"
        Me.opt_dtime.Frozen = True
        Me.opt_dtime.HeaderText = "操作日期"
        Me.opt_dtime.Name = "opt_dtime"
        Me.opt_dtime.ReadOnly = True
        Me.opt_dtime.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.opt_dtime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.opt_dtime.Width = 80
        '
        'dn_no
        '
        Me.dn_no.DataPropertyName = "dn_no"
        Me.dn_no.HeaderText = "单号"
        Me.dn_no.Name = "dn_no"
        Me.dn_no.ReadOnly = True
        Me.dn_no.Width = 80
        '
        'sony_bch_no
        '
        Me.sony_bch_no.DataPropertyName = "sony_bch_no"
        Me.sony_bch_no.HeaderText = "索尼批次"
        Me.sony_bch_no.Name = "sony_bch_no"
        Me.sony_bch_no.ReadOnly = True
        Me.sony_bch_no.Width = 130
        '
        'bch_no
        '
        Me.bch_no.DataPropertyName = "bch_no"
        Me.bch_no.HeaderText = "CEVA批次"
        Me.bch_no.Name = "bch_no"
        Me.bch_no.ReadOnly = True
        Me.bch_no.Width = 130
        '
        'city_to
        '
        Me.city_to.DataPropertyName = "city_to"
        Me.city_to.HeaderText = "送达城市"
        Me.city_to.Name = "city_to"
        Me.city_to.ReadOnly = True
        '
        'bin_code
        '
        Me.bin_code.DataPropertyName = "bin_code"
        Me.bin_code.HeaderText = "库位"
        Me.bin_code.Name = "bin_code"
        Me.bin_code.ReadOnly = True
        '
        'status_code
        '
        Me.status_code.DataPropertyName = "status_code"
        Me.status_code.HeaderText = "完成状态"
        Me.status_code.Name = "status_code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(484, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 12)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "库位"
        '
        'txtBin
        '
        Me.txtBin.Location = New System.Drawing.Point(529, 4)
        Me.txtBin.MaxLength = 20
        Me.txtBin.Name = "txtBin"
        Me.txtBin.Size = New System.Drawing.Size(152, 21)
        Me.txtBin.TabIndex = 20
        '
        'frmOperateStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(774, 427)
        Me.Controls.Add(Me.txtBin)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCityTo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSonyBCH)
        Me.Controls.Add(Me.txtCEVABCH)
        Me.Controls.Add(Me.btn_search)
        Me.Name = "frmOperateStatus"
        Me.Text = "操作状态明细"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSonyBCH As System.Windows.Forms.TextBox
    Friend WithEvents txtCEVABCH As System.Windows.Forms.TextBox
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCityTo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents opt_dtime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dn_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sony_bch_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bch_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents city_to As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bin_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBin As System.Windows.Forms.TextBox
End Class
