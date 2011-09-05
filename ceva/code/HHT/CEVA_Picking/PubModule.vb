Imports System.IO
Imports System
Imports System.Reflection
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.Threading.Timer '引入定时类 

'注册类
Public Structure struResTable
    Dim strText As String
    Dim strVal As String
    Public Sub New(ByVal s1 As String, ByVal s2 As String)
        strText = s1
        strVal = s2
    End Sub
End Structure
Public Interface ResTableInterface
    ReadOnly Property ResTable() As struResTable()
End Interface

Module PubModule

    Public mySymbolScancer As SymbolScancer

    Public TMPBINID_FILE As String = "TMPBINID.sav"
    Public Appcenter_name As String = "CEVA_Picking"
    'Public mySymbolScancer As SymbolScancer
    Public startPath As String = "" '程序运行所在路径
    'M_localSDF = startPath & "\db\" & M_localSDF
    'Public M_setupini As String = "" 'setup.ini文件的所在路径
    Public MDI_siteid As String = "CEVA" '当前公司部门序号,默认为"CEVA01",使支持多帐套数据
    Public MDI_userid As String = "HHT" '登录用户编号:默认是这个
    Public MDI_userName As String '登录用户名称

    'ini文件配置参数：
    Public M_HHTNO As String '本终端的编号(主要用于Z,D箱号自动生成时的前缀)
    Public M_BlueCom As String = ""
    Public M_WEBServiceURL As String = "http://@Svr_IP/RFWebService/RFWebService.asmx"
    Public MS_mz220_ip As String = ""
    Public MS_mz220_port As String = ""
    Public MS_PTComType As String = ""
    Public MSV1 As RFWebService.Service1
    Public MS_SVR_IP As String = "" '服务器IP地址..
    Public MS_SVR_PORT As String = "1433" '服务器sql服务的端口号
    Public WSSN As String = "96FD10C974A864196E3FD7F2C71BAB" '  web service调用验证 for ceva picking .. 

    Public GS_UID As String = ""
    '移动打印标签相关;
    Public M_BoxLab1Path As String = "BoxLab1.lbl" '在窗口Labprt窗口启动时，加上完整路径:M_BoxLab1Path = startPath & "\" & M_BoxLab1Path
    Public M_BoxLab1CMD As String = "" '从 BoxLab1.lbl 文件载入的箱标签指令模版

    Public Sub msg1(ByVal as_msg As String)
        MsgBox(as_msg, MsgBoxStyle.Information & MsgBoxStyle.OkCancel, "提示")
    End Sub
    Public Sub alert(ByVal as_msg As String)
        'If Not IsNothing(mySymbolScancer) Then
        '    mySymbolScancer.ErrorBeep()
        'End If
        MsgBox(as_msg, MsgBoxStyle.Exclamation & MsgBoxStyle.OkCancel, "提示")
    End Sub
    Public Function ask(ByVal as_msg As String) As MsgBoxResult
        Return MsgBox(as_msg, MsgBoxStyle.Question & MsgBoxStyle.YesNo, "提示！")
    End Function

    Public ss_paperLength As String = "320" '箱标签的纸张长度 320 = 50mm * 8dpi:没用上这个参数
    'Public myCancer As SymbolScancer = New SymbolScancer
    '定义一个委托类型 
    Public Delegate Sub del_CheckBarcode(ByVal barcode As String)
    Public gf_del_CheckBarcode As del_CheckBarcode = New del_CheckBarcode(AddressOf CheckBarcode)
    ''这里是实例扫描代码的实体部分.
    Public Sub CheckBarcode(ByVal barcode As String)
    End Sub

    ''' <summary>
    ''' 0，1阶段建立托盘和上架的阶段控制代码：发现不能弹两次窗口后把参数传递过去
    ''' 只能用全局变量了
    ''' </summary>
    ''' <remarks></remarks>
    Public TraySelect_stage As Integer
    Public TraySelect_msg As String

    Public TraySelect2_stage As String = "0" ' -- =1是对sr4detail表进行操作 
    Public TraySelect2_msg As String

    Public GS_CurrentSRNO As String = "" '当前清点所操作的SR单号
    Public GS_CurrentCartonBarcode As String = "" '当前清点所操作的箱条码
    Public AssInfo As New AssemblyInfo

    Friend Function MF_returnNowStr() As String
        '或者：Trim(String.Format("{0:u}", DateTime.Now))
        Return DateTime.Now.ToString("u").Trim().Substring(0, DateTime.Now.ToString("u").Trim().Length - 1)
    End Function

#Region "屏幕键盘控制"

    Public Class SIPINFO
        ''' <summary>
        ''' Initialize a SIPINFO instance by setting the size.
        ''' </summary>
        Public Sub New()
            cbSize = CUInt(Marshal.SizeOf(Me))
        End Sub
        ''' <summary>
        ''' Size, in bytes, of the SIPINFO structure. This member must be filled
        ''' in by the application with the size of operator. Because the system
        ''' can check the size of the structure to determine the operating system
        ''' version number, this member allows for future enhancements to the
        ''' SIPINFO structure while maintaining backward compatibility. 
        ''' </summary>
        Public cbSize As UInteger
        ''' <summary>
        ''' Specifies flags representing state information of the software-based
        ''' input panel. It is any combination of the following bit flags:
        ''' SIPF_DOCKED, SIPF_LOCKED, SIPF_OFF, and SIPF_ON.
        ''' </summary>
        Public fdwFlags As UInteger
        ''' <summary>
        ''' Rectangle, in screen coordinates, that represents the area of the
        ''' desktop not obscured by the software-based input panel. If the software-
        ''' based input panel is floating, this rectangle is equivalent to the
        ''' working area. Full-screen applications that respond to software-based
        ''' input panel size changes can set their window rectangle to this rectangle.
        ''' If the software-based input panel is docked but does not occupy an entire
        ''' edge, then this rectangle represents the largest rectangle not obscured by
        ''' the software-based input panel. If an application wants to use the screen
        ''' space around the software-based input panel, it needs to reference
        ''' rcSipRect.
        ''' </summary>
        Public rcVisibleDesktop As RECT
        ''' <summary>
        ''' Rectangle, in screen coordinates of the window rectangle and not the
        ''' client area, the represents the size and location of the software-based
        ''' input panel. An application does not generally use this information unless
        ''' it needs to wrap around a floating or a docked software-based input panel
        ''' that does not occupy an entire edge. 
        ''' </summary>
        Public rcSipRect As RECT
        ''' <summary>
        ''' Specifies the size of the data pointed to by the pvImData member.
        ''' </summary>
        Public dwImDataSize As UInteger
        ''' <summary>
        ''' Void pointer to IM-defined data. The IM calls the
        ''' IInputMethod::GetImData and IInputMethod::SetImData methods to send
        ''' and receive information from this structure.
        ''' </summary>
        Public pvImData As IntPtr
    End Class

    Public Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure
    <DllImport("coredll.dll")> _
       Public Function SipShowIM(ByVal dwFlag As Integer) As Boolean
    End Function
    <DllImport("coredll.dll")> _
    Public Function SipGetInfo(ByVal pSipInfo As SIPINFO) As UInteger
    End Function
    Public KeyBoardFlag As Boolean = True
    Public Sub showHideKeyBoard()
        Dim sipInfo As New SIPINFO()
        If SipGetInfo(sipInfo) <> 0 Then
            If sipInfo.fdwFlags = 0 Then
                SipShowIM(1)
                KeyBoardFlag = True
            ElseIf sipInfo.fdwFlags = 1 Then
                SipShowIM(0)
                KeyBoardFlag = False
            End If
        Else
        End If
        'If KeyBoardFlag = True Then
        '    SipShowIM(0)
        'End If
    End Sub

#End Region

    Public MS_SerialNumber As String '操作枪的序列码:SDK提供
    '定义系统全局类：主要是一些系统公用函数
    Public mySys As Sysinfo = New Sysinfo

#Region "程序注册定义"

    Public INSTALLED_DIR As String = "\Application\SysCheck.dll"
    Public APPKEY As String = "SchtKenZ"
    Public docno As String = "00000000000000"
    'Public g_OSType As String = "Pocket PC"
    'Public Declare Sub GetMacAddress Lib "\Application\Jusco HHC Program\SchmidtRegKey.dll" (ByVal a As String)
    Public Declare Function DefineSoftwareKey Lib "SchmidtRegKey.dll" (ByVal sSetKey As Byte()) As Integer
    Public Declare Function GenerateKey Lib "SchmidtRegKey.dll" (ByVal sSerialNo As Byte(), ByVal sRegKey As Byte()) As Integer
    Declare Function GetSerialNo Lib "SchmidtRegKey.dll" (ByVal sSerialNo As Byte()) As Integer

    Public Function GetRegKey(ByVal UUid As String) As String

        Dim sstr As String = UUid
        Dim dstr As String = ""
        For i As Integer = 1 To Len(sstr)
            dstr = Mid(sstr, i, 1) + dstr
        Next

        Dim regKey As String = Encryption64.Encrypt(dstr)
        regKey = Mid(regKey.ToUpper, 1, 8)
        Return regKey

    End Function

    ''' <summary>
    ''' 仅在设备是Datalogic时才需要调用厂家的获取函数
    ''' sSymbol的打包到 SchmidtRegKey.dll 里面去了
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetUnitId() As String
        '--------------------------------------
        'strBuffer = Space(60)
        Try
            'GetMacAddress(strBuffer)
            GetUnitId = GetMacAddress()
            Return GetUnitId
        Catch ex As Exception
            Return ""
        End Try
        '--------------------------------------
        'GetUnitId = DllCharToString(strBuffer)
        'GetUnitId = strBuffer
    End Function
    Public Function GetMacAddress() As String
        Dim s As String
        Dim a(1000) As Byte
        On Error Resume Next
        's = Space(100)
        GetSerialNo(a)
        's = Left(s, 17)
        's = Left(System.Text.Encoding.ASCII.GetChars(a), 16)
        s = Left(System.Text.Encoding.ASCII.GetChars(a), 12)
        Return s
    End Function

    Public Function GetTagID(ByVal tag As String) As Integer
        GetTagID = 0
        On Error Resume Next
        GetTagID = CInt(tag)
        On Error GoTo 0
    End Function

    Public Function LookRecTable(ByVal str As String, ByVal rt() As struResTable) As String
        Dim i As Integer
        For i = 0 To UBound(rt)
            If UCase(Trim(str)) = UCase(Trim(rt(i).strText)) Then
                Return rt(i).strVal
            End If
        Next
        Return str
    End Function

#End Region

#Region ""
    'MSV1
    ''' <summary>
    ''' 如果断网了，则自动的重新连接...
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckMSV1()
        'Try
        '    If MSV1.getSvrTime() <> "" Then
        '    Else
        '        MSV1 = New adidasWS.Service1()
        '        MSV1.getSvrTime()
        '    End If
        'Catch ex As Exception
        'End Try
    End Sub
#End Region

#Region "单据状态字定义"

    Public Class state_TaskList
        Public Shared start As String = "01"
        Public Shared scanning As String = "02"
        Public Shared finished As String = "03"
    End Class

    Public Class state_DN
        Public Shared start As String = "01"
        Public Shared scanning As String = "02"
        Public Shared finished As String = "03"
    End Class



#End Region

    Public BARCODELENGTH As Integer = 20
    Public ONE_HUNTRED As Integer = 100
    Public TEN As Integer = 10
    Public alert2Show As Boolean = False
    Public globalbatchno As String = ""

End Module
