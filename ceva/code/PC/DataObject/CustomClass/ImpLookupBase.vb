Imports COMExpress.BusinessObject
Imports System.Threading
Imports System.IO

Namespace BusinessObject
    <Serializable()> Public Class ImpLookupBase
        Inherits LookupBase



        Private Shared mPrivateMacAddress As String = ""
        Public Shared Function GetMacAddress() As String
            If Trim(mPrivateMacAddress) <> "" Then
                Return mPrivateMacAddress
            End If

            Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
            Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter

            cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection
            With prm1
                .DbType = DbType.String
                .Direction = ParameterDirection.Output
                .Size = 20
                .ParameterName = "@netaddr"
            End With

            Try
                cmd.Parameters.Add(prm1)

                cmd.CommandType = CommandType.StoredProcedure
                cmd.CommandText = "stp_get_macaddress"
                'cmd.Connection.Open()
                DatabaseHelper.OpenConnection(cmd.Connection)
                cmd.ExecuteNonQuery()
                If IsDBNull(prm1.Value) Then
                    Return ""
                End If
                mPrivateMacAddress = CType(prm1.Value, String)
                Return mPrivateMacAddress
            Catch e As Exception
                Try
                    cmd.Transaction.Rollback()
                Catch ee As Exception
                End Try
                Return ""
            Finally
                Try
                    DatabaseHelper.CloseConnection(cmd.Connection)
                    'cmd.Connection.Close()
                Catch ex As Exception
                End Try
                cmd.Dispose()
            End Try
        End Function
        Public Function GetPermissionList() As DataSet
            Dim strSQL As String
            strSQL = "select right_no,description from permission"
            Return SQLToDataSet(strSQL)
        End Function

        Public Function GetUserListByDC() As DataSet
            Dim strSQL As String
            strSQL = "select user_code as user_code,user_name as user_name  from operator where not (isnull(isadmin,0)=1 )"
            Return SQLToDataSet(strSQL)
        End Function
        Public Function GetUserListByWhere(ByVal sWhere As String) As DataSet
            Dim strSQL As String
            strSQL = "select user_code as user_code,user_name as user_name  from operator " + sWhere
            Return SQLToDataSet(strSQL)
        End Function
        Public Function GetRoleByWhere(ByVal sWhere As String) As DataSet
            Dim strSQL As String
            strSQL = "select role_code,role_name  from role " + sWhere
            Return SQLToDataSet(strSQL)
        End Function
        Public Function GetAvariableDNListByWhere(ByVal sWhere As String) As DataSet
            ''此DN单不存在于现有的批次中，同时此DN单的状态为初始状态。
            Dim strSQL As String
            strSQL = "select dn_no as dn_no, dn_no+' | ' + city_to as descr from dnhdr where dn_no not in (select distinct dn_no from bchlin )  and status_code = '0' " + sWhere + " order by  city_to "
            Return SQLToDataSet(strSQL)
        End Function
        Public Function GetAvariableBanchByWhere(ByVal sWhere As String) As DataSet
            Dim strSQL As String
            strSQL = "select bch_no from bchhdr where status_code < 2 and bch_no not in (select bch_no from taskhdr)  " + sWhere
            Return SQLToDataSet(strSQL)
        End Function
        Public Function GetBanchByWhereForClose(ByVal sWhere As String) As DataSet
            Dim strSQL As String
            strSQL = "select bch_no from bchhdr where 1=1  " + sWhere
            Return SQLToDataSet(strSQL)
        End Function
        Public Function GetAvariableSonyBanchByWhere(ByVal sWhere As String) As DataSet
            Dim strSQL As String
            strSQL = "select distinct sony_bch_no from dnhdr  where status_code < 4 and dn_no not in (select distinct dn_no from bchlin ) " + sWhere
            Return SQLToDataSet(strSQL)
        End Function
        Public Function GetCityByWhere(ByVal sWhere As String) As DataSet
            Dim strSQL As String
            strSQL = "select distinct destination as city from dbo.cityairport where 1=1  " + sWhere
            Return SQLToDataSet(strSQL)
        End Function
        Public Function GetAvariableBinCount() As DataSet
            Dim strSQL As String
            strSQL = "select isnull(count(bin_code),0) as bincount from bin where bin_code not in (select bin_code from binstatus)"
            Return SQLToDataSet(strSQL)
        End Function

        Public Function getStartTime(ByVal flag As String) As String
            Dim _startTime As String

            If flag = "0" Then      ' 当天开始时间
                _startTime = DateTime.Now.ToString("yyyy-MM-dd")
                _startTime = DateTime.Parse(_startTime).ToString()
            ElseIf flag = "1" Then      '当周的开始时间
                Select Case DateTime.Now.DayOfWeek().ToString()
                    Case "Sunday"
                        _startTime = DateTime.Now.ToString("yyyy-MM-dd")
                        _startTime = DateTime.Parse(_startTime).ToString()
                    Case "Monday"
                        _startTime = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")
                        _startTime = DateTime.Parse(_startTime).ToString()
                    Case "Tuesday"
                        _startTime = DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd")
                        _startTime = DateTime.Parse(_startTime).ToString()
                    Case "Wednesday"
                        _startTime = DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd")
                        _startTime = DateTime.Parse(_startTime).ToString()
                    Case "Thursday"
                        _startTime = DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd")
                        _startTime = DateTime.Parse(_startTime).ToString()
                    Case "Friday"
                        _startTime = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd")
                        _startTime = DateTime.Parse(_startTime).ToString()
                    Case "Saturday"
                        _startTime = DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd")
                        _startTime = DateTime.Parse(_startTime).ToString()
                End Select

            ElseIf flag = "2" Then      '当月
                _startTime = DateTime.Now.ToString("yyyy-MM-dd")
                _startTime = DateTime.Parse(_startTime.Substring(0, 8) + "01").ToString()
            End If
            Return _startTime
        End Function

        Public Function GetReceivingPOList(ByVal dc_code As String, ByVal stime As String, ByVal etime As String, ByVal contain As String) As DataSet
            Dim strSQL As String
            If contain = "1" Then
                strSQL = "select POHID,STCD from po_hdr where opt_date>='" + stime + "'" + "and opt_date<='" + etime + "'"
            Else
                strSQL = "select POHID,STCD from po_hdr where opt_date>='" + stime + "'" + "and opt_date<='" + etime + "'"
            End If
            Return SQLToDataSet(strSQL)
        End Function
        Public Function GetReceivingWOList(ByVal dc_code As String, ByVal stime As String, ByVal etime As String, ByVal contain As String) As DataSet
            Dim strSQL As String
            If contain = "1" Then
                strSQL = "select WOHID,STCD from wo_hdr where opt_date>='" + stime + "'" + "and opt_date<='" + etime + "'"
            Else
                strSQL = "select WOHID,STCD from wo_hdr where opt_date>='" + stime + "'" + "and opt_date<='" + etime + "'"
            End If
            Return SQLToDataSet(strSQL)
        End Function

        Public Function GetPOSkuNo(ByVal dc_code As String, ByVal Ro_No As String) As DataSet
            Dim strSQL As String
            strSQL = "select distinct rtrim(ltrim(UPPER(item_desc))) as item_desc,rtrim(ltrim(item)) as item,isnull(ORDERED,0) as ORDERED from po_lin  where  POHID ='" + Ro_No + "' "
            Return SQLToDataSet(strSQL)
        End Function
        Public Function GetWOSkuNo(ByVal dc_code As String, ByVal Ro_No As String) As DataSet
            Dim strSQL As String
            strSQL = "select distinct rtrim(ltrim(UPPER(descr))) as descr,rtrim(ltrim(item)) as item,isnull(orderqty,0) as orderqty from wo_hdr  where  WOHID ='" + Ro_No + "' "
            Return SQLToDataSet(strSQL)
        End Function
        Public Function GetPictureNameBySkuNo(ByVal SkuNo As String) As DataSet
            Dim strSQL As String
            strSQL = "select distinct isnull(VARCHAR,'Default.bmp') from ICITEM  where  ITEMNO ='" + RTrim(LTrim(SkuNo)) + "' " + " or  ITEM_DESC ='" + RTrim(LTrim(SkuNo)) + "' "
            Return SQLToDataSet(strSQL)
        End Function

        Public Function GetPOSkuNumber(ByVal Ro_No As String, ByVal SkuNo As String) As DataSet
            Dim strSQL As String
            strSQL = "select distinct item,isnull(ORDERED,0) as ORDERED from po_lin  where  POHID ='" + Ro_No + "' and  (item='" + SkuNo + "'" + " or ITEM_DESC = '" + SkuNo + "' )"
            Return SQLToDataSet(strSQL)
        End Function
        Public Function GetItemPackage(ByVal SkuNo As String) As DataSet
            Dim strSQL As String
            strSQL = "select distinct itemno,isnull(package,0) as package,v_up,v_down,v_left,v_right from ICITEM  where   itemno='" + SkuNo + "'" + " or  ITEM_DESC ='" + SkuNo + "' "
            Return SQLToDataSet(strSQL)
        End Function
        Public Function GetItemOrDescr(ByVal SkuNo As String) As DataSet
            Dim strSQL As String
            strSQL = "select distinct itemno,item_desc from ICITEM  where   itemno='" + SkuNo + "'" + " or  ITEM_DESC ='" + SkuNo + "' "
            Return SQLToDataSet(strSQL)
        End Function

        Public Function GetWOSkuNumber(ByVal Ro_No As String, ByVal SkuNo As String) As DataSet
            Dim strSQL As String
            strSQL = "select distinct item,isnull(REQQTY,0) as REQQTY from wo_lin  where  WOHID ='" + Ro_No + "' and  (item='" + SkuNo + "'" + " or DESCR = '" + SkuNo + "' )"
            Return SQLToDataSet(strSQL)
        End Function

    End Class
End Namespace
