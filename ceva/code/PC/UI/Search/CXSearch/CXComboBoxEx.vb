Namespace Windows.Forms.SearchEx1

    Public Class CXComboBoxEx
        Inherits System.Windows.Forms.ComboBox

        Protected Overrides Sub RefreshItem(ByVal index As Integer)
            MyBase.RefreshItem(index)
        End Sub

        Protected Overrides Sub SetItemsCore(ByVal items As System.Collections.IList)
            MyBase.SetItemsCore(items)
        End Sub

        'Public Function AutoGetCom() As String '格适化combobox
        '    If Me.SelectedValue = "" And Me.Text.Trim() = "" Then
        '        AutoGetCom = Trim(Me.SelectedValue)
        '    ElseIf Me.SelectedValue <> "" Then
        '        AutoGetCom = Trim(Me.SelectedValue)
        '    ElseIf Me.SelectedValue = "" And Me.Text.Trim() <> "" Then
        '        AutoGetCom = Me.Text.Trim()
        '    Else
        '        AutoGetCom = Me.Text.Trim()
        '    End If
        'End Function


        'Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        '    MyBase.OnLostFocus(e)
        '    'Dim strTyped As String
        '    'Dim pos As Integer
        '    'strTyped = Me.Text
        '    'If Trim(strTyped) = "" Then
        '    '    'Me.SelectedIndex = -1          'do nothing
        '    'Else
        '    '    pos = Me.FindString(strTyped)
        '    '    If pos >= 0 Then
        '    '        Me.SelectedIndex = pos
        '    '    End If
        '    'End If
        'End Sub

        Private bAllowEx As Boolean = False
        Public Property AllowEx() As Boolean
            Get
                Return bAllowEx
            End Get
            Set(ByVal Value As Boolean)
                bAllowEx = Value
            End Set
        End Property


        Private Function IsMatchedWithList() As Boolean
            Dim dv As DataView
            Dim bRet As Boolean
            bRet = False
            If AllowEx = False Then
                Exit Function
            End If
            If Me.DataSource Is Nothing Then
                Return bRet
            End If
            If Me.DataSource.GetType Is GetType(DataSet) Then
                dv = DirectCast(Me.DataSource, DataSet).Tables(0).DefaultView
            ElseIf Me.DataSource.GetType Is GetType(DataView) Then
                dv = DirectCast(Me.DataSource, DataView)
            Else
                Return bRet
            End If
            Dim strCode As String
            Dim pos As Integer
            Dim strText As String
            Dim i As Integer
            Dim strVal As String
            strText = Me.Text
            '如当前TEXT与DATAVIEW的当前记录相符,则返成功
            pos = Me.SelectedIndex
            If pos >= 0 AndAlso IsDBNull(dv.Item(pos).Item(1)) = False AndAlso CType(dv.Item(pos).Item(1), String) = strText Then
                Return True
            End If
            '不成功,以当前文本在DATAVIEW中找
            For i = 0 To dv.Count - 1
                If IsDBNull(dv.Item(i).Item(1)) = False AndAlso CType(dv.Item(i).Item(1), String) = strText Then
                    Me.SelectedIndex = i
                    Return True
                End If
            Next
            '以当前文本找不到,把当前文本当成Value再找一次
            pos = Microsoft.VisualBasic.InStr(Me.Text, "|")
            If pos > 0 Then
                strCode = Microsoft.VisualBasic.Left(Me.Text, pos - 1)
            Else
                strCode = Me.Text
            End If
            For i = 0 To dv.Count - 1
                If IsDBNull(dv.Item(i).Item(1)) = False AndAlso Trim(CType(dv.Item(i).Item(0), String)) = Trim(strCode) Then
                    Me.SelectedIndex = i
                    Return True
                End If
            Next
            Return False

        End Function



        Public Overridable Property SelectedValueEx() As Object
            Get
                Dim str As String
                Dim bMatched As Boolean = False
                str = Trim(Me.Text)
                If str = "" Then
                    Return DBNull.Value
                    'Return MyBase.SelectedValue()
                End If
                Try
                    bMatched = IsMatchedWithList()
                Catch ex As Exception

                End Try
                If bMatched = False Then
                    Return str
                End If
                Return MyBase.SelectedValue
            End Get
            Set(ByVal Value As Object)
                MyBase.SelectedValue = Value
            End Set
        End Property



        Public Overrides Property Text() As String
            Get
                Return MyBase.Text
            End Get
            Set(ByVal Value As String)
                If Trim(Value) = "" Then
                    MyBase.Text = Value
                ElseIf SetText(Value) = False Then
                    Me.SelectAll()
                    MyBase.SelectedText = Value
                    'MyBase.SelectedIndex = -1
                End If
            End Set
        End Property

        Private Function SetText(ByVal strText As String) As Boolean
            Dim dv As DataView
            If AllowEx = False Then
                Exit Function
            End If
            If Me.DataSource Is Nothing Then
                Return False
            End If
            If Me.DataSource.GetType Is GetType(DataSet) Then
                dv = DirectCast(Me.DataSource, DataSet).Tables(0).DefaultView
            ElseIf Me.DataSource.GetType Is GetType(DataView) Then
                dv = DirectCast(Me.DataSource, DataView)
            Else
                Return False
            End If
            '以文本的方式找一次
            Dim i As Integer
            For i = 0 To dv.Count - 1
                If IsDBNull(dv.Item(i).Item(1)) = False AndAlso CType(dv.Item(i).Item(1), String) = strText Then
                    Me.SelectedIndex = i
                    Return True
                End If
            Next
            Dim pos As Integer
            Dim strCode As String
            '以当前文本找不到,把当前文本当成Value再找一次
            pos = Microsoft.VisualBasic.InStr(strText, "|")
            If pos > 0 Then
                strCode = Microsoft.VisualBasic.Left(strText, pos - 1)
            Else
                strCode = strText
            End If
            For i = 0 To dv.Count - 1
                If IsDBNull(dv.Item(i).Item(1)) = False AndAlso Trim(CType(dv.Item(i).Item(0), String)) = Trim(strCode) Then
                    Me.SelectedValue = strCode
                    Return True
                End If
            Next
            'MyBase.SelectedText = strText
            Return False
        End Function

    End Class
End Namespace
