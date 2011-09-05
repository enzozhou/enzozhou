Imports WMS
Imports YT.BusinessObject
Imports ImportExport
Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports System.Data.SqlClient
Public Class frmSelectLog
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lbltrtype As System.Windows.Forms.Label
    Friend WithEvents lblbehesttrpe As System.Windows.Forms.Label
    Friend WithEvents cbbTranLog As System.Windows.Forms.ComboBox
    Friend WithEvents cbbbehestType As System.Windows.Forms.ComboBox
    Protected WithEvents gbxDateSelect As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpDateEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Protected WithEvents dtpDateStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtskuNo As System.Windows.Forms.TextBox
    Friend WithEvents txtDocNo As System.Windows.Forms.TextBox
    Friend WithEvents btnRelateSku As System.Windows.Forms.Button
    Friend WithEvents btnOrginal As System.Windows.Forms.Button
    Friend WithEvents cbodc_code As System.Windows.Forms.ComboBox
    Friend WithEvents lbldc_name As System.Windows.Forms.Label
    Friend WithEvents btnRelateDc As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSelectLog))
        Me.lbltrtype = New System.Windows.Forms.Label
        Me.lblbehesttrpe = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbbTranLog = New System.Windows.Forms.ComboBox
        Me.cbbbehestType = New System.Windows.Forms.ComboBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.gbxDateSelect = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpDateEnd = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpDateStart = New System.Windows.Forms.DateTimePicker
        Me.txtDocNo = New System.Windows.Forms.TextBox
        Me.txtskuNo = New System.Windows.Forms.TextBox
        Me.btnRelateSku = New System.Windows.Forms.Button
        Me.btnOrginal = New System.Windows.Forms.Button
        Me.cbodc_code = New System.Windows.Forms.ComboBox
        Me.lbldc_name = New System.Windows.Forms.Label
        Me.btnRelateDc = New System.Windows.Forms.Button
        Me.gbxDateSelect.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbltrtype
        '
        Me.lbltrtype.Location = New System.Drawing.Point(24, 104)
        Me.lbltrtype.Name = "lbltrtype"
        Me.lbltrtype.Size = New System.Drawing.Size(83, 22)
        Me.lbltrtype.TabIndex = 0
        Me.lbltrtype.Text = "事务类型："
        '
        'lblbehesttrpe
        '
        Me.lblbehesttrpe.Location = New System.Drawing.Point(24, 128)
        Me.lblbehesttrpe.Name = "lblbehesttrpe"
        Me.lblbehesttrpe.Size = New System.Drawing.Size(136, 21)
        Me.lblbehesttrpe.TabIndex = 1
        Me.lblbehesttrpe.Text = "命令类型："
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "业务单号："
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 21)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "产品代码："
        '
        'cbbTranLog
        '
        Me.cbbTranLog.Location = New System.Drawing.Point(120, 104)
        Me.cbbTranLog.Name = "cbbTranLog"
        Me.cbbTranLog.Size = New System.Drawing.Size(368, 21)
        Me.cbbTranLog.TabIndex = 3
        '
        'cbbbehestType
        '
        Me.cbbbehestType.Location = New System.Drawing.Point(120, 128)
        Me.cbbbehestType.Name = "cbbbehestType"
        Me.cbbbehestType.Size = New System.Drawing.Size(368, 21)
        Me.cbbbehestType.TabIndex = 4
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(336, 208)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(72, 29)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "确 定"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(424, 208)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(62, 29)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "关 闭"
        '
        'gbxDateSelect
        '
        Me.gbxDateSelect.Controls.Add(Me.Label1)
        Me.gbxDateSelect.Controls.Add(Me.dtpDateEnd)
        Me.gbxDateSelect.Controls.Add(Me.Label2)
        Me.gbxDateSelect.Controls.Add(Me.dtpDateStart)
        Me.gbxDateSelect.Location = New System.Drawing.Point(8, 40)
        Me.gbxDateSelect.Name = "gbxDateSelect"
        Me.gbxDateSelect.Size = New System.Drawing.Size(480, 56)
        Me.gbxDateSelect.TabIndex = 25
        Me.gbxDateSelect.TabStop = False
        Me.gbxDateSelect.Text = "日期范围"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("SimSun", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 22)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "开始时间："
        '
        'dtpDateEnd
        '
        Me.dtpDateEnd.Checked = False
        Me.dtpDateEnd.CustomFormat = "yyyy-MM-dd"
        Me.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateEnd.Location = New System.Drawing.Point(336, 24)
        Me.dtpDateEnd.Name = "dtpDateEnd"
        Me.dtpDateEnd.ShowCheckBox = True
        Me.dtpDateEnd.Size = New System.Drawing.Size(128, 20)
        Me.dtpDateEnd.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("SimSun", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(248, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 22)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "结束时间："
        '
        'dtpDateStart
        '
        Me.dtpDateStart.CustomFormat = "yyyy-MM-dd"
        Me.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateStart.Location = New System.Drawing.Point(112, 24)
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.ShowCheckBox = True
        Me.dtpDateStart.Size = New System.Drawing.Size(128, 20)
        Me.dtpDateStart.TabIndex = 1
        '
        'txtDocNo
        '
        Me.txtDocNo.Location = New System.Drawing.Point(120, 152)
        Me.txtDocNo.Name = "txtDocNo"
        Me.txtDocNo.Size = New System.Drawing.Size(368, 20)
        Me.txtDocNo.TabIndex = 5
        Me.txtDocNo.Text = ""
        '
        'txtskuNo
        '
        Me.txtskuNo.Location = New System.Drawing.Point(120, 176)
        Me.txtskuNo.Name = "txtskuNo"
        Me.txtskuNo.Size = New System.Drawing.Size(344, 20)
        Me.txtskuNo.TabIndex = 6
        Me.txtskuNo.Text = ""
        '
        'btnRelateSku
        '
        Me.btnRelateSku.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRelateSku.Image = CType(resources.GetObject("btnRelateSku.Image"), System.Drawing.Image)
        Me.btnRelateSku.Location = New System.Drawing.Point(464, 176)
        Me.btnRelateSku.Name = "btnRelateSku"
        Me.btnRelateSku.Size = New System.Drawing.Size(24, 20)
        Me.btnRelateSku.TabIndex = 7
        '
        'btnOrginal
        '
        Me.btnOrginal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOrginal.Image = CType(resources.GetObject("btnOrginal.Image"), System.Drawing.Image)
        Me.btnOrginal.Location = New System.Drawing.Point(16, 200)
        Me.btnOrginal.Name = "btnOrginal"
        Me.btnOrginal.Size = New System.Drawing.Size(32, 32)
        Me.btnOrginal.TabIndex = 26
        '
        'cbodc_code
        '
        Me.cbodc_code.Items.AddRange(New Object() {".XLS - Excel File", ".TXT - Text File"})
        Me.cbodc_code.Location = New System.Drawing.Point(96, 8)
        Me.cbodc_code.Name = "cbodc_code"
        Me.cbodc_code.Size = New System.Drawing.Size(368, 21)
        Me.cbodc_code.TabIndex = 35
        '
        'lbldc_name
        '
        Me.lbldc_name.Location = New System.Drawing.Point(16, 8)
        Me.lbldc_name.Name = "lbldc_name"
        Me.lbldc_name.Size = New System.Drawing.Size(80, 23)
        Me.lbldc_name.TabIndex = 34
        Me.lbldc_name.Text = "物流中心:"
        '
        'btnRelateDc
        '
        Me.btnRelateDc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRelateDc.Image = CType(resources.GetObject("btnRelateDc.Image"), System.Drawing.Image)
        Me.btnRelateDc.Location = New System.Drawing.Point(464, 8)
        Me.btnRelateDc.Name = "btnRelateDc"
        Me.btnRelateDc.Size = New System.Drawing.Size(24, 20)
        Me.btnRelateDc.TabIndex = 36
        '
        'frmSelectLog
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(496, 246)
        Me.Controls.Add(Me.btnRelateDc)
        Me.Controls.Add(Me.cbodc_code)
        Me.Controls.Add(Me.lbldc_name)
        Me.Controls.Add(Me.btnOrginal)
        Me.Controls.Add(Me.btnRelateSku)
        Me.Controls.Add(Me.txtskuNo)
        Me.Controls.Add(Me.txtDocNo)
        Me.Controls.Add(Me.gbxDateSelect)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.cbbbehestType)
        Me.Controls.Add(Me.cbbTranLog)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblbehesttrpe)
        Me.Controls.Add(Me.lbltrtype)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelectLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " 事物日志查询"
        Me.gbxDateSelect.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim lookup As New lookup
    Dim i As Integer
    Dim ds As DataSet
    Private mFilters As COMExpress.BusinessObject.Filters.CXFilters
    'Dim ManyFilter As COMExpress.BusinessObject.Filters.CXRangeFilter
    Private mObjectName As String


    Private Sub LoadDefaultValue()
        dtpDateStart.Value = DateAdd(DateInterval.Day, -1, Now)
        dtpDateStart.Checked = True
        dtpDateEnd.Checked = False
    End Sub


    Private Sub frmSelectLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetFormResource(Me)
        LoadDcList()
        GetTransLogTranTypeList()
        GetTransLogCommandTypeList()
        LoadDefaultValue()
    End Sub
    Public Property Filter() As COMExpress.BusinessObject.Filters.CXFilters
        Get
            Return mFilters
        End Get
        Set(ByVal Value As COMExpress.BusinessObject.Filters.CXFilters)
            mFilters = Value
        End Set
    End Property
    Public Property ObjectName() As String
        Get
            Return mObjectName
        End Get
        Set(ByVal Value As String)
            mObjectName = Value
        End Set
    End Property
    '获取事物类型
    Private Sub GetTransLogTranTypeList()
        ds = Nothing
        Try
            ds = lookup.SQLToDataSet("select trans_type,trans_desc from transtype")
            '’Me.cbbTranLog.BeginUpdate()
            If ds.Tables(0).Rows.Count > 0 Then
                'For i = 0 To ds.Tables(0).Rows.Count - 1
                '    Me.cbbTranLog.Items.Add(ds.Tables(0).Rows(i).Item(1))
                'Next
                cbbTranLog.DataSource = ds.Tables(0)
                cbbTranLog.DisplayMember = "trans_desc"
                cbbTranLog.ValueMember = "trans_type"
            End If
            Me.cbbTranLog.SelectedValue = "STK"
            '’Me.cbbTranLog.EndUpdate()
        Catch ex As Exception
        End Try
    End Sub
    '获取命令类型
    Private Sub GetTransLogCommandTypeList()
        ds = Nothing
        Try
            ds = lookup.SQLToDataSet("dbo.stp_Lookup_getCommandTypeList")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.cbbbehestType.DataSource = ds.Tables(0)
                Me.cbbbehestType.DisplayMember = "type_name"
                Me.cbbbehestType.ValueMember = "type_code"
            End If
            Me.cbbbehestType.SelectedValue = "990"
        Catch ex As Exception
        End Try
    End Sub
    '确定
    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Try
            UIToFilter()
            If mFilters.Count <= 0 Then
                Message("ID_msg_frmSelectLog_PleaseSelectCondition", True, "请输入查询条件。")
                Exit Sub
            End If
            Me.DialogResult = DialogResult.OK
            'Me.Close()
        Catch ex As Exception
            ErrorMsg(ex, Me.GetType, "btnOk_Click")
        End Try
    End Sub
    Private Sub UIToFilter()
        Dim trans_type As String
        Dim cmd_type As String
        Dim doc_no As String
        Dim sku_no As String
        Dim startDate As String
        Dim endDate As String
        Dim strSQL As String
        Dim fls As New COMExpress.BusinessObject.Filters.CXFilters
        Dim fl As COMExpress.BusinessObject.Filters.CXFilterBase
        trans_type = Trim(Me.cbbTranLog.SelectedValue)
        cmd_type = Trim(cbbbehestType.SelectedValue)
        doc_no = Me.txtDocNo.Text.Trim()
        sku_no = Me.txtskuNo.Text.Trim()
        If trans_type <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("trans_type", trans_type, "clstranslog", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
            fls.Add(fl)
        End If
        If cmd_type <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("cmd_type", cmd_type, "clstranslog", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
            fls.Add(fl)
        End If
        If doc_no <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("doc_no", doc_no, "clstranslog", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
            fls.Add(fl)
        End If
        If sku_no <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("sku_no", sku_no, "clstranslog", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
            fls.Add(fl)
        End If
        If Me.dtpDateStart.Checked = True And Me.dtpDateEnd.Checked = True Then
            '' strSQL = "select opt_dtime from translog where opt_dtime>'" + Me.dtpDateStart.Text.Trim() + "' and opt_dtime <='" + Me.dtpDateEnd.Text.Trim() + "'"
            fl = New COMExpress.BusinessObject.Filters.CXRangeFilter("[translog].[opt_dtime]", COMExpress.BusinessObject.Filters.ConditionOperator.Between, dtpDateStart.Value, dtpDateEnd.Value, True)
            'fl = ManyFilter
            fl.ColumnNameIncludeTableName = True
            fls.Add(fl)
        ElseIf Me.dtpDateStart.Checked = True And Me.dtpDateEnd.Checked = False Then
            '' strSQL = "select opt_dtime from translog where opt_dtime>'" + Me.dtpDateStart.Text.Trim() + "'"
            fl = ImpBusinessCollectionDerived.GetSingleFilter("opt_dtime", dtpDateStart.Value, "clstranslog", COMExpress.BusinessObject.Filters.ConditionOperator.GreaterThan)

            fls.Add(fl)

        ElseIf Me.dtpDateStart.Checked = False And Me.dtpDateEnd.Checked = True Then
            '' strSQL = "select opt_dtime from translog where opt_dtime <='" + Me.dtpDateEnd.Text.Trim() + "'"
            fl = ImpBusinessCollectionDerived.GetSingleFilter("opt_dtime", dtpDateEnd.Value, "clstranslog", COMExpress.BusinessObject.Filters.ConditionOperator.LessThan)
            fls.Add(fl)
        End If

        Dim strDC As String
        strDC = Trim(cbodc_code.Text)
        If Trim(strDC) = "" Then
            strDC = UserRightMgr.gDcCode
        End If
        If strDC.IndexOf("|") >= 0 Then
            Dim pos As Integer
            pos = strDC.IndexOf("|")
            strDC = strDC.Substring(0, pos)
        End If
        If strDC.IndexOf(",") >= 0 Then
            strDC = FormatInclude(strDC)
            fl = ImpBusinessCollectionDerived.GetSingleFilter("dc_code", strDC, "clstranslog", COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
        Else
            fl = ImpBusinessCollectionDerived.GetSingleFilter("dc_code", strDC, "clstranslog", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
        End If
        fls.Add(fl)

        mFilters = fls
        'Dim frmObjectList As frmObjectList
        ''DoSearchCustom(mFilters)
    End Sub

    Private Function FormatInclude(ByVal str As String) As String
        Dim s() As String
        Dim i As Integer
        s = Split(str, ",")
        str = ""
        For i = 0 To s.Length - 1
            str = str + "'" + s(i) + "'"
            If i < s.Length - 1 Then
                str = str + ","
            End If
        Next
        Return str
    End Function

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.Cancel
        'Me.Close()
    End Sub

    Private Sub btnRelateSku_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelateSku.Click
        Dim frm As New frmclsskuinfoselect
        SetModalFormStyle(frm)
        If frm.ShowDialog(Me) = DialogResult.OK Then
            Try
                txtskuNo.Text = frm.txtskuno
            Catch ex As Exception
            End Try
        End If
        frm.Dispose()
        frm = Nothing
    End Sub

    Private Sub btnOrginal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrginal.Click
        Me.DialogResult = DialogResult.Ignore
    End Sub

    Private DefaultDC As String = UserRightMgr.gDcCode
    Private mstrRight_no As String = Rights.SysTranslog

    Private Sub LoadDcList()
        On Error Resume Next
        Dim ds As DataSet
        Dim look As New Lookup
        ds = look.GetDcListByPermission(UserRightMgr.gUserCode, mstrRight_no)
        cbodc_code.ValueMember = ds.Tables(0).Columns(0).ColumnName
        cbodc_code.DisplayMember = ds.Tables(0).Columns(1).ColumnName
        cbodc_code.DataSource = ds.Tables(0).DefaultView
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 1
            If ds.Tables(0).Rows(i).Item(0) = DefaultDC Then
                cbodc_code.SelectedIndex = i
                Return
            End If
        Next
        cbodc_code.SelectedIndex = 0
    End Sub

    Private Function GetDcCodes() As String
        If cbodc_code.SelectedValue <> "" Then
            Return cbodc_code.SelectedValue
        End If
        Dim str As String
        Dim pos As Integer
        str = Trim(cbodc_code.Text)
        pos = str.IndexOf("|")
        If pos < 0 Then
            Return str
        Else
            Return Trim(str.Substring(0, pos))
        End If
    End Function



    Private Sub btnRelateDc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelateDc.Click
        Dim frm As frmRegionDcSelect
        frm = New frmRegionDcSelect
        SetModalFormStyle(frm)
        frm.SupportMultiValue = True
        frm.SelectedValue = GetDcCodes()
        If frm.ShowDialog(Me) = DialogResult.OK Then
            Dim strVal As String
            strVal = frm.SelectedValue
            cbodc_code.Focus()
            If strVal.IndexOf(",") > 0 Then
                'cbodc_code.SelectedValue = DBNull.Value
                cbodc_code.SelectAll()
                cbodc_code.SelectedText = strVal
            Else
                cbodc_code.SelectedValue = strVal
            End If
            SendKeys.Send("{TAB}")
        End If
        frm.Dispose()
        frm = Nothing
    End Sub
End Class
