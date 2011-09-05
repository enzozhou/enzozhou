/****** Object:  StoredProcedure [dbo].[sp_hht_clearSkuBinSort]    Script Date: 08/15/2011 10:53:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--清除sku bin 排序信息 -- Enzo 20110829 
CREATE procedure [dbo].[sp_hht_clearSkuBinSort]
	@sku_no varchar(50),
	@assigned_opt varchar(50), -- 任务操作人
	@sErr varchar(255) output
as 
begin
	delete from dbo.skuBinSort where userID = @assigned_opt and sku_no = @sku_no;
end

GO
