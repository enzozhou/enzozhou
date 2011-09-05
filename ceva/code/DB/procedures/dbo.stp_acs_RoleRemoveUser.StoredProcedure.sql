/****** Object:  StoredProcedure [dbo].[stp_acs_RoleRemoveUser]    Script Date: 08/15/2011 10:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[stp_acs_RoleRemoveUser]
(
    @role_code varchar(10),
    @user_code varchar(20),
    @opt_by nvarchar(20)
)
as
begin
    set nocount on
    --删除用户角色
    delete userrole where role_code=@role_code and user_code=@user_code
    --删除用户角色
    delete Userpermission where user_code=@user_code 
                            and right_no not in (select right_no 
                                                   from Rolepermission 
                                                   where role_code in (select role_code 
                                                                        from userrole 
                                                                        where user_code = @user_code))
end
GO
