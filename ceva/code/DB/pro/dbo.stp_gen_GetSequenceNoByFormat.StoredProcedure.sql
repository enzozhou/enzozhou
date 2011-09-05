IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_gen_GetSequenceNoByFormat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_gen_GetSequenceNoByFormat]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_gen_GetSequenceNoByFormat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [stp_gen_GetSequenceNoByFormat]
(
    @FormatCode nvarchar(50),
    @seq DECIMAL(28, 0) OUTPUT
)
as
begin
    --取全局的流水号,该号码存与sysoption中,
    --供导入导入,以及批次生成, 配货生成,以及发货导出等 中间过程的 临时使用.
    SET NOCOUNT ON
    DECLARE @opt_group nVARCHAR(10)
    DECLARE @opt_code nVARCHAR(50)
    DECLARE @sub_code nVARCHAR(20)
    declare @value nvarchar(50)
    SET @opt_group = ''DocFormat''            
    SET @opt_code = @FormatCode     
    SET @sub_code = ''Sequence''        
--    delete sysoption where opt_group = @strOptGroup and opt_code <> @str_TableName
    if not exists(select 1 from sysoption where opt_group = @opt_group AND opt_code = @opt_code and sub_code=@sub_code)
    begin
	insert into sysoption(opt_group,opt_code,sub_code,description,checked,value)
		values(@opt_group,@opt_code,@sub_code,''SequenceNo'',1,''0'')
    end
    select @value=rtrim(value) from sysoption where opt_group = @opt_group AND opt_code = @opt_code and sub_code=@sub_code
    if (isnumeric(@value)=1)
	select @seq=convert(bigint,@value)+1
    else
	select @seq=1
    --这里只取数, 但不更新,  由过程stp_gen_SetSequenceNoByFormat完成更新.
    --update sysoption set value=convert(varchar(50),@seq) where opt_group = @opt_group AND opt_code = @opt_code and sub_code=@sub_code
end


' 
END
GO
