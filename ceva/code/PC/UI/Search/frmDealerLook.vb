Imports WMS
Imports YT.BusinessObject
Imports COMExpress.Windows.Forms
Public Class frmDealerLook
    Inherits System.Windows.Forms.Form
    Dim lookup As New Lookup
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
    Friend WithEvents dataGridDealer As System.Windows.Forms.DataGrid
    Friend WithEvents bttOk As System.Windows.Forms.Button
    Friend WithEvents bttCalcel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDealerLook))
        Me.dataGridDealer = New System.Windows.Forms.DataGrid
        Me.bttOk = New System.Windows.Forms.Button
        Me.bttCalcel = New System.Windows.Forms.Button
        CType(Me.dataGridDealer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dataGridDealer
        '
        Me.dataGridDealer.AlternatingBackColor = System.Drawing.SystemColors.Control
        Me.dataGridDealer.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dataGridDealer.CaptionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.dataGridDealer.CaptionForeColor = System.Drawing.SystemColors.Info
        Me.dataGridDealer.DataMember = ""
        Me.dataGridDealer.GridLineColor = System.Drawing.SystemColors.ControlDark
        Me.dataGridDealer.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dataGridDealer.Location = New System.Drawing.Point(8, 0)
        Me.dataGridDealer.Name = "dataGridDealer"
        Me.dataGridDealer.ParentRowsBackColor = System.Drawing.SystemColors.GrayText
        Me.dataGridDealer.SelectionForeColor = System.Drawing.SystemColors.Info
        Me.dataGridDealer.Size = New System.Drawing.Size(816, 416)
        Me.dataGridDealer.TabIndex = 0
        '
        'bttOk
        '
        Me.bttOk.Location = New System.Drawing.Point(440, 424)
        Me.bttOk.Name = "bttOk"
        Me.bttOk.Size = New System.Drawing.Size(88, 23)
        Me.bttOk.TabIndex = 1
        Me.bttOk.Text = "确  定"
        '
        'bttCalcel
        '
        Me.bttCalcel.Location = New System.Drawing.Point(608, 424)
        Me.bttCalcel.Name = "bttCalcel"
        Me.bttCalcel.Size = New System.Drawing.Size(88, 23)
        Me.bttCalcel.TabIndex = 2
        Me.bttCalcel.Text = "取  消"
        '
        'frmDealerLook
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(834, 456)
        Me.Controls.Add(Me.bttCalcel)
        Me.Controls.Add(Me.bttOk)
        Me.Controls.Add(Me.dataGridDealer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDealerLook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "经销商查找显示"
        CType(Me.dataGridDealer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public txtdealcode As String
    Public txtname As String
    Public txtperson As String
    Public txtadress As String
    Public txttel As String
    Public txtdeal_code As String '经销商代码
    Public strdealname As String '经销商名称
    Public strperson As String '经销商联系人
    Public strdealaddress As String '经销商名称
    Public strSomeCheck As String
    'Dim frb As New frmDealerSelect
    Public dealSuppor As Boolean
    Dim rs As DataSet
    Private Sub frmDealerLook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dataGridDealer.ReadOnly = True
        getSelectDealers()
    End Sub
    Public Sub getSelectDealers()
        'Dim rs As DataSet
        Dim strSQL As String
        Dim strWhere As String = ""
        strSQL = "select distinct deal_code as 经销商代码,name_short as 名称,address as 地址,person as 联系人,tel as 电话 from dealer "
        If Trim(Me.txtdealcode) <> "" Then
            strWhere = strWhere + "and deal_code like '%" + Me.txtdealcode + "%' "
        End If
        If Trim(Me.txtname) <> "" Then
            strWhere = strWhere + "and  name_short like '%" + Me.txtname + "%' "
        End If
        If Trim(Me.txtadress) <> "" Then
            strWhere = strWhere + "and address like'%" + Me.txtadress + "%' "
        End If
        If Trim(Me.txtperson) <> "" Then
            strWhere = strWhere + "and person like '%" + Me.txtperson + "%' "
        End If
        If Trim(Me.txttel) <> "" Then
            strWhere = strWhere + "and tel like '%" + Me.txttel + "%' "
        End If
        '" and address like'%" + Me.txtadress + "%' and person like '%" + Me.txtperson + "%' and tel like '%" + Me.txttel + "%'"
        If Trim(strWhere) <> "" Then
            strWhere = Mid(strWhere, 4)
            strSQL = strSQL + " where " + strWhere
        End If
        rs = lookup.SQLToDataSet(strSQL)
        Me.dataGridDealer.DataSource = rs.Tables(0).DefaultView
        dataGridDealer.TableStyles.Clear()
        Dim myCurrencyManager As CurrencyManager
        Dim myGridTableStyle As DataGridTableStyle
        myCurrencyManager = CType(Me.BindingContext(rs, rs.Tables(0).TableName), CurrencyManager)
        myGridTableStyle = New DataGridTableStyle(myCurrencyManager)

        dataGridDealer.TableStyles.Add(myGridTableStyle)
        dataGridDealer.TableStyles(0).GridColumnStyles(0).Width = 90
        dataGridDealer.TableStyles(0).GridColumnStyles(1).Width = 230
        dataGridDealer.TableStyles(0).GridColumnStyles(2).Width = 230
        dataGridDealer.TableStyles(0).GridColumnStyles(3).Width = 65
        dataGridDealer.TableStyles(0).GridColumnStyles(4).Width = 125
        dataGridDealer.TableStyles(0).AlternatingBackColor = SystemColors.Control
        Me.dataGridDealer.TableStyles(0).GridLineColor = SystemColors.ControlDarkDark
    End Sub

    Private Sub bttCalcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttCalcel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub bttOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttOk.Click
        If dataGridDealer.CurrentRowIndex < 0 Then
            Message("ID_msg_PlsSelectInformation", True, "请选择你所要查询的资料!")
            Return
        Else
            txtdeal_code = dataGridDealer.Item(dataGridDealer.CurrentRowIndex, 0).ToString
            Me.strdealname = Me.dataGridDealer.Item(Me.dataGridDealer.CurrentRowIndex, 1).ToString()
            Me.strperson = Me.dataGridDealer.Item(Me.dataGridDealer.CurrentRowIndex, 3).ToString()
            Me.strdealaddress = Me.dataGridDealer.Item(Me.dataGridDealer.CurrentRowIndex, 2).ToString()
            If Me.dealSuppor = True Then
                delrows()
            Else
                strSomeCheck = txtdeal_code
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub delrows()
        Dim someCheck As String
        Dim n As Integer
        For n = 0 To rs.Tables(0).Rows.Count - 1
            If dataGridDealer.IsSelected(n) = True Then
                someCheck = someCheck & dataGridDealer.Item(n, 0) + ","
            End If
        Next
        If someCheck = "" Then
            strSomeCheck = txtdeal_code
        Else
            strSomeCheck = Mid(someCheck, 1, InStrRev(someCheck, ",") - 1)
        End If
    End Sub

    Private Sub dataGridDealer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dataGridDealer.MouseUp
        Dim i, n, s, co As Integer
        i = Me.dataGridDealer.CurrentRowIndex
        'Dim n As Integer
        ' Dim s As Integer
        s = 0
        Dim strck As String
        Dim opt As New clsOption
        Try
            strck = opt.GetOptionALL("SYS", "manyselect", "cmselect")
            co = CInt(strck)

        Catch ex As Exception
            co = 30
        End Try
        Try
            If dealSuppor = False Then
                For n = 0 To rs.Tables(0).Rows.Count - 1
                    If dataGridDealer.IsSelected(n) = True Then
                        If n = i Then
                            dataGridDealer.TableStyles(0).SelectionBackColor = SystemColors.ActiveCaption
                        Else
                            Me.dataGridDealer.UnSelect(n)
                        End If
                    End If
                Next
            End If
            If dealSuppor = True Then
                For n = 0 To rs.Tables(0).Rows.Count - 1
                    If dataGridDealer.IsSelected(n) = True And s < co Then
                        s = s + 1
                    Else
                        Me.dataGridDealer.UnSelect(n)
                    End If
                Next
                If s >= co Then
                    MsgBox(PublicResource.LoadResString("ID_msg_SelectRowCannot", "选中的行数不能超过") + co.ToString() + PublicResource.LoadResString("ID_msg_RowStr", "行!"))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
