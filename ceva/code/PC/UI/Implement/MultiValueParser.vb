Public Class MultiValueParser

    '以逗号分隔认为是多值

    Public Shared Function Parser(ByVal strValue As String) As Collection
        Dim col As New Collection
        Dim s() As String
        Dim i As Integer
        s = Split(strValue, ",")
        For i = LBound(s) To UBound(s)
            col.Add(s(i))
        Next
        Return col
    End Function



End Class
