// ****************************************************************************
// <copyright file="AssemblyInfo.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>12.9.2009</date>
// <project>GalaSoft.MvvmLight.CheckVersion</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// <LastBaseLevel>BL0002</LastBaseLevel>
// ****************************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows;

[assembly: AssemblyTitle("GalaSoft.MvvmLight.CheckVersion")]
[assembly: AssemblyDescription("Checks the version of the MVVM Light Toolkit installed on the current computer and compares it to the version on the server.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Laurent Bugnion (GalaSoft)")]
[assembly: AssemblyProduct("GalaSoft.MvvmLight.CheckVersion")]
[assembly: AssemblyCopyright("Copyright © GalaSoft Laurent Bugnion 2009")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]

[assembly: NeutralResourcesLanguage("en-US",
    UltimateResourceFallbackLocation.MainAssembly)]

[assembly: ThemeInfo(ResourceDictionaryLocation.None,
    ResourceDictionaryLocation.SourceAssembly)]

[assembly: AssemblyVersion("1.0.1.*")]

[module: SuppressMessage("Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    MessageId = "Mvvm")]

[module: SuppressMessage("Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    Scope = "namespace",
    Target = "GalaSoft.MvvmLight",
    MessageId = "Mvvm")]

[module: SuppressMessage("Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    Scope = "namespace",
    Target = "GalaSoft.MvvmLight.CheckVersion",
    MessageId = "Mvvm")]

[module: SuppressMessage("Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    Scope = "namespace",
    Target = "GalaSoft.MvvmLight.CheckVersion.Model",
    MessageId = "Mvvm")]

[module: SuppressMessage("Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    Scope = "namespace",
    Target = "GalaSoft.MvvmLight.CheckVersion.ViewModel",
    MessageId = "Mvvm")]