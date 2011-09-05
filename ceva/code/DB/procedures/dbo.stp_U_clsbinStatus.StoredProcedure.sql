/****** Object:  StoredProcedure [dbo].[stp_U_clsbinStatus]    Script Date: 08/15/2011 10:55:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clsbinStatus]( 
	@OLD___dc_code nvarchar(10),
	@OLD___id int,
	@OLD___bin_area nvarchar(10),
	@OLD___bin_code nvarchar(10),
	@OLD___dn_no nvarchar(20),
	@dc_code nvarchar(10),
	@bin_area nvarchar(10),
	@bin_code nvarchar(10),
	@dn_no nvarchar(20),
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
as           ----更新
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[binStatus]
		where dc_code = @OLD___dc_code and
		id = @OLD___id and
		bin_area = @OLD___bin_area and
		bin_code = @OLD___bin_code and
		dn_no = @OLD___dn_no 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	update [dbo].[binStatus] set 
		dc_code = @dc_code,
		bin_area = @bin_area,
		bin_code = @bin_code,
		dn_no = @dn_no,
		type = @type,
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
		id = @OLD___id and
		bin_area = @OLD___bin_area and
		bin_code = @OLD___bin_code and
		dn_no = @OLD___dn_no 

	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
