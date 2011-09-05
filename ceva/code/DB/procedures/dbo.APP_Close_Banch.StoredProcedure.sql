USE [CEVATEST]
GO
/****** Object:  StoredProcedure [dbo].[APP_Close_Banch]    Script Date: 08/15/2011 10:53:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[APP_Close_Banch](
	@dc_code nvarchar(10),
	@bch_no nvarchar(20),
    @opt_by nvarchar(20),
    @RetCode nvarchar(30) output, 
    @RetMsg nvarchar(255) output
)
as
begin
	update bchhdr set status_code = 4 where dc_code=@dc_code and bch_no = @bch_no
    update bchlin set status_code = 4 where dc_code=@dc_code and bch_no = @bch_no
    update dnhdr set status_code = 5 where dc_code=@dc_code and dn_no in (select dn_no from bchlin where dc_code=@dc_code and bch_no = @bch_no)
    update dnlin set status_code = 5 where dc_code=@dc_code and dn_no in (select dn_no from bchlin where dc_code=@dc_code and bch_no = @bch_no)
    update dnbin set status_code = 1 where dc_code=@dc_code and bch_no = @bch_no
    update taskhdr set status_code = 2 where dc_code=@dc_code and bch_no = @bch_no
    update tasklist set status_code = 2 where dc_code=@dc_code and bch_no = @bch_no
    delete binstatus where dc_code = @dc_code and dn_no in (select distinct dn_no from bchlin where dc_code=@dc_code and bch_no = @bch_no)
    delete DnBin where dc_code = @dc_code and dn_no in (select distinct dn_no from bchlin where dc_code=@dc_code and bch_no = @bch_no)
end
GO
