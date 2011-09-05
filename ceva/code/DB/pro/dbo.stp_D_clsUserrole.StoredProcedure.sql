IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsUserrole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_D_clsUserrole]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsUserrole]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_D_clsUserrole](
	@user_code nvarchar(20),
	@role_code nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[Userrole]
	where 	user_code = @user_code and
		role_code = @role_code 
end
' 
END
GO
