Imports YT
Imports YT.BusinessObject
Imports COMExpress.BusinessObject
Public Class frmListWhere
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
    Public WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkClearAllSonyBanch As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelectAllSonyBanch As System.Windows.Forms.CheckBox
    Friend WithEvents SonyBanchList As System.Windows.Forms.CheckedListBox
    Public WithEvents BtnOk As System.Windows.Forms.Button
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkClearAllcity As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelectAllcity As System.Windows.Forms.CheckBox
    Friend WithEvents cityList As System.Windows.Forms.CheckedListBox

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListWhere))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkClearAllSonyBanch = New System.Windows.Forms.CheckBox
        Me.chkSelectAllSonyBanch = New System.Windows.Forms.CheckBox
        Me.SonyBanchList = New System.Windows.Forms.CheckedListBox
        Me.BtnOk = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkClearAllcity = New System.Windows.Forms.CheckBox
        Me.chkSelectAllcity = New System.Windows.Forms.CheckBox
        Me.cityList = New System.Windows.Forms.CheckedListBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.chkClearAllSonyBanch)
        Me.GroupBox1.Controls.Add(Me.chkSelectAllSonyBanch)
        Me.GroupBox1.Controls.Add(Me.SonyBanchList)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(1, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox1.Size = New System.Drawing.Size(614, 250)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "11501"
        Me.GroupBox1.Text = "索尼批次列表"
        '
        'chkClearAllSonyBanch
        '
        Me.chkClearAllSonyBanch.Location = New System.Drawing.Point(83, 222)
        Me.chkClearAllSonyBanch.Name = "chkClearAllSonyBanch"
        Me.chkClearAllSonyBanch.Size = New System.Drawing.Size(76, 26)
        Me.chkClearAllSonyBanch.TabIndex = 77
        Me.chkClearAllSonyBanch.Text = "全不选"
        '
        'chkSelectAllSonyBanch
        '
        Me.chkSelectAllSonyBanch.Location = New System.Drawing.Point(10, 222)
        Me.chkSelectAllSonyBanch.Name = "chkSelectAllSonyBanch"
        Me.chkSelectAllSonyBanch.Size = New System.Drawing.Size(48, 26)
        Me.chkSelectAllSonyBanch.TabIndex = 76
        Me.chkSelectAllSonyBanch.Text = "全选"
        '
        'SonyBanchList
        '
        Me.SonyBanchList.CheckOnClick = True
        Me.SonyBanchList.ColumnWidth = 340
        Me.SonyBanchList.Location = New System.Drawing.Point(9, 20)
        Me.SonyBanchList.Name = "SonyBanchList"
        Me.SonyBanchList.Size = New System.Drawing.Size(599, 196)
        Me.SonyBanchList.TabIndex = 78
        '
        'BtnOk
        '
        Me.BtnOk.BackColor = System.Drawing.SystemColors.Control
        Me.BtnOk.Cursor = System.Windows.Forms.Cursors.Default
        Me.BtnOk.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnOk.Location = New System.Drawing.Point(267, 521)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtnOk.Size = New System.Drawing.Size(77, 22)
        Me.BtnOk.TabIndex = 81
        Me.BtnOk.Tag = "11487"
        Me.BtnOk.Text = "确定"
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.chkClearAllcity)
        Me.GroupBox2.Controls.Add(Me.chkSelectAllcity)
        Me.GroupBox2.Controls.Add(Me.cityList)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox2.Location = New System.Drawing.Point(1, 265)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox2.Size = New System.Drawing.Size(614, 250)
        Me.GroupBox2.TabIndex = 79
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = "11501"
        Me.GroupBox2.Text = "城市列表"
        '
        'chkClearAllcity
        '
        Me.chkClearAllcity.Location = New System.Drawing.Point(83, 222)
        Me.chkClearAllcity.Name = "chkClearAllcity"
        Me.chkClearAllcity.Size = New System.Drawing.Size(76, 26)
        Me.chkClearAllcity.TabIndex = 77
        Me.chkClearAllcity.Text = "全不选"
        '
        'chkSelectAllcity
        '
        Me.chkSelectAllcity.Location = New System.Drawing.Point(10, 222)
        Me.chkSelectAllcity.Name = "chkSelectAllcity"
        Me.chkSelectAllcity.Size = New System.Drawing.Size(48, 26)
        Me.chkSelectAllcity.TabIndex = 76
        Me.chkSelectAllcity.Text = "全选"
        '
        'cityList
        '
        Me.cityList.CheckOnClick = True
        Me.cityList.ColumnWidth = 340
        Me.cityList.Location = New System.Drawing.Point(9, 20)
        Me.cityList.Name = "cityList"
        Me.cityList.Size = New System.Drawing.Size(599, 196)
        Me.cityList.TabIndex = 78
        '
        'frmListWhere
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(627, 550)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmListWhere"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "查询"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
#End Region
#Region " user defined property "
    Dim look As New YT.BusinessObject.Lookup
    Dim Optimization As New clsOptimizationDN
    Dim initBanchNo As String = ""
    Public sCityWhere As String = ""
    Public sSonyBanchWhere As String = ""
    Private objCurrentSonyBanchList As DataSet
    Private objSelectedSonyBanchList As New Microsoft.VisualBasic.Collection
    Private objCurrentCityList As DataSet
    Private objSelectedCityList As New Microsoft.VisualBasic.Collection
#End Region
#Region " customer bussniness flow "
    Private Sub RefreshSonyBanchListInternal()
        On Error Resume Next
        Dim obj As DataSet
        Dim sWhere As String = " "
        obj = look.GetAvariableSonyBanchByWhere(sWhere)
        SonyBanchList.DataSource = obj.Tables(0).DefaultView
        SonyBanchList.ValueMember = obj.Tables(0).Columns("sony_bch_no").ColumnName
        SonyBanchList.DisplayMember = obj.Tables(0).Columns("sony_bch_no").ColumnName
        objCurrentSonyBanchList = obj
    End Sub
    Private Sub RefreshCityListInternal()
        On Error Resume Next
        Dim obj As DataSet
        Dim sWhere As String = " "
        obj = look.GetCityByWhere(sWhere)
        cityList.DataSource = obj.Tables(0).DefaultView
        cityList.ValueMember = obj.Tables(0).Columns("city").ColumnName
        cityList.DisplayMember = obj.Tables(0).Columns("city").ColumnName
        objCurrentCityList = obj
    End Sub
    Private Sub SetSonyBanchListCheckStatus(ByVal bCheck As Boolean)
        Dim i As Integer
        For i = 0 To SonyBanchList.Items.Count - 1
            SonyBanchList.SetItemChecked(i, bCheck)
        Next
    End Sub
    Private Sub SetcityListCheckStatus(ByVal bCheck As Boolean)
        Dim i As Integer
        For i = 0 To cityList.Items.Count - 1
            cityList.SetItemChecked(i, bCheck)
        Next
    End Sub
    Private Sub GetSelectedListForReturn()
        Dim RetCode As String = ""
        Dim RetMsg As String = ""
        While objSelectedSonyBanchList.Count > 0
            objSelectedSonyBanchList.Remove(1)
        End While
        While objSelectedCityList.Count > 0
            objSelectedCityList.Remove(1)
        End While
        Dim i As Integer
        Dim t As Integer
        Dim sSonyBanch As String
        Dim sCity As String
        Try
            If Not objCurrentSonyBanchList Is Nothing Then
                sSonyBanchWhere = Nothing
                For i = 0 To SonyBanchList.Items.Count - 1
                    If SonyBanchList.GetItemChecked(i) Then
                        sSonyBanch = CType(objCurrentSonyBanchList.Tables(0).Rows(i).Item("sony_bch_no"), String)
                        objSelectedSonyBanchList.Add(sSonyBanch)
                        If (sSonyBanchWhere Is Nothing) Then
                            sSonyBanchWhere = "'" + sSonyBanch + "'"
                        Else
                            sSonyBanchWhere = sSonyBanchWhere + ",'" + sSonyBanch + "'"
                        End If
                    End If
                Next
            End If
            If Not objCurrentCityList Is Nothing Then
                sCityWhere = Nothing
                For t = 0 To cityList.Items.Count - 1
                    If cityList.GetItemChecked(t) Then
                        sCity = CType(objCurrentCityList.Tables(0).Rows(t).Item("city"), String)
                        objSelectedCityList.Add(sCity)
                        If (sCityWhere Is Nothing) Then
                            sCityWhere = "'" + sCity + "'"
                        Else
                            sCityWhere = sCityWhere + ",'" + sCity + "'"
                        End If
                    End If
                Next
            End If  
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region " user control envent "
    Private Sub chkSelectAllSonyBanch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAllSonyBanch.CheckedChanged
        If chkSelectAllSonyBanch.Checked Then
            SetSonyBanchListCheckStatus(True)
        End If
        chkClearAllSonyBanch.Checked = Not chkSelectAllSonyBanch.Checked
    End Sub
    Private Sub chkClearAllSonyBanch_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClearAllSonyBanch.CheckedChanged
        If chkClearAllSonyBanch.Checked Then
            SetSonyBanchListCheckStatus(False)
        End If
        chkSelectAllSonyBanch.Checked = Not chkClearAllSonyBanch.Checked
    End Sub
    Private Sub chkSelectAllcity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelectAllcity.CheckedChanged
        If chkSelectAllcity.Checked Then
            SetcityListCheckStatus(True)
        End If
        chkClearAllcity.Checked = Not chkSelectAllcity.Checked
    End Sub

    Private Sub chkClearAllcity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClearAllcity.CheckedChanged
        If chkClearAllcity.Checked Then
            SetcityListCheckStatus(False)
        End If
        chkSelectAllcity.Checked = Not chkClearAllcity.Checked
    End Sub
    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        GetSelectedListForReturn()
        Me.Close()
    End Sub
#End Region

    Private Sub frmListWhere_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshSonyBanchListInternal()
        RefreshCityListInternal()
    End Sub


End Class

