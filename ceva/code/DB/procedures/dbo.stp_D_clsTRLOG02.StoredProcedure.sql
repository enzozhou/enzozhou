/****** Object:  StoredProcedure [dbo].[stp_D_clsTRLOG02]    Script Date: 08/15/2011 10:54:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsTRLOG02](
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
GO
