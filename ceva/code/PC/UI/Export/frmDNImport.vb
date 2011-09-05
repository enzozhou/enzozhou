Imports YT.BusinessObject
Imports ImportExport
Imports COMExpress.BusinessObject

Public Class frmDNImport
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
        'frmPrintSeriaNo.Show()
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
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnBrowsePath As System.Windows.Forms.Button
    Friend WithEvents cboFileType As System.Windows.Forms.ComboBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents lblFileType As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents groupOption As System.Windows.Forms.GroupBox
    Friend WithEvents cbodc_code As System.Windows.Forms.ComboBox
    Friend WithEvents lbldc_name As System.Windows.Forms.Label
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents lblType As System.Windows.Forms.Label
    Friend WithEvents txtBchNo As System.Windows.Forms.TextBox
    Friend WithEvents lblBatch As System.Windows.Forms.Label
    Friend WithEvents cmbType As System.Windows.Forms.ComboBox
    Friend WithEvents TimerClose As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnBrowsePath = New System.Windows.Forms.Button
        Me.cboFileType = New System.Windows.Forms.ComboBox
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.lblPath = New System.Windows.Forms.Label
        Me.lblFilename = New System.Windows.Forms.Label
        Me.lblFileType = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.groupOption = New System.Windows.Forms.GroupBox
        Me.cmbType = New System.Windows.Forms.ComboBox
        Me.lblType = New System.Windows.Forms.Label
        Me.txtBchNo = New System.Windows.Forms.TextBox
        Me.lblBatch = New System.Windows.Forms.Label
        Me.cbodc_code = New System.Windows.Forms.ComboBox
        Me.lbldc_name = New System.Windows.Forms.Label
        Me.lblCaption = New System.Windows.Forms.Label
        Me.btnPreview = New System.Windows.Forms.Button
        Me.TimerClose = New System.Windows.Forms.Timer(Me.components)
        Me.groupOption.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Location = New System.Drawing.Point(432, 209)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(90, 34)
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "Close"
        '
        'btnOK
        '
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Location = New System.Drawing.Point(250, 209)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 34)
        Me.btnOK.TabIndex = 17
        Me.btnOK.Text = "OK"
        '
        'btnBrowsePath
        '
        Me.btnBrowsePath.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBrowsePath.Location = New System.Drawing.Point(490, 121)
        Me.btnBrowsePath.Name = "btnBrowsePath"
        Me.btnBrowsePath.Size = New System.Drawing.Size(28, 21)
        Me.btnBrowsePath.TabIndex = 16
        Me.btnBrowsePath.Text = "..."
        '
        'cboFileType
        '
        Me.cboFileType.Items.AddRange(New Object() {".XLS - Excel File", ".TXT - Text File", ".CSV - Text File"})
        Me.cboFileType.Location = New System.Drawing.Point(106, 52)
        Me.cboFileType.Name = "cboFileType"
        Me.cboFileType.Size = New System.Drawing.Size(412, 20)
        Me.cboFileType.TabIndex = 15
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(106, 121)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(384, 21)
        Me.txtPath.TabIndex = 14
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(106, 86)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(412, 21)
        Me.txtFileName.TabIndex = 13
        '
        'lblPath
        '
        Me.lblPath.Location = New System.Drawing.Point(10, 121)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(86, 24)
        Me.lblPath.TabIndex = 12
        Me.lblPath.Text = "Path:"
        '
        'lblFilename
        '
        Me.lblFilename.Location = New System.Drawing.Point(10, 86)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(96, 25)
        Me.lblFilename.TabIndex = 11
        Me.lblFilename.Text = "File Name"
        '
        'lblFileType
        '
        Me.lblFileType.Location = New System.Drawing.Point(10, 52)
        Me.lblFileType.Name = "lblFileType"
        Me.lblFileType.Size = New System.Drawing.Size(86, 24)
        Me.lblFileType.TabIndex = 10
        Me.lblFileType.Text = "File Type"
        '
        'groupOption
        '
        Me.groupOption.Controls.Add(Me.cmbType)
        Me.groupOption.Controls.Add(Me.lblType)
        Me.groupOption.Controls.Add(Me.txtBchNo)
        Me.groupOption.Controls.Add(Me.lblBatch)
        Me.groupOption.Controls.Add(Me.cbodc_code)
        Me.groupOption.Controls.Add(Me.lbldc_name)
        Me.groupOption.Controls.Add(Me.lblFilename)
        Me.groupOption.Controls.Add(Me.lblPath)
        Me.groupOption.Controls.Add(Me.txtFileName)
        Me.groupOption.Controls.Add(Me.txtPath)
        Me.groupOption.Controls.Add(Me.cboFileType)
        Me.groupOption.Controls.Add(Me.lblFileType)
        Me.groupOption.Controls.Add(Me.btnBrowsePath)
        Me.groupOption.Location = New System.Drawing.Point(10, 16)
        Me.groupOption.Name = "groupOption"
        Me.groupOption.Size = New System.Drawing.Size(528, 185)
        Me.groupOption.TabIndex = 19
        Me.groupOption.TabStop = False
        '
        'cmbType
        '
        Me.cmbType.Items.AddRange(New Object() {"CEVA网销", "CEVA经销商", "CEVA普货", "浦菱陆运", "浦菱空运", "菱华陆运", "嘉里大通陆运", "天地华宇"})
        Me.cmbType.Location = New System.Drawing.Point(369, 153)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(93, 20)
        Me.cmbType.TabIndex = 22
        Me.cmbType.SelectedIndex = 0
        '
        'lblType
        '
        Me.lblType.Location = New System.Drawing.Point(296, 155)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(63, 24)
        Me.lblType.TabIndex = 21
        Me.lblType.Text = "Type:"
        '
        'txtBchNo
        '
        Me.txtBchNo.Location = New System.Drawing.Point(106, 153)
        Me.txtBchNo.MaxLength = 20
        Me.txtBchNo.Name = "txtBchNo"
        Me.txtBchNo.Size = New System.Drawing.Size(162, 21)
        Me.txtBchNo.TabIndex = 20
        '
        'lblBatch
        '
        Me.lblBatch.Location = New System.Drawing.Point(10, 153)
        Me.lblBatch.Name = "lblBatch"
        Me.lblBatch.Size = New System.Drawing.Size(86, 24)
        Me.lblBatch.TabIndex = 19
        Me.lblBatch.Text = "Batch:"
        '
        'cbodc_code
        '
        Me.cbodc_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbodc_code.Items.AddRange(New Object() {".XLS - Excel File", ".TXT - Text File"})
        Me.cbodc_code.Location = New System.Drawing.Point(106, 17)
        Me.cbodc_code.Name = "cbodc_code"
        Me.cbodc_code.Size = New System.Drawing.Size(412, 20)
        Me.cbodc_code.TabIndex = 18
        '
        'lbldc_name
        '
        Me.lbldc_name.Location = New System.Drawing.Point(10, 17)
        Me.lbldc_name.Name = "lbldc_name"
        Me.lbldc_name.Size = New System.Drawing.Size(86, 25)
        Me.lbldc_name.TabIndex = 17
        Me.lbldc_name.Text = "物流中心:"
        '
        'lblCaption
        '
        Me.lblCaption.Location = New System.Drawing.Point(19, 5)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(509, 17)
        Me.lblCaption.TabIndex = 20
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(48, 209)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(90, 34)
        Me.btnPreview.TabIndex = 26
        Me.btnPreview.Text = "Preview"
        '
        'TimerClose
        '
        '
        'frmDNImport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(549, 255)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.groupOption)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDNImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import Option"
        Me.groupOption.ResumeLayout(False)
        Me.groupOption.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private mstrCaption As String = ""
    Private mImportFileName As String = ""
    Private mBussinessName As String = ""
    Private mstrDefaultDC As String = UserRightMgr.gDcCode
    Private mstrRight_no As String
    Private mstrDc_code As String
    Private mstrLibFile As String = ""

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
        'On Error Resume Next
        'Dim ds As DataSet
        'Dim look As New Lookup
        'If Trim(mstrRight_no) <> "" Then
        '    ds = look.GetDcListByPermission(UserRightMgr.gUserCode, mstrRight_no)
        'Else
        '    ds = look.getRegiondcList(COMExpress.BusinessObject.CXLookupCallTypeConstants.ccCache, Nothing)
        'End If
        'cbodc_code.ValueMember = ds.Tables(0).Columns(0).ColumnName
        'cbodc_code.DisplayMember = ds.Tables(0).Columns(1).ColumnName
        'cbodc_code.DataSource = ds.Tables(0).DefaultView
        ''Dim i As Integer
        ''For i = 0 To ds.Tables(0).Rows.Count - 1
        ''    If ds.Tables(0).Rows(i).Item(0) = mstrDefaultDC Then
        ''        cbodc_code.SelectedIndex = i
        ''        Return
        ''    End If
        ''Next
        'If Trim(DefaultDC) <> "" Then
        '    cbodc_code.SelectedValue = DefaultDC
        '    If cbodc_code.SelectedValue <> DefaultDC Or DefaultDC = "" Then
        '        Message("ID_msg_NoRight", True, "无操作权限")
        '        TimerClose.Interval = 100
        '        TimerClose.Enabled = True
        '        Exit Sub
        '    End If
        'Else
        '    cbodc_code.SelectedIndex = 0
        'End If
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

    Public Sub SetDefaultValue(ByVal vFileType As File.FileType, ByVal vFileName As String, ByVal vPath As String, Optional ByVal BussinessName As String = "", Optional ByVal EnableChangeType As Boolean = False, Optional ByVal xmllibfile As String = "")
        If vFileType = File.FileType.XLS Then
            cboFileType.SelectedIndex = 0
        ElseIf vFileType = File.FileType.TXT Then
            cboFileType.SelectedIndex = 1
        ElseIf vFileType = File.FileType.CSV Then
            cboFileType.SelectedIndex = 2
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
        mstrLibFile = xmllibfile
        If Trim(mstrLibFile) = "" Then
            btnPreview.Visible = False
        Else
            btnPreview.Visible = True
        End If
    End Sub

    Private Function GetFileType() As String
        If cboFileType.SelectedIndex = 0 Then
            Return ".xls"
        ElseIf cboFileType.SelectedIndex = 1 Then
            Return ".txt"
        ElseIf cboFileType.SelectedIndex = 2 Then
            Return ".csv"
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
        If String.IsNullOrEmpty(txtBchNo.Text.Trim()) Then
            Message("ID_msg_PlsBchNo", True, "请输入批次号")
            Return
        End If

        Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
        Try
            Dim dtmTest As Date
            Dim Seq_id As String
            dtmTest = TimeValue(Now)
            Seq_id = Format(dtmTest, "yyyyMMddhhmmssffffFF")
            Dim _ds As DataSet = GetImportData()

            Dim parmUserCode As String = UserRightMgr.gUserCode
            cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection
            DatabaseHelper.OpenConnection(cmd.Connection)

            For Each _row As DataRow In _ds.Tables(0).Rows
                Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm4 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm5 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm6 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm7 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm8 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm9 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm10 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm11 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm12 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm13 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm14 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm15 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm16 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                Dim prm17 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
                With prm1
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .ParameterName = "@ID"
                    .Value = Seq_id
                End With
                With prm2
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 10
                    .ParameterName = "@DC_CODE"
                    .Value = "SHA"
                End With
                With prm3
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 20
                    .ParameterName = "@DN_NO"
                    If _row(1) Is Nothing Then
                        Continue For
                    Else
                        .Value = _row(1).ToString()
                    End If
                End With
                With prm4
                    .DbType = DbType.DateTime
                    .Direction = ParameterDirection.Input
                    .ParameterName = "@DUE_DATE"
                    If _row(0) Is Nothing Then
                        .Value = DBNull.Value
                    Else
                        .Value = Convert.ToDateTime(_row(0))
                    End If
                End With
                With prm5
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 3
                    .ParameterName = "@DOC_TYPE"
                    .Value = cmbType.SelectedIndex
                End With
                With prm6
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 10
                    .ParameterName = "@DEAL_TO"
                    If _row(2) Is Nothing Then
                        .Value = DBNull.Value
                    Else
                        .Value = _row(2).ToString()
                    End If
                End With
                With prm7
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 50
                    .ParameterName = "@DEAL_NAME"
                    If _row(3) Is Nothing Then
                        .Value = DBNull.Value
                    Else
                        .Value = _row(3).ToString()
                    End If
                End With
                With prm8
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 100
                    .ParameterName = "@DEAL_PERSON"
                    If _row(4) Is Nothing Then
                        .Value = DBNull.Value
                    Else
                        .Value = _row(4).ToString()
                    End If
                End With
                With prm9
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 30
                    .ParameterName = "@DEAL_TEL"
                    If _row(5) Is Nothing Then
                        .Value = DBNull.Value
                    Else
                        .Value = _row(5).ToString()
                    End If
                End With
                With prm10
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 100
                    .ParameterName = "@UNLOADING_ADDRESS"
                    If _row(6) Is Nothing Then
                        .Value = DBNull.Value
                    Else
                        .Value = _row(6).ToString()
                    End If
                End With
                With prm11
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 30
                    .ParameterName = "@CITY_TO"
                    If _row(7) Is Nothing Then
                        .Value = DBNull.Value
                    Else
                        .Value = _row(7).ToString()
                    End If
                End With
                With prm12
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 50
                    .ParameterName = "@CONDITION"
                    If _row(8) Is Nothing Then
                        .Value = DBNull.Value
                    Else
                        .Value = _row(8).ToString()
                    End If
                End With
                With prm13
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 50
                    .ParameterName = "@METHOD"
                    If _row(9) Is Nothing Then
                        .Value = DBNull.Value
                    Else
                        .Value = _row(9).ToString()
                    End If
                End With
                With prm14
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 20
                    .ParameterName = "@SKU_NO"
                    If _row(10) Is Nothing Then
                        .Value = DBNull.Value
                    Else
                        .Value = _row(10).ToString()
                    End If
                End With
                With prm15
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 20
                    .ParameterName = "@SONY_BCH_NO"
                    If Trim(txtBchNo.Text) = String.Empty Then
                        .Value = DBNull.Value
                    Else
                        .Value = Trim(txtBchNo.Text)
                    End If

                End With
                With prm16
                    .DbType = DbType.Int32
                    .Direction = ParameterDirection.Input
                    .ParameterName = "@QTY"
                    If IsNumeric(_row(11)) Then
                        .Value = Convert.ToInt32(_row(11))
                    Else
                        .Value = DBNull.Value
                    End If
                End With
                With prm17
                    .DbType = DbType.String
                    .Direction = ParameterDirection.Input
                    .Size = 20
                    .ParameterName = "@OPT_BY"
                    .Value = parmUserCode
                End With

                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.Parameters.Add(prm3)
                cmd.Parameters.Add(prm4)
                cmd.Parameters.Add(prm5)
                cmd.Parameters.Add(prm6)
                cmd.Parameters.Add(prm7)
                cmd.Parameters.Add(prm8)
                cmd.Parameters.Add(prm9)
                cmd.Parameters.Add(prm10)
                cmd.Parameters.Add(prm11)
                cmd.Parameters.Add(prm12)
                cmd.Parameters.Add(prm13)
                cmd.Parameters.Add(prm14)
                cmd.Parameters.Add(prm15)
                cmd.Parameters.Add(prm16)
                cmd.Parameters.Add(prm17)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_I_impDN"
                cmd.ExecuteNonQuery()
                cmd.Parameters.Clear()
            Next
            Dim prmID As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            With prmID
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .ParameterName = "@ID"
                .Value = Seq_id
            End With
            cmd.Parameters.Add(prmID)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "stp_imp_DN"
            cmd.ExecuteNonQuery()
            cmd.Parameters.Clear()
            Message("ID_cap_Import_Result_Success", True, "导入成功")
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ErrorMsg(ex, Me.GetType(), "CallImportGeneral")
        Finally
            cmd.Dispose()
        End Try
        'XMLSet.WriteProfileString("WMS", "Import", mBussinessName, Me.txtPath.Text)

        'mImportFileName = GetFileName()

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
        cbodc_code.Enabled = False
    End Sub

    Private Sub cbodc_code_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbodc_code.SelectedIndexChanged
        Dim str As String
        str = cbodc_code.SelectedValue
        If Trim(str) <> "" Then
            mstrDc_code = str
        End If
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim p As New ImportExport.ProcessorBase(Me)
        Dim ds As DataSet
        Dim xmlFile As String
        Dim i As Integer
        Dim strType As String


        If Not System.IO.File.Exists(txtPath.Text + "\" + txtFileName.Text) Then
            Message("ID_msg_FileIsNotExistsplsPutFile", True, "该文件路径不存在，请输入正确的文件路径")
            Return
        ElseIf cboFileType.Text.ToUpper().IndexOf(System.IO.Path.GetExtension(txtPath.Text + "\" + txtFileName.Text).ToUpper()) < 0 Then
            Message("ID_msg_PlsFilePath", True, "请选择正确的文件类型")
            Return
        End If
        If Trim(mstrLibFile) = "" Then
            Return
        End If
        If System.IO.File.Exists(mstrLibFile) = False Then
            Return
        End If
        xmlFile = mstrLibFile
        strType = GetFileType()

        mImportFileName = GetFileName()
        Try
            If strType = ".xls" Then
                p.SetSourceDevice(mImportFileName, "xlsfile")
            ElseIf strType = ".txt" Or strType = ".csv" Then
                p.SetSourceDevice(mImportFileName, "txtfile")
            Else
                Return
            End If
            ds = p.RunImportPreview(xmlFile)
            'InitializeWorkbook(txtPath.Text + "\" + txtFileName.Text)
            'ds = ConvertToDataTable()


            ds.Tables(0).TableName = "预览"
            'For i = 0 To ds.Tables(0).Columns.Count - 1
            '    ds.Tables(0).Columns(i).ColumnName = ds.Tables(0).Columns(i).Caption
            'Next
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

    Private Function GetImportData() As DataSet
        Dim p As New ImportExport.ProcessorBase(Me)
        Dim ds As DataSet
        Dim xmlFile As String
        Dim i As Integer
        Dim strType As String

        If Not System.IO.File.Exists(txtPath.Text + "\" + txtFileName.Text) Then
            Message("ID_msg_FileIsNotExistsplsPutFile", True, "该文件路径不存在，请输入正确的文件路径")
            Return ds
        ElseIf cboFileType.Text.ToUpper().IndexOf(System.IO.Path.GetExtension(txtPath.Text + "\" + txtFileName.Text).ToUpper()) < 0 Then
            Message("ID_msg_PlsFilePath", True, "请选择正确的文件类型")
            Return ds
        End If
        If Trim(mstrLibFile) = "" Then
            Return ds
        End If
        If System.IO.File.Exists(mstrLibFile) = False Then
            Return ds
        End If
        xmlFile = mstrLibFile
        strType = GetFileType()

        mImportFileName = GetFileName()
        Try
            If strType = ".xls" Then
                p.SetSourceDevice(mImportFileName, "xlsfile")
            ElseIf strType = ".txt" Or strType = ".csv" Then
                p.SetSourceDevice(mImportFileName, "txtfile")
            Else
                Return ds
            End If
            ds = p.RunImportPreview(xmlFile)
        Catch ex As Exception
            ErrorMsg(ex, Me.GetType, "btnPreview_Click")
        End Try
        Return ds
        p = Nothing
        GC.Collect()
    End Function


    Private Sub TimerClose_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerClose.Tick
        TimerClose.Enabled = False
        Me.DialogResult = DialogResult.Abort
        Me.Close()
    End Sub
End Class
