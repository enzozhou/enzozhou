/****** Object:  StoredProcedure [dbo].[sp_hht_tasklinScan_list]    Script Date: 08/15/2011 10:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
------------------------------------
--用途：得到扫描之后的结果明细:用于独立的界面物品列表刷新
--项目名称
--说明：
--时间：	2011-4-26 14:31:50
------------------------------------
CREATE PROCEDURE [dbo].[sp_hht_tasklinScan_list]
	@task_id	varchar(50),
	@bch_no		varchar(50),
	@dn_no		varchar(50),
	@bin_code	varchar(50),
	@sku_no		varchar(50),
	@assigned_opt	varchar(50),
	@sErr		varchar(255) output
AS
	set nocount on
	declare @dc_code nvarchar(10)
	declare @have_sno varchar(10)
	declare @sku_desc varchar(100)
	declare @sku_desc_eng varchar(100)
	declare @cnt int -- 
	declare @sumQty0 int
	declare @sumQty1 int
	declare @bin_area1 varchar(50)
	set @dc_code='SHA'

	set @sErr = '0||';

	--	[2] 判断物品是否合法
	select @cnt = count(*) from dnlin
		where dn_no = @dn_no and sku_no=@sku_no
	if @cnt<1
	begin
		rollback tran T_0002
		set @sErr = '-1|物品『'+@sku_no+'』非法，请检查！|';
		return
	end	

	-- 判断有无机身号，没有就累加数量，有就返回给前端，让HHT前段定位到机身号字段
	set @sku_desc = ''
	set @sku_desc_eng = ''
	SELECT @have_sno=have_sno, @sku_desc=sku_desc, @sku_desc_eng=sku_desc_eng
	FROM   skuinfo
	where sku_no = @sku_no
	if @have_sno is null set @have_sno='0'
	
	--	刷新前段数据显示:	sku_no,qty,rqty
	select @sumQty1 = isnull(dnlin.act_qty,0),@sumQty0 = isnull(dnlin.qty,0) 
		from dnlin	where dnlin.dc_code=@dn_no and dc_code=@dc_code;

	--	刷新前段数据显示:第一部分:中间流水:	sku_no,机身号和rowid
	if @have_sno = '1'	-- 有机身号,显示机身号清单
		begin
			SELECT rowid, sku_no, sno
			FROM  tasklin
			where task_id = @task_id and bin_code = @bin_code and opt_by=@assigned_opt 
			and sku_no=@sku_no and dn_no=@dn_no
		end
	Else			-- 没有机身号,显示数量列表..
		begin
			SELECT rowid, sku_no, qty as sno
			FROM  tasklin
			where task_id = @task_id and bin_code = @bin_code and opt_by=@assigned_opt 
			and sku_no=@sku_no and dn_no=@dn_no
		End

	-- 第二部分: 汇总数量:sumQty1,@sumQty0
	select @sumQty1 as sumQty1,@sumQty0 as sumQty0

	set @sErr = '0||';
	return
GO
