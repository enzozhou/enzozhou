Public Class XMLSetting
    Public Function GetProfileString(ByVal AppTitle As String, ByVal Section As String, ByVal key As String, Optional ByVal keyvalue As String = "") As String
        Dim root As Xml.XmlElement
        Dim appNode As Xml.XmlElement
        Dim sectNode As Xml.XmlElement
        Dim keyNode As Xml.XmlElement
        root = xmldoc.SelectSingleNode("Root")
        If root Is Nothing Then
            Return keyvalue
        End If
        appNode = root.SelectSingleNode(AppTitle)
        If appNode Is Nothing Then
            Return keyvalue
        End If

        sectNode = appNode.SelectSingleNode(Section)
        If sectNode Is Nothing Then
            Return keyvalue
        End If

        keyNode = sectNode.SelectSingleNode(key)
        If keyNode Is Nothing Then
            Return keyvalue
        End If
        Return Trim(keyNode.InnerText)
    End Function

    Public Sub WriteProfileString(ByVal AppTitle As String, ByVal Section As String, ByVal key As String, ByVal keyvalue As String)
        Try

            Dim root As Xml.XmlElement
            Dim appNode As Xml.XmlElement
            Dim sectNode As Xml.XmlElement
            Dim keyNode As Xml.XmlElement
            root = xmldoc.SelectSingleNode("Root")
            If root Is Nothing Then
                root = xmldoc.CreateElement("Root")
                SetVersion(root)
                xmldoc.AppendChild(root)
            End If
            appNode = root.SelectSingleNode(AppTitle)
            If appNode Is Nothing Then
                appNode = xmldoc.CreateElement(AppTitle)
                root.AppendChild(appNode)
            End If

            sectNode = appNode.SelectSingleNode(Section)
            If sectNode Is Nothing Then
                sectNode = xmldoc.CreateElement(Section)
                appNode.AppendChild(sectNode)
            End If

            keyNode = sectNode.SelectSingleNode(key)
            If keyNode Is Nothing Then
                keyNode = xmldoc.CreateElement(key)
                sectNode.AppendChild(keyNode)
            End If
            'keyNode.InnerXml = keyvalue
            keyNode.InnerText = keyvalue            '��InnerXml, ��keyvalue�����ر�ķ���, �ᱨ�쳣
            If Trim(mstrFile) <> "" Then
                Save()
            End If
        Catch ex As Exception
            LogMsg(ex, Me.GetType, "WriteProfileString")
        End Try

    End Sub


    Private xmldoc As Xml.XmlDocument
    Private mstrFile As String

    Public Sub New(ByVal strFile As String)
        Open(strFile)
    End Sub

    Public Sub Open(ByVal strFile As String)
        xmldoc = New Xml.XmlDocument
        mstrFile = strFile
        Try
            xmldoc.Load(strFile)
        Catch ex As Exception
            CreateXMLDocument()
        End Try
    End Sub

    Private Sub CreateXMLDocument()
        Dim dec As Xml.XmlDeclaration
        dec = xmldoc.CreateXmlDeclaration("1.0", "utf-8", Nothing)
        '//����Xml�Ķ�������
        xmldoc.AppendChild(dec)
        '//�������ڵ�
        Dim root As Xml.XmlElement
        root = xmldoc.CreateElement("Root")
        SetVersion(root)
        xmldoc.AppendChild(root)
        xmldoc.Save(mstrFile)

    End Sub

    Private Sub SetVersion(ByVal xmlElm As Xml.XmlElement)
        xmlElm.SetAttribute("version", "1.0.0")
    End Sub

    Public Sub Save()
        On Error Resume Next
        xmldoc.Save(mstrFile)
    End Sub

End Class
