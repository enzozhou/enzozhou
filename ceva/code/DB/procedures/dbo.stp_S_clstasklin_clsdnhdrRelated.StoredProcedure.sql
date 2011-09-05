/****** Object:  StoredProcedure [dbo].[stp_S_clstasklin_clsdnhdrRelated]    Script Date: 08/15/2011 10:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clstasklin_clsdnhdrRelated](
	@OLD___dc_code nvarchar(10),
	@OLD___dn_no nvarchar(20)
)
as               ----根据clsdnhdr的关联字段获得clstasklin的列表
begin
	select rowid,dc_code,task_id,bch_no,dn_no,bin_area,bin_code,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp,sku_no,sno,qty
		from [dbo].[tasklin]
		where 	dc_code = @OLD___dc_code and
			dn_no = @OLD___dn_no 
end
GO
