IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsskuinfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsskuinfo]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsskuinfo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsskuinfo](
	@OLD___sku_no nvarchar(20),
	@OLD___sku_wms nvarchar(20)
)
as               ----根据关键字取得clsskuinfo记录
begin
	select sku_no,sku_wms,sku_desc,sku_desc_eng,model_no,cost_type,coutable,high_value,sku_type,source,measured,meas_date,have_sno,[identity],sno_len,six_code,vender,vender_name,unit,gross_weight,net_weight,volume,length,width,height,pack_len,pack_width,pack_height,down_date,category,department,minqty_sales,qty_pack,qty_len,qty_width,qty_height,stuff,expired_day,define1,define2,define3,define4,define5,price,first_opdate,last_opdate,sap_sku,opt_by,opt_dtime,opt_timestamp
		from [dbo].[skuinfo]
		where 	sku_no = @OLD___sku_no and
			sku_wms = @OLD___sku_wms 
end
' 
END
GO
