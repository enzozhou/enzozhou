'系统日志函数
Public Class sysLog
    Public Shared logFile As String = "WSE_SrvLog.txt"
    Public Shared logFile_Err As String = "WSE_SrvLog_ERR.txt"

    Public Shared Sub log(ByVal as_msg As String)
        Try
            Dim fis As System.IO.FileInfo = New System.IO.FileInfo(logFile)
            If fis.Exists Then
                If fis.Length > 20 * 1024 * 1024 Then '超过20M就删除文件
                    fis.Delete()
                End If
            End If
            Dim fw As System.IO.StreamWriter = New System.IO.StreamWriter(logFile, True)
            fw.WriteLine(Now().ToString + " : " + as_msg)
            fw.Flush()
            fw.Close()
        Catch ex As Exception
            ' Dim svrFilePath As String = Server.MapPath("downloadFiles") + "\" 
            Dim fw2 As System.IO.StreamWriter = New System.IO.StreamWriter(logFile_Err, True)
            fw2.WriteLine("sysLog 文件无法启动：" + ex.Message + "  " + logFile_Err)
            fw2.Flush()
            fw2.Close()
        End Try
    End Sub
End Class
