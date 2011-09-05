Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclsbchlinBase__
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
        Protected Friend WithEvents txtdc_code As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldc_code As System.Windows.Forms.Label
    Protected Friend WithEvents txtbch_no As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblbch_no As System.Windows.Forms.Label
    Protected Friend WithEvents txtdn_no As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldn_no As System.Windows.Forms.Label
    Protected Friend WithEvents cbostatus_code As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lblstatus_code As System.Windows.Forms.Label
    Protected Friend WithEvents txtlocked As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbllocked As System.Windows.Forms.Label
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
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtdc_code = New System.Windows.Forms.TextBox()
        Me.lbldc_code = New System.Windows.Forms.Label()
        Me.txtbch_no = New System.Windows.Forms.TextBox()
        Me.lblbch_no = New System.Windows.Forms.Label()
        Me.txtdn_no = New System.Windows.Forms.TextBox()
        Me.lbldn_no = New System.Windows.Forms.Label()
        Me.cbostatus_code = New System.Windows.Forms.ComboBox()
        Me.lblstatus_code = New System.Windows.Forms.Label()
        Me.txtlocked = New System.Windows.Forms.TextBox()
        Me.lbllocked = New System.Windows.Forms.Label()
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
        Me.pnlMain = New System.Windows.Forms.Panel()


        Me.SuspendLayout()
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
        'txtbch_no
        '
        Me.txtbch_no.Location = New System.Drawing.Point(138, 32)
        Me.txtbch_no.Name = "txtbch_no"
        Me.txtbch_no.Size = New System.Drawing.Size(225, 21)
        Me.txtbch_no.TabIndex = 4
        'lblbch_no
        '
        Me.lblbch_no.BackColor = System.Drawing.Color.Transparent
        Me.lblbch_no.Location = New System.Drawing.Point(10, 34)
        Me.lblbch_no.Name = "lblbch_no"
        Me.lblbch_no.Size = New System.Drawing.Size(121, 17)
        Me.lblbch_no.TabIndex = 3
        Me.lblbch_no.Text = "bch_no"
        'txtdn_no
        '
        Me.txtdn_no.Location = New System.Drawing.Point(138, 53)
        Me.txtdn_no.Name = "txtdn_no"
        Me.txtdn_no.Size = New System.Drawing.Size(225, 21)
        Me.txtdn_no.TabIndex = 6
        'lbldn_no
        '
        Me.lbldn_no.BackColor = System.Drawing.Color.Transparent
        Me.lbldn_no.Location = New System.Drawing.Point(10, 56)
        Me.lbldn_no.Name = "lbldn_no"
        Me.lbldn_no.Size = New System.Drawing.Size(121, 17)
        Me.lbldn_no.TabIndex = 5
        Me.lbldn_no.Text = "dn_no"
        'cbostatus_code 
        '
        Me.cbostatus_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbostatus_code.Location = New System.Drawing.Point(138, 75)
        Me.cbostatus_code.Name = "cbostatus_code"
        Me.cbostatus_code.Size = New System.Drawing.Size(225, 21)
        Me.cbostatus_code.TabIndex = 8
        'lblstatus_code
        '
        Me.lblstatus_code.BackColor = System.Drawing.Color.Transparent
        Me.lblstatus_code.Location = New System.Drawing.Point(10, 77)
        Me.lblstatus_code.Name = "lblstatus_code"
        Me.lblstatus_code.Size = New System.Drawing.Size(121, 17)
        Me.lblstatus_code.TabIndex = 7
        Me.lblstatus_code.Text = "status_code"
        'txtlocked
        '
        Me.txtlocked.Location = New System.Drawing.Point(138, 97)
        Me.txtlocked.Name = "txtlocked"
        Me.txtlocked.Size = New System.Drawing.Size(225, 21)
        Me.txtlocked.TabIndex = 10
        'lbllocked
        '
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Location = New System.Drawing.Point(10, 99)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(121, 17)
        Me.lbllocked.TabIndex = 9
        Me.lbllocked.Text = "locked"
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(138, 118)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(225, 21)
        Me.txtopt_by.TabIndex = 12
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(10, 121)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_by.TabIndex = 11
        Me.lblopt_by.Text = "opt_by"
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(138, 140)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.TabIndex = 14
        Me.dtpopt_dtime.Format = DateTimePickerFormat.Long
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(10, 142)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_dtime.TabIndex = 13
        Me.lblopt_dtime.Text = "opt_dtime"
        'dtpstart_dtime
        '
        Me.dtpstart_dtime.Location = New System.Drawing.Point(138, 162)
        Me.dtpstart_dtime.Name = "dtpstart_dtime"
        Me.dtpstart_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpstart_dtime.ShowCheckBox = True
        Me.dtpstart_dtime.TabIndex = 16
        Me.dtpstart_dtime.Format = DateTimePickerFormat.Long
        'lblstart_dtime
        '
        Me.lblstart_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblstart_dtime.Location = New System.Drawing.Point(10, 164)
        Me.lblstart_dtime.Name = "lblstart_dtime"
        Me.lblstart_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblstart_dtime.TabIndex = 15
        Me.lblstart_dtime.Text = "start_dtime"
        'dtpend_dtime
        '
        Me.dtpend_dtime.Location = New System.Drawing.Point(138, 183)
        Me.dtpend_dtime.Name = "dtpend_dtime"
        Me.dtpend_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpend_dtime.ShowCheckBox = True
        Me.dtpend_dtime.TabIndex = 18
        Me.dtpend_dtime.Format = DateTimePickerFormat.Long
        'lblend_dtime
        '
        Me.lblend_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblend_dtime.Location = New System.Drawing.Point(10, 186)
        Me.lblend_dtime.Name = "lblend_dtime"
        Me.lblend_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblend_dtime.TabIndex = 17
        Me.lblend_dtime.Text = "end_dtime"
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
        Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtdc_code, Me.lbldc_code, Me.txtbch_no, Me.lblbch_no, Me.txtdn_no, Me.lbldn_no, Me.cbostatus_code, Me.lblstatus_code, Me.txtlocked, Me.lbllocked, Me.txtopt_by, Me.lblopt_by, Me.dtpopt_dtime, Me.lblopt_dtime, Me.dtpstart_dtime, Me.lblstart_dtime, Me.dtpend_dtime, Me.lblend_dtime, Me.txtopt_timestamp, Me.lblopt_timestamp})
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(392, 264)
        Me.pnlMain.TabIndex = 0
        Me.pnlMain.TabStop = False
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill

        '
        'frmclsbchlin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.AutoScroll = True
        Me.WindowState = FormWindowState.Maximized
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlMain})
        Me.Font = New System.Drawing.Font("Î¢ÈíÑÅºÚ", 9.0, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "clsbchlin"
        Me.Text = "2569"

        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clsbchlin = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtdc_code, "Text", objBO, "dc_code")
            BindField(Me.txtbch_no, "Text", objBO, "bch_no")
            BindField(Me.txtdn_no, "Text", objBO, "dn_no")
            BindField(Me.cbostatus_code, "SelectedValue", objBO, "status_code")
            BindField(Me.txtlocked, "Text", objBO, "locked")
            BindField(Me.txtopt_by, "Text", objBO, "opt_by")
            BindField(Me.dtpopt_dtime, "Text", objBO, "opt_dtime")
            BindField(Me.dtpstart_dtime, "Text", objBO, "start_dtime")
            BindField(Me.dtpend_dtime, "Text", objBO, "end_dtime")
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
        	MyBase.FormatControl(txtdc_code, "dc_code", lbldc_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtbch_no, "bch_no", lblbch_no, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtdn_no, "dn_no", lbldn_no, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(cbostatus_code, "status_code", lblstatus_code, AddressOf mControlHelper.GeneralControlFormatter, AddressOf mControlHelper.ComboListBoxLoader, AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(txtlocked, "locked", lbllocked, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtopt_by, "opt_by", lblopt_by, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(dtpstart_dtime, "start_dtime", lblstart_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(dtpend_dtime, "end_dtime", lblend_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        Me.LoadLayout()
        Catch ThisException As Exception
        	ErrorMsg(ThisException, Me.GetType, "Format")
        End Try        
    End Sub
    
    
    Protected Overrides Sub LoadChildrenData(Optional ByVal blnReset As Boolean = False)
	End Sub
		
    Private Sub frmclsbchlin_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
