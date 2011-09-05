/****** Object:  StoredProcedure [dbo].[stp_S_clsRole]    Script Date: 08/15/2011 10:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsRole](
	@OLD___role_code nvarchar(10)
)
as               ----根据关键字取得clsRole记录
begin
	select role_code,role_name,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Role]
		where 	role_code = @OLD___role_code 
end
GO
