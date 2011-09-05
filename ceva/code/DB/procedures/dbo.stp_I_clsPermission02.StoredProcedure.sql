/****** Object:  StoredProcedure [dbo].[stp_I_clsPermission02]    Script Date: 08/15/2011 10:54:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsPermission02]( 
	@right_no nvarchar(20),
	@description nvarchar(50),
	@trans_type nchar(3),
	@doc_type nchar(3),
	@cmd_type nchar(3),
	@remark ntext,
	@opt_by nvarchar(50),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
exec stp_I_clsPermission
	@right_no = @right_no,
	@description = @description,
	@trans_type = @trans_type,
	@doc_type = @doc_type,
	@cmd_type = @cmd_type,
	@remark = @remark,
	@opt_by = @opt_by,
	@opt_dtime = @opt_dtime,
	@opt_timestamp = @opt_timestamp output
end
GO
