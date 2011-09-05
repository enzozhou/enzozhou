/****** Object:  StoredProcedure [dbo].[stp_S_clstasklin]    Script Date: 08/15/2011 10:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clstasklin](
	@OLD___rowid nvarchar(10)
)
as               ----根据关键字取得clstasklin记录
begin
	select rowid,dc_code,task_id,bch_no,dn_no,bin_area,bin_code,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp,sku_no,sno,qty
		from [dbo].[tasklin]
		where 	rowid = @OLD___rowid 
end
GO
