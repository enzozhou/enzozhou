Public Class frm_SysSetting

    Private Sub btn_rtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rtn.Click
        Me.Close()
    End Sub

    Private Sub btn_ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ok.Click
        Try
            Dim cf As ConfigurationFile = New ConfigurationFile()
            Dim bl As Boolean = cf.SetXMLConfig("configuration", "Svr_IP", tb_ip.Text)
            If bl Then
                Dim Svr_IP As String = cf.GetXMLConfig("configuration", "Svr_IP")
                If Svr_IP <> tb_ip.Text.Trim Then
                    alert("保存失败,请重试!")
                    Return
                End If
            End If
            'bl = cf.SetXMLConfig("configuration", "port", tb_port.Text)
            cf = Nothing
            MS_SVR_IP = Me.tb_ip.Text.Trim()
            'MS_SVR_PORT = Me.tb_port.Text.Trim()

            '重新设置连接参数..
            Dim new_Svr_IP As String = MS_SVR_IP '+ "," + MS_SVR_PORT
            Dim svrAddress As String = Microsoft.VisualBasic.Replace(M_WEBServiceURL, "@Svr_IP", new_Svr_IP)
            MSV1 = New RFWebService.Service1()
            MSV1.Url = svrAddress

            Me.Close()
        Catch ex As Exception
            alert(ex.Message)
        End Try
    End Sub

    Private Sub frm_SysSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = Appcenter_name
        Try
            Dim cf As ConfigurationFile = New ConfigurationFile()
            Dim Svr_IP As String = cf.GetXMLConfig("configuration", "Svr_IP")
            tb_ip.Text = Svr_IP
            'Dim Svr_PORT As String = cf.GetXMLConfig("configuration", "port")
            'tb_port.Text = Svr_PORT
        Catch ex As Exception
            alert(ex.Message)
        End Try
    End Sub

    Private Sub btn_test_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_test.Click

        '重新设置连接参数..
        Dim new_Svr_IP As String = Me.tb_ip.Text.Trim() '+ "," + Me.tb_port.Text.Trim()
        Dim svrAddress As String = Microsoft.VisualBasic.Replace(M_WEBServiceURL, "@Svr_IP", new_Svr_IP)
        MSV1 = New RFWebService.Service1()
        MSV1.Url = svrAddress

        Dim rtn As String = ""
        Try
            rtn = MSV1.get_svr_datetime()
            If rtn <> "" Then
                msg1("连接成功！")
                Return
            End If
        Catch ex As Exception
            alert(ex.Message)
        End Try
    End Sub
End Class