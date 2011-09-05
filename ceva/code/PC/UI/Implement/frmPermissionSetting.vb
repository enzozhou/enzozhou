Public Class frmPermissionSetting
    Inherits System.Windows.Forms.Form

#Region " Windows 窗体设计器生成的代码 "

    Public Sub New()
        MyBase.New()

        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        '在 InitializeComponent() 调用之后添加任何初始化

    End Sub

    '窗体重写 dispose 以清理组件列表。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改此过程。
    '不要使用代码编辑器修改它。
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PermissionList As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblPermission As System.Windows.Forms.Label
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkClearAll As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPermissionSetting))
        Me.PermissionList = New System.Windows.Forms.CheckedListBox
        Me.lblPermission = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.chkSelectAll = New System.Windows.Forms.CheckBox
        Me.chkClearAll = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'PermissionList
        '
        Me.PermissionList.CheckOnClick = True
        Me.PermissionList.ColumnWidth = 340
        Me.PermissionList.Location = New System.Drawing.Point(0, 33)
        Me.PermissionList.MultiColumn = True
        Me.PermissionList.Name = "PermissionList"
        Me.PermissionList.Size = New System.Drawing.Size(708, 260)
        Me.PermissionList.TabIndex = 0
        '
        'lblPermission
        '
        Me.lblPermission.Location = New System.Drawing.Point(5, 9)
        Me.lblPermission.Name = "lblPermission"
        Me.lblPermission.Size = New System.Drawing.Size(288, 18)
        Me.lblPermission.TabIndex = 1
        Me.lblPermission.Text = "Permissions:"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(387, 294)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(120, 35)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add"
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(579, 294)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(120, 35)
        Me.btnRemove.TabIndex = 4
        Me.btnRemove.Text = "Remove"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(730, 353)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 35)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        '
        'chkSelectAll
        '
        Me.chkSelectAll.Location = New System.Drawing.Point(7, 296)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(87, 26)
        Me.chkSelectAll.TabIndex = 9
        Me.chkSelectAll.Text = "全选"
        '
        'chkClearAll
        '
        Me.chkClearAll.Location = New System.Drawing.Point(113, 296)
        Me.chkClearAll.Name = "chkClearAll"
        Me.chkClearAll.Size = New System.Drawing.Size(86, 26)
        Me.chkClearAll.TabIndex = 10
        Me.chkClearAll.Text = "清除"
        '
        'frmPermissionSetting
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(711, 335)
        Me.Controls.Add(Me.chkClearAll)
        Me.Controls.Add(Me.chkSelectAll)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblPermission)
        Me.Controls.Add(Me.PermissionList)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPermissionSetting"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Permission Select"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Enum enumParentType
        user
        role
    End Enum

    Public Enum enumPermissionAction
        None
        Add
        Remove
    End Enum

    Private enAction As enumPermissionAction

    Public ReadOnly Property Action() As enumPermissionAction
        Get
            Return enAction
        End Get
    End Property
    Private enParentType As enumParentType

    Public Property ParentType() As enumParentType
        Get
            Return enParentType
        End Get
        Set(ByVal Value As enumParentType)
            enParentType = Value
        End Set
    End Property

    Private bApplyToUser As Boolean = False
    Public ReadOnly Property ApplyToUser() As Boolean
        Get
            Return bApplyToUser
        End Get
    End Property

    Dim look As New YT.BusinessObject.Lookup

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        enAction = enumPermissionAction.Add
        GetSelectedListForReturn()
        Me.Close()
    End Sub
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        enAction = enumPermissionAction.Remove
        GetSelectedListForReturn()
        Me.Close()
    End Sub

    Private Sub frmPermissionSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadControlText()
        enAction = enumPermissionAction.None
        RefreshPermissionList()
    End Sub

    Private objCurrentPermissionList As DataSet

    Private Sub RefreshPermissionListInternal()
        On Error Resume Next
        Dim obj As DataSet
        obj = look.GetPermissionList()
        PermissionList.DataSource = obj.Tables(0).DefaultView
        PermissionList.ValueMember = obj.Tables(0).Columns(0).ColumnName
        PermissionList.DisplayMember = obj.Tables(0).Columns(1).ColumnName
        objCurrentPermissionList = obj
    End Sub

    Private Sub RefreshPermissionList()
        RefreshPermissionListInternal()
    End Sub

    Private objSelectedPermissionList As New Microsoft.VisualBasic.Collection

    Public ReadOnly Property SelectedPermissionList() As Microsoft.VisualBasic.Collection
        Get
            Return objSelectedPermissionList
        End Get
    End Property


    Private Sub GetSelectedListForReturn()
        While objSelectedPermissionList.Count > 0
            objSelectedPermissionList.Remove(1)
        End While
        If objCurrentPermissionList Is Nothing Then
            Return
        End If

        Dim i As Integer
        Dim RightNo As String
        Try
            For i = 0 To PermissionList.Items.Count - 1
                If PermissionList.GetItemChecked(i) Then
                    RightNo = CType(objCurrentPermissionList.Tables(0).Rows(i).Item(0), String)
                    objSelectedPermissionList.Add(RightNo)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadControlText()
        SetControlText(lblPermission, "ID_cap_frmPermissionSetting_lblPermission", True)
        SetControlText(Me.btnAdd, "ID_cap_frmPermissionSetting_btnAdd", True)
        SetControlText(Me.btnClose, "ID_cap_frmPermissionSetting_btnClose", True)
        SetControlText(Me.btnRemove, "ID_cap_frmPermissionSetting_btnRemove", True)
        SetControlText(Me, "ID_cap_frmPermissionSetting_Title", True)
    End Sub


    Private Sub SetListCheckStatus(ByVal bCheck As Boolean)
        Dim i As Integer
        For i = 0 To PermissionList.Items.Count - 1
            PermissionList.SetItemChecked(i, bCheck)
        Next
    End Sub


    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        If chkSelectAll.Checked Then
            SetListCheckStatus(True)
        End If
    End Sub

    Private Sub chkClearAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClearAll.CheckedChanged
        If chkClearAll.Checked Then
            SetListCheckStatus(False)
        End If
    End Sub
End Class


