rem @echo off

if not exist _Binaries md _Binaries
if not exist _Binaries\Debug md _Binaries\Debug

if not exist _Binaries\Debug\PCL md _Binaries\Debug\PCL
if not exist _Binaries\Debug\STD10 md _Binaries\Debug\STD10
if not exist _Binaries\Debug\NET35 md _Binaries\Debug\NET35
if not exist _Binaries\Debug\NET4 md _Binaries\Debug\NET4
if not exist _Binaries\Debug\NET45 md _Binaries\Debug\NET45
if not exist _Binaries\Debug\NET45Std md _Binaries\Debug\NET45Std
if not exist _Binaries\Debug\UWP md _Binaries\Debug\UWP
if not exist _Binaries\Debug\UWPStd md _Binaries\Debug\UWPStd
if not exist _Binaries\Debug\Android md _Binaries\Debug\Android
if not exist _Binaries\Debug\AndroidStd md _Binaries\Debug\AndroidStd
if not exist _Binaries\Debug\iOS md _Binaries\Debug\iOS
if not exist _Binaries\Debug\iOSStd md _Binaries\Debug\iOSStd
if not exist _Binaries\Debug\SL5 md _Binaries\Debug\SL5
if not exist _Binaries\Debug\WIN81 md _Binaries\Debug\WIN81
if not exist _Binaries\Debug\WP81 md _Binaries\Debug\WP81
if not exist _Binaries\Debug\WPSL80 md _Binaries\Debug\WPSL80
if not exist _Binaries\Debug\WPSL81 md _Binaries\Debug\WPSL81
if not exist _Binaries\Debug\NETCORE30 md _Binaries\Debug\NETCORE30

if not exist _Binaries\Release\PCL md _Binaries\Release\PCL
if not exist _Binaries\Release\STD10 md _Binaries\Release\STD10
if not exist _Binaries\Release\NET35 md _Binaries\Release\NET35
if not exist _Binaries\Release\NET4 md _Binaries\Release\NET4
if not exist _Binaries\Release\NET45 md _Binaries\Release\NET45
if not exist _Binaries\Release\NET45Std md _Binaries\Release\NET45Std
if not exist _Binaries\Release\UWP md _Binaries\Release\UWP
if not exist _Binaries\Release\UWPStd md _Binaries\Release\UWPStd
if not exist _Binaries\Release\Android md _Binaries\Release\Android
if not exist _Binaries\Release\AndroidStd md _Binaries\Release\AndroidStd
if not exist _Binaries\Release\iOS md _Binaries\Release\iOS
if not exist _Binaries\Release\iOSStd md _Binaries\Release\iOSStd
if not exist _Binaries\Release\SL5 md _Binaries\Release\SL5
if not exist _Binaries\Release\WIN81 md _Binaries\Release\WIN81
if not exist _Binaries\Release\WP81 md _Binaries\Release\WP81
if not exist _Binaries\Release\WPSL80 md _Binaries\Release\WPSL80
if not exist _Binaries\Release\WPSL81 md _Binaries\Release\WPSL81
if not exist _Binaries\Release\NETCORE30 md _Binaries\Release\NETCORE30

rem PCL

if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\PCL\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\PCL\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\PCL\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\PCL\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\PCL\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\PCL\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\PCL\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\PCL\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\PCL\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\PCL\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\PCL\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\PCL\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\PCL\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\PCL\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\PCL\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\PCL\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\PCL\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\PCL\Microsoft.Practices.ServiceLocation.xml

rem .NET Standard 1.0

if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\STD10\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\STD10\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\STD10\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.dll" .\_Binaries\Release\STD10\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\STD10\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.xml" .\_Binaries\Release\STD10\GalaSoft.MvvmLight.xml

rem NET35

if exist ".\GalaSoft.MvvmLight (NET35)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (NET35)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\NET35\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (NET35)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (NET35)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\NET35\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (NET35)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (NET35)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\NET35\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (NET35)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (NET35)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\NET35\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (NET35)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (NET35)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\NET35\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (NET35)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (NET35)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\NET35\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\NET35\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\NET35\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\NET35\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\NET35\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\NET35\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\NET35\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\NET35\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\NET35\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\NET35\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\NET35\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\NET35\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\NET35\Microsoft.Practices.ServiceLocation.xml

if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\NET35\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\NET35\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\NET35\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (NET35)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\NET35\System.Windows.Interactivity.xml

rem NET4

if exist ".\GalaSoft.MvvmLight (NET4)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (NET4)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\NET4\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (NET4)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (NET4)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\NET4\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (NET4)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (NET4)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\NET4\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (NET4)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (NET4)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\NET4\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (NET4)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (NET4)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\NET4\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (NET4)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (NET4)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\NET4\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\NET4\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\NET4\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\NET4\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\NET4\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\NET4\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\NET4\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\NET4\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\NET4\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\NET4\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\NET4\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\NET4\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\NET4\Microsoft.Practices.ServiceLocation.xml

if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\NET4\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\NET4\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\NET4\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (NET4)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\NET4\System.Windows.Interactivity.xml

rem NET45

if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\NET45\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\NET45\GalaSoft.MvvmLight.Platform.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\NET45\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\NET45\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\NET45\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\NET45\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\NET45\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\NET45\Microsoft.Practices.ServiceLocation.xml

if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\NET45\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\NET45\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\NET45\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\NET45\System.Windows.Interactivity.xml

rem NET45Std

if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\NET45Std\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\NET45Std\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\NET45Std\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.dll" .\_Binaries\Release\NET45Std\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\NET45Std\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.xml" .\_Binaries\Release\NET45Std\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\NET45Std\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\NET45Std\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\NET45Std\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Release\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Release\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\NET45Std\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\NET45Std\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Release\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Release\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\NET45Std\GalaSoft.MvvmLight.Platform.xml

if exist ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\NET45Std\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\NET45Std\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\NET45Std\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (NET45Std)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\NET45Std\System.Windows.Interactivity.xml

rem UWP

if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\UWP\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\UWP\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\UWP\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\UWP\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\UWP\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\UWP\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\UWP\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\UWP\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\UWP\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\UWP\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\UWP\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\UWP\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\UWP\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\UWP\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Debug\GalaSoft.MvvmLight.Platform.pri" copy ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Debug\GalaSoft.MvvmLight.Platform.pri" .\_Binaries\Debug\UWP\GalaSoft.MvvmLight.Platform.pri
if exist ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\UWP\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Release\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Release\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\UWP\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\UWP\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Release\GalaSoft.MvvmLight.Platform.pri" copy ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Release\GalaSoft.MvvmLight.Platform.pri" .\_Binaries\Release\UWP\GalaSoft.MvvmLight.Platform.pri
if exist ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Release\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (UWP)\bin\Release\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\UWP\GalaSoft.MvvmLight.Platform.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\UWP\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\UWP\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\UWP\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\UWP\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\UWP\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\UWP\Microsoft.Practices.ServiceLocation.xml

rem UWPStd

if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\UWPStd\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\UWPStd\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\UWPStd\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.dll" .\_Binaries\Release\UWPStd\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\UWPStd\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.xml" .\_Binaries\Release\UWPStd\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\UWPStd\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\UWPStd\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Debug\GalaSoft.MvvmLight.Platform.pri" copy ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Debug\GalaSoft.MvvmLight.Platform.pri" .\_Binaries\Debug\UWPStd\GalaSoft.MvvmLight.Platform.pri
if exist ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\UWPStd\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Release\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Release\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\UWPStd\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\UWPStd\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Release\GalaSoft.MvvmLight.Platform.pri" copy ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Release\GalaSoft.MvvmLight.Platform.pri" .\_Binaries\Release\UWPStd\GalaSoft.MvvmLight.Platform.pri
if exist ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Release\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (UWPStd)\bin\Release\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\UWPStd\GalaSoft.MvvmLight.Platform.xml

rem Android

if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\Android\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\Android\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\Android\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\Android\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\Android\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\Android\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Platform (Android)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (Android)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (Android)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (Android)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (Android)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (Android)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (Android)\bin\Release\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (Android)\bin\Release\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\Android\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (Android)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (Android)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\Android\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (Android)\bin\\Release\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (Android)\bin\Release\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\Android\GalaSoft.MvvmLight.Platform.xml

if exist ".\GalaSoft.MvvmLight.AndroidSupport\bin\Debug\GalaSoft.MvvmLight.Platform.AndroidSupport.dll" copy ".\GalaSoft.MvvmLight.AndroidSupport\bin\Debug\GalaSoft.MvvmLight.Platform.AndroidSupport.dll" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.Platform.AndroidSupport.dll
if exist ".\GalaSoft.MvvmLight.AndroidSupport\bin\Debug\GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" copy ".\GalaSoft.MvvmLight.AndroidSupport\bin\Debug\GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.Platform.AndroidSupport.pdb
if exist ".\GalaSoft.MvvmLight.AndroidSupport\bin\Debug\GalaSoft.MvvmLight.Platform.AndroidSupport.xml" copy ".\GalaSoft.MvvmLight.AndroidSupport\bin\Debug\GalaSoft.MvvmLight.Platform.AndroidSupport.xml" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.Platform.AndroidSupport.xml
if exist ".\GalaSoft.MvvmLight.AndroidSupport\bin\Release\GalaSoft.MvvmLight.Platform.AndroidSupport.dll" copy ".\GalaSoft.MvvmLight.AndroidSupport\bin\Release\GalaSoft.MvvmLight.Platform.AndroidSupport.dll" .\_Binaries\Release\Android\GalaSoft.MvvmLight.Platform.AndroidSupport.dll
if exist ".\GalaSoft.MvvmLight.AndroidSupport\bin\Release\GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" copy ".\GalaSoft.MvvmLight.AndroidSupport\bin\Release\GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" .\_Binaries\Release\Android\GalaSoft.MvvmLight.Platform.AndroidSupport.pdb
if exist ".\GalaSoft.MvvmLight.AndroidSupport\bin\Release\GalaSoft.MvvmLight.Platform.AndroidSupport.xml" copy ".\GalaSoft.MvvmLight.AndroidSupport\bin\Release\GalaSoft.MvvmLight.Platform.AndroidSupport.xml" .\_Binaries\Release\Android\GalaSoft.MvvmLight.Platform.AndroidSupport.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\Android\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\Android\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\Android\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\Android\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\Android\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\Android\Microsoft.Practices.ServiceLocation.xml

rem AndroidStd

if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\AndroidStd\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\AndroidStd\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\AndroidStd\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.dll" .\_Binaries\Release\AndroidStd\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\AndroidStd\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.xml" .\_Binaries\Release\AndroidStd\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Platform (AndroidStd)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (AndroidStd)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\AndroidStd\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (AndroidStd)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (AndroidStd)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\AndroidStd\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (AndroidStd)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (AndroidStd)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\AndroidStd\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (AndroidStd)\bin\Release\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (AndroidStd)\bin\Release\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\AndroidStd\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (AndroidStd)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (AndroidStd)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\AndroidStd\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (AndroidStd)\bin\Release\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (AndroidStd)\bin\Release\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\AndroidStd\GalaSoft.MvvmLight.Platform.xml

if exist ".\GalaSoft.MvvmLight.AndroidSupport\bin\Debug\GalaSoft.MvvmLight.Platform.AndroidSupport.dll" copy ".\GalaSoft.MvvmLight.AndroidSupport\bin\Debug\GalaSoft.MvvmLight.Platform.AndroidSupport.dll" .\_Binaries\Debug\AndroidStd\GalaSoft.MvvmLight.Platform.AndroidSupport.dll
if exist ".\GalaSoft.MvvmLight.AndroidSupport\bin\Debug\GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" copy ".\GalaSoft.MvvmLight.AndroidSupport\bin\Debug\GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" .\_Binaries\Debug\AndroidStd\GalaSoft.MvvmLight.Platform.AndroidSupport.pdb
if exist ".\GalaSoft.MvvmLight.AndroidSupport\bin\Debug\GalaSoft.MvvmLight.Platform.AndroidSupport.xml" copy ".\GalaSoft.MvvmLight.AndroidSupport\bin\Debug\GalaSoft.MvvmLight.Platform.AndroidSupport.xml" .\_Binaries\Debug\AndroidStd\GalaSoft.MvvmLight.Platform.AndroidSupport.xml
if exist ".\GalaSoft.MvvmLight.AndroidSupport\bin\Release\GalaSoft.MvvmLight.Platform.AndroidSupport.dll" copy ".\GalaSoft.MvvmLight.AndroidSupport\bin\Release\GalaSoft.MvvmLight.Platform.AndroidSupport.dll" .\_Binaries\Release\AndroidStd\GalaSoft.MvvmLight.Platform.AndroidSupport.dll
if exist ".\GalaSoft.MvvmLight.AndroidSupport\bin\Release\GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" copy ".\GalaSoft.MvvmLight.AndroidSupport\bin\Release\GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" .\_Binaries\Release\AndroidStd\GalaSoft.MvvmLight.Platform.AndroidSupport.pdb
if exist ".\GalaSoft.MvvmLight.AndroidSupport\bin\Release\GalaSoft.MvvmLight.Platform.AndroidSupport.xml" copy ".\GalaSoft.MvvmLight.AndroidSupport\bin\Release\GalaSoft.MvvmLight.Platform.AndroidSupport.xml" .\_Binaries\Release\AndroidStd\GalaSoft.MvvmLight.Platform.AndroidSupport.xml

rem iOS

if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Platform (iOS)\bin\iPhone\Debug\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (iOS)\bin\iPhone\Debug\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (iOS)\bin\iPhone\Debug\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (iOS)\bin\iPhone\Debug\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (iOS)\bin\iPhone\Debug\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (iOS)\bin\iPhone\Debug\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (iOS)\bin\iPhone\Release\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (iOS)\bin\iPhone\Release\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (iOS)\bin\iPhone\Release\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (iOS)\bin\iPhone\Release\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (iOS)\bin\iPhone\Release\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (iOS)\bin\iPhone\Release\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.Platform.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\iOS\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\iOS\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\iOS\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\iOS\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\iOS\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\iOS\Microsoft.Practices.ServiceLocation.xml

rem iOSStd

if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\iOSStd\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\iOSStd\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\iOSStd\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.dll" .\_Binaries\Release\iOSStd\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\iOSStd\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.xml" .\_Binaries\Release\iOSStd\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Platform (iOSStd)\bin\iPhone\Debug\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (iOSStd)\bin\iPhone\Debug\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\iOSStd\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (iOSStd)\bin\iPhone\Debug\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (iOSStd)\bin\iPhone\Debug\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\iOSStd\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (iOSStd)\bin\iPhone\Debug\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (iOSStd)\bin\iPhone\Debug\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\iOSStd\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (iOSStd)\bin\iPhone\Release\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (iOSStd)\bin\iPhone\Release\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\iOSStd\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (iOSStd)\bin\iPhone\Release\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (iOSStd)\bin\iPhone\Release\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\iOSStd\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (iOSStd)\bin\iPhone\Release\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (iOSStd)\bin\iPhone\Release\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\iOSStd\GalaSoft.MvvmLight.Platform.xml

rem SL5

if exist ".\GalaSoft.MvvmLight (SL5)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (SL5)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\SL5\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (SL5)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (SL5)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\SL5\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (SL5)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (SL5)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\SL5\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (SL5)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (SL5)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\SL5\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (SL5)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (SL5)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\SL5\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (SL5)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (SL5)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\SL5\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\SL5\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\SL5\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\SL5\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\SL5\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\SL5\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\SL5\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\SL5\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\SL5\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\SL5\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\SL5\Microsoft.Practices.ServiceLocation.xml

if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\SL5\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\SL5\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\SL5\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (SL5)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\SL5\System.Windows.Interactivity.xml

rem Win81

if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\WIN81\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\WIN81\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\WIN81\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\WIN81\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\WIN81\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\WIN81\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\WIN81\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\WIN81\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\WIN81\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\WIN81\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\WIN81\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\WIN81\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\WIN81\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\WIN81\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\GalaSoft.MvvmLight.Platform.pri" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\GalaSoft.MvvmLight.Platform.pri" .\_Binaries\Debug\WIN81\GalaSoft.MvvmLight.Platform.pri
if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\WIN81\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\WIN81\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\WIN81\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\GalaSoft.MvvmLight.Platform.pri" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\GalaSoft.MvvmLight.Platform.pri" .\_Binaries\Release\WIN81\GalaSoft.MvvmLight.Platform.pri
if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\WIN81\GalaSoft.MvvmLight.Platform.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\WIN81\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\WIN81\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\WIN81\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\WIN81\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\WIN81\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\WIN81\Microsoft.Practices.ServiceLocation.xml

rem WP81

if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\WP81\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\WP81\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\WP81\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\WP81\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\WP81\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\WP81\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\WP81\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\WP81\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\WP81\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\WP81\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\WP81\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\WP81\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\WP81\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\WP81\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\GalaSoft.MvvmLight.Platform.pri" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\GalaSoft.MvvmLight.Platform.pri" .\_Binaries\Debug\WP81\GalaSoft.MvvmLight.Platform.pri
if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\WP81\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\WP81\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\WP81\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\GalaSoft.MvvmLight.Platform.pri" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\GalaSoft.MvvmLight.Platform.pri" .\_Binaries\Release\WP81\GalaSoft.MvvmLight.Platform.pri
if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\WP81\GalaSoft.MvvmLight.Platform.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\WP81\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\WP81\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\WP81\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\WP81\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\WP81\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\WP81\Microsoft.Practices.ServiceLocation.xml

rem WPSL80

if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\WPSL80\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\WPSL80\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\WPSL80\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\WPSL80\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\WPSL80\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\WPSL80\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\WPSL80\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\WPSL80\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\WPSL80\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\WPSL80\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\WPSL80\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\WPSL80\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\WPSL80\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\WPSL80\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\WPSL80\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\WPSL80\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\WPSL80\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\WPSL80\GalaSoft.MvvmLight.Platform.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\WPSL80\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\WPSL80\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\WPSL80\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\WPSL80\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\WPSL80\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\WPSL80\Microsoft.Practices.ServiceLocation.xml

if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\WPSL80\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\WPSL80\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\WPSL80\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\WPSL80\System.Windows.Interactivity.xml

rem WPSL81

if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\WPSL81\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\WPSL81\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\WPSL81\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\WPSL81\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\WPSL81\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\WPSL81\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\WPSL81\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\WPSL81\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\WPSL81\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\WPSL81\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\WPSL81\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\WPSL81\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\WPSL81\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\WPSL81\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\WPSL81\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\WPSL81\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\WPSL81\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\WPSL81\GalaSoft.MvvmLight.Platform.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\WPSL81\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\WPSL81\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\WPSL81\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\WPSL81\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\WPSL81\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\WPSL81\Microsoft.Practices.ServiceLocation.xml

if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\WPSL81\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\WPSL81\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\WPSL81\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\WPSL81\System.Windows.Interactivity.xml

rem NETCORE30

if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\NETCORE30\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\NETCORE30\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight.STD10\bin\Debug\netstandard1.0\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\NETCORE30\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.dll" .\_Binaries\Release\NETCORE30\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\NETCORE30\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight.STD10\bin\Release\netstandard1.0\GalaSoft.MvvmLight.xml" .\_Binaries\Release\NETCORE30\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Platform (NETCORE30)\bin\Debug\netcoreapp3.0\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (NETCORE30)\bin\Debug\netcoreapp3.0\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\NETCORE30\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (NETCORE30)\bin\Debug\netcoreapp3.0\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (NETCORE30)\bin\Debug\netcoreapp3.0\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\NETCORE30\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (NETCORE30)\bin\Debug\netcoreapp3.0\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (NETCORE30)\bin\Debug\netcoreapp3.0\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\NETCORE30\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (NETCORE30)\bin\Release\netcoreapp3.0\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (NETCORE30)\bin\Release\netcoreapp3.0\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\NETCORE30\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (NETCORE30)\bin\Release\netcoreapp3.0\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (NETCORE30)\bin\Release\netcoreapp3.0\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\NETCORE30\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (NETCORE30)\bin\Release\netcoreapp3.0\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (NETCORE30)\bin\Release\netcoreapp3.0\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\NETCORE30\GalaSoft.MvvmLight.Platform.xml
