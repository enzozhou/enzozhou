IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsbin02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_U_clsbin02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsbin02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_U_clsbin02]( 
	@OLD___dc_code nvarchar(10),
	@OLD___bin_code nvarchar(10),
	@dc_code nvarchar(10),
	@bin_code nvarchar(10),
	@description nvarchar(50),
	@wh_code nvarchar(10),
	@bin_type nvarchar(10),
	@bin_area nvarchar(10),
	@area numeric(12,3),
	@palls numeric(12,3),
	@weight numeric(12,3),
	@volume numeric(20,9),
	@canpick bit,
	@isblocked bit,
	@define1 nvarchar(50),
	@define2 nvarchar(50),
	@define3 nvarchar(50),
	@define4 nvarchar(50),
	@define5 nvarchar(50),
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
		@wh_code = @wh_code,
		@bin_type = @bin_type,
		@bin_area = @bin_area,
		@area = @area,
		@palls = @palls,
		@weight = @weight,
		@volume = @volume,
		@canpick = @canpick,
		@isblocked = @isblocked,
		@define1 = @define1,
		@define2 = @define2,
		@define3 = @define3,
		@define4 = @define4,
		@define5 = @define5,
		@opt_by = @opt_by,
		@opt_dtime = @opt_dtime,
		@opt_timestamp = @opt_timestamp output
end
' 
END
GO
