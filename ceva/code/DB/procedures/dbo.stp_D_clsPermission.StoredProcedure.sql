/****** Object:  StoredProcedure [dbo].[stp_D_clsPermission]    Script Date: 08/15/2011 10:53:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsPermission](
	@right_no nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[Permission]
	where 	right_no = @right_no 
end
GO
