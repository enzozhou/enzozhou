Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[binarea]",SelectFromClause:="[dbo].[binarea] ",InsertStoredProcedure:="stp_I_clsbinarea",SelectStoredProcedure:="stp_S_clsbinarea",DeleteStoredProcedure:="stp_D_clsbinarea",UpdateStoredProcedure:="stp_U_clsbinarea"), Serializable()> _
Public MustInherit Class clsbinareaBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="dc_code")> Protected mstrdc_code As System.String = ""
        <CXPropertyVar(PropertyName:="bin_area")> Protected mstrbin_area As System.String = ""
        <CXPropertyVar(PropertyName:="description")> Protected mstrdescription As System.String = ""
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="dc_codeOLD___")> Protected mstrdc_codeOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="bin_areaOLD___")> Protected mstrbin_areaOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="clsbins")> Protected mcolclsbins As clsbins
        Protected mblnclsbinsIsLoaded As Boolean
        <CXPropertyVar(PropertyName:="clsbinStatuses")> Protected mcolclsbinStatuses As clsbinStatuses
        Protected mblnclsbinStatusesIsLoaded As Boolean
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
        	mcolclsbins = clsbins.Newclsbins()
        	mcolclsbinStatuses = clsbinStatuses.NewclsbinStatuses()
  			
			
			
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
        Protected Overridable Property bin_areaOLD___() As System.String
            Get
	            Return mstrbin_areaOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrbin_areaOLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="dc_code", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsbinarea_dc_code")> _
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
        
        <CXDBField(DBFieldName:="bin_area", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=1, SPKeyOrdinal:=1), BusinessProperty("ID_cap_clsbinarea_bin_area")> _
        Public Overridable Property bin_area() As System.String
            Get
                If IsReadOK("bin_area") Then  Return mstrbin_area
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("bin_area") Then  Return
	            If Not Equals(mstrbin_area, Value) Then
	                mstrbin_area = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("bin_area")
			        MarkDirty("bin_area")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="description", DataType:=12, Size:=50, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clsbinarea_description"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=50, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clsbinarea_opt_by"), NullValue("")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clsbinarea_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(102, CXDBFieldFlags), SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsbinarea_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
		        
        <CXLinkProperty("dc_code","dc_code"), _
CXLinkProperty("bin_area","bin_area"), BusinessProperty("ID_cap_clsbins"), CXChildType(GetType(clsbin))> _
        Public Overridable Property  clsbins() As clsbins
            Get
            	Return mcolclsbins
            End Get
            Set (ByVal Value As clsbins)
            	mcolclsbins = Value
            	SetParentPointerForChildren()
            End Set
        End Property
        
        Public Overridable Sub Loadclsbins(Optional ByVal blnReset As boolean = False)
        	If Not Me.IsNew Then
	        	If (not clsbinsIsLoaded) or blnReset Then
	        		clsbins = clsbins.Newclsbins
	        		LoadRelatedChildren(GetType(clsbins).Name)
	        		clsbinsIsLoaded = True
	        	End If
        	End If
        End Sub
        
        Protected Overridable Property clsbinsIsLoaded() As Boolean
            Get 
                clsbinsIsLoaded = mblnclsbinsIsLoaded
            End Get
            Set (ByVal Value As Boolean)
                mblnclsbinsIsLoaded = Value
            End Set
        End Property
		        
        <CXLinkProperty("dc_code","dc_code"), _
CXLinkProperty("bin_area","bin_area"), BusinessProperty("ID_cap_clsbinStatuses1"), CXChildType(GetType(clsbinStatus))> _
        Public Overridable Property  clsbinStatuses() As clsbinStatuses
            Get
            	Return mcolclsbinStatuses
            End Get
            Set (ByVal Value As clsbinStatuses)
            	mcolclsbinStatuses = Value
            	SetParentPointerForChildren()
            End Set
        End Property
        
        Public Overridable Sub LoadclsbinStatuses(Optional ByVal blnReset As boolean = False)
        	If Not Me.IsNew Then
	        	If (not clsbinStatusesIsLoaded) or blnReset Then
	        		clsbinStatuses = clsbinStatuses.NewclsbinStatuses
	        		LoadRelatedChildren(GetType(clsbinStatuses).Name)
	        		clsbinStatusesIsLoaded = True
	        	End If
        	End If
        End Sub
        
        Protected Overridable Property clsbinStatusesIsLoaded() As Boolean
            Get 
                clsbinStatusesIsLoaded = mblnclsbinStatusesIsLoaded
            End Get
            Set (ByVal Value As Boolean)
                mblnclsbinStatusesIsLoaded = Value
            End Set
        End Property
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clsbinareas)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vdc_code As System.String, ByVal vbin_area As System.String, Optional ByVal nLevel As Integer = 0) As clsbinarea
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsbinarea), nLevel, "dc_code", vdc_code, "bin_area", vbin_area)), clsbinarea)
    	End Function  	
    	Public Shared Function Load(ByVal vdc_code As System.String, ByVal vbin_area As System.String, Optional ByVal nLevel As Integer = 0) As clsbinarea
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsbinarea), nLevel, "dc_code", vdc_code, "bin_area", vbin_area)), clsbinarea)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsbinareas
    	    Return YT.BusinessObject.clsbinareas.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsbinarea, Optional ByVal nLevel As Integer = 0) As clsbinareas
    	    Return YT.BusinessObject.clsbinareas.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vdc_code As System.String, ByVal vbin_area As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsbinarea), nLevel, "dc_code", vdc_code, "bin_area", vbin_area))
    	End Sub
    	
    	Public Shared Function Newclsbinarea() As clsbinarea
            Return CType(DataPortal.Create(New Criteria(GetType(clsbinarea), 0)), clsbinarea)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsbinareas
            Return YT.BusinessObject.clsbinareas.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "dc_code", New MaxLengthArgs("dc_code", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "dc_code", New BrokenRules.RuleArgs("dc_code"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "bin_area", New MaxLengthArgs("bin_area", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "bin_area", New BrokenRules.RuleArgs("bin_area"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "description", New MaxLengthArgs("description", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "opt_by", New MaxLengthArgs("opt_by", 50))
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


#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region

    End Class

#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"    
    <Serializable()> Public Class clsbinarea
        Inherits clsbinareaBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace