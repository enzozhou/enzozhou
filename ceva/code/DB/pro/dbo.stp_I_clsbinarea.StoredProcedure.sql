IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsbinarea]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_I_clsbinarea]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsbinarea]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_I_clsbinarea]( 
	@dc_code nvarchar(10),
	@bin_area nvarchar(10),
	@description nvarchar(50),
	@wh_code nvarchar(10),
	@seq nchar(3),
	@address nvarchar(50),
	@person nvarchar(50),
	@tel nvarchar(20),
	@fax nvarchar(20),
	@zip nchar(6),
	@dif_sku bit,
	@dif_status bit,
	@dif_owner bit,
	@define1 nvarchar(50),
	@define2 nvarchar(50),
	@define3 nvarchar(50),
	@define4 nvarchar(50),
	@define5 nvarchar(50),
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
		wh_code,
		seq,
		address,
		person,
		tel,
		fax,
		zip,
		dif_sku,
		dif_status,
		dif_owner,
		define1,
		define2,
		define3,
		define4,
		define5,
		opt_by,
		opt_dtime)
	values(
		@dc_code,
		@bin_area,
		@description,
		@wh_code,
		@seq,
		@address,
		@person,
		@tel,
		@fax,
		@zip,
		@dif_sku,
		@dif_status,
		@dif_owner,
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
