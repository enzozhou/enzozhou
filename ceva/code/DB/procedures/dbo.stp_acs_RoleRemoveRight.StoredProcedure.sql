/****** Object:  StoredProcedure [dbo].[stp_acs_RoleRemoveRight]    Script Date: 08/15/2011 10:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[stp_acs_RoleRemoveRight]
(
    @role_code varchar(10),
    @right_no varchar(20),
    @opt_by nvarchar(20)
)
as
begin
    set nocount on
    --为角色删除此权限
    delete Rolepermission where role_code=@role_code and right_no=@right_no
    --删除属于此角色的用户的权限但排除用户在其他角色里拥有相同的权限
    delete Userpermission where right_no=@right_no 
                            and user_code in (select user_code 
                                                   from userrole 
                                                   where role_code = @role_code )
                            and right_no not in (select right_no 
                                                   from Rolepermission
                                                  where user_code in (select user_code 
                                                                        from userrole 
                                                                       where role_code = @role_code )
                                                        and role_code != @role_code)
end
GO
