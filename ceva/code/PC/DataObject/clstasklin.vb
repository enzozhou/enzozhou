Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[tasklin]",SelectFromClause:="[dbo].[tasklin] ",InsertStoredProcedure:="stp_I_clstasklin",SelectStoredProcedure:="stp_S_clstasklin",DeleteStoredProcedure:="stp_D_clstasklin",UpdateStoredProcedure:="stp_U_clstasklin"), Serializable()> _
Public MustInherit Class clstasklinBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="rowid")> Protected mstrrowid As System.String = ""
        <CXPropertyVar(PropertyName:="dc_code")> Protected mstrdc_code As System.String = ""
        <CXPropertyVar(PropertyName:="task_id")> Protected mstrtask_id As System.String = ""
        <CXPropertyVar(PropertyName:="bch_no")> Protected mstrbch_no As System.String = ""
        <CXPropertyVar(PropertyName:="dn_no")> Protected mstrdn_no As System.String = ""
        <CXPropertyVar(PropertyName:="bin_area")> Protected mstrbin_area As System.String = ""
        <CXPropertyVar(PropertyName:="bin_code")> Protected mstrbin_code As System.String = ""
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="start_dtime")> Protected mdtmstart_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="end_dtime")> Protected mdtmend_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="sku_no")> Protected mstrsku_no As System.String = ""
        <CXPropertyVar(PropertyName:="sno")> Protected mstrsno As System.String = ""
        <CXPropertyVar(PropertyName:="qty")> Protected mcurqty As System.Decimal
        <CXPropertyVar(PropertyName:="rowidOLD___")> Protected mstrrowidOLD___ As System.String = ""
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
  			
			
			
			SetParentPointerForChildren()
		End Sub			
#End Region
        
#Region "Properties"
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property rowidOLD___() As System.String
            Get
	            Return mstrrowidOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrrowidOLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="rowid", DataType:=12, Size:=10, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clstasklin_rowid")> _
        Public Overridable Property rowid() As System.String
            Get
                If IsReadOK("rowid") Then  Return mstrrowid
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("rowid") Then  Return
	            If Not Equals(mstrrowid, Value) Then
	                mstrrowid = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("rowid")
			        MarkDirty("rowid")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="dc_code", DataType:=12, Size:=10, Flags:=CType(2, CXDBFieldFlags), SPUpdateOrdinal:=1), BusinessProperty("ID_cap_clstasklin_dc_code1")> _
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
        
        <CXDBField(DBFieldName:="task_id", DataType:=12, Size:=20, Flags:=CType(2, CXDBFieldFlags), SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clstasklin_task_id")> _
        Public Overridable Property task_id() As System.String
            Get
                If IsReadOK("task_id") Then  Return mstrtask_id
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("task_id") Then  Return
	            If Not Equals(mstrtask_id, Value) Then
	                mstrtask_id = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("task_id")
			        MarkDirty("task_id")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="bch_no", DataType:=12, Size:=20, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clstasklin_bch_no"), NullValue("")> _
        Public Overridable Property bch_no() As System.String
            Get
                If IsReadOK("bch_no") Then  Return mstrbch_no
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("bch_no") Then  Return
	            If Not Equals(mstrbch_no, Value) Then
	                mstrbch_no = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("bch_no")
			        MarkDirty("bch_no")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="dn_no", DataType:=12, Size:=20, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clstasklin_dn_no"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="bin_area", DataType:=12, Size:=10, Flags:=CType(2, CXDBFieldFlags), SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clstasklin_bin_area")> _
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
        
        <CXDBField(DBFieldName:="bin_code", DataType:=12, Size:=10, SPUpdateOrdinal:=6), BusinessProperty("ID_cap_clstasklin_bin_code"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=20, SPUpdateOrdinal:=7), BusinessProperty("ID_cap_clstasklin_opt_by"), NullValue("")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=8), BusinessProperty("ID_cap_clstasklin_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
        <CXDBField(DBFieldName:="start_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=9), BusinessProperty("ID_cap_clstasklin_start_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
        <CXDBField(DBFieldName:="end_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=10), BusinessProperty("ID_cap_clstasklin_end_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(102, CXDBFieldFlags), SPUpdateOrdinal:=11), BusinessProperty("ID_cap_clstasklin_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
        
        <CXDBField(DBFieldName:="sku_no", DataType:=12, Size:=20, SPUpdateOrdinal:=12), BusinessProperty("ID_cap_clstasklin_sku_no"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="sno", DataType:=12, Size:=20, SPUpdateOrdinal:=13), BusinessProperty("ID_cap_clstasklin_sno"), NullValue("")> _
        Public Overridable Property sno() As System.String
            Get
                If IsReadOK("sno") Then  Return mstrsno
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("sno") Then  Return
	            If Not Equals(mstrsno, Value) Then
	                mstrsno = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("sno")
			        MarkDirty("sno")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="qty", DataType:=5, Size:=9, Scale:=3, Precision:=12, SPUpdateOrdinal:=14), BusinessProperty("ID_cap_clstasklin_qty"), NullValue(0)> _
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
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clstasklins)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vrowid As System.String, Optional ByVal nLevel As Integer = 0) As clstasklin
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clstasklin), nLevel, "rowid", vrowid)), clstasklin)
    	End Function  	
    	Public Shared Function Load(ByVal vrowid As System.String, Optional ByVal nLevel As Integer = 0) As clstasklin
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clstasklin), nLevel, "rowid", vrowid)), clstasklin)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clstasklins
    	    Return YT.BusinessObject.clstasklins.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clstasklin, Optional ByVal nLevel As Integer = 0) As clstasklins
    	    Return YT.BusinessObject.clstasklins.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vrowid As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clstasklin), nLevel, "rowid", vrowid))
    	End Sub
    	
    	Public Shared Function Newclstasklin() As clstasklin
            Return CType(DataPortal.Create(New Criteria(GetType(clstasklin), 0)), clstasklin)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clstasklins
            Return YT.BusinessObject.clstasklins.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "rowid", New MaxLengthArgs("rowid", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "rowid", New BrokenRules.RuleArgs("rowid"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "dc_code", New MaxLengthArgs("dc_code", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "dc_code", New BrokenRules.RuleArgs("dc_code"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "task_id", New MaxLengthArgs("task_id", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "task_id", New BrokenRules.RuleArgs("task_id"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "bch_no", New MaxLengthArgs("bch_no", 20))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "dn_no", New MaxLengthArgs("dn_no", 20))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "bin_area", New MaxLengthArgs("bin_area", 10))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "bin_area", New BrokenRules.RuleArgs("bin_area"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "bin_code", New MaxLengthArgs("bin_code", 10))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "opt_by", New MaxLengthArgs("opt_by", 20))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "sku_no", New MaxLengthArgs("sku_no", 20))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "sno", New MaxLengthArgs("sno", 20))
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
    <Serializable()> Public Class clstasklin
        Inherits clstasklinBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace