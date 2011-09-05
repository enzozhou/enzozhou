IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsPermission]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_SL_clsPermission]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_SL_clsPermission]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_SL_clsPermission]
as       ----取得clsPermission的一个列表
begin
	select top 1000 right_no,[description],trans_type,doc_type,cmd_type,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Permission]
end
' 
END
GO
