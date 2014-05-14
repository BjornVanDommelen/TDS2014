@ECHO OFF
REM Perform ILMerge on the assmebly + the CS helper assembly
REM RD /S /Q "%~dp1merged"
REM MD "%~dp1merged"
REM %~dp0..\packages\ilmerge.2.13.0307\ilmerge.exe /target:library /out:"%~dp1merged\%~nx1" "%~1" "%~dp1Hinttech.Tridion.CoreServiceHelpers.Base.dll">"%~dp0BUILD.LOG"

IF EXIST "%~dp0Upload_Local.CMD" GOTO Local
GOTO End

:Local
REM CALL "%~dp0Upload_Local.CMD" "%~dp1merged\%~nx1" "%~2" "%~3"
CALL "%~dp0Upload_Local.CMD" "%~1" "%~2" "%~3"

:End