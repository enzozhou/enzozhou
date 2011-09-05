IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsTRLOG02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_D_clsTRLOG02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsTRLOG02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_D_clsTRLOG02](
	@log_id bigint,
	@OPT_TIMESTAMP timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clsTRLOG
		@log_id = @log_id,
		@OPT_TIMESTAMP = @OPT_TIMESTAMP,
		@stroptby = stroptby

end
' 
END
GO
