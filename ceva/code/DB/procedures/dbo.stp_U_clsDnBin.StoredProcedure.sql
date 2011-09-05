/****** Object:  StoredProcedure [dbo].[stp_U_clsDnBin]    Script Date: 08/15/2011 10:55:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clsDnBin]( 
	@OLD___dc_code nvarchar(10),
	@OLD___dn_no nvarchar(20),
	@OLD___bin_area nvarchar(10),
	@OLD___bin_code nvarchar(10),
	@OLD___bch_no nvarchar(20),
	@rowid nvarchar(10),
	@dc_code nvarchar(10),
	@dn_no nvarchar(20),
	@bin_area nvarchar(10),
	@bin_code nvarchar(10),
	@status_code nchar(5),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@start_dtime datetime,
	@end_dtime datetime,
	@opt_timestamp timestamp output,
	@bch_no nvarchar(20)
)
as           ----更新
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[DnBin]
		where dc_code = @OLD___dc_code and
		dn_no = @OLD___dn_no and
		bin_area = @OLD___bin_area and
		bin_code = @OLD___bin_code and
		bch_no = @OLD___bch_no 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	update [dbo].[DnBin] set 
		rowid = @rowid,
		dc_code = @dc_code,
		dn_no = @dn_no,
		bin_area = @bin_area,
		bin_code = @bin_code,
		status_code = @status_code,
		opt_by = @opt_by,
		opt_dtime = @opt_dtime,
		start_dtime = @start_dtime,
		end_dtime = @end_dtime,
		bch_no = @bch_no
		where dc_code = @OLD___dc_code and
		dn_no = @OLD___dn_no and
		bin_area = @OLD___bin_area and
		bin_code = @OLD___bin_code and
		bch_no = @OLD___bch_no 

	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
