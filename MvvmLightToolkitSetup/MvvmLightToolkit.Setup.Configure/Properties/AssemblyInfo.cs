// ****************************************************************************
// <copyright file="AssemblyInfo.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>1.10.2009</date>
// <project>MvvmLightToolkit.Setup.Configure</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows;

[assembly: AssemblyTitle("MvvmLightToolkit.Setup.Configure")]
[assembly: AssemblyDescription("Custom configuration tool for the MVVM Light Toolkit installer")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("GalaSoft Laurent Bugnion @ http://www.galasoft.ch")]
[assembly: AssemblyProduct("MvvmLightToolkit.Setup.Configure")]
[assembly: AssemblyCopyright("Copyright © 2009 GalaSoft Laurent Bugnion, laurent@galasoft.ch")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]

[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.MainAssembly)]

[assembly: ThemeInfo(
    ResourceDictionaryLocation.None,
    ResourceDictionaryLocation.SourceAssembly)]

[assembly: AssemblyVersion("2.0.0.0")]

[assembly: SuppressMessage(
    "Microsoft.Naming", 
    "CA1703:ResourceStringsShouldBeSpelledCorrectly", 
    MessageId = "ch", 
    Scope = "resource", 
    Target = "MvvmLightToolkit.Setup.Configure.Properties.Resources.resources")]

[assembly: SuppressMessage(
    "Microsoft.Naming", 
    "CA1704:IdentifiersShouldBeSpelledCorrectly", 
    MessageId = "Mvvm")]

[assembly: SuppressMessage(
    "Microsoft.Naming", 
    "CA1704:IdentifiersShouldBeSpelledCorrectly", 
    MessageId = "Mvvm", 
    Scope = "namespace", 
    Target = "MvvmLightToolkit.Setup.Configure")]

[assembly: SuppressMessage(
    "Microsoft.Naming", 
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    MessageId = "Mvvm",
    Scope = "namespace",
    Target = "MvvmLightToolkit.Setup.Configure.Helpers")]

[assembly: SuppressMessage(
    "Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    MessageId = "Mvvm",
    Scope = "namespace",
    Target = "MvvmLightToolkit.Setup.Configure.Log")]

[assembly: SuppressMessage(
    "Microsoft.Naming", 
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    MessageId = "Mvvm",
    Scope = "namespace",
    Target = "MvvmLightToolkit.Setup.Configure.ViewModel")]
