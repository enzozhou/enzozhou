/****** Object:  StoredProcedure [dbo].[stp_S_clstaskhdr]    Script Date: 08/15/2011 10:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clstaskhdr](
	@OLD___dc_code nvarchar(10),
	@OLD___task_id nvarchar(20)
)
as               ----根据关键字取得clstaskhdr记录
begin
	select dc_code,task_id,bch_no,dn_no,status_code,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[taskhdr]
		where 	dc_code = @OLD___dc_code and
			task_id = @OLD___task_id 
end
GO
