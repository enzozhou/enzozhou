Option Explicit On 
Option Strict On
Imports COMExpress.UserInterface.Layout
Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports Janus.Windows.GridEX
Imports System.ComponentModel
Imports YT.BusinessObject
Imports System.Text.RegularExpressions

Public Class DataGrid
    Inherits GridEX
    Implements IGrid

    Public Event GetInvisibleColumn(ByVal InvisibleColumn As Microsoft.VisualBasic.Collection)
    Public Event GetDisableColumn(ByVal InvisibleColumn As Microsoft.VisualBasic.Collection)
    'Public Event GetGridPopMenu(ByVal menu As System.Windows.Forms.ContextMenu)
    Public Event GetFuncType(ByRef vFuncType As String)
    Public Event ItemDoubleClick(ByVal sender As Object, ByVal e As ItemDoubleClickEventArgs)

    Private mobjApp As IWindowsAppManager = [Global].MainForm

    Private mstrColumnListName As String = ""

    Public Property ColumnListName() As String
        Get
            Return mstrColumnListName
        End Get
        Set(ByVal Value As String)
            mstrColumnListName = Value
        End Set
    End Property



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        InitContextMenu()
    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            SaveColumnsWidthSetting()
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
            Try
                Me.DataSource = Nothing
            Catch
            End Try
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'DataGrid
        '
        Me.Hierarchical = True
        Me.RecordNavigator = True
        Me.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True
        Me.Size = New System.Drawing.Size(424, 272)
        Me.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.True
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region



#Region " COM Express generated code "
    Public Sub FindGridRow(ByVal ColName As String, ByVal value As Object) Implements COMExpress.Windows.Forms.IGrid.FindGridRow
        Me.Find(Me.RootTable.Columns(ColName), ConditionOperator.Equal, value, 0, 1)
    End Sub

    Private bPositionChanged As Boolean = False
    Private arGridPosition As ArrayList

    Private Sub DataGrid_SortKeysChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SortKeysChanged
        bPositionChanged = True
    End Sub

    Public ReadOnly Property GridPositions() As System.Collections.ArrayList Implements COMExpress.Windows.Forms.IGrid.GridPositions
        Get
            Dim ar As ArrayList

            Dim row As GridEXRow
            'If bPositionChanged Or arGridPosition Is Nothing Then
            ar = New ArrayList
            'Else
            '    Return arGridPosition
            'End If
            For Each row In Me.GetRows
                If row.RowType = RowType.Record Then
                    ar.Add(CType(Me.DataSource, System.ComponentModel.IBindingList).IndexOf(row.DataRow))
                End If
            Next
            bPositionChanged = False
            arGridPosition = ar
            Return ar
        End Get
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), _
        EditorBrowsable(EditorBrowsableState.Never)> _
 Public Property DataSourceEx() As Object Implements IGrid.DataSource
        Get
            Return CType(Me.DataSource, CSLA.Core.SortableCollectionBase)
        End Get
        Set(ByVal Value As Object)
            If Not Me.DataSource Is Nothing Then
                Me.DataSource = Value
            Else
                Me.InternalImageList.Images.Clear()
                Me.DropDowns.Clear()
                Me.DataSource = Value
                Me.RetrieveStructure(True)
            End If
        End Set
    End Property

    Public Sub DeleteObject() Implements IGrid.DeleteObject
        Me.Delete()
    End Sub




    Public Sub FormatGrid() Implements IGrid.FormatGrid
        Dim objJT As GridEXTable

        Me.SuspendLayout()
        Me.HeaderFormatStyle.FontBold = TriState.True
        Me.SelectedFormatStyle.Blend = 0.5
        For Each objJT In Me.Tables
            FormatTable(objJT, (objJT Is Me.RootTable))
        Next
        LoadColumnsWidthSetting()
        Me.ResumeLayout()

        'SetFieldsAttrib()
        'GroupByBoxInfoText = "Drag a column header here to group by that column."
        GroupByBoxInfoText = PublicResource.LoadResString("ID_DataGrid_GroupBoxInformation", "Drag a column header here to group by that column.")
        RecordNavigatorText = PublicResource.LoadResString("ID_DataGrid_RecordNavigatorTextRecord", "Record") + ":|of"
    End Sub

    Public Property Editable() As Boolean Implements IGrid.Editable
        Get
            Editable = CType(Me.AllowAddNew And Me.AllowEdit, Boolean)
        End Get
        Set(ByVal Value As Boolean)
            If Value = True Then
                Me.AllowAddNew = InheritableBoolean.True
                Me.AllowEdit = InheritableBoolean.True
            Else
                Me.AllowAddNew = InheritableBoolean.False
                Me.AllowEdit = InheritableBoolean.False
            End If
        End Set
    End Property

    Public Property Deletable() As Boolean Implements IGrid.Deletable
        Get
            Return CType(Me.AllowDelete, Boolean)
        End Get
        Set(ByVal Value As Boolean)
            If Value = True Then
                Me.AllowDelete = InheritableBoolean.True
            Else
                Me.AllowDelete = InheritableBoolean.False
            End If
        End Set
    End Property

    Private Function GetObjectName(ByVal objJT As GridEXTable) As String
        Return CType(Me.DataSource, ICXBusinessCollectionBase).BusinessType.Name
    End Function

    Private Sub CopyFont(ByRef source As CXFormatStyle, ByRef target As GridEXFormatStyle)
        If Not source.Font Is Nothing Then
            If source.Font.Bold Then
                target.FontBold = TriState.True
            Else
                target.FontBold = TriState.False
            End If

            If source.Font.Italic Then
                target.FontItalic = TriState.True
            Else
                target.FontItalic = TriState.False
            End If

            If source.Font.Strikeout Then
                target.FontStrikeout = TriState.True
            Else
                target.FontStrikeout = TriState.False
            End If

            If source.Font.Underline Then
                target.FontUnderline = TriState.True
            Else
                target.FontUnderline = TriState.False
            End If

            target.FontSize = source.Font.Size
            target.FontName = source.Font.Name
        End If
    End Sub

    Private Function ToGridEXSortOrder(ByVal vSortOrder As SortOrderEnum) As Janus.Windows.GridEX.SortOrder
        Select Case vSortOrder
            Case SortOrderEnum.soSortAscending          '1
                Return SortOrder.Ascending              '1
            Case SortOrderEnum.soSortDescending         '-1
                Return SortOrder.Descending             '2
            Case Else
                Return SortOrder.Unsorted               '0
        End Select
    End Function

    Private Sub FormatTable(ByVal objJT As GridEXTable, Optional ByVal blnShowGroups As Boolean = False)
        Try
            Dim strTemp As String, strObjectName As String = GetObjectName(objJT)
            Dim objLay As CXLayoutFile = CType(mobjApp.GetLayout, CXLayoutFile)
            Dim objBO As CXObjectLay = CType(objLay.CXObjectLays.Item(strObjectName), CXObjectLay)
            Dim cs As CXColumnSet

            objJT.GroupTotals = GroupTotals.ExpandedGroup
            If objBO.Groups.Count > 0 Then objJT.TotalRow = InheritableBoolean.True

            If objBO.HideColumnsWhenGrouped Then
                objJT.HideColumnsWhenGrouped = InheritableBoolean.True
            Else
                objJT.HideColumnsWhenGrouped = InheritableBoolean.False
            End If

            If objBO.ColumnSets.Count > 0 Then
                objJT.ColumnSetRowCount = objBO.ColumnSetRowCount
                objJT.CellLayoutMode = CellLayoutMode.UseColumnSets
            Else
                SetColumnOrdinal(objJT)
            End If

            For Each cs In objBO.ColumnSets
                With objJT.ColumnSets.Add
                    If cs.Key <> String.Empty Then .Key = cs.Key
                    .Width = cs.Width
                    .Caption = cs.CaptionText
                    .ColumnCount = cs.ColumnCount
                End With
            Next

            Dim objJCol As GridEXColumn
            For Each objJCol In objJT.Columns
                FormatColumn(objJT, objJCol)
            Next

            If objBO.UseOddEvenColor Then
                objJT.RowFormatStyle.BackColor = objBO.OddColor
                With objJT.AlternatingRowFormatStyle
                    .BackColor = objBO.EvenColor
                    .Blend = 0.5
                End With
                Me.AlternatingColors = True
            End If

            Dim objGroup As CXSortField

            objJT.Groups.Clear()
            For Each objGroup In objBO.Groups
                Dim grp As New GridEXGroup
                grp.Column = objJT.Columns(objBO.GetNameByField(objGroup.FieldName))
                grp.SortOrder = ToGridEXSortOrder(objGroup.SortOrder)       'modify by lfish 20080423
                grp.GroupInterval = GroupInterval.Value
                objJT.Groups.Add(grp)
            Next
            If blnShowGroups Then Me.GroupByBoxVisible = objBO.GroupBoxVisible

            objJT.SortKeys.Clear()
            For Each objGroup In objBO.SortFields
                Dim sk As New GridEXSortKey
                sk.Column = objJT.Columns(objBO.GetNameByField(objGroup.FieldName))
                sk.SortOrder = ToGridEXSortOrder(objGroup.SortOrder)        'modify by lfish 20080423
                objJT.SortKeys.Add(sk)
            Next
            Try
                Dim sCap As String
                sCap = objBO.ColCaptionText(CType(Me.Parent, CXWinFormBase).FuncType)
                If Trim(sCap) <> "" Then
                    objJT.Caption = sCap
                Else
                    objJT.Caption = objBO.ColCaptionText
                End If
                'objJT.Caption = objBO.ColCaptionText(CType(Me.Parent, CXWinFormBase).FuncType)
            Catch ex As Exception
                objJT.Caption = objBO.ColCaptionText
            End Try
            strTemp = objBO.PreviewCol
            If strTemp <> "" Then
                objJT.PreviewRowMember = strTemp
                objJT.Columns(strTemp).Visible = False
                objJT.PreviewRowLeftMargin = 16
                objJT.PreviewRow = True
                objJT.PreviewRowLines = 3
            End If
            Dim objFmt As CXFormatStyle = objBO.FormatStyle
            If Not objFmt Is Nothing Then
                CopyFont(objFmt, objJT.RowFormatStyle)
                If Not objFmt.StyleBMPIcon Is Nothing Then
                    Me.InternalImageList.Images.Add(objFmt.StyleBMPIcon, System.Drawing.Color.Magenta)
                    objJT.ImageIndex = Me.InternalImageList.Images.Count - 1
                Else
                    If Not objFmt.StyleIcon Is Nothing Then Me.InternalImageList.Images.Add(objFmt.StyleIcon)
                    objJT.ImageIndex = Me.InternalImageList.Images.Count - 1
                End If
            End If

            Me.CellToolTip = CellToolTip.TruncatedText

        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "FormatTable")
        End Try
    End Sub

    Private Function GetObjectHandler() As BusinessBaseDerived
        With DirectCast(Me.DataSource, IBindingList)
            If .Count > 0 Then

                Return DirectCast(.Item(0), BusinessBaseDerived)
            End If
        End With
    End Function

    Private Sub FormatColumn(ByVal objJT As GridEXTable, ByVal objJCol As GridEXColumn)
        Dim strColName As String = objJCol.Key
        Dim objBO As CXObjectLay = CType(mobjApp.GetLayout.CXObjectLays.Item(GetObjectName(objJT)), CXObjectLay)
        If Not objBO.Columns.Contains(strColName) Then Return

        Try
            Dim objFld As CXField = CType(objBO.Columns.Item(strColName), CXField)
            Dim strFormatName As String
            If objFld.FieldReadOnly Then
                objJCol.EditType = EditType.NoEdit
            End If
            objJCol.Caption = objFld.FieldCaptionText

            Dim intAlign As TextAlignment
            Select Case objFld.FieldControlAlign
                Case FieldControlAlignEnum.fcLeft
                    intAlign = TextAlignment.Near
                Case FieldControlAlignEnum.fcCenter
                    intAlign = TextAlignment.Center
                Case FieldControlAlignEnum.fcRight
                    intAlign = TextAlignment.Far
            End Select

            Dim intWidth As Integer = objFld.Width
            If objFld.CSUseColumnSet <> -1 Then
                With objJT.ColumnSets(objFld.CSUseColumnSet)
                    .Add(objJCol, objFld.CSColumnSetRow, objFld.CSColumnSetColumn, objFld.CSRowSpan, objFld.CSColSpan)
                    If intWidth <> -1 AndAlso objFld.CSColSpan = 1 Then
                        .SetColumnWidth(objFld.CSColumnSetColumn, intWidth)
                    End If
                End With
            Else
                If intWidth <> -1 Then objJCol.Width = intWidth
            End If

            objJCol.TextAlignment = intAlign
            objJCol.WordWrap = objFld.WordWrap
            objJCol.AggregateFunction = CType(objFld.AggregateFunctionType, Janus.Windows.GridEX.AggregateFunction)
            objJCol.DefaultGroupPrefix = objFld.GroupPrefixText
            If objFld.SubTotalPrefixText <> String.Empty Then
                Dim strFormatString As String = objFld.SubTotalPrefixText
                If InStr(strFormatString, "0") > 0 Then
                    objJCol.TotalFormatString = strFormatString
                Else
                    objJCol.TotalFormatString = strFormatString & " 0"
                End If
            End If

            Select Case objFld.FieldControlCategory
                Case FieldControlCategoryEnum.fcComboListEdit
                    Dim dv As DataView = objFld.FieldLookupDomain(GetObjectHandler)
                    'Lookup.SetStatusFilter(GetContainerForm().DataSource.GetType.Name, True)
                    'dv.RowFilter = SetStatusFilter(objFld) 'String.Empty
                    objJCol.EditType = EditType.MultiColumnCombo
                    objJCol.DropDown = Me.DropDowns.Add(objJCol.Key)
                    With objJCol.DropDown
                        .Size = New Size(400, 376)
                        .SetDataBinding(dv, String.Empty)
                        .RetrieveStructure()
                        .DisplayMember = .Columns(1).Key
                        .ValueMember = .Columns(0).Key
                        .Columns(0).Visible = False
                        .ColumnAutoResize = True
                    End With
                    objJCol.CompareTarget = ColumnCompareTarget.Text
                Case FieldControlCategoryEnum.fcMaskEdit
                    objJCol.InputMask = objFld.FieldMask
                Case FieldControlCategoryEnum.fcTime
                    objJCol.EditType = EditType.TextBox
                    objJCol.InputMask = "HH:mm:ss"
                Case FieldControlCategoryEnum.fcCalendar
                    objJCol.EditType = EditType.Custom

                    objJCol.FormatString = GetConDateFmt() & " HH:mm:ss"

                Case FieldControlCategoryEnum.fcCheckBox
                    objJCol.EditType = EditType.CheckBox
                Case FieldControlCategoryEnum.fcPicture
                    objJCol.ColumnType = ColumnType.BoundImage
                    objJCol.BoundImageSize = New Size(48, 48)
            End Select

            If objFld.FieldFormat <> vbNullString Then
                objJCol.FormatString = objFld.FieldFormat
            End If

            ' If objFld.FieldControlCategory = FieldControlCategoryEnum.fcCalendar Then objFld.FieldFormat = GetConDateFmt() & " HH:mm:ss"

            Dim objFmt As CXFormatStyle = objFld.FormatStyle
            If Not objFmt Is Nothing Then
                CopyFont(objFmt, objJCol.CellStyle)
                objJCol.CellStyle.ForeColor = objFmt.ForeColor
                objJCol.CellStyle.BackColor = objFmt.BackColor
                If Not objFmt.StyleBMPIcon Is Nothing Then
                    Dim objBMP As System.Drawing.Bitmap = CType(objFmt.StyleBMPIcon, Bitmap)
                    objBMP.MakeTransparent(System.Drawing.Color.Magenta)
                    objJCol.HeaderImage = objBMP
                Else
                    If Not objFmt.StyleIcon Is Nothing Then
                        objJCol.HeaderImage = objFmt.StyleIcon.ToBitmap
                    End If
                End If
            End If

            Select Case objFld.FieldType
                Case FieldTypeEnum.ftString, FieldTypeEnum.ftDate
                    objJCol.EmptyStringValue = String.Empty
            End Select

            Dim fc As CXCondition
            For Each fc In objFld.FormatConditions
                Dim jsFC As New GridEXFormatCondition
                With jsFC
                    .Column = objJCol
                    .ConditionOperator = CType(fc.[Operator], ConditionOperator)
                    .Value1 = GetFCValue(fc.Value1, objFld)
                    Select Case .ConditionOperator
                        Case ConditionOperator.Between, ConditionOperator.NotBetween
                            .Value2 = GetFCValue(fc.Value2, objFld)
                    End Select
                    With .FormatStyle
                        .BackColor = fc.FormatStyle.BackColor
                        .ForeColor = fc.FormatStyle.ForeColor
                        CopyFont(fc.FormatStyle, jsFC.FormatStyle)
                        .Key = fc.Name
                    End With
                End With
                objJT.FormatConditions.Add(jsFC)
            Next
        Catch ThisException As Exception
            ErrorMsg(ThisException, Me.GetType, "FormatColumn")
        End Try
    End Sub

    Dim dt As New System.Windows.Forms.DateTimePicker
    Dim txtNumEdit As New TextBox
    Private Sub DataGrid_InitCustomEdit(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.InitCustomEditEventArgs) Handles MyBase.InitCustomEdit
        On Error Resume Next

        'If Me.CurrentColumn.DataMember = "ReceivedQty" Then
        '    txtNumEdit.Text = GetRecQtyStr(e)
        '    txtNumEdit.TextAlign = HorizontalAlignment.Right
        '    AddHandler txtNumEdit.TextChanged, AddressOf CheckNumInput
        '    txtNumEdit.MaxLength = 10
        '    txtNumEdit.SelectAll()
        '    e.EditControl = txtNumEdit
        'Else
        dt.ShowCheckBox = False
        dt.Format = DateTimePickerFormat.Custom
        dt.CustomFormat = GetConDateFmt() & " HH:mm:ss"
        If IsDBNull(e.Value) = True Then
            dt.Checked = False
        Else
            dt.Checked = True
        End If
        'dt.
        dt.Value = CType(e.Value, Date) 'CType(e.EditChar.ToString, Date)
        e.EditControl = dt
        'End If
    End Sub

    Private Sub DataGrid_EndCustomEdit(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.EndCustomEditEventArgs) Handles MyBase.EndCustomEdit
        'If Me.CurrentColumn.DataMember = "ReceivedQty" Then
        '    'If Convert.ToDecimal(txtNumEdit.Text.Trim) <> CType(e.Value, Decimal) Then
        '    e.DataChanged = True
        '    e.Value = Convert.ToDecimal(txtNumEdit.Text.Trim)
        '    'End If
        'Else
        If IsDBNull(e.Value) Then
            e.DataChanged = True
            e.Value = dt.Value  'IIf(dt.Checked, dt.Value, Nothing)
        ElseIf dt.Text.CompareTo(e.Value) <> 0 Then
            e.DataChanged = True
            e.Value = dt.Value  'IIf(dt.Checked, dt.Value, Nothing)
        End If
        'End If
    End Sub


    Private Function GetFCValue(ByVal value As Object, ByVal objFld As CXField) As Object
        Select Case objFld.FieldType
            Case FieldTypeEnum.ftBoolean
                Return CBool(value)
            Case FieldTypeEnum.ftDate
                Return CDate(value)
            Case FieldTypeEnum.ftByte
                Return CByte(value)
            Case FieldTypeEnum.ftCurrency, FieldTypeEnum.ftDecimal, FieldTypeEnum.ftDouble, FieldTypeEnum.ftInt64, FieldTypeEnum.ftInteger, FieldTypeEnum.ftLong, FieldTypeEnum.ftSingle
                Return Val(value)
            Case Else
                Return value
        End Select
    End Function

    Private Sub SetColumnOrdinal(ByVal objJT As GridEXTable)
        Dim i As Integer
        Dim functype As String = ""
        Dim currentType As Type = CType(Me.DataSource, ICXBusinessCollectionBase).BusinessType
        Dim containerType As Type '= CType(GetContainerForm.DataSource, ICXBusinessCollectionBase).BusinessType
        If TypeOf GetContainerForm() Is CXWinFormBase Then
            containerType = CType(GetContainerForm.DataSource, ICXBusinessCollectionBase).BusinessType
        Else
            containerType = currentType
        End If
        Dim objBO As CXObjectLay = mobjApp.GetLayout.CXObjectLays.Item(currentType.Name)
        Dim objJCol As GridEXColumn, strColumnList As String

        For Each objJCol In objJT.Columns
            objJCol.Visible = False
        Next

        If Trim(mstrColumnListName) <> "" Then
            strColumnList = mstrColumnListName
        ElseIf currentType Is containerType Then
            strColumnList = currentType.Name & "_List__"
        Else
            strColumnList = currentType.Name & "_" & containerType.Name
        End If

        '-------------------------------------------------------------------
        'If currentType.Name = "clsdnlin" Then
        '    RaiseEvent GetFuncType(functype)
        'End If

        '---------------------------------------------------------------------

        Dim objColList As CXColumnList = objBO.ColumnLists.Item(strColumnList)
        Dim objCol As CXField
        i = 0
        For Each objCol In objColList.FieldColumns
            Try
                With objJT.Columns(objCol.FieldName)
                    .Position = i
                    .Visible = True

                    .Key = objCol.FieldName
                    'If objCol.FieldName = "unit" And Not TypeOf DataSource Is clsskuinfoes Then
                    '    .Bound = False
                    '    .EditType = EditType.NoEdit
                    '    .CellStyle.BackColor = Color.LightGray
                    '    'ElseIf objCol.FieldName = "lot_no" And Not (functype = "OutboundTemporarily") Then
                    '    '    .EditType = EditType.NoEdit
                    '    '    .CellStyle.BackColor = Color.LightGray
                    'End If
                End With
                i = i + 1
            Catch ex As Exception
                LogMsg(ex, Me.GetType, "SetColumnOrdinal")
            End Try
        Next

        SetCustomInvisibleColumn(objJT)
        SetCustomDisableColumn(objJT)
    End Sub


    Private Sub SetCustomDisableColumn(ByVal objJT As GridEXTable)
        Dim k As Integer
        Dim ColName As String
        On Error Resume Next
        Dim DisableColumn As New Microsoft.VisualBasic.Collection


        RaiseEvent GetDisableColumn(DisableColumn)

        For k = 1 To DisableColumn.Count
            ColName = CType(DisableColumn.Item(k), String)
            objJT.Columns(ColName).EditType = EditType.NoEdit
            objJT.Columns(ColName).CellStyle.BackColor = Color.LightGray
        Next
    End Sub


    Private Sub SetCustomInvisibleColumn(ByVal objJT As GridEXTable)
        Dim k As Integer
        Dim ColName As String
        On Error Resume Next
        Dim InvisibleColumn As New Microsoft.VisualBasic.Collection

        'Central DB 版本, DC是要显示的.
        'objJT.Columns("dc_code").Visible = False

        RaiseEvent GetInvisibleColumn(InvisibleColumn)

        For k = 1 To InvisibleColumn.Count
            ColName = CType(InvisibleColumn.Item(k), String)
            objJT.Columns(ColName).Visible = False
        Next
    End Sub


    Public Function GetContainerForm() As CXWinFormBase
        Dim parent As Control = CType(Me.GetContainerControl, Control)
        Do
            Try
                Dim baseForm As CXWinFormBase
                baseForm = CType(parent, CXWinFormBase)
                Return baseForm
            Catch
                parent = parent.Parent
            End Try
        Loop
    End Function

    Private Sub DataGrid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.DoubleClick
        Dim hitTest As GridArea = Me.HitTest()
        If hitTest = Janus.Windows.GridEX.GridArea.Cell Or hitTest = GridArea.CardCaption Or hitTest = GridArea.CardColumnHeader Or hitTest = GridArea.PreviewRow Or hitTest = GridArea.RowHeader Then
            Try
                Dim obj As CXWinFormBase = GetContainerForm()
                If obj Is Nothing Then Exit Sub
                If obj.Editable Then Exit Sub
                If TypeOf obj Is frmObjectList Then
                    obj.Edit()
                ElseIf TypeOf obj Is CXDataForm AndAlso (Not obj.DataSource Is Me.DataSource) Then
                    Dim eArgs As ItemDoubleClickEventArgs
                    eArgs = New ItemDoubleClickEventArgs(Me.DataSource.GetType.Name)
                    RaiseEvent ItemDoubleClick(Me, eArgs)
                    If Not eArgs.Cancel Then
                        CType(obj, CXDataForm).EditChild()
                    End If
                    eArgs = Nothing
                End If
            Catch ThisException As Exception
                ErrorMsg(ThisException, Me.GetType, "DataGrid_DoubleClick")
            End Try
        End If
    End Sub

    Private Sub DataGrid_Error(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.ErrorEventArgs) Handles MyBase.Error
        e.DisplayErrorMessage = False
    End Sub

    Public Event SelectedRowChanged(ByVal sender As Object, ByVal e As COMExpress.Windows.Forms.CurrentGridRowIndexEventArgs) Implements COMExpress.Windows.Forms.IGrid.SelectedRowChanged

    Private Sub DataGrid_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SelectionChanged
        If Me.DataSource Is Nothing Then Return
        RaiseEvent SelectedRowChanged(Me, New CurrentGridRowIndexEventArgs(Me.GetContainerForm.BindingContext(Me.DataSource).Position))
    End Sub

    'Private Sub DataGrid_LoadingRow(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles MyBase.LoadingRow
    '    On Error Resume Next
    '    Dim bContinue As Boolean
    '    bContinue = False
    '    If e.Row.RowType = RowType.Record Then
    '        If e.Row.Table Is Me.RootTable Then
    '            bContinue = True
    '        End If
    '    End If
    '    If Not bContinue = True Then
    '        Exit Sub
    '    End If
    '    'e.Row.ro()
    '    If e.Row.DataRow.GetType.Name = "clsrolin" Then

    '        Dim obj As clsskuinfo
    '        obj = clsskuinfo.Load(CType(e.Row.DataRow, clsrolin).sku_no)
    '        e.Row.Cells("unit").Value = obj.unit
    '    End If
    'End Sub

#End Region


#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation

    Public Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Public Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lplFileName As String) As Integer

    Private Function GetColumnsSettingFile() As String
        Dim strApp As String
        Dim iPos As Integer
        strApp = Reflection.Assembly.GetExecutingAssembly.GetModules()(0).FullyQualifiedName
        iPos = strApp.LastIndexOf(".")
        If iPos > 0 Then
            strApp = strApp.Substring(0, iPos)
        End If
        Return strApp + ".ini"
    End Function

    Private Sub LoadColumnsWidthSetting()
        Dim objName As String
        Dim objColName As String
        Dim strVal As String
        Dim objJT As GridEXTable
        Dim objJCol As GridEXColumn
        objName = Me.DataSource.GetType.Name
        For Each objJT In Me.Tables
            For Each objJCol In objJT.Columns
                objColName = objJCol.Key
                strVal = Space(128)
                GetPrivateProfileString(objName, objColName, "", strVal, 128, GetColumnsSettingFile)
                If Microsoft.VisualBasic.IsNumeric(strVal) Then
                    If CInt(strVal) > 0 And objJCol.Visible = True Then
                        objJCol.Width = CInt(strVal)
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub SaveColumnsWidthSetting()
        'Dim i As Integer
        Try
            Dim objName As String
            Dim objColName As String
            Dim objJT As GridEXTable
            Dim objJCol As GridEXColumn
            objName = Me.DataSource.GetType.Name
            For Each objJT In Me.Tables
                For Each objJCol In objJT.Columns
                    objColName = objJCol.Key
                    If objJCol.Visible = True Then
                        WritePrivateProfileString(objName, objColName, CStr(objJCol.Width), GetColumnsSettingFile)
                    End If
                Next
            Next
        Catch ex As Exception

        End Try

    End Sub


    Private Sub DataGrid_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
        On Error Resume Next
        For Each layout As CXObjectLay In [Global].MainForm.LayoutFile.CXObjectLays
            If Not Me.DataSource Is Nothing AndAlso layout.Name = Me.DataSource.GetType.Name.Remove(Me.DataSource.GetType.Name.Length - 1, 1) Then
                For Each col As CXField In layout.Columns
                    Me.CurrentTable.Columns(col.FieldName).MaxLength = col.FieldMaxLen
                Next
                Exit For
            End If
        Next
        'SetFieldsAttri()
    End Sub


    Private Sub SetFieldvisible(ByVal tableName As String, ByVal fieldNames() As String, ByVal value As Boolean)
        If fieldNames.Length > 0 Then
            Dim objBO As CXObjectLay = CType(mobjApp.GetLayout.CXObjectLays.Item(tableName), CXObjectLay)
            Dim fieldList As New ArrayList
            For Each str As String In fieldNames
                Dim col As CXField = objBO.Columns(str)
                If Not col Is Nothing Then
                    fieldList.Add(col.FieldCaptionText.ToLower)
                End If
            Next
            For Each dc As Janus.Windows.GridEX.GridEXColumn In Me.CurrentTable.Columns
                If Not dc.Caption Is Nothing AndAlso fieldList.Contains(dc.Caption.ToLower) Then
                    dc.Visible = value
                End If
            Next
        End If
    End Sub



    Private prvQtyStr As String = ""
    Private Sub CheckNumInput(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtReceivedQty As TextBox = CType(sender, TextBox)
        Dim str As String = txtReceivedQty.Text
        If Regex.IsMatch(str, "[^0-9]") Then
            txtReceivedQty.Text = prvQtyStr
        Else
            prvQtyStr = txtReceivedQty.Text
        End If
        txtReceivedQty.SelectAll()
        SendKeys.Send("{RIGHT}")
    End Sub


    Public ReadOnly Property GridPosByIndex(ByVal SourceIndex As Integer) As Integer
        Get
            Dim index As Integer
            For index = 0 To CType(Me.DataSource, BusinessCollectionBaseDerived).Count - 1
                If CType(Me.GridPositions(index), Integer) = SourceIndex Then
                    Return index
                End If
            Next
            Return -1
        End Get
    End Property

#End Region


#Region " POP Menu"


    Friend WithEvents GridMenu As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuExport As System.Windows.Forms.MenuItem
    Private MaxPopMenuItems As Integer = 10

    Private Sub InitContextMenu()
        Me.GridMenu = New System.Windows.Forms.ContextMenu
        Dim i As Integer
        'Dim mnuSp As System.Windows.Forms.MenuItem
        For i = 0 To MaxPopMenuItems - 1
            Me.GridMenu.MenuItems.Add("POP" + CStr(i), AddressOf CustomPopMenuClick)
        Next
        'RaiseEvent GetGridPopMenu(GridMenu)
        'If GridMenu.MenuItems.Count > 0 Then
        'mnuSp = New System.Windows.Forms.MenuItem
        Me.GridMenu.MenuItems.Add("-")
        'mnuSp.Text = "-"
        'End If
        Me.mnuExport = New System.Windows.Forms.MenuItem
        Me.GridMenu.MenuItems.Add(Me.mnuExport)
        'Me.mnuExport.Index = 0
        Me.mnuExport.Text = PublicResource.LoadResString("ID_cap_DataGrid_Export", "Export")

        Me.ContextMenu = GridMenu
    End Sub
    Private Sub mnuExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuExport.Click
        Dim s As String
        Dim ofd As New SaveFileDialog
        ofd.Filter = "Excel File(*.xls)|*.xls"
        ofd.CheckFileExists = False
        ofd.AddExtension = True
        If ofd.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            s = ofd.FileName()
            ExportGrid.ExportGridExcelByHtml(Me, s)
        End If
        ofd.Dispose()
        ofd = Nothing
        GC.Collect()
    End Sub

    Private mCustomPopList As Microsoft.VisualBasic.Collection
    Public Event PopMenuInit(ByVal obj As Microsoft.VisualBasic.Collection)
    Public Event PopMenuClick(ByVal index As Integer, ByVal vText As String)

    Private Sub GridMenu_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridMenu.Popup
        mCustomPopList = New Microsoft.VisualBasic.Collection
        RaiseEvent PopMenuInit(mCustomPopList)
        Dim i As Integer
        Dim bSpVisible As Boolean
        bSpVisible = False
        For i = 0 To MaxPopMenuItems - 1
            If i <= mCustomPopList.Count - 1 Then
                GridMenu.MenuItems(i).Text = CType(mCustomPopList.Item(i + 1), String)
                GridMenu.MenuItems(i).Visible = True
                bSpVisible = True
            Else
                GridMenu.MenuItems(i).Visible = False
            End If
        Next
        GridMenu.MenuItems(MaxPopMenuItems).Visible = bSpVisible
    End Sub

    Private Sub CustomPopMenuClick(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim i As Integer
        Dim str As String
        i = CType(sender, MenuItem).Index
        str = CType(sender, MenuItem).Text
        If i <= mCustomPopList.Count - 1 Then
            RaiseEvent PopMenuClick(i + 1, str)
        End If
    End Sub

#End Region

    Public Function SelectItemValue(ByVal vColName As String) As Object
        Dim row As GridEXRow
        Dim obj As BusinessBaseDerived
        Dim vVal As Object
        Try
            If Me.SelectedItems.Count <= 0 Then
                Return Nothing
            End If
            row = SelectedItems(0).GetRow
            If row.DataRow.GetType.IsSubclassOf(GetType(BusinessBaseDerived)) = False Then
                Return Nothing
            End If
            obj = CType(row.DataRow(), BusinessBaseDerived)
            vVal = CallByName(obj, vColName, CallType.Get, Nothing)
            Return vVal
        Catch ex As Exception
            Return Nothing
        End Try
    End Function


    Private Sub DataGrid_FormattingRow(ByVal sender As Object, ByVal e As Janus.Windows.GridEX.RowLoadEventArgs) Handles MyBase.FormattingRow
        Dim colQty As GridEXColumn
        Dim str As String
        If LCase(Me.DataSource.GetType.Name) = LCase("clsstocks") Then
            If e.Row.RowType = RowType.GroupHeader Then
                colQty = Me.RootTable.Columns("qty_onhand")

                str = e.Row.GroupCaption & _
                    Space(4) & " [" & e.Row.GetRecordCount & " " & PublicResource.LoadResString("ID_cap_DataGrid_RecordCount", "Records") & "] "
                str = str & _
                    Space(4) & " [" & PublicResource.LoadResString("ID_cap_DataGrid_Qty", "Qty") & " = " & CStr(e.Row.GetSubTotal(colQty, AggregateFunction.Sum)) & "]"
                e.Row.GroupCaption = str
            End If
        End If
    End Sub
End Class

Public Class ItemDoubleClickEventArgs
    Inherits EventArgs
    Private mDataSourceName As String
    Private mCanceled As Boolean

    Public Sub New(ByVal vSourceName As String)
        mDataSourceName = vSourceName
    End Sub

    Public Property ObjectName() As String
        Get
            Return mDataSourceName
        End Get
        Set(ByVal Value As String)
            mDataSourceName = Value
        End Set
    End Property
    Public Property Cancel() As Boolean
        Get
            Return mCanceled
        End Get
        Set(ByVal Value As Boolean)
            mCanceled = Value
        End Set
    End Property
End Class

#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
'This section will not be overwritten during a round-trip code generation
#End Region
