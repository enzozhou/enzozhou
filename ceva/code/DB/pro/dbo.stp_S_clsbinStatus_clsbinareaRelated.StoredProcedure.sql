IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsbinStatus_clsbinareaRelated]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsbinStatus_clsbinareaRelated]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsbinStatus_clsbinareaRelated]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsbinStatus_clsbinareaRelated](
	@OLD___dc_code nvarchar(10),
	@OLD___wh_code nvarchar(10),
	@OLD___bin_area nvarchar(10)
)
as               ----根据clsbinarea的关联字段获得clsbinStatus的列表
begin
	select dc_code,wh_code,id,bin_area,bin_code,dn_no,type,status_code,close_auto,print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[binStatus]
		where 	dc_code = @OLD___dc_code and
			wh_code = @OLD___wh_code and
			bin_area = @OLD___bin_area 
end
' 
END
GO
