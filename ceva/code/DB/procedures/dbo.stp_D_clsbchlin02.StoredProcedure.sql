/****** Object:  StoredProcedure [dbo].[stp_D_clsbchlin02]    Script Date: 08/15/2011 10:53:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsbchlin02](
	@dc_code nvarchar(10),
	@bch_no nvarchar(20),
	@dn_no nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clsbchlin
		@dc_code = @dc_code,
		@bch_no = @bch_no,
		@dn_no = @dn_no,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby

end
GO
