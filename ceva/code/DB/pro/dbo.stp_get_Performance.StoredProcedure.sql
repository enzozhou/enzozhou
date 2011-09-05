IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_get_Performance]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_get_Performance]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [stp_get_Performance]
(
	@BCH_NO			NVARCHAR(20),
	@SONY_BCH_NO		NVARCHAR(20)
)
as
BEGIN

SELECT CONVERT(varchar(10), tasklin.opt_dtime, 20) as opt_dtime, 
tasklin.opt_by,dnhdr.sony_bch_no, tasklin.bch_no, 
CAST(sum(tasklin.qty) AS INT) AS sum_qty, count(tasklin.dn_no) as sum_dn
FROM tasklin
LEFT JOIN dnhdr ON tasklin.dn_no = dnhdr.dn_no
--left join 
WHERE @BCH_NO IS NULL OR tasklin.bch_no = @BCH_NO 
AND @SONY_BCH_NO IS NULL OR dnhdr.sony_bch_no = @SONY_BCH_NO 
--AND tasklin.opt_dtime BETWEEN @BEGIN_TIME AND @END_TIME
GROUP BY tasklin.opt_by, tasklin.bch_no, dnhdr.sony_bch_no,CONVERT(varchar(10), tasklin.opt_dtime, 20)
--HAVING sum(tasklin.qty) > 10 AND count(tasklin.dn_no)  > 20
ORDER BY tasklin.bch_no, dnhdr.sony_bch_no


END 

GO
