Public Class frmPasteValues
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
    Friend WithEvents txtInput As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblinfo As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblinfo = New System.Windows.Forms.Label
        Me.txtInput = New System.Windows.Forms.TextBox
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblinfo
        '
        Me.lblinfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblinfo.Location = New System.Drawing.Point(0, 0)
        Me.lblinfo.Name = "lblinfo"
        Me.lblinfo.Size = New System.Drawing.Size(442, 40)
        Me.lblinfo.TabIndex = 0
        Me.lblinfo.Text = "Input multi-values, you can key-in values with separator [enter,tab,comma]. paste" & _
        " is also supported."
        '
        'txtInput
        '
        Me.txtInput.Location = New System.Drawing.Point(0, 40)
        Me.txtInput.Multiline = True
        Me.txtInput.Name = "txtInput"
        Me.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtInput.Size = New System.Drawing.Size(440, 200)
        Me.txtInput.TabIndex = 1
        Me.txtInput.Text = ""
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(96, 248)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 32)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(288, 248)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 32)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        '
        'frmPasteValues
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(442, 288)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.lblinfo)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPasteValues"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Values Input"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Values As String
    Public CaptionText As String

    Private Function Comma2MultiLine(ByVal str As String) As String
        Dim s As String
        Dim sp() As String
        Dim i As Integer
        sp = Split(str, ",")
        s = ""
        For i = LBound(sp) To UBound(sp)
            If Trim(sp(i)) <> "" Then
                s = s + Trim(sp(i)) + vbCrLf
            End If
        Next
        Return s
    End Function

    Private Function Multiline2Comma(ByVal str As String) As String
        Dim s As String
        Dim sp() As String
        Dim i As Integer
        str = Replace(str, vbLf, "")
        sp = Split(str, vbCr)
        s = ""
        For i = LBound(sp) To UBound(sp)
            If Trim(sp(i)) <> "" Then
                s = s + Trim(sp(i)) + ","
            End If
        Next
        If Microsoft.VisualBasic.Right(s, 1) = "," Then
            s = Microsoft.VisualBasic.Left(s, Len(s) - 1)
        End If
        Return s
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Values = Multiline2Comma(txtInput.Text)
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Function LoadResString(ByVal strID As String, Optional ByVal strDef As String = "") As String
        Dim s As String
        Try
            s = ""

        Catch ex As Exception

        End Try
        If Trim(s) = "" Then
            Return strDef
        Else
            Return s
        End If
    End Function

    Private Sub LoadControlText()
        Dim s As String
        s = LoadResString("frmPasteValuesText", "Input values")
        If Trim(CaptionText) <> "" Then
            s = s + " " + CaptionText
        End If
        Me.Text = s
        Me.lblinfo.Text = LoadResString("frmPasteValuesInfo", lblinfo.Text)
        Me.btnOK.Text = LoadResString("frmPasteValuesOK", btnOK.Text)
        Me.btnClose.Text = LoadResString("frmPasteValuesClose", btnClose.Text)
    End Sub

    Private Sub frmPasteValues_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadControlText()
        txtInput.Text = Comma2MultiLine(Values)
    End Sub
End Class
