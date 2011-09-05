Imports COMExpress.BusinessObject


Namespace BusinessObject

    Public Class clsDocumentFormat

        Public Const FormatLoan As String = "Loan"
        Public Const FormatRepair As String = "Repair"
        Public Const FormatTemporarily As String = "Temporarily"
        Public Const FormatDeliveryReq As String = "DeliveryReq"
        Public Const FormatDamage As String = "Damage"
        Public Const FormatArchive As String = "Archive"
        Public Const FormatKitReq As String = "KitReq"
        Public Const FormatKitTask As String = "KitTask"
        Public Const FormatSkuMeasure As String = "SkuMeasure"
        Public Const FormatCycleCount As String = "CycleCount"
        Public Const FormatMovement As String = "Movement"
        Public Const FormatBatch As String = "Batch"
        Public Const FormatPicking As String = "Picking"
        Public Const FormatRecieveOrder As String = "RecieveOrder"
        Public Const FormatRecieveTask As String = "RecieveTask"
        Public Const FormatDeliveryNote As String = "DeliveryNote"
        Public Const FormatPutaway As String = "Putaway"
        Public Const FormatTracking As String = "Tracking"
        Public Const FormatReplace As String = "Replace"
        Public Const FormatTag As String = "Tag"
        Public Const FormatInbSample As String = "InbSample"
        Public Const FormatOutSample As String = "OutSample"
        Public Const FormatOutWriteOffSample As String = "OutWOSample"
        Public Const FormatOutDWS As String = "OutDWS"
        Public Const FormatInbPop As String = "InbPop"
        Public Const FormatOutPop As String = "OutPop"

        Private Const DocFormatOptGroup As String = "DocFormat"

        Public Function GetFormatString(ByVal vOptCode As String, ByVal vSubCode As String) As String
            Dim vVal As String
            Try
                vVal = clsOption.GetOptionALL(DocFormatOptGroup, vOptCode, vSubCode)

            Catch ex As Exception
                vVal = ""
            End Try
            Return vVal
        End Function

        Public Function SetFormatString(ByVal vOptCode As String, ByVal vSubCode As String, ByVal vValue As String) As String
            Try
                clsOption.SetOptionALL(DocFormatOptGroup, vOptCode, vSubCode, " ", vValue)
            Catch ex As Exception
            End Try
        End Function

        Public Function GetNewDocumentNumber(ByVal dc_code As String, ByVal vTableName As String, ByVal vDocField As String, ByVal vFormatKey As String, ByVal vEx As String) As String
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
                .Size = 50
                .ParameterName = "@TableName"
                .Value = Trim(vTableName)
            End With
            With prm2
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 50
                .ParameterName = "@FieldName"
                .Value = Trim(vDocField)
            End With
            With prm3
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 50
                .ParameterName = "@FormatCode"
                .Value = Trim(vFormatKey)
            End With
            With prm4
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 50
                .ParameterName = "@Ex"
                .Value = Trim(vEx)
            End With
            With prm5
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .Size = 20
                .ParameterName = "@DocNumber"
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.Parameters.Add(prm1)
                cmd.Parameters.Add(prm2)
                cmd.Parameters.Add(prm3)
                cmd.Parameters.Add(prm4)
                cmd.Parameters.Add(prm5)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_Gen_DocNum"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm5.Value) Then
                    Return ""
                Else
                    Return CType(prm5.Value, String)
                End If
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
                Throw e
                Return ""

            Finally
                Try
                    DatabaseHelper.CloseConnection(cmd.Connection)
                    'cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
        End Function

        Public Function GetDocumentNumberSeq(ByVal dc_code As String, ByVal vTableName As String, ByVal vDocField As String, ByVal vFormatKey As String, ByVal vEx As String, ByVal vDoc_no As String) As Long
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
                .Size = 50
                .ParameterName = "@TableName"
                .Value = Trim(vTableName)
            End With
            With prm2
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 50
                .ParameterName = "@FieldName"
                .Value = Trim(vDocField)
            End With
            With prm3
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 50
                .ParameterName = "@FormatCode"
                .Value = Trim(vFormatKey)
            End With
            With prm4
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 50
                .ParameterName = "@Ex"
                .Value = Trim(vEx)
            End With
            With prm5
                .DbType = DbType.String
                .Direction = ParameterDirection.Input
                .Size = 20
                .ParameterName = "@DocNumber"
                .Value = vDoc_no
            End With
            With prm6
                .DbType = DbType.Int64
                .Direction = ParameterDirection.Output
                .ParameterName = "@seq"
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
                cmd.CommandText = "stp_Gen_DocNumGetSeq"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)

                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm6.Value) = True Then
                    Return 0
                Else
                    Return CType(prm6.Value, Long)
                End If
            Catch e As Exception
                Try
                    If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
                Throw e
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


        Public Function GetNewLoanDocumentNumber() As String
            Dim doc_no1 As String
            Dim doc_no2 As String
            doc_no1 = Me.GetNewDocumentNumber(UserRightMgr.gDcCode, "rohdr", "ro_no", FormatLoan, "")
            doc_no2 = Me.GetNewDocumentNumber(UserRightMgr.gDcCode, "dnhdr", "dn_no", FormatLoan, "")
            If doc_no1 > doc_no2 Then
                Return doc_no1
            End If
            Return doc_no2
        End Function

        Public Shared Function GetGlobalSequenceNo() As Int64
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection
            With prm0
                .DbType = DbType.Int64
                .Direction = ParameterDirection.Output
                .ParameterName = "@seq"
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_get_SequenceNo"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)
                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm0.Value) Then
                    Return 0
                Else
                    Return CType(prm0.Value, Int64)
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

        Public Function GetGlobalRecvhdrSequenceNo() As Int64
            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm0 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
            cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection
            With prm0
                .DbType = DbType.Int64
                .Direction = ParameterDirection.Output
                .ParameterName = "@seq"
            End With
            Try
                cmd.Parameters.Add(prm0)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_get_RecvhdrSequenceNo"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)
                cmd.ExecuteNonQuery()
                If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction.Commit()
                If IsDBNull(prm0.Value) Then
                    Return 0
                Else
                    Return CType(prm0.Value, Int64)
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


    End Class

End Namespace
