IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_SL_clsRole]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsRole]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_SL_clsRole]
as       ----取得clsRole的一个列表
begin
	select top 1000 role_code,role_name,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Role]
end
' 
END
GO
