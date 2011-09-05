Imports YT.BusinessObject
Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports System.Data.SqlClient
Imports ImportExport

Public Class frmObjectList
    Inherits CXListForm
    Implements IPrintableForm

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents DataGrid1 As YTUI.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.DataGrid1 = New YTUI.DataGrid
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.Cursor = System.Windows.Forms.Cursors.Default
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(544, 349)
        Me.DataGrid1.TabIndex = 0
        '
        'frmObjectList
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.WindowState = FormWindowState.Maximized
        Me.ClientSize = New System.Drawing.Size(544, 349)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1})
        Me.Name = "frmObjectList"
        Me.Text = "frmObjectList"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " COM Express generated code "
    Public Overrides ReadOnly Property GridControl() As COMExpress.Windows.Forms.IGrid
        Get
            Return Me.DataGrid1
        End Get
    End Property

    Public Overrides ReadOnly Property ReportViewer() As Object Implements IPrintableForm.ReportViewer
        Get
        End Get
    End Property

    Public Overrides Sub Delete()
        GridControl.DeleteObject()
    End Sub

    Private Sub FormOnError(ByVal sender As Object, ByVal e As FormExceptionEventArgs) Handles MyBase.OnError
        Dim ex As FormExceptionEventArgs = e
        ErrorMsg(ex.Exception, ex.ClassType, ex.Routine)
    End Sub

    Public Overrides Sub Format()
        MyBase.Format()
    End Sub
#End Region
    Protected Overrides Function InvokeToolAction(ByVal ToolKey As String, Optional ByVal Pushed As Boolean = False, Optional ByVal CustomArgs As Object = Nothing) As Boolean
        If ToolKey = BK_NEW Then
            If NewCall() Then
                Return True
            End If
        ElseIf ToolKey = BK_Export Then
            ExportCall()
            Return True
        ElseIf ToolKey = "LoadItem" Then
            ImportCall()
            Return True
        ElseIf ToolKey = BK_RELOADALL Then
            CType(MainForm.GetLookup, Lookup).ClearCache()
            Return MyBase.InvokeToolAction(ToolKey, Pushed, CustomArgs)
        ElseIf ToolKey = BK_FIND Then
            SetFilterValueToStatus()
            'Return True
        End If
        Return MyBase.InvokeToolAction(ToolKey, Pushed, CustomArgs)
    End Function

#Region " Status Updated"
    'This section will not be overwritten during a round-trip code generation

    Protected Overrides Sub UpdateEditStatus()
        MyBase.UpdateEditStatus()
        DisableButton()
    End Sub
    Protected Overrides Sub UpdateNavigationStatus()
        MyBase.UpdateNavigationStatus()
        DisableButton()
    End Sub
    Private Sub DisableButton()
    End Sub
#End Region
#Region " New Call"
    Private Function NewCall() As Boolean
        If Me.DataSource.GetType.Name = "clsbchhdrs" Then
            If FuncType = "ALL" Then
                MainForm.CallOutboundCheckOrder(True, "ALL")
                Me.RefreshData()
                Return True
            Else
                MainForm.CallOutboundCheckOrder(True, "OPEN")
                Me.RefreshData()
                Return True
            End If
        ElseIf Me.DataSource.GetType.Name = "clstaskhdrs" Then
            MainForm.CallAssignTaskForOrder(True, "ALL")
            Me.RefreshData()
            Return True
        End If
        Return False
    End Function
#End Region
#Region " Export call"
    Private Sub ExportCall()
    End Sub
    Private Sub SetFilterValueToStatus()
    End Sub
#End Region
#Region " Import Call"
    Private Sub ImportCall()
        Select Case Me.DataSource.GetType.Name
            Case "clsdnhdrs"
                MainForm.CallImportDN()
                Me.RefreshData()
            Case "clsskuinfoes"
                MainForm.CallImportSKU()
                Me.RefreshData()
            Case "clsbinareas"
                MainForm.CallImportBin()
                Me.RefreshData()
            Case "clscityairports"
                MainForm.CallImportAirPort()
                Me.RefreshData()
            Case "clsbchhdrs"
                MainForm.CallDnBanch()
                Me.RefreshData()
        End Select
    End Sub
#End Region
    Private Sub RefreshRelatedMenu()
        MainForm.RelatedMenu.Clear()
        MainForm.RelatedMenu.Refresh()
    End Sub
    Private Sub frmObjectList_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        RefreshRelatedMenu()
    End Sub
    Private Sub DataGrid1_GetInvisibleColumn(ByVal InvisibleColumn As Microsoft.VisualBasic.Collection) Handles DataGrid1.GetInvisibleColumn
        Select Case Me.DataSource.GetType.Name
            Case "clsoperators"
                InvisibleColumn.Add("password_", "password_")
        End Select
    End Sub
    Protected Overrides Function DoSearchCustom(ByRef filter As COMExpress.BusinessObject.Filters.CXFilters) As System.Windows.Forms.DialogResult
        Try
            Dim rst As DialogResult
            rst = SearchManager.SearchCustom(ObjectType.Name, filter, FuncType)
            If rst = DialogResult.Ignore Then
                Return MyBase.DoSearchCustom(filter)
            Else
                Return rst
            End If
        Catch ex As Exception
            ErrorMsg(ex, Me.GetType, "DoSearchCustom")
            Return DialogResult.Ignore
        End Try
    End Function
End Class
#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
'This section will not be overwritten during a round-trip code generation
#End Region
