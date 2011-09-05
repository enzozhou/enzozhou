Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclstaskhdrBase__
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
    Protected Friend WithEvents txttask_id As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbltask_id As System.Windows.Forms.Label
    Protected Friend WithEvents txtbch_no As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblbch_no As System.Windows.Forms.Label
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
    Protected Friend WithEvents txtopt_timestamp As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_timestamp As System.Windows.Forms.Label
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Protected Friend WithEvents tp__clstasklist As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clstasklist As YTUI.DataGrid
    Protected Friend WithEvents tp__clstasklin As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clstasklin As YTUI.DataGrid
    Protected Friend WithEvents tabGrid As System.Windows.Forms.TabControl

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.splMain = New System.Windows.Forms.Splitter()
        Me.txtdc_code = New System.Windows.Forms.TextBox()
        Me.lbldc_code = New System.Windows.Forms.Label()
        Me.txttask_id = New System.Windows.Forms.TextBox()
        Me.lbltask_id = New System.Windows.Forms.Label()
        Me.txtbch_no = New System.Windows.Forms.TextBox()
        Me.lblbch_no = New System.Windows.Forms.Label()
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
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox()
        Me.lblopt_timestamp = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.gd__clstasklist = New YTUI.DataGrid()
        Me.tp__clstasklist = New System.Windows.Forms.TabPage()
        Me.gd__clstasklin = New YTUI.DataGrid()
        Me.tp__clstasklin = New System.Windows.Forms.TabPage()
        Me.tabGrid = New System.Windows.Forms.TabControl()

        CType(Me.gd__clstasklist, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gd__clstasklin, System.ComponentModel.ISupportInitialize).BeginInit()

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
        Me.txtdc_code.TabIndex = 3
        'lbldc_code
        '
        Me.lbldc_code.BackColor = System.Drawing.Color.Transparent
        Me.lbldc_code.Location = New System.Drawing.Point(10, 12)
        Me.lbldc_code.Name = "lbldc_code"
        Me.lbldc_code.Size = New System.Drawing.Size(121, 17)
        Me.lbldc_code.TabIndex = 4
        Me.lbldc_code.Text = "dc_code"
        'txttask_id
        '
        Me.txttask_id.Location = New System.Drawing.Point(138, 32)
        Me.txttask_id.Name = "txttask_id"
        Me.txttask_id.Size = New System.Drawing.Size(225, 21)
        Me.txttask_id.TabIndex = 5
        'lbltask_id
        '
        Me.lbltask_id.BackColor = System.Drawing.Color.Transparent
        Me.lbltask_id.Location = New System.Drawing.Point(10, 34)
        Me.lbltask_id.Name = "lbltask_id"
        Me.lbltask_id.Size = New System.Drawing.Size(121, 17)
        Me.lbltask_id.TabIndex = 6
        Me.lbltask_id.Text = "task_id"
        'txtbch_no
        '
        Me.txtbch_no.Location = New System.Drawing.Point(138, 53)
        Me.txtbch_no.Name = "txtbch_no"
        Me.txtbch_no.Size = New System.Drawing.Size(225, 21)
        Me.txtbch_no.TabIndex = 7
        'lblbch_no
        '
        Me.lblbch_no.BackColor = System.Drawing.Color.Transparent
        Me.lblbch_no.Location = New System.Drawing.Point(10, 56)
        Me.lblbch_no.Name = "lblbch_no"
        Me.lblbch_no.Size = New System.Drawing.Size(121, 17)
        Me.lblbch_no.TabIndex = 8
        Me.lblbch_no.Text = "bch_no"
        'cbostatus_code 
        '
        Me.cbostatus_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbostatus_code.Location = New System.Drawing.Point(138, 75)
        Me.cbostatus_code.Name = "cbostatus_code"
        Me.cbostatus_code.Size = New System.Drawing.Size(225, 21)
        Me.cbostatus_code.TabIndex = 9
        'lblstatus_code
        '
        Me.lblstatus_code.BackColor = System.Drawing.Color.Transparent
        Me.lblstatus_code.Location = New System.Drawing.Point(10, 77)
        Me.lblstatus_code.Name = "lblstatus_code"
        Me.lblstatus_code.Size = New System.Drawing.Size(121, 17)
        Me.lblstatus_code.TabIndex = 10
        Me.lblstatus_code.Text = "status_code"
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(138, 97)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(225, 21)
        Me.txtopt_by.TabIndex = 11
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(10, 99)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_by.TabIndex = 12
        Me.lblopt_by.Text = "opt_by"
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(138, 118)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.TabIndex = 13
        Me.dtpopt_dtime.Format = DateTimePickerFormat.Long
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(10, 121)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_dtime.TabIndex = 14
        Me.lblopt_dtime.Text = "opt_dtime"
        'dtpstart_dtime
        '
        Me.dtpstart_dtime.Location = New System.Drawing.Point(138, 140)
        Me.dtpstart_dtime.Name = "dtpstart_dtime"
        Me.dtpstart_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpstart_dtime.ShowCheckBox = True
        Me.dtpstart_dtime.TabIndex = 15
        Me.dtpstart_dtime.Format = DateTimePickerFormat.Long
        'lblstart_dtime
        '
        Me.lblstart_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblstart_dtime.Location = New System.Drawing.Point(10, 142)
        Me.lblstart_dtime.Name = "lblstart_dtime"
        Me.lblstart_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblstart_dtime.TabIndex = 16
        Me.lblstart_dtime.Text = "start_dtime"
        'dtpend_dtime
        '
        Me.dtpend_dtime.Location = New System.Drawing.Point(138, 162)
        Me.dtpend_dtime.Name = "dtpend_dtime"
        Me.dtpend_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpend_dtime.ShowCheckBox = True
        Me.dtpend_dtime.TabIndex = 17
        Me.dtpend_dtime.Format = DateTimePickerFormat.Long
        'lblend_dtime
        '
        Me.lblend_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblend_dtime.Location = New System.Drawing.Point(10, 164)
        Me.lblend_dtime.Name = "lblend_dtime"
        Me.lblend_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblend_dtime.TabIndex = 18
        Me.lblend_dtime.Text = "end_dtime"
        'txtopt_timestamp
        '
        Me.txtopt_timestamp.Location = New System.Drawing.Point(2, 2)
        Me.txtopt_timestamp.Name = "txtopt_timestamp"
        Me.txtopt_timestamp.Size = New System.Drawing.Size(150, 23)
        Me.txtopt_timestamp.TabIndex = 2
        'lblopt_timestamp
        '
        Me.lblopt_timestamp.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_timestamp.Location = New System.Drawing.Point(2, 2)
        Me.lblopt_timestamp.Name = "lblopt_timestamp"
        Me.lblopt_timestamp.Size = New System.Drawing.Size(150, 23)
        Me.lblopt_timestamp.TabIndex = 1
        Me.lblopt_timestamp.Text = "opt_timestamp"
        'pnlMain
        '
        Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtdc_code, Me.lbldc_code, Me.txttask_id, Me.lbltask_id, Me.txtbch_no, Me.lblbch_no, Me.cbostatus_code, Me.lblstatus_code, Me.txtopt_by, Me.lblopt_by, Me.dtpopt_dtime, Me.lblopt_dtime, Me.dtpstart_dtime, Me.lblstart_dtime, Me.dtpend_dtime, Me.lblend_dtime, Me.txtopt_timestamp, Me.lblopt_timestamp})
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(392, 264)
        Me.pnlMain.TabIndex = 0
        Me.pnlMain.TabStop = False
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top

        Me.gd__clstasklist.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clstasklist.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clstasklist.Name = "Me.gd__clstasklist"
        Me.gd__clstasklist.Size = New System.Drawing.Size(552, 116)
        Me.gd__clstasklist.TabIndex = 19
        'tp__clstasklist
        '        
        Me.tp__clstasklist.Controls.AddRange(New System.Windows.Forms.Control() {Me.gd__clstasklist})
        Me.tp__clstasklist.Location = New System.Drawing.Point(0, 0)
        Me.tp__clstasklist.Name = "tp__clstasklist"
        Me.tp__clstasklist.Size = New System.Drawing.Size(392, 264)
        Me.tp__clstasklist.TabIndex = 0
        Me.tp__clstasklist.Text = "clstasklists"
        Me.tp__clstasklist.AutoScroll = True

        Me.gd__clstasklin.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clstasklin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clstasklin.Name = "Me.gd__clstasklin"
        Me.gd__clstasklin.Size = New System.Drawing.Size(552, 116)
        Me.gd__clstasklin.TabIndex = 20
        'tp__clstasklin
        '        
        Me.tp__clstasklin.Controls.AddRange(New System.Windows.Forms.Control() {Me.gd__clstasklin})
        Me.tp__clstasklin.Location = New System.Drawing.Point(0, 0)
        Me.tp__clstasklin.Name = "tp__clstasklin"
        Me.tp__clstasklin.Size = New System.Drawing.Size(392, 264)
        Me.tp__clstasklin.TabIndex = 0
        Me.tp__clstasklin.Text = "clstasklins"
        Me.tp__clstasklin.AutoScroll = True
        'tabGrid
        '        
        Me.tabGrid.Controls.AddRange(New System.Windows.Forms.Control() {Me.tp__clstasklist, Me.tp__clstasklin})
        Me.tabGrid.Location = New System.Drawing.Point(0, 0)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.SelectedIndex = 0
        Me.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrid.Size = New System.Drawing.Size(392, 264)
        Me.tabGrid.TabIndex = 18
		 Me.tabGrid.Alignment = System.Windows.Forms.TabAlignment.Bottom
        '
        'frmclstaskhdr
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.AutoScroll = True
        Me.WindowState = FormWindowState.Maximized
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabGrid, Me.splMain, Me.pnlMain})
        Me.Font = New System.Drawing.Font("Î¢ÈíÑÅºÚ", 9.0, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "clstaskhdr"
        Me.Text = "2660"
        CType(Me.gd__clstasklist, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gd__clstasklin, System.ComponentModel.ISupportInitialize).EndInit()

        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clstaskhdr = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtdc_code, "Text", objBO, "dc_code")
            BindField(Me.txttask_id, "Text", objBO, "task_id")
            BindField(Me.txtbch_no, "Text", objBO, "bch_no")
            BindField(Me.cbostatus_code, "SelectedValue", objBO, "status_code")
            BindField(Me.txtopt_by, "Text", objBO, "opt_by")
            BindField(Me.dtpopt_dtime, "Text", objBO, "opt_dtime")
            BindField(Me.dtpstart_dtime, "Text", objBO, "start_dtime")
            BindField(Me.dtpend_dtime, "Text", objBO, "end_dtime")
            CType(Me.gd__clstasklist, IGrid).DataSource = objBO.clstasklists
            CType(Me.gd__clstasklin, IGrid).DataSource = objBO.clstasklins
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "DataBind")
        End Try
    End Sub

    Protected Overrides Sub UpdateControlEditStatus()
    	Me.FormatControlEditStatus()
    	Me.SetChildGridEditMode(Me.gd__clstasklist)
    	Me.SetChildGridEditMode(Me.gd__clstasklin)
    End Sub
    
    Public Overrides Sub Format()
    	try
        	MyBase.Format()
        	MyBase.FormatControl(txtdc_code, "dc_code", lbldc_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txttask_id, "task_id", lbltask_id, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtbch_no, "bch_no", lblbch_no, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(cbostatus_code, "status_code", lblstatus_code, AddressOf mControlHelper.GeneralControlFormatter, AddressOf mControlHelper.ComboListBoxLoader, AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(txtopt_by, "opt_by", lblopt_by, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(dtpstart_dtime, "start_dtime", lblstart_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(dtpend_dtime, "end_dtime", lblend_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
    		Me.tp__clstasklist.Text = mobjapp.GetLayout.CXObjectLays(GetType(clstasklist).Name).ColCaptionText
        	CType(Me.gd__clstasklist, IGrid).FormatGrid()
    		Me.tp__clstasklin.Text = mobjapp.GetLayout.CXObjectLays(GetType(clstasklin).Name).ColCaptionText
        	CType(Me.gd__clstasklin, IGrid).FormatGrid()
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
    	CType(Current, clstaskhdr).Loadclstasklists(blnReset)
    	CType(Current, clstaskhdr).Loadclstasklins(blnReset)
	End Sub
		
    Private Sub frmclstaskhdr_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
