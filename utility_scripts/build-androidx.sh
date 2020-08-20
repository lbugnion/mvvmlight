# How to build package:

# - Run `cd GalaSoft.MvvmLight`
# - Build `GalaSoft.MvvmLight (PCL).csproj` as Release
# - Build `GalaSoft.MvvmLight.Platform.AndroidX.csproj` as Release
# - Run `sh _gatherbinaries.sh`
# - Run `nuget pack ../NuGet/MvvmLightAndroidX.nuspec`

# N.B. The solution that includes AndroidX project is: `GalaSoft.MvvmLight (VS2017).sln`

sh utility_scripts/clean-full.sh

set -e # This will make the script stop if an error happens

cd GalaSoft.MvvmLight

echo 'Restoring packages for GalaSoft.MvvmLight (PCL)'
nuget \
  restore \
  -PackagesDirectory packages \
  'GalaSoft.MvvmLight (PCL)/GalaSoft.MvvmLight (PCL).csproj'

echo 'Building GalaSoft.MvvmLight (PCL)'
msbuild \
  /t:Build \
  /p:Configuration='Release' \
  'GalaSoft.MvvmLight (PCL)/GalaSoft.MvvmLight (PCL).csproj'

echo 'Restoring packages for GalaSoft.MvvmLight.AndroidX'
nuget \
  restore \
  -PackagesDirectory packages \
  'GalaSoft.MvvmLight.AndroidX/GalaSoft.MvvmLight.Platform.AndroidX.csproj'

echo 'Building GalaSoft.MvvmLight.AndroidX'
msbuild \
  /t:Build \
  /p:Configuration='Release' \
  'GalaSoft.MvvmLight.AndroidX/GalaSoft.MvvmLight.Platform.AndroidX.csproj'

sh _gatherbinaries.sh

nuget pack ../NuGet/MvvmLightAndroidX.nuspec