Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclsRoleBase__
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
    Protected Friend WithEvents txtrole_code As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblrole_code As System.Windows.Forms.Label
    Protected Friend WithEvents txtrole_name As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblrole_name As System.Windows.Forms.Label
    Protected Friend WithEvents txtremark As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblremark As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_by As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_by As System.Windows.Forms.Label
    Protected Friend WithEvents dtpopt_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblopt_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_timestamp As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_timestamp As System.Windows.Forms.Label
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Protected Friend WithEvents tp__clsRolepermission As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsRolepermission As YTUI.DataGrid
    Protected Friend WithEvents tp__clsUserrole As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsUserrole As YTUI.DataGrid
    Protected Friend WithEvents tabGrid As System.Windows.Forms.TabControl

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.splMain = New System.Windows.Forms.Splitter()
        Me.txtrole_code = New System.Windows.Forms.TextBox()
        Me.lblrole_code = New System.Windows.Forms.Label()
        Me.txtrole_name = New System.Windows.Forms.TextBox()
        Me.lblrole_name = New System.Windows.Forms.Label()
        Me.txtremark = New System.Windows.Forms.TextBox()
        Me.lblremark = New System.Windows.Forms.Label()
        Me.txtopt_by = New System.Windows.Forms.TextBox()
        Me.lblopt_by = New System.Windows.Forms.Label()
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker()
        Me.lblopt_dtime = New System.Windows.Forms.Label()
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox()
        Me.lblopt_timestamp = New System.Windows.Forms.Label()
        Me.pnlMain = New System.Windows.Forms.Panel()
        Me.gd__clsRolepermission = New YTUI.DataGrid()
        Me.tp__clsRolepermission = New System.Windows.Forms.TabPage()
        Me.gd__clsUserrole = New YTUI.DataGrid()
        Me.tp__clsUserrole = New System.Windows.Forms.TabPage()
        Me.tabGrid = New System.Windows.Forms.TabControl()

        CType(Me.gd__clsRolepermission, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gd__clsUserrole, System.ComponentModel.ISupportInitialize).BeginInit()

        Me.SuspendLayout()
        'splMain
        '
        Me.splMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.splMain.Location = New System.Drawing.Point(0, 264)
        Me.splMain.Name = "splMain"
        Me.splMain.Size = New System.Drawing.Size(480, 8)
        Me.splMain.TabStop = False
        'txtrole_code
        '
        Me.txtrole_code.Location = New System.Drawing.Point(138, 10)
        Me.txtrole_code.Name = "txtrole_code"
        Me.txtrole_code.Size = New System.Drawing.Size(225, 21)
        Me.txtrole_code.TabIndex = 2
        'lblrole_code
        '
        Me.lblrole_code.BackColor = System.Drawing.Color.Transparent
        Me.lblrole_code.Location = New System.Drawing.Point(10, 12)
        Me.lblrole_code.Name = "lblrole_code"
        Me.lblrole_code.Size = New System.Drawing.Size(121, 17)
        Me.lblrole_code.TabIndex = 1
        Me.lblrole_code.Text = "role_code"
        'txtrole_name
        '
        Me.txtrole_name.Location = New System.Drawing.Point(138, 32)
        Me.txtrole_name.Name = "txtrole_name"
        Me.txtrole_name.Size = New System.Drawing.Size(225, 21)
        Me.txtrole_name.TabIndex = 4
        'lblrole_name
        '
        Me.lblrole_name.BackColor = System.Drawing.Color.Transparent
        Me.lblrole_name.Location = New System.Drawing.Point(10, 34)
        Me.lblrole_name.Name = "lblrole_name"
        Me.lblrole_name.Size = New System.Drawing.Size(121, 17)
        Me.lblrole_name.TabIndex = 3
        Me.lblrole_name.Text = "role_name"
        'txtremark
        '
        Me.txtremark.Location = New System.Drawing.Point(138, 53)
        Me.txtremark.Name = "txtremark"
        Me.txtremark.Size = New System.Drawing.Size(225, 21)
        Me.txtremark.TabIndex = 6
        'lblremark
        '
        Me.lblremark.BackColor = System.Drawing.Color.Transparent
        Me.lblremark.Location = New System.Drawing.Point(10, 56)
        Me.lblremark.Name = "lblremark"
        Me.lblremark.Size = New System.Drawing.Size(121, 17)
        Me.lblremark.TabIndex = 5
        Me.lblremark.Text = "remark"
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
        Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtrole_code, Me.lblrole_code, Me.txtrole_name, Me.lblrole_name, Me.txtremark, Me.lblremark, Me.txtopt_by, Me.lblopt_by, Me.dtpopt_dtime, Me.lblopt_dtime, Me.txtopt_timestamp, Me.lblopt_timestamp})
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(392, 264)
        Me.pnlMain.TabIndex = 0
        Me.pnlMain.TabStop = False
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top

        Me.gd__clsRolepermission.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsRolepermission.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsRolepermission.Name = "Me.gd__clsRolepermission"
        Me.gd__clsRolepermission.Size = New System.Drawing.Size(552, 116)
        Me.gd__clsRolepermission.TabIndex = 12
        'tp__clsRolepermission
        '        
        Me.tp__clsRolepermission.Controls.AddRange(New System.Windows.Forms.Control() {Me.gd__clsRolepermission})
        Me.tp__clsRolepermission.Location = New System.Drawing.Point(0, 0)
        Me.tp__clsRolepermission.Name = "tp__clsRolepermission"
        Me.tp__clsRolepermission.Size = New System.Drawing.Size(392, 264)
        Me.tp__clsRolepermission.TabIndex = 0
        Me.tp__clsRolepermission.Text = "clsRolepermissions"
        Me.tp__clsRolepermission.AutoScroll = True

        Me.gd__clsUserrole.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsUserrole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsUserrole.Name = "Me.gd__clsUserrole"
        Me.gd__clsUserrole.Size = New System.Drawing.Size(552, 116)
        Me.gd__clsUserrole.TabIndex = 13
        'tp__clsUserrole
        '        
        Me.tp__clsUserrole.Controls.AddRange(New System.Windows.Forms.Control() {Me.gd__clsUserrole})
        Me.tp__clsUserrole.Location = New System.Drawing.Point(0, 0)
        Me.tp__clsUserrole.Name = "tp__clsUserrole"
        Me.tp__clsUserrole.Size = New System.Drawing.Size(392, 264)
        Me.tp__clsUserrole.TabIndex = 0
        Me.tp__clsUserrole.Text = "clsUserroles"
        Me.tp__clsUserrole.AutoScroll = True
        'tabGrid
        '        
        Me.tabGrid.Controls.AddRange(New System.Windows.Forms.Control() {Me.tp__clsRolepermission, Me.tp__clsUserrole})
        Me.tabGrid.Location = New System.Drawing.Point(0, 0)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.SelectedIndex = 0
        Me.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrid.Size = New System.Drawing.Size(392, 264)
        Me.tabGrid.TabIndex = 11
		 Me.tabGrid.Alignment = System.Windows.Forms.TabAlignment.Bottom
        '
        'frmclsRole
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.AutoScroll = True
        Me.WindowState = FormWindowState.Maximized
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabGrid, Me.splMain, Me.pnlMain})
        Me.Font = New System.Drawing.Font("Î¢ÈíÑÅºÚ", 9.0, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "clsRole"
        Me.Text = "2380"
        CType(Me.gd__clsRolepermission, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gd__clsUserrole, System.ComponentModel.ISupportInitialize).EndInit()

        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clsRole = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtrole_code, "Text", objBO, "role_code")
            BindField(Me.txtrole_name, "Text", objBO, "role_name")
            BindField(Me.txtremark, "Text", objBO, "remark")
            BindField(Me.txtopt_by, "Text", objBO, "opt_by")
            BindField(Me.dtpopt_dtime, "Text", objBO, "opt_dtime")
            CType(Me.gd__clsRolepermission, IGrid).DataSource = objBO.clsRolepermissions
            CType(Me.gd__clsUserrole, IGrid).DataSource = objBO.clsUserroles
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "DataBind")
        End Try
    End Sub

    Protected Overrides Sub UpdateControlEditStatus()
    	Me.FormatControlEditStatus()
    	Me.SetChildGridEditMode(Me.gd__clsRolepermission)
    	Me.SetChildGridEditMode(Me.gd__clsUserrole)
    End Sub
    
    Public Overrides Sub Format()
    	try
        	MyBase.Format()
        	MyBase.FormatControl(txtrole_code, "role_code", lblrole_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtrole_name, "role_name", lblrole_name, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtremark, "remark", lblremark, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtopt_by, "opt_by", lblopt_by, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
    		Me.tp__clsRolepermission.Text = mobjapp.GetLayout.CXObjectLays(GetType(clsRolepermission).Name).ColCaptionText
        	CType(Me.gd__clsRolepermission, IGrid).FormatGrid()
    		Me.tp__clsUserrole.Text = mobjapp.GetLayout.CXObjectLays(GetType(clsUserrole).Name).ColCaptionText
        	CType(Me.gd__clsUserrole, IGrid).FormatGrid()
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
    	CType(Current, clsRole).LoadclsRolepermissions(blnReset)
    	CType(Current, clsRole).LoadclsUserroles(blnReset)
	End Sub
		
    Private Sub frmclsRole_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
