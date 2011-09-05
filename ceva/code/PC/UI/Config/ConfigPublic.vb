Module ConfigPublic
    Public Const ConfigFile As String = "set.xml"
    Public Function GetConfigPath() As String
        Dim str As String
        str = Application.StartupPath + "\Config"
        If System.IO.File.Exists(str + "\" + ConfigFile) = True Then
            Return str
        End If
        Dim iPos As String
        str = Application.StartupPath
        iPos = str.LastIndexOf("\")
        If iPos >= 0 Then
            str = str.Substring(0, iPos)
        End If
        str = str + "\Config"
        If System.IO.File.Exists(str + "\" + ConfigFile) = True Then
            Return str
        End If
        Return ""
    End Function
End Module
