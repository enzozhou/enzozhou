/****** Object:  StoredProcedure [dbo].[stp_S_clsbchhdr]    Script Date: 08/15/2011 10:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsbchhdr](
	@OLD___dc_code nvarchar(10),
	@OLD___bch_no nvarchar(20)
)
as               ----根据关键字取得clsbchhdr记录
begin
	select dc_code,bch_no,[description],status_code,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[bchhdr]
		where 	dc_code = @OLD___dc_code and
			bch_no = @OLD___bch_no 
end
GO
