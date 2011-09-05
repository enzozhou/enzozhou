/****** Object:  StoredProcedure [dbo].[stp_S_clsbinarea]    Script Date: 08/15/2011 10:54:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsbinarea](
	@OLD___dc_code nvarchar(10),
	@OLD___bin_area nvarchar(10)
)
as               ----根据关键字取得clsbinarea记录
begin
	select dc_code,bin_area,[description],opt_by,opt_dtime,opt_timestamp
		from [dbo].[binarea]
		where 	dc_code = @OLD___dc_code and
			bin_area = @OLD___bin_area 
end
GO
