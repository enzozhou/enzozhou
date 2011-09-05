/****** Object:  StoredProcedure [dbo].[stp_S_clsbin_clsbinareaRelated]    Script Date: 08/15/2011 10:54:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsbin_clsbinareaRelated](
	@OLD___dc_code nvarchar(10),
	@OLD___bin_area nvarchar(10)
)
as               ----根据clsbinarea的关联字段获得clsbin的列表
begin
	select dc_code,bin_code,[description],bin_area,length,width,weight,volume,opt_by,opt_dtime,opt_timestamp
		from [dbo].[bin]
		where 	dc_code = @OLD___dc_code and
			bin_area = @OLD___bin_area 
end
GO
