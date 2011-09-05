Option Explicit On 
Option Strict On

Imports COMExpress.Windows.Forms

Public Class CXPropertyGrid
    Inherits System.Windows.Forms.PropertyGrid
    Implements IGrid
    Implements System.ComponentModel.ISupportInitialize

    Public Property DataSource() As Object Implements COMExpress.Windows.Forms.IGrid.DataSource
        Get
            Return Me.SelectedObject
        End Get
        Set(ByVal Value As Object)
            Me.SelectedObject = Value
        End Set
    End Property

    Public Sub DeleteObject() Implements COMExpress.Windows.Forms.IGrid.DeleteObject

    End Sub

    Public Property Editable() As Boolean Implements COMExpress.Windows.Forms.IGrid.Editable
        Get
            Return Me.Enabled
        End Get
        Set(ByVal Value As Boolean)
            Me.Enabled = Value
        End Set
    End Property

	Public Property Deletable() As Boolean Implements COMExpress.Windows.Forms.IGrid.Deletable
        Get

        End Get
        Set(ByVal Value As Boolean)

        End Set
    End Property
    
    Public Sub FindGridRow(ByVal ColName As String, ByVal value As Object) Implements COMExpress.Windows.Forms.IGrid.FindGridRow

    End Sub

	Public Event SelectedRowChanged(ByVal sender As Object, ByVal e As COMExpress.Windows.Forms.CurrentGridRowIndexEventArgs) Implements COMExpress.Windows.Forms.IGrid.SelectedRowChanged
	
    Public Sub FormatGrid() Implements COMExpress.Windows.Forms.IGrid.FormatGrid

    End Sub

    Public Sub BeginInit() Implements System.ComponentModel.ISupportInitialize.BeginInit

    End Sub

    Public Sub EndInit() Implements System.ComponentModel.ISupportInitialize.EndInit

    End Sub

    Public ReadOnly Property GridPositions() As System.Collections.ArrayList Implements COMExpress.Windows.Forms.IGrid.GridPositions
        Get

        End Get
    End Property

#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Class
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region

