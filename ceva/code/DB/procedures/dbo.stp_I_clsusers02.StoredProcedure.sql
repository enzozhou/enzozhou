/****** Object:  StoredProcedure [dbo].[stp_I_clsusers02]    Script Date: 08/15/2011 10:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsusers02]( 
	@uid VarChar(20),
	@uname VarChar(50),
	@pwd VarChar(20),
	@phone VarChar(50),
	@email VarChar(100),
	@gender VarChar(10),
	@roleType VarChar(20)
)
as 
begin
exec stp_I_clsusers
	@uid = @uid,
	@uname = @uname,
	@pwd = @pwd,
	@phone = @phone,
	@email = @email,
	@gender = @gender,
	@roleType = @roleType
end
GO
