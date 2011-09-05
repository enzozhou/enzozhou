Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[barcode]",SelectFromClause:="[dbo].[barcode] ",InsertStoredProcedure:="stp_I_clsbarcode",SelectStoredProcedure:="stp_S_clsbarcode",DeleteStoredProcedure:="stp_D_clsbarcode",UpdateStoredProcedure:="stp_U_clsbarcode"), Serializable()> _
Public MustInherit Class clsbarcodeBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="sku_no")> Protected mstrsku_no As System.String = ""
        <CXPropertyVar(PropertyName:="barcode")> Protected mstrbarcode As System.String = ""
        <CXPropertyVar(PropertyName:="bar_type")> Protected mstrbar_type As System.String = ""
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="sku_noOLD___")> Protected mstrsku_noOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="barcodeOLD___")> Protected mstrbarcodeOLD___ As System.String = ""
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
  			
			
			
			SetParentPointerForChildren()
		End Sub			
#End Region
        
#Region "Properties"
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property sku_noOLD___() As System.String
            Get
	            Return mstrsku_noOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrsku_noOLD___ = Value
            End Set
        End Property
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property barcodeOLD___() As System.String
            Get
	            Return mstrbarcodeOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrbarcodeOLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="sku_no", DataType:=12, Size:=20, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsbarcode_sku_no")> _
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
        
        <CXDBField(DBFieldName:="barcode", DataType:=12, Size:=30, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=1, SPKeyOrdinal:=1), BusinessProperty("ID_cap_clsbarcode_barcode")> _
        Public Overridable Property barcode() As System.String
            Get
                If IsReadOK("barcode") Then  Return mstrbarcode
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("barcode") Then  Return
	            If Not Equals(mstrbarcode, Value) Then
	                mstrbarcode = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("barcode")
			        MarkDirty("barcode")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="bar_type", DataType:=10, Size:=3, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clsbarcode_bar_type"), NullValue("")> _
        Public Overridable Property bar_type() As System.String
            Get
                If IsReadOK("bar_type") Then  Return mstrbar_type
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("bar_type") Then  Return
	            If Not Equals(mstrbar_type, Value) Then
	                mstrbar_type = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("bar_type")
			        MarkDirty("bar_type")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=20, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clsbarcode_opt_by"), NullValue("")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clsbarcode_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(102, CXDBFieldFlags), SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsbarcode_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clsbarcodes)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vsku_no As System.String, ByVal vbarcode As System.String, Optional ByVal nLevel As Integer = 0) As clsbarcode
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsbarcode), nLevel, "sku_no", vsku_no, "barcode", vbarcode)), clsbarcode)
    	End Function  	
    	Public Shared Function Load(ByVal vsku_no As System.String, ByVal vbarcode As System.String, Optional ByVal nLevel As Integer = 0) As clsbarcode
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsbarcode), nLevel, "sku_no", vsku_no, "barcode", vbarcode)), clsbarcode)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsbarcodes
    	    Return YT.BusinessObject.clsbarcodes.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsbarcode, Optional ByVal nLevel As Integer = 0) As clsbarcodes
    	    Return YT.BusinessObject.clsbarcodes.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vsku_no As System.String, ByVal vbarcode As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsbarcode), nLevel, "sku_no", vsku_no, "barcode", vbarcode))
    	End Sub
    	
    	Public Shared Function Newclsbarcode() As clsbarcode
            Return CType(DataPortal.Create(New Criteria(GetType(clsbarcode), 0)), clsbarcode)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsbarcodes
            Return YT.BusinessObject.clsbarcodes.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "sku_no", New MaxLengthArgs("sku_no", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "sku_no", New BrokenRules.RuleArgs("sku_no"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "barcode", New MaxLengthArgs("barcode", 30))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "barcode", New BrokenRules.RuleArgs("barcode"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "bar_type", New MaxLengthArgs("bar_type", 3))
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
    <Serializable()> Public Class clsbarcode
        Inherits clsbarcodeBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace