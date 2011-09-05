/****** Object:  StoredProcedure [dbo].[stp_imp_binarea]    Script Date: 11/25/2010 15:42:06 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[stp_imp_binarea]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[stp_imp_binarea]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[stp_imp_binarea]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE    proc [dbo].[stp_imp_binarea]
(
    @id bigint
)
as
begin
DECLARE @DC_CODE			NVARCHAR(10)
DECLARE @BIN_AREA			NVARCHAR(10)
DECLARE @DESCRIPTION		NVARCHAR(50)
DECLARE @WH_CODE			NVARCHAR(10)
DECLARE @SEQ				NCHAR(3)
DECLARE @ADDRESS			NVARCHAR(50)
DECLARE @PERSON			NVARCHAR(50)
DECLARE @TEL				NVARCHAR(20)
DECLARE @FAX				NVARCHAR(20)
DECLARE @ZIP				NCHAR(6)
DECLARE @OPT_DATE			DATETIME

    declare binarea_cur cursor local for  select dc_code, bin_area, description, wh_code, seq, address, person, tel, fax, zip from impbinarea where id=@id
	select  @OPT_DATE = getdate()	
	OPEN binarea_cur
		FETCH NEXT FROM binarea_cur into @DC_CODE, @BIN_AREA, @DESCRIPTION, @WH_CODE, @SEQ, @ADDRESS, @PERSON, @TEL, @FAX, @ZIP
		WHILE @@FETCH_STATUS = 0
		BEGIN
			if  exists(select 1 from binarea where dc_code=@DC_CODE and bin_area = @BIN_AREA)
					exec  dbo.stp_U_clsbinarea
						@OLD___dc_code = @DC_CODE,
						@OLD___bin_area = @BIN_AREA, 
						@dc_code = @DC_CODE, 
						@bin_area = @BIN_AREA, 
						@description = @DESCRIPTION, 
						@wh_code = @WH_CODE, 
						@seq = @SEQ, 
						@address = @ADDRESS, 
						@person = @PERSON, 
						@tel = @TEL, 
						@fax = @FAX, 
						@zip = @ZIP, 
						@dif_sku = null,
						@dif_status = null, 
						@dif_owner = null, 
						@define1 = null, 
						@define2 = null, 
						@define3 = null, 
						@define4 = null, 
						@define5 = null, 
						@opt_by = null, 
						@opt_dtime = @OPT_DATE,
						@opt_timestamp = null 
			else
				   exec dbo.stp_I_clsbinarea
						@dc_code = @DC_CODE, 
						@bin_area = @BIN_AREA, 
						@description = @DESCRIPTION, 
						@wh_code = @WH_CODE, 
						@seq = @SEQ, 
						@address = @ADDRESS, 
						@person = @PERSON, 
						@tel = @TEL, 
						@fax = @FAX, 
						@zip = @ZIP, 
						@dif_sku = null, 
						@dif_status = null, 
						@dif_owner = null, 
						@define1 = null, 
						@define2 = null, 
						@define3 = null, 
						@define4 = null, 
						@define5 = null, 
						@opt_by = null, 
						@opt_dtime = @OPT_DATE,
						@opt_timestamp = null 

		FETCH NEXT FROM binarea_cur into @DC_CODE, @BIN_AREA, @DESCRIPTION, @WH_CODE, @SEQ, @ADDRESS, @PERSON, @TEL, @FAX, @ZIP
		END 
	CLOSE binarea_cur
	DEALLOCATE binarea_cur
	delete impbinarea where id=@id
    
end
' 
END
GO
