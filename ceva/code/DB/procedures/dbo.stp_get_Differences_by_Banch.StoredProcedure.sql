/****** Object:  StoredProcedure [dbo].[stp_get_Differences_by_Banch]    Script Date: 08/15/2011 10:54:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[stp_get_Differences_by_Banch]
(
    @dc_code nvarchar(10),
	@BCH_NO	 NVARCHAR(20)
)
as
begin
	select l.dn_no as dn_no ,l.sku_no as sku_no,sum(l.qty) as qty,sum(l.act_qty) as act_qty,isnull(sum(l.qty-l.act_qty),0) as not_qty 
	 from  dnlin l 
	 join  bchlin b 
	   on  l.dc_code = b.dc_code 
	  and  l.dn_no = b.dn_no 
	where  b.dc_code = @dc_code and b.BCH_NO = @BCH_NO
      and  isnull(l.qty-l.act_qty,0) >0
   group by l.dn_no,l.sku_no
   order by l.dn_no
end
GO
