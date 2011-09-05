/****** Object:  StoredProcedure [dbo].[stp_I_clsbinarea02]    Script Date: 08/15/2011 10:54:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsbinarea02]( 
	@dc_code nvarchar(10),
	@bin_area nvarchar(10),
	@description nvarchar(50),
	@opt_by nvarchar(50),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
exec stp_I_clsbinarea
	@dc_code = @dc_code,
	@bin_area = @bin_area,
	@description = @description,
	@opt_by = @opt_by,
	@opt_dtime = @opt_dtime,
	@opt_timestamp = @opt_timestamp output
end
GO
