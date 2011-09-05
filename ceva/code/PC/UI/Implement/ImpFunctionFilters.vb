Imports YT
Imports YT.BusinessObject

Module ImpFunctionFilters

    '第一个列表界面的是否区分物流中心
    Private Sub GetRegionDcFilter(ByVal strObjectName As String, ByVal right_no As String, ByVal fls As COMExpress.BusinessObject.Filters.CXFilters)
        Dim sglFl As COMExpress.BusinessObject.Filters.CXFilterBase
        Return
        If fls Is Nothing Then
            Return
        End If
        If LCase(strObjectName) = "clsregiondc" Then
            Return
        End If
        If LCase(strObjectName) = "clsplant" Then
            Return
        End If
        If LCase(strObjectName) = "clsif_req" Then
            Return
        End If
        If LCase(strObjectName) = "clsif_ret" Then
            Return
        End If
        Dim strSQL As String
        strSQL = "select dc_code from dbo.getDCListByPermission('" + UserRightMgr.gUserCode + "','" + Trim(right_no) + "')"
        'sglFl = ImpBusinessCollectionDerived.GetSingleFilterEx("dc_code", UserRightMgr.gDcCode, strObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
        sglFl = ImpBusinessCollectionDerived.GetSingleFilterEx("dc_code", strSQL, strObjectName, COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
        If sglFl Is Nothing Then
            Return
        End If
        fls.Add(sglFl)
    End Sub


    Public Function GetFunctionFilters(ByVal strObjectName As String, ByVal sFuncType As String, ByVal right_no As String) As COMExpress.BusinessObject.Filters.CXFilters
        Dim strWhere As String
        Dim fls As New COMExpress.BusinessObject.Filters.CXFilters
        Dim sglFl As COMExpress.BusinessObject.Filters.CXFilterBase
        Call GetRegionDcFilter(strObjectName, right_no, fls)
        sglFl = Nothing
        If strObjectName = "clsrohdr" Then
            Select Case sFuncType
                Case "InboundPO"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("doc_type", DocType.InboundPO, "clsrohdr", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
            End Select
        ElseIf strObjectName = "clsarchhdr" Then
            Select Case sFuncType
                Case "Inbound"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("arc_type", "1", "clsarchhdr", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
                Case "Outbound"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("arc_type", "2", "clsarchhdr", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
            End Select
        ElseIf strObjectName = "clsdnhdr" Then
            Select Case sFuncType
                Case "AllDn"
                    'sglFl = ImpBusinessCollectionDerived.GetSingleFilter("status_code", DnStatusCode.NotStartDn, "clsdnhdr", COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
                Case "NotStartDn"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("status_code", DnStatusCode.NotStartDn, "clsdnhdr", COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
                Case "StartDn"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("status_code", DnStatusCode.StartDn, "clsdnhdr", COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
                Case "FinishedtDn"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("status_code", DnStatusCode.FinishedtDn, "clsdnhdr", COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
            End Select
        ElseIf strObjectName = "clsbchhdr" Then

            Select Case sFuncType
                Case "ALLBanch"
                    'sglFl = ImpBusinessCollectionDerived.GetSingleFilter("status_code", BatchStatusCode.Open, "clsbchhdr", COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
                Case "NotStartBanch"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("status_code", BatchStatusCode.NotStartBanch, "clsbchhdr", COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
                Case "StartBanch"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("status_code", BatchStatusCode.StartBanch, "clsbchhdr", COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
                Case "FinishedBanch"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("status_code", BatchStatusCode.FinishedtBanch, "clsbchhdr", COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
            End Select
        ElseIf strObjectName = "clstrkhdr" Then
            Select Case sFuncType
                Case "TrackingLoan"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("trk_type", TrackingType.TrackingLoan, "clstrkhdr", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
                Case "TrackingRepair"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("trk_type", TrackingType.TrackingRepair, "clstrkhdr", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
            End Select
        ElseIf strObjectName = "clsmvhdr" Then
            Select Case sFuncType
                Case "MovementBinNormal"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("doc_type", DocType.MovementBinNormalList, "clsmvhdr", COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
                Case "MovementOwnerNonSAP"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("doc_type", DocType.MovementOwnerNonSAP, "clsmvhdr", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
                    'Case "MovementOwnerSAP"
                    '    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("doc_type", DocType.MovementOwnerSAP, "clsmvhdr", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
                Case "MovementStatusChanged"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("doc_type", DocType.MovementStatusChanged, "clsmvhdr", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
                Case "MovementOwnerChanged"         '移货主  MovementOwnerChanged
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("doc_type", DocType.MovementWarehouseList, "clsmvhdr", COMExpress.BusinessObject.Filters.ConditionOperator.IncludeIn)
                Case "MovementBinWithoutOrder"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("doc_type", DocType.MovementBinWithoutOrder, "clsmvhdr", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
            End Select
        ElseIf strObjectName = "clsmessage" Then
            strWhere = "(msg_type='SYS' " + vbCrLf + _
                "or (msg_type<>'SYS' and msg_to='" + UserRightMgr.gUserCode + "'))" + vbCrLf + _
                "and " + vbCrLf + _
                "( " + vbCrLf + _
                "status_code<'NTC14' or  " + vbCrLf + _
                "	(status_code>='NTC14' and (msg_dtime>=dateadd(day,-2,getdate()) or opt_dtime>=dateadd(day,-2,getdate())    ) )" + vbCrLf + _
                ") " + vbCrLf
            sglFl = ImpBusinessCollectionDerived.GetSingleFilter("msg_type", strWhere, "clsmessage", COMExpress.BusinessObject.Filters.ConditionOperator.OrginalWhereClause)
        ElseIf strObjectName = "clsstockusage" Then
            Select Case sFuncType
                Case "StockUsageWM"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("use_type", "500", "clsstockusage", COMExpress.BusinessObject.Filters.ConditionOperator.LessThan)
                Case "StockUsageIM"
                    sglFl = ImpBusinessCollectionDerived.GetSingleFilter("use_type", "500", "clsstockusage", COMExpress.BusinessObject.Filters.ConditionOperator.GreaterThanOrEqualTo)
            End Select
        End If

        If Not sglFl Is Nothing Then
            fls.Add(sglFl)
        End If
        If fls.Count <= 0 Then
            Return Nothing
        End If
        Return fls
    End Function

    Public Function GetFuncTypeByDocType(ByVal doc_type As String) As String
        Select Case doc_type
            'Case DocType.InboundCTO
            '    Return "InboundCTO"
        Case DocType.InboundImport
                Return "InboundImport"
            Case DocType.InboundLoan
                Return "InboundLoan"
            Case DocType.InboundPO
                Return "InboundPO"
            Case DocType.InboundPOP
                Return "InboundPOP"
            Case DocType.InboundRepair
                Return "InboundRepair"
            Case DocType.InboundReturn
                Return "InboundReturn"
            Case DocType.InboundTemporarily
                Return "InboundTemporarily"
            Case DocType.InboundTransfer
                Return "InboundTransfer"
            Case DocType.InboundHand
                Return "InbounndHand"
            Case DocType.InboundTakeback
                Return "InboundTakeback"
            Case DocType.InboundSample
                Return "InboundSample"
                '-----------------------------------
            Case DocType.OutboundHand           '--
                Return "OutboundHand"
            Case DocType.OutboundLoan           '--借机出货
                Return "OutboundLoan"
            Case DocType.OutboundDaily          '每日发货列表
                Return "OutboundNormal"
            Case DocType.OutboundReplaced       '替代后出货
                Return "OutboundNormal"
            Case DocType.OutboundPOP            'POP
                Return "OutboundPOP"
            Case DocType.OutboundRepair         '维修
                Return "OutboundRepair"
            Case DocType.OutboundReturnToPlant  '返厂
                Return "OutboundReturnToPlant"
            Case DocType.OutboundTemporarily    '暂存出库
                Return "OutboundTemporarily"
            Case DocType.OutboundTransfer       '转库出库
                Return "OutboundTransfer"
            Case DocType.OutboundSample         '样机出库
                Return "OutboundSample"
            Case DocType.OutboundWriteOffSample '样机报废
                Return "OutboundSample"
            Case DocType.OutboundDWS            'DWS出库
                Return "OutboundDWS"
            Case Else
                Return doc_type
        End Select

    End Function


    Public Function GetBrowserRight(ByVal strObjectName As String, ByVal sFuncType As String) As String
        Dim strRightNo As String
        strRightNo = ""
        Select Case strObjectName
            '------Security
        Case "clsoperator"
                strRightNo = Rights.USERLIST
            Case "clsrole"
                strRightNo = Rights.ROLELIST
            Case "clspermission"
                strRightNo = Rights.PERMISSIONLIST
            Case Else
        End Select
        Return strRightNo
    End Function
End Module
