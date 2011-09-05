/****** Object:  StoredProcedure [dbo].[stp_I_clsbinStatus02]    Script Date: 08/15/2011 10:54:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsbinStatus02]( 
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
exec stp_I_clsbinStatus
	@dc_code = @dc_code,
	@id = @id output,
	@bin_area = @bin_area,
	@bin_code = @bin_code,
	@dn_no = @dn_no,
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
GO
