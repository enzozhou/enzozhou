IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clscityairport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_U_clscityairport]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clscityairport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_U_clscityairport]( 
	@OLD___destination nvarchar(10),
	@OLD___type nchar(3),
	@destination nvarchar(10),
	@province nvarchar(10),
	@transit nvarchar(10),
	@type nchar(3),
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
		opt_dtime = @opt_dtime
		where destination = @OLD___destination and
		type = @OLD___type 

	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
' 
END
GO
