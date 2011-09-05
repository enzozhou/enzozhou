Imports COMExpress.Windows.Forms

Public Class frmObjectModal
    Inherits CXListForm
	Implements IPrintableForm
	
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.?
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected OverLoads Overrides Sub Dispose(ByVal disposing As Boolean)
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
    Friend WithEvents DataGrid1 As YTUI.DataGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents tbMain As ToolbarEx
	Friend WithEvents imlToolbar As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.DataGrid1 = New YTUI.DataGrid()
        Me.tbMain = New YTUI.ToolbarEx()
        Me.imlToolbar = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGrid1
        '
        Me.DataGrid1.Cursor = System.Windows.Forms.Cursors.Default
        Me.DataGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGrid1.Editable = True
        Me.DataGrid1.Location = New System.Drawing.Point(0, 39)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(456, 265)
        Me.DataGrid1.TabIndex = 1 
        '
        'tbMain
        '
        Me.tbMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbMain.DropDownArrows = True
        Me.tbMain.ImageList = Me.imlToolbar
        Me.tbMain.Name = "tbMain"
        Me.tbMain.ShowToolTips = True
        Me.tbMain.Size = New System.Drawing.Size(526, 39)
        Me.tbMain.TabIndex = 2
        Me.tbMain.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
        '
        'imlToolbar
        '
        Me.imlToolbar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlToolbar.ImageSize = New System.Drawing.Size(16, 16)
        Me.imlToolbar.TransparentColor = System.Drawing.Color.Magenta
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCancel, Me.cmdOK})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 317)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(456, 40)
        Me.Panel1.TabIndex = 4
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(105, 8)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(80, 24)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "&Cancel"
        '
        'cmdOK
        '
        Me.cmdOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdOK.Location = New System.Drawing.Point(9, 8)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(80, 24)
        Me.cmdOK.TabIndex = 6
        Me.cmdOK.Text = "&OK"
        '
        'frmObjectModal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(456, 357)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.DataGrid1 , Me.tbMain })
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.ShowInTaskbar = False
        Me.Name = "frmObjectModal"
        Me.Text = "frmObjectModal"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " COM Express generated code "

	Private mTopLeft As Point, mBottomRight As Point
	
    Public OverLoads Sub Initialize( _
        ByVal objApp As IWindowsAppManager, _
        ByVal strObjectName As String, _
        ByVal BoundProperty As String, _
        ByVal ReplaceProperty As String, _
        ByVal TopLeft As System.Drawing.Point, _
        ByVal BottomRight As System.Drawing.Point, _
        ByRef vntReturn() As Object, _
        ByVal _filters As COMExpress.BusinessObject.Filters.CXFilters)

        Me.Initialize(objApp, objApp.TypeFromString(strObjectName), _filters, _
            objApp.GetLayout.CXObjectLays.Item(strObjectName).StartupMode = COMExpress.UserInterface.Layout.CXStartupMode.spmSearch)
        
		ToolbarHelper.InitializeToolbarService(MainForm, tbMain)
        Me.tbMain.StartService(Me)
        Me.DataGrid1.FindGridRow(BoundProperty, vntReturn(0))
        mTopLeft = TopLeft
        mBottomRight = BottomRight
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    End Sub

    Public Overrides ReadOnly Property GridControl() As COMExpress.Windows.Forms.IGrid
        Get
            Return Me.DataGrid1
        End Get
    End Property
    
    Public Overrides ReadOnly Property ReportViewer() As Object Implements IPrintableForm.ReportViewer
        Get
        End Get
    End Property
    
    Public Overrides Sub Edit()
		'do not bring up form editor
    End Sub
    
    Private Sub FormOnError(ByVal sender As Object, ByVal e As FormExceptionEventArgs) Handles MyBase.OnError
        Dim ex As FormExceptionEventArgs = e
        ErrorMsg(ex.Exception, ex.ClassType, ex.Routine)
    End Sub
    
    Protected Overrides Sub OnActivated(ByVal e As System.EventArgs)
        MyBase.OnActivated(e)
		If Not Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None Then Return
		
        Dim pt As New Point
        If mBottomRight.X - Me.Size.Width > 0 Then
            pt.X = mBottomRight.X - Me.Size.Width
        Else
            pt.X = mTopLeft.X
        End If
        If mBottomRight.Y + Me.Size.Height <= Screen.PrimaryScreen.Bounds.Height Then
            pt.Y = mBottomRight.Y
        Else
            pt.Y = mTopLeft.Y - Me.Size.Height
        End If
        Me.DesktopLocation = pt
    End Sub
    
    Private Sub Panel1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
    	If Not Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None Then Return
        ControlPaint.DrawBorder3D(e.Graphics, Panel1.DisplayRectangle, Border3DStyle.Raised)
    End Sub
    
    Protected Overrides Function IsButtonHidden(ByVal ToolKey As String) As Boolean
        Select Case ToolKey
            Case "Main", "Quit", "MainBar", "Print", "FINDBar", "Form", "FORMBar", "Close", "CLOSEBar", "DBBar"
                Return True
            Case Else
                Return MyBase.IsButtonHidden(ToolKey)
        End Select
    End Function

    Public Overrides ReadOnly Property GetToolbarService() As COMExpress.Windows.Forms.IToolbarService
        Get
            Return Me.tbMain
        End Get
    End Property

    Protected Overrides ReadOnly Property ShowQuickLaunch() As Boolean
        Get
            Return False
        End Get
    End Property
#End Region

#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region


