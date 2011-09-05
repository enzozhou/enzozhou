Imports COMExpress.BusinessObject.Security
Imports COMExpress.BusinessObject
Imports System.Threading

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword2 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChangePwd))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNewPassword2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(160, 168)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 27)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnLogin.Enabled = False
        Me.btnLogin.Location = New System.Drawing.Point(24, 168)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(96, 27)
        Me.btnLogin.TabIndex = 3
        Me.btnLogin.Text = "C&hange"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtPassword.Location = New System.Drawing.Point(104, 56)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(148, 21)
        Me.txtPassword.TabIndex = 0
        Me.txtPassword.Text = ""
        '
        'txtNewPassword
        '
        Me.txtNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtNewPassword.Location = New System.Drawing.Point(104, 85)
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword.Size = New System.Drawing.Size(148, 21)
        Me.txtNewPassword.TabIndex = 1
        Me.txtNewPassword.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Old Password"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "New Password"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(232, 32)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Please enter your old password and New password:"
        '
        'txtNewPassword2
        '
        Me.txtNewPassword2.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtNewPassword2.Location = New System.Drawing.Point(104, 112)
        Me.txtNewPassword2.Name = "txtNewPassword2"
        Me.txtNewPassword2.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtNewPassword2.Size = New System.Drawing.Size(148, 21)
        Me.txtNewPassword2.TabIndex = 2
        Me.txtNewPassword2.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 31)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Confirm New Password"
        '
        'frmChangePwd
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(296, 207)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtNewPassword2, Me.Label4, Me.Label3, Me.btnCancel, Me.btnLogin, Me.txtPassword, Me.txtNewPassword, Me.Label2, Me.Label1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangePwd"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change Password"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " COM Express generated code "

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        DoLogin(txtPassword.Text, txtNewPassword.Text)
    End Sub

    Private Sub DoLogin(ByVal Pwd As String, ByVal PwdNew As String)
        Try
            Cursor = Cursors.WaitCursor
            Status("Verifying user...")

            CXBusinessPrincipal.ChangePassword(Pwd, PwdNew)
            Status()
            Cursor = Cursors.Default

            If Thread.CurrentPrincipal.Identity.IsAuthenticated Then
                Me.DialogResult = DialogResult.OK
            Else
                MsgBox("Changing password failed.", MsgBoxStyle.Exclamation)
            End If
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "DoLogin")
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.DialogResult = DialogResult.Cancel

    End Sub

    Private Sub NewPasswordChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewPassword.TextChanged, txtNewPassword2.TextChanged

        btnLogin.Enabled = (txtNewPassword.Text = txtNewPassword2.Text)

    End Sub
#End Region

#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
