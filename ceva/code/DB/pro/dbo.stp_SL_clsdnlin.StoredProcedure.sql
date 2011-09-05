IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsdnlin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_SL_clsdnlin]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsdnlin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_SL_clsdnlin]
as       ----取得clsdnlin的一个列表
begin
	select top 1000 dc_code,dn_no,row_id,own_code,wh_code,bin_code,sku_no,sku_status,lot_no,serialed,qty,act_qty,status_code,sku_ref,tag_no,tag_qty,req_id,to_no,to_row,exp_status,opt_by,opt_dtime,opt_timestamp
		from [dbo].[dnlin]
end
' 
END
GO
