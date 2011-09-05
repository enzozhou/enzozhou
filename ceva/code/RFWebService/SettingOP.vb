#Region "用于读取下载主数据文件的配置类"

Public Class SettingOP
    Public SettingFileName As String = "Setting.ini"

    ''' <summary>
    ''' 读取配置文件指定key的值
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ReadKeyValue(ByVal as_key As String) As String
        Dim sErr As String = ""
        Dim basePath As String = AppDomain.CurrentDomain.BaseDirectory

        Dim ini_file As String = basePath + "downloadFiles\" + SettingFileName

        'sysLog.log("ReadKeyValue:" + ini_file)

        If Not System.IO.File.Exists(ini_file) Then
            sErr = "文件：" + ini_file + " 不存在"
            sysLog.log(sErr)
            Return Nothing
        End If

        Dim canWrite As Boolean = isFileCanWrite(ini_file)
        While Not canWrite
            canWrite = isFileCanWrite(ini_file)
        End While

        Dim sr As System.IO.StreamReader = Nothing
        Try
            sr = New System.IO.StreamReader(ini_file, System.Text.Encoding.Default)
            Dim line As String = ""
            Dim kv() As String '
            Dim key, value As String
            line = "--"
            While line.Trim <> ""
                line = sr.ReadLine()

                If IsNothing(line) Then
                    Exit While
                End If
                If line.StartsWith("--") Then
                    Continue While
                End If
                kv = line.Split("=")
                key = kv(0)
                value = kv(1)
                If key.Trim = "LastWriteTimeUtc" Then
                    Global_asax.LastWriteTimeUtc = value
                End If
            End While
            Return Global_asax.LastWriteTimeUtc
        Catch ex As Exception
            sysLog.log(ex.Message)
            Return Nothing
        Finally
            sr.Close()
            sr.Dispose()
            sr = Nothing
        End Try
    End Function

    Public Sub WriteKeyValue(ByVal as_key As String, ByVal as_value As String)
        Dim sErr As String = ""
        Dim basePath As String = AppDomain.CurrentDomain.BaseDirectory
        Dim ini_file As String = basePath + "downloadFiles\" + SettingFileName

        Dim canWrite As Boolean = isFileCanWrite(ini_file)
        While Not canWrite
            canWrite = isFileCanWrite(ini_file)
        End While

        '干掉查新创建...:目前只能支持文件下面放有唯一一个参数的：
        If System.IO.File.Exists(ini_file) Then
            System.IO.File.Delete(ini_file)
        End If
        Dim FW As System.IO.StreamWriter = Nothing
        Dim data As String = ""
        Try
            data = as_key + "=" + as_value
            FW = New System.IO.StreamWriter(ini_file, False)
            FW.WriteLine(data)
            FW.Flush()
        Catch ex As Exception
            sysLog.log("WriteKeyValue : " + ex.Message)
        Finally
            FW.Close()
        End Try
    End Sub

    ''' <summary>
    ''' 返回文件是否可以被独占
    ''' </summary>
    ''' <param name="as_file"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isFileCanWrite(ByVal as_file As String) As Boolean
        Return True
        'Dim fis As System.IO.FileStream = Nothing
        'If Not System.IO.File.Exists(as_file) Then
        '    Return True
        'End If
        'Try
        '    fis = New System.IO.FileStream(as_file, IO.FileMode.Open)
        '    If fis.CanWrite Then
        '        Return True
        '    Else
        '        Return False
        '    End If
        'Catch ex As Exception
        '    Return False
        'Finally
        '    If Not IsNothing(fis) Then
        '        fis.Close()
        '        fis = Nothing
        '    End If
        'End Try
    End Function

End Class

#End Region