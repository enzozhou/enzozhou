/****** Object:  StoredProcedure [dbo].[stp_D_clscityairport]    Script Date: 08/15/2011 10:53:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clscityairport](
	@destination nvarchar(10),
	@type nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[cityairport]
	where 	destination = @destination and
		type = @type 
end
GO
