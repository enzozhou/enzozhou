Imports COMExpress.BusinessObject.Security
Imports COMExpress.BusinessObject
Imports System.Threading

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
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmLogin))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboLanguage = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(160, 160)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(96, 27)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        '
        'btnLogin
        '
        Me.btnLogin.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnLogin.Enabled = False
        Me.btnLogin.Location = New System.Drawing.Point(24, 160)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(96, 27)
        Me.btnLogin.TabIndex = 10
        Me.btnLogin.Text = "Login"
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPassword.Location = New System.Drawing.Point(104, 80)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(148, 21)
        Me.txtPassword.TabIndex = 9
        Me.txtPassword.Text = ""
        '
        'txtUsername
        '
        Me.txtUsername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtUsername.Location = New System.Drawing.Point(104, 48)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(148, 21)
        Me.txtUsername.TabIndex = 7
        Me.txtUsername.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Username"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(232, 32)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Please enter your user name and password:"
        '
        'cboLanguage
        '
        Me.cboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLanguage.Location = New System.Drawing.Point(104, 112)
        Me.cboLanguage.Name = "cboLanguage"
        Me.cboLanguage.Size = New System.Drawing.Size(148, 20)
        Me.cboLanguage.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Language"
        '
        'frmLogin
        '
        Me.AcceptButton = Me.btnLogin
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(296, 205)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.btnCancel, Me.btnLogin, Me.txtPassword, Me.txtUsername, Me.Label2, Me.Label1, Me.Label4, Me.cboLanguage})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "System Login"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " COM Express generated code "

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        DoLogin(txtUsername.Text, txtPassword.Text)
    End Sub

    Private Sub DoLogin(ByVal User As String, ByVal Pwd As String)
        Try
            Cursor = Cursors.WaitCursor
            Status("Verifying user...")
            CXBusinessPrincipal.Login(User, Pwd)
            Status()
            Cursor = Cursors.Default

            If Thread.CurrentPrincipal.Identity.IsAuthenticated Then
                MainForm.AppSettings.LoginName = txtUsername.Text
                Me.DialogResult = DialogResult.OK
            Else
                MsgBox("The username and password were not valid", MsgBoxStyle.Exclamation)
            End If
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "DoLogin")
        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.DialogResult = DialogResult.Cancel

    End Sub

    Private Sub txtUsername_TextChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles txtUsername.TextChanged

        btnLogin.Enabled = (Len(txtUsername.Text) > 0)

    End Sub
	
	Private mobjCICol As ArrayList

    Public Sub ShowLanguagesOnly()
        btnCancel.Text = "&Done"
        Me.AcceptButton = btnCancel
        Label1.Visible = False
        Label2.Visible = False
        Label3.Visible = False
        btnLogin.Visible = False
        txtUsername.Visible = False
        txtPassword.Visible = False
        Me.ShowDialog()
    End Sub
    
    Private Sub cboLanguage_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLanguage.SelectedIndexChanged
        Thread.CurrentThread.CurrentUICulture = mobjCICol(cboLanguage.SelectedIndex)
    End Sub
    
    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    	mobjCICol = New ArrayList    		
        mobjCICol.Add(New Globalization.CultureInfo("en-US"))    		
        mobjCICol.Add(New Globalization.CultureInfo("zh-CHS"))
        cboLanguage.DataSource = mobjCICol
        cboLanguage.ValueMember = "Name"
        cboLanguage.DisplayMember = "DisplayName"
        txtUsername.Text = MainForm.AppSettings.LoginName
    End Sub
#End Region


#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
