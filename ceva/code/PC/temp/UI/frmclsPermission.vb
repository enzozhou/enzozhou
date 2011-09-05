Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclsPermissionBase__
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
        Protected Friend WithEvents txtright_no As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblright_no As System.Windows.Forms.Label
    Protected Friend WithEvents txtdescription As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldescription As System.Windows.Forms.Label
    Protected Friend WithEvents txttrans_type As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbltrans_type As System.Windows.Forms.Label
    Protected Friend WithEvents txtdoc_type As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldoc_type As System.Windows.Forms.Label
    Protected Friend WithEvents txtcmd_type As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblcmd_type As System.Windows.Forms.Label
    Protected Friend WithEvents txtremark As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblremark As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_by As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_by As System.Windows.Forms.Label
    Protected Friend WithEvents dtpopt_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblopt_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_timestamp As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_timestamp As System.Windows.Forms.Label
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtright_no = New System.Windows.Forms.TextBox()
        Me.lblright_no = New System.Windows.Forms.Label()
        Me.txtdescription = New System.Windows.Forms.TextBox()
        Me.lbldescription = New System.Windows.Forms.Label()
        Me.txttrans_type = New System.Windows.Forms.TextBox()
        Me.lbltrans_type = New System.Windows.Forms.Label()
        Me.txtdoc_type = New System.Windows.Forms.TextBox()
        Me.lbldoc_type = New System.Windows.Forms.Label()
        Me.txtcmd_type = New System.Windows.Forms.TextBox()
        Me.lblcmd_type = New System.Windows.Forms.Label()
        Me.txtremark = New System.Windows.Forms.TextBox()
        Me.lblremark = New System.Windows.Forms.Label()
        Me.txtopt_by = New System.Windows.Forms.TextBox()
        Me.lblopt_by = New System.Windows.Forms.Label()
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblopt_dtime = New System.Windows.Forms.Label()
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox()
        Me.lblopt_timestamp = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()


        Me.SuspendLayout()
        'txtright_no
        '
        Me.txtright_no.Location = New System.Drawing.Point(138, 10)
        Me.txtright_no.Name = "txtright_no"
        Me.txtright_no.Size = New System.Drawing.Size(225, 21)
        Me.txtright_no.TabIndex = 2
        'lblright_no
        '
        Me.lblright_no.BackColor = System.Drawing.Color.Transparent
        Me.lblright_no.Location = New System.Drawing.Point(10, 12)
        Me.lblright_no.Name = "lblright_no"
        Me.lblright_no.Size = New System.Drawing.Size(121, 17)
        Me.lblright_no.TabIndex = 1
        Me.lblright_no.Text = "right_no"
        'txtdescription
        '
        Me.txtdescription.Location = New System.Drawing.Point(138, 32)
        Me.txtdescription.Name = "txtdescription"
        Me.txtdescription.Size = New System.Drawing.Size(225, 21)
        Me.txtdescription.TabIndex = 4
        'lbldescription
        '
        Me.lbldescription.BackColor = System.Drawing.Color.Transparent
        Me.lbldescription.Location = New System.Drawing.Point(10, 34)
        Me.lbldescription.Name = "lbldescription"
        Me.lbldescription.Size = New System.Drawing.Size(121, 17)
        Me.lbldescription.TabIndex = 3
        Me.lbldescription.Text = "description"
        'txttrans_type
        '
        Me.txttrans_type.Location = New System.Drawing.Point(138, 53)
        Me.txttrans_type.Name = "txttrans_type"
        Me.txttrans_type.Size = New System.Drawing.Size(225, 21)
        Me.txttrans_type.TabIndex = 6
        'lbltrans_type
        '
        Me.lbltrans_type.BackColor = System.Drawing.Color.Transparent
        Me.lbltrans_type.Location = New System.Drawing.Point(10, 56)
        Me.lbltrans_type.Name = "lbltrans_type"
        Me.lbltrans_type.Size = New System.Drawing.Size(121, 17)
        Me.lbltrans_type.TabIndex = 5
        Me.lbltrans_type.Text = "trans_type"
        'txtdoc_type
        '
        Me.txtdoc_type.Location = New System.Drawing.Point(138, 75)
        Me.txtdoc_type.Name = "txtdoc_type"
        Me.txtdoc_type.Size = New System.Drawing.Size(225, 21)
        Me.txtdoc_type.TabIndex = 8
        'lbldoc_type
        '
        Me.lbldoc_type.BackColor = System.Drawing.Color.Transparent
        Me.lbldoc_type.Location = New System.Drawing.Point(10, 77)
        Me.lbldoc_type.Name = "lbldoc_type"
        Me.lbldoc_type.Size = New System.Drawing.Size(121, 17)
        Me.lbldoc_type.TabIndex = 7
        Me.lbldoc_type.Text = "doc_type"
        'txtcmd_type
        '
        Me.txtcmd_type.Location = New System.Drawing.Point(138, 97)
        Me.txtcmd_type.Name = "txtcmd_type"
        Me.txtcmd_type.Size = New System.Drawing.Size(225, 21)
        Me.txtcmd_type.TabIndex = 10
        'lblcmd_type
        '
        Me.lblcmd_type.BackColor = System.Drawing.Color.Transparent
        Me.lblcmd_type.Location = New System.Drawing.Point(10, 99)
        Me.lblcmd_type.Name = "lblcmd_type"
        Me.lblcmd_type.Size = New System.Drawing.Size(121, 17)
        Me.lblcmd_type.TabIndex = 9
        Me.lblcmd_type.Text = "cmd_type"
        'txtremark
        '
        Me.txtremark.Location = New System.Drawing.Point(138, 118)
        Me.txtremark.Name = "txtremark"
        Me.txtremark.Size = New System.Drawing.Size(225, 21)
        Me.txtremark.TabIndex = 12
        'lblremark
        '
        Me.lblremark.BackColor = System.Drawing.Color.Transparent
        Me.lblremark.Location = New System.Drawing.Point(10, 121)
        Me.lblremark.Name = "lblremark"
        Me.lblremark.Size = New System.Drawing.Size(121, 17)
        Me.lblremark.TabIndex = 11
        Me.lblremark.Text = "remark"
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(138, 140)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(225, 21)
        Me.txtopt_by.TabIndex = 14
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(10, 142)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_by.TabIndex = 13
        Me.lblopt_by.Text = "opt_by"
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(138, 162)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.Size = New System.Drawing.Size(225, 21)
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.TabIndex = 16
        Me.dtpopt_dtime.Format = DateTimePickerFormat.Long
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(10, 164)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(121, 17)
        Me.lblopt_dtime.TabIndex = 15
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
        Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtright_no, Me.lblright_no, Me.txtdescription, Me.lbldescription, Me.txttrans_type, Me.lbltrans_type, Me.txtdoc_type, Me.lbldoc_type, Me.txtcmd_type, Me.lblcmd_type, Me.txtremark, Me.lblremark, Me.txtopt_by, Me.lblopt_by, Me.dtpopt_dtime, Me.lblopt_dtime, Me.txtopt_timestamp, Me.lblopt_timestamp})
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(392, 264)
        Me.pnlMain.TabIndex = 0
        Me.pnlMain.TabStop = False
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill

        '
        'frmclsPermission
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.AutoScroll = True
        Me.WindowState = FormWindowState.Maximized
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlMain})
        Me.Font = New System.Drawing.Font("΢���ź�", 9.0, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "clsPermission"
        Me.Text = "2369"

        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clsPermission = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtright_no, "Text", objBO, "right_no")
            BindField(Me.txtdescription, "Text", objBO, "description")
            BindField(Me.txttrans_type, "Text", objBO, "trans_type")
            BindField(Me.txtdoc_type, "Text", objBO, "doc_type")
            BindField(Me.txtcmd_type, "Text", objBO, "cmd_type")
            BindField(Me.txtremark, "Text", objBO, "remark")
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
        	MyBase.FormatControl(txtright_no, "right_no", lblright_no, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtdescription, "description", lbldescription, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txttrans_type, "trans_type", lbltrans_type, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtdoc_type, "doc_type", lbldoc_type, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtcmd_type, "cmd_type", lblcmd_type, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtremark, "remark", lblremark, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtopt_by, "opt_by", lblopt_by, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        Me.LoadLayout()
        Catch ThisException As Exception
        	ErrorMsg(ThisException, Me.GetType, "Format")
        End Try        
    End Sub
    
    
    Protected Overrides Sub LoadChildrenData(Optional ByVal blnReset As Boolean = False)
	End Sub
		
    Private Sub frmclsPermission_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
