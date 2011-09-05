IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clscityairport]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_I_clscityairport]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_I_clscityairport]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create procedure [stp_I_clscityairport]( 
	@destination nvarchar(10),
	@province nvarchar(10),
	@transit nvarchar(10),
	@type nchar(3),
	@opt_dtime datetime,
	@opt_timestamp timestamp output
)
as 
begin
	insert into [dbo].[cityairport]( 
		destination,
		province,
		transit,
		type,
		opt_dtime)
	values(
		@destination,
		@province,
		@transit,
		@type,
		@opt_dtime
	)
	select @opt_timestamp = CONVERT(TIMESTAMP, @@DBTS)
	
	
end
' 
END
GO
