/****** Object:  StoredProcedure [dbo].[stp_S_clsbin]    Script Date: 08/15/2011 10:54:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsbin](
	@OLD___dc_code nvarchar(10),
	@OLD___bin_code nvarchar(10)
)
as               ----根据关键字取得clsbin记录
begin
	select dc_code,bin_code,[description],bin_area,length,width,weight,volume,opt_by,opt_dtime,opt_timestamp
		from [dbo].[bin]
		where 	dc_code = @OLD___dc_code and
			bin_code = @OLD___bin_code 
end
GO
