/****** Object:  StoredProcedure [dbo].[APP_Optimization_Banch]    Script Date: 08/15/2011 10:53:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[APP_Optimization_Banch](
	@dc_code nvarchar(10),
	@bch_no nvarchar(20),
    @opt_by nvarchar(20),
    @RetCode nvarchar(30) output, 
    @RetMsg nvarchar(255) output
)
as
begin
BEGIN TRANSACTION
	declare	@return_value int
	declare @dn_no nvarchar(20)
    --创建DN临时表,用于重新把DN单城市信息优化
	CREATE TABLE #Optimizationed_DN_List(
			dc_code nvarchar(10),
			dn_no nvarchar(20),
			bch_no nvarchar(20),
			city_to nvarchar(10),
			volume numeric(12,3),
			STATUS int NULL,
			OPT_TIMESTAMP varbinary(8) NULL )
    exec APP_Optimizationed_DN_List_ByBanch @dc_code,@bch_no
    declare Dncur cursor local for select dn_no from #Optimizationed_DN_List where dc_code = @dc_code and  bch_no=@bch_no  order by city_to ,volume
    OPEN Dncur
    FETCH NEXT FROM Dncur into @dn_no
    WHILE @@FETCH_STATUS = 0
    BEGIN
        exec @return_value = [APP_Optimization_DN] @dc_code,@bch_no,@dn_no,@opt_by,@RetCode output,@RetMsg output
			IF @return_value < 0 
				BEGIN 
					ROLLBACK TRANSACTION 
                    delete from bchhdr where dc_code = dc_code and bch_no = @bch_no
                    delete from bchlin where dc_code = dc_code and bch_no = @bch_no
					--DROP table #Optimizationed_DN_List
                    select @RetMsg = @RetMsg + ',系统中没找到合适的货位!'
					CLOSE Dncur
					DEALLOCATE Dncur
                    raiserror(@RetMsg, 16, 1) with nowait
					RETURN -1
				END 
            --更新DN状态为货位绑定（2）
		if  exists(select 1 from dnbin where dc_code=@dc_code and bch_no = @bch_no)
		begin 
            update bchhdr set status_code = 1 where dc_code=@dc_code and bch_no = @bch_no
			update dnhdr set status_code = 2 where dc_code=@dc_code and dn_no = @dn_no
		end
        FETCH NEXT FROM Dncur into @dn_no
    END
    CLOSE Dncur
    DEALLOCATE Dncur
    DROP table #Optimizationed_DN_List
COMMIT TRANSACTION
RETURN 1
end
GO
