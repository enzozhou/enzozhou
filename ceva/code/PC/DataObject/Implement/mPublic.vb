
Imports COMExpress.BusinessObject.Filters

Module mPublic

    Public Function MakeFilters(ByVal ColumnName As String, ByVal value As String) As CXRangeFilter
        Dim filter As New CXRangeFilter
        filter.ColumnName = ColumnName
        filter.ColumnNameIncludeTableName = True
        filter.IsDateType = False
        filter.[Operator] = ConditionOperator.Equal
        filter.Value1 = value
        Return filter
    End Function

    Public Function PadZeroL(ByVal vStr As String, ByVal vLen As Integer) As String
        Dim ZeroLen As Integer
        Dim ZeroStr As String
        Dim i As Integer

        ZeroStr = ""
        ZeroLen = vLen - Len(vStr)
        If ZeroLen < 0 Then
            PadZeroL = Right(vStr, vLen)
            Exit Function
        End If
        For i = 1 To ZeroLen
            ZeroStr = ZeroStr & "0"
        Next i
        PadZeroL = ZeroStr & vStr
    End Function

    Public Function IsNumStringOnly(ByVal strNumString As String) As Boolean

        On Error GoTo Error_Label
        isNumStringOnly = False

        If (Trim(strNumString) = vbNullString) Then
            isNumStringOnly = False
            Exit Function
        End If

        Dim vntTemp As Object
        On Error Resume Next
        vntTemp = vbNullString
        vntTemp = CDec(strNumString)
        On Error GoTo Error_Label

        If (vntTemp Is vbNullString) Then
            isNumStringOnly = False
            Exit Function
        End If

        strNumString = Trim(strNumString)

        'By Ericchu 2003/06/02
        Dim intCharAnsiCode As Integer

        Dim i As Integer
        For i = 1 To Len(strNumString)
            intCharAnsiCode = Asc(Mid$(strNumString, i, 1))

            'Note code 48 is zero, and 57 is nine.
            '          44 is comma sign, 45 is negative sign, 46 is decimal point.
            If Not ((intCharAnsiCode >= 48 And intCharAnsiCode <= 57) _
                    Or (intCharAnsiCode >= 44 And intCharAnsiCode <= 46)) Then
                isNumStringOnly = False
                Exit Function
            End If

        Next

        isNumStringOnly = True
        Exit Function

Error_Label:
        isNumStringOnly = False
        Exit Function



    End Function

    Public Function GetCurrentVersion() As String
        Dim ver As System.Version
        Dim str As String
        ver = GetType(BusinessObject.Lookup).Assembly.GetExecutingAssembly.GetName.Version()
        'str = ver.Major.ToString + "." + ver.Minor.ToString + "." + Format(ver.Build, "00") + "." + Format(ver.Revision, "000")
        str = ver.ToString
        Return str
    End Function


End Module
