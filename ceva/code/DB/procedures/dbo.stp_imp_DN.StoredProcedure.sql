set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER    proc [dbo].[stp_imp_DN]
(
    @id bigint
)
as
begin
DECLARE	@DC_CODE						NVARCHAR (10) 
DECLARE	@DN_NO							NVARCHAR (20) 
DECLARE	@DESCRIPTION					NVARCHAR (50) 
DECLARE	@OWN_CODE						NVARCHAR (10) 
DECLARE	@WH_CODE						NVARCHAR (10) 
DECLARE	@DUE_DATE						DATETIME 
DECLARE	@SONY_BCH_NO					NVARCHAR(20) 
DECLARE	@DOC_TYPE						NCHAR (3) 
DECLARE	@SOURCE						    NCHAR (3) 
DECLARE	@STAT_TYPE						NCHAR (3) 
DECLARE	@HAVE_TAG						NCHAR (1) 
DECLARE	@REF_NO						    NVARCHAR (20) 
DECLARE	@STATUS_CODE					NCHAR (5) 
DECLARE	@STATUS_TRK					    NCHAR (5) 
DECLARE	@IMP_DTIME						DATETIME 
DECLARE	@PLANT							NCHAR (4)                          
DECLARE	@CITY_FROM						NVARCHAR (10) 
DECLARE	@DEAL_FROM						NVARCHAR (10) 
DECLARE	@CITY_TO						NVARCHAR (10) 
DECLARE	@BILL_TO						NVARCHAR (10) 
DECLARE	@BILL_NAME						NVARCHAR (50) 
DECLARE	@BILL_PERSON					NVARCHAR (50) 
DECLARE	@BILL_ADDR						NVARCHAR (100) 
DECLARE	@BILL_TEL						NVARCHAR (30) 
DECLARE	@DEAL_TO						NVARCHAR (10) 
DECLARE	@DEAL_NAME						NVARCHAR (50) 
DECLARE	@DEAL_PERSON					NVARCHAR (50) 
DECLARE	@DEAL_TEL						NVARCHAR (30) 
DECLARE	@CARR_CODE						NVARCHAR (10) 
DECLARE	@METHOD						    NVARCHAR (50) 
DECLARE	@UNLOADING_ADDRESS			    NVARCHAR (100) 
DECLARE	@INSTRUCTION					NVARCHAR (50) 
DECLARE	@ROUTE							NVARCHAR (50)               
DECLARE	@POINT							NVARCHAR (50)                
DECLARE	@CONDITION						NVARCHAR (50) 
DECLARE	@SKU_NO						    NVARCHAR (20) 
DECLARE	@SKU_STATUS					    NCHAR (4) 
DECLARE	@LOT_NO						    NVARCHAR (20) 
DECLARE	@SERIALED						BIT 
DECLARE	@QTY							NUMERIC (12,3)                        
DECLARE	@SKU_REF						NVARCHAR (20) 
DECLARE	@TAG_NO						    NVARCHAR (30) 
DECLARE	@TAG_QTY						INT
DECLARE @OPT_DATE						DATETIME
DECLARE @OPT_BY						NVARCHAR (20) 
--DECLARE @tmp_dc_code		NVARCHAR (10) 
DECLARE @tmp_dn_no		NVARCHAR (20) 
DECLARE @tmp_row_no		INT
DECLARE hdrcur CURSOR LOCAL FOR  SELECT 
	dc_code, dn_no, description, own_code, wh_code, due_date, sony_bch_no, doc_type, source, stat_type, have_tag, ref_no, status_code, status_trk, imp_dtime, plant, city_from, deal_from, city_to, bill_to, bill_name, bill_person, bill_addr, bill_tel, deal_to, deal_name, deal_person, deal_tel, carr_code, method, unloading_address, instruction, route, point, condition, sku_no, sku_status, lot_no, serialed, qty, sku_ref, tag_no, tag_qty, opt_by
FROM dbo.ImpDn WHERE id = @id ORDER BY dn_no
	select  @OPT_DATE = getdate()	
	select @tmp_row_no = 0
	OPEN hdrcur
		FETCH NEXT FROM hdrcur into @DC_CODE, @DN_NO, @DESCRIPTION, @OWN_CODE, @WH_CODE, @DUE_DATE, @SONY_BCH_NO, @DOC_TYPE, @SOURCE, @STAT_TYPE, @HAVE_TAG, @REF_NO, @STATUS_CODE, @STATUS_TRK, @IMP_DTIME, @PLANT, @CITY_FROM, @DEAL_FROM, @CITY_TO, @BILL_TO, @BILL_NAME, @BILL_PERSON, @BILL_ADDR, @BILL_TEL, @DEAL_TO, @DEAL_NAME, @DEAL_PERSON, @DEAL_TEL, @CARR_CODE, @METHOD, @UNLOADING_ADDRESS, @INSTRUCTION, @ROUTE, @POINT, @CONDITION, @SKU_NO, @SKU_STATUS, @LOT_NO, @SERIALED, @QTY, @SKU_REF, @TAG_NO, @TAG_QTY, @OPT_BY
		WHILE @@FETCH_STATUS = 0
		BEGIN	
				if  exists(SELECT 1 FROM dnhdr, dnlin WHERE dnhdr.dn_no = @DN_NO AND dnhdr.dc_code = @DC_CODE AND dnlin.dn_no= @DN_NO AND dnlin.dc_code = @DC_CODE AND dnlin.sku_no = @SKU_NO)
				begin 
					if @tmp_dn_no is null or @DN_NO <> @tmp_dn_no
					begin 
						UPDATE dnlin SET qty = 0 WHERE dn_no = @DN_NO --规避重复导入，更新itm数量为0。
						select @tmp_dn_no = @DN_NO
						--select @tmp_row_no = 0
						update [dbo].[dnhdr] set dc_code = @dc_code,dn_no = @dn_no,sony_bch_no = @sony_bch_no,
								imp_dtime = @imp_dtime,city_to = @city_to,deal_to = @deal_to,doc_type = @doc_type,
								deal_name = @deal_name,deal_person = @deal_person,deal_tel = @deal_tel,
								unloading_address = @unloading_address, opt_by = @OPT_BY
						where dc_code = @dc_code and
								dn_no = @dn_no 
					end 
					--select @tmp_row_no = @tmp_row_no + 1
					update [dbo].[dnlin] set dc_code = @dc_code,dn_no = @dn_no,
							own_code = @own_code,wh_code = @wh_code,
							bin_code = NULL,sku_no = @sku_no,sku_status = @sku_status,
							lot_no = @lot_no,serialed = @serialed, qty = qty+@qty, act_qty = 0,
							sku_ref = @sku_ref,tag_no = @tag_no,tag_qty = @tag_qty,
                            req_id = NULL,opt_by = @OPT_BY,opt_dtime = @OPT_DATE
					where   dc_code = @dc_code and
							dn_no = @dn_no and
							sku_no = @sku_no
							--row_id = @tmp_row_no 
				end 
			else
				begin 
					if @tmp_dn_no is null or @DN_NO <> @tmp_dn_no
					begin 
						select @tmp_dn_no = @DN_NO
						select @tmp_row_no = 0
					insert into [dbo].[dnhdr]( dc_code,dn_no,sony_bch_no,imp_dtime,city_to,deal_to,
		                           deal_name,deal_person,deal_tel,unloading_address,doc_type,
                                   status_code,opt_by,opt_dtime,start_dtime,end_dtime,remark)
						values    (@dc_code,@dn_no,@sony_bch_no,@OPT_DATE,@city_to,@deal_to,@deal_name,
								   @deal_person,@deal_tel,@unloading_address,@doc_type,0,@OPT_BY,
                                   @OPT_DATE,@OPT_DATE,NULL,NULL)
				end 
					select @tmp_row_no = @tmp_row_no + 1
					insert into [dbo].[dnlin]( dc_code,dn_no,row_id,own_code,wh_code,bin_code,sku_no,
		                        sku_status,lot_no,serialed,qty,act_qty,status_code,sku_ref,tag_no,tag_qty,opt_by,opt_dtime)
						 values(@dc_code,@dn_no,@tmp_row_no,@own_code,@wh_code,NULL,@sku_no,0,
							   @lot_no,@serialed,@qty,0,@status_code,@sku_ref,@tag_no,@tag_qty,@OPT_BY,@OPT_DATE)
		end 
			FETCH NEXT FROM hdrcur into @DC_CODE, @DN_NO, @DESCRIPTION, @OWN_CODE, @WH_CODE, @DUE_DATE, @SONY_BCH_NO, @DOC_TYPE, @SOURCE, @STAT_TYPE, @HAVE_TAG, @REF_NO, @STATUS_CODE, @STATUS_TRK, @IMP_DTIME, @PLANT, @CITY_FROM, @DEAL_FROM, @CITY_TO, @BILL_TO, @BILL_NAME, @BILL_PERSON, @BILL_ADDR, @BILL_TEL, @DEAL_TO, @DEAL_NAME, @DEAL_PERSON, @DEAL_TEL, @CARR_CODE, @METHOD, @UNLOADING_ADDRESS, @INSTRUCTION, @ROUTE, @POINT, @CONDITION, @SKU_NO, @SKU_STATUS, @LOT_NO, @SERIALED, @QTY, @SKU_REF, @TAG_NO, @TAG_QTY, @OPT_BY
		END 
	CLOSE hdrcur
	DEALLOCATE hdrcur
	delete Impdn where id=@id    
end


