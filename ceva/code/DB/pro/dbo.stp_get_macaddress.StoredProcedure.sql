IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_get_macaddress]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_get_macaddress]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_get_macaddress]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE proc [stp_get_macaddress]
(
    @netaddr nvarchar(20) output
)
as
begin
select @netaddr=rtrim(hostname) from master..sysprocesses where spid=@@spid

end
' 
END
GO
