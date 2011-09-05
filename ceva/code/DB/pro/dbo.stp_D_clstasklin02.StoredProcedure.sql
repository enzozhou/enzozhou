IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clstasklin02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_D_clstasklin02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_D_clstasklin02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_D_clstasklin02](
	@rowid nvarchar(10),
	@dc_code nvarchar(10),
	@wh_code nvarchar(10),
	@task_id nvarchar(20),
	@bin_area nvarchar(10),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	exec stp_D_clstasklin
		@rowid = @rowid,
		@dc_code = @dc_code,
		@wh_code = @wh_code,
		@task_id = @task_id,
		@bin_area = @bin_area,
		@opt_timestamp = @opt_timestamp,
		@stroptby = stroptby

end
' 
END
GO
