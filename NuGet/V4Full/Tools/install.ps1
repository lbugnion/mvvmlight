param($installPath, $toolsPath, $package, $project)

# find the App.xaml file 
$appxaml = $project.ProjectItems | where {$_.Name -eq "App.xaml"}
$appxamlPath = ($appxaml.Properties | where {$_.Name -eq "LocalPath"}).Value

# find the CSPROJ file 
$projectPath = ($project.Properties | where {$_.Name -eq "LocalPath"}).Value + $project.Name + ".csproj"

$namespace = $project.Properties.Item("RootNamespace").Value

# DEBUG ONLY
#$namespace = "PhoneApp1"
#$projectPath = "D:\temp\PhoneApp7\PhoneApp1\PhoneApp1.csproj"
#$appxamlPath = "D:\temp\PhoneApp7\PhoneApp1\App.xaml"
# DEBUG ONLY

$projectXml = New-Object xml
$projectXml.Load($projectPath)

$propertyGroups = $projectXml.SelectNodes("//*") | where { $_.Name -eq "PropertyGroup" }

$found = "Nothing"

foreach ($propertyGroup in $propertyGroups)
{
    $targetFrameworkProfile = $propertyGroup.SelectNodes("//*") | where {$_.Name -eq "TargetFrameworkProfile" }

    if ($targetFrameworkProfile -ne $null)
    {
        if ($targetFrameworkProfile.InnerText -eq "WindowsPhone71")
        {
            $found = "wp71"
            break
        }
    }

    $targetFrameworkIdentifier = $propertyGroup.SelectNodes("//*") | where {$_.Name -eq "TargetFrameworkIdentifier" }

    if ($targetFrameworkIdentifier -ne $null)
    {
        if ($targetFrameworkIdentifier.InnerText -eq "WindowsPhone")
        {
            $found = "wp8"
            break
        }

        if ($targetFrameworkIdentifier.InnerText -eq "Silverlight")
        {
            $version = $propertyGroup.SelectNodes("//*") | where {$_.Name -eq "TargetFrameworkVersion" }

            if ($version -ne $null)
            {
                if ($version.InnerText -eq "v4.0")
                {
                    $found = "sl4"
                    break
                }

                if ($version.InnerText -eq "v5.0")
                {
                    $found = "sl5"
                    break
                }
            }

            $found = "sl"
            break
        }
    }

    $outputType = $propertyGroup.SelectNodes("//*") | where {$_.Name -eq "OutputType" }

    if ($outputType -ne $null)
    {
        if ($outputType.InnerText -eq "AppContainerExe")
        {
            $found = "win8"
            break
        }

        if ($outputType.InnerText -eq "WinExe")
        {
            $version = $propertyGroup.SelectNodes("//*") | where {$_.Name -eq "TargetFrameworkVersion" }

            if ($version -ne $null)
            {
                if ($version.InnerText -eq "v3.5")
                {
                    $found = "wpf35"
                    break
                }

                if ($version.InnerText -eq "v4.0")
                {
                    $found = "wpf4"
                    break
                }

                if ($version.InnerText -eq "v4.5")
                {
                    $found = "wpf45"
                    break
                }
            }

            $found = "wpf"
            break
        }
    }
}

#Write-Host $found
#break
 
# load App.xaml as XML 
$appXamlXml = New-Object xml 
$appXamlXml.Load($appxamlPath)

#$comment = $appXamlXml.CreateComment($found)
#$appXamlXml.AppendChild($comment)

#$comment2 = $appXamlXml.CreateComment($projectPath)
#$appXamlXml.AppendChild($comment2)
 
$resources = $appXamlXml.SelectNodes("//*") | where { $_.Name -eq "Application.Resources" }

if ($resources -eq $null)
{
    $resources = $appXamlXml.CreateNode("element", "Application.Resources", "http://schemas.microsoft.com/winfx/2006/xaml/presentation")
    $app = $appXamlXml.SelectNodes("//*") | where { $_.Name -eq "Application" }
    
    if ($app -eq $null)
    {
        break
    }

    $app.AppendChild($resources)
}

$xmlnsPrefix = "clr-namespace:"

if ($found -eq "win8")
{
    $xmlnsPrefix = "using:"
}

$vml = $appXamlXml.CreateNode("element", "vm:ViewModelLocator", $xmlnsPrefix + $namespace + ".ViewModel")
$vml.SetAttribute("Key", "http://schemas.microsoft.com/winfx/2006/xaml", "Locator")

if ($found -ne "win8")
{
    $app = $appXamlXml.ChildNodes | where { $_.Name -eq "Application" }

    # Check presence of design time XMLNS
    $dWasFound = $app.HasAttribute("xmlns:d")

    if (!$dWasFound)
    {
        $app.SetAttribute("xmlns:d", "http://schemas.microsoft.com/expression/blend/2008")
    }

    # Check presence of Ignorable attribute on Application element
    $ignorable = $app.GetAttribute("Ignorable", "http://schemas.openxmlformats.org/markup-compatibility/2006")
    
    if ($ignorable -ne "")
    {
        $allIgnorables = $ignorable.Split(' ')
        $dWasFound = "False"

        foreach ($ign in $allIgnorables)
        {
            if ($ign -eq "d")
            {
                $dWasFound = "True"
            }
        }

        if ($dWasFound -eq "False")
        {
            $app.SetAttribute("Ignorable", "http://schemas.openxmlformats.org/markup-compatibility/2006", $ignorable + " d")
        }
    }
    else
    {
        $app.SetAttribute("Ignorable", "http://schemas.openxmlformats.org/markup-compatibility/2006", "d")
    }

    $attribute = $appXamlXml.CreateAttribute("d", "IsDataSource", "http://schemas.microsoft.com/expression/blend/2008");
    $attribute.Value = "True";
    $vml.Attributes.Append($attribute)
}

$mergedDictionaries = $resources.SelectNodes("//*") | where { $_.Name -eq "ResourceDictionary" }

if ($mergedDictionaries -eq $null)
{
    $resources.AppendChild($vml)
}
else
{
    $mergedDictionaries[0].AppendChild($vml)
}

$appXamlXml.Save($appxamlPath)
