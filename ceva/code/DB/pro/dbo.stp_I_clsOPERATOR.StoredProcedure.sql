IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsOPERATOR]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_I_clsOPERATOR]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsOPERATOR]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_I_clsOPERATOR]( 
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
' 
END
GO
