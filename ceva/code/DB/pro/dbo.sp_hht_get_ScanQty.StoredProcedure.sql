/****** 对象:  StoredProcedure [dbo].[sp_hht_get_ScanQty]    脚本日期: 08/12/2011 16:39:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：得到一个箱子之内的完成情况:
--项目名称：CodematicDemo
--说明：
--时间：	2011-4-26 14:31:50
------------------------------------
-- [sp_hht_get_ScanQty] @task_id,@bch_no,@dn_no,@bin_code,@sku_no,@sErr
-- exec [sp_hht_get_ScanQty] 'TASK1104270036','BNCH1104270001','9204314482','A-A-02','P27532999',''
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

	set @dc_code = 'SHA'
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
----  'TASK1104270036','BNCH1104270001','9204314482','A-A-02','P27532999',''
--
----	刷新前段数据显示:	sku_no,qty,rqty
--	select  dnlin.act_qty,dnlin.qty from dnlin
--		where dnlin.dc_code='9204314482' and dc_code='SHA';
--	
--	--	刷新前段数据显示:	sku_no,qty,rqty
	select  sum(tasklin.qty) as rqty
		from dnlin,tasklin
		where dnlin.dc_code=tasklin.dc_code
		and dnlin.dn_no=tasklin.dn_no
		and dnlin.sku_no= tasklin.sku_no
		and dnlin.dn_no='9204314482'
		and dnlin.sku_no = 'P27532999'
		group by dnlin.sku_no
--	having sum(tasklin.qty) < @sumQty0
GO
