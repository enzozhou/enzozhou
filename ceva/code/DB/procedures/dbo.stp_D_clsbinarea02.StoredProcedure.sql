/****** Object:  StoredProcedure [dbo].[stp_D_clsbinarea02]    Script Date: 08/15/2011 10:53:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsbinarea02](
	@dc_code nvarchar(10),
	@bin_area nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clsbinarea
		@dc_code = @dc_code,
		@bin_area = @bin_area,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby

end
GO
