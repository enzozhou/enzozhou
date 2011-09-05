/****** Object:  StoredProcedure [dbo].[stp_D_clstasklist]    Script Date: 08/15/2011 10:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[stp_D_clstasklist](
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
    ---更新单据状态
    /*
	dnhdr	status_code	0(初始状态)，1(组批中)，2(货位绑定)，3(任务分配)，4(捡货中)，5（已完成）
	dnlin	status_code	0(初始状态)，1(组批中)，2(货位绑定)，3(任务分配)，4(捡货中)，5（已完成）
	bchdhr	status_code	0(初始状态)，1(货位绑定)，2(任务分配)，3(捡货中)，4（已完成）
	bchlin	status_code	0(初始状态)，1(货位绑定)，2(任务分配)，3(捡货中)，4（已完成）
	taskhdr	status_code	0(初始状态)，1(处理中)，2（已完成）
	tasklist	status_code	0(初始状态)，1(处理中)，2（已完成）
    */
    update bchhdr set status_code = 1 where  dc_code=@dc_code and status_code = 2  and bch_no = @bch_no
    update bchlin set status_code = 1 where  dc_code=@dc_code and status_code = 2  and bch_no = @bch_no
    update dnhdr set status_code = 2  where  dc_code=@dc_code and status_code = 3  and dn_no= @dn_no
    update dnlin set status_code = 2  where  dc_code=@dc_code and status_code = 3  and dn_no= @dn_no

	delete from [dbo].[tasklist]
	where 	task_id = @task_id and
		bch_no = @bch_no and
		dn_no = @dn_no and
		assigned_opt = @assigned_opt and
		dc_code = @dc_code 
end
GO
