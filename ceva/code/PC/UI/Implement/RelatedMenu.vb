Imports COMExpress.Windows.Forms
Imports COMExpress.Windows.Controls



Public Class RelatedMenuKey
    Public Const rohdr As String = "rohdr"
    Public Const dnhdr As String = "dnhdr"
    Public Const recvhdr As String = "recvhdr"
    Public Const recvhdrs As String = "recvhdrs"
    Public Const recvlin As String = "recvlin"
    Public Const recvsno As String = "recvsno"
    Public Const putlinbyrecv As String = "putlinbyrecv"
    Public Const putlin As String = "putlin"
    Public Const measure As String = "measure"
    Public Const damage As String = "damage"
    Public Const loanout As String = "loanout"
    Public Const deliverybatch As String = "deliverybatch"
    Public Const pickhdr As String = "pickhdr"
    Public Const shiplin As String = "shiplin"
    Public Const shipsno As String = "shipsno"
    Public Const archlin As String = "archlin"
    Public Const kreq As String = "kreq"
    Public Const kordhdr As String = "kordhdr"
    Public Const sku_no As String = "sku_no"
    Public Const bin_code As String = "bin_code"
    Public Const dealer As String = "dealer"
    Public Const stock As String = "stock"
    Public Const stockhis As String = "stockhis"
    Public Const stockusageWM As String = "stockusageWM"
    Public Const stockusageIM As String = "stockusageIM"
    Public Const translog As String = "translog"

    Public Const bchhdr As String = "bchhdr"
    Public Const pickordlin As String = "pickordlin"
    Public Const archhdr As String = "archhdr"
    Public Const MovementDnCancel As String = "MovementDnCancel"

    Public Const rpcsourceorder As String = "rpcsourceorder"

End Class

Public Class clsRelatedMenu

    Public sku_no As String = ""
    Public bin_area As String = ""
    Public bin_code As String = ""
    Public sku_status As String = ""
    Public dc_code As String = ""
    Public dn_no As String = ""
    Public bch_no As String = ""
    Public bch_type As String = ""
    Public pick_no As String = ""
    Public ro_no As String = ""
    Public recv_no As String = ""
    Public kreq_no As String = ""
    Public doc_type As String = ""
    Public wh_code As String = ""
    Public lot_no As String = ""
    Public tag_no As String = ""
    Public sku_ref As String = ""

    Public Const MenuPrefix As String = "mnuRelated"
    Private mobjMenu As MenuService = Nothing
    Public Sub New(ByVal objMenu As MenuService)
        mobjMenu = objMenu
        mobjTimer = New Timer
        mobjTimer.Enabled = False
        mobjTimer.Interval = 200
    End Sub

    '下面只是控制查关菜单是否显示.
    Private mItemData As New ItemCollection(10)
    Public Event RefreshNotify()
    Public ReadOnly Property MenuItems() As ItemCollection
        Get
            Return mItemData
        End Get
    End Property

    Public Sub Clear()
        mItemData.Clear()
    End Sub

    Private WithEvents mobjTimer As Timer
    Public Sub Refresh()
        'If mobjTimer Is Nothing Then
        '    Exit Sub
        'End If
        'mobjTimer.Interval = 200
        'mobjTimer.Enabled = True
        RaiseEvent RefreshNotify()
    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Return mItemData.Count
        End Get
    End Property
    Public Sub Add(ByVal vKey As String, ByVal vDefaultCaption As String, Optional ByVal FuncType As String = "")
        Dim str As String
        vKey = Trim(vKey)
        str = PublicResource.LoadResString("ID_mnu_Relate_Caption_" + Trim(vKey), vDefaultCaption)
        mItemData.Add(MenuPrefix + vKey, str, FuncType)
    End Sub

    Protected Overrides Sub Finalize()
        mobjTimer.Enabled = False
        mobjTimer.Dispose()
        mobjTimer = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub mobjTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles mobjTimer.Tick
        Try
            mobjTimer.Enabled = False
            RaiseEvent RefreshNotify()
            GC.Collect()
        Catch ex As Exception
        End Try
    End Sub
End Class




