Option Explicit On 
Option Strict On
Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
<Serializable()> _
    Public MustInherit Class clsusersesBase_
        Inherits ImpBusinessCollectionDerived
#Region " Business Properties and Methods "

        Public Overrides ReadOnly Property BusinessType() As Type
	    	Get
	    	    Return GetType(clsusers)
	    	End Get
		End Property
		
        Default Public Overridable ReadOnly Property Item(ByVal Index As Integer) As clsusers
            Get
                Return CType(list.Item(Index), clsusers)
            End Get
        End Property

        Public Overridable ReadOnly Property ItemByPK(ByVal vuid As System.String) As clsusers
            Get
                Dim r As clsusers

                For Each r In list
                    If Equals(r.uid, vuid) Then
                         Return r
                    End If
                Next
                Return Nothing
            End Get
        End Property

        Public Overridable Sub Add(ByVal objBO As clsusers)
            AddtoList(objBO)
        End Sub

        Public Overridable Sub Add(ByVal vuid As System.String)
            AddtoList(clsusers.Fetch(vuid))
        End Sub

        Protected Overridable Sub AddtoList(ByVal objBO As clsusers)
            If Not Contains(objBO) Then

                list.Add(objBO)

            Else
                Throw New Exception("clsusers already assigned")
            End If
        End Sub

		Public Overridable Sub Remove(ByVal objBO As clsusers)
			list.Remove(objBO)
		End Sub
		
        Public Overridable Sub Remove(ByVal vuid As System.String)
            Dim r As clsusers

            For Each r In list
                If Equals(r.uid, vuid) Then
                    Remove(r)
                    Exit For
                End If
            Next
        End Sub

#End Region

#Region " Contains "

        Public OverLoads Function Contains( _
            ByVal objBO As clsusers) As Boolean

            Dim child As clsusers

            For Each child In list
                If child.Equals(objBO) Then
                    Return True
                End If
            Next

            Return False

        End Function

	    Public OverLoads Function ContainsDeleted( _
	        ByVal objBO As clsusers) As Boolean
	
	        Dim child As clsusers
	
	        For Each child In deletedList
	            If child.Equals(objBO) Then
	                Return True
	            End If
	        Next
	
	        Return False
	
	    End Function

        Public OverLoads Function Contains( _
            ByVal vuid As System.String) As Boolean

            Dim r As clsusers

            For Each r In list
                If Equals(r.uid, vuid) Then
                    Return True
                End If
            Next

            Return False

        End Function
		
        Public OverLoads Function ContainsDeleted( _
            ByVal vuid As System.String) As Boolean

            Dim r As clsusers

            For Each r In deletedList
                If Equals(r.uid, vuid) Then
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
    	Friend Shared Function Newclsuserses() As clsuserses
            Return New clsuserses
        End Function        
        '-1 ignore max limit
        '0 use default max limit
        '>0 as max limit
    	Public Shared Function Fetch(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsuserses
    	    Return CType(DataPortal.Fetch(New CriteriaForFilters(GetType(clsuserses), _Filters, nLevel, iMaxNumber)), clsuserses)
    	End Function
    	
    	Public Shared Function Fetch(ByVal strWhereClause As string, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsuserses
    	    Return CType(DataPortal.Fetch(New CriteriaForWhereClause(GetType(clsuserses), strWhereClause, nLevel, iMaxNumber)), clsuserses)
    	End Function
    	
    	Public Shared Function Fetch(ByVal obj As clsusers, Optional ByVal nLevel As Integer = 0) As clsuserses
    	    If obj.IsNew Then
    	        Dim objCol As clsuserses = New clsuserses
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
    Public Class clsuserses
        Inherits clsusersesBase_
    End Class
#End Region
End Namespace