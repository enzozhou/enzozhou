/****** Object:  StoredProcedure [dbo].[stp_SL_clsbchhdr]    Script Date: 08/15/2011 10:55:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsbchhdr]
as       ----取得clsbchhdr的一个列表
begin
	select top 1000 dc_code,bch_no,[description],status_code,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[bchhdr]
end
GO
