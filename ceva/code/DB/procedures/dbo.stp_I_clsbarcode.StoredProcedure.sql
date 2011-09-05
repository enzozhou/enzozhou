/****** Object:  StoredProcedure [dbo].[stp_I_clsbarcode]    Script Date: 08/15/2011 10:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsbarcode]( 
	@sku_no nvarchar(20),
	@barcode nvarchar(30),
	@bar_type nchar(3),
	@opt_by nvarchar(20),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
	insert into [dbo].[barcode]( 
		sku_no,
		barcode,
		bar_type,
		opt_by,
		opt_dtime)
	values(
		@sku_no,
		@barcode,
		@bar_type,
		@opt_by,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
