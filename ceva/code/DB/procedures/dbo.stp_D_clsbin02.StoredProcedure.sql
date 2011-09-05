/****** Object:  StoredProcedure [dbo].[stp_D_clsbin02]    Script Date: 08/15/2011 10:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsbin02](
	@dc_code nvarchar(10),
	@bin_code nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clsbin
		@dc_code = @dc_code,
		@bin_code = @bin_code,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby

end
GO
