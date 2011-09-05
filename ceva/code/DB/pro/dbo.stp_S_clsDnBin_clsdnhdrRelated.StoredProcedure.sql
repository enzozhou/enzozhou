IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsDnBin_clsdnhdrRelated]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsDnBin_clsdnhdrRelated]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsDnBin_clsdnhdrRelated]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsDnBin_clsdnhdrRelated](
	@OLD___dc_code nvarchar(10),
	@OLD___wh_code nvarchar(10),
	@OLD___dn_no nvarchar(20)
)
as               ----根据clsdnhdr的关联字段获得clsDnBin的列表
begin
	select rowid,dc_code,bch_no,wh_code,dn_no,bin_area,bin_code,sku_no,qty,type,status_code,close_auto,print_by,print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime,opt_timestamp
		from [dbo].[DnBin]
		where 	dc_code = @OLD___dc_code and
			wh_code = @OLD___wh_code and
			dn_no = @OLD___dn_no 
end
' 
END
GO
