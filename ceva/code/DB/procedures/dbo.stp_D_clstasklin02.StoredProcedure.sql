/****** Object:  StoredProcedure [dbo].[stp_D_clstasklin02]    Script Date: 08/15/2011 10:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clstasklin02](
	@rowid nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clstasklin
		@rowid = @rowid,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby

end
GO
