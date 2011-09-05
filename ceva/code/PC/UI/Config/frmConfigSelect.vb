Public Class frmConfigSelect
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblSelectTip As System.Windows.Forms.Label
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents TimerClose As System.Windows.Forms.Timer
    Friend WithEvents lstConfig As System.Windows.Forms.ListBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.lstConfig = New System.Windows.Forms.ListBox
        Me.lblSelectTip = New System.Windows.Forms.Label
        Me.btnSelect = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.TimerClose = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lstConfig
        '
        Me.lstConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstConfig.ItemHeight = 20
        Me.lstConfig.Location = New System.Drawing.Point(8, 32)
        Me.lstConfig.Name = "lstConfig"
        Me.lstConfig.Size = New System.Drawing.Size(272, 124)
        Me.lstConfig.TabIndex = 0
        '
        'lblSelectTip
        '
        Me.lblSelectTip.Location = New System.Drawing.Point(8, 8)
        Me.lblSelectTip.Name = "lblSelectTip"
        Me.lblSelectTip.Size = New System.Drawing.Size(264, 23)
        Me.lblSelectTip.TabIndex = 1
        Me.lblSelectTip.Text = "Please select system to connect:"
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(24, 168)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 32)
        Me.btnSelect.TabIndex = 2
        Me.btnSelect.Text = "Select"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(192, 168)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 32)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        '
        'TimerClose
        '
        '
        'frmConfigSelect
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(288, 206)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.lblSelectTip)
        Me.Controls.Add(Me.lstConfig)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmConfigSelect"
        Me.Text = "Select System"
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private mobj As New ConfigHelper


    Private Sub frmConfigSelect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetFormResource(Me)
        Dim objCol As Collection
        Dim strFile As String
        lstConfig.Items.Clear()
        strFile = GetConfigPath()
        If Trim(strFile) = "" Then
            Message("ID_msg_NoSystemConfigFile", True, "无系统选择配置.")
            TimerClose.Interval = 200
            TimerClose.Enabled = True
            Exit Sub
        End If
        mobj.LoadConfig(strFile + "\" + ConfigFile)
        objCol = mobj.Configs
        Dim i As Integer
        For i = 1 To objCol.Count
            lstConfig.Items.Add(CType(objCol.Item(i), ConfigHelper.ConfigItem).Desciption)
        Next
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub



    Private Sub TimerClose_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerClose.Tick
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim strPath As String
        Dim strFile As String
        Dim index As Integer
        Dim strMessage As String
        index = Me.lstConfig.SelectedIndex
        If (index < 0) Then
            Message("ID_msg_frmConfigSelect_PleaseSelect", True, "请选择")
            Exit Sub
        End If
        strPath = GetConfigPath()
        If Trim(strPath) = "" Then
            Exit Sub
        End If
        Dim item As ConfigHelper.ConfigItem
        item = CType(mobj.Configs.Item(index + 1), ConfigHelper.ConfigItem)
        strFile = strPath + "\" + mobj.Path + "\" + item.PCFile
        If System.IO.File.Exists(strFile) = False Then
            strMessage = PublicResource.LoadResString("ID_msg_frmConfigSelect_FileNotExist", "文件不存在")
            Message(strMessage + vbCrLf + strFile, False)
            Exit Sub
        End If
        strFile = strPath + "\" + mobj.Path + "\" + item.RFFile
        If System.IO.File.Exists(strFile) = False Then
            strMessage = PublicResource.LoadResString("ID_msg_frmConfigSelect_FileNotExist", "文件不存在")
            Message(strMessage + vbCrLf + strFile, False)
            Exit Sub
        End If
        Try
            strFile = strPath + "\" + mobj.Path + "\" + item.PCFile
            System.IO.File.Copy(strFile, Application.StartupPath + "\YT System.exe.config", True)
            strFile = strPath + "\" + mobj.Path + "\" + item.RFFile
            System.IO.File.Copy(strFile, Application.StartupPath + "\YTRF.exe.config", True)
            Me.DialogResult = DialogResult.Yes
        Catch ex As Exception
            ErrorMsg(ex, Me.GetType, "btnSelect_Click")
        End Try
    End Sub

End Class
