IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsRolepermission]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsRolepermission]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsRolepermission]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsRolepermission](
	@OLD___role_code nvarchar(10),
	@OLD___right_no nvarchar(20)
)
as               ----根据关键字取得clsRolepermission记录
begin
	select role_code,right_no,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Rolepermission]
		where 	role_code = @OLD___role_code and
			right_no = @OLD___right_no 
end
' 
END
GO
