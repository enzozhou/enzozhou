/****** Object:  StoredProcedure [dbo].[stp_S_clsUserpermission_clsOPERATORRelated]    Script Date: 08/15/2011 10:55:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsUserpermission_clsOPERATORRelated](
	@OLD___user_code nvarchar(20)
)
as               ----根据clsOPERATOR的关联字段获得clsUserpermission的列表
begin
	select user_code,right_no,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Userpermission]
		where 	user_code = @OLD___user_code 
end
GO
