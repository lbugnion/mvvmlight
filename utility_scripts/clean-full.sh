#!/bin/bash

echo "Cleaning Packages folder"
rm -r GalaSoft.MvvmLight/packages

echo "Cleaning Bin/Obj"
/usr/bin/find . -name obj -type d -exec /bin/rm -rf {} \;
/usr/bin/find . -name bin -type d -exec /bin/rm -rf {} \;

echo "Cleaning Binaries"
rm -r GalaSoft.MvvmLight/_Binaries