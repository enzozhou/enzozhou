/****** Object:  StoredProcedure [dbo].[stp_S_clsRolepermission]    Script Date: 08/15/2011 10:55:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_S_clsRolepermission](
	@OLD___role_code nvarchar(10),
	@OLD___right_no nvarchar(20)
)
as               ----根据关键字取得clsRolepermission记录
begin
	select role_code,right_no,remark,opt_by,opt_dtime,opt_timestamp
		from [dbo].[Rolepermission]
		where 	role_code = @OLD___role_code and
			right_no = @OLD___right_no 
end
GO
