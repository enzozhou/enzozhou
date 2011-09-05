/****** Object:  StoredProcedure [dbo].[stp_I_clsUserrole]    Script Date: 08/15/2011 10:54:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsUserrole]( 
	@user_code nvarchar(20),
	@role_code nvarchar(10),
	@remark ntext,
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
	insert into [dbo].[Userrole]( 
		user_code,
		role_code,
		remark,
		opt_by,
		opt_dtime)
	values(
		@user_code,
		@role_code,
		@remark,
		@opt_by,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
