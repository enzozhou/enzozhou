/****** Object:  StoredProcedure [dbo].[stp_D_clsOPERATOR]    Script Date: 08/15/2011 10:53:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsOPERATOR](
	@user_code nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[OPERATOR]
	where 	user_code = @user_code 
end
GO
