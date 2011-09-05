/****** Object:  StoredProcedure [dbo].[APP_Close_DN]    Script Date: 08/15/2011 10:53:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[APP_Close_DN](
	@dc_code nvarchar(10),
	@dn_no nvarchar(20),
    @opt_by nvarchar(20),
    @RetCode nvarchar(30) output, 
    @RetMsg nvarchar(255) output
)
as
begin
	update dnhdr set status_code = 5 where dc_code=@dc_code and dn_no = @dn_no
end
GO
