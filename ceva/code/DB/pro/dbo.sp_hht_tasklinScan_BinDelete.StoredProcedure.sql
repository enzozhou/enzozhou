/****** 对象:  StoredProcedure [dbo].[sp_hht_tasklinScan_BinDelete]    脚本日期: 08/12/2011 16:39:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	
	set @dc_code='SHA'
	
	SET TRANSACTION ISOLATION LEVEL Read Committed -- REPEATABLE READ
	begin tran T_0006
	
	delete from tasklin where dc_code=@dc_code and task_id=@task_id 
		and bch_no=@bch_no and dn_no=@dn_no and bin_code=@bin_code and sku_no=@sku_no
		and opt_by=@assigned_opt

	-- 同步更新 dnlin.act_qty 数量字段=sum(tasklin.qty)
	declare @sumQty_Scan int	--	所有已经扫描的数量(汇集所有用户的扫描动作)
	select @sumQty_Scan = isnull(sum(qty),0) from tasklin 
		where dc_code=@dc_code and task_id=@task_id 
		and bch_no=@bch_no and dn_no=@dn_no and bin_code=@bin_code and sku_no=@sku_no;
	if @sumQty_Scan is null set @sumQty_Scan = 0;

	-- 更新动作
	update dnlin set act_qty=@sumQty_Scan where dc_code=@dc_code and dn_no=@dn_no and sku_no=@sku_no;
	if @@error > 0 
	begin
		rollback tran T_0006
		set @sErr = '-1|删除库位扫描数据时出错!|'
		return 
	end
	-- 修改提交...
	set @sErr = '0|删除成功!|'
	commit  tran T_0006
GO
