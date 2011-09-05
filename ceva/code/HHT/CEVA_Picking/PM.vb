Imports System.Threading
Imports System.Runtime.InteropServices
Imports System.Text

Public Class PowerManagement
    Implements IDisposable


#Region "------------------Enumerations--------------------"

    ' Defines the System power states
    Public Enum SystemPowerStates As Long

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

    ' Defines the System power requirement flags
    Public Enum PowerReqFlags As Long

        POWER_NAME = 1

        POWER_FORCE = 4096

    End Enum

    ' Defines the Device power states
    Public Enum DevicePowerStates As Long

        PwrDeviceUnspecified = -1

        FullOn = 0      ' Full On: full power,  full functionality

        D0 = FullOn

        LowOn           ' Low Power On: fully functional at low power/performance

        D1 = LowOn

        StandBy         ' Standby: partially powered with automatic wake

        D2 = StandBy

        Sleep           ' Sleep: partially powered with device initiated wake

        D3 = Sleep

        Off             ' Off: unpowered

        D4 = Off

        PwrDeviceMaximum

    End Enum

    ' Defines the Power Status message type.
    Public Enum MessageTypes As Long

        ' System power state transition.
        Transition = 1

        ' Resume from previous state
        Resume_ = 2

        ' Power supply switched to/from AC/DC.
        Change = 4

        ' A member of the POWER_BROADCAST_POWER_INFO structure has changed.
        Status = 8

    End Enum

    ' Defines the AC power status flags.
    Public Enum ACLineStatus As Byte

        ' AC power is offline.
        Offline = 0

        ' AC power is online. 
        OnLine = 1

        ' AC line status is unknown.
        Unknown = 255

    End Enum

    ' Defines the Battery charge status flags.
    Public Enum BatteryFlags As Byte

        ' High
        High = 1

        ' Low
        Low = 2

        ' Critical
        Critical = 4

        ' Charging
        Charging = 8

        ' Reserved1
        Reserved1 = 16

        ' Reserved2
        Reserved2 = 32

        ' Reserved3
        Reserved3 = 64

        ' No system battery
        NoBattery = 128

        ' Unknown status
        Unknown = High Or Low Or Critical Or Charging Or Reserved1 Or Reserved2 Or Reserved3 Or NoBattery

    End Enum

    ' Responses from WaitForMultipleObjects function.
    Private Enum Wait As Integer

        ' The state of the specified object is signaled.
        Object_ = 0

        ' Wait abandoned.
        Abandoned = 128

        ' Wait failed.
        Failed = -1

    End Enum

#End Region

#Region "--------------------Members-----------------------"

    ' Indicates that an application would like to receive all types of 
    ' power notifications.
    Private Const POWER_NOTIFY_ALL As Long = 4294967295

    ' Indicates an infinite wait period
    Private Const INFINITE As Integer = -1

    ' Allocate message buffers on demand and free the message buffers 
    ' after they are read.
    Private Const MSGQUEUE_NOPRECOMMIT As Integer = 1

    ' Event to wake up the worker thread so that it can close
    Private powerThreadAbort As AutoResetEvent

    ' Flag requesting worker thread closure
    Private abortPowerThread As Boolean = False

    ' Flag to indicate that the worker thread is running
    Private powerThreadRunning As Boolean = False

    ' Thread interface queue
    Private powerQueue As Queue

    ' Handle returned from RequestPowerNotifications
    Private hMsgQ As IntPtr = IntPtr.Zero

    ' Handle returned from RequestPowerNotifications
    Private hReq As IntPtr = IntPtr.Zero

    ' Boolean used to indicate if the object has been disposed
    Private bDisposed As Boolean = False

    ' Occurs when there is some PowerNotify information available.
    Public Event PowerNotify As System.EventHandler

#End Region

#Region "-------------------Structures---------------------"

    ' Contains information about a message queue.
    <CLSCompliant(False)> _
    <StructLayout(LayoutKind.Sequential)> _
     Public Structure MessageQueueOptions

        ' Size of the structure in bytes.
        Public Size As System.UInt32

        ' Describes the behavior of the message queue. Set to MSGQUEUE_NOPRECOMMIT to 
        ' allocate message buffers on demand and to free the message buffers after 
        ' they are read, or set to MSGQUEUE_ALLOW_BROKEN to enable a read or write 
        ' operation to complete even if there is no corresponding writer or reader present.
        Public Flags As System.UInt32

        ' Number of messages in the queue.
        Public MaxMessages As System.UInt32

        ' Number of bytes for each message, do not set to zero.
        Public MaxMessage As System.UInt32

        ' Set to TRUE to request read access to the queue. Set to FALSE to request write 
        ' access to the queue.
        Public ReadAccess As System.UInt32

    End Structure

    ' Contains information about the power status of the system  
    ' as received from the Power Status message queue.
    <CLSCompliant(False)> _
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure PowerInfo

        ' Defines the event type.
        Public Message As System.UInt32 'MessageTypes

        ' One of the system power flags.
        Public Flags As System.UInt32 'SystemPowerStates

        ' The byte count of SystemPowerState that follows.
        Public Length As System.UInt32

        ' Levels available in battery flag fields
        Public NumLevels As System.UInt32

        ' Number of seconds of battery life remaining, 
        ' or 0xFFFFFFFF if remaining seconds are unknown.
        Public BatteryLifeTime As System.UInt32

        ' Number of seconds of battery life when at full charge, 
        ' 0xFFFFFFFF if full battery lifetime is unknown.
        Public BatteryFullLifeTime As System.UInt32

        ' Number of seconds of backup battery life remaining, 
        ' or BATTERY_LIFE_UNKNOWN if remaining seconds are unknown.
        Public BackupBatteryLifeTime As System.UInt32

        ' Number of seconds of backup battery life when at full charge, 
        ' or BATTERY_LIFE_UNKNOWN if full battery lifetime is unknown.
        Public BackupBatteryFullLifeTime As System.UInt32

        ' AC power status. 
        Public ACLineStatus As ACLineStatus

        ' Battery charge status.
        Public BatteryFlag As BatteryFlags

        ' Percentage of full battery charge remaining. 
        ' This member can be a value in the range 0 (zero) to 100, or 255 
        ' if the status is unknown. All other values are reserved.
        Public BatteryLifePercent As Byte

        ' Backup battery charge status. 
        Public BackupBatteryFlag As Byte

        ' Percentage of full backup battery charge remaining. 
        ' This value must be in the range of 0 to 100, or BATTERY_PERCENTAGE_UNKNOWN.
        Public BackupBatteryLifePercent As Byte

    End Structure

#End Region

#Region "---------------------Methods----------------------"

    ' Ensures that resources are freed when the garbage collector reclaims the object.
    Protected Overrides Sub Finalize()

        Dispose()

        MyBase.Finalize()

    End Sub

    ' Releases the resources used by the object.
    Public Sub Dispose() Implements IDisposable.Dispose

        If Not bDisposed Then

            ' Try disabling notifications and ending the thread
            DisableNotifications()

            bDisposed = True

            ' SupressFinalize to take this object off the finalization queue 
            ' and prevent finalization code for this object from executing a second time.
            GC.SuppressFinalize(Me)

        End If

    End Sub

    ' Sets the system power state to the requested value. Should be used with extreme care 
    ' since it may result in an unexpected application or system behavior.
    Public Function SetSystemPowerState(ByVal systemState As SystemPowerStates) As Integer

        Dim nError As System.UInt32 = Convert.ToUInt32(0)

        nError = CESetSystemPowerState(IntPtr.Zero, Convert.ToUInt32(systemState), Convert.ToUInt32(0))

        Return CInt(Convert.ToInt32(nError))

    End Function

    ' Returns the current system power state currently in effect. Receives the system power state
    Public Function GetSystemPowerState(ByVal systemStateName As StringBuilder, ByRef systemState As SystemPowerStates) As Integer

        Dim nError As System.UInt32 = Convert.ToUInt32(0)

        nError = CEGetSystemPowerState(systemStateName, Convert.ToUInt32(systemStateName.Capacity), systemState)

        Return CInt(Convert.ToInt32(nError))

    End Function

    ' Requests that the Power Manager change the power state of a device. Should be used with extreme care 
    ' since it may result in an unexpected application or system behavior.
    Public Function DevicePowerNotify(ByVal deviceName As String, ByVal deviceState As DevicePowerStates) As Integer

        Dim nError As System.UInt32 = Convert.ToUInt32(0)

        nError = CEDevicePowerNotify(deviceName, Convert.ToUInt32(deviceState), Convert.ToUInt32(PowerReqFlags.POWER_NAME))

        Return CInt(Convert.ToInt32(nError))

    End Function

    ' Activates notification events. An application can now register to PowerNotify and be 
    ' notified when a power notification is received.
    Public Sub EnableNotifications()

        Dim Options(1) As MessageQueueOptions

        ' Size in bytes ( 5 * 4)
        Options(0).Size = Convert.ToUInt32(Marshal.SizeOf(Options(0)))

        ' Allocate message buffers on demand and to free the message buffers after they are read
        Options(0).Flags = Convert.ToUInt32(MSGQUEUE_NOPRECOMMIT)

        ' Number of messages in the queue
        Options(0).MaxMessages = Convert.ToUInt32(32)

        ' Number of bytes for each message, do not set to zero.
        Options(0).MaxMessage = Convert.ToUInt32(512)

        ' Set to true to request read access to the queue.
        Options(0).ReadAccess = Convert.ToUInt32(1)

        ' Create the queue and request power notifications on it
        hMsgQ = CECreateMsgQueue("PowerNotifications", Options(0))

        hReq = CERequestPowerNotifications(hMsgQ, Convert.ToUInt32(POWER_NOTIFY_ALL))

        ' If the above succeed
        If Not (IntPtr.Zero.Equals(hMsgQ)) AndAlso Not (IntPtr.Zero.Equals(hReq)) Then

            powerQueue = New Queue

            ' Create an event so that we can kill the thread when we want
            powerThreadAbort = New AutoResetEvent(False)

            ' Create the power watcher thread
            Call (New Thread(AddressOf PowerNotifyThread)).Start()

        End If

    End Sub

    ' Disables power notification events.
    Public Sub DisableNotifications()

        ' If we are already closed just exit
        If Not powerThreadRunning Then

            Return

        End If

        ' Stop receiving power notifications
        If Not (IntPtr.Zero.Equals(hReq)) Then

            CEStopPowerNotifications(hReq)

        End If

        ' Attempt to end the PowerNotifyThread
        abortPowerThread = True

        powerThreadAbort.Set()

        ' Wait for the thread to stop
        Dim count As Integer = 0

        While powerThreadRunning

            Thread.Sleep(100)

            ' If it did not stop it time record this and give up
            If System.Math.Min(System.Threading.Interlocked.Increment(count), count - 1) > 50 Then

                Exit While

            End If

        End While

    End Sub

    ' Obtain the next PowerInfo structure
    <CLSCompliant(False)> _
    Public Function GetNextPowerInfo() As PowerInfo

        ' Get the next item from the queue in a thread safe manner
        SyncLock powerQueue.SyncRoot

            Return CType(powerQueue.Dequeue, PowerInfo)

        End SyncLock

    End Function

    ' Worker thread that creates and reads a message queue for power notifications
    Private Sub PowerNotifyThread()

        powerThreadRunning = True

        ' Keep going util we are asked to quit
        While Not abortPowerThread

            Dim Hndles(1) As IntPtr

            Hndles(0) = hMsgQ

            Hndles(1) = powerThreadAbort.Handle

            ' Wait on two handles because the message queue will never
            ' return from a read unless messages are posted.
            Dim res As Wait = CType(CEWaitForMultipleObjects(Convert.ToUInt32(Hndles.Length), Hndles, False, INFINITE), Wait)

            ' Exit the loop if an abort was requested
            If abortPowerThread Then

                Exit While

            End If

            ' Else
            Select Case res

                Case Wait.Abandoned     ' This must be an error - Exit loop and thread

                    abortPowerThread = True

                Case Wait.Failed        ' Timeout - Continue after a brief sleep

                    Thread.Sleep(500)

                Case Wait.Object_       ' Read the message from the queue

                    ' Create a new structure to read into
                    Dim Power As PowerInfo = New PowerInfo

                    Dim PowerSize As System.UInt32 = Convert.ToUInt32(Marshal.SizeOf(Power))

                    Dim BytesRead As System.UInt32 = Convert.ToUInt32(0)

                    Dim Flags As System.UInt32 = Convert.ToUInt32(0)

                    ' Read the message
                    If CEReadMsgQueue(hMsgQ, Power, PowerSize, BytesRead, Convert.ToUInt32(0), Flags) Then

                        ' Set value to zero if percentage is not known
                        If (Power.BatteryLifePercent < 0) OrElse (Power.BatteryLifePercent > 100) Then

                            Power.BatteryLifePercent = 0

                        End If

                        If (Power.BackupBatteryLifePercent < 0) OrElse (Power.BackupBatteryLifePercent > 100) Then

                            Power.BackupBatteryLifePercent = 0

                        End If

                        ' Add the power structure to the queue so that the 
                        ' UI thread can get it
                        SyncLock powerQueue.SyncRoot

                            powerQueue.Enqueue(Power)

                        End SyncLock

                        ' Fire an event to notify the UI
                        RaiseEvent PowerNotify(Me, Nothing)

                    End If

            End Select

        End While

        ' Close the message queue
        If Not (IntPtr.Zero.Equals(hMsgQ)) Then

            CECloseMsgQueue(hMsgQ)

        End If

        powerThreadRunning = False

    End Sub

#End Region

#Region "---------Native Power Management Imports----------"
    <CLSCompliant(False)> _
    Declare Function CERequestPowerNotifications Lib "coredll.dll" Alias "RequestPowerNotifications" (ByVal hMsgQ As IntPtr, ByVal Flags As System.UInt32) As IntPtr

    Declare Function CEStopPowerNotifications Lib "coredll.dll" Alias "StopPowerNotifications" (ByVal hReq As IntPtr) As Boolean
    <CLSCompliant(False)> _
    Declare Function CESetDevicePower Lib "coredll.dll" Alias "SetDevicePower" (ByVal Device As String, ByVal dwDeviceFlags As System.UInt32, ByVal DeviceState As System.UInt32) As System.UInt32
    <CLSCompliant(False)> _
    Declare Function CEGetDevicePower Lib "coredll.dll" Alias "GetDevicePower" (ByVal Device As String, ByVal dwDeviceFlags As System.UInt32, ByVal DeviceState As System.UInt32) As System.UInt32
    <CLSCompliant(False)> _
    Declare Function CEDevicePowerNotify Lib "coredll.dll" Alias "DevicePowerNotify" (ByVal Device As String, ByVal DeviceState As System.UInt32, ByVal Flags As System.UInt32) As System.UInt32
    <CLSCompliant(False)> _
    Declare Function CESetSystemPowerState Lib "coredll.dll" Alias "SetSystemPowerState" (ByVal sState As IntPtr, ByVal StateFlags As System.UInt32, ByVal Options As System.UInt32) As System.UInt32
    <CLSCompliant(False)> _
    Declare Function CEGetSystemPowerState Lib "coredll.dll" Alias "GetSystemPowerState" (ByVal Buffer As StringBuilder, ByVal Length As System.UInt32, ByRef Flags As SystemPowerStates) As System.UInt32
    <CLSCompliant(False)> _
    Declare Function CECreateMsgQueue Lib "coredll.dll" Alias "CreateMsgQueue" (ByVal Name As String, ByRef Options As MessageQueueOptions) As IntPtr

    Declare Function CECloseMsgQueue Lib "coredll.dll" Alias "CloseMsgQueue" (ByVal hMsgQ As IntPtr) As Boolean
    <CLSCompliant(False)> _
    Declare Function CEReadMsgQueue Lib "coredll.dll" Alias "ReadMsgQueue" (ByVal hMsgQ As IntPtr, ByRef Power As PowerInfo, ByVal BuffSize As System.UInt32, ByRef BytesRead As System.UInt32, ByVal Timeout As System.UInt32, ByRef Flags As System.UInt32) As Boolean
    <CLSCompliant(False)> _
    Declare Function CEWaitForMultipleObjects Lib "coredll.dll" Alias "WaitForMultipleObjects" (ByVal nCount As System.UInt32, ByVal lpHandles As IntPtr(), ByVal fWaitAll As Boolean, ByVal dwMilliseconds As Integer) As Integer

#End Region
End Class

