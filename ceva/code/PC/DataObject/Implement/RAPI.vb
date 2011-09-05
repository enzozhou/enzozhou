
Imports System
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading
Imports System.IO
Imports System.Collections

Namespace RemoteCe
    Public Class CE_FIND_DATA
        Private data As Byte() = New Byte(1024) {}
        Public Function GetData() As Byte()
            Return data
        End Function
        Public ReadOnly Property FileAttributes() As Integer
            Get
                Return BitConverter.ToInt32(data, 0)
            End Get
        End Property
        Public ReadOnly Property CreateTime() As DateTime
            Get
                Dim time As Long = BitConverter.ToInt64(data, 4)
                Return DateTime.FromFileTime(time)
            End Get
        End Property
        Public ReadOnly Property LastAccessTime() As DateTime
            Get
                Dim time As Long = BitConverter.ToInt64(data, 12)
                Return DateTime.FromFileTime(time)
            End Get
        End Property
        Public ReadOnly Property LastWriteTime() As DateTime
            Get
                Dim time As Long = BitConverter.ToInt64(data, 20)
                Return DateTime.FromFileTime(time)
            End Get
        End Property
        Public ReadOnly Property FileSize() As Long
            Get
                Return BitConverter.ToInt32(data, 28) + (BitConverter.ToInt32(data, 32) << 32)
            End Get
        End Property
        Public ReadOnly Property FileName() As String
            Get
                Return Encoding.Unicode.GetString(data, 40, 256).TrimEnd(Chr(0))
            End Get
        End Property
    End Class

    Public Structure STORE_INFORMATION
        Public dwStoreSize As Integer
        Public dwFreeSize As Integer
    End Structure

    Public Enum PlatformType As Integer
        VER_PLATFORM_WIN32_CE = 3
    End Enum

    Public Structure OSVERSIONINFO
        Public dwOSVersionInfoSize As Integer
        Public dwMajorVersion As Integer
        Public dwMinorVersion As Integer
        Public dwBuildNumber As Integer
        Public dwPlatformId As PlatformType
    End Structure

    Public Enum DeviceCaps As Short
        HorizontalSize = 4
        VerticalSize = 6
        HorizontalResolution = 8
        VerticalResolution = 10
        BitsPerPixel = 12
    End Enum

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure MEMORYSTATUS
        Public dwLength As Integer
        Public dwMemoryLoad As Integer
        Public dwTotalPhys As Integer
        Public dwAvailPhys As Integer
        Public dwTotalPageFile As Integer
        Public dwAvailPageFile As Integer
        Public dwTotalVirtual As Integer
        Public dwAvailVirtual As Integer
    End Structure

    Public Structure SYSTEM_POWER_STATUS_EX
        Public ACLineStatus As Byte
        Public BatteryFlag As Byte
        Public BatteryLifePercent As Byte
        Public Reserved1 As Byte
        Public BatteryLifeTime As Integer
        Public BatteryFullLifeTime As Integer
        Public Reserved2 As Byte
        Public BackupBatteryFlag As Byte
        Public BackupBatteryLifePercent As Byte
        Public Reserved3 As Byte
        Public BackupBatteryLifeTime As Integer
        Public BackupBatteryFullLifeTime As Integer
    End Structure

    Public Enum ProcessorArchitecture As Short
        Intel = 0
        MIPS = 1
        Alpha = 2
        PPC = 3
        SHX = 4
        ARM = 5
        IA64 = 6
        Alpha64 = 7
        Unknown = -1
    End Enum

    Public Enum ProcessorType As Integer
        PROCESSOR_INTEL_386 = 386
        PROCESSOR_INTEL_486 = 486
        PROCESSOR_INTEL_PENTIUM = 586
        PROCESSOR_INTEL_PENTIUMII = 686
        PROCESSOR_INTEL_IA64 = 2200
        PROCESSOR_MIPS_R4000 = 4000
        PROCESSOR_ALPHA_21064 = 21064
        PROCESSOR_PPC_403 = 403
        PROCESSOR_PPC_601 = 601
        PROCESSOR_PPC_603 = 603
        PROCESSOR_PPC_604 = 604
        PROCESSOR_PPC_620 = 620
        PROCESSOR_HITACHI_SH3 = 10003
        PROCESSOR_HITACHI_SH3E = 10004
        PROCESSOR_HITACHI_SH4 = 10005
        PROCESSOR_MOTOROLA_821 = 821
        PROCESSOR_SHx_SH3 = 103
        PROCESSOR_SHx_SH4 = 104
        PROCESSOR_STRONGARM = 2577
        PROCESSOR_ARM720 = 1824
        PROCESSOR_ARM820 = 2080
        PROCESSOR_ARM920 = 2336
        PROCESSOR_ARM_7TDMI = 70001
    End Enum

    Public Structure SYSTEM_INFO
        Public wProcessorArchitecture As ProcessorArchitecture
        Public wReserved As UInt16
        Public dwPageSize As Integer
        Public lpMinimumApplicationAddress As Integer
        Public lpMaximumApplicationAddress As Integer
        Public dwActiveProcessorMask As Integer
        Public dwNumberOfProcessors As Integer
        Public dwProcessorType As ProcessorType
        Public dwAllocationGranularity As Integer
        Public wProcessorLevel As Short
        Public wProcessorRevision As Short
    End Structure

    Public Enum SystemFolders
        Personal = 5
        Programs = 2
        Favorites = 6
        StartUp = 7
        Recent = 8
        Desktop = 16
        Fonts = 20
    End Enum

    Public Class RAPI
        Public Const CREATE_NEW As Short = 1
        Public Const CREATE_ALWAYS As Short = 2
        Public Const GENERIC_WRITE As Integer = &H40000000
        Public Const GENERIC_READ As Integer = CType(&H80000000, Integer)
        Public Const OPEN_EXISTING As Short = 3
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure RAPIINIT
            Public cbSize As Integer
            Public heRapiInit As Integer
            Public hrRapiInit As Integer
        End Structure
        <StructLayout(LayoutKind.Sequential)> _
        Public Structure PROCESS_INFORMATION
            Public hProcess As Integer
            Public hThread As Integer
            Public dwProcessID As Integer
            Public dwThreadID As Integer
            Public Sub New(ByVal NewInstance As Boolean)
                hProcess = 0
                hThread = 0
                dwProcessID = 0
                dwThreadID = 0
            End Sub
        End Structure
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeCreateFile(ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, ByVal lpSecurityAttributes As Integer, ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, _
         ByVal hTemplateFile As Integer) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeRapiInitEx(<MarshalAs(UnmanagedType.Struct)> ByRef pRapiInit As RAPIINIT) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeRapiInit() As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeRapiUninit() As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeWriteFile(ByVal hFile As Integer, ByVal lpBuffer As Byte(), ByVal nNumberOfbytesToWrite As Integer, ByRef lpNumberOfbytesWritten As Integer, ByVal lpOverlapped As Integer) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeCopyFile(ByVal lpExistingFileName As String, ByVal lpNewFileName As String, ByVal bFailIfExists As Integer) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeDeleteFile(ByVal lpFileName As String) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeMoveFile(ByVal lpExistingFileName As String, ByVal lpNewFileName As String) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeGetFileAttributes(ByVal lpFileName As String) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeSetFileAttributes(ByVal lpFileName As String, ByVal dwFileAttributes As Integer) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeRemoveDirectory(ByVal lpPathName As String) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeCreateDirectory(ByVal lpPathName As String, ByVal lpSecurityAttributes As Integer) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeGetFileSize(ByVal hFile As Integer, ByRef lpFileSizeHigh As Integer) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeCloseHandle(ByVal hObject As Integer) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeGetFileTime(ByVal hFile As Integer, ByRef lpCreationTime As Long, ByRef lpLastAccessTime As Long, ByRef lpLastWriteTime As Long) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode)> _
        Public Shared Function CeSetFileTime(ByVal hFile As Integer, ByRef lpCreationTime As Long, ByRef lpLastAccessTime As Long, ByRef lpLastWriteTime As Long) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeGetLastError() As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeReadFile(ByVal hFile As Integer, ByVal lpBuffer As Byte(), ByVal nNumberOfbytesToRead As Integer, ByRef lpNumberOfbytesRead As Integer, ByVal lpOverlapped As Integer) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeCreateProcess(ByVal pszImageName As String, ByVal pszCmdLine As String, ByVal psaProcess As Integer, ByVal psaThread As Integer, ByVal fInheritHandles As Integer, ByVal fdwCreate As Integer, _
         ByVal pvEnvironment As Integer, ByVal pszCurDir As Integer, ByVal psiStartInfo As Integer, ByVal pi As PROCESS_INFORMATION) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeRapiInvoke(ByVal pDllPath As String, ByVal pFunctionName As String, ByVal cbInput As Integer, ByVal pInput As Integer, ByRef pcbOutput As Integer, ByRef ppOutput As Integer, _
         ByVal ppIRAPIStream As Integer, ByVal dwReserved As Integer) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeFindFirstFile(ByVal lpFileName As String, ByVal lpFindFileData As Byte()) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeFindNextFile(ByVal hFindFile As Integer, ByVal lpFindFileData As Byte()) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeFindClose(ByVal hFindFile As Integer) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeSetEndOfFile(ByVal hFile As Integer) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeGetSystemInfo(ByRef pSI As SYSTEM_INFO) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeGetStoreInformation(ByRef lpsi As STORE_INFORMATION) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeGetSystemPowerStatusEx(ByRef pStatus As SYSTEM_POWER_STATUS_EX, ByVal fUpdate As Boolean) As Boolean
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeGetSpecialFolderPath(ByVal nFolder As Integer, ByVal nBufferLength As Integer, ByVal lpBuffer As StringBuilder) As Integer
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeGetVersionEx(ByRef lpVersionInformation As OSVERSIONINFO) As Boolean
        End Function
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Sub CeGlobalMemoryStatus(ByRef msce As MEMORYSTATUS)
        End Sub
        <DllImport("rapi.dll", CharSet:=CharSet.Unicode, SetLastError:=True)> _
        Public Shared Function CeGetDesktopDeviceCaps(ByVal nIndex As Integer) As Integer
        End Function
    End Class
End Namespace
