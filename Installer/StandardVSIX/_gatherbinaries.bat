rem @echo off

if not exist ..\InstallItems\VSIX md ..\InstallItems\VSIX
if not exist ..\InstallItems\VSIX\Release md ..\InstallItems\VSIX\Release

if exist ".\MvvmLight.VS2010\bin\Release\MvvmLight.VS2010.vsix" copy ".\MvvmLight.VS2010\bin\Release\MvvmLight.VS2010.vsix" ..\InstallItems\VSIX\Release\MvvmLight.VS2010.vsix
if exist ".\MvvmLight.VS2012\bin\Release\MvvmLight.VS2012.vsix" copy ".\MvvmLight.VS2012\bin\Release\MvvmLight.VS2012.vsix" ..\InstallItems\VSIX\Release\MvvmLight.VS2012.vsix
if exist ".\MvvmLight.VS2013\bin\Release\MvvmLight.VS2013.vsix" copy ".\MvvmLight.VS2013\bin\Release\MvvmLight.VS2013.vsix" ..\InstallItems\VSIX\Release\MvvmLight.VS2013.vsix
if exist ".\MvvmLight.VS2015\bin\Release\MvvmLight.VS2015.vsix" copy ".\MvvmLight.VS2015\bin\Release\MvvmLight.VS2015.vsix" ..\InstallItems\VSIX\Release\MvvmLight.VS2015.vsix
