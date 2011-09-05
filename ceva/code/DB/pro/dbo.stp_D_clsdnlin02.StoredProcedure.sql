IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsdnlin02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_D_clsdnlin02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsdnlin02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_D_clsdnlin02](
	@dc_code nvarchar(10),
	@dn_no nvarchar(20),
	@row_id nchar(5),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clsdnlin
		@dc_code = @dc_code,
		@dn_no = @dn_no,
		@row_id = @row_id,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby

end
' 
END
GO
