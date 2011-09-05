/****** Object:  StoredProcedure [dbo].[stp_D_clsbarcode]    Script Date: 08/15/2011 10:53:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsbarcode](
	@sku_no nvarchar(20),
	@barcode nvarchar(30),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[barcode]
	where 	sku_no = @sku_no and
		barcode = @barcode 
end
GO
