
Namespace BusinessObject

    Public Class GeneralType
        Public Enum CmdType
            BrowseCmd = 101
            AddNewCmd = 102
            EditCmd = 103
            DeleteCmd = 104
            SearchCmd = 105
            PurgeCmd = 106
            LabelCmd = 107
            ReportCmd = 108
            SubmitCmd = 121
            CheckCmd = 122
            ConfirmCmd = 123
            CancelCmd = 130
            BlankOutCmd = 131
            ReturnCmd = 132
            RejectCmd = 134
            DownloadCmd = 220
            UploadCmd = 222
            ImportCmd = 230
            ExportCmd = 231
            LoginCmd = 900
            LogoutCmd = 901
            ChangePwdCmd = 902
        End Enum
    End Class


    Public Class BatchType
        '001仓库出货(缺省)/ 002仓库收货/010POP经销商间点间/011退货经销商点单/ 
        Public Const BatchOutbound As String = "DN"
        Public Const BatchInbound As String = "002"
        Public Const BatchBetweenDealer As String = "010"
        Public Const BatchReturnDealer As String = "011"
    End Class
    Public Class BatchStatusCode
        Public Const NotStartBanch As String = "'0    ','1    '"
        Public Const StartBanch As String = "'2    ','3    '"
        Public Const FinishedtBanch As String = "4    "
    End Class

    Public Class TrackingType
        '1=借机跟踪/2=维修跟踪
        Public Const TrackingLoan As String = "1"
        Public Const TrackingRepair As String = "2"
    End Class

    Public Class ArchiveType
        Public Const Inbound As String = "1"
        Public Const Outbound As String = "2"
    End Class

    'First char= 1  for WM,  5  for IM
    'Second char=    1 for receive(reserved) , 2 for delivery, 3 for movement
    Public Enum StockUsageType
        PickingUsageWM = 120                '配货保留
        MovementUsageWM = 130               '移货保留
        DeliveryPreUsageIM = 520            '组批预留保
        DeliveryUsageIM = 521               '组批保留
    End Enum

    Public Class BussinessOperateType
        Public Const Inbound As String = "100"
        Public Const Outbound As String = "200"
        Public Const Transfer As String = "600"
    End Class

    'CL100:收货
    'CL200:发货
    'CL300:配货
    'Cl400:上架
    Public Class ModuleType                                 '模块类型
        Public Const Login As String = "CL000"              '登录
        Public Const MainMenu As String = "CL001"           '主菜单
        Public Const Recieve As String = "CL100"            '收货
        Public Const Delivery As String = "CL200"           '发货
        Public Const Picking As String = "CL300"            '配货
        Public Const Putaway As String = "CL400"            '上架
        Public Const Movement As String = "CL500"           '移货
    End Class

End Namespace