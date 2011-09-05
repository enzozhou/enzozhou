/****** Object:  StoredProcedure [dbo].[stp_S_clsbinStatus_clsbinareaRelated]    Script Date: 08/15/2011 10:55:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsbinStatus_clsbinareaRelated](
	@OLD___dc_code nvarchar(10),
	@OLD___bin_area nvarchar(10)
)
as               ----根据clsbinarea的关联字段获得clsbinStatus的列表
begin
	select dc_code,bin_area,bin_code,dn_no,type,status_code,close_auto,print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[binStatus]
		where 	dc_code = @OLD___dc_code and
			bin_area = @OLD___bin_area 
end
GO
