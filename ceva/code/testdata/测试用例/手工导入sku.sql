insert into [skuinfo]
					(sku_no, sku_wms, sku_desc, sku_desc_eng, model_no, 
					cost_type, coutable, high_value, sku_type, measured, have_sno, 
					six_code, vender, vender_name, unit, gross_weight, net_weight, volume, length, width, height)				
					select 
[物料代码], [物料], [型号规格（中）], [型号规格（英）], [产品名称],
					case when [计费方式]='小件' then 'S' else 'L' end,
					case 
						when [计数否] = 'Y' then 1 
						when [计数否] = 'X' then 0 
						when [计数否] = 'N' then 0 
						else 0 end,
					case when [贵重品] in ('Y','N','X') then 1 else 0 end,
[产品类别],
					case when [测量状态]='已测量' then '1' else '0' end,
					case when [机号检查] in ('Y','是','X') then 1 else 0 end, 
[六位代码], CAST([供应商代码]    AS INT ), [供应商名称], [基本单位],
[毛重 （公斤）],
[净重（公斤）], [体积（立方）], [长度（米）], [宽度（米）], [高度（米）] 
from dbo.[数据区$]