Imports ImportExport
Imports YT.BusinessObject

Public Class frmExport
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
    Friend WithEvents lblFileType As System.Windows.Forms.Label
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents cboFileType As System.Windows.Forms.ComboBox
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents groupOption As System.Windows.Forms.GroupBox
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnBrowsePath As System.Windows.Forms.Button
    Friend WithEvents cbodc_code As System.Windows.Forms.ComboBox
    Friend WithEvents lbldc_name As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblFileType = New System.Windows.Forms.Label
        Me.lblFilename = New System.Windows.Forms.Label
        Me.lblPath = New System.Windows.Forms.Label
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.cboFileType = New System.Windows.Forms.ComboBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.lblCaption = New System.Windows.Forms.Label
        Me.groupOption = New System.Windows.Forms.GroupBox
        Me.cbodc_code = New System.Windows.Forms.ComboBox
        Me.lbldc_name = New System.Windows.Forms.Label
        Me.btnBrowsePath = New System.Windows.Forms.Button
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.groupOption.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblFileType
        '
        Me.lblFileType.Location = New System.Drawing.Point(8, 48)
        Me.lblFileType.Name = "lblFileType"
        Me.lblFileType.Size = New System.Drawing.Size(72, 23)
        Me.lblFileType.TabIndex = 0
        Me.lblFileType.Text = "File Type"
        '
        'lblFilename
        '
        Me.lblFilename.Location = New System.Drawing.Point(8, 80)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(80, 23)
        Me.lblFilename.TabIndex = 1
        Me.lblFilename.Text = "File Name"
        '
        'lblPath
        '
        Me.lblPath.Location = New System.Drawing.Point(8, 112)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(72, 23)
        Me.lblPath.TabIndex = 2
        Me.lblPath.Text = "Path:"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(88, 80)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(344, 20)
        Me.txtFileName.TabIndex = 4
        Me.txtFileName.Text = ""
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(88, 112)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(320, 20)
        Me.txtPath.TabIndex = 5
        Me.txtPath.Text = ""
        '
        'cboFileType
        '
        Me.cboFileType.Items.AddRange(New Object() {"XLS - Excel File", "TXT - Text File", "CSV - Text File"})
        Me.cboFileType.Location = New System.Drawing.Point(88, 48)
        Me.cboFileType.Name = "cboFileType"
        Me.cboFileType.Size = New System.Drawing.Size(344, 21)
        Me.cboFileType.TabIndex = 6
        '
        'btnOK
        '
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Location = New System.Drawing.Point(153, 176)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 32)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "OK"
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Location = New System.Drawing.Point(360, 176)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 32)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(8, 8)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(440, 16)
        Me.lblCaption.TabIndex = 22
        '
        'groupOption
        '
        Me.groupOption.Controls.Add(Me.cbodc_code)
        Me.groupOption.Controls.Add(Me.lbldc_name)
        Me.groupOption.Controls.Add(Me.btnBrowsePath)
        Me.groupOption.Controls.Add(Me.txtPath)
        Me.groupOption.Controls.Add(Me.txtFileName)
        Me.groupOption.Controls.Add(Me.lblPath)
        Me.groupOption.Controls.Add(Me.lblFilename)
        Me.groupOption.Controls.Add(Me.lblFileType)
        Me.groupOption.Controls.Add(Me.cboFileType)
        Me.groupOption.Location = New System.Drawing.Point(8, 24)
        Me.groupOption.Name = "groupOption"
        Me.groupOption.Size = New System.Drawing.Size(440, 144)
        Me.groupOption.TabIndex = 21
        Me.groupOption.TabStop = False
        '
        'cbodc_code
        '
        Me.cbodc_code.Items.AddRange(New Object() {".XLS - Excel File", ".TXT - Text File"})
        Me.cbodc_code.Location = New System.Drawing.Point(88, 16)
        Me.cbodc_code.Name = "cbodc_code"
        Me.cbodc_code.Size = New System.Drawing.Size(344, 21)
        Me.cbodc_code.TabIndex = 20
        '
        'lbldc_name
        '
        Me.lbldc_name.Location = New System.Drawing.Point(8, 16)
        Me.lbldc_name.Name = "lbldc_name"
        Me.lbldc_name.Size = New System.Drawing.Size(72, 23)
        Me.lbldc_name.TabIndex = 19
        Me.lbldc_name.Text = "物流中心"
        '
        'btnBrowsePath
        '
        Me.btnBrowsePath.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBrowsePath.Location = New System.Drawing.Point(407, 112)
        Me.btnBrowsePath.Name = "btnBrowsePath"
        Me.btnBrowsePath.Size = New System.Drawing.Size(20, 20)
        Me.btnBrowsePath.TabIndex = 7
        Me.btnBrowsePath.Text = "..."
        '
        'frmExport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(457, 216)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.groupOption)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExport"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export Option"
        Me.groupOption.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private mstrDefaultDC As String = UserRightMgr.gDcCode
    Private mstrRight_no As String
    Private mstrDc_code As String
    Private mBussinessName As String = ""


    Private mstrCaption As String = ""
    Private mExportFileName As String = ""
    Private mOnlyFileName As String = ""
    Private bDisableDC As Boolean = True

    Public Property DisableDC() As Boolean
        Get
            Return bDisableDC
        End Get
        Set(ByVal Value As Boolean)
            bDisableDC = Value
        End Set
    End Property

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
    Private lookup As New lookup
    Private DefualtExpUrl As String = ""
    Public ReadOnly Property ExportFileName() As String
        Get
            Return mExportFileName
        End Get
    End Property
    Public ReadOnly Property OnlyFileName() As String
        Get
            Return mOnlyFileName
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


    Public Sub SetDefaultValue(ByVal vFileType As File.FileType, ByVal vFileName As String, ByVal vPath As String, ByVal BussinessName As String, Optional ByVal EnableChangeType As Boolean = False, Optional ByVal UseDefaultpath As Boolean = True)
        Dim df As New clsDocumentFormat

        If vFileType = File.FileType.XLS Then
            cboFileType.SelectedIndex = 0
        ElseIf vFileType = File.FileType.TXT Then
            cboFileType.SelectedIndex = 1
        ElseIf vFileType = File.FileType.CSV Then
            cboFileType.SelectedIndex = 2
        End If
        ' cboFileType.SelectedIndex = 0
        '获取导出路径
        If UseDefaultpath Then
            'DefualtExpUrl = lookup.GetDefualtExpUrl()
            If DefualtExpUrl <> "" Then
                vPath = DefualtExpUrl
            End If
        End If
        If Trim(BussinessName) = "" Then
            BussinessName = "Path"
        End If
        mBussinessName = BussinessName
        If Trim(vPath) = "" Then
            vPath = XMLSet.GetProfileString("WMS", "Export", BussinessName, "")
        End If
        If Trim(vPath) <> "" Then
            Me.txtPath.Text = vPath
        Else
            Me.txtPath.Text = "C:\"
        End If


        If vFileName.Trim() = "" Then
            Me.txtFileName.Text = "收货记录" + DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日" + df.GetGlobalRecvhdrSequenceNo().ToString().Trim()
        Else
            Me.txtFileName.Text = vFileName
            'Me.txtPath.Text = vPath
        End If
        Me.cboFileType.Enabled = EnableChangeType
    End Sub

    'Private Function GetFileType() As String
    Private Function GetFileType() As String
        If cboFileType.SelectedIndex = 0 Then
            Return ".xls"
        ElseIf cboFileType.SelectedIndex = 1 Then
            Return ".txt"
        ElseIf cboFileType.SelectedIndex = 2 Then
            Return ".csv"
        End If
    End Function
    'End Function



    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    'Private Function GetFileNameWithType() As String
    '    Dim vFile As String
    '    vFile = Trim(Me.txtFileName.Text)
    '    If vFile.LastIndexOf(".") > 0 Then
    '        mOnlyFileName = Mid(vFile, 1, InStrRev(vFile, "|") - 1)
    '        Return vFile
    '    Else
    '        mOnlyFileName = vFile
    '        Return vFile + GetFileType()
    '    End If
    'End Function

    Private Function GetFileName() As String
        Dim strPath As String
        Dim vFile As String
        strPath = Trim(Me.txtPath.Text)
        If Microsoft.VisualBasic.Right(strPath, 1) = "\" Then
            vFile = Me.txtPath.Text + Me.txtFileName.Text '+ GetFileType()
        Else
            vFile = Me.txtPath.Text + "\" + Me.txtFileName.Text '+ GetFileType()
        End If
        Return vFile
    End Function

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim strPath As String
        strPath = Trim(Me.txtPath.Text)
        '检查文件路径是否存在
        If IsExistedPath(strPath) = False Then
            Me.txtPath.Focus()
            Exit Sub
        End If
        mExportFileName = GetFileName()
        XMLSet.WriteProfileString("WMS", "Export", mBussinessName, Me.txtPath.Text)
        Me.DialogResult = DialogResult.OK
    End Sub



    Private Sub frmExport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetFormResource(Me)
        lblCaption.Text = mstrCaption
        cbodc_code.Enabled = Not bDisableDC
    End Sub

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

    Private Sub cbodc_code_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbodc_code.SelectedIndexChanged
        Dim str As String
        str = cbodc_code.SelectedValue
        If Trim(str) <> "" Then
            mstrDc_code = str
        End If
    End Sub
End Class
