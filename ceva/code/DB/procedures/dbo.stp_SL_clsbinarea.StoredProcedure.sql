/****** Object:  StoredProcedure [dbo].[stp_SL_clsbinarea]    Script Date: 08/15/2011 10:55:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsbinarea]
as       ----取得clsbinarea的一个列表
begin
	select top 1000 dc_code,bin_area,[description],opt_by,opt_dtime,opt_timestamp
		from [dbo].[binarea]
end
GO
