IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsdnlin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_I_clsdnlin]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsdnlin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_I_clsdnlin]( 
	@dc_code nvarchar(10),
	@dn_no nvarchar(20),
	@row_id nchar(5),
	@own_code nvarchar(10),
	@wh_code nvarchar(10),
	@bin_code nvarchar(10),
	@sku_no nvarchar(20),
	@sku_status nchar(4),
	@lot_no nvarchar(20),
	@serialed bit,
	@qty numeric(12,3),
	@act_qty numeric(12,3),
	@status_code nchar(5),
	@sku_ref nvarchar(20),
	@tag_no nvarchar(30),
	@tag_qty int,
	@req_id bigint,
	@to_no nvarchar(20),
	@to_row nchar(5),
	@exp_status int,
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
	insert into [dbo].[dnlin]( 
		dc_code,
		dn_no,
		row_id,
		own_code,
		wh_code,
		bin_code,
		sku_no,
		sku_status,
		lot_no,
		serialed,
		qty,
		act_qty,
		status_code,
		sku_ref,
		tag_no,
		tag_qty,
		req_id,
		to_no,
		to_row,
		exp_status,
		opt_by,
		opt_dtime)
	values(
		@dc_code,
		@dn_no,
		@row_id,
		@own_code,
		@wh_code,
		@bin_code,
		@sku_no,
		@sku_status,
		@lot_no,
		@serialed,
		@qty,
		@act_qty,
		@status_code,
		@sku_ref,
		@tag_no,
		@tag_qty,
		@req_id,
		@to_no,
		@to_row,
		@exp_status,
		@opt_by,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
' 
END
GO
