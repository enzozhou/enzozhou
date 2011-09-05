IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_get_OperateStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_get_OperateStatus]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [stp_get_OperateStatus]
(
	@BCH_NO			NVARCHAR(20),
	@SONY_BCH_NO		NVARCHAR(20),
	@STATUS_CODE		NCHAR(5),
	@CITY_TO			NVARCHAR(10),
	@BIN_CODE			NVARCHAR(10)
)
as
BEGIN

SELECT CONVERT(varchar(10), a.opt_dtime, 20) as opt_dtime, a.dn_no, a.bch_no, a.bin_code,
CASE 
WHEN a.status_code = 0 THEN '初始状态' 
WHEN a.status_code = 1 THEN '处理中' 
WHEN a.status_code = 2 THEN '已完成' 
END AS status_code
, b.sony_bch_no, b.city_to 
FROM tasklin AS a
LEFT JOIN dnhdr AS b ON a.dn_no = b.dn_no
WHERE (@BCH_NO IS NULL OR a.bch_no = @BCH_NO )
AND (@SONY_BCH_NO IS NULL OR b.sony_bch_no = @SONY_BCH_NO)
AND (@CITY_TO IS NULL OR b.city_to IN (@CITY_TO))
AND (@STATUS_CODE IS NULL OR b.stat_type = @STATUS_CODE)
AND (@BIN_CODE  IS NULL OR a.bin_code LIKE '%'+@BIN_CODE+'%')
--LIKE '%'+@BIN_CODE+'%'
END 

GO
