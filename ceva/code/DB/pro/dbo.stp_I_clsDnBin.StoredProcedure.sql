IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsDnBin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_I_clsDnBin]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsDnBin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_I_clsDnBin]( 
	@rowid nvarchar(10),
	@dc_code nvarchar(10),
	@bch_no nvarchar(10),
	@wh_code nvarchar(10),
	@dn_no nvarchar(20),
	@bin_area nvarchar(10),
	@bin_code nvarchar(10),
	@sku_no nvarchar(20),
	@qty numeric(12,3),
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
	insert into [dbo].[DnBin]( 
		rowid,
		dc_code,
		bch_no,
		wh_code,
		dn_no,
		bin_area,
		bin_code,
		sku_no,
		qty,
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
		@rowid,
		@dc_code,
		@bch_no,
		@wh_code,
		@dn_no,
		@bin_area,
		@bin_code,
		@sku_no,
		@qty,
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
	
	
end
' 
END
GO
