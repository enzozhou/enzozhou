IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsbin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_I_clsbin]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsbin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_I_clsbin]( 
	@dc_code nvarchar(10),
	@bin_code nvarchar(10),
	@description nvarchar(50),
	@wh_code nvarchar(10),
	@bin_type nvarchar(10),
	@bin_area nvarchar(10),
	@area numeric(12,3),
	@palls numeric(12,3),
	@length numeric(12,3),
	@width numeric(12,3),
	@weight numeric(12,3),
	@volume numeric(20,9),
	@canpick bit,
	@isblocked bit,
	@define1 nvarchar(50),
	@define2 nvarchar(50),
	@define3 nvarchar(50),
	@define4 nvarchar(50),
	@define5 nvarchar(50),
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
		wh_code,
		bin_type,
		bin_area,
		area,
		palls,
		length,
		width,
		weight,
		volume,
		canpick,
		isblocked,
		define1,
		define2,
		define3,
		define4,
		define5,
		opt_by,
		opt_dtime)
	values(
		@dc_code,
		@bin_code,
		@description,
		@wh_code,
		@bin_type,
		@bin_area,
		@area,
		@palls,
		@length,
		@width,
		@weight,
		@volume,
		@canpick,
		@isblocked,
		@define1,
		@define2,
		@define3,
		@define4,
		@define5,
		@opt_by,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
' 
END
GO
