Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclsOPERATORBase__
    Inherits CXMdiChildForm
	Implements IPrintableForm
	
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
        Protected Friend WithEvents splMain As System.Windows.Forms.Splitter
    Protected Friend WithEvents txtuser_code As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbluser_code As System.Windows.Forms.Label
    Protected Friend WithEvents txtuser_name As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbluser_name As System.Windows.Forms.Label
    Protected Friend WithEvents txtpassword_ As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblpassword_ As System.Windows.Forms.Label
    Protected Friend WithEvents txtSTCD As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblSTCD As System.Windows.Forms.Label
    Protected Friend WithEvents chkallowlogin As System.Windows.Forms.CheckBox
    Protected Friend WithEvents chkisadmin As System.Windows.Forms.CheckBox
    Protected Friend WithEvents txttitle As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbltitle As System.Windows.Forms.Label
    Protected Friend WithEvents txttel As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbltel As System.Windows.Forms.Label
    Protected Friend WithEvents txtfax As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblfax As System.Windows.Forms.Label
    Protected Friend WithEvents txtmobile As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblmobile As System.Windows.Forms.Label
    Protected Friend WithEvents txtemail As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblemail As System.Windows.Forms.Label
    Protected Friend WithEvents dtpcreate_date As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblcreate_date As System.Windows.Forms.Label
    Protected Friend WithEvents dtpupdate_date As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblupdate_date As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_by As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_by As System.Windows.Forms.Label
    Protected Friend WithEvents dtpopt_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblopt_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_timestamp As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_timestamp As System.Windows.Forms.Label
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Protected Friend WithEvents tp__clsUserpermission As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsUserpermission As YTUI.DataGrid
    Protected Friend WithEvents tp__clsUserrole As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsUserrole As YTUI.DataGrid
    Protected Friend WithEvents tabGrid As System.Windows.Forms.TabControl

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.splMain = New System.Windows.Forms.Splitter()
        Me.txtuser_code = New System.Windows.Forms.TextBox()
        Me.lbluser_code = New System.Windows.Forms.Label()
        Me.txtuser_name = New System.Windows.Forms.TextBox()
        Me.lbluser_name = New System.Windows.Forms.Label()
        Me.txtpassword_ = New System.Windows.Forms.TextBox()
        Me.lblpassword_ = New System.Windows.Forms.Label()
        Me.txtSTCD = New System.Windows.Forms.TextBox()
        Me.lblSTCD = New System.Windows.Forms.Label()
        Me.chkallowlogin = New System.Windows.Forms.CheckBox()
        Me.chkisadmin = New System.Windows.Forms.CheckBox()
        Me.txttitle = New System.Windows.Forms.TextBox()
        Me.lbltitle = New System.Windows.Forms.Label()
        Me.txttel = New System.Windows.Forms.TextBox()
        Me.lbltel = New System.Windows.Forms.Label()
        Me.txtfax = New System.Windows.Forms.TextBox()
        Me.lblfax = New System.Windows.Forms.Label()
        Me.txtmobile = New System.Windows.Forms.TextBox()
        Me.lblmobile = New System.Windows.Forms.Label()
        Me.txtemail = New System.Windows.Forms.TextBox()
        Me.lblemail = New System.Windows.Forms.Label()
        Me.dtpcreate_date = New System.Windows.Forms.DateTimePicker()
        Me.lblcreate_date = New System.Windows.Forms.Label()
        Me.dtpupdate_date = New System.Windows.Forms.DateTimePicker()
        Me.lblupdate_date = New System.Windows.Forms.Label()
        Me.txtopt_by = New System.Windows.Forms.TextBox()
        Me.lblopt_by = New System.Windows.Forms.Label()
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblopt_dtime = New System.Windows.Forms.Label()
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox()
        Me.lblopt_timestamp = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.gd__clsUserpermission = New YTUI.DataGrid()
        Me.tp__clsUserpermission = New System.Windows.Forms.TabPage()
        Me.gd__clsUserrole = New YTUI.DataGrid()
        Me.tp__clsUserrole = New System.Windows.Forms.TabPage()
        Me.tabGrid = New System.Windows.Forms.TabControl()

        CType(Me.gd__clsUserpermission, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gd__clsUserrole, System.ComponentModel.ISupportInitialize).BeginInit()

        Me.SuspendLayout()
        'splMain
        '
        Me.splMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.splMain.Location = New System.Drawing.Point(0, 264)
        Me.splMain.Name = "splMain"
        Me.splMain.Size = New System.Drawing.Size(480, 8)
        Me.splMain.TabStop = False
        'txtuser_code
        '
        Me.txtuser_code.Location = New System.Drawing.Point(138, 10)
        Me.txtuser_code.Name = "txtuser_code"
        Me.txtuser_code.Size = New System.Drawing.Size(225, 21)
        Me.txtuser_code.TabIndex = 2
        'lbluser_code
        '
        Me.lbluser_code.BackColor = System.Drawing.Color.Transparent
        Me.lbluser_code.Location = New System.Drawing.Point(10, 12)
        Me.lbluser_code.Name = "lbluser_code"
        Me.lbluser_code.Size = New System.Drawing.Size(121, 17)
        Me.lbluser_code.TabIndex = 1
        Me.lbluser_code.Text = "user_code"
        'txtuser_name
        '
        Me.txtuser_name.Location = New System.Drawing.Point(138, 32)
        Me.txtuser_name.Name = "txtuser_name"
        Me.txtuser_name.Size = New System.Drawing.Size(225, 21)
        Me.txtuser_name.TabIndex = 4
        'lbluser_name
        '
        Me.lbluser_name.BackColor = System.Drawing.Color.Transparent
        Me.lbluser_name.Location = New System.Drawing.Point(10, 34)
        Me.lbluser_name.Name = "lbluser_name"
        Me.lbluser_name.Size = New System.Drawing.Size(121, 17)
        Me.lbluser_name.TabIndex = 3
        Me.lbluser_name.Text = "user_name"
        'txtpassword_
        '
        Me.txtpassword_.Location = New System.Drawing.Point(138, 53)
        Me.txtpassword_.Name = "txtpassword_"
        Me.txtpassword_.Size = New System.Drawing.Size(225, 21)
        Me.txtpassword_.TabIndex = 6
        'lblpassword_
        '
        Me.lblpassword_.BackColor = System.Drawing.Color.Transparent
        Me.lblpassword_.Location = New System.Drawing.Point(10, 56)
        Me.lblpassword_.Name = "lblpassword_"
        Me.lblpassword_.Size = New System.Drawing.Size(121, 17)
        Me.lblpassword_.TabIndex = 5
        Me.lblpassword_.Text = "password"
        'txtSTCD
        '
        Me.txtSTCD.Location = New System.Drawing.Point(138, 75)
        Me.txtSTCD.Name = "txtSTCD"
        Me.txtSTCD.Size = New System.Drawing.Size(225, 21)
        Me.txtSTCD.TabIndex = 8
        'lblSTCD
        '
        Me.lblSTCD.BackColor = System.Drawing.Color.Transparent
        Me.lblSTCD.Location = New System.Drawing.Point(10, 77)
        Me.lblSTCD.Name = "lblSTCD"
        Me.lblSTCD.Size = New System.Drawing.Size(121, 17)
        Me.lblSTCD.TabIndex = 7
        Me.lblSTCD.Text = "STCD"
        'chkallowlogin
        '
        Me.chkallowlogin.Location = New System.Drawing.Point(10, 97)
        Me.chkallowlogin.Name = "chkallowlogin"
        Me.chkallowlogin.Size = New System.Drawing.Size(353, 21)
        Me.chkallowlogin.TabIndex = 9
        Me.chkallowlogin.Text = "allowlogin"
        'chkisadmin
        '
        Me.chkisadmin.Location = New System.Drawing.Point(10, 118)
        Me.chkisadmin.Name = "chkisadmin"
        Me.chkisadmin.Size = New System.Drawing.Size(353, 21)
        Me.chkisadmin.TabIndex = 10
        Me.chkisadmin.Text = "isadmin"
        'txttitle
        '
        Me.txttitle.Location = New System.Drawing.Point(138, 140)
        Me.txttitle.Name = "txttitle"
        Me.txttitle.Size = New System.Drawing.Size(225, 21)
        Me.txttitle.TabIndex = 12
        'lbltitle
        '
        Me.lbltitle.BackColor = System.Drawing.Color.Transparent
        Me.lbltitle.Location = New System.Drawing.Point(10, 142)
        Me.lbltitle.Name = "lbltitle"
        Me.lbltitle.Size = New System.Drawing.Size(121, 17)
        Me.lbltitle.TabIndex = 11
        Me.lbltitle.Text = "title"
        'txttel
        '
        Me.txttel.Location = New System.Drawing.Point(138, 162)
        Me.txttel.Name = "txttel"
        Me.txttel.Size = New System.Drawing.Size(225, 21)
        Me.txttel.TabIndex = 14
        'lbltel
        '
        Me.lbltel.BackColor = System.Drawing.Color.Transparent
        Me.lbltel.Location = New System.Drawing.Point(10, 164)
        Me.lbltel.Name = "lbltel"
        Me.lbltel.Size = New System.Drawing.Size(121, 17)
        Me.lbltel.TabIndex = 13
        Me.lbltel.Text = "tel"
        'txtfax
        '
        Me.txtfax.Location = New System.Drawing.Point(138, 183)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Size = New System.Drawing.Size(225, 21)
        Me.txtfax.TabIndex = 16
        'lblfax
        '
        Me.lblfax.BackColor = System.Drawing.Color.Transparent
        Me.lblfax.Location = New System.Drawing.Point(10, 186)
        Me.lblfax.Name = "lblfax"
        Me.lblfax.Size = New System.Drawing.Size(121, 17)
        Me.lblfax.TabIndex = 15
        Me.lblfax.Text = "fax"
        'txtmobile
        '
        Me.txtmobile.Location = New System.Drawing.Point(138, 205)
        Me.txtmobile.Name = "txtmobile"
        Me.txtmobile.Size = New System.Drawing.Size(225, 21)
        Me.txtmobile.TabIndex = 18
        'lblmobile
        '
        Me.lblmobile.BackColor = System.Drawing.Color.Transparent
        Me.lblmobile.Location = New System.Drawing.Point(10, 207)
        Me.lblmobile.Name = "lblmobile"
        Me.lblmobile.Size = New System.Drawing.Size(121, 17)
        Me.lblmobile.TabIndex = 17
        Me.lblmobile.Text = "mobile"
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(138, 227)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(225, 21)
        Me.txtemail.TabIndex = 20
        'lblemail
        '
        Me.lblemail.BackColor = System.Drawing.Color.Transparent
        Me.lblemail.Location = New System.Drawing.Point(10, 229)
        Me.lblemail.Name = "lblemail"
        Me.lblemail.Size = New System.Drawing.Size(121, 17)
        Me.lblemail.TabIndex = 19
        Me.lblemail.Text = "email"
        'dtpcreate_date
        '
        Me.dtpcreate_date.Location = New System.Drawing.Point(138, 248)
        Me.dtpcreate_date.Name = "dtpcreate_date"
        Me.dtpcreate_date.Size = New System.Drawing.Size(225, 21)
        Me.dtpcreate_date.ShowCheckBox = True
        Me.dtpcreate_date.TabIndex = 22
        Me.dtpcreate_date.Format = DateTimePickerFormat.Long
        'lblcreate_date
        '
        Me.lblcreate_date.BackColor = System.Drawing.Color.Transparent
        Me.lblcreate_date.Location = New System.Drawing.Point(10, 251)
        Me.lblcreate_date.Name = "lblcreate_date"
        Me.lblcreate_date.Size = New System.Drawing.Size(121, 17)
        Me.lblcreate_date.TabIndex = 21
        Me.lblcreate_date.Text = "create_date"
        'dtpupdate_date
        '
        Me.dtpupdate_date.Location = New System.Drawing.Point(138, 270)
        Me.dtpupdate_date.Name = "dtpupdate_date"
        Me.dtpupdate_date.Size = New System.Drawing.Size(225, 21)
        Me.dtpupdate_date.ShowCheckBox = True
        Me.dtpupdate_date.TabIndex = 24
        Me.dtpupdate_date.Format = DateTimePickerFormat.Long
        'lblupdate_date
        '
        Me.lblupdate_date.BackColor = System.Drawing.Color.Transparent
        Me.lblupdate_date.Location = New System.Drawing.Point(10, 272)
        Me.lblupdate_date.Name = "lblupdate_date"
        Me.lblupdate_date.Size = New System.Drawing.Size(121, 17)
        Me.lblupdate_date.TabIndex = 23
        Me.lblupdate_date.Text = "update_date"
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(138, 292)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(225, 21)
        Me.txtopt_by.TabIndex = 26
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(10, 294)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_by.TabIndex = 25
        Me.lblopt_by.Text = "opt_by"
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(138, 313)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.TabIndex = 28
        Me.dtpopt_dtime.Format = DateTimePickerFormat.Long
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(10, 316)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_dtime.TabIndex = 27
        Me.lblopt_dtime.Text = "opt_dtime"
        'txtopt_timestamp
        '
        Me.txtopt_timestamp.Location = New System.Drawing.Point(0, 0)
        Me.txtopt_timestamp.Name = "txtopt_timestamp"
        Me.txtopt_timestamp.Size = New System.Drawing.Size(0, 0)
        Me.txtopt_timestamp.TabIndex = 0
        'lblopt_timestamp
        '
        Me.lblopt_timestamp.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_timestamp.Location = New System.Drawing.Point(0, 0)
        Me.lblopt_timestamp.Name = "lblopt_timestamp"
        Me.lblopt_timestamp.Size = New System.Drawing.Size(0, 0)
        Me.lblopt_timestamp.TabIndex = 0
        Me.lblopt_timestamp.Text = "opt_timestamp"
        'pnlMain
        '
        Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtuser_code, Me.lbluser_code, Me.txtuser_name, Me.lbluser_name, Me.txtpassword_, Me.lblpassword_, Me.txtSTCD, Me.lblSTCD, Me.chkallowlogin, Me.chkisadmin, Me.txttitle, Me.lbltitle, Me.txttel, Me.lbltel, Me.txtfax, Me.lblfax, Me.txtmobile, Me.lblmobile, Me.txtemail, Me.lblemail, Me.dtpcreate_date, Me.lblcreate_date, Me.dtpupdate_date, Me.lblupdate_date, Me.txtopt_by, Me.lblopt_by, Me.dtpopt_dtime, Me.lblopt_dtime, Me.txtopt_timestamp, Me.lblopt_timestamp})
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(392, 264)
        Me.pnlMain.TabIndex = 0
        Me.pnlMain.TabStop = False
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top

        Me.gd__clsUserpermission.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsUserpermission.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsUserpermission.Name = "Me.gd__clsUserpermission"
        Me.gd__clsUserpermission.Size = New System.Drawing.Size(552, 116)
        Me.gd__clsUserpermission.TabIndex = 30
        'tp__clsUserpermission
        '        
        Me.tp__clsUserpermission.Controls.AddRange(New System.Windows.Forms.Control() {Me.gd__clsUserpermission})
        Me.tp__clsUserpermission.Location = New System.Drawing.Point(0, 0)
        Me.tp__clsUserpermission.Name = "tp__clsUserpermission"
        Me.tp__clsUserpermission.Size = New System.Drawing.Size(392, 264)
        Me.tp__clsUserpermission.TabIndex = 0
        Me.tp__clsUserpermission.Text = "clsUserpermissions"
        Me.tp__clsUserpermission.AutoScroll = True

        Me.gd__clsUserrole.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsUserrole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsUserrole.Name = "Me.gd__clsUserrole"
        Me.gd__clsUserrole.Size = New System.Drawing.Size(552, 116)
        Me.gd__clsUserrole.TabIndex = 31
        'tp__clsUserrole
        '        
        Me.tp__clsUserrole.Controls.AddRange(New System.Windows.Forms.Control() {Me.gd__clsUserrole})
        Me.tp__clsUserrole.Location = New System.Drawing.Point(0, 0)
        Me.tp__clsUserrole.Name = "tp__clsUserrole"
        Me.tp__clsUserrole.Size = New System.Drawing.Size(392, 264)
        Me.tp__clsUserrole.TabIndex = 0
        Me.tp__clsUserrole.Text = "clsUserroles"
        Me.tp__clsUserrole.AutoScroll = True
        'tabGrid
        '        
        Me.tabGrid.Controls.AddRange(New System.Windows.Forms.Control() {Me.tp__clsUserpermission, Me.tp__clsUserrole})
        Me.tabGrid.Location = New System.Drawing.Point(0, 0)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.SelectedIndex = 0
        Me.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrid.Size = New System.Drawing.Size(392, 264)
        Me.tabGrid.TabIndex = 29
		 Me.tabGrid.Alignment = System.Windows.Forms.TabAlignment.Bottom
        '
        'frmclsOPERATOR
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.AutoScroll = True
        Me.WindowState = FormWindowState.Maximized
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabGrid, Me.splMain, Me.pnlMain})
        Me.Font = New System.Drawing.Font("Î¢ÈíÑÅºÚ", 9.0, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "clsOPERATOR"
        Me.Text = "2335"
        CType(Me.gd__clsUserpermission, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gd__clsUserrole, System.ComponentModel.ISupportInitialize).EndInit()

        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clsOPERATOR = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtuser_code, "Text", objBO, "user_code")
            BindField(Me.txtuser_name, "Text", objBO, "user_name")
            BindField(Me.txtpassword_, "Text", objBO, "password_")
            BindField(Me.txtSTCD, "Text", objBO, "STCD")
            BindField(Me.chkallowlogin, "Checked", objBO, "allowlogin")
            BindField(Me.chkisadmin, "Checked", objBO, "isadmin")
            BindField(Me.txttitle, "Text", objBO, "title")
            BindField(Me.txttel, "Text", objBO, "tel")
            BindField(Me.txtfax, "Text", objBO, "fax")
            BindField(Me.txtmobile, "Text", objBO, "mobile")
            BindField(Me.txtemail, "Text", objBO, "email")
            BindField(Me.dtpcreate_date, "Text", objBO, "create_date")
            BindField(Me.dtpupdate_date, "Text", objBO, "update_date")
            BindField(Me.txtopt_by, "Text", objBO, "opt_by")
            BindField(Me.dtpopt_dtime, "Text", objBO, "opt_dtime")
            CType(Me.gd__clsUserpermission, IGrid).DataSource = objBO.clsUserpermissions
            CType(Me.gd__clsUserrole, IGrid).DataSource = objBO.clsUserroles
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "DataBind")
        End Try
    End Sub

    Protected Overrides Sub UpdateControlEditStatus()
    	Me.FormatControlEditStatus()
    	Me.SetChildGridEditMode(Me.gd__clsUserpermission)
    	Me.SetChildGridEditMode(Me.gd__clsUserrole)
    End Sub
    
    Public Overrides Sub Format()
    	try
        	MyBase.Format()
        	MyBase.FormatControl(txtuser_code, "user_code", lbluser_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtuser_name, "user_name", lbluser_name, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtpassword_, "password_", lblpassword_, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtSTCD, "STCD", lblSTCD, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(chkallowlogin, "allowlogin", , AddressOf mControlHelper.CheckBoxFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(chkisadmin, "isadmin", , AddressOf mControlHelper.CheckBoxFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(txttitle, "title", lbltitle, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txttel, "tel", lbltel, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtfax, "fax", lblfax, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtmobile, "mobile", lblmobile, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtemail, "email", lblemail, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpcreate_date, "create_date", lblcreate_date, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(dtpupdate_date, "update_date", lblupdate_date, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(txtopt_by, "opt_by", lblopt_by, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
    		Me.tp__clsUserpermission.Text = mobjapp.GetLayout.CXObjectLays(GetType(clsUserpermission).Name).ColCaptionText
        	CType(Me.gd__clsUserpermission, IGrid).FormatGrid()
    		Me.tp__clsUserrole.Text = mobjapp.GetLayout.CXObjectLays(GetType(clsUserrole).Name).ColCaptionText
        	CType(Me.gd__clsUserrole, IGrid).FormatGrid()
        Me.LoadLayout()
        Catch ThisException As Exception
        	ErrorMsg(ThisException, Me.GetType, "Format")
        End Try        
    End Sub
    
    Private Sub tabGrid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabGrid.SelectedIndexChanged
		Me.UpdateEditStatus()
    End Sub
    
    Public Overrides ReadOnly Property SelectedIGrid() As IGrid
    	Get
        	Return CType( tabGrid.TabPages(tabGrid.SelectedIndex).Controls(0) , IGrid)
        End Get
    End Property
    
    Protected Overrides Sub LoadChildrenData(Optional ByVal blnReset As Boolean = False)
    	CType(Current, clsOPERATOR).LoadclsUserpermissions(blnReset)
    	CType(Current, clsOPERATOR).LoadclsUserroles(blnReset)
	End Sub
		
    Private Sub frmclsOPERATOR_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
    	LoadChildrenData
    End Sub

	Public Overrides ReadOnly Property ReportViewer() As Object Implements IPrintableForm.ReportViewer
        Get
        End Get
    End Property
    
    Private Sub FormOnError(ByVal sender As Object, ByVal e As FormExceptionEventArgs) Handles MyBase.OnError
        Dim ex As FormExceptionEventArgs = e
        ErrorMsg(ex.Exception, ex.ClassType, ex.Routine)
    End Sub
#End Region

#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
