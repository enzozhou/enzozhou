/****** Object:  StoredProcedure [dbo].[stp_get_DN_Max_LWH]    Script Date: 08/15/2011 10:54:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[stp_get_DN_Max_LWH]
(
    @dc_code nvarchar(10),
    @dn_no nvarchar(20),
    @Max_length numeric(12,3) output,
    @Max_width numeric(12,3) output,
    @Max_height numeric(12,3) output
)
as
begin
	select @Max_length = isnull(max(length),0),@Max_width = isnull(max(width),0),@Max_height = isnull(max(height),0)
      from skuinfo 
      join dnlin 
        on skuinfo.sku_no = dnlin.sku_no 
     where dnlin.dn_no = @dn_no
       and dnlin.dc_code = @dc_code
end
GO
