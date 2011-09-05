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
        Public Const ARCInboundBrowse As String = "01-PCPRG_06-01"                       '�ջ�->��ⵥ�ݹ���(���)
        Public Const DNHDRLIST As String = "DNHDR-LIST"  '	���������
        Public Const DNHDRNEW As String = "DNHDR-NEW" '	�½�������
        Public Const DNHDREDIT As String = "DNHDR-EDIT" '	�༭������
        Public Const DNHDRREMOVE As String = "DNHDR-REMOVE" '	ɾ��������
        Public Const DNHDRCLOSE As String = "DNHDR-CLOSE" '	�رշ�����
        Public Const DNHDRLOAD As String = "DNHDR-LOAD" '	���뷢����
        Public Const DNHDROPT As String = "DNHDR-OPT" '	�Ż�������
        Public Const DNLISTLIST As String = "DNLIST-LIST" '	������ϸ���
        Public Const DNLINNEW As String = "DNLIN-NEW" '	�½���������ϸ
        Public Const DNLINEDIT As String = "DNLIN-EDIT" '	�༭��������ϸ
        Public Const DNLINREMOVE As String = "DNLIN-REMOVE" '	ɾ����������ϸ
        Public Const DNLINCLOSE As String = "DNLIN-CLOSE" '	�رշ�������ϸ
        Public Const BACHHDRLIST As String = "BACHHDR-LIST" '	�����������
        Public Const BACHHDRNEW As String = "BACHHDR-NEW" '	�½���������
        Public Const BACHHDREDIT As String = "BACHHDR-EDIT" '	�༭��������
        Public Const BACHHDRREMOVE As String = "BACHHDR-REMOVE" '	ɾ����������
        Public Const BACHHDRCLOSE As String = "BACHHDR-CLOSE" '	�رշ�������
        Public Const BACHHDRASSIGN As String = "BACHHDR-ASSIGN" '	���������������
        Public Const BACHLINLIST As String = "BACHLIN-LIST" '	����������ϸ���
        Public Const BACHLINNEW As String = "BACHLIN-NEW" '	�½�����������ϸ
        Public Const BACHLINEDIT As String = "BACHLIN-EDIT" '	�༭����������ϸ
        Public Const BACHLINREMOVE As String = "BACHLIN-REMOVE" '	ɾ������������ϸ
        Public Const TASKHDRLIST As String = "TASKHDR-LIST" '	�����������
        Public Const TASKHDRNEW As String = "TASKHDR-NEW" '	�½���������
        Public Const TASKHDREDIT As String = "TASKHDR-EDIT" '	�༭��������
        Public Const TASKHDRREMOVE As String = "TASKHDR-REMOVE" '	ɾ����������
        Public Const TASKHDRCLOSE As String = "TASKHDR-CLOSE" '	�رշ�������
        Public Const TASKHDRASSIGN As String = "TASKHDR-ASSIGN" '	�������
        Public Const TASKLINLIST As String = "TASKLIN-LIST" '	����������ϸ���
        Public Const TASKLINNEW As String = "TASKLIN-NEW" '	�½�����������ϸ
        Public Const TASKLINEDIT As String = "TASKLIN-EDIT" '	�༭����������ϸ
        Public Const TASKLINREMOVE As String = "TASKLIN-REMOVE" '	ɾ������������ϸ
        Public Const BINSTATUSLIST As String = "BINSTATUS-LIST" '	��λ״̬���
        Public Const BINSTATUSNEW As String = "BINSTATUS-NEW" '	�½���λ״̬
        Public Const BINSTATUSEDIT As String = "BINSTATUS-EDIT" '	�༭��λ״̬
        Public Const BINSTATUSREMOVE As String = "BINSTATUS-REMOVE" '	ɾ����λ״̬
        Public Const DNBINLIST As String = "DNBIN-LIST" '	��λ�����
        Public Const DNBINNEW As String = "DNBIN-NEW" '	�½���λ��
        Public Const DNBINEDIT As String = "DNBIN-EDIT" '	�༭��λ��
        Public Const DNBINREMOVE As String = "DNBIN-REMOVE" '	ɾ����λ��
        Public Const SKUINFOLIST As String = "SKUINFO-LIST" '	��Ʒ��Ϣ���
        Public Const SKUINFONEW As String = "SKUINFO-NEW" '	�½���Ʒ��Ϣ
        Public Const SKUINFOEDIT As String = "SKUINFO-EDIT" '	�༭��Ʒ��Ϣ
        Public Const SKUINFOREMOVE As String = "SKUINFO-REMOVE" '	ɾ����Ʒ��Ϣ
        Public Const SKUINFOLOAD As String = "SKUINFO-LOAD" '	��Ʒ��Ϣ����
        Public Const BINAREALIST As String = "BINAREA-LIST" '	������Ϣ���
        Public Const BINAREANEW As String = "BINAREA-NEW" '	�½�������Ϣ
        Public Const BINAREAEDIT As String = "BINAREA-EDIT" '	�༭������Ϣ
        Public Const BINAREAREMOVE As String = "BINAREA-REMOVE" '	ɾ��������Ϣ
        Public Const BINAREALOAD As String = "BINAREA-LOAD" '	������Ϣ����
        Public Const BINLIST As String = "BIN-LIST" '	��λ��Ϣ���
        Public Const BINNEW As String = "BIN-NEW" '	�½���λ��Ϣ
        Public Const BINEDIT As String = "BIN-EDIT" '	�༭��λ��Ϣ
        Public Const BINREMOVE As String = "BIN-REMOVE" '	ɾ����λ��Ϣ
        Public Const BINLOAD As String = "BIN-LOAD" '	��λ��Ϣ����
        Public Const CTIYLIST As String = "CTIY-LIST" '	������Ϣ���
        Public Const CTIYNEW As String = "CTIY-NEW" '	�½�������Ϣ
        Public Const CTIYEDIT As String = "CTIY-EDIT" '	�༭������Ϣ
        Public Const CTIYREMOVE As String = "CTIY-REMOVE" '	ɾ��������Ϣ
        Public Const CTIYLOAD As String = "CTIY-LOAD" '	������Ϣ����
        Public Const USERLIST As String = "USER-LIST" '	�û���Ϣ���
        Public Const USERNEW As String = "USER-NEW" '	�½��û���Ϣ
        Public Const USEREDIT As String = "USER-EDIT" '	�༭�û���Ϣ
        Public Const USERREMOVE As String = "USER-REMOVE" '	ɾ���û���Ϣ
        Public Const ROLELIST As String = "ROLE-LIST" '	��ɫ��Ϣ���
        Public Const ROLENEW As String = "ROLE-NEW" '	�½���ɫ��Ϣ
        Public Const ROLEEDIT As String = "ROLE-EDIT" '	�༭��ɫ��Ϣ
        Public Const ROLEREMOVE As String = "ROLE-REMOVE" '	ɾ����ɫ��Ϣ
        Public Const ROLEADDPERM As String = "ROLE-ADD-PERM" '	��ɫȨ������
        Public Const ROLEREMOVEPERM As String = "ROLE-REMOVE-PERM" '	��ɫȨ��ɾ��
        Public Const PERMISSIONLIST As String = "PERMISSION-LIST" '	Ȩ����Ϣ���
        Public Const PERMISSIONNEW As String = "PERMISSION-NEW" '	�½�Ȩ����Ϣ
        Public Const PERMISSIONEDIT As String = "PERMISSION-EDIT" '	�༭Ȩ����Ϣ
        Public Const PERMISSIONREMOVE As String = "PERMISSION-REMOVE" '	ɾ��Ȩ����Ϣ
    End Class


End Namespace
