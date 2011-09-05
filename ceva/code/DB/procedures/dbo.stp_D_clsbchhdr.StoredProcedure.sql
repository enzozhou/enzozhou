/****** Object:  StoredProcedure [dbo].[stp_D_clsbchhdr]    Script Date: 08/15/2011 10:53:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[stp_D_clsbchhdr](
	@dc_code nvarchar(10),
	@bch_no nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	declare @RetMsg nvarchar(255)
-- 1 分配后不能删除
--	if  exists(select 1 from tasklist where dc_code=@dc_code and bch_no = @bch_no)
--		begin
--			select @RetMsg = '此批次[' +@bch_no +']已被分配,不能删除！'
--			raiserror(@RetMsg, 16, 1) with nowait
--		return -1
--	end
--	else
--		begin 
--			DELETE FROM dnlin WHERE dn_no IN (SELECT dn_no from tasklist where dc_code=@dc_code and bch_no = @bch_no)
--			DELETE FROM dnhdr WHERE dn_no IN (SELECT dn_no from tasklist where dc_code=@dc_code and bch_no = @bch_no)
--			DELETE FROM DnBin WHERE dn_no IN (SELECT dn_no from tasklist where dc_code=@dc_code and bch_no = @bch_no)
--			DELETE FROM tasklist WHERE bch_no = @bch_no AND dc_code=@dc_code
--			DELETE FROM taskhdr WHERE bch_no = @bch_no AND dc_code=@dc_code
--			DELETE FROM tasklin WHERE bch_no = @bch_no AND dc_code=@dc_code
--			DELETE FROM bchlin WHERE bch_no = @bch_no AND dc_code=@dc_code
--			DELETE FROM bchhdr WHERE bch_no = @bch_no AND dc_code=@dc_code
--		end 
--	delete from [dbo].[bchhdr]	where dc_code = @dc_code and bch_no = @bch_no 
-- 2开始拣货后不能删除
--	if  exists(select 1 from tasklin where dc_code=@dc_code and bch_no = @bch_no)
--		begin
--			select @RetMsg = '此批次[' +@bch_no +']已开始拣货,不能删除！'
--			raiserror(@RetMsg, 16, 1) with nowait
--		return -1
--		end
--	else
--	begin
--		DELETE FROM dnlin     WHERE dn_no IN (SELECT dn_no from bchlin where dc_code=@dc_code and bch_no = @bch_no);
--		DELETE FROM dnhdr    WHERE dn_no IN (SELECT dn_no from bchlin where dc_code=@dc_code and bch_no = @bch_no);
--		DELETE FROM DnBin    WHERE dn_no IN (SELECT dn_no from bchlin where dc_code=@dc_code and bch_no = @bch_no);
--		DELETE FROM tasklist  WHERE bch_no = @bch_no AND dc_code=@dc_code;
--		DELETE FROM taskhdr  WHERE bch_no = @bch_no AND dc_code=@dc_code;
--		DELETE FROM tasklin   WHERE bch_no = @bch_no AND dc_code=@dc_code;
--		DELETE FROM bchlin    WHERE bch_no = @bch_no AND dc_code=@dc_code;
--		DELETE FROM bchhdr   WHERE bch_no = @bch_no AND dc_code=@dc_code;
--	end 
end
GO
