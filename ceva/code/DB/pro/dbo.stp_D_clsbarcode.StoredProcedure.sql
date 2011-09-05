IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsbarcode]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_D_clsbarcode]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsbarcode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_D_clsbarcode](
	@sku_no nvarchar(20),
	@barcode nvarchar(30),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[barcode]
	where 	sku_no = @sku_no and
		barcode = @barcode 
end
' 
END
GO
