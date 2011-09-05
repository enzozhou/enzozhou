IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsOPERATOR02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_U_clsOPERATOR02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsOPERATOR02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_U_clsOPERATOR02]( 
	@OLD___user_code nvarchar(20),
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
as               ----更新02
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[OPERATOR]
		where user_code = @OLD___user_code 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	exec  stp_U_clsOPERATOR
		@OLD___user_code = @OLD___user_code,
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
' 
END
GO
