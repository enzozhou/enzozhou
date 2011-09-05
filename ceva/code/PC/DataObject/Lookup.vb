Option Explicit On 
Option Strict On

Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.CustomAttribute
Imports YT

Namespace BusinessObject
    <Serializable()> Public Class LookupBaseDerived
        Inherits ImpLookupBase
#Region "Class variables"
	
        <CXPropertyVar(PropertyName:="GetStatusCodeSQLClause")> Protected mobjDSGetStatusCode As DataSet
        <CXPropertyVar(PropertyName:="GetDNStatusCodeSQLClause")> Protected mobjDSGetDNStatusCode As DataSet
        <CXPropertyVar(PropertyName:="GetBanchStatusCodeSQLClause")> Protected mobjDSGetBanchStatusCode As DataSet
        <CXPropertyVar(PropertyName:="GetTaskStatusCodeSQLClause")> Protected mobjDSGetTaskStatusCode As DataSet
        <CXPropertyVar(PropertyName:="GetDocTypeSQLClause")> Protected mobjDSGetDocType As DataSet
        
#End Region
        
#Region "Global Lookup methods"
        
        	
        Public Overridable Function GetStatusCode( _
        	ByVal intCallType As CXLookupCallTypeConstants, _
        	ByVal prmValues() As Object) As DataSet
            If mobjDSGetStatusCode Is Nothing Then
                Dim dt As DataTable = BuildStaticTable("GetStatusCode","System.String")
                Dim dr As DataRow
                mobjDSGetStatusCode = New DataSet
                dr = dt.NewRow
                With dr
                    .Item(0) = "0    " 
                    .Item(1) = gResourceManager.GetObject("ID_status_code_0")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "1    "
                    .Item(1) = gResourceManager.GetObject("ID_status_code_1")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "2    "
                    .Item(1) = gResourceManager.GetObject("ID_status_code_2")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "3    "
                    .Item(1) = gResourceManager.GetObject("ID_status_code_3")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "4    "
                    .Item(1) = gResourceManager.GetObject("ID_status_code_4")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "5    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_DnStatusCode5")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "6    "
                    .Item(1) = gResourceManager.GetObject("ID_status_code_6")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "7    "
                    .Item(1) = gResourceManager.GetObject("ID_status_code_7")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "8    "
                    .Item(1) = gResourceManager.GetObject("ID_status_code_8")
                End With
                dt.Rows.Add(dr)
                
                mobjDSGetStatusCode.Tables.Add(dt)
            End If
            Return mobjDSGetStatusCode
        End Function
        	
        Public Overridable Function GetDNStatusCode( _
        	ByVal intCallType As CXLookupCallTypeConstants, _
        	ByVal prmValues() As Object) As DataSet
            If mobjDSGetDNStatusCode Is Nothing Then
                Dim dt As DataTable = BuildStaticTable("GetDNStatusCode","System.String")
                Dim dr As DataRow
                mobjDSGetDNStatusCode = New DataSet
                dr = dt.NewRow
                With dr
                    .Item(0) = "0    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_TaskStatusCode0")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "1    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_DnStatusCode1")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "2    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_DnStatusCode2")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "3    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_DnStatusCode3")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "4    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_DnStatusCode4")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "5    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_DnStatusCode5")
                End With
                dt.Rows.Add(dr)
                
                mobjDSGetDNStatusCode.Tables.Add(dt)
            End If
            Return mobjDSGetDNStatusCode
        End Function
        	
        Public Overridable Function GetBanchStatusCode( _
        	ByVal intCallType As CXLookupCallTypeConstants, _
        	ByVal prmValues() As Object) As DataSet
            If mobjDSGetBanchStatusCode Is Nothing Then
                Dim dt As DataTable = BuildStaticTable("GetBanchStatusCode","System.String")
                Dim dr As DataRow
                mobjDSGetBanchStatusCode = New DataSet
                dr = dt.NewRow
                With dr
                    .Item(0) = "0    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_TaskStatusCode0")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "1    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_banchStatusCode1")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "2    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_banchStatusCode2")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "3    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_banchStatusCode3")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "4    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_banchStatusCode4")
                End With
                dt.Rows.Add(dr)
                
                mobjDSGetBanchStatusCode.Tables.Add(dt)
            End If
            Return mobjDSGetBanchStatusCode
        End Function
        	
        Public Overridable Function GetTaskStatusCode( _
        	ByVal intCallType As CXLookupCallTypeConstants, _
        	ByVal prmValues() As Object) As DataSet
            If mobjDSGetTaskStatusCode Is Nothing Then
                Dim dt As DataTable = BuildStaticTable("GetTaskStatusCode","System.String")
                Dim dr As DataRow
                mobjDSGetTaskStatusCode = New DataSet
                dr = dt.NewRow
                With dr
                    .Item(0) = "0    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_TaskStatusCode0")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "1    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_TaskStatusCode1")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "2    "
                    .Item(1) = gResourceManager.GetObject("ID_cap_TaskStatusCode2")
                End With
                dt.Rows.Add(dr)
                
                mobjDSGetTaskStatusCode.Tables.Add(dt)
            End If
            Return mobjDSGetTaskStatusCode
        End Function
        	
        Public Overridable Function GetDocType( _
        	ByVal intCallType As CXLookupCallTypeConstants, _
        	ByVal prmValues() As Object) As DataSet
            If mobjDSGetDocType Is Nothing Then
                Dim dt As DataTable = BuildStaticTable("GetDocType","System.String")
                Dim dr As DataRow
                mobjDSGetDocType = New DataSet
                dr = dt.NewRow
                With dr
                    .Item(0) = "0"
                    .Item(1) = gResourceManager.GetObject("ID_cap_doctype0")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "1"
                    .Item(1) = gResourceManager.GetObject("ID_cap_doctype1")
                End With
                dt.Rows.Add(dr)
                dr = dt.NewRow
                With dr
                    .Item(0) = "2"
                    .Item(1) = gResourceManager.GetObject("ID_cap_doctype2")
                End With
                With dr
                    .Item(0) = "3"
                    .Item(1) = gResourceManager.GetObject("ID_cap_doctype3")
                End With
                With dr
                    .Item(0) = "4"
                    .Item(1) = gResourceManager.GetObject("ID_cap_doctype4")
                End With
                With dr
                    .Item(0) = "5"
                    .Item(1) = gResourceManager.GetObject("ID_cap_doctype5")
                End With
                With dr
                    .Item(0) = "6"
                    .Item(1) = gResourceManager.GetObject("ID_cap_doctype6")
                End With
                With dr
                    .Item(0) = "7"
                    .Item(1) = gResourceManager.GetObject("ID_cap_doctype7")
                End With
                dt.Rows.Add(dr)
                
                mobjDSGetDocType.Tables.Add(dt)
            End If
            Return mobjDSGetDocType
        End Function
        
#End Region
		
#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region

    End Class

#Region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"    
    <Serializable()> Public Class Lookup
        Inherits LookupBaseDerived
        
    End Class
#End Region
End Namespace