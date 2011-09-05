IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsusers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsusers]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsusers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsusers](
	@OLD___uid VarChar(20)
)
as               ----根据关键字取得clsusers记录
begin
	select uid,uname,pwd,phone,email,gender,roleType
		from [dbo].[users]
		where 	uid = @OLD___uid 
end
' 
END
GO
