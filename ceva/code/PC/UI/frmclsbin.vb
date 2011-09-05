Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclsbinBase__
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
    Protected Friend WithEvents txtbin_code As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblbin_code As System.Windows.Forms.Label
    Protected Friend WithEvents txtdescription As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldescription As System.Windows.Forms.Label
    Protected Friend WithEvents txtbin_area As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblbin_area As System.Windows.Forms.Label
    Protected Friend WithEvents txtlength As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbllength As System.Windows.Forms.Label
    Protected Friend WithEvents txtwidth_ As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblwidth_ As System.Windows.Forms.Label
    Protected Friend WithEvents txtweight As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblweight As System.Windows.Forms.Label
    Protected Friend WithEvents txtvolume As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblvolume As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_by As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_by As System.Windows.Forms.Label
    Protected Friend WithEvents dtpopt_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblopt_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_timestamp As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_timestamp As System.Windows.Forms.Label
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtdc_code = New System.Windows.Forms.TextBox
        Me.lbldc_code = New System.Windows.Forms.Label
        Me.txtbin_code = New System.Windows.Forms.TextBox
        Me.lblbin_code = New System.Windows.Forms.Label
        Me.txtdescription = New System.Windows.Forms.TextBox
        Me.lbldescription = New System.Windows.Forms.Label
        Me.txtbin_area = New System.Windows.Forms.TextBox
        Me.lblbin_area = New System.Windows.Forms.Label
        Me.txtlength = New System.Windows.Forms.TextBox
        Me.lbllength = New System.Windows.Forms.Label
        Me.txtwidth_ = New System.Windows.Forms.TextBox
        Me.lblwidth_ = New System.Windows.Forms.Label
        Me.txtweight = New System.Windows.Forms.TextBox
        Me.lblweight = New System.Windows.Forms.Label
        Me.txtvolume = New System.Windows.Forms.TextBox
        Me.lblvolume = New System.Windows.Forms.Label
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
        Me.CB.Size = New System.Drawing.Size(560, 34)
        '
        'txtdc_code
        '
        Me.txtdc_code.Location = New System.Drawing.Point(166, 37)
        Me.txtdc_code.Name = "txtdc_code"
        Me.txtdc_code.Size = New System.Drawing.Size(270, 23)
        Me.txtdc_code.TabIndex = 2
        '
        'lbldc_code
        '
        Me.lbldc_code.BackColor = System.Drawing.Color.Transparent
        Me.lbldc_code.Location = New System.Drawing.Point(12, 40)
        Me.lbldc_code.Name = "lbldc_code"
        Me.lbldc_code.Size = New System.Drawing.Size(145, 19)
        Me.lbldc_code.TabIndex = 1
        Me.lbldc_code.Text = "dc_code"
        '
        'txtbin_code
        '
        Me.txtbin_code.Location = New System.Drawing.Point(166, 63)
        Me.txtbin_code.Name = "txtbin_code"
        Me.txtbin_code.Size = New System.Drawing.Size(270, 23)
        Me.txtbin_code.TabIndex = 4
        '
        'lblbin_code
        '
        Me.lblbin_code.BackColor = System.Drawing.Color.Transparent
        Me.lblbin_code.Location = New System.Drawing.Point(12, 65)
        Me.lblbin_code.Name = "lblbin_code"
        Me.lblbin_code.Size = New System.Drawing.Size(145, 19)
        Me.lblbin_code.TabIndex = 3
        Me.lblbin_code.Text = "bin_code"
        '
        'txtdescription
        '
        Me.txtdescription.Location = New System.Drawing.Point(166, 87)
        Me.txtdescription.Name = "txtdescription"
        Me.txtdescription.Size = New System.Drawing.Size(270, 23)
        Me.txtdescription.TabIndex = 6
        '
        'lbldescription
        '
        Me.lbldescription.BackColor = System.Drawing.Color.Transparent
        Me.lbldescription.Location = New System.Drawing.Point(12, 90)
        Me.lbldescription.Name = "lbldescription"
        Me.lbldescription.Size = New System.Drawing.Size(145, 19)
        Me.lbldescription.TabIndex = 5
        Me.lbldescription.Text = "description"
        '
        'txtbin_area
        '
        Me.txtbin_area.Location = New System.Drawing.Point(166, 112)
        Me.txtbin_area.Name = "txtbin_area"
        Me.txtbin_area.Size = New System.Drawing.Size(270, 23)
        Me.txtbin_area.TabIndex = 8
        '
        'lblbin_area
        '
        Me.lblbin_area.BackColor = System.Drawing.Color.Transparent
        Me.lblbin_area.Location = New System.Drawing.Point(12, 114)
        Me.lblbin_area.Name = "lblbin_area"
        Me.lblbin_area.Size = New System.Drawing.Size(145, 19)
        Me.lblbin_area.TabIndex = 7
        Me.lblbin_area.Text = "bin_area"
        '
        'txtlength
        '
        Me.txtlength.Location = New System.Drawing.Point(166, 137)
        Me.txtlength.Name = "txtlength"
        Me.txtlength.Size = New System.Drawing.Size(270, 23)
        Me.txtlength.TabIndex = 10
        '
        'lbllength
        '
        Me.lbllength.BackColor = System.Drawing.Color.Transparent
        Me.lbllength.Location = New System.Drawing.Point(12, 139)
        Me.lbllength.Name = "lbllength"
        Me.lbllength.Size = New System.Drawing.Size(145, 20)
        Me.lbllength.TabIndex = 9
        Me.lbllength.Text = "length"
        '
        'txtwidth_
        '
        Me.txtwidth_.Location = New System.Drawing.Point(166, 161)
        Me.txtwidth_.Name = "txtwidth_"
        Me.txtwidth_.Size = New System.Drawing.Size(270, 23)
        Me.txtwidth_.TabIndex = 12
        '
        'lblwidth_
        '
        Me.lblwidth_.BackColor = System.Drawing.Color.Transparent
        Me.lblwidth_.Location = New System.Drawing.Point(12, 164)
        Me.lblwidth_.Name = "lblwidth_"
        Me.lblwidth_.Size = New System.Drawing.Size(145, 20)
        Me.lblwidth_.TabIndex = 11
        Me.lblwidth_.Text = "width"
        '
        'txtweight
        '
        Me.txtweight.Location = New System.Drawing.Point(166, 186)
        Me.txtweight.Name = "txtweight"
        Me.txtweight.Size = New System.Drawing.Size(270, 23)
        Me.txtweight.TabIndex = 14
        '
        'lblweight
        '
        Me.lblweight.BackColor = System.Drawing.Color.Transparent
        Me.lblweight.Location = New System.Drawing.Point(12, 188)
        Me.lblweight.Name = "lblweight"
        Me.lblweight.Size = New System.Drawing.Size(145, 20)
        Me.lblweight.TabIndex = 13
        Me.lblweight.Text = "weight"
        '
        'txtvolume
        '
        Me.txtvolume.Location = New System.Drawing.Point(166, 211)
        Me.txtvolume.Name = "txtvolume"
        Me.txtvolume.Size = New System.Drawing.Size(270, 23)
        Me.txtvolume.TabIndex = 16
        '
        'lblvolume
        '
        Me.lblvolume.BackColor = System.Drawing.Color.Transparent
        Me.lblvolume.Location = New System.Drawing.Point(12, 213)
        Me.lblvolume.Name = "lblvolume"
        Me.lblvolume.Size = New System.Drawing.Size(145, 20)
        Me.lblvolume.TabIndex = 15
        Me.lblvolume.Text = "volume"
        '
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(166, 235)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(270, 23)
        Me.txtopt_by.TabIndex = 18
        '
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(12, 239)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(145, 19)
        Me.lblopt_by.TabIndex = 17
        Me.lblopt_by.Text = "opt_by"
        '
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(166, 260)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.Size = New System.Drawing.Size(270, 23)
        Me.dtpopt_dtime.TabIndex = 20
        '
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(12, 263)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(145, 19)
        Me.lblopt_dtime.TabIndex = 19
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
        Me.pnlMain.Controls.Add(Me.txtdc_code)
        Me.pnlMain.Controls.Add(Me.lbldc_code)
        Me.pnlMain.Controls.Add(Me.txtbin_code)
        Me.pnlMain.Controls.Add(Me.lblbin_code)
        Me.pnlMain.Controls.Add(Me.txtdescription)
        Me.pnlMain.Controls.Add(Me.lbldescription)
        Me.pnlMain.Controls.Add(Me.txtbin_area)
        Me.pnlMain.Controls.Add(Me.lblbin_area)
        Me.pnlMain.Controls.Add(Me.txtlength)
        Me.pnlMain.Controls.Add(Me.lbllength)
        Me.pnlMain.Controls.Add(Me.txtwidth_)
        Me.pnlMain.Controls.Add(Me.lblwidth_)
        Me.pnlMain.Controls.Add(Me.txtweight)
        Me.pnlMain.Controls.Add(Me.lblweight)
        Me.pnlMain.Controls.Add(Me.txtvolume)
        Me.pnlMain.Controls.Add(Me.lblvolume)
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
        'frmclsbinBase__
        '
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmclsbinBase__"
        Me.Text = "2751"
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
        Dim objBO As clsbin = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtdc_code, "Text", objBO, "dc_code")
            BindField(Me.txtbin_code, "Text", objBO, "bin_code")
            BindField(Me.txtdescription, "Text", objBO, "description")
            BindField(Me.txtbin_area, "Text", objBO, "bin_area")
            BindField(Me.txtlength, "Text", objBO, "length")
            BindField(Me.txtwidth_, "Text", objBO, "width_")
            BindField(Me.txtweight, "Text", objBO, "weight")
            BindField(Me.txtvolume, "Text", objBO, "volume")
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
        	MyBase.FormatControl(txtdc_code, "dc_code", lbldc_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtbin_code, "bin_code", lblbin_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtdescription, "description", lbldescription, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtbin_area, "bin_area", lblbin_area, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtlength, "length", lbllength, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtwidth_, "width_", lblwidth_, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtweight, "weight", lblweight, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtvolume, "volume", lblvolume, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtopt_by, "opt_by", lblopt_by, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        Me.LoadLayout()
        Catch ThisException As Exception
        	ErrorMsg(ThisException, Me.GetType, "Format")
        End Try        
    End Sub
    
    
    Protected Overrides Sub LoadChildrenData(Optional ByVal blnReset As Boolean = False)
	End Sub
		
    Private Sub frmclsbin_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
    Protected Overrides Sub UpdateNavigationStatus()
        MyBase.UpdateNavigationStatus()
        DisableButton()
    End Sub

    Protected Overrides Sub UpdateDirtyStatus()
        MyBase.UpdateDirtyStatus()
        DisableButton()
    End Sub

    Protected Overrides Sub UpdateEditStatus()
        MyBase.UpdateEditStatus()
        DisableButton()
    End Sub


    Private Sub DisableButton()
        If Me.Current Is Nothing Then
            Exit Sub
        End If
        If Not Me.GetToolbarService Is Nothing Then
            With Me.GetToolbarService
                .ButtonEnabled(BK_PRINT) = False
                .ButtonEnabled(BK_EXPORT) = False
                .ButtonEnabled(BK_IMPORT) = False

                If Not Me.Editable Then
                    .ButtonEnabled(BK_NEW) = UserRightMgr.GetRightNoDC(Rights.BINNEW)
                    .ButtonEnabled(BK_EDIT) = UserRightMgr.GetRightNoDC(Rights.BINEDIT)
                    .ButtonEnabled(BK_DELETE) = UserRightMgr.GetRightNoDC(Rights.BINREMOVE)
                    .ButtonEnabled("LoadItem") = UserRightMgr.GetRightNoDC(Rights.DNHDRLOAD)
                Else
                    .ButtonEnabled(BK_EDIT) = False
                    .ButtonEnabled(BK_NEW) = False
                    .ButtonEnabled(BK_DELETE) = False
                    .ButtonEnabled("LoadItem") = False
                End If
            End With
        End If
    End Sub

#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
