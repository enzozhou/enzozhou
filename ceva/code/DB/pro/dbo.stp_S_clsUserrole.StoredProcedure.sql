IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsUserrole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsUserrole]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsUserrole]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsUserrole](
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
' 
END
GO
