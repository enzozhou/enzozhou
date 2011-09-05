/****** Object:  StoredProcedure [dbo].[stp_acs_RoleAddRight]    Script Date: 08/15/2011 10:53:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[stp_acs_RoleAddRight]
(
    @role_code varchar(10),
    @right_code varchar(20),
    @opt_by nvarchar(20)
)
as
begin
    set nocount on
	declare @today datetime
    select @today=getdate()
    --给此角色插入此权限
    if not exists(select 1 from rolepermission where role_code=@role_code and right_no=@right_code)
        insert into rolepermission(role_code,right_no,Remark,opt_by,opt_dtime) values(@role_code,@right_code,'',@opt_by,getdate())
   --给此角色下的所有用户插入此权限
	insert into userpermission(user_code,right_no,opt_by,opt_dtime)
		select user_code,@right_code,@opt_by,@today from userrole where role_code=@role_code
end
GO
