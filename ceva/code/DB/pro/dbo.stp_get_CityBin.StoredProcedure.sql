IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_get_CityBin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_get_CityBin]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [stp_get_CityBin]
(
	@BCH_NO			NVARCHAR(20),
	@SONY_BCH_NO		NVARCHAR(20)
)
as
BEGIN

SELECT b.city_to, a.bin_code FROM 
tasklist AS a
LEFT JOIN dnhdr AS b ON a.dn_no = b.dn_no
WHERE (@BCH_NO is null or a.bch_no = @BCH_NO)
and (@SONY_BCH_NO is null or b.sony_bch_no = @SONY_BCH_NO)
ORDER BY b.city_to, a.bin_code

END 

GO
