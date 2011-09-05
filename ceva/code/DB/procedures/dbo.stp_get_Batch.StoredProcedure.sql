IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_get_Batch]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_get_Batch]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [stp_get_Batch]
(
	@BCH_NO			NVARCHAR(20),
	@SONY_BCH_NO		NVARCHAR(20)
)
as
BEGIN

SELECT convert(NVARCHAR(10), a.opt_dtime, 120)AS opt_dtime, a.dn_no, a.sony_bch_no, b.bch_no, 
sum(c.volume) AS volume, sum(c.net_weight) AS net_weight,
CASE substring(b.bin_code, 1, 1) WHEN 'A' THEN count(b.bin_code) END AS A,
CASE substring(b.bin_code, 1, 1)WHEN 'B' THEN count(b.bin_code) END AS B,
CASE substring(b.bin_code, 1, 1)WHEN 'C' THEN count(b.bin_code) END AS C,
CASE substring(b.bin_code, 1, 1)WHEN 'D' THEN count(b.bin_code) END AS D,
CASE substring(b.bin_code, 1, 1)WHEN 'T' THEN count(b.bin_code) END AS T
FROM dnhdr AS a
LEFT JOIN tasklin AS b ON a.dn_no = b.dn_no
LEFT JOIN skuinfo AS c ON b.sku_no = c.sku_no
WHERE (@BCH_NO IS NULL OR b.bch_no LIKE '%'+@BCH_NO+'%') AND
(@SONY_BCH_NO IS NULL OR a.sony_bch_no LIKE '%'+@SONY_BCH_NO+'%' )
GROUP BY convert(NVARCHAR(10), a.opt_dtime, 120), a.dn_no, a.sony_bch_no, b.bch_no, b.bin_code
ORDER BY a.dn_no


END 

GO
