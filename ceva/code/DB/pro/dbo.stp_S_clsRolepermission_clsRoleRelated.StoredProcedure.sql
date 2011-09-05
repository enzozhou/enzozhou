IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsRolepermission_clsRoleRelated]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsRolepermission_clsRoleRelated]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsRolepermission_clsRoleRelated]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsRolepermission_clsRoleRelated](
	@OLD___role_code nvarchar(10)
)
as               ----根据clsRole的关联字段获得clsRolepermission的列表
begin
	select role_code,right_no,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Rolepermission]
		where 	role_code = @OLD___role_code 
end
' 
END
GO
