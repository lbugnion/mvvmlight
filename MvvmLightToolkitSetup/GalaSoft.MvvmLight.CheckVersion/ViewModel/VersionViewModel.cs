// ****************************************************************************
// <copyright file="VersionViewModel.cs" company="GalaSoft Laurent Bugnion">
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
using GalaSoft.MvvmLight.CheckVersion.Properties;

namespace GalaSoft.MvvmLight.CheckVersion.ViewModel
{
    public class VersionViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="IsInError" /> property's name.
        /// </summary>
        public const string IsInErrorPropertyName = "IsInError";

        /// <summary>
        /// The <see cref="VersionString" /> property's name.
        /// </summary>
        public const string VersionStringPropertyName = "VersionString";

        public static readonly Version Empty = new Version("0.0.0.0");

        private readonly Version _model;

        public VersionViewModel(Version model)
        {
            _model = model;
        }

        public bool IsInError
        {
            get
            {
                return Model == null;
            }
        }

        public Version Model
        {
            get
            {
                return _model;
            }
        }

        /// <summary>
        /// Gets the VersionString property.
        /// </summary>
        public string VersionString
        {
            get
            {
                if (Model == null)
                {
                    return Resources.ErrorGettingVersion;
                }

                if (Model == Empty)
                {
                    return Resources.VersionNotAvailable;
                }

                return "V" + Model.Major
                       + "." + Model.Minor
                       + "." + Model.Build;
            }
        }
    }
}