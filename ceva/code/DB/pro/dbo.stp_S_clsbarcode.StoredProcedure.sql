IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsbarcode]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsbarcode]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsbarcode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsbarcode](
	@OLD___sku_no nvarchar(20),
	@OLD___barcode nvarchar(30)
)
as               ----根据关键字取得clsbarcode记录
begin
	select sku_no,barcode,bar_type,opt_by,opt_dtime,opt_timestamp
		from [dbo].[barcode]
		where 	sku_no = @OLD___sku_no and
			barcode = @OLD___barcode 
end
' 
END
GO
