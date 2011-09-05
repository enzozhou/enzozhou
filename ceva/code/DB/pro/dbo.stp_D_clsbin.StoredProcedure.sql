IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsbin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_D_clsbin]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsbin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_D_clsbin](
	@dc_code nvarchar(10),
	@bin_code nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[bin]
	where 	dc_code = @dc_code and
		bin_code = @bin_code 
end
' 
END
GO
