Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclsUserroleBase__
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
        Protected Friend WithEvents txtuser_code As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbluser_code As System.Windows.Forms.Label
    Protected Friend WithEvents txtrole_code As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblrole_code As System.Windows.Forms.Label
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
        Me.txtuser_code = New System.Windows.Forms.TextBox
        Me.lbluser_code = New System.Windows.Forms.Label
        Me.txtrole_code = New System.Windows.Forms.TextBox
        Me.lblrole_code = New System.Windows.Forms.Label
        Me.txtremark = New System.Windows.Forms.TextBox
        Me.lblremark = New System.Windows.Forms.Label
        Me.txtopt_by = New System.Windows.Forms.TextBox
        Me.lblopt_by = New System.Windows.Forms.Label
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker
        Me.lblopt_dtime = New System.Windows.Forms.Label
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox
        Me.lblopt_timestamp = New System.Windows.Forms.Label
        Me.pnlMain = New System.Windows.Forms.Panel
        CType(Me.ErrorPrvd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkIsDirty
        '
        Me.chkIsDirty.Location = New System.Drawing.Point(-47, -79)
        Me.chkIsDirty.Size = New System.Drawing.Size(4, 6)
        '
        'CQ
        '
        Me.CQ.Size = New System.Drawing.Size(560, 25)
        '
        'CB
        '
        Me.CB.Location = New System.Drawing.Point(0, 25)
        Me.CB.Size = New System.Drawing.Size(560, 25)
        '
        'txtuser_code
        '
        Me.txtuser_code.Location = New System.Drawing.Point(166, 33)
        Me.txtuser_code.Name = "txtuser_code"
        Me.txtuser_code.Size = New System.Drawing.Size(270, 23)
        Me.txtuser_code.TabIndex = 2
        '
        'lbluser_code
        '
        Me.lbluser_code.BackColor = System.Drawing.Color.Transparent
        Me.lbluser_code.Location = New System.Drawing.Point(12, 36)
        Me.lbluser_code.Name = "lbluser_code"
        Me.lbluser_code.Size = New System.Drawing.Size(145, 19)
        Me.lbluser_code.TabIndex = 1
        Me.lbluser_code.Text = "user_code"
        '
        'txtrole_code
        '
        Me.txtrole_code.Location = New System.Drawing.Point(166, 59)
        Me.txtrole_code.Name = "txtrole_code"
        Me.txtrole_code.Size = New System.Drawing.Size(270, 23)
        Me.txtrole_code.TabIndex = 4
        '
        'lblrole_code
        '
        Me.lblrole_code.BackColor = System.Drawing.Color.Transparent
        Me.lblrole_code.Location = New System.Drawing.Point(12, 61)
        Me.lblrole_code.Name = "lblrole_code"
        Me.lblrole_code.Size = New System.Drawing.Size(145, 19)
        Me.lblrole_code.TabIndex = 3
        Me.lblrole_code.Text = "role_code"
        '
        'txtremark
        '
        Me.txtremark.Location = New System.Drawing.Point(166, 83)
        Me.txtremark.Name = "txtremark"
        Me.txtremark.Size = New System.Drawing.Size(270, 23)
        Me.txtremark.TabIndex = 6
        '
        'lblremark
        '
        Me.lblremark.BackColor = System.Drawing.Color.Transparent
        Me.lblremark.Location = New System.Drawing.Point(12, 86)
        Me.lblremark.Name = "lblremark"
        Me.lblremark.Size = New System.Drawing.Size(145, 19)
        Me.lblremark.TabIndex = 5
        Me.lblremark.Text = "remark"
        '
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(166, 108)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(270, 23)
        Me.txtopt_by.TabIndex = 8
        '
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(12, 110)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(145, 19)
        Me.lblopt_by.TabIndex = 7
        Me.lblopt_by.Text = "opt_by"
        '
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(166, 133)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.Size = New System.Drawing.Size(270, 23)
        Me.dtpopt_dtime.TabIndex = 10
        '
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(12, 135)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(145, 20)
        Me.lblopt_dtime.TabIndex = 9
        Me.lblopt_dtime.Text = "opt_dtime"
        '
        'txtopt_timestamp
        '
        Me.txtopt_timestamp.Location = New System.Drawing.Point(0, 0)
        Me.txtopt_timestamp.Name = "txtopt_timestamp"
        Me.txtopt_timestamp.Size = New System.Drawing.Size(0, 23)
        Me.txtopt_timestamp.TabIndex = 0
        '
        'lblopt_timestamp
        '
        Me.lblopt_timestamp.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_timestamp.Location = New System.Drawing.Point(0, 0)
        Me.lblopt_timestamp.Name = "lblopt_timestamp"
        Me.lblopt_timestamp.Size = New System.Drawing.Size(0, 0)
        Me.lblopt_timestamp.TabIndex = 0
        Me.lblopt_timestamp.Text = "opt_timestamp"
        '
        'pnlMain
        '
        Me.pnlMain.AutoScroll = True
        Me.pnlMain.Controls.Add(Me.txtuser_code)
        Me.pnlMain.Controls.Add(Me.lbluser_code)
        Me.pnlMain.Controls.Add(Me.txtrole_code)
        Me.pnlMain.Controls.Add(Me.lblrole_code)
        Me.pnlMain.Controls.Add(Me.txtremark)
        Me.pnlMain.Controls.Add(Me.lblremark)
        Me.pnlMain.Controls.Add(Me.txtopt_by)
        Me.pnlMain.Controls.Add(Me.lblopt_by)
        Me.pnlMain.Controls.Add(Me.dtpopt_dtime)
        Me.pnlMain.Controls.Add(Me.lblopt_dtime)
        Me.pnlMain.Controls.Add(Me.txtopt_timestamp)
        Me.pnlMain.Controls.Add(Me.lblopt_timestamp)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMain.Location = New System.Drawing.Point(0, 0)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(560, 421)
        Me.pnlMain.TabIndex = 0
        '
        'frmclsUserroleBase__
        '
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmclsUserroleBase__"
        Me.Text = "2361"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.Controls.SetChildIndex(Me.CQ, 0)
        Me.Controls.SetChildIndex(Me.CB, 0)
        Me.Controls.SetChildIndex(Me.chkIsDirty, 0)
        CType(Me.ErrorPrvd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clsUserrole = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtuser_code, "Text", objBO, "user_code")
            BindField(Me.txtrole_code, "Text", objBO, "role_code")
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
        	MyBase.FormatControl(txtuser_code, "user_code", lbluser_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtrole_code, "role_code", lblrole_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
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
		
    Private Sub frmclsUserrole_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
