/****** Object:  StoredProcedure [dbo].[stp_imp_SKUBarcode]    Script Date: 11/25/2010 15:42:06 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[stp_imp_SKUBarcode]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[stp_imp_SKUBarcode]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[stp_imp_SKUBarcode]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
CREATE    proc [dbo].[stp_imp_SKUBarcode]
(
    @id bigint
)
as
begin
	DECLARE @SKU_NO_TMP		NVARCHAR (50) 
	DECLARE @SKU_NO			NVARCHAR (20) 
	DECLARE @BARCODE			NVARCHAR (30) 
	DECLARE @BAR_TYPE			NVARCHAR (3) 
	DECLARE @OPT_BY				NVARCHAR (20) 
	DECLARE @OPT_DTIME			DATETIME 
	DECLARE @OPT_DATE			DATETIME
	DECLARE @EXPRESSION		NCHAR(1)
	SELECT @EXPRESSION = CHAR(124)  --'124 = - '
    declare hdrcur cursor local for  select sku_no, barcode, bar_type, opt_by from impbarcode where id = @id
	select  @OPT_DATE = getdate()	
	OPEN hdrcur
		FETCH NEXT FROM hdrcur into @SKU_NO_TMP, @BARCODE, @BAR_TYPE, @OPT_BY
		WHILE @@FETCH_STATUS = 0
		BEGIN
		select @SKU_NO = rtrim(SUBSTRING(@SKU_NO_TMP, 0, CHARINDEX(@EXPRESSION, @SKU_NO_TMP)))
			if  exists(SELECT 1 FROM barcode WHERE sku_no = @SKU_NO AND barcode = @BARCODE)
				begin
					update barcode set opt_by = @OPT_BY where sku_no = @SKU_NO and barcode = @BARCODE
				end
			else
				begin
					insert into barcode (sku_no, barcode, opt_by)
					values(@SKU_NO, @BARCODE, @OPT_BY)
				end
				
		FETCH NEXT FROM hdrcur into @SKU_NO_TMP, @BARCODE, @BAR_TYPE, @OPT_BY
		END 
	CLOSE hdrcur
	DEALLOCATE hdrcur
	delete impbarcode where id=@id
    
end
GO
