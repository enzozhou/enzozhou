Imports COMExpress.BusinessObject
Imports COMExpress.BusinessObject.Filters
Imports System.Data
Imports System.Collections

Namespace BusinessObject
    Public Class SecurityManager
        Public Shared Function CheckSBRight(ByRef strRightNo As String) As Boolean
            If (UserRightMgr.GetRightNoDC(strRightNo) = False) Then
                Return False
            End If
            Return True
        End Function
        Public Shared Function CheckSBRight(ByVal strObjectName As String, ByVal sFuncType As String) As Boolean
            Select Case strObjectName
                Case Is = "clsdnhdr"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.DNHDRLIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.DNHDRNEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.DNHDREDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.DNHDRREMOVE)
                    End If
                Case Is = "clsdnlin"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.DNLISTLIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.DNLINNEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.DNLINEDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.DNLINREMOVE)
                    End If
                Case Is = "clsbchhdr"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.BACHHDRLIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.BACHHDRNEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.BACHHDREDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.BACHHDRREMOVE)
                    End If
                Case Is = "clsbchlin"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.BACHLINLIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.BACHLINNEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.BACHLINEDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.BACHLINREMOVE)
                    End If
                Case Is = "clstaskhdr"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.TASKHDRLIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.TASKHDRNEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.TASKHDREDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.TASKHDRREMOVE)
                    End If
                Case Is = "clstasklin"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.TASKLINLIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.TASKLINNEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.TASKLINEDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.TASKLINREMOVE)
                    End If
                Case Is = "clsDnBin"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.DNBINLIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.DNBINNEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.DNBINEDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.DNBINREMOVE)
                    End If
                Case Is = "clsbinStatus"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.BINSTATUSLIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.BINSTATUSNEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.BINSTATUSEDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.BINSTATUSREMOVE)
                    End If
                Case Is = "clsskuinfo"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.SKUINFOLIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.SKUINFONEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.SKUINFOEDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.SKUINFOREMOVE)
                    End If
                Case Is = "clsbin"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.BINLIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.BINNEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.BINEDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.BINREMOVE)
                    End If
                Case Is = "clsbinarea"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.BINAREALIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.BINAREANEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.BINAREAEDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.BINAREAREMOVE)
                    End If
                Case Is = "clscityairport"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.CTIYLIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.CTIYNEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.CTIYEDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.CTIYREMOVE)
                    End If
                Case Is = "clsOPERATOR"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.USERLIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.USERNEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.USEREDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.USERREMOVE)
                    End If
                Case Is = "clsPermission"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.PERMISSIONLIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.PERMISSIONNEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.PERMISSIONEDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.PERMISSIONREMOVE)
                    End If
                Case Is = "clsRole"
                    If (sFuncType = "LIST") Then
                        Return CheckSBRight(Rights.ROLELIST)
                    End If
                    If (sFuncType = "NEW") Then
                        Return CheckSBRight(Rights.ROLENEW)
                    End If
                    If (sFuncType = "EDIT") Then
                        Return CheckSBRight(Rights.ROLEEDIT)
                    End If
                    If (sFuncType = "REMOVE") Then
                        Return CheckSBRight(Rights.ROLEREMOVE)
                    End If
                Case Is = "capImpBin"
                    If (sFuncType = "LOAD") Then
                        Return CheckSBRight(Rights.BINLOAD)
                    End If
                Case Is = "capImpSKU"
                    If (sFuncType = "LOAD") Then
                        Return CheckSBRight(Rights.SKUINFOLOAD)
                    End If
                Case Is = "capImpDN"
                    If (sFuncType = "LOAD") Then
                        Return CheckSBRight(Rights.DNHDRLOAD)
                    End If
                Case Is = "impCity"
                    If (sFuncType = "LOAD") Then
                        Return CheckSBRight(Rights.CTIYLOAD)
                    End If
            End Select
            Return True
        End Function
    End Class
End Namespace

