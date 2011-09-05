Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[taskhdr]",SelectFromClause:="[dbo].[taskhdr] ",InsertStoredProcedure:="stp_I_clstaskhdr",SelectStoredProcedure:="stp_S_clstaskhdr",DeleteStoredProcedure:="stp_D_clstaskhdr",UpdateStoredProcedure:="stp_U_clstaskhdr"), Serializable()> _
Public MustInherit Class clstaskhdrBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="dc_code")> Protected mstrdc_code As System.String = ""
        <CXPropertyVar(PropertyName:="task_id")> Protected mstrtask_id As System.String = ""
        <CXPropertyVar(PropertyName:="bch_no")> Protected mstrbch_no As System.String = ""
        <CXPropertyVar(PropertyName:="status_code")> Protected mstrstatus_code As System.String = ""
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="start_dtime")> Protected mdtmstart_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="end_dtime")> Protected mdtmend_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="dc_codeOLD___")> Protected mstrdc_codeOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="task_idOLD___")> Protected mstrtask_idOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="clstasklists")> Protected mcolclstasklists As clstasklists
        Protected mblnclstasklistsIsLoaded As Boolean
        <CXPropertyVar(PropertyName:="clstasklins")> Protected mcolclstasklins As clstasklins
        Protected mblnclstasklinsIsLoaded As Boolean
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
        	mcolclstasklists = clstasklists.Newclstasklists()
        	mcolclstasklins = clstasklins.Newclstasklins()
  			
			
			
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
        Protected Overridable Property task_idOLD___() As System.String
            Get
	            Return mstrtask_idOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrtask_idOLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="dc_code", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clstaskhdr_dc_code")> _
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
        
        <CXDBField(DBFieldName:="task_id", DataType:=12, Size:=20, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=1, SPKeyOrdinal:=1), BusinessProperty("ID_cap_clstaskhdr_task_id")> _
        Public Overridable Property task_id() As System.String
            Get
                If IsReadOK("task_id") Then  Return mstrtask_id
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("task_id") Then  Return
	            If Not Equals(mstrtask_id, Value) Then
	                mstrtask_id = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("task_id")
			        MarkDirty("task_id")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="bch_no", DataType:=12, Size:=20, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clstaskhdr_bch_no"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="status_code", DataType:=10, Size:=5, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clstaskhdr_status_code"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=20, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clstaskhdr_opt_by"), NullValue("")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clstaskhdr_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
        <CXDBField(DBFieldName:="start_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=6), BusinessProperty("ID_cap_clstaskhdr_start_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
        <CXDBField(DBFieldName:="end_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=7), BusinessProperty("ID_cap_clstaskhdr_end_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(102, CXDBFieldFlags), SPUpdateOrdinal:=8), BusinessProperty("ID_cap_clstaskhdr_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
		        
        <CXLinkProperty("dc_code","dc_code"), _
CXLinkProperty("task_id","task_id"), BusinessProperty("ID_cap_clstasklists"), CXChildType(GetType(clstasklist))> _
        Public Overridable Property  clstasklists() As clstasklists
            Get
            	Return mcolclstasklists
            End Get
            Set (ByVal Value As clstasklists)
            	mcolclstasklists = Value
            	SetParentPointerForChildren()
            End Set
        End Property
        
        Public Overridable Sub Loadclstasklists(Optional ByVal blnReset As boolean = False)
        	If Not Me.IsNew Then
	        	If (not clstasklistsIsLoaded) or blnReset Then
	        		clstasklists = clstasklists.Newclstasklists
	        		LoadRelatedChildren(GetType(clstasklists).Name)
	        		clstasklistsIsLoaded = True
	        	End If
        	End If
        End Sub
        
        Protected Overridable Property clstasklistsIsLoaded() As Boolean
            Get 
                clstasklistsIsLoaded = mblnclstasklistsIsLoaded
            End Get
            Set (ByVal Value As Boolean)
                mblnclstasklistsIsLoaded = Value
            End Set
        End Property
		        
        <CXLinkProperty("dc_code","dc_code"), _
CXLinkProperty("task_id","task_id"), BusinessProperty("ID_cap_clstasklins"), CXChildType(GetType(clstasklin))> _
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
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clstaskhdrs)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vdc_code As System.String, ByVal vtask_id As System.String, Optional ByVal nLevel As Integer = 0) As clstaskhdr
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clstaskhdr), nLevel, "dc_code", vdc_code, "task_id", vtask_id)), clstaskhdr)
    	End Function  	
    	Public Shared Function Load(ByVal vdc_code As System.String, ByVal vtask_id As System.String, Optional ByVal nLevel As Integer = 0) As clstaskhdr
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clstaskhdr), nLevel, "dc_code", vdc_code, "task_id", vtask_id)), clstaskhdr)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clstaskhdrs
    	    Return YT.BusinessObject.clstaskhdrs.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clstaskhdr, Optional ByVal nLevel As Integer = 0) As clstaskhdrs
    	    Return YT.BusinessObject.clstaskhdrs.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vdc_code As System.String, ByVal vtask_id As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clstaskhdr), nLevel, "dc_code", vdc_code, "task_id", vtask_id))
    	End Sub
    	
    	Public Shared Function Newclstaskhdr() As clstaskhdr
            Return CType(DataPortal.Create(New Criteria(GetType(clstaskhdr), 0)), clstaskhdr)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clstaskhdrs
            Return YT.BusinessObject.clstaskhdrs.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "dc_code", New MaxLengthArgs("dc_code", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "dc_code", New BrokenRules.RuleArgs("dc_code"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "task_id", New MaxLengthArgs("task_id", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "task_id", New BrokenRules.RuleArgs("task_id"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "bch_no", New MaxLengthArgs("bch_no", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "bch_no", New BrokenRules.RuleArgs("bch_no"))
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
			Return GetPropertyLookupList(oLookup, "GetTaskStatusCode", "status_code", callType)
		End Function
#End Region

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region

    End Class

#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"    
    <Serializable()> Public Class clstaskhdr
        Inherits clstaskhdrBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace