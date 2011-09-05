IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsbin02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_I_clsbin02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsbin02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_I_clsbin02]( 
	@dc_code nvarchar(10),
	@bin_code nvarchar(10),
	@description nvarchar(50),
	@wh_code nvarchar(10),
	@bin_type nvarchar(10),
	@bin_area nvarchar(10),
	@area numeric(12,3),
	@palls numeric(12,3),
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
exec stp_I_clsbin
	@dc_code = @dc_code,
	@bin_code = @bin_code,
	@description = @description,
	@wh_code = @wh_code,
	@bin_type = @bin_type,
	@bin_area = @bin_area,
	@area = @area,
	@palls = @palls,
	@weight = @weight,
	@volume = @volume,
	@canpick = @canpick,
	@isblocked = @isblocked,
	@define1 = @define1,
	@define2 = @define2,
	@define3 = @define3,
	@define4 = @define4,
	@define5 = @define5,
	@opt_by = @opt_by,
	@opt_dtime = @opt_dtime,
	@opt_timestamp = @opt_timestamp output
end
' 
END
GO
