'Imports YT.BusinessObject
Imports COMExpress.BusinessObject


Namespace BusinessObject

    Public Class ClientManager
        'Public Shared Function Save(ByVal strUser As String, ByVal strModule As String, Optional ByVal strProgName As String = "HHT") As Boolean
        '    Dim clt As clsclient
        '    Dim NetAddr As String
        '    Try
        '        NetAddr = Lookup.GetMacAddress
        '        clt = clsclient.Load(NetAddr, strUser)
        '        clt.clt_id = NetAddr
        '        clt.log_by = strUser
        '        If clt.IsNew Then
        '            clt.log_dtime = Now
        '        End If
        '        clt.last_active = Now
        '        clt.last_module = strModule
        '        clt.log_dtime = Now
        '        clt.define4 = UserRightMgr.gDcCode
        '        clt.define5 = strProgName
        '        clt.clt_ver = ImpBusinessBaseDerived.clield_ver
        '        clt.dc_code = UserRightMgr.gDcCode
        '        clt.Save()
        '        Return True
        '    Catch ex As Exception
        '        Return False
        '    End Try
        'End Function

        'Public Shared Function Remove(ByVal strUser As String) As Boolean
        '    Dim clt As clsclient
        '    Try
        '        clt = clsclient.Load(Lookup.GetMacAddress, strUser)
        '        If clt.IsNew Then
        '            Exit Function
        '        End If
        '        clt.Delete()
        '        clt.Save()
        '        Return True
        '    Catch ex As Exception
        '        Return False
        '    End Try

        'End Function

        'Public Shared Function RemoveAll(ByVal strUser As String) As Boolean
        '    Dim strSQL As String
        '    strSQL = "delete client where log_by='" + strUser + "'"
        '    Try
        '        COMExpress.BusinessObject.DatabaseHelper.ExecuteSQL(strSQL, CommandType.Text)
        '        Return True
        '    Catch ex As Exception
        '        Return False
        '    End Try
        'End Function


        'Public Shared Function LockResource(ByVal strUser As String, ByVal strResource As String) As Boolean
        '    Dim clt As clsclient
        '    Dim NetAddr As String
        '    Try
        '        NetAddr = Lookup.GetMacAddress
        '        clt = clsclient.Load(NetAddr, strUser)
        '        clt.define1 = strResource
        '        clt.last_active = Now
        '        clt.opt_dtime = Now
        '        clt.dc_code = UserRightMgr.gDcCode
        '        clt.Save()
        '        Return True
        '    Catch ex As Exception
        '    End Try
        '    Return False
        'End Function

        'stp_clt_IsLockedResource
        '    @user nvarchar(20),
        '    @res  nvarchar(50),
        '    @user_locked nvarchar(20) output,
        '    @locked bit output

        Public Shared Function IsLockedResource(ByVal currentUser As String, ByVal strResource As String, ByRef strLockedUser As String) As Boolean
            If Trim(strResource) = "" Then
                Return False
            End If
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection

            With prm0
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@user"
                .Value = Trim(currentUser)
            End With
            With prm1
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 50
                .ParameterName = "@res"
                .Value = Trim(strResource)
            End With
            With prm2
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .Size = 20
                .ParameterName = "@user_locked"
            End With
            With prm3
                .DbType = DbType.Boolean
                .Direction = ParameterDirection.Output
                .ParameterName = "@locked"
            End With

            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.Parameters.Add(prm3)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_clt_IsLockedResource"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then
                    cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)
                End If

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then
                    cmd.Transaction.Commit()
                End If
                If IsDBNull(prm2.Value) = True Then
                    strLockedUser = ""
                Else
                    strLockedUser = CType(prm2.Value, String)
                End If
                If IsDBNull(prm3.Value) = True Then
                    Return False
                Else
                    Return CType(prm3.Value, Boolean)
                End If
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then
                        cmd.Transaction.Rollback()
                    End If
                Catch ee As Exception
                End Try
            Finally
                Try
                    DatabaseHelper.CloseConnection(cmd.Connection)
                    'cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
            Return False
        End Function

        'Public Shared Function GetClient(ByVal strUser As String) As clsclient
        '    Dim clt As clsclient
        '    Dim NetAddr As String
        '    Try
        '        NetAddr = Lookup.GetMacAddress
        '        clt = clsclient.Load(NetAddr, strUser)
        '        Return clt
        '    Catch ex As Exception
        '    End Try
        '    Return clsclient.Newclsclient
        'End Function

        Public Shared Sub RemoveOldClients()
            Dim strSQL As String
            On Error Resume Next
            strSQL = "delete client where opt_dtime<dateadd(hour,-24,getdate())"
            COMExpress.BusinessObject.DatabaseHelper.ExecuteSQL(strSQL)
        End Sub



    End Class
End Namespace
