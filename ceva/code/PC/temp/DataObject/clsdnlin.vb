Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[dnlin]",SelectFromClause:="[dbo].[dnlin] ",InsertStoredProcedure:="stp_I_clsdnlin",SelectStoredProcedure:="stp_S_clsdnlin",DeleteStoredProcedure:="stp_D_clsdnlin",UpdateStoredProcedure:="stp_U_clsdnlin"), Serializable()> _
Public MustInherit Class clsdnlinBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="row_id")> Protected mstrrow_id As System.String = ""
        <CXPropertyVar(PropertyName:="sku_no")> Protected mstrsku_no As System.String = ""
        <CXPropertyVar(PropertyName:="qty")> Protected mcurqty As System.Decimal
        <CXPropertyVar(PropertyName:="act_qty")> Protected mcuract_qty As System.Decimal
        <CXPropertyVar(PropertyName:="status_code")> Protected mstrstatus_code As System.String = ""
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="dc_code")> Protected mstrdc_code As System.String = ""
        <CXPropertyVar(PropertyName:="dn_no")> Protected mstrdn_no As System.String = ""
        <CXPropertyVar(PropertyName:="dc_codeOLD___")> Protected mstrdc_codeOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="dn_noOLD___")> Protected mstrdn_noOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="row_idOLD___")> Protected mstrrow_idOLD___ As System.String = ""
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
        Protected Overridable Property dn_noOLD___() As System.String
            Get
	            Return mstrdn_noOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrdn_noOLD___ = Value
            End Set
        End Property
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property row_idOLD___() As System.String
            Get
	            Return mstrrow_idOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrrow_idOLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="row_id", DataType:=10, Size:=5, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=2), BusinessProperty("ID_cap_clsdnlin_row_id")> _
        Public Overridable Property row_id() As System.String
            Get
                If IsReadOK("row_id") Then  Return mstrrow_id
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("row_id") Then  Return
	            If Not Equals(mstrrow_id, Value) Then
	                mstrrow_id = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("row_id")
			        MarkDirty("row_id")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="sku_no", DataType:=12, Size:=20, SPUpdateOrdinal:=1), BusinessProperty("ID_cap_clsdnlin_sku_no"), NullValue("")> _
        Public Overridable Property sku_no() As System.String
            Get
                If IsReadOK("sku_no") Then  Return mstrsku_no
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("sku_no") Then  Return
	            If Not Equals(mstrsku_no, Value) Then
	                mstrsku_no = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("sku_no")
			        MarkDirty("sku_no")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="qty", DataType:=5, Size:=9, Scale:=3, Precision:=12, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clsdnlin_qty"), NullValue(0)> _
        Public Overridable Property qty() As System.Decimal
            Get
                If IsReadOK("qty") Then  Return mcurqty
                Return nothing
            End Get
	        Set(ByVal Value As System.Decimal)
	            If Not IsWriteOK("qty") Then  Return
	            If Not Equals(mcurqty, Value) Then
	                mcurqty = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("qty")
			        MarkDirty("qty")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="act_qty", DataType:=5, Size:=9, Scale:=3, Precision:=12, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clsdnlin_act_qty"), NullValue(0)> _
        Public Overridable Property act_qty() As System.Decimal
            Get
                If IsReadOK("act_qty") Then  Return mcuract_qty
                Return nothing
            End Get
	        Set(ByVal Value As System.Decimal)
	            If Not IsWriteOK("act_qty") Then  Return
	            If Not Equals(mcuract_qty, Value) Then
	                mcuract_qty = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("act_qty")
			        MarkDirty("act_qty")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="status_code", DataType:=10, Size:=5, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clsdnlin_status_code"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=20, SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsdnlin_opt_by"), NullValue("")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=6), BusinessProperty("ID_cap_clsdnlin_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(102, CXDBFieldFlags), SPUpdateOrdinal:=7), BusinessProperty("ID_cap_clsdnlin_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
        
        <CXDBField(DBFieldName:="dc_code", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=8, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsdnlin_dc_code1")> _
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
        
        <CXDBField(DBFieldName:="dn_no", DataType:=12, Size:=20, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=9, SPKeyOrdinal:=1), BusinessProperty("ID_cap_clsdnlin_dn_no1")> _
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
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clsdnlins)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vdc_code As System.String, ByVal vdn_no As System.String, ByVal vrow_id As System.String, Optional ByVal nLevel As Integer = 0) As clsdnlin
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsdnlin), nLevel, "dc_code", vdc_code, "dn_no", vdn_no, "row_id", vrow_id)), clsdnlin)
    	End Function  	
    	Public Shared Function Load(ByVal vdc_code As System.String, ByVal vdn_no As System.String, ByVal vrow_id As System.String, Optional ByVal nLevel As Integer = 0) As clsdnlin
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsdnlin), nLevel, "dc_code", vdc_code, "dn_no", vdn_no, "row_id", vrow_id)), clsdnlin)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsdnlins
    	    Return YT.BusinessObject.clsdnlins.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsdnlin, Optional ByVal nLevel As Integer = 0) As clsdnlins
    	    Return YT.BusinessObject.clsdnlins.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vdc_code As System.String, ByVal vdn_no As System.String, ByVal vrow_id As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsdnlin), nLevel, "dc_code", vdc_code, "dn_no", vdn_no, "row_id", vrow_id))
    	End Sub
    	
    	Public Shared Function Newclsdnlin() As clsdnlin
            Return CType(DataPortal.Create(New Criteria(GetType(clsdnlin), 0)), clsdnlin)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsdnlins
            Return YT.BusinessObject.clsdnlins.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "row_id", New MaxLengthArgs("row_id", 5))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "row_id", New BrokenRules.RuleArgs("row_id"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "sku_no", New MaxLengthArgs("sku_no", 20))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "status_code", New MaxLengthArgs("status_code", 5))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "opt_by", New MaxLengthArgs("opt_by", 20))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "dc_code", New MaxLengthArgs("dc_code", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "dc_code", New BrokenRules.RuleArgs("dc_code"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "dn_no", New MaxLengthArgs("dn_no", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "dn_no", New BrokenRules.RuleArgs("dn_no"))
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
			Return GetPropertyLookupList(oLookup, "GetDNStatusCode", "status_code", callType)
		End Function
#End Region

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region

    End Class

#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"    
    <Serializable()> Public Class clsdnlin
        Inherits clsdnlinBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace