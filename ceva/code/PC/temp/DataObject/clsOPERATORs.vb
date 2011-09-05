Option Explicit On 
Option Strict On
Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
<Serializable()> _
    Public MustInherit Class clsOPERATORsBase_
        Inherits ImpBusinessCollectionDerived
#Region " Business Properties and Methods "

        Public Overrides ReadOnly Property BusinessType() As Type
	    	Get
	    	    Return GetType(clsOPERATOR)
	    	End Get
		End Property
		
        Default Public Overridable ReadOnly Property Item(ByVal Index As Integer) As clsOPERATOR
            Get
                Return CType(list.Item(Index), clsOPERATOR)
            End Get
        End Property

        Public Overridable ReadOnly Property ItemByPK(ByVal vuser_code As System.String) As clsOPERATOR
            Get
                Dim r As clsOPERATOR

                For Each r In list
                    If Equals(r.user_code, vuser_code) Then
                         Return r
                    End If
                Next
                Return Nothing
            End Get
        End Property

        Public Overridable Sub Add(ByVal objBO As clsOPERATOR)
            AddtoList(objBO)
        End Sub

        Public Overridable Sub Add(ByVal vuser_code As System.String)
            AddtoList(clsOPERATOR.Fetch(vuser_code))
        End Sub

        Protected Overridable Sub AddtoList(ByVal objBO As clsOPERATOR)
            If Not Contains(objBO) Then

                list.Add(objBO)

            Else
                Throw New Exception("clsOPERATOR already assigned")
            End If
        End Sub

		Public Overridable Sub Remove(ByVal objBO As clsOPERATOR)
			list.Remove(objBO)
		End Sub
		
        Public Overridable Sub Remove(ByVal vuser_code As System.String)
            Dim r As clsOPERATOR

            For Each r In list
                If Equals(r.user_code, vuser_code) Then
                    Remove(r)
                    Exit For
                End If
            Next
        End Sub

#End Region

#Region " Contains "

        Public OverLoads Function Contains( _
            ByVal objBO As clsOPERATOR) As Boolean

            Dim child As clsOPERATOR

            For Each child In list
                If child.Equals(objBO) Then
                    Return True
                End If
            Next

            Return False

        End Function

	    Public OverLoads Function ContainsDeleted( _
	        ByVal objBO As clsOPERATOR) As Boolean
	
	        Dim child As clsOPERATOR
	
	        For Each child In deletedList
	            If child.Equals(objBO) Then
	                Return True
	            End If
	        Next
	
	        Return False
	
	    End Function

        Public OverLoads Function Contains( _
            ByVal vuser_code As System.String) As Boolean

            Dim r As clsOPERATOR

            For Each r In list
                If Equals(r.user_code, vuser_code) Then
                    Return True
                End If
            Next

            Return False

        End Function
		
        Public OverLoads Function ContainsDeleted( _
            ByVal vuser_code As System.String) As Boolean

            Dim r As clsOPERATOR

            For Each r In deletedList
                If Equals(r.user_code, vuser_code) Then
                     Return True
                End If
            Next

            Return False

        End Function

#End Region

#Region " Constructors "

        Protected Sub New()
            ' disallow direct creation
            
            Me.AllowRemove = True
            Me.AllowNew = True
            Me.AllowEdit = True
            Me.AllowFind = True
            Me.AllowSort = True
        End Sub

#End Region

#Region " Shared Methods "
    	Friend Shared Function NewclsOPERATORs() As clsOPERATORs
            Return New clsOPERATORs
        End Function        
        '-1 ignore max limit
        '0 use default max limit
        '>0 as max limit
    	Public Shared Function Fetch(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsOPERATORs
    	    Return CType(DataPortal.Fetch(New CriteriaForFilters(GetType(clsOPERATORs), _Filters, nLevel, iMaxNumber)), clsOPERATORs)
    	End Function
    	
    	Public Shared Function Fetch(ByVal strWhereClause As string, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsOPERATORs
    	    Return CType(DataPortal.Fetch(New CriteriaForWhereClause(GetType(clsOPERATORs), strWhereClause, nLevel, iMaxNumber)), clsOPERATORs)
    	End Function
    	
    	Public Shared Function Fetch(ByVal obj As clsOPERATOR, Optional ByVal nLevel As Integer = 0) As clsOPERATORs
    	    If obj.IsNew Then
    	        Dim objCol As clsOPERATORs = New clsOPERATORs
    	        objCol.Add(obj)
    	    	Return objCol
    	    Else
    	    	Return Fetch(MakeFilters(obj), nLevel)
    	    End If
    	End Function
#End Region

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
    End Class

#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}" 
<Serializable()> _
    Public Class clsOPERATORs
        Inherits clsOPERATORsBase_
    End Class
#End Region
End Namespace