Imports System.Data
Imports System.IO
Imports System.Xml

Public Class ConfigurationFile
    Private myConfigDs As New DataSet
    Private myConfigDt As New DataTable
    Public Sub New()
        '读入配置文件信息 这个配置文件的名字设置为 :程序名称+".Config"
        Try
            'Dim curDir As String
            'curDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
            'Dim strFileName As String = curDir + "\config.xml"
            Dim strFileName As String = "\Application\CEVA_Picking.config"
            myConfigDs.ReadXml(strFileName)
            'myConfigDt = myConfigDs.Tables(1)
            myConfigDt = myConfigDs.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "启动参数错误！")
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
        Dim XmlDoc As New Xml.XmlDocument
        'Dim curDir As String
        'curDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        'Dim strFileName As String = curDir + "\config.xml"
        Dim strFileName As String = "\Application\CEVA_Picking.config"
        XmlDoc.Load(strFileName) '(Application.ExecutablePath & ".config")
        Dim XN As Xml.XmlNode = XmlDoc.SelectSingleNode("/configuration/appSettings")
        For i As Integer = 0 To myConfigDt.Rows.Count - 1
            If Convert.ToBoolean(XN.ChildNodes.Item(i).Attributes.ItemOf(0).Value() = as_key) Then
                XN.ChildNodes.Item(i).Attributes.ItemOf(1).Value() = as_value
                find = True
                Exit For
            End If
        Next
        If find Then
            XmlDoc.Save(strFileName)
        End If
    End Sub


    Public Function GetXMLConfig(ByVal varNodeName As String, ByVal varAttributesName As String) As String
        Dim rtn As String = ""
        Try
            Dim strExeDir As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase
            '获得可执行文件的全路径
            Dim strDir As String = Path.GetDirectoryName(strExeDir)
            Dim _XmlDocument As New XmlDocument()
            '_XmlDocument.Load(strDir & "\xml\Config.xml")
            _XmlDocument.Load("\Application\CEVA_Picking.config")
            Dim _XmlNode As XmlNode = _XmlDocument.SelectSingleNode(varNodeName)
            For Each _XmlNodeTmp As XmlNode In _XmlNode.ChildNodes
                If _XmlNodeTmp.Attributes("name").Value = varAttributesName Then
                    rtn = _XmlNodeTmp.InnerText
                    Exit For
                End If
            Next
        Catch ex As Exception
            rtn = ex.Message
        End Try
        Return rtn
    End Function

    Public Function SetXMLConfig(ByVal varNodeName As String, ByVal varAttributesName As String, ByVal vrSetValue As String) As Boolean
        Dim bl As Boolean = False
        Try
            Dim strExeDir As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase
            '获得可执行文件的全路径
            Dim strDir As String = Path.GetDirectoryName(strExeDir)
            Dim _XmlDocument As New XmlDocument()
            '_XmlDocument.Load(strDir & "\xml\Config.xml")
            _XmlDocument.Load("\Application\CEVA_Picking.config")
            Dim _XmlNode As XmlNode = _XmlDocument.SelectSingleNode(varNodeName)
            For Each _XmlNodeTmp As XmlNode In _XmlNode.ChildNodes
                Dim xe As XmlElement = DirectCast(_XmlNodeTmp, XmlElement)
                If xe.GetAttribute("name") = varAttributesName Then
                    xe.InnerText = vrSetValue
                    bl = True
                    Exit For
                End If
            Next
            '_XmlDocument.Save(strDir & "\xml\Config.xml")
            _XmlDocument.Save("\Application\CEVA_Picking.config")
        Catch ex As Exception
        End Try
        Return bl
    End Function

    Public Shared Function IsIP(ByVal ip As String) As Boolean
        '判断是否为IP
        Return System.Text.RegularExpressions.Regex.IsMatch(ip, "^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$")
    End Function

    'Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Dim sIp As String = txtIP.Text
    '    Dim sErrorMessage As String = ""
    '    If CommonFun.AnchanCommon.IsIP(sIp) Then
    '        Dim bl As Boolean = New CommonFun.AnchanCommon().SetXMLConfig("ConnectionInfo", "IP", sIp)
    '        If bl Then
    '            sErrorMessage = "修改成功"
    '        Else
    '            sErrorMessage = "修改失败"
    '        End If
    '    Else
    '        sErrorMessage = "无效的IP地址"
    '    End If
    '    lbltxt.Text = sErrorMessage
    '    'lbltxt.Text = new CommonFun.AnchanCommon().GetXMLConfig("ConnectionInfo", "IP");
    'End Sub



End Class
