/****** Object:  StoredProcedure [dbo].[stp_I_clsbin]    Script Date: 08/15/2011 10:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsbin]( 
	@dc_code nvarchar(10),
	@bin_code nvarchar(10),
	@description nvarchar(50),
	@bin_area nvarchar(10),
	@length numeric(12,3),
	@width numeric(12,3),
	@weight numeric(12,3),
	@volume numeric(20,9),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
	insert into [dbo].[bin]( 
		dc_code,
		bin_code,
		[description],
		bin_area,
		length,
		width,
		weight,
		volume,
		opt_by,
		opt_dtime)
	values(
		@dc_code,
		@bin_code,
		@description,
		@bin_area,
		@length,
		@width,
		@weight,
		@volume,
		@opt_by,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
