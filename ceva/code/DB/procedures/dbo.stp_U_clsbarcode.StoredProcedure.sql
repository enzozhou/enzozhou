/****** Object:  StoredProcedure [dbo].[stp_U_clsbarcode]    Script Date: 08/15/2011 10:55:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clsbarcode]( 
	@OLD___sku_no nvarchar(20),
	@OLD___barcode nvarchar(30),
	@sku_no nvarchar(20),
	@barcode nvarchar(30),
	@bar_type nchar(3),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as           ----更新
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[barcode]
		where sku_no = @OLD___sku_no and
		barcode = @OLD___barcode 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	update [dbo].[barcode] set 
		sku_no = @sku_no,
		barcode = @barcode,
		bar_type = @bar_type,
		opt_by = @opt_by,
		opt_dtime = @opt_dtime
		where sku_no = @OLD___sku_no and
		barcode = @OLD___barcode 

	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
