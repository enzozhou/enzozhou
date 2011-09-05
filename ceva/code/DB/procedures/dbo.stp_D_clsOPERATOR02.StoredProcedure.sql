/****** Object:  StoredProcedure [dbo].[stp_D_clsOPERATOR02]    Script Date: 08/15/2011 10:53:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsOPERATOR02](
	@user_code nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clsOPERATOR
		@user_code = @user_code,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby

end
GO
