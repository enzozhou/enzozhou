/****** Object:  StoredProcedure [dbo].[sp_hht_checkBarcode_Sku]    Script Date: 08/15/2011 10:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_hht_checkBarcode_Sku] 
	@dn_no		varchar(50),
	@sku_no		varchar(50),
	@sErr		varchar(255)	output
As
begin
	set @sErr= '';

	declare @serr1 varchar(50)
	declare @sku2 varchar(50)
	exec sp_hht_checkBarcode '',@sku_no,@sku2 output,@serr1 output
	set @sErr = @sku2+'|'+@serr1;

End
GO
