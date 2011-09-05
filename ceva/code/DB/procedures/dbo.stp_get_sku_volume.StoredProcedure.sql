/****** Object:  StoredProcedure [dbo].[stp_get_sku_volume]    Script Date: 08/15/2011 10:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[stp_get_sku_volume]
(
    @sku_no nvarchar(20),
    @volume numeric(20,9) output
)
as
begin
    select @volume = isnull(volume,0) from skuinfo where sku_no= @sku_no
end
GO
