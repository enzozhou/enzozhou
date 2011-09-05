Public Class frmUserSetting
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents UserList As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserSetting))
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.lblUser = New System.Windows.Forms.Label
        Me.UserList = New System.Windows.Forms.CheckedListBox
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(419, 293)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(120, 34)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "Close"
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(204, 293)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(120, 34)
        Me.btnRemove.TabIndex = 13
        Me.btnRemove.Text = "Remove"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(12, 293)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(120, 34)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "Add"
        '
        'lblUser
        '
        Me.lblUser.Location = New System.Drawing.Point(2, 7)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(288, 17)
        Me.lblUser.TabIndex = 10
        Me.lblUser.Text = "ÓÃ»§£º"
        '
        'UserList
        '
        Me.UserList.CheckOnClick = True
        Me.UserList.ColumnWidth = 340
        Me.UserList.Location = New System.Drawing.Point(4, 27)
        Me.UserList.MultiColumn = True
        Me.UserList.Name = "UserList"
        Me.UserList.Size = New System.Drawing.Size(571, 260)
        Me.UserList.TabIndex = 9
        '
        'frmUserSetting
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(577, 331)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.UserList)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserSetting"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmUserSetting"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Enum enumUserAction
        None
        Add
        Remove
    End Enum

    Private enAction As enumUserAction

    Public ReadOnly Property Action() As enumUserAction
        Get
            Return enAction
        End Get
    End Property

    Dim look As New YT.BusinessObject.Lookup


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        enAction = enumUserAction.Add
        GetSelectedListForReturn()
        Me.Close()
    End Sub
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        enAction = enumUserAction.Remove
        GetSelectedListForReturn()
        Me.Close()
    End Sub

    Private Sub frmUserSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadControlText()
        enAction = enumUserAction.None
        RefreshUserList()
    End Sub

    Private objSelectedUserList As New Microsoft.VisualBasic.Collection

    Public ReadOnly Property SelectedUserList() As Microsoft.VisualBasic.Collection
        Get
            Return objSelectedUserList
        End Get
    End Property

    Private Sub GetSelectedListForReturn()
        If objSelectedUserList Is Nothing Then
            Return
        End If
        While objSelectedUserList.Count > 0
            objSelectedUserList.Remove(1)
        End While

        Dim i As Integer
        Dim UserNo As String
        Try
            For i = 0 To UserList.Items.Count - 1
                If UserList.GetItemChecked(i) Then
                    UserNo = CType(objCurrentUserList.Tables(0).Rows(i).Item(0), String)
                    objSelectedUserList.Add(UserNo)
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub


    Private objCurrentUserList As DataSet

    Private Sub RefreshUserListInternal()
        On Error Resume Next
        Dim obj As DataSet
        obj = look.GetUserListByDC()
        UserList.DataSource = obj.Tables(0).DefaultView
        UserList.ValueMember = obj.Tables(0).Columns(0).ColumnName
        UserList.DisplayMember = obj.Tables(0).Columns(1).ColumnName
        objCurrentUserList = obj
    End Sub

    Private Sub RefreshUserList()
        RefreshUserListInternal()
    End Sub

    Private Sub LoadControlText()
        SetControlText(lblUser, "ID_cap_frmUserSetting_lblUser", True)
        SetControlText(Me.btnAdd, "ID_cap_frmUserSetting_btnAdd", True)
        SetControlText(Me.btnClose, "ID_cap_frmUserSetting_btnClose", True)
        SetControlText(Me.btnRemove, "ID_cap_frmUserSetting_btnRemove", True)
        SetControlText(Me, "ID_cap_frmUserSetting_Title", True)
    End Sub



    Private Sub btnRefreshList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshUserList()
    End Sub
End Class
