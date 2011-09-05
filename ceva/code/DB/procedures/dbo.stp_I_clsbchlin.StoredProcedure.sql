/****** Object:  StoredProcedure [dbo].[stp_I_clsbchlin]    Script Date: 08/15/2011 10:54:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsbchlin]( 
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
	insert into [dbo].[bchlin]( 
		dc_code,
		bch_no,
		dn_no,
		status_code,
		locked,
		opt_by,
		opt_dtime,
		start_dtime,
		end_dtime)
	values(
		@dc_code,
		@bch_no,
		@dn_no,
		@status_code,
		@locked,
		@opt_by,
		@opt_dtime,
		@start_dtime,
		@end_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
