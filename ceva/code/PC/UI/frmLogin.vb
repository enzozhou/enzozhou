Imports COMExpress.BusinessObject.Security
Imports COMExpress.BusinessObject
Imports System.Threading
Imports YT.BusinessObject
Imports YT
Imports ImportExport
Imports ImportExport.Data

Public Class frmLogin
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
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUserCode As System.Windows.Forms.Label
    Friend WithEvents lblTip As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblSystemType As System.Windows.Forms.Label
    Friend WithEvents txtSwitch As System.Windows.Forms.LinkLabel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnLogin = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUsername = New System.Windows.Forms.TextBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.lblUserCode = New System.Windows.Forms.Label
        Me.lblTip = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblSystemType = New System.Windows.Forms.Label
        Me.txtSwitch = New System.Windows.Forms.LinkLabel
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(236, 207)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 27)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.Enabled = False
        Me.btnLogin.Location = New System.Drawing.Point(73, 207)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(96, 27)
        Me.btnLogin.TabIndex = 10
        Me.btnLogin.Text = "Login"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(192, 172)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(160, 21)
        Me.txtPassword.TabIndex = 9
        '
        'txtUsername
        '
        Me.txtUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUsername.Location = New System.Drawing.Point(192, 138)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(160, 21)
        Me.txtUsername.TabIndex = 7
        '
        'lblPassword
        '
        Me.lblPassword.Location = New System.Drawing.Point(67, 172)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(106, 16)
        Me.lblPassword.TabIndex = 8
        Me.lblPassword.Text = "Password"
        '
        'lblUserCode
        '
        Me.lblUserCode.Location = New System.Drawing.Point(67, 138)
        Me.lblUserCode.Name = "lblUserCode"
        Me.lblUserCode.Size = New System.Drawing.Size(115, 16)
        Me.lblUserCode.TabIndex = 6
        Me.lblUserCode.Text = "Username"
        '
        'lblTip
        '
        Me.lblTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTip.Location = New System.Drawing.Point(67, 95)
        Me.lblTip.Name = "lblTip"
        Me.lblTip.Size = New System.Drawing.Size(346, 26)
        Me.lblTip.TabIndex = 12
        Me.lblTip.Text = "Please enter your user name and password:"
        Me.lblTip.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'lblVersion
        '
        Me.lblVersion.Location = New System.Drawing.Point(286, 69)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(164, 17)
        Me.lblVersion.TabIndex = 16
        Me.lblVersion.Text = "Version 1.0.0.0"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(450, 60)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'lblSystemType
        '
        Me.lblSystemType.Location = New System.Drawing.Point(125, 69)
        Me.lblSystemType.Name = "lblSystemType"
        Me.lblSystemType.Size = New System.Drawing.Size(192, 17)
        Me.lblSystemType.TabIndex = 19
        Me.lblSystemType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSwitch
        '
        Me.txtSwitch.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.txtSwitch.Location = New System.Drawing.Point(422, 95)
        Me.txtSwitch.Name = "txtSwitch"
        Me.txtSwitch.Size = New System.Drawing.Size(68, 25)
        Me.txtSwitch.TabIndex = 20
        Me.txtSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(450, 240)
        Me.Controls.Add(Me.txtSwitch)
        Me.Controls.Add(Me.lblSystemType)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblTip)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUserCode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "System Login"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " COM Express generated code "

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        'Try
        '    Dim df As New clsDocumentFormat
        '    Dim vDoc_no As String
        '    Application.DoEvents()
        '    vDoc_no = df.GetNewDocumentNumber("archhdr", "arc_no", clsDocumentFormat.FormatArchive + "1", "")
        'Catch ex As Exception
        '    ErrorMsg(ex, ex.GetType, "CallTest")
        'End Try
        'Dim dc_code As String
        'Dim i As Integer
        'Dim bSelected As Boolean
        If Trim(txtUsername.Text) = "" Then
            Message("ID_msg_frmLogin_PleaseInputUserCode", True, "请输入登录用户。")
            txtUsername.Focus()
            Return
        End If
        Try
            Dim opt As clsOPERATOR
            opt = clsOPERATOR.Load(txtUsername.Text)
            If opt.IsNew Then
                Message("ID_msg_err_Login_NoUser", , "无此用户.")
                Exit Sub
            End If
        Catch ex As Exception
            Message("ID_msg_err_Login_NoUser", , "No User.")
            txtUsername.Focus()
            Return
        End Try


        DoLogin(txtUsername.Text, txtPassword.Text, "")


        ' 2007-08-10, Simon
        ' - Add to set ODBC database connection for report.

    End Sub

    Private Sub SetCurrentDatabase()
        AppDomain.CurrentDomain.SetData("DataSource", _
            COMExpress.Configuration.ConfigurationSettings.AppSettings("DataSource"))
    End Sub

    'Private Function CheckDCSetting(ByVal dc_code As String) As Boolean
    '    Dim dc As clsregiondc
    '    Try

    '        dc = clsregiondc.Load(dc_code)
    '        If dc Is Nothing Then
    '            Return False
    '        End If
    '        If dc.IsNew Then
    '            Return False
    '        End If
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    Finally
    '        dc = Nothing
    '    End Try
    'End Function

    Private Sub DoLogin(ByVal User As String, ByVal Pwd As String, ByVal dc_code As String)

        SetCurrentDatabase()

        'Dim dc_code As String
        'Dim sl As clstranslog
        'sl = sl.Newclstranslog
        'sl.trans_type = "SEC"
        'sl.cmd_type = GeneralType.CmdType.LoginCmd

        Try
            UserRightMgr.gDcCode = dc_code
            'dc_code = COMExpress.Configuration.ConfigurationSettings.AppSettings.Item("RegionDC")
            'If UserRightMgr.CheckDcCode(dc_code) = False Then   'DC is not existsed
            '    Message("ID_msg_Invalid_dc_code", , "DC code is invalid.")
            '    Exit Sub
            'End If
            ProgramType.DateFormat = DateFormat()
            ProgramType.DateTimeFormat = DateTimeFormat()

            Cursor = Cursors.WaitCursor
            Status("Verifying user...")
            'CXBusinessPrincipal.Login(User, Pwd)
            Dim loginResult As UserRightMgr.LoginInfoType
            UserRightMgr.gUIAssemblyVersion = GetCurrentVersion()
            loginResult = UserRightMgr.Login(User, Pwd, dc_code)
            UserRightMgr.gDcCode = dc_code
            Status()
            Cursor = Cursors.Default

            If loginResult = UserRightMgr.LoginInfoType.Valid Or loginResult = UserRightMgr.LoginInfoType.PasswordExpired Then
                MainForm.AppSettings.LoginName = txtUsername.Text
                'sl.Status = "L01"
                If loginResult = UserRightMgr.LoginInfoType.PasswordExpired Then
                    Message("ID_msg_PWDExpired", , "Password is expired.")
                    Dim frm As New frmChangePwd
                    Dim dlgRst As DialogResult
                    SetModalFormStyle(frm)
                    dlgRst = frm.ShowDialog(Me)
                    frm.Dispose()
                    frm = Nothing
                    If dlgRst = DialogResult.Cancel Then
                        Exit Sub
                    End If
                End If
                Dim tm As New clsTimeManager
                If tm.CheckAndAdjustTime = False Then
                    Exit Sub
                End If

                Dim ver As New PCVersionControl
                Dim rst As BusinessObject.VersionControl.CheckVersionResult
                rst = ver.CheckVersion()
                If rst <> VersionControl.CheckVersionResult.Pass Then
                    Message("ID_msg_VersionControl_" + rst.ToString, , rst.ToString)
                    Exit Sub
                End If
                'If CheckDCSetting(dc_code) = False Then
                '    Message("ID_msg_Check_DCCodeIsNotCorrectly", True, "DC setting is not correctly")
                '    Exit Sub
                'End If
                'Dim opt As New clsOption
                'opt.SetOtherOption(clsOption.eOptCode_Others.CurrentStore, Warehouse.Trim)
                'opt = Nothing
                YT.Security.ImpBusinessPrincipal.Login(User, Pwd)

                clsValues.ConstValue("usercode") = UserRightMgr.gUserCode
                clsValues.ConstValue("dccode") = UserRightMgr.gDcCode


                'If Thread.CurrentPrincipal.Identity.IsAuthenticated Then
                MainForm.AppSettings.LoginName = txtUsername.Text
                Me.DialogResult = DialogResult.OK
            Else
                Dim str As String
                'sl.param1 = loginResult.ToString
                str = PublicResource.LoadResString("ID_msg_err_Login_" & loginResult.ToString, loginResult.ToString)
                'sl. = str
                MsgBox(str, MsgBoxStyle.Exclamation)
                txtPassword.Focus()
                txtPassword.SelectAll()
                Return
            End If
        Catch ThisException As Exception
            Status()
            Cursor = Cursors.Default
            Dim str As String
            'sl.param1 = loginResult.ToString
            str = PublicResource.LoadResString("ID_msg_err_Connection", "无法连接数据库")
            'sl. = str
            MsgBox(str, MsgBoxStyle.Exclamation)
            'ErrorMsg(ThisException, Me.GetType, "DoLogin")
            LogMsg(ThisException, Me.GetType, "DoLogin")
            Return
        End Try
        'sl.opt_dtime = Now
        'sl.opt_by = User
        'sl.dc_code = UserRightMgr.gDcCode
        'ClientManager.Save(User, ModuleType.Login, "PC")
        'Try
        '    sl.clt_ver = GetCurrentVersion()
        '    sl.Save()
        'Catch ex As Exception
        'End Try
        FreeSystemCache(Me.GetType, "DoLogin")

    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.DialogResult = DialogResult.Cancel

    End Sub

    Private Sub txtUsername_TextChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles txtUsername.TextChanged

        btnLogin.Enabled = (Len(txtUsername.Text) > 0)

    End Sub

    'Private mobjCICol As ArrayList

    'Public Sub ShowLanguagesOnly()
    '    'btnCancel.Text = "&Done"
    '    Me.AcceptButton = btnCancel
    '    Me.lblUserCode.Visible = False
    '    Me.lblPassword.Visible = False
    '    Me.lblTip.Visible = False
    '    btnLogin.Visible = False
    '    txtUsername.Visible = False
    '    txtPassword.Visible = False
    '    Me.ShowDialog()
    'End Sub

    'Private Sub cboLanguage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLanguage.SelectedIndexChanged
    '    Thread.CurrentThread.CurrentUICulture = mobjCICol(cboLanguage.SelectedIndex)
    '    SetFormResource(Me)
    'End Sub

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'mobjCICol = New ArrayList
        'mobjCICol.Add(New Globalization.CultureInfo("en-US"))
        'mobjCICol.Add(New Globalization.CultureInfo("zh-CHS"))
        'cboLanguage.DataSource = mobjCICol
        'cboLanguage.ValueMember = "Name"
        'cboLanguage.DisplayMember = "DisplayName"
        txtUsername.Text = MainForm.AppSettings.LoginName
        SetFormResource(Me)
        'lblLanguage.Visible = False
        'cboLanguage.Visible = False
        lblSystemType.Text = GetSystemTypeOption()
        Dim strVersion As String
        strVersion = Trim(PublicResource.LoadResString("ID_cap_frmLogin_version", "Version"))
        Me.lblVersion.Text = "CEVA - " & strVersion & " " & GetCurrentVersion()
        txtSwitch.Text = Trim(PublicResource.LoadResString("ID_cap_frmLogin_Switch", "Switch"))
        'LoadDcList()
        CheckConfigSet()
    End Sub



    Private Sub CheckConfigSet()
        Dim strPath As String
        strPath = GetConfigPath()
        If Trim(strPath) = "" Then
            txtSwitch.Visible = False
            Exit Sub
        End If
        txtSwitch.Visible = True
    End Sub

    Private Sub txtRegion_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles txtSwitch.LinkClicked
        Dim frm As New frmConfigSelect
        SetModalFormStyle(frm)
        If frm.ShowDialog(Me) = DialogResult.Yes Then
            lblSystemType.Text = GetSystemTypeOption()
            RestartProgram()
        End If
        frm.Dispose()
        frm = Nothing
    End Sub
#End Region


#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region

    Private Sub frmLogin_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Trim(txtUsername.Text) <> "" Then
            Me.txtPassword.Focus()
        End If
    End Sub


    'Private dc As DataTable
    'Private Sub LoadDcList()
    '    Dim rs As DataSet
    '    Dim look As New Lookup
    '    Try
    '        rs = look.getRegiondcList(CXLookupCallTypeConstants.ccCache, Nothing)
    '        dc = rs.Tables(0)
    '        cboDcCode.DisplayMember = dc.Columns(1).ColumnName
    '        cboDcCode.ValueMember = dc.Columns(0).ColumnName
    '        cboDcCode.DataSource = dc
    '    Catch ex As Exception
    '        COMExpress.BusinessObject.CXEventLog.LogToFile("Login无法取得DC列表:" + ex.Message, CXEventLog.LogTypeConstants.logUI)
    '    End Try
    '    look = Nothing
    'End Sub


    'Private Sub txtUsername_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsername.LostFocus
    '    Try
    '        Dim objUser As clsoperator
    '        objUser = clsoperator.Load(Trim(txtUsername.Text))
    '        If objUser.IsNew Then
    '            Exit Sub
    '        End If
    '        If objUser.dc_code = "" Then
    '            Exit Sub
    '        End If
    '        'cboDcCode.SelectedValue = objUser.dc_code

    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class
#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
'This section will not be overwritten during a round-trip code generation
#End Region
