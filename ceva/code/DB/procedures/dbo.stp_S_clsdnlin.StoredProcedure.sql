/****** Object:  StoredProcedure [dbo].[stp_S_clsdnlin]    Script Date: 08/15/2011 10:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsdnlin](
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
GO
