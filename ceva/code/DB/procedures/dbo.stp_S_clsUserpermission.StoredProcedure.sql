/****** Object:  StoredProcedure [dbo].[stp_S_clsUserpermission]    Script Date: 08/15/2011 10:55:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsUserpermission](
	@OLD___user_code nvarchar(20),
	@OLD___right_no nvarchar(20)
)
as               ----根据关键字取得clsUserpermission记录
begin
	select user_code,right_no,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Userpermission]
		where 	user_code = @OLD___user_code and
			right_no = @OLD___right_no 
end
GO
