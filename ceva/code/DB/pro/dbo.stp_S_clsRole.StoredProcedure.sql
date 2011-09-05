IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsRole]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsRole]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsRole]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsRole](
	@OLD___role_code nvarchar(10)
)
as               ----根据关键字取得clsRole记录
begin
	select role_code,role_name,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Role]
		where 	role_code = @OLD___role_code 
end
' 
END
GO
