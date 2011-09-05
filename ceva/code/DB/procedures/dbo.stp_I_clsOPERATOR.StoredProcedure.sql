/****** Object:  StoredProcedure [dbo].[stp_I_clsOPERATOR]    Script Date: 08/15/2011 10:54:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsOPERATOR]( 
	@user_code nvarchar(20),
	@user_name nvarchar(50),
	@password nvarchar(20),
	@STCD nvarchar(6),
	@allowlogin bit,
	@isadmin bit,
	@title nvarchar(50),
	@tel nvarchar(20),
	@fax nvarchar(20),
	@mobile nvarchar(20),
	@email nvarchar(50),
	@create_date datetime,
	@update_date datetime,
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
	insert into [dbo].[OPERATOR]( 
		user_code,
		user_name,
		password,
		STCD,
		allowlogin,
		isadmin,
		title,
		tel,
		fax,
		mobile,
		email,
		create_date,
		update_date,
		opt_by,
		opt_dtime)
	values(
		@user_code,
		@user_name,
		@password,
		@STCD,
		@allowlogin,
		@isadmin,
		@title,
		@tel,
		@fax,
		@mobile,
		@email,
		@create_date,
		@update_date,
		@opt_by,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
