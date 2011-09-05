IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_acs_RoleAddUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_acs_RoleAddUser]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_acs_RoleAddUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create proc [stp_acs_RoleAddUser]
(
    @role_code varchar(10),
    @user_code varchar(20),
    @opt_by nvarchar(20)
)
as
begin
    set nocount on

    if not exists(select 1 from userrole where role_code=@role_code and user_code=@user_code)
        insert into userrole(user_code,role_code,Remark,opt_by,opt_dtime) values(@user_code,@role_code,'''',@opt_by,getdate())

    exec stp_acs_SyncRightRole2User @user_code,@opt_by


end

' 
END
GO
