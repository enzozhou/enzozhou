/****** Object:  StoredProcedure [dbo].[stp_D_clstasklin]    Script Date: 08/15/2011 10:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[stp_D_clstasklin](
	@rowid nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[tasklin]
	where 	rowid = @rowid 
end
GO
