IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsbinarea]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsbinarea]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsbinarea]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsbinarea](
	@OLD___dc_code nvarchar(10),
	@OLD___bin_area nvarchar(10)
)
as               ----根据关键字取得clsbinarea记录
begin
	select dc_code,bin_area,[description],wh_code,seq,address,person,tel,fax,zip,dif_sku,dif_status,dif_owner,define1,define2,define3,define4,define5,opt_by,opt_dtime,opt_timestamp
		from [dbo].[binarea]
		where 	dc_code = @OLD___dc_code and
			bin_area = @OLD___bin_area 
end
' 
END
GO
