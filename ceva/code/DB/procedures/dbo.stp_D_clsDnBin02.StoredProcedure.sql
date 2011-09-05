/****** Object:  StoredProcedure [dbo].[stp_D_clsDnBin02]    Script Date: 08/15/2011 10:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsDnBin02](
	@dc_code nvarchar(10),
	@dn_no nvarchar(20),
	@bin_area nvarchar(10),
	@bin_code nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@bch_no nvarchar(20),
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clsDnBin
		@dc_code = @dc_code,
		@dn_no = @dn_no,
		@bin_area = @bin_area,
		@bin_code = @bin_code,
		@opt_timestamp = @opt_timestamp,
		@bch_no = @bch_no,
		@stroptby = stroptby

end
GO
