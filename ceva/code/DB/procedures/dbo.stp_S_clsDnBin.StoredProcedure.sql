/****** Object:  StoredProcedure [dbo].[stp_S_clsDnBin]    Script Date: 08/15/2011 10:55:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsDnBin](
	@OLD___dc_code nvarchar(10),
	@OLD___dn_no nvarchar(20),
	@OLD___bin_area nvarchar(10),
	@OLD___bin_code nvarchar(10),
	@OLD___bch_no nvarchar(20)
)
as               ----根据关键字取得clsDnBin记录
begin
	select rowid,dc_code,dn_no,bin_area,bin_code,status_code,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp,bch_no
		from [dbo].[DnBin]
		where 	dc_code = @OLD___dc_code and
			dn_no = @OLD___dn_no and
			bin_area = @OLD___bin_area and
			bin_code = @OLD___bin_code and
			bch_no = @OLD___bch_no 
end
GO
