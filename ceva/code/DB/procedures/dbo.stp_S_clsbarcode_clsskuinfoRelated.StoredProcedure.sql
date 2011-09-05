/****** Object:  StoredProcedure [dbo].[stp_S_clsbarcode_clsskuinfoRelated]    Script Date: 08/15/2011 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsbarcode_clsskuinfoRelated](
	@OLD___sku_no nvarchar(20)
)
as               ----根据clsskuinfo的关联字段获得clsbarcode的列表
begin
	select sku_no,barcode,bar_type,opt_by,opt_dtime,opt_timestamp
		from [dbo].[barcode]
		where 	sku_no = @OLD___sku_no 
end
GO
