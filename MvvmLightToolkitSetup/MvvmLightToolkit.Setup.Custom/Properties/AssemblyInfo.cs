// ****************************************************************************
// <copyright file="AssemblyInfo.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>27.8.2009</date>
// <project>MvvmLightToolkit.Setup.Custom</project>
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

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("MvvmLightToolkit.Setup.Custom")]
[assembly: AssemblyDescription("Custom actions for the MVVM Light Toolkit installer")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("GalaSoft Laurent Bugnion @ http://www.galasoft.ch")]
[assembly: AssemblyProduct("MvvmLightToolkit.Setup.Custom")]
[assembly: AssemblyCopyright("Copyright © 2009 GalaSoft Laurent Bugnion, laurent@galasoft.ch")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: NeutralResourcesLanguage("en-US", UltimateResourceFallbackLocation.MainAssembly)]

[assembly: AssemblyVersion("2.0.0.*")]

[module: SuppressMessage(
    "Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    Scope = "namespace",
    Target = "MvvmLightToolkit.Setup.Custom",
    MessageId = "Mvvm")]

[module: SuppressMessage(
    "Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    Scope = "namespace",
    Target = "MvvmLightToolkit.Setup.Custom.ViewModel",
    MessageId = "Mvvm")]

[module: SuppressMessage(
    "Microsoft.Naming", 
    "CA1704:IdentifiersShouldBeSpelledCorrectly", 
    Scope = "namespace", 
    Target = "MvvmLightToolkit.Setup.Custom.Log", 
    MessageId = "Mvvm")]

[module: SuppressMessage(
    "Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    Scope = "namespace",
    Target = "MvvmLightToolkit.Setup.Custom.Helpers",
    MessageId = "Mvvm")]

[module: SuppressMessage(
    "Microsoft.Naming", 
    "CA1704:IdentifiersShouldBeSpelledCorrectly", 
    MessageId = "Mvvm")]

[module: SuppressMessage(
    "Microsoft.Design", 
    "CA1020:AvoidNamespacesWithFewTypes", 
    Scope = "namespace", 
    Target = "MvvmLightToolkit.Setup.Custom")]

[module: SuppressMessage(
    "Microsoft.Design", 
    "CA1020:AvoidNamespacesWithFewTypes", 
    Scope = "namespace", 
    Target = "MvvmLightToolkit.Setup.Custom.Helpers")]

[module: SuppressMessage(
    "Microsoft.Design", 
    "CA1020:AvoidNamespacesWithFewTypes", 
    Scope = "namespace", 
    Target = "MvvmLightToolkit.Setup.Custom.Log")]

[module: SuppressMessage(
    "Microsoft.Performance", 
    "CA1823:AvoidUnusedPrivateFields", 
    Scope = "member", 
    Target = "MvvmLightToolkit.Setup.Custom.CustomizeControl.#Cache", 
    Justification = "Target for an animation")]

[module: SuppressMessage(
    "Microsoft.Naming", 
    "CA1703:ResourceStringsShouldBeSpelledCorrectly", 
    Scope = "resource", 
    Target = "MvvmLightToolkit.Setup.Custom.Properties.Resources.resources", 
    MessageId = "mvvm")]

[module: SuppressMessage(
    "Microsoft.Naming", 
    "CA1703:ResourceStringsShouldBeSpelledCorrectly", 
    Scope = "resource", 
    Target = "MvvmLightToolkit.Setup.Custom.Properties.Resources.resources", 
    MessageId = "ch")]

[module: SuppressMessage(
    "Microsoft.Naming", 
    "CA1703:ResourceStringsShouldBeSpelledCorrectly", 
    Scope = "resource", 
    Target = "MvvmLightToolkit.Setup.Custom.Properties.Resources.resources", 
    MessageId = "getstarted")]

[module: SuppressMessage(
    "Microsoft.Naming", 
    "CA1703:ResourceStringsShouldBeSpelledCorrectly", 
    Scope = "resource", 
    Target = "MvvmLightToolkit.Setup.Custom.Properties.Resources.resources", 
    MessageId = "galasoft")]