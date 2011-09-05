/****** Object:  StoredProcedure [dbo].[sp_hht_tasklinScan_ADD]    Script Date: 08/15/2011 10:53:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--	@sErr 返回信息值: 
--	[-1]|错误信息|第三信息|
--	[ 0]|表示正常|返回用户成功信息|
--	[-2]|需要扫描机身号，不需要报错，返回即可|
--  [-4]|判断是否改库位下面的东西都扫描完成了|
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
	set @dc_code='SHA'

	set @sErr='0||'

	-- 检查SKU信息:
	declare @sku_no3 varchar(50)
	declare @sErr3 varchar(50) 
	exec [sp_hht_checkBarcode] @dn_no,@sku_no,@sku_no3 output,@sErr3 output
	if @sErr3 <>'' 
	begin
		set @sErr = '物品『'+@sku_no+'』非法，请检查！' + @sku_no3 ;
		return
	end 
	
	if @sku_no3 is null set @sku_no3 = ''

	set @sku_no = @sku_no3
	if rtrim(ltrim(@sku_no)) =''
	begin
		set @sErr = '物品『'+@sku_no+'』非法(为空)，请检查！' + @sku_no3 ;
		return
	end 
	
	-- 判断有无机身号，没有就累加数量，有就返回给前端，让HHT前段定位到机身号字段
	set @sku_desc = ''
	set @sku_desc_eng = ''
	SELECT @have_sno=have_sno, @sku_desc=sku_desc, @sku_desc_eng=sku_desc_eng
	FROM   skuinfo
	where sku_no = @sku_no
	if @have_sno is null set @have_sno='0'
	
	if @have_sno = '1' and rtrim(ltrim(@sno)) = ''
	begin
		set @sErr = '-2|'+@sku_desc+'|需要扫描机身号，定位到机身号栏目|'+convert(varchar(10),@have_sno);
		return
	end
	
	-- ================================================
	-- 公共判断.,.,.,.,
	-- ================================================
	--	[1]单据号判断：是否存在,状态是否允许操作?
	select @status_code = status_code from taskhdr where task_id = @task_id;
	if @status_code > '1'
	begin
		set @sErr = '-1|taskhdr中单据状态为『'+@status_code+'』,不允许继续操作!（需要=0）|';
		return
	end

	-- --------------------------------------------------------------
	SET TRANSACTION ISOLATION LEVEL Read Committed -- REPEATABLE READ
	begin tran T_0002
	-- 更新单据状态：
	update taskhdr set status_code= '1' where task_id = @task_id and status_code= '0' ;
	if @@error > 0 
	begin
		rollback tran T_0002
		set @sErr = '-1|保存错误!|'
		return 
	end
	update dnhdr set status_code= '4' where dn_no = @dn_no and status_code <> '5' ;
	if @@error > 0 
	begin
		rollback tran T_0002
		set @sErr = '-1|保存错误!|'
		return 
	end
	update dnlin set status_code= '4' where dn_no = @dn_no and status_code <> '5' and sku_no=@sku_no ;
	if @@error > 0 
	begin
		rollback tran T_0002
		set @sErr = '-1|保存错误!|'
		return 
	end

	--	[-4] 判断机身号重复性
	if @have_sno = '1' and  @sno <> ''
	begin
		select @cnt = count(*) from tasklin
		where task_id = @task_id and sku_no=@sku_no and dn_no = @dn_no 
		and sno=@sno  
		if @cnt>0
		begin
			rollback tran T_0002
			set @sErr = '-4|机身号重复,请检查！|SNO';
			return
		end	
		
		-- 判断机身号是否符合规则; S开头,11位全长
		if len(@sno) < 11 
		begin
			rollback tran T_0002
			set @sErr = '-1|机身号错误:不符合长度规则(必须大于11位!),请检查！|SNO';
			return
		End	

		if substring(@sno,1,1) <> 'S' 
		begin
			rollback tran T_0002
			set @sErr = '-1|机身号错误:不符合开头规则(必须以S开头),请检查！|SNO';
			return
		end	
	end
	
	---- 判断有无机身号，没有就累加数量，有就返回给前端，让HHT前段定位到机身号字段
	-- 如果不要求，或者已经输入了机身号，这继续...
	if @have_sno <> '1'	-- 不要求机身号
	begin
		set @sno = ''
	end

	-- 记录插入,数量增加:-- 取得下一个rowno行号
	select @rowid = isnull(max(convert(decimal,rowid)),0) from tasklin where task_id = @task_id;

	-- 增加或者减少记录:(没有小于0的情况.)
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
			set @sErr = '-3|数量超出！|'+convert(varchar(10),@have_sno);
			-- 数据刷新显示::
			--------------------------------------------------------
			--	刷新前段数据显示:第一部分:中间流水:	sku_no,机身号和rowid
			if @have_sno = '1'	-- 有机身号,显示机身号清单
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
			-- 汇总表
			select @qty11 as sumQty1, @qty10 as sumQty0 
			-- 返回..
			return
			--------------------------------------------------------
		End 
		
		-- 数量未超出...
		
		-- 有机身号，简单插入，无则判断后插入：
		if @have_sno = '1'	-- 要求机身号
			begin
				set @rowid = @rowid + 1;
				INSERT INTO tasklin	(rowid,dc_code,wh_code,task_id,bch_no,dn_no,bin_area,bin_code,sku_no,
					sno,type,qty,status_code,close_auto,print_by,
					print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime)
				VALUES(	@rowid,@dc_code,@wh_code,@task_id,@bch_no,@dn_no,@bin_area,@bin_code,@sku_no,
						@sno,@type,@qty,@status_code,@close_auto,@print_by,
						@print_counter,@print_dtime,@locked,@assigned_opt,getdate(),@start_dtime,@end_dtime );
				if @@error > 0 
				begin
					rollback tran T_0002
					set @sErr = '-1|事务错误！|'
					return 
				end
			End
		Else	-- 如果没有机身号...
			begin
				-- 没有机身号：需要增加一个数据对应的行:
				-- set @bin_area = '[02]:'
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
					set @sErr = '-1|事务错误！|'
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
	update dnlin set act_qty=@sumQty_Scan where dc_code=@dc_code and dn_no=@dn_no and sku_no=@sku_no;
	if @@error > 0 
	begin
		rollback tran T_0002
		set @sErr = '-1|事务错误！|'
		return 
	end
	
	-- 修改提交...
	commit  tran T_0002
	set @sErr='0||'

	--	刷新前段数据显示:	sku_no,qty,rqty
	select @sumQty1 = isnull(dnlin.act_qty,0),@sumQty0 = isnull(dnlin.qty,0) 
	from dnlin
	where dnlin.dn_no=@dn_no and dc_code=@dc_code and sku_no=@sku_no;
	--------------------------------------------------------
	--	刷新前段数据显示:第一部分:中间流水:	sku_no,机身号和rowid
	if @have_sno = '1'	-- 有机身号,显示机身号清单
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
	--------------------------------------------------------

	-- 第二部分: 汇总数量:sumQty1,@sumQty0
	select @sumQty1 as sumQty1,@sumQty0 as sumQty0

	-- 判断是否改库位下面的东西都扫描完成了：
	if @sumQty1>=@sumQty0
	begin
		set @sErr = '-5||'+convert(varchar(10),@have_sno);
		return
	end
	else
	begin
		set @sErr = '0||'+convert(varchar(10),@have_sno);
		return
	end
GO
