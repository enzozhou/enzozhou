/****** Object:  StoredProcedure [dbo].[sp_hht_getTaskList_div_bybchno]    Script Date: 08/15/2011 10:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedure
-- 按照同一个物品,活动用户,单据数量,提取单据数据和活动用户数据给ws调用者--这是2个中间数据集
--	exec sp_hht_getTaskList @assigned_opt @sku_no , @assigned_opt , @sErr
-- 返回: task_id,bch_no,dn_no,bin_code,qty,rqty
-- [sp_hht_getTaskList_div] @sku_no ,@assigned_opt ,@sErr
CREATE procedure [dbo].[sp_hht_getTaskList_div_bybchno]
	@sku_no varchar(50),
	@assigned_opt varchar(50), -- 任务接收人
	@bch_no varchar(50),
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

--	set @sku_no = @sku_no2;
--	-- 增加检测: @sku_no 是否分配给了这个用户:@assigned_opt
--	declare @cnt int
--	select @cnt = count(*) 
--	from tasklist,dnlin 
--	where tasklist.dc_code=dnlin.dc_code and tasklist.dn_no=dnlin.dn_no
--	and dnlin.status_code >=0 and dnlin.sku_no = @sku_no and tasklist.assigned_opt = @assigned_opt
--	if @cnt<1
--	begin
--		Declare @name varchar(50)
--		SELECT @name=user_name 	FROM  OPERATOR where  user_code = @assigned_opt;
--		set @sErr ='物品:[' +@sku_no+']                                               没有分配给用户:' + @name
--		return 
--	end
	
	-- 如果物品都操作完了,则给用户一个提示:
	declare @qty1 int	
	declare @qty2 int
	select @qty1 = sum(dnlin.qty),@qty2=sum(isnull(dnlin.act_qty,0))
	from tasklist,dnlin 
	where tasklist.dc_code=dnlin.dc_code and tasklist.dn_no=dnlin.dn_no
--	and dnlin.status_code >=0
	and dnlin.sku_no = @sku_no
	and tasklist.assigned_opt = @assigned_opt
	and tasklist.bch_no = @bch_no
	if @qty1=@qty2
	begin
		set @sErr ='物品:[' +@sku_no+'],数量='+convert(varchar(30),@qty2)+',已拣货完成!'
		return 
	end

--declare @sku_no nvarchar(20), @assigned_opt nvarchar(20);
declare @optAmount int, @binAMount int;
--set @sku_no = 'P31227177';
--set @assigned_opt = 'enzo1';

--1.取得当前批次操作工数量
	select @optAmount = isnull(count(distinct assigned_opt), 0) from tasklist as tl 
	left join dnlin as dl on tl.dc_code=dl.dc_code and tl.dn_no = dl.dn_no 
	where tl.bch_no = @bch_no and tl.bin_code not in(select bin_code from skuBinSort where task_id = tl.task_id and bch_no = tl.bch_no and sku_no = dl.sku_no and userID <> @assigned_opt)
--	and dl.status_code >=0 
	and dl.sku_no = @sku_no and dl.qty <> isnull(dl.act_qty,0);
--2.取得sku需要库位的数量
--select dl.sku_no, tl.bin_code from tasklist as tl 
--left join dnlin as dl on tl.dn_no = dl.dn_no
--where dl.sku_no = 'P31227177'
--order by dl.sku_no

select @binAMount = count(distinct tl.bin_code) from tasklist as tl 
left join dnlin as dl on tl.dc_code=dl.dc_code and tl.dn_no = dl.dn_no
where tl.bin_code not in(select bin_code from skuBinSort where task_id = tl.task_id and bch_no = tl.bch_no and sku_no = dl.sku_no and userID <> @assigned_opt)
--and dl.status_code >=0 
and tl.bch_no = @bch_no
and dl.sku_no = @sku_no and dl.qty <> isnull(dl.act_qty,0);
--3.库位的数量 mod 操作工数量
	declare @quotient int, @remainder int;
	set @quotient = 0;
	set @remainder = 0;
	if @optAmount > 0 and @optAmount > 0 and @optAmount < @binAMount
--	select @binAMount, @optAmount;
	select @quotient = @binAMount / @optAmount, @remainder = @binAMount % @optAmount;

--4.分配库位
	---删除上次排序记录
		delete from dbo.skuBinSort where userID = @assigned_opt and sku_no = @sku_no and bch_no = @bch_no;
	if @quotient > 0 
	begin
	---写入操作工库位信息到skuBinSort表
		insert into dbo.skuBinSort (bin_code, task_id, bch_no, sku_no, dn_no, userID, opt_time)
		select distinct top (@quotient) tl.bin_code,tl.task_id,tl.bch_no,dl.sku_no, dl.dn_no, @assigned_opt, getdate() from tasklist as tl 
		left join dnlin as dl on tl.dc_code=dl.dc_code and tl.dn_no = dl.dn_no
		where tl.bin_code not in(select bin_code from skuBinSort where task_id = tl.task_id and bch_no = tl.bch_no and sku_no = dl.sku_no and userID <> @assigned_opt)
		and tl.bch_no = @bch_no
		and dl.status_code >=0 and dl.sku_no = @sku_no and dl.qty <> isnull(dl.act_qty,0);

		select distinct top (@quotient) tl.task_id,tl.bch_no,tl.dn_no,tl.bin_code, dl.sku_no, dl.qty as qty, isnull(dl.act_qty,0) as rqty from tasklist as tl 
		left join dnlin as dl on tl.dc_code=dl.dc_code and tl.dn_no = dl.dn_no 
		where tl.bin_code not in(select bin_code from skuBinSort where task_id = tl.task_id and bch_no = tl.bch_no and sku_no = dl.sku_no and userID <> @assigned_opt)
		and tl.bch_no = @bch_no
		and dl.status_code >=0 and dl.sku_no = @sku_no and dl.qty <> isnull(dl.act_qty,0)  and tl.assigned_opt = @assigned_opt
		--group by tl.task_id,tl.bch_no,tl.dn_no,tl.bin_code,dl.sku_no
	end 
	if @quotient = 0 
	begin
		select tl.task_id,tl.bch_no,tl.dn_no,tl.bin_code,dl.sku_no, dl.qty as qty, isnull(dl.act_qty,0) as rqty from tasklist as tl 
		left join dnlin as dl on tl.dc_code=dl.dc_code and tl.dn_no = dl.dn_no 
		where tl.bch_no = @bch_no and dl.status_code >=0 and dl.sku_no = @sku_no and dl.qty <> isnull(dl.act_qty,0) and tl.assigned_opt = @assigned_opt
		--group by tl.task_id,tl.bch_no,tl.dn_no,tl.bin_code,dl.sku_no
	end

end


GO
