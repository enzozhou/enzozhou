IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsbchhdr]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_D_clsbchhdr]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsbchhdr]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_D_clsbchhdr](
	@dc_code nvarchar(10),
	@bch_no nvarchar(20),
	@wh_code nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[bchhdr]
	where 	dc_code = @dc_code and
		bch_no = @bch_no and
		wh_code = @wh_code 
end
' 
END
GO
