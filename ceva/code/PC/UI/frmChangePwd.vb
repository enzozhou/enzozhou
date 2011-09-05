Imports COMExpress.BusinessObject.Security
Imports COMExpress.BusinessObject
Imports System.Threading
Imports YT.BusinessObject
Imports YT

Public Class frmChangePwd
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected OverLoads Overrides Sub Dispose(ByVal disposing As Boolean)
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
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtNewPassword2 As System.Windows.Forms.TextBox
    Friend WithEvents lblOldPwd As System.Windows.Forms.Label
    Friend WithEvents lblNewPwd As System.Windows.Forms.Label
    Friend WithEvents lblTip As System.Windows.Forms.Label
    Friend WithEvents lblConfirmPwd As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangePwd))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnLogin = New System.Windows.Forms.Button
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtNewPassword = New System.Windows.Forms.TextBox
        Me.lblOldPwd = New System.Windows.Forms.Label
        Me.lblNewPwd = New System.Windows.Forms.Label
        Me.lblTip = New System.Windows.Forms.Label
        Me.txtNewPassword2 = New System.Windows.Forms.TextBox
        Me.lblConfirmPwd = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Location = New System.Drawing.Point(150, 168)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 27)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLogin.Enabled = False
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnLogin.Location = New System.Drawing.Point(12, 168)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(96, 27)
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "C&hange"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(104, 56)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(160, 21)
        Me.txtPassword.TabIndex = 0
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewPassword.Location = New System.Drawing.Point(104, 85)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword.Size = New System.Drawing.Size(160, 21)
        Me.txtNewPassword.TabIndex = 1
        '
        'lblOldPwd
        '
        Me.lblOldPwd.Location = New System.Drawing.Point(8, 56)
        Me.lblOldPwd.Name = "lblOldPwd"
        Me.lblOldPwd.Size = New System.Drawing.Size(88, 16)
        Me.lblOldPwd.TabIndex = 8
        Me.lblOldPwd.Text = "Old Password"
        '
        'lblNewPwd
        '
        Me.lblNewPwd.Location = New System.Drawing.Point(8, 88)
        Me.lblNewPwd.Name = "lblNewPwd"
        Me.lblNewPwd.Size = New System.Drawing.Size(88, 16)
        Me.lblNewPwd.TabIndex = 6
        Me.lblNewPwd.Text = "New Password"
        '
        'lblTip
        '
        Me.lblTip.Location = New System.Drawing.Point(16, 8)
        Me.lblTip.Name = "lblTip"
        Me.lblTip.Size = New System.Drawing.Size(232, 32)
        Me.lblTip.TabIndex = 12
        Me.lblTip.Text = "Please enter your old password and New password:"
        '
        'txtNewPassword2
        '
        Me.txtNewPassword2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNewPassword2.Location = New System.Drawing.Point(104, 112)
        Me.txtNewPassword2.Name = "txtNewPassword2"
        Me.txtNewPassword2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword2.Size = New System.Drawing.Size(160, 21)
        Me.txtNewPassword2.TabIndex = 2
        '
        'lblConfirmPwd
        '
        Me.lblConfirmPwd.Location = New System.Drawing.Point(8, 113)
        Me.lblConfirmPwd.Name = "lblConfirmPwd"
        Me.lblConfirmPwd.Size = New System.Drawing.Size(96, 31)
        Me.lblConfirmPwd.TabIndex = 13
        Me.lblConfirmPwd.Text = "Confirm New Password"
        '
        'frmChangePwd
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(285, 209)
        Me.Controls.Add(Me.txtNewPassword2)
        Me.Controls.Add(Me.lblConfirmPwd)
        Me.Controls.Add(Me.lblTip)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtNewPassword)
        Me.Controls.Add(Me.lblOldPwd)
        Me.Controls.Add(Me.lblNewPwd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangePwd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region " COM Express generated code "

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        DoLogin(txtPassword.Text, txtNewPassword.Text, txtNewPassword2.Text)
    End Sub

    Private Sub DoLogin(ByVal Pwd As String, ByVal PwdNew As String, ByVal PwdCon As String)
        Try
            Cursor = Cursors.WaitCursor
            Status("Verifying user...")

            'CXBusinessPrincipal.ChangePassword(Pwd, PwdNew)
            Dim result As UserRightMgr.ChangePWDInfoType = UserRightMgr.ChangePWD(Pwd, PwdNew, PwdCon)
            Status()
            Cursor = Cursors.Default

            If result = UserRightMgr.ChangePWDInfoType.Success Then
                'Dim sl As clstranslog
                'sl = sl.Newclstranslog
                'sl.dc_code = UserRightMgr.gDcCode
                'sl.trans_type = "SEC"
                'sl.cmd_type = GeneralType.CmdType.ChangePwdCmd
                'sl.opt_by = UserRightMgr.gUserCode
                'sl.opt_dtime = Now
                'Try
                '    sl.Save()
                'Catch ex As Exception
                'End Try
                Me.DialogResult = DialogResult.OK
            End If
            MsgBox(PublicResource.LoadResString("ID_msg_err_ChangePwd_" & result.ToString), MsgBoxStyle.Exclamation)

         
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "DoLogin")
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.DialogResult = DialogResult.Cancel

    End Sub

    Private Sub NewPasswordChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewPassword.TextChanged, txtNewPassword2.TextChanged
        'btnLogin.Enabled = (txtNewPassword.Text = txtNewPassword2.Text)
        btnLogin.Enabled = (Len(txtNewPassword.Text) > 0 And Len(txtNewPassword2.Text) > 0)
    End Sub
#End Region

#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region

    Private Sub frmChangePwd_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'LoadControlText()
        SetFormResource(Me)
        txtPassword.MaxLength = MainForm.LayoutFile.CXObjectLays("clsOPERATOR").Columns("password_").FieldMaxLen
        txtNewPassword.MaxLength = txtPassword.MaxLength
        txtNewPassword2.MaxLength = txtPassword.MaxLength

    End Sub

    'Private Sub LoadControlText()
    '    SetControlText(Me.lblOldPwd, "ID_cap_frmChangePwd_lblOldPwd", True)
    '    SetControlText(Me.lblNewPwd, "ID_cap_frmChangePwd_lblNewPwd", True)
    '    SetControlText(Me.lblConfirmPwd, "ID_cap_frmChangePwd_lblConfirmPwd", True)
    '    SetControlText(Me.btnCancel, "ID_cap_frmChangePwd_btnCancel", True)
    '    SetControlText(Me.lblTip, "ID_cap_frmChangePwd_lblTip", True)
    '    SetControlText(Me.btnLogin, "ID_cap_frmChangePwd_btnLogin", True)
    '    Me.Text = GetFieldCaption("ID_frmChangePwd_Title", True)
    'End Sub



End Class
#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
'This section will not be overwritten during a round-trip code generation
#End Region
