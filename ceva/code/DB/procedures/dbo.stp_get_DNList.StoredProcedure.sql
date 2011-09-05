IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_get_DNList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_get_DNList]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [stp_get_DNList]
(
	@BCH_NO			NVARCHAR(20),
	@SONY_BCH_NO		NVARCHAR(20),
	@CITY_TO			NVARCHAR(10),
	@BIN_CODE			NVARCHAR(10),
	@SKU_NO			NVARCHAR(20),
	@MODEL_NO			NVARCHAR(50)
)
as
BEGIN

SELECT convert(NVARCHAR(10), a.opt_dtime, 120) AS opt_dtime, a.dn_no, b.sony_bch_no, a.bch_no, b.city_to, a.sku_no, c.model_no, CAST(sum(a.qty) as int) AS qty, a.bin_code FROM tasklin AS a
LEFT JOIN dnhdr AS b ON a.dn_no = b.dn_no
LEFT JOIN skuinfo AS c ON a.sku_no = c.sku_no
WHERE (@BCH_NO IS NULL OR a.bch_no = @BCH_NO)
AND (@SONY_BCH_NO IS NULL OR b.sony_bch_no = @SONY_BCH_NO)
AND (@CITY_TO IS NULL OR b.city_to IN (@CITY_TO))
AND (@BIN_CODE  IS NULL OR a.bin_code LIKE '%'+@BIN_CODE+'%')
AND (@SKU_NO  IS NULL OR a.sku_no LIKE '%'+@SKU_NO+'%')
AND (@MODEL_NO  IS NULL OR c.model_no LIKE '%'+@MODEL_NO+'%' )
GROUP BY convert(NVARCHAR(10), a.opt_dtime, 120), a.dn_no, a.dn_no, a.sku_no, a.bin_code, a.bch_no, b.sony_bch_no, b.city_to, c.model_no 
ORDER BY a.dn_no
END 

GO
