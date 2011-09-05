Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclsskuinfoBase__
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
    Protected Friend WithEvents txtsku_no As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblsku_no As System.Windows.Forms.Label
    Protected Friend WithEvents txtsku_wms As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblsku_wms As System.Windows.Forms.Label
    Protected Friend WithEvents txtsku_desc As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblsku_desc As System.Windows.Forms.Label
    Protected Friend WithEvents txtsku_desc_eng As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblsku_desc_eng As System.Windows.Forms.Label
    Protected Friend WithEvents txtmodel_no As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblmodel_no As System.Windows.Forms.Label
    Protected Friend WithEvents txtvolume As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblvolume As System.Windows.Forms.Label
    Protected Friend WithEvents txtlength As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbllength As System.Windows.Forms.Label
    Protected Friend WithEvents txtwidth_ As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblwidth_ As System.Windows.Forms.Label
    Protected Friend WithEvents txtheight As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblheight As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_by As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_by As System.Windows.Forms.Label
    Protected Friend WithEvents dtpopt_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblopt_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_timestamp As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_timestamp As System.Windows.Forms.Label
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Protected Friend WithEvents tp__clsbarcode As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsbarcode As YTUI.DataGrid
    Protected Friend WithEvents tabGrid As System.Windows.Forms.TabControl

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.splMain = New System.Windows.Forms.Splitter()
        Me.txtsku_no = New System.Windows.Forms.TextBox()
        Me.lblsku_no = New System.Windows.Forms.Label()
        Me.txtsku_wms = New System.Windows.Forms.TextBox()
        Me.lblsku_wms = New System.Windows.Forms.Label()
        Me.txtsku_desc = New System.Windows.Forms.TextBox()
        Me.lblsku_desc = New System.Windows.Forms.Label()
        Me.txtsku_desc_eng = New System.Windows.Forms.TextBox()
        Me.lblsku_desc_eng = New System.Windows.Forms.Label()
        Me.txtmodel_no = New System.Windows.Forms.TextBox()
        Me.lblmodel_no = New System.Windows.Forms.Label()
        Me.txtvolume = New System.Windows.Forms.TextBox()
        Me.lblvolume = New System.Windows.Forms.Label()
        Me.txtlength = New System.Windows.Forms.TextBox()
        Me.lbllength = New System.Windows.Forms.Label()
        Me.txtwidth_ = New System.Windows.Forms.TextBox()
        Me.lblwidth_ = New System.Windows.Forms.Label()
        Me.txtheight = New System.Windows.Forms.TextBox()
        Me.lblheight = New System.Windows.Forms.Label()
        Me.txtopt_by = New System.Windows.Forms.TextBox()
        Me.lblopt_by = New System.Windows.Forms.Label()
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblopt_dtime = New System.Windows.Forms.Label()
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox()
        Me.lblopt_timestamp = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.gd__clsbarcode = New YTUI.DataGrid()
        Me.tp__clsbarcode = New System.Windows.Forms.TabPage()
        Me.tabGrid = New System.Windows.Forms.TabControl()

        CType(Me.gd__clsbarcode, System.ComponentModel.ISupportInitialize).BeginInit()

        Me.SuspendLayout()
        'splMain
        '
        Me.splMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.splMain.Location = New System.Drawing.Point(0, 264)
        Me.splMain.Name = "splMain"
        Me.splMain.Size = New System.Drawing.Size(480, 8)
        Me.splMain.TabStop = False
        'txtsku_no
        '
        Me.txtsku_no.Location = New System.Drawing.Point(138, 10)
        Me.txtsku_no.Name = "txtsku_no"
        Me.txtsku_no.Size = New System.Drawing.Size(225, 21)
        Me.txtsku_no.TabIndex = 2
        'lblsku_no
        '
        Me.lblsku_no.BackColor = System.Drawing.Color.Transparent
        Me.lblsku_no.Location = New System.Drawing.Point(10, 12)
        Me.lblsku_no.Name = "lblsku_no"
        Me.lblsku_no.Size = New System.Drawing.Size(121, 17)
        Me.lblsku_no.TabIndex = 1
        Me.lblsku_no.Text = "sku_no"
        'txtsku_wms
        '
        Me.txtsku_wms.Location = New System.Drawing.Point(138, 32)
        Me.txtsku_wms.Name = "txtsku_wms"
        Me.txtsku_wms.Size = New System.Drawing.Size(225, 21)
        Me.txtsku_wms.TabIndex = 4
        'lblsku_wms
        '
        Me.lblsku_wms.BackColor = System.Drawing.Color.Transparent
        Me.lblsku_wms.Location = New System.Drawing.Point(10, 34)
        Me.lblsku_wms.Name = "lblsku_wms"
        Me.lblsku_wms.Size = New System.Drawing.Size(121, 17)
        Me.lblsku_wms.TabIndex = 3
        Me.lblsku_wms.Text = "sku_wms"
        'txtsku_desc
        '
        Me.txtsku_desc.Location = New System.Drawing.Point(138, 53)
        Me.txtsku_desc.Name = "txtsku_desc"
        Me.txtsku_desc.Size = New System.Drawing.Size(225, 21)
        Me.txtsku_desc.TabIndex = 6
        'lblsku_desc
        '
        Me.lblsku_desc.BackColor = System.Drawing.Color.Transparent
        Me.lblsku_desc.Location = New System.Drawing.Point(10, 56)
        Me.lblsku_desc.Name = "lblsku_desc"
        Me.lblsku_desc.Size = New System.Drawing.Size(121, 17)
        Me.lblsku_desc.TabIndex = 5
        Me.lblsku_desc.Text = "sku_desc"
        'txtsku_desc_eng
        '
        Me.txtsku_desc_eng.Location = New System.Drawing.Point(138, 75)
        Me.txtsku_desc_eng.Name = "txtsku_desc_eng"
        Me.txtsku_desc_eng.Size = New System.Drawing.Size(225, 21)
        Me.txtsku_desc_eng.TabIndex = 8
        'lblsku_desc_eng
        '
        Me.lblsku_desc_eng.BackColor = System.Drawing.Color.Transparent
        Me.lblsku_desc_eng.Location = New System.Drawing.Point(10, 77)
        Me.lblsku_desc_eng.Name = "lblsku_desc_eng"
        Me.lblsku_desc_eng.Size = New System.Drawing.Size(121, 17)
        Me.lblsku_desc_eng.TabIndex = 7
        Me.lblsku_desc_eng.Text = "sku_desc_eng"
        'txtmodel_no
        '
        Me.txtmodel_no.Location = New System.Drawing.Point(138, 97)
        Me.txtmodel_no.Name = "txtmodel_no"
        Me.txtmodel_no.Size = New System.Drawing.Size(225, 21)
        Me.txtmodel_no.TabIndex = 10
        'lblmodel_no
        '
        Me.lblmodel_no.BackColor = System.Drawing.Color.Transparent
        Me.lblmodel_no.Location = New System.Drawing.Point(10, 99)
        Me.lblmodel_no.Name = "lblmodel_no"
        Me.lblmodel_no.Size = New System.Drawing.Size(121, 17)
        Me.lblmodel_no.TabIndex = 9
        Me.lblmodel_no.Text = "model_no"
        'txtvolume
        '
        Me.txtvolume.Location = New System.Drawing.Point(138, 118)
        Me.txtvolume.Name = "txtvolume"
        Me.txtvolume.Size = New System.Drawing.Size(225, 21)
        Me.txtvolume.TabIndex = 12
        'lblvolume
        '
        Me.lblvolume.BackColor = System.Drawing.Color.Transparent
        Me.lblvolume.Location = New System.Drawing.Point(10, 121)
        Me.lblvolume.Name = "lblvolume"
        Me.lblvolume.Size = New System.Drawing.Size(121, 17)
        Me.lblvolume.TabIndex = 11
        Me.lblvolume.Text = "volume"
        'txtlength
        '
        Me.txtlength.Location = New System.Drawing.Point(138, 140)
        Me.txtlength.Name = "txtlength"
        Me.txtlength.Size = New System.Drawing.Size(225, 21)
        Me.txtlength.TabIndex = 14
        'lbllength
        '
        Me.lbllength.BackColor = System.Drawing.Color.Transparent
        Me.lbllength.Location = New System.Drawing.Point(10, 142)
        Me.lbllength.Name = "lbllength"
        Me.lbllength.Size = New System.Drawing.Size(121, 17)
        Me.lbllength.TabIndex = 13
        Me.lbllength.Text = "length"
        'txtwidth_
        '
        Me.txtwidth_.Location = New System.Drawing.Point(138, 162)
        Me.txtwidth_.Name = "txtwidth_"
        Me.txtwidth_.Size = New System.Drawing.Size(225, 21)
        Me.txtwidth_.TabIndex = 16
        'lblwidth_
        '
        Me.lblwidth_.BackColor = System.Drawing.Color.Transparent
        Me.lblwidth_.Location = New System.Drawing.Point(10, 164)
        Me.lblwidth_.Name = "lblwidth_"
        Me.lblwidth_.Size = New System.Drawing.Size(121, 17)
        Me.lblwidth_.TabIndex = 15
        Me.lblwidth_.Text = "width"
        'txtheight
        '
        Me.txtheight.Location = New System.Drawing.Point(138, 183)
        Me.txtheight.Name = "txtheight"
        Me.txtheight.Size = New System.Drawing.Size(225, 21)
        Me.txtheight.TabIndex = 18
        'lblheight
        '
        Me.lblheight.BackColor = System.Drawing.Color.Transparent
        Me.lblheight.Location = New System.Drawing.Point(10, 186)
        Me.lblheight.Name = "lblheight"
        Me.lblheight.Size = New System.Drawing.Size(121, 17)
        Me.lblheight.TabIndex = 17
        Me.lblheight.Text = "height"
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(138, 205)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(225, 21)
        Me.txtopt_by.TabIndex = 20
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(10, 207)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_by.TabIndex = 19
        Me.lblopt_by.Text = "opt_by"
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(138, 227)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.TabIndex = 22
        Me.dtpopt_dtime.Format = DateTimePickerFormat.Long
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(10, 229)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_dtime.TabIndex = 21
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
        Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtsku_no, Me.lblsku_no, Me.txtsku_wms, Me.lblsku_wms, Me.txtsku_desc, Me.lblsku_desc, Me.txtsku_desc_eng, Me.lblsku_desc_eng, Me.txtmodel_no, Me.lblmodel_no, Me.txtvolume, Me.lblvolume, Me.txtlength, Me.lbllength, Me.txtwidth_, Me.lblwidth_, Me.txtheight, Me.lblheight, Me.txtopt_by, Me.lblopt_by, Me.dtpopt_dtime, Me.lblopt_dtime, Me.txtopt_timestamp, Me.lblopt_timestamp})
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(392, 264)
        Me.pnlMain.TabIndex = 0
        Me.pnlMain.TabStop = False
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top

        Me.gd__clsbarcode.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsbarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsbarcode.Name = "Me.gd__clsbarcode"
        Me.gd__clsbarcode.Size = New System.Drawing.Size(552, 116)
        Me.gd__clsbarcode.TabIndex = 24
        'tp__clsbarcode
        '        
        Me.tp__clsbarcode.Controls.AddRange(New System.Windows.Forms.Control() {Me.gd__clsbarcode})
        Me.tp__clsbarcode.Location = New System.Drawing.Point(0, 0)
        Me.tp__clsbarcode.Name = "tp__clsbarcode"
        Me.tp__clsbarcode.Size = New System.Drawing.Size(392, 264)
        Me.tp__clsbarcode.TabIndex = 0
        Me.tp__clsbarcode.Text = "clsbarcodes"
        Me.tp__clsbarcode.AutoScroll = True
        'tabGrid
        '        
        Me.tabGrid.Controls.AddRange(New System.Windows.Forms.Control() {Me.tp__clsbarcode})
        Me.tabGrid.Location = New System.Drawing.Point(0, 0)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.SelectedIndex = 0
        Me.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrid.Size = New System.Drawing.Size(392, 264)
        Me.tabGrid.TabIndex = 23
		 Me.tabGrid.Alignment = System.Windows.Forms.TabAlignment.Bottom
        '
        'frmclsskuinfo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.AutoScroll = True
        Me.WindowState = FormWindowState.Maximized
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabGrid, Me.splMain, Me.pnlMain})
        Me.Font = New System.Drawing.Font("Î¢ÈíÑÅºÚ", 9.0, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "clsskuinfo"
        Me.Text = "2835"
        CType(Me.gd__clsbarcode, System.ComponentModel.ISupportInitialize).EndInit()

        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clsskuinfo = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtsku_no, "Text", objBO, "sku_no")
            BindField(Me.txtsku_wms, "Text", objBO, "sku_wms")
            BindField(Me.txtsku_desc, "Text", objBO, "sku_desc")
            BindField(Me.txtsku_desc_eng, "Text", objBO, "sku_desc_eng")
            BindField(Me.txtmodel_no, "Text", objBO, "model_no")
            BindField(Me.txtvolume, "Text", objBO, "volume")
            BindField(Me.txtlength, "Text", objBO, "length")
            BindField(Me.txtwidth_, "Text", objBO, "width_")
            BindField(Me.txtheight, "Text", objBO, "height")
            BindField(Me.txtopt_by, "Text", objBO, "opt_by")
            BindField(Me.dtpopt_dtime, "Text", objBO, "opt_dtime")
            CType(Me.gd__clsbarcode, IGrid).DataSource = objBO.clsbarcodes
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "DataBind")
        End Try
    End Sub

    Protected Overrides Sub UpdateControlEditStatus()
    	Me.FormatControlEditStatus()
    	Me.SetChildGridEditMode(Me.gd__clsbarcode)
    End Sub
    
    Public Overrides Sub Format()
    	try
        	MyBase.Format()
        	MyBase.FormatControl(txtsku_no, "sku_no", lblsku_no, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtsku_wms, "sku_wms", lblsku_wms, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtsku_desc, "sku_desc", lblsku_desc, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtsku_desc_eng, "sku_desc_eng", lblsku_desc_eng, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtmodel_no, "model_no", lblmodel_no, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtvolume, "volume", lblvolume, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtlength, "length", lbllength, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtwidth_, "width_", lblwidth_, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtheight, "height", lblheight, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtopt_by, "opt_by", lblopt_by, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
    		Me.tp__clsbarcode.Text = mobjapp.GetLayout.CXObjectLays(GetType(clsbarcode).Name).ColCaptionText
        	CType(Me.gd__clsbarcode, IGrid).FormatGrid()
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
    	CType(Current, clsskuinfo).Loadclsbarcodes(blnReset)
	End Sub
		
    Private Sub frmclsskuinfo_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
