IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsbchhdr]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsbchhdr]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsbchhdr]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsbchhdr](
	@OLD___dc_code nvarchar(10),
	@OLD___bch_no nvarchar(20),
	@OLD___wh_code nvarchar(10)
)
as               ----根据关键字取得clsbchhdr记录
begin
	select dc_code,bch_no,wh_code,[description],bch_type,status_code,close_auto,print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[bchhdr]
		where 	dc_code = @OLD___dc_code and
			bch_no = @OLD___bch_no and
			wh_code = @OLD___wh_code 
end
' 
END
GO
