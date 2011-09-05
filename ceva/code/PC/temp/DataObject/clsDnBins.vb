Option Explicit On 
Option Strict On
Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
<Serializable()> _
    Public MustInherit Class clsDnBinsBase_
        Inherits ImpBusinessCollectionDerived
#Region " Business Properties and Methods "

        Public Overrides ReadOnly Property BusinessType() As Type
	    	Get
	    	    Return GetType(clsDnBin)
	    	End Get
		End Property
		
        Default Public Overridable ReadOnly Property Item(ByVal Index As Integer) As clsDnBin
            Get
                Return CType(list.Item(Index), clsDnBin)
            End Get
        End Property

        Public Overridable ReadOnly Property ItemByPK(ByVal vdc_code As System.String, ByVal vbch_no As System.String, ByVal vdn_no As System.String, ByVal vbin_area As System.String, ByVal vbin_code As System.String) As clsDnBin
            Get
                Dim r As clsDnBin

                For Each r In list
                    If Equals(r.dc_code, vdc_code) AND Equals(r.bch_no, vbch_no) AND Equals(r.dn_no, vdn_no) AND Equals(r.bin_area, vbin_area) AND Equals(r.bin_code, vbin_code) Then
                         Return r
                    End If
                Next
                Return Nothing
            End Get
        End Property

        Public Overridable Sub Add(ByVal objBO As clsDnBin)
            AddtoList(objBO)
        End Sub

        Public Overridable Sub Add(ByVal vdc_code As System.String, ByVal vbch_no As System.String, ByVal vdn_no As System.String, ByVal vbin_area As System.String, ByVal vbin_code As System.String)
            AddtoList(clsDnBin.Fetch(vdc_code, vbch_no, vdn_no, vbin_area, vbin_code))
        End Sub

        Protected Overridable Sub AddtoList(ByVal objBO As clsDnBin)
            If Not Contains(objBO) Then

                list.Add(objBO)

            Else
                Throw New Exception("clsDnBin already assigned")
            End If
        End Sub

		Public Overridable Sub Remove(ByVal objBO As clsDnBin)
			list.Remove(objBO)
		End Sub
		
        Public Overridable Sub Remove(ByVal vdc_code As System.String, ByVal vbch_no As System.String, ByVal vdn_no As System.String, ByVal vbin_area As System.String, ByVal vbin_code As System.String)
            Dim r As clsDnBin

            For Each r In list
                If Equals(r.dc_code, vdc_code) AND Equals(r.bch_no, vbch_no) AND Equals(r.dn_no, vdn_no) AND Equals(r.bin_area, vbin_area) AND Equals(r.bin_code, vbin_code) Then
                    Remove(r)
                    Exit For
                End If
            Next
        End Sub

#End Region

#Region " Contains "

        Public OverLoads Function Contains( _
            ByVal objBO As clsDnBin) As Boolean

            Dim child As clsDnBin

            For Each child In list
                If child.Equals(objBO) Then
                    Return True
                End If
            Next

            Return False

        End Function

	    Public OverLoads Function ContainsDeleted( _
	        ByVal objBO As clsDnBin) As Boolean
	
	        Dim child As clsDnBin
	
	        For Each child In deletedList
	            If child.Equals(objBO) Then
	                Return True
	            End If
	        Next
	
	        Return False
	
	    End Function

        Public OverLoads Function Contains( _
            ByVal vdc_code As System.String, ByVal vbch_no As System.String, ByVal vdn_no As System.String, ByVal vbin_area As System.String, ByVal vbin_code As System.String) As Boolean

            Dim r As clsDnBin

            For Each r In list
                If Equals(r.dc_code, vdc_code) AND Equals(r.bch_no, vbch_no) AND Equals(r.dn_no, vdn_no) AND Equals(r.bin_area, vbin_area) AND Equals(r.bin_code, vbin_code) Then
                    Return True
                End If
            Next

            Return False

        End Function
		
        Public OverLoads Function ContainsDeleted( _
            ByVal vdc_code As System.String, ByVal vbch_no As System.String, ByVal vdn_no As System.String, ByVal vbin_area As System.String, ByVal vbin_code As System.String) As Boolean

            Dim r As clsDnBin

            For Each r In deletedList
                If Equals(r.dc_code, vdc_code) AND Equals(r.bch_no, vbch_no) AND Equals(r.dn_no, vdn_no) AND Equals(r.bin_area, vbin_area) AND Equals(r.bin_code, vbin_code) Then
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
    	Friend Shared Function NewclsDnBins() As clsDnBins
            Return New clsDnBins
        End Function        
        '-1 ignore max limit
        '0 use default max limit
        '>0 as max limit
    	Public Shared Function Fetch(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsDnBins
    	    Return CType(DataPortal.Fetch(New CriteriaForFilters(GetType(clsDnBins), _Filters, nLevel, iMaxNumber)), clsDnBins)
    	End Function
    	
    	Public Shared Function Fetch(ByVal strWhereClause As string, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsDnBins
    	    Return CType(DataPortal.Fetch(New CriteriaForWhereClause(GetType(clsDnBins), strWhereClause, nLevel, iMaxNumber)), clsDnBins)
    	End Function
    	
    	Public Shared Function Fetch(ByVal obj As clsDnBin, Optional ByVal nLevel As Integer = 0) As clsDnBins
    	    If obj.IsNew Then
    	        Dim objCol As clsDnBins = New clsDnBins
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
    Public Class clsDnBins
        Inherits clsDnBinsBase_
    End Class
#End Region
End Namespace