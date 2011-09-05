IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_acs_SyncRightRoleAllUser]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_acs_SyncRightRoleAllUser]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_acs_SyncRightRoleAllUser]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create proc [stp_acs_SyncRightRoleAllUser]
(
    @role_code varchar(10),
    @opt_by nvarchar(20)
)
as
begin
    --select * from userrole
    declare @user_code nvarchar(20)

    declare usrcur cursor local for select user_code from userrole where role_code=@role_code
    OPEN usrcur
    
    FETCH NEXT FROM usrcur into @user_code
    WHILE @@FETCH_STATUS = 0
    BEGIN
        exec stp_acs_SyncRightRole2User @user_code,@opt_by
        FETCH NEXT FROM usrcur into @user_code
    END
    
    CLOSE usrcur
    DEALLOCATE usrcur
end


' 
END
GO
