/****** Object:  StoredProcedure [dbo].[APP_RE_Optimization_Banch]    Script Date: 08/15/2011 10:53:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[APP_RE_Optimization_Banch](
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
    declare Dncur cursor local for select dn_no from dnhdr 
                                     where dn_no in (select distinct dn_no  from bchlin where dc_code=@dc_code and bch_no=@bch_no) 
                                       and dn_no not in (select distinct dn_no from tasklist where dc_code=@dc_code and bch_no=@bch_no ) order by city_to
    OPEN Dncur
    FETCH NEXT FROM Dncur into @dn_no
    WHILE @@FETCH_STATUS = 0
    BEGIN
        exec @return_value = [APP_Optimization_DN] @dc_code,@bch_no,@dn_no,@opt_by,@RetCode output,@RetMsg output
			IF @return_value < 0 
				BEGIN 
					CLOSE Dncur
					DEALLOCATE Dncur
					ROLLBACK TRANSACTION
                    delete from bchhdr where dc_code = dc_code and bch_no = @bch_no
                    delete from bchlin where dc_code = dc_code and bch_no = @bch_no
                    select @RetMsg = '发货单:' +@dn_no +'没找到合适的货位'
                    raiserror(@RetMsg, 16, 1) with nowait
					RETURN -1
				END
            --更新DN状态为货位绑定（2）
			update dnhdr set status_code = 2 where dc_code=@dc_code and dn_no = @dn_no
			update dnlin set status_code = 2 where dc_code=@dc_code and dn_no = @dn_no
        FETCH NEXT FROM Dncur into @dn_no
    END
    CLOSE Dncur
    DEALLOCATE Dncur
COMMIT TRANSACTION
	RETURN 1
end
GO
