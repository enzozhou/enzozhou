Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[bin]",SelectFromClause:="[dbo].[bin] ",InsertStoredProcedure:="stp_I_clsbin",SelectStoredProcedure:="stp_S_clsbin",DeleteStoredProcedure:="stp_D_clsbin",UpdateStoredProcedure:="stp_U_clsbin"), Serializable()> _
Public MustInherit Class clsbinBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="dc_code")> Protected mstrdc_code As System.String = ""
        <CXPropertyVar(PropertyName:="bin_code")> Protected mstrbin_code As System.String = ""
        <CXPropertyVar(PropertyName:="description")> Protected mstrdescription As System.String = ""
        <CXPropertyVar(PropertyName:="bin_area")> Protected mstrbin_area As System.String = ""
        <CXPropertyVar(PropertyName:="length")> Protected mcurlength As System.Decimal
        <CXPropertyVar(PropertyName:="width_")> Protected mcurwidth_ As System.Decimal
        <CXPropertyVar(PropertyName:="weight")> Protected mcurweight As System.Decimal
        <CXPropertyVar(PropertyName:="volume")> Protected mcurvolume As System.Decimal
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="dc_codeOLD___")> Protected mstrdc_codeOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="bin_codeOLD___")> Protected mstrbin_codeOLD___ As System.String = ""
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
        Protected Overridable Property bin_codeOLD___() As System.String
            Get
	            Return mstrbin_codeOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrbin_codeOLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="dc_code", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsbin_dc_code")> _
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
        
        <CXDBField(DBFieldName:="bin_code", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=1, SPKeyOrdinal:=1), BusinessProperty("ID_cap_clsbin_bin_code")> _
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
        
        <CXDBField(DBFieldName:="description", DataType:=12, Size:=50, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clsbin_description"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="bin_area", DataType:=12, Size:=10, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clsbin_bin_area"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="length", DataType:=5, Size:=9, Scale:=3, Precision:=12, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clsbin_length"), NullValue(0)> _
        Public Overridable Property length() As System.Decimal
            Get
                If IsReadOK("length") Then  Return mcurlength
                Return nothing
            End Get
	        Set(ByVal Value As System.Decimal)
	            If Not IsWriteOK("length") Then  Return
	            If Not Equals(mcurlength, Value) Then
	                mcurlength = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("length")
			        MarkDirty("length")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="width", DataType:=5, Size:=9, Scale:=3, Precision:=12, SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsbin_width"), NullValue(0)> _
        Public Overridable Property width_() As System.Decimal
            Get
                If IsReadOK("width_") Then  Return mcurwidth_
                Return nothing
            End Get
	        Set(ByVal Value As System.Decimal)
	            If Not IsWriteOK("width_") Then  Return
	            If Not Equals(mcurwidth_, Value) Then
	                mcurwidth_ = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("width_")
			        MarkDirty("width_")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="weight", DataType:=5, Size:=9, Scale:=3, Precision:=12, SPUpdateOrdinal:=6), BusinessProperty("ID_cap_clsbin_weight"), NullValue(0)> _
        Public Overridable Property weight() As System.Decimal
            Get
                If IsReadOK("weight") Then  Return mcurweight
                Return nothing
            End Get
	        Set(ByVal Value As System.Decimal)
	            If Not IsWriteOK("weight") Then  Return
	            If Not Equals(mcurweight, Value) Then
	                mcurweight = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("weight")
			        MarkDirty("weight")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="volume", DataType:=5, Size:=13, Scale:=9, Precision:=20, SPUpdateOrdinal:=7), BusinessProperty("ID_cap_clsbin_volume"), NullValue(0)> _
        Public Overridable Property volume() As System.Decimal
            Get
                If IsReadOK("volume") Then  Return mcurvolume
                Return nothing
            End Get
	        Set(ByVal Value As System.Decimal)
	            If Not IsWriteOK("volume") Then  Return
	            If Not Equals(mcurvolume, Value) Then
	                mcurvolume = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("volume")
			        MarkDirty("volume")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=20, SPUpdateOrdinal:=8), BusinessProperty("ID_cap_clsbin_opt_by"), NullValue("")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=9), BusinessProperty("ID_cap_clsbin_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(102, CXDBFieldFlags), SPUpdateOrdinal:=10), BusinessProperty("ID_cap_clsbin_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clsbins)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vdc_code As System.String, ByVal vbin_code As System.String, Optional ByVal nLevel As Integer = 0) As clsbin
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsbin), nLevel, "dc_code", vdc_code, "bin_code", vbin_code)), clsbin)
    	End Function  	
    	Public Shared Function Load(ByVal vdc_code As System.String, ByVal vbin_code As System.String, Optional ByVal nLevel As Integer = 0) As clsbin
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsbin), nLevel, "dc_code", vdc_code, "bin_code", vbin_code)), clsbin)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsbins
    	    Return YT.BusinessObject.clsbins.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsbin, Optional ByVal nLevel As Integer = 0) As clsbins
    	    Return YT.BusinessObject.clsbins.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vdc_code As System.String, ByVal vbin_code As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsbin), nLevel, "dc_code", vdc_code, "bin_code", vbin_code))
    	End Sub
    	
    	Public Shared Function Newclsbin() As clsbin
            Return CType(DataPortal.Create(New Criteria(GetType(clsbin), 0)), clsbin)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsbins
            Return YT.BusinessObject.clsbins.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "dc_code", New MaxLengthArgs("dc_code", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "dc_code", New BrokenRules.RuleArgs("dc_code"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "bin_code", New MaxLengthArgs("bin_code", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "bin_code", New BrokenRules.RuleArgs("bin_code"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "description", New MaxLengthArgs("description", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "bin_area", New MaxLengthArgs("bin_area", 10))
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
    <Serializable()> Public Class clsbin
        Inherits clsbinBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace