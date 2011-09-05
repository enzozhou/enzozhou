/****** Object:  StoredProcedure [dbo].[stp_I_clsbin02]    Script Date: 08/15/2011 10:54:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsbin02]( 
	@dc_code nvarchar(10),
	@bin_code nvarchar(10),
	@description nvarchar(50),
	@bin_area nvarchar(10),
	@area numeric(12,3),
	@palls numeric(12,3),
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
exec stp_I_clsbin
	@dc_code = @dc_code,
	@bin_code = @bin_code,
	@description = @description,
	@bin_area = @bin_area,
	@area = @area,
	@palls = @palls,
	@length = @length,
	@width = @width,
	@weight = @weight,
	@volume = @volume,
	@opt_by = @opt_by,
	@opt_dtime = @opt_dtime,
	@opt_timestamp = @opt_timestamp output
end
GO
