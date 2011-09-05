/****** Object:  StoredProcedure [dbo].[stp_D_clsskuinfo]    Script Date: 08/15/2011 10:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsskuinfo](
	@sku_no nvarchar(20),
	@sku_wms nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[skuinfo]
	where 	sku_no = @sku_no and
		sku_wms = @sku_wms 
end
GO
