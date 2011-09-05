/****** Object:  StoredProcedure [dbo].[stp_U_clsbinarea]    Script Date: 08/15/2011 10:55:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clsbinarea]( 
	@OLD___dc_code nvarchar(10),
	@OLD___bin_area nvarchar(10),
	@dc_code nvarchar(10),
	@bin_area nvarchar(10),
	@description nvarchar(50),
	@opt_by nvarchar(50),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as           ----更新
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[binarea]
		where dc_code = @OLD___dc_code and
		bin_area = @OLD___bin_area 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	update [dbo].[binarea] set 
		dc_code = @dc_code,
		bin_area = @bin_area,
		[description] = @description,
		opt_by = @opt_by,
		opt_dtime = @opt_dtime
		where dc_code = @OLD___dc_code and
		bin_area = @OLD___bin_area 

	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
