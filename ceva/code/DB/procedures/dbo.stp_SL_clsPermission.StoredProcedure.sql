/****** Object:  StoredProcedure [dbo].[stp_SL_clsPermission]    Script Date: 08/15/2011 10:55:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_SL_clsPermission]
as       ----取得clsPermission的一个列表
begin
	select top 1000 right_no,[description],trans_type,doc_type,cmd_type,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Permission]
end
GO
