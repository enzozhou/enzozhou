/****** Object:  StoredProcedure [dbo].[stp_D_clsusers02]    Script Date: 08/15/2011 10:54:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsusers02](
	@uid VarChar(20),
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clsusers
		@uid = @uid,
		@stroptby = stroptby

end
GO
