// ****************************************************************************
// <copyright file="IVersionService.cs" company="GalaSoft Laurent Bugnion">
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
// ****************************************************************************

using System;

namespace GalaSoft.MvvmLight.CheckVersion.Model
{
    public interface IVersionService
    {
        void GetVersionOnClient(Action<Version> callback);

        void GetVersionOnServer(Action<Version> callback);
    }
}