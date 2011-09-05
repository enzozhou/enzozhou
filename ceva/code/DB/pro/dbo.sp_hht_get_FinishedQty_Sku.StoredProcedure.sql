/****** 对象:  StoredProcedure [dbo].[sp_hht_get_FinishedQty_Sku]    脚本日期: 08/12/2011 16:39:18 ******/
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
	set @dc_code = 'SHA'

	--	刷新前段数据显示:	sku_no,qty,rqty
	set @sku_desc = ''

	select dnlin.sku_no,skuinfo.sku_desc, dnlin.qty,dnlin.act_qty as rqty
	from dnlin left join skuinfo on(dnlin.sku_no=skuinfo.sku_no),tasklist 
	where dnlin.dc_code=tasklist.dc_code and dnlin.dn_no=tasklist.dn_no
	and dnlin.dn_no=@dn_no
	and tasklist.bin_code = @bin_code
	and dnlin.sku_no = @sku_no
	and dnlin.qty <> dnlin.act_qty
	
end

--	exec sp_hht_get_FinishedQty_Bin @task_id,@bch_no,@dn_no,@bin_code,@sku_no,@sErr
--  exec sp_hht_get_FinishedQty_Bin 'TASK1104270036','BNCH1104270001','9204314482','A-A-02','110',''
GO
