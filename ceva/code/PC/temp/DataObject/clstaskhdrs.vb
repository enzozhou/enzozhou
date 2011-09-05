Option Explicit On 
Option Strict On
Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
<Serializable()> _
    Public MustInherit Class clstaskhdrsBase_
        Inherits ImpBusinessCollectionDerived
#Region " Business Properties and Methods "

        Public Overrides ReadOnly Property BusinessType() As Type
	    	Get
	    	    Return GetType(clstaskhdr)
	    	End Get
		End Property
		
        Default Public Overridable ReadOnly Property Item(ByVal Index As Integer) As clstaskhdr
            Get
                Return CType(list.Item(Index), clstaskhdr)
            End Get
        End Property

        Public Overridable ReadOnly Property ItemByPK(ByVal vdc_code As System.String, ByVal vtask_id As System.String) As clstaskhdr
            Get
                Dim r As clstaskhdr

                For Each r In list
                    If Equals(r.dc_code, vdc_code) AND Equals(r.task_id, vtask_id) Then
                         Return r
                    End If
                Next
                Return Nothing
            End Get
        End Property

        Public Overridable Sub Add(ByVal objBO As clstaskhdr)
            AddtoList(objBO)
        End Sub

        Public Overridable Sub Add(ByVal vdc_code As System.String, ByVal vtask_id As System.String)
            AddtoList(clstaskhdr.Fetch(vdc_code, vtask_id))
        End Sub

        Protected Overridable Sub AddtoList(ByVal objBO As clstaskhdr)
            If Not Contains(objBO) Then

                list.Add(objBO)

            Else
                Throw New Exception("clstaskhdr already assigned")
            End If
        End Sub

		Public Overridable Sub Remove(ByVal objBO As clstaskhdr)
			list.Remove(objBO)
		End Sub
		
        Public Overridable Sub Remove(ByVal vdc_code As System.String, ByVal vtask_id As System.String)
            Dim r As clstaskhdr

            For Each r In list
                If Equals(r.dc_code, vdc_code) AND Equals(r.task_id, vtask_id) Then
                    Remove(r)
                    Exit For
                End If
            Next
        End Sub

#End Region

#Region " Contains "

        Public OverLoads Function Contains( _
            ByVal objBO As clstaskhdr) As Boolean

            Dim child As clstaskhdr

            For Each child In list
                If child.Equals(objBO) Then
                    Return True
                End If
            Next

            Return False

        End Function

	    Public OverLoads Function ContainsDeleted( _
	        ByVal objBO As clstaskhdr) As Boolean
	
	        Dim child As clstaskhdr
	
	        For Each child In deletedList
	            If child.Equals(objBO) Then
	                Return True
	            End If
	        Next
	
	        Return False
	
	    End Function

        Public OverLoads Function Contains( _
            ByVal vdc_code As System.String, ByVal vtask_id As System.String) As Boolean

            Dim r As clstaskhdr

            For Each r In list
                If Equals(r.dc_code, vdc_code) AND Equals(r.task_id, vtask_id) Then
                    Return True
                End If
            Next

            Return False

        End Function
		
        Public OverLoads Function ContainsDeleted( _
            ByVal vdc_code As System.String, ByVal vtask_id As System.String) As Boolean

            Dim r As clstaskhdr

            For Each r In deletedList
                If Equals(r.dc_code, vdc_code) AND Equals(r.task_id, vtask_id) Then
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
    	Friend Shared Function Newclstaskhdrs() As clstaskhdrs
            Return New clstaskhdrs
        End Function        
        '-1 ignore max limit
        '0 use default max limit
        '>0 as max limit
    	Public Shared Function Fetch(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clstaskhdrs
    	    Return CType(DataPortal.Fetch(New CriteriaForFilters(GetType(clstaskhdrs), _Filters, nLevel, iMaxNumber)), clstaskhdrs)
    	End Function
    	
    	Public Shared Function Fetch(ByVal strWhereClause As string, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clstaskhdrs
    	    Return CType(DataPortal.Fetch(New CriteriaForWhereClause(GetType(clstaskhdrs), strWhereClause, nLevel, iMaxNumber)), clstaskhdrs)
    	End Function
    	
    	Public Shared Function Fetch(ByVal obj As clstaskhdr, Optional ByVal nLevel As Integer = 0) As clstaskhdrs
    	    If obj.IsNew Then
    	        Dim objCol As clstaskhdrs = New clstaskhdrs
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
    Public Class clstaskhdrs
        Inherits clstaskhdrsBase_
    End Class
#End Region
End Namespace