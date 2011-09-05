Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports System.Data
Imports System.Collections

Namespace BusinessObject

    Public Class UserRightMgr
        Public Shared gDcCode As String
        'Public Shared gWhCode As String
        Public Shared gUserCode As String
        Public Shared LoginSuccess As Boolean
        Public Shared IsAdmin As Boolean
        Public Shared gUIAssemblyVersion As String

        Public Shared Isavecount As Integer = 0

        '
        Public Enum LoginInfoType
            Valid = 0
            NoUser
            WrongPassword
            PasswordExpired
        End Enum

        Public Enum ChangePWDInfoType
            Success = 0
            WrongOriginalPassword
            WrongConfirmPassword
        End Enum

        Public Enum TransType
            RCV
        End Enum

        Public Enum DocType
            NULL = 0

        End Enum

        Public Enum RightOperaType
            Null = 0
            Browse = 1
            AddNew = 2
            Edit = 3
            Delete = 4
            Search = 5
            Purge = 6
            Label = 7
            Report = 8
            Check = 11
            Confirm = 12
            Download = 20
            Upload = 22
            Print = 23
            Import = 30
            Export = 31
            'Supervisor
        End Enum


        Public Shared Function Login(ByVal User As String, ByVal Pwd As String, ByVal dc_code As String) As LoginInfoType


            Dim result As LoginInfoType
            Dim interFilter As New CXFilters
            Dim RepeatFilter As Filters.CXRangeFilter = MakeFilters("[operator].[user_code]", User)
            interFilter.Add(RepeatFilter)

            Dim UserList As clsOPERATORs = clsOPERATOR.LoadList(interFilter)
            If UserList.Count = 0 Then
                result = LoginInfoType.NoUser
            ElseIf UserList.Item(0).password_ <> Pwd Then
                result = LoginInfoType.WrongPassword
            ElseIf UserList.Item(0).allowlogin = False And UserList.Item(0).isadmin = False Then
                result = LoginInfoType.NoUser
            Else
                result = LoginInfoType.Valid
                IsAdmin = UserList.Item(0).isadmin
                gUserCode = User

                'Dim timeExpired As String = clsOption.GetGlobalOption(clsOption.eOptGroup.SystemOption, clsOption.eSystemOption_OptCode.PasswordExpiry)
                'If result = LoginInfoType.Valid And timeExpired <> "" And Not IsDBNull(UserList(0).update_date) Then
                '    If Date.Parse(UserList(0).update_date.ToString).Date.AddDays(CInt(timeExpired)) >= Now.Date Then
                '        result = LoginInfoType.Valid
                '    Else
                '        result = LoginInfoType.PasswordExpired
                '    End If
                'End If
            End If

            interFilter.Clear()
            interFilter = Nothing
            UserList.Clear()
            UserList = Nothing
            Return result
        End Function

        Public Shared Function ChangePWD(ByVal OldPwd As String, ByVal NewPwd As String, ByVal ConPwd As String) As ChangePWDInfoType
            Dim result As ChangePWDInfoType
            If ConPwd <> NewPwd Then
                result = ChangePWDInfoType.WrongConfirmPassword
                Return result
            End If
            Dim interFilter As New CXFilters
            Dim RepeatFilter As Filters.CXRangeFilter = MakeFilters("[operator].[user_code]", gUserCode)
            interFilter.Add(RepeatFilter)
            'RepeatFilter = MakeFilters("[sUser].[sStore]", gStoreCode)  'modified by wj 2007-09-17
            'interFilter.Add(RepeatFilter)                               'modified by wj 2007-09-17
            Dim UserList As clsOPERATORs
            UserList = clsOPERATOR.LoadList(interFilter)
            'UserList.ApplyEdit()
            If UserList.Item(0).password_ = OldPwd Then
                UserList.Item(0).password_ = NewPwd
                UserList.Save()
                result = ChangePWDInfoType.Success
            Else
                result = ChangePWDInfoType.WrongOriginalPassword
            End If
            interFilter.Clear()
            interFilter = Nothing
            UserList.Clear()
            UserList = Nothing
            Return result
        End Function

        Public Shared Function GetRightNoDC(ByVal RightNo As String) As Boolean
            If IsAdmin Then
                Return True
            End If
            'Return True
            Try

                Dim UserRight As clsUserpermission
                UserRight = clsUserpermission.Load(gUserCode, RightNo)
                If UserRight Is Nothing Then
                    Return False
                ElseIf Not UserRight.IsNew Then
                    Return True
                End If
                Return False
            Catch ex As Exception
                COMExpress.BusinessObject.CXEventLog.LogToFile(ex.Message + vbCrLf + ex.StackTrace, CXEventLog.LogTypeConstants.logUI)
                Return False
            End Try
        End Function
    End Class

    Public Class Rights
        Public Const ARCInboundBrowse As String = "01-PCPRG_06-01"                       '收货->入库单据管理(浏览)
        Public Const DNHDRLIST As String = "DNHDR-LIST"  '	发货单浏览
        Public Const DNHDRNEW As String = "DNHDR-NEW" '	新建发货单
        Public Const DNHDREDIT As String = "DNHDR-EDIT" '	编辑发货单
        Public Const DNHDRREMOVE As String = "DNHDR-REMOVE" '	删除发货单
        Public Const DNHDRCLOSE As String = "DNHDR-CLOSE" '	关闭发货单
        Public Const DNHDRLOAD As String = "DNHDR-LOAD" '	导入发货单
        Public Const DNHDROPT As String = "DNHDR-OPT" '	优化发货单
        Public Const DNLISTLIST As String = "DNLIST-LIST" '	发货明细浏览
        Public Const DNLINNEW As String = "DNLIN-NEW" '	新建发货单明细
        Public Const DNLINEDIT As String = "DNLIN-EDIT" '	编辑发货单明细
        Public Const DNLINREMOVE As String = "DNLIN-REMOVE" '	删除发货单明细
        Public Const DNLINCLOSE As String = "DNLIN-CLOSE" '	关闭发货单明细
        Public Const BACHHDRLIST As String = "BACHHDR-LIST" '	发货批次浏览
        Public Const BACHHDRNEW As String = "BACHHDR-NEW" '	新建发货批次
        Public Const BACHHDREDIT As String = "BACHHDR-EDIT" '	编辑发货批次
        Public Const BACHHDRREMOVE As String = "BACHHDR-REMOVE" '	删除发货批次
        Public Const BACHHDRCLOSE As String = "BACHHDR-CLOSE" '	关闭发货批次
        Public Const BACHHDRASSIGN As String = "BACHHDR-ASSIGN" '	发货批次任务分配
        Public Const BACHLINLIST As String = "BACHLIN-LIST" '	发货批次明细浏览
        Public Const BACHLINNEW As String = "BACHLIN-NEW" '	新建发货批次明细
        Public Const BACHLINEDIT As String = "BACHLIN-EDIT" '	编辑发货批次明细
        Public Const BACHLINREMOVE As String = "BACHLIN-REMOVE" '	删除发货批次明细
        Public Const TASKHDRLIST As String = "TASKHDR-LIST" '	发货任务浏览
        Public Const TASKHDRNEW As String = "TASKHDR-NEW" '	新建发货任务
        Public Const TASKHDREDIT As String = "TASKHDR-EDIT" '	编辑发货任务
        Public Const TASKHDRREMOVE As String = "TASKHDR-REMOVE" '	删除发货任务
        Public Const TASKHDRCLOSE As String = "TASKHDR-CLOSE" '	关闭发货任务
        Public Const TASKHDRASSIGN As String = "TASKHDR-ASSIGN" '	任务分配
        Public Const TASKLINLIST As String = "TASKLIN-LIST" '	发货任务明细浏览
        Public Const TASKLINNEW As String = "TASKLIN-NEW" '	新建发货任务明细
        Public Const TASKLINEDIT As String = "TASKLIN-EDIT" '	编辑发货任务明细
        Public Const TASKLINREMOVE As String = "TASKLIN-REMOVE" '	删除发货任务明细
        Public Const BINSTATUSLIST As String = "BINSTATUS-LIST" '	货位状态浏览
        Public Const BINSTATUSNEW As String = "BINSTATUS-NEW" '	新建货位状态
        Public Const BINSTATUSEDIT As String = "BINSTATUS-EDIT" '	编辑货位状态
        Public Const BINSTATUSREMOVE As String = "BINSTATUS-REMOVE" '	删除货位状态
        Public Const DNBINLIST As String = "DNBIN-LIST" '	货位绑定浏览
        Public Const DNBINNEW As String = "DNBIN-NEW" '	新建货位绑定
        Public Const DNBINEDIT As String = "DNBIN-EDIT" '	编辑货位绑定
        Public Const DNBINREMOVE As String = "DNBIN-REMOVE" '	删除货位绑定
        Public Const SKUINFOLIST As String = "SKUINFO-LIST" '	产品信息浏览
        Public Const SKUINFONEW As String = "SKUINFO-NEW" '	新建产品信息
        Public Const SKUINFOEDIT As String = "SKUINFO-EDIT" '	编辑产品信息
        Public Const SKUINFOREMOVE As String = "SKUINFO-REMOVE" '	删除产品信息
        Public Const SKUINFOLOAD As String = "SKUINFO-LOAD" '	产品信息导入
        Public Const BINAREALIST As String = "BINAREA-LIST" '	货区信息浏览
        Public Const BINAREANEW As String = "BINAREA-NEW" '	新建货区信息
        Public Const BINAREAEDIT As String = "BINAREA-EDIT" '	编辑货区信息
        Public Const BINAREAREMOVE As String = "BINAREA-REMOVE" '	删除货区信息
        Public Const BINAREALOAD As String = "BINAREA-LOAD" '	货区信息导入
        Public Const BINLIST As String = "BIN-LIST" '	货位信息浏览
        Public Const BINNEW As String = "BIN-NEW" '	新建货位信息
        Public Const BINEDIT As String = "BIN-EDIT" '	编辑货位信息
        Public Const BINREMOVE As String = "BIN-REMOVE" '	删除货位信息
        Public Const BINLOAD As String = "BIN-LOAD" '	货位信息导入
        Public Const CTIYLIST As String = "CTIY-LIST" '	城市信息浏览
        Public Const CTIYNEW As String = "CTIY-NEW" '	新建城市信息
        Public Const CTIYEDIT As String = "CTIY-EDIT" '	编辑城市信息
        Public Const CTIYREMOVE As String = "CTIY-REMOVE" '	删除城市信息
        Public Const CTIYLOAD As String = "CTIY-LOAD" '	城市信息导入
        Public Const USERLIST As String = "USER-LIST" '	用户信息浏览
        Public Const USERNEW As String = "USER-NEW" '	新建用户信息
        Public Const USEREDIT As String = "USER-EDIT" '	编辑用户信息
        Public Const USERREMOVE As String = "USER-REMOVE" '	删除用户信息
        Public Const ROLELIST As String = "ROLE-LIST" '	角色信息浏览
        Public Const ROLENEW As String = "ROLE-NEW" '	新建角色信息
        Public Const ROLEEDIT As String = "ROLE-EDIT" '	编辑角色信息
        Public Const ROLEREMOVE As String = "ROLE-REMOVE" '	删除角色信息
        Public Const ROLEADDPERM As String = "ROLE-ADD-PERM" '	角色权限增加
        Public Const ROLEREMOVEPERM As String = "ROLE-REMOVE-PERM" '	角色权限删除
        Public Const PERMISSIONLIST As String = "PERMISSION-LIST" '	权限信息浏览
        Public Const PERMISSIONNEW As String = "PERMISSION-NEW" '	新建权限信息
        Public Const PERMISSIONEDIT As String = "PERMISSION-EDIT" '	编辑权限信息
        Public Const PERMISSIONREMOVE As String = "PERMISSION-REMOVE" '	删除权限信息
    End Class


End Namespace
