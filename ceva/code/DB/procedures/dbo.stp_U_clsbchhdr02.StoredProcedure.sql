/****** Object:  StoredProcedure [dbo].[stp_U_clsbchhdr02]    Script Date: 08/15/2011 10:55:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clsbchhdr02]( 
	@OLD___dc_code nvarchar(10),
	@OLD___bch_no nvarchar(20),
	@dc_code nvarchar(10),
	@bch_no nvarchar(20),
	@description nvarchar(20),
	@status_code nchar(5),
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
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[bchhdr]
		where dc_code = @OLD___dc_code and
		bch_no = @OLD___bch_no 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	exec  stp_U_clsbchhdr
		@OLD___dc_code = @OLD___dc_code,
		@OLD___bch_no = @OLD___bch_no,
		@dc_code = @dc_code,
		@bch_no = @bch_no,
		@description = @description,
		@status_code = @status_code,
		@locked = @locked,
		@opt_by = @opt_by,
		@opt_dtime = @opt_dtime,
		@start_dtime = @start_dtime,
		@end_dtime = @end_dtime,
		@opt_timestamp = @opt_timestamp output
end
GO
