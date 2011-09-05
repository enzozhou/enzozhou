IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clstasklin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clstasklin]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clstasklin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clstasklin](
	@OLD___rowid nvarchar(10),
	@OLD___dc_code nvarchar(10),
	@OLD___wh_code nvarchar(10),
	@OLD___task_id nvarchar(20),
	@OLD___bin_area nvarchar(10)
)
as               ----根据关键字取得clstasklin记录
begin
	select rowid,dc_code,wh_code,task_id,bch_no,dn_no,bin_area,bin_code,sku_no,sno,type,qty,status_code,close_auto,print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[tasklin]
		where 	rowid = @OLD___rowid and
			dc_code = @OLD___dc_code and
			wh_code = @OLD___wh_code and
			task_id = @OLD___task_id and
			bin_area = @OLD___bin_area 
end
' 
END
GO
