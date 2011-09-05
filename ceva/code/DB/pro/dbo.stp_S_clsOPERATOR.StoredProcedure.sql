IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsOPERATOR]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsOPERATOR]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsOPERATOR]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsOPERATOR](
	@OLD___user_code nvarchar(20)
)
as               ----根据关键字取得clsOPERATOR记录
begin
	select user_code,user_name,password,STCD,allowlogin,isadmin,title,tel,fax,mobile,email,create_date,update_date,opt_by,opt_dtime,opt_timestamp
		from [dbo].[OPERATOR]
		where 	user_code = @OLD___user_code 
end
' 
END
GO
