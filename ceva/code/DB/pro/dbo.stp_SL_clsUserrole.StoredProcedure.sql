IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsUserrole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_SL_clsUserrole]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsUserrole]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_SL_clsUserrole]
as       ----取得clsUserrole的一个列表
begin
	select top 1000 user_code,role_code,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Userrole]
end
' 
END
GO
