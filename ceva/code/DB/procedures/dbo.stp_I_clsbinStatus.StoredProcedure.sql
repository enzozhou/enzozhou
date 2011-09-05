/****** Object:  StoredProcedure [dbo].[stp_I_clsbinStatus]    Script Date: 08/15/2011 10:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsbinStatus]( 
	@dc_code nvarchar(10),
	@id int output,
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
as 
begin
	insert into [dbo].[binStatus]( 
		dc_code,
		bin_area,
		bin_code,
		dn_no,
		type,
		status_code,
		close_auto,
		print_by,
		print_counter,
		print_dtime,
		locked,
		opt_by,
		opt_dtime,
		start_dtime,
		end_dtime)
	values(
		@dc_code,
		@bin_area,
		@bin_code,
		@dn_no,
		@type,
		@status_code,
		@close_auto,
		@print_by,
		@print_counter,
		@print_dtime,
		@locked,
		@opt_by,
		@opt_dtime,
		@start_dtime,
		@end_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	select @id = @@IDENTITY
	
end
GO
