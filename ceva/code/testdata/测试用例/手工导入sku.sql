insert into [skuinfo]
					(sku_no, sku_wms, sku_desc, sku_desc_eng, model_no, 
					cost_type, coutable, high_value, sku_type, measured, have_sno, 
					six_code, vender, vender_name, unit, gross_weight, net_weight, volume, length, width, height)				
					select 
[���ϴ���], [����], [�ͺŹ���У�], [�ͺŹ��Ӣ��], [��Ʒ����],
					case when [�Ʒѷ�ʽ]='С��' then 'S' else 'L' end,
					case 
						when [������] = 'Y' then 1 
						when [������] = 'X' then 0 
						when [������] = 'N' then 0 
						else 0 end,
					case when [����Ʒ] in ('Y','N','X') then 1 else 0 end,
[��Ʒ���],
					case when [����״̬]='�Ѳ���' then '1' else '0' end,
					case when [���ż��] in ('Y','��','X') then 1 else 0 end, 
[��λ����], CAST([��Ӧ�̴���]    AS INT ), [��Ӧ������], [������λ],
[ë�� �����],
[���أ����], [�����������], [���ȣ��ף�], [��ȣ��ף�], [�߶ȣ��ף�] 
from dbo.[������$]