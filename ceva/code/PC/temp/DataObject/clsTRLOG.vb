Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports COMExpress.BusinessObject.CustomAttribute
Imports CSLA

Namespace BusinessObject
    <CXDBTableWithSP(TableName:="[dbo].[TRLOG]",SelectFromClause:="[dbo].[TRLOG] ",InsertStoredProcedure:="stp_I_clsTRLOG",SelectStoredProcedure:="stp_S_clsTRLOG",DeleteStoredProcedure:="stp_D_clsTRLOG",UpdateStoredProcedure:="stp_U_clsTRLOG"), Serializable()> _
Public MustInherit Class clsTRLOGBase_
        Inherits ImpBusinessBaseDerived
#Region "Class variables"

        <CXPropertyVar(PropertyName:="log_id")> Protected mvarlog_id As System.Int64
        <CXPropertyVar(PropertyName:="trans_type")> Protected mstrtrans_type As System.String = ""
        <CXPropertyVar(PropertyName:="cmd_type")> Protected mstrcmd_type As System.String = ""
        <CXPropertyVar(PropertyName:="doc_no")> Protected mstrdoc_no As System.String = ""
        <CXPropertyVar(PropertyName:="LINENUM")> Protected mstrLINENUM As System.String = ""
        <CXPropertyVar(PropertyName:="STCD")> Protected mstrSTCD As System.String = ""
        <CXPropertyVar(PropertyName:="ITEMNO")> Protected mstrITEMNO As System.String = ""
        <CXPropertyVar(PropertyName:="ITEM_DESC")> Protected mstrITEM_DESC As System.String = ""
        <CXPropertyVar(PropertyName:="BANTCH")> Protected mstrBANTCH As System.String = ""
        <CXPropertyVar(PropertyName:="QTY")> Protected mcurQTY As System.Decimal
        <CXPropertyVar(PropertyName:="status")> Protected mstrstatus As System.String = ""
        <CXPropertyVar(PropertyName:="reason")> Protected mstrreason As System.String = ""
        <CXPropertyVar(PropertyName:="reasonDesc")> Protected mstrreasonDesc As System.String = ""
        <CXPropertyVar(PropertyName:="OPT_BY")> Protected mstrOPT_BY As System.String = ""
        <CXPropertyVar(PropertyName:="OPT_ADDR")> Protected mstrOPT_ADDR As System.String = ""
        <CXPropertyVar(PropertyName:="OPT_DATE")> Protected mdtmOPT_DATE As New SmartDate()
        <CXPropertyVar(PropertyName:="OPT_TIMESTAMP")> Protected mbytOPT_TIMESTAMP As System.Byte()
        <CXPropertyVar(PropertyName:="log_idOLD___")> Protected mvarlog_idOLD___ As System.Int64
#End Region
  	    
#Region "Constructors"
  	    Protected Sub New()
  	    	' 
  			
			
			
			SetParentPointerForChildren()
		End Sub			
#End Region
        
#Region "Properties"
        
        'Do not change this property name, the correct name convention for it should be: Primary key property name + OLD__
        Protected Overridable Property log_idOLD___() As System.Int64
            Get
	            Return mvarlog_idOLD___
            End Get
            Set (ByVal Value As System.Int64)
	            mvarlog_idOLD___ = Value
            End Set
        End Property
		<CXDBField(DBFieldName:="log_id", DataType:=0, Size:=8, Flags:=CType(58, CXDBFieldFlags), SPUpdateOrdinal:=0, SPKeyOrdinal:=0), BusinessProperty("ID_cap_clsTRLOG_log_id")> _
        Public Overridable ReadOnly Property log_id() As System.Int64
            Get
                If IsReadOK("log_id") Then  Return mvarlog_id
                Return nothing
            End Get	
        End Property
        
        <CXDBField(DBFieldName:="trans_type", DataType:=10, Size:=3, SPUpdateOrdinal:=1), BusinessProperty("ID_cap_clsTRLOG_trans_type"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="cmd_type", DataType:=10, Size:=3, SPUpdateOrdinal:=2), BusinessProperty("ID_cap_clsTRLOG_cmd_type"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="doc_no", DataType:=12, Size:=24, SPUpdateOrdinal:=3), BusinessProperty("ID_cap_clsTRLOG_doc_no"), NullValue("")> _
        Public Overridable Property doc_no() As System.String
            Get
                If IsReadOK("doc_no") Then  Return mstrdoc_no
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("doc_no") Then  Return
	            If Not Equals(mstrdoc_no, Value) Then
	                mstrdoc_no = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("doc_no")
			        MarkDirty("doc_no")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="LINENUM", DataType:=10, Size:=4, SPUpdateOrdinal:=4), BusinessProperty("ID_cap_clsTRLOG_LINENUM"), NullValue("")> _
        Public Overridable Property LINENUM() As System.String
            Get
                If IsReadOK("LINENUM") Then  Return mstrLINENUM
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("LINENUM") Then  Return
	            If Not Equals(mstrLINENUM, Value) Then
	                mstrLINENUM = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("LINENUM")
			        MarkDirty("LINENUM")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="STCD", DataType:=12, Size:=6, SPUpdateOrdinal:=5), BusinessProperty("ID_cap_clsTRLOG_STCD"), NullValue("")> _
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
        
        <CXDBField(DBFieldName:="ITEMNO", DataType:=12, Size:=24, SPUpdateOrdinal:=6), BusinessProperty("ID_cap_clsTRLOG_ITEMNO"), NullValue("")> _
        Public Overridable Property ITEMNO() As System.String
            Get
                If IsReadOK("ITEMNO") Then  Return mstrITEMNO
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("ITEMNO") Then  Return
	            If Not Equals(mstrITEMNO, Value) Then
	                mstrITEMNO = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("ITEMNO")
			        MarkDirty("ITEMNO")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="ITEM_DESC", DataType:=12, Size:=60, SPUpdateOrdinal:=7), BusinessProperty("ID_cap_clsTRLOG_ITEM_DESC"), NullValue("")> _
        Public Overridable Property ITEM_DESC() As System.String
            Get
                If IsReadOK("ITEM_DESC") Then  Return mstrITEM_DESC
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("ITEM_DESC") Then  Return
	            If Not Equals(mstrITEM_DESC, Value) Then
	                mstrITEM_DESC = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("ITEM_DESC")
			        MarkDirty("ITEM_DESC")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="BANTCH", DataType:=12, Size:=24, SPUpdateOrdinal:=8), BusinessProperty("ID_cap_clsTRLOG_BANTCH"), NullValue("")> _
        Public Overridable Property BANTCH() As System.String
            Get
                If IsReadOK("BANTCH") Then  Return mstrBANTCH
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("BANTCH") Then  Return
	            If Not Equals(mstrBANTCH, Value) Then
	                mstrBANTCH = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("BANTCH")
			        MarkDirty("BANTCH")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="QTY", DataType:=5, Size:=9, Scale:=4, Precision:=14, SPUpdateOrdinal:=9), BusinessProperty("ID_cap_clsTRLOG_QTY"), NullValue(0)> _
        Public Overridable Property QTY() As System.Decimal
            Get
                If IsReadOK("QTY") Then  Return mcurQTY
                Return nothing
            End Get
	        Set(ByVal Value As System.Decimal)
	            If Not IsWriteOK("QTY") Then  Return
	            If Not Equals(mcurQTY, Value) Then
	                mcurQTY = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("QTY")
			        MarkDirty("QTY")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="status", DataType:=12, Size:=50, SPUpdateOrdinal:=10), BusinessProperty("ID_cap_clsTRLOG_status"), NullValue("")> _
        Public Overridable Property status() As System.String
            Get
                If IsReadOK("status") Then  Return mstrstatus
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("status") Then  Return
	            If Not Equals(mstrstatus, Value) Then
	                mstrstatus = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("status")
			        MarkDirty("status")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="reason", DataType:=12, Size:=50, SPUpdateOrdinal:=11), BusinessProperty("ID_cap_clsTRLOG_reason"), NullValue("")> _
        Public Overridable Property reason() As System.String
            Get
                If IsReadOK("reason") Then  Return mstrreason
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("reason") Then  Return
	            If Not Equals(mstrreason, Value) Then
	                mstrreason = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("reason")
			        MarkDirty("reason")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="reasonDesc", DataType:=22, Size:=255, SPUpdateOrdinal:=12), BusinessProperty(""), NullValue("")> _
        Public Overridable Property reasonDesc() As System.String
            Get
                If IsReadOK("reasonDesc") Then  Return mstrreasonDesc
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("reasonDesc") Then  Return
	            If Not Equals(mstrreasonDesc, Value) Then
	                mstrreasonDesc = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("reasonDesc")
			        MarkDirty("reasonDesc")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="OPT_BY", DataType:=12, Size:=50, SPUpdateOrdinal:=13), BusinessProperty("ID_cap_clsTRLOG_OPT_BY"), NullValue("")> _
        Public Overridable Property OPT_BY() As System.String
            Get
                If IsReadOK("OPT_BY") Then  Return mstrOPT_BY
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("OPT_BY") Then  Return
	            If Not Equals(mstrOPT_BY, Value) Then
	                mstrOPT_BY = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("OPT_BY")
			        MarkDirty("OPT_BY")
                End If
            End Set
        End Property
        
        <CXDBField(DBFieldName:="OPT_ADDR", DataType:=12, Size:=50, SPUpdateOrdinal:=14), BusinessProperty("ID_cap_clsTRLOG_OPT_ADDR"), NullValue("")> _
        Public Overridable Property OPT_ADDR() As System.String
            Get
                If IsReadOK("OPT_ADDR") Then  Return mstrOPT_ADDR
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("OPT_ADDR") Then  Return
	            If Not Equals(mstrOPT_ADDR, Value) Then
	                mstrOPT_ADDR = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("OPT_ADDR")
			        MarkDirty("OPT_ADDR")
                End If
            End Set
        End Property
        
        
        Public Overridable Property OPT_DATEText() As System.String
            Get
                If IsReadOK("OPT_DATE") Then  Return mdtmOPT_DATE.Text
                Return nothing
            End Get
	        Set(ByVal Value As System.String)
	            If Not IsWriteOK("OPT_DATE") Then  Return
	            If Not Equals(mdtmOPT_DATE.Text, Value) Then
	                mdtmOPT_DATE.Text = Value
	                If Not mblnIgnoreCheckRules Then BrokenRules.CheckRules("OPT_DATE")
			        MarkDirty("OPT_DATE")
                End If
            End Set
        End Property
        <CXDBField(DBFieldName:="OPT_DATE", DataType:=4, Size:=8, SPUpdateOrdinal:=15), BusinessProperty("ID_cap_clsTRLOG_OPT_DATE"), IsDateType(), System.ComponentModel.Editor(GetType(COMExpress.BusinessObject.Design.CXSmartDateEditor), GetType(System.Drawing.Design.UITypeEditor))> _
        Public Overridable Property OPT_DATE() As Object
            Get
            	Dim strValue As string = Me.OPT_DATEText
            	If strValue = String.Empty Then
            		Return System.DBNull.Value
            	Else
                	Return strValue
                End If
            End Get
            Set(ByVal Value As Object)
                If IsDate(Value) Then
                    Me.OPT_DATEText = CType(Value, String)
                Else
                    Me.OPT_DATEText = String.Empty
                End If
            End Set
        End Property
		<CXDBField(DBFieldName:="OPT_TIMESTAMP", DataType:=19, Size:=30, Flags:=CType(100, CXDBFieldFlags), SPUpdateOrdinal:=16), BusinessProperty("ID_cap_clsTRLOG_OPT_TIMESTAMP")> _
        Public Overridable ReadOnly Property OPT_TIMESTAMP() As System.Byte()
            Get
                If IsReadOK("OPT_TIMESTAMP") Then  Return mbytOPT_TIMESTAMP
                Return nothing
            End Get	
        End Property
	    Public Overrides ReadOnly Property BusinessCollectionType() As Type
	    	Get
	    	    Return GetType(clsTRLOGs)
	    	End Get
		End Property
		
#End Region

#Region " Shared Methods "    	
    	Public Shared Function Fetch(ByVal vlog_id As System.Int64, Optional ByVal nLevel As Integer = 0) As clsTRLOG
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsTRLOG), nLevel, "log_id", vlog_id)), clsTRLOG)
    	End Function  	
    	Public Shared Function Load(ByVal vlog_id As System.Int64, Optional ByVal nLevel As Integer = 0) As clsTRLOG
    	    Return CType(DataPortal.Fetch(New Criteria(GetType(clsTRLOG), nLevel, "log_id", vlog_id)), clsTRLOG)
    	End Function
    	
    	Public Shared Function LoadList(ByVal _Filters As CXFilters, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsTRLOGs
    	    Return YT.BusinessObject.clsTRLOGs.Fetch(_Filters, nLevel, iMaxNumber)
    	End Function
    	
    	Public Shared Function LoadListFromObj(ByVal obj As clsTRLOG, Optional ByVal nLevel As Integer = 0) As clsTRLOGs
    	    Return YT.BusinessObject.clsTRLOGs.Fetch(obj, nLevel)
    	End Function
    	    	
    	Public OverLoads Shared Sub Delete(ByVal vlog_id As System.Int64, Optional ByVal nLevel As Integer = 0)
    	    DataPortal.Delete(New Criteria(GetType(clsTRLOG), nLevel, "log_id", vlog_id))
    	End Sub
    	
    	Public Shared Function NewclsTRLOG() As clsTRLOG
            Return CType(DataPortal.Create(New Criteria(GetType(clsTRLOG), 0)), clsTRLOG)
        End Function
        
        Public Shared Function LoadListByWhereSQL(ByVal strWhereClause As String, Optional ByVal nLevel As Integer = 0, Optional ByVal iMaxNumber As Integer = 0) As clsTRLOGs
            Return YT.BusinessObject.clsTRLOGs.Fetch(strWhereClause , nLevel, iMaxNumber)
        End Function
#End Region

#Region " Broken rules "
		Protected Overrides Sub AddBusinessRules()
			MyBase.AddBusinessRules()
			With BrokenRules
      			.SetTargetObject(Me)
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "trans_type", New MaxLengthArgs("trans_type", 3))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "cmd_type", New MaxLengthArgs("cmd_type", 3))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "doc_no", New MaxLengthArgs("doc_no", 24))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "LINENUM", New MaxLengthArgs("LINENUM", 4))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "STCD", New MaxLengthArgs("STCD", 6))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "ITEMNO", New MaxLengthArgs("ITEMNO", 24))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "ITEM_DESC", New MaxLengthArgs("ITEM_DESC", 60))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "BANTCH", New MaxLengthArgs("BANTCH", 24))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "status", New MaxLengthArgs("status", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "reason", New MaxLengthArgs("reason", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "reasonDesc", New MaxLengthArgs("reasonDesc", 255))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "OPT_BY", New MaxLengthArgs("OPT_BY", 50))
      			.AddRule(AddressOf ValidationRules.rlMaxFieldLength, "OPT_ADDR", New MaxLengthArgs("OPT_ADDR", 50))
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
    <Serializable()> Public Class clsTRLOG
        Inherits clsTRLOGBase_
        
        Protected Sub New()
            MyBase.New()
        End Sub
        
    End Class
#End Region
    
End Namespace