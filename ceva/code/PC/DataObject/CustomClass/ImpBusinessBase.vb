Option Explicit On 
Option Strict On
Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA
Imports System.Reflection
Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.ComponentModel

Namespace BusinessObject

    <Serializable()> Public MustInherit Class ImpBusinessBaseDerived
        Inherits BusinessBaseDerived

        '<CXPropertyVar(PropertyName:="sStore")> Protected mstrsStore As System.String = ""

        <Serializable()> Structure ValidField
            Dim FieldName As String
            Dim Info As ValidType
        End Structure

        Public Shared ChildFlag As Boolean = False
        Public Shared ParentObj As BusinessBaseDerived = Nothing
        Public Shared NewAddObjList As New ArrayList
        Private ErrorInfo As ValidField
        Public Shared AutoFillByParentFlag As Boolean = False
        Public Shared objParent As ImpBusinessBaseDerived  'for filling fields when inserting new record in head-grid  
        'Public Shared NewCartonlin As ImpBusinessBaseDerived  'for filling UPC and SKU of cartonlin when inserting new record in frmclsCarton's head-grid
        'Private DateFmt As String

        Enum ValidType
            Valid
            Blank
            Repeat
        End Enum

        'Protected Overrides Sub DataPortal_Create(ByVal Criteria As Object)
        '    'Dim classPropertys As PropertyDescriptorCollection
        '    'Dim clsProperty As PropertyDescriptor
        '    'classPropertys = TypeDescriptor.GetProperties(Me.GetType)
        '    ''If ProgramType.Type = ProgramType.pType.Store AndAlso Not Me.GetType.Name.ToLower = "clssstore" Then
        '    ''    classPropertys = TypeDescriptor.GetProperties(Me.GetType)
        '    ''    clsProperty = classPropertys.Find("sStore", False)
        '    ''    If Not clsProperty Is Nothing Then
        '    ''        clsProperty.SetValue(Me, UserRightMgr.gStoreCode)
        '    ''    End If
        '    ''End If

        '    ''Dim upfield As FieldInfo = Me.GetType.GetField("mdtmUpdatedDate", BindingFlags.NonPublic)
        '    ''If Not upfield Is Nothing Then
        '    ''    Dim upDate As SmartDate = CType(upfields(0).Get, SmartDate)
        '    ''    upDate.FormatString = "yyyy-MM-dd HH:mm:ss"
        '    ''End If
        '    'MyBase.DataPortal_Create(Criteria)
        'End Sub

        Protected Overrides Function CustomPropertyDescriptor(ByVal oProp As System.ComponentModel.PropertyDescriptor) As COMExpress.BusinessObject.BusinessPropertyBaseDescriptor

        End Function

        Protected Overrides ReadOnly Property StringResourceManager() As System.Resources.ResourceManager
            Get
            End Get
        End Property

        'Protected Overrides Sub DataPortal_Update()
        '    'Dim classPropertys As PropertyDescriptorCollection = TypeDescriptor.GetProperties(Me.GetType)
        '    'Dim clsProperty As PropertyDescriptor = classPropertys.Find("UpdatedDate", False)
        '    'If Not clsProperty Is Nothing AndAlso Me.IsDirty Then
        '    '    clsProperty.SetValue(Me, Now.ToString(DateFmt & " HH:mm:ss"))
        '    'End If
        '    ''Try
        '    ''GetPKFields()
        '    'MyBase.DataPortal_Update()
        '    ''Catch ex As Exception
        '    ''    If ex.Message.LastIndexOf("PRIMARY KEY") > 0 AndAlso ex.Message.LastIndexOf("duplicate key") > 0 Then
        '    ''        ErrorInfo.FieldName = "PKField"
        '    ''        ErrorInfo.Info = ValidType.Repeat
        '    ''    Else
        '    ''        Throw ex
        '    ''    End If
        '    ''    'Throw ex
        '    ''End Try
        'End Sub

        Public Function GetValidInfo() As ValidField
            Return ErrorInfo
        End Function

        Public Sub CancelDirty()
            Me.MarkOld()
        End Sub

        Public Sub MakeDirty()
            Me.MarkDirty()
        End Sub

        Public Overrides Sub CheckValid()
            Dim classPropertys As PropertyDescriptorCollection
            Dim clsProperty As PropertyDescriptor
            If Not Me.IsDirty Then
                Exit Sub
            End If
            classPropertys = TypeDescriptor.GetProperties(Me.GetType)
            If ChildFlag Then Me.FillWithParentKeys(ParentObj)
            clsProperty = classPropertys.Find("opt_by", False)
            If Not clsProperty Is Nothing Then
                clsProperty.SetValue(Me, UserRightMgr.gUserCode)
            End If
            clsProperty = classPropertys.Find("opt_dtime", False)
            If Not clsProperty Is Nothing Then
                clsProperty.SetValue(Me, Now)
            End If
            'Central DB,dc_code should not be set automatic.
            'noted by Yu , 2010-02-09
            'clsProperty = classPropertys.Find("dc_code", False)
            'If Not clsProperty Is Nothing AndAlso Not UserRightMgr.gDcCode Is Nothing Then
            '    clsProperty.SetValue(Me, UserRightMgr.gDcCode)
            'End If
            clsProperty = classPropertys.Find("clt_ver", False)
            If Not clsProperty Is Nothing AndAlso Not UserRightMgr.gDcCode Is Nothing Then
                clsProperty.SetValue(Me, clield_ver())
            End If
            'CheckCompleted(Me)
            'CheckTagFlag(Me)
            'CheckBussinessValid(Me)
            'If bCanCheckChildValid = True Then
            '    CheckChildValid(Me)
            'End If
            'BackupMe()
        End Sub

#Region " OnSaveCompleted"

        'Private mobjBackup As ImpBusinessBaseDerived = Nothing
        'Private Sub BackupMe()
        '    If Not Me.IsDirty Then
        '        Exit Sub
        '    End If
        '    Dim strName As String

        '    strName = Me.GetType.Name
        '    Select Case strName
        '        Case "clsrecvhdr"
        '            mobjBackup = clsrecvhdr.Load(CType(Me, clsrecvhdr).dc_code, CType(Me, clsrecvhdr).doc_no)
        '        Case "clsmvhdr"
        '            mobjBackup = clsmvhdr.Load(CType(Me, clsmvhdr).dc_code, CType(Me, clsmvhdr).doc_no)
        '        Case "clsdnhdr"
        '            mobjBackup = clsdnhdr.Load(CType(Me, clsdnhdr).dc_code, CType(Me, clsdnhdr).dn_no)
        '    End Select

        'End Sub

        'Public Function BackupBussiness() As ImpBusinessBaseDerived
        '    Return mobjBackup
        'End Function


        'Public Overrides Sub OnSaveCompleted()
        '    Dim strName As String

        '    strName = Me.GetType.Name
        '    Select Case strName
        '        Case "clsrecvhdr"
        '            OnReceiveSaveCompleted(CType(Me, clsrecvhdr))
        '        Case "clsmvhdr"
        '            OnMovementSaveCompleted(CType(Me, clsmvhdr))
        '        Case "clsdnhdr"
        '            OnDeliverySaveCompleted(CType(Me, clsdnhdr))
        '    End Select
        'End Sub


        'Public Sub OnReceiveSaveCompleted(ByVal obj As clsrecvhdr)
        '    Dim bk As clsrecvhdr
        '    bk = CType(obj.BackupBussiness, clsrecvhdr)
        '    If Not (bk.status_code < GlobalStatus.RECVHDR_CLOSE And obj.status_code >= GlobalStatus.RECVHDR_CLOSE) Then
        '        Exit Sub
        '    End If
        '    obj.Loadclsrecvlins()

        'End Sub

        'Public Sub OnMovementSaveCompleted(ByVal obj As clsmvhdr)

        'End Sub
        'Public Sub OnDeliverySaveCompleted(ByVal obj As clsdnhdr)

        'End Sub

#End Region

        Private bCanCheckChildValid As Boolean = True
        Public Property CanCheckChildValid() As Boolean
            Get
                Return bCanCheckChildValid
            End Get
            Set(ByVal Value As Boolean)
                bCanCheckChildValid = Value
            End Set
        End Property

        Private Shared Sub CheckChildValid(ByVal objBO As BusinessBaseDerived)
            Dim currentType As Type = objBO.GetType
            Dim fields() As PropertyInfo
            Dim field As PropertyInfo



            Do Until currentType Is GetType(BusinessBase)
                ' get the list of fields in this type
                fields = currentType.GetProperties( _
                    BindingFlags.Instance Or _
                    BindingFlags.Public)

                For Each field In fields
                    If field.DeclaringType Is currentType Then
                        Dim attrs() As CXLinkPropertyAttribute = CXLinkPropertyAttribute.GetLinkProperties(field)
                        If Not attrs Is Nothing Then
                            If field.PropertyType.IsSubclassOf(GetType(BusinessCollectionBaseDerived)) Then
                                Dim obj As BusinessBaseDerived, objChild As BusinessCollectionBaseDerived
                                Dim i As Integer
                                objChild = CType(field.GetValue(objBO, Nothing), BusinessCollectionBaseDerived)
                                'CType(objBO, BusinessBaseDerived).UnTrackChildrenEvents(objChild)
                                For Each obj In objChild
                                    obj.CheckValid()
                                Next
                            ElseIf field.PropertyType.IsSubclassOf(GetType(BusinessBase)) Then
                                Dim obj As BusinessBaseDerived = CType(field.GetValue(objBO, Nothing), BusinessBaseDerived)
                                obj.CheckValid()
                            End If
                        End If
                    End If
                Next
                Try
                    currentType = currentType.BaseType
                Catch ex As Exception

                End Try

            Loop
        End Sub


        Public Sub MakeDeletedList()
            Me.MarkDirty()
            Me.MarkDeleted()
        End Sub


        Public Shared ReadOnly Property clield_ver() As String
            Get
                Return Trim(UserRightMgr.gUIAssemblyVersion) + "(" + GetCurrentVersion() + ")"
            End Get
        End Property

#Region " Completed Checking..."

        Private Shared Sub CheckBussinessValid(ByVal objBO As BusinessBaseDerived)
            'If Not objBO.IsDirty Then
            '    Exit Sub
            'End If
            'Dim strName As String
            'strName = objBO.GetType.Name
            'Select Case strName
            '    Case "clsrpchdr"
            '        CheckBussinessValidRPC(DirectCast(objBO, clsrpchdr))
            '    Case "clsskukit"
            '        CheckBussinessValidSkuKit(DirectCast(objBO, clsskukit))
            'End Select
        End Sub

        'Private Shared Sub CheckBussinessValidSkuKit(ByVal objBO As clsskukit)
        '    Dim i As Integer
        '    Dim obj As clskbom
        '    Dim iCount As Integer
        '    If objBO.clskboms.Count <= 0 Then
        '        Exit Sub
        '    End If
        '    iCount = 0
        '    For i = 0 To objBO.clskboms.Count - 1
        '        If objBO.clskboms(i).ismain Then
        '            iCount = iCount + 1
        '        End If
        '    Next
        '    If iCount > 1 Then          '多于一个主物料, 所有的主物料必须有SNO
        '        If BomMainAllHaveSno(objBO.clskboms) = False Then
        '            Throw New Exception("{SkuKitManyMainMustHaveSno}主产品多于一个时必须全有机号.")
        '        End If
        '    ElseIf iCount = 1 Then      '一个主物料, 既可有SNO,也可没有SNO
        '        'Do Donthing, allow to pass
        '    ElseIf iCount = 0 Then
        '        Throw New Exception("{SkuKitNoMain}没有主产品。")
        '    End If
        'End Sub

        'Private Shared Function BomMainAllHaveSno(ByVal boms As clskboms) As Boolean
        '    Dim i As Integer
        '    Dim sku_no As String
        '    Dim sku As clsskuinfo
        '    For i = 0 To boms.Count - 1
        '        If boms(i).ismain Then
        '            sku_no = boms(i).part_no
        '            sku = clsskuinfo.Load(sku_no)
        '            If sku.have_sno = False Then
        '                Return False
        '            End If
        '        End If
        '    Next
        '    Return True
        'End Function


        'Private Shared Sub CheckBussinessValidRPC(ByVal objBO As clsrpchdr)
        '    Dim i As Integer
        '    Dim obj As clsrpcordlin = Nothing
        '    For i = 0 To objBO.clsrpcordlins.Count - 1
        '        If objBO.clsrpcordlins(i).IsNew And objBO.clsrpcordlins(i).rpc_type = "0" Then
        '            ''0'-取消单, cdnhdr.doc_no
        '            ''1'-发货单, dnhdr.dn_no
        '            ''2'-收货单, rohdr.ro_no
        '            obj = objBO.clsrpcordlins(i)
        '            Exit For
        '        End If
        '    Next
        '    If obj Is Nothing Then
        '        Exit Sub
        '    End If
        '    Dim dn As clsdnhdr
        '    Try
        '        dn = clsdnhdr.Load(obj.dc_code, obj.doc_no)
        '        If Not dn.IsNew Then
        '            objBO.deal_to = dn.deal_to
        '        End If
        '    Catch ex As Exception
        '    End Try
        '    dn = Nothing
        'End Sub

        'Private Shared Sub CheckTagFlag(ByVal objBO As BusinessBaseDerived)
        '    If Not objBO.IsDirty Then
        '        Exit Sub
        '    End If
        '    Dim strName As String
        '    strName = objBO.GetType.Name
        '    Select Case strName
        '        Case "clsrohdr"
        '            CheckTagFlagRohdr(DirectCast(objBO, clsrohdr))
        '        Case "clsrecvhdr"
        '            CheckTagFlagRecvhdr(DirectCast(objBO, clsrecvhdr))
        '        Case "clsputhdr"
        '            CheckTagFlagPuthdr(DirectCast(objBO, clsputhdr))
        '        Case "clsccnhdr"
        '            CheckTagFlagCcnhdr(DirectCast(objBO, clsccnhdr))
        '        Case "clsmvhdr"
        '            CheckTagFlagMvhdr(DirectCast(objBO, clsmvhdr))
        '        Case "clspickhdr"
        '            CheckTagFlagPickhdr(DirectCast(objBO, clspickhdr))
        '        Case "clsdnhdr"
        '            CheckTagFlagDnhdr(DirectCast(objBO, clsdnhdr))
        '        Case "clscdnhdr"
        '            CheckTagFlagCdnhdr(DirectCast(objBO, clscdnhdr))
        '    End Select

        'End Sub
        'Private Shared Sub CheckTagFlagRohdr(ByVal objBo As clsrohdr)
        '    If objBo.clsrolins.Count <= 0 Then
        '        Exit Sub
        '    End If
        '    Dim bHaveTag As Boolean = False
        '    Dim i As Integer
        '    For i = 0 To objBo.clsrolins.Count - 1
        '        If objBo.clsrolins(i).tag_no <> "" Then
        '            bHaveTag = True
        '        End If
        '    Next
        '    If (objBo.have_tag = "Y") <> bHaveTag Then
        '        If bHaveTag Then
        '            objBo.have_tag = "Y"
        '        Else
        '            objBo.have_tag = ""
        '        End If
        '    End If
        'End Sub

        'Private Shared Sub CheckTagFlagRecvhdr(ByVal objBo As clsrecvhdr)
        '    If objBo.clsrecvlins.Count <= 0 Then
        '        Exit Sub
        '    End If
        '    Dim bHaveTag As Boolean = False
        '    Dim i As Integer
        '    For i = 0 To objBo.clsrecvlins.Count - 1
        '        If objBo.clsrecvlins(i).tag_no <> "" Then
        '            bHaveTag = True
        '        End If
        '    Next
        '    If (objBo.have_tag = "Y") <> bHaveTag Then
        '        If bHaveTag Then
        '            objBo.have_tag = "Y"
        '        Else
        '            objBo.have_tag = ""
        '        End If
        '    End If
        'End Sub

        'Private Shared Sub CheckTagFlagPuthdr(ByVal objBo As clsputhdr)
        '    If objBo.clsputlins.Count <= 0 Then
        '        Exit Sub
        '    End If
        '    Dim bHaveTag As Boolean = False
        '    Dim i As Integer
        '    For i = 0 To objBo.clsputlins.Count - 1
        '        If objBo.clsputlins(i).tag_no <> "" Then
        '            bHaveTag = True
        '        End If
        '    Next
        '    If (objBo.have_tag = "Y") <> bHaveTag Then
        '        If bHaveTag Then
        '            objBo.have_tag = "Y"
        '        Else
        '            objBo.have_tag = ""
        '        End If
        '    End If
        'End Sub

        'Private Shared Sub CheckTagFlagCcnhdr(ByVal objBo As clsccnhdr)
        '    If objBo.clsccnlins.Count <= 0 Then
        '        Exit Sub
        '    End If
        '    Dim bHaveTag As Boolean = False
        '    Dim i As Integer
        '    For i = 0 To objBo.clsccnlins.Count - 1
        '        If objBo.clsccnlins(i).tag_no <> "" Then
        '            bHaveTag = True
        '        End If
        '    Next
        '    If (objBo.have_tag = "Y") <> bHaveTag Then
        '        If bHaveTag Then
        '            objBo.have_tag = "Y"
        '        Else
        '            objBo.have_tag = ""
        '        End If
        '    End If
        'End Sub
        'Private Shared Sub CheckTagFlagMvhdr(ByVal objBo As clsmvhdr)
        '    If objBo.clsmvlins.Count <= 0 Then
        '        Exit Sub
        '    End If
        '    Dim bHaveTag As Boolean = False
        '    Dim i As Integer
        '    For i = 0 To objBo.clsmvlins.Count - 1
        '        If objBo.clsmvlins(i).tag_no <> "" Then
        '            bHaveTag = True
        '        End If
        '    Next
        '    If (objBo.have_tag = "Y") <> bHaveTag Then
        '        If bHaveTag Then
        '            objBo.have_tag = "Y"
        '        Else
        '            objBo.have_tag = ""
        '        End If
        '    End If
        'End Sub

        'Private Shared Sub CheckTagFlagPickhdr(ByVal objBo As clspickhdr)
        '    If objBo.clspicklins.Count <= 0 Then
        '        Exit Sub
        '    End If
        '    Dim bHaveTag As Boolean = False
        '    Dim i As Integer
        '    For i = 0 To objBo.clspicklins.Count - 1
        '        If objBo.clspicklins(i).tag_no <> "" Then
        '            bHaveTag = True
        '        End If
        '    Next
        '    If (objBo.have_tag = "Y") <> bHaveTag Then
        '        If bHaveTag Then
        '            objBo.have_tag = "Y"
        '        Else
        '            objBo.have_tag = ""
        '        End If
        '    End If
        'End Sub

        'Private Shared Sub CheckTagFlagDnhdr(ByVal objBo As clsdnhdr)
        '    If objBo.clsdnlins.Count <= 0 Then
        '        Exit Sub
        '    End If
        '    Dim bHaveTag As Boolean = False
        '    Dim i As Integer
        '    For i = 0 To objBo.clsdnlins.Count - 1
        '        If objBo.clsdnlins(i).tag_no <> "" Then
        '            bHaveTag = True
        '        End If
        '    Next
        '    If (objBo.have_tag = "Y") <> bHaveTag Then
        '        If bHaveTag Then
        '            objBo.have_tag = "Y"
        '        Else
        '            objBo.have_tag = ""
        '        End If
        '    End If
        'End Sub
        'Private Shared Sub CheckTagFlagCdnhdr(ByVal objBo As clscdnhdr)
        '    If objBo.clscdnlins.Count <= 0 Then
        '        Exit Sub
        '    End If
        '    Dim bHaveTag As Boolean = False
        '    Dim i As Integer
        '    For i = 0 To objBo.clscdnlins.Count - 1
        '        If objBo.clscdnlins(i).tag_no <> "" Then
        '            bHaveTag = True
        '        End If
        '    Next
        '    If (objBo.have_tag = "Y") <> bHaveTag Then
        '        If bHaveTag Then
        '            objBo.have_tag = "Y"
        '        Else
        '            objBo.have_tag = ""
        '        End If
        '    End If
        'End Sub

        'Private Shared Sub CheckCompleted(ByVal objBO As BusinessBaseDerived)
        '    If Not objBO.IsDirty Then
        '        Exit Sub
        '    End If
        '    Dim strName As String
        '    Dim linclose As String
        '    Dim hdrclose As String

        '    strName = objBO.GetType.Name
        '    Select Case strName
        '        Case "clsrecvhdr"
        '            linclose = GlobalStatus.RECVLIN_CLOSE ' "REC54"
        '            hdrclose = GlobalStatus.RECVHDR_CLOSE '"REC14"
        '            CheckCompletedRecvhdr(DirectCast(objBO, clsrecvhdr), linclose, hdrclose)
        '        Case "clsccnhdr"
        '            linclose = "CCT54"
        '            hdrclose = "CCT14"
        '            CheckCompletedCcnhdr(DirectCast(objBO, clsccnhdr), linclose, hdrclose)
        '        Case "clsmvhdr"
        '            linclose = "MOV54"
        '            hdrclose = "MOV14"
        '            CheckCompletedMvhdr(DirectCast(objBO, clsmvhdr), linclose, hdrclose)
        '        Case "clspickhdr"
        '            linclose = "PIK54"
        '            hdrclose = "PIK14"
        '            CheckCompletedPickhdr(DirectCast(objBO, clspickhdr), linclose, hdrclose)
        '        Case "clsdnhdr"
        '            linclose = "DNO54"
        '            hdrclose = "DNO14"
        '            CheckCompletedDnhdr(DirectCast(objBO, clsdnhdr), linclose, hdrclose)
        '        Case "clsputhdr"
        '            linclose = "PUT54"
        '            hdrclose = "PUT14"
        '            CheckCompletedPuthdr(DirectCast(objBO, clsputhdr), linclose, hdrclose)

        '    End Select
        'End Sub

        ''如果表头的状态是关闭，则关闭其详细表的状态；否则退出recvhdr
        'Private Shared Sub CheckCompletedRecvhdr(ByVal objBo As clsrecvhdr, ByVal linStats As String, ByVal hdrStats As String)
        '    Dim i As Integer
        '    Dim lin As clsrecvlin

        '    If objBo.status_code <> hdrStats Then
        '        Exit Sub
        '    End If
        '    If IsDBNull(objBo.start_dtime) = True Then
        '        objBo.start_dtime = Now
        '    End If
        '    If IsDBNull(objBo.end_dtime) = True Then
        '        objBo.end_dtime = Now
        '    End If
        '    For i = 0 To objBo.clsrecvlins.Count - 1
        '        lin = objBo.clsrecvlins(i)
        '        If lin.status_code < linStats Then
        '            lin.status_code = linStats
        '        End If
        '    Next
        'End Sub
        'Private Shared Sub CheckCompletedCcnhdr(ByVal objBo As clsccnhdr, ByVal linStats As String, ByVal hdrStats As String)
        '    Dim i As Integer
        '    Dim lin As clsccnlin

        '    If objBo.status_code <> hdrStats Then
        '        Exit Sub
        '    End If
        '    If IsDBNull(objBo.start_dtime) = True Then
        '        objBo.start_dtime = Now
        '    End If
        '    If IsDBNull(objBo.end_dtime) = True Then
        '        objBo.end_dtime = Now
        '    End If
        '    For i = 0 To objBo.clsccnlins.Count - 1
        '        lin = objBo.clsccnlins(i)
        '        If lin.status_code < linStats Then
        '            lin.status_code = linStats
        '        End If
        '    Next
        'End Sub
        'Private Shared Sub CheckCompletedMvhdr(ByVal objBo As clsmvhdr, ByVal linStats As String, ByVal hdrStats As String)
        '    Dim i As Integer
        '    Dim lin As clsmvlin

        '    If objBo.status_code <> hdrStats Then
        '        Exit Sub
        '    End If
        '    If IsDBNull(objBo.start_dtime) = True Then
        '        objBo.start_dtime = Now
        '    End If
        '    If IsDBNull(objBo.end_dtime) = True Then
        '        objBo.end_dtime = Now
        '    End If
        '    For i = 0 To objBo.clsmvlins.Count - 1
        '        lin = objBo.clsmvlins(i)
        '        If lin.status_code < linStats Then
        '            lin.status_code = linStats
        '        End If
        '    Next
        'End Sub
        'Private Shared Sub CheckCompletedPickhdr(ByVal objBo As clspickhdr, ByVal linStats As String, ByVal hdrStats As String)
        '    Dim i As Integer
        '    Dim lin As clspicklin

        '    If objBo.status_code <> hdrStats Then
        '        Exit Sub
        '    End If
        '    If IsDBNull(objBo.start_dtime) = True Then
        '        objBo.start_dtime = Now
        '    End If
        '    If IsDBNull(objBo.end_dtime) = True Then
        '        objBo.end_dtime = Now
        '    End If
        '    For i = 0 To objBo.clspicklins.Count - 1
        '        lin = objBo.clspicklins(i)
        '        If lin.status_code < linStats Then
        '            lin.status_code = linStats
        '        End If
        '    Next
        'End Sub
        'Private Shared Sub CheckCompletedDnhdr(ByVal objBo As clsdnhdr, ByVal linStats As String, ByVal hdrStats As String)
        '    Dim i As Integer
        '    Dim lin As clsdnlin
        '    Dim shp As clsshiplin
        '    '---------------------------------------------
        '    If objBo.status_code <> hdrStats Then
        '        Exit Sub
        '    End If
        '    If IsDBNull(objBo.start_dtime) = True Then
        '        objBo.start_dtime = Now
        '    End If
        '    If IsDBNull(objBo.end_dtime) = True Then
        '        objBo.end_dtime = Now
        '    End If
        '    For i = 0 To objBo.clsdnlins.Count - 1
        '        lin = objBo.clsdnlins(i)
        '        If lin.status_code < linStats Then
        '            lin.status_code = linStats
        '        End If
        '        lin.Loadclsshiplins(True)
        '        For j As Integer = 0 To lin.clsshiplins.Count - 1
        '            shp = lin.clsshiplins(j)
        '            If shp.status_code < "SHP54" Then
        '                shp.status_code = "SHP54"
        '            End If
        '        Next
        '    Next
        'End Sub
        'Private Shared Sub CheckCompletedPuthdr(ByVal objBo As clsputhdr, ByVal linStats As String, ByVal hdrStats As String)
        '    Dim i As Integer
        '    Dim lin As clsputlin

        '    If objBo.status_code <> hdrStats Then
        '        Exit Sub
        '    End If
        '    For i = 0 To objBo.clsputlins.Count - 1
        '        lin = objBo.clsputlins(i)
        '        If lin.status_code < linStats Then
        '            lin.status_code = linStats
        '        End If
        '    Next
        'End Sub



#End Region



        '取related的对象列表, 设置附加的条件
        Protected Overrides Function GetFiltersAdditionalForRelatedChildren(ByVal PropertyName As String) As COMExpress.BusinessObject.Filters.CXFilters
            Dim classPropertys As PropertyDescriptorCollection
            Dim clsProperty As PropertyDescriptor
            Dim info As PropertyInfo
            Dim objs As BusinessCollectionBaseDerived
            Dim ChildObjectName As String
            If Me.GetType.Name = "clsoperator" Then
                Return Nothing
            End If
            If Me.GetType.Name = "clsif_req" Then
                Return Nothing
            End If

            info = Me.GetType.GetProperty(PropertyName, BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.Public)
            If Not info.PropertyType.IsSubclassOf(GetType(Core.SortableCollectionBase)) Then
                Return Nothing
            End If
            objs = CType(info.GetValue(Me, Nothing), BusinessCollectionBaseDerived)
            ChildObjectName = objs.BusinessType.Name        '子对象名

            Dim ColName As String
            ColName = "dc_code"                 '所有业务必须在DC的范围内进行, 这里若表中有DC, 则加DC的filter.

            '子对象有 dc_code
            classPropertys = TypeDescriptor.GetProperties(objs.BusinessType)
            clsProperty = classPropertys.Find(ColName, True)
            If clsProperty Is Nothing Then
                Return Nothing
            End If
            '-------------------------------
            Dim attrs() As CXLinkPropertyAttribute = CXLinkPropertyAttribute.GetLinkProperties(info)
            Dim i As Integer
            For i = 0 To UBound(attrs)
                If attrs(i).ChildProperty = ColName Then        'Link have dc_code, exit 
                    Return Nothing
                End If
            Next
            Return ImpBusinessCollectionDerived.GetFilter(ColName, UserRightMgr.gDcCode, ChildObjectName, ConditionOperator.Equal)

            'If Me.GetType.Name = "clsskuinfo" Then
            '    If PropertyName = "clsskucharges" Then
            '        Return ImpBusinessCollectionDerived.GetFilter("dc_code", UserRightMgr.gDcCode, "clsskucharge", ConditionOperator.Equal)
            '    End If
            'ElseIf Me.GetType.Name = "clsowner" Then
            '    If PropertyName = "clscalendars" Then
            '        Return ImpBusinessCollectionDerived.GetFilter("dc_code", UserRightMgr.gDcCode, "clscalendar", ConditionOperator.Equal)
            '    ElseIf PropertyName = "clstimecutoffs" Then
            '        Return ImpBusinessCollectionDerived.GetFilter("dc_code", UserRightMgr.gDcCode, "clstimecutoff", ConditionOperator.Equal)
            '    End If
            'End If
            'Return Nothing
        End Function
    End Class



End Namespace