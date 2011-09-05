Imports YT

Public Class PCVersionControl



    Public Function CheckVersion() As BusinessObject.VersionControl.CheckVersionResult
        'Dim rst As BusinessObject.VersionControl.CheckVersionResult
        'Dim ver As New BusinessObject.VersionControl
        'Try
        '    'SysInfo.version中保存的是PC端最低版本号
        '    If Me.GetType.Assembly.GetExecutingAssembly.GetName.Version.CompareTo(New Version(ver.SysInfo.version)) < 0 Then
        '        Return BusinessObject.VersionControl.CheckVersionResult.ClientVersionLow
        '    End If
        'Catch ex As Exception
        '    Return BusinessObject.VersionControl.CheckVersionResult.CheckError
        'End Try
        'Return ver.CheckVersion
    End Function


End Class
