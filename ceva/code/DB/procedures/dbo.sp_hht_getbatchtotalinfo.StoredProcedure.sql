/****** Object:  StoredProcedure [dbo].[sp_hht_getbatchtotalinfo]    Script Date: 08/15/2011 10:53:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- 得到活动批次和库区,库位清单列表
CREATE procedure [dbo].[sp_hht_getbatchtotalinfo] 
	@assigned_opt	varchar(20),
	@bch_no nvarchar(50)
as 
begin

	-- 提取下面的库区,和库位数量:[1]
	select  distinct bin_area,count(bin_code) as bin_code_cnt
	from dnbin
	where bch_no = @bch_no and status_code=0
	group by bch_no,bin_area

	-- 返回共多少个库位: [2]
	select  count(distinct bin_code) as bin_cnt 
	from dnbin
	where bch_no = @bch_no
	group by bch_no

	-- 返回合计物品数量[3] convert(int,isnull(sum(qty),0)) as sumQty 
	select convert(int,isnull(sum(qty),0)) as sumQty --	isnull(sum(qty),0) as sumQty
	from dnlin
	where dn_no in	
	(
		select distinct dn_no from tasklist 
		where assigned_opt=@assigned_opt and bch_no = @bch_no
	)

End

GO
