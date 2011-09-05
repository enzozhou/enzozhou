IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_get_calc_date]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_get_calc_date]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_get_calc_date]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
create proc [stp_get_calc_date]
(
    @dc_code nvarchar(10),
    @own_code nvarchar(10),
    @op_dtime datetime,
    @calc_date datetime output
)
as
begin
    declare @cutoff int
    declare @defaultcutoff int

    select @cutoff=time_cutoff from timecutoff where dc_code=@dc_code and own_code=@own_code
    select @defaultcutoff=convert(int,value) from sysoption where opt_group=''SYS'' and opt_code=''timecutoff'' and sub_code=''default''
    select @defaultcutoff=isnull(@defaultcutoff,8)
    select @cutoff=isnull( @cutoff,@defaultcutoff)
    select @op_dtime=getdate() where @op_dtime is null
    select @calc_date=convert(datetime,convert(nvarchar(30),dateadd(Hour,-@cutoff,@op_dtime),102))
end




' 
END
GO
