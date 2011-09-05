/****** Object:  StoredProcedure [dbo].[stp_I_clstasklist]    Script Date: 08/15/2011 10:54:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clstasklist]( 
	@task_id nvarchar(20),
	@bch_no nvarchar(20),
	@dn_no nvarchar(20),
	@assigned_opt nvarchar(20),
	@bin_area nvarchar(10),
	@bin_code nvarchar(10),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@start_dtime datetime,
	@end_dtime datetime,
	@opt_timestamp timestamp output,
	@dc_code nvarchar(10),
	@status_code nchar(5)
)
as 
begin
	insert into [dbo].[tasklist]( 
		task_id,
		bch_no,
		dn_no,
		assigned_opt,
		bin_area,
		bin_code,
		opt_by,
		opt_dtime,
		start_dtime,
		end_dtime,
		dc_code,
		status_code)
	values(
		@task_id,
		@bch_no,
		@dn_no,
		@assigned_opt,
		@bin_area,
		@bin_code,
		@opt_by,
		@opt_dtime,
		@start_dtime,
		@end_dtime,
		@dc_code,
		@status_code
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
