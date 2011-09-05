Namespace BusinessObject

    Public Class DocType


        Public Const InboundPO As String = "100"                '采购品收货	        		
        Public Const InboundImport As String = "105"            '进口品收货	        		
        Public Const InboundReturnCancel As String = "'110','111'"            '退货收货,取消单
        Public Const InboundReturn As String = "110"            '退货收货	        		
        Public Const InboundReplaced As String = "111"            '取消单收货	        		
        Public Const InboundTransfer As String = "115"          '转库收货	        		
        Public Const InboundLoan As String = "120"              '借机收货  	        		
        Public Const InboundRepair As String = "125"            '修理收货  	        		
        Public Const InboundTemporarily As String = "130"       '暂存品收货	        		
        Public Const InboundTakeback As String = "131"       '取回单收货	        		
        Public Const InboundSample As String = "150"       '样机收货	        		
        Public Const InboundCTO As String = "135"               'CTO收货	100	        		
        Public Const InboundPOP As String = "140"           'POP收货	100	
        Public Const InboundHand As String = "180"          '手工单收货
        Public Const InboundTempTransit As String = "132"          'TIS中转收货

        '200	配送出货	
        '205	换货出货	
        '210	'暂存品出货	
        '215	'POP出货		不再使用
        '220	'修理出货	
        '225	'借机出货	
        '230	CROSS-DOCK出货	
        '235	'返厂出货	
        '240	'转库出货	
        '245	BRAVIA出货	
        '250	网销出货	
        '255	取消单出货	
        '290	其它出货	
        Public Const OutboundNormal As String = "'200','255'"    '200一般出货, 255	取消单出货	
        Public Const OutboundDaily As String = "200"
        Public Const OutboundReplaced As String = "255"
        Public Const OutboundLoan As String = "225"
        Public Const OutboundPOP As String = "215"
        Public Const OutboundTemporarily As String = "210"
        Public Const OutboundTransfer As String = "240"
        Public Const OutboundRepair As String = "220"
        Public Const OutboundReturnToPlant As String = "235"
        Public Const OutboundHand As String = "280"                 '手工单出货
        Public Const OutboundDWS As String = "245"                  'DWS Shop出货
        Public Const OutboundTempTransit As String = "232"                  'TIS中转收货

        Public Const OutboundSample As String = "250"               '样机出货
        Public Const OutboundWriteOffSample As String = "251"       '样机报废
        Public Const OutboundSampleList As String = "'250','251'"               '样机出货


        Public Const MovementBinWithOrder As String = "300"   '有单移货
        Public Const MovementBinWithoutOrder As String = "301"   '无单移货
        Public Const MovementForCancel As String = "302"    '发货取消后移货
        Public Const MovementOwnerChanged As String = "305"   '转货主移库	
        Public Const MovementForTakeback As String = "306"   '取回单暂存后转货主移库	
        Public Const MovementForDWS As String = "307"       'DWS暂存转货主移库	
        Public Const MovementOwnerNonSAP As String = "310"   ''转货主 非SAP
        Public Const MovementStatusChanged As String = "320"   '转状态移库	320

        Public Const MovementBinNormalList As String = "'300','301','302'"   '一般移库	包括300,301	
        Public Const MovementWarehouseList As String = "'305','306','307'"

    End Class

    Public Class KitType
        '需求类型 K加工套装/U拆套装/S=单品加工,/R=收货单品打工/ T=CPSG收货加工
        Public Const KitSuit As String = "K"
        Public Const UnKitSuit As String = "U"
        Public Const KitSingle As String = "S"
        Public Const KitSingleForReceiving As String = "R"
        Public Const KitTagForReceiving As String = "T"
    End Class

    Public Class DnStatusCode
        Public Const NotStartDn As String = "0    "
        Public Const StartDn As String = "'1    ','2    ','3    ','4    '"
        Public Const FinishedtDn As String = "5    "
    End Class
End Namespace
