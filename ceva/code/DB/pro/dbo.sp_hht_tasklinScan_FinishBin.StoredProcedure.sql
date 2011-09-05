/****** 对象:  StoredProcedure [dbo].[sp_hht_tasklinScan_FinishBin]    脚本日期: 08/12/2011 16:39:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：HHT端,点完成时,修改后台单据的状态-联动修改多个表
--时间：	2011-4-26 14:31:50
--	返回信息值: 
--	[-1]|错误信息|第三信息|
--	[ 0]|表示正常|返回用户成功信息|
--	[-2]|需要扫描机身号，不需要报错，返回即可|
--  [-4]|判断是否改库位下面的东西都扫描完成了|
--  [-5]|箱满,请扫描库位号|
------------------------------------
CREATE PROCEDURE [dbo].[sp_hht_tasklinScan_FinishBin]
	@task_id	varchar(50),
	@bch_no		varchar(50),
	@dn_no		varchar(50),
	@bin_code	varchar(50),
	@assigned_opt	varchar(50),
	@sErr		varchar(255) output
AS
	declare @dc_code nvarchar(10)
	declare @wh_code nvarchar(10)
	declare @opt_by nvarchar(20)
	declare @opt_dtime datetime
	declare @rowid nvarchar(10)
	declare @bin_area nvarchar(50)
	declare @type nchar(3)
	declare	@status_code nchar(5)
	declare @close_auto bit
	declare @cnt int  
	declare @cnt1 int  
	declare @cntAll int -- 当前单号下,所有单据的数量(满足一定条件之后的)
	declare @sumQty0 int
	declare @sumQty1 int
	declare @bin_area1 varchar(50)
	set @dc_code='SHA'

	--	dnlin 由 4(捡货中)变为 : 5（已完成）
	--	dnhdr : 如果所有物品都完成了,则状态由4,变成5
	--	其他单据中状态变更情况:
	--	bchdhr		status_code	0(初始状态)，1(货位绑定)，2(任务分配)，3(捡货中)，4（已完成）
	--	bchlin		status_code	0(初始状态)，1(货位绑定)，2(任务分配)，3(捡货中)，4（已完成）
	--	taskhdr		status_code	0(初始状态)，1(处理中)，	2（已完成）
	--	tasklist	status_code	0(初始状态)，1(处理中)，	2（已完成）
	--	dnbin		status_code	0(绑定)，	1(完成)
	set nocount on

	SET TRANSACTION ISOLATION LEVEL Read Committed
	begin transaction

    --使用try…catch结构捕获异常
    begin try
		----------------------------------------------------------------
		-- 当前明细记录更新:
		update dnlin set status_code = 5 where status_code = 4 and dn_no = @dn_no;
		-- 同一单下,所有明细判定
		select @cnt1 = count(*) from dnlin where dn_no = @dn_no;
		select @cntAll = count(*) from dnlin where dn_no = @dn_no and status_code >= 5;
		if @cnt1 = @cntAll	--如果所有明细都是完成状态,则主单也完成:
		begin
			update dnhdr set status_code = 5 where status_code = 4 and dn_no = @dn_no;
		end

		----------------------------------------------------------------
		-- 批次信息...
		update bchlin set status_code = 5 where status_code = 4 and bch_no = @bch_no;
		-- 同一单下,所有明细判定..
		select @cnt1	= count(*) from bchlin where bch_no = @bch_no;
		select @cntAll	= count(*) from bchlin where bch_no = @bch_no and status_code >= 5;
		if @cnt1 = @cntAll	--如果所有明细都是完成状态,则主单也完成:
		begin
			update bchhdr set status_code = 5 where status_code = 4 and bch_no = @bch_no;
		end
		
		----------------------------------------------------------------
		-- 任务明细: tasklist,task_id 下面多个用户,我靠...
		select * from tasklist
		select * from taskhdr  
		--	taskhdr		status_code	0(初始状态)，1(处理中)，	2（已完成）
		--	tasklist	status_code	0(初始状态)，1(处理中)，	2（已完成）

		----------------------------------------------------------------
		-- 一个库位,完成,既是一个DN单号完成了,需要判定其状态:
		--	dnbin	status_code	0(绑定)，1(完成)
		update dnbin set status_code = 1 where status_code = 0 and bch_no = @bch_no 
			and dn_no=@dn_no and bin_code=@bin_code;

        commit transaction --提交事务
		set @sErr = ''

    end try
    --如果出现了异常，进入catch代码段
    begin catch
        rollback transaction --回滚事务
        select @sErr = ERROR_MESSAGE() --输出错误信息
    end catch
GO
