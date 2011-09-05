/****** Object:  StoredProcedure [dbo].[stp_U_clsUserpermission]    Script Date: 08/15/2011 10:55:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clsUserpermission]( 
	@OLD___user_code nvarchar(20),
	@OLD___right_no nvarchar(20),
	@user_code nvarchar(20),
	@right_no nvarchar(20),
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
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[Userpermission]
		where user_code = @OLD___user_code and
		right_no = @OLD___right_no 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	update [dbo].[Userpermission] set 
		user_code = @user_code,
		right_no = @right_no,
		remark = @remark,
		opt_by = @opt_by,
		opt_dtime = @opt_dtime
		where user_code = @OLD___user_code and
		right_no = @OLD___right_no 

	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
