Option Explicit On 
Option Strict On
Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
<Serializable()> _
    Public MustInherit Class clsUserpermissionsBase_
        Inherits ImpBusinessCollectionDerived
#Region " Business Properties and Methods "

        Public Overrides ReadOnly Property BusinessType() As Type
	    	Get
	    	    Return GetType(clsUserpermission)
	    	End Get
		End Property
		
        Default Public Overridable ReadOnly Property Item(ByVal Index As Integer) As clsUserpermission
            Get
                Return CType(list.Item(Index), clsUserpermission)
            End Get
        End Property

        Public Overridable ReadOnly Property ItemByPK(ByVal vuser_code As System.String, ByVal vright_no As System.String) As clsUserpermission
            Get
                Dim r As clsUserpermission

                For Each r In list
                    If Equals(r.user_code, vuser_code) AND Equals(r.right_no, vright_no) Then
                         Return r
                    End If
                Next
                Return Nothing
            End Get
        End Property

        Public Overridable Sub Add(ByVal objBO As clsUserpermission)
            AddtoList(objBO)
        End Sub

        Public Overridable Sub Add(ByVal vuser_code As System.String, ByVal vright_no As System.String)
            AddtoList(clsUserpermission.Fetch(vuser_code, vright_no))
        End Sub

        Protected Overridable Sub AddtoList(ByVal objBO As clsUserpermission)
            If Not Contains(objBO) Then

                list.Add(objBO)

            Else
                Throw New Exception("clsUserpermission already assigned")
            End If
        End Sub

		Public Overridable Sub Remove(ByVal objBO As clsUserpermission)
			list.Remove(objBO)
		End Sub
		
        Public Overridable Sub Remove(ByVal vuser_code As System.String, ByVal vright_no As System.String)
            Dim r As clsUserpermission

            For Each r In list
                If Equals(r.user_code, vuser_code) AND Equals(r.right_no, vright_no) Then
                    Remove(r)
                    Exit For
                End If
            Next
        End Sub

#End Region

#Region " Contains "

        Public OverLoads Function Contains( _
            ByVal objBO As clsUserpermission) As Boolean

            Dim child As clsUserpermission

            For Each child In list
                If child.Equals(objBO) Then
                    Return True
                End If
            Next

            Return False

        End Function

	    Public OverLoads Function ContainsDeleted( _
	        ByVal objBO As clsUserpermission) As Boolean
	
	        Dim child As clsUserpermission
	
	        For Each child In deletedList
	            If child.Equals(objBO) Then
	                Return True
	            End If
	        Next
	
	        Return False
	
	    End Function

        Public OverLoads Function Contains( _
            ByVal vuser_code As System.String, ByVal vright_no As System.String) As Boolean

            Dim r As clsUserpermission

            For Each r In list
                If Equals(r.user_code, vuser_code) AND Equals(r.right_no, vright_no) Then
                    Return True
                End If
            Next

            Return False

        End Function
		
        Public OverLoads Function ContainsDeleted( _
            ByVal vuser_code As System.String, ByVal vright_no As System.String) As Boolean

            Dim r As clsUserpermission

            For Each r In deletedList
                If Equals(r.user_code, vuser_code) AND Equals(r.right_no, vright_no) Then
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
    	Friend Shared Function NewclsUserpermissions() As clsUserpermissions
            Return New clsUserpermissions
        End Function        
        '-1 ignore max limit
        '0 use default max limit
        '>0 as max limit
    	Public Shared Function Fetch(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsUserpermissions
    	    Return CType(DataPortal.Fetch(New CriteriaForFilters(GetType(clsUserpermissions), _Filters, nLevel, iMaxNumber)), clsUserpermissions)
    	End Function
    	
    	Public Shared Function Fetch(ByVal strWhereClause As string, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsUserpermissions
    	    Return CType(DataPortal.Fetch(New CriteriaForWhereClause(GetType(clsUserpermissions), strWhereClause, nLevel, iMaxNumber)), clsUserpermissions)
    	End Function
    	
    	Public Shared Function Fetch(ByVal obj As clsUserpermission, Optional ByVal nLevel As Integer = 0) As clsUserpermissions
    	    If obj.IsNew Then
    	        Dim objCol As clsUserpermissions = New clsUserpermissions
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
    Public Class clsUserpermissions
        Inherits clsUserpermissionsBase_
    End Class
#End Region
End Namespace