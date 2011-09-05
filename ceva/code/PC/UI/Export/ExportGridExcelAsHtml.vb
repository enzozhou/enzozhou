Option Explicit On 
Option Strict On
Imports COMExpress.UserInterface.Layout
Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports Janus.Windows.GridEX
Imports System.ComponentModel
Imports YT.BusinessObject
Imports System.Text.RegularExpressions
Imports ImportExport
Imports ImportExport.Office

Public Class ExportGridExcelAsHtml

    Private mobjApp As IWindowsAppManager = [Global].MainForm

    Private Function GetObjectName(ByVal dg As DataGrid) As String
        Return CType(dg.DataSource, ICXBusinessCollectionBase).BusinessType.Name
    End Function

    Private Function ExportHeader(ByVal sw As System.IO.StreamWriter, ByVal SheetName As String) As Boolean
        Dim strheader As String
        strheader = "<html xmlns:o='urn:schemas-microsoft-com:office:office'" + vbCrLf + _
            "xmlns:x='urn:schemas-microsoft-com:office:excel'" + vbCrLf + _
            "xmlns='http://www.w3.org/TR/REC-html40'>" + vbCrLf + _
            "" + vbCrLf + _
            "<head>" + vbCrLf + _
            "<meta http-equiv=Content-Type content='text/html; charset=GB2312'>" + vbCrLf + _
            "<meta name=ProgId content=Excel.Sheet>" + vbCrLf + _
            "<meta name=Generator content='Microsoft Excel 9'>" + vbCrLf + _
            "<!--[if gte mso 9]><xml>" + vbCrLf + _
            " <o:DocumentProperties>" + vbCrLf + _
            "  <o:LastAuthor>lfish</o:LastAuthor>" + vbCrLf + _
            "  <o:Created>2008-01-07T02:58:08Z</o:Created>" + vbCrLf + _
            "  <o:LastSaved>2008-01-07T02:58:08Z</o:LastSaved>" + vbCrLf + _
            "  <o:Version>9.3821</o:Version>" + vbCrLf + _
            " </o:DocumentProperties>" + vbCrLf + _
            " <o:OfficeDocumentSettings>" + vbCrLf + _
            "  <o:DownloadComponents/>" + vbCrLf + _
            "  <o:LocationOfComponents HRef='file:F:\msowc.cab'/>" + vbCrLf + _
            " </o:OfficeDocumentSettings>" + vbCrLf + _
            "</xml><![endif]-->" + vbCrLf + _
            "<style>" + vbCrLf + _
            "<!--table" + vbCrLf + _
            "	{mso-displayed-decimal-separator:'\.';" + vbCrLf + _
            "	mso-displayed-thousand-separator:'\,';}" + vbCrLf + _
            "@page" + vbCrLf + _
            "	{margin:1.0in .75in 1.0in .75in;" + vbCrLf + _
            "	mso-header-margin:.5in;" + vbCrLf + _
            "	mso-footer-margin:.5in;}" + vbCrLf + _
            "tr" + vbCrLf + _
            "	{mso-height-source:auto;" + vbCrLf + _
            "	mso-ruby-visibility:none;}" + vbCrLf + _
            "col" + vbCrLf + _
            "	{mso-width-source:auto;" + vbCrLf + _
            "	mso-ruby-visibility:none;}" + vbCrLf + _
            "br" + vbCrLf + _
            "	{mso-data-placement:same-cell;}" + vbCrLf + _
            ".style0" + vbCrLf + _
            "	{mso-number-format:General;" + vbCrLf + _
            "	text-align:general;" + vbCrLf + _
            "	vertical-align:bottom;" + vbCrLf + _
            "	white-space:nowrap;" + vbCrLf + _
            "	mso-rotate:0;" + vbCrLf + _
            "	mso-background-source:auto;" + vbCrLf + _
            "	mso-pattern:auto;" + vbCrLf + _
            "	color:windowtext;" + vbCrLf + _
            "	font-size:12.0pt;" + vbCrLf + _
            "	font-weight:400;" + vbCrLf + _
            "	font-style:normal;" + vbCrLf + _
            "	text-decoration:none;" + vbCrLf + _
            "	font-family:宋体;" + vbCrLf + _
            "	mso-generic-font-family:auto;" + vbCrLf + _
            "	mso-font-charset:134;" + vbCrLf + _
            "	border:none;" + vbCrLf + _
            "	mso-protection:locked visible;" + vbCrLf + _
            "	mso-style-name:Normal;" + vbCrLf + _
            "	mso-style-id:0;}" + vbCrLf + _
            "td" + vbCrLf + _
            "	{mso-style-parent:style0;" + vbCrLf + _
            "	padding-top:1px;" + vbCrLf + _
            "	padding-right:1px;" + vbCrLf + _
            "	padding-left:1px;" + vbCrLf + _
            "	mso-ignore:padding;" + vbCrLf + _
            "	color:windowtext;" + vbCrLf + _
            "	font-size:12.0pt;" + vbCrLf + _
            "	font-weight:400;" + vbCrLf + _
            "	font-style:normal;" + vbCrLf + _
            "	text-decoration:none;" + vbCrLf + _
            "	font-family:宋体;" + vbCrLf + _
            "	mso-generic-font-family:auto;" + vbCrLf + _
            "	mso-font-charset:134;" + vbCrLf + _
            "	mso-number-format:General;" + vbCrLf + _
            "	text-align:general;" + vbCrLf + _
            "	vertical-align:bottom;" + vbCrLf + _
            "	border:none;" + vbCrLf + _
            "	mso-background-source:auto;" + vbCrLf + _
            "	mso-pattern:auto;" + vbCrLf + _
            "	mso-protection:locked visible;" + vbCrLf + _
            "	white-space:nowrap;" + vbCrLf + _
            "	mso-rotate:0;}" + vbCrLf + _
            ".xl19" + vbCrLf + _
            "	{mso-style-parent:style0;" + vbCrLf + _
            "	font-family:'Times New Roman', serif;" + vbCrLf + _
            "	mso-font-charset:0;}" + vbCrLf + _
            "ruby" + vbCrLf + _
            "	{ruby-align:left;}" + vbCrLf + _
            "rt" + vbCrLf + _
            "	{color:windowtext;" + vbCrLf + _
            "	font-size:9.0pt;" + vbCrLf + _
            "	font-weight:400;" + vbCrLf + _
            "	font-style:normal;" + vbCrLf + _
            "	text-decoration:none;" + vbCrLf + _
            "	font-family:宋体;" + vbCrLf + _
            "	mso-generic-font-family:auto;" + vbCrLf + _
            "	mso-font-charset:134;" + vbCrLf + _
            "	mso-char-type:none;" + vbCrLf + _
            "	display:none;}" + vbCrLf + _
            "-->" + vbCrLf + _
            "</style>" + vbCrLf + _
            "<!--[if gte mso 9]><xml>" + vbCrLf + _
            " <x:ExcelWorkbook>" + vbCrLf + _
            "  <x:ExcelWorksheets>" + vbCrLf + _
            "   <x:ExcelWorksheet>" + vbCrLf + _
            "    <x:Name>" + Trim(SheetName) + "</x:Name>" + vbCrLf + _
            "    <x:WorksheetOptions>" + vbCrLf + _
            "     <x:DefaultRowHeight>285</x:DefaultRowHeight>" + vbCrLf + _
            "     <x:Selected/>" + vbCrLf + _
            "     <x:Panes>" + vbCrLf + _
            "      <x:Pane>" + vbCrLf + _
            "       <x:Number>3</x:Number>" + vbCrLf + _
            "       <x:ActiveRow>2</x:ActiveRow>" + vbCrLf + _
            "       <x:ActiveCol>2</x:ActiveCol>" + vbCrLf + _
            "      </x:Pane>" + vbCrLf + _
            "     </x:Panes>" + vbCrLf + _
            "     <x:ProtectContents>False</x:ProtectContents>" + vbCrLf + _
            "     <x:ProtectObjects>False</x:ProtectObjects>" + vbCrLf + _
            "     <x:ProtectScenarios>False</x:ProtectScenarios>" + vbCrLf + _
            "    </x:WorksheetOptions>" + vbCrLf + _
            "   </x:ExcelWorksheet>" + vbCrLf + _
            "  </x:ExcelWorksheets>" + vbCrLf + _
            "  <x:WindowHeight>8445</x:WindowHeight>" + vbCrLf + _
            "  <x:WindowWidth>14955</x:WindowWidth>" + vbCrLf + _
            "  <x:WindowTopX>120</x:WindowTopX>" + vbCrLf + _
            "  <x:WindowTopY>45</x:WindowTopY>" + vbCrLf + _
            "  <x:ProtectStructure>False</x:ProtectStructure>" + vbCrLf + _
            "  <x:ProtectWindows>False</x:ProtectWindows>" + vbCrLf + _
            " </x:ExcelWorkbook>" + vbCrLf + _
            "</xml><![endif]-->" + vbCrLf + _
            "</head>" + vbCrLf

        Try
            sw.Write(strheader)
            Return True
        Catch ex As Exception
        End Try
        Return False

    End Function

    Public Function Export(ByVal dg As DataGrid, ByRef vFile As String, Optional ByVal vFormat As String = "XLS") As Boolean
        Try
            Dim strEx As String
            Dim strOut As String
            Dim fs As System.IO.FileStream
            Dim sw As System.IO.StreamWriter
            strEx = UCase(Microsoft.VisualBasic.Right(Trim(vFile), 3))
            If strEx <> UCase(vFormat) Then
                vFile = vFile + "." + vFormat
            End If
            fs = New System.IO.FileStream(vFile, IO.FileMode.Create)
            sw = New System.IO.StreamWriter(fs, System.Text.Encoding.Unicode)
            ExportHeader(sw, dg.RootTable.Caption)

            strOut = vbCrLf + "<body link=blue vlink=purple>"
            sw.WriteLine(strOut)
            strOut = "<table x:str border=0 cellpadding=0 cellspacing=0 width=216 style='border-collapse:collapse;table-layout:fixed;width:162pt'>"
            sw.WriteLine(strOut)
            ExportColumns(dg, sw)

            ExportBody(dg, sw)

            strOut = "</table>"
            sw.WriteLine(strOut)
            strOut = "</body>"
            sw.WriteLine(strOut)
            strOut = "</html>"
            sw.WriteLine(strOut)

            sw.Close()
            fs.Close()
        Catch ex As Exception
            ErrorMsg(ex, Me.GetType, "Export")
        End Try


    End Function

    Private Function GetColumnList(ByVal dg As DataGrid, ByVal objBO As CXObjectLay) As CXColumnList
        Dim currentType As Type = CType(dg.DataSource, ICXBusinessCollectionBase).BusinessType
        Dim containerType As Type
        If TypeOf dg.GetContainerForm() Is CXWinFormBase Then
            containerType = CType(dg.GetContainerForm.DataSource, ICXBusinessCollectionBase).BusinessType
        Else
            containerType = currentType
        End If
        'Dim objBO As CXObjectLay = mobjApp.GetLayout.CXObjectLays.Item(currentType.Name)
        Dim strColumnList As String


        If currentType Is containerType Then
            strColumnList = currentType.Name & "_List__"
        Else
            strColumnList = currentType.Name & "_" & containerType.Name
        End If

        Return objBO.ColumnLists.Item(strColumnList)
    End Function

    Private Function ExportColumns(ByVal dg As DataGrid, ByVal sw As System.IO.StreamWriter) As Boolean
        Dim i As Integer
        Dim str As String
        Dim strOut As String
        strOut = "<tr>"
        sw.WriteLine(strOut)
        strOut = ""
        Dim objColList As CXColumnList
        Dim objBO As CXObjectLay = CType(mobjApp.GetLayout.CXObjectLays.Item(GetObjectName(dg)), CXObjectLay)
        objColList = GetColumnList(dg, objBO)
        'For i = 0 To RootTable.Columns.Count - 1
        Dim objFieldCol As CXField
        Dim objGridCol As GridEXColumn
        For i = 0 To objColList.FieldColumns.Count - 1
            Try
                objFieldCol = objColList.FieldColumns(i)
                objGridCol = dg.RootTable.Columns(objFieldCol.FieldName)
                If objGridCol.Visible = True Then
                    strOut = strOut + "<td " + GetColumnStyle(objGridCol) + ">" + objGridCol.Caption + "</td>"
                End If
            Catch ex As Exception
            End Try
        Next

        sw.WriteLine(strOut)
        strOut = "</tr>"
        sw.WriteLine(strOut)
    End Function

    'Private Structure ColumnsStructure
    '    Public ColumnName As String
    '    Public Visible As Boolean
    'End Structure
    Private mColumns() As GridEXColumn

    Private Sub BuildColumentTable(ByVal dg As DataGrid)

        Dim objColList As CXColumnList
        Dim objBO As CXObjectLay = CType(mobjApp.GetLayout.CXObjectLays.Item(GetObjectName(dg)), CXObjectLay)
        Dim i As Integer
        Dim objFieldCol As CXField
        Dim objGridCol As GridEXColumn

        '输出是按ColumnList的顺序列出的.
        objColList = GetColumnList(dg, objBO)
        ReDim mColumns(objColList.FieldColumns.Count)  'as ColumnsStructure

        For i = 0 To objColList.FieldColumns.Count - 1
            Try
                objFieldCol = objColList.FieldColumns(i)
                objGridCol = dg.RootTable.Columns(objFieldCol.FieldName)
                'Dim strColName As String = objGridCol.Key
                'mCols.Add(i.ToString, objGridCol.Key)
                'mCols.Add(i.ToString, objGridCol.Key)
                'mColumns(i).Visible = objGridCol.Visible
                'mColumns(i).ColumnName = objGridCol.Key
                mColumns(i) = objGridCol
            Catch ex As Exception
            End Try
        Next

    End Sub

    Private Function GetColumnStyle(ByVal objCol As GridEXColumn) As String
        Select Case objCol.TextAlignment
            Case TextAlignment.Empty
                Return " "
            Case TextAlignment.Center
                Return "style='text-align:center' "
            Case TextAlignment.Far
                Return "style='text-align:right' "
            Case TextAlignment.Near
                Return "style='text-align:left' "
        End Select
    End Function

    Private Function ExportBody(ByVal dg As DataGrid, ByVal sw As System.IO.StreamWriter) As Boolean
        Dim i, j As Integer
        Dim str As String
        Dim strOut As String
        Dim objColList As CXColumnList
        Dim objBO As CXObjectLay = CType(mobjApp.GetLayout.CXObjectLays.Item(GetObjectName(dg)), CXObjectLay)
        objColList = GetColumnList(dg, objBO)
        Dim objFieldCol As CXField
        Dim objGridCol As GridEXColumn

        BuildColumentTable(dg)

        For j = 0 To dg.RowCount - 1
            Dim row As GridEXRow
            Dim iCount As Integer
            row = dg.GetRows(j)
            strOut = "<tr>"
            sw.WriteLine(strOut)
            strOut = ""
            'For i = 0 To RootTable.Columns.Count - 1
            iCount = objColList.FieldColumns.Count
            For i = 0 To iCount - 1
                Try
                    'objFieldCol = objColList.FieldColumns(i)
                    'objGridCol = dg.RootTable.Columns(objFieldCol.FieldName)
                    ''strOut = strOut + "<td>" + objGridCol.Caption + "</td>"
                    'Dim strColName As String '= objGridCol.Key
                    'objGridCol.a
                    'strColName.
                    If mColumns(i).Visible = True Then
                        strOut = strOut + "<td " + GetColumnStyle(mColumns(i)) + ">" + CType(row.Cells(mColumns(i).Key).Text, String) + "</td>"
                    End If
                Catch ex As Exception
                End Try
            Next

            sw.WriteLine(strOut)
            strOut = "</tr>"
            sw.WriteLine(strOut)
        Next
    End Function

    Public Sub SaveAsExcelFormat(ByVal sFile As String, ByVal excelFile As String)
        Dim obj As New ExcelFile
        obj.OpenWorkBook(sFile)
        obj.SaveWorkBook(excelFile)
        obj.CloseWorkBook()
        obj.CloseExcelApplication()
        obj = Nothing
    End Sub

End Class
