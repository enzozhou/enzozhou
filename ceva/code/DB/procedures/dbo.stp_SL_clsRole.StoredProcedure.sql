/****** Object:  StoredProcedure [dbo].[stp_SL_clsRole]    Script Date: 08/15/2011 10:55:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsRole]
as       ----取得clsRole的一个列表
begin
	select top 1000 role_code,role_name,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Role]
end
GO
