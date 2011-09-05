Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Diagnostics
Imports System.Text
Imports System.Data.SqlClient

#Region "Model"
''' <summary>
''' 实体类 tasklistM 
''' </summary>
<Serializable()> _
Public Class tasklistM
    Public Sub New()
    End Sub

    Public Sub Clear()
        _dc_code = Nothing
        _wh_code = Nothing
        _task_id = Nothing
        _bch_no = Nothing
        _dn_no = Nothing
        _assigned_opt = Nothing
        _bin_area = Nothing
        _bin_code = Nothing
        _sku_no = Nothing
        _qty = 0
        _type = Nothing
        _status_code = Nothing
        _close_auto = Nothing
        _print_by = Nothing
        _print_counter = 0
        _print_dtime = DateTime.MinValue
        _locked = 0
        _opt_by = Nothing
        _opt_dtime = DateTime.MinValue
        _start_dtime = DateTime.MinValue
        _end_dtime = DateTime.MinValue
        _opt_timestamp = Nothing
    End Sub
    Private _dc_code As [String]
    Private _wh_code As [String]
    Private _task_id As [String]
    Private _bch_no As [String]
    Private _dn_no As [String]
    Private _assigned_opt As [String]
    Private _bin_area As [String]
    Private _bin_code As [String]
    Private _sku_no As [String]
    Private _qty As [Decimal]
    Private _type As String
    Private _status_code As String
    Private _close_auto As String
    Private _print_by As [String]
    Private _print_counter As Int32
    Private _print_dtime As DateTime
    Private _locked As Int32
    Private _opt_by As [String]
    Private _opt_dtime As DateTime
    Private _start_dtime As DateTime
    Private _end_dtime As DateTime
    Private _opt_timestamp As [Byte]()

    ''' <summary>
    ''' 
    ''' </summary>
    Public Property dc_code() As [String]
        Get
            Return _dc_code
        End Get
        Set(ByVal value As [String])
            _dc_code = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property wh_code() As [String]
        Get
            Return _wh_code
        End Get
        Set(ByVal value As [String])
            _wh_code = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property task_id() As [String]
        Get
            Return _task_id
        End Get
        Set(ByVal value As [String])
            _task_id = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property bch_no() As [String]
        Get
            Return _bch_no
        End Get
        Set(ByVal value As [String])
            _bch_no = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property dn_no() As [String]
        Get
            Return _dn_no
        End Get
        Set(ByVal value As [String])
            _dn_no = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property assigned_opt() As [String]
        Get
            Return _assigned_opt
        End Get
        Set(ByVal value As [String])
            _assigned_opt = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property bin_area() As [String]
        Get
            Return _bin_area
        End Get
        Set(ByVal value As [String])
            _bin_area = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property bin_code() As [String]
        Get
            Return _bin_code
        End Get
        Set(ByVal value As [String])
            _bin_code = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property sku_no() As [String]
        Get
            Return _sku_no
        End Get
        Set(ByVal value As [String])
            _sku_no = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property qty() As [Decimal]
        Get
            Return _qty
        End Get
        Set(ByVal value As [Decimal])
            _qty = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property status_code() As String
        Get
            Return _status_code
        End Get
        Set(ByVal value As String)
            _status_code = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property close_auto() As String
        Get
            Return _close_auto
        End Get
        Set(ByVal value As String)
            _close_auto = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property print_by() As [String]
        Get
            Return _print_by
        End Get
        Set(ByVal value As [String])
            _print_by = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property print_counter() As Int32
        Get
            Return _print_counter
        End Get
        Set(ByVal value As Int32)
            _print_counter = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property print_dtime() As DateTime
        Get
            Return _print_dtime
        End Get
        Set(ByVal value As DateTime)
            _print_dtime = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property locked() As Int32
        Get
            Return _locked
        End Get
        Set(ByVal value As Int32)
            _locked = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property opt_by() As [String]
        Get
            Return _opt_by
        End Get
        Set(ByVal value As [String])
            _opt_by = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property opt_dtime() As DateTime
        Get
            Return _opt_dtime
        End Get
        Set(ByVal value As DateTime)
            _opt_dtime = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property start_dtime() As DateTime
        Get
            Return _start_dtime
        End Get
        Set(ByVal value As DateTime)
            _start_dtime = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property end_dtime() As DateTime
        Get
            Return _end_dtime
        End Get
        Set(ByVal value As DateTime)
            _end_dtime = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    Public Property opt_timestamp() As [Byte]()
        Get
            Return _opt_timestamp
        End Get
        Set(ByVal value As [Byte]())
            _opt_timestamp = value
        End Set
    End Property
End Class
#End Region

''' <summary>
''' 从web service的dataset中映射本类的实例
''' </summary>
''' <remarks></remarks>
Public Class tasklist

    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    Public Shared Sub ParametersClear(ByRef cmd As System.Data.SqlClient.SqlCommand)
        Dim i As Integer = 0
        Do While (i _
                    <= (cmd.Parameters.Count - 1))
            cmd.Parameters(i).Value = Nothing
            i = (i + 1)
        Loop
    End Sub

    ''' <summary>
    '''
    ''' </summary>
    Public Shared Function GetModel(ByVal dc_code As String, ByVal wh_code As String, ByVal task_id As String, ByVal bch_no As String, ByVal dn_no As String, ByVal assigned_opt As String, ByVal bin_area As String, ByVal bin_code As String, ByVal sku_no As String) As tasklistM
        'dbCon = New System.Data.SqlClient.SqlConnection(SQLDBhelper.SS_dbconnect_String)
        Dim GetModelCMD As System.Data.SqlClient.SqlCommand = New SqlCommand
        GetModelCMD.CommandText = "select top 1 dc_code,wh_code,task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,sku_no,qty,type,stat" & _
        "us_code,close_auto,print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime," & _
        "opt_timestamp from tasklist  where dc_code=@dc_code and wh_code=@wh_code and task_id=@task_id and bc" & _
        "h_no=@bch_no and dn_no=@dn_no and assigned_opt=@assigned_opt and bin_area=@bin_area and bin_code=@bi" & _
        "n_code and sku_no=@sku_no"
        'GetModelCMD.Connection = dbCon
        GetModelCMD.Parameters.AddWithValue("@dc_code", dc_code)
        GetModelCMD.Parameters.AddWithValue("@wh_code", wh_code)
        GetModelCMD.Parameters.AddWithValue("@task_id", task_id)
        GetModelCMD.Parameters.AddWithValue("@bch_no", bch_no)
        GetModelCMD.Parameters.AddWithValue("@dn_no", dn_no)
        GetModelCMD.Parameters.AddWithValue("@assigned_opt", assigned_opt)
        GetModelCMD.Parameters.AddWithValue("@bin_area", bin_area)
        GetModelCMD.Parameters.AddWithValue("@bin_code", bin_code)
        GetModelCMD.Parameters.AddWithValue("@sku_no", sku_no)
        'If (dbCon.State <> ConnectionState.Open) Then
        '    dbCon.Open()
        'End If
        Dim sda As SqlDataAdapter = New SqlDataAdapter
        sda.SelectCommand = GetModelCMD
        Dim ds As DataSet = New DataSet
        sda.Fill(ds)
        If (ds.Tables(0).Rows.Count > 0) Then
            Dim model As tasklistM = New tasklistM
            model.dc_code = Convert.ToString(ds.Tables(0).Rows(0)("dc_code"))
            model.wh_code = Convert.ToString(ds.Tables(0).Rows(0)("wh_code"))
            model.task_id = Convert.ToString(ds.Tables(0).Rows(0)("task_id"))
            model.bch_no = Convert.ToString(ds.Tables(0).Rows(0)("bch_no"))
            model.dn_no = Convert.ToString(ds.Tables(0).Rows(0)("dn_no"))
            model.assigned_opt = Convert.ToString(ds.Tables(0).Rows(0)("assigned_opt"))
            model.bin_area = Convert.ToString(ds.Tables(0).Rows(0)("bin_area"))
            model.bin_code = Convert.ToString(ds.Tables(0).Rows(0)("bin_code"))
            model.sku_no = Convert.ToString(ds.Tables(0).Rows(0)("sku_no"))
            model.qty = Convert.ToDecimal(ds.Tables(0).Rows(0)("qty"))
            model.type = Convert.Tostring(ds.Tables(0).Rows(0)("type"))
            model.status_code = Convert.Tostring(ds.Tables(0).Rows(0)("status_code"))
            model.close_auto = Convert.Tostring(ds.Tables(0).Rows(0)("close_auto"))
            model.print_by = Convert.ToString(ds.Tables(0).Rows(0)("print_by"))
            model.print_counter = Convert.ToInt32(ds.Tables(0).Rows(0)("print_counter"))
            model.print_dtime = Convert.ToDateTime(ds.Tables(0).Rows(0)("print_dtime"))
            model.locked = Convert.ToInt32(ds.Tables(0).Rows(0)("locked"))
            model.opt_by = Convert.ToString(ds.Tables(0).Rows(0)("opt_by"))
            model.opt_dtime = Convert.ToDateTime(ds.Tables(0).Rows(0)("opt_dtime"))
            model.start_dtime = Convert.ToDateTime(ds.Tables(0).Rows(0)("start_dtime"))
            model.end_dtime = Convert.ToDateTime(ds.Tables(0).Rows(0)("end_dtime"))
            Return model
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    Public Overloads Shared Function GetList(ByVal whereSql As String) As DataSet
        Dim GetListCMD As System.Data.SqlClient.SqlCommand = New SqlCommand
        GetListCMD.CommandText = ("select dc_code,wh_code,task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,sku_no,qty,type,status_cod" & _
        "e,close_auto,print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_ti" & _
        "mestamp from tasklist " + whereSql)
        Return Nothing
        'Return SQLDBhelper.Query(GetListCMD)
    End Function

    ''' <summary>
    '''
    ''' </summary>
    Public Overloads Shared Function GetList(ByVal dc_code As String, ByVal wh_code As String, ByVal task_id As String, ByVal bch_no As String, ByVal dn_no As String, ByVal assigned_opt As String, ByVal bin_area As String, ByVal bin_code As String, ByVal sku_no As String) As DataSet
        Dim GetListCMD As System.Data.SqlClient.SqlCommand = New SqlCommand
        GetListCMD.CommandText = "select dc_code,wh_code,task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,sku_no,qty,type,status_cod" & _
        "e,close_auto,print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_ti" & _
        "mestamp from tasklist  where dc_code=@dc_code and wh_code=@wh_code and task_id=@task_id and bch_no=@" & _
        "bch_no and dn_no=@dn_no and assigned_opt=@assigned_opt and bin_area=@bin_area and bin_code=@bin_code" & _
        " and sku_no=@sku_no"
        GetListCMD.Parameters.AddWithValue("@dc_code", dc_code)
        GetListCMD.Parameters.AddWithValue("@wh_code", wh_code)
        GetListCMD.Parameters.AddWithValue("@task_id", task_id)
        GetListCMD.Parameters.AddWithValue("@bch_no", bch_no)
        GetListCMD.Parameters.AddWithValue("@dn_no", dn_no)
        GetListCMD.Parameters.AddWithValue("@assigned_opt", assigned_opt)
        GetListCMD.Parameters.AddWithValue("@bin_area", bin_area)
        GetListCMD.Parameters.AddWithValue("@bin_code", bin_code)
        GetListCMD.Parameters.AddWithValue("@sku_no", sku_no)
        'Return SQLDBhelper.Query(GetListCMD)
        Return Nothing
    End Function

    ''' <summary>
    '''
    ''' </summary>
    Public Overloads Shared Function GetList(ByVal Top As Integer, ByVal dc_code As String, ByVal wh_code As String, ByVal task_id As String, ByVal bch_no As String, ByVal dn_no As String, ByVal assigned_opt As String, ByVal bin_area As String, ByVal bin_code As String, ByVal sku_no As String, ByVal Orderby As String) As DataSet
        Dim strSql As StringBuilder = New StringBuilder
        strSql.Append(("select top " _
                        + (Top.ToString + (" dc_code,wh_code,task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,sku_no,qty,type,status_code,clos" & _
                        "e_auto,print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestam" & _
                        "p from tasklist  where dc_code=@dc_code and wh_code=@wh_code and task_id=@task_id and bch_no=@bch_no" & _
                        " and dn_no=@dn_no and assigned_opt=@assigned_opt and bin_area=@bin_area and bin_code=@bin_code and s" & _
                        "ku_no=@sku_no " + Orderby))))
        Dim GetListCMD As System.Data.SqlClient.SqlCommand = New SqlCommand
        GetListCMD.CommandText = strSql.ToString
        GetListCMD.Parameters.AddWithValue("@dc_code", dc_code)
        GetListCMD.Parameters.AddWithValue("@wh_code", wh_code)
        GetListCMD.Parameters.AddWithValue("@task_id", task_id)
        GetListCMD.Parameters.AddWithValue("@bch_no", bch_no)
        GetListCMD.Parameters.AddWithValue("@dn_no", dn_no)
        GetListCMD.Parameters.AddWithValue("@assigned_opt", assigned_opt)
        GetListCMD.Parameters.AddWithValue("@bin_area", bin_area)
        GetListCMD.Parameters.AddWithValue("@bin_code", bin_code)
        GetListCMD.Parameters.AddWithValue("@sku_no", sku_no)
        'Return SQLDBhelper.Query(GetListCMD)
        Return Nothing
    End Function

End Class