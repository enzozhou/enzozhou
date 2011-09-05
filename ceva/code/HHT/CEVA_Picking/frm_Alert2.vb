Public Class frm_Alert2
    Public pct As String = ""
    Private Sub btn_rtn_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rtn.Click
        Me.Close()
    End Sub

    Private Sub frm_Alert2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        ll_info.Text = "当前电量:" + pct + "%"
    End Sub

End Class