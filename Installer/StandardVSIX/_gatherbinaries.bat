rem @echo off

if not exist ..\InstallItems\VSIX md ..\InstallItems\VSIX
if not exist ..\InstallItems\VSIX\Release md ..\InstallItems\VSIX\Release

if exist ".\MvvmLight.VS10\bin\Debug\MvvmLight.VS2010.vsix" copy ".\MvvmLight.VS10\bin\Debug\MvvmLight.VS2010.vsix" ..\InstallItems\VSIX\Release\MvvmLight.VS2010.vsix
if exist ".\MvvmLight.VS11\bin\Debug\MvvmLight.VS2012.vsix" copy ".\MvvmLight.VS11\bin\Debug\MvvmLight.VS2012.vsix" ..\InstallItems\VSIX\Release\MvvmLight.VS2012.vsix
if exist ".\MvvmLight.VS12\bin\Debug\MvvmLight.VS2013.vsix" copy ".\MvvmLight.VS12\bin\Debug\MvvmLight.VS2013.vsix" ..\InstallItems\VSIX\Release\MvvmLight.VS2013.vsix

if exist ".\MvvmLight.VS12SlExpress\bin\Debug\MvvmLight.VS2013SilverlightExpress.vsix"  copy ".\MvvmLight.VS12SlExpress\bin\Debug\MvvmLight.VS2013SilverlightExpress.vsix" ..\InstallItems\VSIX\Release\MvvmLight.VS2013SilverlightExpress.vsix
if exist ".\MvvmLight.VS12WinExpress\bin\Debug\MvvmLight.VS2013WindowsExpress.vsix" copy ".\MvvmLight.VS12WinExpress\bin\Debug\MvvmLight.VS2013WindowsExpress.vsix" ..\InstallItems\VSIX\Release\MvvmLight.VS2013WindowsExpress.vsix
if exist ".\MvvmLight.VS12WpExpress\bin\Debug\MvvmLight.VS2013WinPhoneExpress.vsix"  copy ".\MvvmLight.VS12WpExpress\bin\Debug\MvvmLight.VS2013WinPhoneExpress.vsix" ..\InstallItems\VSIX\Release\MvvmLight.VS2013WinPhoneExpress.vsix
if exist ".\MvvmLight.VS12WpfExpress\bin\Debug\MvvmLight.VS2013WpfExpress.vsix" copy ".\MvvmLight.VS12WpfExpress\bin\Debug\MvvmLight.VS2013WpfExpress.vsix" ..\InstallItems\VSIX\Release\MvvmLight.VS2013WpfExpress.vsix

