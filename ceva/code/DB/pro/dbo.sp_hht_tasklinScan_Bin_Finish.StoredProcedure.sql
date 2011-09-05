/****** 对象:  StoredProcedure [dbo].[sp_hht_tasklinScan_Bin_Finish]    脚本日期: 08/12/2011 16:39:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
	if @status_code <> '0'
	begin
		set @sErr = '-1|taskhdr中单据状态为'+@status_code+',不允许继续操作!（需要=0）|'
		return
	end

	--	update taskhdr set 
	--
	--	select * from taskhdr
GO
