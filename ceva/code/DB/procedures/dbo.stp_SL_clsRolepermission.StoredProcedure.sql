/****** Object:  StoredProcedure [dbo].[stp_SL_clsRolepermission]    Script Date: 08/15/2011 10:55:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsRolepermission]
as       ----取得clsRolepermission的一个列表
begin
	select top 1000 role_code,right_no,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Rolepermission]
end
GO
