/****** Object:  StoredProcedure [dbo].[stp_U_clsusers]    Script Date: 08/15/2011 10:55:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_U_clsusers]( 
	@OLD___uid VarChar(20),
	@uid VarChar(20),
	@uname VarChar(50),
	@pwd VarChar(20),
	@phone VarChar(50),
	@email VarChar(100),
	@gender VarChar(10),
	@roleType VarChar(20)
)
as           ----更新
begin
	update [dbo].[users] set 
		uid = @uid,
		uname = @uname,
		pwd = @pwd,
		phone = @phone,
		email = @email,
		gender = @gender,
		roleType = @roleType
		where uid = @OLD___uid 

	
	
end
GO
