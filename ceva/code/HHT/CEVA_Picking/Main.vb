Imports System.IO
Imports System.Diagnostics
Imports System.Reflection
Imports System
Imports System.Data

Public Class Main

    Private WithEvents MyPowerManager As PowerManagement
    Public loginFlag As Boolean = False
    Dim cf As ConfigurationFile

    ' Power event delegate. Invokes the UpdateGUI delegate.
    Private Sub MyPowerManager_PowerNotify(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyPowerManager.PowerNotify
        ' We are not in the UI thread so we need to Invoke to get there
        ' Unfortunately we cannot pass arguements across the thread boundary
        ' as Me is a limitation of the CF
        Me.Invoke(New EventHandler(AddressOf Me.MyPowerManager_UpdateGUI))
    End Sub

    ''' <summary>
    ''' ---------------------------------------------------------------------------
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer2.Enabled = False
        Me.Text = Appcenter_name
        Me.WindowState = FormWindowState.Maximized
        p0.Dock = DockStyle.Fill
        p1.Dock = DockStyle.Fill
        Try
            '载入配置文件..
            cf = New ConfigurationFile()
            'Dim Svr_IP As String = cf.readConfig("Svr_IP")
            Dim Svr_IP As String = cf.GetXMLConfig("configuration", "Svr_IP")
            MS_SVR_IP = Svr_IP
            'MS_SVR_PORT = cf.GetXMLConfig("configuration", "port")

            '得到web service的引用:
            'Svr_IP = MS_SVR_IP + "," + MS_SVR_PORT
            Dim svrAddress As String = Microsoft.VisualBasic.Replace(M_WEBServiceURL, "@Svr_IP", Svr_IP)
            MSV1 = New RFWebService.Service1()
            MSV1.Url = svrAddress

            '首先检查程序是否注册过了：
            If Not mySys.CheckRegister() Then
                Dim fmR As frmReg = New frmReg
                fmR.ShowDialog()
                ShowWindow(FindWindow("HHTaskBar", Nothing), SW_SHOW) 'SHOW
                Me.Close() '要求重新启动程序
                Return
            End If

            '登录控制
            loginFlag = False
            Dim fm As Login = New Login()
            fm.Owner = Me
            fm.ref_Main = Me
            fm.ShowDialog()
            If Not loginFlag Then
                Me.Close()
                Return
            End If

            Cursor.Current = Cursors.WaitCursor
            MyPowerManager = New PowerManagement()
            MyPowerManager.EnableNotifications()

            ' Get the current power state.
            Dim systemStateName As Text.StringBuilder = New Text.StringBuilder(20)
            Dim systemState As PowerManagement.SystemPowerStates
            Dim nError As Integer = MyPowerManager.GetSystemPowerState(systemStateName, systemState)

            'Timer_PW.Enabled = True
            Me.WindowState = FormWindowState.Maximized
            Me.Text = Appcenter_name
            Me.WindowState = FormWindowState.Maximized

            p0.Dock = DockStyle.Fill
            p0.Visible = True
            p1.Visible = False
            p0.Location = New Point(0, 0)
            p1.Location = New Point(0, 0)

            ''得到程序运行路径：
            ''【1】startPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\"
            ''【2】Directory.GetCurrentDirectory
            ''【3】只有使用反射：
            'startPath = Path.GetDirectoryName([Assembly].GetExecutingAssembly().GetName.CodeBase)
            'M_setupini = startPath & "\setup.ini"
            'TMPBINID_FILE = startPath & TMPBINID_FILE
            'M_BoxLab1Path = startPath & "\" & M_BoxLab1Path
            'iniApp() '初始化配置参数信息

            AssInfo = New AssemblyInfo
            ll_version.Text = "版本:" + AssInfo.Version

            Try
                '取得系统时间：Dim str As String = M_Service1.getSvrTime()
                Dim dt As String = MSV1.get_svr_datetime() '2010-09-10 12:20:30
                Dim ls_day As String = Mid(dt, 1, 10)
                Dim ls_time As String = Mid(dt, 12, 8)
                If ls_time.StartsWith(":") Then
                    ls_time = "00" + ls_time
                ElseIf ls_time.StartsWith("0:") Then
                    ls_time = "0" + ls_time
                End If

                Dim obj As String = ls_day & " " & ls_time
                If dt.Trim <> "" Then
                    Today = ls_day
                    TimeOfDay = ls_time
                    '设置成功
                Else
                    alert("Web 服务:" + vbCrLf + MSV1.Url + vbCrLf + "无法连通！")
                    Application.Exit()
                    Me.Close()
                    Return
                End If
            Catch ex As Exception
                alert("无法连接到网络服务器！" + vbCrLf + ex.Message)
                Application.Exit()
                Return
            Finally
                Cursor.Current = Cursors.Default
            End Try


            ' ''Try
            ' ''    Application.DoEvents()
            ' ''    If System.IO.File.Exists("\Application\SCANWEDGE.EXE") Then 'AppPath() & "\LiveUpdate.exe"
            ' ''        Shell("\Application\SCANWEDGE.EXE", "", False)
            ' ''    End If
            ' ''    System.Threading.Thread.Sleep(500)
            ' ''Catch ex As Exception
            ' ''End Try

            Try
                ''权限设置
                'readQX()
                '最后，启动扫描头
                '如果外部ScanWedge正在运行，则关闭之...
                mySymbolScancer = New SymbolScancer()
                mySymbolScancer.StartScan()
            Catch ex As Exception
                'alert("无法启动扫描头：" + vbCrLf + ex.Message)
                'Application.Exit()
                'Return
            End Try

            '电量预警
            Timer2.Enabled = True
            tb_msg1.Text = "[" + MDI_userid + "]" + MDI_userName
        Catch ex As Exception
            alert(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '''' <summary>
    '''' 读取权限
    '''' sp_getHHTQX  @uid,@sErr 
    '''' </summary>
    '''' <remarks></remarks>
    'Private Sub readQX()
    '    Dim sErr As String = ""
    '    Dim ds As DataSet = MSV1.RunProcedure_DS(WSSN, "sp_getHHTQX", "@uid|nvarchar|" + MDI_userid + "|input;@sErr|nvarchar||output", sErr)
    '    If sErr.Trim <> "" Then
    '        alert(sErr)
    '        Return
    '    End If

    '    Dim ls_BoxPT, ls_MakeBox, ls_RCV, ls_SKUPT, ls_QueryStock As String
    '    For Index As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '        If ds.Tables(0).Rows(Index)("winname").ToString.Trim = "HHT_BoxPT" Then
    '            ls_BoxPT = ds.Tables(0).Rows(Index)("flag").ToString().Trim
    '            If ls_BoxPT = "1" Then
    '                ' HHT_BoxPT.Enabled = True
    '            Else
    '                ' HHT_BoxPT.Enabled = False
    '            End If
    '        End If

    '        If ds.Tables(0).Rows(Index)("winname").ToString.Trim = "HHT_MakeBox" Then
    '            ls_MakeBox = ds.Tables(0).Rows(Index)("flag").ToString().Trim
    '            If ls_MakeBox = "1" Then
    '                'HHT_MakeBox.Enabled = True
    '            Else
    '                'HHT_MakeBox.Enabled = False
    '            End If
    '        End If

    '        If ds.Tables(0).Rows(Index)("winname").ToString.Trim = "HHT_RCV" Then
    '            ls_RCV = ds.Tables(0).Rows(Index)("flag").ToString().Trim
    '            If ls_RCV = "1" Then
    '                'HHT_RCV.Enabled = True
    '            Else
    '                'HHT_RCV.Enabled = False
    '            End If
    '        End If

    '        If ds.Tables(0).Rows(Index)("winname").ToString.Trim = "HHT_SKUPT" Then
    '            ls_SKUPT = ds.Tables(0).Rows(Index)("flag").ToString().Trim
    '            If ls_SKUPT = "1" Then
    '                'HHT_SKUPT.Enabled = True
    '            Else
    '                'HHT_SKUPT.Enabled = False
    '            End If
    '        End If

    '        If ds.Tables(0).Rows(Index)("winname").ToString.Trim = "HHT_QueryStock" Then
    '            ls_QueryStock = ds.Tables(0).Rows(Index)("flag").ToString().Trim
    '            If ls_QueryStock = "1" Then
    '                'HHT_QueryStock.Enabled = True
    '            Else
    '                'HHT_QueryStock.Enabled = False
    '            End If
    '        End If

    '    Next
    'End Sub


    ' UpdateGUI delegate. Processes and display the power information
    ' provided by the power management on the system.
    Private BatteryLifePercent As Integer = 0
    Private Sub MyPowerManager_UpdateGUI(ByVal sender As Object, ByVal e As System.EventArgs)
        'Get the information
        Dim powerInfo As PowerManagement.PowerInfo = MyPowerManager.GetNextPowerInfo

        'Determine if we are on battery or AC
        If (powerInfo.Message.Equals(Convert.ToUInt32(PowerManagement.MessageTypes.Status))) Then
            If powerInfo.ACLineStatus = PowerManagement.ACLineStatus.OnLine Then
                'batteryPercentLabel.Text = "充电"
            Else
                'batteryPercentLabel.Text = "100%"
            End If
            'Update Main Battery information
            ProgressBar1.Value = powerInfo.BatteryLifePercent
            BatteryLifePercent = powerInfo.BatteryLifePercent
            ll_pcnt.Text = ProgressBar1.Value.ToString() + "%" 'powerInfo.BatteryLifePercent
            
            'batteryPercentLabel.Text = powerInfo.BatteryLifePercent.ToString + "%"
        Else
            If powerInfo.Flags.Equals(Convert.ToUInt32(PowerManagement.SystemPowerStates.Suspend)) Then
                'The notification of the loss of power does not actually occur 
                'until immediately after it is back.
                'statusBar1.Text = "Device resumed from a suspend. "
            End If
        End If
    End Sub



    Private Sub Main_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If Not loginFlag Then
            e.Cancel = False
            Return
        End If

        If ask("是否确定要退出程序？确认请按【是】") = MsgBoxResult.Yes Then
            MyPowerManager.Dispose()
            MyPowerManager = Nothing
            MSV1.Dispose()
            Timer1.Enabled = False
            mySymbolScancer.StopScan()
            GC.Collect()
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    '''' <summary>
    '''' 初始化引用程序的参数;
    '''' </summary>
    '''' <remarks></remarks>
    'Private Sub iniApp()
    '    Dim ls_line As String = ""
    '    Dim sr As StreamReader = Nothing
    '    Dim col_value As String = ""
    '    Dim equal_pos As Integer = 0
    '    Dim keys As String = ""
    '    Try
    '        If File.Exists(M_setupini) Then
    '        Else
    '            alert("文件:" + M_setupini + "不存在！")
    '            Application.Exit()
    '        End If
    '        sr = New StreamReader(M_setupini)
    '        Do
    '            ls_line = sr.ReadLine()
    '            If ls_line = Nothing Then
    '                Exit Do
    '            End If

    '            If Mid(ls_line, 1, 2) = "--" Then
    '                Continue Do '--掠过没有"="等号的行
    '            End If

    '            equal_pos = ls_line.IndexOf("=")
    '            keys = ls_line.Substring(0, equal_pos)
    '            col_value = ls_line.Substring(equal_pos + 1).Trim
    '            If equal_pos <= 0 Then
    '                Continue Do '--掠过没有"="等号的行
    '            End If

    '            If keys = "WEBServiceURL" Then
    '                M_WEBServiceURL = col_value
    '            End If

    '            If keys = "BlueCom" Then
    '                M_BlueCom = col_value
    '            End If

    '            If keys = "HHTNO" Then
    '                M_HHTNO = col_value
    '            End If

    '            If keys = "MS_mz220_ip" Then
    '                MS_mz220_ip = col_value
    '            End If

    '            If keys = "MS_mz220_port" Then
    '                MS_mz220_port = col_value
    '            End If

    '            If keys = "MS_PTComType" Then
    '                MS_PTComType = col_value
    '            End If
    '        Loop Until ls_line Is Nothing
    '        sr.Close()
    '    Catch ex As Exception
    '        alert(ex.Message)
    '    Finally

    '    End Try
    'End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ls_time As String = MSV1.get_svr_datetime()
        msg1(ls_time)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim str As String = MF_returnNowStr()
            timeStatus.Text = str
        Catch ex As Exception
            timeStatus.Text = ""
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        p0.Visible = False
        'pnl_query.Visible = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        p1.Visible = True
        'pnl_query.Visible = False
    End Sub

    Private Sub PictureBox5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        If ask("是否挂起设备,进入节电模式？") = MsgBoxResult.Yes Then
            'Suspend the device
            Dim nError As Integer = MyPowerManager.SetSystemPowerState(PowerManagement.SystemPowerStates.Suspend)
            If Not (nError = 0) Then
                alert("Suspend Failed. Error: " + nError.ToString)
            End If
        End If
    End Sub

    Private Sub PB_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_Exit.Click
         Me.Close()
    End Sub

    Private Sub PB_Inquire_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB_Inquire.Click
        Dim fm As frm_Picklist = New frm_Picklist()
        fm.ShowDialog()
    End Sub

    Private Sub pictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictureBox1.Click
        p1.Visible = True
        p0.Visible = False
    End Sub

    Private Sub btn_rtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rtn.Click
        p1.Visible = False
        p0.Visible = True
    End Sub

    Private Sub pictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictureBox2.Click
        Dim fm As frm_Move = New frm_Move
        fm.ShowDialog()
    End Sub

    Private Sub pb_keyBoard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        showHideKeyBoard()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim fm As frm_Query = New frm_Query()
        fm.fs_type = "01"
        fm.ShowDialog()
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Dim fm As frm_Query = New frm_Query()
        fm.fs_type = "02"
        fm.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fm As frm_Query = New frm_Query()
        fm.fs_type = "03"
        fm.ShowDialog()
    End Sub

    Private asyncOBJ As Object = New Object()

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If BatteryLifePercent <= 10 Then
            Timer2.Enabled = False
            Dim fm As frm_Alert2 = New frm_Alert2()
            fm.pct = BatteryLifePercent.ToString()
            fm.ShowDialog()
            Timer2.Enabled = True
        End If
    End Sub
End Class
