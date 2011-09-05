Option Explicit On 
Option Strict On
Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA
Imports System.Reflection
Imports System.Collections
Imports System.ComponentModel


Namespace BusinessObject
    <Serializable()> Public MustInherit Class ImpBusinessCollectionDerived
        Inherits BusinessCollectionBaseDerived

        Protected Overrides Sub DataPortal_Update()
            MarkDeletedListDirty()
            MyBase.DataPortal_Update()
        End Sub

        Private Sub MarkDeletedListDirty()
            For Each delObj As Object In Me.deletedList
                DirectCast(delObj, ImpBusinessBaseDerived).MakeDeletedList()
            Next
        End Sub

        '不检查ColName是否存在
        Public Shared Function GetSingleFilter(ByVal ColName As String, ByVal value As String, ByVal TypeName As String, Optional ByVal vOperator As Filters.ConditionOperator = ConditionOperator.Equal) As Filters.CXFilterBase
            Dim A As [Assembly] = GetType(ImpBusinessBaseDerived).Module.Assembly
            Dim myType As Type = A.GetType("YT.BusinessObject." & TypeName)
            'Dim myAttriList() As Object = myType.GetCustomAttributes(True)
            Dim myAttri As CXDBTableWithSPAttribute '= CType(myAttriList(0), CXDBTableWithSPAttribute)
            Dim objFilter As Filters.CXFilterBase
            Try
                myAttri = CType(CustomAttribute.CXDBTableWithSPAttribute.GetDBTableInfo(myType), CXDBTableWithSPAttribute)
                If vOperator = ConditionOperator.OrginalWhereClause Or vOperator = ConditionOperator.IncludeIn Or vOperator = ConditionOperator.NotIncludeIn Then
                    Dim sqlFilter As New Filters.CXSQLFilter(vOperator, ColName, value)
                    sqlFilter = New Filters.CXSQLFilter(vOperator, ColName, value)
                    sqlFilter.ColumnNameIncludeTableName = True
                    sqlFilter.ColumnName = myAttri.TableName & ".[" & ColName & "]"
                    objFilter = sqlFilter
                Else
                    Dim storeFilter As New Filters.CXRangeFilter
                    storeFilter.ColumnName = myAttri.TableName & ".[" & ColName & "]"
                    storeFilter.ColumnNameIncludeTableName = True
                    storeFilter.IsDateType = False
                    storeFilter.[Operator] = vOperator
                    storeFilter.Value1 = value
                    objFilter = storeFilter
                End If
            Catch ex As Exception
            End Try
            Return objFilter
        End Function

        '检查了ColName是否存在
        Public Shared Function GetSingleFilterEx(ByVal ColName As String, ByVal value As String, ByVal TypeName As String, Optional ByVal vOperator As Filters.ConditionOperator = ConditionOperator.Equal) As Filters.CXFilterBase
            Dim A As [Assembly] = GetType(ImpBusinessBaseDerived).Module.Assembly
            Dim myType As Type = A.GetType("YT.BusinessObject." & TypeName)
            'Dim myAttriList() As Object = myType.GetCustomAttributes(True)
            Dim myAttri As CXDBTableWithSPAttribute '= CType(myAttriList(0), CXDBTableWithSPAttribute)
            Dim objFilter As Filters.CXFilterBase = Nothing
            Dim classPropertys As PropertyDescriptorCollection
            Dim clsProperty As PropertyDescriptor
            'Dim i As Integer
            'Dim myAttri2 As CXDBTableWithSPAttribute
            Try
                myAttri = CType(CustomAttribute.CXDBTableWithSPAttribute.GetDBTableInfo(myType), CXDBTableWithSPAttribute)
                'For i = 0 To myAttriList.Length - 1
                '    If myAttriList(i).GetType Is GetType(CXDBTableWithSPAttribute) Then
                '        myAttri = CType(myAttriList(i), CXDBTableWithSPAttribute)
                '        Exit For
                '    End If
                'Next
                'comexpress.BusinessObject.
                classPropertys = TypeDescriptor.GetProperties(myType)
                clsProperty = classPropertys.Find(ColName, True)
                If clsProperty Is Nothing Then
                    Return Nothing
                End If
                If vOperator = ConditionOperator.OrginalWhereClause Or vOperator = ConditionOperator.IncludeIn Or vOperator = ConditionOperator.NotIncludeIn Then
                    Dim sqlFilter As New Filters.CXSQLFilter(vOperator, ColName, value)
                    sqlFilter = New Filters.CXSQLFilter(vOperator, ColName, value)
                    sqlFilter.ColumnNameIncludeTableName = True
                    sqlFilter.ColumnName = myAttri.TableName & ".[" & ColName & "]"
                    objFilter = sqlFilter
                Else
                    Dim storeFilter As New Filters.CXRangeFilter
                    storeFilter.ColumnName = myAttri.TableName & ".[" & ColName & "]"
                    storeFilter.ColumnNameIncludeTableName = True
                    storeFilter.IsDateType = False
                    storeFilter.[Operator] = vOperator
                    storeFilter.Value1 = value
                    objFilter = storeFilter
                End If
            Catch ex As Exception
            End Try
            Return objFilter
        End Function

        Public Shared Function GetSingleRangeFilter(ByVal ColName As String, ByVal value1 As Object, ByVal value2 As Object, ByVal TypeName As String, Optional ByVal vOperator As Filters.ConditionOperator = ConditionOperator.Equal) As Filters.CXFilterBase
            Dim A As [Assembly] = GetType(ImpBusinessBaseDerived).Module.Assembly
            Dim myType As Type = A.GetType("YT.BusinessObject." & TypeName)
            'Dim myAttriList() As Object = myType.GetCustomAttributes(True)
            Dim myAttri As CXDBTableWithSPAttribute '= CType(myAttriList(0), CXDBTableWithSPAttribute)
            Dim objFilter As Filters.CXFilterBase
            'Dim i As Integer
            Try
                myAttri = CType(CustomAttribute.CXDBTableWithSPAttribute.GetDBTableInfo(myType), CXDBTableWithSPAttribute)
                'For i = 0 To myAttriList.Length - 1
                '    If myAttriList(i).GetType Is GetType(CXDBTableWithSPAttribute) Then
                '        myAttri = CType(myAttriList(i), CXDBTableWithSPAttribute)
                '        Exit For
                '    End If
                'Next
                If vOperator <> ConditionOperator.Between And vOperator <> ConditionOperator.NotBetween Then
                    Throw New Exception("UnSupport")
                Else
                    Dim storeFilter As New Filters.CXRangeFilter
                    storeFilter.ColumnName = myAttri.TableName & ".[" & ColName & "]"
                    storeFilter.ColumnNameIncludeTableName = True
                    storeFilter.IsDateType = False
                    storeFilter.[Operator] = vOperator
                    storeFilter.Value1 = value1
                    storeFilter.Value2 = value2
                    objFilter = storeFilter
                End If
            Catch ex As Exception
            End Try
            Return objFilter
        End Function



        Public Shared Function GetFilter(ByVal ColName As String, ByVal value As String, ByVal TypeName As String, Optional ByVal vOperator As Filters.ConditionOperator = ConditionOperator.Equal, Optional ByVal _Filters As CXFilters = Nothing) As CXFilters
            Dim A As [Assembly] = GetType(ImpBusinessBaseDerived).Module.Assembly
            Dim myType As Type = A.GetType("YT.BusinessObject." & TypeName)
            'Dim myAttriList() As Object = myType.GetCustomAttributes(True)
            Dim myAttri As CXDBTableWithSPAttribute '= CType(myAttriList(0), CXDBTableWithSPAttribute)
            'Dim i As Integer
            Dim interFilter As New CXFilters
            Try
                myAttri = CType(CustomAttribute.CXDBTableWithSPAttribute.GetDBTableInfo(myType), CXDBTableWithSPAttribute)
                'For i = 0 To myAttriList.Length - 1
                '    If myAttriList(i).GetType Is GetType(CXDBTableWithSPAttribute) Then
                '        myAttri = CType(myAttriList(i), CXDBTableWithSPAttribute)
                '        Exit For
                '    End If
                'Next
                If Not _Filters Is Nothing Then
                    interFilter = DirectCast(_Filters.Clone, CXFilters)
                End If
                If UserRightMgr.LoginSuccess Then
                    'Dim storeFilter As New Filters.CXRangeFilter
                    'storeFilter.ColumnName = myAttri.TableName & ".[" & ColName & "]"
                    'storeFilter.ColumnNameIncludeTableName = True
                    'storeFilter.IsDateType = False
                    'storeFilter.Operator = operator
                    'storeFilter.Value1 = value
                    Dim fl As CXFilterBase
                    fl = GetSingleFilter(ColName, value, TypeName, vOperator)
                    If (Not interFilter.IsCollection) Then
                        interFilter.Add(fl)
                    Else
                        Dim b As New CXFilters
                        b.Add(fl)
                        interFilter.Add(b)
                    End If
                End If
            Catch e As Exception
                Throw e
            End Try
            Return interFilter
        End Function

        Public Shared Function GetFilterByProperty(ByVal PropertyName As String, ByVal value As String, ByVal TypeName As String, Optional ByVal _Filters As CXFilters = Nothing) As CXFilters
            Dim A As [Assembly] = GetType(ImpBusinessBaseDerived).Module.Assembly
            Dim myType As Type = A.GetType("YT.BusinessObject." & TypeName)
            'Dim myAttriList() As Object = myType.GetCustomAttributes(True)
            Dim myAttri As CXDBTableWithSPAttribute '= CType(myAttriList(0), CXDBTableWithSPAttribute)
            Dim myProperty As PropertyInfo = myType.GetProperty(PropertyName)
            Dim FieldAttris() As Object = myProperty.GetCustomAttributes(False)
            Dim myFiledAttri As CXDBFieldAttribute
            'Dim i As Integer
            myAttri = CType(CustomAttribute.CXDBTableWithSPAttribute.GetDBTableInfo(myType), CXDBTableWithSPAttribute)
            'For i = 0 To myAttriList.Length - 1
            '    If myAttriList(i).GetType Is GetType(CXDBTableWithSPAttribute) Then
            '        myAttri = CType(myAttriList(i), CXDBTableWithSPAttribute)
            '        Exit For
            '    End If
            'Next
            For Each fieldAttri As Object In FieldAttris
                If fieldAttri.GetType.Name = "CXDBField" Then
                    myFiledAttri = CType(fieldAttri, CXDBFieldAttribute)
                    Exit For
                End If
            Next

            If myFiledAttri Is Nothing Then Return Nothing

            Dim interFilter As New CXFilters
            If Not _Filters Is Nothing Then
                interFilter = DirectCast(_Filters.Clone, CXFilters)
            End If
            If UserRightMgr.LoginSuccess Then
                Dim storeFilter As New Filters.CXRangeFilter
                storeFilter.ColumnName = myAttri.TableName & ".[" & myFiledAttri.DBFieldName & "]"
                storeFilter.ColumnNameIncludeTableName = True
                storeFilter.IsDateType = False
                storeFilter.[Operator] = Filters.ConditionOperator.Equal
                storeFilter.Value1 = value
                If (Not interFilter.IsCollection) Then
                    interFilter.Add(storeFilter)
                Else
                    Dim b As New CXFilters
                    b.Add(storeFilter)
                    interFilter.Add(b)
                End If
            End If
            Return interFilter
        End Function

        'Public Function GetLinkFieldFilter(ByVal objParent As ImpBusinessBaseDerived) As Filters.CXFilters
        '    Dim typeName As String = Me.GetType.Name
        '    typeName = typeName.Substring(0, typeName.Length - 1)
        '    Dim A As [Assembly] = GetType(ImpBusinessBaseDerived).Module.Assembly
        '    Dim myType As Type = A.GetType("YT.BusinessObject." & typeName)
        '    Return ImpBusinessBaseDerived.GetLinkFieldFilter(myType, objParent)
        'End Function

    End Class

End Namespace