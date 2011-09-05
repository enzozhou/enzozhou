Imports YT.BusinessObject
Imports System.Resources

Module mGlobal
    Public gResourceManager As New ResourceManager("YT.StringTable", GetType(Lookup).Module.Assembly)
End Module

Public Class LibResourceManager
    Public Shared Function GetString(ByVal ResourceName As String) As String
        Return gResourceManager.GetString(ResourceName)
    End Function

#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
