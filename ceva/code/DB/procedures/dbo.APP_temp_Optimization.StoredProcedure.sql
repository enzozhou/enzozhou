/****** Object:  StoredProcedure [dbo].[APP_temp_Optimization]    Script Date: 08/15/2011 10:53:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[APP_temp_Optimization](
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
    --在临时表里插入DN。
    if  not exists(select 1 from tempdnbin where dc_code=@dc_code and bch_no=@bch_no and dn_no =@dn_no)
		begin
            insert into [dbo].[tempdnbin](rowid,dc_code,bch_no,dn_no,opt_by,opt_dtime,start_dtime,end_dtime)
	                               values('0001',@dc_code,@bch_no,@dn_no,@opt_by,@opt_dtime,@opt_dtime,null)
		end 

end
GO
