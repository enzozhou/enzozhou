Imports COMExpress.BusinessObject

Namespace BusinessObject


    Public Class SysRes

        Public Shared Function RecordResource(ByVal res_id As String, ByVal str As String, ByVal res_type As String) As Boolean
            'This function is only for debug version to record missing resource
#If DEBUG Then
            Dim cmd As IDbCommand = DatabaseHelper.CreateDbCommand
            Dim prm1 As IDbDataParameter = DatabaseHelper.CreateDbParameter()
            Dim prm2 As IDbDataParameter = DatabaseHelper.CreateDbParameter()
            Dim prm3 As IDbDataParameter = DatabaseHelper.CreateDbParameter()
            cmd.Connection = DatabaseHelper.CreateDbConnection

            With prm1
                .ParameterName = "@res_id"
                .Direction = ParameterDirection.Input
                .DbType = DbType.String
                .Value = res_id
                .Size = 100
            End With
            With prm2
                .ParameterName = "@res_name"
                .Direction = ParameterDirection.Input
                .DbType = DbType.String
                .Value = str
                .Size = 200
            End With
            With prm3
                .ParameterName = "@res_type"
                .Direction = ParameterDirection.Input
                .DbType = DbType.String
                .Value = res_type
                .Size = 20
            End With
            Try
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.Parameters.Add(prm3)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_res_record"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                cmd.ExecuteNonQuery()
                Return True
            Catch e As Exception
                Throw e
            Finally
                Try
                    DatabaseHelper.CloseConnection(cmd.Connection)
                    'cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
#End If
        End Function

    End Class


End Namespace
