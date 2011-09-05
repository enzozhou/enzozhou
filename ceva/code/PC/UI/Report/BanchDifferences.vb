Imports YT
Imports YT.BusinessObject
Imports COMExpress.BusinessObject
Imports System.IO
Imports ImportExport
Imports COMExpress.Windows.Forms
Public Class BanchDifferences
    Inherits System.Windows.Forms.Form
    Public initBanchNo As String = ""
    Public initDCCode As String = ""
    Public Function GetDate(ByVal val_dc_code As String, ByVal val_bch_no As String) As Boolean
        Dim cmd As IDbCommand = COMExpress.BusinessObject.DatabaseHelper.CreateDbCommand
        Dim parmUserCode As String = UserRightMgr.gUserCode
        Dim prm1 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        Dim prm2 As IDbDataParameter = COMExpress.BusinessObject.DatabaseHelper.CreateDbParameter
        cmd.Connection = COMExpress.BusinessObject.DatabaseHelper.CreateDbConnection
        With prm1
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Size = 20
            .ParameterName = "@dc_code"
            If Trim(val_dc_code) = String.Empty Then
                .Value = DBNull.Value
            Else
                .Value = Trim(val_dc_code)
            End If
        End With
        With prm2
            .DbType = DbType.String
            .Direction = ParameterDirection.Input
            .Size = 20
            .ParameterName = "@BCH_NO"
            If Trim(val_bch_no) = String.Empty Then
                .Value = DBNull.Value
            Else
                .Value = Trim(val_bch_no)
            End If
        End With
        Try
            cmd.Parameters.Add(prm1)
            cmd.Parameters.Add(prm2)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "stp_get_Differences_by_Banch"
            DatabaseHelper.OpenConnection(cmd.Connection)
            'If Not DatabaseHelper.InGlobalTransaction Then cmd.Transaction = cmd.Connection.BeginTransaction(COMExpress.BusinessObject.DatabaseHelper.TransIsolationLevel)
            Dim idr As IDataReader
            idr = cmd.ExecuteReader()
            Dim _ds As DataSet = New DataSet()
            Dim _dt As DataTable = New DataTable()
            _dt.TableName = "Differences"
            _ds.Tables.Add(_dt)
            _ds.Load(idr, LoadOption.OverwriteChanges, _dt)
            idr.Close()
            dgv.Refresh()
            dgv.DataMember = "Differences"
            dgv.DataSource = _ds
            dgv.AutoGenerateColumns = False
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            Return True
        Catch eex As Exception
            Return False
        Finally
            Try
                DatabaseHelper.CloseConnection(cmd.Connection)
                'cmd.Connection.Close()
            Catch ex As Exception
            End Try
            cmd.Dispose()
        End Try
    End Function
    Function ConvertString(ByVal var_str As String) As String
        Return ConvertString(var_str, 42)
    End Function
    Function ConvertString(ByVal var_str As String, ByVal var_num As Integer) As String
        Dim tmp As String = Convert.ToChar(var_num).ToString()
        Return tmp + var_str + tmp
    End Function
    Private Sub loadData()
        GetDate(initDCCode, initBanchNo)
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Me.DialogResult = DialogResult.OK
    End Sub
    Private Sub CheckBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        Try
            CheckBox1.Checked = True
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            For Each _DataGridViewRow As DataGridViewRow In dgv.Rows
                Dim _CheckBox As DataGridViewCheckBoxCell = _DataGridViewRow.Cells(0)
                '_CheckBox.Selected = True
                _CheckBox.Value = True
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub CheckBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.Click
        Try
            CheckBox1.Checked = False
            CheckBox3.Checked = False
            CheckBox2.Checked = True
            For Each _DataGridViewRow As DataGridViewRow In dgv.Rows
                Dim _CheckBox As DataGridViewCheckBoxCell = _DataGridViewRow.Cells(0)
                If _CheckBox.Value Then
                    '_CheckBox.Selected = False
                    _CheckBox.Value = False
                Else
                    '_CheckBox.Selected = True
                    _CheckBox.Value = True
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CheckBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.Click
        Try
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            For Each _DataGridViewRow As DataGridViewRow In dgv.Rows
                Dim _CheckBox As DataGridViewCheckBoxCell = _DataGridViewRow.Cells(0)
                If _CheckBox.Value Then
                    '_CheckBox.Selected = False
                    _CheckBox.Value = False
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BanchDifferences_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadData()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Me.DialogResult = DialogResult.Cancel
    End Sub
End Class
