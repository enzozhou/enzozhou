Namespace BusinessObject

    Public Class clsBsLock
        '本类的代码,不启用事务,也不受其它的事务的控制
        Private Shared Function GetSequence() As Long
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection
            With prm1
                .DbType = DbType.Int64
                .Direction = ParameterDirection.Output
                .ParameterName = "@seq_id"
                .Value = 0
            End With
            Try
                cmd.Parameters.Add(prm1)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_que_getSeqId"
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
                Return CType(prm1.Value, Long)
            Catch e As Exception
                Throw New Exception("GetSequence fail", e)
            Finally
                Try
                    cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
        End Function

        Private Shared Sub Lock(ByVal BsName As String, ByVal BsSeq As Long)
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection
            With prm1
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 200
                .ParameterName = "@bs_name"
                .Value = Trim(BsName)
            End With
            With prm2
                .DbType = DbType.Int64
                .Direction = ParameterDirection.Input
                .ParameterName = "@bs_id"
                .Value = BsSeq
            End With
            Try
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_bs_CheckAndWaitBeforeDone"
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
            Catch e As Exception
                Throw New Exception("Lock fail", e)
            Finally
                Try
                    cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
        End Sub

        Private Shared Sub Remove(ByVal BsName As String, ByVal BsSeq As Long)
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection
            With prm1
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 200
                .ParameterName = "@bs_name"
                .Value = Trim(BsName)
            End With
            With prm2
                .DbType = DbType.Int64
                .Direction = ParameterDirection.Input
                .ParameterName = "@bs_id"
                .Value = BsSeq
            End With
            Try
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_bs_Remove"
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
            Catch e As Exception
                Throw New Exception("Remove fail", e)
            Finally
                Try
                    cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
        End Sub


        Private mSeq As Long = 0
        Public Property SequenceNo() As Long
            Get
                Return mSeq
            End Get
            Set(ByVal Value As Long)
                mSeq = Value
            End Set
        End Property



        Private Sub LockBussinessInternal(ByVal BsName As String)
            Try
                'mSeq = GetSequence()
                Lock(BsName, mSeq)
            Catch ex As Exception
                COMExpress.BusinessObject.CXEventLog.LogToFile(ex.ToString, COMExpress.BusinessObject.CXEventLog.LogTypeConstants.logUI)
            End Try
        End Sub

        Public Sub LockBussiness(ByVal dc_code As String, ByVal lkName As String)
            Dim BsName As String
            BsName = Trim(dc_code) + Trim(lkName)
            LockBussinessInternal(BsName)
        End Sub

        Public Sub LockBussiness(ByVal dc_code As String, ByVal wh_code As String, ByVal bin_code As String, ByVal sku_no As String, ByVal sku_status As String, ByVal sku_ref As String, ByVal tag_no As String)
            Dim BsName As String
            If Trim(sku_ref) = "" Then
                sku_ref = "[NULL]"
            End If
            If Trim(tag_no) = "" Then
                tag_no = "[NULL]"
            End If
            BsName = Trim(dc_code) + Trim(wh_code) + Trim(bin_code) + Trim(sku_no) + Trim(sku_status) + Trim(sku_ref) + Trim(tag_no)
            LockBussinessInternal(BsName)
        End Sub



        Public Sub LockRemove(ByVal dc_code As String, ByVal lkName As String)
            Dim BsName As String
            Try
                BsName = Trim(dc_code) + Trim(lkName)
                Remove(BsName, mSeq)
            Catch ex As Exception
                COMExpress.BusinessObject.CXEventLog.LogToFile(ex.ToString, COMExpress.BusinessObject.CXEventLog.LogTypeConstants.logUI)
            End Try
        End Sub

        Public Sub LockRemove(ByVal dc_code As String, ByVal wh_code As String, ByVal bin_code As String, ByVal sku_no As String, ByVal sku_status As String, ByVal sku_ref As String, ByVal tag_no As String)
            Dim BsName As String
            If Trim(sku_ref) = "" Then
                sku_ref = "[NULL]"
            End If
            If Trim(tag_no) = "" Then
                tag_no = "[NULL]"
            End If
            BsName = Trim(dc_code) + Trim(wh_code) + Trim(bin_code) + Trim(sku_no) + Trim(sku_status) + Trim(sku_ref) + Trim(tag_no)
            Try
                Remove(BsName, mSeq)
            Catch ex As Exception
                COMExpress.BusinessObject.CXEventLog.LogToFile(ex.ToString, COMExpress.BusinessObject.CXEventLog.LogTypeConstants.logUI)
            End Try
        End Sub




        Public Sub New()
            Try
                mSeq = GetSequence()
            Catch ex As Exception
                mSeq = 0
            End Try
        End Sub
    End Class
End Namespace
