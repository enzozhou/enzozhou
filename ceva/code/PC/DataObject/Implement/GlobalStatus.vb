Option Explicit On 
Option Strict On

Namespace BusinessObject

    Public Class GlobalStatus
        '----�ջ���--------------------
        Public Const ROHDR_OPEN As String = "RRO10"
        Public Const ROHDR_PROCESSING As String = "RRO12"
        Public Const ROHDR_CLOSE As String = "RRO14"
        Public Const ROHDR_CANCEL As String = "RRO20"
        Public Const ROLIN_OPEN As String = "RRO50"
        Public Const ROLIN_PROCESSING As String = "RRO52"
        Public Const ROLIN_CLOSE As String = "RRO54"
        '---�ջ�����----
        Public Const RECVHDR_OPEN As String = "REC10"
        Public Const RECVHDR_PROCESSING As String = "REC12"
        Public Const RECVHDR_CLOSE As String = "REC14"
        Public Const RECVHDR_CANCEL As String = "REC20"
        Public Const RECVLIN_OPEN As String = "REC50"
        Public Const RECVLIN_PROCESSING As String = "REC52"
        Public Const RECVLIN_CLOSE As String = "REC54"
        '--�ϼ�-------
        Public Const PUTHDR_OPEN As String = "PUT10"
        Public Const PUTHDR_PROCESSING As String = "PUT12"
        Public Const PUTHDR_CLOSE As String = "PUT14"
        Public Const PUTHDR_CANCEL As String = "PUT20"
        Public Const PUTLIN_OPEN As String = "PUT50"
        Public Const PUTLIN_PROCESSING As String = "PUT52"
        Public Const PUTLIN_CLOSE As String = "PUT54"
        'Public Const PUTLIN_CANCEL As String = "PUT20"

        '--���
        Public Const PIKHDR_OPEN As String = "PIK10"
        Public Const PIKHDR_PROCESSING As String = "PIK12"
        Public Const PIKHDR_CLOSE As String = "PIK14"
        Public Const PIKHDR_CANCEL As String = "PIK20"
        Public Const PIKLIN_OPEN As String = "PIK50"
        Public Const PIKLIN_PROCESSING As String = "PIK52"
        Public Const PIKLIN_CLOSE As String = "PIK54"

        '----��--
        Public Const BCHHDR_OPEN As String = "BCH10"
        Public Const BCHDR_PROCESSING As String = "BCH12"
        Public Const BCHDR_CLOSE As String = "BCH14"
        Public Const BCHDR_CANCEL As String = "BCH20"

        '--����
        Public Const DNHDR_OPEN As String = "DNO10"
        Public Const DNHDR_CHECKED As String = "DNO11"
        Public Const DNHDR_PROCESSING As String = "DNO12"
        Public Const DNHDR_CLOSE As String = "DNO14"
        Public Const DNHDR_CANCEL As String = "DNO20"
        Public Const DNHDR_SYNC As String = "DNO22"
        Public Const DNLIN_OPEN As String = "DNO50"
        Public Const DNLIN_PROCESSING As String = "DNO52"
        Public Const DNLIN_CLOSE As String = "DNO54"
        Public Const DNLIN_SYNC As String = "DNO62"

        'Private Const SHPHDR_OPEN As String = "DNO10"
        'Private Const SHPHDR_PROCESSING As String = "DNO12"
        'Private Const SHPHDR_CLOSE As String = "DNO14"
        'Private Const SHPHDR_CANCEL As String = "DNO20"
        'Private Const SHPHDR_SYNC As String = "DNO22"
        Public Const SHPLIN_OPEN As String = "SHP50"
        Public Const SHPLIN_PROCESSING As String = "SHP52"
        Public Const SHPLIN_CLOSE As String = "SHP54"
        'Private Const SHPLIN_SYNC As String = "SHP10"

        '�ƻ�
        Public Const MOVHDR_OPEN As String = "MOV10"
        Public Const MOVHDR_PROCESSING As String = "MOV12"
        Public Const MOVHDR_CLOSE As String = "MOV14"
        Public Const MOVHDR_CANCEL As String = "MOV20"
        Public Const MOVLIN_OPEN As String = "MOV50"
        Public Const MOVLIN_PROCESSING As String = "MOV52"
        Public Const MOVLIN_CLOSE As String = "MOV54"

        '��Ʒ����
        Public Const MEASURED_YES As Boolean = True
        Public Const MEASURED_NO As Boolean = False
        Public Const MEASURE_OPEN As String = "MEA10" '       δ����                                                Open                                               MEA        0         B         NULL                                                                                                                                                                                                                                                             NULL                 NULL                                                   0x000000000001032D
        Public Const MEASURE_PROCESSING As String = "MEA12" '       ���ڴ���                                               Processing                                         MEA        0         N         NULL                                                                                                                                                                                                                                                             NULL                 NULL                                                   0x000000000001032E
        Public Const MEASURE_CLOSE As String = "MEA14" '       �����                                                Completed                                          MEA        0         E         NULL                                                                                                                                                                                                                                                             NULL                 NULL                                                   0x000000000001032F
        Public Const MEASURE_CANCEL As String = "MEA20"            'Canceled
        '�̵�
        Public Const INVHDR_OPEN As String = "CCT10"
        Public Const INVHDR_PROCESSING As String = "CCT12"
        Public Const INVHDR_CLOSE As String = "CCT14"
        Public Const INVHDR_CANCEL As String = "CCT20"

        Public Const INVLIN_OPEN As String = "CCT50"
        Public Const INVLIN_PROCESSING As String = "CCT52"
        Public Const INVLIN_CLOSE As String = "CCT54"

        '���Ų�ѯ
        Public Const QSR_OPEN As String = "QSR10" 'δ��Ч
        Public Const QSR_APPLIED As String = "QSR12" '����Ч
        Public Const QSR_COMPLETED As String = "QSR14" '��ȡ��

        Public Const QSV_APPLIED As String = "RSV10" ' ���ڱ���

        '��
        Public Const BOXHDR_INPUT As String = "BOX10"           '��ʼ¼��
        Public Const BOXHDR_RECEIVING As String = "BOX15"        '�ȴ��ջ�
        Public Const BOXHDR_ONHAND As String = "BOX20"          '�ڿ�
        Public Const BOXHDR_MOVEING As String = "BOX22"         '�����ƻ�
        Public Const BOXHDR_SHIPPING As String = "BOX25"        '���ڷ���
        Public Const BOXHDR_SHIPPED As String = "BOX30"         '�ѷ���

        '�ӹ�����
        Public Const KORDHDR_OPEN As String = "KTK10"
        Public Const KORDHDR_PROCESSING As String = "KTK12"
        Public Const KORDHDR_CLOSE As String = "KTK14"
        Public Const KORDHDR_CANCEL As String = "KTK20"
        '�ӹ��ؿ�
        Public Const KORDLIN_OPEN As String = "KRT10"
        Public Const KORDLIN_PROCESSING As String = "KRT12"
        Public Const KORDLIN_CLOSE As String = "KRT14"
        '�ӹ����
        Public Const KORDPICKLIN_OPEN As String = "KTK50"
        Public Const KORDPICKLIN_PROCESSING As String = "KTK52"
        Public Const KORDPICKLIN_CLOSE As String = "KTK54"

        'Comm
        Public Const COMM_SAVED As String = "COM00"             '   not requested"
        Public Const COMM_REQUESTED As String = "COM01"         '   Requested"
        Public Const COMM_OPEN As String = "COM10"              '	δ����
        Public Const COMM_PROCESSING As String = "COM12"        '	���ڴ���
        Public Const COMM_SUCCESS As String = "COM14"           '	�ѳɹ�"
        Public Const COMM_PARTIAL As String = "COM16"           '	�Ѵ���(����)"
        Public Const COMM_FAIL As String = "COM20"              '	ʧ��"

        '�˶����
        Public Const SEGMENT_OPEN As String = "SEG10"  '��ʼ״̬	Open
        Public Const SEGMENT_UPDATE As String = "SEG12" '	������	Update
        Public Const SEGMENT_PROCESSING As String = "SEG14" '	��ɨ��	Processing"
        Public Const SEGMENT_CLOSE As String = "SEG15" '	������	Completed"
        Public Const SEGMENT_CANCEL As String = "SEG20" '	��ȡ��	Canceled"


    End Class
End Namespace
