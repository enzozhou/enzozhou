/****** Object:  StoredProcedure [dbo].[sp_hht_get_FinishedQty_Bin]    Script Date: 08/15/2011 10:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedure
------------------------------------
--用途：根据批次号，DN单号，库位和物品sku,
--得到[1] 主表,[2]明细表,[3]数据汇总信息
--说明：
--时间：	2011-4-26 14:31:50
------------------------------------
--	exec [sp_hht_get_FinishedQty_Bin] @task_id,@bch_no,@dn_no,@bin_code,@assigned_opt,@sErr
--
--declare @sErr varchar(50)
--exec [sp_hht_get_FinishedQty_Bin] 'TASK1104290038','BNCH1104280001','9204314482','A-A-04','P27532991','110', @sErr output
--print @sErr

CREATE PROCEDURE [dbo].[sp_hht_get_FinishedQty_Bin]
	@task_id	varchar(50),
	@bch_no		varchar(50),
	@dn_no		varchar(50),
	@bin_code	varchar(50),
	@sku_no		varchar(50),
	@assigned_opt varchar(50),
	@sErr		varchar(255) output
AS
	declare @dc_code varchar(20)
	declare @sku_desc varchar(50)
	declare @have_sno  varchar(50)
	declare @sumQty0 int
	declare @sumQty1 int
begin

	set nocount on
	SET @sErr=''
	set @dc_code = 'SHA'

	-- 检查SKU信息:
	-- [sp_hht_checkBarcode] @dn_no,@sku_no,@sku_no2 output,@sErr output
	declare @sku_no2 varchar(50)
	declare @sErr2 varchar(50)

	exec [sp_hht_checkBarcode] @dn_no,@sku_no,@sku_no2 output,@sErr2 output

	if @sErr2 <>'' or @sErr2 <> null
	begin
		set @sErr = '-1|物品『'+@sku_no+'』非法，请检查！|';
		return
	end
	-- 否则:刷新:
	set @sku_no = @sku_no2;

	----------------------------------------------------------------
	--	[1]刷新前段数据显示:主表:	sku_no,sku_desc,qty,rqty
	select dnlin.sku_no,skuinfo.sku_desc,dnlin.qty,isnull(dnlin.act_qty,0) as rqty,convert(varchar(10),skuinfo.have_sno) as have_sno
	from dnlin left join skuinfo on(dnlin.sku_no=skuinfo.sku_no),tasklist
	where dnlin.dc_code=tasklist.dc_code and dnlin.dn_no=tasklist.dn_no
	and tasklist.task_id = @task_id 
	and dnlin.dn_no=@dn_no
	and dnlin.sku_no = @sku_no
	and tasklist.bin_code = @bin_code
	and tasklist.assigned_opt = @assigned_opt
	and dnlin.qty <> isnull(dnlin.act_qty,0)
	----------------------------------------------------------------
	-- [2] 明细表: --> 
	-- 判断有无机身号，没有就累加数量，有就返回给前端，让HHT前段定位到机身号字段
	set @sku_desc = ''
	SELECT @have_sno=have_sno, @sku_desc=sku_desc
	FROM   skuinfo
	where sku_no = @sku_no
	if @have_sno is null set @have_sno='0'
	--	刷新前段数据显示:第一部分:中间流水:	sku_no,机身号和rowid
	if @have_sno = '1'	-- 有机身号,显示机身号清单
		begin
			SELECT rowid, sku_no, sno
			FROM  tasklin
			where task_id = @task_id and bin_code = @bin_code and opt_by=@assigned_opt 
			and sku_no=@sku_no and dn_no=@dn_no
		end
	Else	-- 没有机身号,显示数量列表..
		begin
			SELECT rowid, sku_no, qty as sno
			FROM  tasklin
			where task_id = @task_id and bin_code = @bin_code and opt_by=@assigned_opt 
			and sku_no=@sku_no and dn_no=@dn_no
		End

	----------------------------------------------------------------
	--	[3]明细汇总数据 刷新前段数据显示:	sku_no,qty,rqty
	select @sumQty1 = isnull(dnlin.act_qty,0),@sumQty0 = isnull(dnlin.qty,0) 
		from dnlin	where dnlin.dn_no=@dn_no and dc_code=@dc_code and sku_no = @sku_no;
	
	if @sumQty1 is null set @sumQty1=0
	if @sumQty0 is null set @sumQty0=0

	-- 返回数据
	select @sumQty1 as sumQty1,@sumQty0 as sumQty0

	set @sErr = '0||';
	return

end

--	select * from skuinfo
--	exec sp_hht_get_FinishedQty_Bin @task_id,@bch_no,@dn_no,@bin_code,@sku_no,@sErr
--  exec sp_hht_get_FinishedQty_Bin 'TASK1104270036','BNCH1104270001','9204314482','10A-01','110',''
--	select tasklin.sku_no,skuinfo.sku_desc,dnlin.qty,tasklin.qty,
--	from tasklin

--@task_id	varchar(50),
--	@bch_no		varchar(50),
--	@dn_no		varchar(50),
--	@bin_code	varchar(50),
--	@sku_no		varchar(50),
--	@assigned_opt varchar(50),
--	@sErr		varchar(255) output
--
--	TASK1105090080	CEVA1105090001	9204522667
--	exec [sp_hht_get_FinishedQty_Bin] 'TASK1105100081','CEVA1105100001','9600251638','A-A-01','P19934780','zft',''
GO
