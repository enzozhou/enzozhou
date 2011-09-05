/****** 对象:  StoredProcedure [dbo].[sp_hht_getTaskList]    脚本日期: 08/12/2011 16:39:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--取得clstasklist的一个列表
--	exec sp_hht_getTaskList @assigned_opt
CREATE procedure [dbo].[sp_hht_getTaskList]
	@assigned_opt varchar(50), -- 任务接收人
	@sErr varchar(255) output
as 
begin
	declare @uid varchar(50)
	set @uid = '';
	-- 取得按照任务单和对应的扫描汇总数量字段
	-- top 1000 dc_code,wh_code,task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,sku_no,qty,type,status_code,opt_by,opt_dtime
	select top 100 tasklist.task_id,tasklist.bch_no,tasklist.dn_no,tasklist.bin_code,dnlin.qty as qty,
		isnull(dnlin.act_qty,0) as rqty,@uid as uid_div
	from tasklist, dnlin 
	where tasklist.dc_code=dnlin.dc_code and tasklist.dn_no=dnlin.dn_no
	and assigned_opt = @assigned_opt
	and dnlin.row_id = 1
	and tasklist.status_code like '%'

end

--	exec sp_hht_getTaskList '110',''
GO
