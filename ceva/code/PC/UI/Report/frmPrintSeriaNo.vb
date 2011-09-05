Imports YT
Imports YT.BusinessObject
Imports COMExpress.BusinessObject

Public Class frmPrintSeriaNo
    Inherits System.Windows.Forms.Form
    Private _ds As DS_DN
    Public Property ds() As DS_DN
        Get
            Return _ds
        End Get
        Set(ByVal value As DS_DN)
            _ds = value
            'DNPrint1.SetDataSource(_ds)
        End Set
    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SNPrint.ExportInfo(ds) '调用SNPrint 导出方法
    End Sub

    Function ConvertString(ByVal var_str As String) As String
        Return ConvertString(var_str, 42)
    End Function
    Function ConvertString(ByVal var_str As String, ByVal var_num As Integer) As String
        Dim tmp As String = Convert.ToChar(var_num).ToString()
        Return tmp + var_str + tmp
    End Function
End Class