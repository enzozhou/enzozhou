/****** Object:  StoredProcedure [dbo].[stp_U_clsRolepermission02]    Script Date: 08/15/2011 10:55:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clsRolepermission02]( 
	@OLD___role_code nvarchar(10),
	@OLD___right_no nvarchar(20),
	@role_code nvarchar(10),
	@right_no nvarchar(20),
	@remark ntext,
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as               ----更新02
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[Rolepermission]
		where role_code = @OLD___role_code and
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
	exec  stp_U_clsRolepermission
		@OLD___role_code = @OLD___role_code,
		@OLD___right_no = @OLD___right_no,
		@role_code = @role_code,
		@right_no = @right_no,
		@remark = @remark,
		@opt_by = @opt_by,
		@opt_dtime = @opt_dtime,
		@opt_timestamp = @opt_timestamp output
end
GO
