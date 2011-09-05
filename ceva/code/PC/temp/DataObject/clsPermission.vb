Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[Permission]",SelectFromClause:="[dbo].[Permission] ",InsertStoredProcedure:="stp_I_clsPermission",SelectStoredProcedure:="stp_S_clsPermission",DeleteStoredProcedure:="stp_D_clsPermission",UpdateStoredProcedure:="stp_U_clsPermission"), Serializable()> _
Public MustInherit Class clsPermissionBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="right_no")> Protected mstrright_no As System.String = ""
        <CXPropertyVar(PropertyName:="description")> Protected mstrdescription As System.String = ""
        <CXPropertyVar(PropertyName:="trans_type")> Protected mstrtrans_type As System.String = ""
        <CXPropertyVar(PropertyName:="doc_type")> Protected mstrdoc_type As System.String = ""
        <CXPropertyVar(PropertyName:="cmd_type")> Protected mstrcmd_type As System.String = ""
        <CXPropertyVar(PropertyName:="remark")> Protected mstrremark As System.String = ""
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
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
        Protected Overridable Property right_noOLD___() As System.String
            Get
	            Return mstrright_noOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrright_noOLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="right_no", DataType:=12, Size:=20, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsPermission_right_no")> _
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
        
        <CXDBField(DBFieldName:="description", DataType:=12, Size:=50, SPUpdateOrdinal:=1), BusinessProperty("ID_cap_clsPermission_description"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="trans_type", DataType:=10, Size:=3, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clsPermission_trans_type"), NullValue("")> _
        Public Overridable Property trans_type() As System.String
            Get
                If IsReadOK("trans_type") Then  Return mstrtrans_type
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("trans_type") Then  Return
	            If Not Equals(mstrtrans_type, Value) Then
	                mstrtrans_type = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("trans_type")
			        MarkDirty("trans_type")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="doc_type", DataType:=10, Size:=3, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clsPermission_doc_type"), NullValue("")> _
        Public Overridable Property doc_type() As System.String
            Get
                If IsReadOK("doc_type") Then  Return mstrdoc_type
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("doc_type") Then  Return
	            If Not Equals(mstrdoc_type, Value) Then
	                mstrdoc_type = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("doc_type")
			        MarkDirty("doc_type")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="cmd_type", DataType:=10, Size:=3, Flags:=CType(2, CXDBFieldFlags), SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clsPermission_cmd_type")> _
        Public Overridable Property cmd_type() As System.String
            Get
                If IsReadOK("cmd_type") Then  Return mstrcmd_type
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("cmd_type") Then  Return
	            If Not Equals(mstrcmd_type, Value) Then
	                mstrcmd_type = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("cmd_type")
			        MarkDirty("cmd_type")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="remark", DataType:=11, SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsPermission_remark"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=50, SPUpdateOrdinal:=6), BusinessProperty("ID_cap_clsPermission_opt_by"), NullValue("")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=7), BusinessProperty("ID_cap_clsPermission_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(100, CXDBFieldFlags), SPUpdateOrdinal:=8), BusinessProperty("ID_cap_clsPermission_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clsPermissions)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vright_no As System.String, Optional ByVal nLevel As Integer = 0) As clsPermission
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsPermission), nLevel, "right_no", vright_no)), clsPermission)
    	End Function  	
    	Public Shared Function Load(ByVal vright_no As System.String, Optional ByVal nLevel As Integer = 0) As clsPermission
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsPermission), nLevel, "right_no", vright_no)), clsPermission)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsPermissions
    	    Return YT.BusinessObject.clsPermissions.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsPermission, Optional ByVal nLevel As Integer = 0) As clsPermissions
    	    Return YT.BusinessObject.clsPermissions.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vright_no As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsPermission), nLevel, "right_no", vright_no))
    	End Sub
    	
    	Public Shared Function NewclsPermission() As clsPermission
            Return CType(DataPortal.Create(New Criteria(GetType(clsPermission), 0)), clsPermission)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsPermissions
            Return YT.BusinessObject.clsPermissions.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "right_no", New MaxLengthArgs("right_no", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "right_no", New BrokenRules.RuleArgs("right_no"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "description", New MaxLengthArgs("description", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "trans_type", New MaxLengthArgs("trans_type", 3))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "doc_type", New MaxLengthArgs("doc_type", 3))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "cmd_type", New MaxLengthArgs("cmd_type", 3))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "cmd_type", New BrokenRules.RuleArgs("cmd_type"))
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
    <Serializable()> Public Class clsPermission
        Inherits clsPermissionBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace