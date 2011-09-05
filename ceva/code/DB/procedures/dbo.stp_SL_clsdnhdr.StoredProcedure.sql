/****** Object:  StoredProcedure [dbo].[stp_SL_clsdnhdr]    Script Date: 08/15/2011 10:55:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsdnhdr]
as       ----取得clsdnhdr的一个列表
begin
	select top 1000 dc_code,dn_no,sony_bch_no,doc_type,imp_dtime,city_to,deal_to,deal_name,deal_person,deal_tel,unloading_address,status_code,opt_by,opt_dtime,start_dtime,end_dtime,remark,opt_timestamp
		from [dbo].[dnhdr]
end
GO
