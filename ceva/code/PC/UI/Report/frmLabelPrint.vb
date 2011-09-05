Imports YT
Imports YT.BusinessObject
Imports System.IO
Public Class frmLabelPrint
    Inherits System.Windows.Forms.Form
    Public LableType As String
    Private numbers As Int32
    Private package As Int32
    Private v_up, v_down, v_left, v_right As String
    Friend WithEvents txtPackageNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private Fdata As String

#Region " Windows 窗体设计器生成的代码 "

    Public Sub New()
        MyBase.New()

        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        '在 InitializeComponent() 调用之后添加任何初始化

    End Sub

    '窗体重写 dispose 以清理组件列表。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改此过程。
    '不要使用代码编辑器修改它。
    Protected WithEvents gbxDateSelect As System.Windows.Forms.GroupBox
    Protected WithEvents lblTo As System.Windows.Forms.Label
    Protected WithEvents dtpDateStart As System.Windows.Forms.DateTimePicker
    Protected WithEvents dtpDateEnd As System.Windows.Forms.DateTimePicker
    Protected WithEvents rbtnCustomDate As System.Windows.Forms.RadioButton
    Friend WithEvents btnEnter As System.Windows.Forms.Button
    Friend WithEvents btnReturn As System.Windows.Forms.Button
    Friend WithEvents cbxPreview As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncludeClosed As System.Windows.Forms.CheckBox
    Friend WithEvents ro_no As System.Windows.Forms.ComboBox
    Friend WithEvents sku_no As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Banch_no As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PnlCondition As System.Windows.Forms.GroupBox
    Friend WithEvents SkuCondition As System.Windows.Forms.GroupBox
    Friend WithEvents SCondition As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrintNumber As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TimerClose As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.gbxDateSelect = New System.Windows.Forms.GroupBox
        Me.lblTo = New System.Windows.Forms.Label
        Me.dtpDateStart = New System.Windows.Forms.DateTimePicker
        Me.dtpDateEnd = New System.Windows.Forms.DateTimePicker
        Me.rbtnCustomDate = New System.Windows.Forms.RadioButton
        Me.btnEnter = New System.Windows.Forms.Button
        Me.btnReturn = New System.Windows.Forms.Button
        Me.cbxPreview = New System.Windows.Forms.CheckBox
        Me.PnlCondition = New System.Windows.Forms.GroupBox
        Me.chkIncludeClosed = New System.Windows.Forms.CheckBox
        Me.ro_no = New System.Windows.Forms.ComboBox
        Me.SkuCondition = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.sku_no = New System.Windows.Forms.ComboBox
        Me.SCondition = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Banch_no = New System.Windows.Forms.ComboBox
        Me.txtPrintNumber = New System.Windows.Forms.TextBox
        Me.TimerClose = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtPackageNumber = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.gbxDateSelect.SuspendLayout()
        Me.PnlCondition.SuspendLayout()
        Me.SkuCondition.SuspendLayout()
        Me.SCondition.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxDateSelect
        '
        Me.gbxDateSelect.Controls.Add(Me.lblTo)
        Me.gbxDateSelect.Controls.Add(Me.dtpDateStart)
        Me.gbxDateSelect.Controls.Add(Me.dtpDateEnd)
        Me.gbxDateSelect.Controls.Add(Me.rbtnCustomDate)
        Me.gbxDateSelect.Location = New System.Drawing.Point(16, 8)
        Me.gbxDateSelect.Name = "gbxDateSelect"
        Me.gbxDateSelect.Size = New System.Drawing.Size(556, 55)
        Me.gbxDateSelect.TabIndex = 21
        Me.gbxDateSelect.TabStop = False
        Me.gbxDateSelect.Text = "选择日期范围"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(312, 27)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(17, 12)
        Me.lblTo.TabIndex = 3
        Me.lblTo.Text = "到"
        '
        'dtpDateStart
        '
        Me.dtpDateStart.CustomFormat = "yyyy-MM-dd"
        Me.dtpDateStart.Enabled = False
        Me.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateStart.Location = New System.Drawing.Point(128, 21)
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.Size = New System.Drawing.Size(168, 21)
        Me.dtpDateStart.TabIndex = 2
        Me.dtpDateStart.Tag = "@start_date"
        '
        'dtpDateEnd
        '
        Me.dtpDateEnd.CustomFormat = "yyyy-MM-dd"
        Me.dtpDateEnd.Enabled = False
        Me.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateEnd.Location = New System.Drawing.Point(344, 21)
        Me.dtpDateEnd.Name = "dtpDateEnd"
        Me.dtpDateEnd.Size = New System.Drawing.Size(200, 21)
        Me.dtpDateEnd.TabIndex = 2
        Me.dtpDateEnd.Tag = "@end_date"
        '
        'rbtnCustomDate
        '
        Me.rbtnCustomDate.Location = New System.Drawing.Point(19, 21)
        Me.rbtnCustomDate.Name = "rbtnCustomDate"
        Me.rbtnCustomDate.Size = New System.Drawing.Size(125, 24)
        Me.rbtnCustomDate.TabIndex = 1
        Me.rbtnCustomDate.Text = "指定日期从"
        '
        'btnEnter
        '
        Me.btnEnter.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnEnter.Location = New System.Drawing.Point(258, 389)
        Me.btnEnter.Name = "btnEnter"
        Me.btnEnter.Size = New System.Drawing.Size(103, 32)
        Me.btnEnter.TabIndex = 17
        Me.btnEnter.Text = "打印"
        '
        'btnReturn
        '
        Me.btnReturn.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnReturn.Location = New System.Drawing.Point(378, 389)
        Me.btnReturn.Name = "btnReturn"
        Me.btnReturn.Size = New System.Drawing.Size(104, 32)
        Me.btnReturn.TabIndex = 18
        Me.btnReturn.Text = "关闭 "
        '
        'cbxPreview
        '
        Me.cbxPreview.Location = New System.Drawing.Point(35, 366)
        Me.cbxPreview.Name = "cbxPreview"
        Me.cbxPreview.Size = New System.Drawing.Size(154, 20)
        Me.cbxPreview.TabIndex = 19
        Me.cbxPreview.Text = "打印预览"
        '
        'PnlCondition
        '
        Me.PnlCondition.Controls.Add(Me.chkIncludeClosed)
        Me.PnlCondition.Controls.Add(Me.ro_no)
        Me.PnlCondition.Location = New System.Drawing.Point(16, 61)
        Me.PnlCondition.Name = "PnlCondition"
        Me.PnlCondition.Size = New System.Drawing.Size(556, 80)
        Me.PnlCondition.TabIndex = 23
        Me.PnlCondition.TabStop = False
        Me.PnlCondition.Text = "选择收货单"
        '
        'chkIncludeClosed
        '
        Me.chkIncludeClosed.Checked = True
        Me.chkIncludeClosed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncludeClosed.Location = New System.Drawing.Point(10, 32)
        Me.chkIncludeClosed.Name = "chkIncludeClosed"
        Me.chkIncludeClosed.Size = New System.Drawing.Size(153, 20)
        Me.chkIncludeClosed.TabIndex = 28
        Me.chkIncludeClosed.Text = "列出已完成收货单"
        '
        'ro_no
        '
        Me.ro_no.Location = New System.Drawing.Point(173, 32)
        Me.ro_no.Name = "ro_no"
        Me.ro_no.Size = New System.Drawing.Size(374, 20)
        Me.ro_no.TabIndex = 27
        Me.ro_no.Tag = "@ro_no"
        '
        'SkuCondition
        '
        Me.SkuCondition.Controls.Add(Me.Label1)
        Me.SkuCondition.Controls.Add(Me.Label2)
        Me.SkuCondition.Controls.Add(Me.sku_no)
        Me.SkuCondition.Location = New System.Drawing.Point(16, 144)
        Me.SkuCondition.Name = "SkuCondition"
        Me.SkuCondition.Size = New System.Drawing.Size(556, 64)
        Me.SkuCondition.TabIndex = 24
        Me.SkuCondition.TabStop = False
        Me.SkuCondition.Text = "选择产品代码"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "产品代码"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "机号"
        '
        'sku_no
        '
        Me.sku_no.Location = New System.Drawing.Point(173, 24)
        Me.sku_no.Name = "sku_no"
        Me.sku_no.Size = New System.Drawing.Size(374, 20)
        Me.sku_no.TabIndex = 29
        Me.sku_no.Tag = "@sku_no"
        '
        'SCondition
        '
        Me.SCondition.Controls.Add(Me.Label3)
        Me.SCondition.Controls.Add(Me.Banch_no)
        Me.SCondition.Location = New System.Drawing.Point(16, 211)
        Me.SCondition.Name = "SCondition"
        Me.SCondition.Size = New System.Drawing.Size(556, 72)
        Me.SCondition.TabIndex = 25
        Me.SCondition.TabStop = False
        Me.SCondition.Tag = "@s_no"
        Me.SCondition.Text = "批次号"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(24, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "批次号"
        '
        'Banch_no
        '
        Me.Banch_no.Location = New System.Drawing.Point(173, 40)
        Me.Banch_no.Name = "Banch_no"
        Me.Banch_no.Size = New System.Drawing.Size(374, 20)
        Me.Banch_no.TabIndex = 30
        Me.Banch_no.Tag = "@s_no"
        '
        'txtPrintNumber
        '
        Me.txtPrintNumber.Location = New System.Drawing.Point(83, 35)
        Me.txtPrintNumber.Name = "txtPrintNumber"
        Me.txtPrintNumber.Size = New System.Drawing.Size(184, 21)
        Me.txtPrintNumber.TabIndex = 34
        Me.txtPrintNumber.Text = "1"
        '
        'TimerClose
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPackageNumber)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtPrintNumber)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 289)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(556, 72)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "@s_no"
        Me.GroupBox1.Text = "数量"
        '
        'txtPackageNumber
        '
        Me.txtPackageNumber.Location = New System.Drawing.Point(372, 35)
        Me.txtPackageNumber.Name = "txtPackageNumber"
        Me.txtPackageNumber.Size = New System.Drawing.Size(168, 21)
        Me.txtPackageNumber.TabIndex = 36
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(314, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 16)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "包装数量"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "打印数量"
        '
        'frmLabelPrint
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(583, 437)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.SCondition)
        Me.Controls.Add(Me.SkuCondition)
        Me.Controls.Add(Me.PnlCondition)
        Me.Controls.Add(Me.gbxDateSelect)
        Me.Controls.Add(Me.btnEnter)
        Me.Controls.Add(Me.btnReturn)
        Me.Controls.Add(Me.cbxPreview)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLabelPrint"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "标签打印"
        Me.gbxDateSelect.ResumeLayout(False)
        Me.gbxDateSelect.PerformLayout()
        Me.PnlCondition.ResumeLayout(False)
        Me.SkuCondition.ResumeLayout(False)
        Me.SCondition.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim mRptSet As ReportSetting
    Private mParaList As New Hashtable
    Private frmRpt As frmRptViewer
    Dim StartTime As String
    Dim EndTime As String
    Dim flag As String = "1"
    Dim contain As String = "1"
    Public num As Integer
    Public strdn_no As String
    Public arrDn_no As New ArrayList
    Dim lookup As New Lookup

    Public DefaultDC As String = UserRightMgr.gDcCode
    Public dc_code As String

    Private bLoading As Boolean = False

    Private Sub frmLabelPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Me.dtpDateStart.Value = Now
        Me.dtpDateEnd.Value = Now
        If (Me.LableType = "PO") Then
            chkIncludeClosed.Text = "列出已完成收货单"
        ElseIf (Me.LableType = "WO") Then
            chkIncludeClosed.Text = "列出已完成领料单"
        End If
        contain = "1"
        Try
            'Dim rs As DataSet
            bLoading = True
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            bLoading = False
        End Try
        convertDate()
        ReturnBillList()
    End Sub
    Private Sub ReturnBillList()
        Dim lookup As New Lookup
        Dim rs As DataSet
        Dim i As Integer

        StartTime = Me.dtpDateStart.Value.Date
        EndTime = Me.dtpDateEnd.Value.AddDays(1).Date

        If Me.chkIncludeClosed.Checked = True Then
            '包含完成的
            contain = "1"
        Else
            '不包含完成的
            contain = "0"
        End If

        '清空选项
        ro_no.Items.Clear()
        sku_no.Items.Clear()
        Banch_no.Items.Clear()
        '清空数据
        ro_no.Text = ""
        sku_no.Text = ""
        Banch_no.Text = ""
        txtPrintNumber.Text = ""
        If (Me.LableType = "PO") Then
            rs = lookup.GetReceivingPOList("", StartTime, EndTime, contain)
        ElseIf (Me.LableType = "WO") Then
            rs = lookup.GetReceivingWOList("", StartTime, EndTime, contain)
        End If
        If rs.Tables(0).Rows.Count > 0 Then
            For i = 0 To rs.Tables(0).Rows.Count - 1
                ro_no.Items.Add(rs.Tables(0).Rows(i).Item(0) & " | " & rs.Tables(0).Rows(i).Item(1))
            Next
        End If
       
    End Sub
    Private Sub ReturnSkuNo()
        Dim lookup As New Lookup
        Dim rs As DataSet
        Dim i As Integer
        Dim RoNo As String

        ''必须选择入库单


        '获取入库单选中值
        If InStrRev(ro_no.Text, "|") = 0 Then
            RoNo = ro_no.Text
        Else
            RoNo = Mid(ro_no.Text, 1, InStrRev(ro_no.Text, "|") - 1)
        End If


        '清空选项
        sku_no.Items.Clear()
        's_no.Items.Clear()
        '清空数据
        sku_no.Text = ""
        's_no.Text = ""

        '清空选项
        Banch_no.Items.Clear()
        Banch_no.Text = ""
        txtPrintNumber.Text = ""
        If (Me.LableType = "PO") Then
            Banch_no.Text = RTrim(LTrim(RoNo)) + Fdata.ToString  ''Format(Now, "yyyyMMdd")
            rs = lookup.GetPOSkuNo("", RoNo)
        ElseIf (Me.LableType = "WO") Then
            Banch_no.Text = RTrim(LTrim(RoNo))
            rs = lookup.GetWOSkuNo("", RoNo)
        End If
        If rs.Tables(0).Rows.Count > 0 Then
            For i = 0 To rs.Tables(0).Rows.Count - 1
                sku_no.Items.Add(rs.Tables(0).Rows(i).Item(0) & " | " & rs.Tables(0).Rows(i).Item(1))
            Next
        End If

    End Sub

    ' get sno value
    Private Sub ReturnItemNumbers()
        Dim lookup As New Lookup
        Dim RoNo As String
        Dim SkuNo As String
        Dim ck As DataSet
        Dim PackageSet As DataSet
        Dim PictureSet As DataSet
        Dim i As Integer
        Try
            '获取入库单选中值及产品代码选中值
            If InStrRev(ro_no.Text, "|") = 0 Then
                RoNo = Trim(ro_no.Text)
            Else
                RoNo = Trim(Mid(ro_no.Text, 1, InStrRev(ro_no.Text, "|") - 1))
            End If

            If InStrRev(sku_no.Text, "|") = 0 Then
                SkuNo = Trim(sku_no.Text)
            Else
                SkuNo = Trim(Mid(sku_no.Text, 1, InStrRev(sku_no.Text, "|") - 1))
            End If
            If (Me.LableType = "PO") Then
                ck = lookup.GetPOSkuNumber(RoNo, SkuNo)
            ElseIf (Me.LableType = "WO") Then
                ck = lookup.GetWOSkuNumber(RoNo, SkuNo)
            End If
            ''得到包装数量
            PackageSet = lookup.GetItemPackage(SkuNo)

            If PackageSet.Tables(0).Rows.Count > 0 Then
                v_up = (PackageSet.Tables(0).Rows(0).Item("v_up"))
                v_left = (PackageSet.Tables(0).Rows(0).Item("v_left"))
                v_down = (PackageSet.Tables(0).Rows(0).Item("v_down"))
                v_right = (PackageSet.Tables(0).Rows(0).Item("v_right"))
                package = (PackageSet.Tables(0).Rows(0).Item("package"))
                txtPackageNumber.Text = package
            End If
            ''得到打印数量
            If ck.Tables(0).Rows.Count > 0 Then
                For i = 0 To ck.Tables(0).Rows.Count - 1
                    If (package = 0) Then
                        Me.txtPrintNumber.Text = (ck.Tables(0).Rows(i).Item(1))
                        numbers = System.Convert.ToInt32((ck.Tables(0).Rows(i).Item(1)))
                    Else
                        Me.txtPrintNumber.Text = (ck.Tables(0).Rows(i).Item(1)) / package
                        numbers = System.Convert.ToInt32((ck.Tables(0).Rows(i).Item(1))) / package
                    End If
                Next
            End If
            ''根据物料号得到图片名称
            PictureSet = lookup.GetPictureNameBySkuNo(SkuNo)
            If PictureSet.Tables(0).Rows.Count > 0 Then
                mRptSet.PictureName = PictureSet.Tables(0).Rows(0).Item(0).ToString
            End If
        Catch ex As Exception
            Return
        End Try
       
    End Sub
    Private Function inputCheck() As Boolean
        inputCheck = False
        Dim lookup As New Lookup
        Dim skuno As String

        'check product code ---start
        'if product code equal null or ''
        If sku_no.Text = "" Then
            Message("ID_msg_frmLabelPrint_PlsSelectOrInputSkuCode", True, "请选择或输入产品代码!")
            sku_no.Focus()
            Return inputCheck
        End If
        If Banch_no.Text = "" Then
            Message("ID_msg_frmLabelPrint_PlsSelectOrInputBanchCode", True, "请选择或输入产品批次号!")
            Banch_no.Focus()
            Return inputCheck
        End If
        If txtPrintNumber.Text = "" Then
            Message("ID_msg_frmLabelPrint_PlsSelectOrInputPrintNumber", True, "请选择或输入打印数量!")
            txtPrintNumber.Focus()
            Return inputCheck
        End If
        If IsNumeric(Me.txtPrintNumber.Text.ToString) = False Then
            Message("ID_msg_frmLabelPrint_PlsSelectOrInputPrintNumber", True, "打印数量输入不正确，请重新输入!")
            txtPrintNumber.Focus()
            Return inputCheck
        End If
        If IsNumeric(Me.txtPackageNumber.Text.ToString) = False Then
            Message("ID_msg_frmLabelPrint_PlsSelectOrInputPrintNumber", True, "包装数量输入不正确，请重新输入!")
            txtPackageNumber.Focus()
            Return inputCheck
        End If
        'get product code
        If InStrRev(sku_no.Text, "|") = 0 Then
            skuno = Trim(sku_no.Text)
        Else
            skuno = Trim(Mid(sku_no.Text, 1, InStrRev(sku_no.Text, "|") - 1))
        End If
        inputCheck = True
        Return inputCheck
    End Function

    Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnEnter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnter.Click
        Try
            If inputCheck() Then
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                btnEnter.Enabled = False
                Application.DoEvents()
                mRptSet.DirectPrint = Not cbxPreview.Checked
                If (Me.LableType = "PO") Then
                    mRptSet.FileName = "Rpt_PO_LabelPrint.rpt"
                ElseIf (Me.LableType = "WO") Then
                    mRptSet.FileName = "Rpt_LabelPrint.rpt"
                End If

                mRptSet.Title = Me.Text
                LoadPara()
                ' Me.Close()
                LoadRptViewer(mParaList, mRptSet)
                Me.Cursor = System.Windows.Forms.Cursors.Default
                Status()
            Else
                Me.DialogResult = Nothing
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub convertDate()
        Try
            Dim Month As String
            Dim Year As String
            Month = Format(Now, "MM")
            Year = Format(Now, "yyyy").Substring(3, 1)
            Select Case Month
                Case "01"
                    Fdata = "A" + Year + "S"
                Case "02"
                    Fdata = "C" + Year + "S"
                Case "03"
                    Fdata = "D" + Year + "S"
                Case "04"
                    Fdata = "E" + Year + "S"
                Case "05"
                    Fdata = "F" + Year + "S"
                Case "06"
                    Fdata = "G" + Year + "S"
                Case "07"
                    Fdata = "H" + Year + "S"
                Case "08"
                    Fdata = "I" + Year + "S"
                Case "09"
                    Fdata = "J" + Year + "S"
                Case "10"
                    Fdata = "K" + Year + "S"
                Case "11"
                    Fdata = "L" + Year + "S"
                Case "12"
                    Fdata = "M" + Year + "S"
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub LoadPara()
        For Each con As Control In Me.SCondition.Controls
            ' If Not con.Tag Is Nothing Then
            Select Case con.GetType.Name
                Case "ComboBox"
                    mParaList.Add(CType(con, ComboBox).Tag, CType(con, ComboBox).Text)
                    If InStrRev(sku_no.Text, "|") = 0 Then
                        mParaList.Add("@sku_no", Trim(sku_no.Text))
                    Else
                        mParaList.Add("@sku_no", Trim(Mid(sku_no.Text, 1, InStrRev(sku_no.Text, "|") - 1)))
                    End If
            End Select
            If (mParaList.ContainsKey("@qty") = False) Then
                mParaList.Add("@qty", Me.txtPackageNumber.Text.ToString)
            End If
            If (mParaList.ContainsKey("@v_up") = False) Then
                If v_up = Nothing Then
                    v_up = " "
                End If
                mParaList.Add("@v_up", Me.v_up)
            End If
            If (mParaList.ContainsKey("@v_down") = False) Then
                If v_down = Nothing Then
                    v_down = " "
                End If
                mParaList.Add("@v_down", Me.v_down)
            End If
            If (mParaList.ContainsKey("@v_left") = False) Then
                If v_left = Nothing Then
                    v_left = " "
                End If
                mParaList.Add("@v_left", Me.v_left)
            End If
            If (mParaList.ContainsKey("@v_right") = False) Then
                If v_right = Nothing Then
                    v_right = " "
                End If
                mParaList.Add("@v_right", Me.v_right)
            End If
            If (mParaList.ContainsKey("@Fdata") = False) Then
                mParaList.Add("@Fdata", Fdata)
            End If
        Next

    End Sub

    Public Sub LoadRptViewer(ByVal para As Hashtable, ByVal setting As ReportSetting)
        frmRpt = New frmRptViewer(para, setting)
        frmRpt.MdiParent = MainForm
        Dim numbers As Int32
        If mRptSet.DirectPrint Then
            Try
                numbers = System.Convert.ToDecimal(txtPrintNumber.Text)
            Catch ex As Exception
                numbers = 1
            Finally
                frmRpt.DirectPrintNumReport(numbers, Me)
            End Try
        Else
            frmRpt.StartPosition = FormStartPosition.CenterParent
            'frmRpt.WindowState = FormWindowState.Maximized
            frmRpt.Show()
            System.Threading.Thread.Sleep(500)
            Application.DoEvents()
        End If
    End Sub

    Private Sub rbtnEveryDay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReturnBillList()
    End Sub

    Private Sub rbtnEveryWeek_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReturnBillList()
    End Sub

    Private Sub rbtnEveryMonth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReturnBillList()
    End Sub

    Private Sub rbtnCustomDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnCustomDate.CheckedChanged
        ReturnBillList()
        With Me
            .dtpDateStart.Enabled = .rbtnCustomDate.Checked
            .dtpDateEnd.Enabled = .rbtnCustomDate.Checked
        End With
    End Sub

    Private Sub dtpDateStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateStart.ValueChanged
        ReturnBillList()
    End Sub

    Private Sub dtpDateEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateEnd.ValueChanged
        ReturnBillList()
    End Sub

    Private Sub ro_no_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ro_no.TextChanged
        If ro_no.Text <> "" Then
            ReturnSkuNo()
        End If
    End Sub

    Private Sub sku_no_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles sku_no.TextChanged
        If sku_no.Text <> "" Then
            ReturnItemNumbers()
        End If
    End Sub

    Private Sub frmLabelPrint_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        TimerClose.Enabled = False
    End Sub

    Private Sub TimerClose_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerClose.Tick
        'TimerClose.Enabled = False
        'Me.DialogResult = DialogResult.Abort
        'Me.Close()
    End Sub
End Class
