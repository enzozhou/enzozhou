Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.ComponentModel
Imports System.Text
Imports System.Data

Module Utility
    Public gsErrorTitle_RuntimeError As String = "运行时错误"
    Public gsAppTitle As String = ""

    Public opCinfig_PWD_OK As Boolean = False
    'Public CertificateKEY As String = "38792289" '****重要提示:本KEY必需与程序里的KEY一致，否则将会存在安全隐患***
    Private Const ERROR_ALREADY_EXISTS As Long = 183
    Public Const SW_FULLSCREEN As Long = &H0
    Public Const SW_NORMALSCREEN As Long = &H1
    Const SHFS_SHOWTASKBAR As Long = &H1
    Const SHFS_HIDETASKBAR As Long = &H2
    Const SHFS_SHOWSIPBUTTON As Long = &H4
    Const SHFS_HIDESIPBUTTON As Long = &H8
    Const SHFS_SHOWSTARTICON As Long = &H10
    Const SHFS_HIDESTARTICON As Long = &H20
    Const SW_HIDE As Long = 0
    Const SW_SHOWNORMAL As Long = 1
    Public Const SW_SHOW As Integer = 5
    'Public gCN As New SqlServerCe.SqlCeConnection
    Private METHOD_BUFFERED As Int32 = 0
    Private FILE_ANY_ACCESS As Int32 = 0
    Private FILE_DEVICE_HAL As Int32 = &H101
    Private Const ERROR_NOT_SUPPORTED As Int32 = &H32
    Private Const ERROR_INSUFFICIENT_BUFFER As Int32 = &H7A
    Private IOCTL_HAL_GET_DEVICEID As Int32 = (&H10000 * FILE_DEVICE_HAL) Or (&H4000 * FILE_ANY_ACCESS) Or (&H4 * 21) Or METHOD_BUFFERED
    Private SPI_GETOEMINFO As System.UInt32
    Private SPI_GETPLATFORMTYPE As System.UInt32 = 257       'Returns a string specifying the type of Windows CE device：说明摘自Microsoft"http://msdn.microsoft.com/en-us/library/ms940383.aspx"
    Private SPI_GETPLATFORMVERSION As System.UInt32 = 258    'Assigns a version number to an OEM OS design：说明摘自Microsoft"http://msdn.microsoft.com/en-us/library/ms940383.aspx"

    Declare Function SystemParametersInfo Lib "Coredll.dll" _
        (ByVal uiAction As System.UInt32, _
        ByVal uiParam As System.UInt32, _
        ByVal pvParam As StringBuilder, _
        ByVal fWinIni As System.UInt32) As Boolean
    Private Structure SYSTEMTIME
        Public wYear As UInt16
        Public wMonth As UInt16
        Public wDayOfWeek As UInt16
        Public wDay As UInt16
        Public wHour As UInt16
        Public wMinute As UInt16
        Public wSecond As UInt16
        Public wMilliseconds As UInt16
    End Structure
    Private Enum PlaySoundFlags
        SND_SYNC = &H0         '  play synchronously (default)
        SND_ASYNC = &H1         '  play asynchronously
        SND_NODEFAULT = &H2         '  silence not default, if sound not found
        SND_MEMORY = &H4         '  lpszSoundName points to a memory file
        SND_LOOP = &H8         '  loop the sound until next sndPlaySound
        SND_NOSTOP = &H10        '  don't stop any currently playing sound
        SND_NOWAIT = &H2000      '  don't wait if the driver is busy
        SND_ALIAS = &H10000     '  name is a WIN.INI [sounds] entry
        SND_ALIAS_ID = &H110000    '  name is a WIN.INI [sounds] entry identifier
        SND_FILENAME = &H20000     '  name is a file name
        SND_RESOURCE = &H40004     '  name is a resource name or atom
    End Enum
    'For BackupBattery
    Private Class SYSTEM_POWER_STATUS_EX2
        Public ACLineStatus As Byte
        Public BatteryFlag As Byte
        Public BatteryLifePercent As Byte
        Public Reserved1 As Byte
        Public BatteryLifeTime As System.UInt32
        Public BatteryFullLifeTime As System.UInt32
        Public Reserved2 As Byte
        Public BackupBatteryFlag As Byte
        Public BackupBatteryLifePercent As Byte
        Public Reserved3 As Byte
        Public BackupBatteryLifeTime As System.UInt32
        Public BackupBatteryFullLifeTime As System.UInt32
        Public BatteryVoltage As System.UInt32
        Public BatteryCurrent As System.UInt32
        Public BatteryAverageCurrent As System.UInt32
        Public BatteryAverageInterval As System.UInt32
        Public BatterymAHourConsumed As System.UInt32
        Public BatteryTemperature As System.UInt32
        Public BackupBatteryVoltage As System.UInt32
        Public BatteryChemistry As Byte
    End Class 'SYSTEM_POWER_STATUS_EX2

    'For MainBattery
    Private Class SYSTEM_POWER_STATUS_EX
        Public ACLineStatus As Byte
        Public BatteryFlag As Byte
        Public BatteryLifePercent As Byte
        Public Reserved1 As Byte
        Public BatteryLifeTime As System.UInt32
        Public BatteryFullLifeTime As System.UInt32
        Public Reserved2 As Byte
        Public BackupBatteryFlag As Byte
        Public BackupBatteryLifePercent As Byte
        Public Reserved3 As Byte
        Public BackupBatteryLifeTime As System.UInt32
        Public BackupBatteryFullLifeTime As System.UInt32
    End Class 'SYSTEM_POWER_STATUS_EX
    ' Defines the System power states
    Private Enum SystemPowerStates As Long
        ' On state.
        On_ = 65536
        ' No power, full off.
        Off = 131072
        ' Critical off.
        Critical = 262144
        ' Boot state.
        Boot = 524288
        ' Idle state.
        Idle = 1048576
        ' Suspend state.
        Suspend = 2097152
        ' Reset state.
        Reset = 8388608
    End Enum

    Private Function CTL_CODE( _
      ByVal DeviceType As Integer, _
      ByVal Func As Integer, _
      ByVal Method As Integer, _
      ByVal Access As Integer) As Integer

        Return (DeviceType << 16) Or (Access << 14) Or (Func << 2) Or Method

    End Function 'CTL_CODE
    Private Function KernelIoControl _
    ( _
        ByVal dwIoControlCode As Integer, _
        ByVal lpInBuf As IntPtr, _
        ByVal nInBufSize As Integer, _
        ByVal lpOutBuf As IntPtr, _
        ByVal nOutBufSize As Integer, _
        ByRef lpBytesReturned As Integer _
    ) As Integer
    End Function
    Public Class ProcessInfo
        Public hProcess As IntPtr
        Public hThread As IntPtr
        Public ProcessId As Int32
        Public ThreadId As Int32
    End Class 'ProcessInfo
    <System.Runtime.InteropServices.DllImport("coredll")> _
      Private Function PlaySound(ByVal szSound As String, ByVal hMod As System.IntPtr, ByVal flags As PlaySoundFlags) As Boolean
    End Function
    'Play sound
    Public Function Play(ByVal strFileName As String) As Boolean
        If System.IO.File.Exists(strFileName) Then
            PlaySound(strFileName, System.IntPtr.Zero, PlaySoundFlags.SND_FILENAME Or PlaySoundFlags.SND_ASYNC)
        End If
    End Function
    <DllImport("coredll")> _
             Private Function GetSystemPowerStatusEx(ByVal lpSystemPowerStatus As SYSTEM_POWER_STATUS_EX, ByVal fUpdate As Boolean) As System.UInt32
    End Function
    <DllImport("coredll")> _
        Private Function SetSystemPowerState(ByVal sState As IntPtr, ByVal StateFlags As System.UInt32, ByVal Options As System.UInt32) As System.UInt32
    End Function
    <DllImport("coredll")> _
    Private Function GetSystemPowerStatusEx2(ByVal lpSystemPowerStatus As SYSTEM_POWER_STATUS_EX2, ByVal dwLen As System.UInt32, ByVal fUpdate As Boolean) As System.UInt32
    End Function
    <DllImport("CoreDll")> _
Public Function ShowWindow(ByVal hwnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
    End Function
    <DllImport("CoreDll")> _
    Public Function FindWindow(ByVal className As String, ByVal WindowsName As String) As IntPtr
    End Function
    Public Function SetForegroundWindow(ByVal hwnd As Integer) As Boolean
    End Function
    <System.Runtime.InteropServices.DllImport("coredll.dll", EntryPoint:="GetLastError")> _
    Public Function GetLastError() As Integer
    End Function
    <System.Runtime.InteropServices.DllImport("coredll.dll", EntryPoint:="CreateMutexW")> _
    Private Function CreateMutex(ByVal lpMutexAttributes As IntPtr, ByVal InitialOwner As Boolean, ByVal MutexName As String) As Integer
    End Function
    <System.Runtime.InteropServices.DllImport("aygshell", EntryPoint:="SHFullScreen")> _
       Private Function SHFullScreen(ByVal hwndRequester As Long, ByVal dwState As Long) As Boolean
    End Function
    <DllImport("coredll.dll")> _
    Private Sub GetSystemTime(ByRef lpSystemTime As SYSTEMTIME)
    End Sub
    <DllImport("coredll.dll")> _
    Private Function SetSystemTime(ByRef lpSystemTime As SYSTEMTIME) As UInt32
    End Function
    <DllImport("aygshell.dll")> _
    Public Function SHFullScreen(ByVal hwndRequester As IntPtr, ByVal dwState As Integer) As Integer
    End Function
    <DllImport("coredll.dll")> _
    Private Function GetCapture() As IntPtr
    End Function

    Private Declare Function CreateProcess Lib "CoreDll.dll" (ByVal imageName As String, ByVal cmdLine As String, ByVal lpProcessAttributes As IntPtr, ByVal lpThreadAttributes As IntPtr, ByVal boolInheritHandles As Int32, ByVal dwCreationFlags As Int32, ByVal lpEnvironment As IntPtr, ByVal lpszCurrentDir As IntPtr, ByVal si As Byte(), ByVal pi As ProcessInfo) As Integer
    Private Declare Function WaitForSingleObject Lib "CoreDll.dll" (ByVal Handle As IntPtr, ByVal Wait As Int32) As Int32
    Private Declare Function CloseHandle Lib "CoreDll.dll" (ByVal Handle As IntPtr) As Int32
    Private Declare Function KernelIoControl Lib "CoreDll.dll" (ByVal dwIoControlCode As Int32, ByVal lpInBuf As IntPtr, ByVal nInBufSize As Int32, ByVal lpOutBuf() As Byte, ByVal nOutBufSize As Int32, ByRef lpBytesReturned As Int32) As Boolean

    Private Declare Function DefineSoftwareKey Lib "SchmidtRegKey.dll" (ByVal sSetKey As Byte()) As Integer
    Private Declare Function GenerateKey Lib "SchmidtRegKey.dll" (ByVal sSerialNo As Byte(), ByVal sRegKey As Byte()) As Integer
    Declare Function GetSerialNo Lib "SchmidtRegKey.dll" (ByVal sSerialNo As Byte()) As Integer

    Function CreateProcessEX(ByVal ExeName As String, ByVal CmdLine As String, ByVal pi As ProcessInfo, ByVal bWaitForSingleObject As Boolean) As Boolean

        Dim INFINITE As Int32
        INFINITE = &HFFFFFFFF
        Try
            Dim WAIT_OBJECT_0 As Int32 = 0
            Dim result As Int32

            If pi Is Nothing Then
                pi = New ProcessInfo
            End If
            Dim si(128) As Byte

            result = CreateProcess(ExeName, CmdLine, IntPtr.Zero, IntPtr.Zero, 0, 0, IntPtr.Zero, IntPtr.Zero, si, pi)
            If 0 = result Then
                Return False
            End If
            If bWaitForSingleObject Then
                result = WaitForSingleObject(pi.hProcess, INFINITE)
                If WAIT_OBJECT_0 <> result Then
                    Return False
                End If
            End If
            CloseHandle(pi.hThread)
            CloseHandle(pi.hProcess)
            Return True
        Catch ex As Exception
            ErrorHandler("Utility", "CreateProcessEX", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function

    Public Function Shell(ByVal sExeName As String, ByVal sCmdLine As String, ByVal bWaitForSingleObject As Boolean) As Boolean
        Try
            Dim pi As New ProcessInfo
            If CreateProcessEX(sExeName, sCmdLine, pi, bWaitForSingleObject) Then
                Shell = True
                'MessageBox.Show(String.Format("Success! Resuming calling application." + ControlChars.Lf + "PID = 0x{0:X8}" + ControlChars.Lf + "({0})", pi.ProcessId), "Done Waiting...")
            Else
                Shell = False
                'MessageBox.Show(String.Format("Failed!" + ControlChars.Lf + "System Error = 0x{0:X8}" + ControlChars.Lf + "({0})", GetLastError()), "Done waiting...")
            End If
        Catch ex As Exception
            ErrorHandler("Utility", "Shell", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function

    '    <DllImport("coredll", SetLastError:=True)> _
    'Public Shared Sub keybd_event(ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    '    End Sub
    '模拟键盘动作,模拟鼠标动作

    Public Function HideStartIcon() As Boolean
        Dim hwnd As IntPtr = GetCapture()
        SHFullScreen(hwnd, SHFS_HIDESTARTICON)
    End Function
    Public Function ShowStartIcon() As Boolean
        Dim hwnd As IntPtr = GetCapture()
        SHFullScreen(hwnd, SHFS_SHOWSTARTICON + SHFS_SHOWTASKBAR)
    End Function

    Public Function SetLocalSystemTime(ByVal dDate As String) As Boolean
        'Set the clock ahead one hour
        Microsoft.VisualBasic.Today = CDate(dDate)
        Microsoft.VisualBasic.TimeOfDay = CDate(dDate)
        'Dim st As New SYSTEMTIME
        'Dim nHour As Integer
        'nHour = Convert.ToInt16(Microsoft.VisualBasic.Hour(CDate(dDate)))
        'SetLocalSystemTime = False
        'st.wYear = Convert.ToUInt16(Microsoft.VisualBasic.Year(CDate(dDate)))
        'st.wMonth = Convert.ToUInt16(Microsoft.VisualBasic.Month(CDate(dDate)))
        'st.wDay = Convert.ToUInt16(Microsoft.VisualBasic.Day(CDate(dDate)))
        'st.wHour = Convert.ToUInt16(nHour)   ' Convert.ToUInt16(Hour(dDate))
        'st.wMinute = Convert.ToUInt16(Microsoft.VisualBasic.Minute(CDate(dDate)))
        'st.wSecond = Convert.ToUInt16(Microsoft.VisualBasic.Second(CDate(dDate)))
        'SetSystemTime(st)
        SetLocalSystemTime = True
    End Function

    Public Function GetDeviceID() As String
        GetDeviceID = ""
        Try
            ' Initialize the output buffer to the size of a Win32 DEVICE_ID structure
            Dim outbuff(19) As Byte
            Dim dwOutBytes As Int32
            Dim done As Boolean = False

            Dim nBuffSize As Int32 = outbuff.Length
            ' Set DEVICEID.dwSize to size of buffer.  Some platforms look at
            ' this field rather than the nOutBufSize param of KernelIoControl
            ' when determining if the buffer is large enough.
            '
            BitConverter.GetBytes(nBuffSize).CopyTo(outbuff, 0)
            dwOutBytes = 0

            ' Loop until the device ID is retrieved or an error occurs
            '
            While Not done
                If KernelIoControl(IOCTL_HAL_GET_DEVICEID, IntPtr.Zero, 0, outbuff, nBuffSize, dwOutBytes) Then
                    done = True
                Else
                    Dim [error] As Integer = Marshal.GetLastWin32Error()
                    Select Case [error]
                        Case ERROR_NOT_SUPPORTED
                            Throw New NotSupportedException("IOCTL_HAL_GET_DEVICEID is not supported on this device", New Win32Exception([error]))

                        Case ERROR_INSUFFICIENT_BUFFER
                            ' The buffer is not big enough for the data.  The required size 
                            ' is in the first 4 bytes of the output buffer (DEVICE_ID.dwSize).
                            nBuffSize = BitConverter.ToInt32(outbuff, 0)
                            outbuff = New Byte(nBuffSize) {}
                            ' Set DEVICEID.dwSize to size of buffer.  Some
                            ' platforms look at this field rather than the
                            ' nOutBufSize param of KernelIoControl when
                            ' determining if the buffer is large enough.
                            BitConverter.GetBytes(nBuffSize).CopyTo(outbuff, 0)
                        Case Else
                            Throw New Win32Exception([error], "Unexpected error")
                    End Select
                End If
            End While

            Dim dwPresetIDOffset As Int32 = BitConverter.ToInt32(outbuff, &H4)  ' DEVICE_ID.dwPresetIDOffset
            Dim dwPresetIDSize As Int32 = BitConverter.ToInt32(outbuff, &H8)    ' DEVICE_ID.dwPresetIDSize
            Dim dwPlatformIDOffset As Int32 = BitConverter.ToInt32(outbuff, &HC) ' DEVICE_ID.dwPlatformIDOffset
            Dim dwPlatformIDSize As Int32 = BitConverter.ToInt32(outbuff, &H10) ' DEVICE_ID.dwPlatformIDBytes
            Dim sb As New StringBuilder
            Dim i As Integer

            For i = dwPresetIDOffset To (dwPresetIDOffset + dwPresetIDSize) - 1
                sb.Append(String.Format("{0:X2}", outbuff(i)))
            Next i
            sb.Append("-")
            For i = dwPlatformIDOffset To (dwPlatformIDOffset + dwPlatformIDSize) - 1
                sb.Append(String.Format("{0:X2}", outbuff(i)))
            Next i
            Return sb.ToString()

        Catch ex As Exception
            ErrorHandler("Utility", "GetDeviceID", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function

    Public Function IsInstanceRunning() As Boolean
        Try
            Dim appname As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
            If CreateMutex(IntPtr.Zero, True, appname) <> 0 Then
                If GetLastError() = ERROR_ALREADY_EXISTS Then
                    IsInstanceRunning = True
                Else
                    IsInstanceRunning = False
                End If
            End If

        Catch ex As Exception
            ErrorHandler("Utility", "IsInstanceRunning", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function 'IsInstanceRunning


    Public Function AppPath() As String
        AppPath = ""
        Try
            AppPath = System.IO.Path.GetDirectoryName(Reflection.Assembly. _
              GetExecutingAssembly().GetName().CodeBase.ToString())
        Catch ex As Exception
            ErrorHandler("Utility", "AppPath", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function

    Public Function AddDateFlag(ByVal DateNoFlag As String) As String
        AddDateFlag = Mid(DateNoFlag, 1, 4) & "/" & Mid(DateNoFlag, 5, 2) & "/" & Mid(DateNoFlag, 7, 2)
    End Function
    '写入数据到本地文本文件
    Public Function WriteDataToFile(ByVal sFileName As String, ByVal sDate As String, ByVal FM As FileMode) As Boolean
        Try
            Dim sw As StreamWriter
            WriteDataToFile = False
            Dim fns As FileStream = New FileStream(sFileName, FM)
            sw = New StreamWriter(fns)
            sw.WriteLine(sDate)
            sw.Close()
            WriteDataToFile = True
            sw = Nothing
        Catch ex As Exception
            ErrorHandler("Utility", "WriteDataToFile", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function
    Public Function DelFile(ByVal sFileName As String) As Boolean
        Try
            If File.Exists(sFileName) Then
                File.Delete(sFileName)
            End If
            DelFile = True
        Catch ex As Exception
            ErrorHandler("Utility", "DelFile", gsErrorTitle_RuntimeError, "", ex.Message)
            DelFile = False
        End Try

    End Function

    Public Function GetString(ByVal sString As String, ByVal nNo As Integer, ByVal Segregator As String) As String
        GetString = ""
        Try
            Dim vResult As String()
            If nNo <= 0 Then
                GetString = ""
                Exit Function
            End If
            vResult = Split(sString, Segregator)
            If nNo - 1 > UBound(vResult) Then
                GetString = ""
            Else
                GetString = vResult(nNo - 1)
            End If
        Catch ex As Exception
            ErrorHandler("Utility", "GetString", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function


    Public Function CheckNumber(ByVal strNumber As String) As Boolean
        Try
            Dim i As Integer
            Dim bFoundStr As Boolean
            CheckNumber = False
            If Len(strNumber) > 0 Then
                bFoundStr = False
                For i = 1 To Len(strNumber)
                    If InStr(1, "1234567890", Mid(strNumber, i, 1)) = 0 Then
                        bFoundStr = True
                        Exit For
                    End If
                Next i
                If bFoundStr = True Then
                    CheckNumber = False
                Else
                    CheckNumber = True
                End If
            Else
                CheckNumber = False
            End If
        Catch ex As Exception
            ErrorHandler("Utility", "CheckNumber", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function

    Public Function CheckEnglishWords(ByVal strWords As String) As Boolean
        Try
            Dim i As Integer
            Dim bFoundStr As Boolean
            CheckEnglishWords = False

            If Len(strWords) > 0 Then
                bFoundStr = False
                For i = 1 To Len(strWords)
                    If InStr(1, "qwertyuiopasdfghjklzxcvbnm-1234567890", Mid(LCase(strWords), i, 1)) = 0 Then
                        bFoundStr = True
                        Exit For
                    End If
                Next i
                If bFoundStr = True Then
                    CheckEnglishWords = False
                Else
                    CheckEnglishWords = True
                End If
            Else
                CheckEnglishWords = False
            End If
        Catch ex As Exception
            ErrorHandler("Utility", "CheckEnglishWords", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function

    Public Function AutoAddAndMark(ByVal Str As String) As String
        AutoAddAndMark = ""
        Try
            Const AndMark As String = "&"
            Dim sOut As String
            Dim nPos As Integer
            sOut = ""
            nPos = InStr(Str, AndMark)
            Do While nPos > 0
                sOut = sOut & Left(Str, nPos) & AndMark
                Str = Mid$(Str, nPos + 1)
                nPos = InStr(Str, AndMark)
            Loop
            AutoAddAndMark = sOut & Str
        Catch ex As Exception
            ErrorHandler("Utility", "AutoAddAndMark", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function

    Public Function DelSingleQuotationMark(ByVal Str As String) As String      'delete the character of "'"
        DelSingleQuotationMark = ""
        Try
            Const DEli As String = "'"
            Dim sOut As String
            Dim nPos As Integer
            sOut = ""
            nPos = InStr(Str, DEli)
            Do While nPos > 0
                sOut = sOut & Left$(Str, nPos) & DEli
                Str = Mid$(Str, nPos + 1)
                nPos = InStr(Str, DEli)
            Loop
            DelSingleQuotationMark = sOut & Str
        Catch ex As Exception
            ErrorHandler("Utility", "DelSingleQuotationMark", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function


    Public Function SpaceStr(ByVal Lenth As Long) As String
        '因为EVB中没有Space函数,所以写了这个函数来返回指定长度的空格
        Dim strTemp As String
        Dim lngI As Long

        strTemp = ""

        For lngI = 1 To Lenth
            strTemp = strTemp & " "
        Next

        SpaceStr = strTemp
    End Function
    Public Function PadR(ByVal Variable As String, ByVal length As Integer) As String

        If Len(Variable) >= length Then
            PadR = Variable
        Else
            PadR = Variable & SpaceStr(length - Len(Variable))
        End If
        'PadR = Mid(Variable & SpaceStr(nLength), 1, IIf(Len(Variable) > nLength, Len(Variable), nLength))
    End Function
    Public Function PadL(ByVal Variable As String, ByVal length As Integer) As String

        If Len(Variable) >= length Then
            PadL = Variable
        Else
            PadL = SpaceStr(length - Len(Variable)) & Variable
        End If
    End Function


    Function Sync_Clock_From_Server(ByRef dt_Data As DataTable, ByVal nType As Integer) As Boolean
        Try
            If dt_Data.Rows.Count > 0 Then
                If IsDate(dt_Data.Rows(0).Item("ServerDateTime")) Then
                    SetLocalSystemTime(dt_Data.Rows(0).Item("ServerDateTime").ToString)
                End If
            End If
        Catch ex As Exception
            ErrorHandler("Utility", "Sync_Clock_From_Server", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function

    Public Function ConvertToUnicode(ByVal sSourceString As String) As String
        Dim ByteTemp() As Byte = System.Text.Encoding.ASCII.GetBytes(" " & sSourceString)
        ConvertToUnicode = System.Text.Encoding.Default.GetString(ByteTemp, 0, ByteTemp.Length)
    End Function

    Public Function GetNetworkInfo() As String
        GetNetworkInfo = ""
        Try
            Dim MYIP As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)
            GetNetworkInfo = GetNetworkInfo & "Device Name:" & MYIP.HostName.ToString & vbCrLf
            GetNetworkInfo = GetNetworkInfo & "IP:" & MYIP.AddressList.GetValue(0).ToString & vbCrLf

        Catch ex As Exception

        End Try
    End Function
    Public Function PowerSuspend() As String
        PowerSuspend = ""
        Try
            If Convert.ToInt32(SetSystemPowerState(IntPtr.Zero, Convert.ToUInt32(SystemPowerStates.Suspend), Convert.ToUInt32(0))) = 1 Then
                'Do some further work here
            End If
        Catch ex As Exception
            ErrorHandler("Utility", "PowerSuspend", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try

    End Function




    Public Function SaveLoginUserInfo(ByVal sUser As String, ByVal sPWD As String) As Boolean
        Dim sSetup As String
        If System.IO.File.Exists("\Windows\system.dat") Then
            System.IO.File.Delete("\Windows\system.dat")
        End If

        sSetup = "User=" & sUser
        WriteDataToFile("\Windows\system.dat", sSetup, IO.FileMode.Append)
        sSetup = "Password=" & sPWD
        WriteDataToFile("\Windows\system.dat", sSetup, IO.FileMode.Append)
    End Function
    Public Function GetLoginUserInfo(ByRef sUser As String, ByRef sPWD As String) As Boolean
        Try
            Dim sTemp As String
            Dim sr As System.IO.StreamReader
            sUser = ""
            sPWD = ""
            If System.IO.File.Exists("\Windows\system.dat") Then
                sr = System.IO.File.OpenText("\Windows\system.dat")
                While sr.Peek <> -1
                    sTemp = sr.ReadLine
                    If Len(sTemp) > 1 And InStr(1, sTemp, "=") > 0 Then
                        Select Case UCase(GetString(sTemp, 1, "="))
                            Case "USER"
                                sUser = GetString(sTemp, 2, "=")
                            Case "PASSWORD"
                                sPWD = GetString(sTemp, 2, "=")
                        End Select
                    End If
                End While
                sr.Close()
                sr = Nothing
            End If
        Catch ex As Exception
            ErrorHandler("Utility", "GetLoginUserInfo", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function

    Public Function ResetPocketPC() As Integer
        Try
            Dim bytesReturned As Integer = 0
            Dim IOCTL_HAL_REBOOT As Integer = CTL_CODE(FILE_DEVICE_HAL, _
              15, METHOD_BUFFERED, FILE_ANY_ACCESS)
            Return KernelIoControl(IOCTL_HAL_REBOOT, IntPtr.Zero, 0, _
              IntPtr.Zero, 0, bytesReturned)
        Catch ex As Exception
            ErrorHandler("Utility", "ResetPocketPC", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function 'ResetPocketPC

    Public Function ActiveFormIfBeload(ByVal sFormTitle As String) As Boolean
        Dim ptr1 As IntPtr = FindWindow(Nothing, sFormTitle)
        Try
            If (ptr1.ToInt32 <> 0) Then
                ShowWindow(ptr1, 1)
                SetForegroundWindow(ptr1.ToInt32)
            End If
            ActiveFormIfBeload = True
        Catch ex As Exception
            ActiveFormIfBeload = False
        End Try
    End Function

    Private Sub AddGridStyle(ByRef myGrid As DataGrid, ByVal sMappingName As String, ByVal sHeadString As String)
        Dim style1 As New DataGridTableStyle
        Dim i As Integer
        myGrid.TableStyles.Clear()
        Dim textArray1 As String() = Split(sHeadString, "|", -1, 0)
        style1.MappingName = sMappingName
        Try
            Dim column1 As DataGridTextBoxColumn
            For i = 0 To UBound(textArray1)
                If textArray1(i) <> "" Then
                    column1 = New DataGridTextBoxColumn
                    column1.MappingName = GetString(textArray1(i), 1, "^")
                    column1.HeaderText = GetString(textArray1(i), 2, "^")
                    If GetString(textArray1(i), 3, "^") <> "" Then
                        column1.Width = CInt(Val(GetString(textArray1(i), 3, "^")))
                        style1.GridColumnStyles.Add(column1)
                    Else
                        column1.Width = 50 'Default
                        style1.GridColumnStyles.Add(column1)
                    End If
                End If
            Next i
            myGrid.TableStyles.Add(style1)
            column1 = Nothing
        Catch ex As Exception

            ErrorHandler("Utility", "AddGridStyle", gsErrorTitle_RuntimeError, "", ex.Message)

        End Try
    End Sub

    Public Function GetDataFromTextFile(ByVal sFileName As String) As String
        GetDataFromTextFile = ""
        Try
            Dim text1 As String = ""
            If File.Exists(sFileName) Then
                Dim reader1 As StreamReader = File.OpenText(sFileName)
                'Dim reader1 As StreamReader = New System.IO.StreamReader(sFileName, System.Text.Encoding.Default)
                Do While (reader1.Peek <> -1)
                    Dim text2 As String = reader1.ReadLine
                    text1 = (text1 & text2 & vbCrLf)
                Loop
                reader1.Close()
                reader1 = Nothing
            End If
            Return text1
        Catch ex As Exception
            ErrorHandler("Utility", "GetDataFromTextFile", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function

    Public Function WriteDataToTextFile(ByVal sFileName As String, ByVal sData As String) As Boolean
        Try
            WriteDataToTextFile = False
            If File.Exists(sFileName) Then
                File.Delete(sFileName)
            End If
            If WriteDataToFile(sFileName, sData, FileMode.Append) Then
                WriteDataToTextFile = True
            End If

        Catch ex As Exception
            ErrorHandler("Utility", "WriteDataToTextFile", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Function

    Private Function ControlFromName(ByVal frm As Form, ByVal name As String) As Control
        Dim o As Object
        o = frm.GetType().GetField(name, Reflection.BindingFlags.NonPublic Or _
          Reflection.BindingFlags.Instance Or _
          Reflection.BindingFlags.IgnoreCase).GetValue(frm)
        Return (CType(o, Control))
    End Function


    Public Function Delay(ByVal nPauseTime As Double) As Boolean
        Dim nStartTime As Double
        nStartTime = Microsoft.VisualBasic.Timer
        Do While Microsoft.VisualBasic.Timer < nStartTime + nPauseTime
            Application.DoEvents()
        Loop
    End Function

    Public Function ErrorHandler(ByVal sProgName As String, ByVal sProcName As String, ByVal sErrorTitle As String, ByVal sErrNumber As String, ByVal sErrDesc As String) As Boolean
        Try
            WriteErrorToLogFile(sProgName, sProcName, sErrNumber, sErrDesc, AppPath() & "\error.log")
            MsgBox(sErrDesc, MsgBoxStyle.Critical Or MsgBoxStyle.OkOnly, gsAppTitle)
        Catch ex As Exception
        End Try
    End Function

    Private Sub WriteErrorToLogFile(ByVal sProgName As String, ByVal sProcName As String, ByVal lErrNumber As String, ByVal sErrDesc As String, ByVal sFile As String)
        Try
            Dim sw As New System.IO.StreamWriter(sFile, True, System.Text.Encoding.Default)
            sw.WriteLine(Now.ToString & vbTab & UCase(MDI_userid) & vbTab & sProgName & vbTab & sProcName & vbTab & lErrNumber & vbTab & sErrDesc & vbTab)
            sw.Close()
            sw = Nothing
        Catch ex As Exception
            ErrorHandler("Utility", "WriteErrorToLogFile", gsErrorTitle_RuntimeError, "", ex.Message)
        End Try
    End Sub

End Module
