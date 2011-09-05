Public Class ControlsCombobox
    Inherits System.Windows.Forms.UserControl
    Dim key As Boolean
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
    Friend WithEvents cboAotoText As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cboAotoText = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'cboAotoText
        '
        Me.cboAotoText.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAotoText.Location = New System.Drawing.Point(0, 0)
        Me.cboAotoText.Name = "cboAotoText"
        Me.cboAotoText.Size = New System.Drawing.Size(216, 20)
        Me.cboAotoText.TabIndex = 0
        '
        'ControlsCombobox
        '
        Me.Controls.Add(Me.cboAotoText)
        Me.Name = "ControlsCombobox"
        Me.Size = New System.Drawing.Size(216, 24)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cboAotoText_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAotoText.TextChanged
        Dim combox As ComboBox = CType(sender, ComboBox)
        If combox.DroppedDown = True Then
            combox.DroppedDown = True
        End If
        Dim strTyped As String
        Dim intFoundIndex As Integer
        Dim objFoundItem As Object
        Dim strFoundText As String
        Dim strAppendText As String
        If key = True Then
            strTyped = combox.Text
            intFoundIndex = combox.FindString(strTyped)
            If intFoundIndex >= 0 Then
                objFoundItem = combox.Items(intFoundIndex)
                strFoundText = combox.GetItemText(objFoundItem)
                strAppendText = strFoundText.Substring(strTyped.Length)
                combox.Text = strTyped & strAppendText
                combox.SelectionStart = strTyped.Length
                combox.SelectionLength = strAppendText.Length
            End If
        End If
    End Sub

    Private Sub cboAotoText_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAotoText.KeyUp
        key = True
        Select Case e.KeyCode
            Case Keys.Back, Keys.Left, Keys.Right, Keys.Up, _
                Keys.Delete, Keys.Down, Keys.CapsLock
                key = False
        End Select
    End Sub
    Public Function AutoGetCom(ByVal Com As ComboBox) As String '∏Ò  ªØcombobox
        If Com.SelectedValue = "" And Com.Text.Trim() = "" Then
            AutoGetCom = Com.SelectedValue
        ElseIf Com.SelectedValue <> "" Then
            AutoGetCom = Com.SelectedValue
        ElseIf Com.SelectedValue = "" And Com.Text.Trim() <> "" Then
            AutoGetCom = Com.Text.Trim()
        Else
            AutoGetCom = Com.Text.Trim()
        End If

    End Function
End Class
