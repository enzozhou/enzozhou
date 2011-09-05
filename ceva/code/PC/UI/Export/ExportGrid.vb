Imports System.Data


Class ExportGrid
    Public Shared Sub ExportGridExcelByHtml(ByVal dg As DataGrid, ByVal strFile As String)
        Dim obj As New ExportGridExcelAsHtml
        Try
            Dim sTemp As String
            sTemp = System.IO.Path.GetTempFileName
            obj.Export(dg, sTemp)
            obj.SaveAsExcelFormat(sTemp, strFile)
            Try
                System.IO.File.Delete(sTemp)
            Catch ex As Exception
            End Try
        Catch ex As Exception
        End Try
        obj = Nothing
    End Sub


    Public Shared Sub ExportGridExcelDirect(ByVal dg As DataGrid, ByVal strFile As String)
        Dim obj As New ExportGridExcel
        obj.Export(dg, strFile)
    End Sub

    Public Shared Sub ExportGridExcelByXML(ByVal dg As DataGrid, ByVal strFile As String)
        Dim obj As New ExportGridExcelAsXML
        obj.Export(dg, strFile)
        Dim a = SqlDbType.BigInt
    End Sub


End Class
