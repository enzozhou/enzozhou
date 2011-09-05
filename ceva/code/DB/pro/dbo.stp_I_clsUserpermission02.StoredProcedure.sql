IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsUserpermission02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_I_clsUserpermission02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsUserpermission02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_I_clsUserpermission02]( 
	@user_code nvarchar(20),
	@right_no nvarchar(20),
	@remark ntext,
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
exec stp_I_clsUserpermission
	@user_code = @user_code,
	@right_no = @right_no,
	@remark = @remark,
	@opt_by = @opt_by,
	@opt_dtime = @opt_dtime,
	@opt_timestamp = @opt_timestamp output
end
' 
END
GO
