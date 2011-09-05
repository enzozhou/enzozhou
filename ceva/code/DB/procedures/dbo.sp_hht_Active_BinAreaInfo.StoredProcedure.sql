/****** Object:  StoredProcedure [dbo].[sp_hht_Active_BinAreaInfo]    Script Date: 08/15/2011 10:53:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 得到活动批次和库区,库位清单列表
-- [sp_hht_Active_BinAreaInfo]@type,@sErr =  bin_area,bin_code_cnt
CREATE procedure [dbo].[sp_hht_Active_BinAreaInfo] 
	@type			varchar(20),
	@assigned_opt	varchar(20),
	@sErr			varchar(255) output
as 
	Declare @task_id nvarchar(50)
	Declare @bch_no nvarchar(50)
begin
	-- 最新单据号:
	select @bch_no = a.bch_no,@task_id=a.task_id
	from (select top 1 * from tasklist where status_code < 2 order by opt_timestamp desc) a;

	-- 提取下面的库区,和库位数量:
	select  distinct bin_area,count(bin_code) as bin_code_cnt
	from dnbin
	where bch_no = @bch_no and status_code=0
	group by bch_no,bin_area

	-- 返回批次 [2]
	SELECT DISTINCT bch_no from tasklist where status_code < 2 order by bch_no desc
--	select @bch_no as bch_no;

	-- 返回共多少个库位: [3]
	select  count(distinct bin_code) as bin_cnt 
	from dnbin
	where bch_no = @bch_no
	group by bch_no

	-- 返回合计物品数量[4] convert(int,isnull(sum(qty),0)) as sumQty 
	select convert(int,isnull(sum(qty),0)) as sumQty --	isnull(sum(qty),0) as sumQty
	from dnlin
	where dn_no in	
	(
		select distinct dn_no from tasklist 
		where assigned_opt=@assigned_opt and bch_no = @bch_no
	)

End

--	exec [sp_hht_Active_BinAreaInfo] '','',''
--	select  distinct bin_area,count(bin_code) as bin_code_cnt
--	from binstatus
--	select * from dnlin
--	where status_code=0
GO
