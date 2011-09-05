Imports System.Configuration
Imports YT.BusinessObject
Imports COMExpress.Windows.Forms
Imports COMExpress.Windows.Controls
Imports COMExpress.UserInterface.Layout
Imports COMExpress.BusinessObject
Imports CSLA
Imports System.Threading

Public Class frmMain
    Inherits MdiHost.CXMdiMain

    Implements IWindowsAppManager
	Implements ISwitchboardHost
	
    Private mIconResMgr As New Resources.ResourceManager("YTUI.IconImages", GetType(frmMain).Module.Assembly)
    Private mBMPResMgr As New Resources.ResourceManager("YTUI.BmpImages", GetType(frmMain).Module.Assembly)
    Private mStringResMgr As New Resources.ResourceManager("YTUI.StringTable", GetType(frmMain).Module.Assembly)
    Private mobjLayout As CXLayoutFile
    Private mobjLookupObject As Lookup
    Private Const AppConfigFile As String = "\YTApp.config"
    Private mobjAppSettings As WindowsAppSettings


    Public Shared Sub DoUnHandlerException(ByVal sender As Object, ByVal args As ThreadExceptionEventArgs)
        'MsgBox(e.Exception.Message)
        Dim ex As Exception = DirectCast(args.Exception, Exception)
        'Console.WriteLine("MyHandler caught : " + e.Message)
        Dim Str As String
        Microsoft.VisualBasic.MsgBox("System Error, please see log :" + ex.Message, MsgBoxStyle.Critical)
        Str = "System Error:" + ex.Message + "(" + ex.GetType.Name + ")" + vbCrLf + ex.StackTrace
        COMExpress.BusinessObject.CXEventLog.LogToFile(Str, CXEventLog.LogTypeConstants.logUI)
        'Here we can exit the application if .........

        End
    End Sub


    Public Shared Sub Main()
        AddHandler Application.ThreadException, AddressOf DoUnHandlerException

        Dim frm As frmMain
        Try
            frm = New frmMain
            'frm.Show()
            frm.ShowDialog()
            frm.Dispose()
            frm = Nothing
        Catch ex As Exception
            Dim Str As String
            Microsoft.VisualBasic.MsgBox("System Error, please see log :" + ex.Message, MsgBoxStyle.Critical)
            Str = "System Error:" + ex.Message + "(" + ex.GetType.Name + ")" + vbCrLf + ex.StackTrace
            COMExpress.BusinessObject.CXEventLog.LogToFile(Str, CXEventLog.LogTypeConstants.logUI)
        End Try

        'UpgradeProgress()
    End Sub


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()        
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected OverLoads Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        		Me.tvSW = New YTUI.Switchboard()
    	Me.imlSW = New System.Windows.Forms.ImageList(Me.components)
        Me.splMain = New System.Windows.Forms.Splitter()
        Me.sbMain = New CXStatusBar'System.Windows.Forms.StatusBar()
        Me.sbpMain = New System.Windows.Forms.StatusBarPanel()
        Me.sbpUser = New System.Windows.Forms.StatusBarPanel()
        Me.sbpTask = New System.Windows.Forms.StatusBarPanel
        Me.tbMain = New YTUI.ToolbarEx()
        Me.imlToolbar = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuMain = New COMExpress.Windows.Controls.CXImageMainMenu()
        CType(Me.sbpMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpUser, System.ComponentModel.ISupportInitialize).BeginInit()  
        
        Me.SuspendLayout()
        		'
        'imlSW
        '
        Me.imlSW.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlSW.ImageSize = New System.Drawing.Size(16, 16)
        Me.imlSW.TransparentColor = System.Drawing.Color.Transparent
        '
        'tvSW
        '
        Me.tvSW.Dock = System.Windows.Forms.DockStyle.Left
        Me.tvSW.ImageList = Me.imlSW
        Me.tvSW.Location = New System.Drawing.Point(0, 39)
        Me.tvSW.Name = "tvSW"
        Me.tvSW.Size = New System.Drawing.Size(175, 290)
  		'
        'splMain
        '
        Me.splMain.Location = New System.Drawing.Point(175, 39)
        Me.splMain.Name = "splMain"
        Me.splMain.Size = New System.Drawing.Size(8, 290)
        Me.splMain.TabIndex = 4
        Me.splMain.TabStop = False
        '
        'tbMain
        '
        Me.tbMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbMain.DropDownArrows = True
        Me.tbMain.ImageList = Me.imlToolbar
        Me.tbMain.Name = "tbMain"
        Me.tbMain.ShowToolTips = True
        Me.tbMain.Size = New System.Drawing.Size(526, 39)
        Me.tbMain.TabIndex = 2
        Me.tbMain.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'imlToolbar
        '
        Me.imlToolbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlToolbar.ImageSize = New System.Drawing.Size(16, 16)
        Me.imlToolbar.TransparentColor = System.Drawing.Color.Magenta
        '
        'sbMain
        '
        Me.sbMain.Location = New System.Drawing.Point(0, 329)
        Me.sbMain.Name = "sbMain"
        Me.sbMain.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbpMain, Me.sbpUser, Me.sbpTask})
        Me.sbMain.ShowPanels = True
        Me.sbMain.Size = New System.Drawing.Size(526, 16)
        Me.sbMain.TabIndex = 2
        '
        'sbpMain
        '
        Me.sbpMain.Text = "Ready"
        '
        'sbpUser
        '
        Me.sbpUser.Width = 75
        '
        'sbpTask
        '
        Me.sbpTask.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpTask.Width = 173
        '
        
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(526, 345)
        Me.Controls.AddRange(New System.Windows.Forms.Control() { Me.splMain, Me.tvSW, Me.sbMain, Me.tbMain })
        Me.IsMdiContainer = True
        Me.Menu = Me.mnuMain
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        CType(Me.sbpMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpUser, System.ComponentModel.ISupportInitialize).EndInit() 
        
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " COM Express generated code "

    Private WithEvents mobjMenu As MenuService
    Private mobjSB As StatusBarService
    
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
        Try
            If blnCloseAll Then
                Dim frm As Form
                For Each frm In Me.MdiChildren
                    frm.Close()
                Next
                Return Me.MdiChildren.GetLength(0) = 0
            Else
                Me.ActiveForm.Close()
                Return True
            End If
        Catch
            Return False
        End Try

    End Function

    Private Sub LogOn()
        Select Case COMExpress.Configuration.ConfigurationSettings.AppSettings("Authentication")
            Case "COMExpress"
                Dim dlg As New frmLogin()
                If dlg.ShowDialog = DialogResult.OK Then
                    Status(System.Threading.Thread.CurrentPrincipal.Identity.Name, 1)
                Else
                    Return
                End If
            Case "Windows"
                If System.Security.Principal.WindowsIdentity.GetCurrent.IsAuthenticated Then
                    Status(System.Security.Principal.WindowsIdentity.GetCurrent.Name, 1)
                Else
                    Return
                End If
            	Dim dlg As New frmLogin
                dlg.ShowLanguagesOnly()
            Case Else
            	Dim dlg As New frmLogin
                dlg.ShowLanguagesOnly()
        End Select
        LogMenuStatus(True)
        SwitchboardHelper.InitializeSwitchboardService(Me, tvSW, Me)
    End Sub

    Private Sub LogOff()
        If CloseMdi(True) Then
            Try
                CType(tvSW, ISwitchboardService).Clear()
                LogMenuStatus(False)
                System.Threading.Thread.CurrentPrincipal = Nothing
                Status(String.Empty, 1)
            Catch ThisException As Exception
            	ErrorMsg(ThisException, Me.GetType, "LogOff")
        	End Try
        End If
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
            Return mStringResMgr.GetObject(ResName)
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

    Public Function LoadForm(ByVal param As Object, Optional ByVal intPos As Integer = 0, Optional ByVal filters As Filters.CXFilters = Nothing, Optional ByVal GridCaller As RefreshCaller = Nothing, Optional ByVal DataFormType As CXDataForm.CXDataFormType = CXDataForm.CXDataFormType.cdfStandalone, Optional ByVal ParentDataForm As CXWinFormBase = Nothing, Optional ByVal ChildAddNewMode As Boolean = False) As CXWinFormBase Implements IWindowsAppManager.LoadForm
        Cursor.Current = Cursors.WaitCursor

        Dim A As System.Reflection.Assembly
        Dim frmX As CXDataForm
        A = GetType(frmMain).Module.Assembly
        Try
            If TypeOf (param) Is BusinessCollectionBase Then
            	If GetLayout.CXObjectLays(CType(param, BusinessCollectionBaseDerived).BusinessType.Name).UIType = UITypeEnum.utListOnly Then Return Nothing
                frmX = A.CreateInstance("YTUI.frm" & CType(param, BusinessCollectionBaseDerived).BusinessType.Name)
                frmX.DataFormType = DataFormType
                frmX.ParentDataForm = ParentDataForm
                If Not frmX.Initialize(Me, CType(param, BusinessCollectionBase), filters, intPos) Then
                    frmX.Close()
                    Return Nothing
                End If
            Else
            	If GetLayout.CXObjectLays(CType(param, Type).Name).UIType = UITypeEnum.utListOnly Then Return Nothing
                frmX = A.CreateInstance("YTUI.frm" & CType(param, Type).Name)
                frmX.DataFormType = DataFormType
                frmX.ParentDataForm = ParentDataForm
                If Not frmX.Initialize(Me, CType(param, Type), filters) Then
                    frmX.Close()
                    Return Nothing
                End If
            End If
            frmX.InitChildFormDirtySavedStatus(ChildAddNewMode)
            If Not ParentDataForm Is Nothing Then
                If ParentDataForm.Editable Then
                    CType(frmX, IToolbarHost).InvokeToolAction("Edit", True)
                Else
                    CType(frmX, IToolbarHost).InvokeToolAction("Browse", True)
                End If
            End If
            If TypeOf (frmX) Is CXDialogForm Then
                CType(frmX, CXDialogForm).Editable = True
                If CType(frmX, CXDialogForm).ShowDialog() = DialogResult.OK Then
                    If Not GridCaller Is Nothing Then GridCaller.Invoke()
                End If
                If Not ParentDataForm Is Nothing Then
                    If Not ParentDataForm.GetToolbarService Is Nothing Then
                        ParentDataForm.GetToolbarService.StartService (ParentDataForm)
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
                frmPwd.ShowDialog()
            Case "mnuFileClose"""
                CloseMdi()
            Case "mnuFileCloseAll"
                CloseMdi(True)
            Case "mnuFileExit"
                Application.Exit()
            Case "mnuHelpAbout"
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
            Case Else
                Try
                    If Parameter <> String.Empty Then
                        Me.tvSW_LoadObject(Parameter,"")
                    End If
                Catch
                End Try
        End Select
    End Sub
    
    Private Sub tbMain_ItemClick(ByVal Key As String, ByVal Parameter As String) Handles tbMain.ItemClick
        Select Case Key
            Case "Main"
                CType(Me, IWindowsAppManager).SwitchboardVisibility = Not CType(Me, IWindowsAppManager).SwitchboardVisibility
            Case "Quit"
                Application.Exit()
        End Select
    End Sub
    
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    	Dim splash As New frmSplashScreen
        splash.Show()
        splash.Update()
        
    	try
            mobjAppSettings  = WindowsAppSettings.GetSettings(Application.UserAppDataPath().Replace("\" & Application.ProductVersion, "") & AppConfigFile)
        catch ex As exception
            msgbox(ex.message)
        End try
        
        Global.InitializeApp(Me)

        With mobjAppSettings
            If .Width <> 0 And .Height <> 0 Then
                Me.Left = .Left
                Me.Top = .Top
                Me.Width = .Width
                Me.Height = .Height                
            End If
        End With

        mobjLookupObject = New Lookup()
        Dim sLayFile As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath)
        If Dir(sLayFile) <> String.Empty Then
            mobjLayout = CXLayoutFile.NewLayoutFile(sLayFile & "\YT_lay.xml", Me)
        Else
            mobjLayout = CXLayoutFile.NewLayoutFile(GetDBDirectory() & "\YT_lay.xml", Me)
        End If
        
        mobjMenu = New MenuService(Me.mnuMain, Me)
        mobjSB = New StatusbarService(Me.sbMain)        

		ToolbarHelper.InitializeToolbarService(Me, tbMain)
        If mobjAppSettings.SwitchboardWidth <> 0 Then Me.tvSW.Width = mobjAppSettings.SwitchboardWidth
		SwitchboardVisibility = mobjAppSettings.ShowSwitchboard
        StatusBarVisibility = mobjAppSettings.ShowStatusbar
        
        LogOn()
        
        Dim info As Reflection.MethodInfo = ReflectionHelper.GetMethod(Me.GetType, "AfterFrmMainLoad")
        If not (info Is Nothing) Then
            info.Invoke(Me, Nothing)
        End If

        With mobjLayout
            If Not .ApplicationIcon Is Nothing Then Me.Icon = .ApplicationIcon
            Me.Text = .ApplicationTitle
        End With
        
        splash.Close()
        splash.Dispose()
    End Sub

    Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            With mobjAppSettings
                .Left = Me.Left
                .Top = Me.Top
                .Width = Me.Width
                .Height = Me.Height
                .SwitchboardWidth = tvSW.Width
                .ShowStatusbar = StatusBarVisibility
                .ShowSwitchboard = tvSW.Visible
                .SaveSettings(mobjAppSettings, Application.UserAppDataPath().Replace("\" & Application.ProductVersion, "") & AppConfigFile)
            End With
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "frmMain_Closing")
        End Try
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
 
#End Region

 #Region " ISwitchboardHost Implementation"
    Private Sub tvSW_LoadObject(ByVal strObjectName As String, ByVal FuncType As string) Implements ISwitchboardHost.LoadObject
        Cursor.Current = Cursors.WaitCursor
        Try
          	If Me.mobjLayout.CXObjectLays.Contains(strObjectName) = True Then
            	Dim intStartup As CXStartupMode = Me.mobjLayout.CXObjectLays(strObjectName).StartupMode
                Dim frmY As Form
                Dim frmX As CXWinFormBase

                For Each frmY In Me.MdiChildren
                    If TypeInheritsFrom(frmY.GetType, GetType(CXWinFormBase)) Then
                        If CType(frmY, CXWinFormBase).ObjectType.Name = strObjectName Then
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
                        frmX = New frmObjectList
                        If frmX.Initialize(Me, CType(Me, IWindowsAppManager).TypeFromString(strObjectName), , intStartup = CXStartupMode.spmSearch) Then
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
                    Dim info As Reflection.MethodInfo = ReflectionHelper.GetMethod(Me.GetType, "CustomSwitchboardHandler")
                    If info Is Nothing Then
                        MsgBox("Custom switchboard item:" & strObjectName & ", please provide your own implementation.")
                    Else
                        Dim param(0) As Object
                        param(0) = strObjectName
                        info.Invoke(Me, param)
                    End If
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
#End Region
#End Region
#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
    Private Sub CustomSwitchboardHandler(ByVal Key As String)
    End Sub
    
    Private Sub AfterFrmMainLoad()
    End Sub
#End Region

    Public Sub CheckItemBeforeAdd(ByVal Key As String, ByRef bAdd As Boolean) Implements COMExpress.Windows.Forms.ISwitchboardHost.CheckItemBeforeAdd

    End Sub

    Public ReadOnly Property SearchService() As COMExpress.Windows.Forms.ISearchService Implements COMExpress.Windows.Forms.IWindowsAppManager.SearchService
        Get
            Return Nothing
        End Get
    End Property


    End Class



#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"    

#End Region