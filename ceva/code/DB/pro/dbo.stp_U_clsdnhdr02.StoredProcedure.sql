IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsdnhdr02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_U_clsdnhdr02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsdnhdr02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_U_clsdnhdr02]( 
	@OLD___dc_code nvarchar(10),
	@OLD___dn_no nvarchar(20),
	@dc_code nvarchar(10),
	@dn_no nvarchar(20),
	@description nvarchar(50),
	@own_code nvarchar(10),
	@wh_code nvarchar(10),
	@due_date datetime,
	@doc_type nchar(3),
	@source nchar(3),
	@stat_type nchar(3),
	@have_tag nchar(1),
	@ref_no nvarchar(20),
	@status_code nchar(5),
	@status_trk nchar(5),
	@imp_dtime datetime,
	@plant nchar(4),
	@city_from nvarchar(10),
	@deal_from nvarchar(10),
	@city_to nvarchar(10),
	@bill_to nvarchar(10),
	@bill_name nvarchar(50),
	@bill_person nvarchar(50),
	@bill_addr nvarchar(100),
	@bill_tel nvarchar(30),
	@deal_to nvarchar(10),
	@deal_name nvarchar(50),
	@deal_person nvarchar(50),
	@deal_tel nvarchar(30),
	@carr_code nvarchar(10),
	@method nvarchar(50),
	@unloading_address nvarchar(100),
	@instruction nvarchar(50),
	@route nvarchar(50),
	@point nvarchar(50),
	@condition nvarchar(50),
	@exp_status int,
	@close_auto bit,
	@archived bit,
	@print_by nvarchar(20),
	@print_counter int,
	@print_dtime datetime,
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@start_dtime datetime,
	@end_dtime datetime,
	@remark ntext,
	@opt_timestamp timestamp output
)
as               ----更新02
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[dnhdr]
		where dc_code = @OLD___dc_code and
		dn_no = @OLD___dn_no 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	exec  stp_U_clsdnhdr
		@OLD___dc_code = @OLD___dc_code,
		@OLD___dn_no = @OLD___dn_no,
		@dc_code = @dc_code,
		@dn_no = @dn_no,
		@description = @description,
		@own_code = @own_code,
		@wh_code = @wh_code,
		@due_date = @due_date,
		@doc_type = @doc_type,
		@source = @source,
		@stat_type = @stat_type,
		@have_tag = @have_tag,
		@ref_no = @ref_no,
		@status_code = @status_code,
		@status_trk = @status_trk,
		@imp_dtime = @imp_dtime,
		@plant = @plant,
		@city_from = @city_from,
		@deal_from = @deal_from,
		@city_to = @city_to,
		@bill_to = @bill_to,
		@bill_name = @bill_name,
		@bill_person = @bill_person,
		@bill_addr = @bill_addr,
		@bill_tel = @bill_tel,
		@deal_to = @deal_to,
		@deal_name = @deal_name,
		@deal_person = @deal_person,
		@deal_tel = @deal_tel,
		@carr_code = @carr_code,
		@method = @method,
		@unloading_address = @unloading_address,
		@instruction = @instruction,
		@route = @route,
		@point = @point,
		@condition = @condition,
		@exp_status = @exp_status,
		@close_auto = @close_auto,
		@archived = @archived,
		@print_by = @print_by,
		@print_counter = @print_counter,
		@print_dtime = @print_dtime,
		@opt_by = @opt_by,
		@opt_dtime = @opt_dtime,
		@start_dtime = @start_dtime,
		@end_dtime = @end_dtime,
		@remark = @remark,
		@opt_timestamp = @opt_timestamp output
end
' 
END
GO
