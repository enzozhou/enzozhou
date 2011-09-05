Imports COMExpress.Windows.Forms
Imports COMExpress.UserInterface.Layout
Imports System.Reflection
Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA
Imports COMExpress.Windows.Forms.SearchEx
'Imports YTUI.Windows.Forms.SearchEx1


Public Class frmMultiObjectList
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents tabPages As System.Windows.Forms.TabControl
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.tabPages = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Panel1.SuspendLayout()
        Me.tabPages.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.btnClose)
        Me.Panel1.Controls.Add(Me.btnOpen)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 482)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 48)
        Me.Panel1.TabIndex = 3
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(24, 8)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(108, 32)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "刷新"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(648, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(108, 32)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "关闭"
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(488, 8)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(108, 32)
        Me.btnOpen.TabIndex = 0
        Me.btnOpen.Text = "选择记录(单据)"
        '
        'tabPages
        '
        Me.tabPages.Controls.Add(Me.TabPage1)
        Me.tabPages.Location = New System.Drawing.Point(8, 16)
        Me.tabPages.Name = "tabPages"
        Me.tabPages.SelectedIndex = 0
        Me.tabPages.Size = New System.Drawing.Size(504, 272)
        Me.tabPages.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(496, 246)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "发货单"
        '
        'frmMultiObjectList
        '
        Me.AcceptButton = Me.btnOpen
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(776, 530)
        Me.Controls.Add(Me.tabPages)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmMultiObjectList"
        Me.Text = "查找显示"
        Me.Panel1.ResumeLayout(False)
        Me.tabPages.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private mobjApp As IWindowsAppManager
    Private mObjectManager As clsObjectManager


    Public Shared Sub SetDataGridStype(ByVal dg As DataGrid)
        dg.Deletable = False
        dg.Editable = False
        dg.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True
    End Sub




    Public Sub Initialize(ByVal objApp As IWindowsAppManager, ByVal ObjectManager As clsObjectManager)
        mobjApp = objApp
        mObjectManager = ObjectManager
        Dim objBO As CXObjectLay
        Dim TabPage As TabPage
        Dim dg As DataGrid
        tabPages.TabPages.Clear()
        tabPages.Dock = DockStyle.Fill
        objBO = CType(CType(mobjApp.GetLayout, CXLayoutFile).CXObjectLays.Item(ObjectManager.HostObjectType.Name), CXObjectLay)
        TabPage = New TabPage(objBO.CaptionText)
        TabPage.Tag = ObjectManager.HostObjectType.Name
        tabPages.TabPages.Add(TabPage)
        dg = New DataGrid
        TabPage.Controls.Add(dg)
        dg.Dock = DockStyle.Fill
        'dg.GroupByBoxVisible = True
        'dg.Deletable = False
        'dg.Editable = False
        'dg.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True

        SetDataGridStype(dg)

        Dim i As Integer
        Dim obj As clsRelatedObject
        For i = 1 To ObjectManager.Count
            obj = ObjectManager.Item(i)
            If obj.FiltersIsAvailable Then
                objBO = CType(CType(mobjApp.GetLayout, CXLayoutFile).CXObjectLays.Item(obj.ObjectType.Name), CXObjectLay)

                TabPage = New TabPage(objBO.CaptionText)
                TabPage.Tag = obj.ObjectType.Name
                tabPages.TabPages.Add(TabPage)
                dg = New DataGrid
                TabPage.Controls.Add(dg)
                dg.Dock = DockStyle.Fill

                SetDataGridStype(dg)
            End If
        Next
        RefreshData()
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub tabPages_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabPages.SelectedIndexChanged
        RefreshData()
    End Sub

    Public Sub RefreshData(Optional ByVal bFarceRefresh As Boolean = False)
        Dim tb As TabPage
        tb = tabPages.SelectedTab
        Dim dg As DataGrid
        Dim obj As clsRelatedObject
        If Not TypeOf tb.Tag Is String Then
            Exit Sub
        End If
        If mObjectManager Is Nothing Then
            Exit Sub
        End If
        dg = tb.Controls(0)
        If Not TypeOf dg Is DataGrid Then
            Exit Sub
        End If

        If mObjectManager.HostObjectType.Name = tb.Tag Then
            'refresh host
            LoadData(mObjectManager.HostObjectType.Name, dg, mObjectManager.HostFilters, bFarceRefresh)
        Else
            obj = mObjectManager.Item(tb.Tag)
            If Not obj Is Nothing Then
                'refresh                 obj.ObjectName()
                LoadData(obj.ObjectType.Name, dg, obj.Filters, bFarceRefresh)
            End If
        End If
    End Sub

    'Public Function TypeFromString(ByVal ObjectName As String) As System.Type Implements IWindowsAppManager.TypeFromString
    '    Dim lookupType As Type = GetType(Lookup)
    '    Return lookupType.Assembly.GetType(GetType(Lookup).Namespace & "." & ObjectName)
    'End Function

    Private Function CreateBusinessObject(ByVal ObjectName As String) As Object
        Dim businessType As Type
        businessType = mobjApp.TypeFromString(ObjectName)
        Return Activator.CreateInstance(businessType, True)
    End Function


    Private Function GetCriteriaForFiltersForHost(ByVal ObjectName As String, ByVal fl As COMExpress.BusinessObject.Filters.CXFilters) As CriteriaForFilters
        Dim crit As CriteriaForFilters
        Dim ObjectType As Type
        Dim obj As BusinessBaseDerived
        Dim ObjectCollectionType As Type
        Dim i As Integer
        Dim relObj As clsRelatedObject
        Dim iMaxNumber As Integer = 0

        ObjectType = mobjApp.TypeFromString(ObjectName)
        obj = Activator.CreateInstance(ObjectType, True)
        ObjectCollectionType = CallByName(obj, "BusinessCollectionType", CallType.Method)
        If mObjectManager.ReturnCount > 0 Then
            iMaxNumber = -1
        End If
        crit = New CriteriaForFilters(ObjectCollectionType, fl, 0, iMaxNumber)

        ObjectType = mObjectManager.HostObjectType ' mobjApp.TypeFromString(mObjectManager.HostObjectName)
        crit.JoinManager.HostObjectType = ObjectType
        crit.JoinManager.HostFilters = mObjectManager.HostFilters

        For i = 1 To mObjectManager.Count
            relObj = mObjectManager.Item(i)
            If relObj.FiltersIsAvailable Then
                ObjectType = relObj.ObjectType ' mobjApp.TypeFromString(relObj.ObjectName)
                crit.JoinManager.Add(ObjectType, relObj.Filters)
            End If
        Next
        Return crit
    End Function

    Private Function GetCriteriaForFiltersForRelate(ByVal ObjectName As String, ByVal fl As COMExpress.BusinessObject.Filters.CXFilters) As CriteriaForFilters
        Dim crit As CriteriaForFilters
        Dim ObjectType As Type
        Dim ObjectCollectionType As Type
        Dim i As Integer
        Dim relObj As clsRelatedObject
        Dim obj As BusinessBaseDerived
        Dim iMaxNumber As Integer = 0
        ObjectType = mobjApp.TypeFromString(ObjectName)
        obj = Activator.CreateInstance(ObjectType, True)
        ObjectCollectionType = CallByName(obj, "BusinessCollectionType", CallType.Method)
        If mObjectManager.ReturnCount > 0 Then
            iMaxNumber = -1
        End If
        crit = New CriteriaForFilters(ObjectCollectionType, fl, 0, iMaxNumber)

        ObjectType = mObjectManager.HostObjectType ' mobjApp.TypeFromString(mObjectManager.HostObjectName)
        crit.JoinManager.HostObjectType = ObjectType
        crit.JoinManager.HostFilters = mObjectManager.HostFilters

        For i = 1 To mObjectManager.Count
            relObj = mObjectManager.Item(i)
            If relObj.FiltersIsAvailable Then
                ObjectType = relObj.ObjectType ' mobjApp.TypeFromString(relObj.ObjectName)
                crit.JoinManager.Add(ObjectType, relObj.Filters)
            End If
        Next
        Return crit
    End Function

    Public Sub LoadData(ByVal ObjectName As String, ByVal dg As DataGrid, ByVal fl As COMExpress.BusinessObject.Filters.CXFilters, Optional ByVal bFarceRefresh As Boolean = False)
        If Not dg.DataSource Is Nothing AndAlso bFarceRefresh = False Then
            Exit Sub
        End If
        Dim crit As CriteriaForFilters
        Dim objs As COMExpress.BusinessObject.BusinessCollectionBaseDerived
        If ObjectName = mObjectManager.HostObjectType.Name Then
            crit = GetCriteriaForFiltersForHost(ObjectName, fl)
        Else
            crit = GetCriteriaForFiltersForRelate(ObjectName, fl)
        End If
        ''CType(DataPortal.Fetch(New CriteriaForFilters(GetType(clsuserroles), _Filters, nLevel, iMaxNumber)), clsuserroles)
        'Dim obj As COMExpress.BusinessObject.BusinessBaseDerived
        'obj = CreateBusinessObject(ObjectName)
        ''obj.b
        ''Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsarchhdrs
        'objs = CallByName(obj, "LoadList", CallType.Method, fl, 0, -1)
        objs = DataPortal.Fetch(crit)
        'objs.BusinessType()
        'dg.DataSource = objs
        ' CType(mobjApp.GetLookup, YT.BusinessObject.Lookup).SetStatusFilter("", "")
        CType(dg, IGrid).DataSource = objs
        CType(dg, IGrid).FormatGrid()
        dg.GroupByBoxVisible = True

    End Sub


    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim tb As TabPage
        tb = tabPages.SelectedTab
        Dim dg As DataGrid
        Dim obj As clsRelatedObject
        If Not TypeOf tb.Tag Is String Then
            Exit Sub
        End If
        If mObjectManager Is Nothing Then
            Exit Sub
        End If
        dg = tb.Controls(0)
        If Not TypeOf dg Is DataGrid Then
            Exit Sub
        End If

        'If mObjectManager.HostObjectName = tb.Tag Then
        '    'refresh host
        '    LoadData(mObjectManager.HostObjectName, dg, mObjectManager.HostFilters)
        'Else
        '    obj = mObjectManager.Item(tb.Tag)
        '    If Not obj Is Nothing Then
        '        'refresh                 obj.ObjectName()
        '        LoadData(obj.ObjectName, dg, obj.Filters)
        '    End If
        'End If
        Dim objBO As COMExpress.BusinessObject.BusinessBaseDerived
        Dim fl As COMExpress.BusinessObject.Filters.CXFilters
        Dim LinkProperName As String
        Try
            objBO = dg.SelectedItems(0).GetRow.DataRow

            If objBO.GetType.Name = mObjectManager.HostObjectType.Name Then
                mObjectManager.RetFilters = COMExpress.BusinessObject.BusinessCollectionBaseDerived.MakeFilters(objBO)
            Else
                LinkProperName = DirectCast(dg, IGrid).DataSource.GetType.Name
                mObjectManager.RetFilters = GetHostBussinessObject(mObjectManager.HostObjectType.Name, LinkProperName, objBO)
            End If
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            ErrorMsg(ex, Me.GetType, "btnOpen_Click")
        End Try

    End Sub

    Private Function GetHostBussinessObject(ByVal HostObjectName As String, ByVal ProperName As String, ByVal objBO As COMExpress.BusinessObject.BusinessBaseDerived) As COMExpress.BusinessObject.Filters.CXFilters
        Dim HostType As Type
        Dim info As PropertyInfo
        Dim ObjectName As String
        Dim ObjHost As BusinessBaseDerived
        Dim ObjList As BusinessCollectionBaseDerived
        HostType = mobjApp.TypeFromString(HostObjectName)
        ObjHost = Activator.CreateInstance(HostType, True)
        ObjectName = objBO.GetType.Name
        info = ObjHost.GetType.GetProperty( _
                ProperName, _
                BindingFlags.NonPublic Or _
                BindingFlags.Instance Or _
                BindingFlags.Public)
        If info Is Nothing Then
            Throw New COMExpress.BusinessObject.CXAppException("The '" & objBO.GetType.Name & _
                "' object doesn't have a property named '" & ProperName & "'.")
        End If
        Dim attrs() As CXLinkPropertyAttribute = CXLinkPropertyAttribute.GetLinkProperties(info)
        Dim i As Integer
        Dim _filters As New Filters.CXFilters

        For i = 0 To UBound(attrs)
            Dim _filter As New Filters.CXRangeFilter
            With _filter
                .ColumnName = attrs(i).ParentProperty
                .[Operator] = ConditionOperator.Equal
                .Value1 = CallByName(objBO, attrs(i).ChildProperty, CallType.Get)
            End With
            _filters.Add(_filter)
        Next
        'Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsarchhdrs
        Return _filters
    End Function

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RefreshData(True)
    End Sub


End Class
