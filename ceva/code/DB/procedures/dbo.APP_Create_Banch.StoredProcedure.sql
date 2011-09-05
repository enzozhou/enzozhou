/****** Object:  StoredProcedure [dbo].[APP_Create_Banch]    Script Date: 08/15/2011 10:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[APP_Create_Banch](
	@dc_code nvarchar(10),
    @sony_bch_no nvarchar(20),
    @bch_no nvarchar(20),
	@dn_no nvarchar(20),
    @opt_by nvarchar(20),
    @RetCode nvarchar(30) output, 
    @RetMsg nvarchar(255) output
)
as
begin
    declare @opt_dtime datetime
    select @opt_dtime=getdate()
    --如果此批次为新的，创建批次头。
    if not exists(select 1 from bchhdr where dc_code=@dc_code and bch_no=@bch_no)
    begin
		insert into [dbo].[bchhdr](dc_code, bch_no, status_code,locked,opt_by, opt_dtime, start_dtime)
	                        values(@dc_code,@bch_no,0,          0,     @opt_by,@opt_dtime,@opt_dtime)
    end 
    
    --如果此DN单已经在此批次中,程序终止.
    if  exists(select 1 from bchlin where dc_code=@dc_code and bch_no=@bch_no and dn_no =@dn_no)
		begin
           return -1
		end 
    insert into [dbo].[bchlin](dc_code, bch_no, dn_no, status_code,locked,opt_by, opt_dtime, start_dtime)
	                    values(@dc_code,@bch_no,@dn_no,0,          0,     @opt_by,@opt_dtime,@opt_dtime)
    --更新DN状态为组批中（1）
    --update dnhdr set status_code = 1 where dc_code=@dc_code and dn_no = @dn_no
    --update dnlin set status_code = 1 where dc_code=@dc_code and dn_no = @dn_no
    return 1
end
GO
