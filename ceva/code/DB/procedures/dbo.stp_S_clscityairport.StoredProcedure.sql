/****** Object:  StoredProcedure [dbo].[stp_S_clscityairport]    Script Date: 08/15/2011 10:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clscityairport](
	@OLD___destination nvarchar(10),
	@OLD___type nvarchar(10)
)
as               ----根据关键字取得clscityairport记录
begin
	select destination,province,transit,type,opt_dtime,opt_timestamp
		from [dbo].[cityairport]
		where 	destination = @OLD___destination and
			type = @OLD___type 
end
GO
