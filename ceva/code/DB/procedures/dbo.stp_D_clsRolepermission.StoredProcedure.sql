/****** Object:  StoredProcedure [dbo].[stp_D_clsRolepermission]    Script Date: 08/15/2011 10:53:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsRolepermission](
	@role_code nvarchar(10),
	@right_no nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[Rolepermission]
	where 	role_code = @role_code and
		right_no = @right_no 
end
GO
