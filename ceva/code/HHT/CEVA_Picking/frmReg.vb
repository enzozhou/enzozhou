Imports System.IO
Public Class frmReg
    Inherits System.Windows.Forms.Form
    Implements ResTableInterface
    Private mbSoftKeyBoardHasShowed As Boolean = False

    Private m_ResTable() As struResTable = { _
       New struResTable("Register", "14000"), _
       New struResTable("Please register first and then use this application program", "14001"), _
       New struResTable("You can get the application register code when you inform of code in the identification box to Schmidt", "14002"), _
       New struResTable("Identification code:", "14003"), _
       New struResTable("Register code:", "14004"), _
       New struResTable("Register", "14005"), _
       New struResTable("Cancel", "14006") _
       }
    Public ReadOnly Property ResTable() As struResTable() Implements ResTableInterface.ResTable
        Get
            Return m_ResTable
        End Get
    End Property
    Private Sub frmReg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Appcenter_name
        txtUuid.Text = GetUnitId()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim bFlag As Boolean = False
        'MsgBox(GetRegKey(Trim(txtUuid.Text)))
        If Trim(txtRegKey.Text) <> Trim(GetRegKey(Trim(txtUuid.Text))) Then
            MsgBox("Register code error!" & Chr(13) & Chr(10) & "Please retry", , "Register")
            txtRegKey.SelectionStart = 0
            txtRegKey.SelectionLength = Len(txtRegKey.Text)
            txtRegKey.Focus()
        Else
            bFlag = File.Exists(INSTALLED_DIR)
            If bFlag = True Then
                File.Delete(INSTALLED_DIR)
            End If
            Dim sw As StreamWriter
            sw = New StreamWriter(INSTALLED_DIR, False, System.Text.Encoding.ASCII)
            sw.WriteLine(Trim(txtRegKey.Text))

            'If btn_hide.Visible = True Then
            '    Dim ls As String = txtUuid.Text + "," + txtRegKey.Text
            '    Dim serr As String = ""
            '    MSV1.ExecuteSQL_CNT(WSSN, "insert into TMPStart(sn,regkey) values ('" + txtUuid.Text + "','" + txtRegKey.Text + "')", serr)
            '    'If serr <> "" Then
            '    '    alert(serr)
            '    'End If
            '    sw.WriteLine(ls)
            'End If

            sw.Close()
            MsgBox("Register successfully!" & Chr(13) & Chr(10) & "Thank you,PL Restart The Program！", MsgBoxStyle.Information, "Register")
            'MsgBox(LoadResStringEx(REG_MSG_REGSCC, Language), , LoadResStringEx(REG_MSG_REG, Language))
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtRegKey_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRegKey.KeyDown
        If e.KeyCode = Keys.Enter Then
            If CType(sender, Button).Text.Length > 0 Then
                Me.Focus()
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '首先设置公钥：
        Dim pk As String = APPKEY
        If pk.Length < 4 Then
            MsgBox("Public Key Must be input!", MsgBoxStyle.Exclamation, "Exclamation!")
            Return
        End If
        txtRegKey.Text = Trim(GetRegKey(Trim(txtUuid.Text)))
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hide.Click
        Dim sstr As String = txtUuid.Text.Trim
        Dim dstr As String = ""
        '倒转字符串
        For i As Integer = 1 To Len(sstr)
            dstr = Mid(sstr, i, 1) + dstr
        Next
        Dim regKey As String = Encryption64.Encrypt(dstr)
        regKey = Mid(regKey.ToUpper, 1, 8).ToUpper()
        txtRegKey.Text = regKey
        'Dim thisRegistKey As String = GetRegKey(dstr).Trim 'GetRegKey(UUid).Trim
        Dim sql As String = "insert into SYSDeviceSN(sn,key0) values ('" + sstr + "','" + regKey + "')"
        Dim sErr As String = ""
        Try
            Dim cnt As Integer = MSV1.ExecuteSQL_CNT(WSSN, sql, sErr)
        Catch ex As Exception
            alert(ex.Message)
        End Try
    End Sub

    Private Sub pb_keyBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_keyBoard.Click
        showHideKeyBoard()
    End Sub

    Private Sub frmReg_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If KeyBoardFlag Then
                SipShowIM(0)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class