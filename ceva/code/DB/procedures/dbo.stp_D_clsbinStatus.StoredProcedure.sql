/****** Object:  StoredProcedure [dbo].[stp_D_clsbinStatus]    Script Date: 08/15/2011 10:53:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsbinStatus](
	@dc_code nvarchar(10),
	@id int,
	@bin_area nvarchar(10),
	@bin_code nvarchar(10),
	@dn_no nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[binStatus]
	where 	dc_code = @dc_code and
		id = @id and
		bin_area = @bin_area and
		bin_code = @bin_code and
		dn_no = @dn_no 
end
GO
