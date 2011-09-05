IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsbin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsbin]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsbin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsbin](
	@OLD___dc_code nvarchar(10),
	@OLD___bin_code nvarchar(10)
)
as               ----根据关键字取得clsbin记录
begin
	select dc_code,bin_code,[description],wh_code,bin_type,bin_area,area,palls,weight,volume,canpick,isblocked,define1,define2,define3,define4,define5,opt_by,opt_dtime,opt_timestamp
		from [dbo].[bin]
		where 	dc_code = @OLD___dc_code and
			bin_code = @OLD___bin_code 
end
' 
END
GO
