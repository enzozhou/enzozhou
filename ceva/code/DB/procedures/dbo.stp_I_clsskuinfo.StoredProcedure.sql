/****** Object:  StoredProcedure [dbo].[stp_I_clsskuinfo]    Script Date: 08/15/2011 10:54:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsskuinfo]( 
	@sku_no nvarchar(20),
	@sku_wms nvarchar(20),
	@sku_desc nvarchar(50),
	@sku_desc_eng nvarchar(50),
	@model_no nvarchar(50),
	@volume numeric(20,9),
	@length numeric(12,3),
	@width numeric(12,3),
	@height numeric(12,3),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
	insert into [dbo].[skuinfo]( 
		sku_no,
		sku_wms,
		sku_desc,
		sku_desc_eng,
		model_no,
		volume,
		length,
		width,
		height,
		opt_by,
		opt_dtime)
	values(
		@sku_no,
		@sku_wms,
		@sku_desc,
		@sku_desc_eng,
		@model_no,
		@volume,
		@length,
		@width,
		@height,
		@opt_by,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
