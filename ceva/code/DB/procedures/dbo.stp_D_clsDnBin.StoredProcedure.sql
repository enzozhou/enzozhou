/****** Object:  StoredProcedure [dbo].[stp_D_clsDnBin]    Script Date: 08/15/2011 10:53:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsDnBin](
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
	delete from [dbo].[DnBin]
	where 	dc_code = @dc_code and
		dn_no = @dn_no and
		bin_area = @bin_area and
		bin_code = @bin_code and
		bch_no = @bch_no 
end
GO
