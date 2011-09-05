Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[users]",SelectFromClause:="[dbo].[users] ",InsertStoredProcedure:="stp_I_clsusers",SelectStoredProcedure:="stp_S_clsusers",DeleteStoredProcedure:="stp_D_clsusers",UpdateStoredProcedure:="stp_U_clsusers"), Serializable()> _
Public MustInherit Class clsusersBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="uid")> Protected mstruid As System.String = ""
        <CXPropertyVar(PropertyName:="uname")> Protected mstruname As System.String = ""
        <CXPropertyVar(PropertyName:="pwd")> Protected mstrpwd As System.String = ""
        <CXPropertyVar(PropertyName:="phone")> Protected mstrphone As System.String = ""
        <CXPropertyVar(PropertyName:="email")> Protected mstremail As System.String = ""
        <CXPropertyVar(PropertyName:="gender")> Protected mstrgender As System.String = ""
        <CXPropertyVar(PropertyName:="roleType")> Protected mstrroleType As System.String = ""
        <CXPropertyVar(PropertyName:="uidOLD___")> Protected mstruidOLD___ As System.String = ""
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
  			
			
			
			SetParentPointerForChildren()
		End Sub			
#End Region
        
#Region "Properties"
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property uidOLD___() As System.String
            Get
	            Return mstruidOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstruidOLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="uid", DataType:=22, Size:=20, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsusers_uid")> _
        Public Overridable Property uid() As System.String
            Get
                If IsReadOK("uid") Then  Return mstruid
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("uid") Then  Return
	            If Not Equals(mstruid, Value) Then
	                mstruid = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("uid")
			        MarkDirty("uid")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="uname", DataType:=22, Size:=50, SPUpdateOrdinal:=1), BusinessProperty("ID_cap_clsusers_uname"), NullValue("")> _
        Public Overridable Property uname() As System.String
            Get
                If IsReadOK("uname") Then  Return mstruname
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("uname") Then  Return
	            If Not Equals(mstruname, Value) Then
	                mstruname = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("uname")
			        MarkDirty("uname")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="pwd", DataType:=22, Size:=20, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clsusers_pwd"), NullValue("")> _
        Public Overridable Property pwd() As System.String
            Get
                If IsReadOK("pwd") Then  Return mstrpwd
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("pwd") Then  Return
	            If Not Equals(mstrpwd, Value) Then
	                mstrpwd = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("pwd")
			        MarkDirty("pwd")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="phone", DataType:=22, Size:=50, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clsusers_phone"), NullValue("")> _
        Public Overridable Property phone() As System.String
            Get
                If IsReadOK("phone") Then  Return mstrphone
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("phone") Then  Return
	            If Not Equals(mstrphone, Value) Then
	                mstrphone = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("phone")
			        MarkDirty("phone")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="email", DataType:=22, Size:=100, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clsusers_email"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="gender", DataType:=22, Size:=10, SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsusers_gender"), NullValue("")> _
        Public Overridable Property gender() As System.String
            Get
                If IsReadOK("gender") Then  Return mstrgender
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("gender") Then  Return
	            If Not Equals(mstrgender, Value) Then
	                mstrgender = Value
	                Dim blnFoundInCache As boolean 
	                If not Me.LookupObject is nothing Then
		                Dim dvCach As DataView = GetgenderLookupList(CXLookupCallTypeConstants.ccCacheOnly)
	                    Dim intRow As Integer
	                    If Not dvCach Is Nothing Then
	                        With dvCach
	                            .Sort = .Table.Columns(0).ColumnName
	                            intRow = .Find(mstrgender)
	                            If intRow <> -1 Then
	                            	blnFoundInCache = True	                            	
	                            	PropertyHasInvalidLookupValue("gender", False)
	                            End If
	                            .Sort = String.Empty
	                        End With
	                    End If
                    End If
                    If Not blnFoundInCache Then
						PropertyHasInvalidLookupValue("gender", True)
					End If
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("gender")
			        MarkDirty("gender")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="roleType", DataType:=22, Size:=20, SPUpdateOrdinal:=6), BusinessProperty("ID_cap_clsusers_roleType"), NullValue("")> _
        Public Overridable Property roleType() As System.String
            Get
                If IsReadOK("roleType") Then  Return mstrroleType
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("roleType") Then  Return
	            If Not Equals(mstrroleType, Value) Then
	                mstrroleType = Value
	                Dim blnFoundInCache As boolean 
	                If not Me.LookupObject is nothing Then
		                Dim dvCach As DataView = GetroleTypeLookupList(CXLookupCallTypeConstants.ccCacheOnly)
	                    Dim intRow As Integer
	                    If Not dvCach Is Nothing Then
	                        With dvCach
	                            .Sort = .Table.Columns(0).ColumnName
	                            intRow = .Find(mstrroleType)
	                            If intRow <> -1 Then
	                            	blnFoundInCache = True	                            	
	                            	PropertyHasInvalidLookupValue("roleType", False)
	                            End If
	                            .Sort = String.Empty
	                        End With
	                    End If
                    End If
                    If Not blnFoundInCache Then
						PropertyHasInvalidLookupValue("roleType", True)
					End If
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("roleType")
			        MarkDirty("roleType")
                End If
            End Set
        End Property
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clsuserses)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vuid As System.String, Optional ByVal nLevel As Integer = 0) As clsusers
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsusers), nLevel, "uid", vuid)), clsusers)
    	End Function  	
    	Public Shared Function Load(ByVal vuid As System.String, Optional ByVal nLevel As Integer = 0) As clsusers
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsusers), nLevel, "uid", vuid)), clsusers)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsuserses
    	    Return YT.BusinessObject.clsuserses.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsusers, Optional ByVal nLevel As Integer = 0) As clsuserses
    	    Return YT.BusinessObject.clsuserses.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vuid As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsusers), nLevel, "uid", vuid))
    	End Sub
    	
    	Public Shared Function Newclsusers() As clsusers
            Return CType(DataPortal.Create(New Criteria(GetType(clsusers), 0)), clsusers)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsuserses
            Return YT.BusinessObject.clsuserses.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "uid", New MaxLengthArgs("uid", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "uid", New BrokenRules.RuleArgs("uid"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "uname", New MaxLengthArgs("uname", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "pwd", New MaxLengthArgs("pwd", 20))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "phone", New MaxLengthArgs("phone", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "email", New MaxLengthArgs("email", 100))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "gender", New MaxLengthArgs("gender", 10))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "roleType", New MaxLengthArgs("roleType", 20))
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
		
		Public Overridable Function GetgenderLookupList(Optional ByVal callType As COMExpress.BusinessObject.CXLookupCallTypeConstants = CXLookupCallTypeConstants.ccCache) As DataView
			Dim oLookup As LookupBase
			If Me.LookupObject Is Nothing Then
                oLookup = New Lookup
            Else
                oLookup = Me.LookupObject
            End If
			Return GetPropertyLookupList(oLookup, "getGenderList", "gender", callType)
		End Function
		
		Public Overridable Function GetroleTypeLookupList(Optional ByVal callType As COMExpress.BusinessObject.CXLookupCallTypeConstants = CXLookupCallTypeConstants.ccCache) As DataView
			Dim oLookup As LookupBase
			If Me.LookupObject Is Nothing Then
                oLookup = New Lookup
            Else
                oLookup = Me.LookupObject
            End If
			Return GetPropertyLookupList(oLookup, "getRoleTye", "roleType", callType)
		End Function
#End Region

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region

    End Class

#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"    
    <Serializable()> Public Class clsusers
        Inherits clsusersBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace