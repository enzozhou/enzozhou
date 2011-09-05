IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsbinStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_SL_clsbinStatus]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsbinStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_SL_clsbinStatus]
as       ----取得clsbinStatus的一个列表
begin
	select top 1000 dc_code,wh_code,id,bin_area,bin_code,dn_no,type,status_code,close_auto,print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[binStatus]
end
' 
END
GO
