/****** Object:  StoredProcedure [dbo].[stp_S_clsOPERATOR]    Script Date: 08/15/2011 10:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsOPERATOR](
	@OLD___user_code nvarchar(20)
)
as               ----根据关键字取得clsOPERATOR记录
begin
	select user_code,user_name,password,STCD,allowlogin,isadmin,title,tel,fax,mobile,email,create_date,update_date,opt_by,opt_dtime,opt_timestamp
		from [dbo].[OPERATOR]
		where 	user_code = @OLD___user_code 
end
GO
