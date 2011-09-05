/****** Object:  StoredProcedure [dbo].[sp_hht_getInfo]    Script Date: 08/15/2011 10:53:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedure
--取得clstasklist的一个列表
-- sp_hht_getInfo @type,@para1,@para2,@para3,@para4,@para5,@sErr
CREATE procedure [dbo].[sp_hht_getInfo] 
	@type varchar(50),	-- '','',''
	@para1 varchar(50), -- 
	@para2 varchar(50), -- 
	@para3 varchar(50), -- 
	@para4 varchar(50), -- 
	@para5 varchar(50), -- 
	@para6 varchar(50), -- 
	@sErr varchar(255) output
as 
begin
	if @type='01'
	begin
		--	dc_code, task_id, bch_no, assigned_opt,  convert(int,isnull(dnlin.qty,0))
		SELECT tasklist.dn_no, tasklist.bin_code, dnlin.sku_no,convert(int,isnull(dnlin.qty,0)) as qty,
			(select isnull(sum(qty),0) from tasklin 
				where tasklin.task_id = tasklist.task_id 
				and tasklin.bch_no = tasklist.bch_no 
				and tasklin.dn_no = tasklist.dn_no
				and dnlin.sku_no = tasklin.sku_no)  as qty1
		FROM tasklist left join dnlin on( tasklist.dn_no = dnlin.dn_no)
		where tasklist.dn_no = @para1
		and tasklist.assigned_opt = @para2
		and tasklist.bch_no = @para6
	end 

	if @type='02'
	begin
		-- 检查SKU信息:
		-- [sp_hht_checkBarcode] @dn_no,@sku_no,@sku_no2 output,@sErr output
		declare @sku_no2 varchar(50)
		declare @sErr2 varchar(50)
		exec [sp_hht_checkBarcode] '',@para1,@sku_no2 output,@sErr2 output
		if @sErr2 <>''
		begin
			return
		end

		-- dc_code, task_id, bch_no, dn_no, assigned_opt, wh_code,  bin_code, sku_no
		SELECT tasklist.dn_no, tasklist.bin_code, dnlin.sku_no,convert(int,isnull(dnlin.qty,0)) as qty,
			(select isnull(sum(qty),0) from tasklin 
				where tasklin.task_id = tasklist.task_id 
				and tasklin.bch_no = tasklist.bch_no 
				and tasklin.dn_no = tasklist.dn_no
				and dnlin.sku_no = tasklin.sku_no)  as qty1
		FROM tasklist left join dnlin
		on( tasklist.dn_no = dnlin.dn_no)
		where dnlin.sku_no = @sku_no2
		and tasklist.assigned_opt = @para2
		and tasklist.bch_no = @para6
	end 

	if @type='03'
	begin
		SELECT tasklist.dn_no, tasklist.bin_code, dnlin.sku_no,convert(int,isnull(dnlin.qty,0)) as qty,
			(select isnull(sum(qty),0) from tasklin 
				where tasklin.task_id = tasklist.task_id 
				and tasklin.bch_no = tasklist.bch_no 
				and tasklin.dn_no = tasklist.dn_no
				and dnlin.sku_no = tasklin.sku_no)  as qty1
		FROM tasklist left join dnlin
		on( tasklist.dn_no = dnlin.dn_no)
		where tasklist.bin_code = @para1
		and tasklist.assigned_opt = @para2
		and tasklist.bch_no = @para6
	end 
End

----	exec sp_hht_getTaskList '110',''
--		SELECT tasklist.dn_no, tasklist.bin_code, dnlin.sku_no
--		FROM tasklist left join dnlin
--		on( tasklist.dn_no = dnlin.dn_no)
--		where tasklist.bin_code = 'A-A-01';
GO
