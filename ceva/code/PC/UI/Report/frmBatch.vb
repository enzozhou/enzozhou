Imports YT
Imports YT.BusinessObject
Imports COMExpress.BusinessObject
Imports System.IO
Imports ImportExport
Imports COMExpress.Windows.Forms

Public Class frmBatch
    Public Sub GetDate()
        Dim _ds As DataSet = New DataSet()
        Dim _Ds_Batch As Ds_Batch = New Ds_Batch()
        Dim val_bch_no As String = txtCEVABCH.Text
        Dim val_sony_bch_no As String = txtSonyBCH.Text
        Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
        Dim parmUserCode As String = UserRightMgr.gUserCode
        Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm4 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
            cmd.CommandText = "stp_get_Batch"
            DatabaseHelper.OpenConnection(cmd.Connection)
            'If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)
            Dim idr As IDataReader
            idr = cmd.ExecuteReader()

            Dim _dt As DataTable = New DataTable
            _dt.TableName = "Dt_Batch"
            _ds.Tables.Add(_dt)
            _ds.Load(idr, LoadOption.OverwriteChanges, _dt)
            idr.Close()

            For Each _dr As DataRow In _ds.Tables(0).Rows
                _Ds_Batch.Dt_Batch.ImportRow(_dr)
            Next

            Dim _RptBatch As New Rpt_Batch()
            _RptBatch.SetDataSource(_Ds_Batch)
            CrystalReportViewer1.ReportSource = _RptBatch
            CrystalReportViewer1.Refresh()
            CrystalReportViewer1.RefreshReport()
        Catch eex As Exception
            MessageBox.Show(eex.Message)
        Finally
            Try
                DatabaseHelper.CloseConnection(cmd.Connection)
                'cmd.Connection.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            cmd.Dispose()
        End Try
    End Sub

    Private Sub btn_search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_search.Click
        Me.GetDate()
    End Sub
End Class