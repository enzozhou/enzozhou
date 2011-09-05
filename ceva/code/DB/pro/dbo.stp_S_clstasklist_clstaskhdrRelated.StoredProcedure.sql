IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clstasklist_clstaskhdrRelated]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clstasklist_clstaskhdrRelated]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clstasklist_clstaskhdrRelated]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clstasklist_clstaskhdrRelated](
	@OLD___dc_code nvarchar(10),
	@OLD___wh_code nvarchar(10),
	@OLD___task_id nvarchar(20)
)
as               ----根据clstaskhdr的关联字段获得clstasklist的列表
begin
	select dc_code,wh_code,task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,sku_no,qty,type,status_code,close_auto,print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[tasklist]
		where 	dc_code = @OLD___dc_code and
			wh_code = @OLD___wh_code and
			task_id = @OLD___task_id 
end
' 
END
GO
