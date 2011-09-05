/****** 对象:  StoredProcedure [dbo].[sp_hht_set_FinishedQty_Bin]    脚本日期: 08/12/2011 16:39:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	if len(ltrim(rtrim(@sku_no)))>9
	begin
		set @sku_no = substring(@sku_no,1,9)
	end 

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
	set @dc_code = 'SHA'
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
		set @sErr = '-1|数量超出!|'
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
				set @sErr = '-1|保存错误!|'
				return 
			end
		End
	Else	-- 如果不存在,-简单插入..
		Begin
			-- set @bin_area = '[02]:'
			INSERT INTO tasklin(rowid,dc_code,wh_code,task_id,bch_no,dn_no,bin_area,bin_code,sku_no,
				sno,type,qty,status_code,close_auto,print_by,
				print_counter,print_dtime,locked,opt_by,opt_dtime,start_dtime,end_dtime)
			VALUES(@rowid,@dc_code,@wh_code,@task_id,@bch_no,@dn_no,@bin_area,@bin_code,@sku_no,
				'',@type,@qty,@status_code,@close_auto,@print_by,
				@print_counter,@print_dtime,@locked,@assigned_opt,getdate(),@start_dtime,@end_dtime );
				if @@error > 0 
				begin
					rollback tran T_0001
					set @sErr = '-1|保存错误!|'
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
		set @sErr = '-1|保存错误!|'
		return 
	end
	
	commit tran T_0001
	set @sErr = '0|保存成功!|'
	return 
	
End

--	exec sp_hht_get_FinishedQty_Bin @task_id,@bch_no,@dn_no,@bin_code,@sku_no,@sErr
--  exec sp_hht_get_FinishedQty_Bin 'TASK1104270036','BNCH1104270001','9204314482','A-A-02','P27532991',''
GO
