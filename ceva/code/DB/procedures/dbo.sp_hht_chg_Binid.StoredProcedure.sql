/****** Object:  StoredProcedure [dbo].[sp_hht_chg_Binid]    Script Date: 08/15/2011 10:53:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedure
-- 变更表里的 tasklist 的库位
-- [sp_hht_chg_Binid] @bch_no,@dc_code,@dn_no,@bin_code,@bin_code1,@sErr
CREATE procedure [dbo].[sp_hht_chg_Binid]
	@dc_code varchar(50),	-- 传递进来为空
	@dn_no varchar(50),		-- 传递进来为空
	@bin_code varchar(50),	
	@bin_code1 varchar(50),	
	@sErr varchar(255) output
AS
begin
	declare @cnt int 
	declare @bin_area1 varchar(50)
	declare @bch_no varchar(50)

	set @sErr = '';

	select @bin_area1 = bin_area from bin
	where bin_code = @bin_code1;
	if @bin_area1 is null
	begin
		set @sErr = '新库位非法!';
		return;
	end
	if @bin_area1 =''
	begin
		set @sErr = '新库位非法!';
		return;
	end
	
	--		select * from binstatus where bin_code = 'B-A-01'
	
	-- 如果状态已经占用了,则提示用已经分配,不能用了:
	select @cnt = count(*) from binstatus
	where bin_code=@bin_code1;
	if @cnt>0
	begin
		set @sErr = '新库位已经分配,不能被占用!' + @bin_code ;
		return;
	end
	
	-- 提取批次,DN单据号
	select @bch_no=bch_no,@dn_no=dn_no
	from dnbin 
	where bin_code = @bin_code;
	if @bch_no is null
	begin
		set @sErr = '本库位未分配,请检查!';
		return;
	end
	if @bch_no =''
	begin
		set @sErr = '本库位未分配,请检查!';
		return;
	end

	-- --	[1]新库位 binstatus 中不存在
	--	[2]从bin表取得bin_area 字段;
	--	[3]从 dnbin 中取得批次,任务单号等
	
	-- tasklist,dnbin,binstatus
	update tasklist set bin_area = @bin_area1 , bin_code=@bin_code1
	where dc_code=@dc_code and dn_no=@dn_no 
		and bch_no = @bch_no
		and bin_code=@bin_code 

	update tasklin set bin_area = @bin_area1 , bin_code=@bin_code1 
	where dc_code= @dc_code 
		and bch_no=@bch_no
		and dn_no=@dn_no 
		and bin_code=@bin_code

	update dnbin set bin_area = @bin_area1 , bin_code=@bin_code1 
	where dc_code= @dc_code and dn_no=@dn_no
	and bch_no=@bch_no;
	
	update binstatus set bin_area = @bin_area1 , bin_code=@bin_code1 -- ,status_code = 0
	where dc_code= @dc_code and dn_no=@dn_no
	
	
end

--	select * from binstatus

--	exec sp_hht_getTaskList '110',''
GO
