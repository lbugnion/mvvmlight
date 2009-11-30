// ****************************************************************************
// <copyright file="AssemblyInfo.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009
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
// <LastBaseLevel>BL0011</LastBaseLevel>
// ****************************************************************************

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("GalaSoft.MvvmLight.Extras (Silverlight)")]
[assembly: AssemblyDescription("Extras components to implement Model-View-ViewModel applications in Silverlight")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("GalaSoft Laurent Bugnion @ http://www.galasoft.ch")]
[assembly: AssemblyProduct("GalaSoft.MvvmLight.Extras (Silverlight)")]
[assembly: AssemblyCopyright("Copyright © GalaSoft Laurent Bugnion 2009")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: CLSCompliant(true)]

[assembly: Guid("17b56ac0-7c71-4fbe-ab58-8283639bd7c9")]

////[assembly: AssemblyVersion("3.0.0.*")]
[assembly: AssemblyFileVersion("3.0.0.0/alpha3")]

// FxCop
[module: SuppressMessage("Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    MessageId = "Mvvm")]

[module: SuppressMessage("Microsoft.Naming",
    "CA1704:IdentifiersShouldBeSpelledCorrectly",
    Scope = "namespace",
    Target = "GalaSoft.MvvmLight.Command",
    MessageId = "Mvvm")]
