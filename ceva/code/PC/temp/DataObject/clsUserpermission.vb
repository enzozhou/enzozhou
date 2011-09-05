Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[Userpermission]",SelectFromClause:="[dbo].[Userpermission] ",InsertStoredProcedure:="stp_I_clsUserpermission",SelectStoredProcedure:="stp_S_clsUserpermission",DeleteStoredProcedure:="stp_D_clsUserpermission",UpdateStoredProcedure:="stp_U_clsUserpermission"), Serializable()> _
Public MustInherit Class clsUserpermissionBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="user_code")> Protected mstruser_code As System.String = ""
        <CXPropertyVar(PropertyName:="right_no")> Protected mstrright_no As System.String = ""
        <CXPropertyVar(PropertyName:="remark")> Protected mstrremark As System.String = ""
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="user_codeOLD___")> Protected mstruser_codeOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="right_noOLD___")> Protected mstrright_noOLD___ As System.String = ""
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
  			
			
			
			SetParentPointerForChildren()
		End Sub			
#End Region
        
#Region "Properties"
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property user_codeOLD___() As System.String
            Get
	            Return mstruser_codeOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstruser_codeOLD___ = Value
            End Set
        End Property
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property right_noOLD___() As System.String
            Get
	            Return mstrright_noOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrright_noOLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="user_code", DataType:=12, Size:=20, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsUserpermission_user_code")> _
        Public Overridable Property user_code() As System.String
            Get
                If IsReadOK("user_code") Then  Return mstruser_code
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("user_code") Then  Return
	            If Not Equals(mstruser_code, Value) Then
	                mstruser_code = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("user_code")
			        MarkDirty("user_code")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="right_no", DataType:=12, Size:=20, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=1, SPKeyOrdinal:=1), BusinessProperty("ID_cap_clsUserpermission_right_no")> _
        Public Overridable Property right_no() As System.String
            Get
                If IsReadOK("right_no") Then  Return mstrright_no
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("right_no") Then  Return
	            If Not Equals(mstrright_no, Value) Then
	                mstrright_no = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("right_no")
			        MarkDirty("right_no")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="remark", DataType:=11, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clsUserpermission_remark"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=20, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clsUserpermission_opt_by"), NullValue("")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clsUserpermission_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(100, CXDBFieldFlags), SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsUserpermission_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clsUserpermissions)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vuser_code As System.String, ByVal vright_no As System.String, Optional ByVal nLevel As Integer = 0) As clsUserpermission
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsUserpermission), nLevel, "user_code", vuser_code, "right_no", vright_no)), clsUserpermission)
    	End Function  	
    	Public Shared Function Load(ByVal vuser_code As System.String, ByVal vright_no As System.String, Optional ByVal nLevel As Integer = 0) As clsUserpermission
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsUserpermission), nLevel, "user_code", vuser_code, "right_no", vright_no)), clsUserpermission)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsUserpermissions
    	    Return YT.BusinessObject.clsUserpermissions.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsUserpermission, Optional ByVal nLevel As Integer = 0) As clsUserpermissions
    	    Return YT.BusinessObject.clsUserpermissions.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vuser_code As System.String, ByVal vright_no As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsUserpermission), nLevel, "user_code", vuser_code, "right_no", vright_no))
    	End Sub
    	
    	Public Shared Function NewclsUserpermission() As clsUserpermission
            Return CType(DataPortal.Create(New Criteria(GetType(clsUserpermission), 0)), clsUserpermission)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsUserpermissions
            Return YT.BusinessObject.clsUserpermissions.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "user_code", New MaxLengthArgs("user_code", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "user_code", New BrokenRules.RuleArgs("user_code"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "right_no", New MaxLengthArgs("right_no", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "right_no", New BrokenRules.RuleArgs("right_no"))
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
    <Serializable()> Public Class clsUserpermission
        Inherits clsUserpermissionBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace