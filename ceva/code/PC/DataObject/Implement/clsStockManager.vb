Imports COMExpress.BusinessObject


Namespace BusinessObject



    Public Class clsStockManager
        Public Shared Function GetAvailableStockForDelivery(ByVal dc_code As String, ByVal wh_code As String, ByVal sku_no As String, ByVal sku_status As String, ByVal sku_ref As String, ByVal tag_no As String) As Double
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm4 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm5 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm6 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm7 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection

            With prm1
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 10
                .ParameterName = "@dc_code"
                .Value = Trim(dc_code)
            End With
            With prm2
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 10
                .ParameterName = "@wh_code"
                .Value = Trim(wh_code)
            End With
            With prm3
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@sku_no"
                .Value = Trim(sku_no)
            End With
            With prm4
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 4
                .ParameterName = "@sku_status"
                .Value = Trim(sku_status)
            End With
            With prm5
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@sku_ref"
                .Value = Trim(sku_ref)
            End With
            With prm6
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 30
                .ParameterName = "@tag_no"
                .Value = Trim(tag_no)
            End With
            With prm7
                .DbType = DbType.Decimal
                .Direction = ParameterDirection.Output
                .Precision = 12
                .Scale = 3
                .ParameterName = "@qty"
            End With
            Try
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.Parameters.Add(prm3)
                cmd.Parameters.Add(prm4)
                cmd.Parameters.Add(prm5)
                cmd.Parameters.Add(prm6)
                cmd.Parameters.Add(prm7)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_stock_GetAvailableStockForDeliveryEx"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm5.Value) Then
                    Return 0
                Else
                    Return CType(prm5.Value, Double)
                End If
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
                Return 0
            Finally
                Try
                    DatabaseHelper.CloseConnection(cmd.Connection)
                    'cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
        End Function

        Public Shared Function GetAvailableStockForPicking(ByVal dc_code As String, ByVal wh_code As String, ByVal sku_no As String, ByVal sku_status As String, ByVal bin_code As String, ByVal sku_ref As String) As Double
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm4 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm5 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm6 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection


            With prm0
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 10
                .ParameterName = "@dc_code"
                .Value = Trim(dc_code)
            End With
            With prm1
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 10
                .ParameterName = "@wh_code"
                .Value = Trim(wh_code)
            End With
            With prm2
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@sku_no"
                .Value = Trim(sku_no)
            End With
            With prm3
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 4
                .ParameterName = "@sku_status"
                .Value = Trim(sku_status)
            End With
            With prm4
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 10
                .ParameterName = "@bin_code"
                .Value = Trim(bin_code)
            End With
            With prm5
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@sku_ref"
                .Value = Trim(sku_ref)
            End With
            With prm6
                .DbType = DbType.Decimal
                .Direction = ParameterDirection.Output
                .Precision = 12
                .Scale = 3
                .ParameterName = "@qty"
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.Parameters.Add(prm3)
                cmd.Parameters.Add(prm4)
                cmd.Parameters.Add(prm5)
                cmd.Parameters.Add(prm6)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_stock_GetAvailableStockForPicking"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm6.Value) Then
                    Return 0
                Else
                    Return CType(prm6.Value, Double)
                End If
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
                Return 0
            Finally
                Try
                    DatabaseHelper.CloseConnection(cmd.Connection)
                    'cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
        End Function

        Public Shared Sub StockMove(ByVal dc_code As String, ByVal wh_code As String, ByVal source_bin As String, ByVal dest_bin As String, _
            ByVal sku_no As String, ByVal sku_status As String, ByVal lot_no As String, ByVal mov_qty As Double, _
            ByVal doc_no As String, ByVal row_id As String, ByVal sku_ref As String, ByVal tag_no As String)
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm4 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm5 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm6 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm7 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm8 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm9 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm10 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm11 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm12 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection
            With prm0
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 10
                .ParameterName = "@dc_code"
                .Value = Trim(dc_code)
            End With
            With prm1
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 10
                .ParameterName = "@wh_code"
                .Value = Trim(wh_code)
            End With
            With prm2
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@source_bin"
                .Value = Trim(source_bin)
            End With
            With prm3
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@dest_bin"
                .Value = Trim(dest_bin)
            End With
            With prm4
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 4
                .ParameterName = "@sku_status"
                .Value = Trim(sku_status)
            End With
            With prm5
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@sku_no"
                .Value = Trim(sku_no)
            End With
            With prm6
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@lot_no"
                .Value = Trim(lot_no)
            End With
            With prm7
                .DbType = DbType.Decimal
                .Direction = ParameterDirection.Input
                .Precision = 12
                .Scale = 3
                .ParameterName = "@mov_qty"
                .Value = mov_qty
            End With
            With prm8
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@doc_no"
                .Value = Trim(doc_no)
            End With
            With prm9
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 5
                .ParameterName = "@row_id"
                .Value = Trim(row_id)
            End With
            With prm10
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@sku_ref"
                .Value = Trim(sku_ref)
            End With
            With prm11
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 30
                .ParameterName = "@tag_no"
                .Value = Trim(tag_no)
            End With
            With prm12
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@opt_by"
                .Value = Trim(UserRightMgr.gUserCode)
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.Parameters.Add(prm3)
                cmd.Parameters.Add(prm4)
                cmd.Parameters.Add(prm5)
                cmd.Parameters.Add(prm6)
                cmd.Parameters.Add(prm7)
                cmd.Parameters.Add(prm8)
                cmd.Parameters.Add(prm9)
                cmd.Parameters.Add(prm10)
                cmd.Parameters.Add(prm11)
                cmd.Parameters.Add(prm12)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_stock_move_for_ui"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()

            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
                Throw e
            Finally
                Try
                    DatabaseHelper.CloseConnection(cmd.Connection)
                    'cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
        End Sub


    End Class
End Namespace
