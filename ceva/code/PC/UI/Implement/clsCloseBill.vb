Imports YT
Imports YT.BusinessObject
Imports COMExpress.BusinessObject
Public Class clsCloseBill
    Public Function CloseSingleDN(ByVal dc_code As String, ByVal dn_no As String, ByRef RetCode As String, ByRef RetMsg As String) As Boolean
        Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
        Dim parmUserCode As String = UserRightMgr.gUserCode
        Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm4 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm5 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
            .Size = 20
            .ParameterName = "@dn_no"
            .Value = Trim(dn_no)
        End With
        With prm3
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Size = 20
            .ParameterName = "@opt_by"
            .Value = Trim(parmUserCode)
        End With
        With prm4
            .DbType = DbType.String
            .Direction = ParameterDirection.Output
            .Size = 30
            .ParameterName = "@RetCode"
            .Value = Trim(RetCode)
        End With
        With prm5
            .DbType = DbType.String
            .Direction = ParameterDirection.Output
            .Size = 255
            .ParameterName = "@RetMsg"
            .Value = Trim(RetMsg)
        End With
        Try
            cmd.Parameters.Add(prm1)
            cmd.Parameters.Add(prm2)
            cmd.Parameters.Add(prm3)
            cmd.Parameters.Add(prm4)
            cmd.Parameters.Add(prm5)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "APP_Close_DN"
            DatabaseHelper.OpenConnection(cmd.Connection)
            If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)
            cmd.ExecuteNonQuery()
            If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
            Return True
        Catch eex As Exception
            Try
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
            Catch ee As Exception
                Return False
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
    Public Function CloseSingleBanch(ByVal dc_code As String, ByVal bch_no As String, ByRef RetCode As String, ByRef RetMsg As String) As Boolean
        Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
        Dim parmUserCode As String = UserRightMgr.gUserCode
        Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm4 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm5 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
            .Size = 20
            .ParameterName = "@bch_no"
            .Value = Trim(bch_no)
        End With
        With prm3
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Size = 20
            .ParameterName = "@opt_by"
            .Value = Trim(parmUserCode)
        End With
        With prm4
            .DbType = DbType.String
            .Direction = ParameterDirection.Output
            .Size = 30
            .ParameterName = "@RetCode"
            .Value = Trim(RetCode)
        End With
        With prm5
            .DbType = DbType.String
            .Direction = ParameterDirection.Output
            .Size = 255
            .ParameterName = "@RetMsg"
            .Value = Trim(RetMsg)
        End With
        Try
            cmd.Parameters.Add(prm1)
            cmd.Parameters.Add(prm2)
            cmd.Parameters.Add(prm3)
            cmd.Parameters.Add(prm4)
            cmd.Parameters.Add(prm5)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "APP_Close_Banch"
            DatabaseHelper.OpenConnection(cmd.Connection)
            If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)
            cmd.ExecuteNonQuery()
            If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
            Return True
        Catch eex As Exception
            Try
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
            Catch ee As Exception
                Return False
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
End Class
