set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

--取得clstasklist的一个列表
--	exec sp_hht_getTaskList @assigned_opt
-- bch_no,dn_no,bin_code,qty,rqty
ALTER procedure [dbo].[sp_hht_getTaskList]
	@assigned_opt varchar(50) -- 任务接收人
as 
begin
	-- 取得按照任务单和对应的扫描汇总数量字段
	-- top 1000 dc_code,wh_code,task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,sku_no,qty,type,status_code,opt_by,opt_dtime
	select top 100 tasklist.bch_no,tasklist.dn_no,tasklist.bin_code,tasklist.qty,sum(tasklin.qty) as rqty
	from [dbo].[tasklist],tasklin
	where tasklist.dc_code=tasklin.dc_code and tasklist.bch_no=tasklin.bch_no and tasklist.task_id=tasklin.task_id 
	and assigned_opt = @assigned_opt
	and tasklist.status_code like '%'
	group by tasklist.bch_no,tasklist.dn_no,tasklist.bin_code,tasklist.qty,tasklist.status_code

end

--	exec sp_hht_getTaskList 'uid02'
