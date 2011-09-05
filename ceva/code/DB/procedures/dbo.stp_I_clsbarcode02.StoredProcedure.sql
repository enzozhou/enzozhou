/****** Object:  StoredProcedure [dbo].[stp_I_clsbarcode02]    Script Date: 08/15/2011 10:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsbarcode02]( 
	@sku_no nvarchar(20),
	@barcode nvarchar(30),
	@bar_type nchar(3),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
exec stp_I_clsbarcode
	@sku_no = @sku_no,
	@barcode = @barcode,
	@bar_type = @bar_type,
	@opt_by = @opt_by,
	@opt_dtime = @opt_dtime,
	@opt_timestamp = @opt_timestamp output
end
GO
