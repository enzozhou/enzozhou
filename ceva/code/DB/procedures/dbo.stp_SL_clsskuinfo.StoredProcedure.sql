/****** Object:  StoredProcedure [dbo].[stp_SL_clsskuinfo]    Script Date: 08/15/2011 10:55:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsskuinfo]
as       ----取得clsskuinfo的一个列表
begin
	select top 1000 sku_no,sku_wms,sku_desc,sku_desc_eng,model_no,volume,length,width,height,opt_by,opt_dtime,opt_timestamp
		from [dbo].[skuinfo]
end
GO
