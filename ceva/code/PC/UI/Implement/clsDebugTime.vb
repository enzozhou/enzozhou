Public Class clsDebugTime


    'The value of this property is the number of 100-nanosecond intervals that have elapsed since 12:00 A.M., January 1, 0001.
    Declare Auto Function GetTickCount Lib "Kernel32" () As Integer

    Private lngTick As Long

    Public Function NowTick() As Long
        'return now.Ticks /10
        Return GetTickCount
    End Function

    Public Sub New()
        Reset()
    End Sub

    Public Sub Reset()
        lngTick = NowTick()
    End Sub

    Public Function GetTicks() As Long
        Return NowTick() - lngTick
    End Function



End Class
