Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclsbarcodeBase__
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
        Protected Friend WithEvents txtsku_no As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblsku_no As System.Windows.Forms.Label
    Protected Friend WithEvents txtbarcode As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblbarcode As System.Windows.Forms.Label
    Protected Friend WithEvents txtbar_type As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblbar_type As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_by As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_by As System.Windows.Forms.Label
    Protected Friend WithEvents dtpopt_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblopt_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_timestamp As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_timestamp As System.Windows.Forms.Label
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtsku_no = New System.Windows.Forms.TextBox()
        Me.lblsku_no = New System.Windows.Forms.Label()
        Me.txtbarcode = New System.Windows.Forms.TextBox()
        Me.lblbarcode = New System.Windows.Forms.Label()
        Me.txtbar_type = New System.Windows.Forms.TextBox()
        Me.lblbar_type = New System.Windows.Forms.Label()
        Me.txtopt_by = New System.Windows.Forms.TextBox()
        Me.lblopt_by = New System.Windows.Forms.Label()
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblopt_dtime = New System.Windows.Forms.Label()
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox()
        Me.lblopt_timestamp = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()


        Me.SuspendLayout()
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
        'txtbarcode
        '
        Me.txtbarcode.Location = New System.Drawing.Point(138, 32)
        Me.txtbarcode.Name = "txtbarcode"
        Me.txtbarcode.Size = New System.Drawing.Size(225, 21)
        Me.txtbarcode.TabIndex = 4
        'lblbarcode
        '
        Me.lblbarcode.BackColor = System.Drawing.Color.Transparent
        Me.lblbarcode.Location = New System.Drawing.Point(10, 34)
        Me.lblbarcode.Name = "lblbarcode"
        Me.lblbarcode.Size = New System.Drawing.Size(121, 17)
        Me.lblbarcode.TabIndex = 3
        Me.lblbarcode.Text = "barcode"
        'txtbar_type
        '
        Me.txtbar_type.Location = New System.Drawing.Point(138, 53)
        Me.txtbar_type.Name = "txtbar_type"
        Me.txtbar_type.Size = New System.Drawing.Size(225, 21)
        Me.txtbar_type.TabIndex = 6
        'lblbar_type
        '
        Me.lblbar_type.BackColor = System.Drawing.Color.Transparent
        Me.lblbar_type.Location = New System.Drawing.Point(10, 56)
        Me.lblbar_type.Name = "lblbar_type"
        Me.lblbar_type.Size = New System.Drawing.Size(121, 17)
        Me.lblbar_type.TabIndex = 5
        Me.lblbar_type.Text = "bar_type"
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
        Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtsku_no, Me.lblsku_no, Me.txtbarcode, Me.lblbarcode, Me.txtbar_type, Me.lblbar_type, Me.txtopt_by, Me.lblopt_by, Me.dtpopt_dtime, Me.lblopt_dtime, Me.txtopt_timestamp, Me.lblopt_timestamp})
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(392, 264)
        Me.pnlMain.TabIndex = 0
        Me.pnlMain.TabStop = False
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill

        '
        'frmclsbarcode
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.AutoScroll = True
        Me.WindowState = FormWindowState.Maximized
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlMain})
        Me.Font = New System.Drawing.Font("Î¢ÈíÑÅºÚ", 9.0, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "clsbarcode"
        Me.Text = "2887"

        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clsbarcode = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtsku_no, "Text", objBO, "sku_no")
            BindField(Me.txtbarcode, "Text", objBO, "barcode")
            BindField(Me.txtbar_type, "Text", objBO, "bar_type")
            BindField(Me.txtopt_by, "Text", objBO, "opt_by")
            BindField(Me.dtpopt_dtime, "Text", objBO, "opt_dtime")
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
        	MyBase.FormatControl(txtsku_no, "sku_no", lblsku_no, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtbarcode, "barcode", lblbarcode, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtbar_type, "bar_type", lblbar_type, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtopt_by, "opt_by", lblopt_by, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        Me.LoadLayout()
        Catch ThisException As Exception
        	ErrorMsg(ThisException, Me.GetType, "Format")
        End Try        
    End Sub
    
    
    Protected Overrides Sub LoadChildrenData(Optional ByVal blnReset As Boolean = False)
	End Sub
		
    Private Sub frmclsbarcode_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
