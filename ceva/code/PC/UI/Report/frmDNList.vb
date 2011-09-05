Imports YT
Imports YT.BusinessObject
Imports COMExpress.BusinessObject
Imports System.IO
Imports ImportExport
Imports COMExpress.Windows.Forms

Public Class frmDNList
    Dim _ds As DataSet
    Public Function GetDate() As Boolean
        _ds = New DataSet()
        Dim val_bch_no As String = txtCEVABCH.Text
        Dim val_sony_bch_no As String = txtSonyBCH.Text
        Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
        Dim parmUserCode As String = UserRightMgr.gUserCode
        Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm4 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm5 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm6 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
        With prm3
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Size = 10
            .ParameterName = "@BIN_CODE"
            If txtBin.Text.Trim() = "" Then
                .Value = DBNull.Value
            Else
                .Value = txtBin.Text.Trim()
            End If
        End With
        With prm4
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Size = 10
            .ParameterName = "@CITY_TO"
            If txtCityTo.Text.Trim() = "" Then
                .Value = DBNull.Value
            Else
                .Value = txtCityTo.Text.Trim()
            End If
        End With
        With prm5
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Size = 20
            .ParameterName = "@SKU_NO"
            If txtSKUNo.Text.Trim() = "" Then
                .Value = DBNull.Value
            Else
                .Value = txtSKUNo.Text.Trim()
            End If
        End With
        With prm6
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Size = 50
            .ParameterName = "@MODEL_NO"
            If txtModel.Text.Trim() = "" Then
                .Value = DBNull.Value
            Else
                .Value = txtModel.Text.Trim()
            End If
        End With

        Try
            cmd.Parameters.Add(prm1)
            cmd.Parameters.Add(prm2)
            cmd.Parameters.Add(prm3)
            cmd.Parameters.Add(prm4)
            cmd.Parameters.Add(prm5)
            cmd.Parameters.Add(prm6)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "stp_get_DNList"
            DatabaseHelper.OpenConnection(cmd.Connection)
            'If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)
            Dim idr As IDataReader
            idr = cmd.ExecuteReader()

            'Dim _ds As DataSet = New DataSet()
            Dim _dt As DataTable = New DataTable()
            _dt.TableName = "dnlist"
            _ds.Tables.Add(_dt)
            _ds.Load(idr, LoadOption.OverwriteChanges, _dt)
            idr.Close()

            dgv.Refresh()
            dgv.DataMember = "dnlist"
            dgv.DataSource = _ds
            'dgv.AutoGenerateColumns = False
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            Return True
        Catch eex As Exception
            Return False
        Finally
            Try
                DatabaseHelper.CloseConnection(cmd.Connection)
                'cmd.Connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cmd.Dispose()
        End Try
    End Function

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Me.GetDate()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim XmlFile As String
        Dim imp As New Lookup
        Dim s As String
        Dim ofd As New SaveFileDialog
        Try
            XmlFile = "ExportDNList.xml"

            'ds = imp.SQLToDataSet("SELECT dn_no, sku_no, sno FROM tasklin", CommandType.Text, ReportCommandTimeout)
            'XmlFile = "ExportSN1.xml"
            ofd.Filter = "Excel File(*.xls)|*.xls"
            ofd.CheckFileExists = False
            ofd.AddExtension = True
            If ofd.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                s = ofd.FileName()
                Dim exp As New ProcessorBase(Me)
                Dim clf As New CXListForm
                If _ds.Tables(0).Rows.Count <= 0 Then
                    MsgBox("报表没有数据，请重新设置查询条件。")
                Else
                    exp.SetSourceDevice(_ds, clf.MergedFilters)
                    exp.RunExport(s, GetLibFile(XmlFile))
                    Dim wkbNew As New ImportExport.Office.ExcelFile
                    wkbNew.OpenWorkBookShow(s)
                    GC.Collect()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ofd.Dispose()
            ofd = Nothing
            GC.Collect()
        End Try
    End Sub
End Class