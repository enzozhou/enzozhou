/****** Object:  StoredProcedure [dbo].[stp_SL_clsbinStatus]    Script Date: 08/15/2011 10:55:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsbinStatus]
as       ----取得clsbinStatus的一个列表
begin
	select top 1000 dc_code,id,bin_area,bin_code,dn_no,type,status_code,close_auto,print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[binStatus]
end
GO
