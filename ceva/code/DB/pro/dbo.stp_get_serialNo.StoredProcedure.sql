IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_get_serialNo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_get_serialNo]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [stp_get_serialNo]
(
	@BCH_NO			NVARCHAR(20),
	@SONY_BCH_NO		NVARCHAR(20)
)
as
begin

SELECT tl.dn_no, substring(tl.sku_no, 2, len(tl.sku_no)) as sku_no, 
substring(sno, 4, 7) AS sno
, DENSE_RANK()  OVER(PARTITION BY tl.dn_no, tl.sku_no ORDER BY tl.dn_no, tl.sku_no, sno) as id
FROM tasklin AS tl
LEFT JOIN dnhdr  AS dn ON dn.dn_no = tl.dn_no
WHERE sno <> '' AND (@BCH_NO IS NULL OR bch_no like '%'+@BCH_NO+'%')
AND (@SONY_BCH_NO IS NULL OR dn.sony_bch_no like '%'+@SONY_BCH_NO+'%')
group by tl.dn_no, tl.sku_no, sno
order by tl.dn_no 
end 

GO
