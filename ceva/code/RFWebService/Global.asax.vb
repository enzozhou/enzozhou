Imports System.IO
Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication
    Public Shared LastWriteTimeUtc As String = "" '记录在Setting.ini文件上的文件最新修改时间
    'Public Shared ItemMasterUpdateTime As DateTime = Nothing '记录下载文件的修改时间。如果没有，则设置为空
    Public Shared ReadOnly Current_MaxUserCnt As Integer = 30 '(最大承载三0个用户同时下)
    Public Shared Current_DownLoadUserCnt As Integer = 0 '当前正在下载的用户数
    Public Shared Session_CNT As Integer = 0 '连接用户数:当连接的数据数=0时，就把内存的东西 Txt_memStream 清除掉！
    Public Shared Txt_memStream As New MemoryStream(0)
    Public Shared Txt_memStreamIsBusy As Boolean = False '=true表示正有一个线程在使用 Txt_memStream;=false才可以占用这个
    Public Shared SingleFileDownloadIsBusy As Boolean = False '单个文件正在下载标志
    Public Shared ReadOnly ItemMaster_Code As String = "itemMaster_code.txt" '编码文件
    Public Shared ReadOnly ItemMaster_Name As String = "itemMaster_name.txt" '名称文件
    'Public gsCertificateKEY As String = "96FD10C974A864196E3FD7F2C71BAB"
    Public Shared ReadOnly SNStr As String = "96FD10C974A864196E3FD7F2C71BAB" '准许调用函数的串号
    'Global_asax.M_dbconnect_String
    Public Shared M_dbconnect_String As String '数据库连接字符串
    '96FD10C974A864196E3FD7F2C71BAB
    '' 应用程序启动时激发

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        'Dim fw As System.IO.StreamWriter = New System.IO.StreamWriter("c:\log.txt", True)
        'fw.WriteLine("Application_Start")
        'fw.Flush()
        'fw.Close()

        '载入配置文件中的数据块大小： DataBlockSize
        Try

            Dim sg As sysLog = New sysLog()
            sysLog.logFile = Server.MapPath("log") + "\" + sysLog.logFile
            sysLog.logFile_Err = Server.MapPath("log") + "\" + sysLog.logFile_Err
            ' sysLog.log("RF WebService 启动服务!" + vbCrLf + sysLog.logFile + vbCrLf + sysLog.logFile_Err)
            Dim ff As Encryption64 = New Encryption64()
            Dim ConfigurationFile1 As ConfigurationFile = New ConfigurationFile()
            '------------------------------------------------------------------
            M_dbconnect_String = System.Web.Configuration.WebConfigurationManager.AppSettings("ConnectionString")
            '下面用DES解密方法从配置文件中取得数据库登录用户名和密码
            Dim uid, pwd As String '
            uid = System.Web.Configuration.WebConfigurationManager.AppSettings("Userid")
            pwd = System.Web.Configuration.WebConfigurationManager.AppSettings("Password")
            uid = Encryption64.Decrypt(uid)
            pwd = Encryption64.Decrypt(pwd)
            M_dbconnect_String = M_dbconnect_String & " User ID=" & uid & ";Password=" & pwd
            ' sysLog.log(M_dbconnect_String)
        Catch ex As Exception
            sysLog.log(ex.ToString())
        End Try
    End Sub

    '' 会话启动时激发:登记 Session_CNT 数量.达到最大数量时，干掉.
    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ''Session_CNT = Session_CNT + 1
        ''If Session_CNT > Current_MaxUserCnt Then
        ''    Session_CNT = Session_CNT - 1
        ''    Session.Abandon()
        ''End If
        '-----------------------------------------
        '载入数据库连接配置
        '-----------------------------------------
        Try


        Catch ex As Exception

        End Try
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' 每个请求开始时激发
    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' 尝试验证用户身份时激发

    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' 发生错误时激发

    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        '  会话结束时激发
        Session_CNT = Session_CNT - 1
        If Session_CNT <= 0 Then
            Try
                Txt_memStream.Dispose() '清除占用的服务器内存
            Catch ex As Exception
            End Try
        End If
        'Dim fw As System.IO.StreamWriter = New System.IO.StreamWriter("c:\log.txt", True)
        'fw.WriteLine("Session_End: left cnt is " + Session_CNT.ToString())
        'fw.Flush()
        'fw.Close()
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        '' 应用程序结束时激发
        'Dim fw As System.IO.StreamWriter = New System.IO.StreamWriter("c:\log.txt", True)
        'fw.WriteLine("Application_End!!")
        'fw.Flush()
        'fw.Close()
    End Sub

    ''' <summary>
    ''' 下载文件的操作逻辑类:比对资料文件的版本
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ItemMasterFile
        '返回文件的修改时间，如果没有这个文件则返回Nothing
        Public Shared Function getUpdateTime(ByVal fileName As String) As DateTime
            Try
                Dim fis As System.IO.FileInfo = New System.IO.FileInfo(fileName)
                If Not fis.Exists() Then
                    Return Nothing
                End If
                Return fis.LastWriteTimeUtc()
            Catch ex As Exception
                Return Nothing
            End Try
        End Function

        '判断下载文件是否已经更改了:用于外部的缓存失效的控制
        Protected Function hasChanged(ByVal fileName As String, ByRef sErr As String) As Boolean
            sErr = ""
            Try
                'myCF = New ConfigurationFile()
                'Dim LastWriteTimeUtc_saved As String = myCF.readConfig("LastWriteTimeUtc")
                Dim rg As SettingOP = New SettingOP()
                Dim LastWriteTimeUtc_saved As String = rg.ReadKeyValue("LastWriteTimeUtc")

                Dim fis As System.IO.FileInfo = New System.IO.FileInfo(fileName)
                If Not fis.Exists() Then
                    Return True
                End If
                'If ItemMasterUpdateTime <> fis.LastWriteTimeUtc() Then
                If LastWriteTimeUtc_saved.ToString() <> fis.LastWriteTimeUtc().ToString() Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                sErr = ex.Message
                Return Nothing
            Finally

            End Try
        End Function

    End Class

    '等待和占用  Txt_memStream 对象。超时了，则返回错误信息：否则返回空串
    'Global_asax.WaitForeMemStream
    Public Shared Function WaitForeMemStream(ByRef sErr As String) As String
        Dim dt1 As DateTime = Now()
        Dim dt2 As DateTime
        Dim ts As TimeSpan = Nothing

        If Txt_memStreamIsBusy Then '如果忙...
            While Txt_memStreamIsBusy
                dt2 = Now()
                ts = dt2.Subtract(dt1)
                If ts.TotalSeconds > 3 Then '5秒超时
                    sErr = "Time out!"
                    Return sErr
                End If
            End While
            Txt_memStreamIsBusy = True '占用...
        Else
            Txt_memStreamIsBusy = True '占用...
        End If
        Return sErr
    End Function

    '等待和占用  SingleFileDownloadIsBusy 对象，表明单个文件正在下载准备中..(读入到byte()的操作中)
    Public Shared Function WaitForeSingleFile(ByRef sErr As String) As String
        Dim dt1 As DateTime = Now()
        Dim dt2 As DateTime
        Dim ts As TimeSpan = Nothing

        If SingleFileDownloadIsBusy Then '如果忙...
            While SingleFileDownloadIsBusy
                dt2 = Now()
                ts = dt2.Subtract(dt1)
                If ts.TotalSeconds > 3 Then '3秒超时
                    sErr = "single file Time out!"
                    Return sErr
                End If
            End While
            SingleFileDownloadIsBusy = True '占用...
        Else
            SingleFileDownloadIsBusy = True '占用...
        End If
        Return sErr
    End Function


#Region "SQL 执行函数"



#End Region


End Class