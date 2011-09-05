Imports YT
Imports YT.BusinessObject

Public Class PublicResource
    Private Shared mStringResMgr As New Resources.ResourceManager("YTUI.ImpStringTable", GetType(frmMain).Module.Assembly)


    Public Shared Function LoadResString(ByVal ID As String, Optional ByVal strDef As String = " ") As String
        Try
            Dim s As String
            If Trim(ID) = "" Then
                Return ""
            End If
            s = Trim(CType(mStringResMgr.GetObject(ID), String))
            If s = "" Then
                Try
                    SysRes.RecordResource(ID, strDef, "UI")
                Catch ex As Exception
                End Try
                If Trim(strDef) = "" Then
                    Return ID
                End If
                Return strDef
            Else
                Return s
            End If
        Catch ex As Exception
            If Trim(strDef) = "" Then
                Return ID
            End If
            Return strDef
        End Try
    End Function

End Class

Module mPublicResourceFunction

    Public Function GetFieldCaption(ByVal FieldName As String, Optional ByVal UseRes As Boolean = False, Optional ByVal strDef As String = "") As String
        If UseRes Then
            Return PublicResource.LoadResString(FieldName, strDef)
        Else
            Dim FieldPath() As String = FieldName.Split(New Char() {"."})
            If Not MainForm.GetLayout.CXObjectLays(FieldPath(0)) Is Nothing AndAlso _
                Not MainForm.GetLayout.CXObjectLays(FieldPath(0)).Columns(FieldPath(1)) Is Nothing Then
                Return MainForm.GetLayout.CXObjectLays(FieldPath(0)).Columns(FieldPath(1)).FieldCaptionText
            Else
                Return strDef
            End If
        End If
    End Function


    Public Function SetControlText(ByVal ctl As Control, ByVal fieldName As String, Optional ByVal UseRes As Boolean = False)
        Dim strRes As String
        strRes = Trim(GetFieldCaption(fieldName, UseRes, ctl.Text))
        If strRes <> "" Then
            ctl.Text = strRes
        End If
    End Function

    'It only for customizeed form
    Public Sub SetFormResource(ByRef frm As System.Windows.Forms.Form)
        Dim strID As String
        Dim str As String
        strID = "ID_cap_" & frm.Name
        If Trim(frm.Text) <> "" Then
            str = Trim(PublicResource.LoadResString(strID, frm.Text))
            If str <> "" Then
                frm.Text = str
            End If
        End If
        SetResource(strID, frm.Controls)
    End Sub

    Private Sub SetResource(ByVal prefix As String, ByRef ctls As Control.ControlCollection)
        Dim ctl As Control
        For Each ctl In ctls

            If TypeOf ctl Is System.Windows.Forms.Label Or _
                TypeOf ctl Is System.Windows.Forms.CheckBox Or _
                TypeOf ctl Is System.Windows.Forms.Button Or _
                TypeOf ctl Is System.Windows.Forms.RadioButton Or _
                TypeOf ctl Is System.Windows.Forms.GroupBox Then
                SetTextResource(prefix, ctl)
                If ctl.Controls.Count > 0 Then
                    SetResource(prefix + "_" + ctl.Name, ctl.Controls)
                End If
            ElseIf TypeOf ctl Is System.Windows.Forms.TabControl Then
                SetTabControlResource(prefix, ctl)
            ElseIf TypeOf ctl Is System.Windows.Forms.DataGrid Then
                SetDataGridResource(prefix, ctl)
            ElseIf TypeOf ctl Is System.Windows.Forms.ListView Then
                SetListViewResource(prefix, ctl)
            End If

        Next
    End Sub

    Public Sub SetTextResource(ByVal prefix As String, ByRef ctl As Control)
        Dim str As String
        If Trim(ctl.Text) = "" Then
            Exit Sub
        End If
        str = Trim(PublicResource.LoadResString(prefix & "_" & ctl.Name, ctl.Text))
        If str <> "" Then
            ctl.Text = str
        End If
    End Sub

    Private Sub SetTabControlResource(ByVal prefix As String, ByRef tc As System.Windows.Forms.TabControl)
        Dim strID As String
        Dim str As String
        Dim ctl As TabPage
        prefix &= "_" & tc.Name
        For Each ctl In tc.TabPages
            strID = prefix & "_" & ctl.Name
            str = Trim(PublicResource.LoadResString(strID, ctl.Text))
            If str <> "" Then
                ctl.Text = str
            End If
            SetResource(strID, ctl.Controls)
        Next
    End Sub
    Private Sub SetListViewResource(ByVal prefix As String, ByRef lvw As System.Windows.Forms.ListView)
        Dim strID As String
        Dim i As Integer
        Dim str As String
        Exit Sub            '-----ListView不再处理资产， 因为ListView的Column没有名称，根据TEXT不是很好来处理（2010/03/09）。
        prefix &= "_" & lvw.Name
        For i = 0 To lvw.Columns.Count - 1
            strID = prefix & "_" & Replace(lvw.Columns(i).Text, " ", "_")
            str = Trim(PublicResource.LoadResString(strID, lvw.Columns(i).Text))
            If str <> "" Then
                lvw.Columns(i).Text = str
            End If
        Next
    End Sub

    Private Sub SetDataGridResource(ByVal prefix As String, ByRef dg As System.Windows.Forms.DataGrid)

        Dim strID As String
        Dim str As String
        Dim ctl As DataGridTableStyle
        prefix &= "_" & dg.Name
        For Each ctl In dg.TableStyles
            strID = prefix & "_" & ctl.MappingName
            Dim dcs As DataGridColumnStyle
            For Each dcs In ctl.GridColumnStyles
                str = Trim(PublicResource.LoadResString(strID & "_" & dcs.MappingName, dcs.HeaderText))
                If str <> "" Then
                    dcs.HeaderText = str
                End If
            Next
        Next
    End Sub

    Public Sub SetDetailsFormControlPosition(ByRef frm As System.Windows.Forms.Panel, ByVal Height As Integer)
        Dim ctl As Control
        For Each ctl In frm.Controls
            ctl.Top += Height
        Next
    End Sub
End Module