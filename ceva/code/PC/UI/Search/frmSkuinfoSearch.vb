Imports COMExpress.Windows.Forms
Imports YT.BusinessObject

Public Class frmSkuinfoSearch
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
    Friend WithEvents txtCategory As System.Windows.Forms.TextBox
    Friend WithEvents txtVender_name As System.Windows.Forms.TextBox
    Friend WithEvents txtDepartment As System.Windows.Forms.TextBox
    Friend WithEvents txtSix_code As System.Windows.Forms.TextBox
    Friend WithEvents txtModel_no As System.Windows.Forms.TextBox
    Friend WithEvents txtSku_desc As System.Windows.Forms.TextBox
    Friend WithEvents txtSku_no As System.Windows.Forms.TextBox
    Friend WithEvents lblcategory As System.Windows.Forms.Label
    Friend WithEvents lbldepartment As System.Windows.Forms.Label
    Friend WithEvents lblvender_name As System.Windows.Forms.Label
    Friend WithEvents lblmodel_no As System.Windows.Forms.Label
    Friend WithEvents lblsix_code As System.Windows.Forms.Label
    Friend WithEvents lblsku_desc As System.Windows.Forms.Label
    Friend WithEvents lblsku_no As System.Windows.Forms.Label
    Friend WithEvents bttCancel As System.Windows.Forms.Button
    Friend WithEvents bttOk As System.Windows.Forms.Button
    Friend WithEvents btnAdvance As System.Windows.Forms.Button
    Friend WithEvents txtVend_code As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabBasic As System.Windows.Forms.TabPage
    Friend WithEvents tabOther As System.Windows.Forms.TabPage
    Friend WithEvents Grpbarcode As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpRetn As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboOp As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkAllowReturn As System.Windows.Forms.CheckBox
    Friend WithEvents chkDisableSNO As System.Windows.Forms.CheckBox
    Friend WithEvents txtSkuStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnRelateVender As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSkuinfoSearch))
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabBasic = New System.Windows.Forms.TabPage
        Me.btnRelateVender = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtVend_code = New System.Windows.Forms.TextBox
        Me.txtCategory = New System.Windows.Forms.TextBox
        Me.txtVender_name = New System.Windows.Forms.TextBox
        Me.txtDepartment = New System.Windows.Forms.TextBox
        Me.txtSix_code = New System.Windows.Forms.TextBox
        Me.txtModel_no = New System.Windows.Forms.TextBox
        Me.txtSku_desc = New System.Windows.Forms.TextBox
        Me.txtSku_no = New System.Windows.Forms.TextBox
        Me.lblcategory = New System.Windows.Forms.Label
        Me.lbldepartment = New System.Windows.Forms.Label
        Me.lblvender_name = New System.Windows.Forms.Label
        Me.lblmodel_no = New System.Windows.Forms.Label
        Me.lblsix_code = New System.Windows.Forms.Label
        Me.lblsku_desc = New System.Windows.Forms.Label
        Me.lblsku_no = New System.Windows.Forms.Label
        Me.tabOther = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkDisableSNO = New System.Windows.Forms.CheckBox
        Me.cboOp = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.grpRetn = New System.Windows.Forms.GroupBox
        Me.txtSkuStatus = New System.Windows.Forms.TextBox
        Me.chkAllowReturn = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Grpbarcode = New System.Windows.Forms.GroupBox
        Me.txtBarcode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.bttCancel = New System.Windows.Forms.Button
        Me.bttOk = New System.Windows.Forms.Button
        Me.btnAdvance = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.tabBasic.SuspendLayout()
        Me.tabOther.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.grpRetn.SuspendLayout()
        Me.Grpbarcode.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabBasic)
        Me.TabControl1.Controls.Add(Me.tabOther)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(528, 256)
        Me.TabControl1.TabIndex = 0
        '
        'tabBasic
        '
        Me.tabBasic.Controls.Add(Me.btnRelateVender)
        Me.tabBasic.Controls.Add(Me.Label1)
        Me.tabBasic.Controls.Add(Me.txtVend_code)
        Me.tabBasic.Controls.Add(Me.txtCategory)
        Me.tabBasic.Controls.Add(Me.txtVender_name)
        Me.tabBasic.Controls.Add(Me.txtDepartment)
        Me.tabBasic.Controls.Add(Me.txtSix_code)
        Me.tabBasic.Controls.Add(Me.txtModel_no)
        Me.tabBasic.Controls.Add(Me.txtSku_desc)
        Me.tabBasic.Controls.Add(Me.txtSku_no)
        Me.tabBasic.Controls.Add(Me.lblcategory)
        Me.tabBasic.Controls.Add(Me.lbldepartment)
        Me.tabBasic.Controls.Add(Me.lblvender_name)
        Me.tabBasic.Controls.Add(Me.lblmodel_no)
        Me.tabBasic.Controls.Add(Me.lblsix_code)
        Me.tabBasic.Controls.Add(Me.lblsku_desc)
        Me.tabBasic.Controls.Add(Me.lblsku_no)
        Me.tabBasic.Location = New System.Drawing.Point(4, 22)
        Me.tabBasic.Name = "tabBasic"
        Me.tabBasic.Size = New System.Drawing.Size(520, 230)
        Me.tabBasic.TabIndex = 0
        Me.tabBasic.Text = "基本信息"
        '
        'btnRelateVender
        '
        Me.btnRelateVender.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRelateVender.Image = CType(resources.GetObject("btnRelateVender.Image"), System.Drawing.Image)
        Me.btnRelateVender.Location = New System.Drawing.Point(488, 136)
        Me.btnRelateVender.Name = "btnRelateVender"
        Me.btnRelateVender.Size = New System.Drawing.Size(24, 20)
        Me.btnRelateVender.TabIndex = 49
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 22)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "供应商"
        '
        'txtVend_code
        '
        Me.txtVend_code.Location = New System.Drawing.Point(112, 136)
        Me.txtVend_code.Name = "txtVend_code"
        Me.txtVend_code.Size = New System.Drawing.Size(376, 20)
        Me.txtVend_code.TabIndex = 47
        Me.txtVend_code.Text = ""
        '
        'txtCategory
        '
        Me.txtCategory.Location = New System.Drawing.Point(112, 184)
        Me.txtCategory.Name = "txtCategory"
        Me.txtCategory.Size = New System.Drawing.Size(400, 20)
        Me.txtCategory.TabIndex = 46
        Me.txtCategory.Text = ""
        '
        'txtVender_name
        '
        Me.txtVender_name.Location = New System.Drawing.Point(112, 160)
        Me.txtVender_name.Name = "txtVender_name"
        Me.txtVender_name.Size = New System.Drawing.Size(400, 20)
        Me.txtVender_name.TabIndex = 45
        Me.txtVender_name.Text = ""
        '
        'txtDepartment
        '
        Me.txtDepartment.Location = New System.Drawing.Point(112, 112)
        Me.txtDepartment.Name = "txtDepartment"
        Me.txtDepartment.Size = New System.Drawing.Size(400, 20)
        Me.txtDepartment.TabIndex = 44
        Me.txtDepartment.Text = ""
        '
        'txtSix_code
        '
        Me.txtSix_code.Location = New System.Drawing.Point(112, 88)
        Me.txtSix_code.Name = "txtSix_code"
        Me.txtSix_code.Size = New System.Drawing.Size(400, 20)
        Me.txtSix_code.TabIndex = 43
        Me.txtSix_code.Text = ""
        '
        'txtModel_no
        '
        Me.txtModel_no.Location = New System.Drawing.Point(112, 64)
        Me.txtModel_no.Name = "txtModel_no"
        Me.txtModel_no.Size = New System.Drawing.Size(400, 20)
        Me.txtModel_no.TabIndex = 42
        Me.txtModel_no.Text = ""
        '
        'txtSku_desc
        '
        Me.txtSku_desc.Location = New System.Drawing.Point(112, 40)
        Me.txtSku_desc.Name = "txtSku_desc"
        Me.txtSku_desc.Size = New System.Drawing.Size(400, 20)
        Me.txtSku_desc.TabIndex = 31
        Me.txtSku_desc.Text = ""
        '
        'txtSku_no
        '
        Me.txtSku_no.Location = New System.Drawing.Point(112, 16)
        Me.txtSku_no.Name = "txtSku_no"
        Me.txtSku_no.Size = New System.Drawing.Size(400, 20)
        Me.txtSku_no.TabIndex = 41
        Me.txtSku_no.Text = ""
        '
        'lblcategory
        '
        Me.lblcategory.Location = New System.Drawing.Point(16, 184)
        Me.lblcategory.Name = "lblcategory"
        Me.lblcategory.Size = New System.Drawing.Size(83, 21)
        Me.lblcategory.TabIndex = 40
        Me.lblcategory.Text = "产品组"
        '
        'lbldepartment
        '
        Me.lbldepartment.Location = New System.Drawing.Point(16, 112)
        Me.lbldepartment.Name = "lbldepartment"
        Me.lbldepartment.Size = New System.Drawing.Size(83, 21)
        Me.lbldepartment.TabIndex = 39
        Me.lbldepartment.Text = "部门"
        '
        'lblvender_name
        '
        Me.lblvender_name.Location = New System.Drawing.Point(16, 160)
        Me.lblvender_name.Name = "lblvender_name"
        Me.lblvender_name.Size = New System.Drawing.Size(83, 22)
        Me.lblvender_name.TabIndex = 38
        Me.lblvender_name.Text = "供应商名称"
        '
        'lblmodel_no
        '
        Me.lblmodel_no.Location = New System.Drawing.Point(16, 64)
        Me.lblmodel_no.Name = "lblmodel_no"
        Me.lblmodel_no.Size = New System.Drawing.Size(83, 22)
        Me.lblmodel_no.TabIndex = 37
        Me.lblmodel_no.Text = "型号"
        '
        'lblsix_code
        '
        Me.lblsix_code.Location = New System.Drawing.Point(16, 88)
        Me.lblsix_code.Name = "lblsix_code"
        Me.lblsix_code.Size = New System.Drawing.Size(83, 21)
        Me.lblsix_code.TabIndex = 36
        Me.lblsix_code.Text = "六位代码"
        '
        'lblsku_desc
        '
        Me.lblsku_desc.Location = New System.Drawing.Point(16, 40)
        Me.lblsku_desc.Name = "lblsku_desc"
        Me.lblsku_desc.Size = New System.Drawing.Size(83, 21)
        Me.lblsku_desc.TabIndex = 35
        Me.lblsku_desc.Text = "产品描述"
        '
        'lblsku_no
        '
        Me.lblsku_no.Location = New System.Drawing.Point(16, 16)
        Me.lblsku_no.Name = "lblsku_no"
        Me.lblsku_no.Size = New System.Drawing.Size(83, 21)
        Me.lblsku_no.TabIndex = 34
        Me.lblsku_no.Text = "产品号码"
        '
        'tabOther
        '
        Me.tabOther.Controls.Add(Me.GroupBox1)
        Me.tabOther.Controls.Add(Me.grpRetn)
        Me.tabOther.Controls.Add(Me.Grpbarcode)
        Me.tabOther.Location = New System.Drawing.Point(4, 22)
        Me.tabOther.Name = "tabOther"
        Me.tabOther.Size = New System.Drawing.Size(520, 230)
        Me.tabOther.TabIndex = 1
        Me.tabOther.Text = "其它"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkDisableSNO)
        Me.GroupBox1.Controls.Add(Me.cboOp)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 152)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(496, 48)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "操作设定"
        '
        'chkDisableSNO
        '
        Me.chkDisableSNO.Location = New System.Drawing.Point(304, 16)
        Me.chkDisableSNO.Name = "chkDisableSNO"
        Me.chkDisableSNO.TabIndex = 4
        Me.chkDisableSNO.Text = "禁扫机身号"
        '
        'cboOp
        '
        Me.cboOp.ItemHeight = 13
        Me.cboOp.Location = New System.Drawing.Point(136, 16)
        Me.cboOp.Name = "cboOp"
        Me.cboOp.Size = New System.Drawing.Size(152, 21)
        Me.cboOp.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(32, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "操作"
        '
        'grpRetn
        '
        Me.grpRetn.Controls.Add(Me.txtSkuStatus)
        Me.grpRetn.Controls.Add(Me.chkAllowReturn)
        Me.grpRetn.Controls.Add(Me.Label3)
        Me.grpRetn.Location = New System.Drawing.Point(8, 88)
        Me.grpRetn.Name = "grpRetn"
        Me.grpRetn.Size = New System.Drawing.Size(496, 48)
        Me.grpRetn.TabIndex = 45
        Me.grpRetn.TabStop = False
        Me.grpRetn.Text = "作业费率"
        '
        'txtSkuStatus
        '
        Me.txtSkuStatus.Location = New System.Drawing.Point(136, 16)
        Me.txtSkuStatus.Name = "txtSkuStatus"
        Me.txtSkuStatus.Size = New System.Drawing.Size(160, 20)
        Me.txtSkuStatus.TabIndex = 5
        Me.txtSkuStatus.Text = ""
        '
        'chkAllowReturn
        '
        Me.chkAllowReturn.Location = New System.Drawing.Point(304, 16)
        Me.chkAllowReturn.Name = "chkAllowReturn"
        Me.chkAllowReturn.TabIndex = 4
        Me.chkAllowReturn.Text = "允许退返"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(32, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 24)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "产品状态"
        '
        'Grpbarcode
        '
        Me.Grpbarcode.Controls.Add(Me.txtBarcode)
        Me.Grpbarcode.Controls.Add(Me.Label2)
        Me.Grpbarcode.Location = New System.Drawing.Point(8, 24)
        Me.Grpbarcode.Name = "Grpbarcode"
        Me.Grpbarcode.Size = New System.Drawing.Size(496, 48)
        Me.Grpbarcode.TabIndex = 44
        Me.Grpbarcode.TabStop = False
        Me.Grpbarcode.Text = "条码数据"
        '
        'txtBarcode
        '
        Me.txtBarcode.Location = New System.Drawing.Point(136, 16)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(352, 20)
        Me.txtBarcode.TabIndex = 43
        Me.txtBarcode.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(40, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 21)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "条码"
        '
        'bttCancel
        '
        Me.bttCancel.Location = New System.Drawing.Point(432, 264)
        Me.bttCancel.Name = "bttCancel"
        Me.bttCancel.Size = New System.Drawing.Size(94, 32)
        Me.bttCancel.TabIndex = 33
        Me.bttCancel.Text = "取  消"
        '
        'bttOk
        '
        Me.bttOk.Location = New System.Drawing.Point(328, 264)
        Me.bttOk.Name = "bttOk"
        Me.bttOk.Size = New System.Drawing.Size(93, 32)
        Me.bttOk.TabIndex = 32
        Me.bttOk.Text = "确   定"
        '
        'btnAdvance
        '
        Me.btnAdvance.Location = New System.Drawing.Point(8, 264)
        Me.btnAdvance.Name = "btnAdvance"
        Me.btnAdvance.Size = New System.Drawing.Size(93, 32)
        Me.btnAdvance.TabIndex = 34
        Me.btnAdvance.Text = "高级"
        '
        'frmSkuinfoSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(536, 302)
        Me.Controls.Add(Me.btnAdvance)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.bttOk)
        Me.Controls.Add(Me.bttCancel)
        Me.Name = "frmSkuinfoSearch"
        Me.Text = "产品查询"
        Me.TabControl1.ResumeLayout(False)
        Me.tabBasic.ResumeLayout(False)
        Me.tabOther.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.grpRetn.ResumeLayout(False)
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



    Private Sub frmSkuinfoSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        LoadList()
    End Sub

    Private Sub btnAdvance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdvance.Click
        Me.DialogResult = DialogResult.Ignore
        Me.Close()
    End Sub

    Private Sub bttOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttOk.Click
        UIToFilter()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub bttCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub UIToFilter()
        Dim sku_no As String
        Dim sku_desc As String
        Dim model_no As String
        Dim six_code As String
        Dim department As String
        Dim vender As String
        Dim vender_name As String
        Dim category As String
        Dim fls As New COMExpress.BusinessObject.Filters.CXFilters
        Dim fl As COMExpress.BusinessObject.Filters.CXFilterBase
        sku_no = Me.txtSku_no.Text.Trim()
        sku_desc = Me.txtSku_desc.Text.Trim()
        model_no = Me.txtModel_no.Text.Trim()
        six_code = Me.txtSix_code.Text.Trim()
        department = Me.txtDepartment.Text.Trim()
        vender = Me.txtVend_code.Text.Trim()
        vender_name = Me.txtVender_name.Text.Trim()
        category = Me.txtCategory.Text.Trim()
        If sku_no <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("sku_no", sku_no, mObjectName, IIf(Len(sku_no) = 9, COMExpress.BusinessObject.Filters.ConditionOperator.Equal, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise))
            fls.Add(fl)
        End If
        If sku_desc <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("sku_desc", sku_desc, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If model_no <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("model_no", model_no, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If six_code <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("six_code", six_code, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If department <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("department", department, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If vender <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("vender", vender, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        If vender_name <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("vender_name", vender_name, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If

        If category <> "" Then
            fl = ImpBusinessCollectionDerived.GetSingleFilter("category", category, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.LikeWise)
            fls.Add(fl)
        End If
        '----------------------------------------------------------------------------
        Dim barcode As String
        Dim strSQL As String
        Dim sku_status As String
        barcode = Trim(txtBarcode.Text)
        sku_status = Trim(txtSkuStatus.Text)
        If barcode <> "" Then
            strSQL = "select sku_no from barcode where barcode like '%" + barcode + "%'"
            fl = ImpBusinessCollectionDerived.GetSingleFilter("sku_no", strSQL, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
            fls.Add(fl)
        End If
        If sku_status <> "" Then
            strSQL = "select sku_no from skuret where sku_status='" + sku_status + "' and allow_ret=" + IIf(chkAllowReturn.Checked, "1", "0") + ""
            fl = ImpBusinessCollectionDerived.GetSingleFilter("sku_no", strSQL, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
            fls.Add(fl)
        End If
        If chkDisableSNO.Checked = True Then
            strSQL = "select sku_no from skuopset where op_type='600' and dis_sno=1"
            fl = ImpBusinessCollectionDerived.GetSingleFilter("sku_no", strSQL, mObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
            fls.Add(fl)
        End If
        '------------------------------------------------------------------------------
        mFilters = fls
    End Sub

    Public Sub LoadList()
        Dim rs As DataSet
        Dim lk As New Lookup
        'rs = lk.getSkuStatusList(COMExpress.BusinessObject.CXLookupCallTypeConstants.ccCache, Nothing)
        'cboSku_status.DropDownStyle = ComboBoxStyle.DropDownList
        'Me.cboSku_status.DisplayMember = rs.Tables(0).Columns(1).ColumnName
        'Me.cboSku_status.ValueMember = rs.Tables(0).Columns(0).ColumnName
        'Me.cboSku_status.DataSource = rs.Tables(0).DefaultView

        rs = lk.getOperateTypeList(COMExpress.BusinessObject.CXLookupCallTypeConstants.ccCache, Nothing)
        cboOp.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboOp.DisplayMember = rs.Tables(0).Columns(1).ColumnName
        Me.cboOp.ValueMember = rs.Tables(0).Columns(0).ColumnName
        Me.cboOp.DataSource = rs.Tables(0).DefaultView
        cboOp.SelectedIndex = 0
        cboOp.Enabled = False
    End Sub

    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Timer1.Enabled = False
    '    cboSku_status.SelectedIndex = -1

    'End Sub

    Private Sub btnRelateVender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelateVender.Click
        Try
            Dim service As ISearchService
            service = DirectCast(MainForm, IWindowsAppManager).SearchService
            service.SearchExecute("clsdealer", "deal_code", "", False, Me.txtVend_code)
        Catch ex As Exception
        End Try
    End Sub
End Class
