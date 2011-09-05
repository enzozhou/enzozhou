Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports System.Data
Imports System.Collections
Imports YT.BusinessObject
Imports YT
Public Class frmAuthentication
    Inherits System.Windows.Forms.Form
    Dim look As New YT.BusinessObject.Lookup
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
    Friend WithEvents btnSkuSave As System.Windows.Forms.Button
    Friend WithEvents txtPsw As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAuthentication))
        Me.btnSkuSave = New System.Windows.Forms.Button
        Me.txtPsw = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnSkuSave
        '
        Me.btnSkuSave.Location = New System.Drawing.Point(415, 11)
        Me.btnSkuSave.Name = "btnSkuSave"
        Me.btnSkuSave.Size = New System.Drawing.Size(72, 22)
        Me.btnSkuSave.TabIndex = 50
        Me.btnSkuSave.Text = "确认"
        '
        'txtPsw
        '
        Me.txtPsw.Location = New System.Drawing.Point(59, 12)
        Me.txtPsw.Name = "txtPsw"
        Me.txtPsw.Size = New System.Drawing.Size(334, 21)
        Me.txtPsw.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "密码："
        '
        'frmAuthentication
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(499, 46)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPsw)
        Me.Controls.Add(Me.btnSkuSave)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAuthentication"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "验证"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
    Private Sub btnSkuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSkuSave.Click
        Dim obj As DataSet
        Dim sWhere As String = " where  user_code = '" + UserRightMgr.gUserCode + "' and password = '" + Me.txtPsw.Text + "'"
        obj = look.GetUserListByWhere(sWhere)
        If (obj.Tables(0).Rows.Count > 0) Then
            Me.Close()
            Me.DialogResult = DialogResult.OK
            Return
        End If
        Message("ID_cap_Autherntication_fail", True, "密码错误！")
        Me.txtPsw.Focus()
        ''Me.DialogResult = DialogResult.Cancel
    End Sub
    Private Sub frmAuthentication_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtPsw.Focus()
    End Sub
End Class
