/****** Object:  StoredProcedure [dbo].[APP_Optimization_DN_WithOutBanch]    Script Date: 08/15/2011 10:53:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[APP_Optimization_DN_WithOutBanch](
	@dc_code nvarchar(10),
	@dn_no nvarchar(20),
    @opt_by nvarchar(20),
    @RetCode nvarchar(30) output, 
    @RetMsg nvarchar(255) output
)
as
begin
    DECLARE @bch_no nvarchar(20)
    DECLARE	@return_value int
    DECLARE @total_volume numeric(12,3)
    DECLARE @single_volume numeric(12,3)
    DECLARE @ssku_no nvarchar(20)
    DECLARE @nqty numeric(12,3)
    DECLARE @targetBin nvarchar(10)
    DECLARE @targetbinarea nvarchar(10)
    declare @opt_dtime datetime
    select @opt_dtime=getdate()
    SET @total_volume = 0
	SET @return_value = 0
	SET @RetCode = ''
	SET @RetMsg = '' 
    SET @targetBin = '' 
    SELECT @bch_no = bch_no from bchhdr where bch_no in (select distinct bch_no from bch_lin where dc_code= @dc_code and dn_no= @dn_no )
    DECLARE Dnlincur cursor local for select sku_no,qty from dnlin  where dc_code= @dc_code and dn_no= @dn_no 
	OPEN Dnlincur
		FETCH NEXT FROM Dnlincur into @ssku_no,@nqty
		WHILE @@FETCH_STATUS = 0
		BEGIN
			exec @single_volume = stp_get_sku_volume @ssku_no,@single_volume output
            select @total_volume = @total_volume + isnull(@single_volume * @nqty,0)
			FETCH NEXT FROM Dnlincur into @ssku_no,@nqty
		END
    CLOSE Dnlincur
    DEALLOCATE Dnlincur

	DECLARE targetBin cursor local for select bin_code,bin_area from bin where volume > @total_volume  and bin_code not in (select bin_code from  binstatus)order by volume
	OPEN targetBin
		FETCH NEXT FROM targetBin into @targetBin,@targetbinarea
		WHILE @@FETCH_STATUS = 0
		BEGIN
            exec @return_value =  Sp_valid_Bin @targetbinarea,@targetBin,@dn_no,@RetCode output,@RetMsg output
            IF @return_value =1
				begin
                    insert into [dbo].[binStatus]( dc_code,bin_area,bin_code,dn_no,type,status_code,close_auto,
						                           print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime)
					values(@dc_code,@targetbinarea,@targetBin,@dn_no,null,0,0,null,
						   0,null,null,@opt_by,@opt_dtime,@opt_dtime,null)
					insert into [dbo].[DnBin](rowid,dc_code,bch_no,dn_no,bin_area,bin_code,sku_no,qty,type,status_code,close_auto,
		                                      print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime)
	                values('0001',@dc_code,@bch_no,@dn_no,@targetbinarea,@targetBin,'ALL',null,null,0,0,
		                   null,null,null,null,@opt_by,@opt_dtime,@opt_dtime,null)
					return 1
				end  
			FETCH NEXT FROM targetBin into @targetBin,@targetbinarea
		END
    CLOSE targetBin
    DEALLOCATE targetBin
    return -1
end
GO
