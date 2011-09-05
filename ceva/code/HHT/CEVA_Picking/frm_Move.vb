Imports System.Data

Public Class frm_Move

    '实例化一个委托对象，指向本窗口自己的处理函数
    Private thisFrom_del_CheckBarcode As del_CheckBarcode = New del_CheckBarcode(AddressOf CheckBarcode)
    ' 检验读取到的条码
    Private Sub CheckBarcode(ByVal barcode As String)
        If tb_binid.Focused Then
            tb_binid.Text = barcode
            tb_binid_KeyDown(Nothing, Nothing)
            Return
        End If
        If tb_binid1.Focused Then
            tb_binid1.Text = barcode
            tb_binid1_KeyDown(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub btn_pick_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pick.Click
        Me.Close()
    End Sub

    Private Sub frm_Move_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Appcenter_name

        '注册扫描驱动
        gf_del_CheckBarcode = [Delegate].Combine(gf_del_CheckBarcode, thisFrom_del_CheckBarcode)

        tb_binid.Focus()
        tb_binid.SelectAll()
    End Sub

    Private Sub btn_finish_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finish.Click
        Dim dc_code, assigned_opt, bin_code, bin_code1 As String
        dc_code = "SHA"
        'dn_no = tb_dn.Text.Trim
        assigned_opt = MDI_userid
        bin_code = Me.tb_binid.Text
        bin_code1 = Me.tb_binid1.Text

        'SELECT dc_code, task_id, bch_no, dn_no, assigned_opt, wh_code, bin_area, bin_code
        'FROM   tasklist
        'where dc_code= 'SHA' and dn_no = '9204314481'
        'and assigned_opt = '110'

        Try
            '[sp_hht_chg_Binid] @dc_code,@dn_no,@bin_code,@bin_code1,@sErr
            '-- [sp_hht_chg_Binid] @bch_no,@dc_code,@dn_no,@bin_code,@bin_code1,@sErr
            ' -------------------------------------------------------------------
            Dim sErr As String = ""
            Dim rlt As String = MSV1.RunProcedure_Str(WSSN, "sp_hht_chg_Binid", "@dc_code|varchar|" + dc_code + "|input;" _
                               + "@dn_no|varchar||input;" _
                               + "@bin_code|varchar|" + bin_code + "|input;" _
                               + "@bin_code1|varchar|" + bin_code1 + "|input;" _
                               + "@sErr|varchar||output", sErr)
            ' -------------------------------------------------------------------
            If sErr <> "" Then
                alert(sErr)
                Return
            End If
            If rlt = "" Then
                msg1("修改成功！")
                Me.Close()
                Return
            Else
                alert(rlt)
                Return
            End If
        Catch ex As Exception
            alert(ex.Message)
        End Try
    End Sub

    Private Sub pb_keyBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_keyBoard.Click
        showHideKeyBoard()
    End Sub

    Private Sub frm_Move_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Try
            If KeyBoardFlag Then
                SipShowIM(0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tb_dn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If IsNothing(e) Then
            GoTo enter
        End If
        If e.KeyCode = Keys.Enter Then
enter:
            tb_binid.Focus()
            tb_binid.SelectAll()
        End If
    End Sub

    Private Sub tb_binid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_binid.TextChanged
    End Sub
    Private Sub tb_binid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_binid.KeyDown
        If IsNothing(e) Then
            GoTo enter
        End If
        If e.KeyCode = Keys.Enter Then
enter:
            tb_binid1.Focus()
            tb_binid1.SelectAll()
        End If
    End Sub

    Private Sub tb_binid1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_binid1.KeyDown
        If IsNothing(e) Then
            GoTo enter
        End If
        If e.KeyCode = Keys.Enter Then
enter:
            btn_finish_Click_1(Nothing, Nothing)
        End If
    End Sub


    Private Sub frm_Move_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If KeyBoardFlag Then
                SipShowIM(0)
            End If
            gf_del_CheckBarcode = [Delegate].Remove(gf_del_CheckBarcode, thisFrom_del_CheckBarcode)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tb_binid1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_binid1.TextChanged

    End Sub
End Class