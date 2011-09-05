/****** Object:  StoredProcedure [dbo].[stp_get_DN_volume]    Script Date: 08/15/2011 10:54:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[stp_get_DN_volume]
(
    @dc_code nvarchar(10),
    @dn_no nvarchar(20),
    @volume numeric(20,9) output
)
as
begin
	DECLARE @ssku_no nvarchar(20)
    DECLARE @nqty numeric(12,3)
	DECLARE @single_volume numeric(20,9)
    SET @single_volume = 0
    SET @volume = 0
	DECLARE Dnlincur cursor local for select sku_no,isnull(qty,0) as qty from dnlin  where dc_code= @dc_code and dn_no= @dn_no 
	OPEN Dnlincur
		FETCH NEXT FROM Dnlincur into @ssku_no,@nqty
		WHILE @@FETCH_STATUS = 0
		BEGIN
			exec stp_get_sku_volume @ssku_no,@single_volume output
            select @volume = isnull(@volume,0) + isnull(@single_volume * @nqty,0)
			FETCH NEXT FROM Dnlincur into @ssku_no,@nqty
		END
    CLOSE Dnlincur
    DEALLOCATE Dnlincur
end
GO
