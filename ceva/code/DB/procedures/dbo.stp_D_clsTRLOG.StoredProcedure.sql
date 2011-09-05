/****** Object:  StoredProcedure [dbo].[stp_D_clsTRLOG]    Script Date: 08/15/2011 10:54:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsTRLOG](
	@log_id bigint,
	@OPT_TIMESTAMP timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[TRLOG]
	where 	log_id = @log_id 
end
GO
