Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[cityairport]",SelectFromClause:="[dbo].[cityairport] ",InsertStoredProcedure:="stp_I_clscityairport",SelectStoredProcedure:="stp_S_clscityairport",DeleteStoredProcedure:="stp_D_clscityairport",UpdateStoredProcedure:="stp_U_clscityairport"), Serializable()> _
Public MustInherit Class clscityairportBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="destination")> Protected mstrdestination As System.String = ""
        <CXPropertyVar(PropertyName:="province")> Protected mstrprovince As System.String = ""
        <CXPropertyVar(PropertyName:="transit")> Protected mstrtransit As System.String = ""
        <CXPropertyVar(PropertyName:="type_")> Protected mstrtype_ As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="destinationOLD___")> Protected mstrdestinationOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="type_OLD___")> Protected mstrtype_OLD___ As System.String = ""
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
  			
			
			
			SetParentPointerForChildren()
		End Sub			
#End Region
        
#Region "Properties"
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property destinationOLD___() As System.String
            Get
	            Return mstrdestinationOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrdestinationOLD___ = Value
            End Set
        End Property
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property type_OLD___() As System.String
            Get
	            Return mstrtype_OLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrtype_OLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="destination", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clscityairport_destination")> _
        Public Overridable Property destination() As System.String
            Get
                If IsReadOK("destination") Then  Return mstrdestination
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("destination") Then  Return
	            If Not Equals(mstrdestination, Value) Then
	                mstrdestination = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("destination")
			        MarkDirty("destination")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="province", DataType:=12, Size:=10, Flags:=CType(2, CXDBFieldFlags), SPUpdateOrdinal:=1), BusinessProperty("ID_cap_clscityairport_province")> _
        Public Overridable Property province() As System.String
            Get
                If IsReadOK("province") Then  Return mstrprovince
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("province") Then  Return
	            If Not Equals(mstrprovince, Value) Then
	                mstrprovince = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("province")
			        MarkDirty("province")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="transit", DataType:=12, Size:=10, Flags:=CType(2, CXDBFieldFlags), SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clscityairport_transit")> _
        Public Overridable Property transit() As System.String
            Get
                If IsReadOK("transit") Then  Return mstrtransit
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("transit") Then  Return
	            If Not Equals(mstrtransit, Value) Then
	                mstrtransit = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("transit")
			        MarkDirty("transit")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="type", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=3, SPKeyOrdinal:=1), BusinessProperty("ID_cap_clscityairport_type")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clscityairport_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(102, CXDBFieldFlags), SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clscityairport_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clscityairports)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vdestination As System.String, ByVal vtype_ As System.String, Optional ByVal nLevel As Integer = 0) As clscityairport
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clscityairport), nLevel, "destination", vdestination, "type_", vtype_)), clscityairport)
    	End Function  	
    	Public Shared Function Load(ByVal vdestination As System.String, ByVal vtype_ As System.String, Optional ByVal nLevel As Integer = 0) As clscityairport
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clscityairport), nLevel, "destination", vdestination, "type_", vtype_)), clscityairport)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clscityairports
    	    Return YT.BusinessObject.clscityairports.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clscityairport, Optional ByVal nLevel As Integer = 0) As clscityairports
    	    Return YT.BusinessObject.clscityairports.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vdestination As System.String, ByVal vtype_ As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clscityairport), nLevel, "destination", vdestination, "type_", vtype_))
    	End Sub
    	
    	Public Shared Function Newclscityairport() As clscityairport
            Return CType(DataPortal.Create(New Criteria(GetType(clscityairport), 0)), clscityairport)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clscityairports
            Return YT.BusinessObject.clscityairports.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "destination", New MaxLengthArgs("destination", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "destination", New BrokenRules.RuleArgs("destination"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "province", New MaxLengthArgs("province", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "province", New BrokenRules.RuleArgs("province"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "transit", New MaxLengthArgs("transit", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "transit", New BrokenRules.RuleArgs("transit"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "type_", New MaxLengthArgs("type_", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "type_", New BrokenRules.RuleArgs("type_"))
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
    <Serializable()> Public Class clscityairport
        Inherits clscityairportBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace