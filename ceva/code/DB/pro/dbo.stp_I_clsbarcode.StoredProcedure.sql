IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsbarcode]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_I_clsbarcode]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsbarcode]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_I_clsbarcode]( 
	@sku_no nvarchar(20),
	@barcode nvarchar(30),
	@bar_type nchar(3),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
	insert into [dbo].[barcode]( 
		sku_no,
		barcode,
		bar_type,
		opt_by,
		opt_dtime)
	values(
		@sku_no,
		@barcode,
		@bar_type,
		@opt_by,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
' 
END
GO
