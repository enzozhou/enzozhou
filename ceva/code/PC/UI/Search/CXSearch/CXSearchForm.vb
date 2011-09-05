Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.UserInterface.Layout
Imports Microsoft.Win32


Namespace Windows.Forms.SearchEx1


    Public Class CXSearchForm
        Inherits System.Windows.Forms.Form

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
        Friend WithEvents tbbCriteria As System.Windows.Forms.ToolBarButton
        Friend WithEvents pnlMain As System.Windows.Forms.Panel
        Friend WithEvents imlToolbar As System.Windows.Forms.ImageList
        Friend WithEvents tbPages As System.Windows.Forms.ToolBar
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents cmdCancel As System.Windows.Forms.Button
        Friend WithEvents cmdOK As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CXSearchForm))
            Me.tbbCriteria = New System.Windows.Forms.ToolBarButton
            Me.pnlMain = New System.Windows.Forms.Panel
            Me.imlToolbar = New System.Windows.Forms.ImageList(Me.components)
            Me.tbPages = New System.Windows.Forms.ToolBar
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.btnClear = New System.Windows.Forms.Button
            Me.cmdCancel = New System.Windows.Forms.Button
            Me.cmdOK = New System.Windows.Forms.Button
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'tbbCriteria
            '
            Me.tbbCriteria.ImageIndex = 2
            Me.tbbCriteria.Pushed = True
            Me.tbbCriteria.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
            Me.tbbCriteria.Text = "Filters"
            '
            'pnlMain
            '
            Me.pnlMain.AutoScroll = True
            Me.pnlMain.BackColor = System.Drawing.SystemColors.Control
            Me.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlMain.Location = New System.Drawing.Point(24, 64)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(416, 200)
            Me.pnlMain.TabIndex = 10006
            '
            'imlToolbar
            '
            Me.imlToolbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
            Me.imlToolbar.ImageSize = New System.Drawing.Size(16, 16)
            Me.imlToolbar.ImageStream = CType(resources.GetObject("imlToolbar.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imlToolbar.TransparentColor = System.Drawing.Color.Magenta
            '
            'tbPages
            '
            Me.tbPages.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
            Me.tbPages.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbCriteria})
            Me.tbPages.Divider = False
            Me.tbPages.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.tbPages.DropDownArrows = True
            Me.tbPages.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tbPages.ImageList = Me.imlToolbar
            Me.tbPages.Location = New System.Drawing.Point(0, 308)
            Me.tbPages.Name = "tbPages"
            Me.tbPages.ShowToolTips = True
            Me.tbPages.Size = New System.Drawing.Size(592, 26)
            Me.tbPages.TabIndex = 10001
            Me.tbPages.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
            '
            'Panel1
            '
            Me.Panel1.Controls.Add(Me.btnClear)
            Me.Panel1.Controls.Add(Me.cmdCancel)
            Me.Panel1.Controls.Add(Me.cmdOK)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel1.Location = New System.Drawing.Point(0, 334)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(592, 40)
            Me.Panel1.TabIndex = 10002
            '
            'btnClear
            '
            Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnClear.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.Location = New System.Drawing.Point(16, 8)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(80, 24)
            Me.btnClear.TabIndex = 10004
            Me.btnClear.Text = "Clear"
            '
            'cmdCancel
            '
            Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdCancel.Location = New System.Drawing.Point(496, 8)
            Me.cmdCancel.Name = "cmdCancel"
            Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
            Me.cmdCancel.TabIndex = 10003
            Me.cmdCancel.Text = "&Cancel"
            '
            'cmdOK
            '
            Me.cmdOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmdOK.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdOK.Location = New System.Drawing.Point(392, 8)
            Me.cmdOK.Name = "cmdOK"
            Me.cmdOK.Size = New System.Drawing.Size(80, 24)
            Me.cmdOK.TabIndex = 10002
            Me.cmdOK.Text = "&OK"
            '
            'CXSearchForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(592, 374)
            Me.Controls.Add(Me.pnlMain)
            Me.Controls.Add(Me.tbPages)
            Me.Controls.Add(Me.Panel1)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "CXSearchForm"
            Me.Text = "查找"
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
#End Region

        'Private mstrObjectName As String
        Private mObjectManager As clsObjectManager
        Private mobjApp As IWindowsAppManager
        Private Const CON_DEFAULT_FILTER As String = "default__filter__"
        Private mstrFilterName As String
        Private mDateFmtString As String

        Public Sub Initialize(ByVal objApp As IWindowsAppManager, _
            ByVal ObjectManager As clsObjectManager, _
            ByVal objFilters As CXFilters)


            Try
                Cursor.Current = Cursors.WaitCursor
                Me.Refresh()
                'UnManagedAPI.LockWindowUpdate(Me.Handle)
                Me.SuspendLayout()
                pnlMain.SuspendLayout()
                Dim sg As CXSingleFilter
                'DeleteRuntimeControls()

                'mstrObjectName = strObjectName
                mobjApp = objApp
                mObjectManager = ObjectManager

                Dim objBO As CXObjectLay
                'Me.Text = Resources.Strings.GetResourceString("Search") & objBO.ColCaptionText(FuncType)
                tbPages.Buttons.Clear()

                Me.pnlMain.Tag = 2
                Me.pnlMain.Visible = True
                Me.tbbCriteria.Tag = Me.pnlMain
                Dim pos As Integer
                sg = New CXSingleFilter(objApp, ObjectManager.HostObjectType.Name, pnlMain)
                sg.InitializeDS(objFilters)
                objBO = CType(CType(mobjApp.GetLayout, CXLayoutFile).CXObjectLays.Item(ObjectManager.HostObjectType.Name), CXObjectLay)
                Me.Text = "查找 - " + objBO.CaptionText(FuncType)
                pos = tbPages.Buttons.Add(objBO.CaptionText)
                tbPages.Buttons(pos).Tag = sg
                tbPages.Buttons(pos).Pushed = True
                tbPages.Buttons(pos).ImageIndex = 2
                Dim i As Integer
                Dim obj As clsRelatedObject
                For i = 1 To ObjectManager.Count
                    obj = ObjectManager.Item(i)
                    objBO = CType(CType(mobjApp.GetLayout, CXLayoutFile).CXObjectLays.Item(obj.ObjectType.Name), CXObjectLay)
                    sg = New CXSingleFilter(objApp, obj.ObjectType.Name, AddPanel)
                    sg.FuncType = Me.FuncType
                    sg.DateFormatString = Me.DateFormatString
                    sg.InitializeDS(obj.Filters)
                    pos = tbPages.Buttons.Add(objBO.CaptionText)
                    tbPages.Buttons(pos).Tag = sg
                    tbPages.Buttons(pos).Pushed = False
                    tbPages.Buttons(pos).ImageIndex = 2
                Next
            Finally
                pnlMain.ResumeLayout()
                Me.ResumeLayout()
                UnManagedAPI.LockWindowUpdate(IntPtr.Zero)
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        Public Property DateFormatString() As String
            Get
                Return mDateFmtString
            End Get
            Set(ByVal Value As String)
                mDateFmtString = Value
            End Set
        End Property

        Private mFuncType As String = ""
        Public Overridable Property FuncType() As String
            Get
                Return mFuncType
            End Get
            Set(ByVal Value As String)
                mFuncType = Trim(Value)
            End Set
        End Property

        'Private Sub SetDefault(ByVal strFilterName As String)
        '    Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey(GetPath)
        '    key.SetValue(CON_DEFAULT_FILTER, strFilterName)
        'End Sub

        'Private Sub Delete(ByVal strFilterName As String)
        '    Dim key As RegistryKey = Registry.CurrentUser.CreateSubKey(GetPath)
        '    key.DeleteValue(strFilterName)
        '    If Me.GetDefaultFilter.ToLower = strFilterName.ToLower Then
        '        key.DeleteValue(CON_DEFAULT_FILTER)
        '    End If
        'End Sub

        'Private Sub DefaultFilter(ByVal strFilterName As String)
        '    SetDefault(strFilterName)
        'End Sub

        'Private Function GetDefaultFilter() As String
        '    Try
        '        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey(GetPath)
        '        Return key.GetValue(CON_DEFAULT_FILTER, String.Empty)
        '    Catch
        '        Return String.Empty
        '    End Try
        'End Function


        'Private Function LoadSavedFilter(ByVal strFilterName As String) As CXFilters
        '    Dim def() As Byte
        '    Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey(GetPath)

        '    mstrFilterName = strFilterName
        '    def = key.GetValue(mstrFilterName, def)
        '    Dim objStream As New System.IO.MemoryStream(def)
        '    mobjDS = Nothing
        '    mobjDS = New DataSet
        '    mobjDS.ReadXml(objStream, XmlReadMode.Auto)
        '    Return Me.GetFilters
        'End Function

        'Private Sub Open()
        '    Dim frmX As New frmOpen
        '    Try
        '        Dim key As RegistryKey = Registry.CurrentUser.OpenSubKey(GetPath)
        '        Dim strDefaultKey As String = key.GetValue(CON_DEFAULT_FILTER, String.Empty)

        '        frmX.Initialize(key.GetValueNames, strDefaultKey)

        '        AddHandler frmX.DeleteFilter, AddressOf Me.Delete
        '        AddHandler frmX.DefaultFilter, AddressOf Me.DefaultFilter

        '        If frmX.ShowDialog(Me) = DialogResult.OK Then
        '            Dim def() As Byte
        '            mstrFilterName = frmX.SelectedFilter
        '            def = key.GetValue(mstrFilterName, def)
        '            Dim objStream As New System.IO.MemoryStream(def)
        '            mobjDS = Nothing
        '            mobjDS = New DataSet
        '            mobjDS.ReadXml(objStream, XmlReadMode.Auto)
        '            Initialize(mobjApp, mstrObjectName, Me.GetFilters)
        '        End If
        '    Catch
        '    Finally
        '        RemoveHandler frmX.DeleteFilter, AddressOf Me.Delete
        '        RemoveHandler frmX.DefaultFilter, AddressOf Me.DefaultFilter
        '    End Try
        'End Sub

        Private Sub DeleteRuntimeControls()
            Dim btn As ToolBarButton, i As Integer
            Dim ctl As Control

            Do While tbPages.Buttons.Count > 0
                btn = tbPages.Buttons(tbPages.Buttons.Count - 1)
                Try
                    Dim pnl As Panel = CType(btn.Tag, Panel)
                    Do While pnl.Controls.Count > 0
                        ctl = pnl.Controls(0)
                        pnl.Controls.Remove(ctl)
                        ctl.Dispose()
                        ctl = Nothing
                    Loop
                    If Not pnl Is Me.pnlMain Then
                        Me.Controls.Remove(pnl)
                        pnl.Dispose()
                    End If
                Catch
                End Try
                If btn Is Me.tbbCriteria Then
                    btn.Pushed = True
                    Exit Do
                Else
                    tbPages.Buttons.Remove(btn)
                    btn.Dispose()
                End If
            Loop
        End Sub

        'Private ReadOnly Property GetPath() As String
        '    Get
        '        GetPath = "Software\COMExpressGenerated\" & mobjApp.GetLayout.ApplicationTitle & "\Filters\" & mstrObjectName
        '    End Get
        'End Property


        Private Function AddButton(Optional ByVal pnl As Panel = Nothing) As ToolBarButton
            Dim strText As String
            If Not pnl Is Nothing Then
                strText = "Or" ' Resources.Strings.GetResourceString("Or")
            Else
                strText = "MoreOr" ' Resources.Strings.GetResourceString("MoreOr")
            End If
            Dim btn As New ToolBarButton(strText)
            btn.Style = ToolBarButtonStyle.ToggleButton
            tbPages.Buttons.Add(btn)
            btn.ImageIndex = 2
            If Not pnl Is Nothing Then btn.Tag = pnl
            Return btn
        End Function


        Private Function AddPanel() As Panel
            Dim pnl As New Panel
            Dim ctl As Control, iTabIndex As Integer

            For Each ctl In Me.Controls
                If TypeOf ctl Is Panel Then
                    iTabIndex = iTabIndex + 1 + ctl.Controls.Count
                End If
            Next
            pnl.TabIndex = iTabIndex

            Me.Controls.Add(pnl)
            pnl.Visible = False
            pnl.Location = Me.pnlMain.Location
            pnl.Size = Me.pnlMain.Size
            pnl.BorderStyle = BorderStyle.Fixed3D
            pnl.AutoScroll = True
            pnl.Tag = 2
            Return pnl
        End Function

        Private Function AddOrControls() As Panel
            Dim pnl As Panel = AddPanel()
            AddButton(pnl)
            Return pnl
        End Function




        Private Sub ResizeControls()
            Dim i As Integer
            Dim pnl As Panel
            Dim sg As CXSingleFilter
            For i = 0 To Me.tbPages.Buttons.Count - 1
                If tbPages.Buttons(i).Pushed Then
                    If TypeOf tbPages.Buttons(i).Tag Is CXSingleFilter Then
                        sg = DirectCast(tbPages.Buttons(i).Tag, CXSingleFilter)
                        pnl = sg.Panel
                        pnl.Left = 0
                        pnl.Top = 0 'tbMain.Height
                        pnl.Width = Me.ClientSize.Width
                        pnl.Height = tbPages.Top - pnl.Top
                        sg.SizeIt()
                        pnl.Visible = True
                    End If
                    Exit For
                End If
            Next

        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            ResizeControls()
        End Sub

        Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
            MyBase.OnActivated(e)
            ResizeControls()
        End Sub

        Private Sub tbPages_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbPages.ButtonClick
            Dim btn As ToolBarButton, btnCur As ToolBarButton = e.Button
            Dim pnl As Panel
            Dim sg As CXSingleFilter
            Dim bResize As Boolean = False
            If btnCur.Pushed = False Then
                bResize = True
            End If
            btnCur.Pushed = True
            Try
                Cursor.Current = Cursors.WaitCursor
                Me.Refresh()
                UnManagedAPI.LockWindowUpdate(Me.Handle)
                For Each btn In tbPages.Buttons
                    If TypeOf btn.Tag Is CXSingleFilter Then
                        sg = DirectCast(btn.Tag, CXSingleFilter)
                        pnl = sg.Panel
                        If btn Is btnCur Then
                            pnl.Visible = True
                        Else
                            pnl.Visible = False
                            btn.Pushed = False
                        End If
                    End If

                Next
            Finally
                UnManagedAPI.LockWindowUpdate(IntPtr.Zero)
                Cursor.Current = Cursors.Default
            End Try
            If bResize Then
                ResizeControls()
            End If
        End Sub

        Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
            If GetFilters() <= 0 Then
                Message("ID_msg_PleaseSelectCondition", True, "请输入条件")
                Exit Sub
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Sub

        Private Function GetFilters() As Integer
            Dim i As Integer
            Dim iCount As Integer
            Dim pos As Integer
            Dim btn As ToolBarButton
            Dim obj As clsRelatedObject
            Dim sg As CXSingleFilter
            iCount = 0
            If mObjectManager Is Nothing Then
                mObjectManager.ReturnCount = iCount
                Return iCount
            End If
            For i = 0 To Me.tbPages.Buttons.Count - 1
                btn = Me.tbPages.Buttons(i)
                If TypeOf btn.Tag Is CXSingleFilter Then
                    sg = DirectCast(btn.Tag, CXSingleFilter)
                    If Me.mObjectManager.HostObjectType.Name = sg.ObjectName Then
                        mObjectManager.HostFilters = sg.GetFilters
                        mObjectManager.HostFilters.Index = i
                        If COMExpress.BusinessObject.Filters.CXFilters.GetAvailableFilterCount(mObjectManager.HostFilters) > 0 Then
                            iCount = iCount + 1
                        End If
                    Else
                        obj = mObjectManager.Item(sg.ObjectName)
                        If Not obj Is Nothing Then
                            obj.Filters = sg.GetFilters
                            obj.FiltersIsAvailable = (COMExpress.BusinessObject.Filters.CXFilters.GetAvailableFilterCount(obj.Filters) > 0)
                            obj.Filters.Index = i
                            If obj.FiltersIsAvailable Then
                                iCount = iCount + 1
                            End If
                        End If
                    End If
                End If
            Next
            mObjectManager.ReturnCount = iCount
            Return iCount
        End Function

        Public Sub Clear()

            Dim i As Integer
            Dim pos As Integer
            Dim btn As ToolBarButton
            Dim sg As CXSingleFilter
            'Dim fl As COMExpress.BusinessObject.Filters.CXFilters
            If mObjectManager Is Nothing Then
                Exit Sub
            End If
            Cursor.Current = Cursors.WaitCursor
            Me.SuspendLayout()
            For i = 0 To Me.tbPages.Buttons.Count - 1
                btn = Me.tbPages.Buttons(i)
                If TypeOf btn.Tag Is CXSingleFilter Then
                    sg = DirectCast(btn.Tag, CXSingleFilter)
                    'fl = New COMExpress.BusinessObject.Filters.CXFilters
                    sg.Panel.SuspendLayout()
                    sg.Panel.Visible = False
                    sg.InitializeDS(Nothing)
                End If
            Next
            Me.ResumeLayout()
            Cursor.Current = Cursors.Default
            ResizeControls()
        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Clear()
        End Sub
    End Class
End Namespace


