Imports COMExpress.BusinessObject.Filters
Imports COMExpress.UserInterface.Layout
Imports COMExpress.Windows.Controls


Namespace Windows.Forms.SearchEx1



    Public Class CXSearchField
        Inherits System.Windows.Forms.UserControl

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
                ClearBindings(Me)
                If Not mctlValue1 Is Nothing Then
                    mctlValue1.Dispose()
                End If
                If Not mctlValue2 Is Nothing Then
                    mctlValue2.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents btnRelateSearch As System.Windows.Forms.Button
        Friend WithEvents lblFields As System.Windows.Forms.Label
        Friend WithEvents cboOperator As System.Windows.Forms.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CXSearchField))
            Me.btnRelateSearch = New System.Windows.Forms.Button
            Me.lblFields = New System.Windows.Forms.Label
            Me.cboOperator = New System.Windows.Forms.ComboBox
            Me.SuspendLayout()
            '
            'btnRelateSearch
            '
            Me.btnRelateSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnRelateSearch.Image = CType(resources.GetObject("btnRelateSearch.Image"), System.Drawing.Image)
            Me.btnRelateSearch.Location = New System.Drawing.Point(416, 0)
            Me.btnRelateSearch.Name = "btnRelateSearch"
            Me.btnRelateSearch.Size = New System.Drawing.Size(24, 24)
            Me.btnRelateSearch.TabIndex = 7
            '
            'lblFields
            '
            Me.lblFields.AutoSize = True
            Me.lblFields.Location = New System.Drawing.Point(4, 5)
            Me.lblFields.Name = "lblFields"
            Me.lblFields.Size = New System.Drawing.Size(0, 17)
            Me.lblFields.TabIndex = 6
            '
            'cboOperator
            '
            Me.cboOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboOperator.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOperator.Location = New System.Drawing.Point(120, 2)
            Me.cboOperator.Name = "cboOperator"
            Me.cboOperator.Size = New System.Drawing.Size(72, 21)
            Me.cboOperator.TabIndex = 1
            '
            'CXSearchField
            '
            Me.Controls.Add(Me.btnRelateSearch)
            Me.Controls.Add(Me.cboOperator)
            Me.Controls.Add(Me.lblFields)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "CXSearchField"
            Me.Size = New System.Drawing.Size(456, 24)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Check Box..."

        Friend Class CXSearchCheckBox
            Inherits CheckBox

            Public Property CheckValue() As Object
                Get
                    Select Case Me.CheckState
                        Case CheckState.Indeterminate
                            Return System.Convert.DBNull
                        Case Else
                            Return 0
                    End Select
                End Get
                Set(ByVal Value As Object)
                End Set
            End Property

            Public Property CheckOperator() As System.Int32
                Get
                    Select Case Me.CheckState
                        Case CheckState.Checked
                            Return ConditionOperator.NotEqual
                        Case CheckState.Unchecked
                            Return ConditionOperator.Equal
                        Case CheckState.Indeterminate
                            Return ConditionOperator.LikeWise
                    End Select
                End Get
                Set(ByVal Value As System.Int32)
                    Select Case Value
                        Case ConditionOperator.Equal
                            Me.CheckState = CheckState.Unchecked
                        Case ConditionOperator.NotEqual
                            Me.CheckState = CheckState.Checked
                        Case ConditionOperator.LikeWise
                            Me.CheckState = CheckState.Indeterminate
                    End Select
                End Set
            End Property
        End Class

#End Region


#Region "Constructure...."
        Private mstrOldColumn As String = ""
        Public Event FieldSelected(ByVal NewColumn As String, ByVal e As CXSearchField)
        Private mobjFilter As DataRowView
        Private WithEvents mctlValue1 As Control
        Private mctlValue2 As Control
        Private Shared p1 As System.Drawing.Point = New System.Drawing.Point(193, 2)
        Private Shared p1_ As System.Drawing.Point = New System.Drawing.Point(120, 2)
        Private defSize As System.Drawing.Size = New System.Drawing.Size(130, 21)
        Private mobjFld As CXField



        Public Sub Initialize(ByVal objFilter As DataRowView, ByVal objFld As CXField, ByVal objDSLookup As DataView)

            Dim objDT As New clsDebugTime

            mobjFld = objFld
            If Not mctlValue1 Is Nothing Then
                Controls.Remove(mctlValue1)
                mctlValue1 = Nothing
            End If

            If Not mctlValue2 Is Nothing Then
                Controls.Remove(mctlValue2)
                mctlValue2 = Nothing
            End If

            mobjFilter = objFilter

            If objFld.FieldControlCategory = FieldControlCategoryEnum.fcCheckBox Then
                If IsDBNull(objFilter.Item("Value1")) Then objFilter.Item("Operator") = ConditionOperator.LikeWise
                InitOperators(ConditionOperator.LikeWise, False)
                cboOperator.Visible = False
            Else
                InitOperators(objFld.DefaultSearchOperator, objFld.ShowBetweenAnd)
                cboOperator.Visible = objFld.ShowSearchOperator
            End If
            cboOperator.Tag = objFld.ShowSearchOperator



            Debug.WriteLine("Initialize(" + objFld.FieldCaptionText + ") InitOperators:" + objDT.GetTicks.ToString())
            objDT.Reset()


            If objDSLookup Is Nothing Then
                InitControls(objFld)
            Else
                InitCombo(objFld, objDSLookup)
            End If

            Debug.WriteLine("Initialize(" + objFld.FieldCaptionText + ") InitControls:" + objDT.GetTicks.ToString())
            objDT.Reset()

            DataBind()

            Debug.WriteLine("Initialize(" + objFld.FieldCaptionText + ") DataBind:" + objDT.GetTicks.ToString())
            objDT.Reset()

            'If TypeOf Me.ParentForm Is CXSearchForm Then
            '    With DirectCast(Me.ParentForm, CXSearchForm)
            '        If lblFields.Width > .MaxLabelWidth Then .MaxLabelWidth = lblFields.Width
            '    End With
            'End If
            mctlValue1.Visible = True
            ' Debug.WriteLine("cboOperator.SelectedValue:" + CType(cboOperator.SelectedValue, String))
            Value2Status(CType(mobjFilter(1), ConditionOperator))

            'Debug.WriteLine("Initialize(" + objFld.FieldCaptionText + ") Value2Status:" + objDT.GetTicks.ToString())
            objDT.Reset()
        End Sub

        Private mintLabelWidth As Integer = 80
        Public Property LabelWidth() As Integer
            Get
                If mintLabelWidth < lblFields.Width Then
                    Return lblFields.Width
                Else
                    Return mintLabelWidth
                End If
            End Get
            Set(ByVal Value As Integer)
                mintLabelWidth = Value
            End Set
        End Property


        Private Sub Value2Status(ByVal Oper As ConditionOperator)
            If mctlValue2 Is Nothing Then Return
            Select Case Oper
                Case ConditionOperator.Between, ConditionOperator.NotBetween
                    mctlValue2.Visible = True
                Case Else
                    mctlValue2.Visible = False
            End Select
            SizeItInternal(Oper)
        End Sub

        Private Sub InitControls(ByVal objFld As CXField)
            'Dim frm As CXWinFormBase
            'Try
            '    frm = CType(Me.ParentForm, CXSearchForm).CXParentForm
            'Catch ex As Exception
            '    frm = Nothing
            'End Try
            'If Not frm Is Nothing Then
            '    mctlValue1 = frm.CustomSearchControl(objFld, Nothing, Nothing)
            '    If Not mctlValue1 Is Nothing Then
            '        Me.Controls.Add(mctlValue1)
            '        If objFld.ShowBetweenAnd Then
            '            mctlValue2 = frm.CustomSearchControl(objFld, Nothing, Nothing)
            '            Me.Controls.Add(mctlValue2)
            '        End If
            '        Return
            '    End If
            'End If
            Select Case objFld.FieldControlCategory
                Case FieldControlCategoryEnum.fcCalendar
                    mctlValue1 = New CXDateTimePicker
                    Me.Controls.Add(mctlValue1)
                    With CType(mctlValue1, CXDateTimePicker)
                        If DateFormatString = "" Then
                            .Format = DateTimePickerFormat.Short
                        Else
                            .Format = DateTimePickerFormat.Custom
                            .CustomFormat = DateFormatString
                        End If
                        .ShowCheckBox = True
                        .Tag = "ValueEx"
                    End With

                    mctlValue2 = New CXDateTimePicker
                    Me.Controls.Add(mctlValue2)
                    With CType(mctlValue2, CXDateTimePicker)
                        If DateFormatString = "" Then
                            .Format = DateTimePickerFormat.Short
                        Else
                            .Format = DateTimePickerFormat.Custom
                            .CustomFormat = DateFormatString
                        End If
                        .ShowCheckBox = True
                        .Tag = "ValueEx"
                    End With
                Case FieldControlCategoryEnum.fcTime
                    mctlValue1 = New CXDateTimePicker
                    Me.Controls.Add(mctlValue1)
                    With CType(mctlValue1, CXDateTimePicker)
                        .Format = DateTimePickerFormat.Time
                        .ShowCheckBox = True
                        .ShowUpDown = True
                        .Tag = "ValueEx"
                    End With

                    mctlValue2 = New CXDateTimePicker
                    Me.Controls.Add(mctlValue2)
                    With CType(mctlValue2, CXDateTimePicker)
                        .Format = DateTimePickerFormat.Time
                        .ShowCheckBox = True
                        .ShowUpDown = True
                        .Tag = "ValueEx"
                    End With
                Case FieldControlCategoryEnum.fcCheckBox
                    mctlValue1 = New CXSearchCheckBox
                    Me.Controls.Add(mctlValue1)
                    With CType(mctlValue1, CXSearchCheckBox)
                        .ThreeState = True
                        .CheckValue = Convert.DBNull
                        .Tag = "CheckValue"
                    End With
                Case Else
                    mctlValue1 = New TextBox
                    mctlValue1.Tag = "Text"
                    Me.Controls.Add(mctlValue1)
                    mctlValue2 = New TextBox
                    mctlValue2.Tag = "Text"
                    Me.Controls.Add(mctlValue2)
            End Select
        End Sub

        Private Sub InitCombo(ByVal objFld As CXField, ByVal objDS As DataView)
            'Dim frm As CXWinFormBase

            'Try
            '    frm = CType(Me.ParentForm, CXSearchForm).CXParentForm
            'Catch ex As Exception
            '    frm = Nothing
            'End Try
            'If Not frm Is Nothing Then
            '    mctlValue1 = frm.CustomSearchControl(objFld, objDS, Nothing)
            '    If Not mctlValue1 Is Nothing Then
            '        Me.Controls.Add(mctlValue1)
            '        mctlValue2 = frm.CustomSearchControl(objFld, objDS.Table.Copy.DefaultView, Nothing)
            '        Me.Controls.Add(mctlValue2)
            '        Return
            '    End If
            'End If

            Try
                'Dim bc As New BindingContext
                mctlValue1 = New CXComboBoxEx
                'mctlValue1.au
                objDS.Sort = objDS.Table.Columns(0).ColumnName
                If objDS.Find(DBNull.Value) < 0 Then
                    Dim dr As DataRowView = objDS.AddNew
                    dr(0) = DBNull.Value
                    dr(1) = DBNull.Value
                End If
                objDS.Sort = String.Empty

                Dim objDT As New clsDebugTime

                'CType(mctlValue1, ComboBox).BindingContext = bc
                Me.Controls.Add(mctlValue1)
                With CType(mctlValue1, CXComboBoxEx)
                    .ValueMember = objDS.Table.Columns(0).ColumnName
                    .DisplayMember = objDS.Table.Columns(1).ColumnName
                    .DataSource = objDS
                    '.Text = ""
                    .Tag = "SelectedValueEx"
                    .DropDownStyle = ComboBoxStyle.DropDown
                End With

                Debug.WriteLine("InitCombo Value1:" + objDT.GetTicks.ToString())
                objDT.Reset()

                Dim objDS2 As DataView = objDS.Table.Copy.DefaultView
                'bc = New BindingContext

                mctlValue2 = New CXComboBoxEx
                'CType(mctlValue2, ComboBox).BindingContext = bc
                Me.Controls.Add(mctlValue2)
                With CType(mctlValue2, CXComboBoxEx)
                    .ValueMember = objDS2.Table.Columns(0).ColumnName
                    .DisplayMember = objDS2.Table.Columns(1).ColumnName
                    .DataSource = objDS2
                    '.Text = ""
                    .Tag = "SelectedValueEx"
                    .DropDownStyle = ComboBoxStyle.DropDown
                End With

                Debug.WriteLine("InitCombo Value2:" + objDT.GetTicks.ToString())
                objDT.Reset()

            Catch e As Exception
                'MsgBox(e.Message)
            End Try
        End Sub

        Private Sub DataBind()
            'lblFields.DataBindings.Clear()
            cboOperator.DataBindings.Clear()
            mctlValue1.DataBindings.Clear()
            If Not mctlValue2 Is Nothing Then mctlValue2.DataBindings.Clear()

            If TypeOf mctlValue1 Is CXComboBoxEx Then
                DirectCast(mctlValue1, CXComboBoxEx).AllowEx = True
            End If
            If Not mctlValue2 Is Nothing AndAlso TypeOf mctlValue2 Is CXComboBoxEx Then
                DirectCast(mctlValue2, CXComboBoxEx).AllowEx = True
            End If


            'lblFields.DataBindings.Add("Text", mobjFilter, "ColumnCaption")
            lblFields.Text = mobjFilter.Item("ColumnCaption")
            If TypeOf (mctlValue1) Is CXSearchCheckBox Then
                mctlValue1.DataBindings.Add("CheckOperator", mobjFilter, "Operator")
                mctlValue1.DataBindings.Add("CheckValue", mobjFilter, "Value1")
            Else
                cboOperator.DataBindings.Add("SelectedValue", mobjFilter, "Operator")
                'mctlValue1.DataBindings.Add(GetBoundProperty(mctlValue1), mobjFilter, "Value1")
                If mctlValue1.Tag Is Nothing Then
                    mctlValue1.DataBindings.Add("Text", mobjFilter, "Value1")
                Else
                    mctlValue1.DataBindings.Add(mctlValue1.Tag, mobjFilter, "Value1")
                End If
            End If
            If Not mctlValue2 Is Nothing Then
                If mctlValue2.Tag Is Nothing Then
                    mctlValue2.DataBindings.Add("Text", mobjFilter, "Value2")
                Else
                    mctlValue2.DataBindings.Add(mctlValue2.Tag, mobjFilter, "Value2")
                End If
            End If
        End Sub

        'Private Function GetBoundProperty(ByVal ctl As Control) As String
        '    If TypeOf (ctl) Is ComboBox Then
        '        Return "SelectedValue"
        '    ElseIf TypeOf (ctl) Is TextBox Then
        '        Return "Text"
        '    ElseIf TypeOf (ctl) Is CXSearchCheckBox Then
        '        Return "CheckStateEx"
        '    Else
        '        Return "ValueEx"
        '    End If
        'End Function

        Private Function BuildStaticTable(ByVal strTableName As String) As DataTable
            Dim objDT As New DataTable
            Try

                Dim objDCKey As New DataColumn

                With objDCKey
                    .AllowDBNull = False
                    .Unique = True
                    .ColumnName = "Value"
                    .DataType = System.Type.GetType("System.Int32")
                End With
                objDT.Columns.Add(objDCKey)

                Dim objDCValue As New DataColumn
                With objDCValue
                    .AllowDBNull = False
                    .ColumnName = "Display"
                    .DataType = System.Type.GetType("System.String")
                End With
                objDT.Columns.Add(objDCValue)
                objDT.TableName = strTableName
            Catch e As Exception
                'MsgBox(e.Message)
            End Try
            Return objDT
        End Function

        Private Sub InitOperators(ByVal defaultOperator As Long, ByVal ShowBetweenAnd As Boolean)
            Dim objDS As New DataSet
            Dim dt As DataTable, dr As DataRow
            dt = BuildStaticTable("Operator")

            dr = dt.NewRow
            With dr
                .Item(0) = ConditionOperator.LikeWise
                .Item(1) = "Like" 'Resources.Strings.GetResourceString("OperatorLike") ' "Like"
            End With
            dt.Rows.Add(dr)

            dr = dt.NewRow
            With dr
                .Item(0) = ConditionOperator.Equal
                .Item(1) = "="
            End With
            dt.Rows.Add(dr)

            dr = dt.NewRow
            With dr
                .Item(0) = ConditionOperator.NotEqual
                .Item(1) = "<>"
            End With
            dt.Rows.Add(dr)

            dr = dt.NewRow
            With dr
                .Item(0) = ConditionOperator.GreaterThan
                .Item(1) = ">"
            End With
            dt.Rows.Add(dr)

            dr = dt.NewRow
            With dr
                .Item(0) = ConditionOperator.GreaterThanOrEqualTo
                .Item(1) = ">="
            End With
            dt.Rows.Add(dr)

            dr = dt.NewRow
            With dr
                .Item(0) = ConditionOperator.LessThan
                .Item(1) = "<"
            End With
            dt.Rows.Add(dr)

            dr = dt.NewRow
            With dr
                .Item(0) = ConditionOperator.LessThanOrEqualTo
                .Item(1) = "<="
            End With
            dt.Rows.Add(dr)

            dr = dt.NewRow
            With dr
                .Item(0) = ConditionOperator.IsNull
                .Item(1) = "IS NULL" 'Resources.Strings.GetResourceString("OperatorIsNull") '  "IS NULL"
            End With
            dt.Rows.Add(dr)
            dr = dt.NewRow
            With dr
                .Item(0) = ConditionOperator.NotIsNull
                .Item(1) = "NOT IS NULL" 'Resources.Strings.GetResourceString("OperatorNotIsNull") '"NOT IS NULL"
            End With
            dt.Rows.Add(dr)


            If ShowBetweenAnd Then
                dr = dt.NewRow
                With dr
                    .Item(0) = ConditionOperator.Between
                    .Item(1) = "Between" 'Resources.Strings.GetResourceString("OperatorBetweenAnd") ' 
                End With
                dt.Rows.Add(dr)

                dr = dt.NewRow
                With dr
                    .Item(0) = ConditionOperator.NotBetween
                    .Item(1) = "Not Between" ' Resources.Strings.GetResourceString("OperatorNotBetweenAnd") '  "Not Between..And"
                End With
                dt.Rows.Add(dr)
            End If

            dr = dt.NewRow
            With dr
                .Item(0) = ConditionOperator.NotLikeWise
                .Item(1) = "Not Like" 'Resources.Strings.GetResourceString("OperatorNotLike") ' "Not Like"
            End With
            dt.Rows.Add(dr)


            dr = dt.NewRow
            With dr
                .Item(0) = ConditionOperator.IncludeIn
                .Item(1) = "Include"
            End With
            dt.Rows.Add(dr)

            dr = dt.NewRow
            With dr
                .Item(0) = ConditionOperator.NotIncludeIn
                .Item(1) = "Not Include"
            End With
            dt.Rows.Add(dr)



            objDS.Tables.Add(dt)

            Dim objDT As New clsDebugTime
            With cboOperator
                .DataSource = objDS.Tables(0)
                .DisplayMember = "Display"
                .ValueMember = "Value"
                .SelectedValue = defaultOperator
            End With
            Debug.WriteLine("InitOperators bind:" + objDT.GetTicks.ToString())
            objDT.Reset()

        End Sub

        Private Sub cboOperator_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOperator.SelectedValueChanged
            If cboOperator.Focused Then Value2Status(CType(cboOperator.SelectedValue, ConditionOperator))
        End Sub

        Public Sub UpdateData()
            mobjFilter.EndEdit()
        End Sub

        Friend Sub SizeIt()
            Dim op As ConditionOperator
            op = CType(cboOperator.SelectedValue, ConditionOperator)
            SizeItInternal(op)
        End Sub

        Friend Sub SizeItInternal(ByVal op As ConditionOperator)
            Dim lW As Integer, lL As Integer
            Dim bShowVal2 As Boolean
            bShowVal2 = False
            Dim ClientSize As Size

            If op = ConditionOperator.Between Or op = ConditionOperator.NotBetween Then
                bShowVal2 = True
            End If
            'If TypeOf Me.ParentForm Is CXSearchForm Then
            '    lL = DirectCast(Me.ParentForm, CXSearchForm).MaxLabelWidth + 2
            'Else
            'End If
            If Me.ParentForm Is Nothing Then
                Exit Sub
            End If
            lL = lblFields.Location.X + Me.LabelWidth + 2
            With Me.ParentForm
                'Me.Width = .ClientSize.Width
                If DirectCast(cboOperator.Tag, Boolean) Then
                    cboOperator.Location = New Point(lL, 2)
                    lL = cboOperator.Location.X + cboOperator.Width + 2
                End If
                If Not mctlValue1 Is Nothing Then
                    If Not mctlValue2 Is Nothing And bShowVal2 Then
                        'lW = IIf(RelatedSearch, (.ClientSize.Width - lL - 48) \ 2, (.ClientSize.Width - lL - 30) \ 2)
                        lW = (.ClientSize.Width - lL - 48) \ 2
                        mctlValue1.Location = New Point(lL, 2)
                        mctlValue1.Size = New Size(lW, cboOperator.Size.Height)
                        mctlValue2.Location = New Point(mctlValue1.Location.X + mctlValue1.Width + 2, 2)
                        mctlValue2.Size = New Size(lW, cboOperator.Size.Height)
                        If RelatedSearch Then
                            btnRelateSearch.Visible = True
                            Me.btnRelateSearch.Location = New Point(mctlValue2.Location.X + mctlValue2.Width + 2, 2)
                            Me.btnRelateSearch.Size = New Size(24, cboOperator.Size.Height)
                        Else
                            btnRelateSearch.Visible = False
                        End If
                    Else
                        'lW = IIf(RelatedSearch, (.ClientSize.Width - lL - 48), (.ClientSize.Width - lL - 30))
                        lW = (.ClientSize.Width - lL - 48)
                        mctlValue1.Location = New Point(lL, 2)
                        mctlValue1.Size = New Size(lW, cboOperator.Size.Height)
                        If RelatedSearch Then
                            btnRelateSearch.Visible = True
                            Me.btnRelateSearch.Location = New Point(lL + lW + 2, 2)
                            Me.btnRelateSearch.Size = New Size(24, cboOperator.Size.Height)
                        Else
                            btnRelateSearch.Visible = False
                        End If
                    End If
                End If
            End With
        End Sub

        Private Sub ClearBindings(ByVal c As Control)
            If Not c.IsDisposed Then
                If c.DataBindings.Count > 0 Then
                    Dim bindings(c.DataBindings.Count - 1) As Binding
                    c.DataBindings.CopyTo(bindings, 0)
                    c.DataBindings.Clear()
                    For Each bind As Binding In bindings
                        System.ComponentModel. _
                            TypeDescriptor.Refresh(bind.DataSource)
                    Next
                End If

                For Each cc As Control In c.Controls
                    ClearBindings(cc)
                Next
            End If
        End Sub

        Private mDateFmtString As String
        Public Property DateFormatString() As String
            Get
                Return mDateFmtString
            End Get
            Set(ByVal Value As String)
                mDateFmtString = Value
            End Set
        End Property

#Region "Related Searching"
        '------------------------------------------------------------------------------------------------------------
        Public Event RelatedSearchClicked(ByVal strFld As String, ByVal objCon As Control)
        Public Event RelatedSearchQuery(ByVal strFld As String, ByRef bSupported As Boolean)
        Private Sub btnRelateSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelateSearch.Click
            RaiseEvent RelatedSearchClicked(mobjFld.dbName, mctlValue1)
        End Sub
        Public ReadOnly Property RelatedSearch() As Boolean
            Get
                Dim bSupported As Boolean = True
                Try
                    RaiseEvent RelatedSearchQuery(mobjFld.dbName, bSupported)
                Catch ex As Exception
                End Try
                Return bSupported
            End Get
        End Property
        '---------------------------------------------------------------------------------------------------------
#End Region

#Region "Multi Values inputting"

        Private Function SupportMultiValue() As Boolean
            Dim co As ConditionOperator
            Try

                co = cboOperator.SelectedValue
                If co = ConditionOperator.IncludeIn Or co = ConditionOperator.NotIncludeIn Then
                    Return True
                End If
                Return False
            Catch ex As Exception
                Return False
            End Try
        End Function


        Dim lastDownTime As Long = DateTime.Now.Ticks
        Private Sub mctlValue1MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles mctlValue1.MouseDown

            Dim sp As TimeSpan = New TimeSpan(DateTime.Now.Ticks - lastDownTime)
            lastDownTime = DateTime.Now.Ticks
            If (sp.Milliseconds <= SystemInformation.DoubleClickTime / 2) Then
                'Double Click
                mctlValue1DoubleClick()
            Else
            End If
        End Sub


        Private Sub mctlValue1DoubleClick()
            Try

                Dim frm As frmPasteValues
                If SupportMultiValue() = False Then
                    Exit Sub
                End If
                frm = New frmPasteValues
                frm.Icon = Me.ParentForm.Icon
                frm.Values = mctlValue1.Text
                If frm.ShowDialog(Me.ParentForm) <> DialogResult.OK Then
                    Exit Sub
                End If
                mctlValue1.Focus()
                mctlValue1.Text = frm.Values
                frm.Dispose()
                frm = Nothing
            Catch ex As Exception

            End Try

        End Sub
#End Region



#End Region



    End Class



End Namespace


