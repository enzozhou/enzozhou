IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsbin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_SL_clsbin]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsbin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_SL_clsbin]
as       ----取得clsbin的一个列表
begin
	select top 1000 dc_code,bin_code,[description],wh_code,bin_type,bin_area,area,palls,weight,volume,canpick,isblocked,define1,define2,define3,define4,define5,opt_by,opt_dtime,opt_timestamp
		from [dbo].[bin]
end
' 
END
GO
