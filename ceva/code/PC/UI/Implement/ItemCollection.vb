Public Structure ItemSingle
    Public Key As String
    Public Caption As String
    Public Tag As String

    Public Sub New(ByVal vKey As String, ByVal vCaption As String, ByVal vTag As String)
        Key = vKey
        Caption = vCaption
        Tag = vTag
    End Sub
End Structure


Public Class ItemCollection
    Inherits System.Collections.CollectionBase

    Private mintMaxCount As Integer = 10

    Public Sub New(ByVal iMaxCount As Integer)
        mintMaxCount = iMaxCount
    End Sub


    Public Function Contains(ByVal vKey As String) As Boolean
        Dim i As Integer
        For i = 0 To list.Count - 1
            If CType(list.Item(i), ItemSingle).Key = vKey Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function Contains(ByVal vItem As ItemSingle) As Boolean
        Return Contains(vItem.Key)
    End Function

    Public Sub Add(ByVal vItem As ItemSingle)
        ' Invokes Add method of the List object to add a widget
        If Contains(vItem) = False Then
            List.Add(vItem)
        End If
    End Sub

    Public Sub Add(ByVal vKey As String, ByVal vVal As String, Optional ByVal vTag As String = "")
        If Contains(vKey) = False Then
            list.Add(New ItemSingle(vKey, vVal, vTag))
        End If
    End Sub

    Public Sub Remove(ByVal index As Integer)
        If index > Count - 1 Or index < 0 Then
            ' nothong
        Else
            List.RemoveAt(index)
        End If
    End Sub


    Default Public ReadOnly Property Item(ByVal index As Integer) As ItemSingle
        Get
            Return CType(List.Item(index), ItemSingle)
        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal vKey As String) As ItemSingle
        Get
            Dim i As Integer
            Dim im As ItemSingle
            For i = 0 To list.Count - 1
                im = CType(List.Item(i), ItemSingle)
                If im.Key = vKey Then
                    Return im
                End If
            Next
            Return Nothing
        End Get
    End Property


End Class
