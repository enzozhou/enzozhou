/****** Object:  StoredProcedure [dbo].[stp_I_clscityairport]    Script Date: 08/15/2011 10:54:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clscityairport]( 
	@destination nvarchar(10),
	@province nvarchar(10),
	@transit nvarchar(10),
	@type nvarchar(10),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
	insert into [dbo].[cityairport]( 
		destination,
		province,
		transit,
		type,
		opt_dtime)
	values(
		@destination,
		@province,
		@transit,
		@type,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
