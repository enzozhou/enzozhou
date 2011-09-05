/****** Object:  StoredProcedure [dbo].[stp_I_impDN]    Script Date: 08/15/2011 10:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_impDN]( 
	@ID						BIGINT,
	@DC_CODE				NVARCHAR(10),
	@DN_NO					NVARCHAR(20),
	@DUE_DATE				DATETIME,
	@DOC_TYPE				NCHAR(3),
	@DEAL_TO				NVARCHAR(10),
	@DEAL_NAME				NVARCHAR(50),
	@DEAL_PERSON			NVARCHAR(50),
	@UNLOADING_ADDRESS	NVARCHAR(100),
	@DEAL_TEL				NVARCHAR(30),
	@CITY_TO				NVARCHAR(10),
	@CONDITION				NVARCHAR(50),
	@METHOD				NVARCHAR(50),
	@SKU_NO				NVARCHAR(20),
	@SONY_BCH_NO			NVARCHAR(20),
	@QTY					NUMERIC,
	@OPT_BY					NVARCHAR(20)
)
as 
begin
INSERT INTO [dbo].[ImpDn](
           [id]
           ,[dc_code]
           ,[dn_no]
           ,[due_date]
           ,[doc_type]
           ,[deal_to]
           ,[deal_name]
           ,[deal_person]
           ,[deal_tel]
           ,[unloading_address]
           ,[city_to]
           ,[condition]
           ,[method]
           ,[sku_no]
           ,[qty]
           ,[sony_bch_no]
           ,[opt_by])
     VALUES(
	    @ID
           ,@DC_CODE
           ,@DN_NO
           ,@DUE_DATE
           ,@DOC_TYPE
           ,@DEAL_TO
           ,@DEAL_NAME
           ,@DEAL_PERSON
           ,@DEAL_TEL
           ,@UNLOADING_ADDRESS
           ,@CITY_TO
           ,@CONDITION
           ,@METHOD
           ,@SKU_NO
           ,@QTY
           ,@SONY_BCH_NO
           ,@OPT_BY
)
	
	
end
GO
