IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsskuinfo02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_U_clsskuinfo02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsskuinfo02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_U_clsskuinfo02]( 
	@OLD___sku_no nvarchar(20),
	@OLD___sku_wms nvarchar(20),
	@sku_no nvarchar(20),
	@sku_wms nvarchar(20),
	@sku_desc nvarchar(50),
	@sku_desc_eng nvarchar(50),
	@model_no nvarchar(50),
	@cost_type nchar(1),
	@coutable bit,
	@high_value bit,
	@sku_type nvarchar(10),
	@source nvarchar(10),
	@measured bit,
	@meas_date datetime,
	@have_sno bit,
	@identity nvarchar(10),
	@sno_len int,
	@six_code nvarchar(20),
	@vender nvarchar(10),
	@vender_name nvarchar(50),
	@unit nvarchar(10),
	@gross_weight numeric(12,3),
	@net_weight numeric(12,3),
	@volume numeric(20,9),
	@length numeric(12,3),
	@width numeric(12,3),
	@height numeric(12,3),
	@pack_len numeric(12,3),
	@pack_width numeric(12,3),
	@pack_height numeric(12,3),
	@down_date datetime,
	@category nvarchar(10),
	@department nvarchar(10),
	@minqty_sales numeric(12,3),
	@qty_pack numeric(12,3),
	@qty_len numeric(12,3),
	@qty_width numeric(12,3),
	@qty_height numeric(12,3),
	@stuff nvarchar(50),
	@expired_day datetime,
	@define1 nvarchar(50),
	@define2 nvarchar(50),
	@define3 nvarchar(50),
	@define4 nvarchar(50),
	@define5 nvarchar(50),
	@price money,
	@first_opdate datetime,
	@last_opdate datetime,
	@sap_sku nvarchar(20),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as               ----更新02
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[skuinfo]
		where sku_no = @OLD___sku_no and
		sku_wms = @OLD___sku_wms 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	exec  stp_U_clsskuinfo
		@OLD___sku_no = @OLD___sku_no,
		@OLD___sku_wms = @OLD___sku_wms,
		@sku_no = @sku_no,
		@sku_wms = @sku_wms,
		@sku_desc = @sku_desc,
		@sku_desc_eng = @sku_desc_eng,
		@model_no = @model_no,
		@cost_type = @cost_type,
		@coutable = @coutable,
		@high_value = @high_value,
		@sku_type = @sku_type,
		@source = @source,
		@measured = @measured,
		@meas_date = @meas_date,
		@have_sno = @have_sno,
		@identity = @identity,
		@sno_len = @sno_len,
		@six_code = @six_code,
		@vender = @vender,
		@vender_name = @vender_name,
		@unit = @unit,
		@gross_weight = @gross_weight,
		@net_weight = @net_weight,
		@volume = @volume,
		@length = @length,
		@width = @width,
		@height = @height,
		@pack_len = @pack_len,
		@pack_width = @pack_width,
		@pack_height = @pack_height,
		@down_date = @down_date,
		@category = @category,
		@department = @department,
		@minqty_sales = @minqty_sales,
		@qty_pack = @qty_pack,
		@qty_len = @qty_len,
		@qty_width = @qty_width,
		@qty_height = @qty_height,
		@stuff = @stuff,
		@expired_day = @expired_day,
		@define1 = @define1,
		@define2 = @define2,
		@define3 = @define3,
		@define4 = @define4,
		@define5 = @define5,
		@price = @price,
		@first_opdate = @first_opdate,
		@last_opdate = @last_opdate,
		@sap_sku = @sap_sku,
		@opt_by = @opt_by,
		@opt_dtime = @opt_dtime,
		@opt_timestamp = @opt_timestamp output
end
' 
END
GO
