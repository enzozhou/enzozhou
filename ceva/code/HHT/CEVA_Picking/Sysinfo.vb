Imports Microsoft.VisualBasic
Public Class Sysinfo
    Public Sub msg(ByVal msg As String)
        'myCancer.ErrorBeepT(150)
        MsgBox(msg, MsgBoxStyle.Information & MsgBoxStyle.OkOnly, "��ʾ��")
    End Sub
    Public Sub alert(ByVal msg As String)
        'myCancer.ErrorBeepT(500)
        MsgBox(msg, MsgBoxStyle.Exclamation & MsgBoxStyle.OkOnly, "���棡")
    End Sub

    Public Function ask(ByVal msg As String) As MsgBoxResult
        'myCancer.ErrorBeepT(300)
        Return MsgBox(msg, MsgBoxStyle.YesNo, "��ע�⣡")
    End Function
    '��Ȿ�س����Ƿ�ע����ˡ�
    Public Function CheckRegister() As Boolean
        ''Return True 138 2315 5251
        ''��1���鿴 INSTALLED_DIR ���ļ����ݣ��Ƿ����ע����
        ''�������򵯳�ע�ᴰ�ڡ�
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
            mySys.alert("ע����֤ʧ�ܣ�����ϵSchmidt��")
            Return False
        End Try

    End Function
End Class
