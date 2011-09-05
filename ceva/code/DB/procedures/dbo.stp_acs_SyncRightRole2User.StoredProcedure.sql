/****** Object:  StoredProcedure [dbo].[stp_acs_SyncRightRole2User]    Script Date: 08/15/2011 10:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[stp_acs_SyncRightRole2User]
(
    @user_code varchar(20),
    @opt_by nvarchar(20)
)
as
begin
    set nocount on
    declare @today datetime
    select @today=getdate()
    --select * from userpermission
    --select * from rolepermission
    --select * from userrole
    insert into userpermission(user_code,right_no,opt_by,opt_dtime)
    select @user_code,right_no,@opt_by,@today from rolepermission where role_code in (select role_code from userrole where user_code=@user_code)
        and not right_no in (select right_no from userpermission where user_code=@user_code)

    delete userpermission where  user_code=@user_code and not right_no in 
        (select right_no from rolepermission where  role_code in (select role_code from userrole where user_code=@user_code))
end
GO
