/****** Object:  StoredProcedure [dbo].[Sp_Find_BestBin_by_rule]    Script Date: 08/15/2011 10:53:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[Sp_Find_BestBin_by_rule](     @bin_area nvarchar(10),
													  @bin_code nvarchar(10),
													  @bch_no nvarchar(20),
													  @dn_no nvarchar(20),
                                                      @volume numeric(12,3))  AS
begin
	RETURN -1
End
GO
