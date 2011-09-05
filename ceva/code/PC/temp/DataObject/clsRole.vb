Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[Role]",SelectFromClause:="[dbo].[Role] ",InsertStoredProcedure:="stp_I_clsRole",SelectStoredProcedure:="stp_S_clsRole",DeleteStoredProcedure:="stp_D_clsRole",UpdateStoredProcedure:="stp_U_clsRole"), Serializable()> _
Public MustInherit Class clsRoleBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="role_code")> Protected mstrrole_code As System.String = ""
        <CXPropertyVar(PropertyName:="role_name")> Protected mstrrole_name As System.String = ""
        <CXPropertyVar(PropertyName:="remark")> Protected mstrremark As System.String = ""
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="role_codeOLD___")> Protected mstrrole_codeOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="clsRolepermissions")> Protected mcolclsRolepermissions As clsRolepermissions
        Protected mblnclsRolepermissionsIsLoaded As Boolean
        <CXPropertyVar(PropertyName:="clsUserroles")> Protected mcolclsUserroles As clsUserroles
        Protected mblnclsUserrolesIsLoaded As Boolean
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
        	mcolclsRolepermissions = clsRolepermissions.NewclsRolepermissions()
        	mcolclsUserroles = clsUserroles.NewclsUserroles()
  			
			
			
			SetParentPointerForChildren()
		End Sub			
#End Region
        
#Region "Properties"
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property role_codeOLD___() As System.String
            Get
	            Return mstrrole_codeOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrrole_codeOLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="role_code", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsRole_role_code")> _
        Public Overridable Property role_code() As System.String
            Get
                If IsReadOK("role_code") Then  Return mstrrole_code
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("role_code") Then  Return
	            If Not Equals(mstrrole_code, Value) Then
	                mstrrole_code = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("role_code")
			        MarkDirty("role_code")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="role_name", DataType:=12, Size:=50, SPUpdateOrdinal:=1), BusinessProperty("ID_cap_clsRole_role_name"), NullValue("")> _
        Public Overridable Property role_name() As System.String
            Get
                If IsReadOK("role_name") Then  Return mstrrole_name
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("role_name") Then  Return
	            If Not Equals(mstrrole_name, Value) Then
	                mstrrole_name = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("role_name")
			        MarkDirty("role_name")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="remark", DataType:=11, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clsRole_remark"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=20, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clsRole_opt_by"), NullValue("")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clsRole_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(100, CXDBFieldFlags), SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsRole_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
		        
        <CXLinkProperty("role_code","role_code"), BusinessProperty("ID_cap_clsRolepermissions"), CXChildType(GetType(clsRolepermission))> _
        Public Overridable Property  clsRolepermissions() As clsRolepermissions
            Get
            	Return mcolclsRolepermissions
            End Get
            Set (ByVal Value As clsRolepermissions)
            	mcolclsRolepermissions = Value
            	SetParentPointerForChildren()
            End Set
        End Property
        
        Public Overridable Sub LoadclsRolepermissions(Optional ByVal blnReset As boolean = False)
        	If Not Me.IsNew Then
	        	If (not clsRolepermissionsIsLoaded) or blnReset Then
	        		clsRolepermissions = clsRolepermissions.NewclsRolepermissions
	        		LoadRelatedChildren(GetType(clsRolepermissions).Name)
	        		clsRolepermissionsIsLoaded = True
	        	End If
        	End If
        End Sub
        
        Protected Overridable Property clsRolepermissionsIsLoaded() As Boolean
            Get 
                clsRolepermissionsIsLoaded = mblnclsRolepermissionsIsLoaded
            End Get
            Set (ByVal Value As Boolean)
                mblnclsRolepermissionsIsLoaded = Value
            End Set
        End Property
		        
        <CXLinkProperty("role_code","role_code"), BusinessProperty("ID_cap_clsUserroles"), CXChildType(GetType(clsUserrole))> _
        Public Overridable Property  clsUserroles() As clsUserroles
            Get
            	Return mcolclsUserroles
            End Get
            Set (ByVal Value As clsUserroles)
            	mcolclsUserroles = Value
            	SetParentPointerForChildren()
            End Set
        End Property
        
        Public Overridable Sub LoadclsUserroles(Optional ByVal blnReset As boolean = False)
        	If Not Me.IsNew Then
	        	If (not clsUserrolesIsLoaded) or blnReset Then
	        		clsUserroles = clsUserroles.NewclsUserroles
	        		LoadRelatedChildren(GetType(clsUserroles).Name)
	        		clsUserrolesIsLoaded = True
	        	End If
        	End If
        End Sub
        
        Protected Overridable Property clsUserrolesIsLoaded() As Boolean
            Get 
                clsUserrolesIsLoaded = mblnclsUserrolesIsLoaded
            End Get
            Set (ByVal Value As Boolean)
                mblnclsUserrolesIsLoaded = Value
            End Set
        End Property
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clsRoles)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vrole_code As System.String, Optional ByVal nLevel As Integer = 0) As clsRole
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsRole), nLevel, "role_code", vrole_code)), clsRole)
    	End Function  	
    	Public Shared Function Load(ByVal vrole_code As System.String, Optional ByVal nLevel As Integer = 0) As clsRole
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsRole), nLevel, "role_code", vrole_code)), clsRole)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsRoles
    	    Return YT.BusinessObject.clsRoles.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsRole, Optional ByVal nLevel As Integer = 0) As clsRoles
    	    Return YT.BusinessObject.clsRoles.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vrole_code As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsRole), nLevel, "role_code", vrole_code))
    	End Sub
    	
    	Public Shared Function NewclsRole() As clsRole
            Return CType(DataPortal.Create(New Criteria(GetType(clsRole), 0)), clsRole)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsRoles
            Return YT.BusinessObject.clsRoles.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "role_code", New MaxLengthArgs("role_code", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "role_code", New BrokenRules.RuleArgs("role_code"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "role_name", New MaxLengthArgs("role_name", 50))
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
    <Serializable()> Public Class clsRole
        Inherits clsRoleBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace