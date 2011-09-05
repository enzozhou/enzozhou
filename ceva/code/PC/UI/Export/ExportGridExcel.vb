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


Public Class ExportGridExcel

    Private mobjApp As IWindowsAppManager = [Global].MainForm
    Private eFile As New ExcelFile


    Private Function GetObjectName(ByVal dg As DataGrid) As String
        Return CType(dg.DataSource, ICXBusinessCollectionBase).BusinessType.Name
    End Function

    Private Function ExportHeader(ByVal sName As String, ByVal SheetName As String) As Boolean
        eFile.NewWorkBook()
        eFile.SaveWorkBook(sName)
        eFile.SelectWorkSheet(1)
        eFile.SetWorkSheetName(SheetName)
    End Function

    Public Function Export(ByVal dg As DataGrid, ByVal vFile As String, Optional ByVal vFormat As String = "XLS") As Boolean
        Try
            Dim strEx As String
            'Dim strOut As String

            strEx = UCase(Microsoft.VisualBasic.Right(Trim(vFile), 3))
            If strEx <> UCase(vFormat) Then
                vFile = vFile + "." + vFormat
            End If

            ExportHeader(vFile, dg.RootTable.Caption)

            ExportColumns(dg)
            ExportBody(dg)
            eFile.SaveWorkBook()
            eFile.CloseWorkBook()
            eFile.CloseExcelApplication()
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

    Private Function ExportColumns(ByVal dg As DataGrid) As Boolean
        Dim i As Integer
        Dim str As String
        Dim strOut As String
        Dim col As Integer

        Dim objColList As CXColumnList
        Dim objBO As CXObjectLay = CType(mobjApp.GetLayout.CXObjectLays.Item(GetObjectName(dg)), CXObjectLay)
        objColList = GetColumnList(dg, objBO)
        'For i = 0 To RootTable.Columns.Count - 1
        Dim objFieldCol As CXField
        Dim objGridCol As GridEXColumn
        col = 1
        For i = 0 To objColList.FieldColumns.Count - 1
            Try

                objFieldCol = objColList.FieldColumns(i)
                objGridCol = dg.RootTable.Columns(objFieldCol.FieldName)
                If objGridCol.Visible = True Then
                    eFile.SheetWrite(col, 1, objGridCol.Caption)
                col = col + 1
                End If
            Catch ex As Exception

            End Try

        Next

    End Function



    Private Function ExportBody(ByVal dg As DataGrid) As Boolean
        Dim i, j As Integer
        Dim col As Integer
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
            col = 1
            For i = 0 To objColList.FieldColumns.Count - 1
                Try
                    objFieldCol = objColList.FieldColumns(i)
                    objGridCol = dg.RootTable.Columns(objFieldCol.FieldName)
                    Dim strColName As String = objGridCol.Key
                    If objGridCol.Visible = True Then
                        eFile.SheetWrite(col, j + 1 + 1, CType(row.Cells(strColName).Text, String))
                        col = col + 1
                    End If
                Catch ex As Exception
                End Try
            Next

        Next
    End Function
End Class
