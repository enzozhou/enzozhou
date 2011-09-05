Public Class Login
    Public ref_Main As Main

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ref_Main.loginFlag = False
        Me.Close()
    End Sub

    ''' <summary>
    ''' 验证用户名和密码:
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim ls_uid, ls_pwd As String
            ls_uid = Me.TextBox_uid.Text.Trim
            ls_pwd = Me.TextBox_pwd.Text.Trim
            If ls_uid = "" Then
                alert("工号不能为空!")
                Return
            End If
            If ls_pwd = "" Then
                alert("密码不能为空!")
                Return
            End If

            Dim user_code, user_name As String
            Cursor.Current = Cursors.WaitCursor
            Dim ds As Data.DataSet = New Data.DataSet
            Dim sql As String = "select user_code, user_name, password,allowlogin,isadmin from OPERATOR where user_code='" + ls_uid + "' and password='" + ls_pwd + "'"
            Dim serr As String = ""
            ds = MSV1.ExecuteSQL_DS(WSSN, sql, serr)
            If serr <> "" Then
                alert(serr)
                Return
            End If
            If Not IsNothing(ds) Then
                If ds.Tables(0).Rows.Count > 0 Then
                    user_code = ds.Tables(0).Rows(0)("user_code").ToString()
                    user_name = ds.Tables(0).Rows(0)("user_name").ToString()
                Else
                    alert("用户名或者密码错误!")
                    Return
                End If
            Else
                alert("用户名或者密码错误!")
                Return
            End If
            MDI_userid = user_code
            MDI_userName = user_name
            ref_Main.loginFlag = True
            Me.Close()
        Catch ex As Exception
            alert("无法连接到服务器,请检查无线网络！")
            ref_Main.loginFlag = False
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Dim cf As ConfigurationFile
    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Appcenter_name
        ShowWindow(FindWindow("HHTaskBar", Nothing), SW_SHOW)
        ll_version.Text = "版本:" + AssInfo.Version
        TextBox_uid.Focus()
        Try
            cf = New ConfigurationFile
            tb_svrIP.Text = cf.readConfig("Svr_IP")
        Catch ex As Exception
            alert(ex.Message)
        End Try
        'Dim curDir As String
        'curDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        'Label6.Text = curDir
        'TextBox_uid.Text = cf.readConfig("Svr_IP")
    End Sub

    Private Sub TextBox_uid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox_uid.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.TextBox_pwd.Focus()
        End If
    End Sub

    Private Sub TextBox_pwd_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox_pwd.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1_Click(Button1, New System.EventArgs())
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim msg As String = M_Service1.RunProcedure_Str("sp_BoxFinished_QD", "@srno|varchar|TB0907003|input;@cartonbarcode|varchar|TB0907003-1347|input;@sErr|varchar||output")
        'MsgBox("??:" + vbCrLf + msg)

        'Dim msg As String = M_Service1.RunProcedure_Str("sp_CheckBarcodeCommon_HHT", "@bartype|varchar|01|input;@barcode|varchar|" + TextBox_uid.Text.Trim + "|input;@sErr|varchar||output")
        'MsgBox(":" + vbCrLf + msg)

        'Dim msg As String = SQLDBhelper.RunProcedure_Str("sp_BoxFinished_QD", "@srno|varchar|TB0907003|input;@cartonbarcode|varchar|TB0907003-1347|input;@sErr|varchar||output")
        'If msg <> "" Then
        '    alert("错误:" + vbCrLf + msg)
        '    Return
        'End If

    End Sub

    Private Sub pb_keyBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showHideKeyBoard()
    End Sub

    Private Sub Login_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Try
            If KeyBoardFlag Then
                SipShowIM(0)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_select_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_select.Click
        Dim confirmIP As String = ""
        Dim fm As frm_SysSetting = New frm_SysSetting()
        fm.ShowDialog()
        tb_svrIP.Text = MS_SVR_IP
    End Sub

    Private Sub pb_keyBoard_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pb_keyBoard.Click
        showHideKeyBoard()
    End Sub
End Class