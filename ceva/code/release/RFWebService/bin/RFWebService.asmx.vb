Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System
Imports System.IO
Imports System.Collections
Imports System.Text
Imports System.Web
Imports System.Xml.Serialization
Imports Microsoft.Web.Services3
Imports Microsoft.Web.Services3.Messaging
Imports Microsoft.Web.Services3.Addressing

<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class Service1
    Inherits System.Web.Services.WebService

    <WebMethod(Description:="返回服务器时间,测试web service是否通讯成功")> _
Public Function get_svr_datetime() As String
        Dim str As String = Now().ToString
        Return str
    End Function

    <WebMethod(Description:="测试方法:返回当前txt文件版本时间和内存数据流的版本时间.")> _
Public Function getTxt_ModifyTime() As String
        Try
            Dim rlt As String = ""
            Dim svrFilePath As String = Server.MapPath("downloadFiles") + "\" + Global_asax.ItemMaster_Code
            'sysLog.log("1:" + svrFilePath)
            Dim str As DateTime = Global_asax.ItemMasterFile.getUpdateTime(svrFilePath)
            'sysLog.log("2:" + str)
            Dim rg As SettingOP = New SettingOP()
            Dim LastWriteTimeUtc_saved As String = rg.ReadKeyValue("LastWriteTimeUtc")
            'sysLog.log("3:" + LastWriteTimeUtc_saved)
            Dim str2 As String = LastWriteTimeUtc_saved
            'sysLog.log("4:" + str2)
            rlt = "磁盘文件修改时间：" + str + "  || 内存流时间：" + str2
            Return rlt
        Catch ex As Exception
            sysLog.log("getTxt_ModifyTime():" + ex.Message)
            Return ex.Message
        End Try
    End Function

    <WebMethod(EnableSession:=True, Description:="下载名称 itemMaster_name.txt 文件：大小不超过2M")> _
   Public Function DownLoadSingleFile(ByVal as_sn As String, ByVal as_FileName As String, ByRef as_serr As String) As Byte()
        If Global_asax.SNStr <> as_sn Then
            Return Nothing
        End If
        Try
            Dim svrSingleFile As String = Server.MapPath("downloadFiles") + "\" + as_FileName ' Global_asax.ItemMaster_Name
            If Not System.IO.File.Exists(svrSingleFile) Then
                as_serr = "指定文件：" + as_FileName + "在服务器不存在！"
                Return Nothing
            End If
            Dim fis As System.IO.FileInfo = New System.IO.FileInfo(svrSingleFile)
            '载入单个文件到一个byte()数组
            Dim fs As System.IO.FileStream = New System.IO.FileStream(svrSingleFile, IO.FileMode.Open, IO.FileAccess.Read)
            Dim ab_byte(fs.Length) As Byte
            fs.Read(ab_byte, 0, fs.Length)
            fs.Close()
            fs.Dispose()
            as_serr = ""
            Return ab_byte
        Catch ex As Exception
            as_serr = ex.Message
            Return Nothing
        Finally
            Global_asax.Current_DownLoadUserCnt = Global_asax.Current_DownLoadUserCnt - 1
            Global_asax.SingleFileDownloadIsBusy = False '释放资源占用
        End Try
    End Function

    <WebMethod(EnableSession:=True, Description:="分批下载 itemMaster_code.txt 文件")> _
      Public Function DownLoadFileLot(ByVal as_sn As String, ByVal as_fileName As String, ByVal al_off As Long, ByVal al_len As Long, ByRef as_sErr As String) As Byte()
        '方法概述：每次发指定大小的数据下去，设备连续写入一个指定的Txt文件。
        'Dim fw As System.IO.StreamWriter = New System.IO.StreamWriter("c:\log.txt", True)
        If Global_asax.SNStr <> as_sn Then
            Return Nothing
        End If
        Try
            as_sErr = ""
            If as_sErr <> "" Then
                Return Nothing
            End If
            '结束为止：
            If al_off + al_len > Global_asax.Txt_memStream.Capacity Then
                al_len = CDec(Global_asax.Txt_memStream.Capacity) - al_off + 1
            End If
            If al_len < 1 Then
                as_sErr = "数据尚未缓存到服务器上，请重试！" + al_len.ToString + " || " + Global_asax.Txt_memStream.Capacity.ToString() + "  " + al_off.ToString()
                sysLog.log("DownLoadFileLot : " + as_sErr)
                Return Nothing
            End If
            '排队...
            Global_asax.WaitForeMemStream(as_sErr)
            Dim ab_byte(al_len) As Byte
            Global_asax.Txt_memStream.Seek(al_off, SeekOrigin.Begin) '指针移动到指定的位置
            Global_asax.Txt_memStream.Read(ab_byte, 0, al_len) '取出范围内数据
            Return ab_byte
        Catch ex As Exception
            as_sErr = ex.Message
            sysLog.log("DownLoadFileLot : " + ex.Message)
            Return Nothing
        Finally
            Global_asax.Txt_memStreamIsBusy = False '无论上面什么状态，都要：释放资源
        End Try
    End Function

    <WebMethod(EnableSession:=True, Description:="上传单个文件：传递指定的文件名称和文件字节数组()")> _
Public Function UpLoadSingleFile(ByVal as_sn As String, ByVal as_FileName As String, ByVal FileData() As Byte, ByRef as_serr As String) As String
        If Global_asax.SNStr <> as_sn Then
            Return "Connection SN Wrong!"
        End If
        Try
            Dim svrSingleFile As String = Server.MapPath("uploadFiles") + "\" + as_FileName ' Global_asax.ItemMaster_Name
            If System.IO.File.Exists(svrSingleFile) Then
                as_serr = "指定文件：" + as_FileName + "在服务器已经存在了！"
                System.IO.File.Delete(svrSingleFile)
                'Return as_serr
                as_serr = ""
            End If
            Dim fs As System.IO.FileStream = New System.IO.FileStream(svrSingleFile, IO.FileMode.OpenOrCreate, IO.FileAccess.Write)
            fs.Write(FileData, 0, FileData.Length)
            fs.Flush()
            fs.Close()
            as_serr = ""
            Return ""
        Catch ex As Exception
            as_serr = ex.Message
            Return as_serr
        Finally
        End Try
    End Function

#Region "SQL 执行"
    ''' <summary>
    ''' 执行指定SQL,返回数据集
    ''' </summary>
    ''' <param name="as_sql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="执行指定SQL,返回数据集")> _
    Public Function ExecuteSQL_DS(ByVal as_sn As String, ByVal as_sql As String, ByRef as_sErr As String) As DataSet
        If Global_asax.SNStr <> as_sn Then
            as_sErr = "非法调用!"
            Return Nothing
        End If
        Dim ds As DataSet = New DataSet()
        Dim cn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim sda As SqlClient.SqlDataAdapter = Nothing
        Try
            cn = New SqlClient.SqlConnection(Global_asax.M_dbconnect_String)
            cmd = New SqlClient.SqlCommand(as_sql, cn)
            sda = New SqlClient.SqlDataAdapter()
            sda.SelectCommand = cmd
            cn.Open()
            sda.Fill(ds)
            as_sErr = ""
            Return ds
        Catch ex As SqlClient.SqlException
            as_sErr = ex.Message
            Return ds
        Finally
            cn.Close()
            cn = Nothing
            sda = Nothing
        End Try
    End Function

    ''' <summary>
    ''' 执行指定SQL,影响的数据行数
    ''' </summary>
    ''' <param name="as_sql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="执行指定SQL,影响的数据行数")> _
    Public Function ExecuteSQL_CNT(ByVal as_sn As String, ByVal as_sql As String, ByRef as_sErr As String) As String
        as_sErr = ""
        If Global_asax.SNStr <> as_sn Then 'ByVal as_sn As String,
            as_sErr = "非法调用!"
            Return "0"
        End If
        Dim cn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Try
            cn = New SqlClient.SqlConnection(Global_asax.M_dbconnect_String)
            cmd = New SqlClient.SqlCommand(as_sql, cn)
            cn.Open()
            Dim cnt As Integer = cmd.ExecuteNonQuery()
            Return cnt.ToString()
        Catch ex As SqlClient.SqlException
            as_sErr = ex.Message
            Return "0"
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Function

    ''' <summary>
    ''' 执行指定SQL,返回单个结果
    ''' </summary>
    ''' <param name="as_sql"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="执行指定SQL,返回单个结果")> _
    Public Function ExecuteScalar(ByVal as_sn As String, ByVal as_sql As String, ByRef as_sErr As String) As String
        as_sErr = ""
        If Global_asax.SNStr <> as_sn Then 'ByVal as_sn As String,ByRef as_sErr As String
            as_sErr = "非法调用!"
            Return as_sErr
        End If
        Dim ds As DataSet = New DataSet()
        Dim cn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Try
            cn = New SqlClient.SqlConnection(Global_asax.M_dbconnect_String)
            cmd = New SqlClient.SqlCommand(as_sql, cn)
            cn.Open()
            Dim cnt As Object = cmd.ExecuteScalar()
            If IsNothing(cnt) Then
                as_sErr = "IsNothing cmd.ExecuteScalar()"
                Return ""
            End If
            If IsDBNull(cnt) Then
                as_sErr = "IsDBNull cmd.ExecuteScalar()"
                Return ""
            End If
            Return cnt.ToString()
        Catch ex As SqlClient.SqlException
            as_sErr = ex.Message
            Return ""
        Finally
            cn.Close()
            cn = Nothing
        End Try
    End Function

    ''' <summary>
    ''' 执行存储过程，返回字符串
    ''' </summary>
    ''' <param name="as_proName"></param>
    ''' <param name="as_Params"></param>
    ''' <returns>无错则返回空字符串值,有错则返回错误信息</returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="执行指定的存储过程,返回单个output参数序列值")> _
      Public Function RunProcedure_Str(ByVal as_sn As String, ByVal as_proName As String, ByVal as_Params As String, ByRef sErr As String) As String
        '----------------------------------------------------------------------------------------
        'Dim sErr As String = ""
        'SQLDBhelper.RunProcedure_Str("sp_computeSR4Weight", "@newcartonbarcode|varchar|00694201819880095399|input;@weightReal|int|1220|input;@uid|varchar|zxs|input;@sErr|varchar||output", sErr)
        'msg(sErr)
        '----------------------------------------------------------------------------------------
        If as_sn <> Global_asax.SNStr Then
            sErr = "非法调用!"
            Return ""
        End If
        Dim myConn As SqlClient.SqlConnection = Nothing
        Dim myCommand As New SqlClient.SqlCommand(as_proName, myConn)
        Dim outputPM As Integer = 0
        Try
            myConn = New SqlClient.SqlConnection(Global_asax.M_dbconnect_String)
            myConn.Open()
            With myCommand
                .Connection = myConn
                .CommandType = CommandType.StoredProcedure
                Dim params() As String = as_Params.Split(";")
                For ii As Integer = 0 To params.Length - 1
                    Dim ps() As String = params(ii).Split("|")
                    '@SStore|nvarchar|[数据]|inpput/output -- 这是参数和值的序列,类型限制好
                    Dim pName, pType, pValue, pIO As String
                    pName = ps(0)
                    pType = ps(1)
                    pValue = ps(2)
                    pIO = ps(3)
                    Select Case pType.ToLower()
                        Case "nvarchar"
                            .Parameters.Add(pName, SqlDbType.VarChar).Value = pValue
                            If pIO.ToLower = "input" Then
                                .Parameters(pName).Direction = ParameterDirection.Input
                            ElseIf pIO.ToLower = "output" Then
                                .Parameters(pName).Direction = ParameterDirection.Output
                                outputPM = outputPM + 1
                            End If
                            Exit Select
                        Case "varchar"
                            .Parameters.Add(pName, SqlDbType.VarChar).Value = pValue
                            If pIO.ToLower = "input" Then
                                .Parameters(pName).Direction = ParameterDirection.Input
                            ElseIf pIO.ToLower = "output" Then
                                .Parameters(pName).Direction = ParameterDirection.Output
                                outputPM = outputPM + 1
                            End If
                            Exit Select
                        Case "int"
                            .Parameters.Add(pName, SqlDbType.Int).Value = pValue
                            If pType.ToLower = "input" Then
                                .Parameters(pName).Direction = ParameterDirection.Input
                            ElseIf pType.ToLower = "output" Then
                                .Parameters(pName).Direction = ParameterDirection.Output
                            End If
                            Exit Select
                    End Select
                Next
                If outputPM > 0 Then '只能有一个输出参数，只能放到最后一个，只能是长度255
                    .Parameters(.Parameters.Count - 1).Size = 255
                End If
                .ExecuteNonQuery()
                Dim rtnMSG As String = ""
                If outputPM > 0 Then
                    rtnMSG = .Parameters(.Parameters.Count - 1).Value.ToString() '最后一个可能是输出参数
                End If
                Return rtnMSG '返回值
            End With
        Catch ex As Exception
            sErr = ex.Message '返回异常信息
            Return ""
        Finally
            myConn.Close()
        End Try
    End Function

    ''' <summary>
    ''' 执行指定存储过程,返回数据集
    ''' </summary>
    ''' <param name="as_proName"></param>
    ''' <param name="as_Params"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <WebMethod(Description:="执行指定存储过程,返回数据集")> _
    Public Function RunProcedure_DS(ByVal as_sn As String, ByVal as_proName As String, ByVal as_Params As String, ByRef as_sErr As String) As DataSet
        as_sErr = ""
        If Global_asax.SNStr <> as_sn Then
            as_sErr = "非法调用!"
            Return Nothing
        End If
        Dim ds As DataSet = New DataSet()
        Dim cn As SqlClient.SqlConnection = Nothing
        Dim cmd As SqlClient.SqlCommand = Nothing
        Dim sda As SqlClient.SqlDataAdapter = Nothing
        Dim outputPM As Integer = 0

        Try
            cn = New SqlClient.SqlConnection(Global_asax.M_dbconnect_String)
            cmd = New SqlClient.SqlCommand(as_proName, cn)
            cmd.CommandType = CommandType.StoredProcedure
            With cmd
                .Connection = cn
                .CommandType = CommandType.StoredProcedure
                Dim params() As String = as_Params.Split(";")
                For ii As Integer = 0 To params.Length - 1
                    Dim ps() As String = params(ii).Split("|")
                    '@SStore|nvarchar|[数据]|inpput/output -- 这是参数和值的序列,类型限制好
                    Dim pName, pType, pValue, pIO As String
                    pName = ps(0)
                    pType = ps(1)
                    pValue = ps(2)
                    pIO = ps(3)
                    Select Case pType.ToLower()
                        Case "varchar"
                            .Parameters.Add(pName, SqlDbType.VarChar).Value = pValue
                            If pIO.ToLower = "input" Then
                                .Parameters(pName).Direction = ParameterDirection.Input
                            ElseIf pIO.ToLower = "output" Then
                                .Parameters(pName).Direction = ParameterDirection.Output
                                .Parameters(pName).Size = 255
                                outputPM = outputPM + 1
                            End If
                            Exit Select
                        Case "nvarchar"
                            .Parameters.Add(pName, SqlDbType.VarChar).Value = pValue
                            If pIO.ToLower = "input" Then
                                .Parameters(pName).Direction = ParameterDirection.Input
                            ElseIf pIO.ToLower = "output" Then
                                .Parameters(pName).Direction = ParameterDirection.Output
                                .Parameters(pName).Size = 255
                                outputPM = outputPM + 1
                            End If
                            Exit Select
                        Case "int"
                            .Parameters.Add(pName, SqlDbType.Int).Value = pValue
                            If pType.ToLower = "input" Then
                                .Parameters(pName).Direction = ParameterDirection.Input
                            ElseIf pType.ToLower = "output" Then
                                .Parameters(pName).Direction = ParameterDirection.Output
                                outputPM = outputPM + 1
                            End If
                            Exit Select
                    End Select
                Next
                If outputPM > 0 Then '只能有一个输出参数，只能放到最后一个，只能是长度255
                    .Parameters(.Parameters.Count - 1).Size = 255
                End If
            End With
            sda = New SqlClient.SqlDataAdapter()
            sda.SelectCommand = cmd
            cn.Open()
            sda.Fill(ds)
            If outputPM > 0 Then
                as_sErr = cmd.Parameters(cmd.Parameters.Count - 1).Value.ToString() '最后一个可能是输出参数
            End If
            Return ds
        Catch ex As SqlClient.SqlException
            as_sErr = ex.Message
            Return ds
        Finally
            cn.Close()
            cn = Nothing
            sda = Nothing
        End Try
    End Function
#End Region





End Class
