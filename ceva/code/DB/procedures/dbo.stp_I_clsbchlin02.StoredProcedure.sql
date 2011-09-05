/****** Object:  StoredProcedure [dbo].[stp_I_clsbchlin02]    Script Date: 08/15/2011 10:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsbchlin02]( 
	@dc_code nvarchar(10),
	@bch_no nvarchar(20),
	@dn_no nvarchar(20),
	@status_code nchar(5),
	@locked int,
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@start_dtime datetime,
	@end_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
exec stp_I_clsbchlin
	@dc_code = @dc_code,
	@bch_no = @bch_no,
	@dn_no = @dn_no,
	@status_code = @status_code,
	@locked = @locked,
	@opt_by = @opt_by,
	@opt_dtime = @opt_dtime,
	@start_dtime = @start_dtime,
	@end_dtime = @end_dtime,
	@opt_timestamp = @opt_timestamp output
end
GO
