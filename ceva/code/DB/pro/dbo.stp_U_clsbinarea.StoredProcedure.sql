IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsbinarea]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_U_clsbinarea]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsbinarea]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_U_clsbinarea]( 
	@OLD___dc_code nvarchar(10),
	@OLD___bin_area nvarchar(10),
	@dc_code nvarchar(10),
	@bin_area nvarchar(10),
	@description nvarchar(50),
	@wh_code nvarchar(10),
	@seq nchar(3),
	@address nvarchar(50),
	@person nvarchar(50),
	@tel nvarchar(20),
	@fax nvarchar(20),
	@zip nchar(6),
	@dif_sku bit,
	@dif_status bit,
	@dif_owner bit,
	@define1 nvarchar(50),
	@define2 nvarchar(50),
	@define3 nvarchar(50),
	@define4 nvarchar(50),
	@define5 nvarchar(50),
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
		wh_code = @wh_code,
		seq = @seq,
		address = @address,
		person = @person,
		tel = @tel,
		fax = @fax,
		zip = @zip,
		dif_sku = @dif_sku,
		dif_status = @dif_status,
		dif_owner = @dif_owner,
		define1 = @define1,
		define2 = @define2,
		define3 = @define3,
		define4 = @define4,
		define5 = @define5,
		opt_by = @opt_by,
		opt_dtime = @opt_dtime
		where dc_code = @OLD___dc_code and
		bin_area = @OLD___bin_area 

	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
' 
END
GO
