IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsskuinfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_SL_clsskuinfo]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsskuinfo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_SL_clsskuinfo]
as       ----取得clsskuinfo的一个列表
begin
	select top 1000 sku_no,sku_wms,sku_desc,sku_desc_eng,model_no,cost_type,coutable,high_value,sku_type,source,measured,meas_date,have_sno,[identity],sno_len,six_code,vender,vender_name,unit,gross_weight,net_weight,volume,length,width,height,pack_len,pack_width,pack_height,down_date,category,department,minqty_sales,qty_pack,qty_len,qty_width,qty_height,stuff,expired_day,define1,define2,define3,define4,define5,price,first_opdate,last_opdate,sap_sku,opt_by,opt_dtime,opt_timestamp
		from [dbo].[skuinfo]
end
' 
END
GO
