/****** Object:  StoredProcedure [dbo].[Sp_valid_Bin]    Script Date: 08/15/2011 10:53:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Sp_valid_Bin](    @dn_no nvarchar(20),
                                          @bin_area nvarchar(10),
	                                      @bin_code nvarchar(10))  AS
begin

    if  exists(select 1 from binStatus where bin_code=@bin_area and bin_code=@bin_code)
	begin
		RETURN -1
	end 
	if  exists(select 1 from dnbin where bin_code=@bin_area and bin_code=@bin_code and dn_no = @dn_no)
	begin
		RETURN -1
	end 
    RETURN 1
End
GO
