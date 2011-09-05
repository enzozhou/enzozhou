<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportCityBin
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
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.city_to = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bin_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Button1 = New System.Windows.Forms.Button
        Me.txt_bch_no = New System.Windows.Forms.TextBox
        Me.txt_sony_bch_no = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(577, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "导出"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "索尼批次号"
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.city_to, Me.bin_code})
        Me.dgv.Location = New System.Drawing.Point(11, 83)
        Me.dgv.Name = "dgv"
        Me.dgv.RowTemplate.Height = 23
        Me.dgv.Size = New System.Drawing.Size(641, 242)
        Me.dgv.TabIndex = 16
        '
        'city_to
        '
        Me.city_to.DataPropertyName = "city_to"
        Me.city_to.Frozen = True
        Me.city_to.HeaderText = "站点"
        Me.city_to.Name = "city_to"
        Me.city_to.ReadOnly = True
        Me.city_to.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.city_to.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.city_to.Width = 150
        '
        'bin_code
        '
        Me.bin_code.DataPropertyName = "bin_code"
        Me.bin_code.HeaderText = "库位"
        Me.bin_code.Name = "bin_code"
        Me.bin_code.ReadOnly = True
        Me.bin_code.Width = 150
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(577, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "查询"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txt_bch_no
        '
        Me.txt_bch_no.Location = New System.Drawing.Point(95, 50)
        Me.txt_bch_no.Name = "txt_bch_no"
        Me.txt_bch_no.Size = New System.Drawing.Size(457, 21)
        Me.txt_bch_no.TabIndex = 14
        '
        'txt_sony_bch_no
        '
        Me.txt_sony_bch_no.Location = New System.Drawing.Point(95, 6)
        Me.txt_sony_bch_no.Name = "txt_sony_bch_no"
        Me.txt_sony_bch_no.Size = New System.Drawing.Size(457, 21)
        Me.txt_sony_bch_no.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 12)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "内部批次号"
        '
        'frmExportCityBin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(662, 361)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt_bch_no)
        Me.Controls.Add(Me.txt_sony_bch_no)
        Me.Controls.Add(Me.Label2)
        Me.Name = "frmExportCityBin"
        Me.Text = "站点库位对照表"
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txt_bch_no As System.Windows.Forms.TextBox
    Friend WithEvents txt_sony_bch_no As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents city_to As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bin_code As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
