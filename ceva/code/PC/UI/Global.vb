Imports COMExpress.Windows.Forms
Imports COMExpress.BusinessObject
Imports CSLA
Imports YT.BusinessObject
Imports System.Threading
Imports ImportExport
Imports COMExpress.BusinessObject.Filters

Module [Global]

    Private gMainform As frmMain
    Private gXMLSetting As XMLSetting

    Private DateFmt As String = ""
    Private mDebugVersion As Boolean = False
    Public ReadOnly Property DebugVersion() As Boolean
        Get
            Return mDebugVersion
        End Get
    End Property

    Public Sub DoUnHandlerException(ByVal sender As Object, ByVal args As ThreadExceptionEventArgs)
        Dim ex As Exception = DirectCast(args.Exception, Exception)
        'Console.WriteLine("MyHandler caught : " + e.Message)
        Dim Str As String
        Microsoft.VisualBasic.MsgBox("System Error, please see log :" + ex.Message, MsgBoxStyle.Critical)
        Str = "System Error:" + ex.Message + "(" + ex.GetType.Name + ")" + vbCrLf + ex.StackTrace
        COMExpress.BusinessObject.CXEventLog.LogToFile(Str, CXEventLog.LogTypeConstants.logUI)
        'Here we can exit the application if .........
        End
    End Sub



    Public Sub RemoveFilesInTempPath()
        Dim strPath As String
        Try
            strPath = System.IO.Path.GetTempPath
            RemoveFiles(strPath)

        Catch ex As Exception

        End Try
    End Sub


    Private Sub RemoveFiles(ByVal strPath As String)
        'Dim strFileName As String
        Dim strSys As String
        strPath = Replace(Trim(strPath), "\\", "\")
        Dim sb As New System.Text.StringBuilder
        If Len(Trim(strPath)) <= 3 Then
            Return
        End If
        If System.IO.Directory.Exists(strPath) = False Then
            Exit Sub
        End If
        If strPath.Substring(strPath.Length - 2) = ":\" Then
            Exit Sub
        End If
        If strPath.IndexOf("system") >= 0 Then
            Exit Sub
        End If
        'strSys = Space(1000)
        GetWindowsDirectory(sb, 1000)
        strSys = sb.ToString
        If Trim(strSys).Length > 0 And strPath.IndexOf(Trim(strSys)) >= 0 Then
            Exit Sub
        End If


        Dim FileAttr As System.IO.FileAttributes
        Dim FileDate As DateTime
        'strFileName = Dir(strPath + "\*.*", 63)
        Dim di As System.IO.DirectoryInfo
        Dim dirs() As System.IO.DirectoryInfo
        di = New System.IO.DirectoryInfo(strPath)
        dirs = di.GetDirectories("*.*")
        For Each diNext As System.IO.DirectoryInfo In dirs
            Try
                'If (diNext.Attributes And IO.FileAttributes.Directory) = IO.FileAttributes.Directory Then
                RemoveFiles(diNext.FullName)
                System.IO.Directory.Delete(diNext.FullName)
                'Else
                '    If diNext.CreationTime < Now.AddDays(-1) And diNext.LastAccessTime < Now.AddDays(-1) Then
                'System.IO.File.Delete(diNext.FullName)
                '    End If
                'End If

            Catch ex As Exception
            End Try
        Next
        Dim files() As System.IO.FileInfo
        files = di.GetFiles()
        For Each fiNext As System.IO.FileInfo In files
            Try
                If fiNext.CreationTime < Now.AddDays(-1) And fiNext.LastAccessTime < Now.AddDays(-1) Then
                    System.IO.File.Delete(fiNext.FullName)
                End If
            Catch ex As Exception
            End Try
        Next

    End Sub


    'Private Function CreateFolderSingle(ByVal strFolder As String) As Boolean
    '    Try
    '        If System.IO.Directory.Exists(strFolder) = False Then
    '            System.IO.Directory.CreateDirectory(strFolder)
    '        End If
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Private Function CreateFolder(ByVal strFolder As String) As Boolean
    '    If System.IO.Directory.Exists(strFolder) = True Then
    '        Return True
    '    End If
    '    Dim strUp As String
    '    Dim iPos As Integer
    '    iPos = strFolder.LastIndexOf("\")
    '    If iPos > 0 Then
    '        strUp = strFolder.Substring(0, iPos)
    '    End If
    '    If CreateFolder(strUp) = False Then
    '        Return False
    '    End If
    '    Return CreateFolderSingle(strFolder)
    'End Function

    'Public Function GetLogFilePath() As String
    '    Dim strPath As String
    '    Try
    '        strPath = COMExpress.Configuration.ConfigurationSettings.AppSettings("EventLogFilePath")
    '    Catch ex As Exception
    '        strPath = ""
    '    End Try
    '    If Trim(strPath) = "" Or System.IO.Directory.Exists(strPath) = False Then
    '        strPath = IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.GetModules()(0).FullyQualifiedName)
    '    End If
    '    strPath = strPath + "\Log"
    '    CreateFolder(strPath)
    '    Return strPath
    'End Function


    'Private Sub RemoveExpiredLogFile(ByVal LogFilePath As String, ByVal strMatchName As String, ByVal DealLine As DateTime)
    '    Dim strFileName As String
    '    Dim FileAttr As FileAttribute
    '    Dim FileDate As DateTime
    '    strFileName = Dir(LogFilePath + "\" + strMatchName)
    '    While Trim(strFileName) <> ""
    '        Try
    '            FileAttr = GetAttr(LogFilePath + "\" + strFileName)
    '            FileDate = FileDateTime(LogFilePath + "\" + strFileName)
    '            If (FileAttr And vbDirectory) = vbDirectory Then
    '                'Do nothing
    '            ElseIf FileDate < DealLine Then
    '                System.IO.File.Delete(LogFilePath + "\" + strFileName)
    '            End If
    '        Catch ex As Exception
    '        End Try
    '        strFileName = Dir()
    '    End While
    'End Sub

    'Public Sub RemoveExpiredLogFile()
    '    Dim LogFilePath As String
    '    Dim DealLine As DateTime
    '    On Error Resume Next
    '    DealLine = DateAdd(DateInterval.Month, -3, Now)
    '    LogFilePath = GetLogFilePath()
    '    RemoveExpiredLogFile(LogFilePath, "SYS*.log", DealLine)
    '    RemoveExpiredLogFile(LogFilePath, "BO*.log", DealLine)
    '    RemoveExpiredLogFile(LogFilePath, "UI*.log", DealLine)
    '    'For i = -100 To -80
    '    '    filePath = GetLogFilePath() + "\SYS" + Format(DateAdd(DateInterval.Day, i, Now), "yyyyMMdd") + ".log"
    '    '    System.IO.File.Delete(filePath)
    '    '    filePath = GetLogFilePath() + "\BO" + Format(DateAdd(DateInterval.Day, i, Now), "yyyyMMdd") + ".log"
    '    '    System.IO.File.Delete(filePath)
    '    '    filePath = GetLogFilePath() + "\UI" + Format(DateAdd(DateInterval.Day, i, Now), "yyyyMMdd") + ".log"
    '    '    System.IO.File.Delete(filePath)
    '    'Next
    'End Sub


    Public Sub Main()
        AddHandler Application.ThreadException, AddressOf DoUnHandlerException
        LoadXMLSetting()
#If DEBUG Then
        mDebugVersion = True
        CallTest()
#End If
        RemoveFilesInTempPath()

        ChangeCurrentDirectory("")

        RemoveOlderLogFiles()


        Dim frm As frmMain
        Try
            frm = New frmMain
            'frm.Show()
            frm.ShowDialog()
            frm.Dispose()
            frm = Nothing
        Catch ex As Exception
            Dim Str As String
            Microsoft.VisualBasic.MsgBox("System Error, please see log :" + ex.Message, MsgBoxStyle.Critical)
            Str = "System Error:" + ex.Message + "(" + ex.GetType.Name + ")" + vbCrLf + ex.StackTrace
            COMExpress.BusinessObject.CXEventLog.LogToFile(Str, CXEventLog.LogTypeConstants.logUI)
        End Try
        EndProgress()
    End Sub

    Public Sub EndProgress()
        SaveXMLSetting()
        Try
            GC.GetTotalMemory(True)
            GC.Collect()
        Catch ex As Exception
        End Try
        Thread.Sleep(100)
        ChangeCurrentDirectory("")
        UpgradeProgress()
    End Sub


    Private Function GetXMLSettingFile() As String
        Dim strApp As String
        Dim iPos As Integer
        strApp = Reflection.Assembly.GetExecutingAssembly.GetModules()(0).FullyQualifiedName
        iPos = strApp.LastIndexOf(".")
        If iPos > 0 Then
            strApp = strApp.Substring(0, iPos)
        End If
        Return strApp + ".xml"
    End Function

    Private Sub LoadXMLSetting()
        Dim strFile As String
        strFile = GetXMLSettingFile()
        gXMLSetting = New XMLSetting(strFile)
    End Sub
    Private Sub SaveXMLSetting()
        On Error Resume Next
        If Not gXMLSetting Is Nothing Then
            gXMLSetting.Save()
        End If

    End Sub

    Public ReadOnly Property XMLSet() As XMLSetting
        Get
            Return gXMLSetting
        End Get
    End Property

    Public ReadOnly Property MainForm() As frmMain
        Get
            Return gMainform
        End Get
    End Property

    Public Sub InitializeApp(ByVal mainForm As frmMain)
        gMainform = mainForm
    End Sub

    'Public Function CustomMsgBox(ByVal strMessage As String, ByVal buttons As MsgBoxStyle, Optional ByVal MultiLine As Boolean = True) As MsgBoxResult
    '    Try
    '        Dim frm As New frmShowMessage
    '        Dim rst As DialogResult
    '        frm.Message = strMessage
    '        frm.Buttons = buttons
    '        frm.Title = MainForm.MainFormTitle
    '        frm.Icon = MainForm.Icon
    '        frm.MultiLine = MultiLine
    '        rst = frm.ShowDialog(MainForm)
    '        frm.Dispose()
    '        frm = Nothing
    '        Return rst
    '    Catch ex As Exception
    '        Return MsgBoxResult.Abort
    '    End Try
    'End Function

    Public Sub LogMsg(ByVal e As Exception, ByVal ErrorModule As Type, ByVal ErrorRoutine As String)
        Dim str As String
        Dim strMessage As String
        str = ExceptionParser.ParseExcetionMessageForLog(e)
        str = "System Error(" & ErrorModule.Name & "/" & ErrorRoutine & "):" & vbCrLf & str  '+ vbCrLf + e.Message + "(" + e.GetType.Name + ")" + vbCrLf + e.StackTrace
        COMExpress.BusinessObject.CXEventLog.LogToFile(str, CXEventLog.LogTypeConstants.logUI)
    End Sub


    Public Sub ErrorMsg(ByVal e As Exception, ByVal ErrorModule As Type, ByVal ErrorRoutine As String)
        Dim str As String
        'Dim strMessage As String
        str = ExceptionParser.ParseExcetionMessage(e, 30)

        'strMessage = str
        'COMExpress.BusinessObject.CXEventLog.ErrorLogString(
        ErrMsg(str, False)
        str = ExceptionParser.ParseExcetionMessageForLog(e)
        str = "System Error:" + str '+ vbCrLf + e.Message + "(" + e.GetType.Name + ")" + vbCrLf + e.StackTrace
        COMExpress.BusinessObject.CXEventLog.LogToFile(str, CXEventLog.LogTypeConstants.logUI)
    End Sub
    Public Sub ErrMsg(ByVal msg_name As String, Optional ByVal loadfromRes As Boolean = True, Optional ByVal strDef As String = "") '2007-7-26 modify by wj
        If loadfromRes Then
            MsgBox(PublicResource.LoadResString(msg_name, strDef), MsgBoxStyle.Exclamation)
            'CustomMsgBox(mStringResMgr.GetString(msg_name), MsgBoxStyle.Exclamation, MultiLine)
        Else
            MsgBox(msg_name, MsgBoxStyle.Exclamation)
            'CustomMsgBox(msg_name, MsgBoxStyle.Exclamation)
        End If
    End Sub

    Public Function QuestionMsg(ByVal msg_name As String, Optional ByVal loadfromRes As Boolean = True, Optional ByVal strDef As String = "") As MsgBoxResult
        If loadfromRes Then
            Return MsgBox(PublicResource.LoadResString(msg_name, strDef), MsgBoxStyle.YesNo + MsgBoxStyle.Question)
            'Return CustomMsgBox(mStringResMgr.GetString(msg_name), MsgBoxStyle.YesNo + MsgBoxStyle.Question)
        Else
            Return MsgBox(msg_name, MsgBoxStyle.YesNo + MsgBoxStyle.Question)
        End If
    End Function


    Public Function WarnningMsg(ByVal msg_name As String, Optional ByVal loadfromRes As Boolean = True, Optional ByVal strDef As String = "") As MsgBoxResult '2007-7-26 modify by wj
        If loadfromRes Then
            Return MsgBox(PublicResource.LoadResString(msg_name, strDef), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
        Else
            Return MsgBox(msg_name, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)
        End If
    End Function


    Public Sub Message(ByVal msg_name As String, Optional ByVal loadfromRes As Boolean = True, Optional ByVal strDef As String = "")
        If loadfromRes Then
            MsgBox(PublicResource.LoadResString(msg_name, strDef), MsgBoxStyle.Information)
            'CustomMsgBox(mStringResMgr.GetString(msg_name), MsgBoxStyle.Information)
        Else
            'CustomMsgBox(msg_name, MsgBoxStyle.Information)
            MsgBox(msg_name, MsgBoxStyle.Information)
        End If
    End Sub
    Public Sub MmsgBox(ByVal msg_name As String, ByVal buttons As MsgBoxStyle, Optional ByVal loadfromRes As Boolean = True, Optional ByVal strDef As String = "")
        If loadfromRes Then
            MsgBox(PublicResource.LoadResString(msg_name, strDef), buttons)
            'CustomMsgBox(mStringResMgr.GetString(msg_name), MsgBoxStyle.Information)
        Else
            'CustomMsgBox(msg_name, MsgBoxStyle.Information)
            MsgBox(msg_name, buttons)
        End If
    End Sub
    Public Sub Status(Optional ByVal Msg As String = "Ready", Optional ByVal PanelIndex As Integer = 0)
        CType(gMainform, IWindowsAppManager).StatusBarService.Status(Msg, PanelIndex)
    End Sub


    'Public Function CustomMsgBox(ByVal strMessage As String, ByVal buttons As MsgBoxStyle, Optional ByVal MultiLine As Boolean = True) As MsgBoxResult
    '    Try
    '        Dim frm As New frmShowMessage
    '        Dim rst As DialogResult
    '        frm.Message = strMessage
    '        frm.Buttons = buttons
    '        frm.Title = MainForm.MainFormTitle
    '        frm.Icon = MainForm.Icon
    '        frm.MultiLine = MultiLine
    '        SetModalFormStyle(frm)
    '        rst = frm.ShowDialog(MainForm)
    '        frm.Dispose()
    '        frm = Nothing
    '        Return rst
    '    Catch ex As Exception
    '        Return MsgBoxResult.Abort
    '    End Try
    'End Function


    'Public Function GetDCName(ByVal dc_code As String) As String
    '    Dim dc As clsregiondc
    '    Try
    '        dc = clsregiondc.Load(dc_code)
    '        Return dc.dc_name
    '    Catch ex As Exception
    '        Return ""
    '    End Try
    'End Function

    Public Function GetDCCodeFromConfiguration() As String
        Return Trim(COMExpress.Configuration.ConfigurationSettings.AppSettings.Item("RegionDC"))
    End Function

    Public Function GetSystemTypeOption() As String
        Dim obj As New clsOption
        Dim str As String = ""
        Try
            'str = Trim(clsOption.GetGlobalOption(clsOption.eOptGroup.SystemOption, clsOption.eSystemOption_OptCode.SystemType))
            'If str <> "" Then
            '    str = "[" + str + "]"
            'End If
            Return str
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function GetConDateFmt(Optional ByVal convertFlag As Boolean = True) As String
        'If DateFmt = "" Then
        '    ' DateFmt = New clsOption().GetOption(clsOption.eOptGroup.SystemOption, clsOption.eOptCode_SystemOption.DateFormat)
        '    DateFmt = clsOption.GetGlobalOption(clsOption.eOptGroup.SystemOption, clsOption.eSystemOption_OptCode.DateFormat)
        'End If
        'If convertFlag Then
        '    Return DateFmt.Replace("\/", "/")
        'Else
        '    Return DateFmt
        'End If
        Return "yyyy-MM-dd"
    End Function

    Public Sub SetModalFormStyle(ByVal frm As Form)
        frm.ShowInTaskbar = False
        frm.MaximizeBox = False
        frm.MinimizeBox = False
        frm.StartPosition = FormStartPosition.CenterScreen
        frm.FormBorderStyle = FormBorderStyle.FixedDialog
    End Sub


    Public Function GetCurrentVersion() As String
        Dim ver As System.Version
        Dim str As String
        ver = System.Reflection.Assembly.GetExecutingAssembly.GetName.Version()
        'str = ver.Major.ToString + "." + ver.Minor.ToString + "." + Format(ver.Build, "00") + "." + Format(ver.Revision, "000")
        str = ver.ToString
        Return str
    End Function



    Public Function MakeFilters(ByVal ColumnName As String, ByVal value As String, Optional ByVal [operator] As Filters.ConditionOperator = ConditionOperator.Equal) As CXSQLFilter
        Dim filter As New CXSQLFilter([operator], ColumnName, value)
        filter.ColumnName = ColumnName
        filter.ColumnNameIncludeTableName = True
        ' filter.IsDateType = False
        filter.[Operator] = [operator]
        'filter.Value1 = value
        Return filter
    End Function

    Public Function DateFormat(Optional ByVal convertFlag As Boolean = True) As String
        Try
            Return GetConDateFmt()
        Catch ex As Exception
            Return "Short date"
        End Try
    End Function

    Public Function DateTimeFormat(Optional ByVal convertFlag As Boolean = True) As String
        Try
            Return GetConDateFmt() & " HH:mm:ss"
        Catch ex As Exception
            Return "Short date"
        End Try
    End Function

    Public Function GetFirstString(ByVal str As String, ByVal int As Integer) As String
        Dim strarray As String()
        Try
            strarray = str.Split("|")
            str = strarray(int).Trim
            Return str
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Public Function IsMatchedWithList(ByRef cboDataCombo As ComboBox) As Boolean
        Return True
        Dim dv As DataView
        Dim strKeyValue As String
        Dim i As Integer
        Dim strText As String
        Dim bIsMatched As Boolean
        bIsMatched = False
        If TypeOf cboDataCombo.DataSource Is DataSet Then
            dv = DirectCast(cboDataCombo.DataSource, DataSet).Tables(0).DefaultView
        Else
            dv = DirectCast(cboDataCombo.DataSource, DataView)
        End If
        If Len(cboDataCombo.Text) > 0 Then
            For i = 0 To dv.Count - 1
                strText = dv.Item(i).Item(1).Value
                If InStr(1, LCase(strText), LCase(cboDataCombo.Text), vbTextCompare) = 1 Then
                    If LCase(strText) = LCase(cboDataCombo.Text) Then
                        'If identical, set the value to combobox and return success here
                        strKeyValue = CStr(dv.Item(i).Item(0).Value)
                        cboDataCombo.SelectedValue = strKeyValue
                        Return True
                        'Otherwise it is ONLY a partially match, input it into the key value buffer
                    ElseIf Len(strKeyValue) = 0 Then
                        strKeyValue = CStr(dv.Item(i).Item(0).Value)
                        bIsMatched = True
                    End If
                End If
            Next
            'If the loop is ended without jump to Done_isMatchedWithList
            'Means there's only partial match found.
            'Set the value of the combo box by the key buffer value here
            If bIsMatched Then
                cboDataCombo.SelectedValue = strKeyValue
                Return True
            End If

        End If
        cboDataCombo.Text = vbNullString
        cboDataCombo.SelectedValue = vbNullString
        Return True

    End Function

    Public Sub ChangeCurrentDirectory(ByVal strPath As String)
        Try
            If Trim(strPath) = "" Then
                strPath = System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0).FullyQualifiedName()
                strPath = IO.Path.GetDirectoryName(strPath)
            Else
                strPath = IO.Path.GetFullPath(strPath)
            End If
            ChDrive(strPath.Substring(0, 1))
            ChDir(strPath)
        Catch ex As Exception
        End Try
    End Sub

    Declare Auto Function GetWindowsDirectory Lib "Kernel32" (ByVal lpBuffer As System.Text.StringBuilder, ByVal uSize As Integer) As Integer

    Declare Unicode Function ShellExecute Lib "shell32" Alias "ShellExecuteW" (ByVal hWnd As Integer, ByVal strOpen As String, ByVal strFile As String, ByVal strParam As String, ByVal strDirectory As String, ByVal iShow As Integer) As Integer

    Public Sub UpgradeProgress()
        Dim sFullPath As String
        Try

            sFullPath = System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0).FullyQualifiedName()
            sFullPath = IO.Path.GetDirectoryName(sFullPath)
            sFullPath = UCase(sFullPath)
            'If sFullPath.IndexOf(UCase("bin")) > 0 Then
            '    Exit Sub
            'End If
            'If sFullPath.IndexOf(UCase("release")) > 0 Then
            '    Exit Sub
            'End If
            ChDir(sFullPath)
            sFullPath = sFullPath + "\upgrade.bat"
            ShellExecute(0, "open", sFullPath, "", "", 1)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub RestartProgram()
        Dim strFile As String
        strFile = System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0).FullyQualifiedName()
        ShellExecute(0, "open", strFile, "", "", 1)
        End
    End Sub


    Public Function ReportCommandTimeout() As Integer
        Dim iTimeout As Integer
        Try 'CommandTimeout
            iTimeout = CInt(COMExpress.Configuration.ConfigurationSettings.AppSettings("ReportCommandTimeout"))
            If iTimeout < 15 * 60 Then
                iTimeout = 15 * 60
            End If
            Return iTimeout
        Catch ex As Exception
            Return 15 * 60
        End Try
    End Function




    Public Sub RemoveOlderLogFiles()
        On Error Resume Next
        Dim strFile As String
        Dim sFullPath As String
        Dim strFiles As String()
        sFullPath = System.Reflection.Assembly.GetExecutingAssembly.GetModules()(0).FullyQualifiedName()
        sFullPath = IO.Path.GetDirectoryName(sFullPath)
        sFullPath = UCase(sFullPath)
        strFiles = System.IO.Directory.GetFiles(sFullPath + "\log", "*.log")
        For Each strFile In strFiles
            If System.IO.File.GetLastWriteTime(strFile) < DateAdd(DateInterval.Day, -30, Now) Then
                System.IO.File.Delete(strFile)
            End If
        Next
    End Sub

    Public Function GetSysTimeCutOff() As Integer
        Dim str As String
        Try
            str = clsOption.GetOptionALL("SYS", "timecutoff", "default")
            Return CInt(str)
        Catch ex As Exception
            Return 8
        End Try
    End Function

    Public Function GetString(ByVal sString As String, ByVal nNo As Integer, ByVal Segregator As String) As String
        Dim vResult As String()
        If nNo <= 0 Then
            GetString = ""
            Exit Function
        End If
        vResult = Split(sString, Segregator)
        If nNo - 1 > UBound(vResult) Then
            GetString = ""
        Else
            GetString = vResult(nNo - 1)
        End If
    End Function

    '---------------------------added by Jim fang 2008-04-09----start--
    Public Function IsExistedPath(ByVal filePath As String) As Boolean
        If Not System.IO.Directory.Exists(filePath) Then
            Message("ID_msg_Global_PathNotExistPlsPutEnterFilePatch", True, "该路径不存在，请输入正确的文件路径")
            Return False
        End If
        Return True
    End Function

    'Added by Liu 2009-04-15 start
    Public Sub WritePrintTranslog(ByVal dc_code As String, ByVal doc_no As String, ByVal iNum As Integer, ByVal sku_no As String, ByVal ref_no As String, ByVal status_code As String)
        'Dim sl As clstranslog
        'Dim i As Integer
        'Try
        '    sl = sl.Newclstranslog
        '    sl.dc_code = dc_code
        '    sl.trans_type = "PRN"                                           '打印
        '    sl.cmd_type = "108"                                             '报表
        '    sl.doc_no = doc_no                                              '单号
        '    sl.qty = iNum                                                   '打印次数
        '    sl.opt_by = UserRightMgr.gUserCode
        '    'sl.opt_dtime = dTime
        '    sl.sku_no = sku_no
        '    sl.ref_no = ref_no
        '    sl.status_code = status_code
        '    sl.Save()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub


    Public Sub CallTest()

    End Sub


    Public Sub FreeSystemCache(ByVal vType As Type, ByVal vModule As String)
        Try
            clsMiscManager.FreeSystemCache()
        Catch ex As Exception
            LogMsg(ex, vType, vModule)
        End Try
    End Sub

#Region " Your custom code section{BA18CE3E-E986-4941-8BD9-4B959799F3CE}"
    'This section will not be overwritten during a round-trip code generation
#End Region
End Module
#region " Your custom code section{67DE6B32-F9AE-4b19-B6B8-26FE2B6985D4}"
    'This section will not be overwritten during a round-trip code generation
#End Region
