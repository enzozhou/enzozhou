Imports COMExpress.Windows.Forms
Imports YT.BusinessObject
Public Class frmDnhdrSearch
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
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnAdvance As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtVender_name As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDisableSNO As System.Windows.Forms.CheckBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Grpbarcode As System.Windows.Forms.GroupBox
    Friend WithEvents lbldn_no As System.Windows.Forms.Label
    Friend WithEvents labown_code As System.Windows.Forms.Label
    Friend WithEvents labdescription As System.Windows.Forms.Label
    Friend WithEvents txtOwn_code As System.Windows.Forms.TextBox
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents txtDn_no As System.Windows.Forms.TextBox
    Friend WithEvents labdue_date As System.Windows.Forms.Label
    Friend WithEvents txtdue_date As System.Windows.Forms.TextBox
    Friend WithEvents labdoc_type As System.Windows.Forms.Label
    Friend WithEvents lblstat_type As System.Windows.Forms.Label
    Friend WithEvents txtStat_type As System.Windows.Forms.TextBox
    Friend WithEvents lblstatus_code As System.Windows.Forms.Label
    Friend WithEvents txtStatus_code As System.Windows.Forms.TextBox
    Friend WithEvents lbldeal_to As System.Windows.Forms.Label
    Friend WithEvents lbldeal_name As System.Windows.Forms.Label
    Friend WithEvents txtDeal_name As System.Windows.Forms.TextBox
    Friend WithEvents txtDeal_to As System.Windows.Forms.TextBox
    Friend WithEvents lbldeal_person As System.Windows.Forms.Label
    Friend WithEvents txtDeal_person As System.Windows.Forms.TextBox
    Friend WithEvents lblunloading_Address As System.Windows.Forms.Label
    Friend WithEvents lblinstruction As System.Windows.Forms.Label
    Friend WithEvents txtUnloading_Address As System.Windows.Forms.TextBox
    Friend WithEvents txtInstruction As System.Windows.Forms.TextBox
    Friend WithEvents cboSno As System.Windows.Forms.ComboBox 'COMExpress.Windows.Forms.SearchEx.CXComboBoxEx
    Friend WithEvents txtSku_no As System.Windows.Forms.TextBox
    Friend WithEvents txtDoc_type As System.Windows.Forms.TextBox
    Friend WithEvents tabOrther As System.Windows.Forms.TabPage
    Friend WithEvents lblSku As System.Windows.Forms.Label
    Friend WithEvents cckSkuStatus As System.Windows.Forms.CheckBox
    Friend WithEvents cboSkuStatus As System.Windows.Forms.ComboBox 'COMExpress.Windows.Forms.SearchEx.CXComboBoxEx
    Friend WithEvents lblskuStatus As System.Windows.Forms.Label
    Friend WithEvents txtSku_ref As System.Windows.Forms.TextBox
    Friend WithEvents lblSku_ref As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDnhdrSearch))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.labdescription = New System.Windows.Forms.Label
        Me.labown_code = New System.Windows.Forms.Label
        Me.labdue_date = New System.Windows.Forms.Label
        Me.labdoc_type = New System.Windows.Forms.Label
        Me.lblstat_type = New System.Windows.Forms.Label
        Me.txtStat_type = New System.Windows.Forms.TextBox
        Me.txtStatus_code = New System.Windows.Forms.TextBox
        Me.txtDeal_to = New System.Windows.Forms.TextBox
        Me.txtDeal_name = New System.Windows.Forms.TextBox
        Me.txtDeal_person = New System.Windows.Forms.TextBox
        Me.txtUnloading_Address = New System.Windows.Forms.TextBox
        Me.lblinstruction = New System.Windows.Forms.Label
        Me.lblunloading_Address = New System.Windows.Forms.Label
        Me.lbldeal_name = New System.Windows.Forms.Label
        Me.lbldeal_person = New System.Windows.Forms.Label
        Me.txtDn_no = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtdue_date = New System.Windows.Forms.TextBox
        Me.txtOwn_code = New System.Windows.Forms.TextBox
        Me.txtDoc_type = New System.Windows.Forms.TextBox
        Me.lbldn_no = New System.Windows.Forms.Label
        Me.lblstatus_code = New System.Windows.Forms.Label
        Me.txtInstruction = New System.Windows.Forms.TextBox
        Me.lbldeal_to = New System.Windows.Forms.Label
        Me.tabOrther = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkDisableSNO = New System.Windows.Forms.CheckBox
        Me.cboSno = New System.Windows.Forms.ComboBox ' COMExpress.Windows.Forms.SearchEx.CXComboBoxEx
        Me.Label11 = New System.Windows.Forms.Label
        Me.Grpbarcode = New System.Windows.Forms.GroupBox
        Me.txtSku_no = New System.Windows.Forms.TextBox
        Me.lblSku = New System.Windows.Forms.Label
        Me.btnAdvance = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.txtVender_name = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cckSkuStatus = New System.Windows.Forms.CheckBox
        Me.cboSkuStatus = New System.Windows.Forms.ComboBox ' COMExpress.Windows.Forms.SearchEx.CXComboBoxEx
        Me.lblskuStatus = New System.Windows.Forms.Label
        Me.txtSku_ref = New System.Windows.Forms.TextBox
        Me.lblSku_ref = New System.Windows.Forms.Label
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.tabOrther.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Grpbarcode.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.tabOrther)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(595, 336)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.labdescription)
        Me.TabPage1.Controls.Add(Me.labown_code)
        Me.TabPage1.Controls.Add(Me.labdue_date)
        Me.TabPage1.Controls.Add(Me.labdoc_type)
        Me.TabPage1.Controls.Add(Me.lblstat_type)
        Me.TabPage1.Controls.Add(Me.txtStat_type)
        Me.TabPage1.Controls.Add(Me.txtStatus_code)
        Me.TabPage1.Controls.Add(Me.txtDeal_to)
        Me.TabPage1.Controls.Add(Me.txtDeal_name)
        Me.TabPage1.Controls.Add(Me.txtDeal_person)
        Me.TabPage1.Controls.Add(Me.txtUnloading_Address)
        Me.TabPage1.Controls.Add(Me.lblinstruction)
        Me.TabPage1.Controls.Add(Me.lblunloading_Address)
        Me.TabPage1.Controls.Add(Me.lbldeal_name)
        Me.TabPage1.Controls.Add(Me.lbldeal_person)
        Me.TabPage1.Controls.Add(Me.txtDn_no)
        Me.TabPage1.Controls.Add(Me.txtDescription)
        Me.TabPage1.Controls.Add(Me.txtdue_date)
        Me.TabPage1.Controls.Add(Me.txtOwn_code)
        Me.TabPage1.Controls.Add(Me.txtDoc_type)
        Me.TabPage1.Controls.Add(Me.lbldn_no)
        Me.TabPage1.Controls.Add(Me.lblstatus_code)
        Me.TabPage1.Controls.Add(Me.txtInstruction)
        Me.TabPage1.Controls.Add(Me.lbldeal_to)
        Me.TabPage1.Location = New System.Drawing.Point(4, 21)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(587, 311)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "其本信息"
        '
        'labdescription
        '
        Me.labdescription.Location = New System.Drawing.Point(24, 40)
        Me.labdescription.Name = "labdescription"
        Me.labdescription.TabIndex = 80
        Me.labdescription.Text = "描述"
        '
        'labown_code
        '
        Me.labown_code.Location = New System.Drawing.Point(24, 64)
        Me.labown_code.Name = "labown_code"
        Me.labown_code.TabIndex = 79
        Me.labown_code.Text = "仓库"
        '
        'labdue_date
        '
        Me.labdue_date.Location = New System.Drawing.Point(24, 88)
        Me.labdue_date.Name = "labdue_date"
        Me.labdue_date.TabIndex = 78
        Me.labdue_date.Text = "出货日期"
        '
        'labdoc_type
        '
        Me.labdoc_type.Location = New System.Drawing.Point(24, 112)
        Me.labdoc_type.Name = "labdoc_type"
        Me.labdoc_type.TabIndex = 77
        Me.labdoc_type.Text = "单据类型"
        '
        'lblstat_type
        '
        Me.lblstat_type.Location = New System.Drawing.Point(24, 136)
        Me.lblstat_type.Name = "lblstat_type"
        Me.lblstat_type.TabIndex = 76
        Me.lblstat_type.Text = "操作类型"
        '
        'txtStat_type
        '
        Me.txtStat_type.Location = New System.Drawing.Point(136, 136)
        Me.txtStat_type.Name = "txtStat_type"
        Me.txtStat_type.Size = New System.Drawing.Size(432, 21)
        Me.txtStat_type.TabIndex = 75
        Me.txtStat_type.Text = ""
        '
        'txtStatus_code
        '
        Me.txtStatus_code.Location = New System.Drawing.Point(136, 160)
        Me.txtStatus_code.Name = "txtStatus_code"
        Me.txtStatus_code.Size = New System.Drawing.Size(432, 21)
        Me.txtStatus_code.TabIndex = 74
        Me.txtStatus_code.Text = ""
        '
        'txtDeal_to
        '
        Me.txtDeal_to.Location = New System.Drawing.Point(136, 184)
        Me.txtDeal_to.Name = "txtDeal_to"
        Me.txtDeal_to.Size = New System.Drawing.Size(432, 21)
        Me.txtDeal_to.TabIndex = 73
        Me.txtDeal_to.Text = ""
        '
        'txtDeal_name
        '
        Me.txtDeal_name.Location = New System.Drawing.Point(136, 208)
        Me.txtDeal_name.Name = "txtDeal_name"
        Me.txtDeal_name.Size = New System.Drawing.Size(432, 21)
        Me.txtDeal_name.TabIndex = 72
        Me.txtDeal_name.Text = ""
        '
        'txtDeal_person
        '
        Me.txtDeal_person.Location = New System.Drawing.Point(136, 232)
        Me.txtDeal_person.Name = "txtDeal_person"
        Me.txtDeal_person.Size = New System.Drawing.Size(432, 21)
        Me.txtDeal_person.TabIndex = 71
        Me.txtDeal_person.Text = ""
        '
        'txtUnloading_Address
        '
        Me.txtUnloading_Address.Location = New System.Drawing.Point(136, 256)
        Me.txtUnloading_Address.Name = "txtUnloading_Address"
        Me.txtUnloading_Address.Size = New System.Drawing.Size(432, 21)
        Me.txtUnloading_Address.TabIndex = 70
        Me.txtUnloading_Address.Text = ""
        '
        'lblinstruction
        '
        Me.lblinstruction.Location = New System.Drawing.Point(24, 280)
        Me.lblinstruction.Name = "lblinstruction"
        Me.lblinstruction.TabIndex = 69
        Me.lblinstruction.Text = "出货指导"
        '
        'lblunloading_Address
        '
        Me.lblunloading_Address.Location = New System.Drawing.Point(24, 256)
        Me.lblunloading_Address.Name = "lblunloading_Address"
        Me.lblunloading_Address.Size = New System.Drawing.Size(96, 23)
        Me.lblunloading_Address.TabIndex = 68
        Me.lblunloading_Address.Text = "卸货地址"
        '
        'lbldeal_name
        '
        Me.lbldeal_name.Location = New System.Drawing.Point(24, 208)
        Me.lbldeal_name.Name = "lbldeal_name"
        Me.lbldeal_name.Size = New System.Drawing.Size(96, 23)
        Me.lbldeal_name.TabIndex = 67
        Me.lbldeal_name.Text = "送达方名称"
        '
        'lbldeal_person
        '
        Me.lbldeal_person.Location = New System.Drawing.Point(24, 232)
        Me.lbldeal_person.Name = "lbldeal_person"
        Me.lbldeal_person.Size = New System.Drawing.Size(96, 23)
        Me.lbldeal_person.TabIndex = 67
        Me.lbldeal_person.Text = "送达方联系"
        '
        'txtDn_no
        '
        Me.txtDn_no.Location = New System.Drawing.Point(136, 16)
        Me.txtDn_no.Name = "txtDn_no"
        Me.txtDn_no.Size = New System.Drawing.Size(432, 21)
        Me.txtDn_no.TabIndex = 58
        Me.txtDn_no.Text = ""
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(136, 40)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(432, 21)
        Me.txtDescription.TabIndex = 50
        Me.txtDescription.Text = ""
        '
        'txtdue_date
        '
        Me.txtdue_date.Location = New System.Drawing.Point(136, 88)
        Me.txtdue_date.Name = "txtdue_date"
        Me.txtdue_date.Size = New System.Drawing.Size(432, 21)
        Me.txtdue_date.TabIndex = 59
        Me.txtdue_date.Text = ""
        '
        'txtOwn_code
        '
        Me.txtOwn_code.Location = New System.Drawing.Point(136, 64)
        Me.txtOwn_code.Name = "txtOwn_code"
        Me.txtOwn_code.Size = New System.Drawing.Size(432, 21)
        Me.txtOwn_code.TabIndex = 60
        Me.txtOwn_code.Text = ""
        '
        'txtDoc_type
        '
        Me.txtDoc_type.Location = New System.Drawing.Point(136, 112)
        Me.txtDoc_type.Name = "txtDoc_type"
        Me.txtDoc_type.Size = New System.Drawing.Size(432, 21)
        Me.txtDoc_type.TabIndex = 64
        Me.txtDoc_type.Text = ""
        '
        'lbldn_no
        '
        Me.lbldn_no.Location = New System.Drawing.Point(24, 16)
        Me.lbldn_no.Name = "lbldn_no"
        Me.lbldn_no.TabIndex = 51
        Me.lbldn_no.Text = "单号"
        '
        'lblstatus_code
        '
        Me.lblstatus_code.Location = New System.Drawing.Point(24, 160)
        Me.lblstatus_code.Name = "lblstatus_code"
        Me.lblstatus_code.Size = New System.Drawing.Size(96, 24)
        Me.lblstatus_code.TabIndex = 55
        Me.lblstatus_code.Text = "状态"
        '
        'txtInstruction
        '
        Me.txtInstruction.Location = New System.Drawing.Point(136, 280)
        Me.txtInstruction.Name = "txtInstruction"
        Me.txtInstruction.Size = New System.Drawing.Size(432, 21)
        Me.txtInstruction.TabIndex = 63
        Me.txtInstruction.Text = ""
        '
        'lbldeal_to
        '
        Me.lbldeal_to.Location = New System.Drawing.Point(24, 184)
        Me.lbldeal_to.Name = "lbldeal_to"
        Me.lbldeal_to.TabIndex = 66
        Me.lbldeal_to.Text = "送达方"
        '
        'tabOrther
        '
        Me.tabOrther.Controls.Add(Me.GroupBox2)
        Me.tabOrther.Controls.Add(Me.Grpbarcode)
        Me.tabOrther.Location = New System.Drawing.Point(4, 21)
        Me.tabOrther.Name = "tabOrther"
        Me.tabOrther.Size = New System.Drawing.Size(587, 311)
        Me.tabOrther.TabIndex = 1
        Me.tabOrther.Text = "其它"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkDisableSNO)
        Me.GroupBox2.Controls.Add(Me.cboSno)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 216)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(552, 64)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "机身号指定"
        '
        'chkDisableSNO
        '
        Me.chkDisableSNO.Location = New System.Drawing.Point(365, 24)
        Me.chkDisableSNO.Name = "chkDisableSNO"
        Me.chkDisableSNO.Size = New System.Drawing.Size(125, 26)
        Me.chkDisableSNO.TabIndex = 4
        Me.chkDisableSNO.Text = "全部"
        '
        'cboSno
        '
        Me.cboSno.ItemHeight = 12
        Me.cboSno.Location = New System.Drawing.Point(152, 24)
        Me.cboSno.Name = "cboSno"
        Me.cboSno.Size = New System.Drawing.Size(192, 20)
        Me.cboSno.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(24, 24)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(106, 26)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "机身号"
        '
        'Grpbarcode
        '
        Me.Grpbarcode.Controls.Add(Me.txtSku_ref)
        Me.Grpbarcode.Controls.Add(Me.lblSku_ref)
        Me.Grpbarcode.Controls.Add(Me.cckSkuStatus)
        Me.Grpbarcode.Controls.Add(Me.cboSkuStatus)
        Me.Grpbarcode.Controls.Add(Me.lblskuStatus)
        Me.Grpbarcode.Controls.Add(Me.txtSku_no)
        Me.Grpbarcode.Controls.Add(Me.lblSku)
        Me.Grpbarcode.Location = New System.Drawing.Point(16, 24)
        Me.Grpbarcode.Name = "Grpbarcode"
        Me.Grpbarcode.Size = New System.Drawing.Size(552, 184)
        Me.Grpbarcode.TabIndex = 47
        Me.Grpbarcode.TabStop = False
        Me.Grpbarcode.Text = "发货明细"
        '
        'txtSku_no
        '
        Me.txtSku_no.Location = New System.Drawing.Point(160, 17)
        Me.txtSku_no.Name = "txtSku_no"
        Me.txtSku_no.Size = New System.Drawing.Size(341, 21)
        Me.txtSku_no.TabIndex = 43
        Me.txtSku_no.Text = ""
        '
        'lblSku
        '
        Me.lblSku.Location = New System.Drawing.Point(32, 24)
        Me.lblSku.Name = "lblSku"
        Me.lblSku.Size = New System.Drawing.Size(100, 16)
        Me.lblSku.TabIndex = 42
        Me.lblSku.Text = "产品代码"
        '
        'btnAdvance
        '
        Me.btnAdvance.Location = New System.Drawing.Point(8, 352)
        Me.btnAdvance.Name = "btnAdvance"
        Me.btnAdvance.Size = New System.Drawing.Size(105, 34)
        Me.btnAdvance.TabIndex = 1
        Me.btnAdvance.Text = "高级"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(312, 352)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(106, 34)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "查询"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(464, 352)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(106, 34)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "取消"
        '
        'txtVender_name
        '
        Me.txtVender_name.Location = New System.Drawing.Point(-8, 224)
        Me.txtVender_name.Name = "txtVender_name"
        Me.txtVender_name.Size = New System.Drawing.Size(400, 21)
        Me.txtVender_name.TabIndex = 62
        Me.txtVender_name.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(10, 164)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(595, 51)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "操作设定"
        '
        'cckSkuStatus
        '
        Me.cckSkuStatus.Location = New System.Drawing.Point(360, 72)
        Me.cckSkuStatus.Name = "cckSkuStatus"
        Me.cckSkuStatus.TabIndex = 46
        Me.cckSkuStatus.Text = "全部"
        '
        'cboSkuStatus
        '
        Me.cboSkuStatus.Location = New System.Drawing.Point(160, 72)
        Me.cboSkuStatus.Name = "cboSkuStatus"
        Me.cboSkuStatus.Size = New System.Drawing.Size(184, 20)
        Me.cboSkuStatus.TabIndex = 45
        '
        'lblskuStatus
        '
        Me.lblskuStatus.Location = New System.Drawing.Point(32, 72)
        Me.lblskuStatus.Name = "lblskuStatus"
        Me.lblskuStatus.Size = New System.Drawing.Size(106, 26)
        Me.lblskuStatus.TabIndex = 44
        Me.lblskuStatus.Text = "产品状态"
        '
        'txtSku_ref
        '
        Me.txtSku_ref.Location = New System.Drawing.Point(160, 136)
        Me.txtSku_ref.Name = "txtSku_ref"
        Me.txtSku_ref.Size = New System.Drawing.Size(341, 21)
        Me.txtSku_ref.TabIndex = 48
        Me.txtSku_ref.Text = ""
        '
        'lblSku_ref
        '
        Me.lblSku_ref.Location = New System.Drawing.Point(32, 136)
        Me.lblSku_ref.Name = "lblSku_ref"
        Me.lblSku_ref.Size = New System.Drawing.Size(106, 26)
        Me.lblSku_ref.TabIndex = 47
        Me.lblSku_ref.Text = "套状代码"
        '
        'frmDnhdrSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(595, 392)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnAdvance)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtVender_name)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDnhdrSearch"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "发货单查询"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.tabOrther.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Grpbarcode.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private mFilters As COMExpress.BusinessObject.Filters.CXFilters
    Private mObjectName As String

    Public Property Filter() As COMExpress.BusinessObject.Filters.CXFilters
        Get
            Return mFilters
        End Get
        Set(ByVal Value As COMExpress.BusinessObject.Filters.CXFilters)
            mFilters = Value
        End Set
    End Property

    Public Property ObjectName() As String
        Get
            Return mObjectName
        End Get
        Set(ByVal Value As String)
            mObjectName = Value
        End Set
    End Property

    Private mFuncType As String
    Public Property FuncType() As String
        Get
            Return mFuncType
        End Get
        Set(ByVal Value As String)
            mFuncType = Value
        End Set
    End Property

    Private Sub btnAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdvance.Click
        Me.DialogResult = DialogResult.Ignore
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        UIToFilter()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub UIToFilter()
        Dim dn_no As String
        Dim description As String
        Dim own_code As String
        Dim due_date As String
        Dim doc_type As String
        Dim stat_type As String
        Dim status_code As String
        Dim deal_name As String
        Dim deal_person As String
        Dim deal_to As String
        Dim unloading_Address As String
        Dim instruction As String
        Dim fls As New COMExpress.BusinessObject.Filters.CXFilters
        Dim fl As COMExpress.BusinessObject.Filters.CXFilterBase
        ' sku_no = Me.txtSku_no.Text.Trim()
        dn_no = Me.txtDn_no.Text.Trim()
        description = Me.txtDescription.Text.Trim()
        own_code = Me.txtOwn_code.Text.Trim()
        due_date = Me.txtdue_date.Text.Trim()
        doc_type = Me.txtDoc_type.Text.Trim()
        stat_type = Me.txtStat_type.Text.Trim()
        status_code = Me.txtStatus_code.Text.Trim()
        deal_to = Me.txtDeal_to.Text.Trim()
        deal_name = Me.txtDeal_name.Text.Trim()
        deal_person = Me.txtDeal_person.Text.Trim()
        unloading_Address = Me.txtUnloading_Address.Text.Trim()
        instruction = Me.txtInstruction.Text.Trim()
        If dn_no <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("dn_no", dn_no, mObjectName, IIf(Len(dn_no) = 10, COMExpress.BusinessObject.Filters.ConditionOperator.Equal, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise))
            fls.Add(fl)
        End If
        If description <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("description", description, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If own_code <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("own_code", own_code, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If due_date <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("due_date", due_date, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If doc_type <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("doc_type", doc_type, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If stat_type <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("stat_type", stat_type, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If status_code <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("status_code", status_code, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If deal_to <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("deal_to", deal_to, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If deal_name <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("deal_name", deal_name, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If

        If deal_person <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("deal_person", deal_person, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If unloading_Address <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("unloading_Address", unloading_Address, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If instruction <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("instruction", instruction, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        '----------------------------------------------------------------------------
        Dim sku_no As String
        Dim strSQL As String
        Dim sku_status As String
        Dim sku_ref As String
        Dim sno As String
        sku_no = Trim(txtSku_no.Text)
        sku_status = Me.cboSkuStatus.SelectedValue
        sku_ref = Trim(Me.txtSku_ref.Text)
        sno = Me.cboSno.SelectedValue
        If sku_no <> "" Then
            strSQL = "select dn_no from dnlin where sku_no like '%" + sku_no + "%'"
            fl = ImpBusinessCollectionDerived.GetSingleFilter("dn_no", strSQL, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
            fls.Add(fl)
        End If
        If Me.cckSkuStatus.Checked = False Then
            strSQL = "select dn_no from dnlin where sku_status='" + sku_status + "'"
            fl = ImpBusinessCollectionDerived.GetSingleFilter("dn_no", strSQL, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
            fls.Add(fl)
        End If
        If sku_ref <> "" Then
            strSQL = "select dn_no from dnlin where sku_ref like '%" + sku_no + "%'"
            fl = ImpBusinessCollectionDerived.GetSingleFilter("dn_no", strSQL, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
            fls.Add(fl)
        End If
        If chkDisableSNO.Checked = False Then
            strSQL = "select dn_no from dnsno where sno like  '%" + sno + "%'"
            fl = ImpBusinessCollectionDerived.GetSingleFilter("dn_no", strSQL, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
            fls.Add(fl)
        End If
        ''------------------------------------------------------------------------------
        mFilters = fls
    End Sub
    Public Sub LoadList()
        Dim rs As DataSet
        Dim rssku As DataSet
        Dim lk As New Lookup
        Dim lksku As New Lookup
        'rs = lk.getOperateTypeList(COMExpress.BusinessObject.CXLookupCallTypeConstants.ccCache, Nothing)
        Dim strSql As String
        strSql = "select sno from dnsno "
        rs = lk.SQLToDataSet(strSql)
        Me.cboSno.DataSource = rs.Tables(0)
        'Me.cboSno.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboSno.DisplayMember = rs.Tables(0).Columns(0).ColumnName
        Me.cboSno.ValueMember = rs.Tables(0).Columns(0).ColumnName
        'cboSno.SelectedIndex = 0
        'cboSno.Enabled = False
        Me.chkDisableSNO.Checked = True
        Me.cckSkuStatus.Checked = True
        rssku = lksku.SQLToDataSet("select sku_status,description from skustatus")
        Me.cboSkuStatus.DataSource = rssku.Tables(0)
        Me.cboSkuStatus.DisplayMember = rssku.Tables(0).Columns(1).ColumnName
        Me.cboSkuStatus.ValueMember = rssku.Tables(0).Columns(0).ColumnName
    End Sub

    Private Sub frmDnhdrSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        LoadList()
    End Sub

    Private Sub cckSkuStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.cckSkuStatus.Checked = True Then
            Me.cboSkuStatus.Text = ""
            Me.cboSkuStatus.Enabled = False
        Else
            Me.cboSkuStatus.Enabled = True
        End If
    End Sub

    Private Sub chkDisableSNO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDisableSNO.CheckedChanged
        If Me.chkDisableSNO.Checked = True Then
            Me.cboSno.Text = ""
            Me.cboSno.Enabled = False
        Else
            Me.cboSno.Enabled = True
        End If
    End Sub

    Private Sub tabOrther_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabOrther.Click

    End Sub
End Class
