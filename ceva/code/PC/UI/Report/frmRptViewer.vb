Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections
Imports System.Collections.Specialized
Imports COMExpress.Windows.Forms
Imports COMExpress.UserInterface.Layout
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.IO
Imports WMS.BusinessObject

Imports COMExpress.BusinessObject
Imports System.Reflection

Public Class frmRptViewer
    'Inherits System.Windows.Forms.Form
    Inherits CXPrintForm
    'Inherits CXBaseForm
    'Implements IToolbarHost

    Private ArgList As Hashtable
    Private mRptSet As ReportSetting
    Private rpt As ReportDocument
    Public PrnDisabled As Boolean = False
    Public Load_All_DataFlag As Boolean = False

    ' added by Jim fang start
    Public printer As String = ""
    'bxzhang 2008-09-17
    Private mDataSet As DataSet

    Public ProceName As String() = Nothing
    Public number As Integer

    Public Property printerName() As String
        Get
            Return printer
        End Get
        Set(ByVal Value As String)
            printer = Value
        End Set
    End Property
    ' added by Jim fang end


    Private mbolCanceled As Boolean = False
    Private mbolSet As Boolean = False
    Private mobjPrinterSettings As System.Drawing.Printing.PrinterSettings = Nothing
    Private mobjPageSettings As System.Drawing.Printing.PageSettings = Nothing
    Public Sub SetPrinterSettings(ByVal objPrinterSettings As System.Drawing.Printing.PrinterSettings, ByVal objPageSettings As System.Drawing.Printing.PageSettings)
        If objPrinterSettings Is Nothing Then
            Exit Sub
        End If
        If objPageSettings Is Nothing Then
            Exit Sub
        End If
        mbolSet = True
        mobjPrinterSettings = objPrinterSettings
        mobjPageSettings = objPageSettings
    End Sub

    Public ReadOnly Property PrinterSettings() As System.Drawing.Printing.PrinterSettings
        Get
            Return mobjPrinterSettings
        End Get
    End Property
    Public ReadOnly Property PageSettings() As System.Drawing.Printing.PageSettings
        Get
            Return mobjPageSettings
        End Get
    End Property

    Public ReadOnly Property Canceled() As Boolean
        Get
            Return mbolCanceled
        End Get
    End Property

    Private Enum FileType
        Word = 0
        Excel = 1
        PDF = 2
        HTML = 3
        Text = 4
    End Enum

    Private typeLastName() As String = New String() {"doc", "xls", "pdf", "html", "txt"}

#Region " Windows 窗体设计器生成的代码 "
    'bxzhang 2008-09-17  , ByVal Ds As DataSet   ,mDataSet = Ds
    Public Sub New(ByVal args As Hashtable, ByVal rptSet As ReportSetting) ', ByVal Ds As DataSet)
        MyBase.New()

        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        '在 InitializeComponent() 调用之后添加任何初始化
        ArgList = args
        mRptSet = rptSet

        '  mDataSet = Ds

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
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents timPrint As System.Windows.Forms.Timer
    Friend WithEvents CtlRptViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents cbxFileType As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TimerResize As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptViewer))
        Me.btnExport = New System.Windows.Forms.Button
        Me.CtlRptViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.btnClose = New System.Windows.Forms.Button
        Me.timPrint = New System.Windows.Forms.Timer(Me.components)
        Me.cbxFileType = New System.Windows.Forms.ComboBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TimerResize = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CB
        '
        Me.CB.Size = New System.Drawing.Size(805, 34)
        Me.CB.TabIndex = 1
        Me.CB.Visible = False
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(0, 0)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(67, 24)
        Me.btnExport.TabIndex = 2
        Me.btnExport.Text = "Export"
        '
        'CtlRptViewer
        '
        Me.CtlRptViewer.ActiveViewIndex = -1
        Me.CtlRptViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CtlRptViewer.DisplayGroupTree = False
        Me.CtlRptViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CtlRptViewer.EnableDrillDown = False
        Me.CtlRptViewer.Location = New System.Drawing.Point(0, 34)
        Me.CtlRptViewer.Name = "CtlRptViewer"
        Me.CtlRptViewer.SelectionFormula = ""
        Me.CtlRptViewer.ShowExportButton = False
        Me.CtlRptViewer.ShowRefreshButton = False
        Me.CtlRptViewer.Size = New System.Drawing.Size(805, 462)
        Me.CtlRptViewer.TabIndex = 0
        Me.CtlRptViewer.ViewTimeSelectionFormula = ""
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(221, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(77, 24)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.Visible = False
        '
        'timPrint
        '
        Me.timPrint.Interval = 500
        '
        'cbxFileType
        '
        Me.cbxFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxFileType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.cbxFileType.Items.AddRange(New Object() {"Excel", "HTML", "PDF", "Text", "Word"})
        Me.cbxFileType.Location = New System.Drawing.Point(67, 0)
        Me.cbxFileType.Name = "cbxFileType"
        Me.cbxFileType.Size = New System.Drawing.Size(154, 20)
        Me.cbxFileType.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Controls.Add(Me.cbxFileType)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Location = New System.Drawing.Point(96, 164)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(298, 26)
        Me.Panel1.TabIndex = 3
        Me.Panel1.Visible = False
        '
        'TimerResize
        '
        '
        'frmRptViewer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(805, 496)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CtlRptViewer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRptViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmRptViewer"
        Me.Controls.SetChildIndex(Me.CB, 0)
        Me.Controls.SetChildIndex(Me.CtlRptViewer, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub LoadViewerAgr()

        LoadRptArg()
        Me.CtlRptViewer.ReportSource = rpt
        If mRptSet.DirectPrint Then
            'Me.Visible = False
            'Application.DoEvents()
            'Me.CtlRptViewer.PrintReport()
            Me.timPrint.Enabled = True
        Else
            'Me.CtlRptViewer.ReportSource = rpt
        End If
        '
        'rpt.Refresh()
    End Sub

    Private WithEvents mCloseTimer As Timer
    Private Sub frmRptViewer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadViewerAgr()
            If mRptSet.DirectPrint Then
                'Me.Close()
                Me.DialogResult = DialogResult.OK
            Else
                Me.Text = mRptSet.Title
            End If

            Me.cbxFileType.SelectedIndex = 4
            Me.CtlRptViewer.ShowPrintButton = Not PrnDisabled
        Catch ex As Exception
            ErrorMsg(ex, Me.GetType, "Report Error")
            mCloseTimer = New Timer
            mCloseTimer.Interval = 500
            mCloseTimer.Enabled = True
        End Try
        Try
            MainForm.StatusBarService.RefreshStatus()
        Catch
        End Try
        'UpdateMenuButton()
        LoadControlText()

    End Sub

    Protected Overrides Function InvokeToolAction(ByVal ToolKey As String, Optional ByVal Pushed As Boolean = False, Optional ByVal CustomArgs As Object = Nothing) As Boolean
        Select Case ToolKey
            Case BK_PRINT
                DirectPrintReport(Nothing)
                Return True
            Case Else
        End Select
        Return MyBase.InvokeToolAction(ToolKey, Pushed, CustomArgs)
    End Function

    Private Sub setPictureDataSource()
        Dim dsAHA As DataSet1 = New DataSet1()
        Dim ndr As DataRow = dsAHA.PictureDataTable.NewRow()
        Dim picPath As String
        picPath = Application.StartupPath + "\Report\picture\" + mRptSet.PictureName
        If Trim(Dir(picPath)) = "" Then
            picPath = picPath.Replace("bin\", "")
        End If
        Try
            ndr(0) = ReadImage(picPath)
            dsAHA.PictureDataTable.AddPictureDataTableRow(ndr)
            If (dsAHA.PictureDataTable.Rows.Count >= 1) Then
                rpt.SetDataSource(dsAHA)
                rpt.Refresh()
            End If
        Catch ex As Exception
            Return
        End Try
        
    End Sub
    '从指定路径中读取一个图像文件并保存到字节数组中。
    '此方法供水晶报表显示图片使用，所返回字节数组是 BMP 或 JEPG格式图像数据的数组。
    '<param name="path">指定的文件路径</param>
    '<returns>从图像中读取出的数据。</returns>

    Private Function ReadImage(ByVal path As String) As Byte()
        Dim stream As FileStream = Nothing
        Try
            stream = File.OpenRead(path)
            Return ReadImageStream(stream)
        Catch ex As Exception
            Return Nothing
        Finally
            stream.Close()
        End Try
    End Function

    Private Function ReadImageStream(ByVal vstream As Stream) As Byte()
        Dim image As Image = image.FromStream(vstream)
        Dim myImage As Byte() = Nothing
        If (image.RawFormat.Guid = System.Drawing.Imaging.ImageFormat.Bmp.Guid) Then
            Dim memStream As MemoryStream = New MemoryStream()
            image.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg)
            myImage = memStream.GetBuffer()
            memStream.Close()
        Else
            vstream.Position = 0
            vstream.Read(myImage, 0, vstream.Length)
        End If
        Return myImage
    End Function
    Private Sub mCloseTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles mCloseTimer.Tick
        On Error Resume Next
        mCloseTimer.Enabled = False
        mCloseTimer = Nothing
        Me.Close()
    End Sub

    'Private Sub SetDbConnInfo(ByRef rpt As ReportDocument)
    '    Dim crDatabase As CrystalDecisions.CrystalReports.Engine.Database = rpt.Database
    '    Dim conn As TableLogOnInfo = GetdbConn()
    '    'With conn.ConnectionInfo
    '    'With crDatabase.Tables(0).LogOnInfo.ConnectionInfo
    '    '    .AllowCustomConnection = True
    '    '    .ServerName = conn.ConnectionInfo.ServerName
    '    '    .DatabaseName = conn.ConnectionInfo.DatabaseName
    '    '    .UserID = conn.ConnectionInfo.UserID
    '    '    .Password = conn.ConnectionInfo.Password
    '    'rpt.SetDatabaseLogon(.UserID, .Password, .ServerName, .DatabaseName)
    '    'rpt.DataSourceConnections(0).SetConnection(.ServerName, .DatabaseName, .UserID, .Password)
    '    'rpt.DataSourceConnections(0).SetLogon(.UserID, .Password)
    '    'End With
    '    If Not conn Is Nothing Then
    '        For Each crTable As CrystalDecisions.CrystalReports.Engine.Table In crDatabase.Tables
    '            crTable.LogOnInfo.ConnectionInfo = conn.ConnectionInfo
    '            crTable.ApplyLogOnInfo(conn)
    '        Next
    '    End If
    '    'rpt.VerifyDatabase()
    '    'With conn.ConnectionInfo
    '    '    'rpt.SetDatabaseLogon(.UserID, .Password, .ServerName, .DatabaseName)
    '    '    rpt.DataSourceConnections(0).SetConnection(.ServerName, .DatabaseName, .UserID, .Password)
    '    '    rpt.DataSourceConnections(0).SetLogon(.UserID, .Password)
    '    'End With

    'End Sub

    'Private Sub SetDbConnInfo(ByRef rpt As ReportDocument)
    '    Dim crDatabase As CrystalDecisions.CrystalReports.Engine.Database = rpt.Database
    '    Dim conn As TableLogOnInfo = GetdbConn()
    '    'With conn.ConnectionInfo
    '    'With crDatabase.Tables(0).LogOnInfo.ConnectionInfo
    '    '    .AllowCustomConnection = True
    '    '    .ServerName = conn.ConnectionInfo.ServerName
    '    '    .DatabaseName = conn.ConnectionInfo.DatabaseName
    '    '    .UserID = conn.ConnectionInfo.UserID
    '    '    .Password = conn.ConnectionInfo.Password
    '    'rpt.SetDatabaseLogon(.UserID, .Password, .ServerName, .DatabaseName)
    '    'rpt.DataSourceConnections(0).SetConnection(.ServerName, .DatabaseName, .UserID, .Password)
    '    'rpt.DataSourceConnections(0).SetLogon(.UserID, .Password)
    '    'End With
    '    If Not conn Is Nothing Then
    '        For Each crTable As CrystalDecisions.CrystalReports.Engine.Table In crDatabase.Tables
    '            crTable.LogOnInfo.ConnectionInfo = conn.ConnectionInfo
    '            crTable.ApplyLogOnInfo(conn)
    '        Next
    '    End If
    '    'rpt.VerifyDatabase()
    '    'With conn.ConnectionInfo
    '    '    'rpt.SetDatabaseLogon(.UserID, .Password, .ServerName, .DatabaseName)
    '    '    rpt.DataSourceConnections(0).SetConnection(.ServerName, .DatabaseName, .UserID, .Password)
    '    '    rpt.DataSourceConnections(0).SetLogon(.UserID, .Password)
    '    'End With

    '    ' 2007-08-02, Yu
    '    '- Add code to guarantee the database connection also be done by sub-reports.
    '    Try
    '        If Not rpt.Subreports Is Nothing Then
    '            For Each subrpt As ReportDocument In rpt.Subreports
    '                SetDbConnInfo(subrpt)
    '            Next
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Private Sub SetDbConnInfo(ByRef rpt As ReportDocument)
        ' rpt.SetDataSource(mDataSet)
        '-------------bxzhang 2008-09-26
        If mRptSet.FileName = "Rpt_LabelPrint.rpt" Or mRptSet.FileName = "Rpt_PO_LabelPrint.rpt" Then
            Exit Sub
        End If
        ''-----------------------
        'rpt.SetDataSource(GetDataSet)
        'Try
        '    If Not rpt.Subreports Is Nothing Then
        '        For Each subrpt As ReportDocument In rpt.Subreports
        '            SetDbConnInfo(subrpt)
        '        Next
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub


    Protected Function GetDataSet() As DataSet
        Dim i As Integer
        Dim ds As New DataSet
        For i = 0 To Me.ProceName.Length - 1
            Dim adp As New SqlClient.SqlDataAdapter(MakeCommand(i))
            '  adp.Fill(ds, TableName(i))
            adp.Fill(ds)
            adp.SelectCommand.Connection.Close()
            adp.SelectCommand.Connection.Dispose()
            adp.SelectCommand.Dispose()
            adp.Dispose()
            GC.Collect()
        Next
        'ds.WriteXml("c:\test.xml")
        ' RaiseEvent AfterGetData(ds)
        Return ds
    End Function

    Public Function MakeCommand(ByVal index As Integer) As IDbCommand
        Dim cmd As IDbCommand = DatabaseHelper.CreateDbCommand
        cmd.Connection = DatabaseHelper.CreateDbConnection
        For Each item As DictionaryEntry In Me.ArgList
            'If item.Key.ToString.StartsWith("@") Or item.Key.ToString.StartsWith("#") Then
            If IfParaExit(item.Key, index) Then
                Dim prm As IDbDataParameter = DatabaseHelper.CreateDbParameter
                prm.ParameterName = GetParaName(item.Key)
                prm.DbType = DbType.String
                prm.Direction = ParameterDirection.Input
                prm.Size = 50
                prm.Value = item.Value
                cmd.Parameters.Add(prm)
            End If
        Next
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = Me.ProceName(index)
        cmd.CommandTimeout = ReportCommandTimeout()
        'cmd.Connection.Open()
        DatabaseHelper.OpenConnection(cmd.Connection)
        Return cmd
    End Function

    Public Function GetParaName(ByVal para As String) As String
        Return para.Substring(para.IndexOf("@"))
    End Function

    Public Function IfParaExit(ByVal para As String, ByVal index As Integer) As Boolean
        If para.IndexOf("@") < 0 Then Return False
        Dim str As String = para.Substring(0, para.IndexOf("@"))
        Return str = "" OrElse str.IndexOf(index.ToString) >= 0
    End Function


    Private Function GetdbConn() As TableLogOnInfo

        Dim dbConn As New TableLogOnInfo
        Dim strConn As String = AppDomain.CurrentDomain.GetData("DataSource")
        With dbConn.ConnectionInfo
            ' 2007-08-10, Simon
            ' - For ODBC report, use the database same name as server name for DSN connection
            ' .ServerName = GetString(GetString(strConn, 1, ";"), 2, "=")
            '.ServerName = "WMS"
            '.DatabaseName = "WMS"
            '.UserID = "sa"
            '.AllowCustomConnection = True

            .ServerName = GetString(GetString(strConn, 2, ";"), 2, "=")
            .DatabaseName = GetString(GetString(strConn, 2, ";"), 2, "=")
            .UserID = GetString(GetString(strConn, 3, ";"), 2, "=")
            .AllowCustomConnection = True

            If GetString(strConn, 4, ";") <> "" Then
                .Password = GetString(GetString(strConn, 4, ";"), 2, "=")
            End If
        End With
        Return dbConn
    End Function



    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        'Me.Close()
        'Dim RptConditionForm As New frmRptConditionInput(mRptSet.RptType)
        'RptConditionForm.ShowDialog()
        Dim saveFileDialog1 As New SaveFileDialog
        Dim strfilename As String
        Dim selectedType As FileType
        Dim typeIndex As Integer = selectedType.Parse(GetType(FileType), cbxFileType.Text)
        Dim rtpdocmuent As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Try

            saveFileDialog1.Filter = "*.doc|Word|*.xls|Excel|*.pdf|PDF|*.html|html|*.txt|Text"
            saveFileDialog1.FilterIndex = typeIndex + 1
            saveFileDialog1.RestoreDirectory = True
            saveFileDialog1.FileName = mRptSet.Title

            rtpdocmuent = Me.CtlRptViewer.ReportSource

            If saveFileDialog1.ShowDialog(MainForm) = DialogResult.OK Then
                strfilename = saveFileDialog1.FileName & "." & typeLastName(typeIndex)
                rtpdocmuent.ExportToDisk(GetFileType(typeIndex), strfilename)
                Message("ID_msg_err_RptViewer_ExportSuccess", True, "导出成功")
            End If
        Catch ex As Exception
            ErrorMsg(ex, Me.GetType, "btnExport_Click")
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        rpt.Dispose()
        Me.Close()
    End Sub

    Private Sub timPrint_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timPrint.Tick
        If rpt.HasSavedData Then
            Me.timPrint.Enabled = False
            'MsgBox("Show")
            Me.Load_All_DataFlag = True
            'Me.Close()
            'Dim i As Object = Me.rpt.DataDefinition.SummaryFields(0)
        End If
    End Sub

    Private Sub CtlRptViewer_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CtlRptViewer.ReportRefresh
        'Dim paraList As New ParameterFields
        'For Each arg As DictionaryEntry In ArgList
        '    Dim para As New ParameterField
        '    para.ParameterFieldName = arg.Key
        '    Dim dcValue As New ParameterDiscreteValue
        '    dcValue.Value = arg.Value
        '    para.CurrentValues.Add(dcValue)
        '    paraList.Add(para)
        'Next
        'Me.CtlRptViewer.ParameterFieldInfo = paraList
        LoadRptArg()
    End Sub

    Private Function GetFileType(ByVal selectedIndex As Integer) As CrystalDecisions.[Shared].ExportFormatType
        Dim fileTypeCode As Integer
        Select Case CType(selectedIndex, FileType)
            Case FileType.Excel
                fileTypeCode = 4
            Case FileType.HTML
                fileTypeCode = 7
            Case FileType.PDF
                fileTypeCode = 5
            Case FileType.Text
                fileTypeCode = 9
            Case FileType.Word
                fileTypeCode = 3
        End Select
        Return CType(fileTypeCode, CrystalDecisions.[Shared].ExportFormatType)
    End Function

    Private Function LoadRptArg() As Boolean
        Dim strpath As String



        strpath = Application.StartupPath + "\Report\" + mRptSet.FileName
        If Trim(Dir(strpath)) = "" Then
            strpath = strpath.Replace("bin\", "")
        End If
        rpt = New ReportDocument
        ' rpt.Load(Application.StartupPath + "\Printing\" + mRptSet.FileName)

        rpt.Load(strpath)

        '-------------bxzhang 2008-09-17
        SetDbConnInfo(rpt)
        '-----------------------
        Me.setPictureDataSource()
        Try
            For Each arg As DictionaryEntry In ArgList
                If arg.Value Is DBNull.Value Then
                    Try
                        rpt.SetParameterValue(arg.Key, Nothing)
                    Catch ex As Exception
                    End Try
                Else
                    Try
                        rpt.SetParameterValue(arg.Key, arg.Value)
                    Catch ex As Exception
                    End Try
                End If
            Next
        Catch ex As Exception
            LogMsg(ex, Me.GetType, "LoadRptArg")
        End Try


        'If TypeOf (rpt.ReportDefinition.ReportObjects.Item("Picture3")) Is PictureObject Then
        '    Dim picture As PictureObject
        '    picture = rpt.ReportDefinition.ReportObjects.Item("Picture3")
        'End If


        'For Each ro As ReportObject In rpt.ReportDefinition.ReportObjects
        '    Dim txtobject As CrystalDecisions.CrystalReports.Engine.PictureObject
        '    If (ro.Name = "Picture3") Then

        '    End If
        'Next


        'Dim i As New ParameterField
        'i.Name = "@RecordCount"
        'i.ReportParameterType = ParameterType.StoreProcedureParameter
        'rpt.ParameterFields.Add(i)

        'Dim str As Stream = rpt.ExportToStream(ExportFormatType.Text)
    End Function

    Public Sub DirectPrintReport(ByVal ParentForm As Form)
        Try
            If ParentForm Is Nothing Then
                ParentForm = MainForm
            End If
            LoadRptArg()
            If mbolSet Then             '预置了打印机的参数, 或者上一次已经选择过了, 不用再次选择打印参数
                'rpt.PrintOptions.CopyFrom(Me.mobjPrinterSettings, Me.mobjPageSettings)
                
                rpt.PrintOptions.PrinterName = mobjPrinterSettings.PrinterName
                If mobjPrinterSettings.DefaultPageSettings.Landscape Then
                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
                Else
                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                End If
                'If Me.mstrCustomPaperHeight = 1200 Then
                '    rpt.PrintOptions.PaperSize = PaperSize.PaperFanfoldStdGerman
                'End If
            Else
                Dim dialog As New PrintDialog
                Dim PrnSet As New System.Drawing.Printing.PrinterSettings, PaperSet As New System.Drawing.Printing.PageSettings
                rpt.PrintOptions.CopyTo(PrnSet, PaperSet)
                'LoadCustomPaper(PrnSet, PaperSet)
                dialog.PrinterSettings = PrnSet
                If printer <> "" Then           '设定当前打印机
                    dialog.PrinterSettings.PrinterName = printer
                End If

                If dialog.ShowDialog(ParentForm) <> DialogResult.OK Then
                    Me.mbolCanceled = True
                    Exit Sub
                End If
                'rpt.PrintOptions.CopyFrom(dialog.PrinterSettings, PaperSet)
                rpt.PrintOptions.PrinterName = dialog.PrinterSettings.PrinterName
                If dialog.PrinterSettings.DefaultPageSettings.Landscape Then
                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
                Else
                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                End If
                'If Me.mstrCustomPaperHeight = 1200 Then
                '    rpt.PrintOptions.PaperSize = PaperSize.PaperFanfoldStdGerman
                'End If

                Me.SetPrinterSettings(dialog.PrinterSettings, PaperSet)     '保存当前没置 
            End If
            rpt.PrintToPrinter(1, False, 1, 10000)
            If Not mbolSet Then
                Message("ID_msg_err_RptViewer_PrintSuccess", , "打印成功")
            End If
            'Dim dialog As New PrintDialog
            'Dim prnSet As New System.Drawing.Printing.PrinterSettings, perSet As New System.Drawing.Printing.PageSettings
            'rpt.PrintOptions.CopyTo(prnSet, perSet)
            'dialog.PrinterSettings = prnSet
            'If printer <> "" Then
            '    dialog.PrinterSettings.PrinterName = printer
            '    'dialog.PaperSizes. = System.Drawing.Printing.PaperSize
            'End If

            'If dialog.ShowDialog(MainForm) = DialogResult.OK Then
            '    rpt.PrintOptions.CopyFrom(dialog.PrinterSettings, perSet)
            '    rpt.PrintToPrinter(1, False, 1, 10000)
            '    Message("ID_msg_err_RptViewer_PrintSuccess", , "打印成功")
            'End If
        Catch ex As Exception
            LogMsg(ex, Me.GetType, "DirectPrintReport")
        End Try
        Me.Dispose()
    End Sub
    Public Sub DirectPrintNumReport(ByVal number As Integer, ByVal ParentForm As Form)
        Try
            If ParentForm Is Nothing Then
                ParentForm = MainForm
            End If
            LoadRptArg()
            If mbolSet Then
                'rpt.PrintOptions.CopyFrom(Me.mobjPrinterSettings, Me.mobjPageSettings)
                rpt.PrintOptions.PrinterName = mobjPrinterSettings.PrinterName
                If mobjPrinterSettings.DefaultPageSettings.Landscape Then
                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
                Else
                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                End If
                'If Me.mstrCustomPaperHeight = 1200 Then
                '    rpt.PrintOptions.PaperSize = PaperSize.PaperFanfoldStdGerman
                'End If
            Else
                Dim dialog As New PrintDialog
                Dim prnSet As New System.Drawing.Printing.PrinterSettings, perSet As New System.Drawing.Printing.PageSettings
                rpt.PrintOptions.CopyTo(prnSet, perSet)
                dialog.PrinterSettings = prnSet
                If printer <> "" Then
                    dialog.PrinterSettings.PrinterName = printer
                    'dialog.PaperSizes. = System.Drawing.Printing.PaperSize
                End If

                If dialog.ShowDialog(ParentForm) <> DialogResult.OK Then
                    'Me.Close()
                    Me.mbolCanceled = True
                    Exit Sub
                End If
                'rpt.PrintOptions.CopyFrom(dialog.PrinterSettings, perSet)
                rpt.PrintOptions.PrinterName = dialog.PrinterSettings.PrinterName
                If dialog.PrinterSettings.DefaultPageSettings.Landscape Then
                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
                Else
                    rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                End If
                'If Me.mstrCustomPaperHeight = 1200 Then
                '    rpt.PrintOptions.PaperSize = PaperSize.PaperFanfoldStdGerman
                'End If

                Me.SetPrinterSettings(dialog.PrinterSettings, perSet)
            End If
            rpt.PrintToPrinter(number, False, 1, 10000)
            If Not mbolSet Then
                Message("ID_msg_err_RptViewer_PrintSuccess", , "打印成功")
            End If
            'Dim dialog As New PrintDialog
            'Dim prnSet As New System.Drawing.Printing.PrinterSettings, perSet As New System.Drawing.Printing.PageSettings
            'rpt.PrintOptions.CopyTo(prnSet, perSet)
            'dialog.PrinterSettings = prnSet
            'If printer <> "" Then
            '    dialog.PrinterSettings.PrinterName = printer
            '    'dialog.PaperSizes. = System.Drawing.Printing.PaperSize
            'End If
            'dialog.PrinterSettings.Copies = number
            'If dialog.ShowDialog(MainForm) = DialogResult.OK Then
            '    rpt.PrintOptions.CopyFrom(dialog.PrinterSettings, perSet)
            '    rpt.PrintToPrinter(number, False, 1, 10000)
            '    Message("ID_msg_err_RptViewer_PrintSuccess", , "打印成功")
            'End If
        Catch ex As Exception
            LogMsg(ex, Me.GetType, "DirectPrintNumReport")
        End Try
        Me.Dispose()
    End Sub


    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        On Error Resume Next
        Panel1.Visible = False
        TimerResize.Enabled = False
        TimerResize.Interval = 200
        TimerResize.Enabled = True
    End Sub

    Private Sub TimerResize_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerResize.Tick
        Dim pos As Integer
        If Not Panel1 Is Nothing Then
            TimerResize.Enabled = False
            Panel1.Visible = True
            pos = Me.Width - Panel1.Width
            If pos < 260 Then
                pos = 260
            End If
            Panel1.Left = pos
            Panel1.Top = 0
            Panel1.BringToFront()
        End If
    End Sub

    Private Sub LoadControlText()
        Me.btnExport.Text = GetFieldCaption("ID_cap_frmRptViewer_btnExport", True, "Export")
    End Sub

    Private Sub frmRptViewer_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Me.CtlRptViewer.Dispose()
        Me.CtlRptViewer = Nothing
        Me.Dispose()
    End Sub

    Private Sub frmRptViewer_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        MainForm.RelatedMenu.Clear()
        'MainForm.RelatedMenu.Add(RelatedMenuKey.rohdr, "Recieve Order")
        MainForm.RelatedMenu.Refresh()
    End Sub


    Private mstrCustomPaperHeight As Integer = 0

    Public Sub SetPaperHeight(Optional ByVal PaperHeight As Integer = 0)
        mstrCustomPaperHeight = PaperHeight
    End Sub


    Private Sub LoadCustomPaper(ByVal ps As System.Drawing.Printing.PrinterSettings, ByVal PaperSet As System.Drawing.Printing.PageSettings)
        If mstrCustomPaperHeight <= 0 Then
            Exit Sub
        End If
        Dim i As Integer
        Dim p As System.Drawing.Printing.PaperSize
        For i = 0 To ps.PaperSizes.Count - 1
            p = ps.PaperSizes(i)
            If Math.Abs(ps.PaperSizes(i).Height - mstrCustomPaperHeight) < 10 Then
                ps.DefaultPageSettings.PaperSize = ps.PaperSizes(i)
                PaperSet.PaperSize = ps.PaperSizes(i)
                Exit For
            End If
        Next
    End Sub
End Class
