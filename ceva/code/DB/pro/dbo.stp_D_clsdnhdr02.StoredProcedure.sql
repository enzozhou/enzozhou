IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsdnhdr02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_D_clsdnhdr02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsdnhdr02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_D_clsdnhdr02](
	@dc_code nvarchar(10),
	@dn_no nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clsdnhdr
		@dc_code = @dc_code,
		@dn_no = @dn_no,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby

end
' 
END
GO
