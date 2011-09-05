Imports YT.BusinessObject
Imports ImportExport

Public Class frmImportCPSG
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
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents groupOption As System.Windows.Forms.GroupBox
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents cboFileType As System.Windows.Forms.ComboBox
    Friend WithEvents lblFileType As System.Windows.Forms.Label
    Friend WithEvents btnBrowsePath As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents cbodc_code As System.Windows.Forms.ComboBox
    Friend WithEvents lbldc_code As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblCaption = New System.Windows.Forms.Label
        Me.groupOption = New System.Windows.Forms.GroupBox
        Me.cbodc_code = New System.Windows.Forms.ComboBox
        Me.lbldc_code = New System.Windows.Forms.Label
        Me.lblFilename = New System.Windows.Forms.Label
        Me.lblPath = New System.Windows.Forms.Label
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.cboFileType = New System.Windows.Forms.ComboBox
        Me.lblFileType = New System.Windows.Forms.Label
        Me.btnBrowsePath = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.btnPreview = New System.Windows.Forms.Button
        Me.groupOption.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(15, 7)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(424, 16)
        Me.lblCaption.TabIndex = 24
        '
        'groupOption
        '
        Me.groupOption.Controls.Add(Me.cbodc_code)
        Me.groupOption.Controls.Add(Me.lbldc_code)
        Me.groupOption.Controls.Add(Me.lblFilename)
        Me.groupOption.Controls.Add(Me.lblPath)
        Me.groupOption.Controls.Add(Me.txtFileName)
        Me.groupOption.Controls.Add(Me.txtPath)
        Me.groupOption.Controls.Add(Me.cboFileType)
        Me.groupOption.Controls.Add(Me.lblFileType)
        Me.groupOption.Controls.Add(Me.btnBrowsePath)
        Me.groupOption.Location = New System.Drawing.Point(7, 31)
        Me.groupOption.Name = "groupOption"
        Me.groupOption.Size = New System.Drawing.Size(440, 140)
        Me.groupOption.TabIndex = 23
        Me.groupOption.TabStop = False
        '
        'cbodc_code
        '
        Me.cbodc_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbodc_code.Location = New System.Drawing.Point(88, 16)
        Me.cbodc_code.Name = "cbodc_code"
        Me.cbodc_code.Size = New System.Drawing.Size(336, 21)
        Me.cbodc_code.TabIndex = 18
        '
        'lbldc_code
        '
        Me.lbldc_code.Location = New System.Drawing.Point(8, 16)
        Me.lbldc_code.Name = "lbldc_code"
        Me.lbldc_code.Size = New System.Drawing.Size(72, 16)
        Me.lbldc_code.TabIndex = 17
        Me.lbldc_code.Text = "物流中心:"
        '
        'lblFilename
        '
        Me.lblFilename.Location = New System.Drawing.Point(7, 74)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(80, 23)
        Me.lblFilename.TabIndex = 11
        Me.lblFilename.Text = "File Name"
        '
        'lblPath
        '
        Me.lblPath.Location = New System.Drawing.Point(7, 104)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(71, 23)
        Me.lblPath.TabIndex = 12
        Me.lblPath.Text = "Path:"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(87, 74)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(337, 20)
        Me.txtFileName.TabIndex = 13
        Me.txtFileName.Text = ""
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(87, 104)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(313, 20)
        Me.txtPath.TabIndex = 14
        Me.txtPath.Text = ""
        '
        'cboFileType
        '
        Me.cboFileType.Items.AddRange(New Object() {".XLS - Excel File", ".TXT - Text File"})
        Me.cboFileType.Location = New System.Drawing.Point(87, 45)
        Me.cboFileType.Name = "cboFileType"
        Me.cboFileType.Size = New System.Drawing.Size(337, 21)
        Me.cboFileType.TabIndex = 15
        '
        'lblFileType
        '
        Me.lblFileType.Location = New System.Drawing.Point(7, 45)
        Me.lblFileType.Name = "lblFileType"
        Me.lblFileType.Size = New System.Drawing.Size(71, 23)
        Me.lblFileType.TabIndex = 10
        Me.lblFileType.Text = "File Type"
        '
        'btnBrowsePath
        '
        Me.btnBrowsePath.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBrowsePath.Location = New System.Drawing.Point(400, 104)
        Me.btnBrowsePath.Name = "btnBrowsePath"
        Me.btnBrowsePath.Size = New System.Drawing.Size(24, 20)
        Me.btnBrowsePath.TabIndex = 16
        Me.btnBrowsePath.Text = "..."
        '
        'btnOK
        '
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Location = New System.Drawing.Point(207, 178)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 32)
        Me.btnOK.TabIndex = 21
        Me.btnOK.Text = "OK"
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Location = New System.Drawing.Point(360, 178)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 32)
        Me.btnClose.TabIndex = 22
        Me.btnClose.Text = "Close"
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(48, 178)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 32)
        Me.btnPreview.TabIndex = 25
        Me.btnPreview.Text = "Preview"
        '
        'frmImportCPSG
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(454, 219)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.groupOption)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnClose)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportCPSG"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Option"
        Me.groupOption.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private mstrCaption As String = ""
    Private mImportFileName As String = ""
    Private mBussinessName As String = ""

    Private mstrDefaultDC As String
    Private mstrRight_no As String
    Private mstrDc_code As String
    Private dc As DataSet

    Public Property dc_code() As String
        Get
            Return mstrDc_code
        End Get
        Set(ByVal Value As String)
            mstrDc_code = Value
        End Set
    End Property

    Public Property DefaultDC() As String
        Get
            Return mstrDefaultDC
        End Get
        Set(ByVal Value As String)
            mstrDefaultDC = Trim(Value)
        End Set
    End Property

    Public Property Right_no() As String
        Get
            Return mstrRight_no
        End Get
        Set(ByVal Value As String)
            mstrRight_no = Value
        End Set
    End Property


    Private Sub LoadDcList()
        On Error Resume Next
        Dim look As New Lookup
        dc = look.GetDcListByPermission(UserRightMgr.gUserCode, mstrRight_no)
        cbodc_code.ValueMember = dc.Tables(0).Columns(0).ColumnName
        cbodc_code.DisplayMember = dc.Tables(0).Columns(1).ColumnName
        cbodc_code.DataSource = dc.Tables(0).DefaultView
        Dim i As Integer
        For i = 0 To dc.Tables(0).Rows.Count - 1
            If dc.Tables(0).Rows(i).Item(0) = mstrDefaultDC Then
                cbodc_code.SelectedIndex = i
                Return
            End If
        Next
        cbodc_code.SelectedIndex = 0
    End Sub

    Public ReadOnly Property ImportFileName() As String
        Get
            Return mImportFileName
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



    Public Sub SetDefaultValue(ByVal vFileType As File.FileType, ByVal vFileName As String, ByVal vPath As String, Optional ByVal BussinessName As String = "", Optional ByVal EnableChangeType As Boolean = False)
        If vFileType = File.FileType.XLS Then
            cboFileType.SelectedIndex = 0
        ElseIf vFileType = File.FileType.TXT Then
            cboFileType.SelectedIndex = 1
        End If
        'cboFileType.SelectedIndex = 0

        Me.txtFileName.Text = vFileName
        If Trim(BussinessName) = "" Then
            BussinessName = "Path"
        End If
        mBussinessName = BussinessName
        If Trim(vPath) = "" Then
            vPath = XMLSet.GetProfileString("WMS", "Import", BussinessName, "")
        End If
        If Trim(vPath) <> "" Then
            Me.txtPath.Text = vPath
        End If
        Me.cboFileType.Enabled = EnableChangeType
        'Me.btnPreview.Visible = XmlFileExisted()
    End Sub

    Private Function GetFileType() As String
        If cboFileType.SelectedIndex = 0 Then
            Return ".xls"
        ElseIf cboFileType.SelectedIndex = 1 Then
            Return ".txt"
        End If
    End Function



    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
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
        '检查文件路径是否存在
        'If lookup.isFileUrl(strPath) Then
        '    Me.txtPath.Focus()
        '    Exit Function
        'End If
        If Microsoft.VisualBasic.Right(strPath, 1) = "\" Then
            vFile = Me.txtPath.Text + GetFileNameWithType() 'Me.txtFileName.Text '+ GetFileType()
        Else
            vFile = Me.txtPath.Text + "\" + GetFileNameWithType() 'Me.txtFileName.Text '+ GetFileType()
        End If
        Return vFile
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not System.IO.File.Exists(txtPath.Text + "\" + txtFileName.Text) Then
            Message("ID_msg_FileIsNotExistsplsPutFile", True, "该文件路径不存在，请输入正确的文件路径")
            Return
        ElseIf cboFileType.Text.ToUpper().IndexOf(System.IO.Path.GetExtension(txtPath.Text + "\" + txtFileName.Text).ToUpper()) < 0 Then
            Message("ID_msg_PlsFilePath", True, "请选择正确的文件类型")
            Return
        End If
        XMLSet.WriteProfileString("WMS", "Import", mBussinessName, Me.txtPath.Text)
        mImportFileName = GetFileName()
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub btnBrowsePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowsePath.Click
        Try

            OpenFileDialog1.FileName = GetFileName()

            If OpenFileDialog1.ShowDialog(Me) <> DialogResult.OK Then
                Return
            End If
            txtPath.Text = System.IO.Path.GetDirectoryName(OpenFileDialog1.FileName)
            Me.txtFileName.Text = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
        Catch ex As Exception
            ErrorMsg(ex, ex.GetType, "btnBrowsePath_Click")
        End Try

    End Sub

    Private Sub frmImport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetFormResource(Me)
        lblCaption.Text = mstrCaption
        LoadDcList()
    End Sub

    'Private Function XmlFileExisted() As Boolean
    '    If mxmlFile = "" Then
    '        Return False
    '    End If
    '    If System.IO.File.Exists(mxmlFile) = False Then
    '        Return False
    '    End If
    '    Return True
    'End Function

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim p As New ImportExport.ProcessorBase(Me)
        Dim ds As DataSet
        Dim xmlFile As String
        Dim i As Integer

        If Not System.IO.File.Exists(txtPath.Text + "\" + txtFileName.Text) Then
            Message("ID_msg_FileIsNotExistsplsPutFile", True, "该文件路径不存在，请输入正确的文件路径")
            Return
        ElseIf cboFileType.Text.ToUpper().IndexOf(System.IO.Path.GetExtension(txtPath.Text + "\" + txtFileName.Text).ToUpper()) < 0 Then
            Message("ID_msg_PlsFilePath", True, "请选择正确的文件类型")
            Return
        End If
        'If rBtnDefault.Checked = True Then
        'xmlFile = GetLibFile("ImpImportExcel.xml")
        'Else
        xmlFile = GetLibFile("ImpImportExcelCPSG.xml")
        'End If


        mImportFileName = GetFileName()
        Try
            p.SetSourceDevice(mImportFileName, "xlsfile")
            ds = p.RunImportPreview(xmlFile)

            ds.Tables(0).TableName = "预览"
            For i = 0 To ds.Tables(0).Columns.Count - 1
                ds.Tables(0).Columns(i).ColumnName = ds.Tables(0).Columns(i).Caption
            Next
            Dim frm As New frmDataPreview
            SetModalFormStyle(frm)
            frm.DataSource = ds
            frm.ShowDialog(Me)
            frm.Dispose()
            frm = Nothing
        Catch ex As Exception
            ErrorMsg(ex, Me.GetType, "btnPreview_Click")
        End Try
        p = Nothing
        GC.Collect()
    End Sub

    Private Sub cbodc_code_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbodc_code.SelectedIndexChanged
        Dim i As Integer
        Try
            i = cbodc_code.SelectedIndex
            dc_code = dc.Tables(0).Rows(i).Item(0)
        Catch ex As Exception
            dc_code = ""
        End Try
    End Sub
End Class
