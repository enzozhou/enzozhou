Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[skuinfo]",SelectFromClause:="[dbo].[skuinfo] ",InsertStoredProcedure:="stp_I_clsskuinfo",SelectStoredProcedure:="stp_S_clsskuinfo",DeleteStoredProcedure:="stp_D_clsskuinfo",UpdateStoredProcedure:="stp_U_clsskuinfo"), Serializable()> _
Public MustInherit Class clsskuinfoBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="sku_no")> Protected mstrsku_no As System.String = ""
        <CXPropertyVar(PropertyName:="sku_wms")> Protected mstrsku_wms As System.String = ""
        <CXPropertyVar(PropertyName:="sku_desc")> Protected mstrsku_desc As System.String = ""
        <CXPropertyVar(PropertyName:="sku_desc_eng")> Protected mstrsku_desc_eng As System.String = ""
        <CXPropertyVar(PropertyName:="model_no")> Protected mstrmodel_no As System.String = ""
        <CXPropertyVar(PropertyName:="volume")> Protected mcurvolume As System.Decimal
        <CXPropertyVar(PropertyName:="length")> Protected mcurlength As System.Decimal
        <CXPropertyVar(PropertyName:="width_")> Protected mcurwidth_ As System.Decimal
        <CXPropertyVar(PropertyName:="height")> Protected mcurheight As System.Decimal
        <CXPropertyVar(PropertyName:="opt_by")> Protected mstropt_by As System.String = ""
        <CXPropertyVar(PropertyName:="opt_dtime")> Protected mdtmopt_dtime As New SmartDate()
        <CXPropertyVar(PropertyName:="opt_timestamp")> Protected mbytopt_timestamp As System.Byte()
        <CXPropertyVar(PropertyName:="sku_noOLD___")> Protected mstrsku_noOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="sku_wmsOLD___")> Protected mstrsku_wmsOLD___ As System.String = ""
        <CXPropertyVar(PropertyName:="clsbarcodes")> Protected mcolclsbarcodes As clsbarcodes
        Protected mblnclsbarcodesIsLoaded As Boolean
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
        	mcolclsbarcodes = clsbarcodes.Newclsbarcodes()
  			
			
			
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
        Protected Overridable Property sku_wmsOLD___() As System.String
            Get
	            Return mstrsku_wmsOLD___
            End Get
            Set (ByVal Value As System.String)
	            mstrsku_wmsOLD___ = Value
            End Set
        End Property
        
        <CXDBField(DBFieldName:="sku_no", DataType:=12, Size:=20, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsskuinfo_sku_no")> _
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
        
        <CXDBField(DBFieldName:="sku_wms", DataType:=12, Size:=20, Flags:=CType(18, CXDBFieldFlags), SPUpdateOrdinal:=1, SPKeyOrdinal:=1), BusinessProperty("ID_cap_clsskuinfo_sku_wms")> _
        Public Overridable Property sku_wms() As System.String
            Get
                If IsReadOK("sku_wms") Then  Return mstrsku_wms
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("sku_wms") Then  Return
	            If Not Equals(mstrsku_wms, Value) Then
	                mstrsku_wms = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("sku_wms")
			        MarkDirty("sku_wms")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="sku_desc", DataType:=12, Size:=50, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clsskuinfo_sku_desc"), NullValue("")> _
        Public Overridable Property sku_desc() As System.String
            Get
                If IsReadOK("sku_desc") Then  Return mstrsku_desc
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("sku_desc") Then  Return
	            If Not Equals(mstrsku_desc, Value) Then
	                mstrsku_desc = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("sku_desc")
			        MarkDirty("sku_desc")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="sku_desc_eng", DataType:=12, Size:=50, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clsskuinfo_sku_desc_eng"), NullValue("")> _
        Public Overridable Property sku_desc_eng() As System.String
            Get
                If IsReadOK("sku_desc_eng") Then  Return mstrsku_desc_eng
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("sku_desc_eng") Then  Return
	            If Not Equals(mstrsku_desc_eng, Value) Then
	                mstrsku_desc_eng = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("sku_desc_eng")
			        MarkDirty("sku_desc_eng")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="model_no", DataType:=12, Size:=50, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clsskuinfo_model_no"), NullValue("")> _
        Public Overridable Property model_no() As System.String
            Get
                If IsReadOK("model_no") Then  Return mstrmodel_no
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("model_no") Then  Return
	            If Not Equals(mstrmodel_no, Value) Then
	                mstrmodel_no = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("model_no")
			        MarkDirty("model_no")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="volume", DataType:=5, Size:=13, Scale:=9, Precision:=20, SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsskuinfo_volume"), NullValue(0)> _
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
        
        <CXDBField(DBFieldName:="length", DataType:=5, Size:=9, Scale:=3, Precision:=12, SPUpdateOrdinal:=6), BusinessProperty("ID_cap_clsskuinfo_length"), NullValue(0)> _
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
        
        <CXDBField(DBFieldName:="width", DataType:=5, Size:=9, Scale:=3, Precision:=12, SPUpdateOrdinal:=7), BusinessProperty("ID_cap_clsskuinfo_width"), NullValue(0)> _
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
        
        <CXDBField(DBFieldName:="height", DataType:=5, Size:=9, Scale:=3, Precision:=12, SPUpdateOrdinal:=8), BusinessProperty("ID_cap_clsskuinfo_height"), NullValue(0)> _
        Public Overridable Property height() As System.Decimal
            Get
                If IsReadOK("height") Then  Return mcurheight
                Return nothing
            End Get
	        Set(ByVal Value As System.Decimal)
	            If Not IsWriteOK("height") Then  Return
	            If Not Equals(mcurheight, Value) Then
	                mcurheight = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("height")
			        MarkDirty("height")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="opt_by", DataType:=12, Size:=20, SPUpdateOrdinal:=9), BusinessProperty("ID_cap_clsskuinfo_opt_by"), NullValue("")> _
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
        <CXDBField(DBFieldName:="opt_dtime", DataType:=4, Size:=8, SPUpdateOrdinal:=10), BusinessProperty("ID_cap_clsskuinfo_opt_dtime"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
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
		<CXDBField(DBFieldName:="opt_timestamp", DataType:=19, Size:=30, Flags:=CType(102, CXDBFieldFlags), SPUpdateOrdinal:=11), BusinessProperty("ID_cap_clsskuinfo_opt_timestamp")> _
        Public Overridable ReadOnly Property opt_timestamp() As System.Byte()
            Get
                If IsReadOK("opt_timestamp") Then  Return mbytopt_timestamp
                Return nothing
            End Get	
        End Property
		        
        <CXLinkProperty("sku_no","sku_no"), BusinessProperty("ID_cap_clsbarcodes"), CXChildType(GetType(clsbarcode))> _
        Public Overridable Property  clsbarcodes() As clsbarcodes
            Get
            	Return mcolclsbarcodes
            End Get
            Set (ByVal Value As clsbarcodes)
            	mcolclsbarcodes = Value
            	SetParentPointerForChildren()
            End Set
        End Property
        
        Public Overridable Sub Loadclsbarcodes(Optional ByVal blnReset As boolean = False)
        	If Not Me.IsNew Then
	        	If (not clsbarcodesIsLoaded) or blnReset Then
	        		clsbarcodes = clsbarcodes.Newclsbarcodes
	        		LoadRelatedChildren(GetType(clsbarcodes).Name)
	        		clsbarcodesIsLoaded = True
	        	End If
        	End If
        End Sub
        
        Protected Overridable Property clsbarcodesIsLoaded() As Boolean
            Get 
                clsbarcodesIsLoaded = mblnclsbarcodesIsLoaded
            End Get
            Set (ByVal Value As Boolean)
                mblnclsbarcodesIsLoaded = Value
            End Set
        End Property
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clsskuinfoes)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vsku_no As System.String, ByVal vsku_wms As System.String, Optional ByVal nLevel As Integer = 0) As clsskuinfo
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsskuinfo), nLevel, "sku_no", vsku_no, "sku_wms", vsku_wms)), clsskuinfo)
    	End Function  	
    	Public Shared Function Load(ByVal vsku_no As System.String, ByVal vsku_wms As System.String, Optional ByVal nLevel As Integer = 0) As clsskuinfo
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsskuinfo), nLevel, "sku_no", vsku_no, "sku_wms", vsku_wms)), clsskuinfo)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsskuinfoes
    	    Return YT.BusinessObject.clsskuinfoes.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsskuinfo, Optional ByVal nLevel As Integer = 0) As clsskuinfoes
    	    Return YT.BusinessObject.clsskuinfoes.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vsku_no As System.String, ByVal vsku_wms As System.String, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsskuinfo), nLevel, "sku_no", vsku_no, "sku_wms", vsku_wms))
    	End Sub
    	
    	Public Shared Function Newclsskuinfo() As clsskuinfo
            Return CType(DataPortal.Create(New Criteria(GetType(clsskuinfo), 0)), clsskuinfo)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsskuinfoes
            Return YT.BusinessObject.clsskuinfoes.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "sku_no", New MaxLengthArgs("sku_no", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "sku_no", New BrokenRules.RuleArgs("sku_no"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "sku_wms", New MaxLengthArgs("sku_wms", 20))
				.AddRule(AddressOf ValidationRules.rlFieldRequired, "sku_wms", New BrokenRules.RuleArgs("sku_wms"))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "sku_desc", New MaxLengthArgs("sku_desc", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "sku_desc_eng", New MaxLengthArgs("sku_desc_eng", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "model_no", New MaxLengthArgs("model_no", 50))
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
    <Serializable()> Public Class clsskuinfo
        Inherits clsskuinfoBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace