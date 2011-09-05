
Imports System.Threading
Imports System.Windows.Forms
Namespace BusinessObject
    Public Class RemoteFileSystem
        Public Const INVALID_HANDLE = -1
        Public Const GENERIC_READ = &H80000000
        Public Const GENERIC_WRITE = &H40000000  '(1073741824)
        Public Const FILE_SHARE_READ = 1
        Public Const FILE_SHARE_WRITE = 2
        Public Const CREATE_ALWAYS = 2
        Public Const OPEN_EXISTING = 3
        Public Const INIT_SUCCESS = 0
        Public Const WRITE_ERROR = 0
        Public Const READ_ERROR = 0

        Public Const ERROR_NO_MORE_FILES As Integer = 18
        Public Const INVALID_HANDLE_VALUE As Int16 = -1
        Public Const FILE_ATTRIBUTE_NORMAL As Int16 = &H80

        Public Delegate Sub ShowCompletedSizeHandler(ByVal percent As Single)
        Public Event GetCompletedSize As ShowCompletedSizeHandler

        Public Function GetDeviceFreeSpace() As Integer
            Dim si As New RemoteCe.STORE_INFORMATION
            RemoteCe.RAPI.CeGetStoreInformation(si)
            Return si.dwFreeSize
        End Function

        Public Function CopyFileToPocketPC(ByVal sSourceFile As String, ByVal sDestFile As String) As Boolean

            'this could relatively easily be re-written to read buffered chunks of a file
            'and make consecutive writes to the device, or even just set up a huge buffer
            'capable of reading any size file, and do the whole write at once.

            'Set up the binary buffer to read the file from the PC
            Dim intRetVal As Integer
            Dim lngSrcHandle As Integer
            Dim lngDestHandle As Integer
            Dim lngNumBytesWritten As Integer
            Dim FileName As String
            Dim typFindFileData As New RemoteCe.CE_FIND_DATA
            Dim lngFileSize As Integer
            Dim lngFS As Integer
            Dim lngBlockSize As Integer
            Dim bytBuffer() As Byte
            Dim tmpLocation As Integer


            lngBlockSize = 20480           ' read buffer size is about 20K
            'ReDim bytBuffer(lngBlockSize)
            ReDim bytBuffer(lngBlockSize - 1)

            On Error GoTo ErrHandler

            'locate the file, and see if it already exists on the device
            lngSrcHandle = RemoteCe.RAPI.CeFindFirstFile(sDestFile, typFindFileData.GetData)

            'if we get -1 then the file wasn't found so we can go ahead and create it
            'otherwise we dont want to overwrite in this demo, so we will cancel the operation.

            If lngSrcHandle <> INVALID_HANDLE Then
                'WriteLog sDesFile & " already exist!"
                RemoteCe.RAPI.CeFindClose(lngSrcHandle)
                'CopyFileToPocketPC = False
                'Exit Function
            End If

            'create the file on the device, and return the handle to the file
            FileName = sDestFile
            lngDestHandle = RemoteCe.RAPI.CeCreateFile(FileName, GENERIC_WRITE, FILE_SHARE_READ, vbNullString, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0)


            'if something went wrong in CeCreateFile we will get -1, and therefore need to abort
            If lngDestHandle = INVALID_HANDLE Then
                'WriteLog CeGetLastError
                CopyFileToPocketPC = False
                Exit Function
            End If

            lngFileSize = FileLen(sSourceFile)
            If lngFileSize > GetDeviceFreeSpace() Then
                CopyFileToPocketPC = False
                Exit Function
            End If
            lngSrcHandle = FreeFile()

            FileOpen(lngSrcHandle, sSourceFile, OpenMode.Binary, OpenAccess.Read)


            tmpLocation = 0
            'lTotalByte = 0

            Do While Not EOF(lngSrcHandle)
                'Get #lngSrcHandle, 1 + lTotalByte, bytBuffer
                RaiseEvent GetCompletedSize(0)      '2007-8-16 by wj
                If tmpLocation + lngBlockSize <= lngFileSize Then
                    FileGet(lngSrcHandle, bytBuffer, 1 + tmpLocation)

                    'If Not EOF(lngSrcHandle) Then
                    'Write contents of Binary buffer to CE file.
                    'Return value of 0 = failure, non zero = success
                    intRetVal = RemoteCe.RAPI.CeWriteFile(lngDestHandle, bytBuffer, lngBlockSize, lngNumBytesWritten, 0)
                    If intRetVal = WRITE_ERROR Then
                        GoTo ErrHandler
                    End If
                Else
                    ReDim bytBuffer(lngFileSize - tmpLocation - 1)
                    FileGet(lngSrcHandle, bytBuffer, 1 + tmpLocation)
                    'Write the reminder contents of Binary buffer to CE file.
                    'Return value of 0 = failure, non zero = success
                    lngBlockSize = lngFileSize Mod lngBlockSize
                    intRetVal = RemoteCe.RAPI.CeWriteFile(lngDestHandle, bytBuffer, lngBlockSize, lngNumBytesWritten, 0)
                    If intRetVal = WRITE_ERROR Then
                        GoTo ErrHandler
                    End If
                End If

                'lTotalByte = lTotalByte + lngNumBytesWritten
                tmpLocation = tmpLocation + lngNumBytesWritten
                RaiseEvent GetCompletedSize(tmpLocation / lngFileSize)  '2007-8-16 by wj
                'glngTotalTransferedBytes = glngTotalTransferedBytes + lngNumBytesWritten
                Application.DoEvents()
            Loop

            'RaiseEvent GetCompletedSize(1)
            RemoteCe.RAPI.CeCloseHandle(lngDestHandle)
            FileClose(lngSrcHandle)

            CopyFileToPocketPC = True

            Exit Function

ErrHandler:

            'MsgBox "Error " & CeGetLastError & " Occurred When Copying File " & _
            'sSourceFile & " To The Device as " & sDesFile, vbCritical + vbOKOnly
            'WriteLog CeGetLastError
            If lngDestHandle Or lngDestHandle <> INVALID_HANDLE Then
                RemoteCe.RAPI.CeCloseHandle(lngDestHandle)
            End If
            If lngSrcHandle Or lngSrcHandle <> INVALID_HANDLE Then
                FileClose(lngSrcHandle)
            End If

            CopyFileToPocketPC = False

        End Function

        Public Function IsConnectReady()
            Dim i As Integer
            Dim lngSrcHandle As Integer
            Dim typFindFileData As New RemoteCe.CE_FIND_DATA
            lngSrcHandle = INVALID_HANDLE
            For i = 0 To 10
                On Error Resume Next
                lngSrcHandle = RemoteCe.RAPI.CeFindFirstFile("\Windows", typFindFileData.GetData)
                On Error GoTo 0
                If lngSrcHandle <> INVALID_HANDLE Then
                    RemoteCe.RAPI.CeFindClose(lngSrcHandle)
                    Return True
                Else
                    Thread.Sleep(50)
                End If
            Next
            Return False
        End Function


        Public Function CopyFileFromPocketPC(ByVal sSourceFile As String, ByVal sDesFile As String) As Boolean

            Dim intRetVal As Integer
            Dim lngFileHandle As Integer
            Dim lngBytesRead As Integer
            Dim typFindFileData As New RemoteCe.CE_FIND_DATA
            Dim bytBuffer() As Byte

            Dim intFreeFileID As Integer

            Dim intWriteLoop As Integer
            Dim lngFS As Integer
            Dim lngBlockSize As Integer
            Dim lngWritedBytes As Integer

            lngBytesRead = 1
            lngBlockSize = 20480           ' read buffer size is about 20K
            ReDim bytBuffer(lngBlockSize)

            Try
                Kill(sDesFile)
            Catch ex As Exception
            End Try

            Try
                'locate the file, and see if it already exists on the device
                Application.DoEvents()
                lngFileHandle = RemoteCe.RAPI.CeFindFirstFile(sSourceFile, typFindFileData.GetData)

                If lngFileHandle = INVALID_HANDLE Then
                    'MsgBox "File " & sSourceFile & " Not Found. Operation Aborted.", vbOKOnly
                    'WriteLog "File " & sSourceFile & " Not Found. Operation Aborted."
                    CopyFileFromPocketPC = False
                    Exit Function
                End If

                'we dont need this handle now that we know the file is there
                RemoteCe.RAPI.CeFindClose(lngFileHandle)

                'i know it seems odd to have to call a function called CreateFile to read a file
                'but what it really refers to is create me a handle to a file of this type.
                lngFileHandle = RemoteCe.RAPI.CeCreateFile(sSourceFile, GENERIC_READ, FILE_SHARE_READ, vbNullString, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, 0)

                If lngFileHandle = INVALID_HANDLE Then
                    'MsgBox "Failed to open file " & sSourceFile
                    'WriteLog "Can not copy file " & sSourceFile
                    CopyFileFromPocketPC = False
                    Exit Function
                End If

                lngFS = RemoteCe.RAPI.CeGetFileSize(lngFileHandle, 0)
                ' if the file is empty, exit function
                If lngFS = 0 Then
                    RemoteCe.RAPI.CeCloseHandle(lngFileHandle)
                    CopyFileFromPocketPC = True

                    Exit Function
                End If

                ReDim bytBuffer(lngBlockSize)
                intRetVal = RemoteCe.RAPI.CeReadFile(lngFileHandle, bytBuffer, lngBlockSize, lngBytesRead, 0)

                'if we got a 0 return value from readfile then there is an error
                'so pass it to the error handler
                If intRetVal = READ_ERROR Then
                    RemoteCe.RAPI.CeCloseHandle(lngFileHandle)
                    CopyFileFromPocketPC = False
                    Exit Try
                End If

                intFreeFileID = FreeFile()
                FileOpen(intFreeFileID, sDesFile, OpenMode.Binary, OpenAccess.Write) ' For Binary As #intFreeFileID


                lngWritedBytes = 1
                While Not intRetVal And lngBytesRead <> 0           ' reach the end of file
                    RaiseEvent GetCompletedSize(0)
                    If lngBytesRead < lngBlockSize Then             ' last copy
                        For intWriteLoop = 0 To lngBytesRead - 1
                            FilePut(intFreeFileID, bytBuffer(intWriteLoop), lngWritedBytes)
                            lngWritedBytes = lngWritedBytes + 1
                            'lTotalByte = lTotalByte + 1
                            'glngTotalTransferedBytes = glngTotalTransferedBytes + 1
                            Application.DoEvents()
                        Next intWriteLoop
                    Else
                        FilePut(intFreeFileID, bytBuffer, lngWritedBytes)
                        lngWritedBytes = lngWritedBytes + lngBytesRead
                        'lTotalByte = lTotalByte + lngBytesRead
                        'glngTotalTransferedBytes = glngTotalTransferedBytes + lngBytesRead
                        Application.DoEvents()
                    End If
                    'For intWriteLoop = 0 To lngBytesRead - 1
                    'Next intWriteLoop

                    intRetVal = RemoteCe.RAPI.CeReadFile(lngFileHandle, bytBuffer, lngBlockSize, lngBytesRead, 0)
                    RaiseEvent GetCompletedSize(lngWritedBytes / lngFS)
                End While

                FileClose(intFreeFileID)

                RemoteCe.RAPI.CeCloseHandle(lngFileHandle)
                CopyFileFromPocketPC = True

                Exit Function

            Catch ex As Exception
                'MsgBox "Error " & CeGetLastError & " Occurred When Copying File " & _
                'sSourceFile & " From The Device as " & sDesFile, vbCritical + vbOKOnly
                'WriteLog "Error " & CeGetLastError & " Occurred When Copying File " & _
                'sSourceFile & " From The Device as " & sDesFile
                CopyFileFromPocketPC = False
            End Try
        End Function

        Function ReadFileAsBinary(ByVal strSrcFilename As String, ByVal lngFileSize As Integer, ByVal bytBuffer() As Byte) As Boolean

            Dim intFileHandle As Integer
            Dim intSeekPos As Integer
            Dim intRetVal As Integer = 0
            'On Error GoTo ErrHandler

            lngFileSize = FileLen(strSrcFilename)

            intFileHandle = FreeFile()

            FileOpen(intFileHandle, strSrcFilename, OpenMode.Binary, OpenAccess.Read)  ' For Binary As intFileHandle

            For intSeekPos = 1 To lngFileSize
                FileGet(intFileHandle, bytBuffer(intSeekPos - 1), intSeekPos)
                'lTotalByte = lTotalByte + 1
                Application.DoEvents()
            Next intSeekPos

            FileClose(intFileHandle)

            ReadFileAsBinary = True

            Exit Function

ErrHandler:

            'MsgBox("Error reading file " & strSrcFilename, vbCritical & vbOKOnly)

            ReadFileAsBinary = False

        End Function

        Public Function CheckFileInPocketPC(ByVal sFile As String) As Boolean
            On Error GoTo errorhanlder
            Dim lngFileHandle As Integer
            Dim intRetVal As Integer
            Dim typFindFileData As New RemoteCe.CE_FIND_DATA
            CheckFileInPocketPC = False
            'locate the file, and see if it already exists on the device
            lngFileHandle = RemoteCe.RAPI.CeFindFirstFile(sFile, typFindFileData.GetData)

            If lngFileHandle = INVALID_HANDLE Then
                CheckFileInPocketPC = False
            Else
                CheckFileInPocketPC = True
            End If
            RemoteCe.RAPI.CeFindClose(lngFileHandle)
            Exit Function
errorhanlder:
            On Error Resume Next
            RemoteCe.RAPI.CeFindClose(lngFileHandle)
            CheckFileInPocketPC = False
        End Function

        Public Function DeleteCEFile(ByVal sFile As String) As Boolean
            On Error GoTo errorhanlder
            Dim lngFileHandle As Integer
            Dim intRetVal As Integer
            If CheckFileInPocketPC(sFile) Then
                lngFileHandle = RemoteCe.RAPI.CeDeleteFile(sFile)
                If lngFileHandle = INVALID_HANDLE Then
                    DeleteCEFile = False
                Else
                    DeleteCEFile = True
                End If
            Else  'not found
                DeleteCEFile = True
            End If
            Exit Function
errorhanlder:
            DeleteCEFile = False
        End Function

        Public Function CeInit() As Boolean
            Dim tmpRapiInit As New RemoteCe.RAPI.RAPIINIT
            Dim intRetVal As Integer
            RemoteCe.RAPI.CeRapiUninit()
            tmpRapiInit.cbSize = Len(tmpRapiInit)
            intRetVal = RemoteCe.RAPI.CeRapiInitEx(tmpRapiInit)
            Application.DoEvents()
            If intRetVal <> INIT_SUCCESS Then
                RemoteCe.RAPI.CeRapiUninit()
                CeInit = False
            Else
                CeInit = True
            End If
            Thread.Sleep(1000)
        End Function

        Public Sub CeUnInit()
            RemoteCe.RAPI.CeRapiUninit()
        End Sub

        Public Function CreateHHTFile(ByVal filepath As String) As Boolean
            'Dim intRetVal As Integer
            Dim lngSrcHandle As Integer
            Dim lngDestHandle As Integer
            Dim typFindFileData As New RemoteCe.CE_FIND_DATA

            lngSrcHandle = RemoteCe.RAPI.CeFindFirstFile(filepath, typFindFileData.GetData)

            'if we get -1 then the file wasn't found so we can go ahead and create it
            'otherwise we dont want to overwrite in this demo, so we will cancel the operation.

            If lngSrcHandle <> INVALID_HANDLE Then
                'WriteLog sDesFile & " already exist!"
                RemoteCe.RAPI.CeFindClose(lngSrcHandle)
                'CopyFileToPocketPC = False
                'Exit Function
            End If

            'create the file on the device, and return the handle to the file
            lngDestHandle = RemoteCe.RAPI.CeCreateFile(filepath, GENERIC_WRITE, FILE_SHARE_READ, vbNullString, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL, 0)

            If lngDestHandle Or lngDestHandle <> INVALID_HANDLE Then
                RemoteCe.RAPI.CeCloseHandle(lngDestHandle)
            End If

        End Function
    End Class

End Namespace
