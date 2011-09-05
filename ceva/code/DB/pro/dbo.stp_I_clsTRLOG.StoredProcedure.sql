IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsTRLOG]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_I_clsTRLOG]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsTRLOG]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_I_clsTRLOG]( 
	@log_id bigint output,
	@trans_type nchar(3),
	@cmd_type nchar(3),
	@doc_no nvarchar(24),
	@LINENUM nchar(4),
	@STCD nvarchar(6),
	@ITEMNO nvarchar(24),
	@ITEM_DESC nvarchar(60),
	@BANTCH nvarchar(24),
	@QTY numeric(14,4),
	@status nvarchar(50),
	@reason nvarchar(50),
	@reasonDesc VarChar(255),
	@OPT_BY nvarchar(50),
	@OPT_ADDR nvarchar(50),
	@OPT_DATE datetime,
	@OPT_TIMESTAMP timestamp output
)
as 
begin
	insert into [dbo].[TRLOG]( 
		trans_type,
		cmd_type,
		doc_no,
		LINENUM,
		STCD,
		ITEMNO,
		ITEM_DESC,
		BANTCH,
		QTY,
		status,
		reason,
		reasonDesc,
		OPT_BY,
		OPT_ADDR,
		OPT_DATE)
	values(
		@trans_type,
		@cmd_type,
		@doc_no,
		@LINENUM,
		@STCD,
		@ITEMNO,
		@ITEM_DESC,
		@BANTCH,
		@QTY,
		@status,
		@reason,
		@reasonDesc,
		@OPT_BY,
		@OPT_ADDR,
		@OPT_DATE
	)
	select @OPT_TIMESTAMP = CONVERT(TIMESTAMP, @@DBTS)
	
	select @log_id = @@IDENTITY
	
end
' 
END
GO
