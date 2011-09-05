Imports COMExpress.BusinessObject

Module mDAO
    'Private Sub SetDSNInformation(ByVal strDSN As String, ByVal strServer As String, ByVal strCatalog As String, ByVal bTrust As Boolean)
    '    Dim objDao As DAO.DBEngine
    '    Dim str As String
    '    If bTrust = True Then
    '        str = "Server=" & strServer & vbCr & "database=" & strCatalog & vbCr & "Trusted_Connection=Yes"
    '    Else
    '        str = "Server=" & strServer & vbCr & "database=" & strCatalog & vbCr & "Trusted_Connection=No"
    '    End If
    '    objDao = New DAO.DBEngine
    '    objDao.RegisterDatabase(strDSN, "SQL Server", True, str)
    '    objDao = Nothing
    'End Sub


    'Public Sub SetODBCDSNForReport()
    '    Dim strServer As String
    '    Dim strCatalog As String
    '    'Here using SQLConnection, so that we need not parse connection string.
    '    Dim cn As IDbConnection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection()
    '    If Not TypeOf cn Is SqlClient.SqlConnection Then
    '        Throw New Exception("Only SQL Server Supported")
    '    End If
    '    Try
    '        'cn.Open()
    '        COMExpress.BusinessObject.DatabaseHelper.OpenConnection(cn)
    '        'strServer = DirectCast(cn, SqlClient.SqlConnection).DataSource
    '        'strCatalog = DirectCast(cn, SqlClient.SqlConnection).Database
    '        'SetDSNInformation(strCatalog, strServer, strCatalog, False)
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        DatabaseHelper.CloseConnection(cn)
    '        'cn.Close()
    '    End Try
    'End Sub
End Module
