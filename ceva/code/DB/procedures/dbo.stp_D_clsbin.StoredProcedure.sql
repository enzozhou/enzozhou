/****** Object:  StoredProcedure [dbo].[stp_D_clsbin]    Script Date: 08/15/2011 10:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsbin](
	@dc_code nvarchar(10),
	@bin_code nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[bin]
	where 	dc_code = @dc_code and
		bin_code = @bin_code 
end
GO
