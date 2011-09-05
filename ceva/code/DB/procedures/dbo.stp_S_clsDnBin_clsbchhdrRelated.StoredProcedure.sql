/****** Object:  StoredProcedure [dbo].[stp_S_clsDnBin_clsbchhdrRelated]    Script Date: 08/15/2011 10:55:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsDnBin_clsbchhdrRelated](
	@OLD___dc_code nvarchar(10),
	@OLD___bch_no nvarchar(20)
)
as               ----根据clsbchhdr的关联字段获得clsDnBin的列表
begin
	select rowid,dc_code,dn_no,bin_area,bin_code,status_code,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp,bch_no
		from [dbo].[DnBin]
		where 	dc_code = @OLD___dc_code and
			bch_no = @OLD___bch_no 
end
GO
