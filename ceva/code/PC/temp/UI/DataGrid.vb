Option Explicit On 
Option Strict On
Imports COMExpress.UserInterface.Layout
Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports Janus.Windows.GridEX
Imports System.ComponentModel

Public Class DataGrid
    Inherits GridEX
    Implements IGrid
	
    Private mobjApp As IWindowsAppManager = Global.MainForm


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
    Protected OverLoads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
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
        Me.UpdateMode = UpdateMode.CellUpdate
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

#Region " COM Express generated code "
    Public Sub FindGridRow(ByVal ColName As String, ByVal value As Object) Implements COMExpress.Windows.Forms.IGrid.FindGridRow
        Me.Find(Me.RootTable.Columns(ColName), ConditionOperator.Equal, value, 0, 1)
    End Sub
    
    Public ReadOnly Property GridPositions() As System.Collections.ArrayList Implements COMExpress.Windows.Forms.IGrid.GridPositions
        Get
        	Dim ar As New ArrayList
            Dim row As GridEXRow

            For Each row In Me.GetRows
                If row.RowType = RowType.Record Then
                    ar.Add(CType(Me.DataSource, System.ComponentModel.IBindingList).IndexOf(row.DataRow))
                End If
            Next
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
        Me.ResumeLayout()

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
                grp.SortOrder = CType(objGroup.SortOrder, Janus.Windows.GridEX.SortOrder)
                grp.GroupInterval = GroupInterval.Value
                objJT.Groups.Add(grp)
            Next
            If blnShowGroups Then Me.GroupByBoxVisible = objBO.GroupBoxVisible

            objJT.SortKeys.Clear()
            For Each objGroup In objBO.SortFields
                Dim sk As New GridEXSortKey
                sk.Column = objJT.Columns(objBO.GetNameByField(objGroup.FieldName))
                sk.SortOrder = CType(objGroup.SortOrder, Janus.Windows.GridEX.SortOrder)
                objJT.SortKeys.Add(sk)
            Next

            objJT.Caption = objBO.ColCaptionText
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
                    dv.RowFilter = String.Empty
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
                    objJCol.InputMask = "hh:mm:ss"
                Case FieldControlCategoryEnum.fcCalendar
                    objJCol.EditType = EditType.CalendarDropDown
                Case FieldControlCategoryEnum.fcCheckBox
                    objJCol.EditType = EditType.CheckBox
                Case FieldControlCategoryEnum.fcPicture
                    objJCol.ColumnType = ColumnType.BoundImage
                    objJCol.BoundImageSize = New Size(48, 48)
            End Select

            If objFld.FieldFormat <> vbNullString Then objJCol.FormatString = objFld.FieldFormat

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
                    .ConditionOperator = CType(fc.Operator, ConditionOperator)
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
        Dim currentType As Type = CType(Me.DataSource, ICXBusinessCollectionBase).BusinessType
        Dim containerType As Type = CType(GetContainerForm.DataSource, ICXBusinessCollectionBase).BusinessType
        Dim objBO As CXObjectLay = mobjApp.GetLayout.CXObjectLays.Item(currentType.Name)
        Dim objJCol As GridEXColumn, strColumnList As String

        For Each objJCol In objJT.Columns
            objJCol.Visible = False
        Next

        If currentType Is containerType Then
            strColumnList = currentType.Name & "_List__"
        Else
            strColumnList = currentType.Name & "_" & containerType.Name
        End If

        Dim objColList As CXColumnList = objBO.ColumnLists.Item(strColumnList)
        Dim objCol As CXField
        i = 0
        For Each objCol In objColList.FieldColumns
            Try
                With objJT.Columns(objCol.FieldName)
                    .Position = i
                    .Visible = True
                End With
                i = i + 1
            Catch
            End Try
        Next

    End Sub

    Private Function GetContainerForm() As CXWinFormBase
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
                If TypeOf obj Is frmObjectList Then
                    obj.Edit()
                ElseIf TypeOf obj Is CXDataForm AndAlso (Not obj.DataSource Is Me.DataSource) Then
                    CType(obj, CXDataForm).EditChild()
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
#End Region


#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
