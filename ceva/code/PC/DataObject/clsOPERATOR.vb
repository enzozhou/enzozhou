Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[OPERATOR]",SelectFromClause:="[dbo].[OPERATOR] ",InsertStoredProcedure:="stp_I_clsOPERATOR",SelectStoredProcedure:="stp_S_clsOPERATOR",DeleteStoredProcedure:="stp_D_clsOPERATOR",UpdateStoredProcedure:="stp_U_clsOPERATOR"), Serializable()> _
Public MustInherit Class clsOPERATORBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="user_code")> Protected mstruser_code As System.String = ""
        <CXPropertyVar(PropertyName:="user_name")> Protected mstruser_name As System.String = ""
        <CXPropertyVar(PropertyName:="password_")> Protected mstrpassword_ As System.String = ""
        <CXPropertyVar(PropertyName:="STCD")> Protected mstrSTCD As System.String = ""
        <CXPropertyVar(PropertyName:="allowlogin")> Protected mblnallowlogin As System.Boolean
        <CXPropertyVar(PropertyName:="isadmin")> Protected mblnisadmin As System.Boolean
        <CXPropertyVar(PropertyName:="title")> Protected mstrtitle As System.String = ""
        <CXPropertyVar(PropertyName:="tel")> Protected mstrtel As System.String = ""
        <CXPropertyVar(PropertyName:="fax")> Protected mstrfax As System.String = ""
        <CXPropertyVar(PropertyName:="mobile")> Protected mstrmobile As System.String = ""
        <CXPropertyVar(PropertyName:="email")> Protected mstremail As System.String = ""
        <CXPropertyVar(PropertyName:="create_date")> Protected mdtmcreate_date As New SmartDate()
        <CXPropertyVar(PropertyName:="update_date")> Protected mdtmupdate_date As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="user_codeOLD___")> Protected mstruser_codeOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="clsUserpermissions")> Protected mcolclsUserpermissions As clsUserpermissions
        Protected mblnclsUserpermissionsIsLoaded As Boolean
        <CXPropertyVar(PropertyName:="clsUserroles")> Protected mcolclsUserroles As clsUserroles
        Protected mblnclsUserrolesIsLoaded As Boolean
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
        	mcolclsUserpermissions = clsUserpermissions.NewclsUserpermissions()
        	mcolclsUserroles = clsUserroles.NewclsUserroles()
  			
			
			
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
        
        <CXDBField(DBFieldName:="user_code", DataType:=12, Size:=20, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsOPERATOR_user_code")> _
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
        
        <CXDBField(DBFieldName:="user_name", DataType:=12, Size:=50, SPUpdateOrdinal:=1), BusinessProperty("ID_cap_clsOPERATOR_user_name"), NullValue("")> _
        Public Overridable Property user_name() As System.String
            Get
                If IsReadOK("user_name") Then  Return mstruser_name
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("user_name") Then  Return
	            If Not Equals(mstruser_name, Value) Then
	                mstruser_name = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("user_name")
			        MarkDirty("user_name")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="password", DataType:=12, Size:=20, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clsOPERATOR_password"), NullValue("")> _
        Public Overridable Property password_() As System.String
            Get
                If IsReadOK("password_") Then  Return mstrpassword_
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("password_") Then  Return
	            If Not Equals(mstrpassword_, Value) Then
	                mstrpassword_ = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("password_")
			        MarkDirty("password_")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="STCD", DataType:=12, Size:=6, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clsOPERATOR_STCD"), NullValue("")> _
        Public Overridable Property STCD() As System.String
            Get
                If IsReadOK("STCD") Then  Return mstrSTCD
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("STCD") Then  Return
	            If Not Equals(mstrSTCD, Value) Then
	                mstrSTCD = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("STCD")
			        MarkDirty("STCD")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="allowlogin", DataType:=2, Size:=1, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clsOPERATOR_allowlogin")> _
        Public Overridable Property allowlogin() As System.Boolean
            Get
                If IsReadOK("allowlogin") Then  Return mblnallowlogin
                Return nothing
            End Get
	        Set(ByVal Value As System.Boolean)
	            If Not IsWriteOK("allowlogin") Then  Return
	            If Not Equals(mblnallowlogin, Value) Then
	                mblnallowlogin = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("allowlogin")
			        MarkDirty("allowlogin")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="isadmin", DataType:=2, Size:=1, SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsOPERATOR_isadmin")> _
        Public Overridable Property isadmin() As System.Boolean
            Get
                If IsReadOK("isadmin") Then  Return mblnisadmin
                Return nothing
            End Get
	        Set(ByVal Value As System.Boolean)
	            If Not IsWriteOK("isadmin") Then  Return
	            If Not Equals(mblnisadmin, Value) Then
	                mblnisadmin = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("isadmin")
			        MarkDirty("isadmin")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="title", DataType:=12, Size:=50, SPUpdateOrdinal:=6), BusinessProperty("ID_cap_clsOPERATOR_title"), NullValue("")> _
        Public Overridable Property title() As System.String
            Get
                If IsReadOK("title") Then  Return mstrtitle
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("title") Then  Return
	            If Not Equals(mstrtitle, Value) Then
	                mstrtitle = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("title")
			        MarkDirty("title")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="tel", DataType:=12, Size:=20, SPUpdateOrdinal:=7), BusinessProperty("ID_cap_clsOPERATOR_tel"), NullValue("")> _
        Public Overridable Property tel() As System.String
            Get
                If IsReadOK("tel") Then  Return mstrtel
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("tel") Then  Return
	            If Not Equals(mstrtel, Value) Then
	                mstrtel = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("tel")
			        MarkDirty("tel")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="fax", DataType:=12, Size:=20, SPUpdateOrdinal:=8), BusinessProperty("ID_cap_clsOPERATOR_fax"), NullValue("")> _
        Public Overridable Property fax() As System.String
            Get
                If IsReadOK("fax") Then  Return mstrfax
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("fax") Then  Return
	            If Not Equals(mstrfax, Value) Then
	                mstrfax = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("fax")
			        MarkDirty("fax")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="mobile", DataType:=12, Size:=20, SPUpdateOrdinal:=9), BusinessProperty("ID_cap_clsOPERATOR_mobile"), NullValue("")> _
        Public Overridable Property mobile() As System.String
            Get
                If IsReadOK("mobile") Then  Return mstrmobile
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("mobile") Then  Return
	            If Not Equals(mstrmobile, Value) Then
	                mstrmobile = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("mobile")
			        MarkDirty("mobile")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="email", DataType:=12, Size:=50, SPUpdateOrdinal:=10), BusinessProperty("ID_cap_clsOPERATOR_email"), NullValue("")> _
        Public Overridable Property email() As System.String
            Get
                If IsReadOK("email") Then  Return mstremail
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("email") Then  Return
	            If Not Equals(mstremail, Value) Then
	                mstremail = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("email")
			        MarkDirty("email")
                End If
            End Set
        End Property
        
        
        Public Overridable Property create_dateText() As System.String
            Get
                If IsReadOK("create_date") Then  Return mdtmcreate_date.Text
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("create_date") Then  Return
	            If Not Equals(mdtmcreate_date.Text, Value) Then
	                mdtmcreate_date.Text = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("create_date")
			        MarkDirty("create_date")
                End If
            End Set
        End Property
        <CXDBField(DBFieldName:="create_date", DataType:=4, Size:=8, SPUpdateOrdinal:=11), BusinessProperty("ID_cap_clsOPERATOR_create_date"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
        Public Overridable Property create_date() As Object
            Get
            	Dim strValue As string = Me.create_dateText
            	If strValue = String.Empty Then
            		Return System.DBNull.Value
            	Else
                	Return strValue
                End If
            End Get
            Set(ByVal Value As Object)
                If IsDate(Value) Then
                    Me.create_dateText = CType(Value, String)
                Else
                    Me.create_dateText = String.Empty
                End If
            End Set
        End Property
        
        
        Public Overridable Property update_dateText() As System.String
            Get
                If IsReadOK("update_date") Then  Return mdtmupdate_date.Text
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("update_date") Then  Return
	            If Not Equals(mdtmupdate_date.Text, Value) Then
	                mdtmupdate_date.Text = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("update_date")
			        MarkDirty("update_date")
                End If
            End Set
        End Property
        <CXDBField(DBFieldName:="update_date", DataType:=4, Size:=8, SPUpdateOrdinal:=12), BusinessProperty("ID_cap_clsOPERATOR_update_date"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
        Public Overridable Property update_date() As Object
            Get
            	Dim strValue As string = Me.update_dateText
            	If strValue = String.Empty Then
            		Return System.DBNull.Value
            	Else
                	Return strValue
                End If
            End Get
            Set(ByVal Value As Object)
                If IsDate(Value) Then
                    Me.update_dateText = CType(Value, String)
                Else
                    Me.update_dateText = String.Empty
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=20, SPUpdateOrdinal:=13), BusinessProperty("ID_cap_clsOPERATOR_opt_by"), NullValue("")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=14), BusinessProperty("ID_cap_clsOPERATOR_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(100, CXDBFieldFlags), SPUpdateOrdinal:=15), BusinessProperty("ID_cap_clsOPERATOR_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
		        
        <CXLinkProperty("user_code","user_code"), BusinessProperty("ID_cap_clsUserpermissions"), CXChildType(GetType(clsUserpermission))> _
        Public Overridable Property  clsUserpermissions() As clsUserpermissions
            Get
            	Return mcolclsUserpermissions
            End Get
            Set (ByVal Value As clsUserpermissions)
            	mcolclsUserpermissions = Value
            	SetParentPointerForChildren()
            End Set
        End Property
        
        Public Overridable Sub LoadclsUserpermissions(Optional ByVal blnReset As boolean = False)
        	If Not Me.IsNew Then
	        	If (not clsUserpermissionsIsLoaded) or blnReset Then
	        		clsUserpermissions = clsUserpermissions.NewclsUserpermissions
	        		LoadRelatedChildren(GetType(clsUserpermissions).Name)
	        		clsUserpermissionsIsLoaded = True
	        	End If
        	End If
        End Sub
        
        Protected Overridable Property clsUserpermissionsIsLoaded() As Boolean
            Get 
                clsUserpermissionsIsLoaded = mblnclsUserpermissionsIsLoaded
            End Get
            Set (ByVal Value As Boolean)
                mblnclsUserpermissionsIsLoaded = Value
            End Set
        End Property
		        
        <CXLinkProperty("user_code","user_code"), BusinessProperty("ID_cap_clsUserroles"), CXChildType(GetType(clsUserrole))> _
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
	    	    Return GetType(clsOPERATORs)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vuser_code As System.String, Optional ByVal nLevel As Integer = 0) As clsOPERATOR
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsOPERATOR), nLevel, "user_code", vuser_code)), clsOPERATOR)
    	End Function  	
    	Public Shared Function Load(ByVal vuser_code As System.String, Optional ByVal nLevel As Integer = 0) As clsOPERATOR
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsOPERATOR), nLevel, "user_code", vuser_code)), clsOPERATOR)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsOPERATORs
    	    Return YT.BusinessObject.clsOPERATORs.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsOPERATOR, Optional ByVal nLevel As Integer = 0) As clsOPERATORs
    	    Return YT.BusinessObject.clsOPERATORs.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vuser_code As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsOPERATOR), nLevel, "user_code", vuser_code))
    	End Sub
    	
    	Public Shared Function NewclsOPERATOR() As clsOPERATOR
            Return CType(DataPortal.Create(New Criteria(GetType(clsOPERATOR), 0)), clsOPERATOR)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsOPERATORs
            Return YT.BusinessObject.clsOPERATORs.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "user_code", New MaxLengthArgs("user_code", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "user_code", New BrokenRules.RuleArgs("user_code"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "user_name", New MaxLengthArgs("user_name", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "password_", New MaxLengthArgs("password_", 20))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "STCD", New MaxLengthArgs("STCD", 6))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "title", New MaxLengthArgs("title", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "tel", New MaxLengthArgs("tel", 20))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "fax", New MaxLengthArgs("fax", 20))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "mobile", New MaxLengthArgs("mobile", 20))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "email", New MaxLengthArgs("email", 50))
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
    <Serializable()> Public Class clsOPERATOR
        Inherits clsOPERATORBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace