/****** Object:  StoredProcedure [dbo].[stp_SL_clsOPERATOR]    Script Date: 08/15/2011 10:55:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsOPERATOR]
as       ----取得clsOPERATOR的一个列表
begin
	select top 1000 user_code,user_name,password,STCD,allowlogin,isadmin,title,tel,fax,mobile,email,create_date,update_date,opt_by,opt_dtime,opt_timestamp
		from [dbo].[OPERATOR]
end
GO
