Imports YT.BusinessObject

Public Class frmAbout
    Inherits System.Windows.Forms.Form

    ' Reg Key Security Options....
    Const KEY_ALL_ACCESS = &H2003F


    ' Reg Key ROOT Types...
    Const HKEY_LOCAL_MACHINE = &H80000002
    Const ERROR_SUCCESS = 0
    Const REG_SZ = 1                         ' Unicode nul terminated string
    Const REG_DWORD = 4                      ' 32-bit number

    Const gREGKEYSYSINFOLOC = "SOFTWARE\Microsoft\Shared Tools Location"
    Const gREGVALSYSINFOLOC = "MSINFO"
    Const gREGKEYSYSINFO = "SOFTWARE\Microsoft\Shared Tools\MSINFO"
    Const gREGVALSYSINFO = "PATH"

    Private Declare Function RegOpenKeyEx Lib "advapi32" Alias "RegOpenKeyExA" (ByVal hKey As Long, ByVal lpSubKey As String, ByVal ulOptions As Long, ByVal samDesired As Long, ByRef phkResult As Long) As Long
    Private Declare Function RegQueryValueEx Lib "advapi32" Alias "RegQueryValueExA" (ByVal hKey As Long, ByVal lpValueName As String, ByVal lpReserved As Long, ByRef lpType As Long, ByVal lpData As String, ByRef lpcbData As Long) As Long
    Private Declare Function RegCloseKey Lib "advapi32" (ByVal hKey As Long) As Long


#Region " Windows 窗体设计器生成的代码 "

    Public Sub New()
        MyBase.New()

        '该调用是 Windows 窗体设计器所必需的。
        InitializeComponent()

        '在 InitializeComponent() 调用之后添加任何初始化

    End Sub

    '窗体重写 dispose 以清理组件列表。
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改此过程。
    '不要使用代码编辑器修改它。
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdSysInfo As System.Windows.Forms.Button
    Friend WithEvents lblAppTitle As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblForRegion As System.Windows.Forms.Label
    Friend WithEvents lblLicenseTo As System.Windows.Forms.Label
    Protected Friend WithEvents lblProductName As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblWebSite As System.Windows.Forms.Label
    Friend WithEvents lblSystemType As System.Windows.Forms.Label
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents lblLicenseText As System.Windows.Forms.Label
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAbout))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblAppTitle = New System.Windows.Forms.Label
        Me.lblVersion = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblForRegion = New System.Windows.Forms.Label
        Me.lblCopyright = New System.Windows.Forms.Label
        Me.lblWebSite = New System.Windows.Forms.Label
        Me.lblLicenseText = New System.Windows.Forms.Label
        Me.lblLicenseTo = New System.Windows.Forms.Label
        Me.lblWarning = New System.Windows.Forms.Label
        Me.cmdSysInfo = New System.Windows.Forms.Button
        Me.lblProductName = New System.Windows.Forms.Label
        Me.lblSystemType = New System.Windows.Forms.Label
        Me.btnTest = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(16, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(166, 232)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblAppTitle
        '
        Me.lblAppTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAppTitle.Location = New System.Drawing.Point(192, 16)
        Me.lblAppTitle.Name = "lblAppTitle"
        Me.lblAppTitle.Size = New System.Drawing.Size(264, 24)
        Me.lblAppTitle.TabIndex = 1
        Me.lblAppTitle.Text = "Yeart PTS System"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(320, 48)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(84, 18)
        Me.lblVersion.TabIndex = 2
        Me.lblVersion.Text = "Version 1.0.0"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(344, 272)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(96, 24)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "&OK"
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(16, 256)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(424, 8)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'lblForRegion
        '
        Me.lblForRegion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblForRegion.Location = New System.Drawing.Point(256, 72)
        Me.lblForRegion.Name = "lblForRegion"
        Me.lblForRegion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblForRegion.Size = New System.Drawing.Size(184, 16)
        Me.lblForRegion.TabIndex = 5
        Me.lblForRegion.Text = "-"
        Me.lblForRegion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCopyright
        '
        Me.lblCopyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.Location = New System.Drawing.Point(192, 120)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblCopyright.Size = New System.Drawing.Size(256, 16)
        Me.lblCopyright.TabIndex = 6
        Me.lblCopyright.Text = "Copyright 2007 by Schmidt && Co., (H.K.) Ltd."
        '
        'lblWebSite
        '
        Me.lblWebSite.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebSite.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblWebSite.Location = New System.Drawing.Point(192, 136)
        Me.lblWebSite.Name = "lblWebSite"
        Me.lblWebSite.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblWebSite.Size = New System.Drawing.Size(256, 24)
        Me.lblWebSite.TabIndex = 7
        Me.lblWebSite.Text = "http://www.schmidtelectronics.com"
        '
        'lblLicenseText
        '
        Me.lblLicenseText.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicenseText.Location = New System.Drawing.Point(192, 184)
        Me.lblLicenseText.Name = "lblLicenseText"
        Me.lblLicenseText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLicenseText.Size = New System.Drawing.Size(72, 16)
        Me.lblLicenseText.TabIndex = 8
        Me.lblLicenseText.Text = "License to:"
        '
        'lblLicenseTo
        '
        Me.lblLicenseTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLicenseTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLicenseTo.Location = New System.Drawing.Point(192, 208)
        Me.lblLicenseTo.Name = "lblLicenseTo"
        Me.lblLicenseTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblLicenseTo.Size = New System.Drawing.Size(248, 40)
        Me.lblLicenseTo.TabIndex = 9
        Me.lblLicenseTo.Text = "-"
        '
        'lblWarning
        '
        Me.lblWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.Location = New System.Drawing.Point(16, 272)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(320, 56)
        Me.lblWarning.TabIndex = 10
        Me.lblWarning.Text = "Warning: This application software is protected by international copyright law. P" & _
        "lease do not distribute it illegally  in any form and media."
        '
        'cmdSysInfo
        '
        Me.cmdSysInfo.Enabled = False
        Me.cmdSysInfo.Location = New System.Drawing.Point(344, 304)
        Me.cmdSysInfo.Name = "cmdSysInfo"
        Me.cmdSysInfo.Size = New System.Drawing.Size(96, 24)
        Me.cmdSysInfo.TabIndex = 11
        Me.cmdSysInfo.Text = "&System Info..."
        '
        'lblProductName
        '
        Me.lblProductName.AutoSize = True
        Me.lblProductName.BackColor = System.Drawing.Color.Transparent
        Me.lblProductName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductName.ForeColor = System.Drawing.Color.Black
        Me.lblProductName.Location = New System.Drawing.Point(224, 48)
        Me.lblProductName.Name = "lblProductName"
        Me.lblProductName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblProductName.Size = New System.Drawing.Size(38, 18)
        Me.lblProductName.TabIndex = 21
        Me.lblProductName.Text = "YT"
        Me.lblProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblProductName.Visible = False
        '
        'lblSystemType
        '
        Me.lblSystemType.Location = New System.Drawing.Point(248, 96)
        Me.lblSystemType.Name = "lblSystemType"
        Me.lblSystemType.Size = New System.Drawing.Size(192, 16)
        Me.lblSystemType.TabIndex = 22
        Me.lblSystemType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(344, 176)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(96, 24)
        Me.btnTest.TabIndex = 23
        Me.btnTest.Text = "Testing"
        Me.btnTest.Visible = False
        '
        'frmAbout
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(453, 335)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.lblSystemType)
        Me.Controls.Add(Me.lblProductName)
        Me.Controls.Add(Me.cmdSysInfo)
        Me.Controls.Add(Me.lblWarning)
        Me.Controls.Add(Me.lblLicenseTo)
        Me.Controls.Add(Me.lblLicenseText)
        Me.Controls.Add(Me.lblWebSite)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.lblForRegion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblAppTitle)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About YT"
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadControlText()
        Me.lblVersion.Text = GetFieldCaption("ID_cap_frmAbout_lblVersion", True) & GetCurrentVersion()

        Dim strType As String
        strType = GetSystemTypeOption()
        lblSystemType.Text = Trim(strType)
        'If UCase(strType) = UCase("[BIT]") Then
        '    btnTest.Visible = True
        'Else
        '    btnTest.Visible = False
        'End If
    End Sub



    Private Sub lblWebSite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblWebSite.Click
        Dim lngRtnVal As Long

        'status = WinExec("Start " & labWebSite.Caption, 0)    ' call default browser and open web site
        'lngRtnVal = ShellExecute(Me.Handle, "open", lblWebSite.Text, "", "", 1)
    End Sub


    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Me.DialogResult = DialogResult.OK
        'Dim test As New frmInterfaceSelect
        'test.Show()
    End Sub

    Private Sub cmdSysInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSysInfo.Click
        On Error GoTo SysInfoErr


        Dim rc As Long
        Dim SysInfoPath As String


        ' Try To Get System Info Program Path\Name From Registry...
        If GetKeyValue(HKEY_LOCAL_MACHINE, gREGKEYSYSINFO, gREGVALSYSINFO, SysInfoPath) Then
            ' Try To Get System Info Program Path Only From Registry...
        ElseIf GetKeyValue(HKEY_LOCAL_MACHINE, gREGKEYSYSINFOLOC, gREGVALSYSINFOLOC, SysInfoPath) Then
            ' Validate Existance Of Known 32 Bit File Version
            If (Dir(SysInfoPath & "\MSINFO32.EXE") <> "") Then
                SysInfoPath = SysInfoPath & "\MSINFO32.EXE"

                ' Error - File Can Not Be Found...
            Else
                GoTo SysInfoErr
            End If
            ' Error - Registry Entry Can Not Be Found...
        Else
            GoTo SysInfoErr
        End If


        Call Shell(SysInfoPath, vbNormalFocus)


        Exit Sub
SysInfoErr:
        MsgBox("System Information Is Unavailable At This Time", vbOKOnly)
    End Sub


    Private Function GetKeyValue(ByVal KeyRoot As Long, ByVal KeyName As String, ByVal SubKeyRef As String, ByRef KeyVal As String) As Boolean
        Dim i As Long                                           ' Loop Counter
        Dim rc As Long                                          ' Return Code
        Dim hKey As Long                                        ' Handle To An Open Registry Key
        Dim hDepth As Long                                      '
        Dim KeyValType As Long                                  ' Data Type Of A Registry Key
        Dim tmpVal As String                                    ' Tempory Storage For A Registry Key Value
        Dim KeyValSize As Long                                  ' Size Of Registry Key Variable
        '------------------------------------------------------------
        ' Open RegKey Under KeyRoot {HKEY_LOCAL_MACHINE...}
        '------------------------------------------------------------
        rc = RegOpenKeyEx(KeyRoot, KeyName, 0, KEY_ALL_ACCESS, hKey) ' Open Registry Key


        If (rc <> ERROR_SUCCESS) Then GoTo GetKeyError ' Handle Error...


        tmpVal = Space(1024)                             ' Allocate Variable Space
        KeyValSize = 1024                                       ' Mark Variable Size


        '------------------------------------------------------------
        ' Retrieve Registry Key Value...
        '------------------------------------------------------------
        rc = RegQueryValueEx(hKey, SubKeyRef, 0, KeyValType, tmpVal, KeyValSize)    ' Get/Create Key Value


        If (rc <> ERROR_SUCCESS) Then GoTo GetKeyError ' Handle Errors


        tmpVal = Mid(tmpVal, 1, InStr(tmpVal, Chr(0)) - 1)
        '------------------------------------------------------------
        ' Determine Key Value Type For Conversion...
        '------------------------------------------------------------
        Select Case KeyValType                                  ' Search Data Types...
            Case REG_SZ                                             ' String Registry Key Data Type
                KeyVal = tmpVal                                     ' Copy String Value
            Case REG_DWORD                                          ' Double Word Registry Key Data Type
                For i = Len(tmpVal) To 1 Step -1                    ' Convert Each Bit
                    KeyVal = KeyVal + Hex(Asc(Mid(tmpVal, i, 1)))   ' Build Value Char. By Char.
                Next
                KeyVal = Format$("&h" + KeyVal)                     ' Convert Double Word To String
        End Select


        GetKeyValue = True                                      ' Return Success
        rc = RegCloseKey(hKey)                                  ' Close Registry Key
        Exit Function                                           ' Exit

GetKeyError:  ' Cleanup After An Error Has Occured...
        KeyVal = ""                                             ' Set Return Val To Empty String
        GetKeyValue = False                                     ' Return Failure
        rc = RegCloseKey(hKey)                                  ' Close Registry Key
    End Function



    Private Sub lblWebSite_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblWebSite.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lblWebSite_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblWebSite.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub LoadControlText()
        SetTextResource("ID_cap_frmAbout", Me.lblAppTitle)
        SetTextResource("ID_cap_frmAbout", Me.lblProductName)
        SetTextResource("ID_cap_frmAbout", Me.lblForRegion)
        SetTextResource("ID_cap_frmAbout", Me.lblCopyright)
        SetTextResource("ID_cap_frmAbout", Me.lblLicenseText)
        SetTextResource("ID_cap_frmAbout", Me.lblLicenseTo)
        SetTextResource("ID_cap_frmAbout", Me.lblWarning)
        SetTextResource("ID_cap_frmAbout", Me.cmdSysInfo)
        SetTextResource("ID_cap_frmAbout", Me.cmdOK)
        Me.Text = GetFieldCaption("ID_cap_frmAbout_Title", True)
    End Sub

    Private Function SetLblTxt(ByVal lbl As Control, ByVal fieldName As String)
        lbl.Text = GetFieldCaption(fieldName, True)
    End Function

    'Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
    '    Me.DialogResult = DialogResult.Ignore
    'End Sub

    Private Sub frmAbout_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        Me.lblVersion.Left = lblForRegion.Left + lblForRegion.Width - lblVersion.Width
        lblProductName.Left = Me.lblVersion.Left - 12 - lblProductName.Width
    End Sub


End Class
