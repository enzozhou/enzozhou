Imports System.Data

Public Class frm_overView

    Private Sub p1_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles p1.GotFocus
    End Sub
    Private Sub frm_overView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '[sp_hht_Active_BinAreaInfo]@type,@sErr =  bin_area,bin_code_cnt
        ll_cnt.Text = ""
        ll_cnt2.Text = ""
        get_list()
        btn_pick.Focus()
    End Sub

    Private Sub btn_pick_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pick.Click
        Me.Close()
    End Sub

    Private Sub get_list()
        Dim sErr As String = ""
        Try
            lv01.Items.Clear()
            Dim bin_area, bin_code_cnt As String
            ' '[sp_hht_Active_BinAreaInfo]@type,@sErr =  bin_area,bin_code_cnt
            Cursor.Current = Cursors.WaitCursor
            Dim ds As DataSet = MSV1.RunProcedure_DS(WSSN, "sp_hht_Active_BinAreaInfo", "@type|varchar||input;" _
                                                    + "@assigned_opt|varchar|" + MDI_userid + "|input;" _
                                                    + "@sErr|varchar||output", sErr)
            If sErr <> "" Then
                alert(sErr)
                Return
            End If
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                bin_area = ds.Tables(0).Rows(i)("bin_area").ToString()
                bin_code_cnt = ds.Tables(0).Rows(i)("bin_code_cnt").ToString()
                Dim lvm As ListViewItem = New ListViewItem
                lvm.Text = (lv01.Items.Count + 1).ToString()
                lvm.SubItems.Add(bin_area)
                lvm.SubItems.Add(bin_code_cnt)
                lv01.Items.Add(lvm)
                lv01.Refresh()
            Next
            If ds.Tables(1).Rows.Count > 0 Then
                tb_lot.Text = ds.Tables(1).Rows(0)("bch_no").ToString()
            End If

            If ds.Tables(2).Rows.Count > 0 Then
                Dim binCnt As String = ds.Tables(2).Rows(0)("bin_cnt").ToString()
                ll_cnt.Text = "合计:库位数=" + binCnt
            End If

            If ds.Tables(3).Rows.Count > 0 Then
                Dim sumqty As String = ds.Tables(3).Rows(0)("sumQty").ToString()
                ll_cnt2.Text = "件数=" + sumqty
            End If
        Catch ex As Exception
            alert(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btn_pick_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btn_pick.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.Close()
        End If
    End Sub
End Class