IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsusers]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_I_clsusers]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clsusers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_I_clsusers]( 
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
' 
END
GO
