/****** Object:  StoredProcedure [dbo].[stp_U_clsTRLOG02]    Script Date: 08/15/2011 10:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clsTRLOG02]( 
	@OLD___log_id bigint,
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
as               ----更新02
begin
	if (isnull(convert(bigint, @opt_timestamp),0)<>0)
	begin
		declare @newstamp bigint
		select @newstamp=convert(bigint, opt_timestamp) from  [dbo].[TRLOG]
		where log_id = @OLD___log_id 
		if (isnull(@newstamp,0)=0)
			return
		if (@newstamp != isnull(convert(bigint, @opt_timestamp),0))
		begin
			raiserror(51000, 16, 1) with nowait
			--rollback transaction
			return
		end
	end
	exec  stp_U_clsTRLOG
		@OLD___log_id = @OLD___log_id,
		@trans_type = @trans_type,
		@cmd_type = @cmd_type,
		@doc_no = @doc_no,
		@LINENUM = @LINENUM,
		@STCD = @STCD,
		@ITEMNO = @ITEMNO,
		@ITEM_DESC = @ITEM_DESC,
		@BANTCH = @BANTCH,
		@QTY = @QTY,
		@status = @status,
		@reason = @reason,
		@reasonDesc = @reasonDesc,
		@OPT_BY = @OPT_BY,
		@OPT_ADDR = @OPT_ADDR,
		@OPT_DATE = @OPT_DATE,
		@OPT_TIMESTAMP = @OPT_TIMESTAMP output
end
GO
