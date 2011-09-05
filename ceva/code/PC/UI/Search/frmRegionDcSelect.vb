Imports YT.BusinessObject


Public Class frmRegionDcSelect
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
    Friend WithEvents btnCalcel As System.Windows.Forms.Button
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents dgDc As System.Windows.Forms.DataGrid
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRegionDcSelect))
        Me.btnCalcel = New System.Windows.Forms.Button
        Me.btnOk = New System.Windows.Forms.Button
        Me.dgDc = New System.Windows.Forms.DataGrid
        Me.btnSelectAll = New System.Windows.Forms.Button
        CType(Me.dgDc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCalcel
        '
        Me.btnCalcel.Location = New System.Drawing.Point(312, 248)
        Me.btnCalcel.Name = "btnCalcel"
        Me.btnCalcel.Size = New System.Drawing.Size(73, 32)
        Me.btnCalcel.TabIndex = 5
        Me.btnCalcel.Text = "取  消"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(168, 248)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(73, 32)
        Me.btnOk.TabIndex = 4
        Me.btnOk.Text = "确  定"
        '
        'dgDc
        '
        Me.dgDc.AlternatingBackColor = System.Drawing.SystemColors.Control
        Me.dgDc.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgDc.CaptionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.dgDc.CaptionForeColor = System.Drawing.SystemColors.Info
        Me.dgDc.DataMember = ""
        Me.dgDc.GridLineColor = System.Drawing.SystemColors.ControlDark
        Me.dgDc.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgDc.Location = New System.Drawing.Point(0, 0)
        Me.dgDc.Name = "dgDc"
        Me.dgDc.ParentRowsBackColor = System.Drawing.SystemColors.GrayText
        Me.dgDc.SelectionForeColor = System.Drawing.SystemColors.Info
        Me.dgDc.Size = New System.Drawing.Size(400, 240)
        Me.dgDc.TabIndex = 3
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(24, 248)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(73, 32)
        Me.btnSelectAll.TabIndex = 6
        Me.btnSelectAll.Text = "全  选"
        '
        'frmRegionDcSelect
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(400, 286)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.btnCalcel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.dgDc)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRegionDcSelect"
        Me.Text = "请选择物流中心"
        CType(Me.dgDc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public RightNo As String
    Public SupportMultiValue As Boolean = False
    Private ds As DataSet


    Private Sub btnCalcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private mstrSelectedValue As String = ""

    Public Property SelectedValue() As String
        Get
            Return mstrSelectedValue
        End Get
        Set(ByVal Value As String)
            mstrSelectedValue = Value
        End Set
    End Property

    Private Function UI2SelectedValue() As Boolean
        Dim str As String
        Dim i As Integer
        Dim bExistsed As Boolean = False
        str = ""
        For i = 0 To ds.Tables(0).Rows.Count - 1
            If dgDc.IsSelected(i) = True Then
                str = str + ds.Tables(0).Rows(i).Item(0) + ","
                bExistsed = True
            End If
        Next
        If bExistsed = True Then
            mstrSelectedValue = Microsoft.VisualBasic.Left(str, Len(str) - 1)
            Return True
        End If
        Return False
    End Function

    Private Sub SelectedValue2UI()
        Dim str As String
        Dim i As Integer
        If Trim(mstrSelectedValue) = "" Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                dgDc.UnSelect(i)
            Next
            Exit Sub
        End If
        For i = 0 To ds.Tables(0).Rows.Count - 1
            str = Trim(ds.Tables(0).Rows(i).Item(0))
            If str <> "" And mstrSelectedValue.IndexOf(str) >= 0 Then
                dgDc.Select(i)
            Else
                dgDc.UnSelect(i)
            End If
        Next
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If UI2SelectedValue() = False Then
            Message("ID_msg_frmRegionDcSelect_PleaseSelect", True, "请选择物流中心。")
            Return
        End If
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub


    Private Sub LoadDcList()
        On Error Resume Next
        Dim look As New Lookup
        ds = look.GetDcListByPermission(UserRightMgr.gUserCode, RightNo)
        Me.dgDc.DataSource = ds.Tables(0).DefaultView
        dgDc.TableStyles.Clear()
        Dim myCurrencyManager As CurrencyManager
        Dim myGridTableStyle As DataGridTableStyle
        myCurrencyManager = CType(Me.BindingContext(ds, ds.Tables(0).TableName), CurrencyManager)
        myGridTableStyle = New DataGridTableStyle(myCurrencyManager)

        dgDc.TableStyles.Add(myGridTableStyle)
        dgDc.TableStyles(0).AlternatingBackColor = SystemColors.Control
        Me.dgDc.TableStyles(0).GridLineColor = SystemColors.ControlDarkDark
        Dim colStyle As DataGridColumnStyle
        For Each colStyle In dgDc.TableStyles(0).GridColumnStyles
            colStyle.Width = 0
            Select Case colStyle.MappingName
                Case "dc_code"
                    colStyle.HeaderText = "代码"
                    colStyle.Width = 150
                Case "dc_name"
                    colStyle.HeaderText = "名称"
                    colStyle.Width = 200
            End Select
        Next
    End Sub

    Private Sub frmRegionDcSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgDc.ReadOnly = True
        LoadDcList()
        SelectedValue2UI()
        btnSelectAll.Visible = SupportMultiValue
    End Sub

    Private Sub dgDc_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgDc.MouseUp
        Dim i, n, s, co As Integer
        i = Me.dgDc.CurrentRowIndex
        s = 0
        dgDc.TableStyles(0).SelectionBackColor = SystemColors.ActiveCaption
        Try
            If SupportMultiValue = False Then
                For n = 0 To ds.Tables(0).Rows.Count - 1
                    If dgDc.IsSelected(n) = True Then
                        If n = i Then
                            'dgDc.Select(n)
                        Else
                            dgDc.UnSelect(n)

                        End If
                    End If
                Next
            Else                                                'SupportMultiValue   = true


            End If
        Catch ex As Exception
            LogMsg(ex, Me.GetType, "dgDc_MouseUp")
        End Try
    End Sub


    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        Dim i As Integer
        For i = 0 To ds.Tables(0).Rows.Count - 1
            dgDc.Select(i)
        Next
    End Sub
End Class
