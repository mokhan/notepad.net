@echo off
cls
tools\nant\nant.exe -buildfile:project.build %*
@echo %time%