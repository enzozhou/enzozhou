/****** Object:  StoredProcedure [dbo].[stp_I_clstaskhdr]    Script Date: 08/15/2011 10:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clstaskhdr]( 
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
as 
begin
	insert into [dbo].[taskhdr]( 
		dc_code,
		task_id,
		bch_no,
		dn_no,
		status_code,
		opt_by,
		opt_dtime,
		start_dtime,
		end_dtime)
	values(
		@dc_code,
		@task_id,
		@bch_no,
		@dn_no,
		@status_code,
		@opt_by,
		@opt_dtime,
		@start_dtime,
		@end_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
