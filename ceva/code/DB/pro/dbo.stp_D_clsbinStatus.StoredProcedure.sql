IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsbinStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_D_clsbinStatus]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clsbinStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_D_clsbinStatus](
	@dc_code nvarchar(10),
	@wh_code nvarchar(10),
	@id int,
	@bin_area nvarchar(10),
	@bin_code nvarchar(10),
	@dn_no nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	delete from [dbo].[binStatus]
	where 	dc_code = @dc_code and
		wh_code = @wh_code and
		id = @id and
		bin_area = @bin_area and
		bin_code = @bin_code and
		dn_no = @dn_no 
end
' 
END
GO
