/****** Object:  StoredProcedure [dbo].[stp_I_clsDnBin]    Script Date: 08/15/2011 10:54:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsDnBin]( 
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
	insert into [dbo].[DnBin]( 
		rowid,
		dc_code,
		dn_no,
		bin_area,
		bin_code,
		status_code,
		opt_by,
		opt_dtime,
		start_dtime,
		end_dtime,
		bch_no)
	values(
		@rowid,
		@dc_code,
		@dn_no,
		@bin_area,
		@bin_code,
		@status_code,
		@opt_by,
		@opt_dtime,
		@start_dtime,
		@end_dtime,
		@bch_no
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
