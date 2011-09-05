Module ReportPublic

    Public Function GetPrinterSettingByDialog(ByRef objPrinterSettings As System.Drawing.Printing.PrinterSettings, Optional ByVal PrinterName As String = "") As Boolean
        Dim dialog As New PrintDialog
        If PrinterName <> "" Then
            dialog.PrinterSettings.PrinterName = PrinterName
        End If

        If dialog.ShowDialog(MainForm) <> DialogResult.OK Then
            Return False
        End If
        objPrinterSettings = dialog.PrinterSettings
        Return True
    End Function

End Module
