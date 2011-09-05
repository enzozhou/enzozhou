/****** Object:  StoredProcedure [dbo].[stp_D_clsskuinfo02]    Script Date: 08/15/2011 10:54:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsskuinfo02](
	@sku_no nvarchar(20),
	@sku_wms nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clsskuinfo
		@sku_no = @sku_no,
		@sku_wms = @sku_wms,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby

end
GO
