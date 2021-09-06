@echo off
del 00-REG_PRD.SQL
for /f %%i in ('dir /b /n *.sql') do (type %%i >> 00-REG_PRD.TEMP  & echo. >> 00-REG_PRD.TEMP & echo GO )
RENAME 00-REG_PRD.TEMP 00-REG_PRD.SQL