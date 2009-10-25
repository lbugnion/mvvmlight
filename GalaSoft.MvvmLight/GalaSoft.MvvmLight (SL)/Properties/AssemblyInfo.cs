// ****************************************************************************
// <copyright file="AssemblyInfo.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>9.6.2009</date>
// <project>GalaSoft.MvvmLight (SL)</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// <LastBaseLevel>BL0009</LastBaseLevel>
// ****************************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("GalaSoft.MvvmLight (Silverlight)")]
[assembly: AssemblyDescription("A lightweight framework to implement Model-View-ViewModel applications in Silverlight")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("GalaSoft Laurent Bugnion")]
[assembly: AssemblyProduct("GalaSoft.MvvmLight (Silverlight)")]
[assembly: AssemblyCopyright("Copyright © GalaSoft Laurent Bugnion 2009")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

[assembly: CLSCompliant(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("a04c60b3-f5c5-45e2-ae6d-e7303893ff49")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
////[assembly: AssemblyVersion("2.0.0.*")]
[assembly: AssemblyFileVersion("3.0.0.0/alpha1")]

// FxCop
[module: SuppressMessage(
    "Microsoft.Naming", 
    "CA1704:IdentifiersShouldBeSpelledCorrectly", 
    MessageId = "Mvvm")]

[module: SuppressMessage(
    "Microsoft.Naming", 
    "CA1704:IdentifiersShouldBeSpelledCorrectly", 
    Scope = "namespace", 
    Target = "GalaSoft.MvvmLight", 
    MessageId = "Mvvm")]

[module: SuppressMessage(
    "Microsoft.Naming", 
    "CA1704:IdentifiersShouldBeSpelledCorrectly", 
    Scope = "namespace", 
    Target = "GalaSoft.MvvmLight.Messaging", 
    MessageId = "Mvvm")]

[module: SuppressMessage(
    "Microsoft.Naming", 
    "CA1704:IdentifiersShouldBeSpelledCorrectly", 
    Scope = "namespace", 
    Target = "GalaSoft.MvvmLight.Command", 
    MessageId = "Mvvm")]

[module: SuppressMessage(
    "Microsoft.Design", 
    "CA1020:AvoidNamespacesWithFewTypes", 
    Scope = "namespace", 
    Target = "GalaSoft.MvvmLight")]

[module: SuppressMessage(
    "Microsoft.Design", 
    "CA1020:AvoidNamespacesWithFewTypes", 
    Scope = "namespace", 
    Target = "GalaSoft.MvvmLight.Command")]

[assembly: SuppressMessage(
    "Microsoft.Design", 
    "CA1020:AvoidNamespacesWithFewTypes", 
    Scope = "namespace", 
    Target = "GalaSoft.MvvmLight.Helpers")]

[assembly: SuppressMessage(
    "Microsoft.Naming", 
    "CA1704:IdentifiersShouldBeSpelledCorrectly", 
    MessageId = "Mvvm", 
    Scope = "namespace", 
    Target = "GalaSoft.MvvmLight.Helpers")]