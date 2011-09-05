/****** Object:  StoredProcedure [dbo].[stp_D_clsUserpermission02]    Script Date: 08/15/2011 10:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsUserpermission02](
	@user_code nvarchar(20),
	@right_no nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clsUserpermission
		@user_code = @user_code,
		@right_no = @right_no,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby

end
GO
