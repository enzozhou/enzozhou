/****** Object:  StoredProcedure [dbo].[stp_D_clstasklist02]    Script Date: 08/15/2011 10:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clstasklist02](
	@task_id nvarchar(20),
	@bch_no nvarchar(20),
	@dn_no nvarchar(20),
	@assigned_opt nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@dc_code nvarchar(10),
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clstasklist
		@task_id = @task_id,
		@bch_no = @bch_no,
		@dn_no = @dn_no,
		@assigned_opt = @assigned_opt,
		@opt_timestamp = @opt_timestamp,
		@dc_code = @dc_code,
		@stroptby = stroptby

end
GO
