/****** Object:  StoredProcedure [dbo].[stp_SL_clsbin]    Script Date: 08/15/2011 10:55:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsbin]
as       ----取得clsbin的一个列表
begin
	select top 1000 dc_code,bin_code,[description],bin_area,length,width,weight,volume,opt_by,opt_dtime,opt_timestamp
		from [dbo].[bin]
end
GO
