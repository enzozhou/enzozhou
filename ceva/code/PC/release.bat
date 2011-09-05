set outputpath=D:\schmidt\projects\CEVA\SVN\code\release\pc
set HHTPath=D:\schmidt\projects\Norgren\code\Release\PC\HHT

xcopy    UI\bin\*.exe    %outputpath%\Upgrade                                                /c /h /r /d /y 
xcopy    UI\bin\*.dll    %outputpath%\Upgrade                                                /c /h /r /d /y 
xcopy    UI\bin\*.pdb    %outputpath%\Upgrade                                                /c /h /r /d /y 
xcopy    UI\bin\*.config    %outputpath%\Upgrade                                                /c /h /r /d /y 
xcopy    UI\*.xml    UI\bin                                              /c /h /r /d /y 
xcopy    UI\*.xml     %outputpath%\Upgrade                                                /c /h /r /d /y 
xcopy    UI\lib\*.xml  %outputpath%\Upgrade\lib 		 /c /h /r /d /y

xcopy    UI\bin\zh-CHS\*.*   %outputpath%\Upgrade\zh-CHS                         /c /h /r /d /y 
xcopy    UI\Report\*.rpt   %outputpath%\Upgrade\Report                         /c /h /r /d /y 
xcopy    UI\Report\picture\*.bmp   %outputpath%\Upgrade\Report\picture                        /c /h /r /d /y 

@echo press any key to close.
rem pause