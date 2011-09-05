/****** Object:  StoredProcedure [dbo].[stp_S_clsRolepermission_clsRoleRelated]    Script Date: 08/15/2011 10:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsRolepermission_clsRoleRelated](
	@OLD___role_code nvarchar(10)
)
as               ----根据clsRole的关联字段获得clsRolepermission的列表
begin
	select role_code,right_no,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Rolepermission]
		where 	role_code = @OLD___role_code 
end
GO
