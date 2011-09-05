IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsDnBin02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_U_clsDnBin02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsDnBin02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_U_clsDnBin02]( 
	@OLD___rowid nvarchar(10),
	@OLD___dc_code nvarchar(10),
	@OLD___bch_no nvarchar(10),
	@OLD___wh_code nvarchar(10),
	@OLD___dn_no nvarchar(20),
	@OLD___bin_area nvarchar(10),
	@OLD___bin_code nvarchar(10),
	@OLD___sku_no nvarchar(20),
	@rowid nvarchar(10),
	@dc_code nvarchar(10),
	@bch_no nvarchar(10),
	@wh_code nvarchar(10),
	@dn_no nvarchar(20),
	@bin_area nvarchar(10),
	@bin_code nvarchar(10),
	@sku_no nvarchar(20),
	@qty numeric(12,3),
	@type nchar(3),
	@status_code nchar(5),
	@close_auto bit,
	@print_by nvarchar(20),
	@print_counter int,
	@print_dtime datetime,
	@locked int,
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@start_dtime datetime,
	@end_dtime datetime,
	@opt_timestamp timestamp output
)
as               ----更新02
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[DnBin]
		where rowid = @OLD___rowid and
		dc_code = @OLD___dc_code and
		bch_no = @OLD___bch_no and
		wh_code = @OLD___wh_code and
		dn_no = @OLD___dn_no and
		bin_area = @OLD___bin_area and
		bin_code = @OLD___bin_code and
		sku_no = @OLD___sku_no 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	exec  stp_U_clsDnBin
		@OLD___rowid = @OLD___rowid,
		@OLD___dc_code = @OLD___dc_code,
		@OLD___bch_no = @OLD___bch_no,
		@OLD___wh_code = @OLD___wh_code,
		@OLD___dn_no = @OLD___dn_no,
		@OLD___bin_area = @OLD___bin_area,
		@OLD___bin_code = @OLD___bin_code,
		@OLD___sku_no = @OLD___sku_no,
		@rowid = @rowid,
		@dc_code = @dc_code,
		@bch_no = @bch_no,
		@wh_code = @wh_code,
		@dn_no = @dn_no,
		@bin_area = @bin_area,
		@bin_code = @bin_code,
		@sku_no = @sku_no,
		@qty = @qty,
		@type = @type,
		@status_code = @status_code,
		@close_auto = @close_auto,
		@print_by = @print_by,
		@print_counter = @print_counter,
		@print_dtime = @print_dtime,
		@locked = @locked,
		@opt_by = @opt_by,
		@opt_dtime = @opt_dtime,
		@start_dtime = @start_dtime,
		@end_dtime = @end_dtime,
		@opt_timestamp = @opt_timestamp output
end
' 
END
GO
