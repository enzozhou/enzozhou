/****** Object:  StoredProcedure [dbo].[stp_U_clsUserrole]    Script Date: 08/15/2011 10:55:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clsUserrole]( 
	@OLD___user_code nvarchar(20),
	@OLD___role_code nvarchar(10),
	@user_code nvarchar(20),
	@role_code nvarchar(10),
	@remark ntext,
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as           ----更新
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[Userrole]
		where user_code = @OLD___user_code and
		role_code = @OLD___role_code 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	update [dbo].[Userrole] set 
		user_code = @user_code,
		role_code = @role_code,
		remark = @remark,
		opt_by = @opt_by,
		opt_dtime = @opt_dtime
		where user_code = @OLD___user_code and
		role_code = @OLD___role_code 

	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
