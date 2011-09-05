IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsbinarea]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_SL_clsbinarea]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsbinarea]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_SL_clsbinarea]
as       ----取得clsbinarea的一个列表
begin
	select top 1000 dc_code,bin_area,[description],wh_code,seq,address,person,tel,fax,zip,dif_sku,dif_status,dif_owner,define1,define2,define3,define4,define5,opt_by,opt_dtime,opt_timestamp
		from [dbo].[binarea]
end
' 
END
GO
