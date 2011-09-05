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
        Me.splMain = New System.Windows.Forms.Splitter
        Me.txtdc_code = New System.Windows.Forms.TextBox
        Me.lbldc_code = New System.Windows.Forms.Label
        Me.txtbin_area = New System.Windows.Forms.TextBox
        Me.lblbin_area = New System.Windows.Forms.Label
        Me.txtdescription = New System.Windows.Forms.TextBox
        Me.lbldescription = New System.Windows.Forms.Label
        Me.txtopt_by = New System.Windows.Forms.TextBox
        Me.lblopt_by = New System.Windows.Forms.Label
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker
        Me.lblopt_dtime = New System.Windows.Forms.Label
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox
        Me.lblopt_timestamp = New System.Windows.Forms.Label
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.gd__clsbin = New YTUI.DataGrid
        Me.tp__clsbin = New System.Windows.Forms.TabPage
        Me.gd__clsbinStatus = New YTUI.DataGrid
        Me.tp__clsbinStatus = New System.Windows.Forms.TabPage
        Me.tabGrid = New System.Windows.Forms.TabControl
        CType(Me.ErrorPrvd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        CType(Me.gd__clsbin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp__clsbin.SuspendLayout()
        CType(Me.gd__clsbinStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp__clsbinStatus.SuspendLayout()
        Me.tabGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkIsDirty
        '
        Me.chkIsDirty.Location = New System.Drawing.Point(-47, -79)
        Me.chkIsDirty.Size = New System.Drawing.Size(4, 6)
        '
        'CQ
        '
        Me.CQ.Location = New System.Drawing.Point(0, 194)
        Me.CQ.Size = New System.Drawing.Size(560, 25)
        '
        'CB
        '
        Me.CB.Location = New System.Drawing.Point(0, 0)
        Me.CB.Size = New System.Drawing.Size(560, 34)
        '
        'splMain
        '
        Me.splMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.splMain.Location = New System.Drawing.Point(0, 185)
        Me.splMain.Name = "splMain"
        Me.splMain.Size = New System.Drawing.Size(560, 9)
        Me.splMain.TabIndex = 12
        Me.splMain.TabStop = False
        '
        'txtdc_code
        '
        Me.txtdc_code.Location = New System.Drawing.Point(166, 11)
        Me.txtdc_code.Name = "txtdc_code"
        Me.txtdc_code.Size = New System.Drawing.Size(270, 23)
        Me.txtdc_code.TabIndex = 2
        '
        'lbldc_code
        '
        Me.lbldc_code.BackColor = System.Drawing.Color.Transparent
        Me.lbldc_code.Location = New System.Drawing.Point(12, 14)
        Me.lbldc_code.Name = "lbldc_code"
        Me.lbldc_code.Size = New System.Drawing.Size(145, 19)
        Me.lbldc_code.TabIndex = 1
        Me.lbldc_code.Text = "dc_code"
        '
        'txtbin_area
        '
        Me.txtbin_area.Location = New System.Drawing.Point(166, 37)
        Me.txtbin_area.Name = "txtbin_area"
        Me.txtbin_area.Size = New System.Drawing.Size(270, 23)
        Me.txtbin_area.TabIndex = 4
        '
        'lblbin_area
        '
        Me.lblbin_area.BackColor = System.Drawing.Color.Transparent
        Me.lblbin_area.Location = New System.Drawing.Point(12, 39)
        Me.lblbin_area.Name = "lblbin_area"
        Me.lblbin_area.Size = New System.Drawing.Size(145, 19)
        Me.lblbin_area.TabIndex = 3
        Me.lblbin_area.Text = "bin_area"
        '
        'txtdescription
        '
        Me.txtdescription.Location = New System.Drawing.Point(166, 61)
        Me.txtdescription.Name = "txtdescription"
        Me.txtdescription.Size = New System.Drawing.Size(270, 23)
        Me.txtdescription.TabIndex = 6
        '
        'lbldescription
        '
        Me.lbldescription.BackColor = System.Drawing.Color.Transparent
        Me.lbldescription.Location = New System.Drawing.Point(12, 64)
        Me.lbldescription.Name = "lbldescription"
        Me.lbldescription.Size = New System.Drawing.Size(145, 19)
        Me.lbldescription.TabIndex = 5
        Me.lbldescription.Text = "description"
        '
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(166, 86)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(270, 23)
        Me.txtopt_by.TabIndex = 8
        '
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(12, 88)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(145, 19)
        Me.lblopt_by.TabIndex = 7
        Me.lblopt_by.Text = "opt_by"
        '
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(166, 111)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.Size = New System.Drawing.Size(270, 23)
        Me.dtpopt_dtime.TabIndex = 10
        '
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(12, 113)
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
        Me.pnlMain.Controls.Add(Me.txtdc_code)
        Me.pnlMain.Controls.Add(Me.lbldc_code)
        Me.pnlMain.Controls.Add(Me.txtbin_area)
        Me.pnlMain.Controls.Add(Me.lblbin_area)
        Me.pnlMain.Controls.Add(Me.txtdescription)
        Me.pnlMain.Controls.Add(Me.lbldescription)
        Me.pnlMain.Controls.Add(Me.txtopt_by)
        Me.pnlMain.Controls.Add(Me.lblopt_by)
        Me.pnlMain.Controls.Add(Me.dtpopt_dtime)
        Me.pnlMain.Controls.Add(Me.lblopt_dtime)
        Me.pnlMain.Controls.Add(Me.txtopt_timestamp)
        Me.pnlMain.Controls.Add(Me.lblopt_timestamp)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMain.Location = New System.Drawing.Point(0, 34)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(560, 151)
        Me.pnlMain.TabIndex = 0
        '
        'gd__clsbin
        '
        Me.gd__clsbin.ColumnListName = ""
        Me.gd__clsbin.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsbin.Deletable = True
        Me.gd__clsbin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsbin.Editable = False
        Me.gd__clsbin.Hierarchical = True
        Me.gd__clsbin.Location = New System.Drawing.Point(0, 0)
        Me.gd__clsbin.Name = "gd__clsbin"
        Me.gd__clsbin.RecordNavigator = True
        Me.gd__clsbin.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsbin.Size = New System.Drawing.Size(552, 197)
        Me.gd__clsbin.TabIndex = 12
        Me.gd__clsbin.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'tp__clsbin
        '
        Me.tp__clsbin.AutoScroll = True
        Me.tp__clsbin.Controls.Add(Me.gd__clsbin)
        Me.tp__clsbin.Location = New System.Drawing.Point(4, 4)
        Me.tp__clsbin.Name = "tp__clsbin"
        Me.tp__clsbin.Size = New System.Drawing.Size(552, 197)
        Me.tp__clsbin.TabIndex = 0
        Me.tp__clsbin.Text = "clsbins"
        '
        'gd__clsbinStatus
        '
        Me.gd__clsbinStatus.ColumnListName = ""
        Me.gd__clsbinStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsbinStatus.Deletable = True
        Me.gd__clsbinStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsbinStatus.Editable = False
        Me.gd__clsbinStatus.Hierarchical = True
        Me.gd__clsbinStatus.Location = New System.Drawing.Point(0, 0)
        Me.gd__clsbinStatus.Name = "gd__clsbinStatus"
        Me.gd__clsbinStatus.RecordNavigator = True
        Me.gd__clsbinStatus.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsbinStatus.Size = New System.Drawing.Size(664, 140)
        Me.gd__clsbinStatus.TabIndex = 13
        Me.gd__clsbinStatus.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'tp__clsbinStatus
        '
        Me.tp__clsbinStatus.AutoScroll = True
        Me.tp__clsbinStatus.Controls.Add(Me.gd__clsbinStatus)
        Me.tp__clsbinStatus.Location = New System.Drawing.Point(4, 4)
        Me.tp__clsbinStatus.Name = "tp__clsbinStatus"
        Me.tp__clsbinStatus.Size = New System.Drawing.Size(664, 140)
        Me.tp__clsbinStatus.TabIndex = 0
        Me.tp__clsbinStatus.Text = "clsbinStatuses"
        '
        'tabGrid
        '
        Me.tabGrid.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabGrid.Controls.Add(Me.tp__clsbin)
        Me.tabGrid.Controls.Add(Me.tp__clsbinStatus)
        Me.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrid.Location = New System.Drawing.Point(0, 194)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.SelectedIndex = 0
        Me.tabGrid.Size = New System.Drawing.Size(560, 227)
        Me.tabGrid.TabIndex = 11
        '
        'frmclsbinareaBase__
        '
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.Add(Me.tabGrid)
        Me.Controls.Add(Me.splMain)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmclsbinareaBase__"
        Me.Text = "2728"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.CB, 0)
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.Controls.SetChildIndex(Me.splMain, 0)
        Me.Controls.SetChildIndex(Me.tabGrid, 0)
        Me.Controls.SetChildIndex(Me.CQ, 0)
        Me.Controls.SetChildIndex(Me.chkIsDirty, 0)
        CType(Me.ErrorPrvd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        CType(Me.gd__clsbin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp__clsbin.ResumeLayout(False)
        CType(Me.gd__clsbinStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp__clsbinStatus.ResumeLayout(False)
        Me.tabGrid.ResumeLayout(False)
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
                    .ButtonEnabled(BK_NEW) = UserRightMgr.GetRightNoDC(Rights.BINAREANEW)
                    .ButtonEnabled(BK_EDIT) = UserRightMgr.GetRightNoDC(Rights.BINAREAEDIT)
                    .ButtonEnabled(BK_DELETE) = UserRightMgr.GetRightNoDC(Rights.BINAREAREMOVE)
                    .ButtonEnabled("LoadItem") = UserRightMgr.GetRightNoDC(Rights.BINAREALOAD)
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
