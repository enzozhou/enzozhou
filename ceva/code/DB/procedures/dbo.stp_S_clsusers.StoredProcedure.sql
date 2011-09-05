/****** Object:  StoredProcedure [dbo].[stp_S_clsusers]    Script Date: 08/15/2011 10:55:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsusers](
	@OLD___uid VarChar(20)
)
as               ----根据关键字取得clsusers记录
begin
	select uid,uname,pwd,phone,email,gender,roleType
		from [dbo].[users]
		where 	uid = @OLD___uid 
end
GO
