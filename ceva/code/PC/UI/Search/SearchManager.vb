Imports COMExpress.Windows.Forms
Imports COMExpress.Windows.Forms.SearchEx
'Imports YTUI.Windows.Forms.SearchEx1

Public Class SearchManager
    Implements ISearchService
    '
    Public Sub SearchExecute(ByVal strName As String, ByVal strFld As String, ByVal FuncType As String, ByVal SupportMultiValue As Boolean, ByVal objCon As System.Windows.Forms.Control) Implements COMExpress.Windows.Forms.ISearchService.SearchExecute
        'strFld = LCase(strFld)
        'If strFld = "sku_no" Or strFld = "sku_ref" Then
        '    SearchExecuteForSkuNo(strName, strFld, FuncType, SupportMultiValue, objCon)
        'ElseIf strFld = "carr_code" Then
        '    SearchExecuteForCarrname(strName, strFld, FuncType, SupportMultiValue, objCon)
        'ElseIf strFld = "deal_code" Or strFld = "deal_from" Or strFld = "deal_to" Or strFld = "bill_to" Or strFld = "resp_to" Then
        '    SearchExecuteForDealcode(strName, strFld, FuncType, SupportMultiValue, objCon)
        'ElseIf strFld = "dc_code" Then
        '    SearchExecuteForDcCode(strName, strFld, FuncType, SupportMultiValue, objCon)
        'End If
    End Sub

    Public Sub SearchQuery(ByVal strName As String, ByVal strFld As String, ByVal FuncType As String, ByRef bValue As Boolean, ByVal vSearchFuncID As String) Implements COMExpress.Windows.Forms.ISearchService.SearchQuery
        If vSearchFuncID = SearchFunctionConst.RelateSupport Then
            SearchQuery(strName, strFld, FuncType, bValue)
        ElseIf vSearchFuncID = SearchFunctionConst.DisableLookup Then
            DisableLookupQuery(strName, strFld, FuncType, bValue)
        End If
    End Sub

    Public Sub SearchQuery(ByVal strName As String, ByVal strFld As String, ByVal FuncType As String, ByRef bSupported As Boolean)
        If strFld = "sku_no" Or strFld = "sku_ref" Then
            bSupported = True
        ElseIf strFld = "carr_code" Then
            bSupported = True
        ElseIf strFld = "deal_code" Or strFld = "deal_from" Or strFld = "deal_to" Or strFld = "bill_to" Then
            bSupported = True
        ElseIf strFld = "dc_code" Then
            bSupported = True
        Else
            bSupported = False
        End If
    End Sub


    Private Sub SearchExecuteForSkuNo(ByVal strName As String, ByVal strFld As String, ByVal FuncType As String, ByVal SupportMultiValue As Boolean, ByVal objCon As System.Windows.Forms.Control)
        'Dim frm As New frmclsskuinfoselect
        'Dim sku_no As String
        'SetModalFormStyle(frm)
        'frm.skuinfoSuppor(SupportMultiValue)
        'If frm.ShowDialog() = DialogResult.OK Then
        '    sku_no = frm.strskuSome
        '    Try
        '        objCon.Focus()
        '        Application.DoEvents()
        '        objCon.Text = sku_no
        '        Application.DoEvents()
        '        objCon.Focus()
        '    Catch ex As Exception
        '    End Try
        'End If
        'frm.Dispose()
        'frm = Nothing
    End Sub
    'Private Sub SearchExecuteForCarrname(ByVal strName As String, ByVal strFld As String, ByVal FuncType As String, ByVal SupportMultiValue As Boolean, ByVal objCon As System.Windows.Forms.Control)
    '    Dim from As New frmCarrierSelect
    '    SetModalFormStyle(from)
    '    from.carrierSuppor(SupportMultiValue)
    '    If from.ShowDialog() = DialogResult.OK Then

    '        Try
    '            objCon.Text = ""
    '            objCon.Text = from.strCarrSome
    '            objCon.Focus()
    '        Catch ex As Exception
    '        End Try
    '    End If
    '    from.Dispose()
    'End Sub

    'Private Sub SearchExecuteForDealcode(ByVal strName As String, ByVal strFld As String, ByVal FuncType As String, ByVal SupportMultiValue As Boolean, ByVal objCon As System.Windows.Forms.Control)
    '    Dim from As New frmDealerSelect
    '    SetModalFormStyle(from)
    '    from.DealerSuppor(SupportMultiValue)
    '    If from.ShowDialog() = DialogResult.OK Then
    '        Try
    '            objCon.Text = from.strdealSome
    '            objCon.Focus()
    '        Catch ex As Exception
    '        End Try
    '    End If
    '    from.Dispose()
    'End Sub

    'Private Sub SearchExecuteForDcCode(ByVal strName As String, ByVal strFld As String, ByVal FuncType As String, ByVal SupportMultiValue As Boolean, ByVal objCon As System.Windows.Forms.Control)
    '    Dim frm As New frmRegionDcSelect
    '    Dim strRightNo As String
    '    SetModalFormStyle(frm)
    '    frm.SupportMultiValue = SupportMultiValue
    '    frm.RightNo = GetBrowserRight(strName, FuncType)
    '    If frm.ShowDialog() = DialogResult.OK Then
    '        Try
    '            objCon.Focus()
    '            Application.DoEvents()
    '            objCon.Text = frm.SelectedValue
    '            Application.DoEvents()
    '            objCon.Focus()
    '        Catch ex As Exception
    '        End Try
    '    End If
    '    frm.Dispose()
    'End Sub

    Public Shared Function SearchCustom(ByVal ObjectName As String, ByRef filter As COMExpress.BusinessObject.Filters.CXFilters, Optional ByVal FuncType As String = "") As System.Windows.Forms.DialogResult

        'Select Case ObjectName
        '    Case "clsskuinfo", "clsdnhdr", "clsrohdr", "clsrecvhdr", "clsputhdr", "clsmvhdr", "clsbchhdr", "clspickhdr", "clsrpchdr", _
        '        "clsarchhdr", "clskreq", "clskordhdr", "clstrkhdr"

        '        Return SearchCustomMultiObject(ObjectName, FuncType, filter)
        '    Case "clstranslog"
        '        Return SearchCustomTranslog(ObjectName, filter, FuncType)
        'End Select
        Return DialogResult.Ignore
    End Function

    'using DialogResult.OK to confirm search data
    'Public Shared Function SearchCustomSkuinfo(ByVal ObjectName As String, ByRef filter As COMExpress.BusinessObject.Filters.CXFilters) As System.Windows.Forms.DialogResult
    '    Dim frm As frmSkuinfoSearch
    '    Dim rst As DialogResult
    '    frm = New frmSkuinfoSearch
    '    SetModalFormStyle(frm)
    '    frm.Filter = filter
    '    frm.ObjectName = ObjectName
    '    rst = frm.ShowDialog(MainForm)
    '    If rst = DialogResult.OK Then
    '        filter = frm.Filter
    '    End If
    '    frm.Dispose()
    '    Return rst
    'End Function

    'Public Shared Function SearchCustomDnhdr(ByVal ObjectName As String, ByRef filter As COMExpress.BusinessObject.Filters.CXFilters, ByVal FuncType As String) As System.Windows.Forms.DialogResult
    '    Dim frm As frmDnhdrSearch
    '    Dim rst As DialogResult
    '    frm = New frmDnhdrSearch
    '    SetModalFormStyle(frm)
    '    frm.Filter = filter
    '    frm.ObjectName = ObjectName
    '    frm.FuncType = FuncType
    '    rst = frm.ShowDialog(MainForm)
    '    If rst = DialogResult.OK Then
    '        filter = frm.Filter
    '    End If
    '    frm.Dispose()
    '    Return rst
    'End Function

    'Public Shared Function SearchCustomTranslog(ByVal ObjectName As String, ByRef filter As COMExpress.BusinessObject.Filters.CXFilters, ByVal FuncType As String) As System.Windows.Forms.DialogResult
    '    Dim frm As New frmSelectLog
    '    Dim rst As DialogResult
    '    Dim fl As COMExpress.BusinessObject.Filters.CXFilters

    '    SetModalFormStyle(frm)

    '    rst = frm.ShowDialog(MainForm)
    '    If rst <> DialogResult.OK Then
    '        Return rst
    '    End If
    '    filter.Clear()
    '    'fl=frm.
    '    filter.Add(frm.Filter)
    '    frm.Dispose()
    '    frm = Nothing
    '    Return DialogResult.OK
    'End Function


    Public Shared Function SearchCustomMultiObject(ByVal ObjectName As String, ByVal FuncType As String, ByRef filter As COMExpress.BusinessObject.Filters.CXFilters) As System.Windows.Forms.DialogResult
        Dim frm As CXSearchForm
        Dim rst1 As DialogResult
        Dim rst2 As DialogResult

        Dim Obj As New clsObjectManager

        Dim strRightNo As String = ""
        strRightNo = GetBrowserRight(ObjectName, FuncType)

        Obj.HostObjectType = MainForm.TypeFromString(ObjectName)
        Obj.HostFilters = filter
        'If ObjectName = "clsdnhdr" Then
        '    Obj.Add(MainForm.TypeFromString("clsdnlin"))
        '    Obj.Add(MainForm.TypeFromString("clsdnsno"))
        'End If
        AddRelatedObject(ObjectName, Obj)

        frm = New CXSearchForm
        SetModalFormStyle(frm)
        frm.FormBorderStyle = FormBorderStyle.Sizable
        frm.FuncType = FuncType
        frm.DateFormatString = YT.BusinessObject.ProgramType.DateTimeFormat
        'frm.Filter = filter
        frm.Initialize(MainForm, Obj, filter)
        'frm.ObjectName = ObjectName
        rst1 = frm.ShowDialog(MainForm)
        If rst1 = DialogResult.OK Then
            'filter = frm.GetFilters()
            Dim DefFilter As COMExpress.BusinessObject.Filters.CXFilters
            Dim frm2 As New frmMultiObjectList
            DefFilter = GetFunctionFilters(ObjectName, FuncType, strRightNo)               'Default Filters
            If Not DefFilter Is Nothing AndAlso DefFilter.Count > 0 Then        '将default filter加到最前边
                Dim j As Integer
                For j = DefFilter.Count - 1 To 0 Step -1
                    Obj.HostFilters.Insert(0, DefFilter.Item(j))
                Next
            End If
            SetModalFormStyle(frm2)
            frm2.Initialize(MainForm, Obj)
            rst2 = frm2.ShowDialog(MainForm)
            frm2.Dispose()
            If rst2 = DialogResult.OK Then
                filter = Obj.RetFilters
                Dim HostType As Type
                Dim objs As COMExpress.BusinessObject.BusinessCollectionBaseDerived
                Dim ObjHost As COMExpress.BusinessObject.BusinessBaseDerived
                HostType = MainForm.TypeFromString(ObjectName)
                ObjHost = Activator.CreateInstance(HostType, True)
                objs = CallByName(ObjHost, "LoadList", CallType.Method, filter, 0, -1)
                If objs.Count = 1 Then
                    MainForm.CloseFormWithFuncType(objs, FuncType)
                    MainForm.LoadFormWithFuncType(objs, 0, filter, FuncType)
                    rst1 = DialogResult.Cancel
                End If
            Else
                rst1 = DialogResult.Cancel
            End If
        End If
        frm.Dispose()

        Return rst1
    End Function

    Private Shared Function AddRelatedObject(ByVal ObjectName As String, ByVal ObjectManager As clsObjectManager)
        Select Case ObjectName
            Case "clsskuinfo"
                ObjectManager.Add(MainForm.TypeFromString("clsbarcode"))
                ObjectManager.Add(MainForm.TypeFromString("clsskuret"))
                ObjectManager.Add(MainForm.TypeFromString("clsskuopset"))
            Case "clsdnhdr"
                ObjectManager.Add(MainForm.TypeFromString("clsdnlin"))
                ObjectManager.Add(MainForm.TypeFromString("clsdnsno"))
            Case "clsrohdr"
                ObjectManager.Add(MainForm.TypeFromString("clsrolin"))
            Case "clsrecvhdr"
                ObjectManager.Add(MainForm.TypeFromString("clsrecvlin"))
                ObjectManager.Add(MainForm.TypeFromString("clsrecvsno"))
            Case "clsputhdr"
                ObjectManager.Add(MainForm.TypeFromString("clsputlin"))
            Case "clsmvhdr"
                ObjectManager.Add(MainForm.TypeFromString("clsmvlin"))
            Case "clsbchhdr"
                ObjectManager.Add(MainForm.TypeFromString("clsbchlin"))
            Case "clspickhdr"
                ObjectManager.Add(MainForm.TypeFromString("clspicklin"))
            Case "clsrpchdr"
                ObjectManager.Add(MainForm.TypeFromString("clsrpcordlin"))
                ObjectManager.Add(MainForm.TypeFromString("clsrpclin"))
            Case "clsarchhdr"
                ObjectManager.Add(MainForm.TypeFromString("clsarchlin"))
            Case "clskreq"
                ObjectManager.Add(MainForm.TypeFromString("clskordhdr"))
            Case "clskordhdr"
                ObjectManager.Add(MainForm.TypeFromString("clskordpicklin"))
                ObjectManager.Add(MainForm.TypeFromString("clskordlin"))
            Case "clstrkhdr"
                ObjectManager.Add(MainForm.TypeFromString("clstrklin"))
        End Select

    End Function



    Public Sub DisableLookupQuery(ByVal strName As String, ByVal strFld As String, ByVal FuncType As String, ByRef bDisabled As Boolean)
        '        If strFld = "sku_no" Or strFld = "sku_ref" Then
        If strFld = "sku_ref" Then
            bDisabled = True
        End If
    End Sub


End Class
