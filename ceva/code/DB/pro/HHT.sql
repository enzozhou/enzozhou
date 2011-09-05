SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_tasklinScan_ADD]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




------------------------------------
--用途：扫描物品条码或者机身号，增加数量或者减少数量
--项目名称：CodematicDemo
--说明：
--时间：	2011-4-26 14:31:50
------------------------------------
-- [sp_hht_tasklinScan_ADD] @task_id  @bch_no  @dn_no  @bin_code @sku_no  @sno @qty @assigned_opt @sErr
CREATE PROCEDURE [dbo].[sp_hht_tasklinScan_ADD]
	@task_id	varchar(50),
	@bch_no		varchar(50),
	@dn_no		varchar(50),
	@bin_code	varchar(50),
	@sku_no		varchar(50),
	@sno		varchar(50),
	@qty		int,
	@assigned_opt	varchar(50),
	@sErr		varchar(255) output
	--	返回信息值: 
	--	[-1]|错误信息|第三信息|
	--	[ 0]|表示正常|返回用户成功信息|
	--	[-2]|需要扫描机身号，不需要报错，返回即可|
	--  [-4]|判断是否改库位下面的东西都扫描完成了|
AS
	set nocount on
	declare @dc_code nvarchar(10)
	declare @wh_code nvarchar(10)
	declare @opt_by nvarchar(20)
	declare @opt_dtime datetime
	declare @start_dtime datetime
	declare @end_dtime datetime
	declare @rowid nvarchar(10)
	declare @bin_area nvarchar(50)
	declare @type nchar(3)
	declare	@status_code nchar(5)
	declare @close_auto bit
	declare @print_by nvarchar(20)
	declare @print_counter int
	declare @print_dtime datetime
	declare @locked int
	declare @have_sno varchar(10)
	declare @sku_desc varchar(100)
	declare @sku_desc_eng varchar(100)
	declare @cnt int -- 
	declare @sumQty0 int
	declare @sumQty1 int
	declare @bin_area1 varchar(50)
	set @dc_code=''SHA''

	-- ================================================
	-- 公共判断.,.,.,.,
	-- ================================================
	--	[1]单据号判断：是否存在,状态是否允许操作?
	select  @status_code = status_code 
	from taskhdr 
	where task_id = @task_id;
	if @status_code > ''1''
	begin
		set @sErr = ''-1|taskhdr中单据状态为『''+@status_code+''』,不允许继续操作!（需要=0）|'';
		return
	end
	
	SET TRANSACTION ISOLATION LEVEL Read Committed -- REPEATABLE READ
	begin tran T_0002
	-- 更新单据状态：
	update taskhdr set status_code= ''1'' where task_id = @task_id and status_code= ''0'' ;
	if @@error > 0 
	begin
		rollback tran T_0002
		set @sErr = ''-1|保存错误!|''
		return 
	end
	update dnhdr set status_code= ''4'' where dn_no = @dn_no and status_code <> ''5'' ;
	if @@error > 0 
	begin
		rollback tran T_0002
		set @sErr = ''-1|保存错误!|''
		return 
	end
	update dnlin set status_code= ''4'' where dn_no = @dn_no and status_code <> ''5'' and sku_no=@sku_no ;
	if @@error > 0 
	begin
		rollback tran T_0002
		set @sErr = ''-1|保存错误!|''
		return 
	end

	--	[2] 判断物品是否合法
	select @cnt = count(*) from dnlin
		where dn_no = @dn_no and sku_no=@sku_no
	if @cnt<1
	begin
		rollback tran T_0002
		set @sErr = ''-1|物品『''+@sku_no+''』非法，请检查！|'';
		return
	end	

	--	[-4] 判断机身号重复性
	if @sno<>''''
	begin
		select @cnt = count(*) from tasklin
		where task_id = @task_id and sku_no=@sku_no and dn_no = @dn_no 
		and sno=@sno  
		if @cnt>0
		begin
			rollback tran T_0002
			set @sErr = ''-4|机身号重复,请检查！|'';
			return
		end	
	end
	
	-- 判断有无机身号，没有就累加数量，有就返回给前端，让HHT前段定位到机身号字段
	set @sku_desc = ''''
	set @sku_desc_eng = ''''
	SELECT @have_sno=have_sno, @sku_desc=sku_desc, @sku_desc_eng=sku_desc_eng
	FROM   skuinfo
	where sku_no = @sku_no
	if @have_sno is null set @have_sno=''0''
	if @have_sno = ''1''	-- 要求机身号
	begin
		if rtrim(ltrim(@sno)) = ''''	-- 如果没有机身号，这返回....
		begin
			-- set @sErr = ''0||''+@have_sno;
			rollback tran T_0002
			set @sErr = ''-2|''+@sku_desc+''|需要扫描机身号，定位到机身号栏目|''+convert(varchar(10),@have_sno);
			return
		end
		-- 检查重复性：
		select @cnt = count(*) from tasklin 
			where task_id = @task_id and bch_no = @bch_no and sno=@sno
		if @cnt > 0
		begin
			-- set @sErr = ''0||''+@have_sno;
			rollback tran T_0002
			set @sErr = ''-4|机身号''+@sno+''重复，请检查！|''+convert(varchar(10),@have_sno);
			return
		end
	end 
	
	-- 如果不要求，或者已经输入了机身号，这继续...
	if @have_sno <> ''1''	-- 不要求机身号
	begin
		set @sno = ''''
	end

	-- 记录插入,数量增加:-- 取得下一个rowno行号
	select @rowid = isnull(max(convert(decimal,rowid)),0) from tasklin where task_id = @task_id;

	-- 增加或者减少记录:
	if @qty > 0
	begin
		-- 从表中取得其他字段:
		SELECT	@dc_code=dc_code, @wh_code=wh_code,  @bin_area=bin_area,
				@type=type, @status_code=status_code, @close_auto=close_auto, 
				@print_by=print_by, @print_counter=print_counter, @print_dtime=print_dtime, 
				@locked=locked,@start_dtime=start_dtime, @end_dtime=end_dtime
		FROM   tasklist
		where task_id = @task_id and bch_no = @bch_no and assigned_opt = @assigned_opt and dn_no = @dn_no;
		declare @qty10 as int	-- 最大数量
		select @qty10 = sum(isnull(qty,0)) from dnlin where dc_code=@dc_code and dn_no=@dn_no and sku_no=@sku_no;
		declare @qty11 as int	-- 已经扫描数量
		select @qty11 = sum(isnull(qty,0)) from tasklin 
		where dc_code=@dc_code and task_id=@task_id and bch_no=@bch_no and dn_no=@dn_no and bin_area=@bin_area and bin_code=@bin_code and sku_no=@sku_no;
		if @qty11 is null set @qty11=0;
		if @qty11+@qty > @qty10 
		begin
			rollback tran T_0002
			set @sErr = ''-3|数量超出！|''+convert(varchar(10),@have_sno);
			return
		End 
		
--2011-7-29 检查当前批次的机身号是否存在过
-------------------------------------------------
-------------------------------------------------
-------------------------------------------------
-------------------------------------------------
-------------------------------------------------
-------------------------------------------------
-------------------------------------------------
--2011-7-29


		-- 有机身号，简单插入，无则判断后插入：
		if @have_sno = ''1''	-- 要求机身号
			begin
				set @rowid = @rowid+1;
				-- set @bin_area = ''[01]:''
				INSERT INTO tasklin	(rowid,dc_code,wh_code,task_id,bch_no,dn_no,bin_area,bin_code,sku_no,
					sno,type,qty,status_code,close_auto,print_by,
					print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime)
				VALUES(	@rowid,@dc_code,@wh_code,@task_id,@bch_no,@dn_no,@bin_area,@bin_code,@sku_no,
						@sno,@type,@qty,@status_code,@close_auto,@print_by,
						@print_counter,@print_dtime,@locked,@assigned_opt,getdate(),@start_dtime,@end_dtime );
				if @@error > 0 
				begin
					rollback tran T_0002
					set @sErr = ''-1|事务错误！|''
					return 
				end
			End
		Else	-- 如果没有机身号...
			begin
				-- 没有机身号：需要增加一个数据对应的行:
				-- set @bin_area = ''[02]:''
				-- select @rowid = isnull(max(convert(decimal,rowid)),0) from tasklin where task_id = @task_id;
				set  @rowid = @rowid + 1;	
				INSERT INTO tasklin(rowid,dc_code,wh_code,task_id,bch_no,dn_no,bin_area,bin_code,sku_no,
					sno,type,qty,status_code,close_auto,print_by,
					print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime)
				VALUES(@rowid,@dc_code,@wh_code,@task_id,@bch_no,@dn_no,@bin_area,@bin_code,@sku_no,
					@sno,@type,@qty,@status_code,@close_auto,@print_by,
					@print_counter,@print_dtime,@locked,@assigned_opt,getdate(),@start_dtime,@end_dtime );
				if @@error > 0 
				begin
					rollback tran T_0002
					set @sErr = ''-1|事务错误！|''
					return 
				end
			End
	end


	-- 同步更新 dnlin.act_qty 数量字段=sum(tasklin.qty)
	declare @sumQty_Scan int	--	所有已经扫描的数量
	select @sumQty_Scan = sum(qty) from tasklin 
		where dc_code=@dc_code and task_id=@task_id 
		and bch_no=@bch_no and dn_no=@dn_no and bin_area=@bin_area and bin_code=@bin_code and sku_no=@sku_no;
	-- 更新动作
	update dnlin set act_qty=@sumQty_Scan from dnlin where dc_code=@dc_code and dn_no=@dn_no and sku_no=@sku_no;
	if @@error > 0 
	begin
		rollback tran T_0002
		set @sErr = ''-1|事务错误！|''
		return 
	end
	-- 修改提交...
	commit  tran T_0002

	--	刷新前段数据显示:	sku_no,qty,rqty
	select @sumQty1 = isnull(dnlin.act_qty,0),@sumQty0 = isnull(dnlin.qty,0) from dnlin
		where dnlin.dn_no=@dn_no and dc_code=@dc_code and sku_no=@sku_no;
	
	--	刷新前段数据显示:第一部分:中间流水:	sku_no,机身号和rowid
	if @have_sno = ''1''	-- 有机身号,显示机身号清单
		begin
			SELECT rowid, sku_no, sno
			FROM  tasklin
			where task_id = @task_id and bin_code = @bin_code and opt_by=@assigned_opt 
			and sku_no=@sku_no and dn_no=@dn_no
		end
	Else			-- 没有机身号,显示数量
		begin
			SELECT rowid, sku_no, qty as sno
			FROM  tasklin
			where task_id = @task_id and bin_code = @bin_code and opt_by=@assigned_opt 
			and sku_no=@sku_no and dn_no=@dn_no
		End
	

	-- 第二部分: 汇总数量:sumQty1,@sumQty0
	select @sumQty1 as sumQty1,@sumQty0 as sumQty0

	-- 判断是否改库位下面的东西都扫描完成了：
	if @sumQty1>=@sumQty0
	begin
		set @sErr = ''-3||''+convert(varchar(10),@have_sno);
		return
	end
	else
	begin
		set @sErr = ''0||''+convert(varchar(10),@have_sno);
		return
	end

	----------------------------------------------------------------------------------------
	----------------------------------------------------------------------------------------
	--	declare @rowid int
	--	select @rowid = isnull(max(rowid),0) from tasklin where 1=2
	--	print @rowid
	










' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_tasklinScan_Bin_Finish]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
------------------------------------
--用途：库位完成，需要修改单据状态
--项目名称：CodematicDemo
--说明：
--时间：	2011-4-26 14:31:50
------------------------------------
-- [sp_hht_tasklinScan_Bin_Finish] @task_id  @bch_no  @dn_no  @bin_code @assigned_opt @sErr
Create PROCEDURE [dbo].[sp_hht_tasklinScan_Bin_Finish]
	@task_id	varchar(20),
	@bch_no		varchar(10),
	@dn_no		varchar(20),
	@bin_code	varchar(10), 
	@assigned_opt varchar(20),
	@sErr		varchar(255) output
	--	返回信息值: 【-1】|错误信息|第三信息 :: 【0】表示正常|-1,错误,不能保存::返回用户提示信息|
	-- 【-2】需要扫描机身号，不需要报错，返回即可
AS
	set nocount on
	declare @status_code varchar(30)
	declare @cnt int -- 
	declare @sumQty0 int
	declare @sumQty1 int
	-- ================================================
	-- 公共判断：
	-- ================================================
	--	[1]单据号判断：是否存在,状态是否允许操作?
	select  @status_code = status_code 
	from taskhdr 
	where task_id = @task_id;
	if @status_code <> ''0''
	begin
		set @sErr = ''-1|taskhdr中单据状态为''+@status_code+'',不允许继续操作!（需要=0）|''
		return
	end

	--	update taskhdr set 
	--
	--	select * from taskhdr
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_tasklinScan_del]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
------------------------------------
--用途：删除指定rowid的数据行,然后刷新合计数量
--说明：
--时间：	2011-4-26 14:31:50
------------------------------------
-- [sp_hht_tasklinScan_del] @task_id  @bch_no  @dn_no  @bin_code @sku_no  @rowid @assigned_opt @sErr
CREATE PROCEDURE [dbo].[sp_hht_tasklinScan_del]
	@task_id	varchar(50),
	@bch_no		varchar(50),
	@dn_no		varchar(50),
	@bin_code	varchar(50),
	@sku_no		varchar(50),
	@rowid		varchar(50),
	@assigned_opt	varchar(50),
	@sErr		varchar(255) output
AS
	set nocount on
	declare @dc_code nvarchar(10)
	declare @have_sno varchar(10)
	declare @cnt int -- 
	declare @sumQty0 int
	declare @sumQty1 int

	set @dc_code=''SHA''
	
	SET TRANSACTION ISOLATION LEVEL Read Committed -- REPEATABLE READ
	begin tran T_0005

	delete from tasklin where dc_code=@dc_code and task_id=@task_id 
		and bch_no=@bch_no and dn_no=@dn_no and bin_code=@bin_code and rowid=@rowid and sku_no=@sku_no;

	-- 同步更新 dnlin.act_qty 数量字段=sum(tasklin.qty)
	declare @sumQty_Scan int	--	所有已经扫描的数量
	
	select @sumQty_Scan = sum(qty) from tasklin 
		where dc_code=@dc_code and task_id=@task_id 
		and bch_no=@bch_no and dn_no=@dn_no and bin_code=@bin_code and sku_no=@sku_no;

	-- 更新动作
	update dnlin set act_qty=@sumQty_Scan from dnlin where dc_code=@dc_code and dn_no=@dn_no and sku_no=@sku_no;
	if @@error > 0 
	begin
		rollback tran T_0005
		set @sErr = ''-1|删除出错!|''
		return 
	end
	-- 修改提交...
	set @sErr = ''0|删除成功!|''
	commit  tran T_0005


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_getTasklin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
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

--	exec sp_hht_getTasklin ''2001'',''123'',''''


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_getTaskList_div]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


-- 按照同一个物品,活动用户,单据数量,提取单据数据和活动用户数据给ws调用者--这是2个中间数据集
--	exec sp_hht_getTaskList @assigned_opt @sku_no , @assigned_opt , @sErr
-- 返回: task_id,bch_no,dn_no,bin_code,qty,rqty
CREATE procedure [dbo].[sp_hht_getTaskList_div]
	@sku_no varchar(50),
	@assigned_opt varchar(50), -- 任务接收人
	@sErr varchar(255) output
as 
begin

	-- [1]10分钟内扫描过本物品的用户列表(=@assigned_opt参数值):

	-- 得到可以处理的DN单列表 bch_no, dn_no, bin_code, qty, rqty, task_id ,sku_no
	select top 100 tasklist.task_id,tasklist.bch_no,tasklist.dn_no,tasklist.bin_code,dnlin.qty as qty,dnlin.sku_no,
			isnull(dnlin.act_qty,0) as rqty
	from tasklist,dnlin 
	where tasklist.dc_code=dnlin.dc_code and tasklist.dn_no=dnlin.dn_no
	and dnlin.status_code >=0
	and dnlin.sku_no = @sku_no
	and tasklist.assigned_opt = @assigned_opt
	and dnlin.qty <> dnlin.act_qty
	order by bin_code
	
	-- 得到相关的活动操作人员列表:task lin 中最近正在操作这个物品的其他用户:
	select distinct tasklin.opt_by
	from tasklin,dnlin
	where tasklin.sku_no = @sku_no
	and tasklin.dn_no = dnlin.dn_no
	and tasklin.sku_no = dnlin.sku_no
	and Datediff(second,tasklin.opt_dtime,GETDATE()) < 600
	and dnlin.status_code >= 0

	--	-- 取得按照任务单和对应的扫描汇总数量字段
	--	-- top 1000 dc_code,wh_code,task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,sku_no,qty,type,status_code,opt_by,opt_dtime
	--	select top 100 tasklist.task_id,tasklist.bch_no,tasklist.dn_no,tasklist.bin_code,dnlin.qty as qty,isnull(dnlin.act_qty,0) as rqty
	--	from tasklist, dnlin 
	--	where tasklist.dc_code=dnlin.dc_code and tasklist.dn_no=dnlin.dn_no
	--	and assigned_opt = @assigned_opt
	--	and dnlin.row_id = 1
	--	and tasklist.status_code like ''%''
	--	and Datediff(second,op_dtime,GETDATE()) > 100 

end

--			exec [sp_hht_getTaskList_div] ''P27532991'',''001'',''''

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_tasklinScan_list]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
------------------------------------
--用途：得到扫描之后的结果明细:用于独立的界面物品列表刷新
--项目名称
--说明：
--时间：	2011-4-26 14:31:50
------------------------------------
CREATE PROCEDURE [dbo].[sp_hht_tasklinScan_list]
	@task_id	varchar(50),
	@bch_no		varchar(50),
	@dn_no		varchar(50),
	@bin_code	varchar(50),
	@sku_no		varchar(50),
	@assigned_opt	varchar(50),
	@sErr		varchar(255) output
AS
	set nocount on
	declare @dc_code nvarchar(10)
	declare @have_sno varchar(10)
	declare @sku_desc varchar(100)
	declare @sku_desc_eng varchar(100)
	declare @cnt int -- 
	declare @sumQty0 int
	declare @sumQty1 int
	declare @bin_area1 varchar(50)
	set @dc_code=''SHA''

	set @sErr = ''0||'';

	--	[2] 判断物品是否合法
	select @cnt = count(*) from dnlin
		where dn_no = @dn_no and sku_no=@sku_no
	if @cnt<1
	begin
		rollback tran T_0002
		set @sErr = ''-1|物品『''+@sku_no+''』非法，请检查！|'';
		return
	end	

	-- 判断有无机身号，没有就累加数量，有就返回给前端，让HHT前段定位到机身号字段
	set @sku_desc = ''''
	set @sku_desc_eng = ''''
	SELECT @have_sno=have_sno, @sku_desc=sku_desc, @sku_desc_eng=sku_desc_eng
	FROM   skuinfo
	where sku_no = @sku_no
	if @have_sno is null set @have_sno=''0''
	
	--	刷新前段数据显示:	sku_no,qty,rqty
	select @sumQty1 = isnull(dnlin.act_qty,0),@sumQty0 = isnull(dnlin.qty,0) 
		from dnlin	where dnlin.dc_code=@dn_no and dc_code=@dc_code;

	--	刷新前段数据显示:第一部分:中间流水:	sku_no,机身号和rowid
	if @have_sno = ''1''	-- 有机身号,显示机身号清单
		begin
			SELECT rowid, sku_no, sno
			FROM  tasklin
			where task_id = @task_id and bin_code = @bin_code and opt_by=@assigned_opt 
			and sku_no=@sku_no and dn_no=@dn_no
		end
	Else			-- 没有机身号,显示数量列表..
		begin
			SELECT rowid, sku_no, qty as sno
			FROM  tasklin
			where task_id = @task_id and bin_code = @bin_code and opt_by=@assigned_opt 
			and sku_no=@sku_no and dn_no=@dn_no
		End

	-- 第二部分: 汇总数量:sumQty1,@sumQty0
	select @sumQty1 as sumQty1,@sumQty0 as sumQty0

	set @sErr = ''0||'';
	return





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_get_ScanQty]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
------------------------------------
--用途：得到一个箱子之内的完成情况:
--项目名称：CodematicDemo
--说明：
--时间：	2011-4-26 14:31:50
------------------------------------
-- [sp_hht_get_ScanQty] @task_id,@bch_no,@dn_no,@bin_code,@sku_no,@sErr
-- exec [sp_hht_get_ScanQty] ''TASK1104270036'',''BNCH1104270001'',''9204314482'',''A-A-02'',''P27532999'',''''
CREATE PROCEDURE [dbo].[sp_hht_get_ScanQty]
	@task_id	varchar(50),
	@bch_no		varchar(50),
	@dn_no		varchar(50),
	@bin_code	varchar(50),
	@sku_no		varchar(40),
	@sErr		varchar(255) output
AS
	set nocount on
	declare @dc_code varchar(30)
	declare @sumQty0 int
	declare @sumQty1 int
	declare @sku_desc varchar(50)

	set @dc_code = ''SHA''
	select @sku_desc = sku_desc from skuinfo where sku_no=@sku_no;

	
	--	刷新前段数据显示:	sku_no,qty,rqty
	select @sumQty1 = dnlin.act_qty,@sumQty0 = dnlin.qty from dnlin
		where dnlin.dn_no=@dn_no and dc_code=@dc_code;
	
	--	刷新前段数据显示:	sku_no,qty,rqty
	select dnlin.sku_no,@sku_desc as sku_desc,@sumQty0 as qty ,sum(tasklin.qty) as rqty
		from dnlin,tasklin
		where dnlin.dc_code=tasklin.dc_code
		and dnlin.dn_no=tasklin.dn_no
		and dnlin.sku_no= tasklin.sku_no
		and dnlin.dn_no=@dn_no
		and dnlin.sku_no = @sku_no
		group by dnlin.sku_no
	-- having sum(tasklin.qty) < @sumQty0

--
----  ''TASK1104270036'',''BNCH1104270001'',''9204314482'',''A-A-02'',''P27532999'',''''
--
----	刷新前段数据显示:	sku_no,qty,rqty
--	select  dnlin.act_qty,dnlin.qty from dnlin
--		where dnlin.dc_code=''9204314482'' and dc_code=''SHA'';
--	
--	--	刷新前段数据显示:	sku_no,qty,rqty
	select  sum(tasklin.qty) as rqty
		from dnlin,tasklin
		where dnlin.dc_code=tasklin.dc_code
		and dnlin.dn_no=tasklin.dn_no
		and dnlin.sku_no= tasklin.sku_no
		and dnlin.dn_no=''9204314482''
		and dnlin.sku_no = ''P27532999''
		group by dnlin.sku_no
--	having sum(tasklin.qty) < @sumQty0
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_tasklinScan_BinDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
------------------------------------
--用途：删除指定库位上的扫描记录
--说明：
--时间：	2011-4-26 14:31:50
------------------------------------
-- [sp_hht_tasklinScan_BinDelete] @task_id  @bch_no  @dn_no  @bin_code @sku_no  @rowid @assigned_opt @sErr
CREATE PROCEDURE [dbo].[sp_hht_tasklinScan_BinDelete]
	@task_id		varchar(50),
	@bch_no			varchar(50),
	@dn_no			varchar(50),
	@bin_code		varchar(50),	-- 原来的库位
	@sku_no			varchar(50),
	@assigned_opt	varchar(50),
	@sErr			varchar(255) output
AS
	set nocount on
	declare @dc_code nvarchar(10)
	declare @have_sno varchar(10)
	declare @cnt int -- 
	declare @sumQty0 int
	declare @sumQty1 int
	
	set @dc_code=''SHA''
	
	SET TRANSACTION ISOLATION LEVEL Read Committed -- REPEATABLE READ
	begin tran T_0006
	
	delete from tasklin where dc_code=@dc_code and task_id=@task_id 
		and bch_no=@bch_no and dn_no=@dn_no and bin_code=@bin_code and sku_no=@sku_no;

	-- 同步更新 dnlin.act_qty 数量字段=sum(tasklin.qty)
	declare @sumQty_Scan int	--	所有已经扫描的数量
	select @sumQty_Scan = isnull(sum(qty),0) from tasklin 
		where dc_code=@dc_code and task_id=@task_id 
		and bch_no=@bch_no and dn_no=@dn_no and bin_code=@bin_code and sku_no=@sku_no;
	if @sumQty_Scan is null set @sumQty_Scan = 0;

	-- 更新动作
	update dnlin set act_qty=@sumQty_Scan where dc_code=@dc_code and dn_no=@dn_no and sku_no=@sku_no;
	if @@error > 0 
	begin
		rollback tran T_0006
		set @sErr = ''-1|删除库位扫描数据时出错!|''
		return 
	end
	-- 修改提交...
	set @sErr = ''0|删除成功!|''
	commit  tran T_0006
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_set_FinishedQty_Bin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
------------------------------------
--用途：根据批次号，DN单号，库位和物品sku,得到已经扫描的数量和需要的数量
--项目名称：CodematicDemo
--说明：
--时间：	2011-4-26 14:31:50
------------------------------------
--	exec sp_hht_set_FinishedQty_Bin @task_id,@bch_no,@dn_no,@bin_code,@sku_no,@assigned_opt,@sErr
CREATE PROCEDURE [dbo].[sp_hht_set_FinishedQty_Bin]
	@task_id	varchar(50),
	@bch_no		varchar(50),
	@dn_no		varchar(50),
	@bin_code	varchar(50),
	@sku_no		varchar(50),
	@qty	int,	-- 一次性增加输入的非机身号物品的数量
	@assigned_opt varchar(50),
	@sErr		varchar(255) output
AS
	set nocount on
	declare @dc_code nvarchar(10)
	declare @wh_code nvarchar(10)
	declare @opt_by nvarchar(20)
	declare @opt_dtime datetime
	declare @start_dtime datetime
	declare @end_dtime datetime
	declare @rowid nvarchar(10)
	declare @bin_area nvarchar(50)
	declare @type nchar(3)
	declare	@status_code nchar(5)
	declare @close_auto bit
	declare @print_by nvarchar(20)
	declare @print_counter int
	declare @print_dtime datetime
	declare @locked int
	declare @have_sno varchar(10)
	declare @sku_desc varchar(100)
	declare @sku_desc_eng varchar(100)
	declare @cnt int -- 
	declare @sumQty0 int
	declare @sumQty1 int
	declare @bin_area1 varchar(50)
begin

	set nocount on
	set @dc_code = ''SHA''
	declare @pointQty int	-- 指示数量
	declare @scanedQty int	-- 已扫数量
	declare @addedQty int	-- 指示数量
	
	SET TRANSACTION ISOLATION LEVEL Read Committed -- REPEATABLE READ
	begin tran T_0001
	
	-- 需要数量和已经扫描的数量:
	select @pointQty = qty,@scanedQty=act_qty 
	from dnlin
	where dc_code =@dc_code and dn_no = @dn_no and sku_no=@sku_no
	
	-- 当前已经扫描的数量:
	select @addedQty = sum(qty)
	from tasklin
	where dc_code = @dc_code and task_id=@task_id and bch_no=@bch_no 
	and bin_code=@bin_code and sku_no=@sku_no
	if @pointQty < @addedQty + @qty
	begin
		rollback tran T_0001
		set @sErr = ''-1|数量超出!|''
		return 
	end

	----------------------------------------------------------------
	-- 数量增加:
	-- 从表中取得其他字段:
	SELECT	@dc_code=dc_code, @wh_code=wh_code,  @bin_area=bin_area,
			@type=type, @status_code=status_code, @close_auto=close_auto, 
			@print_by=print_by, @print_counter=print_counter, @print_dtime=print_dtime, 
			@locked=locked,@start_dtime=start_dtime, @end_dtime=end_dtime
	FROM   tasklist
	where task_id = @task_id and bch_no = @bch_no and dn_no = @dn_no;
	----------------------------------------------------------------
	-- 更新数量：
	if exists (select 1 from tasklin where dc_code=@dc_code  and task_id=@task_id 
				and bch_no=@bch_no and dn_no=@dn_no and bin_area=@bin_area and bin_code=@bin_code and sku_no=@sku_no)
		begin
			-- 数量增加
			update tasklin set qty = qty + @qty 
			where dc_code=@dc_code and task_id=@task_id 
				and bch_no=@bch_no and dn_no=@dn_no and bin_area=@bin_area 
				and bin_code=@bin_code and sku_no=@sku_no;
			if @@error > 0 
			begin
				rollback tran T_0001
				set @sErr = ''-1|保存错误!|''
				return 
			end
		End
	Else	-- 如果不存在,-简单插入..
		Begin
			-- set @bin_area = ''[02]:''
			INSERT INTO tasklin(rowid,dc_code,wh_code,task_id,bch_no,dn_no,bin_area,bin_code,sku_no,
				sno,type,qty,status_code,close_auto,print_by,
				print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime)
			VALUES(@rowid,@dc_code,@wh_code,@task_id,@bch_no,@dn_no,@bin_area,@bin_code,@sku_no,
				'''',@type,@qty,@status_code,@close_auto,@print_by,
				@print_counter,@print_dtime,@locked,@assigned_opt,getdate(),@start_dtime,@end_dtime );
				if @@error > 0 
				begin
					rollback tran T_0001
					set @sErr = ''-1|保存错误!|''
					return 
				end
		End
	----------------------------------------------------------------

	-- 同步更新 dnlin.act_qty 数量字段=sum(tasklin.qty)
	declare @sumQty_Scan int	--	所有已经扫描的数量
	select @sumQty_Scan = sum(qty)
		from tasklin 
		where dc_code=@dc_code and task_id=@task_id 
		and bch_no=@bch_no and dn_no=@dn_no and bin_area=@bin_area 
		and bin_code=@bin_code and sku_no=@sku_no;

	-- 更新动作
	update dnlin set act_qty=@sumQty_Scan 
		from dnlin 
		where dc_code=@dc_code and dn_no=@dn_no and sku_no=@sku_no;
	if @@error > 0 
	begin
		rollback tran T_0001
		set @sErr = ''-1|保存错误!|''
		return 
	end
	
	commit tran T_0001
	set @sErr = ''0|保存成功!|''
	return 
	
End

--	exec sp_hht_get_FinishedQty_Bin @task_id,@bch_no,@dn_no,@bin_code,@sku_no,@sErr
--  exec sp_hht_get_FinishedQty_Bin ''TASK1104270036'',''BNCH1104270001'',''9204314482'',''A-A-02'',''P27532991'',''''
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_get_FinishedQty_Bin]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
------------------------------------
--用途：根据批次号，DN单号，库位和物品sku,得到已经扫描的数量和需要的数量
--项目名称：CodematicDemo
--说明：
--时间：	2011-4-26 14:31:50
------------------------------------
--	exec sp_hht_get_FinishedQty_Bin @task_id,@bch_no,@dn_no,@bin_code,@assigned_opt,@sErr
CREATE PROCEDURE [dbo].[sp_hht_get_FinishedQty_Bin]
	@task_id	varchar(50),
	@bch_no		varchar(50),
	@dn_no		varchar(50),
	@bin_code	varchar(50),
	@assigned_opt varchar(50),
	@sErr		varchar(255) output
AS
	declare @dc_code varchar(20)
	declare @sku_desc varchar(50)
begin
	
	set nocount on
	SET @sErr=''''
	set @dc_code = ''SHA''

	--	刷新前段数据显示:	sku_no,qty,rqty
	set @sku_desc = ''''

	select dnlin.sku_no,skuinfo.sku_desc, dnlin.qty,dnlin.act_qty as rqty
	from dnlin left join skuinfo on(dnlin.sku_no=skuinfo.sku_no),tasklist 
	where dnlin.dc_code=tasklist.dc_code and dnlin.dn_no=tasklist.dn_no
	and dnlin.dn_no=@dn_no
	and tasklist.bin_code = @bin_code
	and tasklist.assigned_opt = @assigned_opt
	and dnlin.qty <> dnlin.act_qty
	
end

--	exec sp_hht_get_FinishedQty_Bin @task_id,@bch_no,@dn_no,@bin_code,@sku_no,@sErr
--  exec sp_hht_get_FinishedQty_Bin ''TASK1104270036'',''BNCH1104270001'',''9204314482'',''10A-01'',''110'',''''

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_getInfo]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--取得clstasklist的一个列表
-- sp_hht_getInfo @type,@para1,@para2,@para3,@para4,@para5,@sErr
CREATE procedure [dbo].[sp_hht_getInfo] 
	@type varchar(50),	-- '''','''',''''
	@para1 varchar(50), -- 
	@para2 varchar(50), -- 
	@para3 varchar(50), -- 
	@para4 varchar(50), -- 
	@para5 varchar(50), -- 
	@sErr varchar(255) output
as 
begin
	if @type=''01''
	begin
		--	dc_code, task_id, bch_no, assigned_opt, 
		SELECT tasklist.dn_no, tasklist.bin_code, dnlin.sku_no
		FROM tasklist left join dnlin
		on( tasklist.dn_no = dnlin.dn_no)
		where tasklist.dn_no = @para1;
	end 

	if @type=''02''
	begin
		-- dc_code, task_id, bch_no, dn_no, assigned_opt, wh_code,  bin_code, sku_no
		SELECT tasklist.dn_no, tasklist.bin_code, dnlin.sku_no
		FROM tasklist left join dnlin
		on( tasklist.dn_no = dnlin.dn_no)
		where dnlin.sku_no = @para1;
	end 
select * from dnlin
	if @type=''03''
	begin
		SELECT tasklist.dn_no, tasklist.bin_code, dnlin.sku_no
		FROM tasklist left join dnlin
		on( tasklist.dn_no = dnlin.dn_no)
		where tasklist.bin_code = @para1;
	end 

end

--	exec sp_hht_getTaskList ''110'',''''
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_get_FinishedQty_Sku]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
------------------------------------
--用途：根据批次号，DN单号，库位和物品sku,得到已经扫描的数量和需要的数量
--项目名称：CodematicDemo
--说明：
--时间：	2011-4-26 14:31:50
------------------------------------
--	exec sp_hht_get_FinishedQty_Sku @task_id,@bch_no,@dn_no,@bin_code,@sku_no,@sErr
Create PROCEDURE [dbo].[sp_hht_get_FinishedQty_Sku]
	@task_id	varchar(50),
	@bch_no		varchar(50),
	@dn_no		varchar(50),
	@bin_code	varchar(50),
	@sku_no varchar(50),
	@sErr		varchar(255) output
AS
	declare @dc_code varchar(20)
	declare @sku_desc varchar(50)
begin
	
	set nocount on
	set @dc_code = ''SHA''

	--	刷新前段数据显示:	sku_no,qty,rqty
	set @sku_desc = ''''

	select dnlin.sku_no,skuinfo.sku_desc, dnlin.qty,dnlin.act_qty as rqty
	from dnlin left join skuinfo on(dnlin.sku_no=skuinfo.sku_no),tasklist 
	where dnlin.dc_code=tasklist.dc_code and dnlin.dn_no=tasklist.dn_no
	and dnlin.dn_no=@dn_no
	and tasklist.bin_code = @bin_code
	and dnlin.sku_no = @sku_no
	and dnlin.qty <> dnlin.act_qty
	
end

--	exec sp_hht_get_FinishedQty_Bin @task_id,@bch_no,@dn_no,@bin_code,@sku_no,@sErr
--  exec sp_hht_get_FinishedQty_Bin ''TASK1104270036'',''BNCH1104270001'',''9204314482'',''A-A-02'',''110'',''''


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_getTaskList]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
--取得clstasklist的一个列表
--	exec sp_hht_getTaskList @assigned_opt
CREATE procedure [dbo].[sp_hht_getTaskList]
	@assigned_opt varchar(50), -- 任务接收人
	@sErr varchar(255) output
as 
begin
	-- 取得按照任务单和对应的扫描汇总数量字段
	-- top 1000 dc_code,wh_code,task_id,bch_no,dn_no,assigned_opt,bin_area,bin_code,sku_no,qty,type,status_code,opt_by,opt_dtime
	select top 100 tasklist.task_id,tasklist.bch_no,tasklist.dn_no,tasklist.bin_code,dnlin.qty as qty,isnull(dnlin.act_qty,0) as rqty
	from tasklist, dnlin 
	where tasklist.dc_code=dnlin.dc_code and tasklist.dn_no=dnlin.dn_no
	and assigned_opt = @assigned_opt
	and dnlin.row_id = 1
	and tasklist.status_code like ''%''

end

--	exec sp_hht_getTaskList ''110'',''''
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_hht_chg_Binid]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
-- 变更表里的 tasklist 的库位
-- [sp_hht_chg_Binid] @dc_code,@dn_no,@bin_code,@bin_code1,@sErr
CREATE procedure [dbo].[sp_hht_chg_Binid] 
	@dc_code varchar(50),
	@dn_no varchar(50),
	@bin_code varchar(50),
	@bin_code1 varchar(50),
	@sErr varchar(255) output
AS
begin
	update tasklist set bin_code = @bin_code1
		where dc_code=@dc_code and dn_no=@dn_no and bin_code=@bin_code;
	set @sErr = '''';
end

--	exec sp_hht_getTaskList ''110'',''''
' 
END
