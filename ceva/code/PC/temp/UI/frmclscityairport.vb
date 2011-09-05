Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclscityairportBase__
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
        Protected Friend WithEvents txtdestination As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldestination As System.Windows.Forms.Label
    Protected Friend WithEvents txtprovince As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblprovince As System.Windows.Forms.Label
    Protected Friend WithEvents txttransit As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbltransit As System.Windows.Forms.Label
    Protected Friend WithEvents txttype_ As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbltype_ As System.Windows.Forms.Label
    Protected Friend WithEvents dtpopt_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblopt_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_timestamp As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_timestamp As System.Windows.Forms.Label
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtdestination = New System.Windows.Forms.TextBox()
        Me.lbldestination = New System.Windows.Forms.Label()
        Me.txtprovince = New System.Windows.Forms.TextBox()
        Me.lblprovince = New System.Windows.Forms.Label()
        Me.txttransit = New System.Windows.Forms.TextBox()
        Me.lbltransit = New System.Windows.Forms.Label()
        Me.txttype_ = New System.Windows.Forms.TextBox()
        Me.lbltype_ = New System.Windows.Forms.Label()
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblopt_dtime = New System.Windows.Forms.Label()
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox()
        Me.lblopt_timestamp = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()


        Me.SuspendLayout()
        'txtdestination
        '
        Me.txtdestination.Location = New System.Drawing.Point(138, 10)
        Me.txtdestination.Name = "txtdestination"
        Me.txtdestination.Size = New System.Drawing.Size(225, 21)
        Me.txtdestination.TabIndex = 2
        'lbldestination
        '
        Me.lbldestination.BackColor = System.Drawing.Color.Transparent
        Me.lbldestination.Location = New System.Drawing.Point(10, 12)
        Me.lbldestination.Name = "lbldestination"
        Me.lbldestination.Size = New System.Drawing.Size(121, 17)
        Me.lbldestination.TabIndex = 1
        Me.lbldestination.Text = "destination"
        'txtprovince
        '
        Me.txtprovince.Location = New System.Drawing.Point(138, 32)
        Me.txtprovince.Name = "txtprovince"
        Me.txtprovince.Size = New System.Drawing.Size(225, 21)
        Me.txtprovince.TabIndex = 4
        'lblprovince
        '
        Me.lblprovince.BackColor = System.Drawing.Color.Transparent
        Me.lblprovince.Location = New System.Drawing.Point(10, 34)
        Me.lblprovince.Name = "lblprovince"
        Me.lblprovince.Size = New System.Drawing.Size(121, 17)
        Me.lblprovince.TabIndex = 3
        Me.lblprovince.Text = "province"
        'txttransit
        '
        Me.txttransit.Location = New System.Drawing.Point(138, 53)
        Me.txttransit.Name = "txttransit"
        Me.txttransit.Size = New System.Drawing.Size(225, 21)
        Me.txttransit.TabIndex = 6
        'lbltransit
        '
        Me.lbltransit.BackColor = System.Drawing.Color.Transparent
        Me.lbltransit.Location = New System.Drawing.Point(10, 56)
        Me.lbltransit.Name = "lbltransit"
        Me.lbltransit.Size = New System.Drawing.Size(121, 17)
        Me.lbltransit.TabIndex = 5
        Me.lbltransit.Text = "transit"
        'txttype_
        '
        Me.txttype_.Location = New System.Drawing.Point(138, 75)
        Me.txttype_.Name = "txttype_"
        Me.txttype_.Size = New System.Drawing.Size(225, 21)
        Me.txttype_.TabIndex = 8
        'lbltype_
        '
        Me.lbltype_.BackColor = System.Drawing.Color.Transparent
        Me.lbltype_.Location = New System.Drawing.Point(10, 77)
        Me.lbltype_.Name = "lbltype_"
        Me.lbltype_.Size = New System.Drawing.Size(121, 17)
        Me.lbltype_.TabIndex = 7
        Me.lbltype_.Text = "type"
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
        Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtdestination, Me.lbldestination, Me.txtprovince, Me.lblprovince, Me.txttransit, Me.lbltransit, Me.txttype_, Me.lbltype_, Me.dtpopt_dtime, Me.lblopt_dtime, Me.txtopt_timestamp, Me.lblopt_timestamp})
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(392, 264)
        Me.pnlMain.TabIndex = 0
        Me.pnlMain.TabStop = False
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill

        '
        'frmclscityairport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.AutoScroll = True
        Me.WindowState = FormWindowState.Maximized
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlMain})
        Me.Font = New System.Drawing.Font("Î¢ÈíÑÅºÚ", 9.0, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "clscityairport"
        Me.Text = "2953"

        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clscityairport = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtdestination, "Text", objBO, "destination")
            BindField(Me.txtprovince, "Text", objBO, "province")
            BindField(Me.txttransit, "Text", objBO, "transit")
            BindField(Me.txttype_, "Text", objBO, "type_")
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
        	MyBase.FormatControl(txtdestination, "destination", lbldestination, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtprovince, "province", lblprovince, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txttransit, "transit", lbltransit, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txttype_, "type_", lbltype_, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        Me.LoadLayout()
        Catch ThisException As Exception
        	ErrorMsg(ThisException, Me.GetType, "Format")
        End Try        
    End Sub
    
    
    Protected Overrides Sub LoadChildrenData(Optional ByVal blnReset As Boolean = False)
	End Sub
		
    Private Sub frmclscityairport_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
