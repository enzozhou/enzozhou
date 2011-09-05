Public Class AutoCombobox
    Inherits System.Windows.Forms.ComboBox
    Dim key As Boolean

    Protected Overrides Sub RefreshItem(ByVal index As Integer)
        MyBase.RefreshItem(index)
    End Sub

    Protected Overrides Sub SetItemsCore(ByVal items As System.Collections.IList)
        MyBase.SetItemsCore(items)
    End Sub

    Private InOnTextChanged As Boolean = False
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        ' = CType(Me, ComboBox)

        If InOnTextChanged Then
            Exit Sub
        End If
        InOnTextChanged = True
        'If Me.DroppedDown = True Then
        '    Me.DroppedDown = True
        'End If
        Try
            Dim strTyped As String
            Dim intFoundIndex As Integer
            Dim objFoundItem As Object
            Dim strFoundText As String
            Dim strAppendText As String
            If key = True Then
                strTyped = Me.Text.Trim()
                intFoundIndex = Me.FindString(strTyped)
                If intFoundIndex >= 0 Then
                    objFoundItem = Me.Items(intFoundIndex)
                    strFoundText = Me.GetItemText(objFoundItem)
                    If strTyped.Length <= strFoundText.Length Then
                        strAppendText = strFoundText.Substring(strTyped.Length)
                        Me.Text = strTyped & strAppendText
                        Me.SelectionStart = strTyped.Length
                        Me.SelectionLength = strAppendText.Length
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        InOnTextChanged = False

    End Sub

    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
        key = True
        Select Case e.KeyCode
            Case Keys.Back, Keys.Left, Keys.Right, Keys.Up, _
                Keys.Delete, Keys.Down, Keys.CapsLock
                key = False
        End Select
    End Sub

    'Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
    '    Dim strTyped As String
    '    If Me.Text.Trim() = "" Then
    '        Me.Text = ""
    '        Return
    '    Else
    '        strTyped = Me.Text.Trim()
    '        Me.SelectedIndex = Me.FindString(strTyped)
    '    End If
    'End Sub
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


    Private Function IsMatchedWithList() As Boolean
        Dim dv As DataView
        Dim bRet As Boolean
        bRet = False
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


    Dim bInFlag As Boolean = False
    Public Shadows Property SelectedValue() As Object
        Get
            Dim str As String
            '            Dim bMatched As Boolean = False
            str = Trim(Me.Text)
            If str <> "" And bInFlag = False Then
                bInFlag = True
                Try
                    IsMatchedWithList()
                Catch ex As Exception
                End Try
                bInFlag = False
            End If

            'Try
            '    bMatched = IsMatchedWithList()
            'Catch ex As Exception

            'End Try
            'If bMatched = False Then
            '    'Return Nothing               ' 不在列表中的值将在不允许  (但用于查找的输入允许,见CXComboBoxEx)
            '    Return str
            'End If
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
            InOnTextChanged = True
            Try
                If Trim(Value) = "" Then
                    MyBase.Text = Value
                ElseIf SetText(Value) = False Then
                    Me.SelectAll()
                    MyBase.SelectedText = Value
                End If
            Catch ex As Exception
            End Try
            InOnTextChanged = False
        End Set
    End Property

    Private Function SetText(ByVal strText As String) As Boolean
        Dim dv As DataView
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
                'Me.SelectedValue = strCode
                Me.SelectedIndex = i
                Return True
            End If
        Next
        'MyBase.SelectedText = strText
        Return False
    End Function


End Class
