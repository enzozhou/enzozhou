Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[dnhdr]",SelectFromClause:="[dbo].[dnhdr] ",InsertStoredProcedure:="stp_I_clsdnhdr",SelectStoredProcedure:="stp_S_clsdnhdr",DeleteStoredProcedure:="stp_D_clsdnhdr",UpdateStoredProcedure:="stp_U_clsdnhdr"), Serializable()> _
Public MustInherit Class clsdnhdrBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="dc_code")> Protected mstrdc_code As System.String = ""
        <CXPropertyVar(PropertyName:="dn_no")> Protected mstrdn_no As System.String = ""
        <CXPropertyVar(PropertyName:="sony_bch_no")> Protected mstrsony_bch_no As System.String = ""
        <CXPropertyVar(PropertyName:="doc_type")> Protected mstrdoc_type As System.String = ""
        <CXPropertyVar(PropertyName:="imp_dtime")> Protected mdtmimp_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="city_to")> Protected mstrcity_to As System.String = ""
        <CXPropertyVar(PropertyName:="deal_to")> Protected mstrdeal_to As System.String = ""
        <CXPropertyVar(PropertyName:="deal_name")> Protected mstrdeal_name As System.String = ""
        <CXPropertyVar(PropertyName:="deal_person")> Protected mstrdeal_person As System.String = ""
        <CXPropertyVar(PropertyName:="deal_tel")> Protected mstrdeal_tel As System.String = ""
        <CXPropertyVar(PropertyName:="unloading_address")> Protected mstrunloading_address As System.String = ""
        <CXPropertyVar(PropertyName:="status_code")> Protected mstrstatus_code As System.String = ""
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="start_dtime")> Protected mdtmstart_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="end_dtime")> Protected mdtmend_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="remark")> Protected mstrremark As System.String = ""
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="dc_codeOLD___")> Protected mstrdc_codeOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="dn_noOLD___")> Protected mstrdn_noOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="clsdnlins")> Protected mcolclsdnlins As clsdnlins
        Protected mblnclsdnlinsIsLoaded As Boolean
        <CXPropertyVar(PropertyName:="clstasklins")> Protected mcolclstasklins As clstasklins
        Protected mblnclstasklinsIsLoaded As Boolean
        <CXPropertyVar(PropertyName:="clsDnBins")> Protected mcolclsDnBins As clsDnBins
        Protected mblnclsDnBinsIsLoaded As Boolean
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
        	mcolclsdnlins = clsdnlins.Newclsdnlins()
        	mcolclstasklins = clstasklins.Newclstasklins()
        	mcolclsDnBins = clsDnBins.NewclsDnBins()
  			
			
			
			SetParentPointerForChildren()
		End Sub			
#End Region
        
#Region "Properties"
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property dc_codeOLD___() As System.String
            Get
	            Return mstrdc_codeOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrdc_codeOLD___ = Value
            End Set
        End Property
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property dn_noOLD___() As System.String
            Get
	            Return mstrdn_noOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrdn_noOLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="dc_code", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsdnhdr_dc_code1")> _
        Public Overridable Property dc_code() As System.String
            Get
                If IsReadOK("dc_code") Then  Return mstrdc_code
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("dc_code") Then  Return
	            If Not Equals(mstrdc_code, Value) Then
	                mstrdc_code = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("dc_code")
			        MarkDirty("dc_code")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="dn_no", DataType:=12, Size:=20, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=1, SPKeyOrdinal:=1), BusinessProperty("ID_cap_clsdnhdr_dn_no")> _
        Public Overridable Property dn_no() As System.String
            Get
                If IsReadOK("dn_no") Then  Return mstrdn_no
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("dn_no") Then  Return
	            If Not Equals(mstrdn_no, Value) Then
	                mstrdn_no = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("dn_no")
			        MarkDirty("dn_no")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="sony_bch_no", DataType:=12, Size:=20, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clsdnhdr_sony_bch_no"), NullValue("")> _
        Public Overridable Property sony_bch_no() As System.String
            Get
                If IsReadOK("sony_bch_no") Then  Return mstrsony_bch_no
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("sony_bch_no") Then  Return
	            If Not Equals(mstrsony_bch_no, Value) Then
	                mstrsony_bch_no = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("sony_bch_no")
			        MarkDirty("sony_bch_no")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="doc_type", DataType:=10, Size:=3, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clsdnhdr_doc_type1"), NullValue("")> _
        Public Overridable Property doc_type() As System.String
            Get
                If IsReadOK("doc_type") Then  Return mstrdoc_type
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("doc_type") Then  Return
	            If Not Equals(mstrdoc_type, Value) Then
	                mstrdoc_type = Value
	                Dim blnFoundInCache As boolean 
	                If not Me.LookupObject is nothing Then
		                Dim dvCach As DataView = Getdoc_typeLookupList(CXLookupCallTypeConstants.ccCacheOnly)
	                    Dim intRow As Integer
	                    If Not dvCach Is Nothing Then
	                        With dvCach
	                            .Sort = .Table.Columns(0).ColumnName
	                            intRow = .Find(mstrdoc_type)
	                            If intRow <> -1 Then
	                            	blnFoundInCache = True	                            	
	                            	PropertyHasInvalidLookupValue("doc_type", False)
	                            End If
	                            .Sort = String.Empty
	                        End With
	                    End If
                    End If
                    If Not blnFoundInCache Then
						PropertyHasInvalidLookupValue("doc_type", True)
					End If
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("doc_type")
			        MarkDirty("doc_type")
                End If
            End Set
        End Property
        
        
        Public Overridable Property imp_dtimeText() As System.String
            Get
                If IsReadOK("imp_dtime") Then  Return mdtmimp_dtime.Text
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("imp_dtime") Then  Return
	            If Not Equals(mdtmimp_dtime.Text, Value) Then
	                mdtmimp_dtime.Text = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("imp_dtime")
			        MarkDirty("imp_dtime")
                End If
            End Set
        End Property
        <CXDBField(DBFieldName:="imp_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clsdnhdr_imp_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
        Public Overridable Property imp_dtime() As Object
            Get
            	Dim strValue As string = Me.imp_dtimeText
            	If strValue = String.Empty Then
            		Return System.DBNull.Value
            	Else
                	Return strValue
                End If
            End Get
            Set(ByVal Value As Object)
                If IsDate(Value) Then
                    Me.imp_dtimeText = CType(Value, String)
                Else
                    Me.imp_dtimeText = String.Empty
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="city_to", DataType:=12, Size:=10, SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsdnhdr_city_to"), NullValue("")> _
        Public Overridable Property city_to() As System.String
            Get
                If IsReadOK("city_to") Then  Return mstrcity_to
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("city_to") Then  Return
	            If Not Equals(mstrcity_to, Value) Then
	                mstrcity_to = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("city_to")
			        MarkDirty("city_to")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="deal_to", DataType:=12, Size:=10, SPUpdateOrdinal:=6), BusinessProperty("ID_cap_clsdnhdr_deal_to"), NullValue("")> _
        Public Overridable Property deal_to() As System.String
            Get
                If IsReadOK("deal_to") Then  Return mstrdeal_to
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("deal_to") Then  Return
	            If Not Equals(mstrdeal_to, Value) Then
	                mstrdeal_to = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("deal_to")
			        MarkDirty("deal_to")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="deal_name", DataType:=12, Size:=50, SPUpdateOrdinal:=7), BusinessProperty("ID_cap_clsdnhdr_deal_name"), NullValue("")> _
        Public Overridable Property deal_name() As System.String
            Get
                If IsReadOK("deal_name") Then  Return mstrdeal_name
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("deal_name") Then  Return
	            If Not Equals(mstrdeal_name, Value) Then
	                mstrdeal_name = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("deal_name")
			        MarkDirty("deal_name")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="deal_person", DataType:=12, Size:=50, SPUpdateOrdinal:=8), BusinessProperty("ID_cap_clsdnhdr_deal_person"), NullValue("")> _
        Public Overridable Property deal_person() As System.String
            Get
                If IsReadOK("deal_person") Then  Return mstrdeal_person
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("deal_person") Then  Return
	            If Not Equals(mstrdeal_person, Value) Then
	                mstrdeal_person = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("deal_person")
			        MarkDirty("deal_person")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="deal_tel", DataType:=12, Size:=30, SPUpdateOrdinal:=9), BusinessProperty("ID_cap_clsdnhdr_deal_tel"), NullValue("")> _
        Public Overridable Property deal_tel() As System.String
            Get
                If IsReadOK("deal_tel") Then  Return mstrdeal_tel
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("deal_tel") Then  Return
	            If Not Equals(mstrdeal_tel, Value) Then
	                mstrdeal_tel = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("deal_tel")
			        MarkDirty("deal_tel")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="unloading_address", DataType:=12, Size:=100, SPUpdateOrdinal:=10), BusinessProperty("ID_cap_clsdnhdr_unloading_address"), NullValue("")> _
        Public Overridable Property unloading_address() As System.String
            Get
                If IsReadOK("unloading_address") Then  Return mstrunloading_address
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("unloading_address") Then  Return
	            If Not Equals(mstrunloading_address, Value) Then
	                mstrunloading_address = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("unloading_address")
			        MarkDirty("unloading_address")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="status_code", DataType:=10, Size:=5, SPUpdateOrdinal:=11), BusinessProperty("ID_cap_clsdnhdr_status_code"), NullValue("")> _
        Public Overridable Property status_code() As System.String
            Get
                If IsReadOK("status_code") Then  Return mstrstatus_code
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("status_code") Then  Return
	            If Not Equals(mstrstatus_code, Value) Then
	                mstrstatus_code = Value
	                Dim blnFoundInCache As boolean 
	                If not Me.LookupObject is nothing Then
		                Dim dvCach As DataView = Getstatus_codeLookupList(CXLookupCallTypeConstants.ccCacheOnly)
	                    Dim intRow As Integer
	                    If Not dvCach Is Nothing Then
	                        With dvCach
	                            .Sort = .Table.Columns(0).ColumnName
	                            intRow = .Find(mstrstatus_code)
	                            If intRow <> -1 Then
	                            	blnFoundInCache = True	                            	
	                            	PropertyHasInvalidLookupValue("status_code", False)
	                            End If
	                            .Sort = String.Empty
	                        End With
	                    End If
                    End If
                    If Not blnFoundInCache Then
						PropertyHasInvalidLookupValue("status_code", True)
					End If
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("status_code")
			        MarkDirty("status_code")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=20, SPUpdateOrdinal:=12), BusinessProperty("ID_cap_clsdnhdr_opt_by"), NullValue("")> _
        Public Overridable Property opt_by() As System.String
            Get
                If IsReadOK("opt_by") Then  Return mstropt_by
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("opt_by") Then  Return
	            If Not Equals(mstropt_by, Value) Then
	                mstropt_by = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("opt_by")
			        MarkDirty("opt_by")
                End If
            End Set
        End Property
        
        
        Public Overridable Property opt_dtimeText() As System.String
            Get
                If IsReadOK("opt_dtime") Then  Return mdtmopt_dtime.Text
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("opt_dtime") Then  Return
	            If Not Equals(mdtmopt_dtime.Text, Value) Then
	                mdtmopt_dtime.Text = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("opt_dtime")
			        MarkDirty("opt_dtime")
                End If
            End Set
        End Property
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=13), BusinessProperty("ID_cap_clsdnhdr_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
        Public Overridable Property opt_dtime() As Object
            Get
            	Dim strValue As string = Me.opt_dtimeText
            	If strValue = String.Empty Then
            		Return System.DBNull.Value
            	Else
                	Return strValue
                End If
            End Get
            Set(ByVal Value As Object)
                If IsDate(Value) Then
                    Me.opt_dtimeText = CType(Value, String)
                Else
                    Me.opt_dtimeText = String.Empty
                End If
            End Set
        End Property
        
        
        Public Overridable Property start_dtimeText() As System.String
            Get
                If IsReadOK("start_dtime") Then  Return mdtmstart_dtime.Text
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("start_dtime") Then  Return
	            If Not Equals(mdtmstart_dtime.Text, Value) Then
	                mdtmstart_dtime.Text = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("start_dtime")
			        MarkDirty("start_dtime")
                End If
            End Set
        End Property
        <CXDBField(DBFieldName:="start_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=14), BusinessProperty("ID_cap_clsdnhdr_start_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
        Public Overridable Property start_dtime() As Object
            Get
            	Dim strValue As string = Me.start_dtimeText
            	If strValue = String.Empty Then
            		Return System.DBNull.Value
            	Else
                	Return strValue
                End If
            End Get
            Set(ByVal Value As Object)
                If IsDate(Value) Then
                    Me.start_dtimeText = CType(Value, String)
                Else
                    Me.start_dtimeText = String.Empty
                End If
            End Set
        End Property
        
        
        Public Overridable Property end_dtimeText() As System.String
            Get
                If IsReadOK("end_dtime") Then  Return mdtmend_dtime.Text
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("end_dtime") Then  Return
	            If Not Equals(mdtmend_dtime.Text, Value) Then
	                mdtmend_dtime.Text = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("end_dtime")
			        MarkDirty("end_dtime")
                End If
            End Set
        End Property
        <CXDBField(DBFieldName:="end_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=15), BusinessProperty("ID_cap_clsdnhdr_end_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
        Public Overridable Property end_dtime() As Object
            Get
            	Dim strValue As string = Me.end_dtimeText
            	If strValue = String.Empty Then
            		Return System.DBNull.Value
            	Else
                	Return strValue
                End If
            End Get
            Set(ByVal Value As Object)
                If IsDate(Value) Then
                    Me.end_dtimeText = CType(Value, String)
                Else
                    Me.end_dtimeText = String.Empty
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="remark", DataType:=11, SPUpdateOrdinal:=16), BusinessProperty("ID_cap_clsdnhdr_remark"), NullValue("")> _
        Public Overridable Property remark() As System.String
            Get
                If IsReadOK("remark") Then  Return mstrremark
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("remark") Then  Return
	            If Not Equals(mstrremark, Value) Then
	                mstrremark = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("remark")
			        MarkDirty("remark")
                End If
            End Set
        End Property
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(102, CXDBFieldFlags), SPUpdateOrdinal:=17), BusinessProperty("ID_cap_clsdnhdr_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
		        
        <CXLinkProperty("dc_code","dc_code"), _
CXLinkProperty("dn_no","dn_no"), BusinessProperty("ID_cap_clsdnlins"), CXChildType(GetType(clsdnlin))> _
        Public Overridable Property  clsdnlins() As clsdnlins
            Get
            	Return mcolclsdnlins
            End Get
            Set (ByVal Value As clsdnlins)
            	mcolclsdnlins = Value
            	SetParentPointerForChildren()
            End Set
        End Property
        
        Public Overridable Sub Loadclsdnlins(Optional ByVal blnReset As boolean = False)
        	If Not Me.IsNew Then
	        	If (not clsdnlinsIsLoaded) or blnReset Then
	        		clsdnlins = clsdnlins.Newclsdnlins
	        		LoadRelatedChildren(GetType(clsdnlins).Name)
	        		clsdnlinsIsLoaded = True
	        	End If
        	End If
        End Sub
        
        Protected Overridable Property clsdnlinsIsLoaded() As Boolean
            Get 
                clsdnlinsIsLoaded = mblnclsdnlinsIsLoaded
            End Get
            Set (ByVal Value As Boolean)
                mblnclsdnlinsIsLoaded = Value
            End Set
        End Property
		        
        <CXLinkProperty("dc_code","dc_code"), _
CXLinkProperty("dn_no","dn_no"), BusinessProperty("ID_cap_clstasklins"), CXChildType(GetType(clstasklin))> _
        Public Overridable Property  clstasklins() As clstasklins
            Get
            	Return mcolclstasklins
            End Get
            Set (ByVal Value As clstasklins)
            	mcolclstasklins = Value
            	SetParentPointerForChildren()
            End Set
        End Property
        
        Public Overridable Sub Loadclstasklins(Optional ByVal blnReset As boolean = False)
        	If Not Me.IsNew Then
	        	If (not clstasklinsIsLoaded) or blnReset Then
	        		clstasklins = clstasklins.Newclstasklins
	        		LoadRelatedChildren(GetType(clstasklins).Name)
	        		clstasklinsIsLoaded = True
	        	End If
        	End If
        End Sub
        
        Protected Overridable Property clstasklinsIsLoaded() As Boolean
            Get 
                clstasklinsIsLoaded = mblnclstasklinsIsLoaded
            End Get
            Set (ByVal Value As Boolean)
                mblnclstasklinsIsLoaded = Value
            End Set
        End Property
		        
        <CXLinkProperty("dc_code","dc_code"), _
CXLinkProperty("dn_no","dn_no"), BusinessProperty("ID_cap_clsDnBins"), CXChildType(GetType(clsDnBin))> _
        Public Overridable Property  clsDnBins() As clsDnBins
            Get
            	Return mcolclsDnBins
            End Get
            Set (ByVal Value As clsDnBins)
            	mcolclsDnBins = Value
            	SetParentPointerForChildren()
            End Set
        End Property
        
        Public Overridable Sub LoadclsDnBins(Optional ByVal blnReset As boolean = False)
        	If Not Me.IsNew Then
	        	If (not clsDnBinsIsLoaded) or blnReset Then
	        		clsDnBins = clsDnBins.NewclsDnBins
	        		LoadRelatedChildren(GetType(clsDnBins).Name)
	        		clsDnBinsIsLoaded = True
	        	End If
        	End If
        End Sub
        
        Protected Overridable Property clsDnBinsIsLoaded() As Boolean
            Get 
                clsDnBinsIsLoaded = mblnclsDnBinsIsLoaded
            End Get
            Set (ByVal Value As Boolean)
                mblnclsDnBinsIsLoaded = Value
            End Set
        End Property
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clsdnhdrs)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vdc_code As System.String, ByVal vdn_no As System.String, Optional ByVal nLevel As Integer = 0) As clsdnhdr
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsdnhdr), nLevel, "dc_code", vdc_code, "dn_no", vdn_no)), clsdnhdr)
    	End Function  	
    	Public Shared Function Load(ByVal vdc_code As System.String, ByVal vdn_no As System.String, Optional ByVal nLevel As Integer = 0) As clsdnhdr
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsdnhdr), nLevel, "dc_code", vdc_code, "dn_no", vdn_no)), clsdnhdr)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsdnhdrs
    	    Return YT.BusinessObject.clsdnhdrs.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsdnhdr, Optional ByVal nLevel As Integer = 0) As clsdnhdrs
    	    Return YT.BusinessObject.clsdnhdrs.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vdc_code As System.String, ByVal vdn_no As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsdnhdr), nLevel, "dc_code", vdc_code, "dn_no", vdn_no))
    	End Sub
    	
    	Public Shared Function Newclsdnhdr() As clsdnhdr
            Return CType(DataPortal.Create(New Criteria(GetType(clsdnhdr), 0)), clsdnhdr)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsdnhdrs
            Return YT.BusinessObject.clsdnhdrs.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "dc_code", New MaxLengthArgs("dc_code", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "dc_code", New BrokenRules.RuleArgs("dc_code"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "dn_no", New MaxLengthArgs("dn_no", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "dn_no", New BrokenRules.RuleArgs("dn_no"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "sony_bch_no", New MaxLengthArgs("sony_bch_no", 20))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "doc_type", New MaxLengthArgs("doc_type", 3))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "city_to", New MaxLengthArgs("city_to", 10))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "deal_to", New MaxLengthArgs("deal_to", 10))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "deal_name", New MaxLengthArgs("deal_name", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "deal_person", New MaxLengthArgs("deal_person", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "deal_tel", New MaxLengthArgs("deal_tel", 30))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "unloading_address", New MaxLengthArgs("unloading_address", 100))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "status_code", New MaxLengthArgs("status_code", 5))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "opt_by", New MaxLengthArgs("opt_by", 20))
      			If Not Me.mblnIgnoreCheckRules Then .CheckRules()      		
    		End With
        End Sub
#End Region

#Region " System Overrides "
		Protected Overrides ReadOnly Property StringResourceManager() As System.Resources.ResourceManager
            Get
                Return gResourceManager
            End Get
        End Property
        
		Protected Overrides Function CustomPropertyDescriptor(ByVal oProp As System.ComponentModel.PropertyDescriptor) As COMExpress.BusinessObject.BusinessPropertyBaseDescriptor
            Return New BusinessPropertyDescriptor(oProp)
        End Function



#End Region

#Region " Lookup methods "
		
		Public Overridable Function Getdoc_typeLookupList(Optional ByVal callType As COMExpress.BusinessObject.CXLookupCallTypeConstants = CXLookupCallTypeConstants.ccCache) As DataView
			Dim oLookup As LookupBase
			If Me.LookupObject Is Nothing Then
                oLookup = New Lookup
            Else
                oLookup = Me.LookupObject
            End If
			Return GetPropertyLookupList(oLookup, "GetDocType", "doc_type", callType)
		End Function
		
		Public Overridable Function Getstatus_codeLookupList(Optional ByVal callType As COMExpress.BusinessObject.CXLookupCallTypeConstants = CXLookupCallTypeConstants.ccCache) As DataView
			Dim oLookup As LookupBase
			If Me.LookupObject Is Nothing Then
                oLookup = New Lookup
            Else
                oLookup = Me.LookupObject
            End If
			Return GetPropertyLookupList(oLookup, "GetDNStatusCode", "status_code", callType)
		End Function
#End Region

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region

    End Class

#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"    
    <Serializable()> Public Class clsdnhdr
        Inherits clsdnhdrBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace