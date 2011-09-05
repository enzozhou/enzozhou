Imports COMExpress.Windows.Forms
Imports COMExpress.Windows.Controls

Public Class StatusbarService
    Implements IStatusBarService

    Private mobjSB As StatusBar

    Public Sub New(ByVal objSB As StatusBar)
        mobjSB = objSB
    End Sub

    Public Sub Status(Optional ByVal Msg As String = "Ready", Optional ByVal PanelIndex As Integer = 0) Implements COMExpress.Windows.Forms.IStatusBarService.Status
        mobjSB.Panels(PanelIndex).Text = Msg
        mobjSB.Refresh()
    End Sub

    Public Property Visible() As Boolean Implements COMExpress.Windows.Forms.IStatusBarService.Visible
        Get
            Return mobjSB.Visible
        End Get
        Set(ByVal Value As Boolean)
            mobjSB.Visible = Value
        End Set
    End Property

#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
