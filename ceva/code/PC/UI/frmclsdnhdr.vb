Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclsdnhdrBase__
    Inherits CXMdiChildForm
	Implements IPrintableForm
#Region " user defined property "
    Dim CloseBill As New clsCloseBill
    Dim Optimization As New clsOptimizationDN
#End Region
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
    Protected Friend WithEvents txtdc_code As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldc_code As System.Windows.Forms.Label
    Protected Friend WithEvents txtdn_no As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldn_no As System.Windows.Forms.Label
    Protected Friend WithEvents txtsony_bch_no As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblsony_bch_no As System.Windows.Forms.Label
    Protected Friend WithEvents cbodoc_type As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lbldoc_type As System.Windows.Forms.Label
    Protected Friend WithEvents dtpimp_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblimp_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents txtcity_to As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblcity_to As System.Windows.Forms.Label
    Protected Friend WithEvents txtdeal_to As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldeal_to As System.Windows.Forms.Label
    Protected Friend WithEvents txtdeal_name As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldeal_name As System.Windows.Forms.Label
    Protected Friend WithEvents txtdeal_person As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldeal_person As System.Windows.Forms.Label
    Protected Friend WithEvents txtdeal_tel As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldeal_tel As System.Windows.Forms.Label
    Protected Friend WithEvents txtunloading_address As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblunloading_address As System.Windows.Forms.Label
    Protected Friend WithEvents cbostatus_code As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lblstatus_code As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_by As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_by As System.Windows.Forms.Label
    Protected Friend WithEvents dtpopt_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblopt_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents dtpstart_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblstart_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents dtpend_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblend_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents txtremark As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblremark As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_timestamp As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_timestamp As System.Windows.Forms.Label
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Protected Friend WithEvents tp__clsdnlin As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsdnlin As YTUI.DataGrid
    Protected Friend WithEvents tp__clstasklin As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clstasklin As YTUI.DataGrid
    Friend WithEvents BtnFinish As System.Windows.Forms.Button
    Friend WithEvents BtnOptimization As System.Windows.Forms.Button
    Protected Friend WithEvents tp__clsDnBin As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsDnBin As YTUI.DataGrid
    Protected Friend WithEvents tabGrid As System.Windows.Forms.TabControl

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.splMain = New System.Windows.Forms.Splitter
        Me.txtdc_code = New System.Windows.Forms.TextBox
        Me.lbldc_code = New System.Windows.Forms.Label
        Me.txtdn_no = New System.Windows.Forms.TextBox
        Me.lbldn_no = New System.Windows.Forms.Label
        Me.txtsony_bch_no = New System.Windows.Forms.TextBox
        Me.lblsony_bch_no = New System.Windows.Forms.Label
        Me.cbodoc_type = New System.Windows.Forms.ComboBox
        Me.lbldoc_type = New System.Windows.Forms.Label
        Me.dtpimp_dtime = New System.Windows.Forms.DateTimePicker
        Me.lblimp_dtime = New System.Windows.Forms.Label
        Me.txtcity_to = New System.Windows.Forms.TextBox
        Me.lblcity_to = New System.Windows.Forms.Label
        Me.txtdeal_to = New System.Windows.Forms.TextBox
        Me.lbldeal_to = New System.Windows.Forms.Label
        Me.txtdeal_name = New System.Windows.Forms.TextBox
        Me.lbldeal_name = New System.Windows.Forms.Label
        Me.txtdeal_person = New System.Windows.Forms.TextBox
        Me.lbldeal_person = New System.Windows.Forms.Label
        Me.txtdeal_tel = New System.Windows.Forms.TextBox
        Me.lbldeal_tel = New System.Windows.Forms.Label
        Me.txtunloading_address = New System.Windows.Forms.TextBox
        Me.lblunloading_address = New System.Windows.Forms.Label
        Me.cbostatus_code = New System.Windows.Forms.ComboBox
        Me.lblstatus_code = New System.Windows.Forms.Label
        Me.txtopt_by = New System.Windows.Forms.TextBox
        Me.lblopt_by = New System.Windows.Forms.Label
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker
        Me.lblopt_dtime = New System.Windows.Forms.Label
        Me.dtpstart_dtime = New System.Windows.Forms.DateTimePicker
        Me.lblstart_dtime = New System.Windows.Forms.Label
        Me.dtpend_dtime = New System.Windows.Forms.DateTimePicker
        Me.lblend_dtime = New System.Windows.Forms.Label
        Me.txtremark = New System.Windows.Forms.TextBox
        Me.lblremark = New System.Windows.Forms.Label
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox
        Me.lblopt_timestamp = New System.Windows.Forms.Label
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.BtnFinish = New System.Windows.Forms.Button
        Me.BtnOptimization = New System.Windows.Forms.Button
        Me.tp__clsdnlin = New System.Windows.Forms.TabPage
        Me.gd__clsdnlin = New YTUI.DataGrid
        Me.tp__clstasklin = New System.Windows.Forms.TabPage
        Me.gd__clstasklin = New YTUI.DataGrid
        Me.tp__clsDnBin = New System.Windows.Forms.TabPage
        Me.gd__clsDnBin = New YTUI.DataGrid
        Me.tabGrid = New System.Windows.Forms.TabControl
        CType(Me.ErrorPrvd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.tp__clsdnlin.SuspendLayout()
        CType(Me.gd__clsdnlin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp__clstasklin.SuspendLayout()
        CType(Me.gd__clstasklin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp__clsDnBin.SuspendLayout()
        CType(Me.gd__clsDnBin, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.CQ.Location = New System.Drawing.Point(0, 333)
        Me.CQ.Size = New System.Drawing.Size(923, 25)
        '
        'CB
        '
        Me.CB.Location = New System.Drawing.Point(0, 0)
        Me.CB.Size = New System.Drawing.Size(923, 34)
        '
        'splMain
        '
        Me.splMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.splMain.Location = New System.Drawing.Point(0, 323)
        Me.splMain.Name = "splMain"
        Me.splMain.Size = New System.Drawing.Size(923, 10)
        Me.splMain.TabIndex = 34
        Me.splMain.TabStop = False
        '
        'txtdc_code
        '
        Me.txtdc_code.Location = New System.Drawing.Point(161, 16)
        Me.txtdc_code.Name = "txtdc_code"
        Me.txtdc_code.Size = New System.Drawing.Size(250, 23)
        Me.txtdc_code.TabIndex = 2
        '
        'lbldc_code
        '
        Me.lbldc_code.BackColor = System.Drawing.Color.Transparent
        Me.lbldc_code.Location = New System.Drawing.Point(10, 16)
        Me.lbldc_code.Name = "lbldc_code"
        Me.lbldc_code.Size = New System.Drawing.Size(150, 22)
        Me.lbldc_code.TabIndex = 1
        Me.lbldc_code.Text = "dc_code"
        '
        'txtdn_no
        '
        Me.txtdn_no.Location = New System.Drawing.Point(161, 45)
        Me.txtdn_no.Name = "txtdn_no"
        Me.txtdn_no.Size = New System.Drawing.Size(250, 23)
        Me.txtdn_no.TabIndex = 4
        '
        'lbldn_no
        '
        Me.lbldn_no.BackColor = System.Drawing.Color.Transparent
        Me.lbldn_no.Location = New System.Drawing.Point(10, 45)
        Me.lbldn_no.Name = "lbldn_no"
        Me.lbldn_no.Size = New System.Drawing.Size(150, 22)
        Me.lbldn_no.TabIndex = 3
        Me.lbldn_no.Text = "dn_no"
        '
        'txtsony_bch_no
        '
        Me.txtsony_bch_no.Location = New System.Drawing.Point(619, 45)
        Me.txtsony_bch_no.Name = "txtsony_bch_no"
        Me.txtsony_bch_no.Size = New System.Drawing.Size(250, 23)
        Me.txtsony_bch_no.TabIndex = 6
        '
        'lblsony_bch_no
        '
        Me.lblsony_bch_no.BackColor = System.Drawing.Color.Transparent
        Me.lblsony_bch_no.Location = New System.Drawing.Point(462, 45)
        Me.lblsony_bch_no.Name = "lblsony_bch_no"
        Me.lblsony_bch_no.Size = New System.Drawing.Size(150, 22)
        Me.lblsony_bch_no.TabIndex = 5
        Me.lblsony_bch_no.Text = "sony_bch_no"
        '
        'cbodoc_type
        '
        Me.cbodoc_type.Location = New System.Drawing.Point(619, 16)
        Me.cbodoc_type.Name = "cbodoc_type"
        Me.cbodoc_type.Size = New System.Drawing.Size(250, 25)
        Me.cbodoc_type.TabIndex = 8
        '
        'lbldoc_type
        '
        Me.lbldoc_type.BackColor = System.Drawing.Color.Transparent
        Me.lbldoc_type.Location = New System.Drawing.Point(462, 19)
        Me.lbldoc_type.Name = "lbldoc_type"
        Me.lbldoc_type.Size = New System.Drawing.Size(121, 17)
        Me.lbldoc_type.TabIndex = 7
        Me.lbldoc_type.Text = "doc_type"
        '
        'dtpimp_dtime
        '
        Me.dtpimp_dtime.Location = New System.Drawing.Point(161, 260)
        Me.dtpimp_dtime.Name = "dtpimp_dtime"
        Me.dtpimp_dtime.ShowCheckBox = True
        Me.dtpimp_dtime.Size = New System.Drawing.Size(250, 23)
        Me.dtpimp_dtime.TabIndex = 8
        '
        'lblimp_dtime
        '
        Me.lblimp_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblimp_dtime.Location = New System.Drawing.Point(10, 260)
        Me.lblimp_dtime.Name = "lblimp_dtime"
        Me.lblimp_dtime.Size = New System.Drawing.Size(150, 22)
        Me.lblimp_dtime.TabIndex = 7
        Me.lblimp_dtime.Text = "imp_dtime"
        '
        'txtcity_to
        '
        Me.txtcity_to.Location = New System.Drawing.Point(161, 74)
        Me.txtcity_to.Name = "txtcity_to"
        Me.txtcity_to.Size = New System.Drawing.Size(250, 23)
        Me.txtcity_to.TabIndex = 10
        '
        'lblcity_to
        '
        Me.lblcity_to.BackColor = System.Drawing.Color.Transparent
        Me.lblcity_to.Location = New System.Drawing.Point(10, 74)
        Me.lblcity_to.Name = "lblcity_to"
        Me.lblcity_to.Size = New System.Drawing.Size(150, 22)
        Me.lblcity_to.TabIndex = 9
        Me.lblcity_to.Text = "city_to"
        '
        'txtdeal_to
        '
        Me.txtdeal_to.Location = New System.Drawing.Point(619, 74)
        Me.txtdeal_to.Name = "txtdeal_to"
        Me.txtdeal_to.Size = New System.Drawing.Size(250, 23)
        Me.txtdeal_to.TabIndex = 12
        '
        'lbldeal_to
        '
        Me.lbldeal_to.BackColor = System.Drawing.Color.Transparent
        Me.lbldeal_to.Location = New System.Drawing.Point(462, 74)
        Me.lbldeal_to.Name = "lbldeal_to"
        Me.lbldeal_to.Size = New System.Drawing.Size(150, 22)
        Me.lbldeal_to.TabIndex = 11
        Me.lbldeal_to.Text = "deal_to"
        '
        'txtdeal_name
        '
        Me.txtdeal_name.Location = New System.Drawing.Point(161, 105)
        Me.txtdeal_name.Name = "txtdeal_name"
        Me.txtdeal_name.Size = New System.Drawing.Size(250, 23)
        Me.txtdeal_name.TabIndex = 14
        '
        'lbldeal_name
        '
        Me.lbldeal_name.BackColor = System.Drawing.Color.Transparent
        Me.lbldeal_name.Location = New System.Drawing.Point(10, 105)
        Me.lbldeal_name.Name = "lbldeal_name"
        Me.lbldeal_name.Size = New System.Drawing.Size(150, 22)
        Me.lbldeal_name.TabIndex = 13
        Me.lbldeal_name.Text = "deal_name"
        '
        'txtdeal_person
        '
        Me.txtdeal_person.Location = New System.Drawing.Point(619, 105)
        Me.txtdeal_person.Name = "txtdeal_person"
        Me.txtdeal_person.Size = New System.Drawing.Size(250, 23)
        Me.txtdeal_person.TabIndex = 16
        '
        'lbldeal_person
        '
        Me.lbldeal_person.BackColor = System.Drawing.Color.Transparent
        Me.lbldeal_person.Location = New System.Drawing.Point(462, 105)
        Me.lbldeal_person.Name = "lbldeal_person"
        Me.lbldeal_person.Size = New System.Drawing.Size(150, 22)
        Me.lbldeal_person.TabIndex = 15
        Me.lbldeal_person.Text = "deal_person"
        '
        'txtdeal_tel
        '
        Me.txtdeal_tel.Location = New System.Drawing.Point(161, 136)
        Me.txtdeal_tel.Name = "txtdeal_tel"
        Me.txtdeal_tel.Size = New System.Drawing.Size(250, 23)
        Me.txtdeal_tel.TabIndex = 18
        '
        'lbldeal_tel
        '
        Me.lbldeal_tel.BackColor = System.Drawing.Color.Transparent
        Me.lbldeal_tel.Location = New System.Drawing.Point(10, 136)
        Me.lbldeal_tel.Name = "lbldeal_tel"
        Me.lbldeal_tel.Size = New System.Drawing.Size(150, 22)
        Me.lbldeal_tel.TabIndex = 17
        Me.lbldeal_tel.Text = "deal_tel"
        '
        'txtunloading_address
        '
        Me.txtunloading_address.Location = New System.Drawing.Point(161, 168)
        Me.txtunloading_address.Name = "txtunloading_address"
        Me.txtunloading_address.Size = New System.Drawing.Size(250, 23)
        Me.txtunloading_address.TabIndex = 20
        '
        'lblunloading_address
        '
        Me.lblunloading_address.BackColor = System.Drawing.Color.Transparent
        Me.lblunloading_address.Location = New System.Drawing.Point(10, 168)
        Me.lblunloading_address.Name = "lblunloading_address"
        Me.lblunloading_address.Size = New System.Drawing.Size(150, 22)
        Me.lblunloading_address.TabIndex = 19
        Me.lblunloading_address.Text = "unloading_address"
        '
        'cbostatus_code
        '
        Me.cbostatus_code.Location = New System.Drawing.Point(619, 136)
        Me.cbostatus_code.Name = "cbostatus_code"
        Me.cbostatus_code.Size = New System.Drawing.Size(250, 25)
        Me.cbostatus_code.TabIndex = 22
        '
        'lblstatus_code
        '
        Me.lblstatus_code.BackColor = System.Drawing.Color.Transparent
        Me.lblstatus_code.Location = New System.Drawing.Point(462, 136)
        Me.lblstatus_code.Name = "lblstatus_code"
        Me.lblstatus_code.Size = New System.Drawing.Size(150, 22)
        Me.lblstatus_code.TabIndex = 21
        Me.lblstatus_code.Text = "status_code"
        '
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(619, 168)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(250, 23)
        Me.txtopt_by.TabIndex = 24
        '
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(462, 168)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(150, 22)
        Me.lblopt_by.TabIndex = 23
        Me.lblopt_by.Text = "opt_by"
        '
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(161, 200)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.Size = New System.Drawing.Size(250, 23)
        Me.dtpopt_dtime.TabIndex = 26
        '
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(10, 200)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(150, 22)
        Me.lblopt_dtime.TabIndex = 25
        Me.lblopt_dtime.Text = "opt_dtime"
        '
        'dtpstart_dtime
        '
        Me.dtpstart_dtime.Location = New System.Drawing.Point(619, 200)
        Me.dtpstart_dtime.Name = "dtpstart_dtime"
        Me.dtpstart_dtime.ShowCheckBox = True
        Me.dtpstart_dtime.Size = New System.Drawing.Size(250, 23)
        Me.dtpstart_dtime.TabIndex = 28
        '
        'lblstart_dtime
        '
        Me.lblstart_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblstart_dtime.Location = New System.Drawing.Point(462, 200)
        Me.lblstart_dtime.Name = "lblstart_dtime"
        Me.lblstart_dtime.Size = New System.Drawing.Size(150, 22)
        Me.lblstart_dtime.TabIndex = 27
        Me.lblstart_dtime.Text = "start_dtime"
        '
        'dtpend_dtime
        '
        Me.dtpend_dtime.Location = New System.Drawing.Point(161, 231)
        Me.dtpend_dtime.Name = "dtpend_dtime"
        Me.dtpend_dtime.ShowCheckBox = True
        Me.dtpend_dtime.Size = New System.Drawing.Size(250, 23)
        Me.dtpend_dtime.TabIndex = 30
        '
        'lblend_dtime
        '
        Me.lblend_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblend_dtime.Location = New System.Drawing.Point(10, 231)
        Me.lblend_dtime.Name = "lblend_dtime"
        Me.lblend_dtime.Size = New System.Drawing.Size(150, 22)
        Me.lblend_dtime.TabIndex = 29
        Me.lblend_dtime.Text = "end_dtime"
        '
        'txtremark
        '
        Me.txtremark.Location = New System.Drawing.Point(619, 231)
        Me.txtremark.Name = "txtremark"
        Me.txtremark.Size = New System.Drawing.Size(250, 23)
        Me.txtremark.TabIndex = 32
        '
        'lblremark
        '
        Me.lblremark.BackColor = System.Drawing.Color.Transparent
        Me.lblremark.Location = New System.Drawing.Point(462, 231)
        Me.lblremark.Name = "lblremark"
        Me.lblremark.Size = New System.Drawing.Size(150, 22)
        Me.lblremark.TabIndex = 31
        Me.lblremark.Text = "remark"
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
        Me.pnlMain.Controls.Add(Me.BtnFinish)
        Me.pnlMain.Controls.Add(Me.BtnOptimization)
        Me.pnlMain.Controls.Add(Me.txtdc_code)
        Me.pnlMain.Controls.Add(Me.lbldc_code)
        Me.pnlMain.Controls.Add(Me.cbodoc_type)
        Me.pnlMain.Controls.Add(Me.lbldoc_type)
        Me.pnlMain.Controls.Add(Me.txtdn_no)
        Me.pnlMain.Controls.Add(Me.lbldn_no)
        Me.pnlMain.Controls.Add(Me.txtsony_bch_no)
        Me.pnlMain.Controls.Add(Me.lblsony_bch_no)
        Me.pnlMain.Controls.Add(Me.dtpimp_dtime)
        Me.pnlMain.Controls.Add(Me.lblimp_dtime)
        Me.pnlMain.Controls.Add(Me.txtcity_to)
        Me.pnlMain.Controls.Add(Me.lblcity_to)
        Me.pnlMain.Controls.Add(Me.txtdeal_to)
        Me.pnlMain.Controls.Add(Me.lbldeal_to)
        Me.pnlMain.Controls.Add(Me.txtdeal_name)
        Me.pnlMain.Controls.Add(Me.lbldeal_name)
        Me.pnlMain.Controls.Add(Me.txtdeal_person)
        Me.pnlMain.Controls.Add(Me.lbldeal_person)
        Me.pnlMain.Controls.Add(Me.txtdeal_tel)
        Me.pnlMain.Controls.Add(Me.lbldeal_tel)
        Me.pnlMain.Controls.Add(Me.txtunloading_address)
        Me.pnlMain.Controls.Add(Me.lblunloading_address)
        Me.pnlMain.Controls.Add(Me.cbostatus_code)
        Me.pnlMain.Controls.Add(Me.lblstatus_code)
        Me.pnlMain.Controls.Add(Me.txtopt_by)
        Me.pnlMain.Controls.Add(Me.lblopt_by)
        Me.pnlMain.Controls.Add(Me.dtpopt_dtime)
        Me.pnlMain.Controls.Add(Me.lblopt_dtime)
        Me.pnlMain.Controls.Add(Me.dtpstart_dtime)
        Me.pnlMain.Controls.Add(Me.lblstart_dtime)
        Me.pnlMain.Controls.Add(Me.dtpend_dtime)
        Me.pnlMain.Controls.Add(Me.lblend_dtime)
        Me.pnlMain.Controls.Add(Me.txtremark)
        Me.pnlMain.Controls.Add(Me.lblremark)
        Me.pnlMain.Controls.Add(Me.txtopt_timestamp)
        Me.pnlMain.Controls.Add(Me.lblopt_timestamp)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMain.Location = New System.Drawing.Point(0, 34)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(923, 289)
        Me.pnlMain.TabIndex = 0
        '
        'BtnFinish
        '
        Me.BtnFinish.Enabled = False
        Me.BtnFinish.Location = New System.Drawing.Point(768, 258)
        Me.BtnFinish.Name = "BtnFinish"
        Me.BtnFinish.Size = New System.Drawing.Size(90, 26)
        Me.BtnFinish.TabIndex = 34
        Me.BtnFinish.Text = "完成"
        Me.BtnFinish.UseVisualStyleBackColor = True
        Me.BtnFinish.Visible = False
        '
        'BtnOptimization
        '
        Me.BtnOptimization.Enabled = False
        Me.BtnOptimization.Location = New System.Drawing.Point(636, 258)
        Me.BtnOptimization.Name = "BtnOptimization"
        Me.BtnOptimization.Size = New System.Drawing.Size(90, 26)
        Me.BtnOptimization.TabIndex = 33
        Me.BtnOptimization.Text = "货位推荐"
        Me.BtnOptimization.UseVisualStyleBackColor = True
        Me.BtnOptimization.Visible = False
        '
        'tp__clsdnlin
        '
        Me.tp__clsdnlin.AutoScroll = True
        Me.tp__clsdnlin.Controls.Add(Me.gd__clsdnlin)
        Me.tp__clsdnlin.Location = New System.Drawing.Point(4, 4)
        Me.tp__clsdnlin.Name = "tp__clsdnlin"
        Me.tp__clsdnlin.Size = New System.Drawing.Size(915, 81)
        Me.tp__clsdnlin.TabIndex = 0
        Me.tp__clsdnlin.Text = "clsdnlins"
        '
        'gd__clsdnlin
        '
        Me.gd__clsdnlin.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsdnlin.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsdnlin.ColumnListName = ""
        Me.gd__clsdnlin.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsdnlin.Deletable = True
        Me.gd__clsdnlin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsdnlin.Editable = True
        Me.gd__clsdnlin.Hierarchical = True
        Me.gd__clsdnlin.Location = New System.Drawing.Point(0, 0)
        Me.gd__clsdnlin.Name = "gd__clsdnlin"
        Me.gd__clsdnlin.RecordNavigator = True
        Me.gd__clsdnlin.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsdnlin.Size = New System.Drawing.Size(915, 81)
        Me.gd__clsdnlin.TabIndex = 34
        Me.gd__clsdnlin.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'tp__clstasklin
        '
        Me.tp__clstasklin.AutoScroll = True
        Me.tp__clstasklin.Controls.Add(Me.gd__clstasklin)
        Me.tp__clstasklin.Location = New System.Drawing.Point(4, 4)
        Me.tp__clstasklin.Name = "tp__clstasklin"
        Me.tp__clstasklin.Size = New System.Drawing.Size(915, 72)
        Me.tp__clstasklin.TabIndex = 0
        Me.tp__clstasklin.Text = "clstasklins"
        '
        'gd__clstasklin
        '
        Me.gd__clstasklin.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clstasklin.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clstasklin.ColumnListName = ""
        Me.gd__clstasklin.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clstasklin.Deletable = True
        Me.gd__clstasklin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clstasklin.Editable = True
        Me.gd__clstasklin.Hierarchical = True
        Me.gd__clstasklin.Location = New System.Drawing.Point(0, 0)
        Me.gd__clstasklin.Name = "gd__clstasklin"
        Me.gd__clstasklin.RecordNavigator = True
        Me.gd__clstasklin.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clstasklin.Size = New System.Drawing.Size(915, 72)
        Me.gd__clstasklin.TabIndex = 35
        Me.gd__clstasklin.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'tp__clsDnBin
        '
        Me.tp__clsDnBin.AutoScroll = True
        Me.tp__clsDnBin.Controls.Add(Me.gd__clsDnBin)
        Me.tp__clsDnBin.Location = New System.Drawing.Point(4, 4)
        Me.tp__clsDnBin.Name = "tp__clsDnBin"
        Me.tp__clsDnBin.Size = New System.Drawing.Size(915, 72)
        Me.tp__clsDnBin.TabIndex = 0
        Me.tp__clsDnBin.Text = "clsDnBins"
        '
        'gd__clsDnBin
        '
        Me.gd__clsDnBin.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsDnBin.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsDnBin.ColumnListName = ""
        Me.gd__clsDnBin.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsDnBin.Deletable = True
        Me.gd__clsDnBin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsDnBin.Editable = True
        Me.gd__clsDnBin.Hierarchical = True
        Me.gd__clsDnBin.Location = New System.Drawing.Point(0, 0)
        Me.gd__clsDnBin.Name = "gd__clsDnBin"
        Me.gd__clsDnBin.RecordNavigator = True
        Me.gd__clsDnBin.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsDnBin.Size = New System.Drawing.Size(915, 72)
        Me.gd__clsDnBin.TabIndex = 36
        Me.gd__clsDnBin.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'tabGrid
        '
        Me.tabGrid.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabGrid.Controls.Add(Me.tp__clsdnlin)
        Me.tabGrid.Controls.Add(Me.tp__clstasklin)
        Me.tabGrid.Controls.Add(Me.tp__clsDnBin)
        Me.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrid.Location = New System.Drawing.Point(0, 333)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.SelectedIndex = 0
        Me.tabGrid.Size = New System.Drawing.Size(923, 111)
        Me.tabGrid.TabIndex = 33
        '
        'frmclsdnhdrBase__
        '
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(923, 444)
        Me.Controls.Add(Me.tabGrid)
        Me.Controls.Add(Me.splMain)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmclsdnhdrBase__"
        Me.Text = "2587"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.CB, 0)
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.Controls.SetChildIndex(Me.splMain, 0)
        Me.Controls.SetChildIndex(Me.tabGrid, 0)
        Me.Controls.SetChildIndex(Me.CQ, 0)
        Me.Controls.SetChildIndex(Me.chkIsDirty, 0)
        CType(Me.ErrorPrvd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.tp__clsdnlin.ResumeLayout(False)
        CType(Me.gd__clsdnlin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp__clstasklin.ResumeLayout(False)
        CType(Me.gd__clstasklin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp__clsDnBin.ResumeLayout(False)
        CType(Me.gd__clsDnBin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabGrid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clsdnhdr = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtdc_code, "Text", objBO, "dc_code")
            BindField(Me.txtdn_no, "Text", objBO, "dn_no")
            BindField(Me.txtsony_bch_no, "Text", objBO, "sony_bch_no")
            BindField(Me.cbodoc_type, "SelectedValue", objBO, "doc_type")
            BindField(Me.dtpimp_dtime, "Text", objBO, "imp_dtime")
            BindField(Me.txtcity_to, "Text", objBO, "city_to")
            BindField(Me.txtdeal_to, "Text", objBO, "deal_to")
            BindField(Me.txtdeal_name, "Text", objBO, "deal_name")
            BindField(Me.txtdeal_person, "Text", objBO, "deal_person")
            BindField(Me.txtdeal_tel, "Text", objBO, "deal_tel")
            BindField(Me.txtunloading_address, "Text", objBO, "unloading_address")
            BindField(Me.cbostatus_code, "SelectedValue", objBO, "status_code")
            BindField(Me.txtopt_by, "Text", objBO, "opt_by")
            BindField(Me.dtpopt_dtime, "Text", objBO, "opt_dtime")
            BindField(Me.dtpstart_dtime, "Text", objBO, "start_dtime")
            BindField(Me.dtpend_dtime, "Text", objBO, "end_dtime")
            BindField(Me.txtremark, "Text", objBO, "remark")
            CType(Me.gd__clsdnlin, IGrid).DataSource = objBO.clsdnlins
            CType(Me.gd__clstasklin, IGrid).DataSource = objBO.clstasklins
            CType(Me.gd__clsDnBin, IGrid).DataSource = objBO.clsDnBins
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "DataBind")
        End Try
    End Sub

    Protected Overrides Sub UpdateControlEditStatus()
    	Me.FormatControlEditStatus()
    	Me.SetChildGridEditMode(Me.gd__clsdnlin)
    	Me.SetChildGridEditMode(Me.gd__clstasklin)
    	Me.SetChildGridEditMode(Me.gd__clsDnBin)
    End Sub
    
    Public Overrides Sub Format()
    	try
        	MyBase.Format()
        	MyBase.FormatControl(txtdc_code, "dc_code", lbldc_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtdn_no, "dn_no", lbldn_no, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtsony_bch_no, "sony_bch_no", lblsony_bch_no, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(cbodoc_type, "doc_type", lbldoc_type, AddressOf mControlHelper.GeneralControlFormatter, AddressOf mControlHelper.ComboListBoxLoader, AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(dtpimp_dtime, "imp_dtime", lblimp_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(txtcity_to, "city_to", lblcity_to, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtdeal_to, "deal_to", lbldeal_to, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtdeal_name, "deal_name", lbldeal_name, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtdeal_person, "deal_person", lbldeal_person, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtdeal_tel, "deal_tel", lbldeal_tel, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtunloading_address, "unloading_address", lblunloading_address, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(cbostatus_code, "status_code", lblstatus_code, AddressOf mControlHelper.GeneralControlFormatter, AddressOf mControlHelper.ComboListBoxLoader, AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(txtopt_by, "opt_by", lblopt_by, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(dtpstart_dtime, "start_dtime", lblstart_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(dtpend_dtime, "end_dtime", lblend_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(txtremark, "remark", lblremark, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
    		Me.tp__clsdnlin.Text = mobjapp.GetLayout.CXObjectLays(GetType(clsdnlin).Name).ColCaptionText
        	CType(Me.gd__clsdnlin, IGrid).FormatGrid()
    		Me.tp__clstasklin.Text = mobjapp.GetLayout.CXObjectLays(GetType(clstasklin).Name).ColCaptionText
        	CType(Me.gd__clstasklin, IGrid).FormatGrid()
    		Me.tp__clsDnBin.Text = mobjapp.GetLayout.CXObjectLays(GetType(clsDnBin).Name).ColCaptionText
        	CType(Me.gd__clsDnBin, IGrid).FormatGrid()
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
    	CType(Current, clsdnhdr).Loadclsdnlins(blnReset)
    	CType(Current, clsdnhdr).Loadclstasklins(blnReset)
    	CType(Current, clsdnhdr).LoadclsDnBins(blnReset)
	End Sub
		
    Private Sub frmclsdnhdr_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
                    .ButtonEnabled(BK_NEW) = UserRightMgr.GetRightNoDC(Rights.DNHDRNEW)
                    .ButtonEnabled(BK_EDIT) = UserRightMgr.GetRightNoDC(Rights.DNHDREDIT)
                    .ButtonEnabled(BK_DELETE) = UserRightMgr.GetRightNoDC(Rights.DNHDRREMOVE)
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
#Region " user control envent "
    Private Sub BtnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFinish.Click
        Try
            Dim RetCode As String = ""
            Dim RetMsg As String = ""
            CloseBill.CloseSingleDN("SHA", Me.txtdn_no.Text, RetCode, RetMsg)
        Catch ex As Exception
        End Try
        Me.RefreshData()
    End Sub

    Private Sub BtnOptimization_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOptimization.Click
        Try
            Dim RetCode As String = ""
            Dim RetMsg As String = ""
            Optimization.OptimizationBySingleDN("SHA", Me.txtdn_no.Text, RetCode, RetMsg)
        Catch ex As Exception
        End Try
        Me.RefreshData()
    End Sub
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
