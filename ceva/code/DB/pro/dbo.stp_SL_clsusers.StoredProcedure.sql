IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsusers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_SL_clsusers]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsusers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_SL_clsusers]
as       ----取得clsusers的一个列表
begin
	select top 1000 uid,uname,pwd,phone,email,gender,roleType
		from [dbo].[users]
end
' 
END
GO
