IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_acs_SyncRightRole2User]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_acs_SyncRightRole2User]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_acs_SyncRightRole2User]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE proc [stp_acs_SyncRightRole2User]
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

' 
END
GO
