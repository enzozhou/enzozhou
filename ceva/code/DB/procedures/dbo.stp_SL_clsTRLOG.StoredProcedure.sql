/****** Object:  StoredProcedure [dbo].[stp_SL_clsTRLOG]    Script Date: 08/15/2011 10:55:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsTRLOG]
as       ----取得clsTRLOG的一个列表
begin
	select top 1000 log_id,trans_type,cmd_type,doc_no,LINENUM,STCD,ITEMNO,ITEM_DESC,BANTCH,QTY,status,reason,reasonDesc,OPT_BY,OPT_ADDR,OPT_DATE,OPT_TIMESTAMP
		from [dbo].[TRLOG]
end
GO
