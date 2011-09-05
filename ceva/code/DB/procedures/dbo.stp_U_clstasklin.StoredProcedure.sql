/****** Object:  StoredProcedure [dbo].[stp_U_clstasklin]    Script Date: 08/15/2011 10:55:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clstasklin]( 
	@OLD___rowid nvarchar(10),
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
as           ----更新
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[tasklin]
		where rowid = @OLD___rowid 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	update [dbo].[tasklin] set 
		rowid = @rowid,
		dc_code = @dc_code,
		task_id = @task_id,
		bch_no = @bch_no,
		dn_no = @dn_no,
		bin_area = @bin_area,
		bin_code = @bin_code,
		opt_by = @opt_by,
		opt_dtime = @opt_dtime,
		start_dtime = @start_dtime,
		end_dtime = @end_dtime,
		sku_no = @sku_no,
		sno = @sno,
		qty = @qty
		where rowid = @OLD___rowid 

	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
