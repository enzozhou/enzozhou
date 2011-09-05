IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clstasklist]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clstasklist]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clstasklist]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clstasklist](
	@OLD___dc_code nvarchar(10),
	@OLD___wh_code nvarchar(10),
	@OLD___task_id nvarchar(20),
	@OLD___bch_no nvarchar(20),
	@OLD___dn_no nvarchar(20),
	@OLD___assigned_opt nvarchar(20),
	@OLD___bin_area nvarchar(10),
	@OLD___bin_code nvarchar(10),
	@OLD___sku_no nvarchar(20)
)
as               ----根据关键字取得clstasklist记录
begin
	select dc_code,wh_code,task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,sku_no,qty,type,status_code,close_auto,print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[tasklist]
		where 	dc_code = @OLD___dc_code and
			wh_code = @OLD___wh_code and
			task_id = @OLD___task_id and
			bch_no = @OLD___bch_no and
			dn_no = @OLD___dn_no and
			assigned_opt = @OLD___assigned_opt and
			bin_area = @OLD___bin_area and
			bin_code = @OLD___bin_code and
			sku_no = @OLD___sku_no 
end
' 
END
GO
