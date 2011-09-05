/****** Object:  StoredProcedure [dbo].[stp_I_clsbinarea]    Script Date: 08/15/2011 10:54:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsbinarea]( 
	@dc_code nvarchar(10),
	@bin_area nvarchar(10),
	@description nvarchar(50),
	@opt_by nvarchar(50),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
	insert into [dbo].[binarea]( 
		dc_code,
		bin_area,
		[description],
		opt_by,
		opt_dtime)
	values(
		@dc_code,
		@bin_area,
		@description,
		@opt_by,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
