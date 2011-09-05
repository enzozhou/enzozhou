echo Start execute %~1 >>result.txt
　　　　sqlcmd -U sa -P sa -S localhost -d ceva -i %1 >>result.txt
echo execute sql %~1 completed! >>result.txt
echo -------------------------------------------------------------------------->>result.txt