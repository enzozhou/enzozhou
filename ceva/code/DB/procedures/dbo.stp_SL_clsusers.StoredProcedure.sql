/****** Object:  StoredProcedure [dbo].[stp_SL_clsusers]    Script Date: 08/15/2011 10:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsusers]
as       ----取得clsusers的一个列表
begin
	select top 1000 uid,uname,pwd,phone,email,gender,roleType
		from [dbo].[users]
end
GO
