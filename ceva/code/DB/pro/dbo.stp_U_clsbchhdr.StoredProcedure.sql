IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsbchhdr]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_U_clsbchhdr]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsbchhdr]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_U_clsbchhdr]( 
	@OLD___dc_code nvarchar(10),
	@OLD___bch_no nvarchar(20),
	@OLD___wh_code nvarchar(10),
	@dc_code nvarchar(10),
	@bch_no nvarchar(20),
	@wh_code nvarchar(10),
	@description nvarchar(20),
	@bch_type nchar(3),
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
as           ----更新
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[bchhdr]
		where dc_code = @OLD___dc_code and
		bch_no = @OLD___bch_no and
		wh_code = @OLD___wh_code 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	update [dbo].[bchhdr] set 
		dc_code = @dc_code,
		bch_no = @bch_no,
		wh_code = @wh_code,
		[description] = @description,
		bch_type = @bch_type,
		status_code = @status_code,
		close_auto = @close_auto,
		print_by = @print_by,
		print_counter = @print_counter,
		print_dtime = @print_dtime,
		locked = @locked,
		opt_by = @opt_by,
		opt_dtime = @opt_dtime,
		start_dtime = @start_dtime,
		end_dtime = @end_dtime
		where dc_code = @OLD___dc_code and
		bch_no = @OLD___bch_no and
		wh_code = @OLD___wh_code 

	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
' 
END
GO
