/****** Object:  StoredProcedure [dbo].[stp_S_clsbarcode]    Script Date: 08/15/2011 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsbarcode](
	@OLD___sku_no nvarchar(20),
	@OLD___barcode nvarchar(30)
)
as               ----根据关键字取得clsbarcode记录
begin
	select sku_no,barcode,bar_type,opt_by,opt_dtime,opt_timestamp
		from [dbo].[barcode]
		where 	sku_no = @OLD___sku_no and
			barcode = @OLD___barcode 
end
GO
