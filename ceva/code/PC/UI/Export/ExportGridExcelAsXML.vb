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

Public Class ExportGridExcelAsXML

    'Only support Excel 2003, open xml formal excel file by excel2000, the format will be convert into html and the format is not excepted. 
    Private mobjApp As IWindowsAppManager = [Global].MainForm

    Private Function GetObjectName(ByVal dg As DataGrid) As String
        Return CType(dg.DataSource, ICXBusinessCollectionBase).BusinessType.Name
    End Function

    Private Function ExportHeader(ByVal sw As System.IO.StreamWriter, ByVal SheetName As String) As Boolean
        Dim strheader As String
        strheader = "<?xml version=""1.0""?>" + vbCrLf + "<?mso-application progid=""Excel.Sheet""?>" + _
    "<Workbook xmlns=""urn:schemas-microsoft-com:office:spreadsheet"" xmlns:o=""urn:schemas-microsoft-com:office:office"" " + _
    "xmlns:x=""urn:schemas-microsoft-com:office:excel"" xmlns:ss=""urn:schemas-microsoft-com:office:spreadsheet"" " + _
    "xmlns:html=""http://www.w3.org/TR/REC-html40"">" + vbCrLf + " <Styles> <Style ss:ID=""Default"" ss:Name=""Normal"">" + _
    "<Alignment ss:Vertical=""Bottom""/> <Borders/> <Font/> <Interior/> <NumberFormat/> <Protection/> </Style>" + _
    "<Style ss:ID=""s21""> <NumberFormat ss:Format=""@""/> </Style> </Styles>" + vbCrLf + " <Worksheet ss:Name=""" + SheetName + """>" + _
    "<Table> <Column ss:StyleID=""s21""/>"

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
            sw = New System.IO.StreamWriter(fs, System.Text.Encoding.UTF8)
            ExportHeader(sw, dg.RootTable.Caption)


            ExportColumns(dg, sw)
            ExportBody(dg, sw)

            strOut = "</Table></Worksheet></Workbook>"
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
        strOut = "<Row>"
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
                    'strOut = strOut + "<td " + GetColumnStyle(objGridCol) + ">" + objGridCol.Caption + "</td>"
                    strOut = strOut + "<Cell><Data ss:Type=""String"">" + objGridCol.Caption + "</Data></Cell>"
                End If
            Catch ex As Exception
            End Try
        Next

        sw.WriteLine(strOut)
        strOut = "</Row>"
        sw.WriteLine(strOut)
    End Function

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

        For j = 0 To dg.RowCount - 1
            Dim row As GridEXRow
            row = dg.GetRows(j)
            strOut = "<Row>"
            sw.WriteLine(strOut)
            strOut = ""
            'For i = 0 To RootTable.Columns.Count - 1
            For i = 0 To objColList.FieldColumns.Count - 1
                Try
                    objFieldCol = objColList.FieldColumns(i)
                    objGridCol = dg.RootTable.Columns(objFieldCol.FieldName)
                    'strOut = strOut + "<td>" + objGridCol.Caption + "</td>"
                    Dim strColName As String = objGridCol.Key
                    'objGridCol.a
                    If objGridCol.Visible = True Then
                        'strOut = strOut + "<td " + GetColumnStyle(objGridCol) + ">" + CType(row.Cells(strColName).Text, String) + "</td>"
                        strOut = strOut + "<Cell><Data ss:Type=""String"">" + CType(row.Cells(strColName).Text, String) + "</Data></Cell>"
                    End If
                Catch ex As Exception
                End Try
            Next

            sw.WriteLine(strOut)
            strOut = "</Row>"
            sw.WriteLine(strOut)
        Next
    End Function
End Class
