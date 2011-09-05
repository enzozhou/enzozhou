Public Class frmDataPreview
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
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents dg As System.Windows.Forms.DataGrid
    Friend WithEvents PanelButton As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnClose = New System.Windows.Forms.Button
        Me.dg = New System.Windows.Forms.DataGrid
        Me.PanelButton = New System.Windows.Forms.Panel
        CType(Me.dg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(480, 8)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(96, 32)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "¹Ø±Õ"
        '
        'dg
        '
        Me.dg.AllowDrop = True
        Me.dg.AllowNavigation = False
        Me.dg.AllowSorting = False
        Me.dg.DataMember = ""
        Me.dg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dg.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dg.Location = New System.Drawing.Point(0, 0)
        Me.dg.Name = "dg"
        Me.dg.ReadOnly = True
        Me.dg.Size = New System.Drawing.Size(592, 334)
        Me.dg.TabIndex = 1
        '
        'PanelButton
        '
        Me.PanelButton.Controls.Add(Me.btnClose)
        Me.PanelButton.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelButton.Location = New System.Drawing.Point(0, 286)
        Me.PanelButton.Name = "PanelButton"
        Me.PanelButton.Size = New System.Drawing.Size(592, 48)
        Me.PanelButton.TabIndex = 2
        '
        'frmDataPreview
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(592, 334)
        Me.Controls.Add(Me.PanelButton)
        Me.Controls.Add(Me.dg)
        Me.Name = "frmDataPreview"
        Me.Text = "Êý¾ÝÔ¤ÀÀ"
        CType(Me.dg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelButton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public mDataSet As DataSet

    Public Property DataSource() As DataSet
        Get
            Return mDataSet
        End Get
        Set(ByVal Value As DataSet)
            mDataSet = Value
        End Set
    End Property

    Private Sub RefreshData()
        If mDataSet Is Nothing Then
            Exit Sub
        End If
        dg.DataSource = mDataSet.Tables(0).DefaultView
    End Sub



    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.Yes
    End Sub

    Private Sub frmDataPreview_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        RefreshData()
    End Sub

    Private Sub frmDataPreview_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetFormResource(Me)
    End Sub
End Class
