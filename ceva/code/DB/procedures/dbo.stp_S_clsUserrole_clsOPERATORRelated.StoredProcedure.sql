/****** Object:  StoredProcedure [dbo].[stp_S_clsUserrole_clsOPERATORRelated]    Script Date: 08/15/2011 10:55:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsUserrole_clsOPERATORRelated](
	@OLD___user_code nvarchar(20)
)
as               ----根据clsOPERATOR的关联字段获得clsUserrole的列表
begin
	select user_code,role_code,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Userrole]
		where 	user_code = @OLD___user_code 
end
GO
