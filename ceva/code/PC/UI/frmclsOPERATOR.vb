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
        Me.splMain = New System.Windows.Forms.Splitter
        Me.txtuser_code = New System.Windows.Forms.TextBox
        Me.lbluser_code = New System.Windows.Forms.Label
        Me.txtuser_name = New System.Windows.Forms.TextBox
        Me.lbluser_name = New System.Windows.Forms.Label
        Me.txtpassword_ = New System.Windows.Forms.TextBox
        Me.lblpassword_ = New System.Windows.Forms.Label
        Me.txtSTCD = New System.Windows.Forms.TextBox
        Me.lblSTCD = New System.Windows.Forms.Label
        Me.chkallowlogin = New System.Windows.Forms.CheckBox
        Me.chkisadmin = New System.Windows.Forms.CheckBox
        Me.txttitle = New System.Windows.Forms.TextBox
        Me.lbltitle = New System.Windows.Forms.Label
        Me.txttel = New System.Windows.Forms.TextBox
        Me.lbltel = New System.Windows.Forms.Label
        Me.txtfax = New System.Windows.Forms.TextBox
        Me.lblfax = New System.Windows.Forms.Label
        Me.txtmobile = New System.Windows.Forms.TextBox
        Me.lblmobile = New System.Windows.Forms.Label
        Me.txtemail = New System.Windows.Forms.TextBox
        Me.lblemail = New System.Windows.Forms.Label
        Me.dtpcreate_date = New System.Windows.Forms.DateTimePicker
        Me.lblcreate_date = New System.Windows.Forms.Label
        Me.dtpupdate_date = New System.Windows.Forms.DateTimePicker
        Me.lblupdate_date = New System.Windows.Forms.Label
        Me.txtopt_by = New System.Windows.Forms.TextBox
        Me.lblopt_by = New System.Windows.Forms.Label
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker
        Me.lblopt_dtime = New System.Windows.Forms.Label
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox
        Me.lblopt_timestamp = New System.Windows.Forms.Label
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.tp__clsUserpermission = New System.Windows.Forms.TabPage
        Me.gd__clsUserpermission = New YTUI.DataGrid
        Me.tp__clsUserrole = New System.Windows.Forms.TabPage
        Me.gd__clsUserrole = New YTUI.DataGrid
        Me.tabGrid = New System.Windows.Forms.TabControl
        CType(Me.ErrorPrvd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.tp__clsUserpermission.SuspendLayout()
        CType(Me.gd__clsUserpermission, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp__clsUserrole.SuspendLayout()
        CType(Me.gd__clsUserrole, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkIsDirty
        '
        Me.chkIsDirty.Location = New System.Drawing.Point(-47, -79)
        Me.chkIsDirty.Size = New System.Drawing.Size(4, 6)
        '
        'CQ
        '
        Me.CQ.Location = New System.Drawing.Point(0, 34)
        Me.CQ.Size = New System.Drawing.Size(773, 25)
        '
        'CB
        '
        Me.CB.Location = New System.Drawing.Point(0, 0)
        Me.CB.Size = New System.Drawing.Size(773, 34)
        '
        'splMain
        '
        Me.splMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.splMain.Location = New System.Drawing.Point(0, 272)
        Me.splMain.Name = "splMain"
        Me.splMain.Size = New System.Drawing.Size(773, 10)
        Me.splMain.TabIndex = 30
        Me.splMain.TabStop = False
        '
        'txtuser_code
        '
        Me.txtuser_code.Location = New System.Drawing.Point(166, 11)
        Me.txtuser_code.Name = "txtuser_code"
        Me.txtuser_code.Size = New System.Drawing.Size(270, 23)
        Me.txtuser_code.TabIndex = 2
        '
        'lbluser_code
        '
        Me.lbluser_code.BackColor = System.Drawing.Color.Transparent
        Me.lbluser_code.Location = New System.Drawing.Point(12, 14)
        Me.lbluser_code.Name = "lbluser_code"
        Me.lbluser_code.Size = New System.Drawing.Size(145, 19)
        Me.lbluser_code.TabIndex = 1
        Me.lbluser_code.Text = "user_code"
        '
        'txtuser_name
        '
        Me.txtuser_name.Location = New System.Drawing.Point(166, 37)
        Me.txtuser_name.Name = "txtuser_name"
        Me.txtuser_name.Size = New System.Drawing.Size(270, 23)
        Me.txtuser_name.TabIndex = 4
        '
        'lbluser_name
        '
        Me.lbluser_name.BackColor = System.Drawing.Color.Transparent
        Me.lbluser_name.Location = New System.Drawing.Point(12, 39)
        Me.lbluser_name.Name = "lbluser_name"
        Me.lbluser_name.Size = New System.Drawing.Size(145, 19)
        Me.lbluser_name.TabIndex = 3
        Me.lbluser_name.Text = "user_name"
        '
        'txtpassword_
        '
        Me.txtpassword_.Location = New System.Drawing.Point(166, 61)
        Me.txtpassword_.Name = "txtpassword_"
        Me.txtpassword_.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtpassword_.Size = New System.Drawing.Size(270, 23)
        Me.txtpassword_.TabIndex = 6
        '
        'lblpassword_
        '
        Me.lblpassword_.BackColor = System.Drawing.Color.Transparent
        Me.lblpassword_.Location = New System.Drawing.Point(12, 64)
        Me.lblpassword_.Name = "lblpassword_"
        Me.lblpassword_.Size = New System.Drawing.Size(145, 19)
        Me.lblpassword_.TabIndex = 5
        Me.lblpassword_.Text = "password"
        '
        'txtSTCD
        '
        Me.txtSTCD.Location = New System.Drawing.Point(166, 86)
        Me.txtSTCD.Name = "txtSTCD"
        Me.txtSTCD.Size = New System.Drawing.Size(270, 23)
        Me.txtSTCD.TabIndex = 8
        '
        'lblSTCD
        '
        Me.lblSTCD.BackColor = System.Drawing.Color.Transparent
        Me.lblSTCD.Location = New System.Drawing.Point(12, 88)
        Me.lblSTCD.Name = "lblSTCD"
        Me.lblSTCD.Size = New System.Drawing.Size(145, 19)
        Me.lblSTCD.TabIndex = 7
        Me.lblSTCD.Text = "STCD"
        '
        'chkallowlogin
        '
        Me.chkallowlogin.Location = New System.Drawing.Point(12, 166)
        Me.chkallowlogin.Name = "chkallowlogin"
        Me.chkallowlogin.Size = New System.Drawing.Size(157, 24)
        Me.chkallowlogin.TabIndex = 9
        Me.chkallowlogin.Text = "allowlogin"
        '
        'chkisadmin
        '
        Me.chkisadmin.Location = New System.Drawing.Point(279, 166)
        Me.chkisadmin.Name = "chkisadmin"
        Me.chkisadmin.Size = New System.Drawing.Size(157, 24)
        Me.chkisadmin.TabIndex = 10
        Me.chkisadmin.Text = "isadmin"
        '
        'txttitle
        '
        Me.txttitle.Location = New System.Drawing.Point(166, 112)
        Me.txttitle.Name = "txttitle"
        Me.txttitle.Size = New System.Drawing.Size(270, 23)
        Me.txttitle.TabIndex = 12
        '
        'lbltitle
        '
        Me.lbltitle.BackColor = System.Drawing.Color.Transparent
        Me.lbltitle.Location = New System.Drawing.Point(12, 114)
        Me.lbltitle.Name = "lbltitle"
        Me.lbltitle.Size = New System.Drawing.Size(145, 20)
        Me.lbltitle.TabIndex = 11
        Me.lbltitle.Text = "title"
        '
        'txttel
        '
        Me.txttel.Location = New System.Drawing.Point(166, 137)
        Me.txttel.Name = "txttel"
        Me.txttel.Size = New System.Drawing.Size(270, 23)
        Me.txttel.TabIndex = 14
        '
        'lbltel
        '
        Me.lbltel.BackColor = System.Drawing.Color.Transparent
        Me.lbltel.Location = New System.Drawing.Point(12, 139)
        Me.lbltel.Name = "lbltel"
        Me.lbltel.Size = New System.Drawing.Size(145, 20)
        Me.lbltel.TabIndex = 13
        Me.lbltel.Text = "tel"
        '
        'txtfax
        '
        Me.txtfax.Location = New System.Drawing.Point(603, 8)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Size = New System.Drawing.Size(270, 23)
        Me.txtfax.TabIndex = 16
        '
        'lblfax
        '
        Me.lblfax.BackColor = System.Drawing.Color.Transparent
        Me.lblfax.Location = New System.Drawing.Point(449, 12)
        Me.lblfax.Name = "lblfax"
        Me.lblfax.Size = New System.Drawing.Size(145, 19)
        Me.lblfax.TabIndex = 15
        Me.lblfax.Text = "fax"
        '
        'txtmobile
        '
        Me.txtmobile.Location = New System.Drawing.Point(603, 33)
        Me.txtmobile.Name = "txtmobile"
        Me.txtmobile.Size = New System.Drawing.Size(270, 23)
        Me.txtmobile.TabIndex = 18
        '
        'lblmobile
        '
        Me.lblmobile.BackColor = System.Drawing.Color.Transparent
        Me.lblmobile.Location = New System.Drawing.Point(449, 36)
        Me.lblmobile.Name = "lblmobile"
        Me.lblmobile.Size = New System.Drawing.Size(145, 19)
        Me.lblmobile.TabIndex = 17
        Me.lblmobile.Text = "mobile"
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(603, 58)
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(270, 23)
        Me.txtemail.TabIndex = 20
        '
        'lblemail
        '
        Me.lblemail.BackColor = System.Drawing.Color.Transparent
        Me.lblemail.Location = New System.Drawing.Point(449, 61)
        Me.lblemail.Name = "lblemail"
        Me.lblemail.Size = New System.Drawing.Size(145, 19)
        Me.lblemail.TabIndex = 19
        Me.lblemail.Text = "email"
        '
        'dtpcreate_date
        '
        Me.dtpcreate_date.Location = New System.Drawing.Point(603, 82)
        Me.dtpcreate_date.Name = "dtpcreate_date"
        Me.dtpcreate_date.ShowCheckBox = True
        Me.dtpcreate_date.Size = New System.Drawing.Size(270, 23)
        Me.dtpcreate_date.TabIndex = 22
        '
        'lblcreate_date
        '
        Me.lblcreate_date.BackColor = System.Drawing.Color.Transparent
        Me.lblcreate_date.Location = New System.Drawing.Point(449, 86)
        Me.lblcreate_date.Name = "lblcreate_date"
        Me.lblcreate_date.Size = New System.Drawing.Size(145, 19)
        Me.lblcreate_date.TabIndex = 21
        Me.lblcreate_date.Text = "create_date"
        '
        'dtpupdate_date
        '
        Me.dtpupdate_date.Location = New System.Drawing.Point(603, 108)
        Me.dtpupdate_date.Name = "dtpupdate_date"
        Me.dtpupdate_date.ShowCheckBox = True
        Me.dtpupdate_date.Size = New System.Drawing.Size(270, 23)
        Me.dtpupdate_date.TabIndex = 24
        '
        'lblupdate_date
        '
        Me.lblupdate_date.BackColor = System.Drawing.Color.Transparent
        Me.lblupdate_date.Location = New System.Drawing.Point(449, 110)
        Me.lblupdate_date.Name = "lblupdate_date"
        Me.lblupdate_date.Size = New System.Drawing.Size(145, 19)
        Me.lblupdate_date.TabIndex = 23
        Me.lblupdate_date.Text = "update_date"
        '
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(603, 133)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(270, 23)
        Me.txtopt_by.TabIndex = 26
        '
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(449, 135)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(145, 19)
        Me.lblopt_by.TabIndex = 25
        Me.lblopt_by.Text = "opt_by"
        '
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(603, 157)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.Size = New System.Drawing.Size(270, 23)
        Me.dtpopt_dtime.TabIndex = 28
        '
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(449, 160)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(145, 20)
        Me.lblopt_dtime.TabIndex = 27
        Me.lblopt_dtime.Text = "opt_dtime"
        '
        'txtopt_timestamp
        '
        Me.txtopt_timestamp.Location = New System.Drawing.Point(0, 0)
        Me.txtopt_timestamp.Name = "txtopt_timestamp"
        Me.txtopt_timestamp.Size = New System.Drawing.Size(0, 23)
        Me.txtopt_timestamp.TabIndex = 0
        '
        'lblopt_timestamp
        '
        Me.lblopt_timestamp.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_timestamp.Location = New System.Drawing.Point(0, 0)
        Me.lblopt_timestamp.Name = "lblopt_timestamp"
        Me.lblopt_timestamp.Size = New System.Drawing.Size(0, 0)
        Me.lblopt_timestamp.TabIndex = 0
        Me.lblopt_timestamp.Text = "opt_timestamp"
        '
        'pnlMain
        '
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Controls.Add(Me.txtuser_code)
        Me.pnlMain.Controls.Add(Me.lbluser_code)
        Me.pnlMain.Controls.Add(Me.txtuser_name)
        Me.pnlMain.Controls.Add(Me.lbluser_name)
        Me.pnlMain.Controls.Add(Me.txtpassword_)
        Me.pnlMain.Controls.Add(Me.lblpassword_)
        Me.pnlMain.Controls.Add(Me.txtSTCD)
        Me.pnlMain.Controls.Add(Me.lblSTCD)
        Me.pnlMain.Controls.Add(Me.chkallowlogin)
        Me.pnlMain.Controls.Add(Me.chkisadmin)
        Me.pnlMain.Controls.Add(Me.txttitle)
        Me.pnlMain.Controls.Add(Me.lbltitle)
        Me.pnlMain.Controls.Add(Me.txttel)
        Me.pnlMain.Controls.Add(Me.lbltel)
        Me.pnlMain.Controls.Add(Me.txtfax)
        Me.pnlMain.Controls.Add(Me.lblfax)
        Me.pnlMain.Controls.Add(Me.txtmobile)
        Me.pnlMain.Controls.Add(Me.lblmobile)
        Me.pnlMain.Controls.Add(Me.txtemail)
        Me.pnlMain.Controls.Add(Me.lblemail)
        Me.pnlMain.Controls.Add(Me.dtpcreate_date)
        Me.pnlMain.Controls.Add(Me.lblcreate_date)
        Me.pnlMain.Controls.Add(Me.dtpupdate_date)
        Me.pnlMain.Controls.Add(Me.lblupdate_date)
        Me.pnlMain.Controls.Add(Me.txtopt_by)
        Me.pnlMain.Controls.Add(Me.lblopt_by)
        Me.pnlMain.Controls.Add(Me.dtpopt_dtime)
        Me.pnlMain.Controls.Add(Me.lblopt_dtime)
        Me.pnlMain.Controls.Add(Me.txtopt_timestamp)
        Me.pnlMain.Controls.Add(Me.lblopt_timestamp)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMain.Location = New System.Drawing.Point(0, 59)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(773, 213)
        Me.pnlMain.TabIndex = 0
        '
        'tp__clsUserpermission
        '
        Me.tp__clsUserpermission.AutoScroll = True
        Me.tp__clsUserpermission.Controls.Add(Me.gd__clsUserpermission)
        Me.tp__clsUserpermission.Location = New System.Drawing.Point(4, 4)
        Me.tp__clsUserpermission.Name = "tp__clsUserpermission"
        Me.tp__clsUserpermission.Size = New System.Drawing.Size(765, 157)
        Me.tp__clsUserpermission.TabIndex = 0
        Me.tp__clsUserpermission.Text = "clsUserpermissions"
        '
        'gd__clsUserpermission
        '
        Me.gd__clsUserpermission.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsUserpermission.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsUserpermission.ColumnListName = ""
        Me.gd__clsUserpermission.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsUserpermission.Deletable = True
        Me.gd__clsUserpermission.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsUserpermission.Editable = True
        Me.gd__clsUserpermission.Hierarchical = True
        Me.gd__clsUserpermission.Location = New System.Drawing.Point(0, 0)
        Me.gd__clsUserpermission.Name = "gd__clsUserpermission"
        Me.gd__clsUserpermission.RecordNavigator = True
        Me.gd__clsUserpermission.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsUserpermission.Size = New System.Drawing.Size(765, 157)
        Me.gd__clsUserpermission.TabIndex = 30
        Me.gd__clsUserpermission.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'tp__clsUserrole
        '
        Me.tp__clsUserrole.AutoScroll = True
        Me.tp__clsUserrole.Controls.Add(Me.gd__clsUserrole)
        Me.tp__clsUserrole.Location = New System.Drawing.Point(4, 4)
        Me.tp__clsUserrole.Name = "tp__clsUserrole"
        Me.tp__clsUserrole.Size = New System.Drawing.Size(765, 161)
        Me.tp__clsUserrole.TabIndex = 0
        Me.tp__clsUserrole.Text = "clsUserroles"
        '
        'gd__clsUserrole
        '
        Me.gd__clsUserrole.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsUserrole.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsUserrole.ColumnListName = ""
        Me.gd__clsUserrole.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsUserrole.Deletable = True
        Me.gd__clsUserrole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsUserrole.Editable = True
        Me.gd__clsUserrole.Hierarchical = True
        Me.gd__clsUserrole.Location = New System.Drawing.Point(0, 0)
        Me.gd__clsUserrole.Name = "gd__clsUserrole"
        Me.gd__clsUserrole.RecordNavigator = True
        Me.gd__clsUserrole.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsUserrole.Size = New System.Drawing.Size(765, 161)
        Me.gd__clsUserrole.TabIndex = 31
        Me.gd__clsUserrole.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'tabGrid
        '
        Me.tabGrid.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabGrid.Controls.Add(Me.tp__clsUserpermission)
        Me.tabGrid.Controls.Add(Me.tp__clsUserrole)
        Me.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrid.Location = New System.Drawing.Point(0, 282)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.SelectedIndex = 0
        Me.tabGrid.Size = New System.Drawing.Size(773, 187)
        Me.tabGrid.TabIndex = 29
        '
        'frmclsOPERATORBase__
        '
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(773, 469)
        Me.Controls.Add(Me.tabGrid)
        Me.Controls.Add(Me.splMain)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmclsOPERATORBase__"
        Me.Text = "2335"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.CB, 0)
        Me.Controls.SetChildIndex(Me.CQ, 0)
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.Controls.SetChildIndex(Me.splMain, 0)
        Me.Controls.SetChildIndex(Me.tabGrid, 0)
        Me.Controls.SetChildIndex(Me.chkIsDirty, 0)
        CType(Me.ErrorPrvd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.tp__clsUserpermission.ResumeLayout(False)
        CType(Me.gd__clsUserpermission, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp__clsUserrole.ResumeLayout(False)
        CType(Me.gd__clsUserrole, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabGrid.ResumeLayout(False)
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

    Protected Overrides Sub UpdateNavigationStatus()
        MyBase.UpdateNavigationStatus()
        DisableButton()
    End Sub

    Protected Overrides Sub UpdateDirtyStatus()
        MyBase.UpdateDirtyStatus()
        DisableButton()
    End Sub

    Protected Overrides Sub UpdateEditStatus()
        MyBase.UpdateEditStatus()
        DisableButton()
    End Sub


    Private Sub DisableButton()
        If Me.Current Is Nothing Then
            Exit Sub
        End If
        If Not Me.GetToolbarService Is Nothing Then
            With Me.GetToolbarService
                .ButtonEnabled(BK_PRINT) = False
                .ButtonEnabled(BK_EXPORT) = False
                .ButtonEnabled(BK_IMPORT) = False

                If Not Me.Editable Then
                    .ButtonEnabled(BK_NEW) = UserRightMgr.GetRightNoDC(Rights.USERNEW)
                    .ButtonEnabled(BK_EDIT) = UserRightMgr.GetRightNoDC(Rights.USEREDIT)
                    .ButtonEnabled(BK_DELETE) = UserRightMgr.GetRightNoDC(Rights.USERREMOVE)
                    .ButtonEnabled("LoadItem") = UserRightMgr.GetRightNoDC(Rights.DNHDRLOAD)
                Else
                    .ButtonEnabled(BK_EDIT) = False
                    .ButtonEnabled(BK_NEW) = False
                    .ButtonEnabled(BK_DELETE) = False
                    .ButtonEnabled("LoadItem") = False
                End If
            End With
        End If
    End Sub
#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
