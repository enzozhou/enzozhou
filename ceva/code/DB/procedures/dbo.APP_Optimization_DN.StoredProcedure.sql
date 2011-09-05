/****** Object:  StoredProcedure [dbo].[APP_Optimization_DN]    Script Date: 08/15/2011 10:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[APP_Optimization_DN](
	@dc_code nvarchar(10),
    @bch_no nvarchar(20),
	@dn_no nvarchar(20),
    @opt_by nvarchar(20),
    @RetCode nvarchar(30) output, 
    @RetMsg nvarchar(255) output
)
as
begin
    DECLARE	@return_value int
    DECLARE @DN_volume numeric(12,3)
    DECLARE @Max_length numeric(12,3)
    DECLARE @Max_width numeric(12,3)
    DECLARE @Max_height numeric(12,3)
    DECLARE @ssku_no nvarchar(20)
    DECLARE @nqty numeric(12,3)
    DECLARE @targetBin nvarchar(10)
    DECLARE @targetbinarea nvarchar(10)
    declare @opt_dtime datetime
    select @opt_dtime=getdate()
    --设置初始值
    SET @DN_volume = 0
	SET @return_value = 0
	SET @RetCode = ''
	SET @RetMsg = '' 
    SET @targetBin = '' 
    --得到DN的体积
    exec stp_get_DN_volume @dc_code,@dn_no,@DN_volume output
    exec stp_get_DN_Max_LWH @dc_code,@dn_no,@Max_length output,@Max_width output,@Max_height output

	DECLARE targetBin cursor local for select bin_code,bin_area from bin where volume >= @DN_volume*1.2  
                                                                           and length> = @Max_length
                                                                           and width> = @Max_width
                                                                           and weight >= @Max_height
                                                                           and bin_code not in (select bin_code from  binstatus) order by bin_code,volume
	OPEN targetBin
		FETCH NEXT FROM targetBin into @targetBin,@targetbinarea
		WHILE @@FETCH_STATUS = 0
		BEGIN
            exec @return_value =  Sp_valid_Bin @dn_no,@targetbinarea,@targetBin
            IF @return_value =1
				begin
                    --插入binStatus 
                    delete binStatus where dc_code= @dc_code and dn_no =@dn_no
                    insert into [dbo].[binStatus]( dc_code,bin_area,bin_code,dn_no,type,status_code,close_auto,
						                           print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime)
					values(@dc_code,@targetbinarea,@targetBin,@dn_no,null,0,0,null,
						   0,null,null,@opt_by,@opt_dtime,@opt_dtime,null)
                    --插入DnBin
                    delete DnBin where dc_code= @dc_code and dn_no =@dn_no and bch_no = @bch_no and status_code = 1
					insert into [dbo].[DnBin](rowid,dc_code,bch_no,dn_no,bin_area,bin_code,sku_no,qty,type,status_code,close_auto,
		                                      print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime)
	                values('0001',@dc_code,@bch_no,@dn_no,@targetbinarea,@targetBin,'ALL',null,null,0,0,
		                   null,null,null,null,@opt_by,@opt_dtime,@opt_dtime,null)
                    -- 更新dn line 和Bch line 的状态为绑定中
					if exists(select 1 from dnbin where dc_code=@dc_code and dn_no = @dn_no and bch_no = @bch_no)
					begin 
						update dnlin set status_code = 2 where dc_code=@dc_code and dn_no = @dn_no
						update bchlin set status_code = 1 where dc_code=@dc_code and bch_no = @bch_no and dn_no = @dn_no
					end
					CLOSE targetBin
					DEALLOCATE targetBin
					return 1
				end  
			FETCH NEXT FROM targetBin into @targetBin,@targetbinarea
		END
    CLOSE targetBin
    DEALLOCATE targetBin
    select @RetCode = '-1'
    select @RetMsg = 'DN单['+@dn_no+']的所需总体积为：'+ cast(@DN_volume AS nvarchar(20)) 
    return -1
end
GO
