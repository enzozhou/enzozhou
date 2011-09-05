Imports WMS
Imports YT.BusinessObject
Imports COMExpress.Windows.Forms
Imports System.Collections.Hashtable
Public Class frmclsskuinfoselect
    Inherits System.Windows.Forms.Form
    Dim lookup As New lookup
    Public btt As Boolean
    Public txtskuno As String '产品代码
    Public strmodelno As String '产品型号
    Public strskuSome As String

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
    Friend WithEvents bttOk As System.Windows.Forms.Button
    Friend WithEvents bttCancel As System.Windows.Forms.Button
    Friend WithEvents lblsku_desc As System.Windows.Forms.Label
    Friend WithEvents lblmodel_no As System.Windows.Forms.Label
    Friend WithEvents lblsix_code As System.Windows.Forms.Label
    Friend WithEvents lbldepartment As System.Windows.Forms.Label
    Friend WithEvents lblvender_name As System.Windows.Forms.Label
    Friend WithEvents lblcategory As System.Windows.Forms.Label
    Friend WithEvents txtSku_no As System.Windows.Forms.TextBox
    Friend WithEvents txtSku_desc As System.Windows.Forms.TextBox
    Friend WithEvents txtModel_no As System.Windows.Forms.TextBox
    Friend WithEvents txtSix_code As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartment As System.Windows.Forms.TextBox
    Friend WithEvents txtVender_name As System.Windows.Forms.TextBox
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents lblsku_no As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmclsskuinfoselect))
        Me.bttOk = New System.Windows.Forms.Button
        Me.bttCancel = New System.Windows.Forms.Button
        Me.lblsku_no = New System.Windows.Forms.Label
        Me.lblsku_desc = New System.Windows.Forms.Label
        Me.lblmodel_no = New System.Windows.Forms.Label
        Me.lblsix_code = New System.Windows.Forms.Label
        Me.lbldepartment = New System.Windows.Forms.Label
        Me.lblvender_name = New System.Windows.Forms.Label
        Me.lblcategory = New System.Windows.Forms.Label
        Me.txtSku_no = New System.Windows.Forms.TextBox
        Me.txtSku_desc = New System.Windows.Forms.TextBox
        Me.txtModel_no = New System.Windows.Forms.TextBox
        Me.txtSix_code = New System.Windows.Forms.TextBox
        Me.txtDepartment = New System.Windows.Forms.TextBox
        Me.txtVender_name = New System.Windows.Forms.TextBox
        Me.txtCategory = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'bttOk
        '
        Me.bttOk.Location = New System.Drawing.Point(128, 232)
        Me.bttOk.Name = "bttOk"
        Me.bttOk.Size = New System.Drawing.Size(93, 24)
        Me.bttOk.TabIndex = 14
        Me.bttOk.Text = "确   定"
        '
        'bttCancel
        '
        Me.bttCancel.Location = New System.Drawing.Point(256, 232)
        Me.bttCancel.Name = "bttCancel"
        Me.bttCancel.Size = New System.Drawing.Size(94, 24)
        Me.bttCancel.TabIndex = 15
        Me.bttCancel.Text = "取  消"
        '
        'lblsku_no
        '
        Me.lblsku_no.Location = New System.Drawing.Point(27, 15)
        Me.lblsku_no.Name = "lblsku_no"
        Me.lblsku_no.Size = New System.Drawing.Size(83, 21)
        Me.lblsku_no.TabIndex = 16
        Me.lblsku_no.Text = "产品号码"
        '
        'lblsku_desc
        '
        Me.lblsku_desc.Location = New System.Drawing.Point(27, 45)
        Me.lblsku_desc.Name = "lblsku_desc"
        Me.lblsku_desc.Size = New System.Drawing.Size(83, 21)
        Me.lblsku_desc.TabIndex = 17
        Me.lblsku_desc.Text = "产品描述"
        '
        'lblmodel_no
        '
        Me.lblmodel_no.Location = New System.Drawing.Point(27, 74)
        Me.lblmodel_no.Name = "lblmodel_no"
        Me.lblmodel_no.Size = New System.Drawing.Size(83, 22)
        Me.lblmodel_no.TabIndex = 19
        Me.lblmodel_no.Text = "型号"
        '
        'lblsix_code
        '
        Me.lblsix_code.Location = New System.Drawing.Point(27, 104)
        Me.lblsix_code.Name = "lblsix_code"
        Me.lblsix_code.Size = New System.Drawing.Size(83, 21)
        Me.lblsix_code.TabIndex = 18
        Me.lblsix_code.Text = "六位代码"
        '
        'lbldepartment
        '
        Me.lbldepartment.Location = New System.Drawing.Point(27, 134)
        Me.lbldepartment.Name = "lbldepartment"
        Me.lbldepartment.Size = New System.Drawing.Size(83, 21)
        Me.lbldepartment.TabIndex = 21
        Me.lbldepartment.Text = "部门"
        '
        'lblvender_name
        '
        Me.lblvender_name.Location = New System.Drawing.Point(27, 163)
        Me.lblvender_name.Name = "lblvender_name"
        Me.lblvender_name.Size = New System.Drawing.Size(83, 22)
        Me.lblvender_name.TabIndex = 20
        Me.lblvender_name.Text = "供应商"
        '
        'lblcategory
        '
        Me.lblcategory.Location = New System.Drawing.Point(27, 201)
        Me.lblcategory.Name = "lblcategory"
        Me.lblcategory.Size = New System.Drawing.Size(83, 21)
        Me.lblcategory.TabIndex = 23
        Me.lblcategory.Text = "产品组"
        '
        'txtSku_no
        '
        Me.txtSku_no.Location = New System.Drawing.Point(120, 15)
        Me.txtSku_no.Name = "txtSku_no"
        Me.txtSku_no.Size = New System.Drawing.Size(227, 20)
        Me.txtSku_no.TabIndex = 24
        Me.txtSku_no.Text = ""
        '
        'txtSku_desc
        '
        Me.txtSku_desc.Location = New System.Drawing.Point(120, 45)
        Me.txtSku_desc.Name = "txtSku_desc"
        Me.txtSku_desc.Size = New System.Drawing.Size(227, 20)
        Me.txtSku_desc.TabIndex = 0
        Me.txtSku_desc.Text = ""
        '
        'txtModel_no
        '
        Me.txtModel_no.Location = New System.Drawing.Point(120, 74)
        Me.txtModel_no.Name = "txtModel_no"
        Me.txtModel_no.Size = New System.Drawing.Size(227, 20)
        Me.txtModel_no.TabIndex = 26
        Me.txtModel_no.Text = ""
        '
        'txtSix_code
        '
        Me.txtSix_code.Location = New System.Drawing.Point(120, 104)
        Me.txtSix_code.Name = "txtSix_code"
        Me.txtSix_code.Size = New System.Drawing.Size(227, 20)
        Me.txtSix_code.TabIndex = 27
        Me.txtSix_code.Text = ""
        '
        'txtDepartment
        '
        Me.txtDepartment.Location = New System.Drawing.Point(120, 134)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(227, 20)
        Me.txtDepartment.TabIndex = 28
        Me.txtDepartment.Text = ""
        '
        'txtVender_name
        '
        Me.txtVender_name.Location = New System.Drawing.Point(120, 163)
        Me.txtVender_name.Name = "txtVender_name"
        Me.txtVender_name.Size = New System.Drawing.Size(227, 20)
        Me.txtVender_name.TabIndex = 29
        Me.txtVender_name.Text = ""
        '
        'txtCategory
        '
        Me.txtCategory.Location = New System.Drawing.Point(120, 193)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(227, 20)
        Me.txtCategory.TabIndex = 30
        Me.txtCategory.Text = ""
        '
        'frmclsskuinfoselect
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(366, 267)
        Me.Controls.Add(Me.txtCategory)
        Me.Controls.Add(Me.txtVender_name)
        Me.Controls.Add(Me.txtDepartment)
        Me.Controls.Add(Me.txtSix_code)
        Me.Controls.Add(Me.txtModel_no)
        Me.Controls.Add(Me.txtSku_desc)
        Me.Controls.Add(Me.txtSku_no)
        Me.Controls.Add(Me.lblcategory)
        Me.Controls.Add(Me.lbldepartment)
        Me.Controls.Add(Me.lblvender_name)
        Me.Controls.Add(Me.lblmodel_no)
        Me.Controls.Add(Me.lblsix_code)
        Me.Controls.Add(Me.lblsku_desc)
        Me.Controls.Add(Me.lblsku_no)
        Me.Controls.Add(Me.bttCancel)
        Me.Controls.Add(Me.bttOk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmclsskuinfoselect"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "查找"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim from As New frmskuinfolook
    Private Sub frmclsskuinfoselect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '系统初始化
        Me.txtSku_no.Text = ""
        Me.txtSku_desc.Text = ""
        Me.txtCategory.Text = ""
        Me.txtDepartment.Text = ""
        Me.txtModel_no.Text = ""
        Me.txtSix_code.Text = ""
        Me.txtVender_name.Text = ""
    End Sub
 
    Private Sub bttOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttOk.Click

        'Dim from As New frmskuinfolook
        from.txtskuno = Me.txtSku_no.Text.Trim()
        from.txtskudesc = Me.txtSku_desc.Text.Trim()
        from.txtmodelno = Me.txtModel_no.Text.Trim()
        from.txtsixcode = Me.txtSix_code.Text.Trim()
        from.txtdepartment = Me.txtDepartment.Text.Trim()
        from.txtvendername = Me.txtVender_name.Text.Trim()
        from.txtcategory = Me.txtCategory.Text.Trim()
        If Me.txtSku_no.Text = "" And Me.txtSku_desc.Text = "" And Me.txtCategory.Text = "" And Me.txtDepartment.Text = "" And Me.txtModel_no.Text = "" And Me.txtSix_code.Text = "" And Me.txtVender_name.Text = "" Then
            Message("ID_msg_frmCarrierSelect_PlsInputSelectCondition", True, "请至少输入一个查询条件!")
            Return
        End If
        SetModalFormStyle(from)
        If from.ShowDialog(Me) = DialogResult.OK Then
            txtskuno = from.txtskuno
            strmodelno = from.strmodelno
            Me.strskuSome = from.strSomeCheck
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.Cancel
        End If
        Me.Close()
    End Sub

    Private Sub bttCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttCancel.Click
        'Dim frm As frmSkuSearLook
        'frm.Show()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
        'Return
    End Sub
    Public Sub skuinfoSuppor(ByVal Suppor As Boolean)
        from.skuSuppor = Suppor
    End Sub
End Class
