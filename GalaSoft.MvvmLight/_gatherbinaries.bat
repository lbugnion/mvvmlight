rem @echo off

if not exist _Binaries md _Binaries
if not exist _Binaries\Debug md _Binaries\Debug
if not exist _Binaries\Debug\Silverlight5 md _Binaries\Debug\Silverlight5
if not exist _Binaries\Debug\WP71 md _Binaries\Debug\WP71
if not exist _Binaries\Debug\NET45 md _Binaries\Debug\NET45
if not exist _Binaries\Debug\Win8 md _Binaries\Debug\Win8
if not exist _Binaries\Debug\WP8 md _Binaries\Debug\WP8
if not exist _Binaries\Release md _Binaries\Release
if not exist _Binaries\Release\Silverlight5 md _Binaries\Release\Silverlight5
if not exist _Binaries\Release\WP71 md _Binaries\Release\WP71
if not exist _Binaries\Release\NET45 md _Binaries\Release\NET45
if not exist _Binaries\Release\Win8 md _Binaries\Release\Win8
if not exist _Binaries\Release\WP8 md _Binaries\Release\WP8

if exist ".\GalaSoft.MvvmLight (NET45)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (NET45)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (NET45)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (NET45)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (NET45)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (NET45)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (NET45)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (NET45)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (NET45)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (NET45)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (NET45)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (NET45)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight (SL5)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (SL5)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\Silverlight5\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (SL5)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (SL5)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\Silverlight5\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (SL5)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (SL5)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\Silverlight5\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (SL5)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (SL5)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\Silverlight5\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (SL5)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (SL5)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\Silverlight5\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (SL5)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (SL5)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\Silverlight5\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight (WP71)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (WP71)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\WP71\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (WP71)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (WP71)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\WP71\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (WP71)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (WP71)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\WP71\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (WP71)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (WP71)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\WP71\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (WP71)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (WP71)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\WP71\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (WP71)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (WP71)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\WP71\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight (WP8)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (WP8)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\WP8\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (WP8)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (WP8)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\WP8\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (WP8)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (WP8)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\WP8\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (WP8)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (WP8)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\WP8\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (WP8)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (WP8)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\WP8\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (WP8)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (WP8)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\WP8\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight (Win8)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (Win8)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\Win8\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (Win8)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (Win8)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\Win8\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (Win8)\bin\Debug\GalaSoft.MvvmLight.pri" copy ".\GalaSoft.MvvmLight (Win8)\bin\Debug\GalaSoft.MvvmLight.pri" .\_Binaries\Debug\Win8\GalaSoft.MvvmLight.pri
if exist ".\GalaSoft.MvvmLight (Win8)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (Win8)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\Win8\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (Win8)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (Win8)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\Win8\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (Win8)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (Win8)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\Win8\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (Win8)\bin\Release\GalaSoft.MvvmLight.pri" copy ".\GalaSoft.MvvmLight (Win8)\bin\Release\GalaSoft.MvvmLight.pri" .\_Binaries\Release\Win8\GalaSoft.MvvmLight.pri
if exist ".\GalaSoft.MvvmLight (Win8)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (Win8)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\Win8\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\Silverlight5\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\Silverlight5\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\Silverlight5\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\Silverlight5\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\Silverlight5\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\Silverlight5\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\WP71\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\WP71\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\WP71\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\WP71\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\WP71\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\WP71\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\WP8\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\WP8\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\WP8\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\WP8\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\WP8\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\WP8\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\Win8\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\Win8\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\GalaSoft.MvvmLight.Extras.pri" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\GalaSoft.MvvmLight.Extras.pri" .\_Binaries\Debug\Win8\GalaSoft.MvvmLight.Extras.pri
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\Win8\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\Win8\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\Win8\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\GalaSoft.MvvmLight.Extras.pri" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\GalaSoft.MvvmLight.Extras.pri" .\_Binaries\Release\Win8\GalaSoft.MvvmLight.Extras.pri
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\Win8\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\NET45\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\NET45\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\NET45\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\NET45\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\NET45\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\NET45\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\NET45\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (NET45)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\NET45\System.Windows.Interactivity.xml

if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\Silverlight5\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\Silverlight5\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\Silverlight5\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\Silverlight5\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\Silverlight5\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\Silverlight5\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\Silverlight5\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\Silverlight5\System.Windows.Interactivity.xml

if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\WP71\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\WP71\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\WP71\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\WP71\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\WP71\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\WP71\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\WP71\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (WP71)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\WP71\System.Windows.Interactivity.xml

if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\WP8\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\WP8\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\WP8\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\WP8\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\WP8\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\WP8\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\WP8\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (WP8)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\WP8\System.Windows.Interactivity.xml

if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\Win8\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\Win8\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\Microsoft.Practices.ServiceLocation.pri" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\Microsoft.Practices.ServiceLocation.pri" .\_Binaries\Debug\Win8\Microsoft.Practices.ServiceLocation.pri
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\Win8\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\Win8\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\Win8\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\Microsoft.Practices.ServiceLocation.pri" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\Microsoft.Practices.ServiceLocation.pri" .\_Binaries\Release\Win8\Microsoft.Practices.ServiceLocation.pri
if exist ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (Win8)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\Win8\Microsoft.Practices.ServiceLocation.xml
