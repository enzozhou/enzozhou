Imports WMS
Imports YT.BusinessObject
Imports COMExpress.Windows.Forms
'Imports COMExpress.Windows.Forms.ISearchService.SearchQuery
'Imports COMExpress.Windows.

Public Class frmCarrierlook
    Inherits System.Windows.Forms.Form
    Dim lookup As New lookup
    Public txtaddress As String
    Public txtcarrcode As String
    Public txtcarrname As String
    Public txtCarr_code As String
    Public strCarrname As String '运输公司名称
    Public strSomeCheck As String '多选公司代码
    Public carrSuppor As Boolean
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
    Friend WithEvents bttCalcel As System.Windows.Forms.Button
    Friend WithEvents bttOk As System.Windows.Forms.Button
    Friend WithEvents dataGridCarrier As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableCarrier As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxCarrCode As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxCarrName As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxCarrAdress As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCarrierlook))
        Me.bttCalcel = New System.Windows.Forms.Button
        Me.bttOk = New System.Windows.Forms.Button
        Me.dataGridCarrier = New System.Windows.Forms.DataGrid
        Me.DataGridTableCarrier = New System.Windows.Forms.DataGridTableStyle
        Me.DataGridTextBoxCarrCode = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxCarrName = New System.Windows.Forms.DataGridTextBoxColumn
        Me.DataGridTextBoxCarrAdress = New System.Windows.Forms.DataGridTextBoxColumn
        CType(Me.dataGridCarrier, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bttCalcel
        '
        Me.bttCalcel.Location = New System.Drawing.Point(384, 328)
        Me.bttCalcel.Name = "bttCalcel"
        Me.bttCalcel.Size = New System.Drawing.Size(88, 23)
        Me.bttCalcel.TabIndex = 5
        Me.bttCalcel.Text = "取  消"
        '
        'bttOk
        '
        Me.bttOk.Location = New System.Drawing.Point(232, 328)
        Me.bttOk.Name = "bttOk"
        Me.bttOk.Size = New System.Drawing.Size(88, 23)
        Me.bttOk.TabIndex = 4
        Me.bttOk.Text = "确  定"
        '
        'dataGridCarrier
        '
        Me.dataGridCarrier.AlternatingBackColor = System.Drawing.SystemColors.Control
        Me.dataGridCarrier.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dataGridCarrier.CaptionBackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.dataGridCarrier.CaptionForeColor = System.Drawing.SystemColors.Info
        Me.dataGridCarrier.DataMember = ""
        Me.dataGridCarrier.GridLineColor = System.Drawing.SystemColors.ControlDark
        Me.dataGridCarrier.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dataGridCarrier.Location = New System.Drawing.Point(8, -8)
        Me.dataGridCarrier.Name = "dataGridCarrier"
        Me.dataGridCarrier.ParentRowsBackColor = System.Drawing.SystemColors.GrayText
        Me.dataGridCarrier.ReadOnly = True
        Me.dataGridCarrier.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.dataGridCarrier.SelectionForeColor = System.Drawing.SystemColors.Info
        Me.dataGridCarrier.Size = New System.Drawing.Size(608, 320)
        Me.dataGridCarrier.TabIndex = 3
        Me.dataGridCarrier.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableCarrier})
        '
        'DataGridTableCarrier
        '
        Me.DataGridTableCarrier.DataGrid = Me.dataGridCarrier
        Me.DataGridTableCarrier.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxCarrCode, Me.DataGridTextBoxCarrName, Me.DataGridTextBoxCarrAdress})
        Me.DataGridTableCarrier.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableCarrier.MappingName = ""
        Me.DataGridTableCarrier.RowHeaderWidth = 100
        '
        'DataGridTextBoxCarrCode
        '
        Me.DataGridTextBoxCarrCode.Format = ""
        Me.DataGridTextBoxCarrCode.FormatInfo = Nothing
        Me.DataGridTextBoxCarrCode.HeaderText = "运输公司代码"
        Me.DataGridTextBoxCarrCode.MappingName = ""
        Me.DataGridTextBoxCarrCode.ReadOnly = True
        Me.DataGridTextBoxCarrCode.Width = 80
        '
        'DataGridTextBoxCarrName
        '
        Me.DataGridTextBoxCarrName.Format = ""
        Me.DataGridTextBoxCarrName.FormatInfo = Nothing
        Me.DataGridTextBoxCarrName.HeaderText = "运输公司名称"
        Me.DataGridTextBoxCarrName.MappingName = ""
        Me.DataGridTextBoxCarrName.ReadOnly = True
        Me.DataGridTextBoxCarrName.Width = 150
        '
        'DataGridTextBoxCarrAdress
        '
        Me.DataGridTextBoxCarrAdress.Format = ""
        Me.DataGridTextBoxCarrAdress.FormatInfo = Nothing
        Me.DataGridTextBoxCarrAdress.HeaderText = "地址"
        Me.DataGridTextBoxCarrAdress.MappingName = ""
        Me.DataGridTextBoxCarrAdress.ReadOnly = True
        Me.DataGridTextBoxCarrAdress.Width = 150
        '
        'frmCarrierlook
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(626, 366)
        Me.Controls.Add(Me.bttCalcel)
        Me.Controls.Add(Me.bttOk)
        Me.Controls.Add(Me.dataGridCarrier)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCarrierlook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "运输公司查找显示"
        CType(Me.dataGridCarrier, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmCarrierlook_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dataGridCarrier.ReadOnly = True
        getCarrierSelect()
    End Sub
    Private Sub getCarrierSelect()

        Dim strSQL As String
        Dim strWhere As String = ""
        strSQL = "select distinct carr_code as 运输公司代码,carr_name as 运输公司名称,address as 地址 from carrier"
        If Trim(txtcarrcode) <> "" Then
            strWhere = strWhere + "and carr_code like '%" + Me.txtcarrcode + "%' "
        End If
        If Trim(txtcarrname) <> "" Then
            strWhere = strWhere + "and carr_name like '%" + Me.txtcarrname + "%' "
        End If
        If Trim(txtaddress) <> "" Then
            strWhere = strWhere + "and address like '%" + Me.txtaddress + "%' "
        End If
        If Trim(strWhere) <> "" Then
            strWhere = Mid(strWhere, 4)
            strSQL = strSQL + " where " + strWhere
        End If
        '" where carr_code like '%" + Me.txtcarrcode + "%' and carr_name like '%" + Me.txtcarrname + "%' and address like '%" + Me.txtaddress + "%'"
        rs = lookup.SQLToDataSet(strSQL)
        Me.dataGridCarrier.DataSource = rs.Tables(0).DefaultView

        dataGridCarrier.TableStyles.Clear()
        Dim myCurrencyManager As CurrencyManager
        Dim myGridTableStyle As DataGridTableStyle
        myCurrencyManager = CType(Me.BindingContext(rs, rs.Tables(0).TableName), CurrencyManager)
        myGridTableStyle = New DataGridTableStyle(myCurrencyManager)

        dataGridCarrier.TableStyles.Add(myGridTableStyle)
        dataGridCarrier.TableStyles(0).GridColumnStyles(0).Width = 100
        dataGridCarrier.TableStyles(0).GridColumnStyles(1).Width = 170
        dataGridCarrier.TableStyles(0).GridColumnStyles(2).Width = 280
        dataGridCarrier.TableStyles(0).AlternatingBackColor = SystemColors.Control
        Me.dataGridCarrier.TableStyles(0).GridLineColor = SystemColors.ControlDarkDark

    End Sub

    Private Sub bttCalcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttCalcel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub bttOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles bttOk.Click
        If Me.dataGridCarrier.CurrentRowIndex < 0 Then
            Message("ID_msg_PlsSelectInformation", True, "请选择你所要查询的资料!")

            Return
        Else
            txtCarr_code = Me.dataGridCarrier.Item(Me.dataGridCarrier.CurrentRowIndex, 0).ToString()
            strCarrname = Me.dataGridCarrier.Item(Me.dataGridCarrier.CurrentRowIndex, 1).ToString()

            If carrSuppor = True Then
                delrows()
            Else
                strSomeCheck = txtCarr_code
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
    Private Sub delrows()
        Dim someCheck As String
        Dim n As Integer
        'Dim i As Integer
        'i = 0
        For n = 0 To rs.Tables(0).Rows.Count - 1
            If dataGridCarrier.IsSelected(n) = True Then
                someCheck = someCheck & dataGridCarrier.Item(n, 0) + ","
            End If
        Next
      
        If someCheck = "" Then
            strSomeCheck = txtCarr_code
        Else
            strSomeCheck = Mid(someCheck, 1, InStrRev(someCheck, ",") - 1)
        End If
    End Sub

    Private Sub dataGridCarrier_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dataGridCarrier.MouseUp
        Dim i, n, s, co As Integer
        i = Me.dataGridCarrier.CurrentRowIndex
        'Dim n As Integer
        'Dim s As Integer
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
            If carrSuppor = False Then
                For n = 0 To rs.Tables(0).Rows.Count - 1
                    If dataGridCarrier.IsSelected(n) = True Then
                        If n = i Then
                            dataGridCarrier.TableStyles(0).SelectionBackColor = SystemColors.ActiveCaption
                        Else
                            Me.dataGridCarrier.UnSelect(n)
                        End If
                    End If
                Next
            End If
            If carrSuppor = True Then
                For n = 0 To rs.Tables(0).Rows.Count - 1
                    If dataGridCarrier.IsSelected(n) = True And s < co Then
                        s = s + 1
                    Else
                        Me.dataGridCarrier.UnSelect(n)
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
