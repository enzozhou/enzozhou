/****** Object:  StoredProcedure [dbo].[stp_D_clsdnlin]    Script Date: 08/15/2011 10:53:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clsdnlin](
	@dc_code nvarchar(10),
	@dn_no nvarchar(20),
	@row_id nchar(5),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[dnlin]
	where 	dc_code = @dc_code and
		dn_no = @dn_no and
		row_id = @row_id 
end
GO
