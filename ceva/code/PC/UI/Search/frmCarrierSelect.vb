Imports WMS
Imports YT.BusinessObject
Imports COMExpress.Windows.Forms


Public Class frmCarrierSelect
    Inherits System.Windows.Forms.Form
    Dim names As String
    Public txtcarrcode As String '运输公司代码
    Public strCarrName As String '运输公司名称
    Public strCarrSome As String '多选公司代码
    ' Public carrSuppor As Boolean
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
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblAdress As System.Windows.Forms.Label
    Friend WithEvents bttCancel As System.Windows.Forms.Button
    Friend WithEvents bttOk As System.Windows.Forms.Button
    Friend WithEvents lblcarr_code As System.Windows.Forms.Label
    Friend WithEvents lblcarr_name As System.Windows.Forms.Label
    Friend WithEvents txtCarr_code As System.Windows.Forms.TextBox
    Friend WithEvents txtCarr_name As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCarrierSelect))
        Me.txtCarr_code = New System.Windows.Forms.TextBox
        Me.lblcarr_code = New System.Windows.Forms.Label
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.txtCarr_name = New System.Windows.Forms.TextBox
        Me.lblAdress = New System.Windows.Forms.Label
        Me.lblcarr_name = New System.Windows.Forms.Label
        Me.bttCancel = New System.Windows.Forms.Button
        Me.bttOk = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtCarr_code
        '
        Me.txtCarr_code.Location = New System.Drawing.Point(136, 16)
        Me.txtCarr_code.Name = "txtCarr_code"
        Me.txtCarr_code.Size = New System.Drawing.Size(272, 21)
        Me.txtCarr_code.TabIndex = 57
        Me.txtCarr_code.Text = ""
        '
        'lblcarr_code
        '
        Me.lblcarr_code.Location = New System.Drawing.Point(32, 16)
        Me.lblcarr_code.Name = "lblcarr_code"
        Me.lblcarr_code.TabIndex = 56
        Me.lblcarr_code.Text = "运输公司代码"
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(136, 80)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(272, 21)
        Me.txtAddress.TabIndex = 53
        Me.txtAddress.Text = ""
        '
        'txtCarr_name
        '
        Me.txtCarr_name.Location = New System.Drawing.Point(136, 48)
        Me.txtCarr_name.Name = "txtCarr_name"
        Me.txtCarr_name.Size = New System.Drawing.Size(272, 21)
        Me.txtCarr_name.TabIndex = 0
        Me.txtCarr_name.Text = ""
        '
        'lblAdress
        '
        Me.lblAdress.Location = New System.Drawing.Point(32, 80)
        Me.lblAdress.Name = "lblAdress"
        Me.lblAdress.TabIndex = 49
        Me.lblAdress.Text = "地址"
        '
        'lblcarr_name
        '
        Me.lblcarr_name.Location = New System.Drawing.Point(32, 48)
        Me.lblcarr_name.Name = "lblcarr_name"
        Me.lblcarr_name.TabIndex = 48
        Me.lblcarr_name.Text = "运输公司名称"
        '
        'bttCancel
        '
        Me.bttCancel.Location = New System.Drawing.Point(280, 120)
        Me.bttCancel.Name = "bttCancel"
        Me.bttCancel.Size = New System.Drawing.Size(112, 23)
        Me.bttCancel.TabIndex = 47
        Me.bttCancel.Text = "取  消"
        '
        'bttOk
        '
        Me.bttOk.Location = New System.Drawing.Point(136, 120)
        Me.bttOk.Name = "bttOk"
        Me.bttOk.Size = New System.Drawing.Size(112, 23)
        Me.bttOk.TabIndex = 46
        Me.bttOk.Text = "确   定"
        '
        'frmCarrierSelect
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(434, 160)
        Me.Controls.Add(Me.txtCarr_code)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtCarr_name)
        Me.Controls.Add(Me.lblcarr_code)
        Me.Controls.Add(Me.lblAdress)
        Me.Controls.Add(Me.lblcarr_name)
        Me.Controls.Add(Me.bttCancel)
        Me.Controls.Add(Me.bttOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCarrierSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "运输公司查找"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim from As New frmCarrierlook
    Private Sub frmCarrierSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtAddress.Text = ""
        Me.txtCarr_code.Text = ""
        Me.txtCarr_name.Text = ""
        'test()
    End Sub

    Private Sub bttOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttOk.Click
        ' Dim from As New frmCarrierlook
        from.txtcarrcode = Me.txtCarr_code.Text.Trim()
        from.txtcarrname = Me.txtCarr_name.Text.Trim()
        from.txtaddress = Me.txtAddress.Text.Trim()
        If Me.txtCarr_code.Text.Trim() = "" And Me.txtCarr_name.Text.Trim() = "" And Me.txtAddress.Text.Trim() = "" Then
            Message("ID_msg_frmCarrierSelect_PlsInputSelectCondition", True, "请至少输入一个查询条件!")

            Return
        End If
        SetModalFormStyle(from)
        If from.ShowDialog(Me) = DialogResult.OK Then
            txtcarrcode = from.txtCarr_code
            Me.strCarrName = from.strCarrname
            strCarrSome = from.strSomeCheck
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Cancel
        End If
        Me.Close()
    End Sub

    Private Sub bttCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
        Return

    End Sub
    Public Sub carrierSuppor(ByVal Suppor As Boolean)
        from.carrSuppor = Suppor
    End Sub
End Class
