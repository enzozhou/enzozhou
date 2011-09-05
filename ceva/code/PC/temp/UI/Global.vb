Imports COMExpress.Windows.Forms
Imports CSLA

Module Global

    Private gMainform As frmMain

    Public ReadOnly Property MainForm() As frmMain
        Get
            Return gMainform
        End Get
    End Property

    Public Sub InitializeApp(ByVal mainForm As frmMain)
        gMainform = mainForm
    End Sub
    
    Public Sub ErrorMsg(ByVal e As Exception, ByVal ErrorModule As Type, ByVal ErrorRoutine As String)
        If TypeOf e Is ValidationException Then
            MsgBox(e.Message, MsgBoxStyle.Critical)
        Else
            MsgBox( _
                String.Format(CType(MainForm, IWindowsAppManager).LoadResString("ID_msg_Error"), _
                ErrorModule.FullName, e.ToString, ErrorRoutine, e.Source), _
                MsgBoxStyle.Critical)
        End If
    End Sub

    Public Sub Status(Optional ByVal Msg As String = "Ready", Optional ByVal PanelIndex As Integer = 0)
        CType(gMainform, IWindowsAppManager).StatusBarService.Status(Msg, PanelIndex)
    End Sub

#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Module
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
