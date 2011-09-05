/****** Object:  StoredProcedure [dbo].[stp_D_clsUserrole]    Script Date: 08/15/2011 10:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsUserrole](
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
GO
