Namespace BusinessObject

    Public Class clsPrintCode

        Public Const strDnhdr As String = "001"
        Public Const strRochdr As String = "002"
        Public Const strAssignList As String = "003"
        Public Const strRepairbill As String = "004"
        Public Const strBchhdr As String = "005"
        Public Const strMtesting As String = "006"
        Public Const strUserBorrowing As String = "007"
        Public Const strReturn As String = "008"
        Public Const strDelivery As String = "009"
        Public Const strKitPicking As String = "010"
        Public Const strKeepPrintA As String = "011"
        Public Const strLabelPrint As String = "012"
        Public Const strKeepPrintB As String = "013"
        Public Const strCPSGPrint As String = "017"

        Public Const strInboundSample As String = "018"
        Public Const strOutboundSample As String = "019"
        Public Const strOutboundSOF As String = "020"           '报废单
        Public Const strOutboundDWS As String = "021"

        Public Const strSvc_typeA As String = "A"   '延长卡
        Public Const strSvc_typeB As String = "B"   '套装卡

        'Public strPrintGroup As String = UserRightMgr.gDcCode
        Public Const strOptCode As String = "PRN"



        Public Function GetFormatString(ByVal dc_code As String, ByVal vOptCode As String, ByVal vSubCode As String) As String
            Dim vVal As String
            Try
                vVal = clsOption.GetOptionALL(dc_code, vOptCode, vSubCode)

            Catch ex As Exception
                vVal = ""
            End Try
            Return vVal
        End Function

        Public Function SetFormatString(ByVal dc_code As String, ByVal vOptCode As String, ByVal vSubCode As String, ByVal vValue As String) As String
            Try
                clsOption.SetOptionALL(dc_code, vOptCode, vSubCode, " ", vValue)
            Catch ex As Exception
            End Try
        End Function

    End Class

End Namespace

