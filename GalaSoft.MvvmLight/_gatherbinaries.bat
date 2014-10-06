rem @echo off

if not exist _Binaries md _Binaries
if not exist _Binaries\Debug md _Binaries\Debug

if not exist _Binaries\Debug\NET45 md _Binaries\Debug\NET45
if not exist _Binaries\Debug\WIN81 md _Binaries\Debug\WIN81
if not exist _Binaries\Debug\WP81 md _Binaries\Debug\WP81
if not exist _Binaries\Debug\WPSL80 md _Binaries\Debug\WPSL80
if not exist _Binaries\Debug\WPSL81 md _Binaries\Debug\WPSL81
if not exist _Binaries\Debug\NET35 md _Binaries\Debug\NET35
if not exist _Binaries\Debug\NET4 md _Binaries\Debug\NET4
if not exist _Binaries\Debug\SL4 md _Binaries\Debug\SL4
if not exist _Binaries\Debug\Android md _Binaries\Debug\Android
if not exist _Binaries\Debug\AndroidPcl md _Binaries\Debug\AndroidPcl
if not exist _Binaries\Debug\iOS md _Binaries\Debug\iOS
if not exist _Binaries\Debug\PCL md _Binaries\Debug\PCL

if not exist _Binaries\Release\NET45 md _Binaries\Release\NET45
if not exist _Binaries\Release\WIN81 md _Binaries\Release\WIN81
if not exist _Binaries\Release\WP81 md _Binaries\Release\WP81
if not exist _Binaries\Release\WPSL80 md _Binaries\Release\WPSL80
if not exist _Binaries\Release\WPSL81 md _Binaries\Release\WPSL81
if not exist _Binaries\Release\NET35 md _Binaries\Release\NET35
if not exist _Binaries\Release\NET4 md _Binaries\Release\NET4
if not exist _Binaries\Release\SL4 md _Binaries\Release\SL4
if not exist _Binaries\Release\Android md _Binaries\Release\Android
if not exist _Binaries\Release\AndroidPcl md _Binaries\Release\AndroidPcl
if not exist _Binaries\Release\iOS md _Binaries\Release\iOS
if not exist _Binaries\Release\PCL md _Binaries\Release\PCL

if exist ".\GalaSoft.MvvmLight (Android)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (Android)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (Android)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (Android)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (Android)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (Android)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (Android)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (Android)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\Android\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (Android)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (Android)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\Android\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (Android)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (Android)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\Android\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (Android)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (Android)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (Android)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (Android)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (Android)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (Android)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\Android\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (Android)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (Android)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\Android\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (Android)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (Android)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\Android\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (Android)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (Android)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\Android\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Extras (Android)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (Android)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\Android\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (Android)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (Android)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\Android\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (Android)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (Android)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\Android\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (Android)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (Android)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\Android\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (Android)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (Android)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\Android\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (Android)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (Android)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\Android\Microsoft.Practices.ServiceLocation.xml

if exist ".\GalaSoft.MvvmLight (iOS)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (iOS)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (iOS)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (iOS)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (iOS)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (iOS)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (iOS)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (iOS)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (iOS)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (iOS)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (iOS)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (iOS)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\iOS\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\iOS\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\iOS\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\iOS\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\iOS\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\iOS\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\iOS\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (iOS)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\iOS\Microsoft.Practices.ServiceLocation.xml

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

if exist ".\GalaSoft.MvvmLight (SL4)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (SL4)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\SL4\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (SL4)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (SL4)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\SL4\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (SL4)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (SL4)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\SL4\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (SL4)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (SL4)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\SL4\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (SL4)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (SL4)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\SL4\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (SL4)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (SL4)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\SL4\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\SL4\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\SL4\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\SL4\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\SL4\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\SL4\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\SL4\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\SL4\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\SL4\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\SL4\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\SL4\Microsoft.Practices.ServiceLocation.xml

if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\SL4\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\SL4\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\SL4\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Extras (SL4)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\SL4\System.Windows.Interactivity.xml

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

if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\NET45\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\NET45\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\NET45\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\NET45\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\NET45\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\NET45\Microsoft.Practices.ServiceLocation.xml

if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\NET45\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\NET45\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\NET45\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (NET45)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\NET45\System.Windows.Interactivity.xml

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

if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\WIN81\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\WIN81\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\WIN81\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\WIN81\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\WIN81\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Platform (WIN81)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\WIN81\Microsoft.Practices.ServiceLocation.xml

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

if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\WP81\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\WP81\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\WP81\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\WP81\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\WP81\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Platform (WP81)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\WP81\Microsoft.Practices.ServiceLocation.xml

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

if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\WPSL80\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\WPSL80\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\WPSL80\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\WPSL80\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\WPSL80\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\WPSL80\Microsoft.Practices.ServiceLocation.xml

if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\WPSL80\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\WPSL80\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\WPSL80\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL80)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\WPSL80\System.Windows.Interactivity.xml

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

if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Debug\WPSL81\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Debug\WPSL81\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Debug\WPSL81\Microsoft.Practices.ServiceLocation.xml
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\Microsoft.Practices.ServiceLocation.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\Microsoft.Practices.ServiceLocation.dll" .\_Binaries\Release\WPSL81\Microsoft.Practices.ServiceLocation.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\Microsoft.Practices.ServiceLocation.pdb" .\_Binaries\Release\WPSL81\Microsoft.Practices.ServiceLocation.pdb
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\Microsoft.Practices.ServiceLocation.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\Microsoft.Practices.ServiceLocation.xml" .\_Binaries\Release\WPSL81\Microsoft.Practices.ServiceLocation.xml

if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\System.Windows.Interactivity.dll" .\_Binaries\Debug\WPSL81\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Debug\System.Windows.Interactivity.xml" .\_Binaries\Debug\WPSL81\System.Windows.Interactivity.xml
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\System.Windows.Interactivity.dll" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\System.Windows.Interactivity.dll" .\_Binaries\Release\WPSL81\System.Windows.Interactivity.dll
if exist ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\System.Windows.Interactivity.xml" copy ".\GalaSoft.MvvmLight.Platform (WPSL81)\bin\Release\System.Windows.Interactivity.xml" .\_Binaries\Release\WPSL81\System.Windows.Interactivity.xml

if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.dll" .\_Binaries\Debug\AndroidPcl\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.pdb" .\_Binaries\Debug\AndroidPcl\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Debug\GalaSoft.MvvmLight.xml" .\_Binaries\Debug\AndroidPcl\GalaSoft.MvvmLight.xml
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.dll" .\_Binaries\Release\AndroidPcl\GalaSoft.MvvmLight.dll
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.pdb" .\_Binaries\Release\AndroidPcl\GalaSoft.MvvmLight.pdb
if exist ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" copy ".\GalaSoft.MvvmLight (PCL)\bin\Release\GalaSoft.MvvmLight.xml" .\_Binaries\Release\AndroidPcl\GalaSoft.MvvmLight.xml

if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Debug\AndroidPcl\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Debug\AndroidPcl\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Debug\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Debug\AndroidPcl\GalaSoft.MvvmLight.Extras.xml
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.dll" .\_Binaries\Release\AndroidPcl\GalaSoft.MvvmLight.Extras.dll
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.pdb" .\_Binaries\Release\AndroidPcl\GalaSoft.MvvmLight.Extras.pdb
if exist ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" copy ".\GalaSoft.MvvmLight.Extras (PCL)\bin\Release\GalaSoft.MvvmLight.Extras.xml" .\_Binaries\Release\AndroidPcl\GalaSoft.MvvmLight.Extras.xml

if exist ".\GalaSoft.MvvmLight.Platform (Android)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (Android)\bin\Debug\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Debug\AndroidPcl\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (Android)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (Android)\bin\Debug\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Debug\AndroidPcl\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (Android)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (Android)\bin\Debug\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Debug\AndroidPcl\GalaSoft.MvvmLight.Platform.xml
if exist ".\GalaSoft.MvvmLight.Platform (Android)\bin\Release\GalaSoft.MvvmLight.Platform.dll" copy ".\GalaSoft.MvvmLight.Platform (Android)\bin\Release\GalaSoft.MvvmLight.Platform.dll" .\_Binaries\Release\AndroidPcl\GalaSoft.MvvmLight.Platform.dll
if exist ".\GalaSoft.MvvmLight.Platform (Android)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" copy ".\GalaSoft.MvvmLight.Platform (Android)\bin\Release\GalaSoft.MvvmLight.Platform.pdb" .\_Binaries\Release\AndroidPcl\GalaSoft.MvvmLight.Platform.pdb
if exist ".\GalaSoft.MvvmLight.Platform (Android)\bin\Release\GalaSoft.MvvmLight.Platform.xml" copy ".\GalaSoft.MvvmLight.Platform (Android)\bin\Release\GalaSoft.MvvmLight.Platform.xml" .\_Binaries\Release\AndroidPcl\GalaSoft.MvvmLight.Platform.xml

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