/****** Object:  StoredProcedure [dbo].[stp_Gen_DocNum]    Script Date: 08/15/2011 10:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[stp_Gen_DocNum]
(
    @dc_code nvarchar(10),
    @TableName nvarchar(50),
    @FieldName nvarchar(50),
    @FormatCode nvarchar(50),
    @Ex nvarchar(50),
    @DocNumber nVARCHAR(20) OUTPUT
) AS
BEGIN
    /*取得新的单号(DC不同,单号允许相同)
     * Here need to first select the Formatting information from the [sysoption] table.
     * Then based on those information, generate a new document number - this would
     * be consisted of 
     *  "Prefix + NewSequenceNumber + Postfix".
     * Note the NewSequenceNumber can be computed by selecting the biggest existing number 
     * (call it bigNum) in the table [@str_TableName] and then adding it by @intIncrementBy.
     * That is         
     *  NewSequenceNumber = bigNum + @intIncrementBy

    @FormatCode:
        Public Const FormatLoan As String = "Loan"
        Public Const FormatRepair As String = "Repair"
        Public Const FormatTemporarily As String = "Temporarily"
        Public Const FormatDeliveryReq As String = "DeliveryReq"
        Public Const FormatDamage As String = "Damage"
        Public Const FormatArchive As String = "Archive"
        Public Const FormatKitReq As String = "KitReq"
        Public Const FormatKitTask As String = "KitTask"
        Public Const FormatSkuMeasure As String = "SkuMeasure"
        Public Const FormatCycleCount As String = "CycleCount"
        Public Const FormatMovement As String = "Movement"
        Public Const FormatBatch As String = "Batch"
        Public Const FormatPicking As String = "Picking"
     */
    SET NOCOUNT ON
    DECLARE @intRowCount INT
    DECLARE @strQuery NVARCHAR(4000)
    DECLARE @strCurrBigDocNo nVARCHAR(20)
    DECLARE @strCurrSeqPart nVARCHAR(20)
    DECLARE @strPrefix nVARCHAR(100)
    DECLARE @strNumFormat nVARCHAR(100)
    DECLARE @strSuffix nVARCHAR(100)
--    DECLARE @intIncrementBy INT
    DECLARE @strOptGroup nVARCHAR(10)
    DECLARE @decSeqNbr DECIMAL(28, 0)
    DECLARE @intLenSeqNbr INT
    DECLARE @strTemp nVARCHAR(500)
    DECLARE @intCnt INT
    DECLARE @intLenNumFormat INT
    DECLARE @intTemp INT
    declare @int_ErrCode int
    -----------------------------------------------------------------------------
    SET @strOptGroup = 'DocFormat'            -- description = 'DocGenEntry'
    SELECT @DocNumber = ''
    -- Checks if the input is valid.
    IF (ISNULL(@TableName, '') = '')
    BEGIN
        -- Salem Su 2002/07/25, for returning language specific error message
        -- SET @int_ErrCode = -1
        -- SET @str_ErrMsg = 'Incorrect Input.'
        raiserror('{GenDocumentWithoutTableName}No Table Name',16,1) with nowait
        return
    END
    -- Searches the formating information (using the TableName).
    -- Note its an error if cannot find an unique entry.
    -- PRINT 'SELECT BY TABLE NAME'
    --select * from sysoption where opt_group='DocFormat' and opt_code='CycleCount'
    SELECT @strPrefix = ISNULL(value, '') from sysoption where opt_group=@strOptGroup and opt_code=@FormatCode and sub_code='Prefix'
    SELECT @strNumFormat = ISNULL(value, '') from sysoption where opt_group=@strOptGroup and opt_code=@FormatCode and sub_code='NumFormat'
    SELECT @strSuffix = ISNULL(value, '') from sysoption where opt_group=@strOptGroup and opt_code=@FormatCode and sub_code='Suffix'
--print @strOptGroup
--print @FormatCode
--print @strPrefix+' '+@strNumFormat +' '+ @strSuffix
--print isnull(@strNumFormat,'NULL')
    --select datalength(convert(nvarchar(50),'1'))
    IF (datalength(isnull(@strNumFormat,''))<1)
    BEGIN
        -- SET @int_ErrCode = -1
        raiserror('{GenDocumentNoOption}Format is not set',16,1) with nowait
        return
    END
    -- Check if the retrieved data is in correct format. Need to see if @strNumFormat
    -- contains any numbers at all. Note here, we represent a number with digit '0'
    SELECT @strTemp = '', @intCnt = 0, @intLenSeqNbr = 0
    SET @intLenNumFormat = LEN(ISNULL(@strNumFormat, ''))
    IF (@intLenNumFormat <> 0)
    BEGIN
        WHILE (@intCnt < @intLenNumFormat)
        BEGIN
            -- Here, construct the LIKE criteria and count the number of digits in the sequence.
            IF (SUBSTRING(@strNumFormat, @intCnt + 1, 1) = '0')
            BEGIN
                SET @intLenSeqNbr = @intLenSeqNbr + 1
                SET @strTemp = @strTemp + '[0-9]'
            END
            ELSE IF (SUBSTRING(@strNumFormat, @intCnt + 1, 1) = '''')
                SET @strTemp = @strTemp + ''''''
            ELSE IF (SUBSTRING(@strNumFormat, @intCnt + 1, 1) = '[')
                SET @strTemp = @strTemp + '[[]'
            ELSE
                SET @strTemp = @strTemp + SUBSTRING(@strNumFormat, @intCnt + 1, 1)
            SET @intCnt = @intCnt + 1
        END
    END
    IF (LEN(ISNULL(@strNumFormat, '')) <> 0) AND (@intLenSeqNbr = 0)
    BEGIN
        raiserror('{GenDocumentNumFormatError}Num Format is error',16,1) with nowait
        return
    END
    -- Based on the formatting information, first find the biggest existing number.
    declare @now datetime
    declare @date nvarchar(20)
	declare @calc_date datetime
	declare @calc_date_string nvarchar(20)
    select @now=getdate()
    select @date=convert(nvarchar(20),@now,12)
    select @Ex=isnull(@Ex,'')
	exec stp_get_calc_date NULL,NULL,@now,@calc_date output
	select @calc_date_string=convert(nvarchar(20),@calc_date,12)
	if @calc_date_string is null
		select @calc_date_string=@date

    select @strPrefix=replace(@strPrefix,'@DATE',@date)
    select @strPrefix=replace(@strPrefix,'@CALCDATE',@calc_date_string)
    select @strPrefix=replace(@strPrefix,'@EX',@Ex)
    select @strPrefix=replace(@strPrefix,'[','')
    select @strPrefix=replace(@strPrefix,']','')
    
--print 'tableName='+@TableName
print @FieldName
--print @strPrefix
--print @strTemp
--print @strSuffix

    --批号与配货号允许不同的的DC有相同的号码
    if @TableName in ('bchhdr','pickhdr')
        select @strQuery = 'SELECT TOP 1 @strBigDocNo = [' + @FieldName + '] ' 
                  + 'FROM [' + @TableName + '] '
                  + 'WHERE dc_code='''+@dc_code+''' and rtrim([' + @FieldName + ']) LIKE ''' + @strPrefix + @strTemp + @strSuffix + ''' '
                  + 'ORDER BY [' + @FieldName + '] DESC'
    else    --其它收货单发货单 不同的DC单号也不同
        select @strQuery = 'SELECT TOP 1 @strBigDocNo = [' + @FieldName + '] ' 
                  + 'FROM [' + @TableName + '] '
                  + 'WHERE rtrim([' + @FieldName + ']) LIKE ''' + @strPrefix + @strTemp + @strSuffix + ''' '
                  + 'ORDER BY [' + @FieldName + '] DESC'

PRINT  @strQuery 
    EXEC @intTemp = SP_EXECUTESQL 
                @strQuery,
                N'@strBigDocNo varchar(20) OUTPUT',
                @strBigDocNo = @strCurrBigDocNo OUTPUT
    SELECT @int_ErrCode = @@ERROR
    IF (@int_ErrCode <> 0) OR (@intTemp <> 0)
    BEGIN
        raiserror('{GenDocumentGetMaxError}Get Largest Document error.',16,1) with nowait
        return
    END
    SET @strCurrBigDocNo = ISNULL(@strCurrBigDocNo, '')
    -- PRINT 'Retrieved the Document Number of: !' + @strCurrBigDocNo + '!'
    -- Now from this Biggest Existing Document Number, we need to extract its Sequence Number,
    -- by removing the prefix and postfix.
    --
--print @strCurrBigDocNo

    SELECT @DocNumber = '', @decSeqNbr = 0, @intCnt = 0, @strCurrSeqPart = '', @strTemp = ''
    IF (LEN(ISNULL(@strNumFormat, '')) <> 0)
    BEGIN
        IF (ISNULL(@strCurrBigDocNo, '') = '')
            SET @decSeqNbr = 0
        ELSE
        BEGIN
            SET @strCurrSeqPart = SUBSTRING(@strCurrBigDocNo, LEN(@strPrefix)+1, LEN(@strNumFormat))
            SET @intCnt = 0
            WHILE (@intCnt < @intLenNumFormat)
            BEGIN
                -- Here, construct the LIKE criteria and count the number of digits in the sequence.
                IF (SUBSTRING(@strNumFormat, @intCnt + 1, 1) = '0')
                BEGIN
                    SET @strTemp = @strTemp + SUBSTRING(@strCurrSeqPart, @intCnt + 1, 1)
                END
                SET @intCnt = @intCnt + 1
            END
--            SET @decSeqNbr = CONVERT(DECIMAL(28, 0), @strTemp)
            if (isnumeric(@strTemp)=1)
                SET @decSeqNbr = CONVERT(DECIMAL(28, 0), @strTemp)
            else
                SET @decSeqNbr=0
        END
        -- PRINT 'The part containing sequence number is: !' + @strTemp + '!'
        SET @decSeqNbr = @decSeqNbr + 1

        if not @TableName in ('bchhdr','pickhdr')        --批表, 配货表
        begin
            ------以下代码避免单据删除之后, 再建后还是原来的一个单号--------------------------------------------------------------------------------------------
            declare @seq DECIMAL(28, 0)
            exec stp_gen_GetSequenceNoByFormat @FormatCode,@seq output
            if (@seq>@decSeqNbr)
                select @decSeqNbr=@seq
            exec stp_gen_SetSequenceNoByFormat @FormatCode,@decSeqNbr
            ---------------------------------------------------------------------------------------------------
        end
        SET @strTemp = CONVERT(VARCHAR(30), @decSeqNbr)
        SET @intTemp = LEN(@strTemp)
        IF (@intTemp > @intLenSeqNbr)
        BEGIN
            SET @strTemp = SUBSTRING(@strTemp, (@intTemp - @intLenSeqNbr + 1), @intLenSeqNbr)
        END
        ELSE IF (@intTemp < @intLenSeqNbr)
        BEGIN
            -- need to fill in with zeros
            SET @strTemp = REPLACE(SPACE(@intLenSeqNbr - @intTemp), ' ', '0') + @strTemp
        END
        -- PRINT 'The newly generated sequence number is: !' + @strTemp + '!'
        SET @strCurrSeqPart = ''
        SET @intTemp = 0
        SET @intCnt = 0
        WHILE (@intCnt < @intLenNumFormat)
        BEGIN
            -- Here, construct the LIKE criteria and count the number of digits in the sequence.
            IF (SUBSTRING(@strNumFormat, @intCnt + 1, 1) = '0')
            BEGIN
                SET @strCurrSeqPart = @strCurrSeqPart + SUBSTRING(@strTemp, @intTemp + 1, 1)
                SET @intTemp = @intTemp + 1
            END
            ELSE
                SET @strCurrSeqPart = @strCurrSeqPart + SUBSTRING(@strNumFormat, @intCnt + 1, 1)
                SET @intCnt = @intCnt + 1
        END
        -- PRINT 'The newly generated sequence number PART is: !' + @strCurrSeqPart + '!'
    END -- of generating the sequence number part.
    SET @DocNumber =rtrim( @strPrefix + @strCurrSeqPart + @strSuffix)
    GOTO Exit_Handle
Error_Handle:
    -- PRINT 'Got Error and code is ' + CONVERT(VARCHAR(20), @int_ErrCode)
    -- PRINT 'Error Msg is ' + @str_ErrMsg
    RETURN -1
Exit_Handle:
    -- PRINT 'Doc number = !' + ISNULL(@str_DocNumber, '') + '!'
    RETURN 0
END
GO
