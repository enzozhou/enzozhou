/****** Object:  StoredProcedure [dbo].[stp_SL_clstaskhdr]    Script Date: 08/15/2011 10:55:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clstaskhdr]
as       ----取得clstaskhdr的一个列表
begin
	select top 1000 dc_code,task_id,bch_no,dn_no,status_code,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[taskhdr]
end
GO
