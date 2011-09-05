/****** Object:  StoredProcedure [dbo].[stp_D_clsbchhdr02]    Script Date: 08/15/2011 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsbchhdr02](
	@dc_code nvarchar(10),
	@bch_no nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clsbchhdr
		@dc_code = @dc_code,
		@bch_no = @bch_no,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby

end
GO
