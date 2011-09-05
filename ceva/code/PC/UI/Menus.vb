Imports COMExpress.Windows.Forms
Imports COMExpress.Windows.Controls

Public Class MenuService
    Implements IMenuService

    Friend WithEvents mnuMain As CXImageMainMenu
    Private iml As New ImageList
    Private mblnLoading As Boolean

    Public Sub New(ByVal m As CXImageMainMenu, ByVal objApp As IWindowsAppManager)
        mnuMain = m
        mnuMain.IconImageList = iml
        MenuHelper.InitializeMenuService(objApp, Me)
    End Sub

    Private Sub MenuClicked(ByVal sender As Object, ByVal e As System.EventArgs)
        If mblnLoading Then Return
        RaiseEvent ItemClick((CType(sender, CXImageMenu).Key), CType(sender, CXImageMenu).Tag)
    End Sub

    Public Sub RemoveButton(ByVal ToolKey As String) Implements COMExpress.Windows.Forms.IMenuService.RemoveButton
        Dim itm As CXImageMenu = mnuMain.FindMenuItemByKey(ToolKey)
        If Not itm Is Nothing Then
            itm.Parent.MenuItems.RemoveAt(itm.Index)
        End If
    End Sub

    Public Sub AddButton(ByVal ToolKey As String, Optional ByVal ToolText As String = Nothing, Optional ByVal ToolIcon As Object = Nothing, Optional ByVal ToolTip As String = Nothing, Optional ByVal InsertBefore As Object = Nothing, Optional ByVal BeginGroup As Boolean = False, Optional ByVal ShortCutKey As Integer = 0, Optional ByVal ToolType As COMExpress.Windows.Forms.ToolButtonType = COMExpress.Windows.Forms.ToolButtonType.tbDefault, Optional ByVal ToolGroup As String = Nothing, Optional ByVal ToolState As Integer = 0, Optional ByVal ToolVisible As Boolean = True, Optional ByVal ParentKey As String = Nothing) Implements COMExpress.Windows.Forms.IMenuService.AddButton
        Dim itm As New CXImageMenu

        Select Case ToolType
            Case ToolButtonType.tbSeperator
                itm.Text = "-"
            Case ToolButtonType.tbWindowList
                itm.MdiList = True
            Case Else
                If Not ToolIcon Is Nothing Then
                    iml.Images.Add(ToolIcon)
                    itm.ImageIndex = iml.Images.Count - 1
                End If
                itm.Shortcut = ShortCutKey
                itm.Key = ToolKey
                itm.Text = ToolText
                AddHandler itm.Click, AddressOf Me.MenuClicked
        End Select

        If ParentKey = String.Empty Then
            mnuMain.MenuItems.Add(itm)
        Else
            mnuMain.FindMenuItemByKey(ParentKey).MenuItems.Add(itm)
        End If


    End Sub

    Public Sub CommandItemAdded(ByVal Key As String, ByVal Caption As String, ByVal Img As Object, ByVal ParentKey As String) Implements COMExpress.Windows.Forms.IMenuService.CommandItemAdded
        Try
            Dim mnuCommand As CXImageMenu = mnuMain.FindMenuItemByKey("mnuCommand")
            If mnuCommand Is Nothing Then Return
            If ParentKey = "" Then
                Dim mnu As New CXImageMenu
                mnu.Text = Caption
                mnu.Tag = Key
                If Not Img Is Nothing Then
                    If mnuCommand.Tag = String.Empty Then mnuCommand.Tag = iml.Images.Count
                    iml.Images.Add(Img)
                    mnu.ImageIndex = iml.Images.Count - 1
                End If
                mnuCommand.MenuItems.Add(mnu)
            Else
                Dim index As Integer
                Dim mnuParent As CXImageMenu
                For Each mnuParent In mnuCommand.MenuItems
                    If mnuParent.Tag = ParentKey Then
                        Exit For
                    End If
                Next
                If Not mnuParent Is Nothing Then
                    Dim mnu As New CXImageMenu
                    mnu.Text = Caption
                    mnu.Tag = Key
                    If Not Img Is Nothing Then
                        If mnuCommand.Tag = String.Empty Then mnuCommand.Tag = iml.Images.Count
                        iml.Images.Add(Img)
                        mnu.ImageIndex = iml.Images.Count - 1
                    End If
                    mnuParent.MenuItems.Add(mnu)
                    AddHandler mnu.Click, AddressOf MenuClicked
                End If
            End If
            If Not mnuCommand.Visible Then mnuCommand.Visible = True

        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "tvSW_ItemAdded")
        End Try
    End Sub

    Public Sub CommandItemCleared() Implements COMExpress.Windows.Forms.IMenuService.CommandItemCleared
        Try
            Dim mnuCommand As CXImageMenu = mnuMain.FindMenuItemByKey("mnuCommand")
            If mnuCommand Is Nothing Then Return
            If mnuCommand.Tag = String.Empty Then Return
            Dim intImages As Integer = CType(mnuCommand.Tag, Integer)
            While iml.Images.Count > intImages
                iml.Images.RemoveAt(iml.Images.Count - 1)
            End While
            mnuCommand.MenuItems.Clear()
            mnuCommand.Visible = False
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "tvSW_ItemCleared")
        End Try
    End Sub

    Public Property ButtonEnabled(ByVal ToolKey As String) As Boolean Implements COMExpress.Windows.Forms.IMenuService.ButtonEnabled
        Get
            Dim itm As CXImageMenu = mnuMain.FindMenuItemByKey(ToolKey)
            If Not itm Is Nothing Then
                Return itm.Enabled
            End If
        End Get
        Set(ByVal Value As Boolean)
            Dim itm As CXImageMenu = mnuMain.FindMenuItemByKey(ToolKey)
            If Not itm Is Nothing Then
                itm.Enabled = Value
            End If
        End Set
    End Property

    Public Property ButtonPushed(ByVal ToolKey As String) As Boolean Implements COMExpress.Windows.Forms.IMenuService.ButtonPushed
        Get
            Dim itm As CXImageMenu = mnuMain.FindMenuItemByKey(ToolKey)
            If Not itm Is Nothing Then
                Return itm.Checked
            End If
        End Get
        Set(ByVal Value As Boolean)
            Dim itm As CXImageMenu = mnuMain.FindMenuItemByKey(ToolKey)
            If Not itm Is Nothing Then
                itm.Checked = Value
            End If
        End Set
    End Property

    Public Property ButtonVisibility(ByVal ToolKey As String) As Boolean Implements COMExpress.Windows.Forms.IMenuService.ButtonVisibility
        Get
            Dim itm As CXImageMenu = mnuMain.FindMenuItemByKey(ToolKey)
            If Not itm Is Nothing Then
                Return itm.Visible
            End If
        End Get
        Set(ByVal Value As Boolean)
            Dim itm As CXImageMenu = mnuMain.FindMenuItemByKey(ToolKey)
            If Not itm Is Nothing Then
                itm.Visible = Value
            End If
        End Set
    End Property

    Public Event ItemClick(ByVal Key As String, ByVal Parameter As String) Implements COMExpress.Windows.Forms.IMenuService.ItemClick

    Public Sub StopEventHandler(ByVal blnStop As Boolean) Implements COMExpress.Windows.Forms.IMenuService.StopEventHandler
        mblnLoading = blnStop
    End Sub

    Public Sub BuildRelatedMenu(ByVal objRelatedMenu As clsRelatedMenu)
        Dim mnuRelate As CXImageMenu = mnuMain.FindMenuItemByKey("mnuRelaData")
        If mnuRelate Is Nothing Then Return
        mnuRelate.MenuItems.Clear()
        'mnuRelate.Visible = True
        Dim i As Integer
        Dim im As ItemSingle
        For i = 0 To objRelatedMenu.Count - 1
            im = objRelatedMenu.MenuItems.Item(i)
            Dim mnu As New CXImageMenu
            mnu.Text = im.Caption
            mnu.Tag = im.Tag
            mnu.Key = im.Key
            mnuRelate.MenuItems.Add(mnu)
            AddHandler mnu.Click, AddressOf MenuClicked
            mnu = Nothing
        Next
        'If objRelatedMenu.Count <= 0 Then
        '    mnuRelate.Visible = False
        'End If
        im = Nothing
    End Sub
#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
