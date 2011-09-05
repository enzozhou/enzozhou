Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclsTRLOGBase__
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
        Protected Friend WithEvents txtlog_id As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbllog_id As System.Windows.Forms.Label
    Protected Friend WithEvents txttrans_type As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbltrans_type As System.Windows.Forms.Label
    Protected Friend WithEvents txtcmd_type As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblcmd_type As System.Windows.Forms.Label
    Protected Friend WithEvents txtdoc_no As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldoc_no As System.Windows.Forms.Label
    Protected Friend WithEvents txtLINENUM As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblLINENUM As System.Windows.Forms.Label
    Protected Friend WithEvents txtSTCD As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblSTCD As System.Windows.Forms.Label
    Protected Friend WithEvents txtITEMNO As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblITEMNO As System.Windows.Forms.Label
    Protected Friend WithEvents txtITEM_DESC As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblITEM_DESC As System.Windows.Forms.Label
    Protected Friend WithEvents txtBANTCH As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblBANTCH As System.Windows.Forms.Label
    Protected Friend WithEvents txtQTY As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblQTY As System.Windows.Forms.Label
    Protected Friend WithEvents txtstatus As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblstatus As System.Windows.Forms.Label
    Protected Friend WithEvents txtreason As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblreason As System.Windows.Forms.Label
    Protected Friend WithEvents txtreasonDesc As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblreasonDesc As System.Windows.Forms.Label
    Protected Friend WithEvents txtOPT_BY As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblOPT_BY As System.Windows.Forms.Label
    Protected Friend WithEvents txtOPT_ADDR As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblOPT_ADDR As System.Windows.Forms.Label
    Protected Friend WithEvents dtpOPT_DATE As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblOPT_DATE As System.Windows.Forms.Label
    Protected Friend WithEvents txtOPT_TIMESTAMP As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblOPT_TIMESTAMP As System.Windows.Forms.Label
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtlog_id = New System.Windows.Forms.TextBox()
        Me.lbllog_id = New System.Windows.Forms.Label()
        Me.txttrans_type = New System.Windows.Forms.TextBox()
        Me.lbltrans_type = New System.Windows.Forms.Label()
        Me.txtcmd_type = New System.Windows.Forms.TextBox()
        Me.lblcmd_type = New System.Windows.Forms.Label()
        Me.txtdoc_no = New System.Windows.Forms.TextBox()
        Me.lbldoc_no = New System.Windows.Forms.Label()
        Me.txtLINENUM = New System.Windows.Forms.TextBox()
        Me.lblLINENUM = New System.Windows.Forms.Label()
        Me.txtSTCD = New System.Windows.Forms.TextBox()
        Me.lblSTCD = New System.Windows.Forms.Label()
        Me.txtITEMNO = New System.Windows.Forms.TextBox()
        Me.lblITEMNO = New System.Windows.Forms.Label()
        Me.txtITEM_DESC = New System.Windows.Forms.TextBox()
        Me.lblITEM_DESC = New System.Windows.Forms.Label()
        Me.txtBANTCH = New System.Windows.Forms.TextBox()
        Me.lblBANTCH = New System.Windows.Forms.Label()
        Me.txtQTY = New System.Windows.Forms.TextBox()
        Me.lblQTY = New System.Windows.Forms.Label()
        Me.txtstatus = New System.Windows.Forms.TextBox()
        Me.lblstatus = New System.Windows.Forms.Label()
        Me.txtreason = New System.Windows.Forms.TextBox()
        Me.lblreason = New System.Windows.Forms.Label()
        Me.txtreasonDesc = New System.Windows.Forms.TextBox()
        Me.lblreasonDesc = New System.Windows.Forms.Label()
        Me.txtOPT_BY = New System.Windows.Forms.TextBox()
        Me.lblOPT_BY = New System.Windows.Forms.Label()
        Me.txtOPT_ADDR = New System.Windows.Forms.TextBox()
        Me.lblOPT_ADDR = New System.Windows.Forms.Label()
        Me.dtpOPT_DATE = New System.Windows.Forms.DateTimePicker()
        Me.lblOPT_DATE = New System.Windows.Forms.Label()
        Me.txtOPT_TIMESTAMP = New System.Windows.Forms.TextBox()
        Me.lblOPT_TIMESTAMP = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()


        Me.SuspendLayout()
        'txtlog_id
        '
        Me.txtlog_id.Location = New System.Drawing.Point(138, 10)
        Me.txtlog_id.Name = "txtlog_id"
        Me.txtlog_id.Size = New System.Drawing.Size(225, 21)
        Me.txtlog_id.TabIndex = 2
        'lbllog_id
        '
        Me.lbllog_id.BackColor = System.Drawing.Color.Transparent
        Me.lbllog_id.Location = New System.Drawing.Point(10, 12)
        Me.lbllog_id.Name = "lbllog_id"
        Me.lbllog_id.Size = New System.Drawing.Size(121, 17)
        Me.lbllog_id.TabIndex = 1
        Me.lbllog_id.Text = "log_id"
        'txttrans_type
        '
        Me.txttrans_type.Location = New System.Drawing.Point(138, 32)
        Me.txttrans_type.Name = "txttrans_type"
        Me.txttrans_type.Size = New System.Drawing.Size(225, 21)
        Me.txttrans_type.TabIndex = 4
        'lbltrans_type
        '
        Me.lbltrans_type.BackColor = System.Drawing.Color.Transparent
        Me.lbltrans_type.Location = New System.Drawing.Point(10, 34)
        Me.lbltrans_type.Name = "lbltrans_type"
        Me.lbltrans_type.Size = New System.Drawing.Size(121, 17)
        Me.lbltrans_type.TabIndex = 3
        Me.lbltrans_type.Text = "trans_type"
        'txtcmd_type
        '
        Me.txtcmd_type.Location = New System.Drawing.Point(138, 53)
        Me.txtcmd_type.Name = "txtcmd_type"
        Me.txtcmd_type.Size = New System.Drawing.Size(225, 21)
        Me.txtcmd_type.TabIndex = 6
        'lblcmd_type
        '
        Me.lblcmd_type.BackColor = System.Drawing.Color.Transparent
        Me.lblcmd_type.Location = New System.Drawing.Point(10, 56)
        Me.lblcmd_type.Name = "lblcmd_type"
        Me.lblcmd_type.Size = New System.Drawing.Size(121, 17)
        Me.lblcmd_type.TabIndex = 5
        Me.lblcmd_type.Text = "cmd_type"
        'txtdoc_no
        '
        Me.txtdoc_no.Location = New System.Drawing.Point(138, 75)
        Me.txtdoc_no.Name = "txtdoc_no"
        Me.txtdoc_no.Size = New System.Drawing.Size(225, 21)
        Me.txtdoc_no.TabIndex = 8
        'lbldoc_no
        '
        Me.lbldoc_no.BackColor = System.Drawing.Color.Transparent
        Me.lbldoc_no.Location = New System.Drawing.Point(10, 77)
        Me.lbldoc_no.Name = "lbldoc_no"
        Me.lbldoc_no.Size = New System.Drawing.Size(121, 17)
        Me.lbldoc_no.TabIndex = 7
        Me.lbldoc_no.Text = "doc_no"
        'txtLINENUM
        '
        Me.txtLINENUM.Location = New System.Drawing.Point(138, 97)
        Me.txtLINENUM.Name = "txtLINENUM"
        Me.txtLINENUM.Size = New System.Drawing.Size(225, 21)
        Me.txtLINENUM.TabIndex = 10
        'lblLINENUM
        '
        Me.lblLINENUM.BackColor = System.Drawing.Color.Transparent
        Me.lblLINENUM.Location = New System.Drawing.Point(10, 99)
        Me.lblLINENUM.Name = "lblLINENUM"
        Me.lblLINENUM.Size = New System.Drawing.Size(121, 17)
        Me.lblLINENUM.TabIndex = 9
        Me.lblLINENUM.Text = "LINENUM"
        'txtSTCD
        '
        Me.txtSTCD.Location = New System.Drawing.Point(138, 118)
        Me.txtSTCD.Name = "txtSTCD"
        Me.txtSTCD.Size = New System.Drawing.Size(225, 21)
        Me.txtSTCD.TabIndex = 12
        'lblSTCD
        '
        Me.lblSTCD.BackColor = System.Drawing.Color.Transparent
        Me.lblSTCD.Location = New System.Drawing.Point(10, 121)
        Me.lblSTCD.Name = "lblSTCD"
        Me.lblSTCD.Size = New System.Drawing.Size(121, 17)
        Me.lblSTCD.TabIndex = 11
        Me.lblSTCD.Text = "STCD"
        'txtITEMNO
        '
        Me.txtITEMNO.Location = New System.Drawing.Point(138, 140)
        Me.txtITEMNO.Name = "txtITEMNO"
        Me.txtITEMNO.Size = New System.Drawing.Size(225, 21)
        Me.txtITEMNO.TabIndex = 14
        'lblITEMNO
        '
        Me.lblITEMNO.BackColor = System.Drawing.Color.Transparent
        Me.lblITEMNO.Location = New System.Drawing.Point(10, 142)
        Me.lblITEMNO.Name = "lblITEMNO"
        Me.lblITEMNO.Size = New System.Drawing.Size(121, 17)
        Me.lblITEMNO.TabIndex = 13
        Me.lblITEMNO.Text = "ITEMNO"
        'txtITEM_DESC
        '
        Me.txtITEM_DESC.Location = New System.Drawing.Point(138, 162)
        Me.txtITEM_DESC.Name = "txtITEM_DESC"
        Me.txtITEM_DESC.Size = New System.Drawing.Size(225, 21)
        Me.txtITEM_DESC.TabIndex = 16
        'lblITEM_DESC
        '
        Me.lblITEM_DESC.BackColor = System.Drawing.Color.Transparent
        Me.lblITEM_DESC.Location = New System.Drawing.Point(10, 164)
        Me.lblITEM_DESC.Name = "lblITEM_DESC"
        Me.lblITEM_DESC.Size = New System.Drawing.Size(121, 17)
        Me.lblITEM_DESC.TabIndex = 15
        Me.lblITEM_DESC.Text = "ITEM_DESC"
        'txtBANTCH
        '
        Me.txtBANTCH.Location = New System.Drawing.Point(138, 183)
        Me.txtBANTCH.Name = "txtBANTCH"
        Me.txtBANTCH.Size = New System.Drawing.Size(225, 21)
        Me.txtBANTCH.TabIndex = 18
        'lblBANTCH
        '
        Me.lblBANTCH.BackColor = System.Drawing.Color.Transparent
        Me.lblBANTCH.Location = New System.Drawing.Point(10, 186)
        Me.lblBANTCH.Name = "lblBANTCH"
        Me.lblBANTCH.Size = New System.Drawing.Size(121, 17)
        Me.lblBANTCH.TabIndex = 17
        Me.lblBANTCH.Text = "BANTCH"
        'txtQTY
        '
        Me.txtQTY.Location = New System.Drawing.Point(138, 205)
        Me.txtQTY.Name = "txtQTY"
        Me.txtQTY.Size = New System.Drawing.Size(225, 21)
        Me.txtQTY.TabIndex = 20
        'lblQTY
        '
        Me.lblQTY.BackColor = System.Drawing.Color.Transparent
        Me.lblQTY.Location = New System.Drawing.Point(10, 207)
        Me.lblQTY.Name = "lblQTY"
        Me.lblQTY.Size = New System.Drawing.Size(121, 17)
        Me.lblQTY.TabIndex = 19
        Me.lblQTY.Text = "QTY"
        'txtstatus
        '
        Me.txtstatus.Location = New System.Drawing.Point(138, 227)
        Me.txtstatus.Name = "txtstatus"
        Me.txtstatus.Size = New System.Drawing.Size(225, 21)
        Me.txtstatus.TabIndex = 22
        'lblstatus
        '
        Me.lblstatus.BackColor = System.Drawing.Color.Transparent
        Me.lblstatus.Location = New System.Drawing.Point(10, 229)
        Me.lblstatus.Name = "lblstatus"
        Me.lblstatus.Size = New System.Drawing.Size(121, 17)
        Me.lblstatus.TabIndex = 21
        Me.lblstatus.Text = "status"
        'txtreason
        '
        Me.txtreason.Location = New System.Drawing.Point(138, 248)
        Me.txtreason.Name = "txtreason"
        Me.txtreason.Size = New System.Drawing.Size(225, 21)
        Me.txtreason.TabIndex = 24
        'lblreason
        '
        Me.lblreason.BackColor = System.Drawing.Color.Transparent
        Me.lblreason.Location = New System.Drawing.Point(10, 251)
        Me.lblreason.Name = "lblreason"
        Me.lblreason.Size = New System.Drawing.Size(121, 17)
        Me.lblreason.TabIndex = 23
        Me.lblreason.Text = "reason"
        'txtreasonDesc
        '
        Me.txtreasonDesc.Location = New System.Drawing.Point(138, 270)
        Me.txtreasonDesc.Name = "txtreasonDesc"
        Me.txtreasonDesc.Size = New System.Drawing.Size(225, 21)
        Me.txtreasonDesc.TabIndex = 26
        'lblreasonDesc
        '
        Me.lblreasonDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblreasonDesc.Location = New System.Drawing.Point(10, 272)
        Me.lblreasonDesc.Name = "lblreasonDesc"
        Me.lblreasonDesc.Size = New System.Drawing.Size(121, 17)
        Me.lblreasonDesc.TabIndex = 25
        Me.lblreasonDesc.Text = "%%CONTROL_CAPTION%%"
        'txtOPT_BY
        '
        Me.txtOPT_BY.Location = New System.Drawing.Point(138, 292)
        Me.txtOPT_BY.Name = "txtOPT_BY"
        Me.txtOPT_BY.Size = New System.Drawing.Size(225, 21)
        Me.txtOPT_BY.TabIndex = 28
        'lblOPT_BY
        '
        Me.lblOPT_BY.BackColor = System.Drawing.Color.Transparent
        Me.lblOPT_BY.Location = New System.Drawing.Point(10, 294)
        Me.lblOPT_BY.Name = "lblOPT_BY"
        Me.lblOPT_BY.Size = New System.Drawing.Size(121, 17)
        Me.lblOPT_BY.TabIndex = 27
        Me.lblOPT_BY.Text = "OPT_BY"
        'txtOPT_ADDR
        '
        Me.txtOPT_ADDR.Location = New System.Drawing.Point(138, 313)
        Me.txtOPT_ADDR.Name = "txtOPT_ADDR"
        Me.txtOPT_ADDR.Size = New System.Drawing.Size(225, 21)
        Me.txtOPT_ADDR.TabIndex = 30
        'lblOPT_ADDR
        '
        Me.lblOPT_ADDR.BackColor = System.Drawing.Color.Transparent
        Me.lblOPT_ADDR.Location = New System.Drawing.Point(10, 316)
        Me.lblOPT_ADDR.Name = "lblOPT_ADDR"
        Me.lblOPT_ADDR.Size = New System.Drawing.Size(121, 17)
        Me.lblOPT_ADDR.TabIndex = 29
        Me.lblOPT_ADDR.Text = "OPT_ADDR"
        'dtpOPT_DATE
        '
        Me.dtpOPT_DATE.Location = New System.Drawing.Point(138, 335)
        Me.dtpOPT_DATE.Name = "dtpOPT_DATE"
        Me.dtpOPT_DATE.Size = New System.Drawing.Size(225, 21)
        Me.dtpOPT_DATE.ShowCheckBox = True
        Me.dtpOPT_DATE.TabIndex = 32
        Me.dtpOPT_DATE.Format = DateTimePickerFormat.Long
        'lblOPT_DATE
        '
        Me.lblOPT_DATE.BackColor = System.Drawing.Color.Transparent
        Me.lblOPT_DATE.Location = New System.Drawing.Point(10, 337)
        Me.lblOPT_DATE.Name = "lblOPT_DATE"
        Me.lblOPT_DATE.Size = New System.Drawing.Size(121, 17)
        Me.lblOPT_DATE.TabIndex = 31
        Me.lblOPT_DATE.Text = "OPT_DATE"
        'txtOPT_TIMESTAMP
        '
        Me.txtOPT_TIMESTAMP.Location = New System.Drawing.Point(0, 0)
        Me.txtOPT_TIMESTAMP.Name = "txtOPT_TIMESTAMP"
        Me.txtOPT_TIMESTAMP.Size = New System.Drawing.Size(0, 0)
        Me.txtOPT_TIMESTAMP.TabIndex = 0
        'lblOPT_TIMESTAMP
        '
        Me.lblOPT_TIMESTAMP.BackColor = System.Drawing.Color.Transparent
        Me.lblOPT_TIMESTAMP.Location = New System.Drawing.Point(0, 0)
        Me.lblOPT_TIMESTAMP.Name = "lblOPT_TIMESTAMP"
        Me.lblOPT_TIMESTAMP.Size = New System.Drawing.Size(0, 0)
        Me.lblOPT_TIMESTAMP.TabIndex = 0
        Me.lblOPT_TIMESTAMP.Text = "OPT_TIMESTAMP"
        'pnlMain
        '
        Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtlog_id, Me.lbllog_id, Me.txttrans_type, Me.lbltrans_type, Me.txtcmd_type, Me.lblcmd_type, Me.txtdoc_no, Me.lbldoc_no, Me.txtLINENUM, Me.lblLINENUM, Me.txtSTCD, Me.lblSTCD, Me.txtITEMNO, Me.lblITEMNO, Me.txtITEM_DESC, Me.lblITEM_DESC, Me.txtBANTCH, Me.lblBANTCH, Me.txtQTY, Me.lblQTY, Me.txtstatus, Me.lblstatus, Me.txtreason, Me.lblreason, Me.txtreasonDesc, Me.lblreasonDesc, Me.txtOPT_BY, Me.lblOPT_BY, Me.txtOPT_ADDR, Me.lblOPT_ADDR, Me.dtpOPT_DATE, Me.lblOPT_DATE, Me.txtOPT_TIMESTAMP, Me.lblOPT_TIMESTAMP})
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(392, 264)
        Me.pnlMain.TabIndex = 0
        Me.pnlMain.TabStop = False
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill

        '
        'frmclsTRLOG
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.AutoScroll = True
        Me.WindowState = FormWindowState.Maximized
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlMain})
        Me.Font = New System.Drawing.Font("Î¢ÈíÑÅºÚ", 9.0, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "clsTRLOG"
        Me.Text = "2412"

        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clsTRLOG = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtlog_id, "Text", objBO, "log_id")
            BindField(Me.txttrans_type, "Text", objBO, "trans_type")
            BindField(Me.txtcmd_type, "Text", objBO, "cmd_type")
            BindField(Me.txtdoc_no, "Text", objBO, "doc_no")
            BindField(Me.txtLINENUM, "Text", objBO, "LINENUM")
            BindField(Me.txtSTCD, "Text", objBO, "STCD")
            BindField(Me.txtITEMNO, "Text", objBO, "ITEMNO")
            BindField(Me.txtITEM_DESC, "Text", objBO, "ITEM_DESC")
            BindField(Me.txtBANTCH, "Text", objBO, "BANTCH")
            BindField(Me.txtQTY, "Text", objBO, "QTY")
            BindField(Me.txtstatus, "Text", objBO, "status")
            BindField(Me.txtreason, "Text", objBO, "reason")
            BindField(Me.txtreasonDesc, "Text", objBO, "reasonDesc")
            BindField(Me.txtOPT_BY, "Text", objBO, "OPT_BY")
            BindField(Me.txtOPT_ADDR, "Text", objBO, "OPT_ADDR")
            BindField(Me.dtpOPT_DATE, "Text", objBO, "OPT_DATE")
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
        	MyBase.FormatControl(txtlog_id, "log_id", lbllog_id, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txttrans_type, "trans_type", lbltrans_type, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtcmd_type, "cmd_type", lblcmd_type, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtdoc_no, "doc_no", lbldoc_no, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtLINENUM, "LINENUM", lblLINENUM, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtSTCD, "STCD", lblSTCD, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtITEMNO, "ITEMNO", lblITEMNO, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtITEM_DESC, "ITEM_DESC", lblITEM_DESC, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtBANTCH, "BANTCH", lblBANTCH, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtQTY, "QTY", lblQTY, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtstatus, "status", lblstatus, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtreason, "reason", lblreason, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtreasonDesc, "reasonDesc", lblreasonDesc, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtOPT_BY, "OPT_BY", lblOPT_BY, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtOPT_ADDR, "OPT_ADDR", lblOPT_ADDR, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpOPT_DATE, "OPT_DATE", lblOPT_DATE, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        Me.LoadLayout()
        Catch ThisException As Exception
        	ErrorMsg(ThisException, Me.GetType, "Format")
        End Try        
    End Sub
    
    
    Protected Overrides Sub LoadChildrenData(Optional ByVal blnReset As Boolean = False)
	End Sub
		
    Private Sub frmclsTRLOG_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
