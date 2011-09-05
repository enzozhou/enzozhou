/****** Object:  StoredProcedure [dbo].[stp_imp_cityairport]    Script Date: 11/25/2010 15:42:06 ******/
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[stp_imp_cityairport]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[stp_imp_cityairport]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[stp_imp_cityairport]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE    proc [dbo].[stp_imp_cityairport]
(
    @id bigint
)
as
begin
	DECLARE @DESTINATION		NVARCHAR(10)	
	DECLARE @PROVINCE			NVARCHAR(10)	
	DECLARE @TRANSIT			NVARCHAR(10)	
	DECLARE @TYPE				NCHAR(3)	
	DECLARE @OPT_DTIME			DATETIME
	DECLARE @OPT_DATE			DATETIME
    declare hdrcur cursor local for  select destination, province, transit, type, opt_dtime from impcityairport where id=@id
	select  @OPT_DATE = getdate()	
	OPEN hdrcur
		FETCH NEXT FROM hdrcur into @DESTINATION, @PROVINCE, @TRANSIT, @TYPE, @OPT_DTIME
		WHILE @@FETCH_STATUS = 0
		BEGIN
			if  exists(select 1 from cityairport where destination=@DESTINATION and type = @TYPE)
					exec  stp_U_clscityairport
						@OLD___destination = @DESTINATION,
						@OLD___type = @TYPE,
						@destination = @DESTINATION,
						@province = @PROVINCE,
						@transit = @TRANSIT,
						@opt_dtime = @OPT_DATE,
						@opt_timestamp = null 
			else
				   exec stp_I_clscityairport
						@destination = @DESTINATION,
						@province = @PROVINCE,
						@transit = @TRANSIT,
						@type = @TYPE,
						@opt_dtime = @OPT_DATE,
						@opt_timestamp = null 
		FETCH NEXT FROM hdrcur into @DESTINATION, @PROVINCE, @TRANSIT, @TYPE, @OPT_DTIME
		END 
	CLOSE hdrcur
	DEALLOCATE hdrcur
	delete impcityairport where id=@id
end
' 
END
GO
