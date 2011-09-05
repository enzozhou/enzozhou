Imports ImportExport
Imports YT
Imports YT.BusinessObject

Public Class frmExportCon
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents groupOption As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowsePath As System.Windows.Forms.Button
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents lblFileType As System.Windows.Forms.Label
    Friend WithEvents cboFileType As System.Windows.Forms.ComboBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxCompany As System.Windows.Forms.ComboBox
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents gbxTimes As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtEndTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents gbxBchNo As System.Windows.Forms.GroupBox
    Friend WithEvents gubBoxCarrier As System.Windows.Forms.GroupBox
    Friend WithEvents rdbNoSelect As System.Windows.Forms.RadioButton
    Friend WithEvents rdbManyCarrier As System.Windows.Forms.RadioButton
    Friend WithEvents clbCarrierList As System.Windows.Forms.CheckedListBox
    Friend WithEvents butOkCarrier As System.Windows.Forms.Button
    Friend WithEvents butAllCarrier As System.Windows.Forms.Button
    Friend WithEvents butCancelCarrier As System.Windows.Forms.Button
    Friend WithEvents butnAll As System.Windows.Forms.Button
    Friend WithEvents butnCancel As System.Windows.Forms.Button
    Friend WithEvents cboBchNo As System.Windows.Forms.CheckedListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.groupOption = New System.Windows.Forms.GroupBox
        Me.btnBrowsePath = New System.Windows.Forms.Button
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.lblPath = New System.Windows.Forms.Label
        Me.lblFilename = New System.Windows.Forms.Label
        Me.lblFileType = New System.Windows.Forms.Label
        Me.cboFileType = New System.Windows.Forms.ComboBox
        Me.cbxCompany = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.lblCaption = New System.Windows.Forms.Label
        Me.gbxTimes = New System.Windows.Forms.GroupBox
        Me.dtEndTime = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtStartTime = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.gbxBchNo = New System.Windows.Forms.GroupBox
        Me.butnCancel = New System.Windows.Forms.Button
        Me.butnAll = New System.Windows.Forms.Button
        Me.cboBchNo = New System.Windows.Forms.CheckedListBox
        Me.gubBoxCarrier = New System.Windows.Forms.GroupBox
        Me.butCancelCarrier = New System.Windows.Forms.Button
        Me.butAllCarrier = New System.Windows.Forms.Button
        Me.butOkCarrier = New System.Windows.Forms.Button
        Me.clbCarrierList = New System.Windows.Forms.CheckedListBox
        Me.rdbManyCarrier = New System.Windows.Forms.RadioButton
        Me.rdbNoSelect = New System.Windows.Forms.RadioButton
        Me.groupOption.SuspendLayout()
        Me.gbxTimes.SuspendLayout()
        Me.gbxBchNo.SuspendLayout()
        Me.gubBoxCarrier.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupOption
        '
        Me.groupOption.Controls.Add(Me.btnBrowsePath)
        Me.groupOption.Controls.Add(Me.txtPath)
        Me.groupOption.Controls.Add(Me.txtFileName)
        Me.groupOption.Controls.Add(Me.lblPath)
        Me.groupOption.Controls.Add(Me.lblFilename)
        Me.groupOption.Controls.Add(Me.lblFileType)
        Me.groupOption.Controls.Add(Me.cboFileType)
        Me.groupOption.Location = New System.Drawing.Point(13, 327)
        Me.groupOption.Name = "groupOption"
        Me.groupOption.Size = New System.Drawing.Size(440, 111)
        Me.groupOption.TabIndex = 24
        Me.groupOption.TabStop = False
        Me.groupOption.Text = "文件信息"
        '
        'btnBrowsePath
        '
        Me.btnBrowsePath.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBrowsePath.Location = New System.Drawing.Point(400, 82)
        Me.btnBrowsePath.Name = "btnBrowsePath"
        Me.btnBrowsePath.Size = New System.Drawing.Size(33, 20)
        Me.btnBrowsePath.TabIndex = 7
        Me.btnBrowsePath.Text = "..."
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(88, 82)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(312, 20)
        Me.txtPath.TabIndex = 5
        Me.txtPath.Text = "C:\"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(88, 52)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(344, 20)
        Me.txtFileName.TabIndex = 4
        Me.txtFileName.Text = ""
        '
        'lblPath
        '
        Me.lblPath.Location = New System.Drawing.Point(13, 82)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(67, 23)
        Me.lblPath.TabIndex = 2
        Me.lblPath.Text = "导出路径："
        '
        'lblFilename
        '
        Me.lblFilename.Location = New System.Drawing.Point(13, 52)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(67, 23)
        Me.lblFilename.TabIndex = 1
        Me.lblFilename.Text = "文件名称："
        '
        'lblFileType
        '
        Me.lblFileType.Location = New System.Drawing.Point(13, 22)
        Me.lblFileType.Name = "lblFileType"
        Me.lblFileType.Size = New System.Drawing.Size(67, 23)
        Me.lblFileType.TabIndex = 0
        Me.lblFileType.Text = "文件类型："
        '
        'cboFileType
        '
        Me.cboFileType.Enabled = False
        Me.cboFileType.Items.AddRange(New Object() {"CSV - Text File"})
        Me.cboFileType.Location = New System.Drawing.Point(88, 22)
        Me.cboFileType.Name = "cboFileType"
        Me.cboFileType.Size = New System.Drawing.Size(344, 21)
        Me.cboFileType.TabIndex = 6
        Me.cboFileType.Text = "CSV - Text File"
        '
        'cbxCompany
        '
        Me.cbxCompany.Location = New System.Drawing.Point(113, 37)
        Me.cbxCompany.Name = "cbxCompany"
        Me.cbxCompany.Size = New System.Drawing.Size(320, 21)
        Me.cbxCompany.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(27, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 21)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "运输公司："
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Location = New System.Drawing.Point(273, 438)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 32)
        Me.btnClose.TabIndex = 23
        Me.btnClose.Text = "关闭"
        '
        'btnOK
        '
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Location = New System.Drawing.Point(133, 438)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 32)
        Me.btnOK.TabIndex = 22
        Me.btnOK.Text = "导出"
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(13, 7)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(440, 16)
        Me.lblCaption.TabIndex = 25
        '
        'gbxTimes
        '
        Me.gbxTimes.Controls.Add(Me.dtEndTime)
        Me.gbxTimes.Controls.Add(Me.Label3)
        Me.gbxTimes.Controls.Add(Me.dtStartTime)
        Me.gbxTimes.Controls.Add(Me.Label2)
        Me.gbxTimes.Location = New System.Drawing.Point(13, 30)
        Me.gbxTimes.Name = "gbxTimes"
        Me.gbxTimes.Size = New System.Drawing.Size(440, 52)
        Me.gbxTimes.TabIndex = 26
        Me.gbxTimes.TabStop = False
        Me.gbxTimes.Text = "批时间(按工作日)"
        '
        'dtEndTime
        '
        Me.dtEndTime.CustomFormat = "yyyy-MM-dd"
        Me.dtEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEndTime.Location = New System.Drawing.Point(313, 22)
        Me.dtEndTime.Name = "dtEndTime"
        Me.dtEndTime.Size = New System.Drawing.Size(114, 20)
        Me.dtEndTime.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(233, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 22)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "结束时间："
        '
        'dtStartTime
        '
        Me.dtStartTime.CustomFormat = "yyyy-MM-dd"
        Me.dtStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtStartTime.Location = New System.Drawing.Point(107, 22)
        Me.dtStartTime.Name = "dtStartTime"
        Me.dtStartTime.Size = New System.Drawing.Size(106, 20)
        Me.dtStartTime.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(13, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 22)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "开始时间："
        '
        'gbxBchNo
        '
        Me.gbxBchNo.Controls.Add(Me.butnCancel)
        Me.gbxBchNo.Controls.Add(Me.butnAll)
        Me.gbxBchNo.Controls.Add(Me.cboBchNo)
        Me.gbxBchNo.Location = New System.Drawing.Point(13, 215)
        Me.gbxBchNo.Name = "gbxBchNo"
        Me.gbxBchNo.Size = New System.Drawing.Size(440, 112)
        Me.gbxBchNo.TabIndex = 27
        Me.gbxBchNo.TabStop = False
        Me.gbxBchNo.Text = "批号选择"
        '
        'butnCancel
        '
        Me.butnCancel.Location = New System.Drawing.Point(27, 67)
        Me.butnCancel.Name = "butnCancel"
        Me.butnCancel.Size = New System.Drawing.Size(62, 21)
        Me.butnCancel.TabIndex = 4
        Me.butnCancel.Text = "取消全选"
        '
        'butnAll
        '
        Me.butnAll.Location = New System.Drawing.Point(27, 30)
        Me.butnAll.Name = "butnAll"
        Me.butnAll.Size = New System.Drawing.Size(62, 21)
        Me.butnAll.TabIndex = 3
        Me.butnAll.Text = "全 选"
        '
        'cboBchNo
        '
        Me.cboBchNo.HorizontalScrollbar = True
        Me.cboBchNo.Location = New System.Drawing.Point(127, 15)
        Me.cboBchNo.Name = "cboBchNo"
        Me.cboBchNo.Size = New System.Drawing.Size(300, 94)
        Me.cboBchNo.TabIndex = 0
        '
        'gubBoxCarrier
        '
        Me.gubBoxCarrier.Controls.Add(Me.butCancelCarrier)
        Me.gubBoxCarrier.Controls.Add(Me.butAllCarrier)
        Me.gubBoxCarrier.Controls.Add(Me.butOkCarrier)
        Me.gubBoxCarrier.Controls.Add(Me.clbCarrierList)
        Me.gubBoxCarrier.Controls.Add(Me.rdbManyCarrier)
        Me.gubBoxCarrier.Controls.Add(Me.rdbNoSelect)
        Me.gubBoxCarrier.Controls.Add(Me.Label1)
        Me.gubBoxCarrier.Controls.Add(Me.cbxCompany)
        Me.gubBoxCarrier.Location = New System.Drawing.Point(13, 82)
        Me.gubBoxCarrier.Name = "gubBoxCarrier"
        Me.gubBoxCarrier.Size = New System.Drawing.Size(440, 126)
        Me.gubBoxCarrier.TabIndex = 28
        Me.gubBoxCarrier.TabStop = False
        Me.gubBoxCarrier.Text = "选择运输公司"
        '
        'butCancelCarrier
        '
        Me.butCancelCarrier.Location = New System.Drawing.Point(27, 67)
        Me.butCancelCarrier.Name = "butCancelCarrier"
        Me.butCancelCarrier.Size = New System.Drawing.Size(62, 21)
        Me.butCancelCarrier.TabIndex = 12
        Me.butCancelCarrier.Text = "全取消"
        '
        'butAllCarrier
        '
        Me.butAllCarrier.Location = New System.Drawing.Point(27, 37)
        Me.butAllCarrier.Name = "butAllCarrier"
        Me.butAllCarrier.Size = New System.Drawing.Size(62, 21)
        Me.butAllCarrier.TabIndex = 11
        Me.butAllCarrier.Text = "全  选"
        '
        'butOkCarrier
        '
        Me.butOkCarrier.Location = New System.Drawing.Point(27, 97)
        Me.butOkCarrier.Name = "butOkCarrier"
        Me.butOkCarrier.Size = New System.Drawing.Size(62, 21)
        Me.butOkCarrier.TabIndex = 10
        Me.butOkCarrier.Text = "查询批"
        '
        'clbCarrierList
        '
        Me.clbCarrierList.HorizontalScrollbar = True
        Me.clbCarrierList.Location = New System.Drawing.Point(127, 37)
        Me.clbCarrierList.Name = "clbCarrierList"
        Me.clbCarrierList.Size = New System.Drawing.Size(300, 79)
        Me.clbCarrierList.TabIndex = 3
        '
        'rdbManyCarrier
        '
        Me.rdbManyCarrier.Location = New System.Drawing.Point(253, 7)
        Me.rdbManyCarrier.Name = "rdbManyCarrier"
        Me.rdbManyCarrier.Size = New System.Drawing.Size(87, 23)
        Me.rdbManyCarrier.TabIndex = 1
        Me.rdbManyCarrier.Text = "多选公司"
        '
        'rdbNoSelect
        '
        Me.rdbNoSelect.Checked = True
        Me.rdbNoSelect.Location = New System.Drawing.Point(107, 7)
        Me.rdbNoSelect.Name = "rdbNoSelect"
        Me.rdbNoSelect.Size = New System.Drawing.Size(86, 23)
        Me.rdbNoSelect.TabIndex = 0
        Me.rdbNoSelect.TabStop = True
        Me.rdbNoSelect.Text = "单选公司"
        '
        'frmExportCon
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(466, 473)
        Me.Controls.Add(Me.gubBoxCarrier)
        Me.Controls.Add(Me.gbxBchNo)
        Me.Controls.Add(Me.gbxTimes)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.groupOption)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOK)
        Me.Name = "frmExportCon"
        Me.Text = "frmExportCon(to PF)"
        Me.groupOption.ResumeLayout(False)
        Me.gbxTimes.ResumeLayout(False)
        Me.gbxBchNo.ResumeLayout(False)
        Me.gubBoxCarrier.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private mstrCaption As String = ""
    Private mExportFileName As String = ""
    Private mExportBchNo As String = ""

    Private lookup As New Lookup
    Private DefualtExpUrl As String = ""
    Private rs As New DataSet
    Dim ds As New DataSet
    Dim an As New DataSet

    '文件名
    Public ReadOnly Property ExportFileName() As String
        Get
            Return mExportFileName
        End Get
    End Property
    '发货批号
    Public ReadOnly Property ExportBchNo() As String
        Get
            Return mExportBchNo
        End Get
    End Property
    Public Property CaptionText() As String
        Get
            Return mstrCaption
        End Get
        Set(ByVal Value As String)
            mstrCaption = Value
        End Set
    End Property

    Private Function GetFileType() As String
        Return ".csv"
    End Function

    Private Sub btnBrowsePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowsePath.Click

        Try
            If Trim(txtPath.Text) <> "" Then
                FolderBrowserDialog1.SelectedPath = txtPath.Text
            End If

            If FolderBrowserDialog1.ShowDialog(Me) <> DialogResult.OK Then
                Return
            End If
            txtPath.Text = FolderBrowserDialog1.SelectedPath
        Catch ex As Exception
            ErrorMsg(ex, ex.GetType, "btnBrowsePath_Click")
        End Try
    End Sub

    Private Function GetFileNameWithType() As String
        Dim vFile As String
        vFile = Trim(Me.txtFileName.Text)
        If vFile.LastIndexOf(".") > 0 Then
            Return vFile
        Else
            Return vFile + GetFileType()
        End If
    End Function

    Private Function GetFileName() As String
        Dim strPath As String
        Dim vFile As String
        strPath = Trim(Me.txtPath.Text)
        If Microsoft.VisualBasic.Right(strPath, 1) = "\" Then
            vFile = Me.txtPath.Text + GetFileNameWithType() 'Me.txtFileName.Text '+ GetFileType()
        Else
            vFile = Me.txtPath.Text + "\" + GetFileNameWithType() 'Me.txtFileName.Text '+ GetFileType()
        End If
        Return vFile
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim strPath As String
        mExportFileName = GetFileName()
        Dim i As Integer
        Dim bchNo As String = ""
        bchNo = ""
        Try
            If Me.rdbNoSelect.Checked = True Then
                For i = 0 To cboBchNo.Items.Count - 1
                    If Me.cboBchNo.GetItemChecked(i) Then
                        If (an.Tables(0).Rows.Count > 0) Then
                            If an.Tables(0).Rows(i).Item(0) <> "" Then
                                bchNo = bchNo + "-" + an.Tables(0).Rows(i).Item(0)
                            End If
                        End If
                    End If
                Next
            End If
            If Me.rdbManyCarrier.Checked = True Then
                For i = 0 To cboBchNo.Items.Count - 1
                    If Me.cboBchNo.GetItemChecked(i) Then
                        If (an.Tables(0).Rows.Count > 0) Then
                            If an.Tables(0).Rows(i).Item(0) <> "" Then
                                bchNo = bchNo + "-" + an.Tables(0).Rows(i).Item(0)
                            End If
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If bchNo = "" Then
            MsgBox("请选择发货批号！")
            Return
        End If
        Me.mExportBchNo = bchNo

        'If Me.cbxCompany.SelectedIndex = -1 Then
        '    Me.cbxCompany.Text = "0"
        'ElseIf InStrRev(Me.cbxCompany.Text, "|") <> 0 Then
        '    Me.cbxCompany.Text = Mid(Me.cbxCompany.Text, 1, InStrRev(Me.cbxCompany.Text, "|") - 1)
        'End If
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub frmExportCon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtEndTime.Value = Now
        Me.dtStartTime.Value = Now
        SetFormResource(Me)
        lblCaption.Text = mstrCaption
        '设置运输公司下拉框中的值
        setCarrValues()
        rs = lookup.SQLToDataSet("select value from Sysoption where opt_group='100' and opt_code='113' and sub_code='global'")
        If (rs.Tables(0).Rows.Count > 0) Then
            Try
                If rs.Tables(0).Rows(0).Item(0) <> "" Then
                    Me.txtPath.Text = rs.Tables(0).Rows(0).Item(0)
                End If
            Catch ex As Exception
            End Try
        End If
        'Me.Width = 568
        Me.Height = 494
        'gubBoxCarrier.Width = 526
        gubBoxCarrier.Height = 80
        btnOK.Location = New Point(160, 422)
        Me.btnClose.Location = New Point(328, 422)
    End Sub
    '设置运输公司下拉框中的值
    Private Sub setCarrValues()
        Me.cbxCompany.Items.Clear()
        Me.cbxCompany.Text = ""
        'Dim ds As DataSet
        Dim i As Integer

        Dim dtStart As DateTime
        Dim dtEnd As DateTime
        Dim CutOff As Integer
        CutOff = GetSysTimeCutOff()
        dtStart = dtStartTime.Value.Date
        dtStart = DateAdd(DateInterval.Hour, CutOff, dtStart)
        dtEnd = DateAdd(DateInterval.Day, 1, Me.dtEndTime.Value.Date)
        dtEnd = DateAdd(DateInterval.Hour, CutOff, dtEnd)

        'ds = lookup.SQLToDataSet("select distinct b.carr_code,b.carr_code+'|'+b.carr_name from bchhdr a left join carrier b on a.carr_code=b.carr_code where a.due_date between '" + Me.dtStartTime.Value().ToString("yyyy-MM-dd") + "' and '" + Me.dtEndTime.Value.AddDays(1).ToString("yyyy-MM-dd") + "' and a.bch_type='001' and a.bch_no is not null order by b.carr_code+'|'+b.carr_name")
        ds = lookup.SQLToDataSet("select carr_code,carr_code+'  |  ' + carr_name  from carrier where carr_code in (select carr_code from bchhdr where bch_type='001' and due_date between '" + dtStart.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "')")
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Me.cbxCompany.Items.Add(ds.Tables(0).Rows(i).Item(1))
            Next
            Me.cbxCompany.SelectedIndex = 0
            '根据运输公司显示发货批号
            'setBchNo()
        Else
            Me.cbxCompany.Text = "该时间段内没有运输公司"
        End If
        Me.clbCarrierList.DataSource = ds.Tables(0).DefaultView
        Me.clbCarrierList.DisplayMember = ds.Tables(0).Columns(1).ColumnName
        Me.clbCarrierList.ValueMember = ds.Tables(0).Columns(0).ColumnName
    End Sub

    '根据运输公司显示发货批号
    Private Sub setBchNo()
        'Me.clbBchNo.Items.Clear()
        Dim i As Integer
        Dim carrCode As String

        Dim dtStart As DateTime
        Dim dtEnd As DateTime
        Dim CutOff As Integer
        CutOff = GetSysTimeCutOff()
        dtStart = dtStartTime.Value.Date
        dtStart = DateAdd(DateInterval.Hour, CutOff, dtStart)
        dtEnd = DateAdd(DateInterval.Day, 1, Me.dtEndTime.Value.Date)
        dtEnd = DateAdd(DateInterval.Hour, CutOff, dtEnd)

        If Me.cbxCompany.SelectedIndex = -1 Then
            an = lookup.SQLToDataSet("select distinct bch_no,bch_no+'|'+description from bchhdr where due_date between '" + dtStart.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "' and bch_type='001' and bch_no is not null order by bch_no")
        Else
            carrCode = Trim(Mid(Me.cbxCompany.Text, 1, InStrRev(Me.cbxCompany.Text, "|") - 1))
            an = lookup.SQLToDataSet("select distinct bch_no,bch_no+'|'+description from bchhdr where due_date between '" + dtStart.ToString("yyyy-MM-dd HH:mm:ss") + "' and '" + dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "' and carr_code='" + carrCode + "' and bch_type='001' and bch_no is not null order by bch_no")
        End If
        'if me.rdbNoSelect.Checked =True 
        Me.cboBchNo.DataSource = an.Tables(0).DefaultView
        Me.cboBchNo.DisplayMember = an.Tables(0).Columns(1).ColumnName
        Me.cboBchNo.ValueMember = an.Tables(0).Columns(0).ColumnName
    End Sub


    Private Sub dtStartTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtStartTime.ValueChanged
        '设置运输公司下拉框中的值
        setCarrValues()
    End Sub

    Private Sub dtEndTime_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtEndTime.ValueChanged
        '设置运输公司下拉框中的值
        setCarrValues()
    End Sub

    Private Sub cbxCompany_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxCompany.SelectedIndexChanged
        '根据运输公司显示发货批号
        If Me.rdbNoSelect.Checked = True Then
            setBchNo()
        End If
    End Sub
    '多选公司
    Private Sub rdbManyCarrier_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbManyCarrier.CheckedChanged
        Dim ns As DataSet
        ns = lookup.SQLToDataSet("select bch_no,description from bchhdr where status_code='0000'")
        If Me.rdbManyCarrier.Checked = True Then
            Me.cboBchNo.DataSource = ns.Tables(0).DefaultView
            Me.cboBchNo.DisplayMember = ""
            Me.cboBchNo.ValueMember = ""
            'Try
            '    Me.clbBchNo.Items.Clear()
            'Catch ex As Exception
            '    'MsgBox(ex.Message)
            'End Try
            Me.cbxCompany.Visible = False
            Me.Label1.Visible = False
            Me.butAllCarrier.Visible = True
            Me.butCancelCarrier.Visible = True
            Me.clbCarrierList.Visible = True
            'gubBoxCarrier.Location = New Point(16, 90)
            'gubBoxCarrier.Width = 526
            gubBoxCarrier.Height = 138
            gbxBchNo.Location = New Point(16, 232)
            groupOption.Location = New Point(16, 352)
            btnOK.Location = New Point(160, 472)
            Me.btnClose.Location = New Point(328, 472)
            'Me.Width = 568
            Me.Height = 544
        End If
    End Sub
    '单选公司
    Private Sub rdbNoSelect_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbNoSelect.CheckedChanged
        If Me.rdbNoSelect.Checked = True Then
            Me.cbxCompany.Visible = True
            Me.Label1.Visible = True
            Me.butAllCarrier.Visible = False
            Me.butCancelCarrier.Visible = False
            Me.clbCarrierList.Visible = False
            'gubBoxCarrier.Location = New Point(16, 88)
            'gubBoxCarrier.Width = 526
            gubBoxCarrier.Height = 80
            gbxBchNo.Location = New Point(16, 174)
            groupOption.Location = New Point(16, 294)
            btnOK.Location = New Point(160, 422)
            Me.btnClose.Location = New Point(328, 422)
            'Me.Width = 568
            Me.Height = 494
            setBchNo()
        End If
    End Sub
    '根据多选公司显示发货批号
    Private Sub setManyBchNo(ByVal manycarrcode As String)
        'Me.clbBchNo.Items.Clear()
        Dim i As Integer
        Dim carrCode As String

        Dim dtStart As DateTime
        Dim dtEnd As DateTime
        Dim CutOff As Integer
        CutOff = GetSysTimeCutOff()
        dtStart = dtStartTime.Value.Date
        dtStart = DateAdd(DateInterval.Hour, CutOff, dtStart)
        dtEnd = DateAdd(DateInterval.Day, 1, Me.dtEndTime.Value.Date)
        dtEnd = DateAdd(DateInterval.Hour, CutOff, dtEnd)

        'If Me.cbxCompany.SelectedIndex = -1 Then
        '    rs = lookup.SQLToDataSet("select distinct bch_no,bch_no+'|'+description from bchhdr where due_date between '" + Me.dtStartTime.Value().ToString("yyyy-MM-dd") + "' and '" + Me.dtEndTime.Value.AddDays(1).ToString("yyyy-MM-dd") + "' and bch_type='001' and bch_no is not null order by bch_no")
        'Else
        '    carrCode = Mid(Me.cbxCompany.Text, 1, InStrRev(Me.cbxCompany.Text, "|") - 1)
        '    rs = lookup.SQLToDataSet("select distinct bch_no,bch_no+'|'+description from bchhdr where due_date between '" + Me.dtStartTime.Value().ToString("yyyy-MM-dd") + "' and '" + Me.dtEndTime.Value.AddDays(1).ToString("yyyy-MM-dd") + "' and carr_code='" + carrCode + "' and bch_type='001' and bch_no is not null order by bch_no")
        'End If
        an = lookup.SQLToDataSet("stp_get_LoadBatchListByCarrier '" + UserRightMgr.gDcCode + "','" + manycarrcode + "','" + dtStart.ToString("yyyy-MM-dd HH:mm:ss") + "','" + dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'")
        Me.cboBchNo.DisplayMember = an.Tables(0).Columns(1).ColumnName
        Me.cboBchNo.ValueMember = an.Tables(0).Columns(0).ColumnName
        Me.cboBchNo.DataSource = an.Tables(0).DefaultView
    End Sub
    '确定公司
    Private Sub butOkCarrier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOkCarrier.Click
        Dim manyCarrCode As String
        manyCarrCode = ""
        'Dim dg As DataSet()
        Dim i As Integer
        For i = 0 To Me.clbCarrierList.Items.Count - 1
            If Me.clbCarrierList.GetItemChecked(i) Then
                If (ds.Tables(0).Rows.Count > 0) Then
                    If ds.Tables(0).Rows(i).Item(0) <> "" Then
                        manyCarrCode = manyCarrCode + "-" + ds.Tables(0).Rows(i).Item(0)
                    End If
                End If
            End If
        Next
        If manyCarrCode = "" Then
            MsgBox("请选择公司！")
            Return
        End If
        setManyBchNo(manyCarrCode)
    End Sub
    '公司全选
    Private Sub butAllCarrier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAllCarrier.Click
        Dim i As Integer
        Try
            If Me.clbCarrierList.Items.Count > 0 Then
                If Me.clbCarrierList.Items.Count > 20 Then
                    MsgBox("选中的数量不能超过20！")
                    For i = 0 To 19
                        Me.clbCarrierList.SetItemChecked(i, True)
                    Next
                Else
                    For i = 0 To Me.clbCarrierList.Items.Count - 1
                        'Me.clbCarrierList.Items.Item(i) = True
                        Me.clbCarrierList.SetItemChecked(i, True)
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    '公司取消选择
    Private Sub butCancelCarrier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCancelCarrier.Click
        Dim i As Integer
        For i = 0 To Me.clbCarrierList.Items.Count - 1
            Me.clbCarrierList.SetItemChecked(i, False)
        Next
    End Sub
    ' 发货批号全选
    Private Sub butnAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butnAll.Click
        Dim i As Integer
        Try
            If Me.cboBchNo.Items.Count > 0 Then
                If Me.cboBchNo.Items.Count > 20 Then
                    MsgBox("选中的数量不能超过20！")
                    For i = 0 To 19
                        Me.cboBchNo.SetItemChecked(i, True)
                    Next
                Else
                    For i = 0 To Me.cboBchNo.Items.Count - 1
                        Me.cboBchNo.SetItemChecked(i, True)
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    '发货批号取消全选
    Private Sub butnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butnCancel.Click
        Dim i As Integer
        For i = 0 To Me.cboBchNo.Items.Count - 1
            Me.cboBchNo.SetItemChecked(i, False)
        Next
    End Sub
End Class
