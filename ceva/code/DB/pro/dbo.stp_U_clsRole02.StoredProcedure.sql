IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsRole02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_U_clsRole02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsRole02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_U_clsRole02]( 
	@OLD___role_code nvarchar(10),
	@role_code nvarchar(10),
	@role_name nvarchar(50),
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
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[Role]
		where role_code = @OLD___role_code 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	exec  stp_U_clsRole
		@OLD___role_code = @OLD___role_code,
		@role_code = @role_code,
		@role_name = @role_name,
		@remark = @remark,
		@opt_by = @opt_by,
		@opt_dtime = @opt_dtime,
		@opt_timestamp = @opt_timestamp output
end
' 
END
GO
