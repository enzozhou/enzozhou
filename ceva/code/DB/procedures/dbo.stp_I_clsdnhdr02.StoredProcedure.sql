/****** Object:  StoredProcedure [dbo].[stp_I_clsdnhdr02]    Script Date: 08/15/2011 10:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsdnhdr02]( 
	@dc_code nvarchar(10),
	@dn_no nvarchar(20),
	@sony_bch_no nvarchar(20),
	@doc_type nchar(3),
	@imp_dtime datetime,
	@city_to nvarchar(10),
	@deal_to nvarchar(10),
	@deal_name nvarchar(50),
	@deal_person nvarchar(50),
	@deal_tel nvarchar(30),
	@unloading_address nvarchar(100),
	@status_code nchar(5),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@start_dtime datetime,
	@end_dtime datetime,
	@remark ntext,
	@opt_timestamp timestamp output
)
as 
begin
exec stp_I_clsdnhdr
	@dc_code = @dc_code,
	@dn_no = @dn_no,
	@sony_bch_no = @sony_bch_no,
	@doc_type = @doc_type,
	@imp_dtime = @imp_dtime,
	@city_to = @city_to,
	@deal_to = @deal_to,
	@deal_name = @deal_name,
	@deal_person = @deal_person,
	@deal_tel = @deal_tel,
	@unloading_address = @unloading_address,
	@status_code = @status_code,
	@opt_by = @opt_by,
	@opt_dtime = @opt_dtime,
	@start_dtime = @start_dtime,
	@end_dtime = @end_dtime,
	@remark = @remark,
	@opt_timestamp = @opt_timestamp output
end
GO
