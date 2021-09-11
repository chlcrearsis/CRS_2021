@echo off
del 00-REG_TAB.SQL
for /f %%i in ('dir /b /n *.sql') do (type %%i >> 00-REG_TAB.TEMP  & echo. >> 00-REG_TAB.TEMP & echo GO )
RENAME 00-REG_TAB.TEMP 00-REG_TAB.SQL