Namespace Windows.Forms.SearchEx1

    Public Class clsObjectManager


        Private mHostObjectType As Type
        Private mHostFilters As COMExpress.BusinessObject.Filters.CXFilters
        Private mRelateObjects As New Collection

        Public Property HostObjectType() As Type
            Get
                Return mHostObjectType
            End Get
            Set(ByVal Value As Type)
                mHostObjectType = Value
            End Set
        End Property

        Public Property HostFilters() As COMExpress.BusinessObject.Filters.CXFilters
            Get
                Return mHostFilters
            End Get
            Set(ByVal Value As COMExpress.BusinessObject.Filters.CXFilters)
                mHostFilters = Value
            End Set
        End Property

        Public Sub Add(ByVal ObjectType As Type, Optional ByVal Filters As COMExpress.BusinessObject.Filters.CXFilters = Nothing)
            Dim obj As clsRelatedObject
            'If mRelateObjects.Contain(ObjectName) Then
            '    obj = DirectCast(mRelateObjects.Item(ObjectName), struRelatedObject)
            '    If Not Filters Is Nothing Then
            '        obj.Filters = Filters
            '    End If
            'Else
            Dim pos As Integer
            pos = GetIndexByKey(ObjectType.Name)
            If pos <= 0 Then
                obj = New clsRelatedObject
                obj.ObjectType = ObjectType
                obj.Filters = Filters
                mRelateObjects.Add(obj, ObjectType.Name)
            End If

        End Sub

        Public Sub Remove(ByVal ObjectName As String)
            Dim pos As Integer
            pos = GetIndexByKey(ObjectName)
            If pos > 0 Then
                mRelateObjects.Remove(pos)
            End If
        End Sub

        Public Function Count() As Integer
            Return mRelateObjects.Count
        End Function


        Public ReadOnly Property Item(ByVal index As Integer) As clsRelatedObject
            Get
                Return DirectCast(mRelateObjects.Item(index), clsRelatedObject)
            End Get
        End Property

        Public ReadOnly Property Item(ByVal ObjectName As String) As clsRelatedObject
            Get
                Dim pos As Integer
                pos = GetIndexByKey(ObjectName)
                If pos > 0 Then
                    Return DirectCast(mRelateObjects.Item(pos), clsRelatedObject)
                Else
                    Return Nothing
                End If
            End Get
        End Property

        Private Function GetIndexByKey(ByVal strkey As String) As Integer
            Dim i As Integer
            For i = 1 To mRelateObjects.Count
                If DirectCast(mRelateObjects.Item(i), clsRelatedObject).ObjectType.Name = strkey Then
                    Return i
                End If
            Next
            Return -1
        End Function

        Private mretFilters As COMExpress.BusinessObject.Filters.CXFilters

        Public Property RetFilters() As COMExpress.BusinessObject.Filters.CXFilters
            Get
                Return mretFilters
            End Get
            Set(ByVal Value As COMExpress.BusinessObject.Filters.CXFilters)
                mretFilters = Value
            End Set
        End Property

        Private mReturnCount As Integer
        Public Property ReturnCount() As Integer
            Get
                Return mReturnCount
            End Get
            Set(ByVal Value As Integer)
                mReturnCount = Value
            End Set
        End Property


    End Class

    Public Class clsRelatedObject
        Public ObjectType As Type
        'Link property is CXLinkProperty , here not define.
        Public Filters As COMExpress.BusinessObject.Filters.CXFilters
        Public FiltersIsAvailable As Boolean = False
        Public Tag As Object
    End Class

End Namespace

