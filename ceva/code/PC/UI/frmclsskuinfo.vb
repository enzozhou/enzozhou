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
        Me.splMain = New System.Windows.Forms.Splitter
        Me.txtsku_no = New System.Windows.Forms.TextBox
        Me.lblsku_no = New System.Windows.Forms.Label
        Me.txtsku_wms = New System.Windows.Forms.TextBox
        Me.lblsku_wms = New System.Windows.Forms.Label
        Me.txtsku_desc = New System.Windows.Forms.TextBox
        Me.lblsku_desc = New System.Windows.Forms.Label
        Me.txtsku_desc_eng = New System.Windows.Forms.TextBox
        Me.lblsku_desc_eng = New System.Windows.Forms.Label
        Me.txtmodel_no = New System.Windows.Forms.TextBox
        Me.lblmodel_no = New System.Windows.Forms.Label
        Me.txtvolume = New System.Windows.Forms.TextBox
        Me.lblvolume = New System.Windows.Forms.Label
        Me.txtlength = New System.Windows.Forms.TextBox
        Me.lbllength = New System.Windows.Forms.Label
        Me.txtwidth_ = New System.Windows.Forms.TextBox
        Me.lblwidth_ = New System.Windows.Forms.Label
        Me.txtheight = New System.Windows.Forms.TextBox
        Me.lblheight = New System.Windows.Forms.Label
        Me.txtopt_by = New System.Windows.Forms.TextBox
        Me.lblopt_by = New System.Windows.Forms.Label
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker
        Me.lblopt_dtime = New System.Windows.Forms.Label
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox
        Me.lblopt_timestamp = New System.Windows.Forms.Label
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.gd__clsbarcode = New YTUI.DataGrid
        Me.tp__clsbarcode = New System.Windows.Forms.TabPage
        Me.tabGrid = New System.Windows.Forms.TabControl
        CType(Me.ErrorPrvd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        CType(Me.gd__clsbarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp__clsbarcode.SuspendLayout()
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
        Me.CQ.Location = New System.Drawing.Point(0, 345)
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
        Me.splMain.Location = New System.Drawing.Point(0, 336)
        Me.splMain.Name = "splMain"
        Me.splMain.Size = New System.Drawing.Size(560, 9)
        Me.splMain.TabIndex = 24
        Me.splMain.TabStop = False
        '
        'txtsku_no
        '
        Me.txtsku_no.Location = New System.Drawing.Point(166, 11)
        Me.txtsku_no.Name = "txtsku_no"
        Me.txtsku_no.Size = New System.Drawing.Size(270, 23)
        Me.txtsku_no.TabIndex = 2
        '
        'lblsku_no
        '
        Me.lblsku_no.BackColor = System.Drawing.Color.Transparent
        Me.lblsku_no.Location = New System.Drawing.Point(12, 14)
        Me.lblsku_no.Name = "lblsku_no"
        Me.lblsku_no.Size = New System.Drawing.Size(145, 19)
        Me.lblsku_no.TabIndex = 1
        Me.lblsku_no.Text = "sku_no"
        '
        'txtsku_wms
        '
        Me.txtsku_wms.Location = New System.Drawing.Point(166, 37)
        Me.txtsku_wms.Name = "txtsku_wms"
        Me.txtsku_wms.Size = New System.Drawing.Size(270, 23)
        Me.txtsku_wms.TabIndex = 4
        '
        'lblsku_wms
        '
        Me.lblsku_wms.BackColor = System.Drawing.Color.Transparent
        Me.lblsku_wms.Location = New System.Drawing.Point(12, 39)
        Me.lblsku_wms.Name = "lblsku_wms"
        Me.lblsku_wms.Size = New System.Drawing.Size(145, 19)
        Me.lblsku_wms.TabIndex = 3
        Me.lblsku_wms.Text = "sku_wms"
        '
        'txtsku_desc
        '
        Me.txtsku_desc.Location = New System.Drawing.Point(166, 61)
        Me.txtsku_desc.Name = "txtsku_desc"
        Me.txtsku_desc.Size = New System.Drawing.Size(270, 23)
        Me.txtsku_desc.TabIndex = 6
        '
        'lblsku_desc
        '
        Me.lblsku_desc.BackColor = System.Drawing.Color.Transparent
        Me.lblsku_desc.Location = New System.Drawing.Point(12, 64)
        Me.lblsku_desc.Name = "lblsku_desc"
        Me.lblsku_desc.Size = New System.Drawing.Size(145, 19)
        Me.lblsku_desc.TabIndex = 5
        Me.lblsku_desc.Text = "sku_desc"
        '
        'txtsku_desc_eng
        '
        Me.txtsku_desc_eng.Location = New System.Drawing.Point(166, 86)
        Me.txtsku_desc_eng.Name = "txtsku_desc_eng"
        Me.txtsku_desc_eng.Size = New System.Drawing.Size(270, 23)
        Me.txtsku_desc_eng.TabIndex = 8
        '
        'lblsku_desc_eng
        '
        Me.lblsku_desc_eng.BackColor = System.Drawing.Color.Transparent
        Me.lblsku_desc_eng.Location = New System.Drawing.Point(12, 88)
        Me.lblsku_desc_eng.Name = "lblsku_desc_eng"
        Me.lblsku_desc_eng.Size = New System.Drawing.Size(145, 19)
        Me.lblsku_desc_eng.TabIndex = 7
        Me.lblsku_desc_eng.Text = "sku_desc_eng"
        '
        'txtmodel_no
        '
        Me.txtmodel_no.Location = New System.Drawing.Point(166, 111)
        Me.txtmodel_no.Name = "txtmodel_no"
        Me.txtmodel_no.Size = New System.Drawing.Size(270, 23)
        Me.txtmodel_no.TabIndex = 10
        '
        'lblmodel_no
        '
        Me.lblmodel_no.BackColor = System.Drawing.Color.Transparent
        Me.lblmodel_no.Location = New System.Drawing.Point(12, 113)
        Me.lblmodel_no.Name = "lblmodel_no"
        Me.lblmodel_no.Size = New System.Drawing.Size(145, 20)
        Me.lblmodel_no.TabIndex = 9
        Me.lblmodel_no.Text = "model_no"
        '
        'txtvolume
        '
        Me.txtvolume.Location = New System.Drawing.Point(166, 135)
        Me.txtvolume.Name = "txtvolume"
        Me.txtvolume.Size = New System.Drawing.Size(270, 23)
        Me.txtvolume.TabIndex = 12
        '
        'lblvolume
        '
        Me.lblvolume.BackColor = System.Drawing.Color.Transparent
        Me.lblvolume.Location = New System.Drawing.Point(12, 138)
        Me.lblvolume.Name = "lblvolume"
        Me.lblvolume.Size = New System.Drawing.Size(145, 20)
        Me.lblvolume.TabIndex = 11
        Me.lblvolume.Text = "volume"
        '
        'txtlength
        '
        Me.txtlength.Location = New System.Drawing.Point(166, 160)
        Me.txtlength.Name = "txtlength"
        Me.txtlength.Size = New System.Drawing.Size(270, 23)
        Me.txtlength.TabIndex = 14
        '
        'lbllength
        '
        Me.lbllength.BackColor = System.Drawing.Color.Transparent
        Me.lbllength.Location = New System.Drawing.Point(12, 162)
        Me.lbllength.Name = "lbllength"
        Me.lbllength.Size = New System.Drawing.Size(145, 20)
        Me.lbllength.TabIndex = 13
        Me.lbllength.Text = "length"
        '
        'txtwidth_
        '
        Me.txtwidth_.Location = New System.Drawing.Point(166, 185)
        Me.txtwidth_.Name = "txtwidth_"
        Me.txtwidth_.Size = New System.Drawing.Size(270, 23)
        Me.txtwidth_.TabIndex = 16
        '
        'lblwidth_
        '
        Me.lblwidth_.BackColor = System.Drawing.Color.Transparent
        Me.lblwidth_.Location = New System.Drawing.Point(12, 187)
        Me.lblwidth_.Name = "lblwidth_"
        Me.lblwidth_.Size = New System.Drawing.Size(145, 20)
        Me.lblwidth_.TabIndex = 15
        Me.lblwidth_.Text = "width"
        '
        'txtheight
        '
        Me.txtheight.Location = New System.Drawing.Point(166, 209)
        Me.txtheight.Name = "txtheight"
        Me.txtheight.Size = New System.Drawing.Size(270, 23)
        Me.txtheight.TabIndex = 18
        '
        'lblheight
        '
        Me.lblheight.BackColor = System.Drawing.Color.Transparent
        Me.lblheight.Location = New System.Drawing.Point(12, 213)
        Me.lblheight.Name = "lblheight"
        Me.lblheight.Size = New System.Drawing.Size(145, 19)
        Me.lblheight.TabIndex = 17
        Me.lblheight.Text = "height"
        '
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(166, 234)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(270, 23)
        Me.txtopt_by.TabIndex = 20
        '
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(12, 237)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(145, 19)
        Me.lblopt_by.TabIndex = 19
        Me.lblopt_by.Text = "opt_by"
        '
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(166, 259)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.Size = New System.Drawing.Size(270, 23)
        Me.dtpopt_dtime.TabIndex = 22
        '
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(12, 262)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(145, 19)
        Me.lblopt_dtime.TabIndex = 21
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
        Me.pnlMain.Controls.Add(Me.txtsku_no)
        Me.pnlMain.Controls.Add(Me.lblsku_no)
        Me.pnlMain.Controls.Add(Me.txtsku_wms)
        Me.pnlMain.Controls.Add(Me.lblsku_wms)
        Me.pnlMain.Controls.Add(Me.txtsku_desc)
        Me.pnlMain.Controls.Add(Me.lblsku_desc)
        Me.pnlMain.Controls.Add(Me.txtsku_desc_eng)
        Me.pnlMain.Controls.Add(Me.lblsku_desc_eng)
        Me.pnlMain.Controls.Add(Me.txtmodel_no)
        Me.pnlMain.Controls.Add(Me.lblmodel_no)
        Me.pnlMain.Controls.Add(Me.txtvolume)
        Me.pnlMain.Controls.Add(Me.lblvolume)
        Me.pnlMain.Controls.Add(Me.txtlength)
        Me.pnlMain.Controls.Add(Me.lbllength)
        Me.pnlMain.Controls.Add(Me.txtwidth_)
        Me.pnlMain.Controls.Add(Me.lblwidth_)
        Me.pnlMain.Controls.Add(Me.txtheight)
        Me.pnlMain.Controls.Add(Me.lblheight)
        Me.pnlMain.Controls.Add(Me.txtopt_by)
        Me.pnlMain.Controls.Add(Me.lblopt_by)
        Me.pnlMain.Controls.Add(Me.dtpopt_dtime)
        Me.pnlMain.Controls.Add(Me.lblopt_dtime)
        Me.pnlMain.Controls.Add(Me.txtopt_timestamp)
        Me.pnlMain.Controls.Add(Me.lblopt_timestamp)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMain.Location = New System.Drawing.Point(0, 34)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(560, 302)
        Me.pnlMain.TabIndex = 0
        '
        'gd__clsbarcode
        '
        Me.gd__clsbarcode.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsbarcode.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gd__clsbarcode.ColumnListName = ""
        Me.gd__clsbarcode.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsbarcode.Deletable = True
        Me.gd__clsbarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsbarcode.Editable = True
        Me.gd__clsbarcode.Hierarchical = True
        Me.gd__clsbarcode.Location = New System.Drawing.Point(0, 0)
        Me.gd__clsbarcode.Name = "gd__clsbarcode"
        Me.gd__clsbarcode.RecordNavigator = True
        Me.gd__clsbarcode.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsbarcode.Size = New System.Drawing.Size(552, 46)
        Me.gd__clsbarcode.TabIndex = 24
        Me.gd__clsbarcode.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'tp__clsbarcode
        '
        Me.tp__clsbarcode.AutoScroll = True
        Me.tp__clsbarcode.Controls.Add(Me.gd__clsbarcode)
        Me.tp__clsbarcode.Location = New System.Drawing.Point(4, 4)
        Me.tp__clsbarcode.Name = "tp__clsbarcode"
        Me.tp__clsbarcode.Size = New System.Drawing.Size(552, 46)
        Me.tp__clsbarcode.TabIndex = 0
        Me.tp__clsbarcode.Text = "clsbarcodes"
        '
        'tabGrid
        '
        Me.tabGrid.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabGrid.Controls.Add(Me.tp__clsbarcode)
        Me.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrid.Location = New System.Drawing.Point(0, 345)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.SelectedIndex = 0
        Me.tabGrid.Size = New System.Drawing.Size(560, 76)
        Me.tabGrid.TabIndex = 23
        '
        'frmclsskuinfoBase__
        '
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(560, 421)
        Me.Controls.Add(Me.tabGrid)
        Me.Controls.Add(Me.splMain)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmclsskuinfoBase__"
        Me.Text = "2835"
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
        CType(Me.gd__clsbarcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp__clsbarcode.ResumeLayout(False)
        Me.tabGrid.ResumeLayout(False)
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
                    .ButtonEnabled(BK_NEW) = UserRightMgr.GetRightNoDC(Rights.SKUINFONEW)
                    .ButtonEnabled(BK_EDIT) = UserRightMgr.GetRightNoDC(Rights.SKUINFOEDIT)
                    .ButtonEnabled(BK_DELETE) = UserRightMgr.GetRightNoDC(Rights.SKUINFOREMOVE)
                    .ButtonEnabled("LoadItem") = UserRightMgr.GetRightNoDC(Rights.SKUINFOLOAD)
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
