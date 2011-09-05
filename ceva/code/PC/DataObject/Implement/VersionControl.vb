Namespace BusinessObject


    Public Class VersionControl
        Public Enum CheckVersionResult
            Pass = 0
            ClientVersionLow = 100
            BussinessVersionLow = 101
            ComExpressLow = 102
            DBVersionLow = 200
            DBVersionLarge = 210
            CheckError = 999
        End Enum

        Public Const reqMinVersionDB As String = "3.0"            '数据库最低版本号
        Public Const reqMaxVersionDB As String = "3.1"            '数据库最高版本号(本版本同时禁止)
        Public Const reqVersionBussiness As String = "3.0.0.0"   'YT.DLL动态库最低版本号
        Public Const reqVersionLibrary As String = "1.6.2.0"        'ComExpress DLL 所需版本号

        'Private mSysInfo As clssysinfo

        'Public ReadOnly Property SysInfo() As clssysinfo
        '    Get
        '        Return mSysInfo
        '    End Get
        'End Property

        Public Sub New()
            'mSysInfo = clssysinfo.Load("WMS")
        End Sub

        Public Function CheckVersion() As CheckVersionResult
            'check database's version
            'If mSysInfo.ver_db < reqMinVersionDB Then
            '    Return CheckVersionResult.DBVersionLow
            'End If
            'If mSysInfo.ver_db >= reqMaxVersionDB Then
            '    Return CheckVersionResult.DBVersionLarge
            'End If
            ''check YT.dll's version
            'If Me.GetType.Assembly.GetName.Version.CompareTo(New Version(reqVersionBussiness)) < 0 Then
            '    Return CheckVersionResult.BussinessVersionLow
            'End If
            ''-if need, you can add check comexpress dll's code---------------------
            'If GetType(COMExpress.BusinessObject.BusinessBaseDerived).Assembly.GetName.Version.CompareTo(New Version(reqVersionLibrary)) < 0 Then
            '    Return CheckVersionResult.ComExpressLow
            'End If
            '----------------------
            Return CheckVersionResult.Pass
        End Function

    End Class


End Namespace
