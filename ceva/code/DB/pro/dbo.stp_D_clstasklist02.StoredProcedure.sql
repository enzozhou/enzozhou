IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clstasklist02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_D_clstasklist02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clstasklist02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_D_clstasklist02](
	@dc_code nvarchar(10),
	@wh_code nvarchar(10),
	@task_id nvarchar(20),
	@bch_no nvarchar(20),
	@dn_no nvarchar(20),
	@assigned_opt nvarchar(20),
	@bin_area nvarchar(10),
	@bin_code nvarchar(10),
	@sku_no nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clstasklist
		@dc_code = @dc_code,
		@wh_code = @wh_code,
		@task_id = @task_id,
		@bch_no = @bch_no,
		@dn_no = @dn_no,
		@assigned_opt = @assigned_opt,
		@bin_area = @bin_area,
		@bin_code = @bin_code,
		@sku_no = @sku_no,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby

end
' 
END
GO
