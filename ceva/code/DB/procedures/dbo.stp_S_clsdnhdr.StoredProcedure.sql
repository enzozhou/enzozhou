/****** Object:  StoredProcedure [dbo].[stp_S_clsdnhdr]    Script Date: 08/15/2011 10:55:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsdnhdr](
	@OLD___dc_code nvarchar(10),
	@OLD___dn_no nvarchar(20)
)
as               ----根据关键字取得clsdnhdr记录
begin
	select dc_code,dn_no,sony_bch_no,doc_type,imp_dtime,city_to,deal_to,deal_name,deal_person,deal_tel,unloading_address,status_code,opt_by,opt_dtime,start_dtime,end_dtime,remark,opt_timestamp
		from [dbo].[dnhdr]
		where 	dc_code = @OLD___dc_code and
			dn_no = @OLD___dn_no 
end
GO
