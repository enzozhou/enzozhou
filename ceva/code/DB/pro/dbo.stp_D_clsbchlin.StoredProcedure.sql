IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsbchlin]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_D_clsbchlin]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsbchlin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_D_clsbchlin](
	@dc_code nvarchar(10),
	@bch_no nvarchar(20),
	@wh_code nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[bchlin]
	where 	dc_code = @dc_code and
		bch_no = @bch_no and
		wh_code = @wh_code 
end
' 
END
GO
