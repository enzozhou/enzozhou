Imports WMS
Imports YT.BusinessObject
Imports COMExpress
Imports COMExpress.BusinessObject
Imports ImportExport
Imports COMExpress.UserInterface
Imports ImportExport.Data
Imports ImportExport.Office


Module ExportData

    Public Function GetLibFile(ByVal strFile As String) As String
        Dim str As String
        Dim strPath As String
        Dim strPathDev As String
        Dim strFullFile As String
        Dim pos As Integer
        str = Reflection.Assembly.GetExecutingAssembly.GetModules()(0).FullyQualifiedName
        pos = str.LastIndexOf("\")
        If pos > 0 Then
            strPath = Left(str, pos)
        Else
            strPath = str
        End If
        strFullFile = strPath + "\lib\" + strFile
        If Dir(strFullFile) <> "" Then
            Return strFullFile
        End If
        pos = strPath.LastIndexOf("\")
        If pos > 0 Then
            strPathDev = Left(strPath, pos)
        Else
            strPathDev = strPath
        End If
        strFullFile = strPathDev + "\lib\" + strFile
        If Dir(strFullFile) <> "" Then
            Return strFullFile
        End If
        Return strFullFile = strPath + "\lib\" + strFile
    End Function

End Module
