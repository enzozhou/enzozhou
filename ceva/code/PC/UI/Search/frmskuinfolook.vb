Imports WMS
Imports YT.BusinessObject
Imports COMExpress.Windows.Forms
Public Class frmskuinfolook
    Inherits System.Windows.Forms.Form
    Dim lookup As New lookup
    Public txtskuno As String
    Public txtskudesc As String
    Public txtmodelno As String
    Public txtsixcode As String
    Public txtdepartment As String
    Public txtvendername As String
    Public txtcategory As String
    Public strmodelno As String '产品型号
    Public strSomeCheck As String
    Public skuSuppor As Boolean
    'Dim frb As New frmclsskuinfoselect
    Dim rs As DataSet
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
    Friend WithEvents DataGridSkuinfo As System.Windows.Forms.DataGrid
    Friend WithEvents bttOk As System.Windows.Forms.Button
    Friend WithEvents bttCalcel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmskuinfolook))
        Me.DataGridSkuinfo = New System.Windows.Forms.DataGrid
        Me.bttOk = New System.Windows.Forms.Button
        Me.bttCalcel = New System.Windows.Forms.Button
        CType(Me.DataGridSkuinfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridSkuinfo
        '
        Me.DataGridSkuinfo.AlternatingBackColor = System.Drawing.SystemColors.Control
        Me.DataGridSkuinfo.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridSkuinfo.CaptionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.DataGridSkuinfo.CaptionForeColor = System.Drawing.SystemColors.Info
        Me.DataGridSkuinfo.DataMember = ""
        Me.DataGridSkuinfo.GridLineColor = System.Drawing.SystemColors.ControlDark
        Me.DataGridSkuinfo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridSkuinfo.Location = New System.Drawing.Point(7, 0)
        Me.DataGridSkuinfo.Name = "DataGridSkuinfo"
        Me.DataGridSkuinfo.ParentRowsBackColor = System.Drawing.SystemColors.GrayText
        Me.DataGridSkuinfo.SelectionForeColor = System.Drawing.SystemColors.Info
        Me.DataGridSkuinfo.Size = New System.Drawing.Size(680, 357)
        Me.DataGridSkuinfo.TabIndex = 0
        '
        'bttOk
        '
        Me.bttOk.Location = New System.Drawing.Point(472, 360)
        Me.bttOk.Name = "bttOk"
        Me.bttOk.Size = New System.Drawing.Size(86, 32)
        Me.bttOk.TabIndex = 1
        Me.bttOk.Text = "确  定"
        '
        'bttCalcel
        '
        Me.bttCalcel.Location = New System.Drawing.Point(600, 360)
        Me.bttCalcel.Name = "bttCalcel"
        Me.bttCalcel.Size = New System.Drawing.Size(87, 32)
        Me.bttCalcel.TabIndex = 2
        Me.bttCalcel.Text = "取   消"
        '
        'frmskuinfolook
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(694, 400)
        Me.Controls.Add(Me.bttCalcel)
        Me.Controls.Add(Me.bttOk)
        Me.Controls.Add(Me.DataGridSkuinfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmskuinfolook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "产品查找显示"
        CType(Me.DataGridSkuinfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub frmskuinfolook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DataGridSkuinfo.ReadOnly = True
        getSelectValue()
        'dim DataGridSkuinfo.Item(0,0) as Boolean
        'strskuno()
    End Sub
    Private Sub getSelectValue()

        Dim strSQL As String
        Dim strWhere As String = ""

        strSQL = "select distinct sku_no as 产品号码,sku_desc as 产品描述,model_no as 型号,six_code as 六位代码,department as 部门,vender_name as 供应商,category as 产品组 from skuinfo "
        '"where sku_no like '%" + txtskuno + "%' and  sku_desc like '%" + txtskudesc + "%' and model_no like '%" + txtmodelno + "%' and six_code like '%" + txtsixcode + "%' "
        '"and department like '%" + txtdepartment + "%' and  vender_name like '%" + txtvendername + "%' and category like '%" + txtcategory + "%'"
        If Trim(txtskuno) <> "" Then
            strWhere = strWhere + "and sku_no like '%" + txtskuno + "%' "
        End If
        If Trim(txtskudesc) <> "" Then
            strWhere = strWhere + "and sku_desc like '%" + txtskudesc + "%' "
        End If
        If Trim(txtmodelno) <> "" Then
            strWhere = strWhere + "and model_no like '%" + txtmodelno + "%' "
        End If
        If Trim(txtsixcode) <> "" Then
            strWhere = strWhere + "and six_code like '%" + txtsixcode + "%' "
        End If
        If Trim(txtdepartment) <> "" Then
            strWhere = strWhere + "and department like '%" + txtdepartment + "%' "
        End If
        If Trim(txtvendername) <> "" Then
            strWhere = strWhere + "and vender_name like '%" + txtvendername + "%' "
        End If
        If Trim(txtcategory) <> "" Then
            strWhere = strWhere + "and category like '%" + txtcategory + "%' "
        End If
        If Trim(strWhere) <> "" Then
            strWhere = Mid(strWhere, 4)
            strSQL = strSQL + " where " + strWhere
        End If
        rs = lookup.SQLToDataSet(strSQL)
        '将获得查询的值填充到lbxContent
        Me.DataGridSkuinfo.DataSource = rs.Tables(0).DefaultView
        Dim myCurrencyManager As CurrencyManager
        Dim myGridTableStyle As DataGridTableStyle
        myCurrencyManager = CType(Me.BindingContext(rs, rs.Tables(0).TableName), CurrencyManager)
        myGridTableStyle = New DataGridTableStyle(myCurrencyManager)

        DataGridSkuinfo.TableStyles.Add(myGridTableStyle)
        DataGridSkuinfo.TableStyles(0).GridColumnStyles(0).Width = 90
        DataGridSkuinfo.TableStyles(0).GridColumnStyles(1).Width = 150
        DataGridSkuinfo.TableStyles(0).GridColumnStyles(2).Width = 100
        DataGridSkuinfo.TableStyles(0).GridColumnStyles(3).Width = 80
        DataGridSkuinfo.TableStyles(0).GridColumnStyles(4).Width = 80
        DataGridSkuinfo.TableStyles(0).GridColumnStyles(5).Width = 180
        DataGridSkuinfo.TableStyles(0).GridColumnStyles(6).Width = 70
        DataGridSkuinfo.TableStyles(0).AlternatingBackColor = SystemColors.Control
        Me.DataGridSkuinfo.TableStyles(0).GridLineColor = SystemColors.ControlDarkDark
    End Sub

   
    Private Sub bttCalcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttCalcel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub bttOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bttOk.Click
        'frb.getskuno(txtskuno)
        Dim strskuno As String
        If Me.DataGridSkuinfo.CurrentRowIndex < 0 Then
            Message("ID_msg_PlsSelectInformation", True, "请选择你所要查询的资料!")
            Return
        Else
            txtskuno = Me.DataGridSkuinfo.Item(Me.DataGridSkuinfo.CurrentRowIndex, 0).ToString()
            strmodelno = Me.DataGridSkuinfo.Item(Me.DataGridSkuinfo.CurrentRowIndex, 2).ToString()
            If Me.skuSuppor = True Then
                delrows()
            Else
                strSomeCheck = txtskuno
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub delrows()
        Dim someCheck As String
        Dim n As Integer
        For n = 0 To rs.Tables(0).Rows.Count - 1
            If DataGridSkuinfo.IsSelected(n) = True Then
                someCheck = someCheck & DataGridSkuinfo.Item(n, 0) + ","
            End If
        Next
        If someCheck = "" Then
            strSomeCheck = txtskuno
        Else
            strSomeCheck = Mid(someCheck, 1, InStrRev(someCheck, ",") - 1)
        End If
    End Sub

    Private Sub DataGridSkuinfo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridSkuinfo.MouseUp
        Dim i, n, s, co As Integer
        i = Me.DataGridSkuinfo.CurrentRowIndex
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
            If skuSuppor = False Then
                For n = 0 To rs.Tables(0).Rows.Count - 1
                    If DataGridSkuinfo.IsSelected(n) = True Then
                        If n = i Then
                            DataGridSkuinfo.TableStyles(0).SelectionBackColor = SystemColors.ActiveCaption
                        Else
                            Me.DataGridSkuinfo.UnSelect(n)
                        End If
                    End If
                Next
            End If
            If skuSuppor = True Then
                For n = 0 To rs.Tables(0).Rows.Count - 1
                    If DataGridSkuinfo.IsSelected(n) = True And s < co Then
                        s = s + 1
                    Else
                        Me.DataGridSkuinfo.UnSelect(n)
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
