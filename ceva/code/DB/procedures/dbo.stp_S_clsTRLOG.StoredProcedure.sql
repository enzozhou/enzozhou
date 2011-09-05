/****** Object:  StoredProcedure [dbo].[stp_S_clsTRLOG]    Script Date: 08/15/2011 10:55:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsTRLOG](
	@OLD___log_id bigint
)
as               ----根据关键字取得clsTRLOG记录
begin
	select log_id,trans_type,cmd_type,doc_no,LINENUM,STCD,ITEMNO,ITEM_DESC,BANTCH,QTY,status,reason,reasonDesc,OPT_BY,OPT_ADDR,OPT_DATE,OPT_TIMESTAMP
		from [dbo].[TRLOG]
		where 	log_id = @OLD___log_id 
end
GO
