/****** Object:  StoredProcedure [dbo].[stp_U_clstaskhdr02]    Script Date: 08/15/2011 10:55:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clstaskhdr02]( 
	@OLD___dc_code nvarchar(10),
	@OLD___task_id nvarchar(20),
	@dc_code nvarchar(10),
	@task_id nvarchar(20),
	@bch_no nvarchar(20),
	@dn_no nvarchar(20),
	@status_code nchar(5),
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
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[taskhdr]
		where dc_code = @OLD___dc_code and
		task_id = @OLD___task_id 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	exec  stp_U_clstaskhdr
		@OLD___dc_code = @OLD___dc_code,
		@OLD___task_id = @OLD___task_id,
		@dc_code = @dc_code,
		@task_id = @task_id,
		@bch_no = @bch_no,
		@dn_no = @dn_no,
		@status_code = @status_code,
		@opt_by = @opt_by,
		@opt_dtime = @opt_dtime,
		@start_dtime = @start_dtime,
		@end_dtime = @end_dtime,
		@opt_timestamp = @opt_timestamp output
end
GO
