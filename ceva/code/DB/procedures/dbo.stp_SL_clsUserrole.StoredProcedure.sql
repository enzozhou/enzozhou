/****** Object:  StoredProcedure [dbo].[stp_SL_clsUserrole]    Script Date: 08/15/2011 10:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsUserrole]
as       ----取得clsUserrole的一个列表
begin
	select top 1000 user_code,role_code,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Userrole]
end
GO
