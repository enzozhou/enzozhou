/****** Object:  StoredProcedure [dbo].[stp_U_clsbin02]    Script Date: 08/15/2011 10:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clsbin02]( 
	@OLD___dc_code nvarchar(10),
	@OLD___bin_code nvarchar(10),
	@dc_code nvarchar(10),
	@bin_code nvarchar(10),
	@description nvarchar(50),
	@bin_area nvarchar(10),
	@area numeric(12,3),
	@palls numeric(12,3),
	@length numeric(12,3),
	@width numeric(12,3),
	@weight numeric(12,3),
	@volume numeric(20,9),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as               ----更新02
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[bin]
		where dc_code = @OLD___dc_code and
		bin_code = @OLD___bin_code 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	exec  stp_U_clsbin
		@OLD___dc_code = @OLD___dc_code,
		@OLD___bin_code = @OLD___bin_code,
		@dc_code = @dc_code,
		@bin_code = @bin_code,
		@description = @description,
		@bin_area = @bin_area,
		@area = @area,
		@palls = @palls,
		@length = @length,
		@width = @width,
		@weight = @weight,
		@volume = @volume,
		@opt_by = @opt_by,
		@opt_dtime = @opt_dtime,
		@opt_timestamp = @opt_timestamp output
end
GO
