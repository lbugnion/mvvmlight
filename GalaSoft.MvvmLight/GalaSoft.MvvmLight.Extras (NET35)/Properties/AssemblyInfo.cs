// ****************************************************************************
// <copyright file="AssemblyInfo.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2012
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>3.11.2009</date>
// <project>GalaSoft.MvvmLight.Extras</project>
// <web>http://www.galasoft.ch</web>
// <license>
// See license.txt in this project or http://www.galasoft.ch/license_MIT.txt
// </license>
// <LastBaseLevel>BL0020</LastBaseLevel>
// ****************************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;

#if !WIN8
using System.Windows.Markup;
#endif

[assembly: AssemblyTitle("GalaSoft.MvvmLight.Extras")]
[assembly: AssemblyDescription("Extras components to implement Model-View-ViewModel applications in WPF, Silverlight and Windows Phone 7")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("GalaSoft Laurent Bugnion @ http://www.galasoft.ch")]
[assembly: AssemblyProduct("GalaSoft.MvvmLight.Extras")]
[assembly: AssemblyCopyright("Copyright © GalaSoft Laurent Bugnion 2009-2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

#if !WIN8
[assembly: XmlnsDefinition("http://www.galasoft.ch/mvvmlight", "GalaSoft.MvvmLight.Command")]
#endif

[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]

////[assembly: AssemblyVersion("4.0.20.*")]
[assembly: AssemblyFileVersion("4.0.20.0/beta1")]

// FxCop
[module: SuppressMessage("Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    MessageId = "Mvvm")]

[module: SuppressMessage("Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    Scope = "namespace",
    Target = "GalaSoft.MvvmLight.Command",
    MessageId = "Mvvm")]

[module: SuppressMessage("Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    Scope = "namespace",
    Target = "GalaSoft.MvvmLight.Threading",
    MessageId = "Mvvm")]
