/****** Object:  StoredProcedure [dbo].[stp_D_clstaskhdr]    Script Date: 08/15/2011 10:54:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[stp_D_clstaskhdr](
	@dc_code nvarchar(10),
	@task_id nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin

	declare @RetMsg nvarchar(255)
    if  exists(select 1 from tasklin where dc_code=@dc_code and task_id = @task_id)
	begin
		select @RetMsg = '此任务[' +@task_id +']已操作,不能删除！'
		raiserror(@RetMsg, 16, 1) with nowait
        return -1
	end
    --真实删除
	delete from [dbo].[taskhdr]
	where 	dc_code = @dc_code and
		task_id = @task_id 
end
GO
