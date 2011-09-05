/****** Object:  StoredProcedure [dbo].[stp_D_clsdnhdr]    Script Date: 08/15/2011 10:53:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[stp_D_clsdnhdr](
	@dc_code nvarchar(10),
	@dn_no nvarchar(20),
	@opt_timestamp timestamp = NULL ,
	@stroptby nvarchar(50) = NULL
)
as
begin
    declare @RetMsg nvarchar(255)
    if  exists(select 1 from bchlin where dc_code=@dc_code and dn_no = @dn_no)
	begin
		select @RetMsg = '此DN单[' +@dn_no +']已组批,不能删除！'
		raiserror(@RetMsg, 16, 1) with nowait
        return -1
	end
	if  exists(select 1 from tasklist where dc_code=@dc_code and dn_no = @dn_no)
		begin
			select @RetMsg = '此DN单[' +@dn_no +']已比被分配给操作人员,不能删除！'
			raiserror(@RetMsg, 16, 1) with nowait
			return -1
		end
	delete from [dbo].[dnhdr]
	where 	dc_code = @dc_code and
		dn_no = @dn_no 
end
GO
