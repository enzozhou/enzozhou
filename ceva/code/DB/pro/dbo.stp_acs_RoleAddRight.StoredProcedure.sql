IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_acs_RoleAddRight]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_acs_RoleAddRight]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_acs_RoleAddRight]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE proc [stp_acs_RoleAddRight]
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
        insert into rolepermission(role_code,right_no,Remark,opt_by,opt_dtime) values(@role_code,@right_code,'''',@opt_by,getdate())
   --给此角色下的所有用户插入此权限
	insert into userpermission(user_code,right_no,opt_by,opt_dtime)
		select user_code,@right_code,@opt_by,@today from userrole where role_code=@role_code
end


' 
END
GO
