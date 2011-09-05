/****** Object:  StoredProcedure [dbo].[stp_I_clsOPERATOR02]    Script Date: 08/15/2011 10:54:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsOPERATOR02]( 
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
exec stp_I_clsOPERATOR
	@user_code = @user_code,
	@user_name = @user_name,
	@password = @password,
	@STCD = @STCD,
	@allowlogin = @allowlogin,
	@isadmin = @isadmin,
	@title = @title,
	@tel = @tel,
	@fax = @fax,
	@mobile = @mobile,
	@email = @email,
	@create_date = @create_date,
	@update_date = @update_date,
	@opt_by = @opt_by,
	@opt_dtime = @opt_dtime,
	@opt_timestamp = @opt_timestamp output
end
GO
