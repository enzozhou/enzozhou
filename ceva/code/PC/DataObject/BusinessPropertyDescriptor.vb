Imports System.ComponentModel
Imports System.Resources
Imports COMExpress.BusinessObject

Namespace BusinessObject
    Public Class BusinessPropertyDescriptor
        Inherits BusinessPropertyBaseDescriptor

        Public Sub New(ByVal oProp As PropertyDescriptor)
            MyBase.New(oProp)
        End Sub

        Protected Overrides ReadOnly Property StringResourceManager() As System.Resources.ResourceManager
            Get
                Return gResourceManager
            End Get
        End Property
    
#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region

End Namespace