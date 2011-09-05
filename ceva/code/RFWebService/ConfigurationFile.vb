Imports System.Web
Imports System.Xml
Public Class ConfigurationFile
    Private myConfigDs As New DataSet
    Private myConfigDt As New DataTable
    Public Sub New()
        '读入配置文件信息 这个配置文件的名字设置为 :程序名称+".Config"
        Try
            myConfigDs.ReadXml(AppDomain.CurrentDomain.BaseDirectory & "web.config")
            sysLog.log(AppDomain.CurrentDomain.BaseDirectory & "web.config")
            myConfigDt = myConfigDs.Tables(1)
        Catch ex As Exception
            sysLog.log(ex.ToString())
        End Try
    End Sub
    ''' <summary>
    ''' 从配置文件中读取 Key = as_key 的属性值：统统按照字符串格式返回
    ''' </summary>
    ''' <param name="as_key"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function readConfig(ByVal as_key As String) As String
        Dim data As String
        Dim value As String
        For index As Integer = 0 To myConfigDt.Rows.Count - 1
            data = myConfigDt.Rows(index)(0).ToString()
            If Convert.ToBoolean(data = as_key) Then
                value = myConfigDt.Rows(index)(1).ToString()
                Return value
            End If
        Next
        Return Nothing
    End Function
    ''' <summary>
    ''' 向配置文件写指定key的value
    ''' </summary>
    ''' <param name="as_key"></param>
    ''' <param name="as_value"></param>
    ''' <remarks></remarks>
    Public Sub writeConfig(ByVal as_key As String, ByVal as_value As String)
        Dim find As Boolean = False
        Dim XmlDoc As New System.Xml.XmlDocument
        XmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory & "web.config")
        Dim XN As System.Xml.XmlNode = XmlDoc.SelectSingleNode("/configuration/appSettings")
        For i As Integer = 0 To myConfigDt.Rows.Count - 1
            If Convert.ToBoolean(XN.ChildNodes.Item(i).Attributes.ItemOf(0).Value() = as_key) Then
                XN.ChildNodes.Item(i).Attributes.ItemOf(1).Value() = as_value
                find = True
                Exit For
            End If
        Next
        If find Then
            XmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory & "web.config")
            'AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)
        End If
    End Sub
End Class
