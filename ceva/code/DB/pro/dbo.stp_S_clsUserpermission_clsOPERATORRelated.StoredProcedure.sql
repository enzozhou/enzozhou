IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsUserpermission_clsOPERATORRelated]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsUserpermission_clsOPERATORRelated]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsUserpermission_clsOPERATORRelated]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsUserpermission_clsOPERATORRelated](
	@OLD___user_code nvarchar(20)
)
as               ----根据clsOPERATOR的关联字段获得clsUserpermission的列表
begin
	select user_code,right_no,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Userpermission]
		where 	user_code = @OLD___user_code 
end
' 
END
GO
