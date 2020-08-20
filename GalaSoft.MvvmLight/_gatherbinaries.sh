#!/bin/bash

if [ ! -e "_Binaries" ]
then
  mkdir _Binaries
fi
if [ ! -e "_Binaries/Debug" ]
then
  mkdir _Binaries/Debug
fi
if [ ! -e "_Binaries/Release" ]
then
  mkdir _Binaries/Release
fi


if [ ! -e "_Binaries/Debug/PCL" ]
then
  mkdir _Binaries/Debug/PCL
fi
if [ ! -e "_Binaries/Debug/STD10" ]
then
  mkdir _Binaries/Debug/STD10
fi
if [ ! -e "_Binaries/Debug/NET35" ]
then
  mkdir _Binaries/Debug/NET35
fi
if [ ! -e "_Binaries/Debug/NET4" ]
then
  mkdir _Binaries/Debug/NET4
fi
if [ ! -e "_Binaries/Debug/NET45" ]
then
  mkdir _Binaries/Debug/NET45
fi
if [ ! -e "_Binaries/Debug/NET45Std" ]
then
  mkdir _Binaries/Debug/NET45Std
fi
if [ ! -e "_Binaries/Debug/UWP" ]
then
  mkdir _Binaries/Debug/UWP
fi
if [ ! -e "_Binaries/Debug/UWPStd" ]
then
  mkdir _Binaries/Debug/UWPStd
fi
if [ ! -e "_Binaries/Debug/Android" ]
then
  mkdir _Binaries/Debug/Android
fi
if [ ! -e "_Binaries/Debug/AndroidStd" ]
then
  mkdir _Binaries/Debug/AndroidStd
fi
if [ ! -e "_Binaries/Debug/iOS" ]
then
  mkdir _Binaries/Debug/iOS
fi
if [ ! -e "_Binaries/Debug/iOSStd" ]
then
  mkdir _Binaries/Debug/iOSStd
fi
if [ ! -e "_Binaries/Debug/SL5" ]
then
  mkdir _Binaries/Debug/SL5
fi
if [ ! -e "_Binaries/Debug/WIN81" ]
then
  mkdir _Binaries/Debug/WIN81
fi
if [ ! -e "_Binaries/Debug/WP81" ]
then
  mkdir _Binaries/Debug/WP81
fi
if [ ! -e "_Binaries/Debug/WPSL80" ]
then
  mkdir _Binaries/Debug/WPSL80
fi
if [ ! -e "_Binaries/Debug/WPSL81" ]
then
  mkdir _Binaries/Debug/WPSL81
fi

if [ ! -e "_Binaries/Release/PCL" ]
then
  mkdir _Binaries/Release/PCL
fi
if [ ! -e "_Binaries/Release/STD10" ]
then
  mkdir _Binaries/Release/STD10
fi
if [ ! -e "_Binaries/Release/NET35" ]
then
  mkdir _Binaries/Release/NET35
fi
if [ ! -e "_Binaries/Release/NET4" ]
then
  mkdir _Binaries/Release/NET4
fi
if [ ! -e "_Binaries/Release/NET45" ]
then
  mkdir _Binaries/Release/NET45
fi
if [ ! -e "_Binaries/Release/NET45Std" ]
then
  mkdir _Binaries/Release/NET45Std
fi
if [ ! -e "_Binaries/Release/UWP" ]
then
  mkdir _Binaries/Release/UWP
fi
if [ ! -e "_Binaries/Release/UWPStd" ]
then
  mkdir _Binaries/Release/UWPStd
fi
if [ ! -e "_Binaries/Release/Android" ]
then
  mkdir _Binaries/Release/Android
fi
if [ ! -e "_Binaries/Release/AndroidStd" ]
then
  mkdir _Binaries/Release/AndroidStd
fi
if [ ! -e "_Binaries/Release/iOS" ]
then
  mkdir _Binaries/Release/iOS
fi
if [ ! -e "_Binaries/Release/iOSStd" ]
then
  mkdir _Binaries/Release/iOSStd
fi
if [ ! -e "_Binaries/Release/SL5" ]
then
  mkdir _Binaries/Release/SL5
fi
if [ ! -e "_Binaries/Release/WIN81" ]
then
  mkdir _Binaries/Release/WIN81
fi
if [ ! -e "_Binaries/Release/WP81" ]
then
  mkdir _Binaries/Release/WP81
fi
if [ ! -e "_Binaries/Release/WPSL80" ]
then
  mkdir _Binaries/Release/WPSL80
fi
if [ ! -e "_Binaries/Release/WPSL81" ]
then
  mkdir _Binaries/Release/WPSL81
fi

# PCL

if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/PCL/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/PCL/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/PCL/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ./_Binaries/Release/PCL/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/PCL/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ./_Binaries/Release/PCL/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Debug/PCL/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Debug/PCL/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Debug/PCL/GalaSoft.MvvmLight.Extras.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Release/PCL/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Release/PCL/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Release/PCL/GalaSoft.MvvmLight.Extras.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Debug/PCL/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Debug/PCL/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Debug/PCL/Microsoft.Practices.ServiceLocation.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Release/PCL/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Release/PCL/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Release/PCL/Microsoft.Practices.ServiceLocation.xml
fi

# .NET Standard 1.0

if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/STD10/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/STD10/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/STD10/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.dll" ./_Binaries/Release/STD10/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/STD10/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.xml" ./_Binaries/Release/STD10/GalaSoft.MvvmLight.xml
fi

# NET35

if [ -e "./GalaSoft.MvvmLight (NET35)/bin/Debug/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (NET35)/bin/Debug/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/NET35/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (NET35)/bin/Debug/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (NET35)/bin/Debug/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/NET35/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (NET35)/bin/Debug/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (NET35)/bin/Debug/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/NET35/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight (NET35)/bin/Release/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (NET35)/bin/Release/GalaSoft.MvvmLight.dll" ./_Binaries/Release/NET35/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (NET35)/bin/Release/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (NET35)/bin/Release/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/NET35/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (NET35)/bin/Release/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (NET35)/bin/Release/GalaSoft.MvvmLight.xml" ./_Binaries/Release/NET35/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Debug/NET35/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Debug/NET35/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Debug/NET35/GalaSoft.MvvmLight.Extras.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Release/NET35/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Release/NET35/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Release/NET35/GalaSoft.MvvmLight.Extras.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Debug/NET35/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Debug/NET35/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Debug/NET35/Microsoft.Practices.ServiceLocation.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Release/NET35/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Release/NET35/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Release/NET35/Microsoft.Practices.ServiceLocation.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/System.Windows.Interactivity.dll" ./_Binaries/Debug/NET35/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Debug/System.Windows.Interactivity.xml" ./_Binaries/Debug/NET35/System.Windows.Interactivity.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/System.Windows.Interactivity.dll" ./_Binaries/Release/NET35/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET35)/bin/Release/System.Windows.Interactivity.xml" ./_Binaries/Release/NET35/System.Windows.Interactivity.xml
fi

# NET4

if [ -e "./GalaSoft.MvvmLight (NET4)/bin/Debug/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (NET4)/bin/Debug/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/NET4/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (NET4)/bin/Debug/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (NET4)/bin/Debug/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/NET4/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (NET4)/bin/Debug/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (NET4)/bin/Debug/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/NET4/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight (NET4)/bin/Release/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (NET4)/bin/Release/GalaSoft.MvvmLight.dll" ./_Binaries/Release/NET4/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (NET4)/bin/Release/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (NET4)/bin/Release/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/NET4/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (NET4)/bin/Release/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (NET4)/bin/Release/GalaSoft.MvvmLight.xml" ./_Binaries/Release/NET4/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Debug/NET4/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Debug/NET4/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Debug/NET4/GalaSoft.MvvmLight.Extras.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Release/NET4/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Release/NET4/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Release/NET4/GalaSoft.MvvmLight.Extras.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Debug/NET4/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Debug/NET4/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Debug/NET4/Microsoft.Practices.ServiceLocation.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Release/NET4/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Release/NET4/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Release/NET4/Microsoft.Practices.ServiceLocation.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/System.Windows.Interactivity.dll" ./_Binaries/Debug/NET4/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Debug/System.Windows.Interactivity.xml" ./_Binaries/Debug/NET4/System.Windows.Interactivity.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/System.Windows.Interactivity.dll" ./_Binaries/Release/NET4/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (NET4)/bin/Release/System.Windows.Interactivity.xml" ./_Binaries/Release/NET4/System.Windows.Interactivity.xml
fi

# NET45

if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/NET45/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/NET45/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/NET45/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ./_Binaries/Release/NET45/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/NET45/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ./_Binaries/Release/NET45/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Debug/NET45/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Debug/NET45/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Debug/NET45/GalaSoft.MvvmLight.Extras.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Release/NET45/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Release/NET45/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Release/NET45/GalaSoft.MvvmLight.Extras.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (NET45)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Debug/NET45/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Debug/NET45/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Debug/NET45/GalaSoft.MvvmLight.Platform.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Release/NET45/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Release/NET45/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Release/NET45/GalaSoft.MvvmLight.Platform.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Debug/NET45/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Debug/NET45/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Debug/NET45/Microsoft.Practices.ServiceLocation.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Release/NET45/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Release/NET45/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Release/NET45/Microsoft.Practices.ServiceLocation.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (NET45)/bin/Debug/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45)/bin/Debug/System.Windows.Interactivity.dll" ./_Binaries/Debug/NET45/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45)/bin/Debug/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45)/bin/Debug/System.Windows.Interactivity.xml" ./_Binaries/Debug/NET45/System.Windows.Interactivity.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45)/bin/Release/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45)/bin/Release/System.Windows.Interactivity.dll" ./_Binaries/Release/NET45/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45)/bin/Release/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45)/bin/Release/System.Windows.Interactivity.xml" ./_Binaries/Release/NET45/System.Windows.Interactivity.xml
fi

# NET45Std

if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/NET45Std/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/NET45Std/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/NET45Std/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.dll" ./_Binaries/Release/NET45Std/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/NET45Std/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.xml" ./_Binaries/Release/NET45Std/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Debug/NET45Std/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Debug/NET45Std/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Debug/NET45Std/GalaSoft.MvvmLight.Platform.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Release/NET45Std/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Release/NET45Std/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Release/NET45Std/GalaSoft.MvvmLight.Platform.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Debug/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Debug/System.Windows.Interactivity.dll" ./_Binaries/Debug/NET45Std/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Debug/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Debug/System.Windows.Interactivity.xml" ./_Binaries/Debug/NET45Std/System.Windows.Interactivity.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Release/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Release/System.Windows.Interactivity.dll" ./_Binaries/Release/NET45Std/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Release/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (NET45Std)/bin/Release/System.Windows.Interactivity.xml" ./_Binaries/Release/NET45Std/System.Windows.Interactivity.xml
fi

# UWP

if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/UWP/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/UWP/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/UWP/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ./_Binaries/Release/UWP/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/UWP/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ./_Binaries/Release/UWP/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Debug/UWP/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Debug/UWP/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Debug/UWP/GalaSoft.MvvmLight.Extras.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Release/UWP/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Release/UWP/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Release/UWP/GalaSoft.MvvmLight.Extras.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (UWP)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWP)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Debug/UWP/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWP)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWP)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Debug/UWP/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWP)/bin/Debug/GalaSoft.MvvmLight.Platform.pri" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWP)/bin/Debug/GalaSoft.MvvmLight.Platform.pri" ./_Binaries/Debug/UWP/GalaSoft.MvvmLight.Platform.pri
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWP)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWP)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Debug/UWP/GalaSoft.MvvmLight.Platform.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWP)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWP)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Release/UWP/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWP)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWP)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Release/UWP/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWP)/bin/Release/GalaSoft.MvvmLight.Platform.pri" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWP)/bin/Release/GalaSoft.MvvmLight.Platform.pri" ./_Binaries/Release/UWP/GalaSoft.MvvmLight.Platform.pri
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWP)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWP)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Release/UWP/GalaSoft.MvvmLight.Platform.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Debug/UWP/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Debug/UWP/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Debug/UWP/Microsoft.Practices.ServiceLocation.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Release/UWP/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Release/UWP/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Release/UWP/Microsoft.Practices.ServiceLocation.xml
fi

# UWPStd

if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/UWPStd/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/UWPStd/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/UWPStd/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.dll" ./_Binaries/Release/UWPStd/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/UWPStd/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.xml" ./_Binaries/Release/UWPStd/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Debug/UWPStd/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Debug/UWPStd/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Debug/GalaSoft.MvvmLight.Platform.pri" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Debug/GalaSoft.MvvmLight.Platform.pri" ./_Binaries/Debug/UWPStd/GalaSoft.MvvmLight.Platform.pri
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Debug/UWPStd/GalaSoft.MvvmLight.Platform.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Release/UWPStd/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Release/UWPStd/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Release/GalaSoft.MvvmLight.Platform.pri" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Release/GalaSoft.MvvmLight.Platform.pri" ./_Binaries/Release/UWPStd/GalaSoft.MvvmLight.Platform.pri
fi
if [ -e "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (UWPStd)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Release/UWPStd/GalaSoft.MvvmLight.Platform.xml
fi

# Android

if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ./_Binaries/Release/Android/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/Android/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ./_Binaries/Release/Android/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.Extras.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Release/Android/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Release/Android/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Release/Android/GalaSoft.MvvmLight.Extras.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (Android)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (Android)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (Android)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (Android)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (Android)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (Android)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.Platform.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (Android)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (Android)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Release/Android/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (Android)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (Android)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Release/Android/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (Android)/bin//Release/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (Android)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Release/Android/GalaSoft.MvvmLight.Platform.xml
fi

if [ -e "./GalaSoft.MvvmLight.AndroidSupport/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidSupport.dll" ]
then
  cp "./GalaSoft.MvvmLight.AndroidSupport/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidSupport.dll" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.Platform.AndroidSupport.dll
fi
if [ -e "./GalaSoft.MvvmLight.AndroidSupport/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" ]
then
  cp "./GalaSoft.MvvmLight.AndroidSupport/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.Platform.AndroidSupport.pdb
fi
if [ -e "./GalaSoft.MvvmLight.AndroidSupport/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidSupport.xml" ]
then
  cp "./GalaSoft.MvvmLight.AndroidSupport/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidSupport.xml" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.Platform.AndroidSupport.xml
fi
if [ -e "./GalaSoft.MvvmLight.AndroidSupport/bin/Release/GalaSoft.MvvmLight.Platform.AndroidSupport.dll" ]
then
  cp "./GalaSoft.MvvmLight.AndroidSupport/bin/Release/GalaSoft.MvvmLight.Platform.AndroidSupport.dll" ./_Binaries/Release/Android/GalaSoft.MvvmLight.Platform.AndroidSupport.dll
fi
if [ -e "./GalaSoft.MvvmLight.AndroidSupport/bin/Release/GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" ]
then
  cp "./GalaSoft.MvvmLight.AndroidSupport/bin/Release/GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" ./_Binaries/Release/Android/GalaSoft.MvvmLight.Platform.AndroidSupport.pdb
fi
if [ -e "./GalaSoft.MvvmLight.AndroidSupport/bin/Release/GalaSoft.MvvmLight.Platform.AndroidSupport.xml" ]
then
  cp "./GalaSoft.MvvmLight.AndroidSupport/bin/Release/GalaSoft.MvvmLight.Platform.AndroidSupport.xml" ./_Binaries/Release/Android/GalaSoft.MvvmLight.Platform.AndroidSupport.xml
fi

if [ -e "./GalaSoft.MvvmLight.AndroidX/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidX.dll" ]
then
  cp "./GalaSoft.MvvmLight.AndroidX/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidX.dll" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.Platform.AndroidX.dll
fi
if [ -e "./GalaSoft.MvvmLight.AndroidX/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidX.pdb" ]
then
  cp "./GalaSoft.MvvmLight.AndroidX/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidX.pdb" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.Platform.AndroidX.pdb
fi
if [ -e "./GalaSoft.MvvmLight.AndroidX/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidX.xml" ]
then
  cp "./GalaSoft.MvvmLight.AndroidX/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidX.xml" ./_Binaries/Debug/Android/GalaSoft.MvvmLight.Platform.AndroidX.xml
fi
if [ -e "./GalaSoft.MvvmLight.AndroidX/bin/Release/GalaSoft.MvvmLight.Platform.AndroidX.dll" ]
then
  cp "./GalaSoft.MvvmLight.AndroidX/bin/Release/GalaSoft.MvvmLight.Platform.AndroidX.dll" ./_Binaries/Release/Android/GalaSoft.MvvmLight.Platform.AndroidX.dll
fi
if [ -e "./GalaSoft.MvvmLight.AndroidX/bin/Release/GalaSoft.MvvmLight.Platform.AndroidX.pdb" ]
then
  cp "./GalaSoft.MvvmLight.AndroidX/bin/Release/GalaSoft.MvvmLight.Platform.AndroidX.pdb" ./_Binaries/Release/Android/GalaSoft.MvvmLight.Platform.AndroidX.pdb
fi
if [ -e "./GalaSoft.MvvmLight.AndroidX/bin/Release/GalaSoft.MvvmLight.Platform.AndroidX.xml" ]
then
  cp "./GalaSoft.MvvmLight.AndroidX/bin/Release/GalaSoft.MvvmLight.Platform.AndroidX.xml" ./_Binaries/Release/Android/GalaSoft.MvvmLight.Platform.AndroidX.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Debug/Android/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Debug/Android/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Debug/Android/Microsoft.Practices.ServiceLocation.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Release/Android/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Release/Android/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Release/Android/Microsoft.Practices.ServiceLocation.xml
fi

# AndroidStd

if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/AndroidStd/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/AndroidStd/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/AndroidStd/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.dll" ./_Binaries/Release/AndroidStd/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/AndroidStd/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.xml" ./_Binaries/Release/AndroidStd/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (AndroidStd)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (AndroidStd)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Debug/AndroidStd/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (AndroidStd)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (AndroidStd)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Debug/AndroidStd/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (AndroidStd)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (AndroidStd)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Debug/AndroidStd/GalaSoft.MvvmLight.Platform.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (AndroidStd)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (AndroidStd)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Release/AndroidStd/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (AndroidStd)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (AndroidStd)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Release/AndroidStd/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (AndroidStd)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (AndroidStd)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Release/AndroidStd/GalaSoft.MvvmLight.Platform.xml
fi

if [ -e "./GalaSoft.MvvmLight.AndroidSupport/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidSupport.dll" ]
then
  cp "./GalaSoft.MvvmLight.AndroidSupport/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidSupport.dll" ./_Binaries/Debug/AndroidStd/GalaSoft.MvvmLight.Platform.AndroidSupport.dll
fi
if [ -e "./GalaSoft.MvvmLight.AndroidSupport/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" ]
then
  cp "./GalaSoft.MvvmLight.AndroidSupport/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" ./_Binaries/Debug/AndroidStd/GalaSoft.MvvmLight.Platform.AndroidSupport.pdb
fi
if [ -e "./GalaSoft.MvvmLight.AndroidSupport/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidSupport.xml" ]
then
  cp "./GalaSoft.MvvmLight.AndroidSupport/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidSupport.xml" ./_Binaries/Debug/AndroidStd/GalaSoft.MvvmLight.Platform.AndroidSupport.xml
fi
if [ -e "./GalaSoft.MvvmLight.AndroidSupport/bin/Release/GalaSoft.MvvmLight.Platform.AndroidSupport.dll" ]
then
  cp "./GalaSoft.MvvmLight.AndroidSupport/bin/Release/GalaSoft.MvvmLight.Platform.AndroidSupport.dll" ./_Binaries/Release/AndroidStd/GalaSoft.MvvmLight.Platform.AndroidSupport.dll
fi
if [ -e "./GalaSoft.MvvmLight.AndroidSupport/bin/Release/GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" ]
then
  cp "./GalaSoft.MvvmLight.AndroidSupport/bin/Release/GalaSoft.MvvmLight.Platform.AndroidSupport.pdb" ./_Binaries/Release/AndroidStd/GalaSoft.MvvmLight.Platform.AndroidSupport.pdb
fi
if [ -e "./GalaSoft.MvvmLight.AndroidSupport/bin/Release/GalaSoft.MvvmLight.Platform.AndroidSupport.xml" ]
then
  cp "./GalaSoft.MvvmLight.AndroidSupport/bin/Release/GalaSoft.MvvmLight.Platform.AndroidSupport.xml" ./_Binaries/Release/AndroidStd/GalaSoft.MvvmLight.Platform.AndroidSupport.xml
fi

if [ -e "./GalaSoft.MvvmLight.AndroidX/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidX.dll" ]
then
  cp "./GalaSoft.MvvmLight.AndroidX/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidX.dll" ./_Binaries/Debug/AndroidStd/GalaSoft.MvvmLight.Platform.AndroidX.dll
fi
if [ -e "./GalaSoft.MvvmLight.AndroidX/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidX.pdb" ]
then
  cp "./GalaSoft.MvvmLight.AndroidX/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidX.pdb" ./_Binaries/Debug/AndroidStd/GalaSoft.MvvmLight.Platform.AndroidX.pdb
fi
if [ -e "./GalaSoft.MvvmLight.AndroidX/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidX.xml" ]
then
  cp "./GalaSoft.MvvmLight.AndroidX/bin/Debug/GalaSoft.MvvmLight.Platform.AndroidX.xml" ./_Binaries/Debug/AndroidStd/GalaSoft.MvvmLight.Platform.AndroidX.xml
fi
if [ -e "./GalaSoft.MvvmLight.AndroidX/bin/Release/GalaSoft.MvvmLight.Platform.AndroidX.dll" ]
then
  cp "./GalaSoft.MvvmLight.AndroidX/bin/Release/GalaSoft.MvvmLight.Platform.AndroidX.dll" ./_Binaries/Release/AndroidStd/GalaSoft.MvvmLight.Platform.AndroidX.dll
fi
if [ -e "./GalaSoft.MvvmLight.AndroidX/bin/Release/GalaSoft.MvvmLight.Platform.AndroidX.pdb" ]
then
  cp "./GalaSoft.MvvmLight.AndroidX/bin/Release/GalaSoft.MvvmLight.Platform.AndroidX.pdb" ./_Binaries/Release/AndroidStd/GalaSoft.MvvmLight.Platform.AndroidX.pdb
fi
if [ -e "./GalaSoft.MvvmLight.AndroidX/bin/Release/GalaSoft.MvvmLight.Platform.AndroidX.xml" ]
then
  cp "./GalaSoft.MvvmLight.AndroidX/bin/Release/GalaSoft.MvvmLight.Platform.AndroidX.xml" ./_Binaries/Release/AndroidStd/GalaSoft.MvvmLight.Platform.AndroidX.xml
fi

# iOS

if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/iOS/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/iOS/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/iOS/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ./_Binaries/Release/iOS/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/iOS/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ./_Binaries/Release/iOS/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Debug/iOS/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Debug/iOS/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Debug/iOS/GalaSoft.MvvmLight.Extras.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Release/iOS/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Release/iOS/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Release/iOS/GalaSoft.MvvmLight.Extras.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (iOS)/bin/iPhone/Debug/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (iOS)/bin/iPhone/Debug/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Debug/iOS/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (iOS)/bin/iPhone/Debug/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (iOS)/bin/iPhone/Debug/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Debug/iOS/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (iOS)/bin/iPhone/Debug/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (iOS)/bin/iPhone/Debug/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Debug/iOS/GalaSoft.MvvmLight.Platform.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (iOS)/bin/iPhone/Release/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (iOS)/bin/iPhone/Release/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Release/iOS/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (iOS)/bin/iPhone/Release/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (iOS)/bin/iPhone/Release/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Release/iOS/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (iOS)/bin/iPhone/Release/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (iOS)/bin/iPhone/Release/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Release/iOS/GalaSoft.MvvmLight.Platform.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Debug/iOS/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Debug/iOS/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Debug/iOS/Microsoft.Practices.ServiceLocation.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Release/iOS/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Release/iOS/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin//Release/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Release/iOS/Microsoft.Practices.ServiceLocation.xml
fi

# iOSStd

if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/iOSStd/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/iOSStd/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Debug/netstandard1.0/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/iOSStd/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.dll" ./_Binaries/Release/iOSStd/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/iOSStd/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight.STD10/bin/Release/netstandard1.0/GalaSoft.MvvmLight.xml" ./_Binaries/Release/iOSStd/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (iOSStd)/bin/iPhone/Debug/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (iOSStd)/bin/iPhone/Debug/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Debug/iOSStd/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (iOSStd)/bin/iPhone/Debug/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (iOSStd)/bin/iPhone/Debug/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Debug/iOSStd/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (iOSStd)/bin/iPhone/Debug/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (iOSStd)/bin/iPhone/Debug/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Debug/iOSStd/GalaSoft.MvvmLight.Platform.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (iOSStd)/bin/iPhone/Release/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (iOSStd)/bin/iPhone/Release/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Release/iOSStd/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (iOSStd)/bin/iPhone/Release/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (iOSStd)/bin/iPhone/Release/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Release/iOSStd/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (iOSStd)/bin/iPhone/Release/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (iOSStd)/bin/iPhone/Release/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Release/iOSStd/GalaSoft.MvvmLight.Platform.xml
fi

# SL5

if [ -e "./GalaSoft.MvvmLight (SL5)/bin/Debug/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (SL5)/bin/Debug/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/SL5/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (SL5)/bin/Debug/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (SL5)/bin/Debug/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/SL5/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (SL5)/bin/Debug/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (SL5)/bin/Debug/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/SL5/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight (SL5)/bin/Release/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (SL5)/bin/Release/GalaSoft.MvvmLight.dll" ./_Binaries/Release/SL5/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (SL5)/bin/Release/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (SL5)/bin/Release/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/SL5/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (SL5)/bin/Release/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (SL5)/bin/Release/GalaSoft.MvvmLight.xml" ./_Binaries/Release/SL5/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Debug/SL5/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Debug/SL5/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Debug/SL5/GalaSoft.MvvmLight.Extras.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Release/SL5/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Release/SL5/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Release/SL5/GalaSoft.MvvmLight.Extras.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Debug/SL5/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Debug/SL5/Microsoft.Practices.ServiceLocation.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Release/SL5/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Release/SL5/Microsoft.Practices.ServiceLocation.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/System.Windows.Interactivity.dll" ./_Binaries/Debug/SL5/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Debug/System.Windows.Interactivity.xml" ./_Binaries/Debug/SL5/System.Windows.Interactivity.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/System.Windows.Interactivity.dll" ./_Binaries/Release/SL5/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (SL5)/bin/Release/System.Windows.Interactivity.xml" ./_Binaries/Release/SL5/System.Windows.Interactivity.xml
fi

# Win81

if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/WIN81/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/WIN81/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/WIN81/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ./_Binaries/Release/WIN81/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/WIN81/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ./_Binaries/Release/WIN81/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Debug/WIN81/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Debug/WIN81/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Debug/WIN81/GalaSoft.MvvmLight.Extras.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Release/WIN81/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Release/WIN81/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Release/WIN81/GalaSoft.MvvmLight.Extras.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Debug/WIN81/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Debug/WIN81/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Debug/GalaSoft.MvvmLight.Platform.pri" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Debug/GalaSoft.MvvmLight.Platform.pri" ./_Binaries/Debug/WIN81/GalaSoft.MvvmLight.Platform.pri
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Debug/WIN81/GalaSoft.MvvmLight.Platform.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Release/WIN81/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Release/WIN81/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Release/GalaSoft.MvvmLight.Platform.pri" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Release/GalaSoft.MvvmLight.Platform.pri" ./_Binaries/Release/WIN81/GalaSoft.MvvmLight.Platform.pri
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WIN81)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Release/WIN81/GalaSoft.MvvmLight.Platform.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Debug/WIN81/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Debug/WIN81/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Debug/WIN81/Microsoft.Practices.ServiceLocation.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Release/WIN81/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Release/WIN81/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Release/WIN81/Microsoft.Practices.ServiceLocation.xml
fi

# WP81

if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/WP81/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/WP81/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/WP81/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ./_Binaries/Release/WP81/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/WP81/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ./_Binaries/Release/WP81/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Debug/WP81/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Debug/WP81/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Debug/WP81/GalaSoft.MvvmLight.Extras.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Release/WP81/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Release/WP81/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Release/WP81/GalaSoft.MvvmLight.Extras.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (WP81)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WP81)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Debug/WP81/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WP81)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WP81)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Debug/WP81/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WP81)/bin/Debug/GalaSoft.MvvmLight.Platform.pri" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WP81)/bin/Debug/GalaSoft.MvvmLight.Platform.pri" ./_Binaries/Debug/WP81/GalaSoft.MvvmLight.Platform.pri
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WP81)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WP81)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Debug/WP81/GalaSoft.MvvmLight.Platform.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WP81)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WP81)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Release/WP81/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WP81)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WP81)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Release/WP81/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WP81)/bin/Release/GalaSoft.MvvmLight.Platform.pri" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WP81)/bin/Release/GalaSoft.MvvmLight.Platform.pri" ./_Binaries/Release/WP81/GalaSoft.MvvmLight.Platform.pri
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WP81)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WP81)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Release/WP81/GalaSoft.MvvmLight.Platform.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Debug/WP81/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Debug/WP81/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Debug/WP81/Microsoft.Practices.ServiceLocation.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Release/WP81/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Release/WP81/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Release/WP81/Microsoft.Practices.ServiceLocation.xml
fi

# WPSL80

if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/WPSL80/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/WPSL80/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/WPSL80/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ./_Binaries/Release/WPSL80/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/WPSL80/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ./_Binaries/Release/WPSL80/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Debug/WPSL80/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Debug/WPSL80/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Debug/WPSL80/GalaSoft.MvvmLight.Extras.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Release/WPSL80/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Release/WPSL80/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Release/WPSL80/GalaSoft.MvvmLight.Extras.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Debug/WPSL80/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Debug/WPSL80/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Debug/WPSL80/GalaSoft.MvvmLight.Platform.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Release/WPSL80/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Release/WPSL80/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Release/WPSL80/GalaSoft.MvvmLight.Platform.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Debug/WPSL80/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Debug/WPSL80/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Debug/WPSL80/Microsoft.Practices.ServiceLocation.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Release/WPSL80/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Release/WPSL80/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Release/WPSL80/Microsoft.Practices.ServiceLocation.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Debug/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Debug/System.Windows.Interactivity.dll" ./_Binaries/Debug/WPSL80/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Debug/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Debug/System.Windows.Interactivity.xml" ./_Binaries/Debug/WPSL80/System.Windows.Interactivity.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Release/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Release/System.Windows.Interactivity.dll" ./_Binaries/Release/WPSL80/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Release/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL80)/bin/Release/System.Windows.Interactivity.xml" ./_Binaries/Release/WPSL80/System.Windows.Interactivity.xml
fi

# WPSL81

if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.dll" ./_Binaries/Debug/WPSL81/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.pdb" ./_Binaries/Debug/WPSL81/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Debug/GalaSoft.MvvmLight.xml" ./_Binaries/Debug/WPSL81/GalaSoft.MvvmLight.xml
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.dll" ./_Binaries/Release/WPSL81/GalaSoft.MvvmLight.dll
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.pdb" ./_Binaries/Release/WPSL81/GalaSoft.MvvmLight.pdb
fi
if [ -e "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ]
then
  cp "./GalaSoft.MvvmLight (PCL)/bin/Release/GalaSoft.MvvmLight.xml" ./_Binaries/Release/WPSL81/GalaSoft.MvvmLight.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Debug/WPSL81/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Debug/WPSL81/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Debug/WPSL81/GalaSoft.MvvmLight.Extras.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.dll" ./_Binaries/Release/WPSL81/GalaSoft.MvvmLight.Extras.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.pdb" ./_Binaries/Release/WPSL81/GalaSoft.MvvmLight.Extras.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/GalaSoft.MvvmLight.Extras.xml" ./_Binaries/Release/WPSL81/GalaSoft.MvvmLight.Extras.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Debug/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Debug/WPSL81/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Debug/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Debug/WPSL81/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Debug/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Debug/WPSL81/GalaSoft.MvvmLight.Platform.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Release/GalaSoft.MvvmLight.Platform.dll" ./_Binaries/Release/WPSL81/GalaSoft.MvvmLight.Platform.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Release/GalaSoft.MvvmLight.Platform.pdb" ./_Binaries/Release/WPSL81/GalaSoft.MvvmLight.Platform.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Release/GalaSoft.MvvmLight.Platform.xml" ./_Binaries/Release/WPSL81/GalaSoft.MvvmLight.Platform.xml
fi

if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Debug/WPSL81/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Debug/WPSL81/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Debug/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Debug/WPSL81/Microsoft.Practices.ServiceLocation.xml
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.dll" ./_Binaries/Release/WPSL81/Microsoft.Practices.ServiceLocation.dll
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.pdb" ./_Binaries/Release/WPSL81/Microsoft.Practices.ServiceLocation.pdb
fi
if [ -e "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ]
then
  cp "./GalaSoft.MvvmLight.Extras (PCL)/bin/Release/Microsoft.Practices.ServiceLocation.xml" ./_Binaries/Release/WPSL81/Microsoft.Practices.ServiceLocation.xml
fi

if [ -e "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Debug/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Debug/System.Windows.Interactivity.dll" ./_Binaries/Debug/WPSL81/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Debug/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Debug/System.Windows.Interactivity.xml" ./_Binaries/Debug/WPSL81/System.Windows.Interactivity.xml
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Release/System.Windows.Interactivity.dll" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Release/System.Windows.Interactivity.dll" ./_Binaries/Release/WPSL81/System.Windows.Interactivity.dll
fi
if [ -e "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Release/System.Windows.Interactivity.xml" ]
then
  cp "./GalaSoft.MvvmLight.Platform (WPSL81)/bin/Release/System.Windows.Interactivity.xml" ./_Binaries/Release/WPSL81/System.Windows.Interactivity.xml
fi