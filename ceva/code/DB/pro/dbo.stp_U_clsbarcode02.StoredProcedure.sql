IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsbarcode02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_U_clsbarcode02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsbarcode02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_U_clsbarcode02]( 
	@OLD___sku_no nvarchar(20),
	@OLD___barcode nvarchar(30),
	@sku_no nvarchar(20),
	@barcode nvarchar(30),
	@bar_type nchar(3),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as               ----更新02
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
	exec  stp_U_clsbarcode
		@OLD___sku_no = @OLD___sku_no,
		@OLD___barcode = @OLD___barcode,
		@sku_no = @sku_no,
		@barcode = @barcode,
		@bar_type = @bar_type,
		@opt_by = @opt_by,
		@opt_dtime = @opt_dtime,
		@opt_timestamp = @opt_timestamp output
end
' 
END
GO
