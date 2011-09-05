Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject
Imports System.Windows.Forms

Public Class frmclsbchhdrBase__
    Inherits CXMdiChildForm
	Implements IPrintableForm
#Region " user defined property "
    Dim CloseBill As New clsCloseBill
    Dim Optimization As New clsOptimizationDN
    Dim ValidationBill As New clsValidationBill
#End Region
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
    Protected Friend WithEvents txtbch_no As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblbch_no As System.Windows.Forms.Label
    Protected Friend WithEvents txtdescription As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbldescription As System.Windows.Forms.Label
    Protected Friend WithEvents cbostatus_code As System.Windows.Forms.ComboBox
    Protected Friend WithEvents lblstatus_code As System.Windows.Forms.Label
    Protected Friend WithEvents txtlocked As System.Windows.Forms.TextBox
    Protected Friend WithEvents lbllocked As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_by As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_by As System.Windows.Forms.Label
    Protected Friend WithEvents dtpopt_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblopt_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents dtpstart_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblstart_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents dtpend_dtime As System.Windows.Forms.DateTimePicker
    Protected Friend WithEvents lblend_dtime As System.Windows.Forms.Label
    Protected Friend WithEvents txtopt_timestamp As System.Windows.Forms.TextBox
    Protected Friend WithEvents lblopt_timestamp As System.Windows.Forms.Label
    Protected Friend WithEvents pnlMain As System.Windows.Forms.Panel
    Protected Friend WithEvents tp__clsbchlin As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsbchlin As YTUI.DataGrid
    Protected Friend WithEvents tp__clsDnBin As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsDnBin As YTUI.DataGrid
    Protected Friend WithEvents tp__clstaskhdr As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clstaskhdr As YTUI.DataGrid
    Friend WithEvents btnFinish As System.Windows.Forms.Button
    Friend WithEvents BtnAssignTask As System.Windows.Forms.Button
    Protected Friend WithEvents tabGrid As System.Windows.Forms.TabControl

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.splMain = New System.Windows.Forms.Splitter
        Me.txtdc_code = New System.Windows.Forms.TextBox
        Me.lbldc_code = New System.Windows.Forms.Label
        Me.txtbch_no = New System.Windows.Forms.TextBox
        Me.lblbch_no = New System.Windows.Forms.Label
        Me.txtdescription = New System.Windows.Forms.TextBox
        Me.lbldescription = New System.Windows.Forms.Label
        Me.cbostatus_code = New System.Windows.Forms.ComboBox
        Me.lblstatus_code = New System.Windows.Forms.Label
        Me.txtlocked = New System.Windows.Forms.TextBox
        Me.lbllocked = New System.Windows.Forms.Label
        Me.txtopt_by = New System.Windows.Forms.TextBox
        Me.lblopt_by = New System.Windows.Forms.Label
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker
        Me.lblopt_dtime = New System.Windows.Forms.Label
        Me.dtpstart_dtime = New System.Windows.Forms.DateTimePicker
        Me.lblstart_dtime = New System.Windows.Forms.Label
        Me.dtpend_dtime = New System.Windows.Forms.DateTimePicker
        Me.lblend_dtime = New System.Windows.Forms.Label
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox
        Me.lblopt_timestamp = New System.Windows.Forms.Label
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.btnFinish = New System.Windows.Forms.Button
        Me.BtnAssignTask = New System.Windows.Forms.Button
        Me.gd__clsbchlin = New YTUI.DataGrid
        Me.tp__clsbchlin = New System.Windows.Forms.TabPage
        Me.gd__clsDnBin = New YTUI.DataGrid
        Me.tp__clsDnBin = New System.Windows.Forms.TabPage
        Me.gd__clstaskhdr = New YTUI.DataGrid
        Me.tp__clstaskhdr = New System.Windows.Forms.TabPage
        Me.tabGrid = New System.Windows.Forms.TabControl
        CType(Me.ErrorPrvd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        CType(Me.gd__clsbchlin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp__clsbchlin.SuspendLayout()
        CType(Me.gd__clsDnBin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp__clsDnBin.SuspendLayout()
        CType(Me.gd__clstaskhdr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp__clstaskhdr.SuspendLayout()
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
        Me.CQ.Location = New System.Drawing.Point(0, 195)
        Me.CQ.Size = New System.Drawing.Size(892, 25)
        '
        'CB
        '
        Me.CB.Location = New System.Drawing.Point(0, 0)
        Me.CB.Size = New System.Drawing.Size(892, 34)
        '
        'splMain
        '
        Me.splMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.splMain.Location = New System.Drawing.Point(0, 186)
        Me.splMain.Name = "splMain"
        Me.splMain.Size = New System.Drawing.Size(892, 9)
        Me.splMain.TabIndex = 20
        Me.splMain.TabStop = False
        '
        'txtdc_code
        '
        Me.txtdc_code.Location = New System.Drawing.Point(166, 14)
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
        'txtbch_no
        '
        Me.txtbch_no.Location = New System.Drawing.Point(166, 40)
        Me.txtbch_no.Name = "txtbch_no"
        Me.txtbch_no.Size = New System.Drawing.Size(270, 23)
        Me.txtbch_no.TabIndex = 4
        '
        'lblbch_no
        '
        Me.lblbch_no.BackColor = System.Drawing.Color.Transparent
        Me.lblbch_no.Location = New System.Drawing.Point(12, 40)
        Me.lblbch_no.Name = "lblbch_no"
        Me.lblbch_no.Size = New System.Drawing.Size(145, 19)
        Me.lblbch_no.TabIndex = 3
        Me.lblbch_no.Text = "bch_no"
        '
        'txtdescription
        '
        Me.txtdescription.Location = New System.Drawing.Point(610, 14)
        Me.txtdescription.Name = "txtdescription"
        Me.txtdescription.Size = New System.Drawing.Size(270, 23)
        Me.txtdescription.TabIndex = 6
        '
        'lbldescription
        '
        Me.lbldescription.BackColor = System.Drawing.Color.Transparent
        Me.lbldescription.Location = New System.Drawing.Point(456, 14)
        Me.lbldescription.Name = "lbldescription"
        Me.lbldescription.Size = New System.Drawing.Size(145, 19)
        Me.lbldescription.TabIndex = 5
        Me.lbldescription.Text = "description"
        '
        'cbostatus_code
        '
        Me.cbostatus_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbostatus_code.Location = New System.Drawing.Point(610, 40)
        Me.cbostatus_code.Name = "cbostatus_code"
        Me.cbostatus_code.Size = New System.Drawing.Size(270, 25)
        Me.cbostatus_code.TabIndex = 8
        '
        'lblstatus_code
        '
        Me.lblstatus_code.BackColor = System.Drawing.Color.Transparent
        Me.lblstatus_code.Location = New System.Drawing.Point(456, 40)
        Me.lblstatus_code.Name = "lblstatus_code"
        Me.lblstatus_code.Size = New System.Drawing.Size(145, 19)
        Me.lblstatus_code.TabIndex = 7
        Me.lblstatus_code.Text = "status_code"
        '
        'txtlocked
        '
        Me.txtlocked.Location = New System.Drawing.Point(166, 68)
        Me.txtlocked.Name = "txtlocked"
        Me.txtlocked.Size = New System.Drawing.Size(270, 23)
        Me.txtlocked.TabIndex = 10
        '
        'lbllocked
        '
        Me.lbllocked.BackColor = System.Drawing.Color.Transparent
        Me.lbllocked.Location = New System.Drawing.Point(12, 68)
        Me.lbllocked.Name = "lbllocked"
        Me.lbllocked.Size = New System.Drawing.Size(145, 20)
        Me.lbllocked.TabIndex = 9
        Me.lbllocked.Text = "locked"
        '
        'txtopt_by
        '
        Me.txtopt_by.Location = New System.Drawing.Point(610, 68)
        Me.txtopt_by.Name = "txtopt_by"
        Me.txtopt_by.Size = New System.Drawing.Size(270, 23)
        Me.txtopt_by.TabIndex = 12
        '
        'lblopt_by
        '
        Me.lblopt_by.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_by.Location = New System.Drawing.Point(456, 68)
        Me.lblopt_by.Name = "lblopt_by"
        Me.lblopt_by.Size = New System.Drawing.Size(145, 20)
        Me.lblopt_by.TabIndex = 11
        Me.lblopt_by.Text = "opt_by"
        '
        'dtpopt_dtime
        '
        Me.dtpopt_dtime.Location = New System.Drawing.Point(166, 94)
        Me.dtpopt_dtime.Name = "dtpopt_dtime"
        Me.dtpopt_dtime.ShowCheckBox = True
        Me.dtpopt_dtime.Size = New System.Drawing.Size(270, 23)
        Me.dtpopt_dtime.TabIndex = 14
        '
        'lblopt_dtime
        '
        Me.lblopt_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblopt_dtime.Location = New System.Drawing.Point(12, 94)
        Me.lblopt_dtime.Name = "lblopt_dtime"
        Me.lblopt_dtime.Size = New System.Drawing.Size(145, 20)
        Me.lblopt_dtime.TabIndex = 13
        Me.lblopt_dtime.Text = "opt_dtime"
        '
        'dtpstart_dtime
        '
        Me.dtpstart_dtime.Location = New System.Drawing.Point(610, 94)
        Me.dtpstart_dtime.Name = "dtpstart_dtime"
        Me.dtpstart_dtime.ShowCheckBox = True
        Me.dtpstart_dtime.Size = New System.Drawing.Size(270, 23)
        Me.dtpstart_dtime.TabIndex = 16
        '
        'lblstart_dtime
        '
        Me.lblstart_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblstart_dtime.Location = New System.Drawing.Point(456, 94)
        Me.lblstart_dtime.Name = "lblstart_dtime"
        Me.lblstart_dtime.Size = New System.Drawing.Size(145, 20)
        Me.lblstart_dtime.TabIndex = 15
        Me.lblstart_dtime.Text = "start_dtime"
        '
        'dtpend_dtime
        '
        Me.dtpend_dtime.Location = New System.Drawing.Point(166, 122)
        Me.dtpend_dtime.Name = "dtpend_dtime"
        Me.dtpend_dtime.ShowCheckBox = True
        Me.dtpend_dtime.Size = New System.Drawing.Size(270, 23)
        Me.dtpend_dtime.TabIndex = 18
        '
        'lblend_dtime
        '
        Me.lblend_dtime.BackColor = System.Drawing.Color.Transparent
        Me.lblend_dtime.Location = New System.Drawing.Point(12, 122)
        Me.lblend_dtime.Name = "lblend_dtime"
        Me.lblend_dtime.Size = New System.Drawing.Size(145, 19)
        Me.lblend_dtime.TabIndex = 17
        Me.lblend_dtime.Text = "end_dtime"
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
        Me.pnlMain.Controls.Add(Me.btnFinish)
        Me.pnlMain.Controls.Add(Me.BtnAssignTask)
        Me.pnlMain.Controls.Add(Me.txtdc_code)
        Me.pnlMain.Controls.Add(Me.lbldc_code)
        Me.pnlMain.Controls.Add(Me.txtbch_no)
        Me.pnlMain.Controls.Add(Me.lblbch_no)
        Me.pnlMain.Controls.Add(Me.txtdescription)
        Me.pnlMain.Controls.Add(Me.lbldescription)
        Me.pnlMain.Controls.Add(Me.cbostatus_code)
        Me.pnlMain.Controls.Add(Me.lblstatus_code)
        Me.pnlMain.Controls.Add(Me.txtlocked)
        Me.pnlMain.Controls.Add(Me.lbllocked)
        Me.pnlMain.Controls.Add(Me.txtopt_by)
        Me.pnlMain.Controls.Add(Me.lblopt_by)
        Me.pnlMain.Controls.Add(Me.dtpopt_dtime)
        Me.pnlMain.Controls.Add(Me.lblopt_dtime)
        Me.pnlMain.Controls.Add(Me.dtpstart_dtime)
        Me.pnlMain.Controls.Add(Me.lblstart_dtime)
        Me.pnlMain.Controls.Add(Me.dtpend_dtime)
        Me.pnlMain.Controls.Add(Me.lblend_dtime)
        Me.pnlMain.Controls.Add(Me.txtopt_timestamp)
        Me.pnlMain.Controls.Add(Me.lblopt_timestamp)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMain.Location = New System.Drawing.Point(0, 34)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(892, 152)
        Me.pnlMain.TabIndex = 0
        '
        'btnFinish
        '
        Me.btnFinish.Location = New System.Drawing.Point(805, 124)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(75, 23)
        Me.btnFinish.TabIndex = 20
        Me.btnFinish.Text = "完成"
        Me.btnFinish.UseVisualStyleBackColor = True
        '
        'BtnAssignTask
        '
        Me.BtnAssignTask.Location = New System.Drawing.Point(610, 123)
        Me.BtnAssignTask.Name = "BtnAssignTask"
        Me.BtnAssignTask.Size = New System.Drawing.Size(75, 23)
        Me.BtnAssignTask.TabIndex = 19
        Me.BtnAssignTask.Text = "任务分配"
        Me.BtnAssignTask.UseVisualStyleBackColor = True
        '
        'gd__clsbchlin
        '
        Me.gd__clsbchlin.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsbchlin.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gd__clsbchlin.ColumnListName = ""
        Me.gd__clsbchlin.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsbchlin.Deletable = True
        Me.gd__clsbchlin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsbchlin.Editable = True
        Me.gd__clsbchlin.Hierarchical = True
        Me.gd__clsbchlin.Location = New System.Drawing.Point(0, 0)
        Me.gd__clsbchlin.Name = "gd__clsbchlin"
        Me.gd__clsbchlin.RecordNavigator = True
        Me.gd__clsbchlin.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsbchlin.Size = New System.Drawing.Size(884, 196)
        Me.gd__clsbchlin.TabIndex = 20
        Me.gd__clsbchlin.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'tp__clsbchlin
        '
        Me.tp__clsbchlin.AutoScroll = True
        Me.tp__clsbchlin.Controls.Add(Me.gd__clsbchlin)
        Me.tp__clsbchlin.Location = New System.Drawing.Point(4, 4)
        Me.tp__clsbchlin.Name = "tp__clsbchlin"
        Me.tp__clsbchlin.Size = New System.Drawing.Size(884, 196)
        Me.tp__clsbchlin.TabIndex = 0
        Me.tp__clsbchlin.Text = "clsbchlins"
        '
        'gd__clsDnBin
        '
        Me.gd__clsDnBin.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsDnBin.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gd__clsDnBin.ColumnListName = ""
        Me.gd__clsDnBin.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsDnBin.Deletable = True
        Me.gd__clsDnBin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsDnBin.Editable = True
        Me.gd__clsDnBin.Hierarchical = True
        Me.gd__clsDnBin.Location = New System.Drawing.Point(0, 0)
        Me.gd__clsDnBin.Name = "gd__clsDnBin"
        Me.gd__clsDnBin.RecordNavigator = True
        Me.gd__clsDnBin.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsDnBin.Size = New System.Drawing.Size(884, 200)
        Me.gd__clsDnBin.TabIndex = 21
        Me.gd__clsDnBin.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'tp__clsDnBin
        '
        Me.tp__clsDnBin.AutoScroll = True
        Me.tp__clsDnBin.Controls.Add(Me.gd__clsDnBin)
        Me.tp__clsDnBin.Location = New System.Drawing.Point(4, 4)
        Me.tp__clsDnBin.Name = "tp__clsDnBin"
        Me.tp__clsDnBin.Size = New System.Drawing.Size(884, 200)
        Me.tp__clsDnBin.TabIndex = 0
        Me.tp__clsDnBin.Text = "clsDnBins"
        '
        'gd__clstaskhdr
        '
        Me.gd__clstaskhdr.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clstaskhdr.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gd__clstaskhdr.ColumnListName = ""
        Me.gd__clstaskhdr.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clstaskhdr.Deletable = True
        Me.gd__clstaskhdr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clstaskhdr.Editable = True
        Me.gd__clstaskhdr.Hierarchical = True
        Me.gd__clstaskhdr.Location = New System.Drawing.Point(0, 0)
        Me.gd__clstaskhdr.Name = "gd__clstaskhdr"
        Me.gd__clstaskhdr.RecordNavigator = True
        Me.gd__clstaskhdr.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clstaskhdr.Size = New System.Drawing.Size(884, 200)
        Me.gd__clstaskhdr.TabIndex = 22
        Me.gd__clstaskhdr.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'tp__clstaskhdr
        '
        Me.tp__clstaskhdr.AutoScroll = True
        Me.tp__clstaskhdr.Controls.Add(Me.gd__clstaskhdr)
        Me.tp__clstaskhdr.Location = New System.Drawing.Point(4, 4)
        Me.tp__clstaskhdr.Name = "tp__clstaskhdr"
        Me.tp__clstaskhdr.Size = New System.Drawing.Size(884, 200)
        Me.tp__clstaskhdr.TabIndex = 0
        Me.tp__clstaskhdr.Text = "clstaskhdrs"
        '
        'tabGrid
        '
        Me.tabGrid.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabGrid.Controls.Add(Me.tp__clsbchlin)
        Me.tabGrid.Controls.Add(Me.tp__clsDnBin)
        Me.tabGrid.Controls.Add(Me.tp__clstaskhdr)
        Me.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrid.Location = New System.Drawing.Point(0, 195)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.SelectedIndex = 0
        Me.tabGrid.Size = New System.Drawing.Size(892, 226)
        Me.tabGrid.TabIndex = 19
        '
        'frmclsbchhdrBase__
        '
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(892, 421)
        Me.Controls.Add(Me.tabGrid)
        Me.Controls.Add(Me.splMain)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmclsbchhdrBase__"
        Me.Text = "2551"
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
        CType(Me.gd__clsbchlin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp__clsbchlin.ResumeLayout(False)
        CType(Me.gd__clsDnBin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp__clsDnBin.ResumeLayout(False)
        CType(Me.gd__clstaskhdr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp__clstaskhdr.ResumeLayout(False)
        Me.tabGrid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region " COM Express generated code "
	Public Overrides Sub DataBind()
        Dim objBO As clsbchhdr = Me.Current
        
        try
        	Mybase.DataBind()
            BindField(Me.txtdc_code, "Text", objBO, "dc_code")
            BindField(Me.txtbch_no, "Text", objBO, "bch_no")
            BindField(Me.txtdescription, "Text", objBO, "description")
            BindField(Me.cbostatus_code, "SelectedValue", objBO, "status_code")
            BindField(Me.txtlocked, "Text", objBO, "locked")
            BindField(Me.txtopt_by, "Text", objBO, "opt_by")
            BindField(Me.dtpopt_dtime, "Text", objBO, "opt_dtime")
            BindField(Me.dtpstart_dtime, "Text", objBO, "start_dtime")
            BindField(Me.dtpend_dtime, "Text", objBO, "end_dtime")
            CType(Me.gd__clsbchlin, IGrid).DataSource = objBO.clsbchlins
            CType(Me.gd__clsDnBin, IGrid).DataSource = objBO.clsDnBins
            CType(Me.gd__clstaskhdr, IGrid).DataSource = objBO.clstaskhdrs
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "DataBind")
        End Try
    End Sub

    Protected Overrides Sub UpdateControlEditStatus()
    	Me.FormatControlEditStatus()
    	Me.SetChildGridEditMode(Me.gd__clsbchlin)
    	Me.SetChildGridEditMode(Me.gd__clsDnBin)
    	Me.SetChildGridEditMode(Me.gd__clstaskhdr)
    End Sub
    
    Public Overrides Sub Format()
    	try
        	MyBase.Format()
        	MyBase.FormatControl(txtdc_code, "dc_code", lbldc_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtbch_no, "bch_no", lblbch_no, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtdescription, "description", lbldescription, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(cbostatus_code, "status_code", lblstatus_code, AddressOf mControlHelper.GeneralControlFormatter, AddressOf mControlHelper.ComboListBoxLoader, AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(txtlocked, "locked", lbllocked, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(txtopt_by, "opt_by", lblopt_by, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
        	MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(dtpstart_dtime, "start_dtime", lblstart_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
        	MyBase.FormatControl(dtpend_dtime, "end_dtime", lblend_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
    		Me.tp__clsbchlin.Text = mobjapp.GetLayout.CXObjectLays(GetType(clsbchlin).Name).ColCaptionText
        	CType(Me.gd__clsbchlin, IGrid).FormatGrid()
    		Me.tp__clsDnBin.Text = mobjapp.GetLayout.CXObjectLays(GetType(clsDnBin).Name).ColCaptionText
        	CType(Me.gd__clsDnBin, IGrid).FormatGrid()
    		Me.tp__clstaskhdr.Text = mobjapp.GetLayout.CXObjectLays(GetType(clstaskhdr).Name).ColCaptionText
        	CType(Me.gd__clstaskhdr, IGrid).FormatGrid()
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
    	CType(Current, clsbchhdr).Loadclsbchlins(blnReset)
    	CType(Current, clsbchhdr).LoadclsDnBins(blnReset)
    	CType(Current, clsbchhdr).Loadclstaskhdrs(blnReset)
	End Sub
		
    Private Sub frmclsbchhdr_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
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
#Region " user control envent "
    Private Sub BtnAssignTask_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAssignTask.Click
        Try
            Dim frm As New frmAssignTaskInBanch
            frm.ShowInTaskbar = False
            frm.Icon = Me.Icon
            frm.sBanchNo = Me.txtbch_no.Text
            SetModalFormStyle(frm)
            frm.ShowDialog(Me)
            frm.Dispose()
            frm = Nothing
            GC.Collect()
        Catch ex As Exception
        End Try
        Me.tabGrid.SelectedTab = Me.tp__clstaskhdr
        Me.RefreshData()
        DisableButton()
    End Sub
    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        Dim frm As New frmAuthentication
        SetModalFormStyle(frm)
        If frm.ShowDialog <> DialogResult.OK Then
            ''Message("ID_cap_Autherntication_fail", True, "密码错误！")
            Exit Sub
        End If
        Dim _BanchDifferences As New BanchDifferences
        _BanchDifferences.initDCCode = Me.txtdc_code.Text
        _BanchDifferences.initBanchNo = Me.txtbch_no.Text
        SetModalFormStyle(_BanchDifferences)
        If _BanchDifferences.ShowDialog <> DialogResult.OK Then
            Exit Sub
        End If
        Try
            Dim RetCode As String = ""
            Dim RetMsg As String = ""
            CloseBill.CloseSingleBanch("SHA", Me.txtbch_no.Text, RetCode, RetMsg)
        Catch ex As Exception
        End Try
        Me.tabGrid.SelectedTab = Me.tp__clsDnBin
        Me.RefreshData()
        DisableButton()
    End Sub
    Private Sub frmclsbchhdrBase___Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisableButton()
    End Sub
#End Region
#Region " customer bussniness flow "
    Private Sub setBtnAssignEnable()
        Me.BtnAssignTask.Enabled = UserRightMgr.GetRightNoDC(Rights.BACHHDRASSIGN)
        '    If BtnAssignTask.Enabled = True Then
        '        Me.BtnAssignTask.Enabled = ValidationBill.CanAssignTask(Me.txtdc_code.Text, Me.txtbch_no.Text)
        '    End If
    End Sub
    Private Sub setBtnCloseEnable()
        Me.btnFinish.Enabled = UserRightMgr.GetRightNoDC(Rights.BACHHDRCLOSE)
        'If Me.btnFinish.Enabled = True Then
        '    Me.btnFinish.Enabled = ValidationBill.CanCloseBanch(Me.txtdc_code.Text, Me.txtbch_no.Text)
        'End If
    End Sub
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
                    .ButtonEnabled(BK_NEW) = UserRightMgr.GetRightNoDC(Rights.BACHHDRNEW)
                    .ButtonEnabled(BK_EDIT) = UserRightMgr.GetRightNoDC(Rights.BACHHDREDIT)
                    .ButtonEnabled(BK_DELETE) = UserRightMgr.GetRightNoDC(Rights.BACHHDRREMOVE)
                    .ButtonEnabled("LoadItem") = UserRightMgr.GetRightNoDC(Rights.BACHHDRNEW)
                Else
                    .ButtonEnabled(BK_EDIT) = False
                    .ButtonEnabled(BK_NEW) = False
                    .ButtonEnabled(BK_DELETE) = False
                    .ButtonEnabled("LoadItem") = False
                End If
            End With
        End If
        'setBtnAssignEnable()
        setBtnCloseEnable()
        splMain.Visible = Not Me.Editable
    End Sub
#End Region
#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
