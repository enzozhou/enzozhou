Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclsdnhdrBase__
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
    Protected Friend WithEvents tp__clsDnBin As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsDnBin As YTUI.DataGrid
    Protected Friend WithEvents tabGrid As System.Windows.Forms.TabControl

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.splMain = New System.Windows.Forms.Splitter()
        Me.txtdc_code = New System.Windows.Forms.TextBox()
        Me.lbldc_code = New System.Windows.Forms.Label()
        Me.txtdn_no = New System.Windows.Forms.TextBox()
        Me.lbldn_no = New System.Windows.Forms.Label()
        Me.txtsony_bch_no = New System.Windows.Forms.TextBox()
        Me.lblsony_bch_no = New System.Windows.Forms.Label()
        Me.cbodoc_type = New System.Windows.Forms.ComboBox()
        Me.lbldoc_type = New System.Windows.Forms.Label()
        Me.dtpimp_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblimp_dtime = New System.Windows.Forms.Label()
        Me.txtcity_to = New System.Windows.Forms.TextBox()
        Me.lblcity_to = New System.Windows.Forms.Label()
        Me.txtdeal_to = New System.Windows.Forms.TextBox()
        Me.lbldeal_to = New System.Windows.Forms.Label()
        Me.txtdeal_name = New System.Windows.Forms.TextBox()
        Me.lbldeal_name = New System.Windows.Forms.Label()
        Me.txtdeal_person = New System.Windows.Forms.TextBox()
        Me.lbldeal_person = New System.Windows.Forms.Label()
        Me.txtdeal_tel = New System.Windows.Forms.TextBox()
        Me.lbldeal_tel = New System.Windows.Forms.Label()
        Me.txtunloading_address = New System.Windows.Forms.TextBox()
        Me.lblunloading_address = New System.Windows.Forms.Label()
        Me.cbostatus_code = New System.Windows.Forms.ComboBox()
        Me.lblstatus_code = New System.Windows.Forms.Label()
        Me.txtopt_by = New System.Windows.Forms.TextBox()
        Me.lblopt_by = New System.Windows.Forms.Label()
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblopt_dtime = New System.Windows.Forms.Label()
        Me.dtpstart_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblstart_dtime = New System.Windows.Forms.Label()
        Me.dtpend_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblend_dtime = New System.Windows.Forms.Label()
        Me.txtremark = New System.Windows.Forms.TextBox()
        Me.lblremark = New System.Windows.Forms.Label()
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox()
        Me.lblopt_timestamp = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.gd__clsdnlin = New YTUI.DataGrid()
        Me.tp__clsdnlin = New System.Windows.Forms.TabPage()
        Me.gd__clstasklin = New YTUI.DataGrid()
        Me.tp__clstasklin = New System.Windows.Forms.TabPage()
        Me.gd__clsDnBin = New YTUI.DataGrid()
        Me.tp__clsDnBin = New System.Windows.Forms.TabPage()
        Me.tabGrid = New System.Windows.Forms.TabControl()

        CType(Me.gd__clsdnlin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gd__clstasklin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gd__clsDnBin, System.ComponentModel.ISupportInitialize).BeginInit()

        Me.SuspendLayout()
        'splMain
        '
        Me.splMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.splMain.Location = New System.Drawing.Point(0, 264)
        Me.splMain.Name = "splMain"
        Me.splMain.Size = New System.Drawing.Size(480, 8)
        Me.splMain.TabStop = False
        'txtdc_code
        '
        Me.txtdc_code.Location = New System.Drawing.Point(138, 10)
        Me.txtdc_code.Name = "txtdc_code"
        Me.txtdc_code.Size = New System.Drawing.Size(225, 21)
        Me.txtdc_code.TabIndex = 2
        'lbldc_code
        '
        Me.lbldc_code.BackColor = System.Drawing.Color.Transparent
        Me.lbldc_code.Location = New System.Drawing.Point(10, 12)
        Me.lbldc_code.Name = "lbldc_code"
        Me.lbldc_code.Size = New System.Drawing.Size(121, 17)
        Me.lbldc_code.TabIndex = 1
        Me.lbldc_code.Text = "dc_code"
        'txtdn_no
        '
        Me.txtdn_no.Location = New System.Drawing.Point(138, 32)
        Me.txtdn_no.Name = "txtdn_no"
        Me.txtdn_no.Size = New System.Drawing.Size(225, 21)
        Me.txtdn_no.TabIndex = 4
        'lbldn_no
        '
        Me.lbldn_no.BackColor = System.Drawing.Color.Transparent
        Me.lbldn_no.Location = New System.Drawing.Point(10, 34)
        Me.lbldn_no.Name = "lbldn_no"
        Me.lbldn_no.Size = New System.Drawing.Size(121, 17)
        Me.lbldn_no.TabIndex = 3
        Me.lbldn_no.Text = "dn_no"
        'txtsony_bch_no
        '
        Me.txtsony_bch_no.Location = New System.Drawing.Point(138, 53)
        Me.txtsony_bch_no.Name = "txtsony_bch_no"
        Me.txtsony_bch_no.Size = New System.Drawing.Size(225, 21)
        Me.txtsony_bch_no.TabIndex = 6
        'lblsony_bch_no
        '
        Me.lblsony_bch_no.BackColor = System.Drawing.Color.Transparent
        Me.lblsony_bch_no.Location = New System.Drawing.Point(10, 56)
        Me.lblsony_bch_no.Name = "lblsony_bch_no"
        Me.lblsony_bch_no.Size = New System.Drawing.Size(121, 17)
        Me.lblsony_bch_no.TabIndex = 5
        Me.lblsony_bch_no.Text = "sony_bch_no"
        'cbodoc_type 
        '
        Me.cbodoc_type.Location = New System.Drawing.Point(138, 75)
        Me.cbodoc_type.Name = "cbodoc_type"
        Me.cbodoc_type.Size = New System.Drawing.Size(225, 21)
        Me.cbodoc_type.TabIndex = 8
        'lbldoc_type
        '
        Me.lbldoc_type.BackColor = System.Drawing.Color.Transparent
        Me.lbldoc_type.Location = New System.Drawing.Point(10, 77)
        Me.lbldoc_type.Name = "lbldoc_type"
        Me.lbldoc_type.Size = New System.Drawing.Size(121, 17)
        Me.lbldoc_type.TabIndex = 7
        Me.lbldoc_type.Text = "doc_type"
        'dtpimp_dtime
        '
        Me.dtpimp_dtime.Location = New System.Drawing.Point(138, 97)
        Me.dtpimp_dtime.Name = "dtpimp_dtime"
        Me.dtpimp_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpimp_dtime.ShowCheckBox = True
        Me.dtpimp_dtime.TabIndex = 10
        Me.dtpimp_dtime.Format = DateTimePickerFormat.Long
        'lblimp_dtime
        '
        Me.lblimp_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblimp_dtime.Location = New System.Drawing.Point(10, 99)
        Me.lblimp_dtime.Name = "lblimp_dtime"
        Me.lblimp_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblimp_dtime.TabIndex = 9
        Me.lblimp_dtime.Text = "imp_dtime"
        'txtcity_to
        '
        Me.txtcity_to.Location = New System.Drawing.Point(138, 118)
        Me.txtcity_to.Name = "txtcity_to"
        Me.txtcity_to.Size = New System.Drawing.Size(225, 21)
        Me.txtcity_to.TabIndex = 12
        'lblcity_to
        '
        Me.lblcity_to.BackColor = System.Drawing.Color.Transparent
        Me.lblcity_to.Location = New System.Drawing.Point(10, 121)
        Me.lblcity_to.Name = "lblcity_to"
        Me.lblcity_to.Size = New System.Drawing.Size(121, 17)
        Me.lblcity_to.TabIndex = 11
        Me.lblcity_to.Text = "city_to"
        'txtdeal_to
        '
        Me.txtdeal_to.Location = New System.Drawing.Point(138, 140)
        Me.txtdeal_to.Name = "txtdeal_to"
        Me.txtdeal_to.Size = New System.Drawing.Size(225, 21)
        Me.txtdeal_to.TabIndex = 14
        'lbldeal_to
        '
        Me.lbldeal_to.BackColor = System.Drawing.Color.Transparent
        Me.lbldeal_to.Location = New System.Drawing.Point(10, 142)
        Me.lbldeal_to.Name = "lbldeal_to"
        Me.lbldeal_to.Size = New System.Drawing.Size(121, 17)
        Me.lbldeal_to.TabIndex = 13
        Me.lbldeal_to.Text = "deal_to"
        'txtdeal_name
        '
        Me.txtdeal_name.Location = New System.Drawing.Point(138, 162)
        Me.txtdeal_name.Name = "txtdeal_name"
        Me.txtdeal_name.Size = New System.Drawing.Size(225, 21)
        Me.txtdeal_name.TabIndex = 16
        'lbldeal_name
        '
        Me.lbldeal_name.BackColor = System.Drawing.Color.Transparent
        Me.lbldeal_name.Location = New System.Drawing.Point(10, 164)
        Me.lbldeal_name.Name = "lbldeal_name"
        Me.lbldeal_name.Size = New System.Drawing.Size(121, 17)
        Me.lbldeal_name.TabIndex = 15
        Me.lbldeal_name.Text = "deal_name"
        'txtdeal_person
        '
        Me.txtdeal_person.Location = New System.Drawing.Point(138, 183)
        Me.txtdeal_person.Name = "txtdeal_person"
        Me.txtdeal_person.Size = New System.Drawing.Size(225, 21)
        Me.txtdeal_person.TabIndex = 18
        'lbldeal_person
        '
        Me.lbldeal_person.BackColor = System.Drawing.Color.Transparent
        Me.lbldeal_person.Location = New System.Drawing.Point(10, 186)
        Me.lbldeal_person.Name = "lbldeal_person"
        Me.lbldeal_person.Size = New System.Drawing.Size(121, 17)
        Me.lbldeal_person.TabIndex = 17
        Me.lbldeal_person.Text = "deal_person"
        'txtdeal_tel
        '
        Me.txtdeal_tel.Location = New System.Drawing.Point(138, 205)
        Me.txtdeal_tel.Name = "txtdeal_tel"
        Me.txtdeal_tel.Size = New System.Drawing.Size(225, 21)
        Me.txtdeal_tel.TabIndex = 20
        'lbldeal_tel
        '
        Me.lbldeal_tel.BackColor = System.Drawing.Color.Transparent
        Me.lbldeal_tel.Location = New System.Drawing.Point(10, 207)
        Me.lbldeal_tel.Name = "lbldeal_tel"
        Me.lbldeal_tel.Size = New System.Drawing.Size(121, 17)
        Me.lbldeal_tel.TabIndex = 19
        Me.lbldeal_tel.Text = "deal_tel"
        'txtunloading_address
        '
        Me.txtunloading_address.Location = New System.Drawing.Point(138, 227)
        Me.txtunloading_address.Name = "txtunloading_address"
        Me.txtunloading_address.Size = New System.Drawing.Size(225, 21)
        Me.txtunloading_address.TabIndex = 22
        'lblunloading_address
        '
        Me.lblunloading_address.BackColor = System.Drawing.Color.Transparent
        Me.lblunloading_address.Location = New System.Drawing.Point(10, 229)
        Me.lblunloading_address.Name = "lblunloading_address"
        Me.lblunloading_address.Size = New System.Drawing.Size(121, 17)
        Me.lblunloading_address.TabIndex = 21
        Me.lblunloading_address.Text = "unloading_address"
        'cbostatus_code 
        '
        Me.cbostatus_code.Location = New System.Drawing.Point(138, 248)
        Me.cbostatus_code.Name = "cbostatus_code"
        Me.cbostatus_code.Size = New System.Drawing.Size(225, 21)
        Me.cbostatus_code.TabIndex = 24
        'lblstatus_code
        '
        Me.lblstatus_code.BackColor = System.Drawing.Color.Transparent
        Me.lblstatus_code.Location = New System.Drawing.Point(10, 251)
        Me.lblstatus_code.Name = "lblstatus_code"
        Me.lblstatus_code.Size = New System.Drawing.Size(121, 17)
        Me.lblstatus_code.TabIndex = 23
        Me.lblstatus_code.Text = "status_code"
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(138, 270)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(225, 21)
        Me.txtopt_by.TabIndex = 26
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(10, 272)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_by.TabIndex = 25
        Me.lblopt_by.Text = "opt_by"
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(138, 292)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.TabIndex = 28
        Me.dtpopt_dtime.Format = DateTimePickerFormat.Long
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(10, 294)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_dtime.TabIndex = 27
        Me.lblopt_dtime.Text = "opt_dtime"
        'dtpstart_dtime
        '
        Me.dtpstart_dtime.Location = New System.Drawing.Point(138, 313)
        Me.dtpstart_dtime.Name = "dtpstart_dtime"
        Me.dtpstart_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpstart_dtime.ShowCheckBox = True
        Me.dtpstart_dtime.TabIndex = 30
        Me.dtpstart_dtime.Format = DateTimePickerFormat.Long
        'lblstart_dtime
        '
        Me.lblstart_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblstart_dtime.Location = New System.Drawing.Point(10, 316)
        Me.lblstart_dtime.Name = "lblstart_dtime"
        Me.lblstart_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblstart_dtime.TabIndex = 29
        Me.lblstart_dtime.Text = "start_dtime"
        'dtpend_dtime
        '
        Me.dtpend_dtime.Location = New System.Drawing.Point(138, 335)
        Me.dtpend_dtime.Name = "dtpend_dtime"
        Me.dtpend_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpend_dtime.ShowCheckBox = True
        Me.dtpend_dtime.TabIndex = 32
        Me.dtpend_dtime.Format = DateTimePickerFormat.Long
        'lblend_dtime
        '
        Me.lblend_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblend_dtime.Location = New System.Drawing.Point(10, 337)
        Me.lblend_dtime.Name = "lblend_dtime"
        Me.lblend_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblend_dtime.TabIndex = 31
        Me.lblend_dtime.Text = "end_dtime"
        'txtremark
        '
        Me.txtremark.Location = New System.Drawing.Point(138, 357)
        Me.txtremark.Name = "txtremark"
        Me.txtremark.Size = New System.Drawing.Size(225, 21)
        Me.txtremark.TabIndex = 34
        'lblremark
        '
        Me.lblremark.BackColor = System.Drawing.Color.Transparent
        Me.lblremark.Location = New System.Drawing.Point(10, 359)
        Me.lblremark.Name = "lblremark"
        Me.lblremark.Size = New System.Drawing.Size(121, 17)
        Me.lblremark.TabIndex = 33
        Me.lblremark.Text = "remark"
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
        Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtdc_code, Me.lbldc_code, Me.txtdn_no, Me.lbldn_no, Me.txtsony_bch_no, Me.lblsony_bch_no, Me.cbodoc_type, Me.lbldoc_type, Me.dtpimp_dtime, Me.lblimp_dtime, Me.txtcity_to, Me.lblcity_to, Me.txtdeal_to, Me.lbldeal_to, Me.txtdeal_name, Me.lbldeal_name, Me.txtdeal_person, Me.lbldeal_person, Me.txtdeal_tel, Me.lbldeal_tel, Me.txtunloading_address, Me.lblunloading_address, Me.cbostatus_code, Me.lblstatus_code, Me.txtopt_by, Me.lblopt_by, Me.dtpopt_dtime, Me.lblopt_dtime, Me.dtpstart_dtime, Me.lblstart_dtime, Me.dtpend_dtime, Me.lblend_dtime, Me.txtremark, Me.lblremark, Me.txtopt_timestamp, Me.lblopt_timestamp})
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(392, 264)
        Me.pnlMain.TabIndex = 0
        Me.pnlMain.TabStop = False
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top

        Me.gd__clsdnlin.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsdnlin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsdnlin.Name = "Me.gd__clsdnlin"
        Me.gd__clsdnlin.Size = New System.Drawing.Size(552, 116)
        Me.gd__clsdnlin.TabIndex = 36
        'tp__clsdnlin
        '        
        Me.tp__clsdnlin.Controls.AddRange(New System.Windows.Forms.Control() {Me.gd__clsdnlin})
        Me.tp__clsdnlin.Location = New System.Drawing.Point(0, 0)
        Me.tp__clsdnlin.Name = "tp__clsdnlin"
        Me.tp__clsdnlin.Size = New System.Drawing.Size(392, 264)
        Me.tp__clsdnlin.TabIndex = 0
        Me.tp__clsdnlin.Text = "clsdnlins"
        Me.tp__clsdnlin.AutoScroll = True

        Me.gd__clstasklin.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clstasklin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clstasklin.Name = "Me.gd__clstasklin"
        Me.gd__clstasklin.Size = New System.Drawing.Size(552, 116)
        Me.gd__clstasklin.TabIndex = 37
        'tp__clstasklin
        '        
        Me.tp__clstasklin.Controls.AddRange(New System.Windows.Forms.Control() {Me.gd__clstasklin})
        Me.tp__clstasklin.Location = New System.Drawing.Point(0, 0)
        Me.tp__clstasklin.Name = "tp__clstasklin"
        Me.tp__clstasklin.Size = New System.Drawing.Size(392, 264)
        Me.tp__clstasklin.TabIndex = 0
        Me.tp__clstasklin.Text = "clstasklins"
        Me.tp__clstasklin.AutoScroll = True

        Me.gd__clsDnBin.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsDnBin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsDnBin.Name = "Me.gd__clsDnBin"
        Me.gd__clsDnBin.Size = New System.Drawing.Size(552, 116)
        Me.gd__clsDnBin.TabIndex = 38
        'tp__clsDnBin
        '        
        Me.tp__clsDnBin.Controls.AddRange(New System.Windows.Forms.Control() {Me.gd__clsDnBin})
        Me.tp__clsDnBin.Location = New System.Drawing.Point(0, 0)
        Me.tp__clsDnBin.Name = "tp__clsDnBin"
        Me.tp__clsDnBin.Size = New System.Drawing.Size(392, 264)
        Me.tp__clsDnBin.TabIndex = 0
        Me.tp__clsDnBin.Text = "clsDnBins"
        Me.tp__clsDnBin.AutoScroll = True
        'tabGrid
        '        
        Me.tabGrid.Controls.AddRange(New System.Windows.Forms.Control() {Me.tp__clsdnlin, Me.tp__clstasklin, Me.tp__clsDnBin})
        Me.tabGrid.Location = New System.Drawing.Point(0, 0)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.SelectedIndex = 0
        Me.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrid.Size = New System.Drawing.Size(392, 264)
        Me.tabGrid.TabIndex = 35
		 Me.tabGrid.Alignment = System.Windows.Forms.TabAlignment.Bottom
        '
        'frmclsdnhdr
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.AutoScroll = True
        Me.WindowState = FormWindowState.Maximized
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabGrid, Me.splMain, Me.pnlMain})
        Me.Font = New System.Drawing.Font("Î¢ÈíÑÅºÚ", 9.0, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "clsdnhdr"
        Me.Text = "2587"
        CType(Me.gd__clsdnlin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gd__clstasklin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gd__clsDnBin, System.ComponentModel.ISupportInitialize).EndInit()

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

#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
