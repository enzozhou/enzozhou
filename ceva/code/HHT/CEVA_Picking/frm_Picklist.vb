Imports System.Data

Public Class frm_Picklist

    '实例化一个委托对象，指向本窗口自己的处理函数
    Private thisFrom_del_CheckBarcode As del_CheckBarcode = New del_CheckBarcode(AddressOf CheckBarcode)
    ' 检验读取到的条码
    Private Sub CheckBarcode(ByVal barcode As String)
        Dim ls_barcode As String = barcode
        If tb_sku0.Focused() Then
            tb_sku0.Text = barcode
            tb_sku0_KeyDown(Nothing, Nothing)
            Return
        End If

        If tb_sku2.Focused Then
            tb_sku2.Text = barcode
            tb_sku_KeyDown(Nothing, Nothing)
            Return
        End If

        If tb_sno.Focused Then
            tb_sno.Text = barcode
            tb_sno_KeyDown(Nothing, Nothing)
            Return
        End If

        If tb_binOK.Focused Then
            tb_binOK.Text = barcode
            Confirm_Binid()
            Return
        End If

    End Sub

    Enum OPMODEL
        ADD = 1
        DELETE = 2
    End Enum
    Dim current_model As OPMODEL = OPMODEL.ADD
    Public Declare Sub keybd_event Lib "Coredll.dll" Alias "keybd_event" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Private Sub txtTab2Enter_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If (e.KeyChar = vbCr) Then
            If (CType(sender, TextBox).Text.Trim <> "") Then
                keybd_event(9, 0, 0, 0)
                'TAB. KeyCode:9
            Else
                CType(sender, TextBox).Focus()
            End If
        End If
    End Sub

    Private Sub frm_Picklist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '注册扫描驱动
        gf_del_CheckBarcode = [Delegate].Combine(gf_del_CheckBarcode, thisFrom_del_CheckBarcode)

        Me.Text = Appcenter_name
        Me.WindowState = FormWindowState.Maximized
        p0.Dock = DockStyle.Fill
        p1.Dock = DockStyle.Fill

        p0.Location = New Point(0, 0)
        p1.Location = New Point(0, 0)
        p0.Visible = True
        p1.Visible = False
        ll_qtySum.Text = ""

        'Dim fm As frm_overView = New frm_overView()
        Dim fm As frm_overviewmorebatch = New frm_overviewmorebatch()
        fm.ShowDialog()

        lv_tasklist.Items.Clear()
        tb_sku0.Focus()
        'btn_refresh0_Click(Nothing, Nothing)

    End Sub

    Private Sub btn_finish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ls_lot As String = ""
        If ask("批次：" + "" + " ，全部拣货完成，" + vbCrLf + "是否确认？") = MsgBoxResult.Yes Then
        Else
            Return
        End If
    End Sub

    ''' <summary>
    ''' 按照选定行进行删除...
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_model_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If current_model = OPMODEL.ADD Then
        '    current_model = OPMODEL.DELETE
        '    btn_model.Text = "[删除]"
        'ElseIf current_model = OPMODEL.DELETE Then
        '    current_model = OPMODEL.ADD
        '    btn_model.Text = "[增加]"
        'End If
    End Sub

    Private Sub btn_rtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rtn.Click
        If lv_scan.Items.Count > 0 Then
            If ask("不确认库位，直接返回? " + vbCrLf + "按『是』会清除当前扫描记录，请确认!") = MsgBoxResult.Yes Then
                '删除...
                binDeleteConfirm()
                btn_refresh0_Click(Nothing, Nothing)
                p1.Visible = False
                p0.Visible = True
                tb_sku0.Focus()
                tb_sku0.SelectAll()
            End If
            Return
        Else
            Me.Close()
        End If
    End Sub

    Private Sub tb_sku_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_sku2.TextChanged
    End Sub
    ''' <summary>
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tb_sku_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_sku2.KeyDown
        If IsNothing(e) Then
            GoTo enter
        End If

        If e.KeyCode = Keys.Enter Then
enter:      Dim sku2 As String = ""
            sku2 = tb_sku2.Text.Trim
            If sku2 = "" Then
                ll_info.Visible = True
                alert("请扫描或者输入物品条码!")
                tb_sku2.Focus()
                Return
            Else
                ' 检查sku是否正确？
                Dim runSerr As String = checkSKU(sku2)
                If runSerr <> "" Then
                    alert(runSerr)
                    tb_sku2.Focus()
                    tb_sku2.SelectAll()
                    Return
                End If
                '--''如果扫描的是UPC,则无法匹配::这里去掉比对情况:
                'If sku2 <> tb_sku0.Text.Trim() Then
                '    alert("物品条码错误!")
                '    tb_sku2.Focus()
                '    tb_sku2.SelectAll()
                '    Return
                'End If
            End If
            '正确则继续............
            add_scan_sku() '--Enzo 20110824   每扫描sku一次记录一次 具体参看 CEVA - Change Request Lists(20110819) .xls
            'tb_sno.Text = ""
            'tb_sno.Focus()
            'tb_sku2.Text = ""
            'tb_sku2.Focus()
            Return
        End If
        If Not IsNothing(e) Then
            If e.KeyCode = Keys.Down Then
                'tb_sno.Focus()
                'tb_sno.SelectAll()
            End If
        End If
    End Sub

    Private Function checkSKU(ByRef sSKU As String) As String
        '[sp_hht_checkBarcode] @dn_no,@sku_no,@sku_no2 output,@sErr output
        Dim sErr As String = ""
        Dim sSKU2 As String = ""
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim runSerr As String = MSV1.RunProcedure_Str(WSSN, "sp_hht_checkBarcode_sku", "@dn_no|varchar||input;" _
                                + "@sku_no|varchar|" + sSKU + "|input;" _
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
                Me.tb_sku2.Text = sSKU2
                Return ""
            End If
        Catch ex As Exception
            Return ex.Message
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function
    Private Function checktb_sku0(ByRef sSKU As String) As String
        '[sp_hht_checkBarcode] @dn_no,@sku_no,@sku_no2 output,@sErr output
        Dim sErr As String = ""
        Dim sSKU2 As String = ""
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim runSerr As String = MSV1.RunProcedure_Str(WSSN, "sp_hht_checkBarcode_sku", "@dn_no|varchar||input;" _
                                + "@sku_no|varchar|" + sSKU + "|input;" _
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
                Me.tb_sku0.Text = sSKU2
                Return ""
            End If
        Catch ex As Exception
            Return ex.Message
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function
    ''' <summary>
    ''' 得到物品的扫描清单 
    ''' 逻辑:判断物品是否合法,是否需要扫描机身号.根据是或者不是,更改界面的字段显示;
    ''' </summary>
    ''' <param name="as_sku1"></param>
    ''' <param name="as_sku2"></param>
    ''' <remarks></remarks>
    Private Function get_scan_sku_list(ByVal as_sku1 As String, ByVal as_sku2 As String) As String
        Dim task_id, bch_no, dn_no, bin_code, sku_no, assigned_opt As String
        Dim sErr As String = ""
        Try
            If as_sku2 <> as_sku1 Then
                Return "请扫描同一个SKU!"
            End If

            task_id = Me.tb_task_id.Text.Trim()
            bch_no = Me.tb_lot0.Text.Trim()
            dn_no = tb_dn0.Text.Trim()
            bin_code = tb_binid0.Text.Trim()
            assigned_opt = MDI_userid
            sku_no = tb_sku2.Text.Trim()
            ' -----------------------------------------------------------------------------------------
            Dim ds As DataSet = MSV1.RunProcedure_DS(WSSN, "sp_hht_tasklinScan_list", "@task_id|varchar|" + task_id + "|input;" _
                                                     + "@bch_no|varchar|" + bch_no + "|input;" _
                                                     + "@dn_no|varchar|" + dn_no + "|input;" _
                                                     + "@bin_code|varchar|" + bin_code + "|input;" _
                                                     + "@sku_no|varchar|" + sku_no + "|input;" _
                                                     + "@assigned_opt|varchar|" + assigned_opt + "|input;" _
                                                     + "@sErr|varchar||output", sErr)
            ' -----------------------------------------------------------------------------------------
            Dim das() As String = sErr.Split("|")
            If das(0) = "-1" Then '报错 : 物品非法或者其他错误.
                Return "请扫描同一个SKU!"

            End If
            If das(0) = "0" Then '成功！刷新显示;
                Dim rowid0, sku_no0, sno0 As String
                lv_scan.Items.Clear()
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    rowid0 = ds.Tables(0).Rows(i)("rowid").ToString()
                    sku_no0 = ds.Tables(0).Rows(i)("sku_no").ToString()
                    sno0 = ds.Tables(0).Rows(i)("sno").ToString()
                    Dim lvm As ListViewItem = New ListViewItem
                    lvm.Text = (lv_tasklist.Items.Count + 1).ToString()
                    lvm.SubItems.Add(sku_no0)
                    lvm.SubItems.Add(sno0)
                    lvm.SubItems.Add(rowid0)
                    lv_scan.Items.Add(lvm)
                    lv_scan.Refresh()
                Next

                '完成数量统计..
                Dim sumQty1, sumQty0 As String
                sumQty1 = ds.Tables(1).Rows(0)("sumQty1").ToString()
                sumQty0 = ds.Tables(1).Rows(0)("sumQty0").ToString()
                ll_qtySum.Text = sumQty1 + "/" + sumQty0
                Return ""
            End If
        Catch ex As Exception
            alert(ex.Message)
        End Try
    End Function

    ''' <summary>
    ''' 物品条码扫描过程：判断是否合法(=当前指定的物品条码),是否需要机身号.是否需要扫描机身号.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub add_scan_sku()
        Dim task_id, bch_no, dn_no, bin_code, sku_no, sno, qty, assigned_opt As String
        qty = "1"
        '根据物品sku_no ，提取物品信息：名称，是否要机身号
        '  [sp_hht_tasklinScan_ADD] @task_id  @bch_no  @dn_no  @bin_code @sku_no  @sno @qty @assigned_opt @sErr
        Dim sErr As String = ""
        Dim qtySN As Integer = 1
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.Refresh()
            task_id = Me.tb_task_id.Text.Trim()
            bch_no = Me.tb_lot0.Text.Trim()
            dn_no = tb_dn0.Text.Trim()
            bin_code = tb_binid0.Text.Trim()
            sku_no = tb_sku2.Text.Trim()
            'sno = tb_sno.Text.Trim()
            sno = ""
            'If ll_title.Text = "机身号:" Then '如果是机身号扫描...
            '    If sno = "" Then
            '        alert("请扫描或者录入机身号信息!")
            '        tb_sno.Focus()
            '        tb_sno.SelectAll()
            '        Return
            '    Else 'ChangeToCount
            '        qtySN = ChangeToCount(sno)
            '        qty = qtySN.ToString() '取得数量...
            '    End If
            'Else '如果是数量录入..
            '    If Not IsNumeric(tb_sno.Text.Trim) Then
            '        alert("请录入数量!")
            '        tb_sno.Focus()
            '        tb_sno.SelectAll()
            '        Return
            '    End If
            '    '如果是数量,机身号框为数量信息:
            '    qty = tb_sno.Text.Trim
            '    sno = ""
            'End If

            '控制qty只能录入正数
            assigned_opt = MDI_userid

            qty = 1 '--Enzo 20110824 qty不从窗口取 每扫描一次记录一次 具体参看 CEVA - Change Request Lists(20110819) .xls
            ' -----------------------------------------------------------------------------------------
            Dim ds As DataSet = MSV1.RunProcedure_DS(WSSN, "sp_hht_tasklinScan_ADD", "@task_id|varchar|" + task_id + "|input;" _
                                                     + "@bch_no|varchar|" + bch_no + "|input;" _
                                                     + "@dn_no|varchar|" + dn_no + "|input;" _
                                                     + "@bin_code|varchar|" + bin_code + "|input;" _
                                                     + "@sku_no|varchar|" + sku_no + "|input;" _
                                                     + "@sno|varchar|" + sno + "|input;" _
                                                     + "@qty|varchar|" + qty + "|input;" _
                                                     + "@assigned_opt|varchar|" + assigned_opt + "|input;" _
                                                     + "@sErr|varchar||output", sErr)
            ' -----------------------------------------------------------------------------------------
            Dim das() As String = sErr.Split("|")
            If sErr <> "" Then
                If das.Length < 3 Then
                    alert(sErr)
                    Return
                End If
            End If

            If das(0) = "0" Or das(0) = "-3" Then '0或者-4 成功！刷新显示;
                ' '-1|物品@sku_no非法，请检查!|'
                refresh_lv_scan(ds)
                If das(0) = "-3" Then
                    alert(das(1))
                    tb_sku2.Focus()
                    tb_sku2.SelectAll()
                    Return
                End If

                ''清除界面：
                If das(2) = "1" Then '机身号
                    'tb_sno.Enabled = True
                    'tb_sno.Text = ""
                    tb_sku2.Focus()
                    tb_sku2.SelectAll()
                Else 'das(2) 如果=0，是SKU，移动焦点
                    'tb_sku.Text = ""
                    'tb_name0.Text = ""
                    'tb_sno.Text = ""
                    'tb_sno.Enabled = True
                    'tb_sno.Focus()
                    'tb_sno.SelectAll()
                    'p1.Visible = False
                    tb_sku2.Focus()
                    tb_sku2.SelectAll()
                End If
            End If

            If das(0) = "-1" Then '错误！
                alert(das(1))
                ' tb_name2.Text = ""
                'tb_sno.Text = ""
                tb_sku2.Focus()
                tb_sku2.SelectAll()
            End If

            'If das(0) = "-2" Then '需要扫描机身号
            '    tb_name2.Text = das(1)
            '    'tb_sno.Enabled = True
            '    'tb_sno.Text = ""
            '    tb_sku2.Focus()
            '    tb_sku2.SelectAll()
            'End If

            If das(0) = "-5" Then '已经扫描完成
                refresh_lv_scan(ds)
                alert("当前库位已经操作完成，请扫描『确认库位』!")
                tb_binOK.Text = tb_binid2.Text
                tb_binOK.Focus()
                tb_binOK.SelectAll()
                'btn_binOK.Focus()
            End If
            '    If das(0) = "-4" Then '机身号重复
            '        alert(das(1))
            '        'tb_sno.Enabled = True
            '        tb_sku2.Focus()
            '        tb_sku2.SelectAll()
            '    End If
        Catch ex As Exception
            alert(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '''' <summary>
    '''' 判断一下,是否批量性质的Sno: S20-***之类的
    '''' </summary>
    '''' <param name="as_sno"></param>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Private Function input_sno_batch(ByVal as_sno As String) As String
    '    Dim rlt As String = ""
    '    Dim sno As String = as_sno.Trim.ToUpper()
    '    If sno.Substring(0, 1) <> "S" Then
    '        Return ""
    '    End If
    '    '判断循环多少次:
    '    Dim cnt As Integer = 0
    '    ' -号结尾的;
    '    Dim jindex As Integer = sno.IndexOf("-")
    '    Dim tmp As String = Mid(sno, 1, jindex + 1)
    '    cnt = CType(tmp, Integer)
    '    Return rlt
    'End Function

    ''' <summary>
    ''' 刷新扫描清单和汇总数据视图
    ''' </summary>
    ''' <param name="ds"></param>
    ''' <remarks></remarks>
    Private Sub refresh_lv_scan(ByRef ds As DataSet)
        Dim rowid0, sku_no0, sno0 As String
        lv_scan.Items.Clear()
        Me.SuspendLayout()
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            rowid0 = ds.Tables(0).Rows(i)("rowid").ToString()
            sku_no0 = ds.Tables(0).Rows(i)("sku_no").ToString()
            sno0 = ds.Tables(0).Rows(i)("sno").ToString()
            Dim lvm As ListViewItem = New ListViewItem
            lvm.Text = (lv_scan.Items.Count + 1).ToString()
            lvm.SubItems.Add(sku_no0)
            '注意:如果是数字,则需要去掉小数点显示一个整数:
            If sno0.ToUpper.StartsWith("S") Then 'S字母开头的...
            Else
                If sno0.IndexOf(".") > 0 Then '如果是数字,则转化为无小数点格式..
                    sno0 = CType(sno0, Integer).ToString()
                End If
            End If
            lvm.SubItems.Add(sno0)
            lvm.SubItems.Add(rowid0)
            lv_scan.Items.Add(lvm)
        Next
        Me.ResumeLayout()
        lv_scan.Refresh()

        '完成数量统计..
        Dim sumQty1, sumQty0 As String
        sumQty1 = ds.Tables(1).Rows(0)("sumQty1").ToString()
        sumQty0 = ds.Tables(1).Rows(0)("sumQty0").ToString()
        ll_qtySum.Text = sumQty1 + "/" + sumQty0
    End Sub


    ''' <summary>
    ''' 录入数量或者扫描机身号,增加数量到表
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub add_scan_sku_Qty()
        Dim task_id, bch_no, dn_no, bin_code, sku_no, sno, qty, assigned_opt As String
        qty = "0"
        '根据物品sku_no ，提取物品信息：名称，是否要机身号
        '  [sp_hht_tasklinScan_ADD] @task_id  @bch_no  @dn_no  @bin_code @sku_no  @sno @qty @assigned_opt @sErr
        Dim sErr As String = ""
        Try
            task_id = Me.tb_task_id.Text.Trim()
            bch_no = Me.tb_lot0.Text.Trim()
            dn_no = tb_dn0.Text.Trim()
            bin_code = tb_binid0.Text.Trim()
            sku_no = tb_sku2.Text.Trim()
            sno = tb_sno.Text.Trim()

            If ll_title.Text = "机身号:" Then '如果是机身号扫描...
                If sno = "" Then
                    alert("请扫描或者录入机身号信息!")
                    tb_sno.Focus()
                    tb_sno.SelectAll()
                    Return
                End If
            Else '如果是数量录入..
                If Not IsNumeric(tb_sno.Text.Trim) Then
                    alert("请录入数量!")
                    tb_sno.Focus()
                    tb_sno.SelectAll()
                    Return
                End If
                '如果是数量,机身号框为数量信息:
                qty = tb_sno.Text.Trim
                sno = ""
            End If

            '控制qty只能录入正数
            assigned_opt = MDI_userid
            ' -----------------------------------------------------------------------------------------
            Dim ds As DataSet = MSV1.RunProcedure_DS(WSSN, "sp_hht_tasklinScan_ADD", "@task_id|varchar|" + task_id + "|input;" _
                                                     + "@bch_no|varchar|" + bch_no + "|input;" _
                                                     + "@dn_no|varchar|" + dn_no + "|input;" _
                                                     + "@bin_code|varchar|" + bin_code + "|input;" _
                                                     + "@sku_no|varchar|" + sku_no + "|input;" _
                                                     + "@sno|varchar|" + sno + "|input;" _
                                                     + "@qty|varchar|" + qty + "|input;" _
                                                     + "@assigned_opt|varchar|" + assigned_opt + "|input;" _
                                                     + "@sErr|varchar||output", sErr)
            ' -----------------------------------------------------------------------------------------
            Dim das() As String = sErr.Split("|")
            If das.Length < 3 Then
                alert(sErr)
                Return
            End If
            If das(0) = "0" Then '成功！刷新显示;
                ' '-1|物品@sku_no非法，请检查!|'
                ' rowid0, sku_no0, sno0
                Dim rowid0, sku_no0, sno0 As String
                lv_scan.Items.Clear()
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    rowid0 = ds.Tables(0).Rows(i)("rowid").ToString()
                    sku_no0 = ds.Tables(0).Rows(i)("sku_no").ToString()
                    sno0 = ds.Tables(0).Rows(i)("sno").ToString()
                    Dim lvm As ListViewItem = New ListViewItem
                    lvm.Text = (lv_tasklist.Items.Count + 1).ToString()
                    lvm.SubItems.Add(sku_no0)
                    lvm.SubItems.Add(sno0)
                    lvm.SubItems.Add(rowid0)
                    lv_scan.Items.Add(lvm)
                    lv_scan.Refresh()
                Next

                '完成数量统计..
                Dim sumQty1, sumQty0 As String
                sumQty1 = ds.Tables(1).Rows(0)("sumQty1").ToString()
                sumQty0 = ds.Tables(1).Rows(0)("sumQty0").ToString()
                ll_qtySum.Text = sumQty1 + "/" + sumQty0

                ''清除界面：
                If das(2) = "1" Then '机身号
                    tb_sno.Enabled = True
                    tb_sno.Text = ""
                    tb_sno.Focus()
                    tb_sno.SelectAll()
                Else '如果=0，是SKU，调整页面
                    'tb_sku.Text = ""
                    'tb_name0.Text = ""
                    'tb_sno.Text = ""
                    'tb_sno.Enabled = True
                    'tb_sno.Focus()
                    'tb_sno.SelectAll()
                    p1.Visible = False
                End If
            End If

            If das(0) = "-1" Then '错误！
                alert(das(1))
                tb_sku2.Text = ""
                'tb_name2.Text = ""
                tb_sno.Text = ""
                tb_sku2.Focus()
                tb_sku2.SelectAll()
            End If

            If das(0) = "-2" Then '需要扫描机身号
                'tb_name2.Text = das(1)
                tb_sno.Enabled = True
                tb_sno.Text = ""
                tb_sno.Focus()
                tb_sno.SelectAll()
            End If

            If das(0) = "-3" Then '已经扫描完成
                'btn_binOK.Focus()
                alert("当前库位已经操作完成，确认『库位完成』")
                'btn_binOK.Focus()
            End If

            If das(0) = "-4" Then '机身号重复
                alert(das(1))
                tb_sno.Enabled = True
                tb_sno.Focus()
                tb_sno.SelectAll()
            End If

        Catch ex As Exception
            alert(ex.Message)
        End Try
    End Sub

    'lv_scan
    Private Sub btn_rtn0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    ''' <summary>
    ''' 进入扫描界面
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_pick_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pick.Click
        If tb_binid0.Text.Trim = "" Then
            alert("请选择库位!")
            lv_tasklist.Focus()
            Return
        End If
        p1.Visible = True
        p0.Visible = False
        Me.clear_p2()
        tb_binid2.Text = tb_binid0.Text
        tb_sku3.Text = tb_sku0.Text
        tb_binOK.Text = tb_binid0.Text
        ' 刷新 ll_info 状态数据
        get_AccumulatedQty_Bin()
        tb_sku2.Focus()
    End Sub

    Private Sub clear_p2()
        tb_binid2.Text = ""
        tb_sku3.Text = ""
        tb_sku2.Text = ""
        tb_name2.Text = ""
        tb_sno.Text = ""
        ll_info.Text = ""
        lv_scan.Items.Clear()
    End Sub

    ''' <summary>
    ''' 选择当前单据信息
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lv_tasklist_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv_tasklist.SelectedIndexChanged
        tb_lot0.Text = ""
        tb_dn0.Text = ""
        tb_binid0.Text = ""
        tb_task_id.Text = ""
        Dim selectedItem As ListViewItem = Nothing
        For Each lvi As Integer In lv_tasklist.SelectedIndices
            selectedItem = lv_tasklist.Items(lvi)
            Exit For
        Next
        If Not IsNothing(selectedItem) Then
            tb_sku0.Text = selectedItem.SubItems(1).Text
            tb_binid0.Text = selectedItem.SubItems(2).Text
            tb_dn0.Text = selectedItem.SubItems(5).Text
            tb_task_id.Text = selectedItem.SubItems(6).Text
            tb_lot0.Text = selectedItem.SubItems(7).Text
        End If
    End Sub

    ''' <summary>
    ''' 切换-显示选择的DN单明细
    ''' sp_hht_getTaskList
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    '''' <summary>
    '''' 得到ceva批次数据列表
    '''' exec sp_hht_getTaskList @assigned_opt
    '''' 返回字段序列 : bch_no,dn_no,bin_code,qty,rqty
    '''' </summary>
    '''' <remarks></remarks>
    'Private Sub get_taskList()
    '    Dim bch_no, dn_no, bin_code, qty, rqty, task_id As String
    '    Dim ds As DataSet = Nothing
    '    Dim sErr As String = ""
    '    'tb_task_id.Text = ""
    '    Try
    '        Cursor.Current = Cursors.WaitCursor
    '        ds = MSV1.RunProcedure_DS(WSSN, "sp_hht_getTaskList", "@assigned_opt|varchar|" + MDI_userid + "|input;@sErr|varchar||output", sErr)
    '        If sErr <> "" Then
    '            alert(sErr)
    '            Return
    '        End If
    '        lv_tasklist.Items.Clear()
    '        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '            bch_no = ds.Tables(0).Rows(i)("bch_no").ToString()
    '            dn_no = ds.Tables(0).Rows(i)("dn_no").ToString()
    '            bin_code = ds.Tables(0).Rows(i)("bin_code").ToString()
    '            qty = ds.Tables(0).Rows(i)("qty").ToString()
    '            rqty = ds.Tables(0).Rows(i)("rqty").ToString()
    '            task_id = ds.Tables(0).Rows(i)("task_id").ToString()
    '            Dim lvm As ListViewItem = New ListViewItem
    '            lvm.Text = (lv_tasklist.Items.Count + 1).ToString()
    '            lvm.SubItems.Add(bch_no)
    '            lvm.SubItems.Add(bin_code)
    '            lvm.SubItems.Add(qty)
    '            lvm.SubItems.Add(rqty)
    '            lvm.SubItems.Add(dn_no)
    '            lvm.SubItems.Add(task_id)
    '            lv_tasklist.Items.Add(lvm)
    '            lv_tasklist.Refresh()
    '        Next
    '    Catch ex As Exception
    '        alert(ex.Message)
    '    Finally
    '        Cursor.Current = Cursors.Default
    '    End Try
    'End Sub

    ''' <summary>
    ''' 根据批次号，库位号，dn单号，得到物品明细信息(不是扫描明细)
    ''' sp_hht_getTaskList
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub get_taskList_detail(ByVal as_task_id As String)
        '--	exec sp_hht_getTasklin @task_id
        '--	dc_code, wh_code, task_id, bch_no, dn_no, assigned_opt, bin_area, bin_code, tasklist.sku_no,skuinfo.sku_desc, 
        '--	qty, type, status_code, tasklist.opt_by, tasklist.opt_dtime
        'task_id, dc_code, wh_code, assigned_opt, bin_area, type, status_code, opt_by, opt_dtime
        Dim bch_no, dn_no, bin_code, sku_no, sku_desc As String
        Dim qty, rqty As String
        Dim ds As DataSet = Nothing
        Dim sErr As String = ""
        If as_task_id = "" Then
            Return
        End If
        Try
            Cursor.Current = Cursors.WaitCursor
            'lv_taskDetail.Items.Clear()
            ds = MSV1.RunProcedure_DS(WSSN, "sp_hht_getTasklin", "@task_id|varchar|" + as_task_id + "|input;@assigned_opt|varchar|" + MDI_userid + "|input;@sErr|varchar||output", sErr)
            If sErr <> "" Then
                alert(sErr)
                Return
            End If
            'lv_taskDetail.Items.Clear()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ' bch_no,dn_no, assigned_opt,bin_code, sku_no,sku_desc,qty, type, status_code, opt_by, opt_dtime 
                bch_no = ds.Tables(0).Rows(i)("bch_no").ToString()
                dn_no = ds.Tables(0).Rows(i)("dn_no").ToString()
                bin_code = ds.Tables(0).Rows(i)("bin_code").ToString()
                sku_no = ds.Tables(0).Rows(i)("sku_no").ToString()
                sku_desc = ds.Tables(0).Rows(i)("sku_desc").ToString()
                qty = ds.Tables(0).Rows(i)("qty").ToString()
                rqty = ds.Tables(0).Rows(i)("rqty").ToString()
                Dim lvm As ListViewItem = New ListViewItem
                lvm.Text = (lv_tasklist.Items.Count + 1).ToString()
                lvm.SubItems.Add(dn_no)
                lvm.SubItems.Add(bin_code)
                lvm.SubItems.Add(sku_no)
                lvm.SubItems.Add(sku_desc)
                lvm.SubItems.Add(qty)
                lvm.SubItems.Add(rqty)
                'lv_taskDetail.Items.Add(lvm)
                'lv_taskDetail.Refresh()
            Next
        Catch ex As Exception
            alert(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        p1.Visible = True
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showHideKeyBoard()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showHideKeyBoard()
    End Sub

    Private Sub tb_sno_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_sno.TextChanged
    End Sub
    Private Sub tb_sno_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_sno.KeyDown
        If IsNothing(e) Then
            GoTo enter
        End If

        If e.KeyCode = Keys.Enter Then
enter:
            Dim sno As String = tb_sno.Text.Trim
            If sno = "" Then
                tb_sno.Focus()
                tb_sno.SelectAll()
                Return
            End If
            ' 扫描物品，累加数量
            '[sp_hht_tasklinScan_ADD] @task_id  @bch_no  @dn_no  @bin_code @sku_no  @sno @qty @assigned_opt @sErr
            add_scan_sku()
            Return
        End If

        '其他键盘...
        If Not IsNothing(e) Then
            If e.KeyCode = Keys.Up Then '回到SKU框中...
                tb_sku2.Focus()
                tb_sku2.SelectAll()
                Return
            End If
        End If
    End Sub

    Private Sub btn_binOK_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        btn_binOK_Click(Nothing, Nothing)
    End Sub
    Private Sub btn_binOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        p1.Visible = False
    End Sub

    Private Sub tb_binid02_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub tb_binid02_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btn_binOK_Click(Nothing, Nothing)
        End If
    End Sub


    Private Sub btn_binOK_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CType(sender, Button).Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold)
    End Sub

    Private Sub btn_binOK_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CType(sender, Button).Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular)
    End Sub

    Private Sub tb_binid0_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub tb_binid0_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If tb_binid0.Text.Trim <> "" Then

            End If
        End If
    End Sub

    Private Sub frm_Picklist_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If KeyBoardFlag Then
                SipShowIM(0)
            End If
            gf_del_CheckBarcode = [Delegate].Remove(gf_del_CheckBarcode, thisFrom_del_CheckBarcode)
        Catch ex As Exception
            alert(ex.Message)
        End Try
    End Sub

    Private Sub tb_addedQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    ''' <summary>
    ''' 得到库位上面的完成情况;
    ''' 得到物品的属性:是否有机身号?sku_no
    ''' </summary>
    ''' <remarks></remarks>
    Private Function get_AccumulatedQty_Bin() As String
        Dim bch_no, dn_no, bin_code, task_id, sku_no As String
        Dim sErr As String = ""
        ll_qtySum.Text = ""
        Try
            'exec sp_hht_get_FinishedQty_Bin @task_id,@bch_no,@dn_no,@bin_code,@sku_no,@sErr
            Cursor.Current = Cursors.WaitCursor
            task_id = Me.tb_task_id.Text.Trim()
            bch_no = Me.tb_lot0.Text.Trim()
            dn_no = tb_dn0.Text
            bin_code = tb_binid2.Text.Trim()
            sku_no = tb_sku0.Text.Trim
            Dim ds As DataSet = MSV1.RunProcedure_DS(WSSN, "sp_hht_get_FinishedQty_Bin", "@task_id|varchar|" + task_id + "|input;" _
                                                    + "@bch_no|varchar|" + bch_no + "|input;" _
                                                    + "@dn_no|varchar|" + dn_no + "|input;" _
                                                    + "@bin_code|varchar|" + bin_code + "|input;" _
                                                    + "@sku_no|varchar|" + sku_no + "|input;" _
                                                    + "@assigned_opt|varchar|" + MDI_userid + "|input;" _
                                                    + "@sErr|varchar||output", sErr)
            Dim das() As String = sErr.Split("|")
            If das(0) <> "0" Then
                alert(das(1))
                Return das(1)
            End If

            'sku_no,sku_desc,qty,rqty,have_sno
            Dim sku_no0, sku_desc, qty0, rqty, have_sno As String
            sku_desc = ""
            have_sno = "0"
            Dim obj As Object = Nothing
            lv_scan.Items.Clear()
            Dim orqty As Object = Nothing
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                sku_no0 = ds.Tables(0).Rows(i)("sku_no").ToString()
                sku_desc = ds.Tables(0).Rows(i)("sku_desc").ToString()
                qty0 = ds.Tables(0).Rows(i)("qty").ToString()
                qty0 = CType(qty0, Integer).ToString()
                orqty = ds.Tables(0).Rows(i)("rqty")
                If IsNothing(orqty) Then
                    orqty = "0"
                End If
                If IsDBNull(orqty) Then
                    orqty = "0"
                End If
                rqty = orqty.ToString()
                rqty = CType(rqty, Integer).ToString()
                obj = ds.Tables(0).Rows(i)("have_sno")
                If IsNothing(obj) Then
                    obj = "0"
                End If
                have_sno = obj.ToString().ToLower()
            Next

            If have_sno = "0" Then '{无}机身号
                ll_title.Text = "数量:"
            Else
                ll_title.Text = "机身号:"
            End If
            tb_name2.Text = sku_desc '显示数据...
            '明细表信息字段: rowid, sku_no, sno 
            Dim rowid0, sno0 As String
            lv_scan.Items.Clear()
            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                rowid0 = ds.Tables(1).Rows(i)("rowid").ToString()
                sku_no0 = ds.Tables(1).Rows(i)("sku_no").ToString()
                sno0 = ds.Tables(1).Rows(i)("sno").ToString()

                '注意:如果是数字,则需要去掉小数点显示一个整数:
                If sno0.ToUpper.StartsWith("S") Then 'S字母开头的...
                Else
                    If sno0.IndexOf(".") > 0 Then '如果是数字,则转化为无小数点格式..
                        sno0 = CType(sno0, Integer).ToString()
                    End If
                End If
                Dim lvm As ListViewItem = New ListViewItem
                lvm.Text = (lv_scan.Items.Count + 1).ToString()
                lvm.SubItems.Add(sku_no0)
                lvm.SubItems.Add(sno0)
                lvm.SubItems.Add(rowid0)
                lv_scan.Items.Add(lvm)
                lv_scan.Refresh()
            Next

            ' 显示汇总信息;
            Dim sumQty1, sumQty0 As String
            sumQty1 = ds.Tables(2).Rows(0)("sumQty1").ToString()
            sumQty0 = ds.Tables(2).Rows(0)("sumQty0").ToString()
            ll_qtySum.Text = sumQty1 + "/" + sumQty0
            Return ""
        Catch ex As Exception
            Return ex.Message
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'set_FinishedQty_Bin()
        get_AccumulatedQty_Bin()
        tb_sku2.Focus()
        tb_sku2.SelectAll()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        p1.Visible = True
        get_AccumulatedQty_Bin()
        tb_sku2.Focus()
        tb_sku2.SelectAll()
    End Sub

    ''' <summary>
    ''' sku 刷新显示：
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btn_refresh0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_refresh0.Click
        '提取登录用户的可用任务清单 
        '[1]得到当前需要的任务列表
        '[2]得到当前操作此物品的（活动）用户列表
        '[3]用[1]的列表，根据【2】的列表，分配一下数据，显示到HHT
        Try
            Cursor.Current = Cursors.WaitCursor
            Me.Refresh()
            Dim sku0 As String = tb_sku0.Text.Trim
            If sku0 = "" Then
                Return
            End If

            lv_tasklist.Items.Clear()
            lv_tasklist.SuspendLayout()

            Dim sErr As String = ""
            '-----Enzo 20110816 修改不同用户操作同一个SKU排序逻辑
            'Dim ds As DataSet = MSV1.wf_sp_hht_getTaskList(WSSN, sku0, MDI_userid, sErr)
            'Dim ds As DataSet = MSV1.RunProcedure_DS(WSSN, "sp_hht_getTaskList_div", "@sku_no|varchar|" + sku0 + "|input;@assigned_opt|varchar|" + MDI_userid + "|input;@sErr|varchar||output", sErr)  '---Enzo 20110831 03:00          

            Dim ds As DataSet = MSV1.RunProcedure_DS(WSSN, "sp_hht_getTaskList_div_bybchno", "@bch_no|varchar|" + globalbatchno + "|input;@sku_no|varchar|" + sku0 + "|input;@assigned_opt|varchar|" + MDI_userid + "|input;@sErr|varchar||output", sErr)

            If sErr <> "" Then
                alert(sErr)
                Return
            End If

            '字段:sku,库位,数量,实际数量,DN单号
            Dim task_id, bch_no, dn_no, bin_code, qty, rqty, sku_no As String
            lv_tasklist.Items.Clear()
            lv_tasklist.SuspendLayout()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                bch_no = ds.Tables(0).Rows(i)("bch_no").ToString()
                dn_no = ds.Tables(0).Rows(i)("dn_no").ToString()
                bin_code = ds.Tables(0).Rows(i)("bin_code").ToString()
                qty = ds.Tables(0).Rows(i)("qty").ToString()
                qty = CType(qty, Integer).ToString()
                rqty = ds.Tables(0).Rows(i)("rqty").ToString()
                rqty = CType(rqty, Integer).ToString()
                task_id = ds.Tables(0).Rows(i)("task_id").ToString()
                sku_no = ds.Tables(0).Rows(i)("sku_no").ToString()
                Dim lvm As ListViewItem = New ListViewItem
                lvm.Text = (lv_tasklist.Items.Count + 1).ToString()
                lvm.SubItems.Add(sku_no)
                lvm.SubItems.Add(bin_code)
                lvm.SubItems.Add(qty)
                lvm.SubItems.Add(rqty)
                lvm.SubItems.Add(dn_no)
                lvm.SubItems.Add(task_id)
                lvm.SubItems.Add(bch_no)
                lv_tasklist.Items.Add(lvm)
            Next
            lv_tasklist.ResumeLayout()
            lv_tasklist.Refresh()
        Catch ex As Exception
            alert(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
            tb_sku0.Focus()
            tb_sku0.SelectAll()
        End Try
    End Sub

    ''' <summary>
    ''' 删除指定的数据行
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim selectedItem As ListViewItem = Nothing
        For Each lvi As Integer In lv_scan.SelectedIndices
            selectedItem = lv_scan.Items(lvi)
            Exit For
        Next

        If Not IsNothing(selectedItem) Then
            If ask("是否删除?") <> MsgBoxResult.Yes Then
                tb_sku2.Focus()
                tb_sku2.SelectAll()
                Return
            End If
            Dim bin, sku, dn, task_id0, bch_no0, rowid0 As String
            bin = tb_binid2.Text.Trim()
            sku = tb_sku3.Text.Trim()
            dn = tb_dn0.Text.Trim()
            task_id0 = tb_task_id.Text
            bch_no0 = tb_lot0.Text
            rowid0 = selectedItem.SubItems(3).Text '当前行号
            '删除指定行,然后刷新数据显示
            Dim sErr As String = ""
            Try
                ' -----------------------------------------------------------------------------------------
                MSV1.RunProcedure_Str(WSSN, "sp_hht_tasklinScan_del", "@task_id|varchar|" + task_id0 + "|input;" _
                                                         + "@bch_no|varchar|" + bch_no0 + "|input;" _
                                                         + "@dn_no|varchar|" + dn + "|input;" _
                                                         + "@bin_code|varchar|" + bin + "|input;" _
                                                         + "@sku_no|varchar|" + sku + "|input;" _
                                                         + "@rowid|varchar|" + rowid0 + "|input;" _
                                                         + "@assigned_opt|varchar|" + MDI_userid + "|input;" _
                                                         + "@sErr|varchar||output", sErr)
                If sErr <> "" Then
                    alert("删除失败:" + sErr)
                    tb_sku2.Focus()
                    tb_sku2.SelectAll()
                    Return
                Else
                    'msg1("删除成功!")
                    get_AccumulatedQty_Bin()
                    tb_sku2.Focus()
                    tb_sku2.SelectAll()
                End If
                ' -----------------------------------------------------------------------------------------
            Catch ex As Exception
                alert(ex.Message)
            End Try
        End If
    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Confirm_Binid()
        If tb_binOK.Text.Trim = "" Then
            Return
        End If

        '确认库位:如果不一样,问过用户就删除之:并且返回上一个界面.
        If tb_binOK.Text.Trim <> tb_binid2.Text.Trim Then
            Dim mrt As MsgBoxResult = ask("库位不一致,重新扫描请按{是}" + vbCrLf + "放弃当前扫描操作,删除扫描记录,请按{否}")
            If mrt = MsgBoxResult.Yes Then '重新扫描
                tb_binOK.Focus()
                tb_binOK.SelectAll()
                Return
            End If
            If mrt = MsgBoxResult.No Then '删除操作记录:
                If ask("是否确认删除扫描记录?") = MsgBoxResult.Yes Then
                    '删除...
                    binDeleteConfirm()
                    tb_sno.Text = ""
                    tb_sku2.Text = ""
                    tb_binOK.Text = ""
                    tb_sku2.SelectAll()
                Else
                    Return
                End If
            End If
        Else '如果库位一致: 则确认状态
            '确认完成,同时修改背后单据状态:
            ' sp_hht_tasklinScan_FinishBin @task_id @bch_no @dn_no @bin_code @assigned_opt @sErr
            Dim bin, sku, dn, task_id0, bch_no0 As String
            bin = tb_binid2.Text.Trim()
            sku = tb_sku3.Text.Trim()
            dn = tb_dn0.Text.Trim()
            task_id0 = tb_task_id.Text
            bch_no0 = tb_lot0.Text
            '删除指定行,然后刷新数据显示
            Dim sErr As String = ""
            Try
                ' sp_hht_tasklinScan_FinishBin @task_id @bch_no @dn_no @bin_code @assigned_opt @sErr
                ' -----------------------------------------------------------------------------------------
                MSV1.RunProcedure_Str(WSSN, "sp_hht_tasklinScan_FinishBin", "@task_id|varchar|" + task_id0 + "|input;" _
                                                         + "@bch_no|varchar|" + bch_no0 + "|input;" _
                                                         + "@dn_no|varchar|" + dn + "|input;" _
                                                         + "@bin_code|varchar|" + bin + "|input;" _
                                                         + "@assigned_opt|varchar|" + MDI_userid + "|input;" _
                                                         + "@sErr|varchar||output", sErr)
                If sErr <> "" Then
                    alert("操作完成!" + sErr)
                    Return
                Else
                    get_AccumulatedQty_Bin()
                    tb_sku2.Focus()
                End If
                ' -----------------------------------------------------------------------------------------
            Catch ex As Exception
                alert(ex.Message)
            End Try
            p1.Visible = False
            p0.Visible = True
            btn_refresh0_Click(Nothing, Nothing)
            'get_AccumulatedQty_Bin()
            'tb_sku2.Focus()
        End If
    End Sub
    ''' <summary>
    ''' 删除指定库位上的扫描记录...
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub binDeleteConfirm()
        'If ask("是否删除?") <> MsgBoxResult.Yes Then
        '    Return
        'End If
        Dim bin, sku, dn, task_id0, bch_no0 As String
        bin = tb_binid2.Text.Trim()
        sku = tb_sku3.Text.Trim()
        dn = tb_dn0.Text.Trim()
        task_id0 = tb_task_id.Text
        bch_no0 = tb_lot0.Text
        '删除指定行,然后刷新数据显示
        Dim sErr As String = ""
        Try
            Cursor.Current = Cursors.WaitCursor
            ' -----------------------------------------------------------------------------------------
            MSV1.RunProcedure_Str(WSSN, "sp_hht_tasklinScan_BinDelete", "@task_id|varchar|" + task_id0 + "|input;" _
                                                     + "@bch_no|varchar|" + bch_no0 + "|input;" _
                                                     + "@dn_no|varchar|" + dn + "|input;" _
                                                     + "@bin_code|varchar|" + bin + "|input;" _
                                                     + "@sku_no|varchar|" + sku + "|input;" _
                                                     + "@assigned_opt|varchar|" + MDI_userid + "|input;" _
                                                     + "@sErr|varchar||output", sErr)
            If sErr <> "" Then
                alert("删除失败:" + sErr)
                Return
            Else
                get_AccumulatedQty_Bin()
                'msg1("删除成功!")
            End If
            ' -----------------------------------------------------------------------------------------
        Catch ex As Exception
            alert(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btn_rtn0_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rtn0.Click
        '----Enzo 20110816 --清楚skuBinSort表数据
        ClearSkuBinSort()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        get_AccumulatedQty_Bin()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub tb_sku0_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_sku0.KeyDown

        If IsNothing(e) Then
            GoTo enter
        End If
        If e.KeyCode = Keys.Enter Then
enter:
            If tb_sku0.Text.Trim <> "" Then
                Dim sku2 As String = tb_sku0.Text.Trim
                checktb_sku0(sku2)
                btn_refresh0_Click(Nothing, Nothing)
                tb_sku0.Focus()
                tb_sku0.SelectAll()
                Return
            End If
            Return
        End If

        If Not IsNothing(e) Then
            If e.KeyCode = Keys.Down Then
                lv_tasklist.Focus()
            End If
        End If
    End Sub

    Private Sub lv_tasklist_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lv_tasklist.KeyDown
        If IsNothing(e) Then
            GoTo enter
        End If
        If e.KeyCode = Keys.Enter Then
enter:
            'Dim selectedItem As ListViewItem = Nothing
            'For Each lvi As Integer In lv_tasklist.SelectedIndices
            '    selectedItem = lv_tasklist.Items(lvi)
            '    Exit For
            'Next
            btn_pick_Click(Nothing, Nothing)
            Return
        End If

        ' 向上按键，第一列时，将焦点返回给
        If e.KeyCode = Keys.Up Then


        End If

    End Sub

    Private Sub pb_keyBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_keyBoard.Click
        showHideKeyBoard()
    End Sub

    Private Sub tb_binOK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_binOK.TextChanged
    End Sub
    Private Sub tb_binOK_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tb_binOK.KeyDown
        If IsNothing(e) Then
            GoTo enter
        End If
        If e.KeyCode = Keys.Enter Then
enter:

            '' 临时测试用..
            'Confirm_Binid()
            'Return

            If tb_binOK.Text <> "" Then
                alert("请用激光扫描头扫描库位!" + vbCrLf + "手输无效!")
                Return
            End If
            Return
        End If
    End Sub

    ''' <summary>
    ''' S20-** 转化为 20 个
    ''' SA1-** 转化为 101个
    ''' ...
    ''' ...
    ''' </summary>
    ''' <param name="strBarCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ChangeToCount(ByVal strBarCode As String) As Integer
        Dim intCount As Integer
        Dim intIndex As Integer
        'Init ListArray
        Dim strArray() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
        Try

            If strBarCode.StartsWith("S") Then
                Dim tmp As String = strBarCode.Substring(1, 2)
                If IsNumeric(tmp) Then
                    Return CType(tmp, Integer)
                End If
            Else
                Return 1
            End If
            'If IsNumeric(strBarCode) Then
            '    Return strBarCode
            'End If
            'intCount = 0

            ''判断条码是否合法
            'If strBarCode.Length() <> BARCODELENGTH Then
            '    Return intCount
            'End If

            ''判断前一位是否为字母
            'If IsNumeric(strBarCode.Substring(0, 1)) Then
            '    If Not IsNumeric(strBarCode.Substring(0, 2)) Then
            '        intCount = 0
            '    Else
            '        intCount = CInt(strBarCode)
            '    End If
            'Else
            '    '检测条码值在数组中的位置
            '    intIndex = (Array.IndexOf(strArray, strBarCode.Substring(0, 1)))
            '    intCount = ONE_HUNTRED + intIndex * TEN + CInt(strBarCode.Substring(1, 1))
            'End If
            'Return intCount
        Catch ex As Exception
            intCount = 1
            Return intCount
        End Try

    End Function

    Sub ClearSkuBinSort()
        Try
            Dim sErr As String = ""
            Dim sku0 As String = tb_sku0.Text.Trim()
            Dim _str As String = MSV1.RunProcedure_Str(WSSN, "sp_hht_clearSkuBinSort", "@sku_no|varchar|" + sku0 + "|input;@assigned_opt|varchar|" + MDI_userid + "|input;@sErr|varchar||output", sErr)

            If sErr <> "" Then
                alert(sErr)
                Return
            End If
        Catch ex As Exception
            alert(ex.Message)
        End Try
    End Sub
End Class
