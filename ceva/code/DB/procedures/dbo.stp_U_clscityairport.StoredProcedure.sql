/****** Object:  StoredProcedure [dbo].[stp_U_clscityairport]    Script Date: 08/15/2011 10:55:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clscityairport]( 
	@OLD___destination nvarchar(10),
	@OLD___type nvarchar(10),
	@destination nvarchar(10),
	@province nvarchar(10),
	@transit nvarchar(10),
	@type nvarchar(10),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as           ----更新
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[cityairport]
		where destination = @OLD___destination and
		type = @OLD___type 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	update [dbo].[cityairport] set 
		destination = @destination,
		province = @province,
		transit = @transit,
		type = @type,
		opt_dtime = @opt_dtime
		where destination = @OLD___destination and
		type = @OLD___type 

	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
