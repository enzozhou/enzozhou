/****** Object:  StoredProcedure [dbo].[stp_D_clsbinarea]    Script Date: 08/15/2011 10:53:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsbinarea](
	@dc_code nvarchar(10),
	@bin_area nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[binarea]
	where 	dc_code = @dc_code and
		bin_area = @bin_area 
end
GO
