IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsusers02]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_U_clsusers02]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_U_clsusers02]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_U_clsusers02]( 
	@OLD___uid VarChar(20),
	@uid VarChar(20),
	@uname VarChar(50),
	@pwd VarChar(20),
	@phone VarChar(50),
	@email VarChar(100),
	@gender VarChar(10),
	@roleType VarChar(20)
)
as               ----更新02
begin
	exec  stp_U_clsusers
		@OLD___uid = @OLD___uid,
		@uid = @uid,
		@uname = @uname,
		@pwd = @pwd,
		@phone = @phone,
		@email = @email,
		@gender = @gender,
		@roleType = @roleType
end
' 
END
GO
