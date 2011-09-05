Imports System.Configuration
Imports YT.BusinessObject
Imports COMExpress.Windows.Forms
Imports COMExpress.Windows.Controls
Imports COMExpress.UserInterface.Layout
Imports COMExpress.BusinessObject
Imports CSLA
Imports System.Threading
Imports YT
Public Class frmMain
    Inherits MdiHost.CXMdiMain
    Implements IWindowsAppManager
    Implements ISwitchboardHost

    Private mIconResMgr As New System.Resources.ResourceManager("YTUI.IconImages", GetType(frmMain).Module.Assembly)
    Private mBMPResMgr As New System.Resources.ResourceManager("YTUI.BmpImages", GetType(frmMain).Module.Assembly)
    Private mStringResMgr As New System.Resources.ResourceManager("YTUI.StringTable", GetType(frmMain).Module.Assembly)
    Private mobjLayout As CXLayoutFile
    Private mobjLookupObject As Lookup
    Private Const AppConfigFile As String = "\WMSApp.config"
    Private mobjAppSettings As WindowsAppSettings
    Private quitQsnFlag As Boolean = True
    Private mSearchManager As New SearchManager

    Public ReadOnly Property LayoutFile() As CXLayoutFile
        Get
            Return mobjLayout
        End Get
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
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
    Friend WithEvents imlSW As System.Windows.Forms.ImageList
    Friend WithEvents tvSW As Switchboard
    Friend WithEvents splMain As System.Windows.Forms.Splitter
    Friend WithEvents sbMain As CXStatusBar 'System.Windows.Forms.StatusBar
    Friend WithEvents sbpUser As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpMain As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpTask As System.Windows.Forms.StatusBarPanel
    Friend WithEvents tbMain As ToolbarEx
    Friend WithEvents imlToolbar As System.Windows.Forms.ImageList
    Friend WithEvents mnuMain As CXImageMainMenu
    Friend WithEvents TimerClose As System.Windows.Forms.Timer
    Friend WithEvents TimerClient As System.Windows.Forms.Timer
    Friend WithEvents TimerChangeDC As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.tvSW = New YTUI.Switchboard
        Me.imlSW = New System.Windows.Forms.ImageList(Me.components)
        Me.splMain = New System.Windows.Forms.Splitter
        Me.sbMain = New COMExpress.Windows.Controls.CXStatusBar
        Me.sbpMain = New System.Windows.Forms.StatusBarPanel
        Me.sbpUser = New System.Windows.Forms.StatusBarPanel
        Me.sbpTask = New System.Windows.Forms.StatusBarPanel
        Me.tbMain = New YTUI.ToolbarEx
        Me.imlToolbar = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuMain = New COMExpress.Windows.Controls.CXImageMainMenu
        Me.TimerClose = New System.Windows.Forms.Timer(Me.components)
        Me.TimerClient = New System.Windows.Forms.Timer(Me.components)
        Me.TimerChangeDC = New System.Windows.Forms.Timer(Me.components)
        CType(Me.sbpMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpTask, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tvSW
        '
        Me.tvSW.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvSW.ImageIndex = 0
        Me.tvSW.ImageList = Me.imlSW
        Me.tvSW.Location = New System.Drawing.Point(0, 28)
        Me.tvSW.Name = "tvSW"
        Me.tvSW.SelectedImageIndex = 0
        Me.tvSW.Size = New System.Drawing.Size(146, 223)
        Me.tvSW.TabIndex = 5
        '
        'imlSW
        '
        Me.imlSW.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlSW.ImageSize = New System.Drawing.Size(16, 16)
        Me.imlSW.TransparentColor = System.Drawing.Color.Transparent
        '
        'splMain
        '
        Me.splMain.Location = New System.Drawing.Point(146, 28)
        Me.splMain.Name = "splMain"
        Me.splMain.Size = New System.Drawing.Size(6, 223)
        Me.splMain.TabIndex = 4
        Me.splMain.TabStop = False
        '
        'sbMain
        '
        Me.sbMain.Location = New System.Drawing.Point(0, 251)
        Me.sbMain.Name = "sbMain"
        Me.sbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbpMain, Me.sbpUser, Me.sbpTask})
        Me.sbMain.ShowPanels = True
        Me.sbMain.Size = New System.Drawing.Size(364, 24)
        Me.sbMain.TabIndex = 2
        '
        'sbpMain
        '
        Me.sbpMain.Name = "sbpMain"
        Me.sbpMain.Text = "Ready"
        '
        'sbpUser
        '
        Me.sbpUser.Name = "sbpUser"
        Me.sbpUser.Width = 75
        '
        'sbpTask
        '
        Me.sbpTask.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpTask.Name = "sbpTask"
        Me.sbpTask.Width = 172
        '
        'tbMain
        '
        Me.tbMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbMain.DropDownArrows = True
        Me.tbMain.ImageList = Me.imlToolbar
        Me.tbMain.Location = New System.Drawing.Point(0, 0)
        Me.tbMain.Name = "tbMain"
        Me.tbMain.ShowToolTips = True
        Me.tbMain.Size = New System.Drawing.Size(364, 28)
        Me.tbMain.TabIndex = 2
        Me.tbMain.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'imlToolbar
        '
        Me.imlToolbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlToolbar.ImageSize = New System.Drawing.Size(16, 16)
        Me.imlToolbar.TransparentColor = System.Drawing.Color.Magenta
        '
        'mnuMain
        '
        Me.mnuMain.IconImageList = Nothing
        '
        'TimerClose
        '
        '
        'TimerClient
        '
        '
        'TimerChangeDC
        '
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.ClientSize = New System.Drawing.Size(364, 275)
        Me.Controls.Add(Me.splMain)
        Me.Controls.Add(Me.tvSW)
        Me.Controls.Add(Me.sbMain)
        Me.Controls.Add(Me.tbMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.Controls.SetChildIndex(Me.tbMain, 0)
        Me.Controls.SetChildIndex(Me.sbMain, 0)
        Me.Controls.SetChildIndex(Me.tvSW, 0)
        Me.Controls.SetChildIndex(Me.splMain, 0)
        CType(Me.sbpMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpTask, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
#Region " COM Express generated code "

    Private WithEvents mobjMenu As MenuService
    Private mobjSB As StatusbarService

#Region " Properties "
    Public ReadOnly Property AppSettings() As COMExpress.Windows.Forms.WindowsAppSettings Implements COMExpress.Windows.Forms.IWindowsAppManager.AppSettings
        Get
            Return mobjAppSettings
        End Get
    End Property
#End Region

#Region " Internal methods "
    Private Function TypeInheritsFrom( _
          ByVal TypeToCheck As Type, ByVal CheckAgainst As Type) As Boolean

        Dim Base As Type = TypeToCheck

        ' scan up through the inheritance hierarchy, checking each
        ' class to see if it is the one we're looking for
        While Not Base.BaseType Is Nothing
            ' if we find the target class return True
            If Base Is CheckAgainst Then Return True
            Base = Base.BaseType
        End While

        ' the target class is not in the inheritance hierarchy so
        ' return False
        Return False
    End Function

    Private Function GetDBDirectory() As String
        Dim currentDirectory As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(Application.ExecutablePath).Parent
        While Not (currentDirectory Is Nothing)

            Dim childDirectories As System.IO.DirectoryInfo() = currentDirectory.GetDirectories()
            Dim childDir As System.IO.DirectoryInfo

            For Each childDir In childDirectories

                If (childDir.Name.ToUpper = "UI") Then
                    Return childDir.FullName
                End If
            Next
            currentDirectory = currentDirectory.Parent
        End While
        Return ""
    End Function

    Private Function CloseMdi(Optional ByVal blnCloseAll As Boolean = False) As Boolean
        If Me.MdiChildren.GetLength(0) = 0 Then Return True
        Dim frm As Form
        Try
            If blnCloseAll Then
                For Each frm In Me.MdiChildren
                    frm.Close()
                    frm.Dispose()
                Next
                GC.Collect()
                Return Me.MdiChildren.GetLength(0) = 0
            Else
                frm = Me.ActiveMdiChild
                frm.Close()
                frm.Dispose()
                GC.Collect()
                Return True
            End If
        Catch
            Return False
        End Try

    End Function

    Private Sub CloseMe()
        TimerClient.Enabled = False

        TimerClose.Interval = 300
        TimerClose.Enabled = True

    End Sub

    Private Sub LogOn()
        Dim dlg As New frmLogin
        UserRightMgr.LoginSuccess = False
        If dlg.ShowDialog = DialogResult.OK Then
            RefreshRegionInformation()
            UserRightMgr.LoginSuccess = True
        Else
            ChangeCurrentDirectory("")
            EndProgress()
            End             '这里程序直接就结束了.
            ' CloseMe()
            'Exit Sub
        End If
        LogMenuStatus(True)
        SwitchboardHelper.InitializeSwitchboardService(Me, tvSW, Me)
        ClientManager.RemoveOldClients()
    End Sub

    Private Sub LogOff()
        If CloseMdi(True) Then
            Try
                CType(tvSW, ISwitchboardService).Clear()
                LogMenuStatus(False)
                System.Threading.Thread.CurrentPrincipal = Nothing
                Status(String.Empty, 1)
                'Me.Visible = False
                '不能有visible=false语名,否则会引起form.Closing事件'
                'Note By Yu YunSong
                Application.DoEvents()
                LogOn()
            Catch ThisException As Exception
                ErrorMsg(ThisException, Me.GetType, "LogOff")
            End Try
        End If
        SaveLogOffLog()
    End Sub
#End Region

#Region " IWindowsAppManager Implementation "

    Public Property StatusbarVisibility() As Boolean Implements COMExpress.Windows.Forms.IWindowsAppManager.StatusbarVisibility
        Get
            Return mobjSB.Visible
        End Get
        Set(ByVal Value As Boolean)
            mobjSB.Visible = Value
            mobjMenu.StopEventHandler(True)
            mobjMenu.ButtonPushed("mnuViewStatusBar") = Value
            mobjMenu.StopEventHandler(False)
        End Set
    End Property

    Public Property SwitchboardVisibility() As Boolean Implements COMExpress.Windows.Forms.IWindowsAppManager.SwitchboardVisibility

        Get
            Return tvSW.Visible
        End Get
        Set(ByVal Value As Boolean)
            tvSW.Visible = Value
            splMain.Visible = Value

            Dim intPos As Integer
            If Not tvSW.Visible Then intPos = tvSW.Width
            If tvSW.Visible Then
                If intPos = 0 Then intPos = 175
                splMain.Left = intPos
            End If

            mobjMenu.StopEventHandler(True)
            mobjMenu.ButtonPushed("mnuViewCmdTree") = Value
            mobjMenu.StopEventHandler(False)
            tbMain.StopEventHandler(True)
            tbMain.ButtonPushed("Main") = Value
            tbMain.StopEventHandler(False)
            Me.RefreshMdiClient()
        End Set
    End Property

    Public ReadOnly Property MenuService() As COMExpress.Windows.Forms.IMenuService Implements COMExpress.Windows.Forms.IWindowsAppManager.MenuService
        Get
            Return mobjMenu
        End Get
    End Property

    Public ReadOnly Property StatusBarService() As COMExpress.Windows.Forms.IStatusBarService Implements COMExpress.Windows.Forms.IWindowsAppManager.StatusBarService
        Get
            Return mobjSB
        End Get
    End Property

    Public Function LoadResBMP(ByVal ResName As String) As System.Drawing.Image Implements IWindowsAppManager.LoadResBMP
        LoadResBMP = mBMPResMgr.GetObject(ResName)
    End Function

    Public Function LoadResIcon(ByVal ResName As String) As System.Drawing.Icon Implements IWindowsAppManager.LoadResIcon
        LoadResIcon = mIconResMgr.GetObject(ResName)
    End Function

    Public Function LoadResString(ByVal ResName As String) As String Implements IWindowsAppManager.LoadResString
        Try
            'Return PublicResource.LoadResString(ResName)
            Return mStringResMgr.GetString(ResName)
        Catch
            Return ResName
        End Try
    End Function

    Public Function LoadResStringFromLib(ByVal resName As String) As String Implements IWindowsAppManager.LoadResStringFromLib
        Try
            Return YT.LibResourceManager.GetString(resName)
        Catch
            Return resName
        End Try
    End Function

    Public Function CallPromptForm( _
        ByVal ObjectName As String, _
        ByVal BoundProperty As String, _
        ByVal ReplaceProperty As String, _
        ByVal SearchProperty As String, _
        ByVal TopLeft As System.Drawing.Point, _
        ByVal BottomRight As System.Drawing.Point, _
        ByRef vntReturn() As Object, _
        ByVal _filters As COMExpress.BusinessObject.Filters.CXFilters) As Boolean Implements IWindowsAppManager.CallPromptForm
        Dim frmX As New frmObjectModal

        Try
            With frmX
                .Initialize(Me, ObjectName, BoundProperty, ReplaceProperty, TopLeft, BottomRight, vntReturn, _filters)
                If .ShowDialog = DialogResult.OK Then
                    vntReturn(0) = ReflectionHelper.GetPropertyValue(.Current, BoundProperty)
                    vntReturn(1) = ReflectionHelper.GetPropertyValue(.Current, ReplaceProperty)
                    If SearchProperty = String.Empty OrElse SearchProperty.ToLower = BoundProperty.ToLower Then
                        vntReturn(2) = vntReturn(0)
                    Else
                        vntReturn(2) = ReflectionHelper.GetPropertyValue(.Current, SearchProperty)
                    End If
                    CallPromptForm = True
                Else
                    CallPromptForm = False
                End If
            End With
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "CallPromptForm")
        End Try
    End Function

    Public Function GetLookup() As Object Implements IWindowsAppManager.GetLookup
        Return mobjLookupObject
    End Function

    Public Function GetLayout() As CXLayoutFile Implements IWindowsAppManager.GetLayout
        Return mobjLayout
    End Function

    Public Function TypeFromString(ByVal ObjectName As String) As System.Type Implements IWindowsAppManager.TypeFromString
        Dim lookupType As Type = GetType(Lookup)
        Return lookupType.Assembly.GetType(GetType(Lookup).Namespace & "." & ObjectName)
    End Function

    Public Function CreateObjectEx(ByVal ObjectName As String) As Object Implements IWindowsAppManager.CreateObjectEx
        Dim objBO As Object = Activator.CreateInstance(TypeFromString(ObjectName), True)
        Try
            CType(objBO, BusinessBaseDerived).LookupObject = mobjLookupObject
        Catch
        End Try
        Return objBO
    End Function

    'param is BusinessCollectionBase
    'or a Bussiness type
    Public Function LoadForm(ByVal param As Object, Optional ByVal intPos As Integer = 0, Optional ByVal filters As Filters.CXFilters = Nothing, Optional ByVal GridCaller As RefreshCaller = Nothing, Optional ByVal DataFormType As CXDataForm.CXDataFormType = CXDataForm.CXDataFormType.cdfStandalone, Optional ByVal ParentDataForm As CXWinFormBase = Nothing, Optional ByVal ChildAddNewMode As Boolean = False) As CXWinFormBase Implements IWindowsAppManager.LoadForm
        Cursor.Current = Cursors.WaitCursor

        Dim A As System.Reflection.Assembly
        Dim frmX As CXDataForm
        A = GetType(frmMain).Module.Assembly
        Try
            '-------------------------------------------------------------------
            For Each frmY As Form In Me.MdiChildren
                If TypeInheritsFrom(frmY.GetType, GetType(CXDataForm)) Then
                    If TypeOf (param) Is BusinessCollectionBase Then
                        If Not ParentDataForm Is Nothing Then
                            If CType(frmY, CXDataForm).WindowDupKey = CType(param, BusinessCollectionBaseDerived).BusinessType.Name + Trim(ParentDataForm.FuncType) Then
                                CType(frmY, CXDataForm).DirectPosition = intPos
                                frmY.Select()
                                Return Nothing
                            End If
                        ElseIf CType(frmY, CXDataForm).ObjectType.Name = CType(param, BusinessCollectionBaseDerived).BusinessType.Name Then
                            CType(frmY, CXDataForm).DirectPosition = intPos
                            frmY.Select()
                            Return Nothing
                        End If
                        'Else
                        '    If CType(frmY, CXDataForm).ObjectType.Name = param.GetType.Name Then
                        '        frmY.Select()
                        '        Return Nothing
                        '    End If
                    End If
                End If
            Next
            '---------------------------------------------------------------------
            If TypeOf (param) Is BusinessCollectionBase Then
                If GetLayout.CXObjectLays(CType(param, BusinessCollectionBaseDerived).BusinessType.Name).UIType = UITypeEnum.utListOnly Then Return Nothing
                frmX = A.CreateInstance("YTUI.frm" & CType(param, BusinessCollectionBaseDerived).BusinessType.Name)
                frmX.DataFormType = DataFormType
                frmX.ParentDataForm = ParentDataForm
                frmX.DateFormatString = GetConDateFmt() & " HH:mm:ss"
                If Not ParentDataForm Is Nothing Then
                    frmX.FuncType = ParentDataForm.FuncType
                End If
                'If EnterChildFormFlag Then
                '    frmX.Tag = SetChildFormTagObj()
                'End If
                If Not frmX.Initialize(Me, CType(param, BusinessCollectionBase), filters, intPos) Then
                    frmX.Close()
                    Return Nothing
                End If


            Else
                If GetLayout.CXObjectLays(CType(param, Type).Name).UIType = UITypeEnum.utListOnly Then Return Nothing
                frmX = A.CreateInstance("YTUI.frm" & CType(param, Type).Name)
                frmX.DataFormType = DataFormType
                frmX.ParentDataForm = ParentDataForm
                frmX.DateFormatString = GetConDateFmt() & " HH:mm:ss"
                If Not ParentDataForm Is Nothing Then
                    frmX.FuncType = ParentDataForm.FuncType
                End If
                If Not frmX.Initialize(Me, CType(param, Type), filters) Then
                    frmX.Close()
                    Return Nothing
                End If
            End If
            frmX.InitChildFormDirtySavedStatus(ChildAddNewMode)
            If Not ParentDataForm Is Nothing Then
                If ParentDataForm.Editable Then
                    CType(frmX, IToolbarHost).InvokeToolAction("Edit", True)
                    'Else
                    '    CType(frmX, IToolbarHost).InvokeToolAction("Browse", True)
                End If
            End If
            If TypeOf (frmX) Is CXDialogForm Then
                CType(frmX, CXDialogForm).Editable = True
                If CType(frmX, CXDialogForm).ShowDialog(Me) = DialogResult.OK Then
                    If Not GridCaller Is Nothing Then GridCaller.Invoke()
                End If
                If Not ParentDataForm Is Nothing Then
                    If Not ParentDataForm.GetToolbarService Is Nothing Then
                        ParentDataForm.GetToolbarService.StartService(ParentDataForm)
                    End If
                End If
                frmX.Dispose()
                Return Nothing
            Else
                frmX.MdiParent = Me
                frmX.Caller = GridCaller
                frmX.Show()
                Return frmX
            End If
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "LoadForm")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Public ReadOnly Property IsRootDelegate() As COMExpress.Windows.Forms.Design.IsRootControl Implements COMExpress.Windows.Forms.IWindowsAppManager.IsRootDelegate
        Get
            Return AddressOf mControlHelper.IsRootControl
        End Get
    End Property

    Public ReadOnly Property PrintService() As COMExpress.Windows.Forms.IPrintService Implements COMExpress.Windows.Forms.IWindowsAppManager.PrintService
        Get
        End Get
    End Property

    Public ReadOnly Property ToolbarService() As COMExpress.Windows.Forms.IToolbarService Implements COMExpress.Windows.Forms.IWindowsAppManager.ToolbarService
        Get
            Return tbMain
        End Get
    End Property
#End Region

#Region " Event Handlers"

    Private Sub LogMenuStatus(ByVal Logoned As Boolean)
        If Logoned Then
            mobjMenu.ButtonVisibility("mnuFileLogin") = False
            mobjMenu.ButtonVisibility("mnuFileChangePwd") = True
            mobjMenu.ButtonVisibility("mnuFileLogOff") = True
        Else
            mobjMenu.ButtonVisibility("mnuFileLogin") = True
            mobjMenu.ButtonVisibility("mnuFileChangePwd") = False
            mobjMenu.ButtonVisibility("mnuFileLogOff") = False
        End If
    End Sub



    Private Sub MenuClicked(ByVal Key As String, ByVal Parameter As String) Handles mobjMenu.ItemClick

        Select Case Key
            Case "mnuFileLogin" : LogOn()
            Case "mnuFileLogOff" : LogOff()
            Case "mnuFileChangePwd"
                Dim frmPwd As New frmChangePwd
                frmPwd.ShowDialog(Me)
                frmPwd.Dispose()
                frmPwd = Nothing
                GC.Collect()
            Case "mnuFileClose"
                CloseMdi()
            Case "mnuFileCloseAll", "mnuWindowCloseAll"
                CloseMdi(True)
            Case "mnuFileExit"
                'Application.Exit()
                If QuestionMsg("ID_qsn_msg_frmMain_ConfirmQuit", , "Do you confirm to quit system") = MsgBoxResult.Yes Then
                    SaveLogOffLog()
                    quitQsnFlag = False
                    Application.Exit()
                End If
            Case "mnuHelpAbout"
                CallHelpAbout()
            Case "mnuProductionOrder"
                tvSW_LoadObject("clsordhdr", "")
            Case "mnuLogs"
                tvSW_LoadObject("clslogs", "")
            Case "mnuUers"
                tvSW_LoadObject("clsusers", "")
            Case "mnuSystemOption"
                CallHelpAbout()
            Case "mnuViewCmdTree"
                Me.SwitchboardVisibility = Not Me.SwitchboardVisibility
            Case "mnuViewStatusBar"
                Me.StatusbarVisibility = Not Me.StatusbarVisibility
            Case "mnuWindowArrangeIcons"
                Me.LayoutMdi(MdiLayout.ArrangeIcons)
            Case "mnuWindowCascade"
                Me.LayoutMdi(MdiLayout.Cascade)
            Case "mnuWindowTileHorizontal"
                Me.LayoutMdi(MdiLayout.TileHorizontal)
            Case "mnuWindowTileVertical"
                Me.LayoutMdi(MdiLayout.TileVertical)
            Case "mnuWarehouseskumeasure"
                tvSW_LoadObject("clsskumeasure", "")
            Case "mnuWarehousedamage"
                tvSW_LoadObject("clsdamage", "")
            Case "mnuWarehouseccnhdr"
                tvSW_LoadObject("clsccnhdr", "")
            Case "mnuWarehousebox"
                tvSW_LoadObject("clsboxhdr", "")
            Case "mnuWarehousecdnhdr"
                tvSW_LoadObject("clscdnhdr", "")
            Case "mnuWarehouseqrysno"
                tvSW_LoadObject("clsqrysno", "")
            Case "mnuWarehousestocksno"
                tvSW_LoadObject("clsstocksno", "")
            Case "mnuWarehouseqryorder"
                tvSW_LoadObject("clsqryorder", "")
            Case Else
                Try
                    Dim strMenuKey As String
                    If InStr(Key, clsRelatedMenu.MenuPrefix) > 0 Then
                        strMenuKey = Mid(Key, Len(clsRelatedMenu.MenuPrefix) + 1)
                        'RelatedCallMenu(strMenuKey, Parameter)
                    ElseIf Parameter <> String.Empty Then
                        Me.tvSW_LoadObject(Parameter, "")
                    End If
                Catch ex As Exception
                    LogMsg(ex, Me.GetType, "mobjMenu_ItemClick")
                End Try
        End Select


    End Sub

    Private Sub tbMain_ItemClick(ByVal Key As String, ByVal Parameter As String) Handles tbMain.ItemClick
        Select Case Key
            Case "Main"
                CType(Me, IWindowsAppManager).SwitchboardVisibility = Not CType(Me, IWindowsAppManager).SwitchboardVisibility
            Case "Quit"
                If QuestionMsg("ID_qsn_msg_frmMain_ConfirmQuit", , "Do you confirm to quit system") = MsgBoxResult.Yes Then
                    SaveLogOffLog()
                    quitQsnFlag = False
                    Application.Exit()
                End If
        End Select
    End Sub




    Public Function MainFormTitle() As String
        Dim str As String
        str = mobjLayout.ApplicationTitle

        Return str + " " + GetSystemTypeOption()

    End Function

    Private Sub LoadFunction()

        'Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("en-US")
        Thread.CurrentThread.CurrentUICulture = New Globalization.CultureInfo("zh-cn")


        Try
            mobjAppSettings = WindowsAppSettings.GetSettings(Application.UserAppDataPath().Replace("\" & Application.ProductVersion, "") & AppConfigFile)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim splash As New frmSplashScreen
        splash.Show()
        splash.Update()


        [Global].InitializeApp(Me)

        With mobjAppSettings
            If .Width <> 0 And .Height <> 0 Then
                Me.Left = .Left
                Me.Top = .Top
                Me.Width = .Width
                Me.Height = .Height
            End If
        End With

        mobjLookupObject = New Lookup
        Dim sTemp As String
        Dim sLayFile As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
        sTemp = sLayFile & "\YT_lay.xml"
        If Trim(Dir(sTemp)) <> "" Then
            mobjLayout = CXLayoutFile.NewLayoutFile(sTemp, Me)
        Else

            sTemp = GetDBDirectory() & "\YT_lay.xml"
            If System.IO.File.Exists(sTemp) Then
                mobjLayout = CXLayoutFile.NewLayoutFile(sTemp, Me)
            Else
                mobjLayout = CXLayoutFile.NewLayoutFile(System.IO.Path.GetDirectoryName(Application.ExecutablePath) & "\YT_lay.xml", Me)
            End If
        End If

        mobjMenu = New MenuService(Me.mnuMain, Me)
        mobjSB = New StatusbarService(Me.sbMain)

        ToolbarHelper.InitializeToolbarService(Me, tbMain)
        If mobjAppSettings.SwitchboardWidth <> 0 Then Me.tvSW.Width = mobjAppSettings.SwitchboardWidth
        SwitchboardVisibility = mobjAppSettings.ShowSwitchboard
        StatusbarVisibility = mobjAppSettings.ShowStatusbar

        ' 2007-07-22, Simon Lei, - Close splash form first before login
        splash.Close()
        splash.Dispose()

        LogOn()

        Dim info As Reflection.MethodInfo = ReflectionHelper.GetMethod(Me.GetType, "AfterFrmMainLoad")
        If Not (info Is Nothing) Then
            info.Invoke(Me, Nothing)
        End If

        With mobjLayout
            If Not .ApplicationIcon Is Nothing Then Me.Icon = .ApplicationIcon
            'Me.Text = .ApplicationTitle
        End With

        Me.Text = MainFormTitle()

        For i As Integer = 1 To tvSW.GetNodeCount(False) - 1
            tvSW.Nodes(i).Collapse()
        Next


        RelatedMenu.Clear()
        RelatedMenu.Refresh()

        'SetMnuRelatedEnabled(False)
        Me.WindowState = FormWindowState.Maximized

        If UserRightMgr.LoginSuccess = False Then
            Exit Sub
        End If
        SaveClient()
        TimerClient.Interval = 1000 * 60 * 50       '每5分钟
        TimerClient.Enabled = False
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadFunction()
    End Sub

    Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If quitQsnFlag Then
            If QuestionMsg("ID_qsn_msg_frmMain_ConfirmQuit", , "Do you confirm to quit system") = MsgBoxResult.Yes Then
                SaveLogOffLog()
                Try
                    With mobjAppSettings
                        .Left = Me.Left
                        .Top = Me.Top
                        .Width = Me.Width
                        .Height = Me.Height
                        .SwitchboardWidth = tvSW.Width
                        .ShowStatusbar = StatusbarVisibility
                        .ShowSwitchboard = tvSW.Visible
                        .SaveSettings(mobjAppSettings, Application.UserAppDataPath().Replace("\" & Application.ProductVersion, "") & AppConfigFile)
                    End With
                Catch ThisException As Exception
                    ErrorMsg(ThisException, Me.GetType, "frmMain_Closing")
                End Try
                TimerClient.Enabled = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub


    Private Sub frmMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.tvSW.Width = Me.splMain.Left
    End Sub

    Private Sub splMain_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles splMain.Move
        tvSW.Width = Me.splMain.Left
        Try
            Me.RefreshMdiClient()
        Catch
        End Try
    End Sub


    Private Sub TimerClose_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerClose.Tick
        TimerClose.Enabled = False
        quitQsnFlag = False
        Application.Exit()
    End Sub




#End Region

#Region " ISwitchboardHost Implementation"

    Private Sub tvSW_LoadObject(ByVal strObjectName As String, ByVal sFuncType As String) Implements ISwitchboardHost.LoadObject
        GC.Collect()
        Dim strRightNo As String = ""
        If SecurityManager.CheckSBRight(strObjectName, "LIST") = False Then
            Message("ID_msg_NoRight", True, "无此权限.")
            Exit Sub
        End If
        Cursor.Current = Cursors.WaitCursor
        Try
            If Me.mobjLayout.CXObjectLays.Contains(strObjectName) = True Then
                Dim intStartup As CXStartupMode = Me.mobjLayout.CXObjectLays(strObjectName).StartupMode
                Dim frmY As Form
                Dim frmX As CXWinFormBase

                For Each frmY In Me.MdiChildren
                    If TypeInheritsFrom(frmY.GetType, GetType(CXWinFormBase)) Then
                        If Trim(sFuncType) <> "" Then
                            If CType(frmY, CXWinFormBase).WindowDupKey = strObjectName + Trim(sFuncType) Then
                                frmY.Select()
                                Return
                            End If
                        ElseIf CType(frmY, CXWinFormBase).ObjectType.Name = strObjectName Then
                            frmY.Select()
                            Return
                        End If
                    End If
                Next
                Select Case intStartup
                    Case CXStartupMode.spmEdit
                        Dim objType As Type = CType(Me, IWindowsAppManager).TypeFromString(strObjectName)
                        Dim obj As BusinessBase = _
                            CType(ReflectionHelper.CallStaticMethod( _
                            objType, _
                            "New" & objType.Name), BusinessBase)
                        Dim objCol As BusinessCollectionBase = CType(ReflectionHelper.CallStaticMethod(obj.GetType, "LoadListFromObj", obj, 1), BusinessCollectionBase)
                        Me.LoadForm(objCol)
                    Case CXStartupMode.spmEditAll
                        Me.LoadForm(CType(Me, IWindowsAppManager).TypeFromString(strObjectName))
                    Case CXStartupMode.spmPGBrowse
                        frmX = New frmObjectPropGrid
                        If frmX.Initialize(Me, CType(Me, IWindowsAppManager).TypeFromString(strObjectName), , intStartup = CXStartupMode.spmSearch) Then
                            frmX.MdiParent = Me
                            frmX.Show()
                        Else
                            frmX.Close()
                        End If
                    Case Else
                        Dim fl As Filters.CXFilters
                        frmX = New frmObjectList
                        frmX.FuncType = sFuncType
                        fl = GetFunctionFilters(strObjectName, sFuncType, strRightNo)
                        frmX.DateFormatString = GetConDateFmt() & " HH:mm:ss"
                        If frmX.Initialize(Me, CType(Me, IWindowsAppManager).TypeFromString(strObjectName), fl, intStartup = CXStartupMode.spmSearch) Then
                            frmX.MdiParent = Me
                            frmX.Show()
                        Else
                            frmX.Close()
                        End If
                End Select
            Else
                If GetLayout.CXSWItems.Contains(strObjectName) Then
                    'please insert a "CustomSwitchboardHandler" in the custom code section to handle the custom items
                    'the function should be like:
                    'Private Sub CustomSwitchboardHandler(ByVal Key As String)
                    '   select case key
                    '   ...
                    '   end select
                    'end sub
                    'Dim info As Reflection.MethodInfo = ReflectionHelper.GetMethod(Me.GetType, "CustomSwitchboardHandler")

                    CustomSwitchboardHandler(strObjectName)
                End If
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub tvSW_ItemAdded(ByVal Key As String, ByVal Caption As String, ByVal Img As Object, ByVal ParentKey As String) Implements ISwitchboardHost.OnItemAdded

        mobjMenu.CommandItemAdded(Key, Caption, Img, ParentKey)

    End Sub

    Private Sub tvSW_ItemCleared() Implements ISwitchboardHost.OnItemCleared
        mobjMenu.CommandItemCleared()
    End Sub

    Public Sub CheckItemBeforeAdd(ByVal Key As String, ByRef bAdd As Boolean) Implements COMExpress.Windows.Forms.ISwitchboardHost.CheckItemBeforeAdd
        bAdd = True
        If InStr(Key, "POP") > 0 Then
            If ProgramType.Phase < ProgramType.PhaseType.Phase15 Then
                bAdd = False
            End If
        End If
    End Sub

#End Region
#End Region
#Region " Related Function"

    Public WithEvents RelatedMenu As New clsRelatedMenu(mobjMenu)




    'mnuRelaData

    Private Sub RelatedMenu_RefreshNotify() Handles RelatedMenu.RefreshNotify
        Try
            mobjMenu.BuildRelatedMenu(RelatedMenu)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub LoadRelatedObjectList(ByVal BusinessObj As BusinessCollectionBaseDerived, ByVal objFilters As Filters.CXFilters, Optional ByVal vFuncType As String = "")
        Try
            For Each frmY As Form In Me.MdiChildren
                If TypeInheritsFrom(frmY.GetType, GetType(CXListForm)) Then
                    If CType(CType(frmY, CXListForm).DataSource, BusinessCollectionBaseDerived).BusinessType.Name = BusinessObj.BusinessType.Name Then
                        frmY.Close()
                    End If
                End If
            Next
            'LoadForm(BusinessObj.BusinessType, 0, objFilters)
            Dim frmX As frmObjectList
            Dim strObjectName As String
            strObjectName = BusinessObj.BusinessType.Name
            frmX = New frmObjectList
            frmX.FuncType = vFuncType
            frmX.DefaultFilters = objFilters
            frmX.DateFormatString = GetConDateFmt() & " HH:mm:ss"
            'Lookup.SetStatusFilter(strObjectName)
            If frmX.Initialize(Me, CType(Me, IWindowsAppManager).TypeFromString(strObjectName), , False) Then
                frmX.MdiParent = Me
                'frmX.Filters = New Filters.CXFilters
                frmX.AutoRefreshFlag = False
                frmX.Show()
                frmX.AutoRefreshFlag = True
            Else
                frmX.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadRelatedDataForm(ByVal BusinessObj As BusinessCollectionBaseDerived, ByVal objFilters As Filters.CXFilters, Optional ByVal vFuncType As String = "")
        Try
            For Each frmY As Form In Me.MdiChildren
                If TypeInheritsFrom(frmY.GetType, GetType(CXDataForm)) Then
                    If CType(frmY, CXDataForm).ObjectType.Name = BusinessObj.BusinessType.Name Then
                        frmY.Close()
                    End If
                End If
            Next
            LoadFormWithFuncType(BusinessObj, 0, objFilters, vFuncType)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub CloseFormWithFuncType(ByVal param As Object, ByVal vFuncType As String)
        Dim A As System.Reflection.Assembly
        Dim frmX As CXDataForm
        A = GetType(frmMain).Module.Assembly
        Try
            For Each frmY As Form In Me.MdiChildren
                If TypeInheritsFrom(frmY.GetType, GetType(CXDataForm)) Then
                    If TypeOf (param) Is BusinessCollectionBase Then
                        If CType(frmY, CXDataForm).WindowDupKey = CType(param, BusinessCollectionBaseDerived).BusinessType.Name + Trim(vFuncType) Then
                            frmY.Close()
                            Return
                        End If
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Function LoadFormWithFuncType(ByVal param As Object, Optional ByVal intPos As Integer = 0, Optional ByVal filters As Filters.CXFilters = Nothing, Optional ByVal vFuncType As String = "")
        Cursor.Current = Cursors.WaitCursor

        Dim A As System.Reflection.Assembly
        Dim frmX As CXDataForm
        A = GetType(frmMain).Module.Assembly
        Try
            For Each frmY As Form In Me.MdiChildren
                If TypeInheritsFrom(frmY.GetType, GetType(CXDataForm)) Then
                    If TypeOf (param) Is BusinessCollectionBase Then
                        'If Not ParentDataForm Is Nothing Then
                        If CType(frmY, CXDataForm).WindowDupKey = CType(param, BusinessCollectionBaseDerived).BusinessType.Name + Trim(vFuncType) Then
                            CType(frmY, CXDataForm).DirectPosition = intPos
                            frmY.Select()
                            Return Nothing
                        End If
                        'ElseIf CType(frmY, CXDataForm).ObjectType.Name = CType(param, BusinessCollectionBaseDerived).BusinessType.Name Then
                        '    CType(frmY, CXDataForm).DirectPosition = intPos
                        '    frmY.Select()
                        '    Return Nothing
                        'End If
                        'Else
                        '    If CType(frmY, CXDataForm).ObjectType.Name = param.GetType.Name Then
                        '        frmY.Select()
                        '        Return Nothing
                        '    End If
                    End If
                End If
            Next

            If TypeOf (param) Is BusinessCollectionBase Then
                If GetLayout.CXObjectLays(CType(param, BusinessCollectionBaseDerived).BusinessType.Name).UIType = UITypeEnum.utListOnly Then Return Nothing
                frmX = A.CreateInstance("YTUI.frm" & CType(param, BusinessCollectionBaseDerived).BusinessType.Name)
                frmX.DataFormType = CXDataForm.CXDataFormType.cdfStandalone
                frmX.ParentDataForm = Nothing
                frmX.DateFormatString = GetConDateFmt() & " HH:mm:ss"
                'If Not ParentDataForm Is Nothing Then
                frmX.FuncType = vFuncType ' ParentDataForm.FuncType
                'End If
                'If EnterChildFormFlag Then
                '    frmX.Tag = SetChildFormTagObj()
                'End If
                If Not frmX.Initialize(Me, CType(param, BusinessCollectionBase), filters, intPos) Then
                    frmX.Close()
                    Return Nothing
                End If

            Else
                If GetLayout.CXObjectLays(CType(param, Type).Name).UIType = UITypeEnum.utListOnly Then Return Nothing
                frmX = A.CreateInstance("YTUI.frm" & CType(param, Type).Name)
                frmX.DataFormType = CXDataForm.CXDataFormType.cdfStandalone ' DataFormType
                frmX.ParentDataForm = Nothing ' ParentDataForm
                frmX.DateFormatString = GetConDateFmt() & " HH:mm:ss"
                'If Not ParentDataForm Is Nothing Then
                frmX.FuncType = vFuncType ' ParentDataForm.FuncType
                'End If
                If Not frmX.Initialize(Me, CType(param, Type), filters) Then
                    frmX.Close()
                    Return Nothing
                End If
            End If
            frmX.InitChildFormDirtySavedStatus(False)
            'If Not ParentDataForm Is Nothing Then
            'If ParentDataForm.Editable Then
            '    CType(frmX, IToolbarHost).InvokeToolAction("Edit", True)
            '    'Else
            '    '    CType(frmX, IToolbarHost).InvokeToolAction("Browse", True)
            'End If
            'End If
            If TypeOf (frmX) Is CXDialogForm Then
                CType(frmX, CXDialogForm).Editable = True
                If CType(frmX, CXDialogForm).ShowDialog(Me) = DialogResult.OK Then
                    'If Not GridCaller Is Nothing Then GridCaller.Invoke()
                End If
                'If Not ParentDataForm Is Nothing Then
                '    If Not ParentDataForm.GetToolbarService Is Nothing Then
                '        ParentDataForm.GetToolbarService.StartService(ParentDataForm)
                '    End If
                'End If
                frmX.Dispose()
                Return Nothing
            Else
                frmX.MdiParent = Me
                frmX.Caller = Nothing ' GridCaller
                frmX.Show()
                Return frmX
            End If
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "LoadForm")
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

#End Region
#Region " CustomSwitchboardHandler"
    'This section will not be overwritten during a round-trip code generation
    Private Sub CustomSwitchboardHandler(ByVal Key As String)
        Try
            If SecurityManager.CheckSBRight(Key, "LOAD") = False Then
                Message("ID_msg_NoRight", True, "无此权限.")
                Exit Sub
            End If
            Select Case Key
                ''发货单
                Case "clsdnhdrALL"   ''发货单(全部)
                    CallIAllDn()
                Case "clsdnhdrNotSatrtDn"   ''发货单(未处理)
                    CallINotStartDn()
                Case "clsdnhdrStartDn"   ''发货单(处理中)
                    CallIStartDn()
                Case "clsdnhdrFinishedtDn"   ''发货单(已完成)
                    Me.CallIFinishedtDn()
                    ''发货批次
                Case "clsbchhdrALL"   ''发货批次(全部)
                    CallIAllBanch()
                Case "clsbchhdrNotStartBanch"   ''发货批次(未处理)
                    CallINotStartBanch()
                Case "clsbchhdrStartBanch"   ''发货批次(处理中)
                    CallIStartBanch()
                Case "clsbchhdrFinishedBanch"   ''发货批次(已完成)
                    Me.CallIFinishedtBanch()
                Case "capbanch"   ''发货单组批(初始)
                    CallOutboundCheckOrder(False, "OPEN")
                Case "capbanchlist"   ''发货单组批（全部）
                    CallOutboundCheckOrder(False, "ALL")
                Case "capImpBin"
                    CallImportBin()
                    'CallImportBinArea()
                Case "capImpSKU"
                    CallImportSKU()
                Case "capImpDN"
                    CallImportDN()
                Case "impCity"
                    CallImportAirPort()
                Case "clsSnReports"
                    Dim _SNPrint As New SNPrint
                    SetModalFormStyle(_SNPrint)
                    If _SNPrint.ShowDialog <> DialogResult.OK Then
                        Exit Sub
                    End If
                Case "clsOperatorEffect"
                    Dim _frm As New frmPerformance
                    SetModalFormStyle(_frm)
                    If _frm.ShowDialog <> DialogResult.OK Then
                        Exit Sub
                    End If
                Case "clsDnDetailReports"
                    Dim _frm As New frmDNList
                    SetModalFormStyle(_frm)
                    If _frm.ShowDialog <> DialogResult.OK Then
                        Exit Sub
                    End If
                Case "clsOperatorDeatail"
                    Dim _frm As New frmOperateStatus
                    SetModalFormStyle(_frm)
                    If _frm.ShowDialog <> DialogResult.OK Then
                        Exit Sub
                    End If
                Case "clsCityBin"
                    Dim _frm As New frmExportCityBin
                    SetModalFormStyle(_frm)
                    If _frm.ShowDialog <> DialogResult.OK Then
                        Exit Sub
                    End If
                Case "importBarcode"
                    CallImportBarcode()
                Case "clsBanchReports"
                    Dim _frm As New frmBatch
                    SetModalFormStyle(_frm)
                    _frm.MaximizeBox = True
                    If _frm.ShowDialog <> DialogResult.OK Then
                        Exit Sub
                    End If
            End Select
        Catch ex As Exception
            Dim str As String
            Microsoft.VisualBasic.MsgBox("System Error, please see log :" + ex.Message, MsgBoxStyle.Critical)
            str = "System Error:" + ex.Message + "(" + ex.GetType.Name + ")" + vbCrLf + ex.StackTrace
            COMExpress.BusinessObject.CXEventLog.LogToFile(str, CXEventLog.LogTypeConstants.logUI)
        End Try
    End Sub
#End Region
#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"

    Private Sub SaveLogOffLog()
        On Error Resume Next

        'Dim sl As clstranslog
        'sl = sl.Newclstranslog
        'sl.trans_type = "SEC"
        'sl.cmd_type = GeneralType.CmdType.LogoutCmd
        'sl.opt_by = UserRightMgr.gUserCode
        'sl.dc_code = UserRightMgr.gDcCode
        'sl.opt_dtime = Now
        'sl.clt_ver = GetCurrentVersion()
        'sl.Save()
        ''Dim clt As clsclient
        ''clt = clsclient.Load(Lookup.GetMacAddress, UserRightMgr.gUserCode)
        ''If clt.IsNew Then
        ''    Exit Sub
        ''End If
        ''clt.Delete()
        ''clt.Save()
        'ClientManager.Remove(UserRightMgr.gUserCode)
    End Sub

    Private Sub AfterFrmMainLoad()
    End Sub




    'Public Sub SetMnuEnabled(ByVal MnuKey As String, ByVal flag As Boolean)
    '    mobjMenu.ButtonEnabled(MnuKey) = flag
    'End Sub




#End Region
#Region " Call function for Menu and switchboard"
    Public Sub LoadObjectList(ByVal strObjectName As String, ByVal sFuncType As String, Optional ByVal filters As Filters.CXFilters = Nothing)
        GC.Collect()
        Dim strRightNo As String = ""
        strRightNo = GetBrowserRight(strObjectName, sFuncType)

        Cursor.Current = Cursors.WaitCursor
        Try
            If Me.mobjLayout.CXObjectLays.Contains(strObjectName) = True Then
                Dim intStartup As CXStartupMode = Me.mobjLayout.CXObjectLays(strObjectName).StartupMode
                Dim frmY As Form
                Dim frmX As CXWinFormBase

                For Each frmY In Me.MdiChildren
                    If TypeInheritsFrom(frmY.GetType, GetType(CXWinFormBase)) Then
                        If Trim(sFuncType) <> "" Then
                            If CType(frmY, CXWinFormBase).WindowDupKey = strObjectName + Trim(sFuncType) Then
                                frmY.Close()
                            End If
                        ElseIf CType(frmY, CXWinFormBase).ObjectType.Name = strObjectName Then
                            frmY.Close()
                        End If
                    End If
                Next
                Application.DoEvents()

                Dim fl As Filters.CXFilters
                frmX = New frmObjectList
                fl = GetFunctionFilters(strObjectName, sFuncType, strRightNo)
                If fl Is Nothing Then
                    fl = filters
                ElseIf Not filters Is Nothing Then
                    ' fl.Add(filters)
                    '-------------------------------------bxzhang 2008-06-13
                    If (Not fl.IsCollection) Then
                        Dim a As New Filters.CXFilters
                        a.Add(fl)
                        a.Add(filters)
                        'a.IndexName = filters.IndexName
                        fl = a
                    Else
                        Dim b As New Filters.CXFilters
                        b.Add(filters)
                        'b.IndexName = filters.IndexName
                        fl.Add(b)
                    End If
                    '--------------------------------------
                End If
                frmX.DateFormatString = GetConDateFmt() & " HH:mm:ss"
                frmX.FuncType = sFuncType
                If frmX.Initialize(Me, CType(Me, IWindowsAppManager).TypeFromString(strObjectName), fl) Then
                    frmX.MdiParent = Me
                    frmX.Show()
                Else
                    frmX.Close()
                End If
            End If
        Finally
            Cursor.Current = Cursors.Default
        End Try
        GC.Collect()
    End Sub
    '帮助
    Private Sub CallHelpAbout()
        Dim rst As DialogResult
        Dim frm As New frmAbout
        SetModalFormStyle(frm)
        rst = frm.ShowDialog(Me)
        frm.Dispose()
        frm = Nothing
        GC.Collect()
    End Sub
    Private Sub CallSystemChange()
        Dim frm As Form
        Dim strPath As String
        strPath = GetConfigPath()
        If Trim(strPath) = "" Then
            Exit Sub
        End If
        For Each frm In Me.MdiChildren
            frm.Close()
            frm.Dispose()
        Next
        GC.Collect()
        frm = New frmConfigSelect
        SetModalFormStyle(frm)
        If frm.ShowDialog(Me) = DialogResult.Yes Then
            RestartProgram()
        End If
        frm.Dispose()
        frm = Nothing

    End Sub
    Public Sub CallOutboundCheckOrder(ByVal bShowForm As Boolean, ByVal sFuncType As String)
        If bShowForm Then
            Dim frm As New frmNormalDnBanch
            frm.ShowInTaskbar = False
            frm.Icon = Me.Icon
            SetModalFormStyle(frm)
            frm.ShowDialog(Me)
            frm.Dispose()
            frm = Nothing
            GC.Collect()
        Else
            Me.tvSW_LoadObject("clsbchhdr", sFuncType)
        End If
    End Sub
    Public Sub CallAssignTaskForOrder(ByVal bShowForm As Boolean, ByVal sFuncType As String)
        If bShowForm Then
            Dim frm As New frmAssignTask
            frm.ShowInTaskbar = False
            frm.Icon = Me.Icon
            SetModalFormStyle(frm)
            frm.ShowDialog(Me)
            frm.Dispose()
            frm = Nothing
            GC.Collect()
        Else
            Me.tvSW_LoadObject("clstaskhdr", sFuncType)
        End If
    End Sub
#End Region
#Region " Export Functions"

#End Region
#Region " Import function"
    Public Function CallImportGeneral(ByVal vFileType As ImportExport.File.FileType, ByVal vDataFile As String, ByVal vPath As String, ByVal vBussiness As String, ByVal vXmlFile As String, ByVal vCaption As String, ByVal right_no As String)
        Dim frm As New frmImport
        frm.Right_no = right_no
        frm.CaptionText = vCaption

        frm.SetDefaultValue(vFileType, vDataFile, vPath, vBussiness, False, GetLibFile(vXmlFile))
        'Set Default value
        SetModalFormStyle(frm)

        If frm.ShowDialog <> DialogResult.OK Then
            Exit Function
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim p As New ImportExport.ProcessorBase(MainForm)
        Try
            If vFileType = ImportExport.File.FileType.XLS Then
                p.SetSourceDevice(frm.ImportFileName, "xlsfile")
            ElseIf vFileType = ImportExport.File.FileType.TXT Or vFileType = ImportExport.File.FileType.CSV Then
                p.SetSourceDevice(frm.ImportFileName, "txtfile")
            End If
            '2010-02-05 add by lfish
            Dim dtmTest As Date
            Dim Seq_id As String
            dtmTest = TimeValue(Now)
            Seq_id = Format(dtmTest, "yyyyMMddhhmmssffffFF")
            p.SetRuntimeValue("id", Seq_id)
            '
            p.RunImport(GetLibFile(vXmlFile))
            Message("ID_cap_Import_Result_Success", True, "导入成功")
        Catch ex As Exception
            ErrorMsg(ex, p.GetType, "CallImportGeneral")
        Finally
            p = Nothing
            For i As Integer = 0 To 10
                GC.Collect()
                Threading.Thread.Sleep(10)
                Application.DoEvents()
            Next
        End Try

        Me.Cursor = Cursors.Default
        frm.Dispose()
        frm = Nothing
    End Function
    Public Sub CallImportDNGeneral(ByVal vFileType As ImportExport.File.FileType, ByVal vDataFile As String, ByVal vPath As String, ByVal vBussiness As String, ByVal vXmlFile As String, ByVal vCaption As String, ByVal right_no As String, ByVal frm As frmDNImport)
        Dim parmUserCode As String = UserRightMgr.gUserCode
        frm.Right_no = right_no
        frm.CaptionText = vCaption

        frm.SetDefaultValue(vFileType, vDataFile, vPath, vBussiness, False, GetLibFile(vXmlFile))
        'Set Default value
        SetModalFormStyle(frm)

        If frm.ShowDialog <> DialogResult.OK Then
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim p As New ImportExport.ProcessorBase(MainForm)
        'Try
        '    If vFileType = ImportExport.File.FileType.XLS Then
        '        p.SetSourceDevice(frm.ImportFileName, "xlsfile")
        '    ElseIf vFileType = ImportExport.File.FileType.TXT Or vFileType = ImportExport.File.FileType.CSV Then
        '        p.SetSourceDevice(frm.ImportFileName, "txtfile")
        '    End If
        '    '2010-02-05 add by lfish
        '    Dim dtmTest As Date
        '    Dim Seq_id As String
        '    dtmTest = TimeValue(Now)
        '    Seq_id = Format(dtmTest, "yyyyMMddhhmmssffffFF")
        '    p.SetRuntimeValue("id", Seq_id)
        '    p.SetRuntimeValue("opt_by", parmUserCode)
        '    p.SetRuntimeValue("sony_bch_no", frm.txtBchNo.Text.Trim())
        '    p.SetRuntimeValue("doc_type", frm.cmbType.SelectedIndex)

        '    '
        '    p.RunImport(GetLibFile(vXmlFile))
        '    Message("ID_cap_Import_Result_Success", True, "导入成功")
        'Catch ex As Exception
        '    ErrorMsg(ex, p.GetType, "CallImportGeneral")
        'Finally
        '    p = Nothing
        '    For i As Integer = 0 To 10
        '        GC.Collect()
        '        Threading.Thread.Sleep(10)
        '        Application.DoEvents()
        '    Next
        'End Try

        Me.Cursor = Cursors.Default
        frm.Dispose()
        frm = Nothing
    End Sub
    Public Function CallImportAirPortGeneral(ByVal vFileType As ImportExport.File.FileType, ByVal vDataFile As String, ByVal vPath As String, ByVal vBussiness As String, ByVal vXmlFile As String, ByVal vCaption As String, ByVal right_no As String, ByVal frm As frmAirPortImport)
        frm.Right_no = right_no
        frm.CaptionText = vCaption

        frm.SetDefaultValue(vFileType, vDataFile, vPath, vBussiness, False, GetLibFile(vXmlFile))
        'Set Default value
        SetModalFormStyle(frm)

        If frm.ShowDialog <> DialogResult.OK Then
            Exit Function
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim p As New ImportExport.ProcessorBase(MainForm)
        Try
            If vFileType = ImportExport.File.FileType.XLS Then
                p.SetSourceDevice(frm.ImportFileName, "xlsfile")
            ElseIf vFileType = ImportExport.File.FileType.TXT Or vFileType = ImportExport.File.FileType.CSV Then
                p.SetSourceDevice(frm.ImportFileName, "txtfile")
            End If
            '2010-02-05 add by lfish
            Dim dtmTest As Date
            Dim Seq_id As String
            dtmTest = TimeValue(Now)
            Seq_id = Format(dtmTest, "yyyyMMddhhmmssffffFF")
            p.SetRuntimeValue("id", Seq_id)
            p.SetRuntimeValue("type", frm.cmbType.SelectedIndex)

            '
            p.RunImport(GetLibFile(vXmlFile))
            Message("ID_cap_Import_Result_Success", True, "导入成功")
        Catch ex As Exception
            ErrorMsg(ex, p.GetType, "CallImportGeneral")
        Finally
            p = Nothing
            For i As Integer = 0 To 10
                GC.Collect()
                Threading.Thread.Sleep(10)
                Application.DoEvents()
            Next
        End Try

        Me.Cursor = Cursors.Default
        frm.Dispose()
        frm = Nothing
    End Function
    Public Sub CallImportBin()
        Dim str As String
        Dim frm As New frmImport
        str = PublicResource.LoadResString("ID_capImpBin", "Bin导入")
        Dim p As New ImportExport.ProcessorBase(MainForm)
        p.SetSourceDevice(frm.ImportFileName, "xlsfile")
        'p.SetRuntimeValue("id", "BIN")
        Call CallImportGeneral(ImportExport.File.FileType.XLS, "Bin.xls", "", "Bin", "ImpBin.xml", str, Rights.BINAREALOAD)
    End Sub
    Public Sub CallImportSKU()
        Dim str As String
        Dim frm As New frmImport
        str = PublicResource.LoadResString("ID_capImpSKU", "SKU导入")
        Dim p As New ImportExport.ProcessorBase(MainForm)
        'p.SetSourceDevice(frm.ImportFileName, "xlsfile") '保留原先导入xls文件功能
        p.SetSourceDevice(frm.ImportFileName, "txtfile")
        'p.SetRuntimeValue("id", "SKU")
        'Call CallImportGeneral(ImportExport.File.FileType.XLS, "SKU.xls", "", "SKU", "ImpSKU.xml", str, Rights.SKUINFOLOAD) '保留原先导入xls文件功能
        'Call CallImportGeneral(ImportExport.File.FileType.TXT, "SKU.txt", "", "SKU", "ImpSKUTXT.xml", str, Rights.SKUINFOLOAD)
        Call CallImportGeneral(ImportExport.File.FileType.TXT, "SKU.txt", "", "SKU", "ImpSKU1.xml", str, Rights.SKUINFOLOAD)
    End Sub
    Public Sub CallImportDN()
        Dim str As String
        Dim frm As New frmDNImport
        str = PublicResource.LoadResString("ID_capImpDN", "DN导入")
        Dim p As New ImportExport.ProcessorBase(MainForm)
        p.SetSourceDevice(frm.ImportFileName, "txtfile")
        'p.SetRuntimeValue("id", "TEST")
        Call CallImportDNGeneral(ImportExport.File.FileType.CSV, "DN.csv", "", "DN", "ImpDN.xml", str, Rights.DNHDRLOAD, frm)
    End Sub
    Public Sub CallImportBinArea()
        Dim str As String
        Dim frm As New frmImport
        str = PublicResource.LoadResString("ID_cap_Import_BinArea", "BinArea导入")
        Dim p As New ImportExport.ProcessorBase(MainForm)
        p.SetSourceDevice(frm.ImportFileName, "xlsfile")
        'p.SetRuntimeValue("id", "TEST")
        Call CallImportGeneral(ImportExport.File.FileType.XLS, "ImpBinArea.xls", "", "BinArea", "ImpBinArea.xml", str, Rights.BINAREALOAD)
    End Sub
    Public Sub CallImportAirPort()
        Dim str As String
        Dim frm As New frmAirPortImport
        str = PublicResource.LoadResString("ID_cap_Import_AirPort", "AirPort导入")
        Dim p As New ImportExport.ProcessorBase(MainForm)
        p.SetSourceDevice(frm.ImportFileName, "xlsfile")
        'p.SetRuntimeValue("id", "TEST")
        Call CallImportAirPortGeneral(ImportExport.File.FileType.XLS, "AirPort.xls", "", "AirPort", "ImpAirPort.xml", str, Rights.CTIYLOAD, frm)
    End Sub
    Private Sub CallIAllDn()
        Me.tvSW_LoadObject("clsdnhdr", "AllDn")
    End Sub
    Private Sub CallINotStartDn()
        Me.tvSW_LoadObject("clsdnhdr", "NotStartDn")
    End Sub
    Private Sub CallIStartDn()
        Me.tvSW_LoadObject("clsdnhdr", "StartDn")
    End Sub
    Private Sub CallIFinishedtDn()
        Me.tvSW_LoadObject("clsdnhdr", "FinishedtDn")
    End Sub
    Private Sub CallIAllBanch()
        Me.tvSW_LoadObject("clsbchhdr", "ALLBanch")
    End Sub
    Private Sub CallINotStartBanch()
        Me.tvSW_LoadObject("clsbchhdr", "NotStartBanch")
    End Sub
    Private Sub CallIStartBanch()
        Me.tvSW_LoadObject("clsbchhdr", "StartBanch")
    End Sub
    Private Sub CallIFinishedtBanch()
        Me.tvSW_LoadObject("clsbchhdr", "FinishedBanch")
    End Sub
    Public Sub CallDnBanch()
        Dim frm As New frmDnBanch
        frm.ShowInTaskbar = False
        frm.Icon = Me.Icon
        SetModalFormStyle(frm)
        frm.ShowDialog(Me)
        frm.Dispose()
        frm = Nothing
        GC.Collect()
    End Sub
    Public Sub CallImportBarcode()
        Dim str As String
        Dim frm As New frmImport
        str = PublicResource.LoadResString("ID_capImpBin", "Barcode导入")
        Dim p As New ImportExport.ProcessorBase(MainForm)
        p.SetSourceDevice(frm.ImportFileName, "xlsfile")
        'p.SetRuntimeValue("id", "BIN")
        Call CallImportGeneral(ImportExport.File.FileType.XLS, "barcode.xls", "", "barcode", "ImpBarcode.xml", str, Rights.BINAREALOAD)
    End Sub

#End Region
#Region " Report Printing"
    Public Sub CallReportPO002()
        ''成品追溯报表
        Dim frm As New frmRawMaterialsReports
        frm.MdiParent = MainForm
        frm.StartPosition = FormStartPosition.CenterParent
        frm.Show()
        System.Threading.Thread.Sleep(500)
        Application.DoEvents()
    End Sub
#End Region
#Region " Testing codes"

    Private Sub LoadMenusTest(ByVal items As CXTButtons, ByVal sb As System.Text.StringBuilder, ByVal iDep As Integer)
        Dim i As Integer
        Dim im As CXTButton
        For i = 0 To items.Count - 1
            sb.Append(Space(iDep * 4) + items(i).Key + vbCrLf)
            If Not items(i).SubItems Is Nothing Then
                LoadMenusTest(items(i).SubItems, sb, iDep + 1)
            End If
        Next
    End Sub

    Private Sub CallPutawayList()
        Dim sb As New System.Text.StringBuilder
        LoadMenusTest(Me.LayoutFile.Menus, sb, 1)
        Dim sw As System.IO.StreamWriter
        Try
            sw = New System.IO.StreamWriter("c:\menu.txt")
            sw.Write(sb.ToString)
            sw.Close()
        Catch ex As Exception
            ErrorMsg(ex, Me.GetType, "CallTesting")
        End Try
        Dim rst As DialogResult
        rst = MsgBox("view data by order(Yes),or by item(No)", MsgBoxStyle.YesNoCancel)
        If rst = DialogResult.Yes Then
            Me.tvSW_LoadObject("clsputhdr", "")
        ElseIf rst = DialogResult.No Then
            Me.tvSW_LoadObject("clsputlin", "")
        End If
    End Sub
#End Region
#Region " Other codes"
    Private Sub frmMain_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        If Me.MdiChildren.Length <= 0 Then
            RelatedMenu.Clear()
            'MainForm.RelatedMenu.Add(RelatedMenuKey.rohdr, "Recieve Order")
            RelatedMenu.Refresh()
        End If
    End Sub
    Public ReadOnly Property SearchService() As COMExpress.Windows.Forms.ISearchService Implements COMExpress.Windows.Forms.IWindowsAppManager.SearchService
        Get
            Return mSearchManager
        End Get
    End Property
    Private Sub SaveClient()
        'On Error Resume Next
        'ClientManager.Save(UserRightMgr.gUserCode, ModuleType.MainMenu, "PC")
        'ClientManager.RemoveOldClients()
    End Sub
    Private Sub TimerClient_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerClient.Tick
        TimerClient.Enabled = False
        SaveClient()
        TimerClient.Enabled = True
    End Sub
    Private Sub sbMain_PanelClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.StatusBarPanelClickEventArgs) Handles sbMain.PanelClick
        If e.StatusBarPanel Is sbpUser And e.Button = MouseButtons.Left And e.Clicks > 1 Then
            TimerChangeDC.Interval = 200
            TimerChangeDC.Enabled = True
        End If
    End Sub
    Public Sub RefreshRegionInformation()
        On Error Resume Next
        'Status(UserRightMgr.gUserCode + "@" + GetDCName(UserRightMgr.gDcCode), 1)
    End Sub
    Public Sub CallChangeRegionDC()
        'Dim frm As frmSelectDc
        'If UserRightMgr.IsAdmin = False Then
        '    Exit Sub
        'End If
        'frm = New frmSelectDc
        'SetModalFormStyle(frm)
        'If frm.ShowDialog(MainForm) <> DialogResult.OK Then
        '    Exit Sub
        'End If
        'CloseMdi(True)
        'RefreshRegionInformation()
    End Sub
    Private Sub TimerChangeDC_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerChangeDC.Tick
        TimerChangeDC.Enabled = False
        CallChangeRegionDC()
    End Sub
#End Region
End Class
#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"

#End Region