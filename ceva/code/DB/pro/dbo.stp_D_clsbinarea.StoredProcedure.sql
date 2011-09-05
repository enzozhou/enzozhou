IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsbinarea]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_D_clsbinarea]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsbinarea]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_D_clsbinarea](
	@dc_code nvarchar(10),
	@bin_area nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[binarea]
	where 	dc_code = @dc_code and
		bin_area = @bin_area 
end
' 
END
GO
