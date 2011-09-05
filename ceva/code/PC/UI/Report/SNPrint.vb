Imports YT
Imports YT.BusinessObject
Imports COMExpress.BusinessObject
Imports System.IO
Imports ImportExport
Imports COMExpress.Windows.Forms


Public Class SNPrint
    Inherits System.Windows.Forms.Form
    Public Function GetDate(ByVal val_bch_no As String, ByVal val_sony_bch_no As String) As Boolean
        Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
        Dim parmUserCode As String = UserRightMgr.gUserCode
        Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection
        With prm1
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Size = 20
            .ParameterName = "@BCH_NO"
            If Trim(val_bch_no) = String.Empty Then
                .Value = DBNull.Value
            Else
                .Value = Trim(val_bch_no)
            End If
        End With
        With prm2
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Size = 20
            .ParameterName = "@SONY_BCH_NO"
            If Trim(val_sony_bch_no) = String.Empty Then
                .Value = DBNull.Value
            Else
                .Value = Trim(val_sony_bch_no)
            End If
        End With

        Try
            cmd.Parameters.Add(prm1)
            cmd.Parameters.Add(prm2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "stp_get_serialNo"
            DatabaseHelper.OpenConnection(cmd.Connection)
            'If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)
            Dim idr As IDataReader
            idr = cmd.ExecuteReader()

            Dim _ds As DataSet = New DataSet()
            Dim _dt As DataTable = New DataTable()
            _dt.TableName = "sn"
            _ds.Tables.Add(_dt)
            _ds.Load(idr, LoadOption.OverwriteChanges, _dt)
            idr.Close()

            dgv.Refresh()
            dgv.DataMember = "sn"
            dgv.DataSource = _ds
            dgv.AutoGenerateColumns = False
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            Return True
        Catch eex As Exception
            Return False
        Finally
            Try
                DatabaseHelper.CloseConnection(cmd.Connection)
                'cmd.Connection.Close()
            Catch ex As Exception
            End Try
            cmd.Dispose()
        End Try
    End Function

    Function ConvertString(ByVal var_str As String) As String
        Return ConvertString(var_str, 42)
    End Function
    Function ConvertString(ByVal var_str As String, ByVal var_num As Integer) As String
        Dim tmp As String = Convert.ToChar(var_num).ToString()
        Return tmp + var_str + tmp
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'GetDate("BNCH1104270002", String.Empty)
        GetDate(txt_bch_no.Text, txt_sony_bch_no.Text)
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
    End Sub

    Private Function GetCheckDate() As DS_DN
        Dim ds As DS_DN = New DS_DN()
        Try
            If dgv.Rows.Count > 0 Then
                Dim parmUserCode As String = UserRightMgr.gUserCode
                Dim dr As DataRow
                Dim str_date As String = DateTime.Now.ToShortDateString()
                For Each _DataGridViewRow As DataGridViewRow In dgv.Rows
                    If _DataGridViewRow.Cells(1).Value Is Nothing Then Exit For
                    If _DataGridViewRow.Cells(0).Value = True Then
                        dr = ds.DT_DN.NewDT_DNRow()
                        dr("DN_NO") = _DataGridViewRow.Cells(1).Value
                        dr("SKU_NO") = _DataGridViewRow.Cells(2).Value
                        dr("SERIAL_NO") = _DataGridViewRow.Cells(3).Value
                        dr("PRINT_NAME") = parmUserCode
                        dr("PRINT_TIME") = str_date
                        dr("ID") = _DataGridViewRow.Cells(4).Value
                        ds.DT_DN.Rows.Add(dr)
                    End If
                    'Console.WriteLine(String.Format("{0}, {1}", er(0), er(1)))
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return ds
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim ds As DS_DN = GetCheckDate() '取得数据
            If ds.Tables(0).Rows.Count > 0 Then
                ExportInfo(ds)
            Else
                MessageBox.Show("请选择要导出的数据。")
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Sub ExportInfo(ByVal ds As DS_DN)
        Dim XmlFile As String
        Dim imp As New Lookup
        Dim s As String
        Dim ofd As New SaveFileDialog
        Try
            XmlFile = "ExportSN.xml"

            'ds = imp.SQLToDataSet("SELECT dn_no, sku_no, sno FROM tasklin", CommandType.Text, ReportCommandTimeout)
            'XmlFile = "ExportSN1.xml"
        Catch ex As Exception
        End Try
        ofd.Filter = "Excel File(*.xls)|*.xls"
        ofd.CheckFileExists = False
        ofd.AddExtension = True
        If ofd.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            s = ofd.FileName()
            Dim exp As New ProcessorBase(Me)
            Dim clf As New CXListForm
            If ds.Tables(0).Rows.Count <= 0 Then
                MsgBox("报表没有数据，请重新设置查询条件。")
            Else
                exp.SetSourceDevice(ds, clf.MergedFilters)
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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim frm As New frmPrintSeriaNo()
        frm.ds = GetCheckDate()
        If frm.ds.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("请选择要打印的数据。")
        Else
            frm.DNPrint1.SetDataSource(frm.ds)
            frm.CrystalReportViewer1.Refresh()
            frm.CrystalReportViewer1.RefreshReport()
            frm.ShowInTaskbar = False
            'frm.MaximizeBox = False
            frm.MinimizeBox = False
            frm.StartPosition = FormStartPosition.CenterScreen
            'frm.FormBorderStyle = FormBorderStyle.FixedDialog
            frm.ShowDialog()
        End If
    End Sub

    Private Sub CheckBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        Try
            CheckBox1.Checked = True
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            For Each _DataGridViewRow As DataGridViewRow In dgv.Rows
                Dim _CheckBox As DataGridViewCheckBoxCell = _DataGridViewRow.Cells(0)
                '_CheckBox.Selected = True
                _CheckBox.Value = True
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub CheckBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.Click
        Try
            CheckBox1.Checked = False
            CheckBox3.Checked = False
            CheckBox2.Checked = True
            For Each _DataGridViewRow As DataGridViewRow In dgv.Rows
                Dim _CheckBox As DataGridViewCheckBoxCell = _DataGridViewRow.Cells(0)
                If _CheckBox.Value Then
                    '_CheckBox.Selected = False
                    _CheckBox.Value = False
                Else
                    '_CheckBox.Selected = True
                    _CheckBox.Value = True
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CheckBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.Click
        Try
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            For Each _DataGridViewRow As DataGridViewRow In dgv.Rows
                Dim _CheckBox As DataGridViewCheckBoxCell = _DataGridViewRow.Cells(0)
                If _CheckBox.Value Then
                    '_CheckBox.Selected = False
                    _CheckBox.Value = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
