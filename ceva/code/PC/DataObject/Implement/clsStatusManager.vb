Namespace BusinessObject

    Public Class clsStatusManager
        'Default=N��ʵʩ��أ�B=��ʼ״̬,P��ҵԤ����״̬,N=�м���ҵ״̬��A��ҵ����״̬��E=��ֹ״̬
        Public Const StatusFlowOpen As String = "B"
        Public Const StatusFlowProcessing As String = "N"
        Public Const StatusFlowClosed As String = "E"
        Public Const StatusFlowCanceled As String = "C"
        Public Const StatusFlowPreProcess As String = "P"
        Public Const StatusFlowAfterProcess As String = "A"

        'Private mobjStatus As clsstatus

        'Public Shared Function LoadStatus(ByVal strTransType As String, ByVal strTransSub As String, ByVal strFlow As String) As clsstatus
        '    Dim fb As COMExpress.BusinessObject.Filters.CXFilterBase
        '    Dim fl As New COMExpress.BusinessObject.Filters.CXFilters
        '    Dim objs As clsstatuses
        '    fb = ImpBusinessCollectionDerived.GetSingleFilter("trans_type", strTransType, "clsstatus", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
        '    fl.Add(fb)
        '    fb = ImpBusinessCollectionDerived.GetSingleFilter("trans_sub", strTransSub, "clsstatus", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
        '    fl.Add(fb)
        '    fb = ImpBusinessCollectionDerived.GetSingleFilter("flow_type", strFlow, "clsstatus", COMExpress.BusinessObject.Filters.ConditionOperator.Equal)
        '    fl.Add(fb)

        '    objs = clsstatus.LoadList(fl)
        '    If objs.Count > 0 Then
        '        Return objs.Item(1)
        '    End If
        '    Return Nothing
        'End Function



    End Class


End Namespace
