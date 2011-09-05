Imports YT
Imports YT.BusinessObject
Imports COMExpress.BusinessObject
Imports System.IO
Imports ImportExport
Imports COMExpress.Windows.Forms

Public Class frmExportCityBin
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
            cmd.CommandText = "stp_get_CityBin"
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
            'dgv.AutoGenerateColumns = False
            'dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            Return True
        Catch eex As Exception
            MessageBox.Show(eex.Message)
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'GetDate("BNCH1104270002", String.Empty)
        GetDate(txt_bch_no.Text, txt_sony_bch_no.Text)
    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim ds As DataSet

            ds = TryCast(dgv.DataSource(), DataSet)   '取得数据

            If Not IsNothing(ds) Then
                ExportInfo(ds)
            Else
                MessageBox.Show("请选择要导出的数据。")
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub ExportInfo(ByVal ds As DataSet)
        Dim XmlFile As String
        Dim imp As New Lookup
        Dim s As String
        Dim ofd As New SaveFileDialog
        Try
            XmlFile = "ExportCityBin.xml"

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

End Class