/****** Object:  StoredProcedure [dbo].[stp_I_clsDnBin02]    Script Date: 08/15/2011 10:54:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsDnBin02]( 
	@rowid nvarchar(10),
	@dc_code nvarchar(10),
	@dn_no nvarchar(20),
	@bin_area nvarchar(10),
	@bin_code nvarchar(10),
	@status_code nchar(5),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@start_dtime datetime,
	@end_dtime datetime,
	@opt_timestamp timestamp output,
	@bch_no nvarchar(20)
)
as 
begin
exec stp_I_clsDnBin
	@rowid = @rowid,
	@dc_code = @dc_code,
	@dn_no = @dn_no,
	@bin_area = @bin_area,
	@bin_code = @bin_code,
	@status_code = @status_code,
	@opt_by = @opt_by,
	@opt_dtime = @opt_dtime,
	@start_dtime = @start_dtime,
	@end_dtime = @end_dtime,
	@opt_timestamp = @opt_timestamp output,
	@bch_no = @bch_no
end
GO
