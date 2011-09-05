Imports System.Data

Public Class frm_Query
    Public fs_type As String = "" '01,02,03

    '实例化一个委托对象，指向本窗口自己的处理函数
    Private thisFrom_del_CheckBarcode As del_CheckBarcode = New del_CheckBarcode(AddressOf CheckBarcode)
    ' 检验读取到的条码
    Private Sub CheckBarcode(ByVal barcode As String)
        If tb_dn.Focused Then
            tb_dn.Text = barcode
            get_lv1()
            tb_dn.Focus()
            tb_dn.SelectAll()
            Return
        End If
        If tb_sku.Focused Then
            tb_sku.Text = barcode
            get_lv2()
            tb_sku.Focus()
            tb_sku.SelectAll()
            Return
        End If
        If tb_bin.Focused Then
            tb_bin.Text = barcode
            get_lv3()
            tb_bin.Focus()
            tb_bin.SelectAll()
            Return
        End If
    End Sub

    Private Sub frm_Query_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        p1.Dock = DockStyle.Fill
        p2.Dock = DockStyle.Fill
        p3.Dock = DockStyle.Fill
        lv01.Items.Clear()
        lv02.Items.Clear()
        lv03.Items.Clear()
        p1.Visible = False
        p2.Visible = False
        p3.Visible = False
        p1.Location = New Point(0, 0)
        p2.Location = New Point(0, 0)
        p3.Location = New Point(0, 0)

        '注册扫描驱动
        gf_del_CheckBarcode = [Delegate].Combine(gf_del_CheckBarcode, thisFrom_del_CheckBarcode)

        If fs_type = "01" Then
            p1.Visible = True
            tb_dn.Focus()
            tb_dn.SelectAll()
        End If
        If fs_type = "02" Then
            p2.Visible = True
            tb_sku.Focus()
            tb_sku.SelectAll()
        End If
        If fs_type = "03" Then
            p3.Visible = True
            tb_bin.Focus()
            tb_bin.SelectAll()
        End If
    End Sub

    Private Sub btn_pick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pick.Click
        get_lv1()
        tb_dn.Focus()
        tb_dn.SelectAll()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        get_lv2()
        checktb_sku0() '-----Enzo   替换sku末位字母 2011090220：08
        tb_sku.Focus()
        tb_sku.SelectAll()
    End Sub
    Private Function checktb_sku0() As String
        '[sp_hht_checkBarcode] @dn_no,@sku_no,@sku_no2 output,@sErr output
        Dim sErr As String = ""
        Dim sSKU2 As String = tb_sku.Text.Trim()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim runSerr As String = MSV1.RunProcedure_Str(WSSN, "sp_hht_checkBarcode_sku", "@dn_no|varchar||input;" _
                                + "@sku_no|varchar|" + sSKU2 + "|input;" _
                                + "@sErr|varchar||output", sErr)
            Dim data2() As String = runSerr.Split("|")
            If data2.Length < 1 Then
                Return sErr
            End If
            sSKU2 = data2(0)
            sErr = data2(1)
            If sErr <> "" Then
                Return sErr
            Else
                Me.tb_sku.Text = sSKU2
                Return ""
            End If
        Catch ex As Exception
            Return ex.Message
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        get_lv3()
        tb_bin.Focus()
        tb_bin.SelectAll()
    End Sub

    Private Sub get_lv1()
        Dim sErr As String = ""
        Try
            Dim dn_no, bin_code, sku_no, qty, qty1 As String
            'sp_hht_getInfo @type,@para1,@para2,@para3,@para4,@para5,@sErr
            Cursor.Current = Cursors.WaitCursor
            Dim para1, para2, para3, para4, para5 As String
            para1 = tb_dn.Text
            para2 = MDI_userid
            para3 = ""
            para4 = ""
            para5 = ""
            Dim ds As DataSet = MSV1.RunProcedure_DS(WSSN, "sp_hht_getInfo", "@type|varchar|" + fs_type + "|input;" _
                                                    + "@para1|varchar|" + para1 + "|input;" _
                                                    + "@para2|varchar|" + para2 + "|input;" _
                                                    + "@para3|varchar|" + para3 + "|input;" _
                                                    + "@para4|varchar|" + para4 + "|input;" _
                                                    + "@para5|varchar|" + para5 + "|input;" _
                                                    + "@sErr|varchar||output", sErr)

            'Dim das() As String = sErr.Split("|")
            If sErr <> "" Then
                alert(sErr)
                Return
            End If

            ' dn_no, bin_code, sku_no
            lv01.Items.Clear()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dn_no = ds.Tables(0).Rows(i)("dn_no").ToString()
                bin_code = ds.Tables(0).Rows(i)("bin_code").ToString()
                sku_no = ds.Tables(0).Rows(i)("sku_no").ToString()
                qty = ds.Tables(0).Rows(i)("qty").ToString()
                qty1 = ds.Tables(0).Rows(i)("qty1").ToString()
                Dim lvm As ListViewItem = New ListViewItem
                lvm.Text = (lv01.Items.Count + 1).ToString()
                lvm.SubItems.Add(dn_no)
                lvm.SubItems.Add(bin_code)
                lvm.SubItems.Add(sku_no)
                qty = CType(qty, Integer).ToString()
                qty1 = CType(qty1, Integer).ToString()
                lvm.SubItems.Add(qty1 + "/" + qty)
                lv01.Items.Add(lvm)
                lv01.Refresh()
            Next
        Catch ex As Exception
            alert(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub get_lv2()
        Dim sErr As String = ""
        Try
            Dim dn_no, bin_code, sku_no, qty, qty1 As String
            'sp_hht_getInfo @type,@para1,@para2,@para3,@para4,@para5,@sErr
            Cursor.Current = Cursors.WaitCursor
            Dim para1, para2, para3, para4, para5 As String
            para1 = tb_sku.Text
            para2 = MDI_userid
            para3 = ""
            para4 = ""
            para5 = ""
            Dim ds As DataSet = MSV1.RunProcedure_DS(WSSN, "sp_hht_getInfo", "@type|varchar|" + fs_type + "|input;" _
                                                    + "@para1|varchar|" + para1 + "|input;" _
                                                    + "@para2|varchar|" + para2 + "|input;" _
                                                    + "@para3|varchar|" + para3 + "|input;" _
                                                    + "@para4|varchar|" + para4 + "|input;" _
                                                    + "@para5|varchar|" + para5 + "|input;" _
                                                    + "@sErr|varchar||output", sErr)

            'Dim das() As String = sErr.Split("|")
            If sErr <> "" Then
                alert(sErr)
                Return
            End If

            ' dn_no, bin_code, sku_no
            lv02.Items.Clear()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                dn_no = ds.Tables(0).Rows(i)("dn_no").ToString()
                bin_code = ds.Tables(0).Rows(i)("bin_code").ToString()
                sku_no = ds.Tables(0).Rows(i)("sku_no").ToString()
                qty = ds.Tables(0).Rows(i)("qty").ToString()
                qty1 = ds.Tables(0).Rows(i)("qty1").ToString()
                Dim lvm As ListViewItem = New ListViewItem
                lvm.Text = (lv02.Items.Count + 1).ToString()
                lvm.SubItems.Add(dn_no)
                lvm.SubItems.Add(bin_code)
                lvm.SubItems.Add(sku_no)
                qty = CType(qty, Integer).ToString()
                qty1 = CType(qty1, Integer).ToString()
                lvm.SubItems.Add(qty1 + "/" + qty)
                lv02.Items.Add(lvm)
                lv02.Refresh()
            Next
        Catch ex As Exception
            alert(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub get_lv3()
        Dim sErr As String = ""
        Try
            Dim dn_no, bin_code, sku_no, qty, qty1 As String
            'sp_hht_getInfo @type,@para1,@para2,@para3,@para4,@para5,@sErr
            Cursor.Current = Cursors.WaitCursor
            Dim para1, para2, para3, para4, para5 As String
            para1 = tb_bin.Text
            para2 = MDI_userid
            para3 = ""
            para4 = ""
            para5 = ""
            '--------------------------------------------------------------------
            Dim ds As DataSet = MSV1.RunProcedure_DS(WSSN, "sp_hht_getInfo", "@type|varchar|" + fs_type + "|input;" _
                                                    + "@para1|varchar|" + para1 + "|input;" _
                                                    + "@para2|varchar|" + para2 + "|input;" _
                                                    + "@para3|varchar|" + para3 + "|input;" _
                                                    + "@para4|varchar|" + para4 + "|input;" _
                                                    + "@para5|varchar|" + para5 + "|input;" _
                                                    + "@sErr|varchar||output", sErr)
            '--------------------------------------------------------------------
            'Dim das() As String = sErr.Split("|")
            If sErr <> "" Then
                alert(sErr)
                Return
            End If

            ' dn_no, bin_code, sku_no
            lv03.Items.Clear()
            If ds.Tables.Count = 0 Then
                alert("没有数据")
            ElseIf ds.Tables(0).Columns.Count = 0 Then
                alert("没有数据")
            Else
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    dn_no = ds.Tables(0).Rows(i)("dn_no").ToString()
                    bin_code = ds.Tables(0).Rows(i)("bin_code").ToString()
                    sku_no = ds.Tables(0).Rows(i)("sku_no").ToString()
                    qty = ds.Tables(0).Rows(i)("qty").ToString()
                    qty1 = ds.Tables(0).Rows(i)("qty1").ToString()
                    Dim lvm As ListViewItem = New ListViewItem
                    lvm.Text = (lv03.Items.Count + 1).ToString()
                    lvm.SubItems.Add(dn_no)
                    lvm.SubItems.Add(bin_code)
                    lvm.SubItems.Add(sku_no)
                    qty = CType(qty, Integer).ToString()
                    qty1 = CType(qty1, Integer).ToString()
                    lvm.SubItems.Add(qty1 + "/" + qty)
                    lv03.Items.Add(lvm)
                    lv03.Refresh()
                Next
            End If
        Catch ex As Exception
            alert(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btn_rtn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rtn0.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub tb_dn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_dn.KeyDown
        If IsNothing(e) Then
            GoTo enter
        End If
        If e.KeyCode = Keys.Enter Then
enter:
            btn_pick_Click(Nothing, Nothing)
            Return
        End If
    End Sub

    Private Sub tb_sku_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_sku.KeyDown
        If IsNothing(e) Then
            GoTo enter
        End If
        If e.KeyCode = Keys.Enter Then
enter:
            Button1_Click(Nothing, Nothing)
            Return
        End If

    End Sub

    Private Sub tb_bin_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_bin.KeyDown
        If IsNothing(e) Then
            GoTo enter
        End If
        If e.KeyCode = Keys.Enter Then
enter:
            Button3_Click(Nothing, Nothing)
            Return
        End If
    End Sub


    Private Sub pb_keyBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_keyBoard.Click, PictureBox2.Click, PictureBox1.Click
        showHideKeyBoard()
    End Sub

    Private Sub frm_Query_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed

    End Sub

    Private Sub frm_Query_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If KeyBoardFlag Then
                SipShowIM(0)
            End If
            gf_del_CheckBarcode = [Delegate].Remove(gf_del_CheckBarcode, thisFrom_del_CheckBarcode)
        Catch ex As Exception
        End Try
    End Sub
End Class