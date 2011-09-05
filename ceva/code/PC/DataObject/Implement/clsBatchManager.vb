'Imports YT.BusinessObject
Imports COMExpress.BusinessObject

Namespace BusinessObject


    Public Class clsBatchManager

        Public Shared Function GetBatchLockValue(ByVal dc_code As String, ByVal bch_no As String) As Integer
            Dim ds As DataSet
            Dim strSQL As String
            Try
                strSQL = "select locked from bchhdr where dc_code='" + dc_code + "' and bch_no='" + Trim(bch_no) + "'"
                ds = COMExpress.BusinessObject.DatabaseHelper.SQLToDataSet(strSQL, CommandType.Text)
                If IsDBNull(ds.Tables(0).Rows(0).Item(0)) = True Then
                    Return 0
                Else
                    Return CType(ds.Tables(0).Rows(0).Item(0), Integer)
                End If
            Catch ex As Exception
                Return -1
            End Try

        End Function

        Public Shared Sub SetBatchLockValue(ByVal dc_code As String, ByVal bch_no As String, ByVal iLock As Integer)
            Dim strSQL As String
            strSQL = "update bchhdr set locked=" + CStr(iLock) + " where dc_code='" + dc_code + "' and  bch_no='" + Trim(bch_no) + "'"
            Try
                COMExpress.BusinessObject.DatabaseHelper.ExecuteSQL(strSQL, CommandType.Text)
            Catch ex As Exception

            End Try
        End Sub

        Public Shared Function GetBatchSequenceNo(ByVal dc_code As String, ByVal carr_code As String) As Integer
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
                .Size = 10
                .ParameterName = "@carr_code"
                .Value = Trim(carr_code)
            End With
            With prm2
                .DbType = DbType.Int32
                .Direction = ParameterDirection.Output
                .ParameterName = "@seq"
            End With

            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_get_BatchSequenceNo"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm2.Value) = True Then
                    Return 0
                Else
                    Return CType(prm2.Value, Integer)
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





        Public Shared Function DeliveryNoteJumpBatch(ByVal dc_code As String, ByVal dn_no As String, ByVal carr_code As String) As String
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm4 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
                .Direction = ParameterDirection.Input
                .ParameterName = "@carr_code"
                .Size = 20
                .Value = Trim(carr_code)
            End With
            With prm3
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@opt_by"
                .Value = Trim(UserRightMgr.gUserCode)
            End With
            With prm4
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .Size = 20
                .ParameterName = "@bch_no"
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.Parameters.Add(prm3)
                cmd.Parameters.Add(prm4)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_fl_DeliveryNoteJumpBatch"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)
                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                Return CType(prm4.Value, String)
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
        End Function

        Public Shared Function GetBatchByDnNo(ByVal dc_code As String, ByVal dn_no As String) As String
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
                .Direction = ParameterDirection.Output
                .ParameterName = "@bch_no"
                .Size = 20
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_fl_GetBatchByDnNo"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)
                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm2.Value) = True Then
                    Return ""
                End If
                Return CType(prm2.Value, String)
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
            Finally
                Try
                    DatabaseHelper.CloseConnection(cmd.Connection)
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
            Return ""
        End Function


        Public Shared Function GetBatchByRoNo(ByVal dc_code As String, ByVal ro_no As String) As String
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
                .ParameterName = "@ro_no"
                .Value = Trim(ro_no)
            End With
            With prm2
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .ParameterName = "@bch_no"
                .Size = 20
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_fl_GetBatchByRoNo"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)
                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm2.Value) = True Then
                    Return ""
                End If
                Return CType(prm2.Value, String)
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
            Finally
                Try
                    DatabaseHelper.CloseConnection(cmd.Connection)
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
            Return ""
        End Function

    End Class


End Namespace
