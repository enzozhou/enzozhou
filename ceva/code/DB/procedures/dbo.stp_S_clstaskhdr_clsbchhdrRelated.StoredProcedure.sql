/****** Object:  StoredProcedure [dbo].[stp_S_clstaskhdr_clsbchhdrRelated]    Script Date: 08/15/2011 10:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clstaskhdr_clsbchhdrRelated](
	@OLD___dc_code nvarchar(10),
	@OLD___bch_no nvarchar(20)
)
as               ----根据clsbchhdr的关联字段获得clstaskhdr的列表
begin
	select dc_code,task_id,bch_no,status_code,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[taskhdr]
		where 	dc_code = @OLD___dc_code and
			bch_no = @OLD___bch_no 
end
GO
