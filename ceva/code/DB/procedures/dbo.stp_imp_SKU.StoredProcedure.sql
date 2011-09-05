/****** Object:  StoredProcedure [dbo].[stp_imp_SKU]    Script Date: 11/25/2010 15:42:06 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[stp_imp_SKU]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[stp_imp_SKU]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[stp_imp_SKU]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
CREATE    proc [dbo].[stp_imp_SKU]
(
    @id bigint
)
as
begin
	DECLARE @SKU_NO			NVARCHAR (20) 
	DECLARE @SKU_WMS			NVARCHAR (20) 
	DECLARE @SKU_DESC			NVARCHAR (50) 
	DECLARE @SKU_DESC_ENG		NVARCHAR (50) 
	DECLARE @MODEL_NO			NVARCHAR (50) 
	DECLARE @COST_TYPE			NCHAR (10) 
	DECLARE @COUTABLE			NCHAR (10) 
	DECLARE @HIGH_VALUE		NCHAR (10) 
	DECLARE @SKU_TYPE			NVARCHAR (10) 
	DECLARE @SOURCE			NVARCHAR (10) 
	DECLARE @MEASURED			NCHAR (10) 
	DECLARE @MEAS_DATE			DATETIME 
	DECLARE @HAVE_SNO			NCHAR (10) 
	DECLARE @IDENTITY			NVARCHAR (10) 
	DECLARE @SNO_LEN			INT 
	DECLARE @SIX_CODE			NVARCHAR (20) 
	DECLARE @VENDER			NVARCHAR (10) 
	DECLARE @VENDER_NAME		NVARCHAR (50) 
	DECLARE @UNIT				NVARCHAR (10) 
	DECLARE @GROSS_WEIGHT		NUMERIC (12,3) 
	DECLARE @NET_WEIGHT		NUMERIC (12,3) 
	DECLARE @VOLUME			NUMERIC (20,9) 
	DECLARE @LENGTH			NUMERIC (12,3) 
	DECLARE @WIDTH				NUMERIC (12,3) 
	DECLARE @HEIGHT				NUMERIC (12,3) 
	DECLARE @PACK_LEN			NUMERIC (12,3) 
	DECLARE @PACK_WIDTH		NUMERIC (12,3) 
	DECLARE @PACK_HEIGHT		NUMERIC (12,3) 
	DECLARE @DOWN_DATE		DATETIME 
	DECLARE @CATEGORY			NVARCHAR (10) 
	DECLARE @DEPARTMENT		NVARCHAR (10) 
	DECLARE @MINQTY_SALES		NUMERIC (12,3) 
	DECLARE @QTY_PACK			NUMERIC (12,3) 
	DECLARE @QTY_LEN			NUMERIC (12,3) 
	DECLARE @QTY_WIDTH		NUMERIC (12,3) 
	DECLARE @QTY_HEIGHT		NUMERIC (12,3) 
	DECLARE @STUFF				NVARCHAR (50) 
	DECLARE @EXPIRED_DAY		DATETIME 
	DECLARE @DEFINE1			NVARCHAR (50) 
	DECLARE @DEFINE2			NVARCHAR (50) 
	DECLARE @DEFINE3			NVARCHAR (50) 
	DECLARE @DEFINE4			NVARCHAR (50) 
	DECLARE @DEFINE5			NVARCHAR (50) 
	DECLARE @PRICE				MONEY 
	DECLARE @FIRST_OPDATE		DATETIME 
	DECLARE @LAST_OPDATE		DATETIME 
	DECLARE @SAP_SKU			NVARCHAR (20) 
	DECLARE @OPT_BY				NVARCHAR (20) 
	DECLARE @OPT_DTIME			DATETIME 
	DECLARE @OPT_DATE			DATETIME
    declare hdrcur cursor local for  select [sku_no],  [sku_wms],  [sku_desc],  [sku_desc_eng],  [model_no],  [cost_type],  [coutable],  [high_value],  [sku_type],  [source],  [measured],  [meas_date],  [have_sno],  [identity1],  [sno_len],  [six_code],  [vender],  [vender_name],  [unit],  [gross_weight],  [net_weight],  [volume],  [length],  [width],  [height],  [pack_len],  [pack_width],  [pack_height],  [down_date],  [category],  [department],  [minqty_sales],  [qty_pack],  [qty_len],  [qty_width],  [qty_height],  [stuff],  [expired_day],  [define1],  [define2],  [define3],  [define4],  [define5],  [price],  [first_opdate],  [last_opdate],  [sap_sku],  [opt_by],  [opt_dtime] from impskuinfo where id = @id
	select  @OPT_DATE = getdate()	
	OPEN hdrcur
		FETCH NEXT FROM hdrcur into @SKU_NO, @SKU_WMS, @SKU_DESC, @SKU_DESC_ENG, @MODEL_NO, @COST_TYPE, @COUTABLE, @HIGH_VALUE, @SKU_TYPE, @SOURCE, @MEASURED, @MEAS_DATE, @HAVE_SNO, @IDENTITY, @SNO_LEN, @SIX_CODE, @VENDER, @VENDER_NAME, @UNIT, @GROSS_WEIGHT, @NET_WEIGHT, @VOLUME, @LENGTH, @WIDTH, @HEIGHT, @PACK_LEN, @PACK_WIDTH, @PACK_HEIGHT, @DOWN_DATE, @CATEGORY, @DEPARTMENT, @MINQTY_SALES, @QTY_PACK, @QTY_LEN, @QTY_WIDTH, @QTY_HEIGHT, @STUFF, @EXPIRED_DAY, @DEFINE1, @DEFINE2, @DEFINE3, @DEFINE4, @DEFINE5, @PRICE, @FIRST_OPDATE, @LAST_OPDATE, @SAP_SKU, @OPT_BY, @OPT_DTIME
		WHILE @@FETCH_STATUS = 0
		BEGIN
			if  exists(select 1 from skuinfo where sku_no=@SKU_NO and sku_wms = @SKU_WMS)
				begin
				update [dbo].[skuinfo] set sku_desc = @SKU_DESC, sku_desc_eng = @SKU_DESC_ENG, model_no = @MODEL_NO, 
				cost_type = case when @COST_TYPE='小件' then 'S' else 'L' end, coutable = case 
					when @COUTABLE = 'Y' then 1 
					when @COUTABLE = 'X' then 0 
					when @COUTABLE = 'N' then 0 
					else 0 end, high_value = case when @HIGH_VALUE in ('Y','N','X') then 1 else 0 end, sku_type = @SKU_TYPE, measured = case when @MEASURED='已测量' then '1' else '0' end, have_sno = case when @HAVE_SNO in ('Y','是','X') then 1 else 0 end,
				six_code = @SIX_CODE, vender = @VENDER, vender_name = @VENDER_NAME, unit = @UNIT, gross_weight = @GROSS_WEIGHT, net_weight = @NET_WEIGHT, volume = @VOLUME, length = @LENGTH, width = @WIDTH, height = @HEIGHT, category = @CATEGORY, department = @DEPARTMENT, opt_by = @OPT_BY, opt_dtime = @OPT_DATE from [dbo].[skuinfo] where sku_no = @SKU_NO and sku_wms = @SKU_WMS
				end
			else
				begin
					insert into [dbo].[skuinfo]
					(sku_no, sku_wms, sku_desc, sku_desc_eng, model_no, 
					cost_type, coutable, high_value, sku_type, measured, have_sno, 
					six_code, vender, vender_name, unit, gross_weight, net_weight, volume, length, width, height, category, department, opt_by, opt_dtime)
					values(@SKU_NO, @SKU_WMS, @SKU_DESC, @SKU_DESC_ENG, @MODEL_NO, 
					case when @COST_TYPE='小件' then 'S' else 'L' end,
					case 
						when @COUTABLE = 'Y' then 1 
						when @COUTABLE = 'X' then 0 
						when @COUTABLE = 'N' then 0 
						else 0 end,
					case when @HIGH_VALUE in ('Y','N','X') then 1 else 0 end,
					@SKU_TYPE,
					case when @MEASURED='已测量' then '1' else '0' end,
					case when @HAVE_SNO in ('Y','是','X') then 1 else 0 end, 
					@SIX_CODE, @VENDER, @VENDER_NAME, @UNIT, @GROSS_WEIGHT, @NET_WEIGHT, @VOLUME, @LENGTH, @WIDTH, @HEIGHT, @CATEGORY, @DEPARTMENT, @OPT_BY, @OPT_DATE)
				end
				
			FETCH NEXT FROM hdrcur into @SKU_NO, @SKU_WMS
			, @SKU_DESC, @SKU_DESC_ENG, @MODEL_NO, @COST_TYPE, @COUTABLE, @HIGH_VALUE, @SKU_TYPE, @SOURCE, @MEASURED, @MEAS_DATE, @HAVE_SNO, @IDENTITY, @SNO_LEN, @SIX_CODE, @VENDER, @VENDER_NAME, @UNIT, @GROSS_WEIGHT, @NET_WEIGHT, @VOLUME, @LENGTH, @WIDTH, @HEIGHT, @PACK_LEN, @PACK_WIDTH, @PACK_HEIGHT, @DOWN_DATE, @CATEGORY, @DEPARTMENT, @MINQTY_SALES, @QTY_PACK, @QTY_LEN, @QTY_WIDTH, @QTY_HEIGHT, @STUFF, @EXPIRED_DAY, @DEFINE1, @DEFINE2, @DEFINE3, @DEFINE4, @DEFINE5, @PRICE, @FIRST_OPDATE, @LAST_OPDATE, @SAP_SKU, @OPT_BY, @OPT_DTIME
		END 
	CLOSE hdrcur
	DEALLOCATE hdrcur
	delete impskuinfo where id=@id
    
end
GO
