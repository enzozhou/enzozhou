Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclsbinareaBase__
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
    Protected Friend WithEvents txtbin_area As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblbin_area As System.Windows.Forms.Label
    Protected Friend WithEvents txtdescription As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldescription As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_by As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_by As System.Windows.Forms.Label
    Protected Friend WithEvents dtpopt_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblopt_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_timestamp As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_timestamp As System.Windows.Forms.Label
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Protected Friend WithEvents tp__clsbin As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsbin As YTUI.DataGrid
    Protected Friend WithEvents tp__clsbinStatus As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsbinStatus As YTUI.DataGrid
    Protected Friend WithEvents tabGrid As System.Windows.Forms.TabControl

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.splMain = New System.Windows.Forms.Splitter()
        Me.txtdc_code = New System.Windows.Forms.TextBox()
        Me.lbldc_code = New System.Windows.Forms.Label()
        Me.txtbin_area = New System.Windows.Forms.TextBox()
        Me.lblbin_area = New System.Windows.Forms.Label()
        Me.txtdescription = New System.Windows.Forms.TextBox()
        Me.lbldescription = New System.Windows.Forms.Label()
        Me.txtopt_by = New System.Windows.Forms.TextBox()
        Me.lblopt_by = New System.Windows.Forms.Label()
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblopt_dtime = New System.Windows.Forms.Label()
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox()
        Me.lblopt_timestamp = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.gd__clsbin = New YTUI.DataGrid()
        Me.tp__clsbin = New System.Windows.Forms.TabPage()
        Me.gd__clsbinStatus = New YTUI.DataGrid()
        Me.tp__clsbinStatus = New System.Windows.Forms.TabPage()
        Me.tabGrid = New System.Windows.Forms.TabControl()

        CType(Me.gd__clsbin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gd__clsbinStatus, System.ComponentModel.ISupportInitialize).BeginInit()

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
        'txtbin_area
        '
        Me.txtbin_area.Location = New System.Drawing.Point(138, 32)
        Me.txtbin_area.Name = "txtbin_area"
        Me.txtbin_area.Size = New System.Drawing.Size(225, 21)
        Me.txtbin_area.TabIndex = 4
        'lblbin_area
        '
        Me.lblbin_area.BackColor = System.Drawing.Color.Transparent
        Me.lblbin_area.Location = New System.Drawing.Point(10, 34)
        Me.lblbin_area.Name = "lblbin_area"
        Me.lblbin_area.Size = New System.Drawing.Size(121, 17)
        Me.lblbin_area.TabIndex = 3
        Me.lblbin_area.Text = "bin_area"
        'txtdescription
        '
        Me.txtdescription.Location = New System.Drawing.Point(138, 53)
        Me.txtdescription.Name = "txtdescription"
        Me.txtdescription.Size = New System.Drawing.Size(225, 21)
        Me.txtdescription.TabIndex = 6
        'lbldescription
        '
        Me.lbldescription.BackColor = System.Drawing.Color.Transparent
        Me.lbldescription.Location = New System.Drawing.Point(10, 56)
        Me.lbldescription.Name = "lbldescription"
        Me.lbldescription.Size = New System.Drawing.Size(121, 17)
        Me.lbldescription.TabIndex = 5
        Me.lbldescription.Text = "description"
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(138, 75)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(225, 21)
        Me.txtopt_by.TabIndex = 8
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(10, 77)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_by.TabIndex = 7
        Me.lblopt_by.Text = "opt_by"
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(138, 97)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.TabIndex = 10
        Me.dtpopt_dtime.Format = DateTimePickerFormat.Long
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(10, 99)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_dtime.TabIndex = 9
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
        Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtdc_code, Me.lbldc_code, Me.txtbin_area, Me.lblbin_area, Me.txtdescription, Me.lbldescription, Me.txtopt_by, Me.lblopt_by, Me.dtpopt_dtime, Me.lblopt_dtime, Me.txtopt_timestamp, Me.lblopt_timestamp})
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(392, 264)
        Me.pnlMain.TabIndex = 0
        Me.pnlMain.TabStop = False
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top

        Me.gd__clsbin.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsbin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsbin.Name = "Me.gd__clsbin"
        Me.gd__clsbin.Size = New System.Drawing.Size(552, 116)
        Me.gd__clsbin.TabIndex = 12
        'tp__clsbin
        '        
        Me.tp__clsbin.Controls.AddRange(New System.Windows.Forms.Control() {Me.gd__clsbin})
        Me.tp__clsbin.Location = New System.Drawing.Point(0, 0)
        Me.tp__clsbin.Name = "tp__clsbin"
        Me.tp__clsbin.Size = New System.Drawing.Size(392, 264)
        Me.tp__clsbin.TabIndex = 0
        Me.tp__clsbin.Text = "clsbins"
        Me.tp__clsbin.AutoScroll = True

        Me.gd__clsbinStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsbinStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsbinStatus.Name = "Me.gd__clsbinStatus"
        Me.gd__clsbinStatus.Size = New System.Drawing.Size(552, 116)
        Me.gd__clsbinStatus.TabIndex = 13
        'tp__clsbinStatus
        '        
        Me.tp__clsbinStatus.Controls.AddRange(New System.Windows.Forms.Control() {Me.gd__clsbinStatus})
        Me.tp__clsbinStatus.Location = New System.Drawing.Point(0, 0)
        Me.tp__clsbinStatus.Name = "tp__clsbinStatus"
        Me.tp__clsbinStatus.Size = New System.Drawing.Size(392, 264)
        Me.tp__clsbinStatus.TabIndex = 0
        Me.tp__clsbinStatus.Text = "clsbinStatuses"
        Me.tp__clsbinStatus.AutoScroll = True
        'tabGrid
        '        
        Me.tabGrid.Controls.AddRange(New System.Windows.Forms.Control() {Me.tp__clsbin, Me.tp__clsbinStatus})
        Me.tabGrid.Location = New System.Drawing.Point(0, 0)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.SelectedIndex = 0
        Me.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrid.Size = New System.Drawing.Size(392, 264)
        Me.tabGrid.TabIndex = 11
		 Me.tabGrid.Alignment = System.Windows.Forms.TabAlignment.Bottom
        '
        'frmclsbinarea
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.AutoScroll = True
        Me.WindowState = FormWindowState.Maximized
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabGrid, Me.splMain, Me.pnlMain})
        Me.Font = New System.Drawing.Font("Î¢ÈíÑÅºÚ", 9.0, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "clsbinarea"
        Me.Text = "2728"
        CType(Me.gd__clsbin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gd__clsbinStatus, System.ComponentModel.ISupportInitialize).EndInit()

        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clsbinarea = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtdc_code, "Text", objBO, "dc_code")
            BindField(Me.txtbin_area, "Text", objBO, "bin_area")
            BindField(Me.txtdescription, "Text", objBO, "description")
            BindField(Me.txtopt_by, "Text", objBO, "opt_by")
            BindField(Me.dtpopt_dtime, "Text", objBO, "opt_dtime")
            CType(Me.gd__clsbin, IGrid).DataSource = objBO.clsbins
            CType(Me.gd__clsbinStatus, IGrid).DataSource = objBO.clsbinStatuses
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "DataBind")
        End Try
    End Sub

    Protected Overrides Sub UpdateControlEditStatus()
    	Me.FormatControlEditStatus()
    	Me.SetChildGridEditMode(Me.gd__clsbin)
    	Me.SetChildGridEditMode(Me.gd__clsbinStatus)
    End Sub
    
    Public Overrides Sub Format()
    	try
        	MyBase.Format()
        	MyBase.FormatControl(txtdc_code, "dc_code", lbldc_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtbin_area, "bin_area", lblbin_area, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtdescription, "description", lbldescription, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtopt_by, "opt_by", lblopt_by, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
    		Me.tp__clsbin.Text = mobjapp.GetLayout.CXObjectLays(GetType(clsbin).Name).ColCaptionText
        	CType(Me.gd__clsbin, IGrid).FormatGrid()
    		Me.tp__clsbinStatus.Text = mobjapp.GetLayout.CXObjectLays(GetType(clsbinStatus).Name).ColCaptionText
        	CType(Me.gd__clsbinStatus, IGrid).FormatGrid()
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
    	CType(Current, clsbinarea).Loadclsbins(blnReset)
    	CType(Current, clsbinarea).LoadclsbinStatuses(blnReset)
	End Sub
		
    Private Sub frmclsbinarea_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
