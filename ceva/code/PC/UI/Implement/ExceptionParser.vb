Public Class ExceptionParser
    Public Shared Function ParseExcetionMessageForLog(ByVal ex As Exception, Optional ByVal nLine As Integer = 50) As String
        Dim e As Exception
        Dim strApp As String
        Dim bInID As Boolean
        Dim bSQLExp As Boolean
        Dim str As String
        Dim vRet As String = ""
        'Dim strInnerTraceStack As String = ""
        e = ex
        bSQLExp = False
        While (Not e Is Nothing)
            'If Not e Is ex Then
            '    strInnerTraceStack = e.GetType.Name + ":" + e.StackTrace
            'End If
            If TypeOf (e) Is COMExpress.BusinessObject.CXAppException And TypeOf (e.InnerException) Is SqlClient.SqlException Then
                strApp = ExceptionParser.GetLimitedString(e.Message, nLine)
                If Not e Is ex Then
                    strApp = strApp + vbCrLf + "<<" + e.GetType.Name + ">>:" + e.StackTrace
                End If
                str = ""
                bInID = False
            Else
                str = ParseMessage(e.Message, e.GetType, bInID)
                str = ExceptionParser.GetLimitedString(str, nLine)
                If Not e Is ex Then
                    If Right(str, Len(vbCrLf)) = vbCrLf Then
                        str = Left(str, Len(str) - Len(vbCrLf))
                    End If
                    str = str + vbCrLf + "<<" + e.GetType.Name + ">>:" + e.StackTrace
                End If
            End If
            If TypeOf (e) Is SqlClient.SqlException Then
                bSQLExp = True
            Else
                bSQLExp = False
            End If

            If bInID = True Then
                If bSQLExp Then
                    vRet = str
                Else
                    vRet = str + vbCrLf + vRet
                End If
                str = ""
            ElseIf TypeOf (e) Is SqlClient.SqlException Then
                str = ParseSQLExceptionMessage(DirectCast(e, SqlClient.SqlException))
                If Trim(str) <> "" Then
                    str = ExceptionParser.GetLimitedString(str, nLine)
                    If Not e Is ex Then
                        If Right(str, Len(vbCrLf)) = vbCrLf Then
                            str = Left(str, Len(str) - Len(vbCrLf))
                        End If
                        str = str + vbCrLf + "<<" + e.GetType.Name + ">>:" + e.StackTrace
                    End If
                    vRet = str + vbCrLf + vRet
                End If
                str = ""
            End If
            If e Is ex Then
                str = ""
            End If
            e = e.InnerException
        End While
        If Trim(vRet) = "" Then
            vRet = Trim(strApp)
        End If
        If Trim(vRet) = "" Then
            vRet = ex.Message
        End If
        vRet = vRet + vbCrLf + "<<" + ex.GetType.Name + ">>:" + ex.StackTrace
        If Right(vRet, Len(vbCrLf)) = vbCrLf Then
            vRet = Left(vRet, Len(vRet) - Len(vbCrLf))
        End If
        If Trim(str) <> "" Then
            vRet = vRet + vbCrLf + str
        End If
        If Right(vRet, Len(vbCrLf)) = vbCrLf Then
            vRet = Left(vRet, Len(vRet) - Len(vbCrLf))
        End If
        Return vRet
    End Function

    Public Shared Function ParseExcetionMessage(ByVal ex As Exception, Optional ByVal nLine As Integer = 30) As String
        Dim e As Exception
        Dim strApp As String
        Dim bInID As Boolean
        Dim bSQLExp As Boolean
        Dim str As String
        Dim vRet As String = ""
        Dim strLast As String = ""
        e = ex
        bSQLExp = False
        While (Not e Is Nothing)
            If strLast <> e.Message Then
                If TypeOf (e) Is COMExpress.BusinessObject.CXAppException And TypeOf (e.InnerException) Is SqlClient.SqlException Then
                    strApp = e.Message
                    strApp = ExceptionParser.GetLimitedString(strApp, nLine)
                    str = ""
                    bInID = False
                Else
                    str = ParseMessage(e.Message, e.GetType, bInID)
                    str = ExceptionParser.GetLimitedString(str, nLine)
                End If
                If TypeOf (e) Is SqlClient.SqlException Then
                    bSQLExp = True
                Else
                    bSQLExp = False
                End If

                If bInID = True Then
                    If bSQLExp Then
                        vRet = str
                    Else
                        vRet = str + vbCrLf + vRet
                    End If
                    str = ""
                ElseIf TypeOf (e) Is SqlClient.SqlException Then
                    str = ParseSQLExceptionMessage(DirectCast(e, SqlClient.SqlException))
                    str = ExceptionParser.GetLimitedString(str, nLine)
                    If Trim(str) <> "" Then
                        vRet = str + vbCrLf + vRet
                    End If
                    str = ""
                End If
                If e Is ex Then
                    str = ""
                End If

            End If

            strLast = e.Message
            e = e.InnerException
        End While
        If Trim(vRet) = "" Then
            vRet = Trim(strApp)
        End If
        If Trim(str) <> "" Then
            If Trim(vRet) = "" Then
                vRet = str
            Else
                vRet = vRet + vbCrLf + str
            End If
        End If
        If Trim(vRet) = "" Then
            vRet = ex.Message
        End If
        If Right(vRet, Len(vbCrLf)) = vbCrLf Then
            vRet = Left(vRet, Len(vRet) - Len(vbCrLf))
        End If
        Return vRet
    End Function


    Private Shared Function ParseMessage(ByVal message As String, ByVal vType As Type, ByRef bIncludeID As Boolean) As String
        Dim strLine As String
        Dim strByID, strMessage As String
        Dim strTemp As String
        Dim vRet As String
        Dim bByID As Boolean
        Dim s() As String
        bIncludeID = False
        s = Split(Replace(message, vbLf, ""), vbCr)
        For i As Integer = LBound(s) To UBound(s)
            strTemp = ParseMessageByLine(s(i), vType, bByID)
            If bByID Then
                strByID = strTemp + vbCrLf + strByID
                bIncludeID = True
            Else
                strMessage = strTemp + vbCrLf + strMessage
            End If
        Next
        If Trim(strByID) <> "" Then
            vRet = strByID
            If Trim(strMessage) <> "" Then
                vRet = vRet + ":" + strMessage
            End If
        Else
            vRet = strMessage
        End If
        If Right(vRet, Len(vbCrLf)) = vbCrLf Then
            vRet = Left(vRet, Len(vRet) - Len(vbCrLf))
        End If
        Return vRet
    End Function


    Private Shared Function ParseMessageByLine(ByVal message As String, ByVal vType As Type, ByRef bIncludeID As Boolean) As String
        Dim pos1, pos2, pos3 As Integer
        Dim vParam As String
        Dim i As Integer
        Dim strRes As String
        Dim strID As String
        Dim strDef As String
        Dim str As String
        Dim strVP As String
        Dim s() As String
        If vType Is Nothing Then
            vType = GetType(Exception)
        End If
        bIncludeID = False
        pos1 = InStr(message, "{")   'start with 1
        pos2 = InStr(message, "}")   'start with 1
        pos3 = InStr(message, "#$")
        If pos1 = 1 And pos2 > 0 Then
            bIncludeID = True
            strID = Trim(Mid(message, pos1 + 1, pos2 - pos1 - 1))
            If pos3 <= pos2 Then
                strDef = Mid(message, pos2 + 1)
                vParam = ""
            Else
                strDef = Mid(message, pos2 + 1, pos3 - pos2 - 1)
                vParam = Mid(message, pos3 + 2)
            End If
            strRes = PublicResource.LoadResString("ID_exp_" + vType.Name + "_" + Replace(strID, " ", "_"), strDef)
            s = Split(vParam, ",")
            For i = 1 To 10
                strVP = "#" + i.ToString
                If (i - 1 < LBound(s)) Or (i - 1 > UBound(s)) Then
                    strRes = Replace(strRes, strVP, "")
                Else
                    strRes = Replace(strRes, strVP, s(i - 1))
                End If
            Next
            Return strRes
        End If
        Return message
    End Function

    Private Shared Function ParseSQLExceptionMessage(ByVal e As SqlClient.SqlException) As String
        Dim str As String
        Dim str2 As String
        If e.Number = 51000 Then
            str = PublicResource.LoadResString("ID_exp_SQLException_51000", "其它用户已经更改了记录," + vbCrLf + "请刷新记录后再操作.")
            Return str
        Else
            str = PublicResource.LoadResString("ID_exp_SQLException_Code", "代码:")
            str2 = PublicResource.LoadResString("ID_exp_SQLException_Source", "来源:系统数据库")
            Return e.Message + "(" + str + e.Number.ToString + "," + str2 + ")"
        End If
    End Function


    Public Shared Function GetLimitedString(ByVal str As String, ByVal iLineCount As Integer) As String
        Dim s() As String
        Dim i As Integer
        Dim iCount As Integer
        Dim strRet As String
        str = Replace(str, vbLf, "")
        s = Split(str, vbCr)
        strRet = ""
        For i = LBound(s) To UBound(s)
            strRet = strRet + s(i) + vbCrLf
            iCount = iCount + 1
            If iCount > iLineCount Then
                Return strRet
            End If
        Next
        If Right(strRet, Len(vbCrLf)) = vbCrLf Then
            strRet = Left(strRet, Len(strRet) - Len(vbCrLf))
        End If
        Return strRet
    End Function


End Class
