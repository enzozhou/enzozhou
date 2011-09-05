Imports System.Windows.Forms
Imports COMExpress.BusinessObject
Imports COMExpress.Windows.Forms
Imports COMExpress.UserInterface.Layout

Public Class Switchboard
    Inherits TreeView
    Implements ISwitchboardService

    Private mobjApp As IWindowsAppManager
    Private mobjKeys As Hashtable
    Private mobjHost As ISwitchboardHost

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

#End Region

#Region "Methods"

    Private Sub Switchboard_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
        Dim pt As Point = Me.PointToClient(Cursor.Current.Position)
        Dim node As TreeNode = Me.GetNodeAt(pt)
        If Not node Is Nothing Then
            If Not Me.SelectedNode Is node Then Me.SelectedNode = node
            mobjHost.LoadObject(CType(node.Tag, String))
        End If
    End Sub

#End Region

#Region "ISwitchboardService Implementation"

    Public Sub AddGroup(ByVal Key As String, ByVal Caption As String, ByVal Img As Object, ByVal UseLargeImage As Boolean) Implements COMExpress.Windows.Forms.ISwitchboardService.AddGroup
        Dim Node As TreeNode
        Node = Nodes.Add(Caption)

        mobjKeys.Add(Key, Node.Index + 1)
        With Node
            If Not Img Is Nothing Then
                Me.ImageList.Images.Add(Img)
                .ImageIndex = Me.ImageList.Images.Count - 1
            Else
                .ImageIndex = 0
            End If
            .SelectedImageIndex = .ImageIndex
            mobjHost.OnItemAdded(Key, Caption, Img, "")
        End With
    End Sub

    Public Sub AddGroupItem(ByVal Key As String, ByVal Caption As String, ByVal Img As Object, ByVal ParentKey As String) Implements COMExpress.Windows.Forms.ISwitchboardService.AddGroupItem
        Dim Node As TreeNode = New TreeNode(Caption)

        mobjKeys.Add(Key, Node.Index + 1)
        If Not Img Is Nothing Then
            Me.ImageList.Images.Add(CType(Img, Image))
            Node.ImageIndex = Me.ImageList.Images.Count - 1
            Node.SelectedImageIndex = Node.ImageIndex
        Else
            Node.ImageIndex = 0
            Node.SelectedImageIndex = Node.ImageIndex
        End If
        Node.ForeColor = System.Drawing.Color.Navy
        Node.Tag = Key
        Dim ParentNode As TreeNode = Me.Nodes(mobjKeys(ParentKey) - 1)
        ParentNode.Nodes.Add(Node)
        mobjHost.OnItemAdded(Key, Caption, Me.ImageList.Images(Node.ImageIndex), ParentKey)
    End Sub

    Public Sub AfterInitialization() Implements COMExpress.Windows.Forms.ISwitchboardService.AfterInitialization
        Me.ExpandAll()
        Me.ResumeLayout()
    End Sub

    Public Sub BeforeInitialization(ByVal objSwitchboardHost As COMExpress.Windows.Forms.ISwitchboardHost, ByVal objApp As COMExpress.Windows.Forms.IWindowsAppManager) Implements COMExpress.Windows.Forms.ISwitchboardService.BeforeInitialization
        mobjKeys = New Hashtable
        mobjApp = objApp
        mobjHost = objSwitchboardHost

        With Me
            .ShowPlusMinus = False
            .ShowRootLines = False
        End With

        With Me.ImageList
            .ColorDepth = ColorDepth.Depth32Bit
            .TransparentColor = System.Drawing.Color.Magenta
            .Images.Clear()
            .Images.Add(mobjApp.LoadResIcon("ID_Menu"))
        End With
    End Sub

    Public Function IsGroupExisted(ByVal Key As String) As Boolean Implements COMExpress.Windows.Forms.ISwitchboardService.IsGroupExisted
        Dim btnGrp As TreeNode
        Try
            btnGrp = Me.Nodes.Item(mobjKeys(Key) - 1)
            Return (Not btnGrp Is Nothing)
        Catch
            Return False
        End Try
    End Function

    Public Sub Clear() Implements COMExpress.Windows.Forms.ISwitchboardService.Clear
        Me.Nodes.Clear()
        mobjHost.OnItemCleared()
    End Sub
#End Region


#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
