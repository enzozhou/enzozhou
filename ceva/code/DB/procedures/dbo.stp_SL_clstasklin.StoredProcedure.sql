/****** Object:  StoredProcedure [dbo].[stp_SL_clstasklin]    Script Date: 08/15/2011 10:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clstasklin]
as       ----取得clstasklin的一个列表
begin
	select top 1000 rowid,dc_code,task_id,bch_no,dn_no,bin_area,bin_code,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp,sku_no,sno,qty
		from [dbo].[tasklin]
end
GO
