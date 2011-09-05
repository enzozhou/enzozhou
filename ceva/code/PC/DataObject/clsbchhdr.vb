Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[bchhdr]",SelectFromClause:="[dbo].[bchhdr] ",InsertStoredProcedure:="stp_I_clsbchhdr",SelectStoredProcedure:="stp_S_clsbchhdr",DeleteStoredProcedure:="stp_D_clsbchhdr",UpdateStoredProcedure:="stp_U_clsbchhdr"), Serializable()> _
Public MustInherit Class clsbchhdrBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="dc_code")> Protected mstrdc_code As System.String = ""
        <CXPropertyVar(PropertyName:="bch_no")> Protected mstrbch_no As System.String = ""
        <CXPropertyVar(PropertyName:="description")> Protected mstrdescription As System.String = ""
        <CXPropertyVar(PropertyName:="status_code")> Protected mstrstatus_code As System.String = ""
        <CXPropertyVar(PropertyName:="locked")> Protected mlnglocked As System.Int32
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="start_dtime")> Protected mdtmstart_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="end_dtime")> Protected mdtmend_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="dc_codeOLD___")> Protected mstrdc_codeOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="bch_noOLD___")> Protected mstrbch_noOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="clsbchlins")> Protected mcolclsbchlins As clsbchlins
        Protected mblnclsbchlinsIsLoaded As Boolean
        <CXPropertyVar(PropertyName:="clsDnBins")> Protected mcolclsDnBins As clsDnBins
        Protected mblnclsDnBinsIsLoaded As Boolean
        <CXPropertyVar(PropertyName:="clstaskhdrs")> Protected mcolclstaskhdrs As clstaskhdrs
        Protected mblnclstaskhdrsIsLoaded As Boolean
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
        	mcolclsbchlins = clsbchlins.Newclsbchlins()
        	mcolclsDnBins = clsDnBins.NewclsDnBins()
        	mcolclstaskhdrs = clstaskhdrs.Newclstaskhdrs()
  			
			
			
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
        Protected Overridable Property bch_noOLD___() As System.String
            Get
	            Return mstrbch_noOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrbch_noOLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="dc_code", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsbchhdr_dc_code1")> _
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
        
        <CXDBField(DBFieldName:="bch_no", DataType:=12, Size:=20, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=1, SPKeyOrdinal:=1), BusinessProperty("ID_cap_clsbchhdr_bch_no")> _
        Public Overridable Property bch_no() As System.String
            Get
                If IsReadOK("bch_no") Then  Return mstrbch_no
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("bch_no") Then  Return
	            If Not Equals(mstrbch_no, Value) Then
	                mstrbch_no = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("bch_no")
			        MarkDirty("bch_no")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="description", DataType:=12, Size:=20, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clsbchhdr_description"), NullValue("")> _
        Public Overridable Property description() As System.String
            Get
                If IsReadOK("description") Then  Return mstrdescription
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("description") Then  Return
	            If Not Equals(mstrdescription, Value) Then
	                mstrdescription = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("description")
			        MarkDirty("description")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="status_code", DataType:=10, Size:=5, SPUpdateOrdinal:=9), BusinessProperty("ID_cap_clsbchhdr_status_code"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="locked", DataType:=8, Size:=4, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clsbchhdr_locked"), NullValue(0)> _
        Public Overridable Property locked() As System.Int32
            Get
                If IsReadOK("locked") Then  Return mlnglocked
                Return nothing
            End Get
	        Set(ByVal Value As System.Int32)
	            If Not IsWriteOK("locked") Then  Return
	            If Not Equals(mlnglocked, Value) Then
	                mlnglocked = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("locked")
			        MarkDirty("locked")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=20, SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsbchhdr_opt_by"), NullValue("")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=6), BusinessProperty("ID_cap_clsbchhdr_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
        <CXDBField(DBFieldName:="start_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=7), BusinessProperty("ID_cap_clsbchhdr_start_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
        <CXDBField(DBFieldName:="end_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=8), BusinessProperty("ID_cap_clsbchhdr_end_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(102, CXDBFieldFlags), SPUpdateOrdinal:=9), BusinessProperty("ID_cap_clsbchhdr_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
		        
        <CXLinkProperty("dc_code","dc_code"), _
CXLinkProperty("bch_no","bch_no"), BusinessProperty("ID_cap_clsbchlins"), CXChildType(GetType(clsbchlin))> _
        Public Overridable Property  clsbchlins() As clsbchlins
            Get
            	Return mcolclsbchlins
            End Get
            Set (ByVal Value As clsbchlins)
            	mcolclsbchlins = Value
            	SetParentPointerForChildren()
            End Set
        End Property
        
        Public Overridable Sub Loadclsbchlins(Optional ByVal blnReset As boolean = False)
        	If Not Me.IsNew Then
	        	If (not clsbchlinsIsLoaded) or blnReset Then
	        		clsbchlins = clsbchlins.Newclsbchlins
	        		LoadRelatedChildren(GetType(clsbchlins).Name)
	        		clsbchlinsIsLoaded = True
	        	End If
        	End If
        End Sub
        
        Protected Overridable Property clsbchlinsIsLoaded() As Boolean
            Get 
                clsbchlinsIsLoaded = mblnclsbchlinsIsLoaded
            End Get
            Set (ByVal Value As Boolean)
                mblnclsbchlinsIsLoaded = Value
            End Set
        End Property
		        
        <CXLinkProperty("dc_code","dc_code"), _
CXLinkProperty("bch_no","bch_no"), BusinessProperty("ID_cap_clsDnBins"), CXChildType(GetType(clsDnBin))> _
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
		        
        <CXLinkProperty("dc_code","dc_code"), _
CXLinkProperty("bch_no","bch_no"), BusinessProperty("ID_cap_clstaskhdrs"), CXChildType(GetType(clstaskhdr))> _
        Public Overridable Property  clstaskhdrs() As clstaskhdrs
            Get
            	Return mcolclstaskhdrs
            End Get
            Set (ByVal Value As clstaskhdrs)
            	mcolclstaskhdrs = Value
            	SetParentPointerForChildren()
            End Set
        End Property
        
        Public Overridable Sub Loadclstaskhdrs(Optional ByVal blnReset As boolean = False)
        	If Not Me.IsNew Then
	        	If (not clstaskhdrsIsLoaded) or blnReset Then
	        		clstaskhdrs = clstaskhdrs.Newclstaskhdrs
	        		LoadRelatedChildren(GetType(clstaskhdrs).Name)
	        		clstaskhdrsIsLoaded = True
	        	End If
        	End If
        End Sub
        
        Protected Overridable Property clstaskhdrsIsLoaded() As Boolean
            Get 
                clstaskhdrsIsLoaded = mblnclstaskhdrsIsLoaded
            End Get
            Set (ByVal Value As Boolean)
                mblnclstaskhdrsIsLoaded = Value
            End Set
        End Property
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clsbchhdrs)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vdc_code As System.String, ByVal vbch_no As System.String, Optional ByVal nLevel As Integer = 0) As clsbchhdr
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsbchhdr), nLevel, "dc_code", vdc_code, "bch_no", vbch_no)), clsbchhdr)
    	End Function  	
    	Public Shared Function Load(ByVal vdc_code As System.String, ByVal vbch_no As System.String, Optional ByVal nLevel As Integer = 0) As clsbchhdr
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsbchhdr), nLevel, "dc_code", vdc_code, "bch_no", vbch_no)), clsbchhdr)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsbchhdrs
    	    Return YT.BusinessObject.clsbchhdrs.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsbchhdr, Optional ByVal nLevel As Integer = 0) As clsbchhdrs
    	    Return YT.BusinessObject.clsbchhdrs.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vdc_code As System.String, ByVal vbch_no As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsbchhdr), nLevel, "dc_code", vdc_code, "bch_no", vbch_no))
    	End Sub
    	
    	Public Shared Function Newclsbchhdr() As clsbchhdr
            Return CType(DataPortal.Create(New Criteria(GetType(clsbchhdr), 0)), clsbchhdr)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsbchhdrs
            Return YT.BusinessObject.clsbchhdrs.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "dc_code", New MaxLengthArgs("dc_code", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "dc_code", New BrokenRules.RuleArgs("dc_code"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "bch_no", New MaxLengthArgs("bch_no", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "bch_no", New BrokenRules.RuleArgs("bch_no"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "description", New MaxLengthArgs("description", 20))
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
		
		Public Overridable Function Getstatus_codeLookupList(Optional ByVal callType As COMExpress.BusinessObject.CXLookupCallTypeConstants = CXLookupCallTypeConstants.ccCache) As DataView
			Dim oLookup As LookupBase
			If Me.LookupObject Is Nothing Then
                oLookup = New Lookup
            Else
                oLookup = Me.LookupObject
            End If
			Return GetPropertyLookupList(oLookup, "GetBanchStatusCode", "status_code", callType)
		End Function
#End Region

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region

    End Class

#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"    
    <Serializable()> Public Class clsbchhdr
        Inherits clsbchhdrBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace