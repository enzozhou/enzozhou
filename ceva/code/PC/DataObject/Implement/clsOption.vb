Option Strict On
Imports COMExpress.BusinessObject.Filters

Namespace BusinessObject

    Public Class clsOption

        Public Const English As String = "en-US"
        Public Const SimplifiedChinese As String = "zh-CHS"

        Public Const BinDefineGroup As String = "Buffer"
        Public Const BinTypeCodeInbound As String = "INB"
        Public Const BinTypeCodeOutbound As String = "OUT"
        'Public Const BinTypeCodeCycleCount As String = "CCN"
        Public Const BinTypeCodeKitting As String = "KIT"
        Public Const BinTypeCodeDWS As String = "DWS"


        Public Enum eOptGroup
            SystemOption = 100
            UserDefineField = 110
        End Enum

        Public Enum eSystemOption_OptCode
            PasswordExpiry = 100
            SystemType = 110
            Language = 111
            DateFormat = 112
            'DefualtExpUrl = 113
            EnableDefineOrderOfWarrantCard = 120
        End Enum

        Public Enum eUserDefineField_OptCode
            city = 100
            carrier = 110
            owner = 115
            warehouse
            binarea
            bin
            skuinfo
            [operator]
            bchtruck
        End Enum



        'Public Enum eOptCode_SystemOption
        '    Language = 1
        '    Store = 2
        '    HVI = 3
        '    DateFormat = 4
        '    PasswordExpiry = 5
        '    Discrepancy_Period = 6
        '    WithoutDiscrepancy_Period = 7
        '    Currency = 8
        '    Country = 9
        '    DiscrepancyFileDirectory = 10
        '    OrphanUPCDirectory = 11
        '    OrphanUPC_Period = 12
        'End Enum

        Public Shared Function GetGlobalOption(ByVal iOptGroup As eOptGroup, ByVal iOptCode As Integer) As String
            Return GetOption(iOptGroup, iOptCode, "global")
        End Function

        Public Shared Function GetOption(ByVal iOptGroup As eOptGroup, ByVal iOptCode As Integer, ByVal SubCode As String) As String
            Dim sGroup As String
            Dim sOptCode As String
            sGroup = PadZeroL(CInt(iOptGroup).ToString, 3)
            sOptCode = PadZeroL(iOptCode.ToString, 3)
            Return GetOptionALL(sGroup, sOptCode, SubCode)
        End Function

        'Public Function GetOption(ByVal OptGroup As eOptGroup, ByVal OptCode As Integer) As String
        '    Dim tmp1, tmp2 As String
        '    tmp1 = PadZeroL(CInt(OptGroup).ToString, 3)
        '    tmp2 = PadZeroL(OptCode.ToString, 3)
        '    Return GetOption(tmp1, tmp2)
        'End Function

        Public Shared Function GetOptionDC(ByVal iOptGroup As eOptGroup, ByVal iOptCode As Integer) As String
            Dim sGroup As String
            Dim sOptCode As String
            sGroup = PadZeroL(CInt(iOptGroup).ToString, 3)
            sOptCode = PadZeroL(iOptCode.ToString, 3)
            Return GetOptionDC(sGroup, sOptCode)
        End Function

        Public Shared Sub SetGlobalOption(ByVal OptGroup As eOptGroup, ByVal iOptCode As Integer, ByVal sDesc As String, ByVal Value As String)
            SetOption(OptGroup, iOptCode, "global", sDesc, Value)
        End Sub

        Public Shared Sub SetOption(ByVal OptGroup As eOptGroup, ByVal iOptCode As Integer, ByVal SubCode As String, ByVal sDesc As String, ByVal Value As String)
            Dim sGroup As String
            Dim sOptCode As String
            sGroup = PadZeroL(CInt(OptGroup).ToString, 3)
            sOptCode = PadZeroL(iOptCode.ToString, 3)
            SetOptionALL(sGroup, sOptCode, SubCode, sDesc, Value)
        End Sub

        Public Shared Sub SetOptionDC(ByVal OptGroup As eOptGroup, ByVal iOptCode As Integer, ByVal sDesc As String, ByVal Value As String)
            Dim sGroup As String
            Dim sOptCode As String
            sGroup = PadZeroL(CInt(OptGroup).ToString, 3)
            sOptCode = PadZeroL(iOptCode.ToString, 3)
            SetOptionDC(sGroup, sOptCode, sDesc, Value)
        End Sub

        Public Shared Function GetOptionALL(ByVal OptGroup As String, ByVal OptCode As String, ByVal SubCode As String) As String
            ''Dim obj As clssysoption
            ''obj = clssysoption.Load(OptGroup, OptCode, SubCode)
            'Dim sValue As String
            'Dim interFilter As New CXFilters
            'interFilter.Add(MakeFilters("[sysoption].[opt_group]", OptGroup))
            'interFilter.Add(MakeFilters("[sysoption].[opt_code]", OptCode))
            'interFilter.Add(MakeFilters("[sysoption].[sub_code]", SubCode))
            'Dim objList As clssysoptions = clssysoption.LoadList(interFilter)
            ''If obj Is Nothing Then
            ''    Return ""
            ''ElseIf obj.IsNew Then
            ''    Return ""
            ''Else
            ''    Return obj.value1
            ''End If
            'If objList.Count = 0 Then
            '    sValue = ""
            'Else
            '    sValue = CType(IIf(IsDBNull(objList.Item(0).value), "", objList.Item(0).value), String)
            'End If
            'interFilter.Clear()
            'interFilter = Nothing
            'objList.Clear()
            'objList = Nothing
            'Return sValue
        End Function

        Public Shared Sub SetOptionALL(ByVal OptGroup As String, ByVal OptCode As String, ByVal SubCode As String, ByVal sDesc As String, ByVal Value As String)
            'Dim obj As clssysoption
            'Try
            '    obj = clssysoption.Load(OptGroup, OptCode, SubCode)
            'Catch ex As Exception
            '    obj = clssysoption.Newclssysoption
            'End Try

            'If obj.IsNew = False Then
            '    obj.value = Value
            '    obj.Save()
            'Else
            '    obj.opt_group = OptGroup
            '    obj.opt_code = OptCode
            '    obj.sub_code = SubCode
            '    obj.description = sDesc
            '    obj.value = Value
            '    obj.checked = True
            '    obj.opt_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
            '    obj.opt_by = UserRightMgr.gUserCode
            '    obj.Save()
            '    obj = Nothing
            'End If
        End Sub

        Public Shared Sub SetOptionOK(ByVal OptGroup As String, ByVal OptCode As String, ByVal SubCode As String, ByVal sDesc As String, ByVal Value As String, ByVal remark As String)
            'Dim obj As clssysoption
            'Try
            '    obj = clssysoption.Load(OptGroup, OptCode, SubCode)
            'Catch ex As Exception
            '    obj = clssysoption.Newclssysoption
            'End Try

            'If obj.IsNew = False Then
            '    obj.value = Value
            '    obj.remark = remark
            '    obj.Save()
            'Else
            '    obj.opt_group = OptGroup
            '    obj.opt_code = OptCode
            '    obj.sub_code = SubCode
            '    obj.description = sDesc
            '    obj.value = Value
            '    obj.checked = True
            '    obj.remark = remark
            '    obj.opt_date = Now.ToString("yyyy-MM-dd HH:mm:ss")
            '    obj.opt_by = UserRightMgr.gUserCode
            '    obj.Save()
            '    obj = Nothing
            'End If
        End Sub

        Public Shared Function GetOptionDC(ByVal OptGroup As String, ByVal OptCode As String) As String
            Return GetOptionALL(OptGroup, OptCode, UserRightMgr.gDcCode)
        End Function

        Public Shared Sub SetOptionDC(ByVal OptGroup As String, ByVal OptCode As String, ByVal sDesc As String, ByVal Value As String)
            SetOptionALL(OptGroup, OptCode, UserRightMgr.gDcCode, sDesc, Value)
        End Sub

    End Class

End Namespace

