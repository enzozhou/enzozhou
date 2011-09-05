/****** Object:  StoredProcedure [dbo].[stp_I_clsusers]    Script Date: 08/15/2011 10:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[stp_I_clsusers]( 
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
	insert into [dbo].[users]( 
		uid,
		uname,
		pwd,
		phone,
		email,
		gender,
		roleType)
	values(
		@uid,
		@uname,
		@pwd,
		@phone,
		@email,
		@gender,
		@roleType
	)
	
	
end
GO
