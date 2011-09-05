Option Explicit On 
Option Strict On
Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
<Serializable()> _
    Public MustInherit Class clsbarcodesBase_
        Inherits ImpBusinessCollectionDerived
#Region " Business Properties and Methods "

        Public Overrides ReadOnly Property BusinessType() As Type
	    	Get
	    	    Return GetType(clsbarcode)
	    	End Get
		End Property
		
        Default Public Overridable ReadOnly Property Item(ByVal Index As Integer) As clsbarcode
            Get
                Return CType(list.Item(Index), clsbarcode)
            End Get
        End Property

        Public Overridable ReadOnly Property ItemByPK(ByVal vsku_no As System.String, ByVal vbarcode As System.String) As clsbarcode
            Get
                Dim r As clsbarcode

                For Each r In list
                    If Equals(r.sku_no, vsku_no) AND Equals(r.barcode, vbarcode) Then
                         Return r
                    End If
                Next
                Return Nothing
            End Get
        End Property

        Public Overridable Sub Add(ByVal objBO As clsbarcode)
            AddtoList(objBO)
        End Sub

        Public Overridable Sub Add(ByVal vsku_no As System.String, ByVal vbarcode As System.String)
            AddtoList(clsbarcode.Fetch(vsku_no, vbarcode))
        End Sub

        Protected Overridable Sub AddtoList(ByVal objBO As clsbarcode)
            If Not Contains(objBO) Then

                list.Add(objBO)

            Else
                Throw New Exception("clsbarcode already assigned")
            End If
        End Sub

		Public Overridable Sub Remove(ByVal objBO As clsbarcode)
			list.Remove(objBO)
		End Sub
		
        Public Overridable Sub Remove(ByVal vsku_no As System.String, ByVal vbarcode As System.String)
            Dim r As clsbarcode

            For Each r In list
                If Equals(r.sku_no, vsku_no) AND Equals(r.barcode, vbarcode) Then
                    Remove(r)
                    Exit For
                End If
            Next
        End Sub

#End Region

#Region " Contains "

        Public OverLoads Function Contains( _
            ByVal objBO As clsbarcode) As Boolean

            Dim child As clsbarcode

            For Each child In list
                If child.Equals(objBO) Then
                    Return True
                End If
            Next

            Return False

        End Function

	    Public OverLoads Function ContainsDeleted( _
	        ByVal objBO As clsbarcode) As Boolean
	
	        Dim child As clsbarcode
	
	        For Each child In deletedList
	            If child.Equals(objBO) Then
	                Return True
	            End If
	        Next
	
	        Return False
	
	    End Function

        Public OverLoads Function Contains( _
            ByVal vsku_no As System.String, ByVal vbarcode As System.String) As Boolean

            Dim r As clsbarcode

            For Each r In list
                If Equals(r.sku_no, vsku_no) AND Equals(r.barcode, vbarcode) Then
                    Return True
                End If
            Next

            Return False

        End Function
		
        Public OverLoads Function ContainsDeleted( _
            ByVal vsku_no As System.String, ByVal vbarcode As System.String) As Boolean

            Dim r As clsbarcode

            For Each r In deletedList
                If Equals(r.sku_no, vsku_no) AND Equals(r.barcode, vbarcode) Then
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
    	Friend Shared Function Newclsbarcodes() As clsbarcodes
            Return New clsbarcodes
        End Function        
        '-1 ignore max limit
        '0 use default max limit
        '>0 as max limit
    	Public Shared Function Fetch(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsbarcodes
    	    Return CType(DataPortal.Fetch(New CriteriaForFilters(GetType(clsbarcodes), _Filters, nLevel, iMaxNumber)), clsbarcodes)
    	End Function
    	
    	Public Shared Function Fetch(ByVal strWhereClause As string, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsbarcodes
    	    Return CType(DataPortal.Fetch(New CriteriaForWhereClause(GetType(clsbarcodes), strWhereClause, nLevel, iMaxNumber)), clsbarcodes)
    	End Function
    	
    	Public Shared Function Fetch(ByVal obj As clsbarcode, Optional ByVal nLevel As Integer = 0) As clsbarcodes
    	    If obj.IsNew Then
    	        Dim objCol As clsbarcodes = New clsbarcodes
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
    Public Class clsbarcodes
        Inherits clsbarcodesBase_
    End Class
#End Region
End Namespace