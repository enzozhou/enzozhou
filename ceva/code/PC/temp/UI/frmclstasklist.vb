Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclstasklistBase__
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
        Protected Friend WithEvents txttask_id As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbltask_id As System.Windows.Forms.Label
    Protected Friend WithEvents txtbch_no As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblbch_no As System.Windows.Forms.Label
    Protected Friend WithEvents txtdn_no As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldn_no As System.Windows.Forms.Label
    Protected Friend WithEvents txtassigned_opt As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblassigned_opt As System.Windows.Forms.Label
    Protected Friend WithEvents txtbin_area As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblbin_area As System.Windows.Forms.Label
    Protected Friend WithEvents txtbin_code As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblbin_code As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_by As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_by As System.Windows.Forms.Label
    Protected Friend WithEvents dtpopt_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblopt_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents dtpstart_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblstart_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents dtpend_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblend_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_timestamp As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_timestamp As System.Windows.Forms.Label
    Protected Friend WithEvents txtdc_code As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldc_code As System.Windows.Forms.Label
    Protected Friend WithEvents cbostatus_code As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lblstatus_code As System.Windows.Forms.Label
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txttask_id = New System.Windows.Forms.TextBox()
        Me.lbltask_id = New System.Windows.Forms.Label()
        Me.txtbch_no = New System.Windows.Forms.TextBox()
        Me.lblbch_no = New System.Windows.Forms.Label()
        Me.txtdn_no = New System.Windows.Forms.TextBox()
        Me.lbldn_no = New System.Windows.Forms.Label()
        Me.txtassigned_opt = New System.Windows.Forms.TextBox()
        Me.lblassigned_opt = New System.Windows.Forms.Label()
        Me.txtbin_area = New System.Windows.Forms.TextBox()
        Me.lblbin_area = New System.Windows.Forms.Label()
        Me.txtbin_code = New System.Windows.Forms.TextBox()
        Me.lblbin_code = New System.Windows.Forms.Label()
        Me.txtopt_by = New System.Windows.Forms.TextBox()
        Me.lblopt_by = New System.Windows.Forms.Label()
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblopt_dtime = New System.Windows.Forms.Label()
        Me.dtpstart_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblstart_dtime = New System.Windows.Forms.Label()
        Me.dtpend_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblend_dtime = New System.Windows.Forms.Label()
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox()
        Me.lblopt_timestamp = New System.Windows.Forms.Label()
        Me.txtdc_code = New System.Windows.Forms.TextBox()
        Me.lbldc_code = New System.Windows.Forms.Label()
        Me.cbostatus_code = New System.Windows.Forms.ComboBox()
        Me.lblstatus_code = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()


        Me.SuspendLayout()
        'txttask_id
        '
        Me.txttask_id.Location = New System.Drawing.Point(138, 10)
        Me.txttask_id.Name = "txttask_id"
        Me.txttask_id.Size = New System.Drawing.Size(225, 21)
        Me.txttask_id.TabIndex = 3
        'lbltask_id
        '
        Me.lbltask_id.BackColor = System.Drawing.Color.Transparent
        Me.lbltask_id.Location = New System.Drawing.Point(10, 12)
        Me.lbltask_id.Name = "lbltask_id"
        Me.lbltask_id.Size = New System.Drawing.Size(121, 17)
        Me.lbltask_id.TabIndex = 4
        Me.lbltask_id.Text = "task_id"
        'txtbch_no
        '
        Me.txtbch_no.Location = New System.Drawing.Point(138, 32)
        Me.txtbch_no.Name = "txtbch_no"
        Me.txtbch_no.Size = New System.Drawing.Size(225, 21)
        Me.txtbch_no.TabIndex = 5
        'lblbch_no
        '
        Me.lblbch_no.BackColor = System.Drawing.Color.Transparent
        Me.lblbch_no.Location = New System.Drawing.Point(10, 34)
        Me.lblbch_no.Name = "lblbch_no"
        Me.lblbch_no.Size = New System.Drawing.Size(121, 17)
        Me.lblbch_no.TabIndex = 6
        Me.lblbch_no.Text = "bch_no"
        'txtdn_no
        '
        Me.txtdn_no.Location = New System.Drawing.Point(138, 53)
        Me.txtdn_no.Name = "txtdn_no"
        Me.txtdn_no.Size = New System.Drawing.Size(225, 21)
        Me.txtdn_no.TabIndex = 7
        'lbldn_no
        '
        Me.lbldn_no.BackColor = System.Drawing.Color.Transparent
        Me.lbldn_no.Location = New System.Drawing.Point(10, 56)
        Me.lbldn_no.Name = "lbldn_no"
        Me.lbldn_no.Size = New System.Drawing.Size(121, 17)
        Me.lbldn_no.TabIndex = 8
        Me.lbldn_no.Text = "dn_no"
        'txtassigned_opt
        '
        Me.txtassigned_opt.Location = New System.Drawing.Point(138, 75)
        Me.txtassigned_opt.Name = "txtassigned_opt"
        Me.txtassigned_opt.Size = New System.Drawing.Size(225, 21)
        Me.txtassigned_opt.TabIndex = 9
        'lblassigned_opt
        '
        Me.lblassigned_opt.BackColor = System.Drawing.Color.Transparent
        Me.lblassigned_opt.Location = New System.Drawing.Point(10, 77)
        Me.lblassigned_opt.Name = "lblassigned_opt"
        Me.lblassigned_opt.Size = New System.Drawing.Size(121, 17)
        Me.lblassigned_opt.TabIndex = 10
        Me.lblassigned_opt.Text = "assigned_opt"
        'txtbin_area
        '
        Me.txtbin_area.Location = New System.Drawing.Point(138, 97)
        Me.txtbin_area.Name = "txtbin_area"
        Me.txtbin_area.Size = New System.Drawing.Size(225, 21)
        Me.txtbin_area.TabIndex = 11
        'lblbin_area
        '
        Me.lblbin_area.BackColor = System.Drawing.Color.Transparent
        Me.lblbin_area.Location = New System.Drawing.Point(10, 99)
        Me.lblbin_area.Name = "lblbin_area"
        Me.lblbin_area.Size = New System.Drawing.Size(121, 17)
        Me.lblbin_area.TabIndex = 12
        Me.lblbin_area.Text = "bin_area"
        'txtbin_code
        '
        Me.txtbin_code.Location = New System.Drawing.Point(138, 118)
        Me.txtbin_code.Name = "txtbin_code"
        Me.txtbin_code.Size = New System.Drawing.Size(225, 21)
        Me.txtbin_code.TabIndex = 13
        'lblbin_code
        '
        Me.lblbin_code.BackColor = System.Drawing.Color.Transparent
        Me.lblbin_code.Location = New System.Drawing.Point(10, 121)
        Me.lblbin_code.Name = "lblbin_code"
        Me.lblbin_code.Size = New System.Drawing.Size(121, 17)
        Me.lblbin_code.TabIndex = 14
        Me.lblbin_code.Text = "bin_code"
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(138, 140)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(225, 21)
        Me.txtopt_by.TabIndex = 15
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(10, 142)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_by.TabIndex = 16
        Me.lblopt_by.Text = "opt_by"
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(138, 162)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.TabIndex = 17
        Me.dtpopt_dtime.Format = DateTimePickerFormat.Long
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(10, 164)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_dtime.TabIndex = 18
        Me.lblopt_dtime.Text = "opt_dtime"
        'dtpstart_dtime
        '
        Me.dtpstart_dtime.Location = New System.Drawing.Point(138, 183)
        Me.dtpstart_dtime.Name = "dtpstart_dtime"
        Me.dtpstart_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpstart_dtime.ShowCheckBox = True
        Me.dtpstart_dtime.TabIndex = 19
        Me.dtpstart_dtime.Format = DateTimePickerFormat.Long
        'lblstart_dtime
        '
        Me.lblstart_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblstart_dtime.Location = New System.Drawing.Point(10, 186)
        Me.lblstart_dtime.Name = "lblstart_dtime"
        Me.lblstart_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblstart_dtime.TabIndex = 20
        Me.lblstart_dtime.Text = "start_dtime"
        'dtpend_dtime
        '
        Me.dtpend_dtime.Location = New System.Drawing.Point(138, 205)
        Me.dtpend_dtime.Name = "dtpend_dtime"
        Me.dtpend_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpend_dtime.ShowCheckBox = True
        Me.dtpend_dtime.TabIndex = 21
        Me.dtpend_dtime.Format = DateTimePickerFormat.Long
        'lblend_dtime
        '
        Me.lblend_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblend_dtime.Location = New System.Drawing.Point(10, 207)
        Me.lblend_dtime.Name = "lblend_dtime"
        Me.lblend_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblend_dtime.TabIndex = 22
        Me.lblend_dtime.Text = "end_dtime"
        'txtopt_timestamp
        '
        Me.txtopt_timestamp.Location = New System.Drawing.Point(2, 2)
        Me.txtopt_timestamp.Name = "txtopt_timestamp"
        Me.txtopt_timestamp.Size = New System.Drawing.Size(150, 23)
        Me.txtopt_timestamp.TabIndex = 1
        'lblopt_timestamp
        '
        Me.lblopt_timestamp.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_timestamp.Location = New System.Drawing.Point(2, 2)
        Me.lblopt_timestamp.Name = "lblopt_timestamp"
        Me.lblopt_timestamp.Size = New System.Drawing.Size(150, 23)
        Me.lblopt_timestamp.TabIndex = 2
        Me.lblopt_timestamp.Text = "opt_timestamp"
        'txtdc_code
        '
        Me.txtdc_code.Location = New System.Drawing.Point(138, 227)
        Me.txtdc_code.Name = "txtdc_code"
        Me.txtdc_code.Size = New System.Drawing.Size(225, 21)
        Me.txtdc_code.TabIndex = 23
        'lbldc_code
        '
        Me.lbldc_code.BackColor = System.Drawing.Color.Transparent
        Me.lbldc_code.Location = New System.Drawing.Point(10, 229)
        Me.lbldc_code.Name = "lbldc_code"
        Me.lbldc_code.Size = New System.Drawing.Size(121, 17)
        Me.lbldc_code.TabIndex = 24
        Me.lbldc_code.Text = "dc_code"
        'cbostatus_code 
        '
        Me.cbostatus_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbostatus_code.Location = New System.Drawing.Point(138, 248)
        Me.cbostatus_code.Name = "cbostatus_code"
        Me.cbostatus_code.Size = New System.Drawing.Size(225, 21)
        Me.cbostatus_code.TabIndex = 25
        'lblstatus_code
        '
        Me.lblstatus_code.BackColor = System.Drawing.Color.Transparent
        Me.lblstatus_code.Location = New System.Drawing.Point(10, 251)
        Me.lblstatus_code.Name = "lblstatus_code"
        Me.lblstatus_code.Size = New System.Drawing.Size(121, 17)
        Me.lblstatus_code.TabIndex = 26
        Me.lblstatus_code.Text = "status_code"
        'pnlMain
        '
        Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.txttask_id, Me.lbltask_id, Me.txtbch_no, Me.lblbch_no, Me.txtdn_no, Me.lbldn_no, Me.txtassigned_opt, Me.lblassigned_opt, Me.txtbin_area, Me.lblbin_area, Me.txtbin_code, Me.lblbin_code, Me.txtopt_by, Me.lblopt_by, Me.dtpopt_dtime, Me.lblopt_dtime, Me.dtpstart_dtime, Me.lblstart_dtime, Me.dtpend_dtime, Me.lblend_dtime, Me.txtopt_timestamp, Me.lblopt_timestamp, Me.txtdc_code, Me.lbldc_code, Me.cbostatus_code, Me.lblstatus_code})
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(392, 264)
        Me.pnlMain.TabIndex = 0
        Me.pnlMain.TabStop = False
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill

        '
        'frmclstasklist
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.AutoScroll = True
        Me.WindowState = FormWindowState.Maximized
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlMain})
        Me.Font = New System.Drawing.Font("Î¢ÈíÑÅºÚ", 9.0, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "clstasklist"
        Me.Text = "2704"

        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clstasklist = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txttask_id, "Text", objBO, "task_id")
            BindField(Me.txtbch_no, "Text", objBO, "bch_no")
            BindField(Me.txtdn_no, "Text", objBO, "dn_no")
            BindField(Me.txtassigned_opt, "Text", objBO, "assigned_opt")
            BindField(Me.txtbin_area, "Text", objBO, "bin_area")
            BindField(Me.txtbin_code, "Text", objBO, "bin_code")
            BindField(Me.txtopt_by, "Text", objBO, "opt_by")
            BindField(Me.dtpopt_dtime, "Text", objBO, "opt_dtime")
            BindField(Me.dtpstart_dtime, "Text", objBO, "start_dtime")
            BindField(Me.dtpend_dtime, "Text", objBO, "end_dtime")
            BindField(Me.txtdc_code, "Text", objBO, "dc_code")
            BindField(Me.cbostatus_code, "SelectedValue", objBO, "status_code")
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "DataBind")
        End Try
    End Sub

    Protected Overrides Sub UpdateControlEditStatus()
    	Me.FormatControlEditStatus()
    End Sub
    
    Public Overrides Sub Format()
    	try
        	MyBase.Format()
        	MyBase.FormatControl(txttask_id, "task_id", lbltask_id, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtbch_no, "bch_no", lblbch_no, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtdn_no, "dn_no", lbldn_no, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtassigned_opt, "assigned_opt", lblassigned_opt, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtbin_area, "bin_area", lblbin_area, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtbin_code, "bin_code", lblbin_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtopt_by, "opt_by", lblopt_by, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(dtpstart_dtime, "start_dtime", lblstart_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(dtpend_dtime, "end_dtime", lblend_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(txtdc_code, "dc_code", lbldc_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(cbostatus_code, "status_code", lblstatus_code, AddressOf mControlHelper.GeneralControlFormatter, AddressOf mControlHelper.ComboListBoxLoader, AddressOf mControlHelper.EnabledSupporter)
        Me.LoadLayout()
        Catch ThisException As Exception
        	ErrorMsg(ThisException, Me.GetType, "Format")
        End Try        
    End Sub
    
    
    Protected Overrides Sub LoadChildrenData(Optional ByVal blnReset As Boolean = False)
	End Sub
		
    Private Sub frmclstasklist_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
