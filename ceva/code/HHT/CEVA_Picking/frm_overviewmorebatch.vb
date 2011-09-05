Imports System.Data
Public Class frm_overviewmorebatch

    Private Sub frm_overviewmorebatch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '取可操作的批次列表 --Enzo 20110831 02:25
        Dim sErr As String = ""
        Try
            Dim ds As DataSet = MSV1.RunProcedure_DS(WSSN, "sp_hht_getavailablebatchno", "@sErr|varchar||output", sErr)
            If ds.Tables.Count > 0 Then
                For Each dr As DataRow In ds.Tables(0).Rows
                    cmbbatchno.Items.Add(dr(0))
                Next
                cmbbatchno.SelectedIndex = 0
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub get_list()
        Dim sErr As String = ""
        Try
            globalbatchno = cmbbatchno.SelectedItem.ToString()
            lv01.Items.Clear()
            Dim bin_area, bin_code_cnt As String
            ' '[sp_hht_Active_BinAreaInfo]@type,@sErr =  bin_area,bin_code_cnt
            Cursor.Current = Cursors.WaitCursor
            Dim ds As DataSet = MSV1.RunProcedure_DS(WSSN, "sp_hht_getbatchtotalinfo", "@bch_no|varchar|" + globalbatchno + "|input;@assigned_opt|varchar|" + MDI_userid + "|input", sErr)
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
                Dim binCnt As String = ds.Tables(1).Rows(0)("bin_cnt").ToString()
                ll_cnt.Text = "合计:库位数=" + binCnt
            End If

            If ds.Tables(2).Rows.Count > 0 Then
                Dim sumqty As String = ds.Tables(2).Rows(0)("sumQty").ToString()
                ll_cnt2.Text = "件数=" + sumqty
            End If
        Catch ex As Exception
            alert(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btn_pick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pick.Click
        Me.Close()
    End Sub

    Private Sub cmbbatchno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbatchno.SelectedIndexChanged
        get_list()
    End Sub
End Class