/****** 对象:  StoredProcedure [dbo].[sp_hht_getTasklin]    脚本日期: 08/12/2011 16:39:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--	--	取得clstasklist的一个列表
--	exec sp_hht_getTasklin @task_id,
--	dc_code, wh_code, task_id, bch_no, dn_no, assigned_opt, bin_area, bin_code, tasklist.sku_no,skuinfo.sku_desc, 
--	qty, type, status_code, tasklist.opt_by, tasklist.opt_dtime
CREATE procedure [dbo].[sp_hht_getTasklin]
	@task_id varchar(50), -- 任务单号
	@assigned_opt varchar(50),	
	@sErr varchar(255) output
as 
begin
	
	SELECT  tasklist.bch_no, tasklist.dn_no, tasklist.assigned_opt, tasklist.bin_area, tasklist.bin_code, 
			tasklist.sku_no,skuinfo.sku_desc,sum(tasklist.qty) as qty,sum(tasklin.qty) as rqty
	FROM tasklist,skuinfo,tasklin
		where tasklist.sku_no = skuinfo.sku_no
		and tasklist.sku_no = skuinfo.sku_no
		and tasklist.task_id = tasklin.task_id
		and tasklist.task_id = @task_id	
		and tasklist.assigned_opt = @assigned_opt
		and tasklist.assigned_opt = @assigned_opt
		group by tasklist.bch_no, tasklist.dn_no, tasklist.assigned_opt, 
			tasklist.bin_area, tasklist.bin_code, tasklist.sku_no,skuinfo.sku_desc

end

--	exec sp_hht_getTasklin '2001','123',''
GO
