IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clstasklist]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_U_clstasklist]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clstasklist]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_U_clstasklist]( 
	@OLD___dc_code nvarchar(10),
	@OLD___wh_code nvarchar(10),
	@OLD___task_id nvarchar(20),
	@OLD___bch_no nvarchar(20),
	@OLD___dn_no nvarchar(20),
	@OLD___assigned_opt nvarchar(20),
	@OLD___bin_area nvarchar(10),
	@OLD___bin_code nvarchar(10),
	@OLD___sku_no nvarchar(20),
	@dc_code nvarchar(10),
	@wh_code nvarchar(10),
	@task_id nvarchar(20),
	@bch_no nvarchar(20),
	@dn_no nvarchar(20),
	@assigned_opt nvarchar(20),
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
as           ----更新
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[tasklist]
		where dc_code = @OLD___dc_code and
		wh_code = @OLD___wh_code and
		task_id = @OLD___task_id and
		bch_no = @OLD___bch_no and
		dn_no = @OLD___dn_no and
		assigned_opt = @OLD___assigned_opt and
		bin_area = @OLD___bin_area and
		bin_code = @OLD___bin_code and
		sku_no = @OLD___sku_no 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	update [dbo].[tasklist] set 
		dc_code = @dc_code,
		wh_code = @wh_code,
		task_id = @task_id,
		bch_no = @bch_no,
		dn_no = @dn_no,
		assigned_opt = @assigned_opt,
		bin_area = @bin_area,
		bin_code = @bin_code,
		sku_no = @sku_no,
		qty = @qty,
		type = @type,
		status_code = @status_code,
		close_auto = @close_auto,
		print_by = @print_by,
		print_counter = @print_counter,
		print_dtime = @print_dtime,
		locked = @locked,
		opt_by = @opt_by,
		opt_dtime = @opt_dtime,
		start_dtime = @start_dtime,
		end_dtime = @end_dtime
		where dc_code = @OLD___dc_code and
		wh_code = @OLD___wh_code and
		task_id = @OLD___task_id and
		bch_no = @OLD___bch_no and
		dn_no = @OLD___dn_no and
		assigned_opt = @OLD___assigned_opt and
		bin_area = @OLD___bin_area and
		bin_code = @OLD___bin_code and
		sku_no = @OLD___sku_no 

	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
' 
END
GO
