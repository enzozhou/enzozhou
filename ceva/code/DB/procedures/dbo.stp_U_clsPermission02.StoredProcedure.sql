/****** Object:  StoredProcedure [dbo].[stp_U_clsPermission02]    Script Date: 08/15/2011 10:55:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clsPermission02]( 
	@OLD___right_no nvarchar(20),
	@right_no nvarchar(20),
	@description nvarchar(50),
	@trans_type nchar(3),
	@doc_type nchar(3),
	@cmd_type nchar(3),
	@remark ntext,
	@opt_by nvarchar(50),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as               ----更新02
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[Permission]
		where right_no = @OLD___right_no 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	exec  stp_U_clsPermission
		@OLD___right_no = @OLD___right_no,
		@right_no = @right_no,
		@description = @description,
		@trans_type = @trans_type,
		@doc_type = @doc_type,
		@cmd_type = @cmd_type,
		@remark = @remark,
		@opt_by = @opt_by,
		@opt_dtime = @opt_dtime,
		@opt_timestamp = @opt_timestamp output
end
GO
