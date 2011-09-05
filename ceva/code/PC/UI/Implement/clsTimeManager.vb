Public Class clsTimeManager

    Declare Function FileTimeToSystemTime Lib "kernel32.dll" (ByRef ft As Long, ByVal st As Byte()) As Integer
    Declare Function SetSystemTime Lib "kernel32.dll" (ByVal st As Byte()) As Integer


    Public Sub SetTime(ByVal dt As DateTime)
        Dim ft As Long
        Dim st(16) As Byte
        On Error Resume Next
        ft = dt.ToFileTime()
        FileTimeToSystemTime(ft, st)
        SetSystemTime(st)
    End Sub

    Public Function GetServerTime() As DateTime
        Dim strSQL As String
        Dim ds As DataSet
        Dim dt As DateTime
        strSQL = "select getdate()"
        ds = COMExpress.BusinessObject.DatabaseHelper.SQLToDataSet(strSQL, CommandType.Text)
        dt = CType(ds.Tables(0).Rows(0).Item(0), DateTime)
        Return dt
    End Function

    Public Function CheckTime(ByVal dtServer As DateTime) As Boolean
        Dim dtLow As DateTime
        Dim dtUp As DateTime
        'Dim sp As TimeSpan = New TimeSpan(0, 30, 0)
        dtLow = dtServer.AddMinutes(-30)
        dtUp = dtServer.AddMinutes(30)
        If dtLow < Now And Now < dtUp Then
            Return True
        End If
        Return False
    End Function

    Public Function CheckAndAdjustTime() As Boolean
        Dim dtServer As DateTime
        Try
            dtServer = GetServerTime()
            If CheckTime(dtServer) = True Then
                Return True
            End If
            SetTime(dtServer)
            If CheckTime(dtServer) = True Then
                Return True
            End If
            Message("ID_msg_clsTimeManager_TimeErr", True, "当前系统时间与服务器不一致.")
            Return False
        Catch ex As Exception

        End Try
    End Function

End Class
