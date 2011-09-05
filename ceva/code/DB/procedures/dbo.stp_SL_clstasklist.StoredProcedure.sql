/****** Object:  StoredProcedure [dbo].[stp_SL_clstasklist]    Script Date: 08/15/2011 10:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clstasklist]
as       ----取得clstasklist的一个列表
begin
	select top 1000 task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp,dc_code,status_code
		from [dbo].[tasklist]
end
GO
