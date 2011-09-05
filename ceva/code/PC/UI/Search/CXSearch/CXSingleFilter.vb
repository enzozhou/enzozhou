Imports COMExpress.BusinessObject.Filters
Imports COMExpress.UserInterface.Layout
Imports COMExpress.Windows.Forms

Namespace Windows.Forms.SearchEx1


    Public Class CXSingleFilter

        Private mobjLookups As New Hashtable
        Private mstrObjectName As String
        Private mobjApp As IWindowsAppManager
        Private mDateFmtString As String
        Private mobjBO As CXObjectLay
        Private pnl As Panel

        Public Sub New(ByVal objApp As IWindowsAppManager, ByVal strObjectName As String, ByVal pnl As Panel)
            mobjApp = objApp
            mstrObjectName = strObjectName
            Dim objLay As CXLayoutFile = CType(mobjApp.GetLayout, CXLayoutFile)
            mobjBO = CType(objLay.CXObjectLays.Item(mstrObjectName), CXObjectLay)
            Me.pnl = pnl
        End Sub

        Public ReadOnly Property Panel() As Panel
            Get
                Return pnl
            End Get
        End Property

        Public ReadOnly Property ObjectName() As String
            Get
                Return mstrObjectName
            End Get
        End Property


        Public Property DateFormatString() As String
            Get
                Return mDateFmtString
            End Get
            Set(ByVal Value As String)
                mDateFmtString = Value
            End Set
        End Property



        Private Sub InitializeNew(ByRef dt As DataTable)
            Dim dr As DataRow
            Dim objLay As CXLayoutFile = CType(mobjApp.GetLayout, CXLayoutFile)
            Dim objBO As CXObjectLay = CType(objLay.CXObjectLays.Item(mstrObjectName), CXObjectLay)
            Dim objFld As CXField

            Dim objDT As New clsDebugTime

            For Each objFld In objBO.Columns
                If Not objFld.NotSearchable Then
                    dr = dt.NewRow
                    dr.Item(0) = objFld.DBNameIncludeTableName
                    dr.Item(1) = objFld.DefaultSearchOperator
                    dr.Item(4) = objFld.FieldCaptionText
                    Select Case objFld.FieldControlCategory
                        Case FieldControlCategoryEnum.fcCalendar, FieldControlCategoryEnum.fcTime
                            dr.Item(5) = True
                        Case Else
                            dr.Item(5) = False
                    End Select
                    dr.Item(6) = objFld.FieldType
                    dt.Rows.Add(dr)
                    AddSearch(dt.DefaultView(dt.DefaultView.Count - 1), objFld, pnl)
                End If
            Next

            'Dim ctl As Control

            'For Each ctl In pnl.Controls
            '    If TypeOf ctl Is CXSearchField Then
            '        CType(ctl, CXSearchField).SizeIt()
            '    End If
            'Next
            Debug.WriteLine("InitializeExist AddSearch Finished:" + objDT.GetTicks.ToString())
            objDT.Reset()

            Dim ctl As Control
            Dim iMaxWidth As Integer = 0
            For Each ctl In pnl.Controls
                If TypeOf ctl Is CXSearchField Then
                    With CType(ctl, CXSearchField)
                        If iMaxWidth < .LabelWidth Then
                            iMaxWidth = .LabelWidth
                        End If
                    End With
                End If
            Next
            For Each ctl In pnl.Controls
                If TypeOf ctl Is CXSearchField Then
                    CType(ctl, CXSearchField).LabelWidth = iMaxWidth
                End If
            Next

        End Sub



        Private Sub InitializeExist( _
                           ByVal objFilters As CXFilters, _
                           ByRef dt As DataTable)
            Dim objFilter As CXRangeFilter
            Dim dr As DataRow

            pnl.SuspendLayout()


            For Each objFilter In objFilters
                Dim objFld As CXField = mobjBO.Columns.Item(mobjBO.GetNameByFieldNameIncludeTableName(objFilter.ColumnName))
                '根据objFilter.ColumnName取得CXField
                If Not objFld.NotSearchable Then
                    dr = dt.NewRow
                    dr.Item(0) = objFilter.ColumnName
                    dr.Item(1) = objFilter.Operator
                    dr.Item(2) = objFilter.Value1
                    dr.Item(3) = objFilter.Value2
                    dr.Item(4) = objFld.FieldCaptionText
                    Select Case objFld.FieldControlCategory
                        Case FieldControlCategoryEnum.fcCalendar, FieldControlCategoryEnum.fcTime
                            dr.Item(5) = True
                        Case Else
                            dr.Item(5) = False
                    End Select
                    dr.Item(6) = objFld.FieldType
                    dt.Rows.Add(dr)
                    AddSearch(dt.DefaultView(dt.DefaultView.Count - 1), objFld, pnl)
                End If
            Next

            Dim ctl As Control
            Dim iMaxWidth As Integer = 0
            For Each ctl In pnl.Controls
                If TypeOf ctl Is CXSearchField Then
                    With CType(ctl, CXSearchField)
                        If iMaxWidth < .LabelWidth Then
                            iMaxWidth = .LabelWidth
                        End If
                    End With
                End If
            Next
            For Each ctl In pnl.Controls
                If TypeOf ctl Is CXSearchField Then
                    CType(ctl, CXSearchField).LabelWidth = iMaxWidth
                End If
            Next
        End Sub

        Public Sub SizeIt()
            Dim ctl As Control
            For Each ctl In pnl.Controls
                If TypeOf ctl Is CXSearchField Then
                    With CType(ctl, CXSearchField)
                        If pnl.Width > .Left + .LabelWidth Then
                            .Width = pnl.Width - .Left
                        End If
                        .SizeIt()
                    End With
                End If
            Next
        End Sub

        Private Sub AddSearch( _
            ByVal row As DataRowView, _
            ByVal objFld As CXField, _
            ByVal pnl As Panel)
            Dim obj As New CXSearchField, blnUseDefault As Boolean


            Dim objDT As New clsDebugTime

            obj.SuspendLayout()

            blnUseDefault = (objFld.SearchFieldTop = 0 And objFld.SearchFieldLeft = 0 And _
                objFld.SearchFieldWidth = 0 And objFld.SearchFieldHeight = 0)

            obj.TabIndex = pnl.TabIndex + pnl.Controls.Count + 1
            If blnUseDefault Then
                obj.Location = New System.Drawing.Point(4, CType(pnl.Tag, Integer))
            Else
                obj.Location = New System.Drawing.Point(objFld.SearchFieldLeft, objFld.SearchFieldTop)
            End If
            pnl.Tag = CType(CType(pnl.Tag, Integer) + 24, Object)
            If blnUseDefault Then
                obj.Size = New System.Drawing.Size(456, 24)
            Else
                obj.Size = New System.Drawing.Size(objFld.SearchFieldWidth, objFld.SearchFieldHeight)
            End If
            obj.Visible = True
            If objFld.FieldControlCategory = FieldControlCategoryEnum.fcCalendar Then
                obj.DateFormatString = DateFormatString
            End If

            Debug.WriteLine("--AddSearch(" + objFld.FieldCaptionText + ") before:" + objDT.GetTicks.ToString())
            objDT.Reset()

            Dim dv As DataView
            dv = GetLookup(row("ColumnName"))


            Debug.WriteLine("**AddSearch(" + objFld.FieldCaptionText + ") GetLookup:" + objDT.GetTicks.ToString())
            objDT.Reset()


            obj.Initialize(row, objFld, dv)

            Debug.WriteLine("--AddSearch(" + objFld.FieldCaptionText + ") Initialize:" + objDT.GetTicks.ToString())
            objDT.Reset()


            obj.ResumeLayout()

            pnl.Controls.Add(obj)


            ''------------------------------
            AddHandler obj.RelatedSearchClicked, AddressOf RelatedSearchFieldClicked
            AddHandler obj.RelatedSearchQuery, AddressOf RelatedSearchFieldQuery
            ''------------------------------

            'Debug.WriteLine("AddSearch(" + objFld.FieldCaptionText + ") Finished:" + objDT.GetTicks.ToString())
            'objDT.Reset()

            Debug.WriteLine("")
        End Sub



        Private Function GetLookup(ByVal strFieldName As String) As DataView
            Dim dv As DataView

            Dim objDT As New clsDebugTime

            Try
                dv = CType(mobjLookups.Item(strFieldName), DataView).Table.Copy.DefaultView
                If Not dv Is Nothing Then Return dv
            Catch
            End Try

            Dim objBO As CXObjectLay = mobjApp.GetLayout.CXObjectLays.Item(mstrObjectName)
            Dim objFld As CXField = objBO.Columns.Item(objBO.GetNameByFieldNameIncludeTableName(strFieldName))

            If objFld.FieldControlCategory = FieldControlCategoryEnum.fcComboListEdit Then
                Try
                    dv = objFld.FieldLookupDomain(mobjApp.CreateObjectEx(mstrObjectName))
                    Dim strFilter As String = ""
                    'RaiseEvent FeedFieldLookupFilter(strFieldName, strFilter)
                    dv.RowFilter = strFilter 'String.Empty
                    mobjLookups.Add(dv, strFieldName)

                    Debug.WriteLine("GetLookup sucessfull:" + objDT.GetTicks.ToString())
                    objDT.Reset()

                    Return dv
                Catch
                    Debug.WriteLine("GetLookup fail:" + objDT.GetTicks.ToString())
                    objDT.Reset()

                    Return Nothing
                End Try
            Else
                Debug.WriteLine("GetLookup nolook:" + objDT.GetTicks.ToString())
                objDT.Reset()

                Return Nothing
            End If
        End Function



        Friend Shared Function BuildDataTable(ByVal strTableName As String) As DataTable
            Dim objDT As New DataTable
            Try

                Dim objDCKey As New DataColumn
                With objDCKey
                    .AllowDBNull = False
                    '.Unique = True
                    .ColumnName = "ColumnName"
                    .DataType = System.Type.GetType("System.String")
                End With
                objDT.Columns.Add(objDCKey)

                Dim objDCOperator As New DataColumn
                With objDCOperator
                    .AllowDBNull = False
                    .ColumnName = "Operator"
                    .DataType = System.Type.GetType("System.Int32")
                End With
                objDT.Columns.Add(objDCOperator)

                Dim objDCValue1 As New DataColumn
                With objDCValue1
                    .AllowDBNull = True
                    .ColumnName = "Value1"
                    .DataType = System.Type.GetType("System.String")
                End With
                objDT.Columns.Add(objDCValue1)

                Dim objDCValue2 As New DataColumn
                With objDCValue2
                    .AllowDBNull = True
                    .ColumnName = "Value2"
                    .DataType = System.Type.GetType("System.String")
                End With
                objDT.Columns.Add(objDCValue2)

                Dim objDCCaption As New DataColumn
                With objDCCaption
                    .AllowDBNull = True
                    .ColumnName = "ColumnCaption"
                    .DataType = System.Type.GetType("System.String")
                End With
                objDT.Columns.Add(objDCCaption)

                Dim objDCDataType As New DataColumn
                With objDCDataType
                    .AllowDBNull = True
                    .ColumnName = "IsDateType"
                    .DataType = System.Type.GetType("System.Boolean")
                End With
                objDT.Columns.Add(objDCDataType)

                Dim objDCType As New DataColumn
                With objDCType
                    .AllowDBNull = True
                    .ColumnName = "DataType"
                    .DataType = System.Type.GetType("System.Int16")
                End With
                objDT.Columns.Add(objDCType)

                objDT.TableName = strTableName
            Catch e As Exception
                MsgBox(e.Message, MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Search")
            End Try
            Return objDT
        End Function

        Private mobjDS As DataSet

        Public Sub InitializeDS(ByVal objFilters As CXFilters)
            Dim dt As DataTable

            pnl.Controls.Clear()
            mobjDS = New DataSet
            If objFilters Is Nothing OrElse objFilters.Count = 0 Then
                dt = BuildDataTable("Filters0")
                'sg = New Windows.Forms.SearchEx.CXSingleFilter(mobjApp, mstrObjectName, pnlMain)
                InitializeNew(dt)
                mobjDS.Tables.Add(dt)
                'InitializeNewSingleFilter(dt, Me.pnlMain)
            Else
                'item(0) is CXFilters
                If objFilters.IsCollection Then
                    Dim objF As CXFilters, index As Integer
                    'only use item(0), other filters will be ignore.
                    'For index = 0 To objFilters.Count - 1
                    index = 0
                    Dim dt2 As DataTable = BuildDataTable("Filters" & index)
                    objF = objFilters.Item(index)
                    'If index = 0 Then
                    'InitializeSingleFilter(objF, dt2, Me.pnlMain)
                    'sg = New Windows.Forms.SearchEx.CXSingleFilter(mobjApp, mstrObjectName, pnlMain)
                    InitializeExist(objF, dt2)
                    mobjDS.Tables.Add(dt2)
                    'Else
                    '    'InitializeSingleFilter(objF, dt2, AddOrControls)
                    '    sg = New Windows.Forms.SearchEx.CXSingleFilter(mobjApp, mstrObjectName, AddOrControls)
                    '    sg.Initialize(objF, dt2)
                    '    mobjDS.Tables.Add(dt2)
                    'End If
                    'Next
                Else
                    dt = BuildDataTable("Filters0")
                    'InitializeSingleFilter(objFilters, dt, Me.pnlMain)
                    'sg = New Windows.Forms.SearchEx.CXSingleFilter(mobjApp, mstrObjectName, pnlMain)
                    InitializeExist(objFilters, dt)
                    mobjDS.Tables.Add(dt)
                End If
            End If
        End Sub


        Public Function GetFilters() As CXFilters
            Dim objFilters As New CXFilters
            Dim dr As DataRow

            If mobjDS.Tables.Count = 1 Then
                For Each dr In mobjDS.Tables(0).Rows
                    Dim objFilter As CXRangeFilter = New CXRangeFilter
                    objFilter.ColumnNameIncludeTableName = True
                    objFilter.ColumnName = dr.Item(0)
                    objFilter.Operator = dr.Item(1)
                    If Not IsDBNull(dr.Item(2)) Then objFilter.Value1 = GetValue(dr, 2)
                    If Not IsDBNull(dr.Item(3)) Then objFilter.Value2 = GetValue(dr, 3)
                    objFilters.Add(objFilter)
                Next
            Else
                Dim dt As DataTable, i As Integer = 0
                objFilters.AndOrOper = CXFilters.AndOrTypeConstants.atOR
                For Each dt In mobjDS.Tables
                    Dim objCols As New CXFilters
                    objCols.Index = i
                    i = i + 1
                    For Each dr In dt.Rows
                        Dim objFilter As New CXRangeFilter
                        objFilter.ColumnNameIncludeTableName = True
                        objFilter.ColumnName = dr.Item(0)
                        objFilter.Operator = dr.Item(1)
                        If Not IsDBNull(dr.Item(2)) Then objFilter.Value1 = GetValue(dr, 2)
                        If Not IsDBNull(dr.Item(3)) Then objFilter.Value2 = GetValue(dr, 3)
                        objCols.Add(objFilter)
                    Next
                    objFilters.Add(objCols)
                Next
            End If
            Return objFilters
        End Function



        Private Function GetValue(ByVal dr As DataRow, ByVal index As Integer) As Object
            Try

                Dim Value As String = dr.Item(index)
                Dim DataType As FieldTypeEnum = dr.Item(6)

                Select Case DataType
                    Case FieldTypeEnum.ftBoolean
                        Return DirectCast(Value, Boolean)
                    Case FieldTypeEnum.ftCurrency
                        Return Decimal.Parse(Value)
                    Case FieldTypeEnum.ftDate
                        Return Date.Parse(Value)
                    Case FieldTypeEnum.ftDecimal : Return Decimal.Parse(Value)
                    Case FieldTypeEnum.ftDouble : Return Double.Parse(Value)
                    Case FieldTypeEnum.ftGUID : Return New Guid(Value)
                    Case FieldTypeEnum.ftInt64 : Return DirectCast(Value, Int64)
                    Case FieldTypeEnum.ftInteger : Return DirectCast(Value, Int16)
                    Case FieldTypeEnum.ftLong : Return DirectCast(Value, Int32)
                    Case FieldTypeEnum.ftSingle : Return Single.Parse(Value)
                    Case Else
                        Return Value
                End Select
            Catch
                Return dr.Item(index)
            End Try
        End Function

        Private mFuncType As String = ""
        Public Overridable Property FuncType() As String
            Get
                Return mFuncType
            End Get
            Set(ByVal Value As String)
                mFuncType = Trim(Value)
            End Set
        End Property

        Private Sub RelatedSearchFieldClicked(ByVal strFld As String, ByVal objCon As Control)
            Try
                Dim SearchService As ISearchService
                If mobjApp Is Nothing Then
                    Exit Sub
                End If
                SearchService = mobjApp.SearchService
                If SearchService Is Nothing Then
                    Exit Sub
                End If
                SearchService.SearchExecute(Me.ObjectName, strFld, FuncType, objCon)
            Catch ex As Exception
                COMExpress.BusinessObject.CXEventLog.LogToFile(ex.Message & vbCrLf & ex.StackTrace, COMExpress.BusinessObject.CXEventLog.LogTypeConstants.logUI)
            End Try
        End Sub
        Private Sub RelatedSearchFieldQuery(ByVal strFld As String, ByRef bSupported As Boolean)
            Try
                Dim SearchService As ISearchService
                If mobjApp Is Nothing Then
                    Exit Sub
                End If
                SearchService = mobjApp.SearchService
                If SearchService Is Nothing Then
                    bSupported = False
                    Exit Sub
                End If
                SearchService.SearchQuery(ObjectName, strFld, FuncType, bSupported)
            Catch ex As Exception
                COMExpress.BusinessObject.CXEventLog.LogToFile(ex.Message & vbCrLf & ex.StackTrace, COMExpress.BusinessObject.CXEventLog.LogTypeConstants.logUI)
            End Try
        End Sub

    End Class



End Namespace
