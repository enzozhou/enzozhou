/****** Object:  StoredProcedure [dbo].[stp_S_clsskuinfo]    Script Date: 08/15/2011 10:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsskuinfo](
	@OLD___sku_no nvarchar(20),
	@OLD___sku_wms nvarchar(20)
)
as               ----根据关键字取得clsskuinfo记录
begin
	select sku_no,sku_wms,sku_desc,sku_desc_eng,model_no,volume,length,width,height,opt_by,opt_dtime,opt_timestamp
		from [dbo].[skuinfo]
		where 	sku_no = @OLD___sku_no and
			sku_wms = @OLD___sku_wms 
end
GO
