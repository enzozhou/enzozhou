/****** Object:  StoredProcedure [dbo].[stp_get_macaddress]    Script Date: 08/15/2011 10:54:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[stp_get_macaddress]
(
    @netaddr nvarchar(20) output
)
as
begin
select @netaddr=rtrim(hostname) from master..sysprocesses where spid=@@spid

end
GO
