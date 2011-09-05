/****** Object:  StoredProcedure [dbo].[stp_S_clstasklist]    Script Date: 08/15/2011 10:55:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clstasklist](
	@OLD___task_id nvarchar(20),
	@OLD___bch_no nvarchar(20),
	@OLD___dn_no nvarchar(20),
	@OLD___assigned_opt nvarchar(20),
	@OLD___dc_code nvarchar(10)
)
as               ----根据关键字取得clstasklist记录
begin
	select task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp,dc_code,status_code
		from [dbo].[tasklist]
		where 	task_id = @OLD___task_id and
			bch_no = @OLD___bch_no and
			dn_no = @OLD___dn_no and
			assigned_opt = @OLD___assigned_opt and
			dc_code = @OLD___dc_code 
end
GO
