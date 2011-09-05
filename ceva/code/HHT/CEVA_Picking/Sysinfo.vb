Imports Microsoft.VisualBasic
Public Class Sysinfo
    Public Sub msg(ByVal msg As String)
        'myCancer.ErrorBeepT(150)
        MsgBox(msg, MsgBoxStyle.Information & MsgBoxStyle.OkOnly, "提示：")
    End Sub
    Public Sub alert(ByVal msg As String)
        'myCancer.ErrorBeepT(500)
        MsgBox(msg, MsgBoxStyle.Exclamation & MsgBoxStyle.OkOnly, "警告！")
    End Sub

    Public Function ask(ByVal msg As String) As MsgBoxResult
        'myCancer.ErrorBeepT(300)
        Return MsgBox(msg, MsgBoxStyle.YesNo, "请注意！")
    End Function
    '检测本地程序是否注册过了。
    Public Function CheckRegister() As Boolean
        ''Return True 138 2315 5251
        ''【1】查看 INSTALLED_DIR 中文件内容，是否符合注册码
        ''不符合则弹出注册窗口。
        Try
            Dim UUid As String = GetUnitId()
            Dim thisRegistKey As String = GetRegKey(UUid).Trim 'GetRegKey(UUid).Trim
            Dim fs As System.IO.FileStream = New System.IO.FileStream(INSTALLED_DIR, IO.FileMode.OpenOrCreate)
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(fs)

            Dim RegistKey As String = sr.ReadLine()
            sr.Close()
            sr = Nothing

            'MsgBox(RegistKey & "--" & thisRegistKey)
            If RegistKey <> thisRegistKey Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            mySys.alert("注册验证失败，请联系Schmidt！")
            Return False
        End Try

    End Function
End Class
