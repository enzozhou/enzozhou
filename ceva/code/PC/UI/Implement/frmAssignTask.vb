Imports YT
Imports YT.BusinessObject
Imports COMExpress.BusinessObject
Public Class frmAssignTask
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
    Friend WithEvents btnSkuSave As System.Windows.Forms.Button
    Public WithEvents GbData As System.Windows.Forms.GroupBox
    Public WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents userlist As System.Windows.Forms.CheckedListBox
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkClearAll As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelectAll As System.Windows.Forms.CheckBox
    Friend WithEvents cmbBanch As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAssignTask))
        Me.btnSkuSave = New System.Windows.Forms.Button
        Me.GbData = New System.Windows.Forms.GroupBox
        Me.cmbBanch = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkClearAll = New System.Windows.Forms.CheckBox
        Me.chkSelectAll = New System.Windows.Forms.CheckBox
        Me.userlist = New System.Windows.Forms.CheckedListBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.GbData.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSkuSave
        '
        Me.btnSkuSave.Location = New System.Drawing.Point(401, 454)
        Me.btnSkuSave.Name = "btnSkuSave"
        Me.btnSkuSave.Size = New System.Drawing.Size(72, 22)
        Me.btnSkuSave.TabIndex = 50
        Me.btnSkuSave.Text = "�������"
        '
        'GbData
        '
        Me.GbData.BackColor = System.Drawing.SystemColors.Control
        Me.GbData.Controls.Add(Me.btnSkuSave)
        Me.GbData.Controls.Add(Me.chkSelectAll)
        Me.GbData.Controls.Add(Me.chkClearAll)
        Me.GbData.Controls.Add(Me.cmbBanch)
        Me.GbData.Controls.Add(Me.Label3)
        Me.GbData.Controls.Add(Me.GroupBox1)
        Me.GbData.Dock = System.Windows.Forms.DockStyle.Top
        Me.GbData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GbData.Location = New System.Drawing.Point(0, 0)
        Me.GbData.Name = "GbData"
        Me.GbData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GbData.Size = New System.Drawing.Size(484, 480)
        Me.GbData.TabIndex = 49
        Me.GbData.TabStop = False
        Me.GbData.Tag = "11494"
        '
        'cmbBanch
        '
        Me.cmbBanch.FormattingEnabled = True
        Me.cmbBanch.Location = New System.Drawing.Point(94, 14)
        Me.cmbBanch.Name = "cmbBanch"
        Me.cmbBanch.Size = New System.Drawing.Size(378, 20)
        Me.cmbBanch.TabIndex = 81
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(10, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 21)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "���κ�"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.userlist)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(6, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(472, 408)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "11494"
        '
        'chkClearAll
        '
        Me.chkClearAll.Location = New System.Drawing.Point(71, 454)
        Me.chkClearAll.Name = "chkClearAll"
        Me.chkClearAll.Size = New System.Drawing.Size(76, 26)
        Me.chkClearAll.TabIndex = 56
        Me.chkClearAll.Text = "ȫ��ѡ"
        '
        'chkSelectAll
        '
        Me.chkSelectAll.Location = New System.Drawing.Point(17, 454)
        Me.chkSelectAll.Name = "chkSelectAll"
        Me.chkSelectAll.Size = New System.Drawing.Size(48, 26)
        Me.chkSelectAll.TabIndex = 55
        Me.chkSelectAll.Text = "ȫѡ"
        '
        'userlist
        '
        Me.userlist.CheckOnClick = True
        Me.userlist.ColumnWidth = 340
        Me.userlist.Location = New System.Drawing.Point(6, 20)
        Me.userlist.MultiColumn = True
        Me.userlist.Name = "userlist"
        Me.userlist.Size = New System.Drawing.Size(460, 388)
        Me.userlist.TabIndex = 54
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.Control
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Location = New System.Drawing.Point(664, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button2.Size = New System.Drawing.Size(50, 22)
        Me.Button2.TabIndex = 74
        Me.Button2.Tag = "11487"
        Me.Button2.Text = "���"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'frmAssignTask
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(484, 481)
        Me.Controls.Add(Me.GbData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAssignTask"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "�������"
        Me.GbData.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region

#Region " user defined property "
    Dim look As New YT.BusinessObject.Lookup
    Dim initTaskNo As String
    Dim Optimization As New clsOptimizationDN
    Private objCurrentuserlist As DataSet
    Private objSelecteduserlist As New Microsoft.VisualBasic.Collection
    Public ReadOnly Property Selecteduserlist() As Microsoft.VisualBasic.Collection
        Get
            Return objSelecteduserlist
        End Get
    End Property

#End Region

#Region " user control envent "

    Private Sub btnQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RefreshuserlistInternal()
    End Sub
    Private Sub frmAssignTask_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadAvariableBanchList()
        RefreshuserlistInternal()
    End Sub
    Private Sub chkClearAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClearAll.CheckedChanged
        If chkClearAll.Checked Then
            SetListCheckStatus(False)
        End If
        chkSelectAll.Checked = Not chkClearAll.Checked
    End Sub
    Private Sub chkSelectAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAll.CheckedChanged
        If chkSelectAll.Checked Then
            SetListCheckStatus(True)
        End If
        chkClearAll.Checked = Not chkSelectAll.Checked
    End Sub
    Private Sub btnSkuSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSkuSave.Click
        GetCarrierSeqBatchNo(initTaskNo)
        GetSelectedListForReturn()
        Me.Close()
    End Sub
#End Region
#Region " customer bussniness flow "

    Private Sub LoadAvariableBanchList()
        On Error Resume Next
        Dim obj As DataSet
        obj = look.GetAvariableBanchByWhere("")
        cmbBanch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown
        cmbBanch.DisplayMember = obj.Tables(0).Columns("bch_no").ColumnName
        cmbBanch.ValueMember = obj.Tables(0).Columns("bch_no").ColumnName
        cmbBanch.DataSource = obj.Tables(0).DefaultView
        cmbBanch.Refresh()
    End Sub
    Private Sub RefreshuserlistInternal()
        On Error Resume Next
        Dim obj As DataSet
        obj = look.GetUserListByWhere(" where 1=1")
        userlist.DataSource = obj.Tables(0).DefaultView
        userlist.ValueMember = obj.Tables(0).Columns("user_code").ColumnName
        userlist.DisplayMember = obj.Tables(0).Columns("user_name").ColumnName
        objCurrentuserlist = obj
    End Sub
    Private Sub GetSelectedListForReturn()
        Dim RetCode As String = ""
        Dim RetMsg As String = ""
        While objSelecteduserlist.Count > 0
            objSelecteduserlist.Remove(1)
        End While
        If objCurrentuserlist Is Nothing Then
            Return
        End If
        If (cmbBanch.SelectedValue = "") Then
            Return
        End If
        Dim i As Integer
        Dim UserCode As String
        Try
            For i = 0 To userlist.Items.Count - 1
                If userlist.GetItemChecked(i) Then
                    UserCode = CType(objCurrentuserlist.Tables(0).Rows(i).Item("user_code"), String)
                    objSelecteduserlist.Add(UserCode)
                    Optimization.CreateTaskByBanch("SHA", initTaskNo, cmbBanch.SelectedValue, UserCode, RetCode, RetMsg)
                End If
            Next
        Catch ex As Exception
            ErrorMsg(ex, Me.GetType, "APP_Create_Taskh")
        End Try
    End Sub
    Private Sub SetListCheckStatus(ByVal bCheck As Boolean)
        Dim i As Integer
        For i = 0 To userlist.Items.Count - 1
            userlist.SetItemChecked(i, bCheck)
        Next
    End Sub
    Private Sub GetCarrierSeqBatchNo(ByRef TaskNo As String)
        Dim obj As New clsDocumentFormat
        Try
            TaskNo = obj.GetNewDocumentNumber("SHA", "taskhdr", "task_id", clsDocumentFormat.FormatKitTask, "TASK")
        Catch ex As Exception
        End Try
    End Sub
#End Region 
End Class
