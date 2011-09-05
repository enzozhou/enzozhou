Imports System.Xml

Public Class ConfigHelper
    Public Class ConfigItem
        Public Name As String
        Public Desciption As String
        Public PCFile As String
        Public RFFile As String
    End Class


    Private mstrPath As String
    Public ReadOnly Property Path() As String
        Get
            Return mstrPath
        End Get
    End Property

    Private mItems As New Collection

    Private Sub LoadConfigItem(ByVal Node As Xml.XmlElement)
        Dim obj As New ConfigItem
        obj.Name = Trim(Node.GetAttribute("name"))
        obj.Desciption = Trim(Node.GetAttribute("description"))
        obj.PCFile = Trim(Node.GetAttribute("pcfile"))
        obj.RFFile = Trim(Node.GetAttribute("rffile"))
        mItems.Add(obj, obj.Name)
    End Sub

    Public Sub LoadConfig(ByVal strFile As String)
        Dim xmldoc As New Xml.XmlDocument
        Dim root As Xml.XmlElement
        Dim Node As Xml.XmlNode
        Dim sectNode As Xml.XmlElement
        Dim keyNode As Xml.XmlElement
        Try
            xmldoc.Load(strFile)
            root = xmldoc.SelectSingleNode("config")
            mstrPath = Trim(root.GetAttribute("path"))
            For Each Node In root
                If Node.NodeType = XmlNodeType.Element And LCase(Node.LocalName) = "item" Then
                    LoadConfigItem(Node)
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    Public ReadOnly Property Configs() As Collection
        Get
            Return mItems
        End Get
    End Property

End Class
