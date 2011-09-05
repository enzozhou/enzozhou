/****** Object:  StoredProcedure [dbo].[stp_S_clsUserrole]    Script Date: 08/15/2011 10:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsUserrole](
	@OLD___user_code nvarchar(20),
	@OLD___role_code nvarchar(10)
)
as               ----根据关键字取得clsUserrole记录
begin
	select user_code,role_code,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Userrole]
		where 	user_code = @OLD___user_code and
			role_code = @OLD___role_code 
end
GO
