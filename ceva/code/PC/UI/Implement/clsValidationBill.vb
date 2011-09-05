Imports YT
Imports YT.BusinessObject
Imports COMExpress.BusinessObject
Public Class clsValidationBill
#Region " user defined property "
    Dim look As New YT.BusinessObject.Lookup
#End Region
    Public Function CanAssignTask(ByVal dc_code As String, ByVal bch_no As String) As Boolean
        Dim obj As DataSet
        Dim sWhere As String = " and dc_code = '" + dc_code + "' and bch_no = " + " '" + bch_no + "' and status_code < 2"
        obj = look.GetAvariableBanchByWhere(sWhere)
        If (obj.Tables(0).Rows.Count > 0) Then
            Return True
        End If
        Return False
    End Function
    Public Function CanCloseBanch(ByVal dc_code As String, ByVal bch_no As String) As Boolean
        Dim obj As DataSet
        Dim sWhere As String = " and dc_code = '" + dc_code + "' and bch_no = '" + bch_no + "'" + " and status_code <> 4"
        obj = look.GetBanchByWhereForClose(sWhere)
        If (obj.Tables(0).Rows.Count > 0) Then
            Return True
        End If
        Return False
    End Function
End Class
