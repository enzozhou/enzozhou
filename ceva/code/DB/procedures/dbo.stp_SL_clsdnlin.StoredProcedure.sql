/****** Object:  StoredProcedure [dbo].[stp_SL_clsdnlin]    Script Date: 08/15/2011 10:55:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsdnlin]
as       ----取得clsdnlin的一个列表
begin
	select top 1000 dc_code,dn_no,row_id,own_code,wh_code,bin_code,sku_no,sku_status,lot_no,serialed,qty,act_qty,status_code,sku_ref,tag_no,tag_qty,req_id,to_no,to_row,exp_status,opt_by,opt_dtime,opt_timestamp
		from [dbo].[dnlin]
end
GO
