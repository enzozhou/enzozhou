Imports COMExpress.UserInterface.Layout

Module mControlHelper

	Public Function IsRootControl(ByVal ctl As Control) As Boolean
        If TypeOf ctl Is PropertyGrid Then Return True
        If TypeOf ctl Is YTUI.CXPropertyGrid Then Return True
        If TypeOf ctl Is YTUI.DataGrid Then Return True
    End Function
    
	
	Public Sub TextBoxFormatter( _
           ByVal EditControl As Control, _
           ByVal fFont As Font, _
           ByVal fBackColor As Color, _
           ByVal fForeColor As Color, _
           ByVal objfld As CXField)

        BaseControlFormatter(EditControl, fFont, fBackColor, fForeColor)
        With CType(EditControl, TextBox)
            If objfld.FieldMaxLen <> 0 Then .MaxLength = objfld.FieldMaxLen
            Select Case objfld.FieldControlAlign
                Case FieldControlAlignEnum.fcCenter
                    .TextAlign = HorizontalAlignment.Center
                Case FieldControlAlignEnum.fcLeft
                    .TextAlign = HorizontalAlignment.Left
                Case FieldControlAlignEnum.fcRight
                    .TextAlign = HorizontalAlignment.Right
            End Select
        End With
    End Sub
	
    Public Sub ReadOnlySupporter(ByVal EditControl As Control, ByVal Locked As Boolean)
        CallByName(EditControl, "ReadOnly", CallType.Let, Locked)
    End Sub
	
   	Public Sub GeneralControlFormatter( _
        ByVal EditControl As Control, _
        ByVal fFont As Font, _
        ByVal fBackColor As Color, _
        ByVal fForeColor As Color, _
        ByVal objfld as CXField)

        BaseControlFormatter(EditControl, fFont, fBackColor, fForeColor)
    End Sub
	
 	Public Sub ComboListBoxLoader(ByVal EditControl As Control, ByVal dv As DataView, Byval objFld as CXField)
        With CType(EditControl, ListControl)
            .DataSource = dv
            .DisplayMember = dv.Table.Columns(1).ColumnName
            .ValueMember = dv.Table.Columns(0).ColumnName
        End With
    End Sub
	
	Public Sub EnabledSupporter(ByVal EditControl As Control, ByVal Locked As Boolean)
		EditControl.Enabled = Not Locked
	End Sub
	
    Public Sub CheckBoxFormatter( _
        ByVal EditControl As Control, _
        ByVal fFont As Font, _
        ByVal fBackColor As Color, _
        ByVal fForeColor As Color, _
        ByVal objfld As CXField)

        BaseControlFormatter(EditControl, fFont, fBackColor, fForeColor)
        With CType(EditControl, CheckBox)
            Select Case objfld.FieldControlAlign
                Case FieldControlAlignEnum.fcCenter
                    .CheckAlign = ContentAlignment.MiddleCenter
                Case FieldControlAlignEnum.fcLeft
                    .CheckAlign = ContentAlignment.MiddleLeft
                Case FieldControlAlignEnum.fcRight
                    .CheckAlign = ContentAlignment.MiddleRight
            End Select
            .Text = objfld.FieldCaptionText
        End With
    End Sub
	
	Private Sub BaseControlFormatter( _
           ByVal EditControl As Control, _
           ByVal fFont As Font, _
           ByVal fBackColor As Color, _
           ByVal fForeColor As Color)
        With EditControl
            If Not fFont Is Nothing Then .Font = fFont
            If Not TypeOf EditControl Is CheckBox Then .BackColor = fBackColor
            .ForeColor = fForeColor
        End With
    End Sub

#region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Module
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
