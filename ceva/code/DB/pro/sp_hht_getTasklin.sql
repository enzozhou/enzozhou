set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

--	--	取得clstasklist的一个列表
--	exec sp_hht_getTasklin @task_id,
--	dc_code, wh_code, task_id, bch_no, dn_no, assigned_opt, bin_area, bin_code, tasklist.sku_no,skuinfo.sku_desc, 
--	qty, type, status_code, tasklist.opt_by, tasklist.opt_dtime
Alter procedure sp_hht_getTasklin
	@task_id varchar(50), -- 任务单号
	@assigned_opt varchar(50)
as 
begin
	
	SELECT  bch_no, dn_no, assigned_opt, bin_area, bin_code, tasklist.sku_no,skuinfo.sku_desc, 
		qty, status_code, tasklist.opt_by, tasklist.opt_dtime
	FROM tasklist,skuinfo
	where tasklist.sku_no = skuinfo.sku_no
	and task_id = @task_id
	and assigned_opt = @assigned_opt

end

--	exec sp_hht_getTasklin @task_id
--	exec sp_hht_getTasklin '2001','uid01'
