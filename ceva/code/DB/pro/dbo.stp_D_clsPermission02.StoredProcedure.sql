IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsPermission02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_D_clsPermission02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsPermission02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE procedure [stp_D_clsPermission02](
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
' 
END
GO
