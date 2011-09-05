/****** Object:  StoredProcedure [dbo].[stp_D_clsPermission02]    Script Date: 08/15/2011 10:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[stp_D_clsPermission02](
	@right_no nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clsPermission
		@right_no = @right_no,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby
    --删除用户，角色的相关权限
    delete Rolepermission where right_no = @right_no
    delete Userpermission where right_no = @right_no
end
GO
