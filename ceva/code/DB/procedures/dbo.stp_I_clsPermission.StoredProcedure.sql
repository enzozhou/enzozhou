/****** Object:  StoredProcedure [dbo].[stp_I_clsPermission]    Script Date: 08/15/2011 10:54:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsPermission]( 
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
	insert into [dbo].[Permission]( 
		right_no,
		[description],
		trans_type,
		doc_type,
		cmd_type,
		remark,
		opt_by,
		opt_dtime)
	values(
		@right_no,
		@description,
		@trans_type,
		@doc_type,
		@cmd_type,
		@remark,
		@opt_by,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
GO
