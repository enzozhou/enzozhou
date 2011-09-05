Option Explicit On 
Option Strict On
Imports System.Collections.Specialized
Imports COMExpress.Windows.Forms
Imports COMExpress.UserInterface.Layout
Imports COMExpress.BusinessObject
Imports YT.BusinessObject

Public Class ToolBarButtonEx
    Inherits System.Windows.Forms.ToolBarButton

    Private mblnIsMainMenu As Boolean
    Private mstrButtonKey As String

    Public Property ButtonKey() As String
        Get
            Return mstrButtonKey
        End Get
        Set(ByVal Value As String)
            mstrButtonKey = Value
        End Set
    End Property

    Public Property IsMainMenu() As Boolean
        Get
            Return mblnIsMainMenu
        End Get
        Set(ByVal Value As Boolean)
            mblnIsMainMenu = Value
        End Set
    End Property

#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
    Private components As System.ComponentModel.IContainer

    Private Sub InitializeComponent()

    End Sub
End Class

#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
'This section will not be overwritten during a round-trip code generation
#End Region


Public Class ToolbarEx
    Inherits System.Windows.Forms.ToolBar
    Implements IToolbarService


    Private mobjForm As IToolbarHost
    Private mobjKeys As Hashtable
    Private mblnLoading As Boolean

    Friend WithEvents Timer1 As System.Windows.Forms.Timer


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents imlToolbar As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.imlToolbar = New System.Windows.Forms.ImageList(Me.components)
        '
        'imlToolbar
        '
        Me.imlToolbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlToolbar.ImageSize = New System.Drawing.Size(16, 16)
        Me.imlToolbar.TransparentColor = System.Drawing.Color.Transparent

        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    End Sub

#End Region

#Region " COM Express generated code "
    Dim i As Integer
    Private Sub ToolbarEx_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles MyBase.ButtonClick
        If mblnLoading Then Return
        Dim button As ToolBarButtonEx
        button = CType(e.Button, ToolBarButtonEx)
        RaiseEvent ItemClick(button.ButtonKey, String.Empty)

        If mobjForm Is Nothing Then Return
        'If CType(mobjForm, CXBaseForm).Name = "frmclsccnhdrBase__" And UCase(button.ButtonKey) = "SAVE" Then
        '    i = CType(CType(mobjForm, frmclsccnhdr).Current, clsccnhdr).clsccnlins.Count
        '    Timer1.Start()

        'End If
        With CType(mobjForm, IToolbarHost)
            If .BeforeInvokeToolAction(button.ButtonKey, button.Pushed, button.Tag) Then .InvokeToolAction(button.ButtonKey, button.Pushed, button.Tag)
        End With
        ' MsgBox(UserRightMgr.Isavecount.ToString)
    End Sub


    Private Sub ShowProgress()
        'Dim frm As New frmProcessing
        'frm.count = i
        'frm.ShowDialog()
        'frm.Dispose()
        'frm = Nothing
        'GC.Collect()
    End Sub
#End Region

#Region "IToolbarService Implementation"

    Public Property ButtonEnabled(ByVal ToolKey As String) As Boolean Implements COMExpress.Windows.Forms.IMenuBaseService.ButtonEnabled
        Get
            Return Me.Buttons(CType(mobjKeys.Item(ToolKey), Integer)).Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me.Buttons(CType(mobjKeys.Item(ToolKey), Integer)).Enabled = Value
        End Set
    End Property

    Public Property ButtonPushed(ByVal ToolKey As String) As Boolean Implements COMExpress.Windows.Forms.IMenuBaseService.ButtonPushed
        Get
            Return Me.Buttons(CType(mobjKeys.Item(ToolKey), Integer)).Pushed
        End Get
        Set(ByVal Value As Boolean)
            Me.Buttons(CType(mobjKeys.Item(ToolKey), Integer)).Pushed = Value
        End Set
    End Property

    Public Property ButtonVisibility(ByVal ToolKey As String) As Boolean Implements COMExpress.Windows.Forms.IMenuBaseService.ButtonVisibility
        Get
            Return Me.Buttons(CType(mobjKeys.Item(ToolKey), Integer)).Visible
        End Get
        Set(ByVal Value As Boolean)
            Me.Buttons(CType(mobjKeys.Item(ToolKey), Integer)).Visible = Value
        End Set
    End Property

    Public Event ItemClick(ByVal Key As String, ByVal Parameter As String) Implements COMExpress.Windows.Forms.IMenuBaseService.ItemClick

    Public Sub StopEventHandler(ByVal blnStop As Boolean) Implements COMExpress.Windows.Forms.IMenuBaseService.StopEventHandler
        mblnLoading = blnStop
    End Sub

    Public Sub RemoveButton(ByVal ToolKey As String) Implements COMExpress.Windows.Forms.IToolbarService.RemoveButton
        Me.Buttons.RemoveAt(CType(mobjKeys.Item(ToolKey), Integer))
    End Sub

    Public Sub AddButton(ByVal ToolKey As String, Optional ByVal ToolText As String = Nothing, Optional ByVal ToolIcon As Object = Nothing, Optional ByVal ToolTip As String = Nothing, Optional ByVal InsertBefore As Object = Nothing, Optional ByVal BeginGroup As Boolean = False, Optional ByVal IsMainMenu As Boolean = False, Optional ByVal ToolType As Integer = 0, Optional ByVal ToolGroup As String = Nothing, Optional ByVal ToolState As Integer = 0, Optional ByVal ToolVisible As Boolean = True) Implements COMExpress.Windows.Forms.IToolbarService.AddButton
        If mobjKeys.Contains(ToolKey) Then Return
        Dim btn As New ToolBarButtonEx
        btn.ButtonKey = ToolKey
        btn.ToolTipText = ToolTip
        If Not ToolIcon Is Nothing Then
            If TypeOf ToolIcon Is Icon Then
                Me.imlToolbar.Images.Add(CType(ToolIcon, Icon))
            Else
                Me.imlToolbar.Images.Add(CType(ToolIcon, Image))
            End If
            btn.ImageIndex = Me.imlToolbar.Images.Count - 1
        End If
        btn.Text = ToolText
        Select Case ToolType
            Case 0
                btn.Style = ToolBarButtonStyle.PushButton
            Case 1, 2
                btn.Style = ToolBarButtonStyle.ToggleButton
            Case 3
                btn.Style = ToolBarButtonStyle.Separator
        End Select
        btn.IsMainMenu = IsMainMenu
        Dim index As Integer
        If InsertBefore Is Nothing Then
            index = Me.Buttons.Add(btn)
            mobjKeys.Add(btn.ButtonKey, index)
        Else
            If TypeOf InsertBefore Is String Then
                index = CType(mobjKeys.Item(CType(InsertBefore, String)), Integer)
                mobjKeys.Remove(CType(InsertBefore, String))
                mobjKeys.Add(btn.ButtonKey, index)
                mobjKeys.Add(CType(InsertBefore, String), index + 1)
                Me.Buttons.Insert(index, btn)
            Else
                index = CType(InsertBefore, Integer)
                Dim btnOld As ToolBarButtonEx = CType(Me.Buttons.Item(index), ToolBarButtonEx)
                mobjKeys.Remove(btnOld.ButtonKey)
                mobjKeys.Add(btn.ButtonKey, index)
                mobjKeys.Add(btnOld.ButtonKey, index + 1)
                Me.Buttons.Insert(index, btn)
            End If
        End If
        btn.Visible = ToolVisible
    End Sub

    Public Sub AfterInitialization() Implements COMExpress.Windows.Forms.IToolbarService.AfterInitialization
    End Sub

    Public Sub BeforeInitialization(ByVal ImageSize As System.Drawing.Size, ByVal UseLargeImage As Boolean) Implements COMExpress.Windows.Forms.IToolbarService.BeforeInitialization
        mobjKeys = New Hashtable

        With Me
            .ImageList = Me.imlToolbar
            With .ImageList
                .TransparentColor = System.Drawing.Color.Magenta
                .ColorDepth = ColorDepth.Depth32Bit
                .Images.Clear()
                .ImageSize = ImageSize
            End With
        End With
    End Sub

    Public Sub StartService(ByVal objToolbarHost As COMExpress.Windows.Forms.IToolbarHost) Implements COMExpress.Windows.Forms.IToolbarService.StartService
        Dim button As ToolBarButtonEx, blnVisible As Boolean, blnMDIHost As Boolean

        blnMDIHost = MainForm.IsMdiContainer
        If objToolbarHost Is Nothing Then
            If MainForm.IsMdiContainer And MainForm.MdiChildren.Length > 1 Then
                Try
                    objToolbarHost = CType(MainForm.ActiveMdiChild, IToolbarHost)
                Catch ex As Exception
                    MainForm.StatusBarService.RefreshStatus()
                    Exit Sub
                End Try
            End If
        Else
            mobjForm = objToolbarHost
        End If


        'mobjForm = objToolbarHost
        blnVisible = Not (objToolbarHost Is Nothing)
        'blnMDIHost = MainForm.IsMdiContainer
        For Each button In Me.Buttons
            If Not button.IsMainMenu Then
                If (objToolbarHost Is Nothing) Then
                    button.Visible = blnVisible
                Else
                    button.Visible = blnVisible And _
                        (Not objToolbarHost.IsButtonHidden(button.ButtonKey))
                End If
            Else
                If (objToolbarHost Is Nothing) Then
                    button.Visible = blnMDIHost
                Else
                    button.Visible = blnMDIHost And _
                        (Not objToolbarHost.IsButtonHidden(button.ButtonKey))
                End If
            End If
        Next
        If Not (objToolbarHost Is Nothing) Then
            With objToolbarHost
                .OnServiceStarted()
                .UpdateDirtyStatus()
                .UpdateEditStatus()
            End With
        End If
        MainForm.StatusBarService.RefreshStatus()
    End Sub



    Public Sub RefreshService() Implements COMExpress.Windows.Forms.IToolbarService.RefreshService
        MainForm.StatusBarService.RefreshStatus()
    End Sub



    Private mobjTaskCollection As New COMExpress.Windows.Forms.TaskColloction


    Public Sub Attach(ByVal frm As Form) Implements COMExpress.Windows.Forms.IToolbarService.Attach
        On Error Resume Next
        mobjTaskCollection.Add(frm)
    End Sub
    Public Sub Detach(ByVal frm As Form) Implements COMExpress.Windows.Forms.IToolbarService.Deattach
        On Error Resume Next
        mobjTaskCollection.Remove(frm)
    End Sub



    Public Function GetTaskCollection() As COMExpress.Windows.Forms.TaskColloction Implements COMExpress.Windows.Forms.IToolbarService.GetTaskCollection
        Return mobjTaskCollection
    End Function


#End Region



    'Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Timer1.Stop()
    '    ShowProgress()
    'End Sub
End Class