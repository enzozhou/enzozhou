IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsdnhdr]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsdnhdr]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsdnhdr]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsdnhdr](
	@OLD___dc_code nvarchar(10),
	@OLD___dn_no nvarchar(20)
)
as               ----根据关键字取得clsdnhdr记录
begin
	select dc_code,dn_no,[description],own_code,wh_code,due_date,doc_type,source,stat_type,have_tag,ref_no,status_code,status_trk,imp_dtime,plant,city_from,deal_from,city_to,bill_to,bill_name,bill_person,bill_addr,bill_tel,deal_to,deal_name,deal_person,deal_tel,carr_code,method,unloading_address,instruction,route,point,condition,exp_status,close_auto,archived,print_by,print_counter,print_dtime,opt_by,opt_dtime,start_dtime,end_dtime,remark,opt_timestamp
		from [dbo].[dnhdr]
		where 	dc_code = @OLD___dc_code and
			dn_no = @OLD___dn_no 
end
' 
END
GO
