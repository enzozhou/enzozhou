/****** Object:  StoredProcedure [dbo].[stp_I_clscityairport02]    Script Date: 08/15/2011 10:54:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clscityairport02]( 
	@destination nvarchar(10),
	@province nvarchar(10),
	@transit nvarchar(10),
	@type nvarchar(10),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
exec stp_I_clscityairport
	@destination = @destination,
	@province = @province,
	@transit = @transit,
	@type = @type,
	@opt_dtime = @opt_dtime,
	@opt_timestamp = @opt_timestamp output
end
GO
