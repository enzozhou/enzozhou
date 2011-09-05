Imports WMS
Imports YT.BusinessObject
Imports COMExpress.Windows.Forms
Public Class frmDealerSelect
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
    Friend WithEvents bttCancel As System.Windows.Forms.Button
    Friend WithEvents bttOk As System.Windows.Forms.Button
    Friend WithEvents lbldealer_code As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtDealer_code As System.Windows.Forms.TextBox
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents txtPerson As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblPerson As System.Windows.Forms.Label
    Friend WithEvents lblTel As System.Windows.Forms.Label
    Friend WithEvents lblAdress As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDealerSelect))
        Me.txtTel = New System.Windows.Forms.TextBox
        Me.txtPerson = New System.Windows.Forms.TextBox
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.lblPerson = New System.Windows.Forms.Label
        Me.lblTel = New System.Windows.Forms.Label
        Me.lblAdress = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.bttCancel = New System.Windows.Forms.Button
        Me.bttOk = New System.Windows.Forms.Button
        Me.lbldealer_code = New System.Windows.Forms.Label
        Me.txtDealer_code = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'txtTel
        '
        Me.txtTel.Location = New System.Drawing.Point(136, 144)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(272, 21)
        Me.txtTel.TabIndex = 43
        Me.txtTel.Text = ""
        '
        'txtPerson
        '
        Me.txtPerson.Location = New System.Drawing.Point(136, 112)
        Me.txtPerson.Name = "txtPerson"
        Me.txtPerson.Size = New System.Drawing.Size(272, 21)
        Me.txtPerson.TabIndex = 42
        Me.txtPerson.Text = ""
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(136, 80)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(272, 21)
        Me.txtAddress.TabIndex = 41
        Me.txtAddress.Text = ""
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(136, 48)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(272, 21)
        Me.txtName.TabIndex = 0
        Me.txtName.Text = ""
        '
        'lblPerson
        '
        Me.lblPerson.Location = New System.Drawing.Point(26, 112)
        Me.lblPerson.Name = "lblPerson"
        Me.lblPerson.TabIndex = 36
        Me.lblPerson.Text = "联系人"
        '
        'lblTel
        '
        Me.lblTel.Location = New System.Drawing.Point(26, 144)
        Me.lblTel.Name = "lblTel"
        Me.lblTel.TabIndex = 35
        Me.lblTel.Text = "电话"
        '
        'lblAdress
        '
        Me.lblAdress.Location = New System.Drawing.Point(26, 80)
        Me.lblAdress.Name = "lblAdress"
        Me.lblAdress.TabIndex = 34
        Me.lblAdress.Text = "地址"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(26, 48)
        Me.lblName.Name = "lblName"
        Me.lblName.TabIndex = 33
        Me.lblName.Text = "经销商名称"
        '
        'bttCancel
        '
        Me.bttCancel.Location = New System.Drawing.Point(288, 192)
        Me.bttCancel.Name = "bttCancel"
        Me.bttCancel.Size = New System.Drawing.Size(112, 23)
        Me.bttCancel.TabIndex = 32
        Me.bttCancel.Text = "取  消"
        '
        'bttOk
        '
        Me.bttOk.Location = New System.Drawing.Point(144, 192)
        Me.bttOk.Name = "bttOk"
        Me.bttOk.Size = New System.Drawing.Size(112, 23)
        Me.bttOk.TabIndex = 31
        Me.bttOk.Text = "确   定"
        '
        'lbldealer_code
        '
        Me.lbldealer_code.Location = New System.Drawing.Point(24, 16)
        Me.lbldealer_code.Name = "lbldealer_code"
        Me.lbldealer_code.TabIndex = 44
        Me.lbldealer_code.Text = "经销商代码"
        '
        'txtDealer_code
        '
        Me.txtDealer_code.Location = New System.Drawing.Point(136, 16)
        Me.txtDealer_code.Name = "txtDealer_code"
        Me.txtDealer_code.Size = New System.Drawing.Size(272, 21)
        Me.txtDealer_code.TabIndex = 45
        Me.txtDealer_code.Text = ""
        '
        'frmDealerSelect
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(436, 232)
        Me.Controls.Add(Me.txtDealer_code)
        Me.Controls.Add(Me.lbldealer_code)
        Me.Controls.Add(Me.txtTel)
        Me.Controls.Add(Me.txtPerson)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.lblPerson)
        Me.Controls.Add(Me.lblTel)
        Me.Controls.Add(Me.lblAdress)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.bttCancel)
        Me.Controls.Add(Me.bttOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDealerSelect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "经销商查找"
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public txtdealcode As String '经销商代码
    Public strdealname As String '经销商名称
    Public strdealaddress As String '经销商名称
    Public strperson As String '经销商联系人
    Public strdealSome As String
    Dim from As New frmDealerLook
    Private Sub frmDealerSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtAddress.Text = ""
        Me.txtDealer_code.Text = ""
        Me.txtName.Text = ""
        Me.txtPerson.Text = ""
        Me.txtTel.Text = ""
        'getDealerLook()
    End Sub


    Private Sub bttOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttOk.Click
        'Dim from As New frmDealerLook
        Dim rst As DialogResult
        from.txtdealcode = Me.txtDealer_code.Text.Trim()
        from.txtadress = Me.txtAddress.Text.Trim()
        from.txtname = Me.txtName.Text.Trim()
        from.txtperson = Me.txtPerson.Text.Trim()
        from.txttel = Me.txtTel.Text.Trim()
        If Me.txtAddress.Text = "" And Me.txtDealer_code.Text = "" And Me.txtName.Text = "" And Me.txtPerson.Text = "" And Me.txtTel.Text = "" Then
            Message("ID_msg_frmCarrierSelect_PlsInputSelectCondition", True, "请至少输入一个查询条件!")
            Return
        End If
        SetModalFormStyle(from)
        If from.ShowDialog(Me) = DialogResult.OK Then
            txtdealcode = from.txtdeal_code
            Me.strdealname = from.strdealname
            Me.strperson = from.strperson
            Me.strdealaddress = from.strdealaddress
            Me.strdealSome = from.strSomeCheck
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Cancel
        End If
        Me.Close()
    End Sub

    Private Sub bttCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
    Public Sub DealerSuppor(ByVal Suppor As Boolean)
        from.dealSuppor = Suppor
    End Sub
End Class
