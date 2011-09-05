/****** Object:  StoredProcedure [dbo].[stp_I_clsRole]    Script Date: 08/15/2011 10:54:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsRole]( 
	@role_code nvarchar(10),
	@role_name nvarchar(50),
	@remark ntext,
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
	insert into [dbo].[Role]( 
		role_code,
		role_name,
		remark,
		opt_by,
		opt_dtime)
	values(
		@role_code,
		@role_name,
		@remark,
		@opt_by,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
