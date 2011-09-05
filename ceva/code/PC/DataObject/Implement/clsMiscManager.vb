Imports COMExpress.BusinessObject


Namespace BusinessObject
    Public Class clsMiscManager

        'getSkuKitSingleList 
        Public Shared Function IsKitSingleList(ByVal dc_code As String, ByVal sku_no As String) As Boolean
            Dim strSQL As String
            Dim ds As DataSet
            Try
                strSQL = "select 1 from dbo.getSkuKitSingleList('" + dc_code + "',NULL) where sku_no='" + Trim(sku_no) + "'"
                ds = COMExpress.BusinessObject.DatabaseHelper.SQLToDataSet(strSQL, CommandType.Text)
                If ds.Tables(0).Rows.Count > 0 Then
                    Return True
                End If
                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function




        Public Shared Function CheckSkuRetStatus(ByVal sku_status As String, ByVal sku_no As String) As String
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection

            With prm1
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 4
                .ParameterName = "@sku_status"
                .Value = Trim(sku_status)
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
                .Direction = ParameterDirection.Output
                .Size = 4
                .ParameterName = "@ret_status"
            End With
            Try
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.Parameters.Add(prm3)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_fl_CheckSkuRetStatus"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm3.Value) = True Then
                    Return sku_status
                Else
                    Return CType(prm3.Value, String)
                End If
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
                Return sku_status
            Finally
                Try
                    DatabaseHelper.CloseConnection(cmd.Connection)
                    'cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
        End Function


        Public Shared Sub OutboundDWSCheckDetail(ByVal dc_code As String, ByVal dn_no As String, ByRef bSame As Boolean, ByRef intRet As Integer)
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm3 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm4 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
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
                .DbType = DbType.Boolean
                .Direction = ParameterDirection.Output
                .ParameterName = "@samedate"
            End With
            With prm4
                .DbType = DbType.Int32
                .Direction = ParameterDirection.Output
                .ParameterName = "@ret"
            End With
            Try
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.Parameters.Add(prm3)
                cmd.Parameters.Add(prm4)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_fl_OutboundDWSCheckDetail"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm3.Value) = True Then
                    bSame = True
                Else
                    bSame = CType(prm3.Value, Boolean)
                End If
                If IsDBNull(prm4.Value) = True Then
                    intRet = 0
                Else
                    intRet = CType(prm4.Value, Integer)
                End If

            Catch ex As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
                Throw New Exception("function OutboundDWSCheckDetail fail.", ex)
            Finally
                Try
                    DatabaseHelper.CloseConnection(cmd.Connection)
                    'cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
        End Sub


        Public Shared Sub FreeSystemCache()
            Dim strSQL As String
            strSQL = "exec stp_sys_freecache"
            DatabaseHelper.ExecuteSQL(strSQL, CommandType.Text)
        End Sub


        'Public Shared Function GetDWSMovementDocument(ByVal dc_code As String, ByVal dn_no As String, ByRef bin_code As String) As String
        '    Dim strSQL As String
        '    Dim rs As DataSet
        '    Dim opt As clssysoption
        '    Try
        '        opt = clssysoption.Load(dc_code, "Buffer", clsOption.BinTypeCodeDWS)
        '        bin_code = Trim(opt.value)
        '        strSQL = "select doc_no from mvhdr where dc_code='" + dc_code + "' and ref_no='" + dn_no + "' and doc_type='" + DocType.MovementForDWS + "'"
        '        rs = COMExpress.BusinessObject.DatabaseHelper.SQLToDataSet(strSQL, CommandType.Text)
        '        If rs.Tables(0).Rows.Count <= 0 Then
        '            Return ""
        '        End If
        '        Return CType(rs.Tables(0).Rows(0).Item(0), String)
        '    Catch ex As Exception
        '    End Try
        '    Return ""
        'End Function


        'Public Shared Sub CloseDWSMovement(ByVal dc_code As String, ByVal dn_no As String)
        '    Dim doc_no As String
        '    Dim strSQL As String
        '    Dim rs As DataSet
        '    Try

        '        strSQL = "select doc_no from mvhdr where dc_code='" + dc_code + "' and ref_no='" + dn_no + "' and doc_type='" + DocType.MovementForDWS + "'"
        '        rs = COMExpress.BusinessObject.DatabaseHelper.SQLToDataSet(strSQL, CommandType.Text)
        '        If rs.Tables(0).Rows.Count <= 0 Then
        '            Return
        '        End If
        '        doc_no = CType(rs.Tables(0).Rows(0).Item(0), String)
        '        Dim mv As clsmvhdr
        '        Dim i As Integer
        '        mv = clsmvhdr.Load(dc_code, doc_no)
        '        mv.Loadclsmvlins()
        '        For i = 0 To mv.clsmvlins.Count - 1
        '            mv.clsmvlins(i).src_qty = mv.clsmvlins(i).sys_qty
        '            mv.clsmvlins(i).act_qty = mv.clsmvlins(i).sys_qty
        '            mv.clsmvlins(i).status_code = GlobalStatus.MOVLIN_CLOSE
        '        Next
        '        mv.status_code = GlobalStatus.MOVHDR_CLOSE
        '        mv.Save()
        '    Catch ex As Exception
        '        COMExpress.BusinessObject.CXEventLog.LogToFile(ex.Message + vbCrLf + ex.StackTrace, CXEventLog.LogTypeConstants.logUI)
        '    End Try

        'End Sub

    End Class
End Namespace
