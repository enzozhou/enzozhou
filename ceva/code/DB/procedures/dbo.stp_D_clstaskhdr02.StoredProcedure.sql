/****** Object:  StoredProcedure [dbo].[stp_D_clstaskhdr02]    Script Date: 08/15/2011 10:54:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_D_clstaskhdr02](
	@dc_code nvarchar(10),
	@task_id nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clstaskhdr
		@dc_code = @dc_code,
		@task_id = @task_id,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby

end
GO
