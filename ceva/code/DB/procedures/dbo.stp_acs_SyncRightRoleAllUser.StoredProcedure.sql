/****** Object:  StoredProcedure [dbo].[stp_acs_SyncRightRoleAllUser]    Script Date: 08/15/2011 10:53:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[stp_acs_SyncRightRoleAllUser]
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
GO
