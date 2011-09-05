/****** Object:  StoredProcedure [dbo].[stp_U_clsskuinfo]    Script Date: 08/15/2011 10:55:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clsskuinfo]( 
	@OLD___sku_no nvarchar(20),
	@OLD___sku_wms nvarchar(20),
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
as           ----更新
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[skuinfo]
		where sku_no = @OLD___sku_no and
		sku_wms = @OLD___sku_wms 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	update [dbo].[skuinfo] set 
		sku_no = @sku_no,
		sku_wms = @sku_wms,
		sku_desc = @sku_desc,
		sku_desc_eng = @sku_desc_eng,
		model_no = @model_no,
		volume = @volume,
		length = @length,
		width = @width,
		height = @height,
		opt_by = @opt_by,
		opt_dtime = @opt_dtime
		where sku_no = @OLD___sku_no and
		sku_wms = @OLD___sku_wms 

	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
