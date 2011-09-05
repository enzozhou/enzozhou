IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_sys_freecache]') AND type in (N'P', N'PC'))
DROP PROCEDURE [stp_sys_freecache]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[stp_sys_freecache]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'create proc [stp_sys_freecache]
as
begin
    --dbcc freeproccache
    
    declare @sql nvarchar(1000)
    declare @ver nvarchar(50)
    SELECT @ver=convert(nvarchar(50),SERVERPROPERTY(''productversion''))
    if(charindex(''.'',@ver)>0)
        select @ver=left(@ver,charindex(''.'',@ver)-1)
    print ''version:''+@ver
    if(convert(int,@ver)>=9)            -- is SQL SERVER 2005
    begin
        select @sql=
            ''BEGIN TRY''+char(13)+
            ''declare @count int''+char(13)+
            ''select @count=count(1) from master..syscacheobjects''+char(13)+
            ''print @count''+char(13)+
            ''if(@count>2000)''+char(13)+
            ''    dbcc freeproccache''+char(13)+
            ''END TRY''+char(13)+
            ''BEGIN CATCH''+char(13)+
            ''    dbcc freeproccache''+char(13)+
            ''END CATCH''
        print @sql
        exec sp_executesql @sql
    end
    else
    begin
        select @sql=''dbcc freeproccache''
        print @sql
        exec sp_executesql @sql
    end
    
end
' 
END
GO
