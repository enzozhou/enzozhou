IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsdnlin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsdnlin]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsdnlin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsdnlin](
	@OLD___dc_code nvarchar(10),
	@OLD___dn_no nvarchar(20),
	@OLD___row_id nchar(5)
)
as               ----根据关键字取得clsdnlin记录
begin
	select dc_code,dn_no,row_id,own_code,wh_code,bin_code,sku_no,sku_status,lot_no,serialed,qty,act_qty,status_code,sku_ref,tag_no,tag_qty,req_id,to_no,to_row,exp_status,opt_by,opt_dtime,opt_timestamp
		from [dbo].[dnlin]
		where 	dc_code = @OLD___dc_code and
			dn_no = @OLD___dn_no and
			row_id = @OLD___row_id 
end
' 
END
GO
