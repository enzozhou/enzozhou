Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[binStatus]",SelectFromClause:="[dbo].[binStatus] ",InsertStoredProcedure:="stp_I_clsbinStatus",SelectStoredProcedure:="stp_S_clsbinStatus",DeleteStoredProcedure:="stp_D_clsbinStatus",UpdateStoredProcedure:="stp_U_clsbinStatus"), Serializable()> _
Public MustInherit Class clsbinStatusBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="dc_code")> Protected mstrdc_code As System.String = ""
        <CXPropertyVar(PropertyName:="id")> Protected mlngid As System.Int32
        <CXPropertyVar(PropertyName:="bin_area")> Protected mstrbin_area As System.String = ""
        <CXPropertyVar(PropertyName:="bin_code")> Protected mstrbin_code As System.String = ""
        <CXPropertyVar(PropertyName:="dn_no")> Protected mstrdn_no As System.String = ""
        <CXPropertyVar(PropertyName:="type_")> Protected mstrtype_ As System.String = ""
        <CXPropertyVar(PropertyName:="status_code")> Protected mstrstatus_code As System.String = ""
        <CXPropertyVar(PropertyName:="close_auto")> Protected mblnclose_auto As System.Boolean
        <CXPropertyVar(PropertyName:="print_by")> Protected mstrprint_by As System.String = ""
        <CXPropertyVar(PropertyName:="print_counter")> Protected mlngprint_counter As System.Int32
        <CXPropertyVar(PropertyName:="print_dtime")> Protected mdtmprint_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="locked")> Protected mlnglocked As System.Int32
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="start_dtime")> Protected mdtmstart_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="end_dtime")> Protected mdtmend_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="dc_codeOLD___")> Protected mstrdc_codeOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="idOLD___")> Protected mlngidOLD___ As System.Int32
        <CXPropertyVar(PropertyName:="bin_areaOLD___")> Protected mstrbin_areaOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="bin_codeOLD___")> Protected mstrbin_codeOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="dn_noOLD___")> Protected mstrdn_noOLD___ As System.String = ""
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
  			
			
			
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
        Protected Overridable Property idOLD___() As System.Int32
            Get
	            Return mlngidOLD___
            End Get
            Set (ByVal Value As System.Int32)
	            mlngidOLD___ = Value
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
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property bin_codeOLD___() As System.String
            Get
	            Return mstrbin_codeOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrbin_codeOLD___ = Value
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
        
        <CXDBField(DBFieldName:="dc_code", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsbinStatus_dc_code1")> _
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
		<CXDBField(DBFieldName:="id", DataType:=8, Size:=4, Flags:=CType(58, CXDBFieldFlags), SPUpdateOrdinal:=1, SPKeyOrdinal:=1), BusinessProperty("ID_cap_clsbinStatus_id1")> _
        Public Overridable ReadOnly Property id() As System.Int32
            Get
                If IsReadOK("id") Then  Return mlngid
                Return nothing
            End Get	
        End Property
        
        <CXDBField(DBFieldName:="bin_area", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=2, SPKeyOrdinal:=2), BusinessProperty("ID_cap_clsbinStatus_bin_area")> _
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
        
        <CXDBField(DBFieldName:="bin_code", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=3, SPKeyOrdinal:=3), BusinessProperty("ID_cap_clsbinStatus_bin_code1")> _
        Public Overridable Property bin_code() As System.String
            Get
                If IsReadOK("bin_code") Then  Return mstrbin_code
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("bin_code") Then  Return
	            If Not Equals(mstrbin_code, Value) Then
	                mstrbin_code = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("bin_code")
			        MarkDirty("bin_code")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="dn_no", DataType:=12, Size:=20, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=4, SPKeyOrdinal:=4), BusinessProperty("ID_cap_clsbinStatus_dn_no1")> _
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
        
        <CXDBField(DBFieldName:="type", DataType:=10, Size:=3, SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsbinStatus_type1"), NullValue("")> _
        Public Overridable Property type_() As System.String
            Get
                If IsReadOK("type_") Then  Return mstrtype_
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("type_") Then  Return
	            If Not Equals(mstrtype_, Value) Then
	                mstrtype_ = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("type_")
			        MarkDirty("type_")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="status_code", DataType:=10, Size:=5, SPUpdateOrdinal:=6), BusinessProperty("ID_cap_clsbinStatus_status_code1"), NullValue("")> _
        Public Overridable Property status_code() As System.String
            Get
                If IsReadOK("status_code") Then  Return mstrstatus_code
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("status_code") Then  Return
	            If Not Equals(mstrstatus_code, Value) Then
	                mstrstatus_code = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("status_code")
			        MarkDirty("status_code")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="close_auto", DataType:=2, Size:=1, SPUpdateOrdinal:=7), BusinessProperty("ID_cap_clsbinStatus_close_auto1")> _
        Public Overridable Property close_auto() As System.Boolean
            Get
                If IsReadOK("close_auto") Then  Return mblnclose_auto
                Return nothing
            End Get
	        Set(ByVal Value As System.Boolean)
	            If Not IsWriteOK("close_auto") Then  Return
	            If Not Equals(mblnclose_auto, Value) Then
	                mblnclose_auto = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("close_auto")
			        MarkDirty("close_auto")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="print_by", DataType:=12, Size:=20, SPUpdateOrdinal:=8), BusinessProperty("ID_cap_clsbinStatus_print_by1"), NullValue("")> _
        Public Overridable Property print_by() As System.String
            Get
                If IsReadOK("print_by") Then  Return mstrprint_by
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("print_by") Then  Return
	            If Not Equals(mstrprint_by, Value) Then
	                mstrprint_by = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("print_by")
			        MarkDirty("print_by")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="print_counter", DataType:=8, Size:=4, SPUpdateOrdinal:=9), BusinessProperty("ID_cap_clsbinStatus_print_counter1"), NullValue(0)> _
        Public Overridable Property print_counter() As System.Int32
            Get
                If IsReadOK("print_counter") Then  Return mlngprint_counter
                Return nothing
            End Get
	        Set(ByVal Value As System.Int32)
	            If Not IsWriteOK("print_counter") Then  Return
	            If Not Equals(mlngprint_counter, Value) Then
	                mlngprint_counter = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("print_counter")
			        MarkDirty("print_counter")
                End If
            End Set
        End Property
        
        
        Public Overridable Property print_dtimeText() As System.String
            Get
                If IsReadOK("print_dtime") Then  Return mdtmprint_dtime.Text
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("print_dtime") Then  Return
	            If Not Equals(mdtmprint_dtime.Text, Value) Then
	                mdtmprint_dtime.Text = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("print_dtime")
			        MarkDirty("print_dtime")
                End If
            End Set
        End Property
        <CXDBField(DBFieldName:="print_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=10), BusinessProperty("ID_cap_clsbinStatus_print_dtime1"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
        Public Overridable Property print_dtime() As Object
            Get
            	Dim strValue As string = Me.print_dtimeText
            	If strValue = String.Empty Then
            		Return System.DBNull.Value
            	Else
                	Return strValue
                End If
            End Get
            Set(ByVal Value As Object)
                If IsDate(Value) Then
                    Me.print_dtimeText = CType(Value, String)
                Else
                    Me.print_dtimeText = String.Empty
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="locked", DataType:=8, Size:=4, SPUpdateOrdinal:=11), BusinessProperty("ID_cap_clsbinStatus_locked1"), NullValue(0)> _
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
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=20, SPUpdateOrdinal:=12), BusinessProperty("ID_cap_clsbinStatus_opt_by1"), NullValue("")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=13), BusinessProperty("ID_cap_clsbinStatus_opt_dtime1"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
        <CXDBField(DBFieldName:="start_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=14), BusinessProperty("ID_cap_clsbinStatus_start_dtime1"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
        <CXDBField(DBFieldName:="end_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=15), BusinessProperty("ID_cap_clsbinStatus_end_dtime1"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(102, CXDBFieldFlags), SPUpdateOrdinal:=16), BusinessProperty("ID_cap_clsbinStatus_opt_timestamp1")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clsbinStatuses)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vdc_code As System.String, ByVal vid As System.Int32, ByVal vbin_area As System.String, ByVal vbin_code As System.String, ByVal vdn_no As System.String, Optional ByVal nLevel As Integer = 0) As clsbinStatus
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsbinStatus), nLevel, "dc_code", vdc_code, "id", vid, "bin_area", vbin_area, "bin_code", vbin_code, "dn_no", vdn_no)), clsbinStatus)
    	End Function  	
    	Public Shared Function Load(ByVal vdc_code As System.String, ByVal vid As System.Int32, ByVal vbin_area As System.String, ByVal vbin_code As System.String, ByVal vdn_no As System.String, Optional ByVal nLevel As Integer = 0) As clsbinStatus
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsbinStatus), nLevel, "dc_code", vdc_code, "id", vid, "bin_area", vbin_area, "bin_code", vbin_code, "dn_no", vdn_no)), clsbinStatus)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsbinStatuses
    	    Return YT.BusinessObject.clsbinStatuses.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsbinStatus, Optional ByVal nLevel As Integer = 0) As clsbinStatuses
    	    Return YT.BusinessObject.clsbinStatuses.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vdc_code As System.String, ByVal vid As System.Int32, ByVal vbin_area As System.String, ByVal vbin_code As System.String, ByVal vdn_no As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsbinStatus), nLevel, "dc_code", vdc_code, "id", vid, "bin_area", vbin_area, "bin_code", vbin_code, "dn_no", vdn_no))
    	End Sub
    	
    	Public Shared Function NewclsbinStatus() As clsbinStatus
            Return CType(DataPortal.Create(New Criteria(GetType(clsbinStatus), 0)), clsbinStatus)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsbinStatuses
            Return YT.BusinessObject.clsbinStatuses.Fetch(strWhereClause , nLevel, iMaxNumber)
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
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "bin_code", New MaxLengthArgs("bin_code", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "bin_code", New BrokenRules.RuleArgs("bin_code"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "dn_no", New MaxLengthArgs("dn_no", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "dn_no", New BrokenRules.RuleArgs("dn_no"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "type_", New MaxLengthArgs("type_", 3))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "status_code", New MaxLengthArgs("status_code", 5))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "print_by", New MaxLengthArgs("print_by", 20))
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


#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region

    End Class

#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"    
    <Serializable()> Public Class clsbinStatus
        Inherits clsbinStatusBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace