/****** Object:  StoredProcedure [dbo].[stp_I_clstasklin]    Script Date: 08/15/2011 10:54:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clstasklin]( 
	@rowid nvarchar(10),
	@dc_code nvarchar(10),
	@task_id nvarchar(20),
	@bch_no nvarchar(20),
	@dn_no nvarchar(20),
	@bin_area nvarchar(10),
	@bin_code nvarchar(10),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@start_dtime datetime,
	@end_dtime datetime,
	@opt_timestamp timestamp output,
	@sku_no nvarchar(20),
	@sno nvarchar(20),
	@qty numeric(12,3)
)
as 
begin
	insert into [dbo].[tasklin]( 
		rowid,
		dc_code,
		task_id,
		bch_no,
		dn_no,
		bin_area,
		bin_code,
		opt_by,
		opt_dtime,
		start_dtime,
		end_dtime,
		sku_no,
		sno,
		qty)
	values(
		@rowid,
		@dc_code,
		@task_id,
		@bch_no,
		@dn_no,
		@bin_area,
		@bin_code,
		@opt_by,
		@opt_dtime,
		@start_dtime,
		@end_dtime,
		@sku_no,
		@sno,
		@qty
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
