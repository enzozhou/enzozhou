@echo on
��������for /r "E:\��Ŀ\CEVA\ceva_picking\code\DB\tbl" %%i in (*.sql,*.prc) do call sub "%%i"
@echo off