IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsTRLOG]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_S_clsTRLOG]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_S_clsTRLOG]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_S_clsTRLOG](
	@OLD___log_id bigint
)
as               ----根据关键字取得clsTRLOG记录
begin
	select log_id,trans_type,cmd_type,doc_no,LINENUM,STCD,ITEMNO,ITEM_DESC,BANTCH,QTY,status,reason,reasonDesc,OPT_BY,OPT_ADDR,OPT_DATE,OPT_TIMESTAMP
		from [dbo].[TRLOG]
		where 	log_id = @OLD___log_id 
end
' 
END
GO
