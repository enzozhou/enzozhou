Imports COMExpress.Windows.Forms
Imports COMExpress.Windows.Controls
Public Class ListViewSorter
    Implements System.Collections.IComparer
    Private m_Column As Integer = 0
    Private m_SortType As Integer = 0 '排序类型
    Private m_asc As Boolean = True

    Public Sub New(ByVal Column As Integer, ByVal bAsc As Boolean)
        m_Column = Column
        m_asc = bAsc
    End Sub 'New

    Public Sub New(ByVal Column As Integer, ByVal bAsc As Boolean, ByVal SortType As Integer)
        m_Column = Column
        m_SortType = SortType
        m_asc = bAsc
    End Sub 'New

    Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
        Dim item1 As String = CType(x, ListViewItem).SubItems(m_Column).Text.Trim()
        Dim item2 As String = CType(y, ListViewItem).SubItems(m_Column).Text.Trim()
        Dim intSort As Integer = 0
        If Not m_asc Then '反序
            Dim temp As String = item1
            item1 = item2
            item2 = temp
        End If

        If m_SortType = 0 Then '字符排序
            intSort = [String].Compare(item1, item2)
            '数值排序
        Else
            Dim str1 As Double = 0
            Dim str2 As Double = 0
            If item1 = "" Then '为空设置为最小
                Return 1
            Else
                If item2 = "" Then
                    Return 0
                End If
            End If
            Try
                str1 = Double.Parse(item1)
                str2 = Double.Parse(item2)
            Catch
            End Try
            '转换出错
            If str1 >= str2 Then
                Return 0
            Else
                Return 1
            End If
        End If
        Return intSort
    End Function
    'Friend sortItem As ListViewItem
    'Friend sortColumn As Integer

    '' A SortWrapper requires the item and the index of the clicked column.
    'Public Sub New(ByVal Item As ListViewItem, ByVal iColumn As Integer)
    '    sortItem = Item
    '    sortColumn = iColumn
    'End Sub

    '' Text property for getting the text of an item.
    'Public ReadOnly Property [Text]() As String
    '    Get
    '        Return sortItem.SubItems(sortColumn).Text
    '    End Get
    'End Property

    '' Implementation of the IComparer 
    '' interface for sorting ArrayList items.
    'Public Class SortComparer
    '    Implements IComparer
    '    Private ascending As Boolean


    '    ' Constructor requires the sort order;
    '    ' true if ascending, otherwise descending.
    '    Public Sub New(ByVal asc As Boolean)
    '        Me.ascending = asc
    '    End Sub


    '    ' Implemnentation of the IComparer:Compare 
    '    ' method for comparing two objects.
    '    Public Function [Compare](ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
    '        Dim xItem As ListViewSorter = CType(x, ListViewSorter)
    '        Dim yItem As ListViewSorter = CType(y, ListViewSorter)

    '        Dim xText As String = xItem.sortItem.SubItems(xItem.sortColumn).Text
    '        Dim yText As String = yItem.sortItem.SubItems(yItem.sortColumn).Text
    '        Return xText.CompareTo(yText) * IIf(Me.ascending, 1, -1)
    '    End Function
    'End Class

    'Implements System.Collections.IComparer
    'Private col As Integer
    'Public Sub New(ByVal SortIndex As Integer)
    '    Me.col = SortIndex
    'End Sub

    'Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
    '    Dim x1, y1 As ListViewItem
    '    Dim intx, inty As Integer
    '    x1 = x
    '    y1 = y
    '    Return System.Collections.CaseInsensitiveComparer.Default.Compare(x1.SubItems(col).Text, y1.SubItems(col).Text)


    'End Function

    'Private Function ParseListItemString(ByVal x As String) As Integer
    '    Dim counter, i As Integer
    '    counter = 0
    '    For i = x.Length - 1 To 0 Step -1
    '        If (x.Chars(i) = "{ ") Then
    '            Exit For
    '        End If
    '        counter = counter + 1
    '    Next i

    '    Return CInt((x.Substring(x.Length - counter, counter - 1)))
    'End Function
    ' Implements IComparer

    'Public Sub New()
    '    col = 0
    'End Sub
    'Public Sub New(ByVal column As Integer)

    '    col = column
    'End Sub
    'Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
    '    If (String.Compare((CType(x, ListViewItem)).SubItems(col).Text, (CType(y, ListViewItem)).SubItems(col).Text) = 0) Then
    '        Return String.Compare((CType(x, ListViewItem)).SubItems(0).Text, (CType(y, ListViewItem)).SubItems(0).Text)
    '    Else
    '        Return String.Compare((CType(x, ListViewItem)).SubItems(col).Text, (CType(y, ListViewItem)).SubItems(col).Text)
    '    End If
    'End Function

End Class
