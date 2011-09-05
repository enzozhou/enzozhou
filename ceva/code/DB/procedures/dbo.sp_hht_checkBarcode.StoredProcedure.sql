/****** Object:  StoredProcedure [dbo].[sp_hht_checkBarcode]    Script Date: 08/15/2011 10:53:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--	检查扫描到得barcode是否正确
--	[1] 到dnlin中检查正常的barcode,
--	[2] 去掉结尾的一个字符,重新到 dnlin中检查正常的barcode
--	[3]	到 barcode 中检查是否属于 barcode - sku_no 映射
--	[sp_hht_checkBarcode] @dn_no,@sku_no,@sku_no2 output,@sErr output
CREATE procedure [dbo].[sp_hht_checkBarcode] 
	@dn_no		varchar(50),
	@sku_no		varchar(50),
	@sku_no2	varchar(50)		output, -- 如果是UPC,这里返回正确的SKU
	@sErr		varchar(255)	output
As
begin
	set @sErr= '';

	---------------------------------------------------------
	---处理 {P1233123-21}或者 {P12-33123-21}的数据异常情况 -----
	---------------------------------------------------------
	-- 如果有-,则处理之...
	declare @cnt int
	declare @tmp varchar(50)
	declare @sku_no1 varchar(50)
	declare @sku_no3 varchar(50)
	declare @sku_no9 varchar(50)
	set @sku_no9 = @sku_no

	set @cnt = charindex('-',@sku_no)
	if @cnt > 0	
	begin
		set @sku_no1 = substring(@sku_no,1,@cnt-1)+substring(@sku_no,@cnt+1,30)
		set @sku_no9 = @sku_no1
	end

	set @cnt = charindex('-',@sku_no1)
	if @cnt > 0	
	begin
		set @sku_no2 = substring(@sku_no1,1,@cnt-1)+substring(@sku_no1,@cnt+1,30)
		set @sku_no9 = @sku_no2
	end
	
	set @cnt = charindex('-',@sku_no2)
	if @cnt > 0	
	begin
		set @sku_no3 = substring(@sku_no2,1,@cnt-1)+substring(@sku_no2,@cnt+1,30)
		set @sku_no9 = @sku_no3
	end

	-- == 刷新结果值:
	set @sku_no = @sku_no9
	---------------------------------------------------------
	-- 取截取后:
	set @sku_no3 = substring(ltrim(rtrim(@sku_no)),1,len(ltrim(rtrim(@sku_no)))-1)

	if  @dn_no=''	-- 如果是SKU查询:
	begin
		-- 先从业务数据表中获取 : 
		select @sku_no2 = isnull(min(sku_no),'') from dnlin where (sku_no=@sku_no);
		if @sku_no2<> '' 
		begin
			set @sErr = ''
			set @sku_no2=@sku_no;
			return;
		end
		select @sku_no2 = isnull(min(sku_no),'') from dnlin where (sku_no=@sku_no3);
		if @sku_no2<> '' 
		begin
			set @sErr = ''
			set @sku_no2=@sku_no3;
			return;
		end

		-- 如果空,则,转化为upc后继续查找...
		-- P14983190	4905524761993
		-- 按照UPC查询一次:
		select @sku_no2 = isnull(sku_no,'') from barcode where (sku_no=@sku_no or sku_no=@sku_no3) or barcode= @sku_no;
		if @sku_no2 = ''
		begin
			set @sErr = '无效SKU-2'
			return
		end	
		return 
	end
	else -- 扫描单据查询
		begin
			set @sErr = ''
			set @cnt = 0  
			set @sku_no2 = ''

			select @sku_no2 = isnull(min(sku_no),'') from dnlin where (sku_no=@sku_no) and dn_no=@dn_no;
			if @sku_no2<> '' 
			begin
				set @sErr = ''
				set @sku_no2=@sku_no;
				return;
			end
			select @sku_no2 = isnull(min(sku_no),'') from dnlin where (sku_no=@sku_no3) and dn_no=@dn_no;
			if @sku_no2<> '' 
			begin
				set @sErr = ''
				set @sku_no2=@sku_no3;
				return;
			end

			-- upc 转化成 商品条码:
			select @sku_no2 = isnull(min(sku_no),'') from barcode where (sku_no=@sku_no or sku_no=@sku_no3) or barcode= @sku_no;
			if @sku_no2 <> ''
			begin
				set @sErr = ''
				set @sku_no = @sku_no2;
				return;
			end

			-- 返回....
			return;
	end
End

----	select * from barcode
----	where dn_no = '9204522661' and sku_no = 'P02229172'
----	P14983190	4905524761993


--	declare @dn_no		varchar(50)
--	declare @sku_no		varchar(50)
--	declare @sku_no2	varchar(50) 
--	declare @sErr		varchar(255)
--	set @dn_no = ''
--	set @sku_no = 'P02074875' -- 'P14983190'
--	exec [sp_hht_checkBarcode] @dn_no,@sku_no,@sku_no2 output,@sErr output
--	print @sku_no2;
--	print @sErr

--select  isnull(min(sku_no),'') from dnlin where (sku_no='P149831 90R' or sku_no='P14983 190');
GO
