/****** Object:  StoredProcedure [dbo].[APP_Optimizationed_DN_List_ByBanch]    Script Date: 08/15/2011 10:53:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[APP_Optimizationed_DN_List_ByBanch](
	@dc_code nvarchar(10),
	@bch_no nvarchar(20)
)
as
begin
	declare	@return_value int
	declare @dn_no nvarchar(20)
    declare @sCity nvarchar(10)
	declare @sDestinationCity nvarchar(10)
	declare @DN_volume numeric(12,3)
	declare Dncur cursor local for select dn_no,city_to from dnhdr where dn_no in (select distinct dn_no  from bchlin where dc_code=@dc_code and bch_no=@bch_no) order by city_to
	OPEN Dncur
	FETCH NEXT FROM Dncur into @dn_no,@sCity
	WHILE @@FETCH_STATUS = 0
		BEGIN
            --begin 重新赋予真实的中转城市
			if exists(select 1 from cityairport where destination=@sCity)
			begin
				select @sCity = transit from cityairport where destination=@sCity
			end 
			select @sDestinationCity = @sCity 
			--end 重新赋予真实的中转城市
            exec @DN_volume = stp_get_DN_volume @dc_code,@dn_no,@DN_volume output
            insert into #Optimizationed_DN_List( dc_code,dn_no,bch_no,city_to,volume, STATUS)
			    values(@dc_code,@dn_no,@bch_no,@sDestinationCity,@DN_volume,0)
			FETCH NEXT FROM Dncur into @dn_no,@sCity
		END
	CLOSE Dncur
	DEALLOCATE Dncur
end
GO
