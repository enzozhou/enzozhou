/****** Object:  StoredProcedure [dbo].[stp_SL_clsDnBin]    Script Date: 08/15/2011 10:55:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsDnBin]
as       ----取得clsDnBin的一个列表
begin
	select top 1000 rowid,dc_code,dn_no,bin_area,bin_code,status_code,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp,bch_no
		from [dbo].[DnBin]
end
GO
