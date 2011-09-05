/****** Object:  StoredProcedure [dbo].[stp_S_clstasklist_clstaskhdrRelated]    Script Date: 08/15/2011 10:55:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clstasklist_clstaskhdrRelated](
	@OLD___task_id nvarchar(20),
	@OLD___dc_code nvarchar(10)
)
as               ----根据clstaskhdr的关联字段获得clstasklist的列表
begin
	select task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp,dc_code,status_code
		from [dbo].[tasklist]
		where 	task_id = @OLD___task_id and
			dc_code = @OLD___dc_code 
end
GO
