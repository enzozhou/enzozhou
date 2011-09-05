Namespace BusinessObject

    Public Class DocType


        Public Const InboundPO As String = "100"                '�ɹ�Ʒ�ջ�	        		
        Public Const InboundImport As String = "105"            '����Ʒ�ջ�	        		
        Public Const InboundReturnCancel As String = "'110','111'"            '�˻��ջ�,ȡ����
        Public Const InboundReturn As String = "110"            '�˻��ջ�	        		
        Public Const InboundReplaced As String = "111"            'ȡ�����ջ�	        		
        Public Const InboundTransfer As String = "115"          'ת���ջ�	        		
        Public Const InboundLoan As String = "120"              '����ջ�  	        		
        Public Const InboundRepair As String = "125"            '�����ջ�  	        		
        Public Const InboundTemporarily As String = "130"       '�ݴ�Ʒ�ջ�	        		
        Public Const InboundTakeback As String = "131"       'ȡ�ص��ջ�	        		
        Public Const InboundSample As String = "150"       '�����ջ�	        		
        Public Const InboundCTO As String = "135"               'CTO�ջ�	100	        		
        Public Const InboundPOP As String = "140"           'POP�ջ�	100	
        Public Const InboundHand As String = "180"          '�ֹ����ջ�
        Public Const InboundTempTransit As String = "132"          'TIS��ת�ջ�

        '200	���ͳ���	
        '205	��������	
        '210	'�ݴ�Ʒ����	
        '215	'POP����		����ʹ��
        '220	'�������	
        '225	'�������	
        '230	CROSS-DOCK����	
        '235	'��������	
        '240	'ת�����	
        '245	BRAVIA����	
        '250	��������	
        '255	ȡ��������	
        '290	��������	
        Public Const OutboundNormal As String = "'200','255'"    '200һ�����, 255	ȡ��������	
        Public Const OutboundDaily As String = "200"
        Public Const OutboundReplaced As String = "255"
        Public Const OutboundLoan As String = "225"
        Public Const OutboundPOP As String = "215"
        Public Const OutboundTemporarily As String = "210"
        Public Const OutboundTransfer As String = "240"
        Public Const OutboundRepair As String = "220"
        Public Const OutboundReturnToPlant As String = "235"
        Public Const OutboundHand As String = "280"                 '�ֹ�������
        Public Const OutboundDWS As String = "245"                  'DWS Shop����
        Public Const OutboundTempTransit As String = "232"                  'TIS��ת�ջ�

        Public Const OutboundSample As String = "250"               '��������
        Public Const OutboundWriteOffSample As String = "251"       '��������
        Public Const OutboundSampleList As String = "'250','251'"               '��������


        Public Const MovementBinWithOrder As String = "300"   '�е��ƻ�
        Public Const MovementBinWithoutOrder As String = "301"   '�޵��ƻ�
        Public Const MovementForCancel As String = "302"    '����ȡ�����ƻ�
        Public Const MovementOwnerChanged As String = "305"   'ת�����ƿ�	
        Public Const MovementForTakeback As String = "306"   'ȡ�ص��ݴ��ת�����ƿ�	
        Public Const MovementForDWS As String = "307"       'DWS�ݴ�ת�����ƿ�	
        Public Const MovementOwnerNonSAP As String = "310"   ''ת���� ��SAP
        Public Const MovementStatusChanged As String = "320"   'ת״̬�ƿ�	320

        Public Const MovementBinNormalList As String = "'300','301','302'"   'һ���ƿ�	����300,301	
        Public Const MovementWarehouseList As String = "'305','306','307'"

    End Class

    Public Class KitType
        '�������� K�ӹ���װ/U����װ/S=��Ʒ�ӹ�,/R=�ջ���Ʒ��/ T=CPSG�ջ��ӹ�
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
