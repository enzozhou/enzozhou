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
    Friend WithEvents btnAddRemovePermission As System.Windows.Forms.Button
    Friend WithEvents btnAddRemoveUser As System.Windows.Forms.Button
    Protected Friend WithEvents tabGrid As System.Windows.Forms.TabControl

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.splMain = New System.Windows.Forms.Splitter
        Me.txtrole_code = New System.Windows.Forms.TextBox
        Me.lblrole_code = New System.Windows.Forms.Label
        Me.txtrole_name = New System.Windows.Forms.TextBox
        Me.lblrole_name = New System.Windows.Forms.Label
        Me.txtremark = New System.Windows.Forms.TextBox
        Me.lblremark = New System.Windows.Forms.Label
        Me.txtopt_by = New System.Windows.Forms.TextBox
        Me.lblopt_by = New System.Windows.Forms.Label
        Me.dtpopt_dtime = New System.Windows.Forms.DateTimePicker
        Me.lblopt_dtime = New System.Windows.Forms.Label
        Me.txtopt_timestamp = New System.Windows.Forms.TextBox
        Me.lblopt_timestamp = New System.Windows.Forms.Label
        Me.pnlMain = New System.Windows.Forms.Panel
        Me.btnAddRemovePermission = New System.Windows.Forms.Button
        Me.btnAddRemoveUser = New System.Windows.Forms.Button
        Me.tp__clsRolepermission = New System.Windows.Forms.TabPage
        Me.gd__clsRolepermission = New YTUI.DataGrid
        Me.tp__clsUserrole = New System.Windows.Forms.TabPage
        Me.gd__clsUserrole = New YTUI.DataGrid
        Me.tabGrid = New System.Windows.Forms.TabControl
        CType(Me.ErrorPrvd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMain.SuspendLayout()
        Me.tp__clsRolepermission.SuspendLayout()
        CType(Me.gd__clsRolepermission, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tp__clsUserrole.SuspendLayout()
        CType(Me.gd__clsUserrole, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.CQ.Location = New System.Drawing.Point(0, 34)
        Me.CQ.Size = New System.Drawing.Size(789, 25)
        '
        'CB
        '
        Me.CB.Location = New System.Drawing.Point(0, 0)
        Me.CB.Size = New System.Drawing.Size(789, 34)
        '
        'splMain
        '
        Me.splMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.splMain.Location = New System.Drawing.Point(0, 249)
        Me.splMain.Name = "splMain"
        Me.splMain.Size = New System.Drawing.Size(789, 9)
        Me.splMain.TabIndex = 12
        Me.splMain.TabStop = False
        '
        'txtrole_code
        '
        Me.txtrole_code.Location = New System.Drawing.Point(166, 11)
        Me.txtrole_code.Name = "txtrole_code"
        Me.txtrole_code.Size = New System.Drawing.Size(270, 23)
        Me.txtrole_code.TabIndex = 2
        '
        'lblrole_code
        '
        Me.lblrole_code.BackColor = System.Drawing.Color.Transparent
        Me.lblrole_code.Location = New System.Drawing.Point(12, 14)
        Me.lblrole_code.Name = "lblrole_code"
        Me.lblrole_code.Size = New System.Drawing.Size(145, 19)
        Me.lblrole_code.TabIndex = 1
        Me.lblrole_code.Text = "role_code"
        '
        'txtrole_name
        '
        Me.txtrole_name.Location = New System.Drawing.Point(166, 37)
        Me.txtrole_name.Name = "txtrole_name"
        Me.txtrole_name.Size = New System.Drawing.Size(270, 23)
        Me.txtrole_name.TabIndex = 4
        '
        'lblrole_name
        '
        Me.lblrole_name.BackColor = System.Drawing.Color.Transparent
        Me.lblrole_name.Location = New System.Drawing.Point(12, 39)
        Me.lblrole_name.Name = "lblrole_name"
        Me.lblrole_name.Size = New System.Drawing.Size(145, 19)
        Me.lblrole_name.TabIndex = 3
        Me.lblrole_name.Text = "role_name"
        '
        'txtremark
        '
        Me.txtremark.Location = New System.Drawing.Point(166, 61)
        Me.txtremark.Name = "txtremark"
        Me.txtremark.Size = New System.Drawing.Size(270, 23)
        Me.txtremark.TabIndex = 6
        '
        'lblremark
        '
        Me.lblremark.BackColor = System.Drawing.Color.Transparent
        Me.lblremark.Location = New System.Drawing.Point(12, 64)
        Me.lblremark.Name = "lblremark"
        Me.lblremark.Size = New System.Drawing.Size(145, 19)
        Me.lblremark.TabIndex = 5
        Me.lblremark.Text = "remark"
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
        Me.pnlMain.Controls.Add(Me.btnAddRemovePermission)
        Me.pnlMain.Controls.Add(Me.btnAddRemoveUser)
        Me.pnlMain.Controls.Add(Me.txtrole_code)
        Me.pnlMain.Controls.Add(Me.lblrole_code)
        Me.pnlMain.Controls.Add(Me.txtrole_name)
        Me.pnlMain.Controls.Add(Me.lblrole_name)
        Me.pnlMain.Controls.Add(Me.txtremark)
        Me.pnlMain.Controls.Add(Me.lblremark)
        Me.pnlMain.Controls.Add(Me.txtopt_by)
        Me.pnlMain.Controls.Add(Me.lblopt_by)
        Me.pnlMain.Controls.Add(Me.dtpopt_dtime)
        Me.pnlMain.Controls.Add(Me.lblopt_dtime)
        Me.pnlMain.Controls.Add(Me.txtopt_timestamp)
        Me.pnlMain.Controls.Add(Me.lblopt_timestamp)
        Me.pnlMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMain.Location = New System.Drawing.Point(0, 59)
        Me.pnlMain.Name = "pnlMain"
        Me.pnlMain.Size = New System.Drawing.Size(789, 190)
        Me.pnlMain.TabIndex = 0
        '
        'btnAddRemovePermission
        '
        Me.btnAddRemovePermission.Location = New System.Drawing.Point(446, 103)
        Me.btnAddRemovePermission.Name = "btnAddRemovePermission"
        Me.btnAddRemovePermission.Size = New System.Drawing.Size(104, 30)
        Me.btnAddRemovePermission.TabIndex = 14
        Me.btnAddRemovePermission.Text = "添加/移除权限"
        '
        'btnAddRemoveUser
        '
        Me.btnAddRemoveUser.Location = New System.Drawing.Point(446, 29)
        Me.btnAddRemoveUser.Name = "btnAddRemoveUser"
        Me.btnAddRemoveUser.Size = New System.Drawing.Size(104, 30)
        Me.btnAddRemoveUser.TabIndex = 13
        Me.btnAddRemoveUser.Text = "添加/删除 用户"
        '
        'tp__clsRolepermission
        '
        Me.tp__clsRolepermission.AutoScroll = True
        Me.tp__clsRolepermission.Controls.Add(Me.gd__clsRolepermission)
        Me.tp__clsRolepermission.Location = New System.Drawing.Point(4, 4)
        Me.tp__clsRolepermission.Name = "tp__clsRolepermission"
        Me.tp__clsRolepermission.Size = New System.Drawing.Size(781, 139)
        Me.tp__clsRolepermission.TabIndex = 0
        Me.tp__clsRolepermission.Text = "clsRolepermissions"
        '
        'gd__clsRolepermission
        '
        Me.gd__clsRolepermission.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsRolepermission.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsRolepermission.ColumnListName = ""
        Me.gd__clsRolepermission.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsRolepermission.Deletable = True
        Me.gd__clsRolepermission.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsRolepermission.Editable = True
        Me.gd__clsRolepermission.Hierarchical = True
        Me.gd__clsRolepermission.Location = New System.Drawing.Point(0, 0)
        Me.gd__clsRolepermission.Name = "gd__clsRolepermission"
        Me.gd__clsRolepermission.RecordNavigator = True
        Me.gd__clsRolepermission.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsRolepermission.Size = New System.Drawing.Size(781, 139)
        Me.gd__clsRolepermission.TabIndex = 12
        Me.gd__clsRolepermission.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'tp__clsUserrole
        '
        Me.tp__clsUserrole.AutoScroll = True
        Me.tp__clsUserrole.Controls.Add(Me.gd__clsUserrole)
        Me.tp__clsUserrole.Location = New System.Drawing.Point(4, 4)
        Me.tp__clsUserrole.Name = "tp__clsUserrole"
        Me.tp__clsUserrole.Size = New System.Drawing.Size(781, 143)
        Me.tp__clsUserrole.TabIndex = 0
        Me.tp__clsUserrole.Text = "clsUserroles"
        '
        'gd__clsUserrole
        '
        Me.gd__clsUserrole.AllowAddNew = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsUserrole.AllowDelete = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsUserrole.ColumnListName = ""
        Me.gd__clsUserrole.Cursor = System.Windows.Forms.Cursors.Default
        Me.gd__clsUserrole.Deletable = True
        Me.gd__clsUserrole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gd__clsUserrole.Editable = True
        Me.gd__clsUserrole.Hierarchical = True
        Me.gd__clsUserrole.Location = New System.Drawing.Point(0, 0)
        Me.gd__clsUserrole.Name = "gd__clsUserrole"
        Me.gd__clsUserrole.RecordNavigator = True
        Me.gd__clsUserrole.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        Me.gd__clsUserrole.Size = New System.Drawing.Size(781, 143)
        Me.gd__clsUserrole.TabIndex = 13
        Me.gd__clsUserrole.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.[True]
        '
        'tabGrid
        '
        Me.tabGrid.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabGrid.Controls.Add(Me.tp__clsRolepermission)
        Me.tabGrid.Controls.Add(Me.tp__clsUserrole)
        Me.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabGrid.Location = New System.Drawing.Point(0, 258)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.SelectedIndex = 0
        Me.tabGrid.Size = New System.Drawing.Size(789, 169)
        Me.tabGrid.TabIndex = 11
        '
        'frmclsRoleBase__
        '
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(789, 427)
        Me.Controls.Add(Me.tabGrid)
        Me.Controls.Add(Me.splMain)
        Me.Controls.Add(Me.pnlMain)
        Me.Font = New System.Drawing.Font("Microsoft YaHei", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmclsRoleBase__"
        Me.Text = "2380"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Controls.SetChildIndex(Me.CB, 0)
        Me.Controls.SetChildIndex(Me.CQ, 0)
        Me.Controls.SetChildIndex(Me.pnlMain, 0)
        Me.Controls.SetChildIndex(Me.splMain, 0)
        Me.Controls.SetChildIndex(Me.tabGrid, 0)
        Me.Controls.SetChildIndex(Me.chkIsDirty, 0)
        CType(Me.ErrorPrvd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMain.ResumeLayout(False)
        Me.pnlMain.PerformLayout()
        Me.tp__clsRolepermission.ResumeLayout(False)
        CType(Me.gd__clsRolepermission, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tp__clsUserrole.ResumeLayout(False)
        CType(Me.gd__clsUserrole, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabGrid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " COM Express generated code "
    Public Overrides Sub DataBind()
        Dim objBO As clsRole = Me.Current

        Try
            MyBase.DataBind()
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
        Try
            MyBase.Format()
            MyBase.FormatControl(txtrole_code, "role_code", lblrole_code, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
            MyBase.FormatControl(txtrole_name, "role_name", lblrole_name, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
            MyBase.FormatControl(txtremark, "remark", lblremark, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
            MyBase.FormatControl(txtopt_by, "opt_by", lblopt_by, AddressOf mControlHelper.TextBoxFormatter, , AddressOf mControlHelper.ReadOnlySupporter)
            MyBase.FormatControl(dtpopt_dtime, "opt_dtime", lblopt_dtime, AddressOf mControlHelper.GeneralControlFormatter, , AddressOf mControlHelper.EnabledSupporter)
            Me.tp__clsRolepermission.Text = mobjApp.GetLayout.CXObjectLays(GetType(clsRolepermission).Name).ColCaptionText
            CType(Me.gd__clsRolepermission, IGrid).FormatGrid()
            Me.tp__clsUserrole.Text = mobjApp.GetLayout.CXObjectLays(GetType(clsUserrole).Name).ColCaptionText
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
            Return CType(tabGrid.TabPages(tabGrid.SelectedIndex).Controls(0), IGrid)
        End Get
    End Property

    Protected Overrides Sub LoadChildrenData(Optional ByVal blnReset As Boolean = False)
        CType(Current, clsRole).LoadclsRolepermissions(blnReset)
        CType(Current, clsRole).LoadclsUserroles(blnReset)
    End Sub

    Private Sub frmclsRole_OnCurrent(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.OnCurrent
        LoadChildrenData()
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

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region

    Private Sub btnAddRemoveUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRemoveUser.Click

        Dim frm As New frmUserSetting
        Dim i As Integer
        Dim sTemp As String
        Dim sUser As String
        Dim dc_code As String
        Dim SelectList As Microsoft.VisualBasic.Collection
        If (UserRightMgr.GetRightNoDC("Add_Remove_User") = False) Then
            ErrMsg("ID_msg_err_No_Right", True, "权限不够！请联系管理员.")
            Return
        End If
        tabGrid.SelectedIndex = 1
        SetModalFormStyle(frm)
        frm.ShowDialog(MainForm)
        If frm.Action = frmUserSetting.enumUserAction.Add Then
            SelectList = frm.SelectedUserList
            For i = 1 To SelectList.Count
                sTemp = CType(SelectList.Item(i), String)
                Split4UserAndStore(sTemp, sUser)
                AddUser(sUser, dc_code)
            Next
        ElseIf frm.Action = frmUserSetting.enumUserAction.Remove Then
            SelectList = frm.SelectedUserList
            For i = 1 To SelectList.Count
                sTemp = CType(SelectList.Item(i), String)
                Split4UserAndStore(sTemp, sUser)
                RemoveUser(sUser, dc_code)
            Next
        End If
        frm.Dispose()
        frm = Nothing
        Me.RefreshData()
    End Sub

    Private Sub btnAddRemovePermission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRemovePermission.Click

        Dim frm As New frmPermissionSetting
        Dim i As Integer
        Dim RightNo As String
        Dim SelectList As Microsoft.VisualBasic.Collection
        If (UserRightMgr.GetRightNoDC("AddRemovePermission") = False) Then
            ErrMsg("ID_msg_err_No_Right", True, "权限不够！请联系管理员.")
            Return
        End If
        tabGrid.SelectedIndex = 0
        frm.ParentType = frmPermissionSetting.enumParentType.role
        SetModalFormStyle(frm)
        frm.ShowDialog(MainForm)
        If frm.Action = frmPermissionSetting.enumPermissionAction.Add Then
            SelectList = frm.SelectedPermissionList
            For i = 1 To SelectList.Count
                RightNo = CType(SelectList.Item(i), String)
                AddRightNo(RightNo)
            Next
        ElseIf frm.Action = frmPermissionSetting.enumPermissionAction.Remove Then
            SelectList = frm.SelectedPermissionList
            For i = 1 To SelectList.Count
                RightNo = CType(SelectList.Item(i), String)
                RemoveRightNo(RightNo)
            Next
        End If
        frm.Dispose()
        frm = Nothing
        Me.RefreshData()
    End Sub

    Private Sub Split4UserAndStore(ByVal sTemp As String, ByRef sUser As String)
        Dim pos As Integer
        pos = sTemp.IndexOf("@")
        If (pos < 0) Then
            sUser = sTemp
        Else
            sUser = Microsoft.VisualBasic.Left(sTemp, pos)
        End If
    End Sub
    Private Sub AddUser(ByVal sUser As String, ByVal dc_code As String)

        Dim objRole As clsrole
        objRole = DirectCast(Me.Current, clsrole)
        Dim strSQL As String
        strSQL = "exec stp_acs_RoleAddUser '" + objRole.role_code + "','" + sUser + "','" + Trim(UserRightMgr.gUserCode) + "'"
        Try
            COMExpress.BusinessObject.DatabaseHelper.ExecuteSQL(strSQL, CommandType.Text)
        Catch ex As Exception
        End Try

    End Sub

    Private Sub RemoveUser(ByVal user_code As String, ByVal dc_code As String)
        Dim objRole As clsRole
        objRole = DirectCast(Me.Current, clsRole)
        Dim strSQL As String
        strSQL = "exec stp_acs_RoleRemoveUser '" + objRole.role_code + "','" + user_code + "','" + Trim(UserRightMgr.gUserCode) + "'"
        Try
            COMExpress.BusinessObject.DatabaseHelper.ExecuteSQL(strSQL, CommandType.Text)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub AddRightNo(ByVal RightNo As String)

        Dim objRole As clsRole
        objRole = DirectCast(Me.Current, clsRole)
        Dim strSQL As String
        strSQL = "exec stp_acs_RoleAddRight '" + objRole.role_code + "','" + RightNo + "','" + Trim(UserRightMgr.gUserCode) + "'"
        Try
            COMExpress.BusinessObject.DatabaseHelper.ExecuteSQL(strSQL, CommandType.Text)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub RemoveRightNo(ByVal RightNo As String)
        Dim objRole As clsRole
        objRole = DirectCast(Me.Current, clsRole)
        Dim strSQL As String
        strSQL = "exec stp_acs_RoleRemoveRight '" + objRole.role_code + "','" + RightNo + "','" + Trim(UserRightMgr.gUserCode) + "'"
        Try
            COMExpress.BusinessObject.DatabaseHelper.ExecuteSQL(strSQL, CommandType.Text)
        Catch ex As Exception
        End Try
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
                    .ButtonEnabled(BK_NEW) = UserRightMgr.GetRightNoDC(Rights.ROLENEW)
                    .ButtonEnabled(BK_EDIT) = UserRightMgr.GetRightNoDC(Rights.ROLEEDIT)
                    .ButtonEnabled(BK_DELETE) = UserRightMgr.GetRightNoDC(Rights.ROLEREMOVE)
                    .ButtonEnabled("LoadItem") = UserRightMgr.GetRightNoDC(Rights.DNHDRLOAD)
                Else
                    .ButtonEnabled(BK_EDIT) = False
                    .ButtonEnabled(BK_NEW) = False
                    .ButtonEnabled(BK_DELETE) = False
                    .ButtonEnabled("LoadItem") = False
                End If
            End With
        End If
        Me.btnAddRemovePermission.Enabled = UserRightMgr.GetRightNoDC(Rights.ROLEREMOVEPERM)
        Me.btnAddRemoveUser.Enabled = UserRightMgr.GetRightNoDC(Rights.ROLEADDPERM)
    End Sub
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
