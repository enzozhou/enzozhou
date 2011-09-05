Imports COMExpress.BusinessObject


Namespace BusinessObject
    Public Class clsBlockManager
        Public Shared Function IsOrderBlocked(ByVal dc_code As String, ByVal dn_no As String) As Boolean
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
                .Size = 20
                .ParameterName = "@dn_no"
                .Value = Trim(dn_no)
            End With
            With prm2
                .DbType = DbType.Boolean
                .Direction = ParameterDirection.Output
                .ParameterName = "@IsBlocked"
            End With

            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_fl_IsOrderBlocked"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm2.Value) Then
                    Return False
                Else
                    Return CType(prm2.Value, Boolean)
                End If
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
                Return False
            Finally
                Try
                    cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
        End Function


        Public Shared Function IsOrderCanceled(ByVal dc_code As String, ByVal dn_no As String) As Boolean
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
                .Size = 20
                .ParameterName = "@dn_no"
                .Value = Trim(dn_no)
            End With
            With prm2
                .DbType = DbType.Boolean
                .Direction = ParameterDirection.Output
                .ParameterName = "@IsBlocked"
            End With

            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_fl_IsOrderCanceled"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm2.Value) Then
                    Return False
                Else
                    Return CType(prm2.Value, Boolean)
                End If
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
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


        Public Shared Function IsSnoBlocked(ByVal dc_code As String, ByVal sku_no As String, ByVal sno As String) As Boolean
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
                .Size = 20
                .ParameterName = "@sku_no"
                .Value = Trim(sku_no)
            End With
            With prm2
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@sno"
                .Value = Trim(sno)
            End With
            With prm3
                .DbType = DbType.Boolean
                .Direction = ParameterDirection.Output
                .ParameterName = "@IsBlocked"
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.Parameters.Add(prm3)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_fl_IsSnoBlocked"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm3.Value) Then
                    Return False
                Else
                    Return CType(prm3.Value, Boolean)
                End If
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
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

        Public Shared Function IsSnoExBlocked(ByVal dc_code As String, ByVal sku_no As String, ByVal startsno As String, ByVal endsno As String) As Boolean
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm4 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm5 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
                .Size = 20
                .ParameterName = "@sku_no"
                .Value = Trim(sku_no)
            End With
            With prm2
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@Startsno"
                .Value = Trim(startsno)
            End With
            With prm3
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@Endsno"
                .Value = Trim(endsno)
            End With
            With prm4
                .DbType = DbType.Boolean
                .Direction = ParameterDirection.Output
                .ParameterName = "@IsBlocked"
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.Parameters.Add(prm3)
                cmd.Parameters.Add(prm4)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_fl_IsSnoExBlocked"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm4.Value) Then
                    Return False
                Else
                    Return CType(prm4.Value, Boolean)
                End If
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
                Return False
            Finally
                Try
                    cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
        End Function
        Public Shared Function IsSkuBlocked(ByVal dc_code As String, ByVal sku_no As String) As Boolean
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
                .Size = 20
                .ParameterName = "@sku_no"
                .Value = Trim(sku_no)
            End With
            With prm2
                .DbType = DbType.Boolean
                .Direction = ParameterDirection.Output
                .ParameterName = "@IsBlocked"
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_fl_IsSkuBlocked"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm2.Value) Then
                    Return False
                Else
                    Return CType(prm2.Value, Boolean)
                End If
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
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

        Public Shared Function DnHaveUnMeasuredSku(ByVal dc_code As String, ByVal dn_no As String) As Boolean
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
                .Size = 20
                .ParameterName = "@dn_no"
                .Value = Trim(dn_no)
            End With
            With prm2
                .DbType = DbType.Boolean
                .Direction = ParameterDirection.Output
                .ParameterName = "@Unmeasured"
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_fl_DnHaveUnmeasured"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm2.Value) Then
                    Return False
                Else
                    Return CType(prm2.Value, Boolean)
                End If
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
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


        Public Shared Function DeliveryPreBlock(ByVal dc_code As String, ByVal dn_no As String) As Boolean
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
                .Size = 20
                .ParameterName = "@dn_no"
                .Value = Trim(dn_no)
            End With
            With prm2
                .DbType = DbType.String
                .Size = 20
                .Direction = ParameterDirection.Input
                .ParameterName = "@opt_by"
                .Value = Trim(UserRightMgr.gUserCode)
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_stock_deliverypreblock"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                Return True
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
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

        Public Shared Function DeliveryPreBlockRemove(ByVal dc_code As String, ByVal dn_no As String) As Boolean
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
                .Size = 20
                .ParameterName = "@dn_no"
                .Value = Trim(dn_no)
            End With
            With prm2
                .DbType = DbType.String
                .Size = 20
                .Direction = ParameterDirection.Input
                .ParameterName = "@opt_by"
                .Value = Trim(UserRightMgr.gUserCode)
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_stock_deliverypreblockremove"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                Return True
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
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


        Public Shared Sub CheckStockUsageForDelivery()
            Dim strSQL As String = "stp_fl_CheckStockUsage"
            COMExpress.BusinessObject.DatabaseHelper.ExecuteSQL(strSQL, CommandType.Text)
        End Sub


    End Class




End Namespace