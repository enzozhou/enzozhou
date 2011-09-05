IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsbarcode_clsskuinfoRelated]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsbarcode_clsskuinfoRelated]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsbarcode_clsskuinfoRelated]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsbarcode_clsskuinfoRelated](
	@OLD___sku_no nvarchar(20)
)
as               ----根据clsskuinfo的关联字段获得clsbarcode的列表
begin
	select sku_no,barcode,bar_type,opt_by,opt_dtime,opt_timestamp
		from [dbo].[barcode]
		where 	sku_no = @OLD___sku_no 
end
' 
END
GO
