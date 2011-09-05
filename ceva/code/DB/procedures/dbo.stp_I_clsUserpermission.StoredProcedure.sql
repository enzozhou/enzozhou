/****** Object:  StoredProcedure [dbo].[stp_I_clsUserpermission]    Script Date: 08/15/2011 10:54:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsUserpermission]( 
	@user_code nvarchar(20),
	@right_no nvarchar(20),
	@remark ntext,
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
	insert into [dbo].[Userpermission]( 
		user_code,
		right_no,
		remark,
		opt_by,
		opt_dtime)
	values(
		@user_code,
		@right_no,
		@remark,
		@opt_by,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
