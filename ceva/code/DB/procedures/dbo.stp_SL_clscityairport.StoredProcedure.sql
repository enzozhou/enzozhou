/****** Object:  StoredProcedure [dbo].[stp_SL_clscityairport]    Script Date: 08/15/2011 10:55:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clscityairport]
as       ----取得clscityairport的一个列表
begin
	select top 1000 destination,province,transit,type,opt_dtime,opt_timestamp
		from [dbo].[cityairport]
end
GO
