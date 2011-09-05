/****** Object:  StoredProcedure [dbo].[stp_imp_Bin]    Script Date: 11/25/2010 15:42:06 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[stp_imp_Bin]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[stp_imp_Bin]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   proc [dbo].[stp_imp_Bin]
(
    @id bigint
)
as
begin
	DECLARE @DC_CODE		NVARCHAR(10)	
	DECLARE @BIN_CODE		NVARCHAR(10)	
	DECLARE @DESCRIPTION	NVARCHAR(50)	
	DECLARE @WH_CODE		NVARCHAR(10)	
	DECLARE @BIN_TYPE		NVARCHAR(10)	
	DECLARE @BIN_AREA		NVARCHAR(10)	
	DECLARE @AREA			NUMERIC(12, 3)	
	DECLARE @PALLS			NUMERIC(12, 3)	
	DECLARE @LENGTH		NUMERIC(12, 3)	
	DECLARE @WIDTH			NUMERIC(12, 3)	
	DECLARE @WEIGHT		NUMERIC(12, 3)	
	DECLARE @VOLUME		NUMERIC(20, 9)	
	DECLARE @CANPICK		BIT	
	DECLARE @ISBLOCKED		BIT	
	DECLARE @DEFINE1		NVARCHAR(50)	
	DECLARE @DEFINE2		NVARCHAR(50)	
	DECLARE @DEFINE3		NVARCHAR(50)	
	DECLARE @DEFINE4		NVARCHAR(50)	
	DECLARE @DEFINE5		NVARCHAR(50)	
	DECLARE @OPT_BY			NVARCHAR(20)	
	DECLARE @OPT_DTIME		DATETIME
	DECLARE @OPT_DATE		DATETIME
	DECLARE @EXPRESSION	NCHAR(1)
    declare hdrcur cursor local for  select dc_code, bin_code, description, wh_code, bin_type, bin_area, area, palls, length, width, weight, volume, canpick, isblocked, define1, define2, define3, define4, define5, opt_by, opt_dtime from impbin where id=@id
	select  @OPT_DATE = getdate()	
	select @EXPRESSION = CHAR(45)
	OPEN hdrcur
		FETCH NEXT FROM hdrcur into @DC_CODE, @BIN_CODE, @DESCRIPTION, @WH_CODE, @BIN_TYPE, @BIN_AREA, @AREA, @PALLS, @LENGTH, @WIDTH, @WEIGHT, @VOLUME, @CANPICK, @ISBLOCKED, @DEFINE1, @DEFINE2, @DEFINE3, @DEFINE4, @DEFINE5, @OPT_BY, @OPT_DTIME
		WHILE @@FETCH_STATUS = 0
		BEGIN
		select @BIN_AREA = SUBSTRING(@BIN_CODE, 0, CHARINDEX(@EXPRESSION, @BIN_CODE))
			if  exists(select 1 from bin where dc_code=@DC_CODE and bin_code = @BIN_CODE)
				update [dbo].[bin] set 
					dc_code = @dc_code,
					bin_code = @bin_code,
					bin_area = @bin_area,
					length = @length,
					width = @width,
					weight = @weight,
					volume = @volume,
					define5 = @define5,
					opt_by = @opt_by,
					opt_dtime = @opt_dtime
					where dc_code = @DC_CODE and bin_code = @BIN_CODE 					
			else
				insert into [dbo].[bin](
					dc_code,
					bin_code,
					bin_area,
					length,
					width,
					weight,
					volume,
					opt_by,
					opt_dtime)
				values(
					@DC_CODE,
					@BIN_CODE,
					@BIN_AREA,
					@LENGTH,
					@WIDTH,
					@WEIGHT,
					@VOLUME,
					@OPT_BY,
					@OPT_DTIME
				)

				begin --写入Binarea
					if not exists(select 1 from binarea where dc_code=@DC_CODE and bin_area = @BIN_AREA)
						insert into binarea (dc_code, bin_area, opt_dtime) values(@DC_CODE, @BIN_AREA, @OPT_DATE)
				end 
			FETCH NEXT FROM hdrcur into @DC_CODE, @BIN_CODE, @DESCRIPTION, @WH_CODE, @BIN_TYPE, @BIN_AREA, @AREA, @PALLS, @LENGTH, @WIDTH, @WEIGHT, @VOLUME, @CANPICK, @ISBLOCKED, @DEFINE1, @DEFINE2, @DEFINE3, @DEFINE4, @DEFINE5, @OPT_BY, @OPT_DTIME
		END 
	CLOSE hdrcur
	DEALLOCATE hdrcur
	delete impbin where id=@id
end
GO
