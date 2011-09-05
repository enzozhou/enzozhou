/****** Object:  StoredProcedure [dbo].[stp_S_clsdnlin_clsdnhdrRelated]    Script Date: 08/15/2011 10:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsdnlin_clsdnhdrRelated](
	@OLD___dc_code nvarchar(10),
	@OLD___dn_no nvarchar(20)
)
as               ----根据clsdnhdr的关联字段获得clsdnlin的列表
begin
	select row_id,sku_no,qty,act_qty,status_code,lot_no,serialed,tag_no,opt_by,opt_dtime,opt_timestamp,dc_code,dn_no
		from [dbo].[dnlin]
		where 	dc_code = @OLD___dc_code and
			dn_no = @OLD___dn_no 
end
GO
