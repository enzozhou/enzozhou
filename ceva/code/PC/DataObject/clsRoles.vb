Option Explicit On 
Option Strict On
Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
<Serializable()> _
    Public MustInherit Class clsRolesBase_
        Inherits ImpBusinessCollectionDerived
#Region " Business Properties and Methods "

        Public Overrides ReadOnly Property BusinessType() As Type
	    	Get
	    	    Return GetType(clsRole)
	    	End Get
		End Property
		
        Default Public Overridable ReadOnly Property Item(ByVal Index As Integer) As clsRole
            Get
                Return CType(list.Item(Index), clsRole)
            End Get
        End Property

        Public Overridable ReadOnly Property ItemByPK(ByVal vrole_code As System.String) As clsRole
            Get
                Dim r As clsRole

                For Each r In list
                    If Equals(r.role_code, vrole_code) Then
                         Return r
                    End If
                Next
                Return Nothing
            End Get
        End Property

        Public Overridable Sub Add(ByVal objBO As clsRole)
            AddtoList(objBO)
        End Sub

        Public Overridable Sub Add(ByVal vrole_code As System.String)
            AddtoList(clsRole.Fetch(vrole_code))
        End Sub

        Protected Overridable Sub AddtoList(ByVal objBO As clsRole)
            If Not Contains(objBO) Then

                list.Add(objBO)

            Else
                Throw New Exception("clsRole already assigned")
            End If
        End Sub

		Public Overridable Sub Remove(ByVal objBO As clsRole)
			list.Remove(objBO)
		End Sub
		
        Public Overridable Sub Remove(ByVal vrole_code As System.String)
            Dim r As clsRole

            For Each r In list
                If Equals(r.role_code, vrole_code) Then
                    Remove(r)
                    Exit For
                End If
            Next
        End Sub

#End Region

#Region " Contains "

        Public OverLoads Function Contains( _
            ByVal objBO As clsRole) As Boolean

            Dim child As clsRole

            For Each child In list
                If child.Equals(objBO) Then
                    Return True
                End If
            Next

            Return False

        End Function

	    Public OverLoads Function ContainsDeleted( _
	        ByVal objBO As clsRole) As Boolean
	
	        Dim child As clsRole
	
	        For Each child In deletedList
	            If child.Equals(objBO) Then
	                Return True
	            End If
	        Next
	
	        Return False
	
	    End Function

        Public OverLoads Function Contains( _
            ByVal vrole_code As System.String) As Boolean

            Dim r As clsRole

            For Each r In list
                If Equals(r.role_code, vrole_code) Then
                    Return True
                End If
            Next

            Return False

        End Function
		
        Public OverLoads Function ContainsDeleted( _
            ByVal vrole_code As System.String) As Boolean

            Dim r As clsRole

            For Each r In deletedList
                If Equals(r.role_code, vrole_code) Then
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
    	Friend Shared Function NewclsRoles() As clsRoles
            Return New clsRoles
        End Function        
        '-1 ignore max limit
        '0 use default max limit
        '>0 as max limit
    	Public Shared Function Fetch(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsRoles
    	    Return CType(DataPortal.Fetch(New CriteriaForFilters(GetType(clsRoles), _Filters, nLevel, iMaxNumber)), clsRoles)
    	End Function
    	
    	Public Shared Function Fetch(ByVal strWhereClause As string, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsRoles
    	    Return CType(DataPortal.Fetch(New CriteriaForWhereClause(GetType(clsRoles), strWhereClause, nLevel, iMaxNumber)), clsRoles)
    	End Function
    	
    	Public Shared Function Fetch(ByVal obj As clsRole, Optional ByVal nLevel As Integer = 0) As clsRoles
    	    If obj.IsNew Then
    	        Dim objCol As clsRoles = New clsRoles
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
    Public Class clsRoles
        Inherits clsRolesBase_
    End Class
#End Region
End Namespace