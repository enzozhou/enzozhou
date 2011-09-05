/****** Object:  StoredProcedure [dbo].[stp_D_clsbchlin]    Script Date: 08/15/2011 10:53:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[stp_D_clsbchlin](
	@dc_code nvarchar(10),
	@bch_no nvarchar(20),
	@dn_no nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
	---更新单据状态
    /*
	dnhdr	status_code	0(初始状态)，1(组批中)，2(货位绑定)，3(任务分配)，4(捡货中)，5（已完成）
	dnlin	status_code	0(初始状态)，1(组批中)，2(货位绑定)，3(任务分配)，4(捡货中)，5（已完成）
	bchdhr	status_code	0(初始状态)，1(货位绑定)，2(任务分配)，3(捡货中)，4（已完成）
	bchlin	status_code	0(初始状态)，1(货位绑定)，2(任务分配)，3(捡货中)，4（已完成）
	taskhdr	status_code	0(初始状态)，1(处理中)，2（已完成）
	tasklist	status_code	0(初始状态)，1(处理中)，2（已完成）
    */
--    update dnhdr set status_code = 0 where dc_code=@dc_code and status_code in( '1','2') and dn_no = @dn_no
--    update dnlin set status_code = 0 where dc_code=@dc_code and status_code in( '1','2')and dn_no = @dn_no
--    delete dnbin where dc_code=@dc_code and bch_no = @bch_no and dn_no = @dn_no
--    delete binstatus where dc_code=@dc_code  and  dn_no = @dn_no


	declare @RetMsg nvarchar(255)
-- 2开始拣货后不能删除
	if  exists(select 1 from tasklin where dc_code=@dc_code and bch_no = @bch_no)
		begin
			select @RetMsg = '此批次[' +@bch_no +']已开始拣货,不能删除！'
			raiserror(@RetMsg, 16, 1) with nowait
		return -1
		end
	else
	begin
		DELETE FROM dnlin     WHERE dn_no IN (SELECT dn_no from bchlin where dc_code=@dc_code and bch_no = @bch_no);
		DELETE FROM dnhdr    WHERE dn_no IN (SELECT dn_no from bchlin where dc_code=@dc_code and bch_no = @bch_no);
		DELETE FROM DnBin    WHERE dn_no IN (SELECT dn_no from bchlin where dc_code=@dc_code and bch_no = @bch_no);
		DELETE FROM tasklist  WHERE bch_no = @bch_no AND dc_code=@dc_code;
		DELETE FROM taskhdr  WHERE bch_no = @bch_no AND dc_code=@dc_code;
		DELETE FROM tasklin   WHERE bch_no = @bch_no AND dc_code=@dc_code;
		DELETE FROM bchlin    WHERE bch_no = @bch_no AND dc_code=@dc_code;
		DELETE FROM bchhdr   WHERE bch_no = @bch_no AND dc_code=@dc_code;
	end 

--	delete from [dbo].[bchlin]
--	where 	dc_code = @dc_code and
--		bch_no = @bch_no and
--		dn_no = @dn_no 
end
GO
