Imports System
Public Class SymbolScancer
    ''' <summary>
    ''' 就绪状态，接受任何时刻扫描近来的条码:
    ''' 这里调用一个委托使用的全局函数，用于获取所有当前程序下的扫描条码数据.
    ''' </summary>
    ''' <param name="TheReaderData"></param>
    ''' <remarks></remarks>
    Private Sub HandleData(ByVal TheReaderData As Symbol.Barcode.ReaderData)
        gf_del_CheckBarcode(TheReaderData.Text)
    End Sub
#Region " 下面是例程区域,所有带有扫描功能的窗口都可以拷贝这里的代码段 "
    Dim audiook As Boolean
    Private MyAudioController As Symbol.Audio.Controller = Nothing
    Private MyReader As Symbol.Barcode.Reader = Nothing
    Private MyReaderData As Symbol.Barcode.ReaderData = Nothing
    Private MyEventHandler As System.EventHandler = Nothing
    Private MyAutdioDevice As Symbol.Audio.Device = Nothing
    Private Frequency As Integer = 2870 'hz 声音的频率
    '------------------------------------------------------------------------------------
    ''' <summary>
    ''' 默认：初始化扫描器对象
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StartScan()
        'MyBase.New() '显示的调用基类代码：在这里没有什么用
        Try
            MyAutdioDevice = Symbol.StandardForms.SelectDevice.Select( _
                                                            Symbol.Audio.Controller.Title, _
                                                            Symbol.Audio.Device.AvailableDevices)
            audiook = True
            If (MyAutdioDevice Is Nothing) Then
                MessageBox.Show("No Autdio Device Selected", "SelectDevice")
                Return
            End If
            'check the device type
            Select Case (MyAutdioDevice.AudioType)
                Case Symbol.Audio.AudioType.StandardAudio
                    MyAudioController = New Symbol.Audio.StandardAudio(MyAutdioDevice)
                Case Symbol.Audio.AudioType.SimulatedAudio
                    MyAudioController = New Symbol.Audio.SimulatedAudio(MyAutdioDevice)
                Case Else
                    Throw New Symbol.Exceptions.InvalidDataTypeException("Unknown Device Type")
            End Select
            'If we can initialize the Reader
            If (Me.InitReader()) Then
                Me.StartRead()
            End If
        Catch ex As Exception

        End Try
    End Sub
    '''' <summary>
    '''' 自己重载销毁函数，用于释放非脱管的资源：释放对扫描头的占用
    '''' </summary>
    '''' <remarks></remarks>
    'Protected Overrides Sub Finalize()
    '    TermReader()
    '    'MyBase.Finalize()
    'End Sub

    ''' <summary>
    ''' Stop reading and disable/close reader 000
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub StopScan()
        Try
            TermReader()
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' 释放资源的函数
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TermReader()
        'If we have a reader
        If Not (Me.MyReader Is Nothing) Then
            Me.StopRead()
            'Disable reader, with wait cursor
            Me.MyReader.Actions.Disable()
            'free it up
            Me.MyReader.Dispose()
            ' Indicate we no longer have one
            Me.MyReader = Nothing
        End If

        ' If we have a reader data
        If Not (Me.MyReaderData Is Nothing) Then
            'Free it up
            Me.MyReaderData.Dispose()
            'Indicate we no longer have one
            Me.MyReaderData = Nothing
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '注意：如果不销毁 MyAudioController ，则程序退出时会有 objectDisposeException 发生
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not (MyAutdioDevice Is Nothing) Then
            Me.MyAudioController.Dispose()
            MyAutdioDevice = Nothing
        End If

    End Sub
    ''' <summary>
    ''' 初始化扫描
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InitReader() As Boolean
        ' If reader is already present then fail initialize
        If Not (Me.MyReader Is Nothing) Then
            Return False
        End If
        'Create new reader, first available reader will be used.
        Me.MyReader = New Symbol.Barcode.Reader
        'Create reader data
        Me.MyReaderData = New Symbol.Barcode.ReaderData( _
                                     Symbol.Barcode.ReaderDataTypes.Text, _
                                     Symbol.Barcode.ReaderDataLengths.MaximumLabel)
        ' create event handler delegate
        Me.MyEventHandler = New System.EventHandler(AddressOf MyReader_ReadNotify)
        'Enable reader, with wait cursor
        Me.MyReader.Actions.Enable()
        Return True
    End Function
    ''' <summary>
    ''' Attach to this notification event to be called back when a read completes.
    ''' 读取到条码后发出通知：调用 HandleData（）函数来处理.
    ''' </summary>
    ''' <param name="o"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MyReader_ReadNotify(ByVal o As Object, ByVal e As EventArgs)
        Dim TheReaderData As Symbol.Barcode.ReaderData = Me.MyReader.GetNextReaderData()
        'If it is a successful read (as opposed to a failed one)
        If (TheReaderData.Result = Symbol.Results.SUCCESS) Then
            'Handle the data from this read
            Me.HandleData(TheReaderData)
            'Start the next read
            Me.StartRead()
        End If
    End Sub
    ''' <summary>
    ''' 开始读条码
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StartRead()
        'If we have both a reader and a reader data
        If Not ((Me.MyReader Is Nothing) And (Me.MyReaderData Is Nothing)) Then
            'Submit a read
            AddHandler MyReader.ReadNotify, Me.MyEventHandler
            Me.MyReader.Actions.Read(Me.MyReaderData)
        End If
    End Sub
    ''' <summary>
    ''' Stop all reads on the reader
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub StopRead()
        'If we have a reader
        If Not (Me.MyReader Is Nothing) Then
            'Flush (Cancel all pending reads)
            RemoveHandler MyReader.ReadNotify, Me.MyEventHandler
            Me.MyReader.Actions.Flush()
        End If
    End Sub
    ''' <summary>
    ''' 声音报警
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ErrorBeep()
        Dim Duration As Integer = 1000 'millisec
        Dim Frequency As Integer = 2870 'hz
        If audiook Then
            Try
                Me.MyAudioController.PlayAudio(Duration, Frequency) 'play Default beep
            Catch ex As Exception

            End Try
        End If
    End Sub    'Initialize the reader.
    ''' <summary>
    ''' 声音报警--定时
    ''' </summary>
    ''' <param name="Duration"></param>
    ''' <remarks></remarks>
    Public Sub ErrorBeepT(ByVal Duration As Integer)
        If audiook Then
            Try
                Me.MyAudioController.PlayAudio(Duration, Frequency) 'play Default beep
            Catch ex As Exception

            End Try
        End If
    End Sub    'Initialize the reader.
#End Region

End Class
