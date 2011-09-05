<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerformance
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
        Me.btn_search = New System.Windows.Forms.Button
        Me.txtCEVABCH = New System.Windows.Forms.TextBox
        Me.txtSonyBCH = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.opt_dtime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.opt_by = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sony_bch_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bch_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sum_qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sum_dn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnExport = New System.Windows.Forms.Button
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_search
        '
        Me.btn_search.Location = New System.Drawing.Point(505, 12)
        Me.btn_search.Name = "btn_search"
        Me.btn_search.Size = New System.Drawing.Size(75, 23)
        Me.btn_search.TabIndex = 0
        Me.btn_search.Text = "搜索"
        Me.btn_search.UseVisualStyleBackColor = True
        '
        'txtCEVABCH
        '
        Me.txtCEVABCH.Location = New System.Drawing.Point(72, 12)
        Me.txtCEVABCH.MaxLength = 20
        Me.txtCEVABCH.Name = "txtCEVABCH"
        Me.txtCEVABCH.Size = New System.Drawing.Size(152, 21)
        Me.txtCEVABCH.TabIndex = 1
        '
        'txtSonyBCH
        '
        Me.txtSonyBCH.Location = New System.Drawing.Point(328, 12)
        Me.txtSonyBCH.MaxLength = 20
        Me.txtSonyBCH.Name = "txtSonyBCH"
        Me.txtSonyBCH.Size = New System.Drawing.Size(152, 21)
        Me.txtSonyBCH.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "CEVA批次号"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(241, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Sony批次号"
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
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.opt_dtime, Me.opt_by, Me.sony_bch_no, Me.bch_no, Me.sum_qty, Me.sum_dn})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgv.Location = New System.Drawing.Point(3, 56)
        Me.dgv.Name = "dgv"
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.Size = New System.Drawing.Size(685, 307)
        Me.dgv.TabIndex = 6
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
        'opt_by
        '
        Me.opt_by.DataPropertyName = "opt_by"
        Me.opt_by.HeaderText = "操作人员"
        Me.opt_by.Name = "opt_by"
        Me.opt_by.ReadOnly = True
        Me.opt_by.Width = 80
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
        'sum_qty
        '
        Me.sum_qty.DataPropertyName = "sum_qty"
        Me.sum_qty.HeaderText = "操作件数"
        Me.sum_qty.Name = "sum_qty"
        Me.sum_qty.ReadOnly = True
        '
        'sum_dn
        '
        Me.sum_dn.DataPropertyName = "sum_dn"
        Me.sum_dn.HeaderText = "操作票数"
        Me.sum_dn.Name = "sum_dn"
        Me.sum_dn.ReadOnly = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(613, 12)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 7
        Me.btnExport.Text = "导出"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'frmPerformance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 375)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSonyBCH)
        Me.Controls.Add(Me.txtCEVABCH)
        Me.Controls.Add(Me.btn_search)
        Me.Name = "frmPerformance"
        Me.Text = "人员绩效统计"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_search As System.Windows.Forms.Button
    Friend WithEvents txtCEVABCH As System.Windows.Forms.TextBox
    Friend WithEvents txtSonyBCH As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents opt_dtime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents opt_by As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sony_bch_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bch_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sum_qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sum_dn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
