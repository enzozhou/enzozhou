Public Class FileSelection
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents btnBrowsePath As System.Windows.Forms.Button
    Friend WithEvents cboFileType As System.Windows.Forms.ComboBox
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents lblFilename As System.Windows.Forms.Label
    Friend WithEvents lblFileType As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnBrowsePath = New System.Windows.Forms.Button
        Me.cboFileType = New System.Windows.Forms.ComboBox
        Me.txtPath = New System.Windows.Forms.TextBox
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.lblPath = New System.Windows.Forms.Label
        Me.lblFilename = New System.Windows.Forms.Label
        Me.lblFileType = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.SuspendLayout()
        '
        'btnBrowsePath
        '
        Me.btnBrowsePath.Location = New System.Drawing.Point(400, 56)
        Me.btnBrowsePath.Name = "btnBrowsePath"
        Me.btnBrowsePath.Size = New System.Drawing.Size(20, 20)
        Me.btnBrowsePath.TabIndex = 21
        Me.btnBrowsePath.Text = "..."
        '
        'cboFileType
        '
        Me.cboFileType.Items.AddRange(New Object() {"XLS - Excel Format"})
        Me.cboFileType.Location = New System.Drawing.Point(80, 0)
        Me.cboFileType.Name = "cboFileType"
        Me.cboFileType.Size = New System.Drawing.Size(344, 21)
        Me.cboFileType.TabIndex = 20
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(80, 56)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(320, 20)
        Me.txtPath.TabIndex = 19
        Me.txtPath.Text = "C:\"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(80, 32)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(344, 20)
        Me.txtFileName.TabIndex = 18
        Me.txtFileName.Text = "保留品出货查询报表"
        '
        'lblPath
        '
        Me.lblPath.Location = New System.Drawing.Point(0, 56)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(72, 23)
        Me.lblPath.TabIndex = 17
        Me.lblPath.Text = "存放路径:"
        '
        'lblFilename
        '
        Me.lblFilename.Location = New System.Drawing.Point(0, 32)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(80, 23)
        Me.lblFilename.TabIndex = 16
        Me.lblFilename.Text = "文件名"
        '
        'lblFileType
        '
        Me.lblFileType.Location = New System.Drawing.Point(0, 0)
        Me.lblFileType.Name = "lblFileType"
        Me.lblFileType.Size = New System.Drawing.Size(72, 23)
        Me.lblFileType.TabIndex = 15
        Me.lblFileType.Text = "文件类型"
        '
        'FileSelection
        '
        Me.Controls.Add(Me.btnBrowsePath)
        Me.Controls.Add(Me.cboFileType)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.lblFileType)
        Me.Name = "FileSelection"
        Me.Size = New System.Drawing.Size(424, 80)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnBrowsePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowsePath.Click
        If Trim(txtPath.Text) <> "" Then
            FolderBrowserDialog1.SelectedPath = txtPath.Text
        End If

        If FolderBrowserDialog1.ShowDialog(Me.ParentForm) <> DialogResult.OK Then
            Return
        End If
        txtPath.Text = FolderBrowserDialog1.SelectedPath
    End Sub
End Class
