/****** Object:  StoredProcedure [dbo].[stp_SL_clsbarcode]    Script Date: 08/15/2011 10:55:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsbarcode]
as       ----取得clsbarcode的一个列表
begin
	select top 1000 sku_no,barcode,bar_type,opt_by,opt_dtime,opt_timestamp
		from [dbo].[barcode]
end
GO
