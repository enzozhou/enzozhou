/****** Object:  StoredProcedure [dbo].[APP_Create_Task]    Script Date: 08/15/2011 10:53:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[APP_Create_Task](
	@dc_code nvarchar(10),
    @task_no nvarchar(20),
	@bch_no nvarchar(20),
    @user_code nvarchar(20),
    @opt_by nvarchar(20),
    @RetCode nvarchar(30) output, 
    @RetMsg nvarchar(255) output
)
as
begin
	declare @dn_no nvarchar(20)
	declare @bin_area nvarchar(10)
	declare @bin_code nvarchar(10)
    declare @opt_dtime datetime
    select @opt_dtime=getdate()
/*
    if  exists(select 1 from taskhdr where dc_code=@dc_code and bch_no = @bch_no)
	begin
		select @RetMsg = '此批次:' +@bch_no +'已经被创建任务了'
		raiserror(@RetMsg, 16, 1) with nowait
        return -1
	end
*/
    --如果此任务为新的，创建任务头。
    if not exists(select 1 from taskhdr where dc_code=@dc_code and task_id=@task_no)
	begin
		insert into [dbo].[taskhdr]( dc_code,task_id,bch_no,status_code,opt_by,opt_dtime,start_dtime)
							  values(@dc_code,@task_no,@bch_no,0,@opt_by,@opt_dtime,@opt_dtime)
		update bchhdr set status_code = 2 where dc_code=@dc_code and bch_no= @bch_no and status_code <2
	end
    DECLARE tasklist cursor local for select dn_no,bin_area,bin_code from dnbin where bch_no = @bch_no and dc_code = @dc_code
    OPEN tasklist
		FETCH NEXT FROM tasklist into @dn_no,@bin_area,@bin_code
		WHILE @@FETCH_STATUS = 0
		BEGIN
            if not exists(select 1 from tasklist where dc_code=@dc_code and task_id=@task_no and assigned_opt = @user_code and dn_no=@dn_no and bch_no = @bch_no)
            begin
				insert into [dbo].[tasklist](task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,opt_by,opt_dtime,start_dtime,dc_code,status_code)
	                   values(@task_no,@bch_no,@dn_no,@user_code,@bin_area,@bin_code,@opt_by,@opt_dtime,@opt_dtime,@dc_code,0)
				update bchlin set status_code = 2 where dc_code=@dc_code and bch_no= @bch_no and dn_no = @dn_no and status_code <2
            end
			
			FETCH NEXT FROM tasklist into @dn_no,@bin_area,@bin_code
		END
    CLOSE tasklist
    DEALLOCATE tasklist
end
GO
