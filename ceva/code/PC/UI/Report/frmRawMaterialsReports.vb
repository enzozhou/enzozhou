Imports ImportExport
Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports YT.BusinessObject

Public Class frmRawMaterialsReports
    Inherits CXPrintForm
    'Inherits CXMdiChildForm
    'Implements IPrintableForm

    Public CaptionText As String

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents lblBanch As System.Windows.Forms.Label
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents txtBanch As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Protected Friend WithEvents tabGrid As System.Windows.Forms.TabControl
    Protected Friend WithEvents tp__clsWO_Info As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsWO_Info As YTUI.DataGrid
    Protected Friend WithEvents tp__clsPO_Info As System.Windows.Forms.TabPage
    Protected Friend WithEvents gd__clsPO_Info As YTUI.DataGrid
    Friend WithEvents groupOption As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblItem = New System.Windows.Forms.Label
        Me.lblBanch = New System.Windows.Forms.Label
        Me.txtItem = New System.Windows.Forms.TextBox
        Me.txtBanch = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.groupOption = New System.Windows.Forms.GroupBox
        Me.tabGrid = New System.Windows.Forms.TabControl
        Me.tp__clsWO_Info = New System.Windows.Forms.TabPage
        Me.gd__clsWO_Info = New YTUI.DataGrid
        Me.tp__clsPO_Info = New System.Windows.Forms.TabPage
        Me.gd__clsPO_Info = New YTUI.DataGrid
        Me.groupOption.SuspendLayout()
        Me.tabGrid.SuspendLayout()
        Me.tp__clsWO_Info.SuspendLayout()
        CType(Me.gd__clsWO_Info, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp__clsPO_Info.SuspendLayout()
        CType(Me.gd__clsPO_Info, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CB
        '
        Me.CB.Size = New System.Drawing.Size(891, 32)
        '
        'lblItem
        '
        Me.lblItem.Location = New System.Drawing.Point(10, 19)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(96, 25)
        Me.lblItem.TabIndex = 1
        Me.lblItem.Text = "产品编码"
        '
        'lblBanch
        '
        Me.lblBanch.Location = New System.Drawing.Point(339, 19)
        Me.lblBanch.Name = "lblBanch"
        Me.lblBanch.Size = New System.Drawing.Size(86, 24)
        Me.lblBanch.TabIndex = 2
        Me.lblBanch.Text = "批次号"
        '
        'txtItem
        '
        Me.txtItem.Location = New System.Drawing.Point(83, 19)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(190, 23)
        Me.txtItem.TabIndex = 4
        '
        'txtBanch
        '
        Me.txtBanch.Location = New System.Drawing.Point(417, 19)
        Me.txtBanch.Name = "txtBanch"
        Me.txtBanch.Size = New System.Drawing.Size(186, 23)
        Me.txtBanch.TabIndex = 5
        '
        'btnOK
        '
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnOK.Location = New System.Drawing.Point(660, 19)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(90, 25)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "查询"
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClear.Location = New System.Drawing.Point(769, 19)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(90, 25)
        Me.btnClear.TabIndex = 9
        Me.btnClear.Text = "清除"
        '
        'groupOption
        '
        Me.groupOption.Controls.Add(Me.txtBanch)
        Me.groupOption.Controls.Add(Me.txtItem)
        Me.groupOption.Controls.Add(Me.btnClear)
        Me.groupOption.Controls.Add(Me.btnOK)
        Me.groupOption.Controls.Add(Me.lblBanch)
        Me.groupOption.Controls.Add(Me.lblItem)
        Me.groupOption.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupOption.Location = New System.Drawing.Point(0, 32)
        Me.groupOption.Name = "groupOption"
        Me.groupOption.Size = New System.Drawing.Size(891, 57)
        Me.groupOption.TabIndex = 21
        Me.groupOption.TabStop = False
        Me.groupOption.Text = "查询条件"
        '
        'tabGrid
        '
        Me.tabGrid.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabGrid.Controls.Add(Me.tp__clsWO_Info)
        Me.tabGrid.Controls.Add(Me.tp__clsPO_Info)
        Me.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrid.Location = New System.Drawing.Point(0, 89)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.SelectedIndex = 0
        Me.tabGrid.Size = New System.Drawing.Size(891, 394)
        Me.tabGrid.TabIndex = 22
        '
        'tp__clsWO_Info
        '
        Me.tp__clsWO_Info.AutoScroll = True
        Me.tp__clsWO_Info.Controls.Add(Me.gd__clsWO_Info)
        Me.tp__clsWO_Info.Location = New System.Drawing.Point(4, 4)
        Me.tp__clsWO_Info.Name = "tp__clsWO_Info"
        Me.tp__clsWO_Info.Size = New System.Drawing.Size(883, 364)
        Me.tp__clsWO_Info.TabIndex = 0
        Me.tp__clsWO_Info.Text = "领料信息列表"
        '
        'gd__clsWO_Info
        '
        Me.gd__clsWO_Info.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gd__clsWO_Info.ColumnListName = ""
        Me.gd__clsWO_Info.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsWO_Info.Deletable = False
        Me.gd__clsWO_Info.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsWO_Info.Editable = False
        Me.gd__clsWO_Info.Hierarchical = True
        Me.gd__clsWO_Info.Location = New System.Drawing.Point(0, 0)
        Me.gd__clsWO_Info.Name = "gd__clsWO_Info"
        Me.gd__clsWO_Info.RecordNavigator = True
        Me.gd__clsWO_Info.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gd__clsWO_Info.Size = New System.Drawing.Size(883, 364)
        Me.gd__clsWO_Info.TabIndex = 19
        '
        'tp__clsPO_Info
        '
        Me.tp__clsPO_Info.AutoScroll = True
        Me.tp__clsPO_Info.Controls.Add(Me.gd__clsPO_Info)
        Me.tp__clsPO_Info.Location = New System.Drawing.Point(4, 4)
        Me.tp__clsPO_Info.Name = "tp__clsPO_Info"
        Me.tp__clsPO_Info.Size = New System.Drawing.Size(883, 364)
        Me.tp__clsPO_Info.TabIndex = 0
        Me.tp__clsPO_Info.Text = "采购信息列表"
        '
        'gd__clsPO_Info
        '
        Me.gd__clsPO_Info.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gd__clsPO_Info.ColumnListName = ""
        Me.gd__clsPO_Info.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsPO_Info.Deletable = False
        Me.gd__clsPO_Info.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsPO_Info.Editable = False
        Me.gd__clsPO_Info.Hierarchical = True
        Me.gd__clsPO_Info.Location = New System.Drawing.Point(0, 0)
        Me.gd__clsPO_Info.Name = "gd__clsPO_Info"
        Me.gd__clsPO_Info.RecordNavigator = True
        Me.gd__clsPO_Info.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.gd__clsPO_Info.Size = New System.Drawing.Size(883, 364)
        Me.gd__clsPO_Info.TabIndex = 20
        '
        'frmRawMaterialsReports
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(891, 483)
        Me.Controls.Add(Me.tabGrid)
        Me.Controls.Add(Me.groupOption)
        Me.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!)
        Me.Name = "frmRawMaterialsReports"
        Me.Text = "原料追溯报表"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.CB, 0)
        Me.Controls.SetChildIndex(Me.groupOption, 0)
        Me.Controls.SetChildIndex(Me.tabGrid, 0)
        Me.groupOption.ResumeLayout(False)
        Me.groupOption.PerformLayout()
        Me.tabGrid.ResumeLayout(False)
        Me.tp__clsWO_Info.ResumeLayout(False)
        CType(Me.gd__clsWO_Info, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp__clsPO_Info.ResumeLayout(False)
        CType(Me.gd__clsPO_Info, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click


        CType(Me.gd__clsPO_Info, IGrid).DataSource = Nothing
        CType(Me.gd__clsWO_Info, IGrid).DataSource = Nothing
        gd__clsPO_Info.Refresh()
        gd__clsWO_Info.Refresh()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim obj As DataSet = New DataSet
        Dim sql As String
        Dim imp As New Lookup
        Try
            ''get WO  reports information
            sql = "RP_get_RawMaterials_WO_report  '" + Me.txtItem.Text.ToString + "','" + Me.txtBanch.Text.ToString + "'"
            obj = imp.SQLToDataSet(sql, CommandType.Text, ReportCommandTimeout)
            CType(Me.gd__clsWO_Info, IGrid).DataSource = obj.Tables(0)
            ''get PO  reports information
            sql = "RP_get_RawMaterials_PO_report  '" + Me.txtItem.Text.ToString + "','" + Me.txtBanch.Text.ToString + "'"
            obj = imp.SQLToDataSet(sql, CommandType.Text, ReportCommandTimeout)
            CType(Me.gd__clsPO_Info, IGrid).DataSource = obj.Tables(0)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub gd__clsWO_Info_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gd__clsWO_Info.DoubleClick
        ExportInfo("WO")
    End Sub

    Private Sub gd__clsPO_Info_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gd__clsPO_Info.DoubleClick
        ExportInfo("PO")
    End Sub

    Private Sub ExportInfo(ByVal fromsource As String)
        Dim obj As DataSet = New DataSet
        Dim XmlFile As String
        Dim sql As String
        Dim imp As New Lookup
        Dim s As String
        Dim ofd As New SaveFileDialog
        Try
            Select Case fromsource
                Case "PO"
                    ''get PO  reports information
                    sql = "RP_get_RawMaterials_PO_report  '" + Me.txtItem.Text.ToString + "','" + Me.txtBanch.Text.ToString + "'"
                    obj = imp.SQLToDataSet(sql, CommandType.Text, ReportCommandTimeout)
                    XmlFile = "RawMaterials_PO.xml"
                Case "WO"
                    sql = "RP_get_RawMaterials_WO_report  '" + Me.txtItem.Text.ToString + "','" + Me.txtBanch.Text.ToString + "'"
                    obj = imp.SQLToDataSet(sql, CommandType.Text, ReportCommandTimeout)
                    XmlFile = "RawMaterials_WO.xml"
                Case Else
                    Return
            End Select
        Catch ex As Exception
        End Try
        ofd.Filter = "Excel File(*.xls)|*.xls"
        ofd.CheckFileExists = False
        ofd.AddExtension = True
        If ofd.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            s = ofd.FileName()
            Dim exp As New ProcessorBase(MainForm)
            Dim clf As New CXListForm
            If obj.Tables(0).Rows.Count <= 0 Then
                MsgBox("报表没有数据，请重新设置查询条件！")
            Else
                exp.SetSourceDevice(obj, clf.MergedFilters)
                exp.RunExport(s, GetLibFile(XmlFile))
                Dim wkbNew As New ImportExport.Office.ExcelFile
                wkbNew.OpenWorkBookShow(s)
                GC.Collect()
            End If
        End If
        ofd.Dispose()
        ofd = Nothing
        GC.Collect()
    End Sub

End Class
