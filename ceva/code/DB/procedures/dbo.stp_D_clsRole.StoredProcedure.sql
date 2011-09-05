/****** Object:  StoredProcedure [dbo].[stp_D_clsRole]    Script Date: 08/15/2011 10:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsRole](
	@role_code nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[Role]
	where 	role_code = @role_code 
end
GO
