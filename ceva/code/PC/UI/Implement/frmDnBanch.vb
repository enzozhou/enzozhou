Imports YT
Imports YT.BusinessObject
Imports COMExpress.BusinessObject
Public Class frmDnBanch
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Public WithEvents GbQuery As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkClearAllDn As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelectAllDn As System.Windows.Forms.CheckBox
    Friend WithEvents DnList As System.Windows.Forms.CheckedListBox
    Public WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LbBinCount As System.Windows.Forms.Label
    Friend WithEvents lbDNcount As System.Windows.Forms.Label
    Friend WithEvents txtSonyBanch As System.Windows.Forms.TextBox
    Friend WithEvents chknormal As System.Windows.Forms.CheckBox
    Friend WithEvents chkvender As System.Windows.Forms.CheckBox
    Friend WithEvents chknet As System.Windows.Forms.CheckBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnQuery As System.Windows.Forms.Button
    Friend WithEvents btnfind As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDnBanch))
        Me.GbQuery = New System.Windows.Forms.GroupBox
        Me.btnQuery = New System.Windows.Forms.Button
        Me.txtCity = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.chknormal = New System.Windows.Forms.CheckBox
        Me.chkvender = New System.Windows.Forms.CheckBox
        Me.chknet = New System.Windows.Forms.CheckBox
        Me.txtSonyBanch = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkClearAllDn = New System.Windows.Forms.CheckBox
        Me.chkSelectAllDn = New System.Windows.Forms.CheckBox
        Me.DnList = New System.Windows.Forms.CheckedListBox
        Me.BtnOk = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LbBinCount = New System.Windows.Forms.Label
        Me.lbDNcount = New System.Windows.Forms.Label
        Me.btnfind = New System.Windows.Forms.Button
        Me.GbQuery.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GbQuery
        '
        Me.GbQuery.BackColor = System.Drawing.SystemColors.Control
        Me.GbQuery.Controls.Add(Me.btnfind)
        Me.GbQuery.Controls.Add(Me.btnQuery)
        Me.GbQuery.Controls.Add(Me.txtCity)
        Me.GbQuery.Controls.Add(Me.Label4)
        Me.GbQuery.Controls.Add(Me.chknormal)
        Me.GbQuery.Controls.Add(Me.chkvender)
        Me.GbQuery.Controls.Add(Me.chknet)
        Me.GbQuery.Controls.Add(Me.txtSonyBanch)
        Me.GbQuery.Controls.Add(Me.Label3)
        Me.GbQuery.Dock = System.Windows.Forms.DockStyle.Top
        Me.GbQuery.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GbQuery.Location = New System.Drawing.Point(0, 0)
        Me.GbQuery.Name = "GbQuery"
        Me.GbQuery.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GbQuery.Size = New System.Drawing.Size(515, 106)
        Me.GbQuery.TabIndex = 52
        Me.GbQuery.TabStop = False
        Me.GbQuery.Tag = "11501"
        '
        'btnQuery
        '
        Me.btnQuery.Location = New System.Drawing.Point(356, 67)
        Me.btnQuery.Name = "btnQuery"
        Me.btnQuery.Size = New System.Drawing.Size(75, 23)
        Me.btnQuery.TabIndex = 86
        Me.btnQuery.Text = "确定"
        Me.btnQuery.UseVisualStyleBackColor = True
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(96, 42)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(337, 21)
        Me.txtCity.TabIndex = 85
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(7, 45)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 21)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "目的城市:"
        '
        'chknormal
        '
        Me.chknormal.AutoSize = True
        Me.chknormal.Location = New System.Drawing.Point(239, 73)
        Me.chknormal.Name = "chknormal"
        Me.chknormal.Size = New System.Drawing.Size(48, 16)
        Me.chknormal.TabIndex = 83
        Me.chknormal.Text = "普货"
        Me.chknormal.UseVisualStyleBackColor = True
        '
        'chkvender
        '
        Me.chkvender.AutoSize = True
        Me.chkvender.Location = New System.Drawing.Point(122, 73)
        Me.chkvender.Name = "chkvender"
        Me.chkvender.Size = New System.Drawing.Size(60, 16)
        Me.chkvender.TabIndex = 82
        Me.chkvender.Text = "经销商"
        Me.chkvender.UseVisualStyleBackColor = True
        '
        'chknet
        '
        Me.chknet.AutoSize = True
        Me.chknet.Location = New System.Drawing.Point(7, 73)
        Me.chknet.Name = "chknet"
        Me.chknet.Size = New System.Drawing.Size(48, 16)
        Me.chknet.TabIndex = 81
        Me.chknet.Text = "网销"
        Me.chknet.UseVisualStyleBackColor = True
        '
        'txtSonyBanch
        '
        Me.txtSonyBanch.Location = New System.Drawing.Point(96, 11)
        Me.txtSonyBanch.Name = "txtSonyBanch"
        Me.txtSonyBanch.Size = New System.Drawing.Size(337, 21)
        Me.txtSonyBanch.TabIndex = 80
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(7, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 21)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "索尼批次号:"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.chkClearAllDn)
        Me.GroupBox1.Controls.Add(Me.chkSelectAllDn)
        Me.GroupBox1.Controls.Add(Me.DnList)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(0, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(509, 396)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "11501"
        Me.GroupBox1.Text = "发货单列表"
        '
        'chkClearAllDn
        '
        Me.chkClearAllDn.Location = New System.Drawing.Point(83, 366)
        Me.chkClearAllDn.Name = "chkClearAllDn"
        Me.chkClearAllDn.Size = New System.Drawing.Size(76, 26)
        Me.chkClearAllDn.TabIndex = 77
        Me.chkClearAllDn.Text = "全不选"
        '
        'chkSelectAllDn
        '
        Me.chkSelectAllDn.Location = New System.Drawing.Point(10, 366)
        Me.chkSelectAllDn.Name = "chkSelectAllDn"
        Me.chkSelectAllDn.Size = New System.Drawing.Size(48, 26)
        Me.chkSelectAllDn.TabIndex = 76
        Me.chkSelectAllDn.Text = "全选"
        '
        'DnList
        '
        Me.DnList.CheckOnClick = True
        Me.DnList.ColumnWidth = 340
        Me.DnList.Location = New System.Drawing.Point(9, 20)
        Me.DnList.Name = "DnList"
        Me.DnList.Size = New System.Drawing.Size(494, 340)
        Me.DnList.TabIndex = 78
        '
        'BtnOk
        '
        Me.BtnOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnOk.Location = New System.Drawing.Point(12, 514)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtnOk.Size = New System.Drawing.Size(77, 22)
        Me.BtnOk.TabIndex = 81
        Me.BtnOk.Tag = "11487"
        Me.BtnOk.Text = "货位推荐"
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(120, 518)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 21)
        Me.Label1.TabIndex = 82
        Me.Label1.Text = "可用货位数："
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(276, 516)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 21)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "已选发货单数："
        '
        'LbBinCount
        '
        Me.LbBinCount.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LbBinCount.ForeColor = System.Drawing.Color.Red
        Me.LbBinCount.Location = New System.Drawing.Point(192, 516)
        Me.LbBinCount.Name = "LbBinCount"
        Me.LbBinCount.Size = New System.Drawing.Size(69, 21)
        Me.LbBinCount.TabIndex = 84
        '
        'lbDNcount
        '
        Me.lbDNcount.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.lbDNcount.ForeColor = System.Drawing.Color.Red
        Me.lbDNcount.Location = New System.Drawing.Point(362, 512)
        Me.lbDNcount.Name = "lbDNcount"
        Me.lbDNcount.Size = New System.Drawing.Size(69, 21)
        Me.lbDNcount.TabIndex = 85
        '
        'btnfind
        '
        Me.btnfind.Location = New System.Drawing.Point(434, 13)
        Me.btnfind.Name = "btnfind"
        Me.btnfind.Size = New System.Drawing.Size(75, 50)
        Me.btnfind.TabIndex = 87
        Me.btnfind.Text = "查询"
        Me.btnfind.UseVisualStyleBackColor = True
        '
        'frmDnBanch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(515, 540)
        Me.Controls.Add(Me.lbDNcount)
        Me.Controls.Add(Me.LbBinCount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GbQuery)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDnBanch"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "特殊发货组批"
        Me.GbQuery.ResumeLayout(False)
        Me.GbQuery.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region " user defined property "
    Dim look As New YT.BusinessObject.Lookup
    Dim Optimization As New clsOptimizationDN
    Dim initBanchNo As String = ""
    Private objCurrentDNList As DataSet
    Private objSelectedDNList As New Microsoft.VisualBasic.Collection
#End Region
#Region " customer bussniness flow "
    Private Sub SetAvaialbelBinCount()
        On Error Resume Next
        Dim obj As DataSet
        obj = look.GetAvariableBinCount
        Me.LbBinCount.Text = 0
        If obj.Tables(0).Rows.Count > 0 Then
            Me.LbBinCount.Text = obj.Tables(0).Rows(0).Item("bincount").ToString
        End If
    End Sub
    Private Sub RefreshDnListInternal()
        On Error Resume Next
        Dim obj As DataSet
        Dim sWhere As String = " "
        sWhere = PreparedWhereStr()
        obj = look.GetAvariableDNListByWhere(sWhere)
        DnList.DataSource = obj.Tables(0).DefaultView
        DnList.ValueMember = obj.Tables(0).Columns("dn_no").ColumnName
        DnList.DisplayMember = obj.Tables(0).Columns("descr").ColumnName
        objCurrentDNList = obj
    End Sub
    Private Sub SetDnListCheckStatus(ByVal bCheck As Boolean)
        Dim i As Integer
        For i = 0 To DnList.Items.Count - 1
            DnList.SetItemChecked(i, bCheck)
        Next
    End Sub
    Private Sub GetSelectedListForReturn()
        Dim RetCode As String = ""
        Dim RetMsg As String = ""
        While objSelectedDNList.Count > 0
            objSelectedDNList.Remove(1)
        End While
        If objCurrentDNList Is Nothing Then
            Return
        End If
        Dim i As Integer
        Dim DnNo As String
        Try
            For i = 0 To DnList.Items.Count - 1
                If DnList.GetItemChecked(i) Then
                    DnNo = CType(objCurrentDNList.Tables(0).Rows(i).Item("dn_no"), String)
                    objSelectedDNList.Add(DnNo)
                    'create a new banch and add the DN into this banch
                    Optimization.CreateBanchBySingleDN("SHA", "", initBanchNo, DnNo, RetCode, RetMsg)
                End If
            Next
            'Optimization the bin for each DN in this banch 
            Optimization.OptimizationBanch("SHA", initBanchNo, RetCode, RetMsg)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub GetCarrierSeqBatchNo(ByRef BchNo As String)
        Dim obj As New clsDocumentFormat
        Try
            BchNo = obj.GetNewDocumentNumber("SHA", "bchhdr", "bch_no", clsDocumentFormat.FormatBatch, "BNCH")
        Catch ex As Exception
        End Try
    End Sub
    Private Function PreparedWhereStr() As String
        Dim sWhere As String = " "
        If Me.txtSonyBanch.Text <> "" Then
            sWhere = sWhere + " and sony_bch_no in  (" + Me.txtSonyBanch.Text + ")"
        End If
        If Me.txtCity.Text <> "" Then
            sWhere = sWhere + " and city_to in( " + Me.txtCity.Text + ")"
        End If
        If Me.chknet.Checked Then
            sWhere = sWhere + " and doc_type = '0'"
        End If
        If Me.chkvender.Checked Then
            sWhere = sWhere + " and doc_type = '1'"
        End If
        If Me.chknormal.Checked Then
            sWhere = sWhere + " and doc_type = '2'"
        End If
        Return sWhere
    End Function

#End Region
#Region " user control envent "
    Private Sub chkSelectAllDn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAllDn.CheckedChanged
        If chkSelectAllDn.Checked Then
            SetDnListCheckStatus(True)
        End If
        chkClearAllDn.Checked = Not chkSelectAllDn.Checked
        lbDNcount.Text = DnList.CheckedItems.Count
    End Sub
    Private Sub chkClearAllDn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClearAllDn.CheckedChanged
        If chkClearAllDn.Checked Then
            SetDnListCheckStatus(False)
        End If
        chkSelectAllDn.Checked = Not chkClearAllDn.Checked
        lbDNcount.Text = DnList.CheckedItems.Count
    End Sub
    Private Sub cmbSonyBanch_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshDnListInternal()
    End Sub
    Private Sub frmNormalDnBanch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetAvaialbelBinCount()
    End Sub
    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        GetCarrierSeqBatchNo(Me.initBanchNo)
        GetSelectedListForReturn()
        Me.Close()
    End Sub
    Private Sub DnList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DnList.SelectedIndexChanged
        lbDNcount.Text = DnList.CheckedItems.Count
    End Sub
#End Region

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuery.Click
        RefreshDnListInternal()
    End Sub

    Private Sub btnfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnfind.Click
        Dim frm As New frmListWhere
        SetModalFormStyle(frm)
        frm.ShowDialog()
        Me.txtSonyBanch.Text = frm.sSonyBanchWhere
        Me.txtCity.Text = frm.sCityWhere
    End Sub
End Class

