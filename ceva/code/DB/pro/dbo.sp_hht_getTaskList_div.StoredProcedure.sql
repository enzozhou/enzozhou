/****** 对象:  StoredProcedure [dbo].[sp_hht_getTaskList_div]    脚本日期: 08/12/2011 16:39:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedure
-- 按照同一个物品,活动用户,单据数量,提取单据数据和活动用户数据给ws调用者--这是2个中间数据集
--	exec sp_hht_getTaskList @assigned_opt @sku_no , @assigned_opt , @sErr
-- 返回: task_id,bch_no,dn_no,bin_code,qty,rqty
-- [sp_hht_getTaskList_div] @sku_no ,@assigned_opt ,@sErr
CREATE procedure [dbo].[sp_hht_getTaskList_div]
	@sku_no varchar(50),
	@assigned_opt varchar(50), -- 任务接收人
	@sErr varchar(255) output
as 
begin
	
	-- [1]10分钟内扫描过本物品的用户列表(=@assigned_opt参数值):

	-- 检查SKU信息:
	-- [sp_hht_checkBarcode] @dn_no,@sku_no,@sku_no2 output,@sErr output
	declare @sku_no2 varchar(50)
	declare @sErr2 varchar(50)
	exec [sp_hht_checkBarcode] '',@sku_no,@sku_no2 output,@sErr2 output
	if @sErr2 <>''
	begin
		set @sErr = '物品『'+@sku_no+'』非法，请检查！'+@sku_no+'   '+@sku_no2;
		return
	end

	-- 合法:刷新SKU_NO

	set @sku_no = @sku_no2;
	-- 增加检测: @sku_no 是否分配给了这个用户:@assigned_opt
	declare @cnt int
	select @cnt = count(*) 
	from tasklist,dnlin 
	where tasklist.dc_code=dnlin.dc_code and tasklist.dn_no=dnlin.dn_no
	and dnlin.status_code >=0 and dnlin.sku_no = @sku_no and tasklist.assigned_opt = @assigned_opt
	if @cnt<1
	begin
		Declare @name varchar(50)
		SELECT @name=user_name 	FROM  OPERATOR where  user_code = @assigned_opt;
		set @sErr ='物品:[' +@sku_no+']                                               没有分配给用户:' + @name
		return 
	end
	
	-- 如果物品都操作完了,则给用户一个提示:
	declare @qty1 int	
	declare @qty2 int
	select @qty1 = sum(dnlin.qty),@qty2=sum(isnull(dnlin.act_qty,0))
	from tasklist,dnlin 
	where tasklist.dc_code=dnlin.dc_code and tasklist.dn_no=dnlin.dn_no
	and dnlin.status_code >=0
	and dnlin.sku_no = @sku_no
	and tasklist.assigned_opt = @assigned_opt
	if @qty1=@qty2
	begin
		set @sErr ='物品:[' +@sku_no+'],数量='+convert(varchar(30),@qty2)+',已拣货完成!'
		return 
	end

	-- select @sku_no as '@sku_no'

	-- 得到可以处理的DN单列表 task_id,bch_no, dn_no, bin_code, qty, rqty, task_id ,sku_no,assigned_opt
	select top 100 tasklist.task_id,tasklist.bch_no,tasklist.dn_no,tasklist.bin_code,dnlin.qty as qty,
		dnlin.sku_no,isnull(dnlin.act_qty,0) as rqty,tasklist.assigned_opt 
	from tasklist,dnlin 
	where tasklist.dc_code=dnlin.dc_code and tasklist.dn_no=dnlin.dn_no
	and dnlin.status_code >=0
	and dnlin.sku_no = @sku_no
	and tasklist.assigned_opt = @assigned_opt
	and dnlin.qty <> isnull(dnlin.act_qty,0)
	order by bin_code
	
	-- 得到相关的活动操作人员列表: task lin 中最近正在操作这个物品的其他用户:
	select distinct tasklin.opt_by
	from tasklin,dnlin
	where tasklin.sku_no = @sku_no
	and tasklin.dn_no = dnlin.dn_no
	and tasklin.sku_no = dnlin.sku_no
	--and Datediff(second,tasklin.opt_dtime,GETDATE()) < 600
	--and dnlin.status_code >= 0
	union 
	select @assigned_opt as opt_by

end

--		exec [sp_hht_getTaskList_div] 'P17806761','zft',''

--		select * from tasklin

--		exec [sp_hht_getTaskList_div] 'P48892776' ,'zft' ,''

--		exec [sp_hht_getTaskList_div] 'P48892776' ,'zft' ,''


--select top 100 tasklist.task_id,tasklist.bch_no,tasklist.dn_no,tasklist.bin_code,dnlin.qty as qty,
--		dnlin.sku_no,isnull(dnlin.act_qty,0) as rqty,tasklist.assigned_opt 
--from tasklist,dnlin 
--where tasklist.dc_code=dnlin.dc_code and tasklist.dn_no=dnlin.dn_no
--and dnlin.status_code >=0
--and dnlin.sku_no = 'P48892776'
--and tasklist.assigned_opt = 'zft'
----and dnlin.qty <> isnull(dnlin.act_qty,0)
--order by bin_code


--
--declare @sku_no varchar(50)
--declare @sku_no2 varchar(50)
--declare @sErr2 varchar(50)
--set @sku_no = 'P48892776'
--
--exec [sp_hht_checkBarcode] '',@sku_no,@sku_no2 output,@sErr2 output
--if @sErr2 <>''
--begin
--	print @sErr2
--end
--print  @sku_no2
--
--
--select * from barcode where (sku_no='P48892776' or sku_no='P4889277') or barcode= 'P4889277';
--
GO
